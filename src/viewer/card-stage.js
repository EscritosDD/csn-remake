let stage=null,builder=null,onActivate=null,onInspect=null,onZoom=null,activeBox=null,activeSpec=null;
let zoom=1,paused=false,rendering=false,restPose=null,retryAt=0,pumping=false,observer=null;
const cards=new Map(),bound=new Set(),queue=[];
const thumbs=new Map();
const releaseTree=root=>{
  if(!root||!root.traverse)return;
  root.traverse(object=>{
    if(!object.userData||!object.userData.glbOwned)return;
    const geometry=object.geometry;
    if(geometry&&geometry.userData&&geometry.userData.glbOwned&&typeof geometry.dispose==='function')geometry.dispose();
    const materials=Array.isArray(object.material)?object.material:[object.material];
    materials.forEach(material=>{
      if(!material||!material.userData||!material.userData.glbOwned||typeof material.dispose!=='function')return;
      for(const key in material){const value=material[key];if(value&&value.isTexture&&value.userData&&value.userData.glbOwned&&typeof value.dispose==='function')value.dispose();}
      material.dispose();
    });
  });
};

function clampZoom(value){return Math.max(1,Math.min(2.5,+value||1));}

function updateCamera(){
  if(!stage)return;
  stage.camera.position.set(0,stage.baseDistance*0.22,stage.baseDistance/zoom);
  stage.camera.lookAt(0,0,0);
}

export function getCardStage(){return stage;}
export function stageZoom(){return zoom;}
export function activeCard(){return {box:activeBox,spec:activeSpec};}

export function setStageBaseDistance(value){
  if(!stage)return;
  stage.baseDistance=Math.max(0.4,+value||3);
  updateCamera();
}

export function setStageZoom(value,notify){
  zoom=clampZoom(value);
  updateCamera();
  if(notify!==false&&typeof onZoom==='function')onZoom(zoom);
}

export function setCardStageCallbacks(callbacks){
  if(callbacks&&typeof callbacks.onActivate==='function')onActivate=callbacks.onActivate;
  if(callbacks&&typeof callbacks.onInspect==='function')onInspect=callbacks.onInspect;
  if(callbacks&&typeof callbacks.onZoom==='function')onZoom=callbacks.onZoom;
}

export function setCardRestPose(fn){restPose=typeof fn==='function'?fn:null;}
export function isCardStagePaused(){return paused;}
export function isCardStageRendering(){return rendering;}
export function setCardStagePaused(value){
  paused=!!value;
  if(!paused)pump();
}

export function unmountStage(){
  if(activeBox&&stage&&stage.renderer.domElement.parentNode===activeBox)activeBox.removeChild(stage.renderer.domElement);
  activeBox=null;activeSpec=null;
}

export function setCardModelBuilder(fn){
  builder=typeof fn==='function'?fn:null;
  if(builder)pump();
}

export function ensureCardStage(stageEl){
  if(stage)return stage;
  if(typeof THREE==='undefined')return null;
  try{
    const renderer=new THREE.WebGLRenderer({antialias:true,alpha:true,preserveDrawingBuffer:true});
    renderer.setPixelRatio(Math.min(window.devicePixelRatio||1,2));
    renderer.setClearColor(0x11150f,0);
    renderer.domElement.classList.add('card-stage-canvas');
    const scene=new THREE.Scene();
    scene.add(new THREE.HemisphereLight(0xe7f0d9,0x30372b,2));
    const key=new THREE.DirectionalLight(0xffedc2,2.4);key.position.set(3,5,4);scene.add(key);
    const fill=new THREE.DirectionalLight(0x9bb8d1,1.1);fill.position.set(-4,2,-3);scene.add(fill);
    const meshyFill=new THREE.DirectionalLight(0xd7ebff,1.8);meshyFill.position.set(-3,2,5);meshyFill.intensity=0;scene.add(meshyFill);
    const meshyRim=new THREE.DirectionalLight(0xffd9a8,2.2);meshyRim.position.set(3,4,-4);meshyRim.intensity=0;scene.add(meshyRim);
    const spin=new THREE.Group();scene.add(spin);
    const platform=new THREE.Mesh(new THREE.CircleGeometry(1,48),new THREE.MeshStandardMaterial({color:0x30382a,roughness:0.9,metalness:0}));platform.rotation.x=-Math.PI/2;scene.add(platform);
    stage={renderer,scene,camera:new THREE.PerspectiveCamera(36,1,0.01,80),spin,platform,meshyFill,meshyRim,baseDistance:3,stageEl:stageEl||null};
    updateCamera();
    return stage;
  }catch(error){
    return null;
  }
}

