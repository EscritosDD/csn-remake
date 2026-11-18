// Decompiled with JetBrains decompiler
// Type: StorePurchaseWeaponPanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StorePurchaseWeaponPanelHandler : StorePanel
{
  private MenuAnimatorHandler 딟;
  private MenuOverlayHandler 딟;
  private 땃.딷 딟;
  public StorePanel_WeaponStats WeaponStatsInstance;
  private Transform[] 딟 = new Transform[5];
  public GuiScrollList3D Scroller;
  public GuiMultiLineText3D WeaponNameText;
  public GuiText3D CoinsCostText;
  public GuiText3D CurrentCountText;
  public GameObject CoinsIcon;
  public GameObject ItemIcon;
  public GuiButton3D PurchaseButton;
  public Material AvatarIconMaterial;
  public GameObject LoadingIcon;
  public GameObject LockedInformation;
  public GameObject LevelInfo;
  public GuiText3D LevelXText;
  public StorePanel_WeaponStats WeaponStats;
  public MenuOverlayHandler OverlayPrefab;
  public StorePurchaseConfirmationPanelHandler PurchasePanelPrefab;
  public GuiText3D ClassRequiredText;
  public float IconOffset;
  public Transform BaseIconPos;

  private void Awake()
  {
  }

  public void Init(StoreItemButton.떎 StoreItemInfo, Transform StartPoint, Transform EndPoint)
  {
    땓.딞 딞 = StoreItemInfo.딟.땃().땃() as 땓.딞;
    this.딟 = ((Component) this).GetComponent<MenuAnimatorHandler>();
    this.딟.SetOnOpenFinishedCallback(new MenuAnimatorHandler.땔(this.UpdateScrollerClipping));
    this.딟.StartPoint = StartPoint;
    this.딟.EndPoint = EndPoint;
    this.딟 = Object.Instantiate((Object) this.OverlayPrefab, new Vector3(0.0f, this.딟.YVal - 0.1f, 0.0f), Quaternion.identity) as MenuOverlayHandler;
    // ISSUE: reference to a compiler-generated method
    this.set_LocalImageCache(new 딟.땫(1024, (딟.땇) GlobalAppData.떏()));
    this.딟 = StoreItemInfo.딟;
    this.ItemIcon.SetActive(false);
    this.get_LocalImageCache().딟(딞.땤().딟(), new Action(this.OnImageDownloadFailure), new Action<Texture2D>(this.OnImageDownloadSuccess));
    if (StoreItemInfo.딟)
    {
      ((Component) this.PurchaseButton).gameObject.SetActive(false);
      ((Component) this.CoinsCostText).gameObject.SetActive(false);
      this.CoinsIcon.SetActive(false);
    }
    ((Component) this.ClassRequiredText).gameObject.SetActive(false);
    this.LevelInfo.SetActive(false);
    this.LockedInformation.SetActive(false);
    if (!StoreItemInfo.땄)
    {
      ((Component) this.PurchaseButton).gameObject.SetActive(false);
      this.LockedInformation.SetActive(true);
      if (StoreItemInfo.딧)
      {
        this.LevelXText.set_LocTextParms(new object[1]
        {
          (object) StoreItemInfo.딟
        });
        this.LevelXText.UpdateMesh();
        this.LevelInfo.SetActive(true);
      }
      else if (StoreItemInfo.땃)
      {
        Vector3 vector3;
        // ISSUE: explicit constructor call
        ((Vector3) ref vector3).\u002Ector(0.0f, 0.0f, 0.0f);
        for (int index = 0; index < StoreItemInfo.딟.RequiredClassIcons.Length; ++index)
        {
          if (Object.op_Inequality((Object) StoreItemInfo.딟.RequiredClassIcons[index], (Object) null))
          {
            this.딟[index] = Object.Instantiate((Object) StoreItemInfo.딟.RequiredClassIcons[index]) as Transform;
            ((Component) this.딟[index]).renderer.sharedMaterial = new Material(((Component) StoreItemInfo.딟.RequiredClassIcons[index]).renderer.sharedMaterial);
            this.딟[index].parent = ((Component) this).transform;
            this.딟[index].localScale = new Vector3(1.1f, 1f, 1.1f);
            this.딟[index].localPosition = Vector3.op_Addition(this.BaseIconPos.localPosition, vector3);
            ((Component) this.딟[index]).gameObject.SetActive(true);
            // ISSUE: explicit constructor call
            ((Vector3) ref vector3).\u002Ector((float) vector3.x + this.IconOffset, 0.0f, 0.0f);
          }
        }
        ((Component) this.ClassRequiredText).gameObject.SetActive(true);
        this.LevelInfo.SetActive(false);
      }
    }
    this.WeaponNameText.Text = this.딟.딢();
    this.WeaponNameText.UpdateMesh();
    this.WeaponStatsInstance = Object.Instantiate((Object) this.WeaponStats) as StorePanel_WeaponStats;
    this.WeaponStatsInstance.Init(this.딟);
    this.Scroller.AddItem(((Component) this.WeaponStatsInstance).transform, 15f / 32f);
    this.Scroller.UpdateItemClipping();
    ((Component) this.Scroller).gameObject.SetActive(false);
    if (!StoreItemInfo.딟)
    {
      OfferData offerData = this.딟.딶();
      this.CoinsCostText.Text = offerData == null ? "N/A" : offerData.딢().ToString();
      this.CoinsCostText.UpdateMesh();
    }
    this.CurrentCountText.Text = GlobalAppData.땽().땃(this.딟.딧()).ToString();
    this.CurrentCountText.UpdateMesh();
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

  private void UpdateScrollerClipping()
  {
    ((Component) this.Scroller).gameObject.SetActive(true);
    this.WeaponStatsInstance.SetAvailableToIcons();
    this.Scroller.UpdateItemClipping();
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (StorePurchaseWeaponPanelHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      StorePurchaseWeaponPanelHandler.딟 = new Dictionary<string, int>(2)
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
    if (!StorePurchaseWeaponPanelHandler.딟.TryGetValue(key, out num))
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
    GlobalAppData.땄(this.CoinsIcon);
    GlobalAppData.땄(this.ItemIcon);
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
