// Decompiled with JetBrains decompiler
// Type: SquadRosterUnitPanel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using UnityEngine;

public class SquadRosterUnitPanel : MonoBehaviour
{
  public GameObject PanelBackground;
  public GameObject UnitThumb;
  public GameObject UnitThumbBackground;
  public GameObject ClassIcon;
  public GameObject DeadIcon;
  public GameObject RankIcon;
  public GameObject UnitHealthIcon;
  public GuiText3D UnitHealthText;
  public GameObject UnitPointsIcon;
  public GuiText3D UnitPointsText;

  public bool SetUnitData(
    땓.땊 UnitData,
    땓.떀 Character,
    Material TeamBackgroundMaterial,
    Material DeadBackgroundMaterial,
    Shader DeadCharShader,
    bool GetMaximumCharAttrib,
    bool IsOnRight)
  {
    if (Character == null || Object.op_Equality((Object) Character.땁(), (Object) null))
      return false;
    if (Object.op_Inequality((Object) this.ClassIcon, (Object) null))
      this.ClassIcon.renderer.material = GlobalAppData.땲().딟(Character.땁().GUIIcon, Color.white);
    this.SetUnitRankIcon(Character.땝());
    int UnitHealth = !GetMaximumCharAttrib ? this.GetCharacterHealth(UnitData) : Character.딱();
    int UnitPoints = !GetMaximumCharAttrib ? this.GetCharacterActionPoints(UnitData) : Character.딟((땓.땊) null);
    this.set_bUnitAlive(!UnitData.땺() || !UnitData.땓());
    bool localTeam = this.UnitIsVisibleToLocalTeam(this.get_CharacterIndex(), UnitData);
    if (Object.op_Inequality((Object) this.UnitThumb, (Object) null))
    {
      this.UnitThumb.SetActive(true);
      this.UnitThumb.renderer.sharedMaterial = Character.땁().CharacterIcon;
      if (!this.get_bUnitAlive() && Object.op_Inequality((Object) DeadCharShader, (Object) null))
        this.UnitThumb.renderer.material = GlobalAppData.땲().딟(Character.땁().CharacterIcon, DeadCharShader);
      if (IsOnRight)
      {
        this.UnitThumb.renderer.material.SetTextureOffset("_MainTex", new Vector2(1f, 0.0f));
        this.UnitThumb.renderer.material.SetTextureScale("_MainTex", new Vector2(-1f, 1f));
      }
    }
    this.SetUnitThumbBackgroundMaterial(this.get_bUnitAlive() || Object.op_Equality((Object) DeadCharShader, (Object) null) ? TeamBackgroundMaterial : DeadBackgroundMaterial);
    this.SetUnitPanelAliveStatus(this.get_bUnitAlive(), UnitHealth, UnitPoints, localTeam);
    return true;
  }

  public void SetUnitThumbBackgroundMaterial(Material NewMat)
  {
    if (!Object.op_Inequality((Object) this.UnitThumbBackground, (Object) null))
      return;
    this.UnitThumbBackground.renderer.sharedMaterial = NewMat;
  }

  public void SetUnitRankIcon(int XP)
  {
    if (!Object.op_Inequality((Object) this.RankIcon, (Object) null))
      return;
    this.RankIcon.renderer.material = GlobalAppData.딢().딟(XP).RankIcon;
  }

  public int GetCharacterHealth(땓.땊 UnitData) => UnitData != null ? UnitData.딧 : 0;

  public int GetCharacterActionPoints(땓.땊 UnitData) => UnitData != null ? UnitData.딢 : 0;

  private void SetUnitPanelAliveStatus(
    bool Alive,
    int UnitHealth,
    int UnitPoints,
    bool UnitVisibleToLocalTeam)
  {
    if (Object.op_Inequality((Object) this.ClassIcon, (Object) null))
      this.ClassIcon.SetActive(Alive);
    if (Object.op_Inequality((Object) this.DeadIcon, (Object) null))
      this.DeadIcon.SetActive(!Alive);
    if (Object.op_Inequality((Object) this.UnitHealthIcon, (Object) null))
      this.UnitHealthIcon.SetActive(Alive);
    if (Object.op_Inequality((Object) this.UnitPointsIcon, (Object) null))
      this.UnitPointsIcon.SetActive(Alive);
    if (Object.op_Inequality((Object) this.UnitHealthText, (Object) null))
    {
      ((Component) this.UnitHealthText).gameObject.SetActive(Alive);
      if (UnitVisibleToLocalTeam)
      {
        UnitHealth = UnitHealth >= 0 ? UnitHealth : 0;
        this.UnitHealthText.Text = UnitHealth.ToString();
      }
      else
        this.UnitHealthText.Text = "?";
      this.UnitHealthText.UpdateMesh();
    }
    if (!Object.op_Inequality((Object) this.UnitPointsText, (Object) null))
      return;
    UnitPoints = UnitPoints >= 0 ? UnitPoints : 0;
    ((Component) this.UnitPointsText).gameObject.SetActive(Alive);
    this.UnitPointsText.Text = UnitPoints.ToString();
    this.UnitPointsText.UpdateMesh();
  }

  private bool UnitIsVisibleToLocalTeam(int CharacterIndex, 땓.땊 UnitData)
  {
    if (딶.딡.땴() == null)
      return true;
    딶.땖 땖 = 딶.딡.땴().땼();
    딶.땙 땙 = 땖.떂();
    return 땖.딟(땙, CharacterIndex, UnitData.땃, UnitData.딶, 땖.땂(), false);
  }

  public MeshFilter GetPanelBackgroundMesh()
  {
    if (Object.op_Inequality((Object) this.PanelBackground, (Object) null))
      return this.PanelBackground.GetComponent<MeshFilter>();
    if (Object.op_Inequality((Object) this.UnitThumbBackground, (Object) null))
      return this.UnitThumbBackground.GetComponent<MeshFilter>();
    return Object.op_Inequality((Object) this.UnitThumb, (Object) null) ? this.UnitThumb.GetComponent<MeshFilter>() : (MeshFilter) null;
  }

  public Vector3 GetPanelBackgroundLocalScale()
  {
    if (Object.op_Inequality((Object) this.PanelBackground, (Object) null))
      return this.PanelBackground.transform.localScale;
    if (Object.op_Inequality((Object) this.UnitThumbBackground, (Object) null))
      return this.UnitThumbBackground.transform.localScale;
    return Object.op_Inequality((Object) this.UnitThumb, (Object) null) ? this.UnitThumb.transform.localScale : Vector3.one;
  }

  [CompilerGenerated]
  [SpecialName]
  public bool get_bUnitAlive() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  protected void set_bUnitAlive(bool value) => this.딟 = value;

  [CompilerGenerated]
  [SpecialName]
  public int get_CharacterIndex() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  protected void set_CharacterIndex(int value) => this.딟 = value;
}