export function resizeStage(box){
  if(!stage)return;
  const target=box||activeBox||stage.stageEl;
  const width=Math.max(1,Math.round(target&&target.clientWidth||320));
  const height=Math.max(1,Math.round(target&&target.clientHeight||200));
  stage.renderer.setSize(width,height,false);
  stage.camera.aspect=width/height;
  stage.camera.updateProjectionMatrix();
}

export function renderStage(){
  if(!stage)return;
  stage.renderer.render(stage.scene,stage.camera);
}

export function snapshotStage(){
  if(!stage||!activeBox)return null;
  renderStage();
  let url=null;
  try{url=stage.renderer.domElement.toDataURL('image/png');}catch(error){return null;}
  const img=activeBox.querySelector('.card-3d-thumb');
  if(img&&url){img.src=url;img.hidden=false;img.classList.remove('is-loading');}
  return url;
}

function applyThumb(box,url){
  const img=box&&box.querySelector('.card-3d-thumb');
  if(!img||!url)return;
  img.src=url;img.hidden=false;img.classList.remove('is-loading');
}

function thumbKey(spec){
  return [spec.kind,spec.key,spec.skinIndex||0,spec.weapon||'',spec.file||''].join('|');
}

function isGunChild(object,root){
  let node=object.parent;
  while(node&&node!==root){if(node.userData&&node.userData.isViewerGun)return true;node=node.parent;}
  return false;
}

export function computeAccurateBounds(model){
  const bounds=new THREE.Box3();
  const points=[];
  const world=new THREE.Vector3(),base=new THREE.Vector3(),tmp=new THREE.Vector3();
  const boneMatrix=new THREE.Matrix4(),inverse=new THREE.Matrix4();
  model.updateMatrixWorld(true);
  model.traverse(object=>{
    if(!object.visible||!object.isMesh||!object.geometry||!object.geometry.attributes.position)return;
    if(isGunChild(object,model))return;
    if(object.isSkinnedMesh&&object.skeleton)object.skeleton.update();
    const position=object.geometry.attributes.position;
    const skinned=!!(object.isSkinnedMesh&&object.skeleton&&object.skeleton.boneMatrices);
    const native=skinned&&typeof object.getVertexPosition==='function';
    const indices=skinned&&!native?object.geometry.attributes.skinIndex:null;
    const weights=skinned&&!native?object.geometry.attributes.skinWeight:null;
    if(skinned&&!native&&(!indices||!weights))return;
    if(skinned)inverse.copy(object.bindMatrixInverse);
    for(let i=0;i<position.count;i++){
      if(native){object.getVertexPosition(i,world);world.applyMatrix4(object.matrixWorld);}
      else if(skinned){
        base.fromBufferAttribute(position,i).applyMatrix4(object.bindMatrix);
        world.set(0,0,0);
        for(let j=0;j<4;j++){
          const weight=weights.getComponent(i,j);
          if(!weight)continue;
          const boneIndex=indices.getComponent(i,j);
          if(!Number.isFinite(boneIndex)||boneIndex<0)continue;
          boneMatrix.fromArray(object.skeleton.boneMatrices,boneIndex*16);
          tmp.copy(base).applyMatrix4(boneMatrix).multiplyScalar(weight);
          world.add(tmp);
        }
        world.applyMatrix4(inverse).applyMatrix4(object.matrixWorld);
      }else world.fromBufferAttribute(position,i).applyMatrix4(object.matrixWorld);
      if(Number.isFinite(world.x)&&Number.isFinite(world.y)&&Number.isFinite(world.z))points.push([world.x,world.y,world.z]);
    }
  });
  if(!points.length)return bounds;
  let cx=0,cy=0,cz=0;
  for(const point of points){cx+=point[0];cy+=point[1];cz+=point[2];}
  cx/=points.length;cy/=points.length;cz/=points.length;
  const distances=points.map(point=>Math.hypot(point[0]-cx,point[1]-cy,point[2]-cz)).sort((a,b)=>a-b);
  const limit=Math.max((distances[Math.floor(distances.length/2)]||1)*6,0.25);
  for(const point of points){
    if(Math.hypot(point[0]-cx,point[1]-cy,point[2]-cz)>limit)continue;
    bounds.expandByPoint(tmp.set(point[0],point[1],point[2]));
  }
  if(bounds.isEmpty())for(const point of points)bounds.expandByPoint(tmp.set(point[0],point[1],point[2]));
  return bounds;
}

