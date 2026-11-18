// Decompiled with JetBrains decompiler
// Type: MultiPlayerScreen1Handler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[AddComponentMenu("Gui3D/Screens/MultiPlayer")]
public class MultiPlayerScreen1Handler : BaseMenuHandler
{
  private MultiPlayerResumePanelHandler 딟;
  private 땄.땕 딟;
  private 땄.딱 딟;
  private 딟.떊[] 딟;
  private GameObject 딟;
  private Transform 딟;
  private Transform 땄;
  private Transform 딧;
  private LoadingScreenOverlayHandler 딟;
  private Material 딟;
  private RandomGameButtonHandler 딟;
  private Transform 딢;
  private Transform 땃;
  private 딢.딪 딟;
  private 딢.땿 딟 = new 딢.땿();
  public float RefreshDelay = 15f;
  private int 딟;
  private bool 딟;
  private List<딟.떊> 딟 = new List<딟.떊>();
  public GameObject Overlay;
  public Camera IntroCamera;
  public GuiScrollList3D MatchList;
  public GameInviteMessageHandler GameInviteMessage;
  public Transform YourTurnDividerPrefab;
  public WaitingGameButton WaitingGameButtonPrefab;
  public GameObject NewGameButton;
  public GuiText3D NewGameText;
  public Transform ChallengeDividerPrefab;
  public Transform FriendWaitingDividerPrefab;
  public Transform WaitingForFriendsDividerPrefab;
  public GameButtonHandler GameButtonPrefab;
  public MultiPlayerResumePanelHandler ResumePanelPrefab;
  public GuiButton3D RefreshButton;
  public GuiButton3D MuteButton;
  public GuiButton3D UnmuteButton;
  public ToolTipHandler NewGameToolTipPrefab;
  public ToolTipHandler AcceptChallengePrefab;
  public LoadingScreenOverlayHandler LoadingOverlayPrefab;
  public ErrorMessagehandler ErrorMessage;
  public GameLimit GameLimitPrefab;
  public EngineVersionChecker VersionCheckerPrefab;
  public GameObject NewUserFlowHighlight;
  public RandomGameButtonHandler RandomGameButton;
  public Transform FriendGameButton;
  public Transform PlayAgainstDivider;
  public Transform StartPoint;
  public Transform EndPoint;
  public GuiText3D chatOnText;
  public GuiText3D chatOffText;

  private void Start()
  {
    base.딟 = ((Component) this).transform.position;
    this.딟 = ((Component) this.RefreshButton).renderer.material;
    this.NewUserFlowHighlight.SetActive(false);
  }

  private void StartRequestingMatches()
  {
    Resources.UnloadUnusedAssets();
    this.MatchList.RemoveAll(true);
    this.딟 = GlobalAppData.떏().땂();
    this.딟 = GlobalAppData.떏().딱();
    this.딟.Clear();
  }

  private void DisplayErrorMessage(
    딟.땑 ErrorCode,
    ErrorMessagehandler.땶 ErrorType,
    EventHandler OnClosing)
  {
    ErrorMessagehandler errorMessagehandler = Object.Instantiate((Object) FrontendHub.딟.ErrorMessage) as ErrorMessagehandler;
    errorMessagehandler.Init(ErrorType, ErrorCode);
    if (OnClosing == null)
      return;
    errorMessagehandler.OnClosing += OnClosing;
  }

