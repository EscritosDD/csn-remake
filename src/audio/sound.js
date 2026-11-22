import { lsGet } from '../core/storage.js';
import { DMR_WEAPONS, WEAPON_SFX, weaponSfxFile } from '../data/weapons.js';

import { CHAR_VOICE } from '../data/cast.js';
import { VOICE_FILES } from '../data/roles.js';

export const LS_SOUND='radsoldiers_sound';

export let AC=null, soundOn=(lsGet(LS_SOUND)!=='0');

export function audioCtx(){if(!soundOn)return null;try{if(!AC)AC=new (window.AudioContext||window.webkitAudioContext)();if(AC.state==='suspended')AC.resume();return AC;}catch(e){return null;}}

export function tone(freq,dur,type,vol,slideTo){const ac=audioCtx();if(!ac)return;const o=ac.createOscillator(),g=ac.createGain();o.type=type||'square';o.frequency.setValueAtTime(freq,ac.currentTime);if(slideTo)o.frequency.exponentialRampToValueAtTime(Math.max(30,slideTo),ac.currentTime+dur);g.gain.setValueAtTime(vol||0.05,ac.currentTime);g.gain.exponentialRampToValueAtTime(0.0001,ac.currentTime+dur);o.connect(g);g.connect(ac.destination);o.start();o.stop(ac.currentTime+dur+0.02);}

export function noiseBurst(dur,vol,freqEnd){const ac=audioCtx();if(!ac)return;const len=Math.max(1,(ac.sampleRate*dur)|0);const buf=ac.createBuffer(1,len,ac.sampleRate);const d=buf.getChannelData(0);for(let i=0;i<len;i++)d[i]=(Math.random()*2-1)*(1-i/len);const src=ac.createBufferSource();src.buffer=buf;const f=ac.createBiquadFilter();f.type='lowpass';f.frequency.setValueAtTime(3200,ac.currentTime);f.frequency.exponentialRampToValueAtTime(Math.max(60,freqEnd||300),ac.currentTime+dur);const g=ac.createGain();g.gain.setValueAtTime(vol||0.12,ac.currentTime);g.gain.exponentialRampToValueAtTime(0.0001,ac.currentTime+dur);src.connect(f);f.connect(g);g.connect(ac.destination);src.start();}

export function sfx(kind){if(!soundOn)return;try{
  if(kind==='shoot'){noiseBurst(0.12,0.10,900);tone(160,0.08,'square',0.03,70);}
  else if(kind==='boom'){noiseBurst(0.5,0.22,120);tone(70,0.4,'sine',0.16,34);}
  else if(kind==='place'){tone(190,0.07,'square',0.05,120);setTimeout(()=>tone(1250,0.05,'square',0.03),70);}
  else if(kind==='flash'){noiseBurst(0.16,0.15,2600);tone(2600,0.24,'sine',0.10,880);setTimeout(()=>tone(1750,0.13,'sine',0.05,660),45);}
  else if(kind==='turn'){tone(520,0.09,'triangle',0.05);setTimeout(()=>tone(660,0.1,'triangle',0.05),95);}
  else if(kind==='win'){[523,659,784,1046].forEach((f,i)=>setTimeout(()=>tone(f,0.16,'triangle',0.06),i*120));}
  else if(kind==='lose'){[392,330,262,196].forEach((f,i)=>setTimeout(()=>tone(f,0.16,'triangle',0.06),i*120));}
 }catch(e){}}

export const AU_BASE='assets/audio/';

export let AU_AMBIENT=null;

const AUDIO_BUFFERS=new Map(),AUDIO_PENDING=new Map(),AUDIO_TEMPLATES=new Map();

function auBuffer(path){
  const ac=audioCtx();if(!ac)return null;
  if(AUDIO_BUFFERS.has(path))return AUDIO_BUFFERS.get(path);
  if(AUDIO_PENDING.has(path))return null;
  const pending=fetch(AU_BASE+path).then(r=>{if(!r.ok)throw new Error(path);return r.arrayBuffer();}).then(data=>new Promise((resolve,reject)=>{const req=ac.decodeAudioData(data,resolve,reject);if(req&&req.then)req.then(resolve,reject);}))
    .then(buffer=>{AUDIO_BUFFERS.set(path,buffer);AUDIO_PENDING.delete(path);return buffer;}).catch(()=>{AUDIO_PENDING.delete(path);return null;});
  AUDIO_PENDING.set(path,pending);return null;
}

export function auPlay(path,vol,loop){
  if(!soundOn)return null;
  const level=vol==null?0.6:vol;
  try{
    const ac=audioCtx(),buffer=ac&&auBuffer(path);
    if(buffer){
      const src=ac.createBufferSource(),gain=ac.createGain();
      src.buffer=buffer;src.loop=!!loop;gain.gain.value=level;src.connect(gain);gain.connect(ac.destination);src.start();return src;
    }
    let a=AUDIO_TEMPLATES.get(path);
    if(!a){a=new Audio(AU_BASE+path);AUDIO_TEMPLATES.set(path,a);}
    try{a.pause();a.currentTime=0;}catch(e){}
    a.volume=level;a.loop=!!loop;a.play().catch(()=>{});return a;
  }catch(e){return null;}
}

export function auWeapon(cat,weaponName){
  const f=weaponSfxFile(cat,weaponName);if(f)auPlay('sfx/weapons/'+f,f.endsWith('.wav')?0.35:0.45);
}


export function auClick(){auPlay('sfx/ui/ui_click.mp3',0.35);}

export function auVoice(un,ev,vol){
  if(!un||!un.role)return;
  let folder=null;
  try{const nm=un.name||(globalThis.charNameFor ? globalThis.charNameFor(un.role) : '');if(nm&&CHAR_VOICE[nm])folder=CHAR_VOICE[nm];}catch(e){}
  if(!folder)folder=VOICE_FILES[un.role];
  if(!folder)return;
  auPlay('voice/'+folder+'/'+ev+'.mp3',vol==null?0.5:vol);
}

export const AMBIENT_FILE={astillero:'ambient/skirmish04/amb0.mp3',platform:'ambient/skirmish04/amb0.mp3',cruce:'ambient/rotonda/amb0.mp3',depot:'ambient/skirmish03/amb0.mp3',terminal:'ambient/skirmish03/amb0.mp3'};

export function auAmbient(theme){if(AU_AMBIENT){try{AU_AMBIENT.pause();}catch(e){}AU_AMBIENT=null;}const f=auPlay(AMBIENT_FILE[theme]||('ambient/'+theme+'/amb0.mp3'),0.20,true);AU_AMBIENT=f;}

export const MUSIC_TRACKS=['game_subtle_01','game_subtle_02','game_subtle_03','game_subtle_04','game_subtle_05','game_subtle_06','game_subtle_07'];

export let AU_MUSIC=null;

export function auMusicStart(){
  if(!soundOn)return;
  auMusicStop();
  const t=MUSIC_TRACKS[Math.floor(Math.random()*MUSIC_TRACKS.length)];
  AU_MUSIC=auPlay('music/'+t+'.mp3',0.15,true);
}

export function auMusicStop(){if(AU_MUSIC){try{AU_MUSIC.pause();}catch(e){}AU_MUSIC=null;}}

export function auStopAmbient(){if(AU_AMBIENT){try{AU_AMBIENT.pause();}catch(e){}AU_AMBIENT=null;}}

export function renderSoundBtn(){const b=document.getElementById('soundBtn');if(b)b.textContent=soundOn?'🔊 Sonido: sí':'🔇 Sonido: no';}
