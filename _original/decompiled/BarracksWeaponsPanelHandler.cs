// Decompiled with JetBrains decompiler
// Type: BarracksWeaponsPanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BarracksWeaponsPanelHandler : MonoBehaviour
{
  private string 딟;
  private bool 딟;
  private int 딟;
  private bool 땄;
  private 땃.땢 딟;
  private LoadingScreenOverlayHandler 딟;
  public MenuAnimatorHandler MenuAnim;
  public bool IsClosing;
  public GuiText3D WeaponName;
  public GuiText3D WeaponCountInfo;
  public GuiText3D WeaponSquadPointCostText;
  public GuiButton3D BuyMoreButton;
  public GameObject LockedBackground;
  public GameObject UnlockedBackground;
  public Animation SquadPointsIconAnim;
  public GameObject LevelLockedDisplay;
  public GuiText3D LevelLockedNumber;
  public StorePurchaseConfirmationPanelHandler StorePurchaseConfirmationPanel;
  public ErrorMessagehandler ErrorMessage;
  public LoadingScreenOverlayHandler LoadingOverlay;
  public GameObject ScrollerUpArrow;
  public GameObject ScrollerDownArrow;

  private void Start()
  {
  }

  public void Init(Transform StartPoint, Transform EndPoint)
  {
    this.MenuAnim = ((Component) this).GetComponent<MenuAnimatorHandler>();
    this.MenuAnim.SetWaitForUpdate(true);
    this.MenuAnim.StartPoint = StartPoint;
    this.MenuAnim.EndPoint = EndPoint;
    ((Component) this.BuyMoreButton).gameObject.SetActive(false);
    this.LevelLockedDisplay.gameObject.SetActive(false);
    this.set_IsEnteringTheShop(false);
  }

  private void ReOpenPanel() => FrontendHub.딟.BarracksScreen.ForceOpenWeaponPanel();

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (BarracksWeaponsPanelHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      BarracksWeaponsPanelHandler.딟 = new Dictionary<string, int>(1)
      {
        {
          "Buy",
          0
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!BarracksWeaponsPanelHandler.딟.TryGetValue(key, out num) || num != 0)
      return;
    this.set_IsEnteringTheShop(true);
    if (Object.op_Equality((Object) this.딟, (Object) null))
      this.딟 = Object.Instantiate((Object) this.LoadingOverlay, new Vector3(0.0f, 3.1f, 0.0f), Quaternion.identity) as LoadingScreenOverlayHandler;
    this.딟 = new 땃.땢(GlobalAppData.땼().땔(this.딟).땄());
    FrontendHub.딟.BarracksScreen.ClosePanels();
  }

  public void UpdateWeaponInfo(string SelectedWeaponId, int NumberOfWeaponInUse)
  {
    this.딟 = SelectedWeaponId;
    this.딟 = NumberOfWeaponInUse;
    this.SquadPointsIconAnim.Play();
    this.딟 = true;
  }

  private void Update()
  {
    if (this.딟)
    {
      딢.땻 Product = GlobalAppData.땼().땔(this.딟);
      if (Object.op_Equality((Object) Product.땥(), (Object) null))
        this.WeaponName.Text = " ??? ";
      else
        this.WeaponName.LocText = Product.땥().Name;
      this.WeaponName.UpdateMesh();
      int num = GlobalAppData.땽().땃(Product.땄());
      this.땄 = num >= this.딟;
      this.WeaponCountInfo.Text = Mathf.Min(this.딟, num).ToString() + " / " + num.ToString();
      this.WeaponCountInfo.UpdateMesh();
      this.WeaponSquadPointCostText.Text = GlobalAppData.딢().딟(this.딟).SquadPoints.ToString();
      this.WeaponSquadPointCostText.UpdateMesh();
      this.UpdateWeaponDisplay(Product);
      this.딟 = false;
    }
    if (this.딟 == null || !this.딟.딟())
      return;
    this.딟.Close();
    if (this.딟.땄())
    {
      StorePurchaseConfirmationPanelHandler confirmationPanelHandler = Object.Instantiate((Object) this.StorePurchaseConfirmationPanel) as StorePurchaseConfirmationPanelHandler;
      confirmationPanelHandler.Init(this.딟.땃(), FrontendHub.딟.StoreScreen.get_ImageCache());
      confirmationPanelHandler.set_OnClosedCallback(new Action(FrontendHub.딟.BarracksScreen.ForceOpenWeaponPanel));
    }
    else
      this.DisplayErrorMessage(this.딟.딢(), !this.딟.딧() ? ErrorMessagehandler.땶.딟 : ErrorMessagehandler.땶.땽);
    this.MenuAnim.SetWaitForUpdate(false);
    this.딟 = (땃.땢) null;
  }

  private void DisplayErrorMessage(딟.땑 ErrorCode, ErrorMessagehandler.땶 ErrorType) => (Object.Instantiate((Object) this.ErrorMessage) as ErrorMessagehandler).Init(ErrorType, ErrorCode);

  private void UpdateWeaponDisplay(딢.땻 Product)
  {
    int num1 = GlobalAppData.땽().때();
    int num2 = Product.땓();
    this.LevelLockedDisplay.gameObject.SetActive(false);
    if (this.땄)
    {
      ((Component) this.BuyMoreButton).gameObject.SetActive(false);
      this.LockedBackground.SetActive(false);
      this.UnlockedBackground.SetActive(true);
      this.WeaponName.TextColor = Color.black;
    }
    else
    {
      if (GlobalAppData.떏().땥())
      {
        ((Component) this.BuyMoreButton).gameObject.SetActive(true);
        if (Product.땺())
          ((Component) this.BuyMoreButton).gameObject.SetActive(false);
        if (num1 <= num2)
        {
          ((Component) this.BuyMoreButton).gameObject.SetActive(false);
          this.LevelLockedNumber.Text = (Product.땓() + 1).ToString();
          this.LevelLockedNumber.UpdateMesh();
          this.LevelLockedDisplay.gameObject.SetActive(true);
        }
      }
      this.LockedBackground.SetActive(true);
      this.UnlockedBackground.SetActive(false);
      this.WeaponName.TextColor = Color.white;
    }
    this.WeaponName.UpdateMesh();
    if (!Object.op_Inequality((Object) this.ScrollerDownArrow, (Object) null) || !Object.op_Inequality((Object) this.ScrollerUpArrow, (Object) null))
      return;
    this.UpdateScrollerControlButtons();
  }

  private void UpdateScrollerControlButtons()
  {
    int num1 = FrontendHub.딟.BarracksScreen.BarracksWeaponScroller.get_ActiveElement();
    int num2 = FrontendHub.딟.BarracksScreen.BarracksWeaponScroller.NumElements - 1;
    if (Object.op_Inequality((Object) this.ScrollerDownArrow, (Object) null))
    {
      if (num1 == 0)
        this.ScrollerDownArrow.SetActive(false);
      else
        this.ScrollerDownArrow.SetActive(true);
    }
    if (!Object.op_Inequality((Object) this.ScrollerUpArrow, (Object) null))
      return;
    if (num1 == num2)
      this.ScrollerUpArrow.SetActive(false);
    else
      this.ScrollerUpArrow.SetActive(true);
  }

  public void Close()
  {
    if (!this.땄)
    {
      if (!FrontendHub.딟.BarracksScreen.get_OpeningWeaponsInfoPanel() && !this.get_IsEnteringTheShop())
        FrontendHub.딟.BarracksScreen.SetSelectedCharacterWeapon();
    }
    else if (!FrontendHub.딟.BarracksScreen.get_OpeningWeaponsInfoPanel())
      FrontendHub.딟.BarracksScreen.ClearWeaponFallback();
    this.IsClosing = true;
    if (this.딟 == null)
      this.MenuAnim.SetWaitForUpdate(false);
    this.MenuAnim.Close();
  }

  [CompilerGenerated]
  [SpecialName]
  public bool get_IsEnteringTheShop() => this.딧;

  [CompilerGenerated]
  [SpecialName]
  public void set_IsEnteringTheShop(bool value) => this.딧 = value;
}
