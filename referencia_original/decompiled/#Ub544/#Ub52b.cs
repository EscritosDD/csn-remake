// Decompiled with JetBrains decompiler
// Type: 땄.딫
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땄
{
  internal class 딫 : 땷
  {
    private Action<떅> 딟;
    private 떅 딟;

    public 딫([In] 딟.땇 obj0, [In] Action<떅> obj1, [In] string obj2, [In] string obj3)
      : base(obj0)
    {
      this.딟 = new 떅();
      this.딟 = obj1;
      string str = string.Format("offer_id={0}&region={1}", (object) obj2, (object) obj3);
      this.딟("POST", obj0.땋() + "/store/googlewallet/transactions", str, 땷.딸.딟);
      ((딧.땋) this).딧();
      this.땄("x-fireteam-country", obj3);
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.Created)
      {
        this.딟.딟(this.땓<JWTData>().JWT);
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
