'use strict';
const fs=require('node:fs');

const align4=value=>(value+3)&~3;

function makeTestGLB(){
  const positions=new Float32Array([-0.4,0,0,0.4,0,0,0,1.2,0]);
  const joints=new Uint16Array([0,0,0,0]);
  const weights=new Float32Array([1,0,0,0]);
  const indices=new Uint16Array([0,1,2]);
  const inverse=new Float32Array([1,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1]);
  const times=new Float32Array([0,1]);
  const rotations=new Float32Array([0,0,0,1,0,0,0,1]);
  const views=[];
  let cursor=0;
  const chunks=[];
  const add=(typedArray,target)=>{
    const bytes=Buffer.from(typedArray.buffer,typedArray.byteOffset,typedArray.byteLength);
    const byteOffset=cursor;
    views.push({buffer:0,byteOffset,byteLength:bytes.length,target});
    chunks.push(bytes);cursor+=bytes.length;
    const pad=(4-bytes.length%4)%4;
    if(pad){chunks.push(Buffer.alloc(pad));cursor+=pad;}
    return views.length-1;
  };
  const positionView=add(positions,34962);
  const jointView=add(joints,34962);
  const weightView=add(weights,34962);
  const indexView=add(indices,34963);
  const inverseView=add(inverse,0);
  const timeView=add(times,0);
  const rotationView=add(rotations,0);
  const bin=Buffer.concat(chunks);
  const json={
    asset:{version:'2.0',generator:'csn-test'},
    scene:0,
    scenes:[{nodes:[0]}],
    nodes:[{name:'TestRoot',children:[1]},{name:'TestMesh',mesh:0,skin:0}],
    meshes:[{name:'TestTriangle',primitives:[{attributes:{POSITION:positionView,JOINTS_0:jointView,WEIGHTS_0:weightView},indices:indexView,material:0}]}],
    skins:[{joints:[0],inverseBindMatrices:inverseView}],
    materials:[{name:'TestMaterial',pbrMetallicRoughness:{baseColorFactor:[1,1,1,1],metallicFactor:0,roughnessFactor:1},alphaMode:'OPAQUE',doubleSided:false}],
    animations:[{name:'idle',samplers:[{input:timeView,output:rotationView,interpolation:'LINEAR'}],channels:[{sampler:0,target:{node:0,path:'rotation'}}]}],
    accessors:[
      {bufferView:positionView,componentType:5126,count:3,type:'VEC3',min:[-0.4,0,0],max:[0.4,1.2,0]},
      {bufferView:jointView,componentType:5123,count:1,type:'VEC4'},
      {bufferView:weightView,componentType:5126,count:1,type:'VEC4'},
      {bufferView:indexView,componentType:5123,count:3,type:'SCALAR'},
      {bufferView:inverseView,componentType:5126,count:1,type:'MAT4'},
      {bufferView:timeView,componentType:5126,count:2,type:'SCALAR',min:[0],max:[1]},
      {bufferView:rotationView,componentType:5126,count:2,type:'VEC4'}
    ],
    bufferViews:views,
    buffers:[{byteLength:bin.length}],
  };
  let jsonText=JSON.stringify(json);
  while(jsonText.length%4)jsonText+=' ';
  const jsonBytes=Buffer.from(jsonText,'utf8');
  const total=12+8+jsonBytes.length+8+bin.length;
  const header=Buffer.alloc(12);
  header.writeUInt32LE(0x46546c67,0);header.writeUInt32LE(2,4);header.writeUInt32LE(total,8);
  const jsonHeader=Buffer.alloc(8);jsonHeader.writeUInt32LE(jsonBytes.length,0);jsonHeader.writeUInt32LE(0x4e4f534a,4);
  const binHeader=Buffer.alloc(8);binHeader.writeUInt32LE(bin.length,0);binHeader.writeUInt32LE(0x004e4942,4);
  return Buffer.concat([header,jsonHeader,jsonBytes,binHeader,bin]);
}

function writeTestGLB(file){
  const buffer=makeTestGLB();
  fs.writeFileSync(file,buffer);
  return file;
}

module.exports={makeTestGLB,writeTestGLB};
