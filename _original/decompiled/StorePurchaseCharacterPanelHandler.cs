// Decompiled with JetBrains decompiler
// Type: StorePurchaseCharacterPanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StorePurchaseCharacterPanelHandler : StorePanel
{
  private MenuAnimatorHandler 딟;
  private MenuOverlayHandler 딟;
  private 땃.딷 딟;
  private List<땄.땐> 딟 = new List<땄.땐>();
  private List<땃.딷> 딟 = new List<땃.딷>();
  private List<string> 딟 = new List<string>();
  private List<string> 땄 = new List<string>();
  private StorePanel_CharacterStats 딟;
  private 땃.딷 땄;
  private 땃.딷 딧;
  private 딧.딼 딟 = new 딧.딼();
  public GuiScrollList3D Scroller;
  public GuiButton3D PurchaseButton;
  public GuiButton3D tryButton;
  public GuiText3D CharacterNameText;
  public GuiText3D CoinsCostText;
  public GuiText3D CurrentCountText;
  public GameObject CoinsIcon;
  public GameObject ItemIcon;
  public Material AvatarIconMaterial;
  public GameObject LoadingIcon;
  public GameObject LockedInformation;
  public GuiText3D LevelXText;
  public StorePanel_CharacterStats CharacterStats;
  public MenuOverlayHandler OverlayPrefab;
  public StorePurchaseConfirmationPanelHandler PurchasePanelPrefab;
  public TryBeforeYouBuyPanelHandler tryBeforeYouBuyPanel;
  private TryBeforeYouBuyPanelHandler 딟;

  private void Start()
  {
  }

  public void Init(StoreItemButton.떎 StoreItemInfo, Transform StartPoint, Transform EndPoint)
  {
    // ISSUE: reference to a compiler-generated method
    this.set_LocalImageCache(new 딟.땫(512, (딟.땇) GlobalAppData.떏()));
    this.딟 = StoreItemInfo.딟;
    땓.딞 딞 = this.딟.땃().땃() as 땓.딞;
    this.딟 = ((Component) this).GetComponent<MenuAnimatorHandler>();
    this.딟.StartPoint = StartPoint;
    this.딟.EndPoint = EndPoint;
    this.딟.SetOnOpenFinishedCallback(new MenuAnimatorHandler.땔(this.UpdateScrollerClipping));
    this.딟 = Object.Instantiate((Object) this.OverlayPrefab, new Vector3(0.0f, this.딟.YVal - 0.1f, 0.0f), Quaternion.identity) as MenuOverlayHandler;
    this.ItemIcon.SetActive(false);
    this.get_LocalImageCache().딟(딞.땤().딟(), new Action(this.OnImageDownloadFailure), new Action<Texture2D>(this.OnImageDownloadSuccess));
    if (this.딟.땃().딝() == null || this.딟.땃().딝().Count == 0)
      this.CreateCharacterInfo(this.딟);
    else
      this.ProcessCharacterBundle();
    if (!StoreItemInfo.땄)
    {
      object[] objArray = new object[1]
      {
        (object) StoreItemInfo.딟
      };
      ((Component) this.PurchaseButton).gameObject.SetActive(false);
      this.LevelXText.set_LocTextParms(objArray);
      this.LevelXText.UpdateMesh();
      this.LockedInformation.SetActive(true);
    }
    else
      this.LockedInformation.SetActive(false);
    if (StoreItemInfo.딟)
    {
      ((Component) this.PurchaseButton).gameObject.SetActive(false);
      ((Component) this.CoinsCostText).gameObject.SetActive(false);
      this.CoinsIcon.SetActive(false);
    }
    this.CharacterNameText.Text = this.딟.딢();
    this.CharacterNameText.UpdateMesh();
    OfferData offerData = this.딟.딶();
    this.CoinsCostText.Text = offerData == null ? "N/A" : offerData.딢().ToString();
    this.CoinsCostText.UpdateMesh();
  }

  private void UpdateScrollerClipping()
  {
    ((Component) this.Scroller).gameObject.SetActive(true);
    this.Scroller.UpdateItemClipping();
  }

  private void OnImageDownloadFailure()
  {
  }

  private void OnImageDownloadSuccess(Texture2D Image)
  {
    if (Object.op_Equality((Object) this.ItemIcon, (Object) null))
      return;
    this.LoadingIcon.SetActive(false);
    딧.딼.딟(this.ItemIcon, this.AvatarIconMaterial, Image);
    this.ItemIcon.SetActive(true);
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (StorePurchaseCharacterPanelHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      StorePurchaseCharacterPanelHandler.딟 = new Dictionary<string, int>(3)
      {
        {
          "Close",
          0
        },
        {
          "Buy",
          1
        },
        {
          "Try",
          2
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!StorePurchaseCharacterPanelHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        this.Close();
        break;
      case 1:
        (Object.Instantiate((Object) this.PurchasePanelPrefab) as StorePurchaseConfirmationPanelHandler).Init(this.딟, FrontendHub.딟.StoreScreen.get_ImageCache());
        this.Close();
        break;
      case 2:
        if (!Object.op_Equality((Object) this.딟, (Object) null))
          break;
        if (this.땄 == null && this.딟.떏())
          this.땄 = this.딟;
        if (this.땄 == null)
          break;
        this.딟 = Object.Instantiate((Object) this.tryBeforeYouBuyPanel) as TryBeforeYouBuyPanelHandler;
        this.딟.Init((BaseMenuHandler) FrontendHub.딟.StoreScreen, this.땄);
        this.딟.Open();
        break;
    }
  }

  public override void Close()
  {
    this.딟.Close();
    this.딟.Close();
  }

  private void ProcessCharacterBundle()
  {
    foreach (KeyValuePair<string, int> keyValuePair in this.딟.땃().딝())
      this.딟.Add(GlobalAppData.떏().땠(keyValuePair.Key));
  }

  private void CreateCharacterInfo(땃.딷 Item)
  {
    땓.딞 딞 = Item.땃().땃() as 땓.딞;
    땓.딠 딠 = Item.땃().딢() as 땓.딠;
    string HealthText = 딞.땭();
    string APText = 딞.떂();
    string SPText = 딞.떎();
    if (딠.딝() != null)
    {
      foreach (FireTeamCatalogEntryDescriptionAbilityData descriptionAbilityData in 딠.딝())
      {
        this.딟.Add(descriptionAbilityData.Name);
        this.땄.Add(descriptionAbilityData.Description);
      }
    }
    string Ability01Name = this.딟[0];
    string Ability02Name = this.딟[1];
    string Ability01Description = this.땄[0];
    string Ability02Description = this.땄[1];
    string WeaponName = 딠.땺();
    if (Object.op_Equality((Object) this.딟, (Object) null))
    {
      this.딟 = Object.Instantiate((Object) this.CharacterStats) as StorePanel_CharacterStats;
      this.딟.Init(HealthText, APText, SPText, Ability01Name, Ability02Name, Ability01Description, Ability02Description, WeaponName);
      this.Scroller.AddItem(((Component) this.딟).transform, 13f / 16f);
      ((Component) this.Scroller).gameObject.SetActive(false);
    }
    this.CurrentCountText.Text = GlobalAppData.땽().땃(Item.딧()).ToString();
    this.CurrentCountText.UpdateMesh();
  }

  private void Update()
  {
    if (this.딟 != null)
    {
      bool flag1 = true;
      bool flag2 = true;
      foreach (땄.땘 땘 in this.딟)
      {
        if (!땘.땄())
        {
          flag1 = false;
          break;
        }
      }
      if (flag1)
      {
        foreach (땄.땘 땘 in this.딟)
        {
          if (!땘.딧())
          {
            flag2 = false;
            break;
          }
        }
        if (flag2)
        {
          foreach (땄.땐 땐 in this.딟)
            this.딟.Add(new 땃.딷(땐.딟));
          foreach (땃.딷 딷 in this.딟)
          {
            if (딷.떏())
              this.땄 = 딷;
            if (딷.땤())
              this.딧 = 딷;
          }
        }
        this.딟 = (List<땄.땐>) null;
      }
    }
    if (this.땄 == null || this.딧 == null || !this.딟.get_IsOpen())
      return;
    this.CreateCharacterInfo(this.땄);
    this.UpdateScrollerClipping();
  }

  private void OnDestroy()
  {
    GlobalAppData.땄(this.CoinsIcon);
    GlobalAppData.땄(this.ItemIcon);
    if (this.get_LocalImageCache() != null)
    {
      this.get_LocalImageCache().Dispose();
      // ISSUE: reference to a compiler-generated method
      this.set_LocalImageCache((딟.땫) null);
    }
    this.딟.딟();
  }

  [CompilerGenerated]
  [SpecialName]
  public 딟.땫 get_LocalImageCache() => this.딟;
}
