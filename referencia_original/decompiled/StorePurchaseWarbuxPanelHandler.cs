// Decompiled with JetBrains decompiler
// Type: StorePurchaseWarbuxPanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StorePurchaseWarbuxPanelHandler : MonoBehaviour
{
  private bool 딟;
  private int 딟;
  private int 땄 = 6;
  private int 딧;
  private List<땃.딷> 딟;
  private GameObject 딟;
  public GameObject Overlay;
  public StorePurchaseWarbuxConfirmationPanelHandle WarbuxConfirmationPanelPrefab;
  public GuiButton3D CloseButton;
  public GuiButton3D NextSetArrow;
  public GuiButton3D PreviousSetArrow;
  public GuiMultiLineText3D YouDontHaveEnoughText;
  public StoreQuickPurchaseWarbuxButtonHandler[] Buttons = new StoreQuickPurchaseWarbuxButtonHandler[6];
  private 딟.땫 딟;

  private void Start()
  {
    ((Component) this.CloseButton).gameObject.SetActive(false);
    ((Component) this.YouDontHaveEnoughText).gameObject.SetActive(false);
    ((Component) this.NextSetArrow).gameObject.SetActive(false);
    ((Component) this.PreviousSetArrow).gameObject.SetActive(false);
    foreach (Component button in this.Buttons)
      button.gameObject.SetActive(false);
    this.딧 = 0;
    this.딟 = GlobalAppData.땋().땃().Where<땃.딷>((Func<땃.딷, bool>) (obj0 => obj0.땂())).ToList<땃.딷>();
    this.딟 = Object.Instantiate((Object) this.Overlay) as GameObject;
    this.딟.transform.position = Vector3.op_Subtraction(((Component) this).transform.position, new Vector3(0.0f, 0.1f, 0.0f));
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (StorePurchaseWarbuxPanelHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      StorePurchaseWarbuxPanelHandler.딟 = new Dictionary<string, int>(3)
      {
        {
          "Cancel",
          0
        },
        {
          "NextSet",
          1
        },
        {
          "PreviousSet",
          2
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!StorePurchaseWarbuxPanelHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        this.딟.GetComponent<MenuOverlayHandler>().Close();
        if (this.get_OnClosedCallback() != null)
          this.get_OnClosedCallback()();
        Object.Destroy((Object) ((Component) this).gameObject);
        break;
      case 1:
        ++this.딧;
        this.InitialiseScrollArrows();
        this.AssignStoreItemToButtons();
        break;
      case 2:
        --this.딧;
        this.InitialiseScrollArrows();
        this.AssignStoreItemToButtons();
        break;
    }
  }

  private void Update()
  {
    if (this.딟 || ((Component) this).animation.isPlaying)
      return;
    ((Component) this.CloseButton).gameObject.SetActive(true);
    ((Component) this.YouDontHaveEnoughText).gameObject.SetActive(true);
    foreach (Component button in this.Buttons)
      button.gameObject.SetActive(true);
    this.딟 = this.딟.Count;
    this.InitialiseScrollArrows();
    this.AssignStoreItemToButtons();
    if (this.get_OnOpenCallback() != null)
      this.get_OnOpenCallback()();
    this.딟 = true;
  }

  private void InitialiseScrollArrows()
  {
    if (this.딧 == 0)
    {
      ((Component) this.PreviousSetArrow).gameObject.SetActive(false);
      this.PreviousSetArrow.Disabled = true;
    }
    else
    {
      ((Component) this.PreviousSetArrow).gameObject.SetActive(true);
      this.PreviousSetArrow.Disabled = false;
    }
    if (this.딟 > this.땄)
    {
      if (this.딧 == 0)
      {
        ((Component) this.NextSetArrow).gameObject.SetActive(true);
        this.NextSetArrow.Disabled = false;
      }
      else if (this.딟 >= this.땄 + this.땄 * this.딧)
      {
        ((Component) this.NextSetArrow).gameObject.SetActive(true);
        this.NextSetArrow.Disabled = false;
      }
      else
      {
        ((Component) this.NextSetArrow).gameObject.SetActive(false);
        this.NextSetArrow.Disabled = true;
      }
    }
    else
    {
      ((Component) this.NextSetArrow).gameObject.SetActive(false);
      this.NextSetArrow.Disabled = true;
    }
  }

  private void AssignStoreItemToButtons()
  {
    int index = 0;
    int num = 0;
    foreach (Component button in this.Buttons)
      button.gameObject.SetActive(false);
    for (; num + this.딧 * this.땄 < this.딟; ++num)
    {
      for (; index < this.땄; ++index)
      {
        if (index + this.딧 * this.땄 < this.딟)
        {
          ((Component) this.Buttons[index]).gameObject.SetActive(true);
          this.Buttons[index].Init(this.딟, this.딟[index + this.딧 * this.땄]);
        }
      }
    }
  }

  private void QuickPurchaseWarbux(땃.딷 Item)
  {
    StorePurchaseWarbuxConfirmationPanelHandle confirmationPanelHandle = Object.Instantiate((Object) this.WarbuxConfirmationPanelPrefab, ((Component) this).transform.position, Quaternion.identity) as StorePurchaseWarbuxConfirmationPanelHandle;
    confirmationPanelHandle.Init(this.딟, Item);
    confirmationPanelHandle.SetOnClosedCallback(this.get_OnClosedCallback());
    this.딟.GetComponent<MenuOverlayHandler>().Close();
    Object.Destroy((Object) ((Component) this).gameObject);
  }

  public void Init(딟.땫 ImageCache) => this.딟 = ImageCache;

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
}
