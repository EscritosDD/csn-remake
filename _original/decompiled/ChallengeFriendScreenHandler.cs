// Decompiled with JetBrains decompiler
// Type: ChallengeFriendScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

[AddComponentMenu("Gui3D/Screens/Friend Selection")]
public class ChallengeFriendScreenHandler : BaseMenuHandler
{
  private ChallengeFriendPanelHandler 딟;
  private 딢.딨 딟;
  private List<딢.땇> 딟 = new List<딢.땇>();
  private ChallengeFriendScreenHandler.땯 딟;
  private 딟.땫 딟;
  private LoadingScreenOverlayHandler 딟;
  private List<FriendSelectionButton> 딟 = new List<FriendSelectionButton>();
  private new Vector3 딟;
  private bool 딟;
  private Transform 딟;
  private Transform 땄;
  private 땄.땛 딟;
  private MessagePostedOverlayHandler 딟;
  public GameObject FriendSearchComponents;
  public GameObject FacebookOfflineComponents;
  public GameObject PostToFacebookComponents;
  public GameObject NoFriendsComponents;
  public GuiTextField3D SearchText;
  public Transform SearchResultMainListPos;
  public FriendSelectionButton FriendButtonPrefab;
  public GuiScrollList3D MainList;
  public ListDivider WarChestFriendsDivider;
  public ListDivider ChallengeFBFriendsDividerPrefab;
  public GameObject FacebookLoginButtonPrefab;
  public WarchestFriendButton WarchestFriendButtonPrefab;
  public ChallengeFriendPanelHandler ChallengePanelPrefab;
  public FriendRequestSentPanel FriendRequestSentPrefab;
  public MessagePostedOverlayHandler MessagePostedPrefab;
  public GuiButton3D MainBackButton;
  public GuiButton3D AddFriendButton;
  public GuiButton3D FacebookLoginButton;
  public GuiButton3D FacebookBackOneStepButton;
  public ListDivider ChallengeYourFriendsDividerPrefab;
  public GameObject FacebookMessageItemPrefab;
  public LocalisationEntry FacebookMessageText;
  public GuiMultiLineText3D FaceBookPostText;
  public ToolTipHandler AddingFriendsPrefab;
  public ToolTipHandler ChallengingFriendsPrefab;
  public LoadingScreenOverlayHandler LoadingOverlayPrefab;
  public Transform FriendsRequestDivider;
  public Transform WarchestFriendsArrowDivider;
  public FriendRequestButton FriendRequestButtonPrefab;
  public FacebookActionButton FacebookPostMessageButton;
  public FacebookActionButton FacebookInviteFriendButton;
  public FacebookActionButton FacebookAcceptPostButton;
  public LocalisationEntry PostSucceededText;
  public LocalisationEntry PostFailedText;
  public LocalisationEntry MessageSentText;
  public LocalisationEntry MessageFailedText;
  public LocalisationEntry EmailSubject;
  public LocalisationEntry EmailBody;
  public GameObject ScrollBar;
  public Transform StartPoint;
  public Transform EndPoint;

  private void OnDestroy()
  {
    GlobalAppData.딷().땄(new Action<Hashtable>(this.FacebookReceivedUserInfo));
    GlobalAppData.딷().땄(new Action<string>(ChallengeFriendScreenHandler.딟));
    GlobalAppData.딷().땄(new Action(this.FacebookMessageDialogCompleted));
    GlobalAppData.딷().딢(new Action(this.FacebookMessageDialogDidntComplete));
    GlobalAppData.딷().딢(new Action<string>(this.FacebookMessageDialogFailed));
    GlobalAppData.딷().딶(new Action(this.FacebookPostCompleted));
    GlobalAppData.딷().딶(new Action<string>(this.FacebookPostFailed));
  }

