// Decompiled with JetBrains decompiler
// Type: GameplayHUDUnitInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using UnityEngine;

public class GameplayHUDUnitInfo : MonoBehaviour
{
  public GameObject UnitInfoThumb;
  public GameObject UnitInfoThumbBackground;
  public GameObject UnitInfoClassIcon;
  public GameObject UnitInfoNameBackground;
  public GuiText3D UnitInfoHealthText;
  public GuiText3D UnitInfoPointsText;
  public GameObject UnitInfoPointsIcon;
  public bool ShouldAnimatePointsIcon;
  public GuiText3D UnitNameText;
  public GuiButton3D CurrentUnitButton;
  public GuiButton3D UnitInfoButton;
  private bool 딟;
  private int 딟 = -1;
  private string 딟;
  private float 딟 = 0.32f;

  public virtual void UpdateUnitInfoData(
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
    this.딟 = this.ShortenName(UnitName);
    // ISSUE: reference to a compiler-generated method
    this.set_LocalCharacterIndex(CharIndex);
    if (this.딟 != SquadGridActive)
    {
      ((Component) this).gameObject.SetActive(!SquadGridActive);
      if (!IsTutorial && Object.op_Inequality((Object) this.UnitInfoButton, (Object) null))
        ((Component) this.UnitInfoButton).gameObject.SetActive(!SquadGridActive);
      if (!SquadGridActive)
        ForceUpdate = true;
    }
    this.딟 = SquadGridActive;
    if (SquadGridActive)
      return;
    if (Object.op_Inequality((Object) this.CurrentUnitButton, (Object) null) && NumTeamMembers != this.딟)
    {
      this.CurrentUnitButton.Disabled = NumTeamMembers <= 1;
      this.CurrentUnitButton.AnimateButton = NumTeamMembers > 1;
    }
    this.딟 = NumTeamMembers;
    if (Object.op_Inequality((Object) this.UnitInfoThumb, (Object) null))
      this.UnitInfoThumb.renderer.sharedMaterial = UnitIcon;
    if (Object.op_Inequality((Object) this.UnitInfoClassIcon, (Object) null))
    {
      if (Object.op_Equality((Object) UnitClass, (Object) null) && this.UnitInfoClassIcon.activeInHierarchy || Object.op_Inequality((Object) UnitClass, (Object) null) && !this.UnitInfoClassIcon.activeInHierarchy)
        this.UnitInfoClassIcon.gameObject.SetActive(Object.op_Inequality((Object) UnitClass, (Object) null));
      if (Object.op_Inequality((Object) UnitClass, (Object) null))
        this.UnitInfoClassIcon.renderer.material = GlobalAppData.땲().딟(UnitClass, Color.white);
    }
    if (Object.op_Inequality((Object) this.UnitInfoThumbBackground, (Object) null))
      this.UnitInfoThumbBackground.renderer.sharedMaterial = TeamBackgroundMaterial;
    if (Object.op_Inequality((Object) this.UnitInfoButton, (Object) null) && ForceUpdate)
    {
      if (IsTutorial)
        ((Component) this.UnitInfoButton).gameObject.SetActive(false);
      else
        ((Component) this.UnitInfoButton).renderer.material.color = TeamColour;
    }
    if (Object.op_Inequality((Object) this.UnitInfoNameBackground, (Object) null) && ForceUpdate)
      this.UnitInfoNameBackground.renderer.material.color = TeamColour;
    this.UpdateUnitHealth(ForceUpdate);
    int unitPointsValue = this.GetUnitPointsValue(Controller);
    if (Object.op_Inequality((Object) this.UnitInfoPointsText, (Object) null) && this.get_PrevCharacterPoints() != unitPointsValue || ForceUpdate)
    {
      this.UnitInfoPointsText.Text = unitPointsValue.ToString();
      this.UnitInfoPointsText.UpdateMesh();
    }
    // ISSUE: reference to a compiler-generated method
    this.set_PrevCharacterPoints(unitPointsValue);
    if (Object.op_Inequality((Object) this.UnitNameText, (Object) null) && this.UnitNameText.Text != this.딟 || ForceUpdate)
    {
      this.UnitNameText.Text = this.딟;
      this.UnitNameText.UpdateMesh();
    }
    if (!this.ShouldAnimatePointsIcon)
      return;
    string name = ((Object) this.UnitInfoPointsIcon.animation.clip).name;
    if (Object.op_Inequality((Object) this.UnitInfoPointsIcon, (Object) null))
    {
      if (this.UnitInfoPointsIcon.animation.isPlaying)
        this.UnitInfoPointsIcon.animation.Stop();
      this.UnitInfoPointsIcon.animation.Play(name);
    }
    this.ShouldAnimatePointsIcon = false;
  }

  public void UpdateUnitHealth(bool ForceUpdate)
  {
    int 딧 = 딶.딡.땴().땼().떂().땺()[this.get_LocalCharacterIndex()].딧;
    if (Object.op_Inequality((Object) this.UnitInfoHealthText, (Object) null) && this.get_PrevCharacterHealth() != 딧 || ForceUpdate)
    {
      this.UnitInfoHealthText.Text = 딧.ToString();
      this.UnitInfoHealthText.UpdateMesh();
    }
    // ISSUE: reference to a compiler-generated method
    this.set_PrevCharacterHealth(딧);
  }

  private void OnEnable()
  {
    if (!Object.op_Inequality((Object) this.UnitInfoPointsIcon, (Object) null))
      return;
    this.UnitInfoPointsIcon.animation.playAutomatically = false;
    string str = "Generic_Pulse_3_Times";
    this.UnitInfoPointsIcon.animation[str].enabled = true;
    this.UnitInfoPointsIcon.animation[str].normalizedTime = 0.0f;
    this.UnitInfoPointsIcon.animation.Sample();
    this.UnitInfoPointsIcon.animation[str].enabled = false;
  }

  public virtual int GetUnitPointsValue(땓.땦 Controller) => Controller != null ? Controller.땴().딢 : 0;

  private string ShortenName(string Name)
  {
    string str = Name;
    if (this.UnitNameText.Font.딟(str, true, this.UnitNameText.Size).x <= (double) this.딟)
      return Name;
    for (Vector2 vector2 = this.UnitNameText.Font.딟(str + "...", true, this.UnitNameText.Size); vector2.x > (double) this.딟; vector2 = this.UnitNameText.Font.딟(str + "...", true, this.UnitNameText.Size))
      str = str.Substring(0, str.Length - 1);
    return str + "...";
  }

  [CompilerGenerated]
  [SpecialName]
  public int get_PrevCharacterHealth() => this.땄;

  [CompilerGenerated]
  [SpecialName]
  public int get_PrevCharacterPoints() => this.딧;

  [CompilerGenerated]
  [SpecialName]
  public int get_LocalCharacterIndex() => this.딢;
}
