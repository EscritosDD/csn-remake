// Decompiled with JetBrains decompiler
// Type: CommanderAbilitySelectionScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[AddComponentMenu("Gui3D/Screens/Commander Ability Selection")]
public class CommanderAbilitySelectionScreenHandler : BaseMenuHandler
{
  public CommanderAbilitySelectionAbilityRoster AbilityRoster;
  public CommanderAbilitySelectionAbilityGrid SelectedAbilityGrid;
  public Camera CommanderAbilitySelectionCamera;
  public bool DisplayArrows = true;
  public GameObject MoreArrowLeft;
  public GuiText3D MoreTextLeft;
  public GameObject MoreArrowRight;
  public GuiText3D MoreTextRight;
  public ToolTipHandler CommanderAbilitiesToolTip;
  public PlayerProfilePanel2Handler AbilitiesPanelPrefab;
  public GuiButton3D RemoveAllButton;
  public GuiButton3D NextButton;
  public GameObject NextButtonDisabled;
  public Shader ButtonNAShader;
  private 딶.땂 딟;
  private 딧.땧 딟;
  private new BaseMenuHandler 딟;
  private PlayerProfilePanel2Handler 딟;
  private 땃.땃 딟;
  private bool 딟;
  public GameObject NewUserFlowHighlight;
  private InstantActionInfoBarHandler 딟;
  public InstantActionInfoBarHandler InstantActionInfoBarPrefab;
  public ToolTipHandler InvalidWeaponsTooltipPrefab;
  public Transform StartPoint;
  public Transform EndPoint;
  public GameObject ScrollerButtonLeft;
  public GameObject ScrollerButtonRight;

  public void Awake() => base.딟 = ((Component) this).transform.position;

  public void Start()
  {
    ((Component) this.CommanderAbilitySelectionCamera).gameObject.SetActive(false);
    if (this.딟 == null)
      this.딟 = new 땃.땃(this.RemoveAllButton, this.ButtonNAShader);
    this.NextButtonDisabled.SetActive(true);
    ((Component) this.NextButton).gameObject.SetActive(false);
    this.NewUserFlowHighlight.SetActive(false);
  }

  public void Update()
  {
    if (this.DisplayArrows)
      this.UpdateArrows();
    this.UpdateButtonStates();
    if (((Component) this.NextButton).gameObject.activeInHierarchy)
    {
      if (this.딟 != null)
        this.NewUserFlowHighlight.SetActive(this.딟.딢());
    }
    else
      this.NewUserFlowHighlight.SetActive(false);
    this.AutoSelectAbilities();
    this.UpdateScrollerButtons();
  }

  private void AutoSelectAbilities()
  {
    if (!this.딟 || this.SelectedAbilityGrid.GetNumUsedSlots() > 0)
      return;
    List<CommanderAbilitySelectionButton> abilitiesToAutoSelect = this.AbilityRoster.GetAbilitiesToAutoSelect(this.get_Calculator().땓());
    if (abilitiesToAutoSelect == null)
      return;
    this.딟 = false;
    for (int index = 0; index < abilitiesToAutoSelect.Count; ++index)
      this.AddAbility(abilitiesToAutoSelect[index]);
  }

  private void UpdateButtonStates()
  {
    if (!this.SelectedAbilityGrid.IsValid())
      return;
    if (this.SelectedAbilityGrid.GetNumUsedSlots() == 0)
    {
      this.딟.땄();
      this.NextButtonDisabled.SetActive(true);
      ((Component) this.NextButton).gameObject.SetActive(false);
    }
    else
    {
      this.딟.딟();
      this.NextButtonDisabled.SetActive(false);
      ((Component) this.NextButton).gameObject.SetActive(true);
    }
  }

  private void UpdateArrows()
  {
    if (Object.op_Inequality((Object) BaseMenuHandler.딟, (Object) this))
      return;
    if (this.AbilityRoster.IsAtFirstElement(1))
    {
      this.MoreArrowLeft.SetActive(false);
      ((Component) this.MoreTextLeft).gameObject.SetActive(false);
    }
    else
    {
      this.MoreArrowLeft.SetActive(true);
      ((Component) this.MoreTextLeft).gameObject.SetActive(true);
    }
    if (this.AbilityRoster.IsAtLastElement(1))
    {
      this.MoreArrowRight.SetActive(false);
      ((Component) this.MoreTextRight).gameObject.SetActive(false);
    }
    else
    {
      this.MoreArrowRight.SetActive(true);
      ((Component) this.MoreTextRight).gameObject.SetActive(true);
    }
  }

