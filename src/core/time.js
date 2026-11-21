export function isWeekend(d){d=d||new Date();const g=d.getDay();return g===0||g===6;}

export function msToNextSaturday(){const now=new Date();const d=new Date(now.getFullYear(),now.getMonth(),now.getDate());let add=(6-d.getDay()+7)%7;if(add===0)add=7;const target=new Date(d.getTime()+add*86400000);return target-now;}

export function fmtCountdown(ms){const s=Math.floor(ms/1000);const dd=Math.floor(s/86400),hh=Math.floor(s%86400/3600),mm=Math.floor(s%3600/60),ss=s%60;return (dd>0?dd+'d ':'')+String(hh).padStart(2,'0')+':'+String(mm).padStart(2,'0')+':'+String(ss).padStart(2,'0');}