  private void Start()
  {
    GlobalAppData.딷().딟(new Action<Hashtable>(this.FacebookReceivedUserInfo));
    GlobalAppData.딷().딟(new Action<string>(ChallengeFriendScreenHandler.딟));
    GlobalAppData.딷().딟(new Action(this.FacebookMessageDialogCompleted));
    GlobalAppData.딷().딧(new Action(this.FacebookMessageDialogDidntComplete));
    GlobalAppData.딷().딧(new Action<string>(this.FacebookMessageDialogFailed));
    GlobalAppData.딷().땃(new Action(this.FacebookPostCompleted));
    GlobalAppData.딷().땃(new Action<string>(this.FacebookPostFailed));
    this.딟 = new 딟.땫(256, (딟.땇) GlobalAppData.떏());
    base.딟 = ((Component) this).transform.position;
    this.FriendSearchComponents.SetActive(false);
    this.딟 = ((Component) this.MainList).gameObject.transform.localPosition;
  }

  public void Refresh() => this.SetState(딢.딨.땄);

  public override void ActivateMenu() => this.ActivateMenu(false, ChallengeFriendScreenHandler.땯.땄);

  public void ActivateMenu(
    ChallengeFriendScreenHandler.땯 ChallengeFriendsReturnScreen)
  {
    this.ActivateMenu(true, ChallengeFriendsReturnScreen);
  }

  private void ActivateMenu(
    bool Restart,
    ChallengeFriendScreenHandler.땯 ChallengeFriendsReturnScreen)
  {
    this.ClosePanels();
    base.ActivateMenu();
    if (Restart)
      this.딟 = ChallengeFriendsReturnScreen;
    FrontendHub.딟.MoneyDisplay.UpdateDisplay(true, MoneyDisplayHandler.딤.땃);
    this.SetState(딢.딨.땄);
    GlobalAppData.땽().딧(딢.땹.땄);
    if (GlobalAppData.땽().딟(딢.땹.딧) > 0)
      this.AddingFriendsPrefab.Discard();
    if (GlobalAppData.땽().딟(딢.땹.딢) <= 0)
      return;
    this.ChallengingFriendsPrefab.Discard();
  }

  public override void DeactivateMenu()
  {
    this.ClosePanels();
    this.Clear();
    base.DeactivateMenu();
    ((Component) FrontendHub.딟.MoneyDisplay).gameObject.SetActive(true);
    this.딟.Dispose();
    this.딟 = new 딟.땫(256, (딟.땇) GlobalAppData.떏());
  }

