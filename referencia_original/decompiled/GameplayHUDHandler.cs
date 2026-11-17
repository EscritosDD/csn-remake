// Decompiled with JetBrains decompiler
// Type: GameplayHUDHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class GameplayHUDHandler : BaseHUDScreenHandler
{
  public AudioShader2 EndTurnPanelOpenAudio;
  public PausePanelHandler PausePanelPrefab;
  public EndTurnPanelHandler EndTurnPanelPrefab;
  public AbandonGamePanelHandler AbandonGamePrefab;
  public ExitGamePanelHandler ExitGamePrefab;
  public ConfirmResetPanelHandler confirmResetPrefab;
  private PausePanelHandler 딟;
  private EndTurnPanelHandler 딟;
  private AbandonGamePanelHandler 딟;
  private ExitGamePanelHandler 딟;
  private ConfirmResetPanelHandler 딟;
  public Material Team1MaterialBackground;
  public Material Team2MaterialBackground;
  public Material Team1SquadIcon;
  public Material Team2SquadIcon;
  public GuiGameTouchInputComponent HUDTouchComponent;
  public GuiButton2State3D UndoButton;
  public GameObject UndoButtonActive;
  public GameObject UndoButtonDisabled;
  public GuiButton2State3D EndTurnButton;
  public GameObject EndTurnBackground;
  public GameObject EndTurnForeground;
  public GuiButton3D EnemySquadButton;
  public GameObject EnemySquadButtonBackground;
  public GuiButton3D FriendlySquadButton;
  public GameObject FriendlySquadButtonBackground;
  public GameObject PauseGameButton;
  public GameObject TutorialHomeButton;
  public GuiButton3D AbilityInfoButton;
  public SquadSelectionHUDHandler PlayerSquadSelection;
  public SquadSelectionHUDHandler EnemySquadSelection;
  public AbilitySelectionHUDHandler AbilitySelection;
  public TurnTitleScreenHandler TurnsTitleScreen;
  public ReplayScreenHandler ReplayScreen;
  public MapNameScreenHandler MapNameScreen;
  public SquadDeploymentScreenHandler SquadDeployScreen;
  public UnitInfoScreenHandler UnitInfoScreen;
  public GameplayHUDUnitInfo CurrentPlayerUnitInfo;
  public GameplayHUDUnitEnemyInfo CurrentEnemyUnitInfo;
  public Camera GameCamera;
  public Camera BackgroundCamera;
  public GameObject BackgroundMesh;
  public GameObject BackgroundSilhouetteMesh;
  public GameResultOverlayHandler GameResultOverlay;
  public DynamicHighlightToolTipHandler AbilityHUDTooltipPrefab;
  public CapturePointDisplay PointDisplay;
  public CoinPotBoxHandler EndTurnCoinPot;
  public AbilityToolTipHandler abilityTooltipPrefab;
  public AbilityTooltipInfo[] abilityTooltips;
  public Transform Anim_StartPoint_Left;
  public Transform Anim_EndPoint_Left;
  public Transform Anim_StartPoint_Right;
  public Transform Anim_EndPoint_Right;
  public HUDCloudHandler cloudHandlerPrefab;
  public GameObject HUDBlocker;
  public ToolTipHandler[] tooltips;
  private bool 딟 = true;
  private bool 땄;
  private 땓.땦 딟;
  private 땓.땦 땄;
  private 딟.땫 딟;
  private 땓.땁 딟;
  private 땃.땢 딟;
  private LoadingScreenOverlayHandler 딟;
  public LoadingScreenOverlayHandler LoadingOverlayPrefab;
  public StorePurchaseConfirmationPanelHandler StorePurchasePrefab;
  public ErrorMessagehandler ErrorMessagePrefab;
  public GameObject TryOutHud;
  public GameObject TryOutPurchaseButton;
  private GameplayHUDHandler.땉 딟;
  private GameplayHUDHandler.땉 땄;
  private bool 딧;
  private bool 딢;
  private 딢.딴 딟;
  private HUDCloudHandler 딟;
  private bool 땃;

  private void Awake() => this.딟 = new 딟.땫(1024, (딟.땇) GlobalAppData.떏());

  private void OnDestroy()
  {
    this.딟.Dispose();
    this.딟 = (딟.땫) null;
  }

  public void ActivateGameplayHUD()
  {
    if (((Component) this).gameObject.activeInHierarchy)
      return;
    ((Component) this).gameObject.SetActive(true);
    this.땄 = true;
    this.ActivateMenu();
    this.HideTurnTitleScreen();
    this.UpdateCapturePointHUDVisibility();
    ((Component) this.FriendlySquadButton).renderer.sharedMaterial = this.get_Game().땼().딝() != 0 ? this.Team2SquadIcon : this.Team1SquadIcon;
    ((Component) this.EnemySquadButton).renderer.sharedMaterial = this.get_Game().땼().딝() != 0 ? this.Team1SquadIcon : this.Team2SquadIcon;
    this.ShowSquadGrid(true);
    this.HideCoinPot();
    this.HideAbilityInfoButton();
    this.HideTryoutHud();
    this.UpdateTutorialHomeButtonState(this.get_Game().땼().떔() is 딶.딖);
    if (this.딟 == null)
      return;
    this.딟(this);
  }

  public void DeactivateGameplayHUD()
  {
    if (((Component) this).gameObject.activeInHierarchy)
    {
      ((Component) this).gameObject.SetActive(false);
      this.땄 = true;
    }
    if (((Component) this.AbilitySelection).gameObject.activeInHierarchy)
      ((Component) this.AbilitySelection).gameObject.SetActive(false);
    this.HideCoinPot();
    this.HideCapturePointStatus();
    this.ShowSquadGrid(false);
    this.HideTryoutHud();
    if (this.땄 == null)
      return;
    this.땄(this);
  }

  public override void InitailiseScreenData() => this.UpdateGameUnitsInfoData();

  public void ToggleHUDVisible()
  {
    this.딟 = !this.딟;
    ((Component) this).gameObject.SetActive(this.딟);
    ((Component) this.PlayerSquadSelection).gameObject.SetActive(this.딟);
    ((Component) this.EnemySquadSelection).gameObject.SetActive(this.딟);
    ((Component) this.AbilitySelection).gameObject.SetActive(this.딟);
    this.땄 = this.딟;
    if (this.딟)
      return;
    ((Component) this.HUDTouchComponent).gameObject.SetActive(true);
  }

  private void Update()
  {
    if (this.get_Game() != null)
    {
      if (this.CloudsAreOpen())
        this.HUDBlocker.SetActive(true);
      else
        this.HUDBlocker.SetActive(false);
    }
    this.UpdateHUDButtonStates();
    this.UpdateGameUnitsInfoData();
    this.땄 = false;
    this.UpdatePurchaseRequest();
    this.WaitForCoinPot();
    this.UpdateSelectedUnitsHealth();
  }

  private void UpdateSelectedUnitsHealth()
  {
    if (this.땄 != null)
      this.CurrentEnemyUnitInfo.UpdateUnitHealth(false);
    if (this.딟 == null)
      return;
    this.CurrentPlayerUnitInfo.UpdateUnitHealth(false);
  }

  private void WaitForCoinPot()
  {
    if (!this.딢 || !Object.op_Equality((Object) this.EndTurnCoinPot, (Object) null) && this.EndTurnCoinPot.IsActive())
      return;
    this.딢 = false;
    this.get_Game().딷()?.땁();
  }

  private void UpdatePurchaseRequest()
  {
    if (this.딟 == null || !this.딟.딟())
      return;
    this.딟.Close();
    if (this.딟.땄())
    {
      StorePurchaseConfirmationPanelHandler confirmationPanelHandler = Object.Instantiate((Object) this.StorePurchasePrefab) as StorePurchaseConfirmationPanelHandler;
      ((Component) confirmationPanelHandler).transform.parent = ((Component) this.UICamera).transform;
      ((Component) confirmationPanelHandler).transform.localPosition = new Vector3(0.0f, 0.0f, 1f);
      confirmationPanelHandler.Init(this.딟.땃(), this.딟, ((Component) this.UICamera).transform);
      if (this.get_Game().땼().떔() is 딶.딴)
        confirmationPanelHandler.set_OnSuccessCallback(new Action(this.TryoutCharacterPurchaseSuccessful));
    }
    else
      this.DisplayErrorMessage(this.딟.딢(), !this.딟.딧() ? ErrorMessagehandler.땶.딟 : ErrorMessagehandler.땶.땽);
    this.딟 = (땃.땢) null;
  }

  private void DisplayErrorMessage(딟.땑 ErrorCode, ErrorMessagehandler.땶 ErrorType)
  {
    ErrorMessagehandler errorMessagehandler = Object.Instantiate((Object) this.ErrorMessagePrefab) as ErrorMessagehandler;
    errorMessagehandler.SetParent(((Component) this.UICamera).transform, new Vector3(0.0f, 0.0f, 1f));
    errorMessagehandler.Init(ErrorType, ErrorCode);
  }

  private void UpdateGameUnitsInfoData()
  {
    if (this.get_CurrStage() == null)
      return;
    땓.땦 딟 = this.딟;
    if (this.get_CurrStage().땈() != null)
    {
      if (this.get_CurrStage().땈() != this.딟)
        this.딟 = this.get_CurrStage().땈();
    }
    else if (this.딟 != null && this.딟.땴().땄 == this.get_Game().땼().딝())
      this.딟 = (땓.땦) null;
    if (this.get_CurrStage().땜() != null)
    {
      if (this.get_CurrStage().땜() != this.딟)
      {
        this.땄 = this.get_CurrStage().땜();
        this.딟 = this.get_CurrStage().땜();
      }
    }
    else if (this.딟 != null && this.딟.땴().땄 != this.get_Game().땼().딝())
      this.딟 = (땓.땦) null;
    if (딟 == this.딟 && (this.딟 == null || !this.딟.땻()) && this.get_CurrStage().땘() == this.get_CurrStage().딸())
      return;
    if (this.딟 != null)
    {
      this.ShowUnitInfo(true);
      this.딟.땓(false);
    }
    else
      this.ShowUnitInfo(false);
    this.AbilitySelection.ActivateMenu();
  }

  private bool GetUnitMaterialsAndName(
    int GameObjIdx,
    ref Material UnitThumb,
    ref Material UnitClass,
    ref string UnitName,
    ref bool UnitIsHuman)
  {
    if (this.get_Game().땼().땻()[GameObjIdx] is 땓.떀 떀 && Object.op_Inequality((Object) 떀.땁(), (Object) null))
    {
      UnitThumb = 떀.땟();
      UnitClass = 떀.땁().GUIIcon;
      UnitName = 떀.땂();
      UnitIsHuman = true;
      return true;
    }
    UnitIsHuman = false;
    UnitClass = (Material) null;
    땓.딲 딲 = this.get_Game().땼().땻()[GameObjIdx];
    if (딲 == null)
      return false;
    UnitThumb = 딲.땟();
    UnitName = 딲.땂();
    return true;
  }

  private void UpdateHUDButtonStates()
  {
    if (this.get_Game() == null)
      return;
    bool InTutorial = this.get_Game().땼().떔() is 딶.딖;
    딶.땯 TurnStage = this.get_Game().딷();
    this.UpdateUndoButtonState(TurnStage, InTutorial);
    this.UpdateEndTurnButtonState(TurnStage, InTutorial);
    if (Object.op_Inequality((Object) this.PauseGameButton, (Object) null) && this.땄)
      this.PauseGameButton.SetActive(!InTutorial);
    this.UpdateTutorialHomeButtonState(InTutorial);
  }

  private void UpdateTutorialHomeButtonState(bool InTutorial)
  {
    if (!Object.op_Inequality((Object) this.TutorialHomeButton, (Object) null) || !this.땄)
      return;
    this.TutorialHomeButton.SetActive(InTutorial);
  }

  public void UpdateUndoButtonState(딶.땯 TurnStage, bool InTutorial)
  {
    if (!Object.op_Inequality((Object) this.UndoButton, (Object) null))
      return;
    if (InTutorial && TurnStage != null && !TurnStage.딳())
    {
      this.UndoButton.SetButtonDisabled(true);
    }
    else
    {
      bool flag1 = this.get_Game().땼().떂().땥()[this.get_Game().땼().떂().땥().Count - 1] is 땃.땬;
      bool ShouldDisable = this.get_Game().땼().떂().땥().Count <= 1 || flag1;
      bool flag2 = false;
      bool flag3 = false;
      if (this.UndoButton.Disabled != ShouldDisable)
      {
        if (ShouldDisable)
        {
          if (this.딧)
          {
            flag2 = true;
            this.딧 = false;
          }
        }
        else
          flag3 = true;
        this.UndoButton.SetButtonDisabled(ShouldDisable);
      }
      if (flag2 && Object.op_Inequality((Object) this.UndoButtonDisabled, (Object) null))
      {
        string str = "Button_Rotate_CCW";
        ((Behaviour) this.UndoButtonDisabled.animation).enabled = false;
        ((Behaviour) this.UndoButtonDisabled.animation).enabled = true;
        this.UndoButtonDisabled.animation.Play(str);
      }
      if (!flag3 || !Object.op_Inequality((Object) this.UndoButtonActive, (Object) null))
        return;
      string str1 = "Button_Rotate_CCW";
      this.UndoButtonActive.animation[str1].enabled = true;
      this.UndoButtonActive.animation[str1].normalizedTime = 0.0f;
      this.UndoButtonActive.animation.Sample();
      this.UndoButtonActive.animation[str1].enabled = false;
    }
  }

  public void UpdateEndTurnButtonState(딶.땯 TurnStage, bool InTutorial)
  {
    if (!Object.op_Inequality((Object) this.EndTurnButton, (Object) null))
      return;
    if (InTutorial && TurnStage != null && !TurnStage.떔())
    {
      if (this.EndTurnButton.Disabled)
        return;
      this.EndTurnButton.SetButtonDisabled(true);
    }
    else
    {
      if (!this.EndTurnButton.Disabled)
        return;
      this.EndTurnButton.SetButtonDisabled(false);
    }
  }

  private void OnButtonPressed(string Command)
  {
    if (this.get_Game() == null || this.CloudsAreOpen())
      return;
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (GameplayHUDHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      GameplayHUDHandler.딟 = new Dictionary<string, int>(15)
      {
        {
          "SelectPlayerCharacter",
          0
        },
        {
          "SelectEnemyCharacter",
          1
        },
        {
          "CancelAbility",
          2
        },
        {
          "EndTurn",
          3
        },
        {
          "Undo",
          4
        },
        {
          "Pause",
          5
        },
        {
          "Home",
          6
        },
        {
          "SelectFriendlyUnitInfo",
          7
        },
        {
          "SelectEnemyUnitInfo",
          8
        },
        {
          "Store",
          9
        },
        {
          "TryoutStore",
          10
        },
        {
          "Skip",
          11
        },
        {
          "AbilityInfo",
          12
        },
        {
          "Reset",
          13
        },
        {
          "Exit",
          14
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!GameplayHUDHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        if (this.PlayerSquadSelection.get_SquadSelectionActive())
          break;
        this.OpenFriendlySquadGrid(true);
        this.OpenEnemySquadGrid(false);
        break;
      case 1:
        if (this.EnemySquadSelection.get_SquadSelectionActive())
          break;
        this.OpenEnemySquadGrid(true);
        this.OpenFriendlySquadGrid(false);
        break;
      case 2:
        if (this.get_Game() == null)
          break;
        딶.땯 땯 = this.get_Game().딷();
        if (땯 == null)
          break;
        땯.딟(딢.딴.땄);
        this.OpenEnemySquadGrid(false);
        break;
      case 3:
        this.get_Game().딷()?.딥();
        break;
      case 4:
        this.OnUndoButtonPressed();
        break;
      case 5:
        this.OpenPausePanel();
        break;
      case 6:
        this.OpenExitGamePanel(false);
        break;
      case 7:
        if (this.get_CurrStage() == null || this.get_CurrStage().땈() == null)
          break;
        break;
      case 8:
        if (this.get_CurrStage() == null || this.get_CurrStage().땜() == null)
          break;
        break;
      case 9:
        if (this.CurrentEnemyUnitInfo.CharacterIndex == -1)
          break;
        this.StartPurchaseRequest(this.get_Game().땼().땻()[this.CurrentEnemyUnitInfo.CharacterIndex] as 땓.떀);
        break;
      case 10:
        땓.떀 tryoutChar = this.GetTryoutChar();
        if (tryoutChar != null)
        {
          this.StartPurchaseRequest(tryoutChar);
          break;
        }
        Debug.LogWarning((object) "No tryout character found for this mission");
        break;
      case 11:
        if (!Object.op_Inequality((Object) this.EndTurnCoinPot, (Object) null))
          break;
        this.EndTurnCoinPot.Skip();
        break;
      case 12:
        if (!Object.op_Inequality((Object) this.AbilityInfoButton, (Object) null))
          break;
        this.DisplayAbilityTooltip(this.딟, true);
        break;
      case 13:
        if (!Object.op_Equality((Object) this.딟, (Object) null) && this.딟.ResetStarted())
          break;
        this.OpenResetGamePanel();
        break;
      case 14:
        if (!Object.op_Equality((Object) this.딟, (Object) null) && this.딟.ResetStarted())
          break;
        this.OpenAbandonGamePanel(false);
        break;
    }
  }

  private 땓.떀 GetTryoutChar()
  {
    for (int index = 0; index < this.get_Game().땼().땻().Count; ++index)
    {
      if (this.get_Game().땼().땻()[index] is 땓.떀)
        return this.get_Game().땼().땻()[index] as 땓.떀;
    }
    return (땓.떀) null;
  }

  private bool EndTurnPanelIsOpen() => Object.op_Inequality((Object) this.딟, (Object) null) && this.딟.get_ConfirmationPanelActive();

  public void OnUndoButtonPressed()
  {
    if (this.EndTurnPanelIsOpen() || this.UndoButton.Disabled)
      return;
    딶.땯 땯 = this.get_Game().딷();
    if (땯 == null)
      return;
    this.딧 = true;
    땯.땄(false);
    if (this.UndoButtonActive.animation.isPlaying)
      this.UndoButtonActive.animation.Stop();
    this.UndoButtonActive.animation.Play("Button_Rotate_CCW");
  }

  private void StartPurchaseRequest(땓.떀 Char)
  {
    딢.땥 땥 = GlobalAppData.땼().딸(Char.떔());
    GlobalAppData.땋().딟();
    this.딟 = new 땃.땢(땥.땭());
    this.딟 = Object.Instantiate((Object) this.LoadingOverlayPrefab) as LoadingScreenOverlayHandler;
    ((Component) this.딟).transform.parent = ((Component) this.UICamera).transform;
    ((Component) this.딟).transform.localPosition = new Vector3(0.0f, 0.0f, 1f);
  }

  public void OpenUnitInfoScreen(땓.땦 Unit, int TeamIdx)
  {
    this.DeactivateGameplayHUD();
    this.UnitInfoScreen.ActivateMenu();
    땓.떀 Character = this.get_Game().땼().땻()[Unit.땔()] as 땓.떀;
    this.UnitInfoScreen.SetUnitInfoScreenData(Unit, Character, TeamIdx);
  }

  public void TogglePausePanel()
  {
    if (this.EndTurnPanelIsOpen())
      return;
    if (Object.op_Inequality((Object) this.딟, (Object) null) && this.딟.get_IsOpen())
    {
      if (!this.딟.get_PausePanelActive())
        return;
      this.딟.ClosePausePanel(false);
    }
    else
    {
      if (!Object.op_Equality((Object) this.딟, (Object) null) && !this.딟.HasFinishedClosing())
        return;
      this.OpenPausePanel();
    }
  }

  public void OpenPausePanel()
  {
    this.딟 = Object.Instantiate((Object) this.PausePanelPrefab) as PausePanelHandler;
    this.딟.SetPausePanelStartPosition(new Vector3((float) ((Component) this).transform.localPosition.x, (float) (((Component) this).transform.localPosition.y + 0.5), (float) ((Component) this).transform.localPosition.z));
    this.딟.Init(this.Anim_StartPoint_Left, this.Anim_EndPoint_Left);
  }

  public void OpenAbandonGamePanel(bool fromPausePanel)
  {
    this.딟 = Object.Instantiate((Object) this.AbandonGamePrefab) as AbandonGamePanelHandler;
    this.딟.InitailiseAbandonGamePanel(new Vector3((float) ((Component) this).transform.localPosition.x, (float) (((Component) this).transform.localPosition.y + 0.5), (float) ((Component) this).transform.localPosition.z), fromPausePanel, this.Anim_StartPoint_Right, this.Anim_EndPoint_Right);
  }

  private void OpenResetGamePanel() => this.딟 = Object.Instantiate((Object) this.confirmResetPrefab, new Vector3((float) ((Component) this).transform.localPosition.x, (float) (((Component) this).transform.localPosition.y + 0.5), (float) ((Component) this).transform.localPosition.z), Quaternion.identity) as ConfirmResetPanelHandler;

  public void OpenExitGamePanel(bool ReturnScreenSet, bool fromPausePanel)
  {
    this.딟 = Object.Instantiate((Object) this.ExitGamePrefab) as ExitGamePanelHandler;
    this.딟.InitailiseExitGamePanel(new Vector3((float) ((Component) this).transform.localPosition.x, (float) (((Component) this).transform.localPosition.y + 0.5), (float) ((Component) this).transform.localPosition.z), ReturnScreenSet, fromPausePanel, this.Anim_StartPoint_Right, this.Anim_EndPoint_Right);
  }

  public void OpenExitGamePanel(bool fromPausePanel) => this.OpenExitGamePanel(false, fromPausePanel);

  public void OpenEndTurnVerification(bool APRemaining)
  {
    if (Object.op_Inequality((Object) this.EndTurnPanelOpenAudio, (Object) null))
    {
      double num = (double) this.EndTurnPanelOpenAudio.PlayOneShot(((Component) this).gameObject, 0.0f);
    }
    this.딟 = Object.Instantiate((Object) this.EndTurnPanelPrefab) as EndTurnPanelHandler;
    this.딟.InitailiseEndTurnPanel(new Vector3((float) ((Component) this).transform.localPosition.x, (float) (((Component) this).transform.localPosition.y + 1.0), (float) ((Component) this).transform.localPosition.z), APRemaining, this.Anim_StartPoint_Right, this.Anim_EndPoint_Right);
    ((Component) this.EndTurnButton).gameObject.SetActive(false);
  }

  public void OpenTurnTitleScreenWhileInGame()
  {
    if (!Object.op_Inequality((Object) this.TurnsTitleScreen, (Object) null))
      return;
    this.DeactivateGameplayHUD();
    ((Component) this.TurnsTitleScreen).gameObject.SetActive(true);
    this.TurnsTitleScreen.ActivateMenu();
    if (this.get_Game() == null || !this.get_Game().땼().땳())
      return;
    this.DisplayTooltip(딢.딮.딙);
  }

  public void HideTurnTitleScreen()
  {
    if (!Object.op_Inequality((Object) this.TurnsTitleScreen, (Object) null))
      return;
    this.TurnsTitleScreen.Deactivate();
  }

  public void HideCoinPot()
  {
    if (this.get_Game() == null)
      return;
    this.딢 = false;
    if (!Object.op_Implicit((Object) this.EndTurnCoinPot))
      return;
    this.EndTurnCoinPot.StopAnims();
    ((Component) this.EndTurnCoinPot).gameObject.SetActive(false);
  }

  public void ShowCoinPot()
  {
    this.딢 = true;
    if (!Object.op_Inequality((Object) this.EndTurnCoinPot, (Object) null) || this.get_Game().땼().떓() != 딶.딹.딧)
      return;
    this.EndTurnCoinPot.Show();
  }

  public void ShowAbilityInfoButton()
  {
    if (!Object.op_Inequality((Object) this.AbilityInfoButton, (Object) null))
      return;
    ((Component) this.AbilityInfoButton).gameObject.SetActive(true);
  }

  public void HideAbilityInfoButton()
  {
    if (!Object.op_Inequality((Object) this.AbilityInfoButton, (Object) null))
      return;
    ((Component) this.AbilityInfoButton).gameObject.SetActive(false);
  }

  public void OpenReplayScreen()
  {
    if (!Object.op_Inequality((Object) this.ReplayScreen, (Object) null))
      return;
    this.DeactivateGameplayHUD();
    ((Component) this.ReplayScreen).gameObject.SetActive(true);
    this.ReplayScreen.ActivateMenu();
  }

  public void CloseReplayScreen()
  {
    if (!Object.op_Inequality((Object) this.ReplayScreen, (Object) null))
      return;
    ((Component) this.ReplayScreen).gameObject.SetActive(false);
  }

  public void OpenMapNameScreen()
  {
    bool flag = 딶.딡.땴() != null && 딶.딡.땴().땼().떔().땭();
    if (!Object.op_Inequality((Object) this.MapNameScreen, (Object) null) || !flag)
      return;
    this.DeactivateGameplayHUD();
    ((Component) this.MapNameScreen).gameObject.SetActive(true);
    this.MapNameScreen.ActivateMenu();
  }

  public void OpenSquadDeploymentScreen()
  {
    if (!Object.op_Inequality((Object) this.SquadDeployScreen, (Object) null))
      return;
    this.DeactivateGameplayHUD();
    ((Component) this.SquadDeployScreen).gameObject.SetActive(true);
    this.SquadDeployScreen.ActivateMenu();
  }

  public bool IsPlayerCameraMovementAllowed() => Object.op_Equality((Object) this.딟, (Object) null) && Object.op_Equality((Object) this.딟, (Object) null) && Object.op_Equality((Object) this.딟, (Object) null) && Object.op_Equality((Object) this.딟, (Object) null);

  public void CloseAllHUDGridsOnEndTurn()
  {
    if (this.PlayerSquadSelection.SquadGrid.get_bGridOpen())
      this.PlayerSquadSelection.CloseSquadSelectionHUD();
    if (this.EnemySquadSelection.SquadGrid.get_bGridOpen())
      this.EnemySquadSelection.CloseSquadSelectionHUD();
    if (((Component) this.AbilitySelection).gameObject.activeInHierarchy)
      ((Component) this.AbilitySelection).gameObject.SetActive(false);
    this.get_Game().딷().때();
    ((Component) this.FriendlySquadButton).gameObject.SetActive(false);
    ((Component) this.EnemySquadButton).gameObject.SetActive(false);
  }

  public void CloseAnyOpenPanelInstancesOnExit(bool CloseInstantly)
  {
    if (Object.op_Inequality((Object) this.딟, (Object) null))
      this.딟.ClosePausePanel(CloseInstantly);
    if (Object.op_Inequality((Object) this.딟, (Object) null))
      this.딟.CloseConfirmationPanel(CloseInstantly);
    if (Object.op_Inequality((Object) this.딟, (Object) null))
      this.딟.CloseConfirmationPanel(CloseInstantly);
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    this.딟.CloseConfirmationPanel(CloseInstantly);
  }

  [SpecialName]
  private 딶.땯 get_CurrStage() => this.get_Game() == null ? (딶.땯) null : this.get_Game().딷();

  public void SetLoadingBackgroundActive(bool BackgroundActive)
  {
    if (Object.op_Inequality((Object) this.BackgroundCamera, (Object) null))
      ((Component) this.BackgroundCamera).gameObject.SetActive(BackgroundActive);
    if (Object.op_Inequality((Object) this.BackgroundMesh, (Object) null))
      this.BackgroundMesh.SetActive(BackgroundActive);
    if (!Object.op_Inequality((Object) this.BackgroundSilhouetteMesh, (Object) null))
      return;
    this.BackgroundSilhouetteMesh.SetActive(BackgroundActive);
  }

  public void SetGameCameraActive(bool GameCameraActive)
  {
    if (!Object.op_Inequality((Object) this.GameCamera, (Object) null))
      return;
    ((Component) this.GameCamera).gameObject.SetActive(GameCameraActive);
  }

  public void UpdateCapturePointStatus(
    딶.땖 GameState,
    bool[] ActiveZones,
    bool[] PrevActiveZones,
    bool ForceUpdateBlink)
  {
    if (!Object.op_Inequality((Object) this.PointDisplay, (Object) null))
      return;
    this.딟 = new 땓.땁(ActiveZones, PrevActiveZones);
    this.PointDisplay.Init(GameState, this.딟, ForceUpdateBlink);
  }

  public void ShowTryoutHud()
  {
    this.TryOutHud.SetActive(true);
    if (!GlobalAppData.떏().땥())
      return;
    this.TryOutPurchaseButton.SetActive(true);
  }

  public void HideTryoutHud()
  {
    this.TryOutHud.SetActive(false);
    this.TryOutPurchaseButton.SetActive(false);
  }

  private void UpdateCapturePointHUDVisibility()
  {
    if (this.get_Game() == null)
      return;
    if (this.get_Game().땼().떔().딢())
      this.ShowCapturePointStatus();
    else
      this.HideCapturePointStatus();
  }

  private void ShowSquadGrid(bool show)
  {
    if (this.get_Game() == null)
      return;
    show &= !(this.get_Game().땼().떔() is 딶.딖);
    ((Component) this.FriendlySquadButton).gameObject.SetActive(show);
    ((Component) this.EnemySquadButton).gameObject.SetActive(show);
    ((Component) this.CurrentPlayerUnitInfo).gameObject.SetActive(false);
    this.CurrentEnemyUnitInfo.Hide();
    this.PlayerSquadSelection.CloseSquadSelectionHUD();
    this.EnemySquadSelection.CloseSquadSelectionHUD();
  }

  private void OpenFriendlySquadGrid(bool open)
  {
    if (open)
    {
      ((Component) this.FriendlySquadButton).gameObject.SetActive(false);
      this.PlayerSquadSelection.ActivateMenu(this.get_Game().땼().딝() != 0 ? 딶.땂.땄 : 딶.땂.딟);
      ((Component) this.CurrentPlayerUnitInfo).gameObject.SetActive(false);
    }
    else
    {
      bool flag = this.딟 != null && this.딟.땴().땄 == this.get_Game().땼().딝();
      ((Component) this.FriendlySquadButton).gameObject.SetActive(!flag);
      this.PlayerSquadSelection.CloseSquadSelectionHUD();
      ((Component) this.CurrentPlayerUnitInfo).gameObject.SetActive(flag);
    }
  }

  private void OpenEnemySquadGrid(bool open)
  {
    if (open)
    {
      if (this.get_Game().땼().딥().Count == 1)
      {
        this.get_Game().딟.MoveToSpawn(딶.땂.땄);
      }
      else
      {
        ((Component) this.EnemySquadButton).gameObject.SetActive(false);
        this.EnemySquadSelection.ActivateMenu(this.get_Game().땼().딝() != 0 ? 딶.땂.딟 : 딶.땂.땄);
        this.CurrentEnemyUnitInfo.Hide();
      }
    }
    else
    {
      bool flag = this.딟 != null && this.딟.땴().땄 != this.get_Game().땼().딝();
      ((Component) this.EnemySquadButton).gameObject.SetActive(!flag);
      this.EnemySquadSelection.CloseSquadSelectionHUD();
      if (!flag)
        this.CurrentEnemyUnitInfo.Hide();
      else
        ((Component) this.CurrentEnemyUnitInfo).gameObject.SetActive(flag);
    }
  }

  private void ShowUnitInfo(bool show)
  {
    bool IsTutorial = this.get_Game().땼().떔() is 딶.딖;
    if (this.딟 == null)
    {
      ((Component) this.FriendlySquadButton).gameObject.SetActive(!IsTutorial);
      ((Component) this.EnemySquadButton).gameObject.SetActive(!IsTutorial);
      ((Component) this.CurrentPlayerUnitInfo).gameObject.SetActive(false);
      this.CurrentEnemyUnitInfo.Hide();
    }
    else
    {
      bool flag = this.딟.땴().땄 == this.get_Game().땼().딝();
      GameplayHUDUnitInfo gameplayHudUnitInfo;
      bool SquadGridActive;
      if (flag)
      {
        gameplayHudUnitInfo = this.CurrentPlayerUnitInfo;
        SquadGridActive = this.PlayerSquadSelection.SquadGrid.get_bGridOpen();
      }
      else
      {
        gameplayHudUnitInfo = (GameplayHUDUnitInfo) this.CurrentEnemyUnitInfo;
        SquadGridActive = this.EnemySquadSelection.SquadGrid.get_bGridOpen();
      }
      ((Component) gameplayHudUnitInfo).gameObject.SetActive(show);
      if (!show)
        return;
      Material UnitThumb = (Material) null;
      Material UnitClass = (Material) null;
      string UnitName = (string) null;
      bool UnitIsHuman = true;
      this.GetUnitMaterialsAndName(this.딟.땔(), ref UnitThumb, ref UnitClass, ref UnitName, ref UnitIsHuman);
      int NumTeamMembers = this.get_CurrStage().땃(this.딟.땴().땄);
      Material materialBackground;
      Color TeamColour;
      if (flag)
      {
        ((Component) this.FriendlySquadButton).gameObject.SetActive(false);
        if (this.get_Game().땼().딝() == 0)
        {
          materialBackground = this.Team1MaterialBackground;
          TeamColour = GlobalAppData.딟.GameAssets.Blue;
        }
        else
        {
          materialBackground = this.Team2MaterialBackground;
          TeamColour = GlobalAppData.딟.GameAssets.Red;
        }
      }
      else
      {
        ((Component) this.EnemySquadButton).gameObject.SetActive(false);
        if (this.get_Game().땼().딝() == 0)
        {
          materialBackground = this.Team2MaterialBackground;
          TeamColour = GlobalAppData.딟.GameAssets.Red;
        }
        else
        {
          materialBackground = this.Team1MaterialBackground;
          TeamColour = GlobalAppData.딟.GameAssets.Blue;
        }
      }
      gameplayHudUnitInfo.UpdateUnitInfoData(materialBackground, TeamColour, UnitThumb, UnitClass, UnitName, this.딟, this.딟.땔(), NumTeamMembers, SquadGridActive, IsTutorial, true);
      if (!Object.op_Inequality((Object) gameplayHudUnitInfo.UnitInfoButton, (Object) null) || UnitIsHuman == ((Component) gameplayHudUnitInfo.UnitInfoButton).gameObject.activeInHierarchy || SquadGridActive || IsTutorial)
        return;
      ((Component) gameplayHudUnitInfo.UnitInfoButton).gameObject.SetActive(UnitIsHuman);
    }
  }

  public void UpdateSquadGrids()
  {
    this.ShowSquadGrid(true);
    this.딟 = (땓.땦) null;
  }

  public void HideCapturePointStatus()
  {
    if (!Object.op_Inequality((Object) this.PointDisplay, (Object) null))
      return;
    this.PointDisplay.Hide();
  }

  public void ShowCapturePointStatus()
  {
    if (!Object.op_Inequality((Object) this.PointDisplay, (Object) null))
      return;
    this.PointDisplay.Show();
  }

  public void InitGameStatus(bool[] ActiveZones, bool[] PrevActiveZones, bool ForceUpdateBlink)
  {
    if (Object.op_Inequality((Object) this.ReplayScreen, (Object) null))
      this.ReplayScreen.InitGameStatus(ActiveZones, PrevActiveZones, ForceUpdateBlink);
    if (!Object.op_Inequality((Object) this.TurnsTitleScreen, (Object) null))
      return;
    this.TurnsTitleScreen.InitGameStatus(ActiveZones, PrevActiveZones, ForceUpdateBlink);
  }

  public void UpdateGameStatus()
  {
    if (Object.op_Inequality((Object) this.ReplayScreen, (Object) null))
      this.ReplayScreen.UpdateGameStatus();
    if (!Object.op_Inequality((Object) this.TurnsTitleScreen, (Object) null))
      return;
    this.TurnsTitleScreen.UpdateGameStatus();
  }

  private bool ShouldShowCapturePointHUD() => !(this.get_Game().땼().떔() is 딶.딖);

  private bool ShouldDisplayAbilityTooltips() => !(this.get_Game().땼().떔() is 딶.딖);

  public bool DisplayAbilityTooltip(딢.딴 ability, bool Force)
  {
    if (!this.ShouldDisplayAbilityTooltips())
      return false;
    bool flag = false;
    for (int index = 0; index < this.abilityTooltips.Length; ++index)
    {
      if (this.abilityTooltips[index].ability == ability)
      {
        this.abilityTooltipPrefab.Display(this.abilityTooltips[index], Force);
        flag = true;
        break;
      }
    }
    return flag;
  }

  public void SetSelectedAbility(딢.딴 Ability) => this.딟 = Ability;

  public void SetCallbacks(GameplayHUDHandler.땉 onActivated, GameplayHUDHandler.땉 onDeactivated)
  {
    this.딟 = onActivated;
    this.땄 = onDeactivated;
  }

  public void StartReset(bool closeConfirmPanel)
  {
    if (closeConfirmPanel && Object.op_Inequality((Object) this.딟, (Object) null))
      this.딟.Close();
    if (Object.op_Inequality((Object) this.딟, (Object) null) && this.딟.ResetStarted())
      return;
    if (Object.op_Equality((Object) this.딟, (Object) null))
      this.딟 = Object.Instantiate((Object) this.cloudHandlerPrefab, ((Component) this).transform.localPosition, Quaternion.identity) as HUDCloudHandler;
    this.딟.StartReset();
  }

  public bool CloudsAreOpen() => Object.op_Inequality((Object) this.딟, (Object) null) && this.딟.CloudsAreOpen();

  public void TryoutCharacterPurchaseSuccessful()
  {
    땓.떀 tryoutChar = this.GetTryoutChar();
    if (tryoutChar == null)
      return;
    딟.딦.딟("Tryout_Purchase", new Dictionary<string, string>()
    {
      {
        "character",
        tryoutChar.떔()
      },
      {
        "location",
        !GlobalAppData.땂() ? "world" : "store"
      }
    });
  }

  public void DisplayTooltip(딢.딮 tooltipType)
  {
    for (int index = 0; index < this.tooltips.Length; ++index)
    {
      ToolTipHandler tooltip = this.tooltips[index];
      if (!Object.op_Equality((Object) tooltip, (Object) null) && tooltip.Type == tooltipType)
      {
        tooltip.Display();
        break;
      }
    }
  }

  public 땓.땦 GetCurrentSelectedUnit() => this.딟;

  public delegate void 땉([In] GameplayHUDHandler obj0);
}
