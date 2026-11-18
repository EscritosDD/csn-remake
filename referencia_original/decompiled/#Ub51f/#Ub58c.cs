// Decompiled with JetBrains decompiler
// Type: 딟.떌
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace 딟
{
  internal class 떌 : 땄.땷
  {
    private 땯 딟;

    public 떌([In] 땇 obj0, [In] 땯 obj1)
      : base(obj0)
    {
      this.딟 = obj1;
      byte[] bytes = Encoding.UTF8.GetBytes(string.Format("grant_type=refresh_token&refresh_token={0}", (object) obj0.떂()));
      this.딟("POST", obj0.땋() + "/auth/token", bytes, (땄.땷.딸) 0);
      this.땄("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(obj0.땤() + ":" + obj0.땽())));
      ((딧.땋) this).딧();
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.OK)
      {
        AccessTokenData accessTokenData = this.땓<AccessTokenData>();
        this.딟.딟 = accessTokenData.AccessToken;
        this.딟.땄 = accessTokenData.RefreshToken;
        this.딟.딧(true);
      }
      else if (this.딝().땄() == HttpStatusCode.BadRequest)
      {
        ErrorData errorData = this.땓<ErrorData>();
        if (errorData != null && errorData.Error != null && errorData.Error == "invalid_grant")
          this.딟.딟 = true;
      }
      this.딟.땄(true);
    }

    public override void 땄() => this.딟.땄(true);

    [SpecialName]
    public override 땄.땘 딧() => (땄.땘) this.딟;
  }
}