  private void SetState(딢.딨 NewState)
  {
    if (Object.op_Inequality((Object) this.ScrollBar, (Object) null))
      this.ScrollBar.SetActive(false);
    this.딟 = NewState;
    switch (NewState)
    {
      case 딢.딨.땄:
        this.MainList.Reset();
        this.NoFriendsComponents.SetActive(false);
        this.FacebookOfflineComponents.SetActive(false);
        this.PostToFacebookComponents.SetActive(false);
        ((Component) this.MainList).gameObject.SetActive(true);
        ((Component) this.MainBackButton).gameObject.SetActive(true);
        ((Component) this.AddFriendButton).gameObject.SetActive(true);
        ((Component) this.FacebookLoginButton).gameObject.SetActive(true);
        ((Component) this.FacebookBackOneStepButton).gameObject.SetActive(false);
        if (Object.op_Equality((Object) this.딟, (Object) null))
          this.딟 = Object.Instantiate((Object) this.LoadingOverlayPrefab, new Vector3(0.0f, 2f, 0.0f), Quaternion.identity) as LoadingScreenOverlayHandler;
        this.딟.Clear();
        this.딟.Clear();
        this.딟 = true;
        GlobalAppData.땢().딧();
        GlobalAppData.땢().딟();
        this.FriendSearchComponents.SetActive(false);
        ((Component) this.MainList).gameObject.transform.localPosition = this.딟;
        if (GlobalAppData.딷().땃())
          GlobalAppData.딷().땄();
        if (!Object.op_Inequality((Object) this.ScrollBar, (Object) null))
          break;
        this.ScrollBar.SetActive(true);
        break;
      case 딢.딨.딧:
        this.MainList.Reset();
        ((Component) this.MainList).gameObject.SetActive(false);
        this.NoFriendsComponents.SetActive(true);
        this.FacebookOfflineComponents.SetActive(false);
        this.PostToFacebookComponents.SetActive(false);
        this.FriendSearchComponents.SetActive(false);
        ((Component) this.MainBackButton).gameObject.SetActive(true);
        ((Component) this.AddFriendButton).gameObject.SetActive(false);
        ((Component) this.FacebookLoginButton).gameObject.SetActive(false);
        ((Component) this.FacebookBackOneStepButton).gameObject.SetActive(false);
        break;
      case 딢.딨.딢:
        this.MainList.Reset();
        ((Component) this.MainList).gameObject.SetActive(true);
        this.NoFriendsComponents.SetActive(false);
        this.FacebookOfflineComponents.SetActive(false);
        this.PostToFacebookComponents.SetActive(false);
        this.FriendSearchComponents.SetActive(true);
        this.SearchText.Clear();
        ((Component) this.MainBackButton).gameObject.SetActive(false);
        ((Component) this.AddFriendButton).gameObject.SetActive(true);
        ((Component) this.FacebookLoginButton).gameObject.SetActive(true);
        ((Component) this.FacebookBackOneStepButton).gameObject.SetActive(false);
        ((Component) this.MainList).gameObject.transform.position = this.SearchResultMainListPos.position;
        break;
      case 딢.딨.땃:
        ((Component) this.MainList).gameObject.SetActive(false);
        this.NoFriendsComponents.SetActive(false);
        this.FacebookOfflineComponents.SetActive(true);
        this.PostToFacebookComponents.SetActive(false);
        ((Component) this.MainBackButton).gameObject.SetActive(false);
        this.FriendSearchComponents.SetActive(false);
        if (GlobalAppData.딷().땃())
        {
          this.SetState(딢.딨.딶);
          break;
        }
        this.FacebookInviteFriendButton.Deactivate();
        this.FacebookPostMessageButton.Deactivate();
        break;
      case 딢.딨.딶:
        this.RefreshFacebookWrapper();
        break;
      case 딢.딨.땓:
        this.MainList.Reset();
        ((Component) this.MainList).gameObject.SetActive(false);
        this.NoFriendsComponents.SetActive(false);
        this.FacebookOfflineComponents.SetActive(true);
        this.PostToFacebookComponents.SetActive(false);
        ((Component) this.FacebookBackOneStepButton).gameObject.SetActive(true);
        this.FacebookInviteFriendButton.Activate();
        this.FacebookPostMessageButton.Activate();
        ((Component) this.MainBackButton).gameObject.SetActive(false);
        this.FriendSearchComponents.SetActive(false);
        break;
      case 딢.딨.땺:
        this.MainList.Reset();
        ((Component) this.MainList).gameObject.SetActive(false);
        this.NoFriendsComponents.SetActive(false);
        this.FacebookOfflineComponents.SetActive(false);
        ((Component) this.FacebookBackOneStepButton).gameObject.SetActive(true);
        this.PostToFacebookComponents.SetActive(true);
        ((Component) this.MainBackButton).gameObject.SetActive(false);
        this.FriendSearchComponents.SetActive(false);
        string facebookPostText1 = this.GetLocalisedFacebookPostText();
        if (string.IsNullOrEmpty(facebookPostText1))
          break;
        this.FaceBookPostText.Text = facebookPostText1;
        this.FaceBookPostText.UpdateMesh();
        break;
      case 딢.딨.땥:
        this.MainList.Reset();
        ((Component) this.MainList).gameObject.SetActive(false);
        this.NoFriendsComponents.SetActive(false);
        this.FacebookOfflineComponents.SetActive(true);
        this.PostToFacebookComponents.SetActive(false);
        ((Component) this.MainBackButton).gameObject.SetActive(false);
        this.FriendSearchComponents.SetActive(false);
        ((Component) this.FacebookBackOneStepButton).gameObject.SetActive(true);
        string facebookPostText2 = this.GetLocalisedFacebookPostText();
        if (string.IsNullOrEmpty(facebookPostText2))
          break;
        GlobalAppData.딷().딟(facebookPostText2);
        break;
    }
  }

