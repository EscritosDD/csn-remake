// Decompiled with JetBrains decompiler
// Type: StorePurchaseConfirmationPanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StorePurchaseConfirmationPanelHandler : StorePanel
{
  private 땃.딷 딟;
  private GameObject 딟;
  private 땃.딦 딟;
  private bool 딟;
  private Transform 딟;
  private LoadingScreenOverlayHandler 딟;
  private 딧.딼 딟 = new 딧.딼();
  private 딟.땫 딟;
  public GameObject Overlay;
  public LoadingScreenOverlayHandler LoadingOverlay;
  public GuiButton3D CoinsButton;
  public GameObject CoinsButtonModel;
  public GameObject CoinsIcon;
  public GuiText3D CoinsText;
  public GuiButton3D CancelButton;
  public GuiMultiLineText3D AreYouSureText;
  public GameObject ItemIcon;
  public Material AvatarIconMaterial;
  public Material CoinsButtonMaterial;
  public Shader ClippedGreyscale;
  public ErrorMessagehandler ErrorMessage;
  public PurchaseSuccessfulPanelHandler SuccessMessage;

  private void DisplayErrorMessage(딟.땑 ErrorCode, ErrorMessagehandler.땶 ErrorType)
  {
    ErrorMessagehandler errorMessagehandler = Object.Instantiate((Object) this.ErrorMessage) as ErrorMessagehandler;
    ((Component) errorMessagehandler).transform.position = Vector3.op_Addition(((Component) this).transform.position, new Vector3(0.0f, 0.5f, 0.0f));
    errorMessagehandler.Init(ErrorType, ErrorCode);
  }

  private void Start()
  {
    this.딟 = Object.Instantiate((Object) this.Overlay) as GameObject;
    this.딟.transform.position = Vector3.op_Subtraction(((Component) this).transform.position, new Vector3(0.0f, 0.1f, 0.0f));
    ((Component) this.CoinsButton).gameObject.SetActive(false);
    this.CoinsIcon.SetActive(false);
    ((Component) this.CancelButton).gameObject.SetActive(false);
    ((Component) this.AreYouSureText).gameObject.SetActive(false);
    this.ItemIcon.SetActive(false);
    ((Component) this.CoinsText).gameObject.SetActive(false);
    if (this.get_OnOpenCallback() == null)
      return;
    this.get_OnOpenCallback()();
  }

  public void Init(땃.딷 Item, 딟.땫 ImageCache, Transform LoadingOverlayParent)
  {
    this.딟 = LoadingOverlayParent;
    this.Init(Item, ImageCache);
  }

  public void Init(땃.딷 Item, 딟.땫 ImageCache)
  {
    this.딟 = new 땃.딦(Item);
    this.딟.딟(new Action<PurchaseResult>(this.OnItemPurchased));
    this.딟.딟(new Action<딟.땑, ErrorMessagehandler.땶>(this.OnItemPurchaseError));
    this.딟 = Item;
    this.딟 = ImageCache;
    this.ItemIcon.SetActive(false);
    땓.딞 딞 = Item.땃().땃() as 땓.딞;
    ImageCache.딟(딞.딦().딟(), new Action(this.OnImageDownloadFailure), new Action<Texture2D>(this.OnImageDownloadSuccess));
    if (Item.딶() != null)
    {
      this.CoinsText.Text = Item.딶().딢().ToString();
      this.CoinsText.UpdateMesh();
    }
    this.AreYouSureText.set_LocTextParms(new object[1]
    {
      (object) Item.딢()
    });
    this.AreYouSureText.UpdateMesh();
  }

  private void OnImageDownloadFailure()
  {
  }

  private void OnImageDownloadSuccess(Texture2D Image)
  {
    if (Object.op_Equality((Object) this.ItemIcon, (Object) null))
      return;
    딧.딼.딟(this.ItemIcon, this.AvatarIconMaterial, Image);
    this.ItemIcon.SetActive(true);
  }

  private void OnButtonPressed(string Command)
  {
    if (this.딟.딶())
      return;
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (StorePurchaseConfirmationPanelHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      StorePurchaseConfirmationPanelHandler.딟 = new Dictionary<string, int>(2)
      {
        {
          "Cancel",
          0
        },
        {
          "PurchaseWithCoins",
          1
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!StorePurchaseConfirmationPanelHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        if (this.get_OnClosedCallback() != null)
          this.get_OnClosedCallback()();
        this.Close();
        break;
      case 1:
        this.딟.딟(this.딟.딶());
        break;
    }
  }

  public override void Close()
  {
    base.Close();
    this.딟.GetComponent<MenuOverlayHandler>().Close();
    Object.Destroy((Object) ((Component) this).gameObject);
  }

  private void Update()
  {
    this.딟.땄();
    if (!this.딟 && !((Component) this).animation.isPlaying)
    {
      OfferData offerData = this.딟.딶();
      if (offerData != null)
      {
        if (!GlobalAppData.떏().딦().딟(offerData))
        {
          this.CoinsButton.Disabled = true;
          this.딟.딟(this.CoinsButtonModel.gameObject, this.CoinsButtonMaterial);
          this.딟.딟(this.CoinsButtonModel.gameObject, this.ClippedGreyscale);
        }
        ((Component) this.CoinsButton).gameObject.SetActive(true);
        this.CoinsIcon.SetActive(true);
      }
      ((Component) this.CancelButton).gameObject.SetActive(true);
      ((Component) this.AreYouSureText).gameObject.SetActive(true);
      this.ItemIcon.SetActive(true);
      ((Component) this.CoinsText).gameObject.SetActive(true);
      this.딟 = true;
    }
    if (this.딟.딶())
    {
      if (!Object.op_Equality((Object) this.딟, (Object) null))
        return;
      this.딟 = Object.Instantiate((Object) this.LoadingOverlay) as LoadingScreenOverlayHandler;
      if (Object.op_Inequality((Object) this.딟, (Object) null))
        ((Component) this.딟).transform.parent = this.딟;
      ((Component) this.딟).transform.localPosition = new Vector3(0.0f, 3.5f, 0.0f);
    }
    else
    {
      if (!Object.op_Inequality((Object) this.딟, (Object) null))
        return;
      this.딟.Close();
    }
  }

  private void OnItemPurchased(PurchaseResult result)
  {
    if (this.get_OnSuccessCallback() != null)
      this.get_OnSuccessCallback()();
    (Object.Instantiate((Object) this.SuccessMessage, ((Component) this).transform.position, Quaternion.identity) as PurchaseSuccessfulPanelHandler).Init(this.ItemIcon.renderer.material, this.딟, (딟.땫) null, (string) null);
    this.Close();
  }

  private void OnItemPurchaseError(딟.땑 ErrorCode, ErrorMessagehandler.땶 ErrorType)
  {
    if (ErrorType == ErrorMessagehandler.땶.떏)
      return;
    this.DisplayErrorMessage(ErrorCode, ErrorType);
  }

  private void OnDestroy() => this.딟.딟();

  [CompilerGenerated]
  [SpecialName]
  public Action get_OnOpenCallback() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public void set_OnOpenCallback(Action value) => this.딟 = value;

  [CompilerGenerated]
  [SpecialName]
  public Action get_OnClosedCallback() => this.땄;

  [CompilerGenerated]
  [SpecialName]
  public void set_OnClosedCallback(Action value) => this.땄 = value;

  [CompilerGenerated]
  [SpecialName]
  public Action get_OnSuccessCallback() => this.딧;

  [CompilerGenerated]
  [SpecialName]
  public void set_OnSuccessCallback(Action value) => this.딧 = value;
}