  private void Update()
  {
    this.딟.딟();
    if (this.딟.땄())
    {
      this.딟.color = new Color(1f, 1f, 1f, 1f);
      this.RefreshButton.Disabled = false;
      this.RefreshButton.AnimateButton = true;
    }
    else
    {
      this.딟.color = new Color(1f, 1f, 1f, 0.5f);
      this.RefreshButton.Disabled = true;
      this.RefreshButton.AnimateButton = false;
    }
    if (this.딟 != null && this.딟.땄())
    {
      if (this.딟.딧())
      {
        this.딟 = false;
        this.딟 = this.딟.딟;
        foreach (딟.떊 Message in this.딟.딟)
        {
          if (Message.떎() is 땄.땭)
          {
            if (Object.op_Equality((Object) this.딟, (Object) null))
            {
              this.딟 = Object.Instantiate((Object) this.ChallengeDividerPrefab) as Transform;
              this.MatchList.AddItem(this.딟, 0.10625f);
            }
            if (Message.땺())
            {
              GlobalAppData.떏().땼(Message.땄());
            }
            else
            {
              GameInviteMessageHandler inviteMessageHandler = Object.Instantiate((Object) this.GameInviteMessage) as GameInviteMessageHandler;
              inviteMessageHandler.Init(Message, this.MatchList);
              this.MatchList.AddItem(((Component) inviteMessageHandler).transform, 0.125f);
              this.딟 = true;
              this.AcceptChallengePrefab.Display();
            }
          }
          if (Message.떎() is 땄.땥)
            this.딟.Add(Message);
          if (Message.떎() is 땄.딝)
            this.딟.Add(Message);
        }
      }
      else if (this.딟.딟())
        this.DisplayErrorMessage(((땄.땘) this.딟).딟, ErrorMessagehandler.땶.땽, new EventHandler(this.OnClosingErrorMessage));
      else
        this.DisplayErrorMessage(((땄.땘) this.딟).딟, ErrorMessagehandler.땶.딟, new EventHandler(this.OnClosingErrorMessage));
      this.딟 = (땄.딱) null;
    }
    if (this.딟 == null && this.딟 != null && this.딟.땄())
    {
      if (this.딟.딧())
      {
        if (this.딟.딟 != null)
        {
          List<땄.땞> list1 = ((IEnumerable<땄.땞>) this.딟.딟).Where<땄.땞>((Func<땄.땞, bool>) (obj0 => GlobalAppData.떏().딟(obj0) == 땓.딨.딧)).OrderBy<땄.땞, DateTime>((Func<땄.땞, DateTime>) (obj0 => obj0.딟)).ToList<땄.땞>();
          List<땄.땞> list2 = ((IEnumerable<땄.땞>) this.딟.딟).Where<땄.땞>((Func<땄.땞, bool>) (obj0 => GlobalAppData.떏().딟(obj0) == 땓.딨.땄)).OrderBy<땄.땞, DateTime>((Func<땄.땞, DateTime>) (obj0 => obj0.딟)).ToList<땄.땞>();
          if (list1.Count > 0 || this.딟.Count > 0)
          {
            this.딟 = true;
            if (Object.op_Equality((Object) this.땄, (Object) null))
            {
              this.땄 = Object.Instantiate((Object) this.FriendWaitingDividerPrefab) as Transform;
              this.MatchList.AddItem(this.땄, 0.10625f);
            }
          }
          foreach (땄.땞 SessionInfo in list1)
          {
            GameButtonHandler gameButtonHandler = Object.Instantiate((Object) this.GameButtonPrefab) as GameButtonHandler;
            gameButtonHandler.Init(this.MatchList, SessionInfo, true, (Action<딶.땖>) null, false);
            this.MatchList.AddItem(((Component) gameButtonHandler).transform, 0.125f);
          }
          foreach (딟.떊 떊 in this.딟)
          {
            딟.땮 땮 = 떊.떎() as 딟.땮;
            Action<딶.땖> GameStatePatcher;
            if (땮 is 땄.땥)
            {
              // ISSUE: object of a compiler-generated type is created
              // ISSUE: reference to a compiler-generated method
              GameStatePatcher = new Action<딶.땖>(new MultiPlayerScreen1Handler.딭()
              {
                딟 = 떊
              }.딟);
            }
            else
            {
              // ISSUE: object of a compiler-generated type is created
              // ISSUE: reference to a compiler-generated method
              GameStatePatcher = new Action<딶.땖>(new MultiPlayerScreen1Handler.땣()
              {
                딟 = 떊
              }.딟);
            }
            GameButtonHandler gameButtonHandler = Object.Instantiate((Object) this.GameButtonPrefab) as GameButtonHandler;
            gameButtonHandler.Init(this.MatchList, 땮.땄().SessionId, true, GameStatePatcher, true);
            this.MatchList.AddItem(((Component) gameButtonHandler).transform, 0.125f);
          }
          if (list2.Count > 0)
          {
            this.딟 = true;
            if (Object.op_Equality((Object) this.딧, (Object) null))
            {
              this.딧 = Object.Instantiate((Object) this.WaitingForFriendsDividerPrefab) as Transform;
              this.MatchList.AddItem(this.딧, 0.10625f);
            }
          }
          foreach (땄.땞 SessionInfo in list2)
          {
            GameButtonHandler gameButtonHandler = Object.Instantiate((Object) this.GameButtonPrefab) as GameButtonHandler;
            gameButtonHandler.Init(this.MatchList, SessionInfo, false, (Action<딶.땖>) null, false);
            this.MatchList.AddItem(((Component) gameButtonHandler).transform, 0.125f);
          }
          this.AddPlayGameButtons();
          if (this.딟)
          {
            this.NewGameButton.SetActive(true);
            ((Component) this.NewGameText).gameObject.SetActive(true);
            this.NewUserFlowHighlight.SetActive(딢.땚.딢());
          }
          else
          {
            this.NewGameButton.SetActive(false);
            ((Component) this.NewGameText).gameObject.SetActive(false);
          }
        }
      }
      else if (this.딟.딟())
        this.DisplayErrorMessage(((땄.땘) this.딟).딟, ErrorMessagehandler.땶.땽, new EventHandler(this.OnClosingErrorMessage));
      else
        this.DisplayErrorMessage(((땄.땘) this.딟).딟, ErrorMessagehandler.땶.딟, new EventHandler(this.OnClosingErrorMessage));
      this.딟.Close();
      this.딟 = (땄.땕) null;
    }
    if (this.딟 == null)
      return;
    this.딟.딟();
  }

