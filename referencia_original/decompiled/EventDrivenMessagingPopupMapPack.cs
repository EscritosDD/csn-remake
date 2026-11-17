// Decompiled with JetBrains decompiler
// Type: EventDrivenMessagingPopupMapPack
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EventDrivenMessagingPopupMapPack : MonoBehaviour
{
  private MenuOverlayHandler 딟;
  private LoadingScreenOverlayHandler 딟;
  private LoadingScreenOverlayHandler 땄;
  private bool 딟;
  private Dictionary<string, string> 딟 = new Dictionary<string, string>();
  private 땃.딷 딟;
  private OfferData 딟;
  private string 딟;
  private 딟.땫 딟;
  private Material 딟;
  private Material 땄;
  private 땃.딦 딟;
  public Material SuccessIconBaseMaterial;
  public GuiText3D EventTitleText;
  public GuiText3D EventTitleShadowText;
  public GuiText3D EventDescriptionTitleText;
  public GuiText3D ItemCurrencyText;
  public GuiText3D ItemCurrencyTextShadow;
  public GuiMultiLineText3D BuyButtonText;
  public GuiMultiLineText3D EventDescriptionText;
  public GameObject CurrencyDisplay;
  public Renderer ImageDisplay;
  public MenuOverlayHandler OverlayPrefab;
  public LoadingScreenOverlayHandler LoadingOverlayPrefab;
  public LoadingScreenOverlayHandler purchasingOverlayPrefab;
  public LoadingScreenOverlayHandler purchasingOverlayPrefabNacl;
  public ErrorMessagehandler ErrorMessage;
  public PurchaseSuccessfulPanelHandler SuccessMessage;
  public LocalisationEntry BuyNowCharacterText;
  public LocalisationEntry BuyNowWeaponText;
  public GuiText3D NaClTaxMessage;

  public void Init(딢.땕 Event)
  {
    GlobalAppData.땋().딟();
    this.CreateLoadingOverlay();
    this.딟 = new 딟.땫(256, (딟.땇) GlobalAppData.떏());
    this.딟 = new Material(this.ImageDisplay.sharedMaterial);
    this.ImageDisplay.sharedMaterial = this.딟;
    ((Component) this.ImageDisplay).gameObject.SetActive(false);
    this.CurrencyDisplay.SetActive(false);
    if (Event.딢() == 딢.땪.딶)
    {
      this.딟 = GlobalAppData.땼().딳(Event.딟()).땄();
      this.딟.Add("type", "mappack");
      this.딟.Add("id", Event.딟());
    }
    else if (Event.딢() == 딢.땪.땺)
    {
      this.딟 = GlobalAppData.땼().땝(Event.딟()).땄();
      this.딟.Add("type", "challengepack");
      this.딟.Add("id", Event.딟());
    }
    else if (Event.딢() == 딢.땪.땥)
    {
      this.딟 = GlobalAppData.땼().딸(Event.딟()).땭();
      this.딟.Add("type", "character");
      this.딟.Add("id", Event.딟());
      this.BuyButtonText.LocText = this.BuyNowCharacterText;
      this.BuyButtonText.UpdateMesh();
    }
    else if (Event.딢() == 딢.땪.딝)
    {
      this.딟 = GlobalAppData.땼().땔(Event.딟()).땄();
      this.딟.Add("type", "weapon");
      this.딟.Add("id", Event.딟());
      this.BuyButtonText.LocText = this.BuyNowWeaponText;
      this.BuyButtonText.UpdateMesh();
    }
    this.딟 = new 땃.딦(this.딟);
    this.딟.딟(new Action<땃.딷>(this.OnItemFound));
    this.딟.딧(new Action<딟.땑, ErrorMessagehandler.땶>(this.OnItemFindError));
    this.딟.딟(new Action<PurchaseResult>(this.OnItemPurchased));
    this.딟.딟(new Action<딟.땑, ErrorMessagehandler.땶>(this.OnItemPurchaseError));
    딟.딦.딟("SpecialEvtMsgOpened", this.딟);
  }

  private void OnItemPurchaseError(딟.땑 ErrorCode, ErrorMessagehandler.땶 ErrorType)
  {
    if (ErrorType == ErrorMessagehandler.땶.떏)
      return;
    this.DisplayErrorMessage(ErrorCode, ErrorType);
  }

  private void OnItemPurchased(PurchaseResult result)
  {
    딟.딦.딟("SpecialEvtMsgPurchased", this.딟);
    this.DisplaySuccessMessage();
    this.Close();
  }

  private void OnItemFindError(딟.땑 ErrorCode, ErrorMessagehandler.땶 ErrorType)
  {
    this.CloseLoadingOverlay();
    this.Close();
  }

  private void OnItemFound(땃.딷 Item)
  {
    this.딟 = Item;
    this.CloseLoadingOverlay();
    땓.딠 딠 = Item.땃().딢() as 땓.딠;
    땓.딞 딞 = Item.땃().땃() as 땓.딞;
    땓.딡 딡 = 딠.땥();
    if (딡 != null)
    {
      if (딡.딢().땄())
        this.딟.딟(딡.딢().딟(), new Action(this.OnAdvertDownloadFailure), new Action<Texture2D>(this.OnAdvertDownloadSuccess));
      this.EventTitleText.Text = 딡.딧();
      this.EventTitleShadowText.Text = this.EventTitleText.Text;
      this.EventTitleText.UpdateMesh();
      this.EventTitleShadowText.UpdateMesh();
      if (Object.op_Inequality((Object) this.EventDescriptionTitleText, (Object) null))
      {
        this.EventDescriptionTitleText.Text = 딡.땄();
        this.EventDescriptionTitleText.UpdateMesh();
      }
      this.EventDescriptionText.Text = 딡.딟();
      this.EventDescriptionText.UpdateMesh();
      this.딟 = Item.땥();
      if (this.딟 != null)
      {
        ApplePriceDisplay applePriceDisplay = ((Component) this).gameObject.AddComponent<ApplePriceDisplay>();
        applePriceDisplay.set_TextControl(this.ItemCurrencyText);
        applePriceDisplay.set_TextShadowControl(this.ItemCurrencyTextShadow);
        applePriceDisplay.set_Display(this.CurrencyDisplay);
        applePriceDisplay.set_Offer(this.딟);
        if (Object.op_Inequality((Object) this.NaClTaxMessage, (Object) null))
          ((Component) this.NaClTaxMessage).gameObject.SetActive(true);
      }
    }
    this.딟.딟(딞.딦().딟(), new Action(this.OnIconDownloadFailure), new Action<Texture2D>(this.OnIconDownloadSuccess));
  }

  private void OnAdvertDownloadFailure()
  {
  }

  private void OnAdvertDownloadSuccess(Texture2D Image)
  {
    this.딟.mainTexture = (Texture) Image;
    ((Component) this.ImageDisplay).gameObject.SetActive(true);
  }

  private void OnIconDownloadFailure()
  {
  }

  private void OnIconDownloadSuccess(Texture2D Image)
  {
    this.땄 = new Material(this.SuccessIconBaseMaterial);
    this.땄.mainTexture = (Texture) Image;
  }

  private void Start()
  {
    this.딟 = Object.Instantiate((Object) this.OverlayPrefab) as MenuOverlayHandler;
    ((Component) this.딟).transform.position = Vector3.op_Subtraction(((Component) this).transform.position, new Vector3(0.0f, 0.1f, 0.0f));
  }

  private void OnDestroy()
  {
    if (this.딟 != null)
    {
      this.딟.Dispose();
      this.딟 = (딟.땫) null;
    }
    if (Object.op_Inequality((Object) this.딟, (Object) null))
    {
      Object.Destroy((Object) this.딟);
      this.딟 = (Material) null;
    }
    this.CloseLoadingOverlay();
    this.ClosePurchasingOverlay();
  }

  private void CreatePurchasingOverlay()
  {
    if (Object.op_Inequality((Object) this.땄, (Object) null))
      return;
    this.땄 = Object.Instantiate((Object) this.purchasingOverlayPrefabNacl) as LoadingScreenOverlayHandler;
    ((Component) this.땄).transform.position = Vector3.op_Addition(((Component) this).transform.position, new Vector3(0.0f, 1f, 0.0f));
  }

  private void CreateLoadingOverlay()
  {
    if (Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    this.딟 = Object.Instantiate((Object) this.LoadingOverlayPrefab) as LoadingScreenOverlayHandler;
    ((Component) this.딟).transform.position = Vector3.op_Addition(((Component) this).transform.position, new Vector3(0.0f, 1f, 0.0f));
  }

  private void Update()
  {
    this.딟.땄();
    if (this.딟 == null)
      return;
    if (this.딟.딶())
      this.CreatePurchasingOverlay();
    else
      this.ClosePurchasingOverlay();
  }

  private void CloseLoadingOverlay()
  {
    if (Object.op_Equality((Object) this.딟, (Object) null))
      return;
    this.딟.Close();
    this.딟 = (LoadingScreenOverlayHandler) null;
  }

  private void ClosePurchasingOverlay()
  {
    if (Object.op_Equality((Object) this.땄, (Object) null))
      return;
    this.땄.Close();
    this.땄 = (LoadingScreenOverlayHandler) null;
  }

  private void OnButtonPressed(string Command)
  {
    if (this.딟)
      return;
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (EventDrivenMessagingPopupMapPack.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      EventDrivenMessagingPopupMapPack.딟 = new Dictionary<string, int>(2)
      {
        {
          "Accept",
          0
        },
        {
          "Close",
          1
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!EventDrivenMessagingPopupMapPack.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        if (this.딟 != null)
        {
          this.딟.딟(this.딟);
          break;
        }
        this.딟 = true;
        this.LoadNextScreen();
        break;
      case 1:
        딟.딦.딟("SpecialEvtMsgClosed", this.딟);
        this.Close();
        break;
    }
  }

  private void Close()
  {
    this.딟.Close();
    Object.Destroy((Object) ((Component) this).gameObject);
  }

  private void LoadNextScreen()
  {
    GlobalAppData.딟.딟(GlobalAppState.땊.땥);
    GlobalAppData.딟.딟(this.딟);
    Application.LoadLevelAsync(GlobalAppData.딟.EnvSettings.ScenesAsset.Data.땄());
  }

  private void DisplaySuccessMessage()
  {
    PurchaseSuccessfulPanelHandler successfulPanelHandler = Object.Instantiate((Object) this.SuccessMessage) as PurchaseSuccessfulPanelHandler;
    ((Component) successfulPanelHandler).transform.position = Vector3.op_Addition(((Component) this).transform.position, new Vector3(0.0f, 0.5f, 0.0f));
    successfulPanelHandler.Init(this.땄, this.딟, this.딟, (string) null);
    this.딟 = (딟.땫) null;
  }

  private void DisplayErrorMessage(딟.땑 ErrorCode, ErrorMessagehandler.땶 ErrorType)
  {
    ErrorMessagehandler errorMessagehandler = Object.Instantiate((Object) this.ErrorMessage) as ErrorMessagehandler;
    ((Component) errorMessagehandler).transform.position = Vector3.op_Addition(((Component) this).transform.position, new Vector3(0.0f, 1f, 0.0f));
    errorMessagehandler.Init(ErrorType, ErrorCode);
  }
}
