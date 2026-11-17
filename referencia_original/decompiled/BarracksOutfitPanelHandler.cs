// Decompiled with JetBrains decompiler
// Type: BarracksOutfitPanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BarracksOutfitPanelHandler : MonoBehaviour
{
  private bool 딟;
  private bool 땄;
  private string 딟;
  private 땃.땢 딟;
  private LoadingScreenOverlayHandler 딟;
  public MenuAnimatorHandler MenuAnim;
  public bool IsClosing;
  public GuiButton3D BuyMoreButton;
  public GuiText3D OutfitName;
  public GameObject LockedBackground;
  public GameObject UnlockedBackground;
  public StorePurchaseConfirmationPanelHandler StorePurchaseConfirmationPanel;
  public ErrorMessagehandler ErrorMessage;
  public LoadingScreenOverlayHandler LoadingOverlay;
  public GameObject ScrollerUpArrow;
  public GameObject ScrollerDownArrow;

  private void Awake()
  {
    ((Component) this.BuyMoreButton).gameObject.SetActive(false);
    this.set_IsEnteringTheShop(false);
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (BarracksOutfitPanelHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      BarracksOutfitPanelHandler.딟 = new Dictionary<string, int>(1)
      {
        {
          "Buy",
          0
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!BarracksOutfitPanelHandler.딟.TryGetValue(key, out num) || num != 0)
      return;
    this.set_IsEnteringTheShop(true);
    if (Object.op_Equality((Object) this.딟, (Object) null))
      this.딟 = Object.Instantiate((Object) this.LoadingOverlay, new Vector3(0.0f, 3.1f, 0.0f), Quaternion.identity) as LoadingScreenOverlayHandler;
    this.딟 = new 땃.땢(GlobalAppData.땼().딣(this.딟).땄());
    FrontendHub.딟.BarracksScreen.ClosePanels();
  }

  public void Init(bool DisplayStoreButton, Transform StartPoint, Transform EndPoint)
  {
    this.딟 = DisplayStoreButton;
    this.MenuAnim = ((Component) this).GetComponent<MenuAnimatorHandler>();
    this.MenuAnim.SetWaitForUpdate(true);
    this.MenuAnim.StartPoint = StartPoint;
    this.MenuAnim.EndPoint = EndPoint;
  }

  private void Update()
  {
    if (this.딟 == null || !this.딟.딟())
      return;
    this.딟.Close();
    if (this.딟.땄())
    {
      StorePurchaseConfirmationPanelHandler confirmationPanelHandler = Object.Instantiate((Object) this.StorePurchaseConfirmationPanel) as StorePurchaseConfirmationPanelHandler;
      confirmationPanelHandler.Init(this.딟.땃(), FrontendHub.딟.StoreScreen.get_ImageCache());
      confirmationPanelHandler.set_OnClosedCallback(new Action(FrontendHub.딟.BarracksScreen.ForceOpenOutfitPanel));
    }
    else
      this.DisplayErrorMessage(this.딟.딢(), !this.딟.딧() ? ErrorMessagehandler.땶.딟 : ErrorMessagehandler.땶.땽);
    this.MenuAnim.SetWaitForUpdate(false);
    this.딟 = (땃.땢) null;
  }

  private void DisplayErrorMessage(딟.땑 ErrorCode, ErrorMessagehandler.땶 ErrorType) => (Object.Instantiate((Object) this.ErrorMessage) as ErrorMessagehandler).Init(ErrorType, ErrorCode);

  private void UpdatePanelDisplay(딢.때 Product)
  {
    int num1 = GlobalAppData.땽().때();
    int num2 = Product.땺();
    ((Component) this.BuyMoreButton).gameObject.SetActive(false);
    if (GlobalAppData.떏().땥() && this.딟 && !this.땄 && !Product.땥() && num1 > num2)
      ((Component) this.BuyMoreButton).gameObject.SetActive(true);
    if (this.땄)
    {
      this.LockedBackground.SetActive(false);
      this.UnlockedBackground.SetActive(true);
      this.OutfitName.TextColor = Color.black;
    }
    else
    {
      this.LockedBackground.SetActive(true);
      this.UnlockedBackground.SetActive(false);
      this.OutfitName.TextColor = Color.white;
    }
    this.OutfitName.UpdateMesh();
  }

  public void Close()
  {
    ((Component) this.BuyMoreButton).gameObject.SetActive(false);
    if (!this.땄)
    {
      if (!this.get_IsEnteringTheShop())
        FrontendHub.딟.BarracksScreen.SetSelectedCharacterOutfit();
    }
    else
      FrontendHub.딟.BarracksScreen.ClearOutfitFallback();
    this.IsClosing = true;
    if (this.딟 == null)
      this.MenuAnim.SetWaitForUpdate(false);
    this.MenuAnim.Close();
  }

  public void UpdateOutfitInfo(string OutfitId)
  {
    this.딟 = OutfitId;
    this.땄 = true;
    딢.때 Product = GlobalAppData.땼().딣(OutfitId);
    if (!string.IsNullOrEmpty(Product.땄()) && !GlobalAppData.땽().딶(Product.땄()))
      this.땄 = false;
    UnitOutfit OutfitInfo = GlobalAppData.땼().떏(OutfitId);
    this.UpdatePanelDisplay(Product);
    this.UpdateOutfitInfo(OutfitInfo);
  }

  public void UpdateOutfitInfo(UnitOutfit OutfitInfo)
  {
    if (Object.op_Equality((Object) OutfitInfo, (Object) null))
      땓.땞.딟(this.OutfitName, " ??? ");
    else
      땓.땞.딟(this.OutfitName, OutfitInfo.Name);
    this.UpdateScrollerControlButtons();
  }

  private void UpdateScrollerControlButtons()
  {
    int num = FrontendHub.딟.BarracksScreen.BarracksOutfitScroller.get_ActiveElement();
    int numElements = FrontendHub.딟.BarracksScreen.BarracksOutfitScroller.NumElements;
    if (numElements == 0)
    {
      this.ScrollerUpArrow.SetActive(false);
      this.ScrollerDownArrow.SetActive(false);
    }
    else
    {
      if (Object.op_Inequality((Object) this.ScrollerDownArrow, (Object) null))
      {
        if (num == 0)
          this.ScrollerDownArrow.SetActive(false);
        else
          this.ScrollerDownArrow.SetActive(true);
      }
      if (!Object.op_Inequality((Object) this.ScrollerUpArrow, (Object) null))
        return;
      if (num == numElements - 1)
        this.ScrollerUpArrow.SetActive(false);
      else
        this.ScrollerUpArrow.SetActive(true);
    }
  }

  [CompilerGenerated]
  [SpecialName]
  public bool get_IsEnteringTheShop() => this.딧;

  [CompilerGenerated]
  [SpecialName]
  public void set_IsEnteringTheShop(bool value) => this.딧 = value;
}
