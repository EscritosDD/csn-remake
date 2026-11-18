// Decompiled with JetBrains decompiler
// Type: 딟.딭
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
using 땄;

namespace 딟
{
  internal class 딭 : 땷
  {
    private 딤 딟;

    public 딭([In] 땇 obj0, [In] string obj1, [In] 딤 obj2)
      : base(obj0)
    {
      this.딟 = obj2;
      this.딟("GET", obj0.땋() + string.Format("/users/{0}/friends", (object) obj1) + "?per_page=200&extended=true", 땷.딸.딟);
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.OK)
      {
        this.딟.딟 = ((IEnumerable<UserData>) this.땓<FriendsData>().Items).Select<UserData, 땄.딽>((Func<UserData, 땄.딽>) (obj0 => new 땄.딽(obj0, new Func<Dictionary<string, object>, 땄.땅>(this.딶().딟)))).ToArray<땄.딽>();
        this.딟.딧(true);
        this.딶().딟((IEnumerable<땄.딽>) this.딟.딟);
      }
      this.딟.땄(true);
    }

    public override void 땄() => this.딟.땄(true);

    [SpecialName]
    public override 땄.땘 딧() => (땄.땘) this.딟;
  }
}
