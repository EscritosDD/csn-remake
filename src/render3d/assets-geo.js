import { SKIRMISH_GEO } from '../data/maps.js';
import { toonGrad3, box3, makeContactShadow3 } from './scene.js';
import { TEAM_A_HEX } from './env.js';

export function skState(theme){return SKIRMISH_GEO[theme]||null;}

export function loadSkirmishTop(theme){
  const st=skState(theme);
  if(!st||st.topImg||st.topFailed)return;
  const im=new Image();
  im.onload=()=>{st.topImg=im;st.topReady=true;if(G)draw();};
  im.onerror=()=>{st.topFailed=true;};
  im.src=st.top;
}

export function loadSkirmishGeo(theme){
  const st=skState(theme);
  if(!st||st.ready||st.loading||typeof THREE==='undefined')return;
  st.loading=true;
  const texLoad=src=>new Promise((res,rej)=>{new THREE.TextureLoader().load(src,t=>{t.colorSpace=THREE.SRGBColorSpace;t.anisotropy=4;res(t);},undefined,rej);});
  Promise.all([
    fetch(st.bin).then(r=>{if(!r.ok)throw new Error('bin');return r.arrayBuffer();}),
    texLoad(st.atlas[0]),
    texLoad(st.atlas[1])
  ]).then(([buf,t1,t2])=>{
    const dv=new DataView(buf);
    const hlen=dv.getUint32(0,true);
    const header=JSON.parse(new TextDecoder().decode(new Uint8Array(buf,4,hlen)));
    const nv=header.verts;
    let off=4+hlen;
    st.pos=new Float32Array(buf,off,nv*3);off+=nv*3*4;
    const mn=[Infinity,Infinity,Infinity],mx=[-Infinity,-Infinity,-Infinity];
    for(let i=0;i<st.pos.length;i+=3)for(let k=0;k<3;k++){mn[k]=Math.min(mn[k],st.pos[i+k]);mx[k]=Math.max(mx[k],st.pos[i+k]);}
    st.bounds={min:mn,max:mx};
    st.uv=new Float32Array(buf,off,nv*2);off+=nv*2*4;
    const nidx=header.groups.reduce((a,g)=>a+g.count,0);
    st.idx=new Uint32Array(buf,off,nidx);
    st.groups=header.groups;st.scale=header.scale||st.scale;
    st.tex=[t1,t2];st.ready=true;st.loading=false;
    if(G&&T3&&VIEW_MODE==='3d'&&G.map.theme===theme)build3DWorld();
  }).catch(()=>{st.loading=false;});
}

export function buildSkirmishGeo3(theme){
  const st=skState(theme);
  if(!st||!st.ready)return null;
  if(!st.geo){
    const g=new THREE.BufferGeometry();
    g.setAttribute('position',new THREE.BufferAttribute(st.pos,3));
    g.setAttribute('uv',new THREE.BufferAttribute(st.uv,2));
    g.setIndex(new THREE.BufferAttribute(st.idx,1));
    st.groups.forEach(gr=>g.addGroup(gr.start,gr.count,gr.mat));
    g.computeVertexNormals();
    st.geo=g;
  }
  const mats=st.tex.map(t=>{const gt=toonGrad3();if(gt&&THREE.MeshToonMaterial)return new THREE.MeshToonMaterial({color:0xffffff,map:t,gradientMap:gt});return new THREE.MeshStandardMaterial({color:0xffffff,map:t,roughness:0.95,metalness:0.02});});
  const mesh=new THREE.Mesh(st.geo,mats);
  if(NATIVE_GRID&&st.bounds){
    const sx=W/(st.bounds.max[0]-st.bounds.min[0]),sz=H/(st.bounds.max[2]-st.bounds.min[2]);
    mesh.scale.set(sx,(sx+sz)/2,sz);
    mesh.position.set(-(st.bounds.min[0]+st.bounds.max[0])*sx/2,0.02,-(st.bounds.min[2]+st.bounds.max[2])*sz/2);
  } else {
    mesh.scale.setScalar(st.scale);
    mesh.position.y=0.02;
  }
  mesh.receiveShadow=true;
  return mesh;
}

export function makeDrone3(){
  const g=new THREE.Group();
  const contactSh=makeContactShadow3(0.46,-0.36);if(contactSh)g.add(contactSh);
  g.add(box3(0.52,0.16,0.52,'#3a4148',0,0,0,0.5));
  g.add(box3(0.3,0.07,0.3,'#f2b234',0,0.11,0,0.5));
  g.add(box3(0.12,0.08,0.12,'#23272c',0.3,-0.02,0,0.5));
  const rotors=[];
  [[-0.3,-0.3],[0.3,-0.3],[-0.3,0.3],[0.3,0.3]].forEach(c=>{
    const arm=box3(0.22,0.03,0.05,'#22262b',c[0]*0.82,0.05,c[1]*0.82,0.5);
    arm.rotation.y=Math.atan2(c[1],c[0]);g.add(arm);
    const rot=new THREE.Group();rot.position.set(c[0],0.1,c[1]);
    rot.add(box3(0.3,0.015,0.045,'#c7ccd1',0,0,0,0.4));
    rot.add(box3(0.045,0.015,0.3,'#c7ccd1',0,0,0,0.4));
    g.add(rot);rotors.push(rot);
  });
  const light=new THREE.Mesh(new THREE.SphereGeometry(0.05,10,10),new THREE.MeshBasicMaterial({color:0xffb03a,transparent:true,opacity:0.9}));
  light.position.set(-0.2,0.06,0);g.add(light);
  const ring=new THREE.Mesh(new THREE.TorusGeometry(0.4,0.018,8,36),new THREE.MeshBasicMaterial({color:TEAM_A_HEX}));
  ring.rotation.x=Math.PI/2;ring.position.y=-0.34;g.add(ring);
  g.userData={rotors:rotors,light:light};
  return g;
}
