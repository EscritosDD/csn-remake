// Decompiled with JetBrains decompiler
// Type: SquadSelectionScreenHandlerNew
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Gui3D/Screens/Squad Selection New")]
public class SquadSelectionScreenHandlerNew : BaseMenuHandler
{
  public SquadSelectionUnitRoster UnitRoster;
  public SquadSelectionSelectedUnitGrid SelectedUnitGrid;
  public GuiButton3D NextButton;
  public GameObject NextButtonDisabled;
  public GuiButton3D RemoveAllButton;
  public Shader ButtonNAShader;
  public bool DisplayArrows;
  public GameObject MoreArrowLeft;
  public GuiText3D MoreTextLeft;
  public GameObject MoreArrowRight;
  public GuiText3D MoreTextRight;
  public ToolTipHandler SquadSelectionToolTip;
  public LoadingScreenOverlayHandler SendingOverlayPrefab;
  public GameObject NewUserFlowHighlight;
  public Transform SquadPointWarningPrefab;
  private 딶.땂 딟;
  private 딧.땧 딟;
  private new BaseMenuHandler 딟;
  private 딢.딳.땝 딟;
  private List<땓.떀> 딟 = new List<땓.떀>();
  private List<땓.떀> 땄 = new List<땓.떀>();
  private 딢.딬 딟;
  private 딶.딞 딟;
  private string 딟;
  private bool 딟;
  private bool 땄;
  private 땃.땃 딟;
  private LoadingScreenOverlayHandler 딟;
  private Transform 딟;
  public MenuOverlayHandler MenuOverlayPrefab;
  private MenuOverlayHandler 딟;
  private InstantActionInfoBarHandler 딟;
  public InstantActionInfoBarHandler InstantActionInfoBarPrefab;
  private bool 딧;
  public OutnumberedMessageHandler OutnumberedMessagePrefab;
  public GameObject ScrollerButtonLeft;
  public GameObject ScrollerButtonRight;

  public void Awake()
  {
    base.딟 = ((Component) this).transform.position;
    ((Component) this.NextButton).gameObject.SetActive(false);
    this.NextButtonDisabled.SetActive(true);
    this.NewUserFlowHighlight.SetActive(false);
    this.딧 = false;
  }

  public void Start()
  {
    if (this.딟 != null)
      return;
    this.딟 = new 땃.땃(this.RemoveAllButton, this.ButtonNAShader);
  }

  public void Update()
  {
    this.UpdateButtonStates();
    if (this.DisplayArrows)
      this.UpdateArrows();
    if (this.딟 != null)
    {
      this.딟.딧();
      switch (this.딟.딟())
      {
        case 딢.땍.땄:
          this.딟 = this.딟.땄();
          break;
        case 딢.땍.딧:
        case 딢.땍.딢:
          this.딟 = (딢.딬) null;
          this.CloseSendingOverlay();
          break;
      }
    }
    if (this.딟 != null && this.딟.땄())
    {
      딶.땖 GameToLoad = this.딟.딟();
      this.딟 = (딢.딳.땝) null;
      this.DeactivateMenu(true);
      FrontendHub.딟.LoadingScreen.ActivateMenu(GameToLoad, true);
    }
    if (((Component) this.NextButton).gameObject.activeInHierarchy)
    {
      if (this.딟 != null)
        this.NewUserFlowHighlight.SetActive(this.딟.딢());
    }
    else
      this.NewUserFlowHighlight.SetActive(false);
    this.UpdateScrollerButtons();
  }

  public void OnNetworkError(땄.땘 Response)
  {
    딟.땑 딟 = Response.딟;
    ErrorMessagehandler errorMessagehandler = Object.Instantiate((Object) FrontendHub.딟.ErrorMessage) as ErrorMessagehandler;
    if (Response.딟())
    {
      errorMessagehandler.Init(ErrorMessagehandler.땶.땽, 딟.땑.딟);
    }
    else
    {
      switch (딟)
      {
        case 딟.땑.딝:
          errorMessagehandler.Init(ErrorMessagehandler.땶.떂, 딟);
          break;
        case 딟.땑.떎:
          errorMessagehandler.Init(ErrorMessagehandler.땶.딦, 딟);
          break;
        default:
          errorMessagehandler.Init(ErrorMessagehandler.땶.딟, 딟);
          break;
      }
    }
    this.CloseSendingOverlay();
  }

