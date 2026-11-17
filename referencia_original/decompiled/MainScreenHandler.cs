// Decompiled with JetBrains decompiler
// Type: MainScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[AddComponentMenu("Gui3D/Screens/Main Screen")]
public class MainScreenHandler : BaseMenuHandler
{
  private 땄.딱 딟;
  private bool 딟;
  private bool 땄;
  private bool 딧;
  private 땓.땒 딟;
  private bool 딢;
  private SettingsPanelHandler 딟;
  private 딟.떊[] 딟;
  public MessageScreenHandler YourTurnScreen;
  public MessageScreenHandler MessageScreen;
  public SettingsPanelHandler SettingsPanelPrefab;
  public Camera IntroCamera;
  public RandomStoreCharacter StoreCharacter;
  public GameObject FriendsNewIcon;
  public GameObject UnreadMessagesIcon;
  public ToolTipHandler BetweenTurnCoinBonusTooltip;
  public ToolTipHandler StartOfMPBonusTooltip;
  public ToolTipHandler EndOfMPBonusTooltip;
  public ToolTipHandler StoreToolTip;
  public ToolTipHandler MPTurnSubmittedWaitOpponentTooltip;
  public GuiText3D FriendNotificationsCountText;
  public GuiText3D UnreadMessagesText;
  public GameObject NewUserFlowArrow;
  public GameObject MainScreenSilhouette;
  public GameObject DefaultSilhouette;
  public Transform LeftPanelStartPosition;
  public Transform LeftPanelEndPosition;

