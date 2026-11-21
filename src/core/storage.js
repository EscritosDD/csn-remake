export const MEM_STORE={};

export function lsGet(k){try{const v=localStorage.getItem(k);if(v!==null&&v!==undefined)return v;}catch(e){}return Object.prototype.hasOwnProperty.call(MEM_STORE,k)?MEM_STORE[k]:null;}

export function lsSet(k,v){MEM_STORE[k]=String(v);try{localStorage.setItem(k,String(v));}catch(e){}}

export function lsRemove(k){delete MEM_STORE[k];try{localStorage.removeItem(k);}catch(e){}}
