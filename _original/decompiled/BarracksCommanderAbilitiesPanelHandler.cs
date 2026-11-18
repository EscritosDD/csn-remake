// Decompiled with JetBrains decompiler
// Type: BarracksCommanderAbilitiesPanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class BarracksCommanderAbilitiesPanelHandler : MonoBehaviour
{
  private 딢.딴 딟 = 딢.딴.땵;
  private 땓.떀 딟;
  private GameObject 딟;
  public GuiScrollList3D AbilityList;
  public UnitAbilityButtonGroup AbilityButtonsx1;
  public UnitAbilityButtonGroup AbilityButtonsx2;
  public GameObject Overlay;
  public MenuAnimatorHandler MenuAnim;
  public UnitAbilityButton[] ActiveAbilityButtons;
  public GuiText3D AblilityTitleText;
  public GuiMultiLineText3D AblilityText;
  public GameObject AbilityIcon;
  public Material AbilitySelected;
  public Material AbilityEmpty;
  public GameObject[] ActiveAbilityNumbers;

  private void Start()
  {
    this.MenuAnim = ((Component) this).GetComponent<MenuAnimatorHandler>();
    this.딟 = Object.Instantiate((Object) this.Overlay, new Vector3(0.0f, 0.8f, 0.0f), Quaternion.identity) as GameObject;
  }

  private void InitAbilityButtons(
    List<PlayerAbilityEntry> Abilities,
    UnitAbilityButton[] Buttons,
    int StartIndex)
  {
    for (int index = 0; index < Buttons.Length; ++index)
      Buttons[index].Init(Abilities[StartIndex + index]);
  }

  public void Init(땓.떀 Char)
  {
    this.딟 = Char;
    int num = GlobalAppData.땽().때();
    PlayerAbilityEntry[] playerAbilities = GlobalAppData.딢().GenericData.PlayerAbilities;
    List<PlayerAbilityEntry> Abilities = new List<PlayerAbilityEntry>();
    foreach (PlayerAbilityEntry playerAbilityEntry in playerAbilities)
    {
      if (num > playerAbilityEntry.RequiredLevel)
        Abilities.Add(playerAbilityEntry);
    }
    int StartIndex;
    for (StartIndex = 0; StartIndex < Abilities.Count - 1; StartIndex += 2)
    {
      UnitAbilityButtonGroup abilityButtonGroup = Object.Instantiate((Object) this.AbilityButtonsx2) as UnitAbilityButtonGroup;
      this.InitAbilityButtons(Abilities, abilityButtonGroup.Buttons, StartIndex);
      this.AbilityList.AddItem(((Component) abilityButtonGroup).transform, 0.084375f);
    }
    for (; StartIndex < Abilities.Count; ++StartIndex)
    {
      UnitAbilityButtonGroup abilityButtonGroup = Object.Instantiate((Object) this.AbilityButtonsx1) as UnitAbilityButtonGroup;
      this.InitAbilityButtons(Abilities, abilityButtonGroup.Buttons, StartIndex);
      this.AbilityList.AddItem(((Component) abilityButtonGroup).transform, 0.084375f);
    }
    if (Abilities.Count > 0)
      this.딟 = Abilities[0].AbilityInfo.Ability;
    else if (Char.땁().Abilities.Length > 0)
      this.딟 = Char.땁().Abilities[0];
    this.UpdateAbilityButtons();
  }

  private void UpdateAbilityButtons()
  {
    PlayerAbilityEntry playerAbilityEntry = (PlayerAbilityEntry) null;
    AbilityInfo abilityInfo = (AbilityInfo) null;
    if (this.딟 != 딢.딴.땵)
    {
      playerAbilityEntry = GlobalAppData.딢().GenericData.딟(this.딟);
      abilityInfo = GlobalAppData.딢().GenericData.땄(this.딟);
    }
    for (int index1 = 0; index1 < this.ActiveAbilityButtons.Length; ++index1)
    {
      int index2 = index1;
      if (index2 < this.딟.땁().Abilities.Length)
      {
        this.ActiveAbilityButtons[index1].Init(GlobalAppData.딢().GenericData.땄(this.딟.땁().Abilities[index2]));
        ((Component) this.ActiveAbilityButtons[index1]).renderer.sharedMaterial = this.AbilitySelected;
        this.ActiveAbilityNumbers[index1].SetActive(false);
      }
      else
      {
        int index3 = index2 - this.딟.땁().Abilities.Length;
        if (index3 >= this.딟.떓().Count)
        {
          this.ActiveAbilityButtons[index1].Icon.SetActive(false);
          ((Component) this.ActiveAbilityButtons[index1]).renderer.sharedMaterial = this.AbilityEmpty;
          this.ActiveAbilityNumbers[index1].SetActive(true);
        }
        else
        {
          this.ActiveAbilityButtons[index1].Init(GlobalAppData.딢().GenericData.딟(this.딟.떓()[index3]));
          this.ActiveAbilityButtons[index1].Icon.SetActive(true);
          ((Component) this.ActiveAbilityButtons[index1]).renderer.sharedMaterial = this.AbilitySelected;
          this.ActiveAbilityNumbers[index1].SetActive(false);
        }
      }
    }
    if (playerAbilityEntry != null)
    {
      this.AblilityTitleText.Text = 딧.딪.딟(playerAbilityEntry.AbilityInfo.Title);
      this.AblilityText.Text = 딧.딪.딟(playerAbilityEntry.AbilityInfo.Description);
      this.AbilityIcon.renderer.material = playerAbilityEntry.AbilityInfo.Icon;
      if (string.IsNullOrEmpty(this.AblilityText.Text))
        this.AblilityText.Text = "Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info";
    }
    else if (abilityInfo != null)
    {
      this.AblilityTitleText.Text = 딧.딪.딟(abilityInfo.Title);
      this.AblilityText.Text = 딧.딪.딟(abilityInfo.Description);
      this.AbilityIcon.renderer.material = abilityInfo.Icon;
      if (string.IsNullOrEmpty(this.AblilityText.Text))
        this.AblilityText.Text = "Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info Info";
    }
    else
    {
      this.AblilityTitleText.Text = (string) null;
      this.AblilityText.Text = (string) null;
    }
    this.AblilityTitleText.UpdateMesh();
    this.AblilityText.UpdateMesh();
  }

  public void Close()
  {
    this.딟.GetComponent<MenuOverlayHandler>().Close();
    this.MenuAnim.Close();
  }

  private void OnButtonPressed(string Command)
  {
  }

  private void OnAbilitySelected(딢.딴 Type)
  {
    this.딟 = Type;
    this.UpdateAbilityButtons();
  }

  private void OnActiveAbilitySelected(딢.딴 Type)
  {
    if (this.딟 == Type)
      this.딟.떓().Remove(Type);
    else
      this.딟 = Type;
    this.UpdateAbilityButtons();
  }

  private void OnCharacterAbilitySelected(딢.딴 Type)
  {
    this.딟 = Type;
    this.UpdateAbilityButtons();
  }

  private void OnDestroy() => GlobalAppData.땄(this.AbilityIcon);
}
