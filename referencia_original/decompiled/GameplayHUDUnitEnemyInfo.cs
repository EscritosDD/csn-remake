// Decompiled with JetBrains decompiler
// Type: GameplayHUDUnitEnemyInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class GameplayHUDUnitEnemyInfo : GameplayHUDUnitInfo
{
  private 딢.땥 딟;
  public int CharacterIndex = -1;
  public GameObject UnitPointsIcon;
  public GameObject UnitInfoPointsBackground;
  public GuiButton3D StoreButton;
  public int MaxDamageTheshold = 50;
  public int MediumDamageThreshold = 25;
  public Material HeavyDamageMaterial;
  public Material MediumDamageMaterial;
  public Material LightDamageMaterial;

  public override void UpdateUnitInfoData(
    Material TeamBackgroundMaterial,
    Color TeamColour,
    Material UnitIcon,
    Material UnitClass,
    string UnitName,
    땓.땦 Controller,
    int CharIndex,
    int NumTeamMembers,
    bool SquadGridActive,
    bool IsTutorial,
    bool ForceUpdate)
  {
    ((Component) this.StoreButton).gameObject.SetActive(false);
    base.UpdateUnitInfoData(TeamBackgroundMaterial, TeamColour, UnitIcon, UnitClass, UnitName, Controller, CharIndex, NumTeamMembers, SquadGridActive, IsTutorial, ForceUpdate);
    if (this.get_PrevCharacterPoints() > 0)
    {
      ((Component) this.UnitInfoPointsText).gameObject.SetActive(true);
      this.UnitPointsIcon.SetActive(true);
      this.UnitInfoPointsBackground.SetActive(true);
      this.UnitPointsIcon.renderer.material = this.get_PrevCharacterPoints() < this.MaxDamageTheshold ? (this.get_PrevCharacterPoints() < this.MediumDamageThreshold ? this.LightDamageMaterial : this.MediumDamageMaterial) : this.HeavyDamageMaterial;
    }
    else
    {
      ((Component) this.UnitInfoPointsText).gameObject.SetActive(false);
      this.UnitPointsIcon.SetActive(false);
      this.UnitInfoPointsBackground.SetActive(false);
    }
    this.CharacterIndex = CharIndex;
    땓.떀 떀 = 딶.딡.땴().땼().땻()[CharIndex] as 땓.떀;
    this.딟 = (딢.땥) null;
    if (떀 != null)
      this.딟 = GlobalAppData.땼().딸(떀.떔());
    if (!GlobalAppData.떏().땥())
      return;
    if (this.딟 == null)
      ((Component) this.StoreButton).gameObject.SetActive(false);
    else if (string.IsNullOrEmpty(this.딟.땭()))
      ((Component) this.StoreButton).gameObject.SetActive(false);
    else
      ((Component) this.StoreButton).gameObject.SetActive(true);
  }

  public override int GetUnitPointsValue(땓.땦 Controller)
  {
    딶.땯 땯 = 딶.딡.땴().딷();
    if (땯 == null)
      return -1;
    int num1 = 0;
    int num2 = 0;
    땯.딟(out num1, out num2, this.get_LocalCharacterIndex());
    return Mathf.RoundToInt((float) (num1 + num2) * 0.5f);
  }

  public void Hide()
  {
    ((Component) this).gameObject.SetActive(false);
    this.CharacterIndex = -1;
  }
}
