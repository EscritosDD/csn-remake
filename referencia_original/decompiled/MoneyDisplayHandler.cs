// Decompiled with JetBrains decompiler
// Type: MoneyDisplayHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

public class MoneyDisplayHandler : MonoBehaviour
{
  private bool 딟;
  private bool 땄;
  private static int 딟;
  private int 땄 = -1;
  public GuiText3D CoinsText;
  public XPProgressBar PlayerProgressBar;
  public GameObject PlayerXPBackground;
  public GuiText3D CurrentLevelNumberText;
  public GameObject CurrentLevelBackground;
  public GameObject ProfileSection;
  public GameObject TitleSection;
  public GuiText3D PageTitle;
  public GuiButton3D CoinsButton;
  public GameObject OfflineOverlay;
  public GuiButton3D StoreActiveButton;
  public GameObject StoreInactiveButton;
  public GameObject CoinsDisplay;
  public GameObject BUxDisplay;
  public GameObject ProfileDisplay;
  public ParticleSystem CoinVortex;
  public LocalisationEntry PlayGamesScreenTitle;
  public LocalisationEntry MultiplayerScreenTitle;
  public LocalisationEntry SingleplayerScreenTitle;
  public LocalisationEntry PassAndPlayScreenTitle;
  public LocalisationEntry BarracksScreenTitle;
  public LocalisationEntry FriendsScreenTitle;
  public LocalisationEntry ProfileScreenTitle;
  public LocalisationEntry CommanderSelectionScreenTitle;
  public LocalisationEntry CommanderAbilitySelectionScreenTitle;
  public LocalisationEntry SquadSelectionScreenTitle;
  public LocalisationEntry StoreScreenTitle;
  public LocalisationEntry SquadPointSelectionScreenTitle;
  public LocalisationEntry MapSelectionScreenTitle;
  public float LargeTextSize;
  public float SmallTextSize;
  public bool IsWebPlayer;
  public GameObject MaximiseButton;
  public GameObject MinimiseButton;

  private void Start()
  {
    GlobalAppData.떏().딟(new Action<딟.땬>(this.OnInventoryChanged));
    if (GlobalAppData.떏().딦() == null)
      return;
    this.OnInventoryChanged(GlobalAppData.떏().딦());
  }

  public void SetFullscreenToggleButtons()
  {
    if (Screen.fullScreen)
    {
      this.MaximiseButton.SetActive(false);
      this.MinimiseButton.SetActive(true);
    }
    else
    {
      this.MaximiseButton.SetActive(true);
      this.MinimiseButton.SetActive(false);
    }
  }

