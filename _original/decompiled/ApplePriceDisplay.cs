// Decompiled with JetBrains decompiler
// Type: ApplePriceDisplay
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class ApplePriceDisplay : MonoBehaviour
{
  public void Start()
  {
    if (this.get_Offer() == null || Object.op_Equality((Object) this.get_TextControl(), (Object) null))
      Object.Destroy((Object) this);
    else
      this.StartCoroutine(this.UpdatePrice());
  }

  [DebuggerHidden]
  private IEnumerator UpdatePrice() => (IEnumerator) new ApplePriceDisplay.\u003CUpdatePrice\u003Ec__Iterator14()
  {
    딟 = this
  };

  public static void 딟(
    [In] 땃.딷 obj0,
    [In] GameObject obj1,
    [In] GuiText3D obj2,
    [In] GuiText3D obj3,
    [In] GameObject obj4,
    [In] Action obj5)
  {
    if (!Object.op_Inequality((Object) obj2, (Object) null))
      return;
    OfferData offerData = obj0.땥();
    if (offerData == null)
      return;
    ApplePriceDisplay applePriceDisplay = obj1.AddComponent<ApplePriceDisplay>();
    applePriceDisplay.set_Offer(offerData);
    applePriceDisplay.set_TextControl(obj2);
    applePriceDisplay.set_TextShadowControl(obj3);
    applePriceDisplay.set_Display(obj4);
    applePriceDisplay.set_CompletionCallback(obj5);
  }

  [CompilerGenerated]
  [SpecialName]
  public OfferData get_Offer() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public void set_Offer(OfferData value) => this.딟 = value;

  [CompilerGenerated]
  [SpecialName]
  public GuiText3D get_TextControl() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public void set_TextControl(GuiText3D value) => this.딟 = value;

  [CompilerGenerated]
  [SpecialName]
  public GuiText3D get_TextShadowControl() => this.땄;

  [CompilerGenerated]
  [SpecialName]
  public void set_TextShadowControl(GuiText3D value) => this.땄 = value;

  [CompilerGenerated]
  [SpecialName]
  public GameObject get_Display() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public void set_Display(GameObject value) => this.딟 = value;

  [CompilerGenerated]
  [SpecialName]
  public Action get_CompletionCallback() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public void set_CompletionCallback(Action value) => this.딟 = value;
}
