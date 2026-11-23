import { lsGet, lsSet } from '../core/storage.js';
import { TUTORIAL_MISSION, TUTORIAL_STEPS } from '../data/maps.js';

export const LS_TUTORIAL='radsoldiers_tutorial_v1';

let state={active:false,index:0,enemyCount:0,endRound:null,hooks:{}};

function hook(name,...args){
  try{if(typeof state.hooks[name]==='function')return state.hooks[name](...args);}catch(e){}
  return undefined;
}

function show(){
  const step=TUTORIAL_STEPS[state.index];
  if(step)hook('show',step,state.index,TUTORIAL_STEPS.length);
}

export function configureTutorial(hooks){state.hooks=hooks||{};}

export function isTutorialActive(){return state.active;}

export function tutorialIndex(){return state.index;}

export function tutorialStep(){return TUTORIAL_STEPS[state.index]||null;}

export function tutorialCompleted(){return lsGet(LS_TUTORIAL)==='1';}

export function startTutorial(){
  state.active=true;state.index=0;state.enemyCount=0;state.endRound=null;
  hook('start',TUTORIAL_MISSION);
  show();
}

export function tutorialAdvance(){
  if(!state.active)return;
  if(state.index>=TUTORIAL_STEPS.length-1){completeTutorial();return;}
  state.index++;
  hook('advance',TUTORIAL_STEPS[state.index],state.index,TUTORIAL_STEPS.length);
  show();
}

export function completeTutorial(skipped){
  if(!state.active&&!skipped)return;
  state.active=false;
  lsSet(LS_TUTORIAL,'1');
  if(skipped)hook('skip');else hook('complete');
  hook('hide');
}

export function skipTutorial(){completeTutorial(true);}

export function replayTutorial(){startTutorial();}

export function tutorialEvent(type,info){
  if(!state.active)return;
  info=info||{};
  const step=tutorialStep();
  if(!step)return;
  if(step.check==='turnReturn'&&type==='endTurn'){
    const g=hook('getGame');
    if(state.endRound==null&&g)state.endRound=g.round;
    return;
  }
  if(step.event!==type){hook('hint',step,info);return;}
  if(step.require==='cover'&&!(info.cover>0)){hook('hint',step,info);return;}
  if(type==='shoot'&&info.ok===false){hook('hint',step,info);return;}
  tutorialAdvance();
}

export function tutorialCheck(g){
  if(!state.active)return;
  if(!g){
    state.active=false;
    hook('hide');
    return;
  }
  if(!state.enemyCount)state.enemyCount=g.units.filter(u=>u.team==='B').length;
  const step=tutorialStep();
  if(!step)return;
  if(step.check==='turnReturn'){
    if(g.turn==='B'&&state.endRound==null)state.endRound=g.round;
    else if(state.endRound!=null&&g.turn==='A'&&g.round>state.endRound)tutorialAdvance();
  }else if(step.check==='kill'){
    const alive=g.units.filter(u=>u.team==='B'&&u.alive).length;
    if(alive<state.enemyCount)tutorialAdvance();
  }
}
