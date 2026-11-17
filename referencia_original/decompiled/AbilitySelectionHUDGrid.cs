// Decompiled with JetBrains decompiler
// Type: AbilitySelectionHUDGrid
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class AbilitySelectionHUDGrid : BaseHUDGrid
{
  public Material Team1CharacterAbilityMateralBG;
  public Material Team2CharacterAbilityMateralBG;
  public Material Team1CharacterAbilitySelectedMateralBG;
  public Material Team2CharacterAbilitySelectedMateralBG;
  public Material DisabledCharacterAbilityMaterialBG;
  public AbilitySelectionHUDButton[] AbilityButtons;
  public static int 딟 = -1;
  public static int 땄 = -2;

  public bool PopulateAbiltyHUDSelection(
    int ActiveTeam,
    땓.땦 CurrUnitController,
    땓.떀 CurrCharacter,
    딢.딴 CurrentSelectedAbility)
  {
    // ISSUE: reference to a compiler-generated method
    this.set_NumAbilites(0);
    this.ResetAbilityButtons();
    if (CurrCharacter != null)
    {
      for (int index = 0; index < CurrCharacter.떓().Count; ++index)
      {
        PlayerAbilityEntry playerAbilityEntry = GlobalAppData.딢().GenericData.딟(CurrCharacter.떓()[index]);
        if (playerAbilityEntry != null && 땓.땎.땄(playerAbilityEntry.AbilityInfo.Ability))
        {
          Material forTeamAbilityType = this.GetMaterialBackgroundForTeamAbilityType(ActiveTeam, false, playerAbilityEntry.AbilityInfo.Ability == CurrentSelectedAbility);
          int abilityUsesRemaining = this.GetNumAbilityUsesRemaining(playerAbilityEntry.AbilityInfo.Ability, CurrUnitController, CurrCharacter);
          bool Selectable = this.IsAbilitySelectable(playerAbilityEntry.AbilityInfo.Ability, CurrUnitController, CurrCharacter, abilityUsesRemaining);
          this.SetAbilityButtonActive(this.get_NumAbilites(), true);
          this.AbilityButtons[this.get_NumAbilites()].SetAbilityData(playerAbilityEntry.AbilityInfo.Ability, this.get_NumAbilites(), playerAbilityEntry.AbilityInfo.Icon, !Selectable ? this.DisabledCharacterAbilityMaterialBG : forTeamAbilityType, this.GetAbilityAPCost(playerAbilityEntry.AbilityInfo.Ability, CurrUnitController, CurrCharacter), abilityUsesRemaining, Selectable);
          AbilitySelectionHUDGrid selectionHudGrid = this;
          // ISSUE: reference to a compiler-generated method
          selectionHudGrid.set_NumAbilites(selectionHudGrid.get_NumAbilites() + 1);
        }
      }
      for (int index = 0; index < CurrCharacter.땁().Abilities.Length; ++index)
      {
        AbilityInfo abilityInfo = GlobalAppData.딢().GenericData.땄(CurrCharacter.땁().Abilities[index]);
        if (abilityInfo != null && 땓.땎.땄(abilityInfo.Ability))
        {
          Material forTeamAbilityType = this.GetMaterialBackgroundForTeamAbilityType(ActiveTeam, true, abilityInfo.Ability == CurrentSelectedAbility);
          int abilityUsesRemaining = this.GetNumAbilityUsesRemaining(abilityInfo.Ability, CurrUnitController, CurrCharacter);
          bool Selectable = this.IsAbilitySelectable(abilityInfo.Ability, CurrUnitController, CurrCharacter, abilityUsesRemaining);
          this.SetAbilityButtonActive(this.get_NumAbilites(), true);
          this.AbilityButtons[this.get_NumAbilites()].SetAbilityData(abilityInfo.Ability, this.get_NumAbilites(), abilityInfo.Icon, !Selectable ? this.DisabledCharacterAbilityMaterialBG : forTeamAbilityType, this.GetAbilityAPCost(abilityInfo.Ability, CurrUnitController, CurrCharacter), abilityUsesRemaining, Selectable);
          AbilitySelectionHUDGrid selectionHudGrid = this;
          // ISSUE: reference to a compiler-generated method
          selectionHudGrid.set_NumAbilites(selectionHudGrid.get_NumAbilites() + 1);
        }
      }
    }
    this.set_bGridOpen(this.get_NumAbilites() >= 1);
    return this.get_bGridOpen();
  }

  private int GetNumAbilityUsesRemaining(딢.딴 Ability, 땓.땦 CurrUnitController, 땓.떀 CurrCharacter) => 땓.땎.땄(CurrCharacter.땄(), CurrUnitController.땔(), Ability);

  private int GetAbilityAPCost(딢.딴 Ability, 땓.땦 CurrUnitController, 땓.떀 CurrCharacter) => 땓.땎.딟(CurrCharacter.땄(), CurrUnitController.땔(), Ability);

  private bool IsAbilitySelectable(
    딢.딴 Ability,
    땓.땦 CurrUnitController,
    땓.떀 CurrCharacter,
    int NumUsesRemaining)
  {
    return !AbilitySelectionHUDGrid.딟(CurrCharacter) && 땓.땎.딟(CurrCharacter.땄(), CurrUnitController.땔(), Ability, NumUsesRemaining);
  }

  private static bool 딟([In] 땓.떀 obj0) => obj0.땄().땉() != null && obj0.땄().땉().딷() != null && obj0.땄().땉().딷().딸();

  private void ResetAbilityButtons()
  {
    for (int Index = 0; Index < this.AbilityButtons.Length; ++Index)
      this.SetAbilityButtonActive(Index, false);
  }

  private void SetAbilityButtonActive(int Index, bool Active)
  {
    if (Index >= this.AbilityButtons.Length)
      return;
    ((Component) this.AbilityButtons[Index]).gameObject.SetActive(Active);
  }

  private Material GetMaterialBackgroundForTeamAbilityType(
    int ActiveTeam,
    bool CharacterAbility,
    bool AbilitySelected)
  {
    return CharacterAbility ? (AbilitySelected ? (ActiveTeam == 0 ? this.Team1CharacterAbilitySelectedMateralBG : this.Team2CharacterAbilitySelectedMateralBG) : (ActiveTeam == 0 ? this.Team1CharacterAbilityMateralBG : this.Team2CharacterAbilityMateralBG)) : (AbilitySelected ? (ActiveTeam == 0 ? this.Team1CharacterAbilitySelectedMateralBG : this.Team2CharacterAbilitySelectedMateralBG) : (ActiveTeam == 0 ? this.Team1CharacterAbilityMateralBG : this.Team2CharacterAbilityMateralBG));
  }

  [CompilerGenerated]
  [SpecialName]
  public int get_NumAbilites() => this.딧;
}
