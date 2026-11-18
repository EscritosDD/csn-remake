// Decompiled with JetBrains decompiler
// Type: BarracksAbilitiesPanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class BarracksAbilitiesPanelHandler : MonoBehaviour
{
  public GameObject Overlay;
  public UnitAbilityButton[] AbilityButtons;
  public GuiMultiLineText3D AbilityText;
  public GuiText3D AbilityTitle;
  public GameObject AbilityIcon;
  private MenuAnimatorHandler 딟;
  private GameObject 딟;
  private 딢.딴 딟;
  private 딧.딼 딟 = new 딧.딼();

  private void Start()
  {
  }

  public void Init(땓.떀 SelectedCharacter, Transform StartPoint, Transform EndPoint)
  {
    this.딟 = ((Component) this).GetComponent<MenuAnimatorHandler>();
    this.딟 = Object.Instantiate((Object) this.Overlay, new Vector3(0.0f, 1.05f, 0.0f), Quaternion.identity) as GameObject;
    this.딟.StartPoint = StartPoint;
    this.딟.EndPoint = EndPoint;
    for (int index = 0; index < this.AbilityButtons.Length; ++index)
    {
      if (index < SelectedCharacter.땁().Abilities.Length)
        this.AbilityButtons[index].Init(GlobalAppData.딢().GenericData.땄(SelectedCharacter.땁().Abilities[index]));
      else
        this.AbilityButtons[index].Disable();
    }
    if (SelectedCharacter.땁().Abilities.Length > 0)
      this.딟 = SelectedCharacter.땁().Abilities[0];
    this.UpdateSelectedAbility();
  }

  private void UpdateSelectedAbility()
  {
    AbilityInfo abilityInfo = GlobalAppData.딢().GenericData.땄(this.딟);
    if (abilityInfo != null)
    {
      this.AbilityText.Text = (string) null;
      this.AbilityText.LocText = abilityInfo.Description;
      this.AbilityText.UpdateMesh();
      this.AbilityTitle.Text = (string) null;
      this.AbilityTitle.LocText = abilityInfo.Title;
      this.AbilityTitle.UpdateMesh();
      this.딟.딟(this.AbilityIcon, abilityInfo.Icon);
    }
    else
    {
      this.AbilityText.Text = "Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info";
      this.AbilityText.LocText = (LocalisationEntry) null;
      this.AbilityText.UpdateMesh();
      this.AbilityTitle.Text = "Unknown Ability";
      this.AbilityTitle.LocText = (LocalisationEntry) null;
      this.AbilityTitle.UpdateMesh();
    }
  }

  private void Update()
  {
  }

  private void OnCharacterAbilitySelected(딢.딴 Type)
  {
    this.딟 = Type;
    this.UpdateSelectedAbility();
  }

  public void Close()
  {
    this.딟.GetComponent<MenuOverlayHandler>().Close();
    this.딟.Close();
  }

  public void OnDestroy()
  {
    GlobalAppData.딟(this.AbilityIcon.renderer.material);
    this.딟.딟();
  }
}
