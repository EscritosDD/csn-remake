// Decompiled with JetBrains decompiler
// Type: 땄.땬
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
  public class 땬 : 땷
  {
    private 딬 딟;

    public 땬([In] 딟.땇 obj0, [In] 딬 obj1)
      : base(obj0)
    {
      this.딟 = obj1;
      byte[] bytes = Encoding.UTF8.GetBytes("grant_type=client_credentials");
      this.딟("POST", obj0.땋() + "/auth/token", bytes, (땷.딸) 0);
      this.땄("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(obj0.땤() + ":" + obj0.땽())));
      ((딧.땋) this).딧();
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.OK)
      {
        AccessTokenData accessTokenData = this.땓<AccessTokenData>();
        ((딧.땋) new 떊(this.딶(), this.딟, accessTokenData.AccessToken)).딶();
      }
      else
        this.딟.땄(true);
    }

    public override void 땄() => this.딟.땄(true);

    [SpecialName]
    public override 땘 딧() => (땘) this.딟;
  }
}
