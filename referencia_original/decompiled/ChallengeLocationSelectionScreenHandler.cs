// Decompiled with JetBrains decompiler
// Type: ChallengeLocationSelectionScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ChallengeLocationSelectionScreenHandler : BaseMenuHandler
{
  private 딢.딪 딟;
  private 딢.딲 딟;
  private bool 딟;
  private 딢.딳.땝 딟;
  private LoadingScreenOverlayHandler 딟;
  private 딢.딳.땝 땄;
  private bool 땄;
  public TryBeforeYouBuyPanelHandler tryBeforeYouBuyPanel;
  public int tryBeforeYouBuyDateOffset;
  public GameObject tryBeforeYouBuyAvatar;
  private TryBeforeYouBuyPanelHandler 딟;
  public LoadingScreenOverlayHandler LoadingOverlayPrefab;
  public Camera WorldCamera;
  public GameLimit GameLimitPrefab;
  public ErrorMessagehandler ErrorMessagePrefab;
  public PackSelectionScreenHandler PackSelectionScreenPrefab;
  public EngineVersionChecker VersionCheckerPrefab;
  public ToolTipHandler SinglePlayerTooltipPrefab;
  public ToolTipHandler SinglePlayerTooltipNoAccountPrefab;
  public GameObject NewUserFlowHighlight;
  public GameObject[] LocationLabels;
  public FreeCharacterTooltipHandler freeCharacterTooltipPrefab;
  public ReplayTutorialConfirmationHandler TutorialConfirmationPrefab;
  private ReplayTutorialConfirmationHandler 딟;
  public CloudCoverLoadingScreen CloudCoverPrefab;
  public GameObject TryButton;

  private void Awake()
  {
    base.딟 = ((Component) this).transform.position;
    this.DeactivateCamera();
    this.NewUserFlowHighlight.gameObject.SetActive(false);
    foreach (GameObject locationLabel in this.LocationLabels)
      locationLabel.SetActive(false);
    this.땄 = true;
  }

  private void DeactivateCamera() => ((Component) this.WorldCamera).gameObject.SetActive(false);

  private void ActivateCamera() => ((Component) this.WorldCamera).gameObject.SetActive(true);

  public void ActivateMenu(bool checkEligibleForCharacter)
  {
    this.땄 = checkEligibleForCharacter;
    this.ActivateMenu();
  }

  public override void ActivateMenu()
  {
    base.ActivateMenu();
    FrontendHub.딟.MoneyDisplay.UpdateDisplay(true, MoneyDisplayHandler.딤.딶);
    this.딟 = new 딢.딲();
    this.딟.딟(10f);
    this.ActivateCamera();
    foreach (GameObject locationLabel in this.LocationLabels)
      locationLabel.SetActive(true);
    if (!string.IsNullOrEmpty(((딟.땇) GlobalAppData.떏()).땓()))
      this.SinglePlayerTooltipPrefab.Display();
    else
      this.SinglePlayerTooltipNoAccountPrefab.Display();
    if (this.땄 && GlobalAppData.땽().땂())
    {
      this.DeactivateMenu();
      FrontendHub.딟.FreeCharacterScreen.ActivateMenu();
    }
    else
    {
      GlobalAppData.땢().딟();
      FrontendHub.딟.MainScreen.TryRequestNotifications();
      this.InitTryBeforeYouBuyPopup();
    }
  }

  public void DeactivateMenu(bool DisableWorldCamera)
  {
    if (DisableWorldCamera)
      this.DeactivateCamera();
    this.CloseLoadingOverlay();
    foreach (GameObject locationLabel in this.LocationLabels)
      locationLabel.SetActive(false);
    if (Object.op_Inequality((Object) this.딟, (Object) null))
      Object.Destroy((Object) ((Component) this.딟).gameObject);
    base.DeactivateMenu();
  }

  public override void DeactivateMenu()
  {
    this.DeactivateCamera();
    this.CloseLoadingOverlay();
    foreach (GameObject locationLabel in this.LocationLabels)
      locationLabel.SetActive(false);
    this.땄 = true;
    base.DeactivateMenu();
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (ChallengeLocationSelectionScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      ChallengeLocationSelectionScreenHandler.딟 = new Dictionary<string, int>(7)
      {
        {
          "Back",
          0
        },
        {
          "Multiplayer",
          1
        },
        {
          "InstantAction",
          2
        },
        {
          "StartTutorial",
          3
        },
        {
          "ConfirmTutorialLoad",
          4
        },
        {
          "CancelTutorialLoad",
          5
        },
        {
          "Try",
          6
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!ChallengeLocationSelectionScreenHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        this.DeactivateMenu();
        FrontendHub.딟.MainScreen.ActivateMenu();
        break;
      case 1:
        딢.땚.땄("Multiplayer");
        if (GlobalAppData.떏().땥())
        {
          this.딟 = new 딢.딪();
          this.딟.딟((GameLimit) null, this.VersionCheckerPrefab, new 딢.딪.떕(this.OnOpenMPFail), new 딢.딪.떕(this.OnOpenMPSucccess));
          break;
        }
        FrontendHub.딟.LoginHandler.LoginAttempt(true);
        break;
      case 2:
        딢.땚.땄("QuickPlay");
        this.딟 = Object.Instantiate((Object) this.LoadingOverlayPrefab, new Vector3(0.0f, 2.2f, 0.0f), Quaternion.identity) as LoadingScreenOverlayHandler;
        this.딟 = true;
        break;
      case 3:
        this.OpenTutorialConfirmation();
        break;
      case 4:
        this.StartTutorial();
        this.딟.Close();
        break;
      case 5:
        this.딟.Close();
        break;
      case 6:
        if (!Object.op_Inequality((Object) this.딟, (Object) null))
          break;
        this.딟.Open();
        break;
    }
  }

  private void OpenTutorialConfirmation()
  {
    this.딟 = Object.Instantiate((Object) this.TutorialConfirmationPrefab) as ReplayTutorialConfirmationHandler;
    ((Component) this.딟).transform.parent = ((Component) this).gameObject.transform;
  }

  private void StartTutorial()
  {
    this.딟 = Object.Instantiate((Object) this.LoadingOverlayPrefab, new Vector3(0.0f, 2.2f, 0.0f), Quaternion.identity) as LoadingScreenOverlayHandler;
    GlobalAppData.딟(false);
    if (this.땄 != null)
      return;
    this.땄 = 딢.딳.딟(new List<땓.떀>(), new List<땓.떀>(), 0, GlobalAppData.딟.TutorialLevelId, GlobalAppData.딟.TutorialLevelScenario);
    딟.딦.딟("TutorialReplay");
  }

  private void Update()
  {
    if (this.딟 != null)
      this.딟.딟();
    if (this.딟 != null && !this.딟.땺())
      this.딟.땄(Time.deltaTime);
    if (this.땄 != null && this.땄.땄())
    {
      딶.땖 GameToLoad = this.땄.딟();
      this.땄 = (딢.딳.땝) null;
      this.DeactivateMenu();
      FrontendHub.딟.LoadingScreen.ActivateMenu(GameToLoad, true);
    }
    if (this.딟 != null && this.딟.땄())
    {
      딶.땖 GameToLoad = this.딟.딟();
      this.딟 = (딢.딳.땝) null;
      this.CloseLoadingOverlay();
      this.DeactivateMenu();
      FrontendHub.딟.LoadingScreen.ActivateMenu(GameToLoad, true);
    }
    if (!this.딟 || !this.딟.땺())
      return;
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
      case 딢.떑.딝:
        this.DeactivateMenu();
        FrontendHub.딟.MultiPlayerScreen.ActivateMenu();
        break;
    }
    this.딟 = false;
  }

  private void OnLocationSelected(string LocationId)
  {
    딢.땚.딟("Challenges", LocationId);
    딢.땃[] ChallengePackManifests = GlobalAppData.땼().떇(LocationId);
    if (ChallengePackManifests.Length == 0)
    {
      this.DeactivateMenu(true);
      FrontendHub.딟.MainScreen.ActivateMenu();
    }
    else
    {
      this.DeactivateMenu(false);
      FrontendHub.딟.ChallengePackSelectionScreen.ActivateMenu(ChallengePackManifests, this.WorldCamera);
    }
  }

  private void OnOpenMPFail() => this.딟 = (딢.딪) null;

  private void OnOpenMPSucccess()
  {
    this.딟 = (딢.딪) null;
    this.DeactivateMenu();
    FrontendHub.딟.MultiPlayerScreen.ActivateMenu();
  }

  [DebuggerHidden]
  private IEnumerator LoadChallengeMapCoroutine(string MissionId) => (IEnumerator) new ChallengeLocationSelectionScreenHandler.\u003CLoadChallengeMapCoroutine\u003Ec__Iterator15()
  {
    딟 = MissionId,
    땄 = MissionId,
    딟 = this
  };

  private void StartNewSinglePlayerSession() => this.StartCoroutine(this.LoadChallengeMapCoroutine(this.딟.땃()));

  private void ContinueMission(딶.땖 GameState)
  {
    if (GameState.떔().딢(GameState) || GameState.딟.딧())
    {
      딢.딳.땄(GameState);
    }
    else
    {
      this.DeactivateMenu();
      FrontendHub.딟.LoadingScreen.ActivateMenu(GameState, true);
    }
  }

  private void StartMPSesssion()
  {
    this.딟 = new 딢.딪();
    this.딟.딟(this.GameLimitPrefab, this.VersionCheckerPrefab, new 딢.딪.떕(this.OnMPGameStartFail), new 딢.딪.떕(this.OnMPGameStartSuccess));
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

  private void DisplayErrorMessage(딟.땑 ErrorCode, ErrorMessagehandler.땶 ErrorType) => (Object.Instantiate((Object) this.ErrorMessagePrefab) as ErrorMessagehandler).Init(ErrorType, ErrorCode);

  private void CloseLoadingOverlay()
  {
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    this.딟.Close();
    this.딟 = (LoadingScreenOverlayHandler) null;
  }

  private void OnDestroy() => this.CloudCoverPrefab = (CloudCoverLoadingScreen) null;

  private void InitTryBeforeYouBuyPopup()
  {
    if (Object.op_Inequality((Object) this.딟, (Object) null))
      Object.Destroy((Object) ((Component) this.딟).gameObject);
    this.딟 = Object.Instantiate((Object) this.tryBeforeYouBuyPanel) as TryBeforeYouBuyPanelHandler;
    if (this.딟.Init((BaseMenuHandler) this, this.tryBeforeYouBuyDateOffset))
    {
      ((Component) this.딟).gameObject.SetActive(false);
      this.tryBeforeYouBuyAvatar.renderer.sharedMaterial = this.딟.GetCharacterIcon();
      this.TryButton.SetActive(true);
    }
    else
    {
      Object.Destroy((Object) ((Component) this.딟).gameObject);
      this.TryButton.SetActive(false);
    }
  }
}
