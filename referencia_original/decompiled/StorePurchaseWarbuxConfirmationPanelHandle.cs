// Decompiled with JetBrains decompiler
// Type: StorePurchaseWarbuxConfirmationPanelHandle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StorePurchaseWarbuxConfirmationPanelHandle : StorePanel
{
  private 땃.딷 딟;
  private GameObject 딟;
  private Action 딟;
  private Action 땄;
  private 땃.딦 딟;
  private LoadingScreenOverlayHandler 딟;
  public GuiButton3D CloseButton;
  public GuiButton3D ConfirmButton;
  public GuiMultiLineText3D AreYouSureText;
  public GameObject ItemIcon;
  public Material AvatarIconMaterial;
  public LoadingScreenOverlayHandler LoadingOverlayPrefab;
  public LoadingScreenOverlayHandler LoadingOverlayPrefabNacl;
  public ErrorMessagehandler ErrorMessage;
  public PurchaseSuccessfulPanelHandler SuccessMessage;
  public GameObject Overlay;

  private void DisplayErrorMessage(딟.땑 ErrorCode, ErrorMessagehandler.땶 ErrorType)
  {
    ErrorMessagehandler errorMessagehandler = Object.Instantiate((Object) this.ErrorMessage) as ErrorMessagehandler;
    ((Component) errorMessagehandler).transform.position = ((Component) this).transform.position;
    errorMessagehandler.Init(ErrorType, ErrorCode);
    errorMessagehandler.OnClosedCallback = this.딟;
  }

  public void Init(딟.땫 ImageCache, 땃.딷 Item)
  {
    this.딟 = new 땃.딦(Item);
    this.딟.딟(new Action<PurchaseResult>(this.OnItemPurchased));
    this.딟.딟(new Action<딟.땑, ErrorMessagehandler.땶>(this.OnItemPurchaseError));
    this.딟 = Item;
    땓.딞 딞 = Item.땃().땃() as 땓.딞;
    ImageCache.딟(딞.딦().딟(), new Action(this.OnDownloadFailure), new Action<Texture2D>(this.OnDownloadSuccess));
    ((Component) this.CloseButton).gameObject.SetActive(false);
    ((Component) this.ConfirmButton).gameObject.SetActive(false);
    ((Component) this.AreYouSureText).gameObject.SetActive(false);
    this.ItemIcon.SetActive(false);
    this.딟 = Object.Instantiate((Object) this.Overlay) as GameObject;
    this.딟.transform.position = Vector3.op_Subtraction(((Component) this).transform.position, new Vector3(0.0f, 0.1f, 0.0f));
    this.딟.딟(Item.땥());
  }

  private void OnDownloadFailure()
  {
  }

  private void OnDownloadSuccess(Texture2D Image)
  {
    if (!Object.op_Inequality((Object) this.ItemIcon, (Object) null))
      return;
    딧.딼.딟(this.ItemIcon, this.AvatarIconMaterial, Image);
  }

  private void OnItemPurchaseError(딟.땑 ErrorCode, ErrorMessagehandler.땶 ErrorType)
  {
    if (ErrorType != ErrorMessagehandler.땶.떏)
    {
      this.DisplayErrorMessage(ErrorCode, ErrorType);
      this.CloseToErrorMessage();
    }
    else
      this.Close();
  }

  private void OnItemPurchased(PurchaseResult result)
  {
    this.ShowSuccessOverlay();
    this.Close();
    if (this.땄 == null)
      return;
    this.땄();
  }

  private void ShowSuccessOverlay() => (Object.Instantiate((Object) this.SuccessMessage, ((Component) this).transform.position, Quaternion.identity) as PurchaseSuccessfulPanelHandler).Init(this.ItemIcon.renderer.material, this.딟, (딟.땫) null, (string) null);

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (StorePurchaseWarbuxConfirmationPanelHandle.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      StorePurchaseWarbuxConfirmationPanelHandle.딟 = new Dictionary<string, int>(2)
      {
        {
          "Cancel",
          0
        },
        {
          "Accept",
          1
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!StorePurchaseWarbuxConfirmationPanelHandle.딟.TryGetValue(key, out num))
      return;
    if (num != 0)
    {
      if (num != 1)
        return;
      this.딟.딟(this.딟.땥());
    }
    else
      this.Close();
  }

  public override void Close()
  {
    if (this.딟 != null)
      this.딟();
    this.CloseLoadingOverlay();
    this.딟.GetComponent<MenuOverlayHandler>().Close();
    Object.Destroy((Object) ((Component) this).gameObject);
  }

  public void CloseToErrorMessage()
  {
    this.CloseLoadingOverlay();
    this.딟.GetComponent<MenuOverlayHandler>().Close();
    Object.Destroy((Object) ((Component) this).gameObject);
  }

  private void Update()
  {
    this.딟.땄();
    if (this.딟.딶())
      this.OpenLoadingOverlay();
    else
      this.CloseLoadingOverlay();
  }

  private void OpenLoadingOverlay()
  {
    if (!Object.op_Equality((Object) this.딟, (Object) null))
      return;
    this.딟 = Object.Instantiate((Object) this.LoadingOverlayPrefabNacl) as LoadingScreenOverlayHandler;
    ((Component) this.딟).transform.position = Vector3.op_Addition(((Component) this).transform.position, new Vector3(0.0f, 0.5f, 0.0f));
  }

  private void CloseLoadingOverlay()
  {
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    this.딟.Close();
    this.딟 = (LoadingScreenOverlayHandler) null;
  }

  [SpecialName]
  private TimeSpan get_MinPurchaseInterval() => new TimeSpan(0, 0, 5);

  public void SetOnClosedCallback(Action Callback) => this.딟 = Callback;

  public void SetOnSuccessCallback(Action Callback) => this.땄 = Callback;
}