function thumbnailTexturesReady(model){
  let ready=true,hasMap=false;
  model.traverse(object=>{
    if(!object.isMesh||!object.material)return;
    const mats=Array.isArray(object.material)?object.material:[object.material];
    for(const mat of mats){
      if(!mat.map)continue;
      hasMap=true;
      const image=mat.map.image;
      if(!image||image.complete===false)ready=false;
    }
  });
  return hasMap&&ready;
}

function readThumbBBox(renderer){
  const gl=renderer.getContext(),canvas=renderer.domElement;
  const width=canvas.width,height=canvas.height,pixels=new Uint8Array(width*height*4);
  gl.readPixels(0,0,width,height,gl.RGBA,gl.UNSIGNED_BYTE,pixels);
  let non=0,minX=width,maxX=0,minY=height,maxY=0;
  for(let y=0;y<height;y++)for(let x=0;x<width;x++){
    if(pixels[(y*width+x)*4+3]<=8)continue;
    non++;
    if(x<minX)minX=x;
    if(x>maxX)maxX=x;
    if(y<minY)minY=y;
    if(y>maxY)maxY=y;
  }
  if(!non)return null;
  return {x:(minX+maxX)/(2*width),y:(minY+maxY)/(2*height),width:(maxX-minX+1)/width,height:(maxY-minY+1)/height};
}