  private string GetLocalisedFacebookPostText()
  {
    땄.땣 땣 = GlobalAppData.떏().땄(GlobalAppData.땽().떔(), false);
    if (땣 == null || !땣.딧())
      return (string) null;
    return 딧.딪.딟(this.FacebookMessageText, (object) 땣.딟.땄());
  }

  private void RefreshFacebookWrapper()
  {
    if (!GlobalAppData.딷().땃())
      GlobalAppData.딷().딟(true);
    else
      GlobalAppData.딷().땄();
  }

  private void ClosePanels()
  {
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    Object.Destroy((Object) ((Component) this.딟).gameObject);
  }

  private void OnErrorClosing(object Sender, EventArgs Args)
  {
    (Sender as ErrorMessagehandler).OnClosing -= new EventHandler(this.OnErrorClosing);
    this.GoBack();
  }

  private void FacebookReceivedUserInfo(Hashtable UserInfo)
  {
    string str = UserInfo[(object) "id"].ToString();
    this.딟 = GlobalAppData.떏().땺(str, GlobalAppData.딷().딢());
  }

  private void FacebookMessageDialogDidntComplete()
  {
    Debug.Log((object) nameof (FacebookMessageDialogDidntComplete));
    this.FacebookAcceptPostButton.Activate();
    this.SetState(딢.딨.땓);
  }

  private void FacebookMessageDialogCompleted()
  {
    Debug.Log((object) nameof (FacebookMessageDialogCompleted));
    this.OpenOverlay(this.MessageSentText);
    this.SetState(딢.딨.땓);
  }

  private void OpenOverlay(LocalisationEntry Entry)
  {
    this.딟 = Object.Instantiate((Object) this.MessagePostedPrefab) as MessagePostedOverlayHandler;
    this.딟.MessageText.LocText = Entry;
    this.딟.MessageText.UpdateMesh();
  }

  private void FacebookMessageDialogFailed(string Message)
  {
    Debug.Log((object) nameof (FacebookMessageDialogFailed));
    this.OpenOverlay(this.MessageFailedText);
    this.SetState(딢.딨.땓);
  }

  private void FacebookPostCompleted()
  {
    this.FacebookAcceptPostButton.Activate();
    this.OpenOverlay(this.PostSucceededText);
    this.SetState(딢.딨.땓);
  }

  private void FacebookPostFailed(string Message)
  {
    this.FacebookAcceptPostButton.Activate();
    this.OpenOverlay(this.PostFailedText);
    this.SetState(딢.딨.땓);
  }

  private static void 딟([In] string obj0)
  {
    Debug.Log((object) ("Facebook Login Failed: " + obj0));
    GlobalAppData.떏().때();
    if (!(GlobalAppData.땽().딳().Scheme == "facebook"))
      return;
    GlobalAppData.땽().땓(GlobalAppData.딟.땓());
  }

