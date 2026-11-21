export function facingVec(u){const m={0:[1,0],1:[0,1],2:[-1,0],3:[0,-1]};return m[(u.facing==null?(u.team==='A'?0:2):u.facing)]||[1,0];}

export function angleToFacing(dx,dy){if(dx===0&&dy===0)return null;if(Math.abs(dx)>=Math.abs(dy))return dx>=0?0:2;return dy>=0?1:3;}

export function facingYaw(u){if(u._moveYaw!=null)return u._moveYaw;const fv=facingVec(u);return Math.atan2(fv[1],fv[0]);}

export function shortestArc(a){while(a>Math.PI)a-=Math.PI*2;while(a<-Math.PI)a+=Math.PI*2;return a;}

export function dist(a,b){return Math.abs(a.x-b.x)+Math.abs(a.y-b.y);}

export function cheb(a,b){return Math.max(Math.abs(a.x-b.x),Math.abs(a.y-b.y));}