export function renderThumbnail(spec,model){
  if(!stage||!model||paused||rendering)return null;
  rendering=true;
  const saved=stage.spin.children.slice();
  const savedRotation=stage.spin.rotation.clone();
  const platformVisible=stage.platform.visible;
  const savedFill=stage.meshyFill.intensity;
  const savedRim=stage.meshyRim.intensity;
  const savedCamera={fov:stage.camera.fov,aspect:stage.camera.aspect,baseDistance:stage.baseDistance,position:stage.camera.position.clone()};
  let centered=null,fallbackScale=null;
  try{
    while(stage.spin.children.length){const child=stage.spin.children[0];stage.spin.remove(child);releaseTree(child);}
    if(!spec||!thumbnailTexturesReady(model))return null;
    stage.platform.visible=false;
    stage.meshyFill.intensity=model.userData&&model.userData.meshy?1.8:0;
    stage.meshyRim.intensity=model.userData&&model.userData.meshy?2.2:0;
    stage.spin.rotation.set(0,0,0);
    stage.renderer.clear(true,true,true);
    if(typeof restPose==='function')restPose(model);
    model.updateMatrixWorld(true);
    model.traverse(object=>{if(object.isSkinnedMesh&&object.skeleton)object.skeleton.update();});
    const bounds=computeAccurateBounds(model);
    const center=new THREE.Vector3(),size=new THREE.Vector3();
    bounds.getSize(size);bounds.getCenter(center);
    if(!Number.isFinite(size.x)||Math.max(size.x,size.y,size.z)<0.001)return null;
    let wideFallback=false;
    if(Math.max(size.x,size.y,size.z)>5||center.length()>5){
      fallbackScale=new THREE.Vector3(1.3/size.x,1.3/size.y,1.3/size.z);
      model.scale.multiply(fallbackScale);
      model.updateMatrixWorld(true);
      model.traverse(object=>{if(object.isSkinnedMesh&&object.skeleton)object.skeleton.update();});
      center.set(0,0,0);size.set(0.8,1.3,0.7);wideFallback=true;
    }
    centered=new THREE.Group();
    centered.position.set(-center.x,-center.y,-center.z);
    centered.add(model);
    stage.spin.add(centered);
    stage.spin.rotation.set(spec.kind==='weapons'?0.25:0,-0.55,0);
    centered.updateMatrixWorld(true);
    const troop=spec.kind==='roles';
    const width=troop?320:360,height=troop?260:240;
    stage.renderer.setSize(width,height,false);
    stage.camera.aspect=width/height;
    stage.camera.fov=36;
    stage.camera.updateProjectionMatrix();
    const fovRad=stage.camera.fov*Math.PI/180;
    const dist=Math.min(4,Math.max(1.1,(Math.max(size.y,size.x/stage.camera.aspect)*0.57)/Math.tan(fovRad/2)));
    let viewDist=dist*2.2;
    const target=new THREE.Vector3(),forward=new THREE.Vector3(),right=new THREE.Vector3(),up=new THREE.Vector3();
    stage.camera.position.set(0,viewDist*0.12,viewDist);
    stage.camera.lookAt(target);
    for(let pass=0;pass<4;pass++){
      stage.renderer.clear(true,true,true);
      stage.renderer.render(stage.scene,stage.camera);
      const bbox=readThumbBBox(stage.renderer);
      if(!bbox)continue;
      const halfHeight=Math.tan(fovRad/2)*viewDist,halfWidth=halfHeight*stage.camera.aspect;
      stage.camera.getWorldDirection(forward);
      right.setFromMatrixColumn(stage.camera.matrixWorld,0);
      up.setFromMatrixColumn(stage.camera.matrixWorld,1);
      const offset=right.multiplyScalar((bbox.x*2-1)*halfWidth).add(up.multiplyScalar((bbox.y*2-1)*halfHeight));
      target.add(offset);
      viewDist*=Math.max(wideFallback?1:0.45,Math.min(2.5,Math.max(bbox.width/0.74,bbox.height/0.74)));
      stage.camera.position.copy(target).addScaledVector(forward,-viewDist);
      stage.camera.lookAt(target);
    }
    stage.renderer.clear(true,true,true);
    stage.renderer.render(stage.scene,stage.camera);
    const finalBBox=readThumbBBox(stage.renderer);
    if(!finalBBox||finalBBox.width<0.02||finalBBox.height<0.02)return null;
    const url=stage.renderer.domElement.toDataURL('image/png');
    return url&&url.length>2048?url:null;
  }catch(error){
    return null;
  }finally{
    if(centered)centered.remove(model);
    if(fallbackScale)model.scale.multiply(new THREE.Vector3(1/fallbackScale.x,1/fallbackScale.y,1/fallbackScale.z));
    while(stage.spin.children.length){const child=stage.spin.children[0];stage.spin.remove(child);releaseTree(child);}
    for(const child of saved)stage.spin.add(child);
    stage.spin.rotation.copy(savedRotation);
    stage.platform.visible=platformVisible;
    stage.meshyFill.intensity=savedFill;stage.meshyRim.intensity=savedRim;
    stage.camera.fov=savedCamera.fov;stage.camera.aspect=savedCamera.aspect;
    stage.camera.position.copy(savedCamera.position);stage.camera.updateProjectionMatrix();
    stage.baseDistance=savedCamera.baseDistance;
    updateCamera();resizeStage(activeBox||stage.stageEl);renderStage();
    rendering=false;
  }
}

function retryThumb(task){
  if((task.tries||0)>=30)return;
  task.tries=(task.tries||0)+1;
  queue.push(task);
  retryAt=Date.now()+400;
}

function pump(){
  if(pumping||paused||!builder)return;
  pumping=true;
  (async()=>{
    while(queue.length){
      if(paused||Date.now()<retryAt)break;
      const task=queue.shift();
      if(!task.box||!task.box.isConnected)continue;
      const img=task.box.querySelector('.card-3d-thumb');
      if(img&&img.src&&img.src.indexOf('data:')===0)continue;
      try{
        const model=await builder(task.spec);
        if(paused||!task.box.isConnected)continue;
        const url=model?renderThumbnail(task.spec,model):null;
        if(url){thumbs.set(task.key,url);applyThumb(task.box,url);}
        else retryThumb(task);
      }catch(error){retryThumb(task);}
    }
    pumping=false;
    if(!paused&&queue.length)setTimeout(pump,Math.max(40,retryAt-Date.now()));
  })();
}