  private void Update()
  {
    switch (this.딟)
    {
      case 딢.딨.땄:
        if (this.딟)
        {
          딟.떊[] 떊Array = (딟.떊[]) null;
          땄.딽[] 딽Array = (땄.딽[]) null;
          bool flag1 = false;
          bool flag2 = false;
          if (!GlobalAppData.땢().땭() && !GlobalAppData.땢().떂())
          {
            if (GlobalAppData.땢().딦())
            {
              딽Array = GlobalAppData.땢().떎();
              떊Array = GlobalAppData.땢().땋();
              flag1 = true;
            }
            else
              flag2 = true;
          }
          if (flag2)
          {
            if (Object.op_Inequality((Object) this.딟, (Object) null))
            {
              this.딟.Close();
              this.딟 = (LoadingScreenOverlayHandler) null;
            }
            ErrorMessagehandler errorMessagehandler = Object.Instantiate((Object) FrontendHub.딟.ErrorMessage) as ErrorMessagehandler;
            errorMessagehandler.Init(ErrorMessagehandler.땶.딟, 딟.땑.딟);
            errorMessagehandler.OnClosing += new EventHandler(this.OnErrorClosing);
            this.딟 = false;
          }
          else if (flag1)
          {
            if (Object.op_Inequality((Object) this.딟, (Object) null))
            {
              this.딟.Close();
              this.딟 = (LoadingScreenOverlayHandler) null;
            }
            this.딟 = false;
            int num = 0;
            if (떊Array != null)
            {
              foreach (딟.떊 Message in 떊Array)
              {
                if (Message.떎() is 땄.떏)
                {
                  if (Object.op_Equality((Object) this.땄, (Object) null))
                  {
                    this.땄 = Object.Instantiate((Object) this.FriendsRequestDivider) as Transform;
                    this.MainList.AddItem(this.땄, 3f / 32f);
                  }
                  FriendRequestButton friendRequestButton = Object.Instantiate((Object) this.FriendRequestButtonPrefab) as FriendRequestButton;
                  friendRequestButton.Init(Message, this.MainList, this);
                  this.MainList.AddItem(((Component) friendRequestButton).transform, 7f / 64f);
                  ++num;
                }
              }
            }
            if (딽Array != null)
              this.딟 = ((IEnumerable<땄.딽>) 딽Array).Select<땄.딽, 딢.땇>((Func<땄.딽, 딢.땇>) (f => new 딢.땇(this.딟, f))).ToList<딢.땇>();
            if (this.딟.Count == 0 && num == 0)
            {
              this.SetState(딢.딨.딧);
            }
            else
            {
              this.딟.Sort(new Comparison<딢.땇>(ChallengeFriendScreenHandler.딟));
              foreach (딢.땇 Friend in this.딟)
              {
                if (Object.op_Equality((Object) this.딟, (Object) null))
                {
                  this.딟 = Object.Instantiate((Object) this.WarchestFriendsArrowDivider) as Transform;
                  this.MainList.AddItem(this.딟, 3f / 32f);
                }
                FriendSelectionButton friendSelectionButton = Object.Instantiate((Object) this.FriendButtonPrefab) as FriendSelectionButton;
                friendSelectionButton.Init(Friend, this.MainList);
                this.MainList.AddItem(((Component) friendSelectionButton).transform, 7f / 64f);
                this.딟.Add(friendSelectionButton);
                Friend.딟(friendSelectionButton);
              }
              if (this.딟.Count > 0)
                this.ChallengingFriendsPrefab.Display();
              this.MainList.AddItem(new GameObject().transform, 0.125f);
            }
          }
        }
        bool flag = true;
        foreach (GuiScrollList3D.땴 땴 in this.MainList.GetItems())
        {
          if (Object.op_Inequality((Object) ((Component) 땴.딟).GetComponent<FriendRequestButton>(), (Object) null))
            flag = false;
        }
        if (flag && Object.op_Inequality((Object) this.땄, (Object) null))
        {
          this.MainList.RemoveItem(this.땄);
          Object.Destroy((Object) ((Component) this.땄).gameObject);
          this.땄 = (Transform) null;
          break;
        }
        break;
      case 딢.딨.딶:
        if (GlobalAppData.딷().땃())
        {
          this.SetState(딢.딨.땓);
          break;
        }
        break;
    }
    if (this.딟 == null || !this.딟.땄())
      return;
    if (this.딟.딧() && this.딟.딟)
      GlobalAppData.땽().땓("facebook://" + this.딟.딟);
    this.딟 = (땄.땛) null;
  }