  private void AddPlayGameButtons()
  {
    if (Object.op_Equality((Object) this.땃, (Object) null))
    {
      this.땃 = Object.Instantiate((Object) this.PlayAgainstDivider) as Transform;
      this.MatchList.AddItem(((Component) this.땃).transform, 0.10625f);
    }
    if (Object.op_Equality((Object) this.딟, (Object) null))
    {
      this.딟 = Object.Instantiate((Object) this.RandomGameButton) as RandomGameButtonHandler;
      if (!this.딟)
        this.딟.UpdateNUFIcon(딢.땚.딢());
      this.MatchList.AddItem(((Component) this.딟).transform, 0.125f);
      this.딟 = this.MatchList.GetCurrentIndex();
    }
    if (Object.op_Equality((Object) this.딢, (Object) null))
    {
      this.딢 = Object.Instantiate((Object) this.FriendGameButton) as Transform;
      this.MatchList.AddItem(((Component) this.딢).transform, 0.125f);
    }
    this.MatchList.AddItem(new GameObject().transform, 0.125f);
  }

  private void OnClosingErrorMessage(object Sender, EventArgs Args)
  {
    this.DeactivateMenu();
    FrontendHub.딟.ChallengeLocationSelectionScreen.ActivateMenu();
  }

  private List<딟.떊> FindNotificationsForSession(string SessionId)
  {
    List<딟.떊> 떊List = new List<딟.떊>();
    foreach (딟.떊 떊 in this.딟)
    {
      if (떊.떎() is 딟.땮 땮1 && 땮1.땄().SessionId == SessionId)
        떊List.Add(떊);
    }
    return 떊List;
  }

