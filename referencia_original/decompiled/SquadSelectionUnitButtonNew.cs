// Decompiled with JetBrains decompiler
// Type: SquadSelectionUnitButtonNew
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using UnityEngine;
using 땓;

[AddComponentMenu("Gui3D/Controls/Squad Selection Unit Button New")]
public class SquadSelectionUnitButtonNew : MonoBehaviour
{
  public GameObject CharacterIcon;
  public GameObject WeaponIcon;
  public GameObject SquadPointIcon;
  public GameObject HealthIcon;
  public GameObject ActionPointsIcon;
  public GameObject Background;
  public GameObject CharacterBackground;
  public GuiText3D SquadPointsText;
  public GuiText3D HealthText;
  public GuiText3D ActionPointsText;
  public string SelectionAnimationName;
  public string DeSelectionAnimationName;
  public float ButtonOpacity = 0.35f;
  private Material 딟;
  private Material 땄;
  private Material 딧;
  private Color 딟;
  private Material 딢;
  private Material 땃;
  private Material 딶;
  private Material 땓;
  public 떀 Character;
  public AudioShader2 NotSelectedAudio;
  public AudioShader2 SelectedAudio;
  private Animation 딟;
  private bool 딟;
  private bool 땄;
  private bool 딧;
  public bool CharacterIconLoaded;
  public bool WeaponIconLoaded;

  private void Start()
  {
  }

  public void HideLoadingElements()
  {
    if (Object.op_Inequality((Object) this.CharacterIcon, (Object) null))
      this.CharacterIcon.gameObject.SetActive(false);
    if (Object.op_Inequality((Object) this.WeaponIcon, (Object) null))
      this.WeaponIcon.gameObject.SetActive(false);
    this.WeaponIconLoaded = false;
    this.CharacterIconLoaded = false;
  }

  public void Init(떀 Character, bool SelectedCharacter, Shader NotAvailableShader, bool ReInit)
  {
    this.HideLoadingElements();
    this.땄 = SelectedCharacter;
    this.Character = Character;
    if (ReInit)
      this.딟 = new Color((float) this.Background.renderer.material.color.r, (float) this.Background.renderer.material.color.g, (float) this.Background.renderer.material.color.b, (float) this.Background.renderer.material.color.a);
    GuiButton3D component = ((Component) this).gameObject.GetComponent<GuiButton3D>();
    if (Object.op_Inequality((Object) component, (Object) null))
    {
      if (this.딟)
      {
        this.LockButton(component);
      }
      else
      {
        if (this.땄 || this.get_UnitSelected())
        {
          component.set_CustomPressFunc("RemoveUnit");
          component.PlayAudio = this.SelectedAudio;
        }
        else
        {
          component.set_CustomPressFunc("AddUnit");
          component.PlayAudio = this.NotSelectedAudio;
        }
        component.set_CustomPressValue((object) this);
      }
    }
    if (Object.op_Inequality((Object) this.SquadPointsText, (Object) null))
    {
      this.SquadPointsText.Text = Character.딟(GlobalAppData.딢()).ToString();
      this.SquadPointsText.UpdateMesh();
    }
    if (Object.op_Inequality((Object) this.HealthText, (Object) null))
    {
      this.HealthText.Text = Character.딱().ToString();
      this.HealthText.UpdateMesh();
    }
    if (Object.op_Inequality((Object) this.ActionPointsText, (Object) null))
    {
      this.ActionPointsText.Text = Character.딟((땓.땊) null).ToString();
      this.ActionPointsText.UpdateMesh();
    }
    if (Object.op_Inequality((Object) NotAvailableShader, (Object) null))
    {
      if (Object.op_Equality((Object) this.딟, (Object) null))
        this.딟 = GlobalAppData.땲().딟(Character.땁().CharacterIcon, NotAvailableShader);
      if (Object.op_Equality((Object) this.땄, (Object) null))
      {
        this.딧 = this.CharacterBackground.renderer.sharedMaterial;
        this.땄 = GlobalAppData.땲().딟(this.CharacterBackground.renderer.material, NotAvailableShader);
      }
      if (Object.op_Equality((Object) this.딢, (Object) null))
      {
        this.땃 = this.HealthIcon.renderer.material;
        this.딢 = GlobalAppData.땲().딟(this.HealthIcon.renderer.material, NotAvailableShader);
      }
      if (Object.op_Equality((Object) this.딶, (Object) null))
      {
        this.땓 = this.ActionPointsIcon.renderer.material;
        this.딶 = GlobalAppData.땲().딟(this.ActionPointsIcon.renderer.material, NotAvailableShader);
      }
    }
    if (this.get_UnitSelected() && this.딧)
      this.SetButtonOpacity();
    if (!Object.op_Equality((Object) this.딟, (Object) null))
      return;
    this.딟 = ((Component) this).GetComponentInChildren<Animation>();
  }

