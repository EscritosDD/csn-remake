export function disposeObject3D(root){
  const geometries=new Set(),materials=new Set(),textures=new Set();
  const collectTexture=value=>{if(value&&value.isTexture)textures.add(value);};
  const collectMaterial=material=>{
    if(!material||materials.has(material))return;
    materials.add(material);
    for(const key in material){
      const value=material[key];
      if(Array.isArray(value))value.forEach(collectTexture);
      else collectTexture(value);
    }
    if(material.uniforms)for(const key in material.uniforms)collectTexture(material.uniforms[key]&&material.uniforms[key].value);
  };
  root&&root.traverse&&root.traverse(object=>{
    if(object.geometry)geometries.add(object.geometry);
    const material=object.material;
    if(Array.isArray(material))material.forEach(collectMaterial);
    else collectMaterial(material);
  });
  textures.forEach(texture=>{if(texture.userData&&texture.userData.glbOwned&&!texture.userData.sharedAsset&&typeof texture.dispose==='function')texture.dispose();});
  materials.forEach(material=>{if(material.userData&&material.userData.glbOwned&&typeof material.dispose==='function')material.dispose();});
  geometries.forEach(geometry=>{if(geometry.userData&&geometry.userData.glbOwned&&typeof geometry.dispose==='function')geometry.dispose();});
  return {geometries:geometries.size,materials:materials.size,textures:textures.size};
}

export class AssetCache{
  constructor(options={}){
    this.maxEntries=Math.max(1,options.maxEntries||16);
    this.entries=new Map();
    this.pending=new Map();
  }
  get(key,loader){
    if(this.entries.has(key)){
      const entry=this.entries.get(key);
      this.entries.delete(key);this.entries.set(key,entry);
      return Promise.resolve(entry.value);
    }
    if(this.pending.has(key))return this.pending.get(key);
    const task=Promise.resolve().then(loader).then(value=>{
      this.pending.delete(key);
      this.set(key,value);
      return value;
    },error=>{this.pending.delete(key);throw error;});
    this.pending.set(key,task);
    return task;
  }
  set(key,value){
    if(this.entries.has(key))this.entries.delete(key);
    this.entries.set(key,{value});
    while(this.entries.size>this.maxEntries){
      const oldest=this.entries.keys().next().value;
      const entry=this.entries.get(oldest);
      this.entries.delete(oldest);
      if(entry&&entry.value&&entry.value.scene)disposeObject3D(entry.value.scene);
      else if(entry&&entry.value&&typeof entry.value.dispose==='function')entry.value.dispose();
    }
    return value;
  }
  has(key){return this.entries.has(key)||this.pending.has(key);}
  delete(key){
    this.pending.delete(key);
    const entry=this.entries.get(key);
    if(!entry)return false;
    this.entries.delete(key);
    if(entry.value&&entry.value.scene)disposeObject3D(entry.value.scene);
    else if(entry.value&&typeof entry.value.dispose==='function')entry.value.dispose();
    return true;
  }
  clear(){
    const keys=[...this.entries.keys()];
    keys.forEach(key=>this.delete(key));
    this.pending.clear();
    return keys.length;
  }
  get size(){return this.entries.size+this.pending.size;}
}

export const COMPETITIVE_ASSETS=new AssetCache({maxEntries:16});
