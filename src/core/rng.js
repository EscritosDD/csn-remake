export let rngState=987654321;

export function setTurnSeed(round,turn){
  const salt=(typeof G!=='undefined'&&G&&G.matchSeed)?G.matchSeed:1;
  rngState=((Math.imul(round,987643)^Math.imul(salt,2654435761)^(turn==='A'?12345:67890))>>>0)||1;
}

export function rng(){rngState=(Math.imul(rngState,1664525)+1013904223)>>>0;return rngState/4294967296;}