  private void LockButton(GuiButton3D Button)
  {
    Button.set_CustomPressFunc((string) null);
    Button.set_CustomPressValue((object) null);
    Button.AnimateButton = false;
    Button.SuspendPressedAudio = true;
  }

  public void Update()
  {
    if (this.Character == null)
      return;
    if (!this.CharacterIconLoaded && Object.op_Inequality((Object) this.CharacterIcon, (Object) null) && Object.op_Inequality((Object) this.Character.땁(), (Object) null) && Object.op_Inequality((Object) this.Character.땁().CharacterIcon, (Object) null))
    {
      this.CharacterIcon.gameObject.SetActive(true);
      this.CharacterIcon.renderer.material = this.Character.땁().CharacterIcon;
      this.CharacterIconLoaded = true;
      if (this.get_UnitSelected())
        this.SetButtonOpacity();
    }
    if (this.WeaponIconLoaded || !Object.op_Inequality((Object) this.WeaponIcon, (Object) null) || !Object.op_Inequality((Object) this.Character.딛(), (Object) null))
      return;
    if (Object.op_Inequality((Object) this.Character.딛().Icon, (Object) null))
    {
      this.WeaponIcon.gameObject.SetActive(true);
      this.WeaponIcon.renderer.material = this.Character.딛().Icon;
      this.WeaponIconLoaded = true;
      if (!this.get_UnitSelected())
        return;
      this.SetButtonOpacity();
    }
    else
      Debug.LogError((object) ("No icon for weapon: " + this.Character.딛().WeaponId));
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
    this.CharacterIcon.renderer.material.color = new Color((float) this.CharacterIcon.renderer.material.color.r, (float) this.CharacterIcon.renderer.material.color.g, (float) this.CharacterIcon.renderer.material.color.b, this.ButtonOpacity);
    this.WeaponIcon.renderer.material.color = new Color((float) this.WeaponIcon.renderer.material.color.r, (float) this.WeaponIcon.renderer.material.color.g, (float) this.WeaponIcon.renderer.material.color.b, this.ButtonOpacity);
    this.SquadPointIcon.renderer.material.color = new Color((float) this.SquadPointIcon.renderer.material.color.r, (float) this.SquadPointIcon.renderer.material.color.g, (float) this.SquadPointIcon.renderer.material.color.b, this.ButtonOpacity);
    this.HealthIcon.renderer.material.color = new Color((float) this.HealthIcon.renderer.material.color.r, (float) this.HealthIcon.renderer.material.color.g, (float) this.HealthIcon.renderer.material.color.b, this.ButtonOpacity);
    this.ActionPointsIcon.renderer.material.color = new Color((float) this.ActionPointsIcon.renderer.material.color.r, (float) this.ActionPointsIcon.renderer.material.color.g, (float) this.ActionPointsIcon.renderer.material.color.b, this.ButtonOpacity);
    ((Component) this.ActionPointsText).renderer.material.color = new Color((float) ((Component) this.ActionPointsText).renderer.material.color.r, (float) ((Component) this.ActionPointsText).renderer.material.color.g, (float) ((Component) this.ActionPointsText).renderer.material.color.b, this.ButtonOpacity);
    ((Component) this.HealthText).renderer.material.color = new Color((float) ((Component) this.HealthText).renderer.material.color.r, (float) ((Component) this.HealthText).renderer.material.color.g, (float) ((Component) this.HealthText).renderer.material.color.b, this.ButtonOpacity);
    ((Component) this.SquadPointsText).renderer.material.color = new Color((float) ((Component) this.SquadPointsText).renderer.material.color.r, (float) ((Component) this.SquadPointsText).renderer.material.color.g, (float) ((Component) this.SquadPointsText).renderer.material.color.b, this.ButtonOpacity);
  }

