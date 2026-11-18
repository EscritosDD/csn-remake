// Decompiled with JetBrains decompiler
// Type: 딟.땿`1
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
  public class 땿<딟> : 땷
  {
    private Action<딙<딟>> 딟;
    private 딙<딟> 딟;

    public 땿([In] 땇 obj0, [In] string obj1, [In] int obj2, [In] 딙<딟> obj3, [In] Action<딙<딟>> obj4)
      : base(obj0)
    {
      this.딟 = (Action<딙<딟>>) obj3;
      this.딟 = obj4;
      this.딟("GET", obj0.땲() + "/users/xbox-xuid:" + obj1 + "/sessions?type=match&limit=" + obj2.ToString() + "&order=rts&fmt=json", (땷.딸) 0);
      this.땄("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(this.딶().떏() + ":" + this.딶().땼())));
    }

    [SpecialName]
    public override 땄.땘 딧() => (땄.땘) this.딟;

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.OK)
      {
        ((딙<딟>) this.딟).딟(new 딹<딟>(this.땓<EchoSessionListJson>()));
        ((땄.땘) this.딟).딧(true);
      }
      ((땄.땘) this.딟).땄(true);
      this.딟((딙<딟>) this.딟);
    }

    public override void 땄()
    {
      ((땄.땘) this.딟).땄(true);
      this.딟((딙<딟>) this.딟);
    }
  }
}