  public override void ActivateMenu() => this.ActivateMenu(false);

  public void ActivateMenu(딶.땂 Team, 딧.땧 LoadingInfo, BaseMenuHandler ReturnScreen)
  {
    this.딟 = Team;
    this.딟 = LoadingInfo;
    this.딟 = ReturnScreen;
    this.ActivateMenu(true);
  }

  public void ActivateMenu(bool Restart)
  {
    base.ActivateMenu();
    this.SelectedAbilityGrid.Init(this.딟.땓(), Restart, this.get_Calculator());
    this.AbilityRoster.Init(this.SelectedAbilityGrid.get_RemainingAP(), Restart);
    ((Component) this.CommanderAbilitySelectionCamera).gameObject.SetActive(true);
    FrontendHub.딟.MoneyDisplay.UpdateDisplay(true, MoneyDisplayHandler.딤.떎);
    this.CommanderAbilitiesToolTip.Display();
    if (this.딟 != null && this.딟.딢())
      딢.땚.딝();
    this.딟 = Object.Instantiate((Object) this.InstantActionInfoBarPrefab) as InstantActionInfoBarHandler;
    this.딟.Init(this.딟);
    this.딟 = true;
    this.ShowInvalidWeaponsTooltip();
  }

  private void ShowInvalidWeaponsTooltip()
  {
    if (this.딟.땺() != 딶.딹.땄)
      return;
    SinglePlayerMissionAsset playerMissionAsset = GlobalAppData.땃(this.딟.딧());
    if (!Object.op_Inequality((Object) playerMissionAsset, (Object) null) || !playerMissionAsset.ShowWeaponWarning)
      return;
    this.InvalidWeaponsTooltipPrefab.Display();
  }

  public void TryActivateMenuBack()
  {
    if (this.GetNumAvailablePlayerAbilities() > 0)
      this.ActivateMenu();
    else
      this.BackOut();
  }

  public void TryActivateMenu(딶.땂 Team, 딧.땧 LoadingInfo, BaseMenuHandler ReturnScreen)
  {
    // ISSUE: reference to a compiler-generated method
    this.set_Calculator(new 딶.딞(GlobalAppData.딢(), LoadingInfo.땓()));
    if (this.GetNumAvailablePlayerAbilities() > 0)
      this.ActivateMenu(Team, LoadingInfo, ReturnScreen);
    else
      FrontendHub.딟.SquadSelectionScreen.ActivateMenu(Team, true, LoadingInfo, this.get_Calculator(), ReturnScreen);
  }

  public int GetNumAvailablePlayerAbilities()
  {
    int num1 = GlobalAppData.땽().때();
    PlayerAbilityEntry[] playerAbilities = GlobalAppData.딢().GenericData.PlayerAbilities;
    int num2 = 0;
    foreach (PlayerAbilityEntry playerAbilityEntry in playerAbilities)
    {
      if (num1 > playerAbilityEntry.RequiredLevel)
        ++num2;
    }
    return num2;
  }

  private void DeactivateMenu(bool ClearGrid)
  {
    this.DeactivateMenu();
    if (ClearGrid)
    {
      this.SelectedAbilityGrid.Clear();
      this.AbilityRoster.Clear();
    }
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    Object.Destroy((Object) ((Component) this.딟).gameObject);
  }

