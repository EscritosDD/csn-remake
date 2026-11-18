// Decompiled with JetBrains decompiler
// Type: AbilitySelectionHUDButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using UnityEngine;

public class AbilitySelectionHUDButton : MonoBehaviour
{
  public GuiButton3D AbiltyButton;
  public GameObject AbilityBackground;
  public GameObject AbilityThumb;
  public GameObject AbilityThumbBackground;
  public GameObject AbilityPointsIcon;
  public GameObject AbilityUseInfinite;
  public GuiText3D AbilityPointsText;
  public GuiText3D AbilityNumText;
  private bool 딟;

  public void SetAbilityData(
    딢.딴 Ability,
    int ButtonIdx,
    Material AbilityIcon,
    Material BackgroundMaterial,
    int Cost,
    int NumLeft,
    bool Selectable)
  {
    // ISSUE: reference to a compiler-generated method
    this.set_bAbilitySelectable(Selectable);
    // ISSUE: reference to a compiler-generated method
    this.set_AbilityType(Ability);
    if (Object.op_Inequality((Object) this.AbilityThumb, (Object) null))
      this.AbilityThumb.renderer.sharedMaterial = AbilityIcon;
    if (Object.op_Inequality((Object) this.AbilityThumbBackground, (Object) null))
      this.AbilityThumbBackground.renderer.sharedMaterial = BackgroundMaterial;
    if (Object.op_Inequality((Object) this.AbilityPointsText, (Object) null) && Object.op_Inequality((Object) this.AbilityPointsIcon, (Object) null))
    {
      ((Component) this.AbilityPointsText).gameObject.SetActive(Cost > 0);
      this.AbilityPointsIcon.SetActive(Cost > 0);
      if (Cost > 0)
      {
        this.AbilityPointsText.Text = Cost.ToString();
        this.AbilityPointsText.UpdateMesh();
      }
    }
    if (Object.op_Inequality((Object) this.AbilityNumText, (Object) null) && Object.op_Inequality((Object) this.AbilityUseInfinite, (Object) null))
    {
      if (NumLeft == AbilitySelectionHUDGrid.딟)
        this.AbilityUseInfinite.SetActive(true);
      else
        this.AbilityUseInfinite.SetActive(false);
      if (NumLeft == AbilitySelectionHUDGrid.땄 || !땓.땎.땤(Ability))
        ((Component) this.AbilityNumText).gameObject.SetActive(false);
      else
        ((Component) this.AbilityNumText).gameObject.SetActive(NumLeft >= 0);
      if (NumLeft >= 0)
      {
        this.AbilityNumText.Text = "x" + NumLeft.ToString();
        this.AbilityNumText.UpdateMesh();
      }
    }
    if (!Object.op_Inequality((Object) this.AbiltyButton, (Object) null))
      return;
    this.AbiltyButton.SuspendPressedAudio = !this.get_bAbilitySelectable();
    this.AbiltyButton.AnimateButton = this.get_bAbilitySelectable();
    if (!this.get_bAbilitySelectable() || this.딟)
      return;
    this.딟 = true;
    this.AbiltyButton.set_CustomPressFunc("OnAbilitySelectionButtonPressed");
    this.AbiltyButton.set_CustomPressValue((object) ButtonIdx);
  }

  public void ShutDownAbilityButton()
  {
    if (!Object.op_Inequality((Object) this.AbiltyButton, (Object) null))
      return;
    this.AbiltyButton.ResetButtonPulseToDefault();
  }

  private void FixedUpdate()
  {
    if (딶.딡.땴() == null || 딶.딡.땴().딷() == null)
      return;
    if (딶.딡.땴().딷().땞() == this.get_AbilityType())
    {
      if (((Component) this).animation.isPlaying)
        return;
      ((Component) this).animation.Play();
    }
    else
    {
      if (!((Component) this).animation.isPlaying)
        return;
      ((Component) this).animation.Stop();
    }
  }

  [CompilerGenerated]
  [SpecialName]
  public 딢.딴 get_AbilityType() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public bool get_bAbilitySelectable() => this.땄;
}
