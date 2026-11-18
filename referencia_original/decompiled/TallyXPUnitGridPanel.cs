// Decompiled with JetBrains decompiler
// Type: TallyXPUnitGridPanel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class TallyXPUnitGridPanel : SquadRosterUnitPanel
{
  public TallyXPBar UnitXPBar;
  public GameObject LevelUpGlow;
  public Material LevelUpBackgroundMaterial;
  public Material LevelUpFillBarMaterial;
  private bool 딟;

  public bool InitaliseXPUnitGridPanel(
    땺.땃 XPStore,
    땓.땊 UnitData,
    int UnitCharIndex,
    땓.떀 Character,
    Material TeamBackgroundMaterial,
    bool GetMaximumCharAttrib)
  {
    땓.떀 떀 = GlobalAppData.땽().딟(Character);
    if (떀 == null)
    {
      ((Component) this.UnitXPBar).gameObject.SetActive(false);
    }
    else
    {
      int inCurrentXP = 떀 != null ? 떀.땝() : 0;
      int inRewardXP = XPStore.딢(UnitCharIndex);
      int inCurrentLevel = GlobalAppData.딢().땄(inCurrentXP);
      this.UnitXPBar.IntialiseTallyXPBar(inCurrentXP, inRewardXP, inCurrentLevel, false);
    }
    this.딟 = false;
    bool flag = this.SetUnitData(UnitData, Character, TeamBackgroundMaterial, (Material) null, (Shader) null, GetMaximumCharAttrib, false);
    if (Object.op_Inequality((Object) this.LevelUpGlow, (Object) null))
      this.LevelUpGlow.SetActive(false);
    if (flag && 떀 != null)
    {
      this.UnitXPBar.AddOnLevelUpCallback(new TallyXPBar.딪(this.OnUnitLevelUp));
      this.UnitXPBar.TriggerTallyXPBarFillAnimation(true);
    }
    return flag;
  }

  public void OnUnitLevelUp(int CurrentXP, int CurrentLevel)
  {
    if (!this.딟)
    {
      if (Object.op_Inequality((Object) this.LevelUpGlow, (Object) null))
        this.LevelUpGlow.SetActive(true);
      this.SetUnitThumbBackgroundMaterial(this.LevelUpBackgroundMaterial);
      this.UnitXPBar.SetXPFillBarGraphicBackgroundMaterial(this.LevelUpFillBarMaterial);
      this.딟 = true;
    }
    this.SetUnitRankIcon(CurrentXP);
  }

  public void SkipXPFillAnim() => this.UnitXPBar.FinishXPBarFillAnimation();
}