  public override void DeactivateMenu()
  {
    base.DeactivateMenu();
    ((Component) this.CommanderAbilitySelectionCamera).gameObject.SetActive(false);
    if (Object.op_Inequality((Object) this.딟, (Object) null))
      this.딟.Close();
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    Object.Destroy((Object) ((Component) this.딟).gameObject);
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (CommanderAbilitySelectionScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      CommanderAbilitySelectionScreenHandler.딟 = new Dictionary<string, int>(8)
      {
        {
          "Back",
          0
        },
        {
          "RemoveAll",
          1
        },
        {
          "Random",
          2
        },
        {
          "Next",
          3
        },
        {
          "Info",
          4
        },
        {
          "ClosePanel",
          5
        },
        {
          "ScrollerLeft",
          6
        },
        {
          "ScrollerRight",
          7
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!CommanderAbilitySelectionScreenHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        this.DeactivateMenu(true);
        this.BackOut();
        break;
      case 1:
        this.RemoveAllAbilities();
        break;
      case 2:
        this.RandomAbilitySelection();
        break;
      case 3:
        딧.땧 LoadingInfo = this.딟.딟();
        if (LoadingInfo.딢())
          딢.땚.떎();
        this.DeactivateMenu(false);
        FrontendHub.딟.SquadSelectionScreen.ActivateMenu(this.딟, true, LoadingInfo, this.get_Calculator(), (BaseMenuHandler) this);
        break;
      case 4:
        PlayerAbilityEntry activeAbility = this.AbilityRoster.GetActiveAbility();
        if (!Object.op_Equality((Object) this.딟, (Object) null) || activeAbility == null)
          break;
        this.딟 = Object.Instantiate((Object) this.AbilitiesPanelPrefab) as PlayerProfilePanel2Handler;
        ((Component) this.딟).transform.parent = ((Component) this).transform;
        this.딟.Init(activeAbility, this.StartPoint, this.EndPoint);
        break;
      case 5:
        if (!Object.op_Inequality((Object) this.딟, (Object) null))
          break;
        this.딟.Close();
        break;
      case 6:
        this.AbilityRoster.AbilitySelectionList.DecrementScroller();
        break;
      case 7:
        this.AbilityRoster.AbilitySelectionList.IncrementScroller();
        break;
    }
  }

  private void UpdateScrollerButtons()
  {
    GuiScroller3D abilitySelectionList = this.AbilityRoster.AbilitySelectionList;
    if (abilitySelectionList.NumElements <= 1)
    {
      this.ScrollerButtonLeft.SetActive(false);
      this.ScrollerButtonRight.SetActive(false);
    }
    else if (abilitySelectionList.get_ActiveElement() == 0)
    {
      this.ScrollerButtonLeft.SetActive(false);
      this.ScrollerButtonRight.SetActive(true);
    }
    else if (abilitySelectionList.get_ActiveElement() == abilitySelectionList.NumElements - 1)
    {
      this.ScrollerButtonLeft.SetActive(true);
      this.ScrollerButtonRight.SetActive(false);
    }
    else
    {
      this.ScrollerButtonLeft.SetActive(true);
      this.ScrollerButtonRight.SetActive(true);
    }
  }

  private void BackOut()
  {
    if (Object.op_Inequality((Object) this.딟, (Object) null))
      this.딟.ActivateMenu();
    else
      FrontendHub.딟.ChallengeLocationSelectionScreen.ActivateMenu();
  }

  public void RandomAbilitySelection()
  {
    this.RemoveAllAbilities();
    CommanderAbilitySelectionButton availableAbility;
    do
    {
      availableAbility = this.AbilityRoster.GetRandomAvailableAbility(this.SelectedAbilityGrid.get_RemainingAP(), this.SelectedAbilityGrid.GetNumAvailableSlots());
      if (Object.op_Inequality((Object) availableAbility, (Object) null))
        this.AddAbility(availableAbility);
    }
    while (Object.op_Inequality((Object) availableAbility, (Object) null));
  }

  public void RemoveAllAbilities()
  {
    this.SelectedAbilityGrid.RemoveAllAbilities();
    this.AbilityRoster.RemoveAllAbilities(this.SelectedAbilityGrid.get_RemainingAP(), this.SelectedAbilityGrid.GetNumAvailableSlots());
  }

  public void AddAbility(CommanderAbilitySelectionButton Button)
  {
    if (!this.SelectedAbilityGrid.AbilityAdded(Button.get_Ability(), false))
      return;
    Button.AbilityAdded();
    this.AbilityRoster.AbilityAdded(this.SelectedAbilityGrid.get_RemainingAP(), this.SelectedAbilityGrid.GetNumAvailableSlots());
  }

  public void RemoveAbility(CommanderAbilitySelectionButton Button)
  {
    Button.AbilityRemoved();
    this.SelectedAbilityGrid.AbilityRemoved(Button);
    this.AbilityRoster.AbilityRemoved(Button, this.SelectedAbilityGrid.get_RemainingAP(), this.SelectedAbilityGrid.GetNumAvailableSlots());
  }

  [CompilerGenerated]
  [SpecialName]
  public 딶.딞 get_Calculator() => this.딟;
}
