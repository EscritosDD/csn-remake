// Decompiled with JetBrains decompiler
// Type: SelectGameModeScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class SelectGameModeScreenHandler : BaseMenuHandler
{
  private 딢.딲 딟;
  private LoadingScreenOverlayHandler 딟;
  private 딢.딳.땝 딟;
  private 딢.딪 딟;
  private bool 딟;
  public GameLimit GameLimitPrefab;
  public LoadingScreenOverlayHandler LoadingOverlayPrefab;
  public ToolTipHandler SinglePlayerTooltipPrefab;
  public ToolTipHandler MultiPlayerToolTipPrefab;
  public ToolTipHandler PassAndPlayToolTipPrefab;
  public ToolTipHandler InstantActionToolTipPrefab;
  public ToolTipHandler EndOfNewUserFlowToolTipPrefab;
  public EngineVersionChecker VersionCheckerPrefab;
  public ErrorMessagehandler ErrorMessagePrefab;
  public GameObject NewUserFlowHighlight;

  private void Awake()
  {
    base.딟 = ((Component) this).transform.position;
    this.NewUserFlowHighlight.gameObject.SetActive(false);
  }

  private void Update()
  {
    if (this.딟 != null && !this.딟.땺())
      this.딟.땄(Time.deltaTime);
    if (this.딟 != null && this.딟.땄())
    {
      딶.땖 GameToLoad = this.딟.딟();
      this.딟 = (딢.딳.땝) null;
      this.CloseLoadingOverlay();
      this.DeactivateMenu();
      FrontendHub.딟.LoadingScreen.ActivateMenu(GameToLoad, true);
    }
    if (this.딟 && this.딟.땺())
    {
      switch (this.딟.땓())
      {
        case 딢.떑.딟:
          this.CloseLoadingOverlay();
          Debug.Log((object) "Outcome of Instant Action is none");
          break;
        case 딢.떑.땄:
          this.StartMPSesssion();
          break;
        case 딢.떑.딧:
          this.JoinMPSession();
          break;
        case 딢.떑.딢:
          this.ContinueMission(this.딟.딶());
          break;
        case 딢.떑.땃:
          this.StartNewSinglePlayerSession();
          break;
        case 딢.떑.딶:
          this.ContinueMission(this.딟.딶());
          break;
        case 딢.떑.땓:
          this.DeactivateMenu();
          FrontendHub.딟.RegistrationScreen.ActivateMenu(false, true);
          break;
        case 딢.떑.땺:
          this.CloseLoadingOverlay();
          this.DisplayErrorMessage(딟.땑.딟, ErrorMessagehandler.땶.딷);
          break;
        case 딢.떑.땥:
          this.CloseLoadingOverlay();
          this.DisplayErrorMessage(딟.땑.딟, ErrorMessagehandler.땶.땢);
          break;
      }
      this.딟 = false;
    }
    if (this.딟 == null)
      return;
    this.딟.딟();
  }

  private void OnOpenMPFail() => this.딟 = (딢.딪) null;

  private void OnOpenMPSucccess()
  {
    this.딟 = (딢.딪) null;
    this.DeactivateMenu();
    FrontendHub.딟.MultiPlayerScreen.ActivateMenu();
  }

  private void CloseLoadingOverlay()
  {
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    this.딟.Close();
    this.딟 = (LoadingScreenOverlayHandler) null;
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (SelectGameModeScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      SelectGameModeScreenHandler.딟 = new Dictionary<string, int>(6)
      {
        {
          "Back",
          0
        },
        {
          "Challenges",
          1
        },
        {
          "MultiPlayer",
          2
        },
        {
          "PassAndPlay",
          3
        },
        {
          "GetMaps",
          4
        },
        {
          "InstantAction",
          5
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!SelectGameModeScreenHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        this.DeactivateMenu();
        FrontendHub.딟.MainScreen.ActivateMenu();
        break;
      case 1:
        딢.땚.땄("Challenges");
        this.DeactivateMenu();
        FrontendHub.딟.ChallengeLocationSelectionScreen.ActivateMenu();
        break;
      case 2:
        딢.땚.땄("Multiplayer");
        if (GlobalAppData.떏().땥())
        {
          this.딟 = new 딢.딪();
          this.딟.딟((GameLimit) null, this.VersionCheckerPrefab, new 딢.딪.떕(this.OnOpenMPFail), new 딢.딪.떕(this.OnOpenMPSucccess));
          break;
        }
        FrontendHub.딟.LoginHandler.LoginAttempt(true);
        break;
      case 3:
        this.DeactivateMenu();
        FrontendHub.딟.PassAndPlayScreen.ActivateMenu();
        break;
      case 4:
        if (GlobalAppData.떏().땥())
        {
          this.DeactivateMenu();
          FrontendHub.딟.StoreScreen.ActivateMenu(땃.땽.떂);
          break;
        }
        FrontendHub.딟.LoginHandler.LoginAttempt(true);
        break;
      case 5:
        딢.땚.땄("QuickPlay");
        this.딟 = Object.Instantiate((Object) this.LoadingOverlayPrefab, new Vector3(0.0f, 2.2f, 0.0f), Quaternion.identity) as LoadingScreenOverlayHandler;
        this.딟 = true;
        break;
    }
  }

  private void StartMPSesssion()
  {
    this.딟 = new 딢.딪();
    this.딟.딟(this.GameLimitPrefab, this.VersionCheckerPrefab, new 딢.딪.떕(this.OnMPGameStartFail), new 딢.딪.떕(this.OnMPGameStartSuccess));
  }

  private void OnMPGameStartFail()
  {
    this.딟 = (딢.딪) null;
    this.CloseLoadingOverlay();
  }

  private void OnMPGameStartSuccess()
  {
    this.딟 = (딢.딪) null;
    딧.땧 LoadingInfo = new 딧.땧(GlobalAppData.딢().Version, 딶.딹.딧);
    LoadingInfo.딟(GlobalAppData.땽().땩());
    LoadingInfo.딟(딢.땚.딢());
    this.DeactivateMenu();
    FrontendHub.딟.SquadPointSelectionScreen.ActivateMenu(true, LoadingInfo, (BaseMenuHandler) this);
  }

  private void JoinMPSession()
  {
    this.DeactivateMenu();
    딶.땖 GameToLoad = this.딟.딶();
    if (GameToLoad.딟.딧())
      딢.딳.땄(GameToLoad);
    else if (GameToLoad.땴())
    {
      딧.땧 LoadingInfo = new 딧.땧(GlobalAppData.딢().Version, 딶.딹.딧);
      LoadingInfo.딟(GameToLoad.딟.딟);
      LoadingInfo.딧(false);
      LoadingInfo.딟(GameToLoad.딟.땄);
      LoadingInfo.땄(GameToLoad.딟.딢);
      FrontendHub.딟.CommanderAbilityScreen.TryActivateMenu(딶.땂.딟, LoadingInfo, (BaseMenuHandler) this);
    }
    else
      FrontendHub.딟.LoadingScreen.ActivateMenu(GameToLoad, true);
  }

  private void StartNewSinglePlayerSession()
  {
    this.DeactivateMenu();
    SinglePlayerMissionAsset playerMissionAsset = GlobalAppData.땃(this.딟.땃());
    딢.땚.땃(playerMissionAsset);
    if (playerMissionAsset.AllowPlayerUnitChoice)
    {
      딧.땧 LoadingInfo = new 딧.땧(GlobalAppData.딢().Version, 딶.딹.땄);
      LoadingInfo.딟(playerMissionAsset.Id);
      LoadingInfo.땄(playerMissionAsset.PlayerUnitChoiceSquadPointsTier);
      LoadingInfo.딟(딢.땚.딟(playerMissionAsset));
      FrontendHub.딟.CommanderAbilityScreen.TryActivateMenu(딶.땂.딟, LoadingInfo, (BaseMenuHandler) this);
    }
    else
      this.딟 = 딢.딳.땄(playerMissionAsset);
  }

  private void ContinueMission(딶.땖 GameState)
  {
    if (GameState.떔().딢(GameState))
    {
      딢.딳.땄(GameState);
    }
    else
    {
      this.DeactivateMenu();
      FrontendHub.딟.LoadingScreen.ActivateMenu(GameState, true);
    }
  }

  public override void ActivateMenu()
  {
    base.ActivateMenu();
    this.딟 = new 딢.딲();
    this.딟.딟(10f);
    FrontendHub.딟.MoneyDisplay.UpdateDisplay(true, MoneyDisplayHandler.딤.딶);
    FrontendHub.딟.MainScreen.TryRequestNotifications();
    if (딢.땚.딧() || 딢.땚.딢())
      this.NewUserFlowHighlight.SetActive(true);
    else
      this.EndOfNewUserFlowToolTipPrefab.Display();
  }

  public override void DeactivateMenu()
  {
    this.CloseLoadingOverlay();
    base.DeactivateMenu();
  }

  private void DisplayErrorMessage(딟.땑 ErrorCode, ErrorMessagehandler.땶 ErrorType) => (Object.Instantiate((Object) this.ErrorMessagePrefab) as ErrorMessagehandler).Init(ErrorType, ErrorCode);
}