  private void Start()
  {
    base.딟 = ((Component) this).transform.position;
    GlobalAppData.땼().땥();
    this.FriendsNewIcon.SetActive(false);
    this.UnreadMessagesIcon.SetActive(false);
    this.NewUserFlowArrow.SetActive(false);
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (MainScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      MainScreenHandler.딟 = new Dictionary<string, int>(9)
      {
        {
          "Play",
          0
        },
        {
          "Options",
          1
        },
        {
          "Store",
          2
        },
        {
          "QuickStore",
          3
        },
        {
          "Barracks",
          4
        },
        {
          "Profile",
          5
        },
        {
          "Messages",
          6
        },
        {
          "Friends",
          7
        },
        {
          "PassAndPlay",
          8
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!MainScreenHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        딢.땚.딶();
        this.DeactivateMenu();
        FrontendHub.딟.ChallengeLocationSelectionScreen.ActivateMenu();
        break;
      case 1:
        this.딟 = Object.Instantiate((Object) this.SettingsPanelPrefab) as SettingsPanelHandler;
        this.딟.Init(this.LeftPanelStartPosition, this.LeftPanelEndPosition);
        break;
      case 2:
        if (GlobalAppData.떏().땥())
        {
          this.DeactivateMenu();
          FrontendHub.딟.StoreScreen.ActivateMenu(땃.땽.딧);
          딟.딦.딟("Store_Accessed", new Dictionary<string, string>()
          {
            {
              "type",
              "StoreButton"
            }
          });
          break;
        }
        FrontendHub.딟.LoginHandler.LoginAttempt(true);
        break;
      case 3:
        if (GlobalAppData.떏().땥())
        {
          this.DeactivateMenu();
          FrontendHub.딟.StoreScreen.ActivateMenu(땃.땽.딧, this.StoreCharacter.get_CachedProductId());
          딟.딦.딟("Store_Accessed", new Dictionary<string, string>()
          {
            {
              "type",
              "SuggestedCharacter"
            }
          });
          break;
        }
        FrontendHub.딟.LoginHandler.LoginAttempt(true);
        break;
      case 4:
        this.DeactivateMenu();
        FrontendHub.딟.BarracksScreen.ActivateMenu(딢.딩.딟, false);
        break;
      case 5:
        this.DeactivateMenu();
        FrontendHub.딟.ProfileScreen.ActivateMenu(BaseMenuHandler.딟);
        break;
      case 6:
        if (GlobalAppData.떏().땥())
        {
          this.DeactivateMenu();
          this.MessageScreen.ActivateMenu(this, this.딟);
          딟.딦.딟("AccessNewsPage");
          break;
        }
        FrontendHub.딟.LoginHandler.LoginAttempt(true);
        break;
      case 7:
        if (GlobalAppData.떏().땥())
        {
          this.DeactivateMenu();
          FrontendHub.딟.ChallengeFriendScreen.ActivateMenu(ChallengeFriendScreenHandler.땯.딟);
          break;
        }
        FrontendHub.딟.LoginHandler.LoginAttempt(true);
        break;
      case 8:
        this.DeactivateMenu();
        FrontendHub.딟.PassAndPlayScreen.ActivateMenu();
        break;
    }
  }

  public override void ActivateMenu()
  {
    base.ActivateMenu();
    if (Object.op_Inequality((Object) this.MainScreenSilhouette, (Object) null))
    {
      this.MainScreenSilhouette.SetActive(true);
      this.DefaultSilhouette.SetActive(false);
    }
    this.StoreCharacter.Activate();
    ((Component) this.IntroCamera).gameObject.SetActive(true);
    this.TryRequestNotifications();
    if (GlobalAppData.땽().딟(딢.땹.딝) >= 5)
    {
      this.StoreToolTip.Display();
      GlobalAppData.땽().딟(딢.땹.딝, 0);
    }
    this.set_NumUnreadNewsItems(0);
    if (GlobalAppData.떏().땥() && (this.딟 == null || this.딢))
    {
      this.딟 = GlobalAppData.떏().딶();
      this.딢 = false;
    }
    this.NewUserFlowArrow.SetActive(딢.땚.땄());
    FrontendHub.딟.MoneyDisplay.UpdateDisplay(false, MoneyDisplayHandler.딤.딟);
  }

  public void TryRequestNotifications()
  {
    if (!GlobalAppData.떏().땥() || this.딟 != null)
      return;
    this.딟 = GlobalAppData.떏().땂();
    this.딟 = (딟.떊[]) null;
    this.set_NumberOfFriendRelationMessages(0);
    this.UpdateNotificationDisplays();
  }

  public override void DeactivateMenu()
  {
    base.DeactivateMenu();
    if (Object.op_Inequality((Object) this.MainScreenSilhouette, (Object) null))
    {
      this.MainScreenSilhouette.SetActive(false);
      this.DefaultSilhouette.SetActive(true);
    }
    this.StoreCharacter.Deactivate();
    ((Component) this.IntroCamera).gameObject.SetActive(false);
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    this.딟.Close();
  }

  public void Update()
  {
    if (this.딟 != null && this.딟.땄() && this.딟.딧())
    {
      this.딟 = this.딟.딟;
      foreach (딟.떊 떊 in this.딟.딟)
      {
        if (떊.떎() is 땄.떏)
        {
          MainScreenHandler mainScreenHandler = this;
          mainScreenHandler.set_NumberOfFriendRelationMessages(mainScreenHandler.get_NumberOfFriendRelationMessages() + 1);
        }
      }
      this.UpdateNotificationDisplays();
      this.딟 = (땄.딱) null;
    }
    if (GlobalAppData.땽().땹())
    {
      if (!this.딟)
      {
        this.MPTurnSubmittedWaitOpponentTooltip.Display();
        this.StartOfMPBonusTooltip.Display();
        this.딟 = true;
      }
      if (!this.딧)
      {
        this.딧 = true;
        FrontendHub.딟.MoneyDisplay.CoinVortex.Play();
        GlobalAppData.땽().딶(false);
      }
    }
    if (GlobalAppData.땽().딟(딢.땹.딶) > 0 && !this.땄)
    {
      this.땄 = true;
      this.EndOfMPBonusTooltip.Display();
    }
    this.UpdateUnreadNews();
  }

  private void UpdateUnreadNews()
  {
    if (this.딟 == null || this.딢 || !this.딟.땄())
      return;
    this.딢 = true;
    if (!this.딟.딧())
      return;
    DateTime dateTime = DateTime.MinValue;
    string str = PlayerPrefs.GetString("MessageScreenAccessTime");
    if (!string.IsNullOrEmpty(str))
      dateTime = Convert.ToDateTime(str);
    foreach (땓.땵 땵 in this.딟.딟.딟())
    {
      if (땵.땄() > dateTime)
      {
        MainScreenHandler mainScreenHandler = this;
        mainScreenHandler.set_NumUnreadNewsItems(mainScreenHandler.get_NumUnreadNewsItems() + 1);
      }
    }
    if (this.get_NumUnreadNewsItems() > 0)
    {
      this.UnreadMessagesIcon.SetActive(true);
      this.UnreadMessagesText.Text = this.get_NumUnreadNewsItems().ToString();
      this.UnreadMessagesText.LocText = (LocalisationEntry) null;
      this.UnreadMessagesText.UpdateMesh();
    }
    else
      this.UnreadMessagesIcon.SetActive(false);
  }

  private void UpdateNotificationDisplays()
  {
    if (this.get_NumberOfFriendRelationMessages() > 0)
    {
      this.FriendsNewIcon.SetActive(true);
      this.FriendNotificationsCountText.Text = this.get_NumberOfFriendRelationMessages().ToString();
      this.FriendNotificationsCountText.LocText = (LocalisationEntry) null;
      this.FriendNotificationsCountText.UpdateMesh();
    }
    else
      this.FriendsNewIcon.SetActive(false);
  }

  public bool HasInvite()
  {
    if (this.딟 != null)
    {
      foreach (딟.떊 떊 in this.딟)
      {
        if (떊.떎() is 땄.땭)
          return true;
      }
    }
    return false;
  }

  [CompilerGenerated]
  [SpecialName]
  public int get_NumberOfFriendRelationMessages() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public void set_NumberOfFriendRelationMessages(int value) => this.딟 = value;

  [CompilerGenerated]
  [SpecialName]
  public int get_NumUnreadNewsItems() => this.땄;

  [CompilerGenerated]
  [SpecialName]
  public void set_NumUnreadNewsItems(int value) => this.땄 = value;
}
