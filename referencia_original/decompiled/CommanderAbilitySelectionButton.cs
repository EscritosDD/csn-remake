// Decompiled with JetBrains decompiler
// Type: CommanderAbilitySelectionButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using UnityEngine;

[AddComponentMenu("Gui3D/Controls/Squad Selection Unit Button New")]
public class CommanderAbilitySelectionButton : MonoBehaviour
{
  public GameObject AbilityIcon;
  public GameObject SquadPointIcon;
  public GameObject ActionPointsIcon;
  public GameObject Background;
  public GameObject AbilityBackground;
  public GuiText3D SquadPointsText;
  public GuiText3D ActionPointsText;
  public AudioShader2 NotSelectedAudio;
  public AudioShader2 SelectedAudio;
  public float ButtonOpacity = 0.35f;
  public float ButtonScale = 0.75f;
  public string SelectionAnimationName;
  public string DeSelectionAnimationName;
  private Material 딟;
  private Material 땄;
  private Material 딧;
  private Color 딟;
  private Material 딢;
  private Material 땃;
  private Animation 딟;
  private bool 딟;
  private bool 땄;
  private bool 딧;

  public void Init(
    PlayerAbilityEntry Ability,
    bool SelectedAbility,
    Shader NotAvailableShader,
    bool ReInit)
  {
    // ISSUE: reference to a compiler-generated method
    this.set_Ability(Ability);
    this.땄 = SelectedAbility;
    if (ReInit)
      this.딟 = new Color((float) this.Background.renderer.material.color.r, (float) this.Background.renderer.material.color.g, (float) this.Background.renderer.material.color.b, (float) this.Background.renderer.material.color.a);
    GuiButton3D component = ((Component) this).gameObject.GetComponent<GuiButton3D>();
    if (Object.op_Inequality((Object) component, (Object) null))
    {
      if (this.딟)
      {
        component.set_CustomPressFunc((string) null);
        component.set_CustomPressValue((object) null);
      }
      else
      {
        if (this.땄 || this.get_AbilitySelected())
        {
          component.set_CustomPressFunc("RemoveAbility");
          component.PlayAudio = this.SelectedAudio;
        }
        else
        {
          component.set_CustomPressFunc("AddAbility");
          component.PlayAudio = this.NotSelectedAudio;
        }
        component.set_CustomPressValue((object) this);
      }
    }
    if (Object.op_Inequality((Object) this.AbilityIcon, (Object) null))
    {
      this.AbilityIcon.gameObject.SetActive(true);
      this.AbilityIcon.renderer.material = Ability.AbilityInfo.Icon;
    }
    if (Object.op_Inequality((Object) this.SquadPointIcon, (Object) null))
      this.SquadPointIcon.gameObject.SetActive(true);
    if (Object.op_Inequality((Object) this.SquadPointsText, (Object) null))
    {
      this.SquadPointsText.Text = Ability.SquadPoints.ToString();
      this.SquadPointsText.UpdateMesh();
    }
    if (Object.op_Inequality((Object) this.ActionPointsText, (Object) null))
    {
      this.ActionPointsText.Text = 땓.땎.땃(Ability.AbilityInfo.Ability).ToString();
      this.ActionPointsText.UpdateMesh();
    }
    if (Object.op_Inequality((Object) NotAvailableShader, (Object) null))
    {
      if (Object.op_Equality((Object) this.딟, (Object) null))
        this.딟 = GlobalAppData.땲().딟(Ability.AbilityInfo.Icon, NotAvailableShader);
      if (Object.op_Equality((Object) this.땄, (Object) null))
      {
        this.딧 = this.AbilityBackground.renderer.material;
        this.땄 = GlobalAppData.땲().딟(this.AbilityBackground.renderer.material, NotAvailableShader);
      }
      if (Object.op_Equality((Object) this.딢, (Object) null))
      {
        this.땃 = this.ActionPointsIcon.renderer.material;
        this.딢 = GlobalAppData.땲().딟(this.ActionPointsIcon.renderer.material, NotAvailableShader);
      }
    }
    if (this.get_AbilitySelected() && this.딧)
      this.SetButtonOpacity();
    if (!Object.op_Equality((Object) this.딟, (Object) null))
      return;
    this.딟 = ((Component) this).GetComponentInChildren<Animation>();
  }

  public void UpdateButtonVisuals(bool Selected)
  {
    if (Selected)
    {
      if (Object.op_Inequality((Object) this.딟, (Object) null) && !this.딟.IsPlaying(this.SelectionAnimationName))
        this.딟.Play(this.SelectionAnimationName);
      if (this.땄)
        return;
      this.SetButtonOpacity();
    }
    else
    {
      if (Object.op_Inequality((Object) this.딟, (Object) null) && !this.딟.IsPlaying(this.DeSelectionAnimationName))
        this.딟.Play(this.DeSelectionAnimationName);
      if (this.땄)
        return;
      this.ResetButtonOpacity();
    }
  }