  private static int 딟([In] 딢.땇 obj0, [In] 딢.땇 obj1) => obj0.딧().땄().CompareTo(obj1.딧().땄());

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (ChallengeFriendScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      ChallengeFriendScreenHandler.딟 = new Dictionary<string, int>(11)
      {
        {
          "Back",
          0
        },
        {
          "BackOneStep",
          1
        },
        {
          "ClosePanel",
          2
        },
        {
          "FriendSearch",
          3
        },
        {
          "Facebook",
          4
        },
        {
          "FacebookLogin",
          5
        },
        {
          "SendFacebookMessage",
          6
        },
        {
          "FacebookPostMessage",
          7
        },
        {
          "FacebookInviteFriend",
          8
        },
        {
          "FacebookBackOneStep",
          9
        },
        {
          "EmailInvite",
          10
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!ChallengeFriendScreenHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        this.GoBack();
        break;
      case 1:
        this.SetState(딢.딨.땄);
        break;
      case 2:
        this.ClosePanels();
        break;
      case 3:
        this.SetState(딢.딨.딢);
        break;
      case 4:
        this.SetState(딢.딨.딶);
        break;
      case 5:
        this.SetState(딢.딨.딶);
        break;
      case 6:
        string facebookPostText = this.GetLocalisedFacebookPostText();
        if (string.IsNullOrEmpty(facebookPostText))
          break;
        this.FacebookAcceptPostButton.Deactivate();
        GlobalAppData.딷().딟(facebookPostText, GlobalAppData.땼().땟(), "RAD Soldiers", string.Empty, string.Empty);
        break;
      case 7:
        this.SetState(딢.딨.땺);
        break;
      case 8:
        this.SetState(딢.딨.땥);
        break;
      case 9:
        this.SetState(딢.딨.땄);
        break;
      case 10:
        this.TryEmailInvite();
        break;
    }
  }

  private void GoBack()
  {
    this.DeactivateMenu();
    if (Object.op_Inequality((Object) this.딟, (Object) null))
      this.딟.Close();
    switch (this.딟)
    {
      case ChallengeFriendScreenHandler.땯.땄:
        FrontendHub.딟.MultiPlayerScreen.ActivateMenu();
        break;
      case ChallengeFriendScreenHandler.땯.딢:
        FrontendHub.딟.ChallengeMissionMapScreen.ActivateMenu();
        break;
      default:
        FrontendHub.딟.MainScreen.ActivateMenu();
        break;
    }
  }

  private void OnFriendSelected(FriendSelectionButton FriendButton)
  {
    this.딟 = Object.Instantiate((Object) this.ChallengePanelPrefab) as ChallengeFriendPanelHandler;
    ((Component) this.딟).transform.parent = ((Component) this).transform;
    this.딟.Init(((Component) FriendButton).gameObject, FriendButton.get_Friend().딧().딟(), FriendButton.get_IsFacebookUser(), this.MainList, this.StartPoint, this.EndPoint);
  }

  private void OnSearch(string Name)
  {
    this.MainList.Reset();
    땄.땊 SearchResponse = GlobalAppData.떏().딟(Name, 땄.떀.딟);
    WarchestFriendButton warchestFriendButton = Object.Instantiate((Object) this.WarchestFriendButtonPrefab) as WarchestFriendButton;
    warchestFriendButton.Init(SearchResponse, this.MainList, this.FriendRequestSentPrefab);
    this.MainList.AddItem(((Component) warchestFriendButton).transform, 5f / 64f);
  }

  private void Clear() => this.MainList.Reset();

  private void SetEmailButtonStates(GuiButton3D[] buttons, bool active)
  {
    if (!active)
    {
      foreach (Component button in buttons)
        button.gameObject.SetActive(false);
    }
    else if (true)
    {
      ((Component) buttons[0]).gameObject.SetActive(true);
      ((Component) buttons[1]).gameObject.SetActive(false);
    }
    else
    {
      ((Component) buttons[0]).gameObject.SetActive(false);
      ((Component) buttons[1]).gameObject.SetActive(true);
    }
  }

  private void TryEmailInvite()
  {
    string stringToEscape1 = 딧.딪.딟(this.EmailSubject);
    string stringToEscape2 = 딧.딪.딟(this.EmailBody);
    GlobalAppData.딶(string.Format("mailto:?to=&subject={0}&body={1}", (object) Uri.EscapeUriString(stringToEscape1), (object) Uri.EscapeUriString(stringToEscape2)));
    딟.딦.딟("EmailInvite");
  }

  public enum 땯
  {
    딟,
    땄,
    딧,
    딢,
  }

  public enum 땨
  {
    딟,
    땄,
  }
}
