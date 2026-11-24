'use strict';
const test = require('node:test');
const assert = require('node:assert/strict');
const fs = require('node:fs');
const path = require('node:path');
const root = path.dirname(__dirname);

async function load() {
  const [maps, cast, roles, weapons, tutorial] = await Promise.all([
    import('../src/data/maps.js'),
    import('../src/data/cast.js'),
    import('../src/data/roles.js'),
    import('../src/data/weapons.js'),
    import('../src/game/tutorial.js')
  ]);
  return { campaign: maps, maps, cast, roles, weapons, tutorial };
}

test('la campaña usa solo los 17 personajes del IPA en mapas 3D reales', async () => {
  const { campaign, maps, cast, roles, weapons } = await load();
  const names = new Set(cast.ORIG_CAST.filter(c => c.play).map(c => c.name));
  const mapIds = new Set(Object.keys(maps.MAP_DEFS));
  const missions = [campaign.TUTORIAL_MISSION, ...campaign.CAMPAIGN_MISSIONS];
  assert.equal(campaign.CAMPAIGN_MISSIONS.length, 109);
  for (const m of missions) {
    assert.ok(mapIds.has(m.map), 'mapa no disponible: ' + m.map);
    assert.ok(m.turnLimit > 0);
    assert.ok(m.radioLines !== false);
    for (const list of [m.playerRoster, m.enemyRoster]) {
      for (const r of list) {
        assert.ok(names.has(r.charName), 'personaje no original: ' + r.charName);
        assert.ok(roles.ROLES[r.role], 'rol inexistente: ' + r.role);
        assert.ok(weapons.WEAPONS[r.weapon], 'arma inexistente: ' + r.weapon);
      }
    }
  }
  assert.equal(campaign.CAMPAIGN_CHAPTERS.length, 8);
  assert.equal(campaign.missionById('tutorial').id, 'tutorial');
  assert.equal(campaign.missionById('m-tryout-tommytesla').id, 'm-tryout-tommytesla');
  assert.equal(campaign.rosterKey('Hipster Dave'), 'original:Hipster Dave');
});

test('las medallas exigen victoria, pocas bajas y rondas dentro del limite', async () => {
  const { campaign } = await load();
  const m = campaign.CAMPAIGN_MISSIONS[0];
  assert.equal(campaign.campaignStars(false, 0, 1, m), 0);
  assert.equal(campaign.campaignStars(true, 2, 1, m), 1);
  assert.equal(campaign.campaignStars(true, 1, 1, m), 2);
  assert.equal(campaign.campaignStars(true, 0, m.turnLimit, m), 3);
  assert.equal(campaign.campaignStars(true, 0, m.turnLimit + 1, m), 2);
  assert.equal(campaign.radioLines('tutorial').length, campaign.TUTORIAL_STEPS.length);
});

test('el tutorial avanza con acciones reales y exige cobertura', async () => {
  const { campaign, tutorial } = await load();
  const events = [];
  tutorial.configureTutorial({ show: (step) => events.push(step.id) });
  tutorial.startTutorial();
  assert.equal(tutorial.tutorialStep().id, 'select');
  tutorial.tutorialEvent('select', { unit: { name: 'Hipster Dave' } });
  assert.equal(tutorial.tutorialStep().id, 'move');
  tutorial.tutorialEvent('move', { cover: 0 });
  assert.equal(tutorial.tutorialStep().id, 'move');
  tutorial.tutorialEvent('move', { cover: 2 });
  assert.equal(tutorial.tutorialStep().id, 'shoot');
  tutorial.tutorialEvent('shoot', { ok: false });
  assert.equal(tutorial.tutorialStep().id, 'shoot');
  tutorial.tutorialEvent('shoot', { ok: true });
  assert.equal(tutorial.tutorialStep().id, 'grenade');
  tutorial.tutorialEvent('grenade', { armed: true });
  assert.equal(tutorial.tutorialStep().id, 'endTurn');
  tutorial.skipTutorial();
  assert.equal(tutorial.isTutorialActive(), false);
  assert.equal(tutorial.tutorialCompleted(), true);
  assert.deepEqual(events, ['select', 'move', 'shoot', 'grenade', 'endTurn']);
});

test('la campaña despliega la misión directamente sin abrir el configurador', () => {
  const main = fs.readFileSync(path.join(root, 'src', 'main.js'), 'utf8');
  const missions = fs.readFileSync(path.join(root, 'src', 'game', 'missions.js'), 'utf8');
  const bridge = fs.readFileSync(path.join(root, 'src', 'bridge.js'), 'utf8');
  assert.match(main, /function missionSquad\(list\)\{return list\.map\(entry=>\(\{role:entry\.role,weapon:entry\.weapon,charKey:rosterKey\(entry\.charName\)\}\)\);\}/);
  assert.match(main, /if\(!myNation\)\{myNation=NATIONS\[0\];setDemoNation\(myNation\);\}/);
  assert.match(main, /Object\.assign\(setup,\{mode,campaignMission:idx,isTutorial:mode==='tutorial',map:mission\.map,fmt:mission\.playerRoster\.length,opp:'ia'/);
  assert.match(main, /hideCampaignView\(\);[\s\S]*?\$\('#setupArea'\)\.style\.display='none';[\s\S]*?showScreen\('scr-play'\);[\s\S]*?setViewMode3\('3d'\);[\s\S]*?startGame\(missionSquad\(mission\.playerRoster\),missionSquad\(mission\.enemyRoster\)\)/);
  assert.match(main, /function deployCampaignMission\(idx\)\{const index=Math\.max\(0,Math\.min\(CAMPAIGN_MISSIONS\.length-1,idx\|\|0\)\);deployMissionData\(CAMPAIGN_MISSIONS\[index\],'campana',index\);\}/);
  assert.match(main, /function startTutorial\(\)\{deployMissionData\(TUTORIAL_MISSION,'tutorial',0\);\}/);
  assert.match(main, /startTutorialFlow\(\);/);
  assert.doesNotMatch(missions, /openSetup\('campana'/);
  assert.match(missions, /closeModal\(\);deployMission\('\+\(idx\+1\)\+'\)/);
  assert.match(missions, /closeModal\(\);deployMission\('\+idx\+'\)/);
  assert.match(missions, /closeModal\(\);deployMission\(0\)/);
  assert.match(bridge, /d\('deployMission',\(\)=>r\.deployMission\)/);
  assert.match(bridge, /d\('startTutorial',\(\)=>r\.startTutorial\)/);
});

