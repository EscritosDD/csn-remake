// Decompiled with JetBrains decompiler
// Type: StorePurchaseSkinPanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StorePurchaseSkinPanelHandler : StorePanel
{
  private MenuAnimatorHandler 딟;
  private MenuOverlayHandler 딟;
  private 땃.딷 딟;
  private int 딟;
  public GuiButton3D PurchaseButton;
  public GuiMultiLineText3D SkinNameText;
  public GuiText3D CharacterNameText;
  public GuiMultiLineText3D Description;
  public GuiText3D CostText;
  public GuiText3D CurrentCountText;
  public GameObject CoinsIcon;
  public GameObject ItemIcon;
  public Material AvatarIconMaterial;
  public GuiText3D MaxAmountText;
  public GameObject LoadingIcon;
  public GameObject LockedInformation;
  public GameObject LevelInfo;
  public GuiText3D LevelXText;
  public GuiText3D LockedCharacterName;
  public MenuOverlayHandler OverlayPrefab;
  public StorePurchaseConfirmationPanelHandler PurchasePanelPrefab;

  private void Start()
  {
  }

  public void Init(StoreItemButton.떎 StoreItemInfo, Transform StartPoint, Transform EndPoint)
  {
    // ISSUE: reference to a compiler-generated method
    this.set_LocalImageCache(new 딟.땫(256, (딟.땇) GlobalAppData.떏()));
    this.딟 = StoreItemInfo.딟;
    this.딟 = ((Component) this).GetComponent<MenuAnimatorHandler>();
    this.딟.StartPoint = StartPoint;
    this.딟.EndPoint = EndPoint;
    this.딟 = Object.Instantiate((Object) this.OverlayPrefab, new Vector3(0.0f, this.딟.YVal - 0.1f, 0.0f), Quaternion.identity) as MenuOverlayHandler;
    this.ItemIcon.SetActive(false);
    땓.딞 딞 = this.딟.땃().땃() as 땓.딞;
    땓.딠 딠 = this.딟.땃().딢() as 땓.딠;
    this.get_LocalImageCache().딟(딞.땤().딟(), new Action(this.OnImageDownloadFailure), new Action<Texture2D>(this.OnImageDownloadSuccess));
    if (StoreItemInfo.딟)
      this.DisablePurchaseInfo();
    this.SkinNameText.Text = this.딟.딢();
    this.SkinNameText.UpdateMesh();
    this.CharacterNameText.Text = 딠.딧();
    this.CharacterNameText.UpdateMesh();
    this.Description.Text = 딠.딢();
    this.Description.UpdateMesh();
    OfferData offerData = this.딟.딶();
    this.CostText.Text = (offerData != null ? offerData.딢() : 0).ToString();
    this.CostText.UpdateMesh();
    this.딟 = GlobalAppData.땽().땃(this.딟.딧());
    this.CurrentCountText.Text = this.딟.ToString();
    this.CurrentCountText.UpdateMesh();
    if (!StoreItemInfo.땄)
    {
      if (StoreItemInfo.딧)
      {
        object[] objArray = new object[1]
        {
          (object) StoreItemInfo.딟
        };
        ((Component) this.PurchaseButton).gameObject.SetActive(false);
        this.LevelXText.set_LocTextParms(objArray);
        this.LevelXText.UpdateMesh();
        this.LevelInfo.SetActive(true);
      }
      else if (StoreItemInfo.딢)
      {
        ((Component) this.PurchaseButton).gameObject.SetActive(false);
        ((Component) this.LockedCharacterName).gameObject.SetActive(true);
        this.LockedCharacterName.Text = StoreItemInfo.딟;
        this.LockedCharacterName.UpdateMesh();
        this.LevelInfo.SetActive(false);
      }
      this.LockedInformation.SetActive(true);
    }
    else
    {
      this.LockedInformation.SetActive(false);
      this.LevelInfo.SetActive(false);
    }
    if (this.딟.땢())
    {
      ((Component) this.MaxAmountText).gameObject.SetActive(true);
      this.MaxAmountText.Text = "1";
      this.MaxAmountText.UpdateMesh();
      if (this.딟 < 1)
        return;
      this.DisablePurchaseInfo();
      this.LockedInformation.SetActive(false);
    }
    else
      ((Component) this.MaxAmountText).gameObject.SetActive(false);
  }

  private void DisablePurchaseInfo()
  {
    ((Component) this.PurchaseButton).gameObject.SetActive(false);
    ((Component) this.CostText).gameObject.SetActive(false);
    this.CoinsIcon.SetActive(false);
  }

  private void OnImageDownloadFailure()
  {
  }

  private void OnImageDownloadSuccess(Texture2D Image)
  {
    if (Object.op_Equality((Object) this.ItemIcon, (Object) null))
      return;
    this.LoadingIcon.SetActive(false);
    GlobalAppData.딟(this.ItemIcon.renderer.material);
    딧.딼.딟(this.ItemIcon, this.AvatarIconMaterial, Image);
    this.ItemIcon.SetActive(true);
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (StorePurchaseSkinPanelHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      StorePurchaseSkinPanelHandler.딟 = new Dictionary<string, int>(2)
      {
        {
          "Close",
          0
        },
        {
          "Buy",
          1
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!StorePurchaseSkinPanelHandler.딟.TryGetValue(key, out num))
      return;
    if (num != 0)
    {
      if (num != 1)
        return;
      (Object.Instantiate((Object) this.PurchasePanelPrefab) as StorePurchaseConfirmationPanelHandler).Init(this.딟, FrontendHub.딟.StoreScreen.get_ImageCache());
      this.Close();
    }
    else
      this.Close();
  }

  public override void Close()
  {
    this.딟.Close();
    this.딟.Close();
  }

  private void OnDestroy()
  {
    GlobalAppData.땄(this.ItemIcon);
    GlobalAppData.땄(this.CoinsIcon);
    if (this.get_LocalImageCache() == null)
      return;
    this.get_LocalImageCache().Dispose();
    // ISSUE: reference to a compiler-generated method
    this.set_LocalImageCache((딟.땫) null);
  }

  [CompilerGenerated]
  [SpecialName]
  public 딟.땫 get_LocalImageCache() => this.딟;
}