  public void ResetButtonOpacity()
  {
    if (this.땄)
      return;
    this.Background.renderer.material.color = new Color((float) this.Background.renderer.material.color.r, (float) this.Background.renderer.material.color.g, (float) this.Background.renderer.material.color.b, 1f);
    this.CharacterIcon.renderer.material.color = new Color((float) this.CharacterIcon.renderer.material.color.r, (float) this.CharacterIcon.renderer.material.color.g, (float) this.CharacterIcon.renderer.material.color.b, 1f);
    this.WeaponIcon.renderer.material.color = new Color((float) this.WeaponIcon.renderer.material.color.r, (float) this.WeaponIcon.renderer.material.color.g, (float) this.WeaponIcon.renderer.material.color.b, 1f);
    this.SquadPointIcon.renderer.material.color = new Color((float) this.SquadPointIcon.renderer.material.color.r, (float) this.SquadPointIcon.renderer.material.color.g, (float) this.SquadPointIcon.renderer.material.color.b, 1f);
    this.HealthIcon.renderer.material.color = new Color((float) this.HealthIcon.renderer.material.color.r, (float) this.HealthIcon.renderer.material.color.g, (float) this.HealthIcon.renderer.material.color.b, 1f);
    this.ActionPointsIcon.renderer.material.color = new Color((float) this.ActionPointsIcon.renderer.material.color.r, (float) this.ActionPointsIcon.renderer.material.color.g, (float) this.ActionPointsIcon.renderer.material.color.b, 1f);
    ((Component) this.ActionPointsText).renderer.material.color = new Color((float) ((Component) this.ActionPointsText).renderer.material.color.r, (float) ((Component) this.ActionPointsText).renderer.material.color.g, (float) ((Component) this.ActionPointsText).renderer.material.color.b, 1f);
    ((Component) this.HealthText).renderer.material.color = new Color((float) ((Component) this.HealthText).renderer.material.color.r, (float) ((Component) this.HealthText).renderer.material.color.g, (float) ((Component) this.HealthText).renderer.material.color.b, 1f);
    ((Component) this.SquadPointsText).renderer.material.color = new Color((float) ((Component) this.SquadPointsText).renderer.material.color.r, (float) ((Component) this.SquadPointsText).renderer.material.color.g, (float) ((Component) this.SquadPointsText).renderer.material.color.b, 1f);
  }

  public void UnitAdded()
  {
    this.UpdateButtonVisuals(true);
    GuiButton3D component = ((Component) this).gameObject.GetComponent<GuiButton3D>();
    if (Object.op_Inequality((Object) component, (Object) null))
    {
      component.set_CustomPressFunc("RemoveUnit");
      component.set_CustomPressValue((object) this);
      component.PlayAudio = this.SelectedAudio;
    }
    // ISSUE: reference to a compiler-generated method
    this.set_UnitSelected(true);
  }

  public void UnitRemoved()
  {
    this.UpdateButtonVisuals(false);
    GuiButton3D component = ((Component) this).gameObject.GetComponent<GuiButton3D>();
    if (Object.op_Inequality((Object) component, (Object) null) && !this.땄)
    {
      component.set_CustomPressFunc("AddUnit");
      component.set_CustomPressValue((object) this);
      component.PlayAudio = this.NotSelectedAudio;
    }
    // ISSUE: reference to a compiler-generated method
    this.set_UnitSelected(false);
  }

  public void Lock()
  {
    GuiButton3D component = ((Component) this).gameObject.GetComponent<GuiButton3D>();
    if (Object.op_Inequality((Object) component, (Object) null))
      this.LockButton(component);
    this.딟 = true;
  }

  public void SetUnitAvailable(bool Available)
  {
    this.딧 = Available;
    if (!Available)
    {
      if (Object.op_Inequality((Object) this.딟, (Object) null))
        this.CharacterIcon.renderer.material = GlobalAppData.땲().딟(this.딟, this.딟.shader);
      if (Object.op_Inequality((Object) this.땄, (Object) null))
        this.CharacterBackground.renderer.sharedMaterial = GlobalAppData.땲().딟(this.땄, this.땄.shader);
      this.Background.renderer.material.color = new Color(0.1f, 0.1f, 0.1f, 1f);
      if (Object.op_Inequality((Object) this.딢, (Object) null))
        this.HealthIcon.renderer.material = GlobalAppData.땲().딟(this.딢, this.딢.shader);
      if (!Object.op_Inequality((Object) this.딶, (Object) null))
        return;
      this.ActionPointsIcon.renderer.material = GlobalAppData.땲().딟(this.딶, this.딶.shader);
    }
    else
    {
      if (Object.op_Inequality((Object) this.딟, (Object) null))
        this.CharacterIcon.renderer.material = GlobalAppData.땲().딟(this.Character.땁().CharacterIcon, this.Character.땁().CharacterIcon.shader);
      if (Object.op_Inequality((Object) this.땄, (Object) null))
        this.CharacterBackground.renderer.sharedMaterial = GlobalAppData.땲().딟(this.딧, this.딧.shader);
      this.Background.renderer.material.color = this.딟;
      if (Object.op_Inequality((Object) this.딢, (Object) null))
        this.HealthIcon.renderer.material = GlobalAppData.땲().딟(this.땃, this.땃.shader);
      if (!Object.op_Inequality((Object) this.딶, (Object) null))
        return;
      this.ActionPointsIcon.renderer.material = GlobalAppData.땲().딟(this.땓, this.땓.shader);
    }
  }

  [CompilerGenerated]
  [SpecialName]
  public bool get_UnitSelected() => this.딢;
}
