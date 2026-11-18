// Decompiled with JetBrains decompiler
// Type: CurrencyPurchasePopupHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyPurchasePopupHandler : MonoBehaviour
{
  private const string 딟 = "191a7723-20f1-49a2-aeb5-e3bc0438ebda";
  private const string 땄 = "dda7d59e-8fce-4375-9c9b-856dbd6b85e8";
  private const string 딧 = "1dc7cec1-d24f-402a-b876-8336335cfa5e";
  private Action 딟;
  private Action<string> 딟;
  [SerializeField]
  private MenuOverlayHandler screenOverlayPrefab;
  private MenuOverlayHandler 딟;
  [SerializeField]
  private GuiText3D CostTextField26k;
  [SerializeField]
  private GuiText3D CostTextField80k;
  [SerializeField]
  private GuiText3D CostTextField215k;

  private void Start()
  {
    if (!Object.op_Inequality((Object) this.screenOverlayPrefab, (Object) null))
      return;
    Vector3 localPosition = ((Component) this).transform.localPosition;
    ref Vector3 local = ref localPosition;
    local.y = (__Null) (local.y - 0.0500000007450581);
    this.딟 = Object.Instantiate((Object) this.screenOverlayPrefab, localPosition, Quaternion.identity) as MenuOverlayHandler;
  }

  public void Init(Action closeCallback, Action<string> purchaseCallback)
  {
    this.딟 = closeCallback;
    this.딟 = purchaseCallback;
    foreach (땃.딷 딷 in GlobalAppData.땋().땃())
    {
      if (딷.땃().땄() == "191a7723-20f1-49a2-aeb5-e3bc0438ebda")
        ApplePriceDisplay.딟(딷, ((Component) this).gameObject, this.CostTextField26k, (GuiText3D) null, (GameObject) null, (Action) (() => { }));
      else if (딷.땃().땄() == "dda7d59e-8fce-4375-9c9b-856dbd6b85e8")
        ApplePriceDisplay.딟(딷, ((Component) this).gameObject, this.CostTextField80k, (GuiText3D) null, (GameObject) null, (Action) (() => { }));
      else if (딷.땃().땄() == "1dc7cec1-d24f-402a-b876-8336335cfa5e")
        ApplePriceDisplay.딟(딷, ((Component) this).gameObject, this.CostTextField215k, (GuiText3D) null, (GameObject) null, (Action) (() => { }));
    }
  }

  public void ClosePopup()
  {
    if (Object.op_Inequality((Object) this.딟, (Object) null))
      this.딟.CloseInstantly();
    if (this.딟 == null)
      return;
    this.딟();
  }

  private void OnButtonPressed(string command)
  {
    string key = command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (CurrencyPurchasePopupHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      CurrencyPurchasePopupHandler.딟 = new Dictionary<string, int>(4)
      {
        {
          "Close",
          0
        },
        {
          "26k",
          1
        },
        {
          "80k",
          2
        },
        {
          "215k",
          3
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!CurrencyPurchasePopupHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        this.ClosePopup();
        break;
      case 1:
        this.딟("191a7723-20f1-49a2-aeb5-e3bc0438ebda");
        break;
      case 2:
        this.딟("dda7d59e-8fce-4375-9c9b-856dbd6b85e8");
        break;
      case 3:
        this.딟("1dc7cec1-d24f-402a-b876-8336335cfa5e");
        break;
    }
  }
}
