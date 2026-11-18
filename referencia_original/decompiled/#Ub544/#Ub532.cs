// Decompiled with JetBrains decompiler
// Type: 땄.딲
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace 땄
{
  internal class 딲 : 땷
  {
    private 땿 딟;
    private Action<땿> 딟;

    public 딲([In] 딟.땇 obj0, [In] 땿 obj1, [In] string obj2, [In] string obj3, [In] string obj4, [In] Action<땿> obj5)
      : base(obj0)
    {
      this.딟 = obj1;
      this.딟 = obj5;
      string str1 = obj0.땋() + string.Format("/store/android/transactions/{0}", (object) obj2);
      AndroidPurchaseData androidPurchaseData = new AndroidPurchaseData();
      byte[] bytes = Encoding.UTF8.GetBytes(obj3);
      androidPurchaseData.purchaseData = Convert.ToBase64String(bytes);
      androidPurchaseData.signature = obj4;
      string str2 = 딧.땾.땄((object) androidPurchaseData);
      this.딟("PUT", str1, str2, 땷.딸.딟);
      ((딧.땋) this).땃();
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.OK)
      {
        this.딟.딟 = this.땓<PurchaseResult>();
        this.딟.딧(true);
      }
      this.딶();
    }

    public override void 땄() => this.딶();

    private new void 딶()
    {
      this.딟.땄(true);
      this.딟(this.딟);
    }

    [SpecialName]
    public override 땘 딧() => (땘) this.딟;
  }
}