  public void HandlePushNotification(딟.딽 NotType)
  {
    if (NotType != 딟.딽.딟)
      return;
    Debug.Log((object) NotType);
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (MultiPlayerScreen1Handler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      MultiPlayerScreen1Handler.딟 = new Dictionary<string, int>(8)
      {
        {
          "Back",
          0
        },
        {
          "ClosePanel",
          1
        },
        {
          "NewGame",
          2
        },
        {
          "Refresh",
          3
        },
        {
          "Challenge",
          4
        },
        {
          "QuickGame",
          5
        },
        {
          "Mute",
          6
        },
        {
          "Unmute",
          7
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!MultiPlayerScreen1Handler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        this.DeactivateMenu();
        FrontendHub.딟.ChallengeLocationSelectionScreen.ActivateMenu();
        break;
      case 1:
        this.ClosePanels();
        break;
      case 2:
        this.NewUserFlowHighlight.SetActive(false);
        if (this.딟)
          this.MatchList.ScrollToElement(this.딟);
        this.딟.UpdateNUFIcon(딢.땚.딢());
        break;
      case 3:
        this.딟 = new 딢.딪();
        this.딟.딟((GameLimit) null, this.VersionCheckerPrefab, new 딢.딪.떕(this.OnRefreshFail), new 딢.딪.떕(this.OnRefreshSuccess));
        this.딟.딟(this.RefreshDelay);
        break;
      case 4:
        this.ClosePanels();
        this.DeactivateMenu();
        FrontendHub.딟.ChallengeFriendScreen.ActivateMenu(ChallengeFriendScreenHandler.땯.땄);
        break;
      case 5:
        딢.땚.땥();
        this.딟 = new 딢.딪();
        this.딟.딟(this.GameLimitPrefab, this.VersionCheckerPrefab, new 딢.딪.떕(this.OnQuickGameFail), new 딢.딪.떕(this.OnQuickGameSuccess));
        break;
      case 6:
        PlayerPrefs.SetInt("::all.muted", 1);
        ((Component) this.MuteButton).gameObject.SetActive(false);
        ((Component) this.UnmuteButton).gameObject.SetActive(true);
        ((Component) this.chatOffText).gameObject.SetActive(true);
        ((Component) this.chatOnText).gameObject.SetActive(false);
        딟.딦.딟("Chat_MuteAll");
        break;
      case 7:
        PlayerPrefs.DeleteKey("::all.muted");
        ((Component) this.MuteButton).gameObject.SetActive(true);
        ((Component) this.UnmuteButton).gameObject.SetActive(false);
        ((Component) this.chatOffText).gameObject.SetActive(false);
        ((Component) this.chatOnText).gameObject.SetActive(true);
        딟.딦.딟("Chat_UnmuteAll");
        break;
    }
  }

  private void OnRefreshFail() => this.딟 = (딢.딪) null;

  private void OnRefreshSuccess()
  {
    this.딟 = (딢.딪) null;
    this.ActivateMenu();
  }

  private void OnQuickGameFail() => this.딟 = (딢.딪) null;

  private void OnQuickGameSuccess()
  {
    this.딟 = (딢.딪) null;
    딧.땧 LoadingInfo = new 딧.땧(GlobalAppData.딢().Version, 딶.딹.딧);
    LoadingInfo.딟(GlobalAppData.땽().땩());
    LoadingInfo.딟(딢.땚.딢());
    this.ClosePanels();
    this.DeactivateMenu();
    FrontendHub.딟.SquadPointSelectionScreen.ActivateMenu(true, LoadingInfo, (BaseMenuHandler) this);
  }

  private void ClosePanels()
  {
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    this.딟.GetComponent<MenuOverlayHandler>().Close();
    ((Component) this.딟).GetComponent<MenuAnimatorHandler>().Close();
  }

  private void OnGameSelected(딶.땖 GameState)
  {
    this.딟 = Object.Instantiate((Object) this.Overlay, new Vector3(0.0f, 0.7f, 0.0f), Quaternion.identity) as GameObject;
    this.딟 = Object.Instantiate((Object) this.ResumePanelPrefab) as MultiPlayerResumePanelHandler;
    ((Component) this.딟).transform.parent = ((Component) this).transform;
    ((Component) this.딟).transform.localPosition = new Vector3(0.0f, (float) ((Component) this.딟).transform.localPosition.y, 0.0f);
    this.딟.Init(GameState, this.StartPoint, this.EndPoint);
  }

  private void OnContinueGame(딶.땖 GameState)
  {
    this.DeactivateMenu();
    if (GameState.딟.딧() || GameState.딟.딢())
      딢.딳.땄(GameState);
    else if (GameState.땴())
    {
      딧.땧 LoadingInfo = new 딧.땧(GlobalAppData.딢().Version, 딶.딹.딧);
      LoadingInfo.딟(GameState.딟.딟);
      LoadingInfo.딧(false);
      LoadingInfo.딟(GameState.딟.땄);
      LoadingInfo.땄(GameState.딟.딢);
      FrontendHub.딟.CommanderAbilityScreen.TryActivateMenu(딶.땂.딟, LoadingInfo, (BaseMenuHandler) this);
    }
    else
      FrontendHub.딟.LoadingScreen.ActivateMenu(GameState, true);
  }

  public override void ActivateMenu()
  {
    base.ActivateMenu();
    if (((Component) this.IntroCamera).gameObject.activeInHierarchy)
      ((Component) this.IntroCamera).gameObject.SetActive(false);
    this.ClosePanels();
    this.MatchList.UpdateItemClipping();
    this.StartRequestingMatches();
    FrontendHub.딟.MoneyDisplay.UpdateDisplay(true, MoneyDisplayHandler.딤.땺);
    this.딟 = Object.Instantiate((Object) this.LoadingOverlayPrefab) as LoadingScreenOverlayHandler;
    this.딟.딟(this.RefreshDelay);
    if (ChatDisplay.딟())
    {
      ((Component) this.UnmuteButton).gameObject.SetActive(true);
      ((Component) this.MuteButton).gameObject.SetActive(false);
      ((Component) this.chatOffText).gameObject.SetActive(true);
      ((Component) this.chatOnText).gameObject.SetActive(false);
    }
    else
    {
      ((Component) this.UnmuteButton).gameObject.SetActive(false);
      ((Component) this.MuteButton).gameObject.SetActive(true);
      ((Component) this.chatOnText).gameObject.SetActive(true);
      ((Component) this.chatOffText).gameObject.SetActive(false);
    }
  }

  public override void DeactivateMenu()
  {
    this.딟 = (딢.딪) null;
    this.ClosePanels();
    this.MatchList.RemoveAll(true);
    base.DeactivateMenu();
  }
}
