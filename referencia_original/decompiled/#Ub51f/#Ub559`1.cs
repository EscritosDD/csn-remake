// Decompiled with JetBrains decompiler
// Type: 딟.땙`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using 땄;

namespace 딟
{
  public class 땙<딟> : 땷
  {
    private Action<딫<딟>> 딟;
    private 딫<딟> 딟;

    public 땙([In] 땇 obj0, [In] 땶 obj1, [In] 딫<딟> obj2, [In] Action<딫<딟>> obj3)
      : base(obj0)
    {
      this.딟 = (Action<딫<딟>>) obj2;
      this.딟 = obj3;
      string str = obj0.땲() + "/sessions/" + obj1.딟() + "/events?fmt=json";
      if (!string.IsNullOrEmpty(obj1.땄()))
        str = str + "&user=xbox-xuid%3A" + obj1.땄();
      if (!string.IsNullOrEmpty(obj1.딧()))
        str = str + "&type=" + obj1.딧();
      if (obj1.땃() != -1L && obj1.딶() != -1L && (obj1.딢() == "r" || obj1.딢() == "tr" || obj1.딢() == "fr"))
      {
        obj1.딟(Math.Min(obj1.땃(), obj1.딶()));
        obj1.땄(Math.Max(obj1.땃(), obj1.딶()));
        str = str + "&" + obj1.딢() + "=" + obj1.땃().ToString() + ":" + obj1.딶().ToString();
      }
      this.딟("GET", str + "&limit=-1", (땷.딸) 0);
      this.땄("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(this.딶().떏() + ":" + this.딶().땼())));
    }

    [SpecialName]
    public override 땄.땘 딧() => (땄.땘) this.딟;

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.OK)
      {
        ((딫<딟>) this.딟).딟(new 떅<딟>(this.땓<EchoEventListJson>()));
        ((땄.땘) this.딟).딧(true);
      }
      ((땄.땘) this.딟).땄(true);
      this.딟((딫<딟>) this.딟);
    }

    public override void 땄()
    {
      ((땄.땘) this.딟).땄(true);
      this.딟((딫<딟>) this.딟);
    }
  }
}
