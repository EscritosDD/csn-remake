// Decompiled with JetBrains decompiler
// Type: SquadDeploymentUnitButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using UnityEngine;
using 땓;

public class SquadDeploymentUnitButton : MonoBehaviour
{
  public GameObject UnitThumb;
  public GameObject UnitThumbBackground;
  public GameObject ClassIcon;
  public GameObject RevertDeployIcon;
  public GameObject DeployUnitBackground;
  public Vector3 SelectedScale;
  public Vector3 DeployedScale;
  public float DeployedZPosition;
  public Vector3 ThumbBGDefaultScale;
  public Vector3 ThumbBGDefaultPosition;
  private Material 딟;
  private Material 땄;

  public bool SetDeploymentButtonData(
    int CharIdx,
    int ButtonIndex,
    Material TeamBackgroundMaterial,
    Material TeamBackgroundSelectedMaterial,
    떀 Character)
  {
    this.set_Deployed(false);
    this.딟 = TeamBackgroundMaterial;
    this.땄 = TeamBackgroundSelectedMaterial;
    // ISSUE: reference to a compiler-generated method
    this.set_CharacterIndex(CharIdx);
    GuiButton3D component = ((Component) this).gameObject.GetComponent<GuiButton3D>();
    if (Object.op_Inequality((Object) component, (Object) null))
    {
      component.set_CustomPressFunc("OnDeployButtonPressed");
      component.set_CustomPressValue((object) ButtonIndex);
    }
    if (Character == null || Object.op_Equality((Object) Character.땷(), (Object) null) || Object.op_Equality((Object) Character.딣(), (Object) null) || Object.op_Equality((Object) Character.땁(), (Object) null))
      return false;
    if (Object.op_Inequality((Object) this.UnitThumb, (Object) null))
    {
      this.UnitThumb.SetActive(true);
      this.UnitThumb.renderer.sharedMaterial = Character.땁().CharacterIcon;
    }
    if (Object.op_Inequality((Object) this.ClassIcon, (Object) null))
      this.ClassIcon.renderer.material = GlobalAppData.땲().딟(Character.땁().GUIIcon, Color.white);
    if (Object.op_Inequality((Object) this.UnitThumbBackground, (Object) null))
      this.UnitThumbBackground.renderer.sharedMaterial = TeamBackgroundMaterial;
    if (Object.op_Inequality((Object) this.DeployUnitBackground, (Object) null))
      this.DeployUnitBackground.renderer.sharedMaterial = TeamBackgroundMaterial;
    this.SetDeploymentPanelDeployedStatus(false);
    return true;
  }

  public void ToggleDeploymentPanelSelected(bool SelectedState)
  {
    this.set_Selected(SelectedState);
    if (!Object.op_Inequality((Object) this.UnitThumbBackground, (Object) null))
      return;
    this.UnitThumbBackground.renderer.sharedMaterial = !this.get_Selected() ? this.딟 : this.땄;
    this.UnitThumbBackground.transform.localScale = !this.get_Selected() ? this.ThumbBGDefaultScale : this.SelectedScale;
  }

  public void SetDeploymentPanelDeployedStatus(bool DeployedState)
  {
    this.set_Deployed(DeployedState);
    if (this.get_Selected())
      this.ToggleDeploymentPanelSelected(!this.get_Selected());
    if (Object.op_Inequality((Object) this.RevertDeployIcon, (Object) null))
      this.RevertDeployIcon.SetActive(this.get_Deployed());
    if (!Object.op_Inequality((Object) this.UnitThumbBackground, (Object) null))
      return;
    this.UnitThumbBackground.transform.localScale = !this.get_Deployed() ? this.ThumbBGDefaultScale : this.DeployedScale;
    this.UnitThumbBackground.transform.localPosition = !this.get_Deployed() ? this.ThumbBGDefaultPosition : new Vector3((float) this.ThumbBGDefaultPosition.x, (float) this.ThumbBGDefaultPosition.y, this.DeployedZPosition);
  }

  [CompilerGenerated]
  [SpecialName]
  public bool get_Deployed() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public void set_Deployed(bool value) => this.딟 = value;

  [CompilerGenerated]
  [SpecialName]
  public bool get_Selected() => this.땄;

  [CompilerGenerated]
  [SpecialName]
  public void set_Selected(bool value) => this.땄 = value;

  [CompilerGenerated]
  [SpecialName]
  public int get_CharacterIndex() => this.딟;
}
