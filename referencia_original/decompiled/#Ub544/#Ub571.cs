// Decompiled with JetBrains decompiler
// Type: 땄.땱
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땄
{
  internal class 땱 : 땷
  {
    private 땣 딟;

    public 땱([In] 딟.땇 obj0, [In] string obj1, [In] 땣 obj2)
      : base(obj0)
    {
      this.딟 = obj2;
      this.딟("GET", obj0.땋() + string.Format("/users/{0}?extended=true", (object) obj1), 땷.딸.딟);
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.OK)
      {
        this.딟.딟 = new 딽(this.땓<UserData>(), new Func<Dictionary<string, object>, 땅>(this.딶().딟));
        this.딟.딧(true);
        this.딶().딟(this.딟.딟);
      }
      this.딟.땄(true);
    }

    public override void 땄() => this.딟.땄(true);

    [SpecialName]
    public override 땘 딧() => (땘) this.딟;
  }
}