  public void SetButtonOpacity()
  {
    if (this.땄)
      return;
    this.Background.renderer.material.color = new Color((float) this.Background.renderer.material.color.r, (float) this.Background.renderer.material.color.g, (float) this.Background.renderer.material.color.b, this.ButtonOpacity);
    this.AbilityIcon.renderer.material.color = new Color((float) this.AbilityIcon.renderer.material.color.r, (float) this.AbilityIcon.renderer.material.color.g, (float) this.AbilityIcon.renderer.material.color.b, this.ButtonOpacity);
    this.SquadPointIcon.renderer.material.color = new Color((float) this.SquadPointIcon.renderer.material.color.r, (float) this.SquadPointIcon.renderer.material.color.g, (float) this.SquadPointIcon.renderer.material.color.b, this.ButtonOpacity);
    this.ActionPointsIcon.renderer.material.color = new Color((float) this.ActionPointsIcon.renderer.material.color.r, (float) this.ActionPointsIcon.renderer.material.color.g, (float) this.ActionPointsIcon.renderer.material.color.b, this.ButtonOpacity);
    ((Component) this.ActionPointsText).renderer.material.color = new Color((float) ((Component) this.ActionPointsText).renderer.material.color.r, (float) ((Component) this.ActionPointsText).renderer.material.color.g, (float) ((Component) this.ActionPointsText).renderer.material.color.b, this.ButtonOpacity);
    ((Component) this.SquadPointsText).renderer.material.color = new Color((float) ((Component) this.SquadPointsText).renderer.material.color.r, (float) ((Component) this.SquadPointsText).renderer.material.color.g, (float) ((Component) this.SquadPointsText).renderer.material.color.b, this.ButtonOpacity);
  }

  public void ResetButtonOpacity()
  {
    if (this.땄)
      return;
    this.Background.renderer.material.color = new Color((float) this.Background.renderer.material.color.r, (float) this.Background.renderer.material.color.g, (float) this.Background.renderer.material.color.b, 1f);
    this.AbilityIcon.renderer.material.color = new Color((float) this.AbilityIcon.renderer.material.color.r, (float) this.AbilityIcon.renderer.material.color.g, (float) this.AbilityIcon.renderer.material.color.b, 1f);
    this.SquadPointIcon.renderer.material.color = new Color((float) this.SquadPointIcon.renderer.material.color.r, (float) this.SquadPointIcon.renderer.material.color.g, (float) this.SquadPointIcon.renderer.material.color.b, 1f);
    this.ActionPointsIcon.renderer.material.color = new Color((float) this.ActionPointsIcon.renderer.material.color.r, (float) this.ActionPointsIcon.renderer.material.color.g, (float) this.ActionPointsIcon.renderer.material.color.b, 1f);
    ((Component) this.ActionPointsText).renderer.material.color = new Color((float) ((Component) this.ActionPointsText).renderer.material.color.r, (float) ((Component) this.ActionPointsText).renderer.material.color.g, (float) ((Component) this.ActionPointsText).renderer.material.color.b, 1f);
    ((Component) this.SquadPointsText).renderer.material.color = new Color((float) ((Component) this.SquadPointsText).renderer.material.color.r, (float) ((Component) this.SquadPointsText).renderer.material.color.g, (float) ((Component) this.SquadPointsText).renderer.material.color.b, 1f);
  }

  public void AbilityAdded()
  {
    this.UpdateButtonVisuals(true);
    GuiButton3D component = ((Component) this).gameObject.GetComponent<GuiButton3D>();
    if (Object.op_Inequality((Object) component, (Object) null))
    {
      component.set_CustomPressFunc("RemoveAbility");
      component.set_CustomPressValue((object) this);
      component.PlayAudio = this.SelectedAudio;
    }
    // ISSUE: reference to a compiler-generated method
    this.set_AbilitySelected(true);
  }

  public void AbilityRemoved()
  {
    this.UpdateButtonVisuals(false);
    GuiButton3D component = ((Component) this).gameObject.GetComponent<GuiButton3D>();
    if (Object.op_Inequality((Object) component, (Object) null) && !this.땄)
    {
      component.set_CustomPressFunc("AddAbility");
      component.set_CustomPressValue((object) this);
      component.PlayAudio = this.NotSelectedAudio;
    }
    // ISSUE: reference to a compiler-generated method
    this.set_AbilitySelected(false);
  }

  public void Lock()
  {
    GuiButton3D component = ((Component) this).gameObject.GetComponent<GuiButton3D>();
    if (Object.op_Inequality((Object) component, (Object) null))
    {
      component.set_CustomPressFunc((string) null);
      component.set_CustomPressValue((object) null);
    }
    this.딟 = true;
  }

  public void SetUnitAvailable(bool Available)
  {
    this.딧 = Available;
    ((Component) this).gameObject.GetComponent<GuiButton3D>().Disabled = !Available;
    if (!Available)
    {
      if (Object.op_Inequality((Object) this.딟, (Object) null))
        this.AbilityIcon.renderer.material = this.딟;
      if (Object.op_Inequality((Object) this.땄, (Object) null))
        this.AbilityBackground.renderer.material = this.땄;
      this.Background.renderer.material.color = new Color(0.1f, 0.1f, 0.1f, 1f);
      if (!Object.op_Inequality((Object) this.딢, (Object) null))
        return;
      this.ActionPointsIcon.renderer.material = this.딢;
    }
    else
    {
      if (Object.op_Inequality((Object) this.딟, (Object) null))
        this.AbilityIcon.renderer.material = this.get_Ability().AbilityInfo.Icon;
      if (Object.op_Inequality((Object) this.땄, (Object) null))
        this.AbilityBackground.renderer.material = this.딧;
      this.Background.renderer.material.color = this.딟;
      if (!Object.op_Inequality((Object) this.딢, (Object) null))
        return;
      this.ActionPointsIcon.renderer.material = this.땃;
    }
  }

  [CompilerGenerated]
  [SpecialName]
  public PlayerAbilityEntry get_Ability() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public bool get_AbilitySelected() => this.딢;
}