function queueThumb(box,spec){
  const key=thumbKey(spec);
  if(thumbs.has(key)){applyThumb(box,thumbs.get(key));return;}
  const existing=queue.find(task=>task.key===key);
  if(existing){
    if(!existing.box||!existing.box.isConnected){existing.box=box;existing.spec=spec;}
    return;
  }
  queue.push({box,spec,key});
  if(!paused)pump();
}

function bindBox(box){
  if(bound.has(box))return;
  bound.add(box);
  box.addEventListener('pointerdown',event=>{
    if(event.button!==undefined&&event.button!==0)return;
    const spec=cards.get(box);
    if(!spec||spec.static)return;
    if(spec.inspect){if(typeof onInspect==='function')onInspect(box,spec);return;}
    if(typeof onActivate==='function')onActivate(box,spec);
    if(!stage)return;
    let lastX=event.clientX,lastY=event.clientY;
    try{box.setPointerCapture(event.pointerId);}catch(error){}
    const move=e=>{
      const dx=e.clientX-lastX,dy=e.clientY-lastY;
      lastX=e.clientX;lastY=e.clientY;
      stage.spin.rotation.y+=dx*0.008;
      stage.spin.rotation.x=Math.max(-0.65,Math.min(0.65,stage.spin.rotation.x+dy*0.006));
      renderStage();
    };
    const end=()=>{
      box.removeEventListener('pointermove',move);box.removeEventListener('pointerup',end);box.removeEventListener('pointercancel',end);
      snapshotStage();
    };
    box.addEventListener('pointermove',move);
    box.addEventListener('pointerup',end);
    box.addEventListener('pointercancel',end);
  });
  box.addEventListener('wheel',event=>{
    const spec=cards.get(box);
    if(!spec||spec.static)return;
    event.preventDefault();
    setStageZoom(zoom+(event.deltaY<0?0.12:-0.12));
    renderStage();
  },{passive:false});
  box.addEventListener('click',event=>{
    const button=event.target.closest('[data-card-zoom]');
    if(!button)return;
    event.stopPropagation();
    setStageZoom(zoom+(+button.dataset.cardZoom||0));
    renderStage();
  });
}

export function registerCardBox(box,spec){
  if(!box||!spec)return;
  const previous=cards.get(box);
  cards.set(box,spec);
  bindBox(box);
  const img=box.querySelector('.card-3d-thumb');
  if(img&&!img.classList.contains('is-loading'))img.classList.add('is-loading');
  if(previous&&thumbKey(previous)!==thumbKey(spec))thumbs.delete(thumbKey(previous));
  queueThumb(box,spec);
  if(observer)observer.observe(box);
}

export function mountStageInto(box,spec){
  if(!stage)return;
  if(activeBox&&activeBox!==box)snapshotStage();
  activeBox=box||null;
  activeSpec=spec||null;
  if(!box)return;
  box.appendChild(stage.renderer.domElement);
  const img=box.querySelector('.card-3d-thumb');
  if(img)img.classList.add('is-hidden');
  resizeStage(box);
  renderStage();
}

export function pruneCardBoxes(){
  for(const box of Array.from(cards.keys())){
    if(box.isConnected)continue;
    cards.delete(box);
    bound.delete(box);
    if(observer)observer.unobserve(box);
  }
}

export function scanCardBoxes(root){
  const scope=root||document;
  pruneCardBoxes();
  if(!observer&&typeof IntersectionObserver!=='undefined'){
    observer=new IntersectionObserver(entries=>{
      for(const entry of entries){
        if(!entry.isIntersecting)continue;
        const spec=cards.get(entry.target);
        if(spec)queueThumb(entry.target,spec);
      }
    },{rootMargin:'160px'});
  }
  scope.querySelectorAll('.card-3d-box[data-card-spec]').forEach(box=>{
    if(box.id==='inspectorStage')return;
    let spec=null;
    try{spec=JSON.parse(box.dataset.cardSpec);}catch(error){return;}
    registerCardBox(box,spec);
  });
}

export function resetCardStage(){
  if(activeBox)snapshotStage();
  activeBox=null;activeSpec=null;
  queue.length=0;
  thumbs.clear();
}
