import fs from 'node:fs';
import path from 'node:path';
import { validateManifest } from '../src/data/catalog-competitive.js';

const MAGIC=0x46546c67;
const JSON_CHUNK=0x4e4f534a;
const BIN_CHUNK=0x004e4942;

function inspectGLB(file){
  const errors=[];
  if(!fs.existsSync(file))return {file,ok:false,errors:['No existe el archivo.']};
  const buffer=fs.readFileSync(file);
  if(buffer.length<20)return {file,ok:false,errors:['Cabecera truncada.']};
  const view=new DataView(buffer.buffer,buffer.byteOffset,buffer.byteLength);
  if(view.getUint32(0,true)!==MAGIC)errors.push('Magic incorrecto.');
  if(view.getUint32(4,true)!==2)errors.push('La versión debe ser 2.');
  const declared=view.getUint32(8,true);
  if(declared>buffer.length)errors.push('Longitud declarada mayor que el archivo.');
  let json=null,binaryLength=0;
  for(let offset=12;offset+8<=buffer.length;){
    const length=view.getUint32(offset,true),type=view.getUint32(offset+4,true);
    if(offset+8+length>buffer.length){errors.push('Chunk truncado.');break;}
    if(type===JSON_CHUNK){try{json=JSON.parse(buffer.toString('utf8',offset+8,offset+8+length));}catch(error){errors.push('JSON inválido: '+error.message);}}
    if(type===BIN_CHUNK)binaryLength=length;
    offset+=8+length+((4-length%4)%4);
  }
  if(!json)errors.push('Falta el chunk JSON.');
  else{
    if(json.asset&&json.asset.version!=='2.0')errors.push('asset.version debe ser 2.0.');
    const nodes=Array.isArray(json.nodes)?json.nodes:[];
    const bufferViews=Array.isArray(json.bufferViews)?json.bufferViews:[];
    const accessors=Array.isArray(json.accessors)?json.accessors:[];
    bufferViews.forEach((entry,index)=>{
      if(!Number.isInteger(entry.byteOffset)||entry.byteOffset<0||entry.byteOffset+entry.byteLength>binaryLength)errors.push('bufferView['+index+'] fuera del BIN.');
    });
    accessors.forEach((entry,index)=>{
      if(!Number.isInteger(entry.bufferView)||!bufferViews[entry.bufferView]){errors.push('accessor['+index+'] sin bufferView válido.');return;}
      const sizes={SCALAR:1,VEC2:2,VEC3:3,VEC4:4,MAT4:16};
      const item=sizes[entry.type];
      const bytes={5120:1,5121:1,5122:2,5123:2,5125:4,5126:4}[entry.componentType];
      if(!item||!bytes){errors.push('accessor['+index+'] tiene type/componentType desconocido.');return;}
      const need=entry.count*item*bytes;
      if(bufferViews[entry.bufferView].byteLength<need)errors.push('accessor['+index+'] excede su bufferView.');
    });
    (json.skins||[]).forEach((skin,index)=>{
      if(!Array.isArray(skin.joints)||!skin.joints.length)errors.push('skin['+index+'] sin joints.');
      skin.joints&&skin.joints.forEach(joint=>{if(!nodes[joint])errors.push('skin['+index+'] referencia un nodo inexistente.');});
    });
    (json.animations||[]).forEach((animation,index)=>{
      const samplers=Array.isArray(animation.samplers)?animation.samplers:[];
      (animation.channels||[]).forEach((channel,channelIndex)=>{
        if(!samplers[channel.sampler])errors.push('animation['+index+'].channel['+channelIndex+'] sin sampler.');
        if(!nodes[channel.target&&channel.target.node])errors.push('animation['+index+'].channel['+channelIndex+'] sin nodo.');
      });
    });
  }
  return {file,ok:errors.length===0,errors,stats:{nodes:(json&&json.nodes||[]).length,meshes:(json&&json.meshes||[]).length,skins:(json&&json.skins||[]).length,animations:(json&&json.animations||[]).length,bytes:buffer.length}};
}

function resolveManifest(arg){
  const candidate=path.resolve(arg||'assets/competitive/manifest.json');
  if(!fs.existsSync(candidate))return {manifest:null,error:'No existe el manifest: '+candidate,file:candidate};
  try{return {manifest:JSON.parse(fs.readFileSync(candidate,'utf8')),error:null,file:candidate};}
  catch(error){return {manifest:null,error:error.message,file:candidate};}
}

function main(){
  const args=process.argv.slice(2);
  const manifestArg=args.find(arg=>arg.endsWith('manifest.json'));
  const resolved=resolveManifest(manifestArg);
  const result={manifest:resolved.file,ok:true,manifestErrors:[],files:[]};
  if(resolved.error)result.manifestErrors.push(resolved.error);
  else{
    const validation=validateManifest(resolved.manifest);
    result.manifestErrors.push(...validation.errors);
    for(const entry of [...(resolved.manifest.chars||[]),...(resolved.manifest.weapons||[])]){
      const file=path.resolve(path.dirname(resolved.file),'..',entry.file);
      result.files.push(inspectGLB(file));
    }
  }
  for(const arg of args){
    if(arg===manifestArg||arg.endsWith('manifest.json'))continue;
    result.files.push(inspectGLB(path.resolve(arg)));
  }
  result.ok=result.manifestErrors.length===0&&result.files.every(file=>file.ok);
  console.log(JSON.stringify(result,null,2));
  process.exitCode=result.ok?0:1;
}

main();