  private void OnDestroy()
  {
    GlobalAppData.떏().땄(new Action<딟.땬>(this.OnInventoryChanged));
    GlobalAppData.땄(this.PlayerXPBackground);
    if (Object.op_Inequality((Object) this.CurrentLevelBackground, (Object) null))
      GlobalAppData.땄(this.CurrentLevelBackground);
    GlobalAppData.땄(this.ProfileSection);
    GlobalAppData.땄(this.TitleSection);
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (MoneyDisplayHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      MoneyDisplayHandler.딟 = new Dictionary<string, int>(4)
      {
        {
          "GetMoney",
          0
        },
        {
          "Store",
          0
        },
        {
          "Profile",
          1
        },
        {
          "ToggleFullscreen",
          2
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!MoneyDisplayHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        if (GlobalAppData.떏().땥())
        {
          BaseMenuHandler.딟.DeactivateMenu();
          FrontendHub.딟.StoreScreen.ActivateMenu(땃.땽.딧);
          딟.딦.딟("Store_Accessed", new Dictionary<string, string>()
          {
            {
              "type",
              "CoinsAndRadBuxButton"
            }
          });
          break;
        }
        FrontendHub.딟.LoginHandler.LoginAttempt(true);
        break;
      case 1:
        if (BaseMenuHandler.딟 is PlayerProfilePanelHandler)
          break;
        BaseMenuHandler.딟.DeactivateMenu();
        FrontendHub.딟.ProfileScreen.ActivateMenu(BaseMenuHandler.딟);
        break;
      case 2:
        딢.딼.딟();
        break;
    }
  }

  private void Update()
  {
    VersionedGameData versionedGameData = GlobalAppData.딢();
    if (Object.op_Inequality((Object) versionedGameData, (Object) null))
    {
      int 땄 = this.땄;
      this.땄 = versionedGameData.GenericData.땄(GlobalAppData.땽().딣());
      this.PlayerProgressBar.InitForPlayer();
      if (땄 != this.땄)
      {
        this.CurrentLevelNumberText.Text = this.땄.ToString();
        this.CurrentLevelNumberText.UpdateMesh();
      }
      if (this.딟)
      {
        ((Component) this.PlayerProgressBar).gameObject.SetActive(true);
        this.PlayerXPBackground.SetActive(true);
        ((Component) this.CurrentLevelNumberText).gameObject.SetActive(true);
        if (Object.op_Inequality((Object) this.CurrentLevelBackground, (Object) null))
          this.CurrentLevelBackground.SetActive(true);
        this.딟 = false;
      }
    }
    if (!this.IsWebPlayer)
      return;
    this.SetFullscreenToggleButtons();
  }

  public void UpdateDisplay(bool ShowTitle, MoneyDisplayHandler.딤 PageName)
  {
    if (!((Component) this).gameObject.activeInHierarchy)
      ((Component) this).gameObject.SetActive(true);
    this.딟 = true;
    this.SetStoreButtonState(true);
    this.ProfileSection.SetActive(true);
    this.TitleSection.SetActive(false);
    ((Component) this.PageTitle).gameObject.SetActive(false);
    if (ShowTitle)
    {
      this.UpdatePageTitle(PageName);
      if (!this.IsWebPlayer)
      {
        ((Component) this.PlayerProgressBar).gameObject.SetActive(false);
        this.PlayerXPBackground.SetActive(false);
        ((Component) this.CurrentLevelNumberText).gameObject.SetActive(false);
        if (Object.op_Inequality((Object) this.CurrentLevelBackground, (Object) null))
          this.CurrentLevelBackground.SetActive(false);
      }
      this.TitleSection.SetActive(true);
      ((Component) this.PageTitle).gameObject.SetActive(true);
    }
    if (!GlobalAppData.떏().땥())
    {
      this.OfflineOverlay.SetActive(true);
      if (!this.IsWebPlayer)
        return;
      this.CoinsDisplay.SetActive(false);
      this.BUxDisplay.SetActive(false);
      this.ProfileDisplay.SetActive(false);
    }
    else
      this.OfflineOverlay.SetActive(false);
  }

  private void SetStoreButtonState(bool IsActive)
  {
    if (IsActive)
    {
      ((Component) this.StoreActiveButton).gameObject.SetActive(true);
      this.StoreInactiveButton.SetActive(false);
      this.CoinsButton.Disabled = false;
    }
    else
    {
      ((Component) this.StoreActiveButton).gameObject.SetActive(false);
      this.StoreInactiveButton.SetActive(true);
      this.CoinsButton.Disabled = true;
    }
  }

  private void UpdatePageTitle(MoneyDisplayHandler.딤 PageName)
  {
    switch (PageName)
    {
      case MoneyDisplayHandler.딤.땄:
        this.PageTitle.LocText = this.StoreScreenTitle;
        this.SetStoreButtonState(false);
        break;
      case MoneyDisplayHandler.딤.딧:
        this.PageTitle.LocText = this.BarracksScreenTitle;
        this.SetStoreButtonState(true);
        break;
      case MoneyDisplayHandler.딤.딢:
        this.PageTitle.LocText = this.ProfileScreenTitle;
        this.SetStoreButtonState(true);
        break;
      case MoneyDisplayHandler.딤.땃:
        this.PageTitle.LocText = this.FriendsScreenTitle;
        this.SetStoreButtonState(true);
        break;
      case MoneyDisplayHandler.딤.딶:
        this.PageTitle.LocText = this.PlayGamesScreenTitle;
        this.SetStoreButtonState(true);
        break;
      case MoneyDisplayHandler.딤.땓:
        this.PageTitle.LocText = this.SingleplayerScreenTitle;
        this.SetStoreButtonState(true);
        break;
      case MoneyDisplayHandler.딤.땺:
        this.PageTitle.LocText = this.MultiplayerScreenTitle;
        this.SetStoreButtonState(true);
        break;
      case MoneyDisplayHandler.딤.땥:
        this.PageTitle.LocText = this.PassAndPlayScreenTitle;
        this.SetStoreButtonState(true);
        break;
      case MoneyDisplayHandler.딤.딝:
        this.PageTitle.LocText = this.CommanderSelectionScreenTitle;
        this.SetStoreButtonState(true);
        break;
      case MoneyDisplayHandler.딤.떎:
        this.PageTitle.LocText = this.CommanderAbilitySelectionScreenTitle;
        this.SetStoreButtonState(true);
        break;
      case MoneyDisplayHandler.딤.떂:
        this.PageTitle.LocText = this.SquadSelectionScreenTitle;
        this.SetStoreButtonState(true);
        break;
      case MoneyDisplayHandler.딤.땭:
        this.PageTitle.LocText = this.MapSelectionScreenTitle;
        this.SetStoreButtonState(true);
        break;
      case MoneyDisplayHandler.딤.딦:
        this.PageTitle.LocText = this.SquadPointSelectionScreenTitle;
        this.SetStoreButtonState(true);
        break;
      case MoneyDisplayHandler.딤.땤:
        this.PageTitle.LocText = this.BarracksScreenTitle;
        this.SetStoreButtonState(true);
        break;
    }
    this.PageTitle.UpdateMesh();
  }

  public void OnInventoryChanged(딟.땬 Inventory)
  {
    int num = Inventory.딟(GlobalAppData.딧().GameSettings.CurrencyCoinsId);
    this.CoinsText.LocText = (LocalisationEntry) null;
    this.CoinsText.Text = num.ToString();
    this.CoinsText.Size = num < 1000000 ? this.LargeTextSize : this.SmallTextSize;
    this.CoinsText.UpdateMesh();
  }

  public enum 딤
  {
    딟,
    땄,
    딧,
    딢,
    땃,
    딶,
    땓,
    땺,
    땥,
    딝,
    떎,
    떂,
    땭,
    딦,
    땤,
  }
}
