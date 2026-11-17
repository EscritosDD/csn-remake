// Decompiled with JetBrains decompiler
// Type: 땄.떈
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땄
{
  internal class 떈 : 땷
  {
    private 떐 딟;

    public 떈([In] 딟.땇 obj0, [In] 떐 obj1, [In] string obj2, [In] string obj3, [In] string obj4)
      : base(obj0)
    {
      this.딟 = obj1;
      ((딧.땋) this).딟 = new TimeSpan(0, 0, 20);
      this.딟("GET", obj0.땋() + string.Format("/users/{0}/facebook/friends?per_page=200&extended=true&auth_data.id={1}&auth_data.access_token={2}", (object) obj2, (object) obj3, (object) obj4), 땷.딸.딟);
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.OK)
      {
        this.딟.딟 = ((IEnumerable<FacebookFriendData>) this.땓<FacebookFriendsData>().Items).Select<FacebookFriendData, 딽>((Func<FacebookFriendData, 딽>) (obj0 => new 딽(obj0, new Func<Dictionary<string, object>, 땅>(this.딶().딟)))).ToArray<딽>();
        foreach (딽 딽 in this.딟.딟)
          this.딶().딟(딽);
        this.딟.딧(true);
      }
      this.딟.땄(true);
    }

    public override void 땄() => this.딟.땄(true);

    [SpecialName]
    public override 땘 딧() => (땘) this.딟;
  }
}