  private void UpdateButtonStates()
  {
    if (!this.SelectedUnitGrid.IsValid())
      return;
    if (this.SelectedUnitGrid.GetNumSelectedUnits() < 2 || this.SelectedUnitGrid.get_UsedAP() > this.딟.딶())
    {
      ((Component) this.NextButton).gameObject.SetActive(false);
      this.NextButtonDisabled.SetActive(true);
    }
    else
    {
      ((Component) this.NextButton).gameObject.SetActive(true);
      this.NextButtonDisabled.SetActive(false);
    }
    if (this.SelectedUnitGrid.GetNumSelectedUnits() <= 1)
      this.딟.땄();
    else
      this.딟.딟();
  }

  private void UpdateArrows()
  {
    if (Object.op_Inequality((Object) BaseMenuHandler.딟, (Object) this))
      return;
    if (this.UnitRoster.IsAtFirstElement(1))
    {
      this.MoreArrowLeft.SetActive(false);
      ((Component) this.MoreTextLeft).gameObject.SetActive(false);
    }
    else
    {
      this.MoreArrowLeft.SetActive(true);
      ((Component) this.MoreTextLeft).gameObject.SetActive(true);
    }
    if (this.UnitRoster.IsAtLastElement(1))
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

  private void CloseSendingOverlay()
  {
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    this.딟.Close();
    this.딟 = (LoadingScreenOverlayHandler) null;
  }

  private static string 딟()
  {
    string str = (string) null;
    List<땓.떀> 떀List = GlobalAppData.땽().땲();
    for (int index = 0; index < 떀List.Count; ++index)
    {
      떀List[index].땠();
      if (떀List[index].땁().ClassType == 땓.땅.땃)
      {
        str = 떀List[index].딳();
        break;
      }
    }
    return str;
  }

  public override void ActivateMenu() => this.ActivateMenu(this.딟, false, (딧.땧) null, (딶.딞) null, (BaseMenuHandler) null);

  public void ActivateMenu(
    딶.땂 Team,
    bool Restart,
    딧.땧 LoadingInfo,
    딶.딞 Calculator,
    BaseMenuHandler ReturnScreen)
  {
    string CommanderId = SquadSelectionScreenHandlerNew.딟();
    base.ActivateMenu();
    if (Restart)
    {
      this.딟 = LoadingInfo;
      this.딟 = Team;
      this.딟 = ReturnScreen;
      this.딟 = false;
      this.딟 = Calculator;
    }
    this.딟.딟((IEnumerable<땓.떀>) GlobalAppData.땽().땲());
    if (!string.IsNullOrEmpty(CommanderId))
      this.딟 = CommanderId;
    this.UnitRoster.Init(GlobalAppData.땽().땲(), Restart, CommanderId, this);
    this.SelectedUnitGrid.Init(this.딟.땓(), Restart, this.딟);
    FrontendHub.딟.MoneyDisplay.UpdateDisplay(true, MoneyDisplayHandler.딤.떂);
    if (this.딟 != null)
    {
      if (this.딟.딢())
        딢.땚.떂();
      this.딟 = Object.Instantiate((Object) this.InstantActionInfoBarPrefab) as InstantActionInfoBarHandler;
      this.딟.Init(this.딟);
    }
    this.땄 = false;
    if (!this.딧)
    {
      if (this.딟.땺() != 딶.딹.땄)
        return;
      SinglePlayerMissionAsset playerMissionAsset = GlobalAppData.땃(this.딟.딧());
      List<땓.떀> 떀List = GlobalAppData.땽().땲();
      if (playerMissionAsset.RecommendedMinUnits > 떀List.Count)
      {
        this.딧 = true;
        this.DisplayOutnumberedToolTip(playerMissionAsset.RecommendedMinUnits.ToString());
      }
      else
        this.SquadSelectionToolTip.Display();
    }
    else
      this.SquadSelectionToolTip.Display();
  }

  public void DeactivateMenu(bool ClearGrid)
  {
    this.DeactivateMenu();
    this.CloseSendingOverlay();
    if (ClearGrid)
    {
      this.SelectedUnitGrid.Clear();
      this.UnitRoster.Clear();
    }
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    Object.Destroy((Object) ((Component) this.딟).gameObject);
  }

  public override void DeactivateMenu()
  {
    base.DeactivateMenu();
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    Object.Destroy((Object) ((Component) this.딟).gameObject);
  }

  public void LoadingFinished()
  {
    if (!this.딟 && !string.IsNullOrEmpty(this.딟))
    {
      this.SelectedUnitGrid.UnitAdded(this.UnitRoster.AddCommanderToRoster(this.딟), true);
      this.딟 = true;
    }
    this.UnitRoster.UpdateUnitAvailableStatus(this.SelectedUnitGrid.get_RemainingAP(), this.SelectedUnitGrid.GetNumAvailableSlots());
  }

  private void OnButtonPressed(string Command)
  {
    if (this.딟 != null)
      return;
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (SquadSelectionScreenHandlerNew.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      SquadSelectionScreenHandlerNew.딟 = new Dictionary<string, int>(9)
      {
        {
          "Back",
          0
        },
        {
          "Barracks",
          1
        },
        {
          "RemoveAll",
          2
        },
        {
          "Random",
          3
        },
        {
          "BuyCharacter",
          4
        },
        {
          "Close",
          5
        },
        {
          "Next",
          6
        },
        {
          "ScrollerLeft",
          7
        },
        {
          "ScrollerRight",
          8
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!SquadSelectionScreenHandlerNew.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        this.DeactivateMenu(true);
        if (Object.op_Inequality((Object) this.딟, (Object) null))
        {
          this.딟.ActivateMenu();
          break;
        }
        FrontendHub.딟.CommanderAbilityScreen.TryActivateMenuBack();
        break;
      case 1:
        땓.떀 activeCharacter = this.UnitRoster.GetActiveCharacter();
        this.DeactivateMenu(false);
        FrontendHub.딟.BarracksScreen.ActivateMenu(this.딟, activeCharacter.딳(), 딢.딩.딧, true);
        break;
      case 2:
        this.RemoveAllUnits();
        break;
      case 3:
        this.RandomUnitSelection();
        break;
      case 4:
        if (GlobalAppData.떏().땥())
        {
          this.DeactivateMenu();
          FrontendHub.딟.StoreScreen.ActivateMenu(땃.땽.땓);
          break;
        }
        FrontendHub.딟.LoginHandler.LoginAttempt(true);
        break;
      case 5:
        if (!Object.op_Inequality((Object) this.딟, (Object) null))
          break;
        Object.Destroy((Object) ((Component) this.딟).gameObject);
        this.딟.Close();
        break;
      case 6:
        if (this.SelectedUnitGrid.GetNumSelectedUnits() < 2)
          break;
        bool flag = true;
        if (!this.땄 && this.ShouldDisplaySquadPointWarning())
        {
          this.딟 = Object.Instantiate((Object) this.SquadPointWarningPrefab) as Transform;
          this.딟.parent = ((Component) this).transform;
          GuiComponent3D.땄((GuiComponent3D) ((Component) this.딟).GetComponentInChildren<GuiButton3D>());
          Vector3 vector3;
          // ISSUE: explicit constructor call
          ((Vector3) ref vector3).\u002Ector((float) ((Component) this.딟).transform.position.x, (float) (((Component) this.딟).transform.position.y - 0.100000001490116), (float) ((Component) this.딟).transform.position.z);
          this.딟 = Object.Instantiate((Object) this.MenuOverlayPrefab) as MenuOverlayHandler;
          ((Component) this.딟).transform.position = vector3;
          flag = false;
          this.땄 = true;
        }
        if (this.딟.딢())
          딢.땚.땭();
        if (!flag)
          break;
        this.StartNewGame();
        break;
      case 7:
        this.UnitRoster.UnitSelectionList.DecrementScroller();
        break;
      case 8:
        this.UnitRoster.UnitSelectionList.IncrementScroller();
        break;
    }
  }

  private void UpdateScrollerButtons()
  {
    GuiScroller3D unitSelectionList = this.UnitRoster.UnitSelectionList;
    if (unitSelectionList.NumElements == 0)
    {
      this.ScrollerButtonLeft.SetActive(false);
      this.ScrollerButtonRight.SetActive(false);
    }
    else if (unitSelectionList.get_ActiveElement() == 0)
    {
      this.ScrollerButtonLeft.SetActive(false);
      this.ScrollerButtonRight.SetActive(true);
    }
    else if (unitSelectionList.get_ActiveElement() == unitSelectionList.NumElements - 1)
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

  private void DisplayOutnumberedToolTip(string SuggestedSquadSize)
  {
    object[] Params = new object[1]
    {
      (object) SuggestedSquadSize
    };
    (Object.Instantiate((Object) this.OutnumberedMessagePrefab) as OutnumberedMessageHandler).Init(Params);
  }

  private bool ShouldDisplaySquadPointWarning() => this.UnitRoster.CanAddMoreUnits(this.SelectedUnitGrid.get_RemainingAP(), this.SelectedUnitGrid.GetNumAvailableSlots());

  private void StartNewGame()
  {
    switch (this.딟.땺())
    {
      case 딶.딹.딟:
        if (this.딟 == 딶.땂.딟)
        {
          딧.땧 LoadingInfo = this.딟.딟();
          this.딟 = this.SelectedUnitGrid.FillCharacterList();
          this.DeactivateMenu(true);
          FrontendHub.딟.AuthScreen.ActivateMenu(딶.땂.땄, true, LoadingInfo);
          break;
        }
        this.땄 = this.SelectedUnitGrid.FillCharacterList();
        this.딟 = 딢.딳.딟(this.딟, this.땄, this.딟.땓(), this.딟.딧(), 0);
        break;
      case 딶.딹.땄:
        this.딟 = this.SelectedUnitGrid.FillCharacterList();
        SinglePlayerMissionAsset playerMissionAsset = GlobalAppData.땃(this.딟.딧());
        if (Object.op_Inequality((Object) playerMissionAsset, (Object) null))
        {
          this.딟 = 딢.딳.딟(playerMissionAsset, (IEnumerable<땓.떀>) this.딟);
          break;
        }
        Debug.LogError((object) "Failed to create single player mission");
        break;
      case 딶.딹.딧:
        if (Object.op_Equality((Object) this.딟, (Object) null))
          this.딟 = Object.Instantiate((Object) this.SendingOverlayPrefab, new Vector3(0.0f, 2.2f, 0.0f), Quaternion.identity) as LoadingScreenOverlayHandler;
        this.딟 = this.SelectedUnitGrid.FillCharacterList();
        if (this.딟.딝() != null)
        {
          if (GlobalAppData.땼().딟(this.딟.떂()).GenericData.PlayFirstTurnImmediately)
          {
            this.딟 = (딢.딬) new 땃.딧(this, this.딟, this.딟);
            break;
          }
          this.딟 = (딢.딬) new 땃.땄(this, this.딟, this.딟);
          break;
        }
        if (!string.IsNullOrEmpty(this.딟.땥()))
        {
          if (GlobalAppData.딢().GenericData.PlayFirstTurnImmediately)
          {
            this.딟 = (딢.딬) new 땃.딟(this, this.딟, this.딟);
            break;
          }
          this.딟 = (딢.딬) new 딢.땮(this, this.딟, this.딟);
          break;
        }
        this.딟 = (딢.딬) new 딢.땸(this, this.딟, this.딟);
        break;
    }
  }

  public void RandomUnitSelection()
  {
    this.RemoveAllUnits();
    SquadSelectionUnitButtonNew randomAvailableUnit;
    do
    {
      randomAvailableUnit = this.UnitRoster.GetRandomAvailableUnit(this.SelectedUnitGrid.get_RemainingAP(), this.SelectedUnitGrid.GetNumAvailableSlots(), this.SelectedUnitGrid.GetNumSelectedUnits());
      if (Object.op_Inequality((Object) randomAvailableUnit, (Object) null))
        this.AddUnit(randomAvailableUnit);
    }
    while (Object.op_Inequality((Object) randomAvailableUnit, (Object) null));
  }

  public void RemoveAllUnits()
  {
    this.SelectedUnitGrid.RemoveAllUnits();
    this.UnitRoster.RemoveAllUnits(this.SelectedUnitGrid.get_RemainingAP(), this.SelectedUnitGrid.GetNumAvailableSlots());
  }

  public void AddUnit(SquadSelectionUnitButtonNew Button)
  {
    if (!this.SelectedUnitGrid.UnitAdded(Button.Character, false))
      return;
    Button.UnitAdded();
    this.UnitRoster.UnitAdded(this.SelectedUnitGrid.get_RemainingAP(), this.SelectedUnitGrid.GetNumAvailableSlots());
  }

  public void RemoveUnit(SquadSelectionUnitButtonNew Button)
  {
    Button.UnitRemoved();
    this.SelectedUnitGrid.UnitRemoved(Button);
    this.UnitRoster.UnitRemoved(Button, this.SelectedUnitGrid.get_RemainingAP(), this.SelectedUnitGrid.GetNumAvailableSlots());
  }
}
