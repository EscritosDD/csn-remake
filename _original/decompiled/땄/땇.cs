// Decompiled with JetBrains decompiler
// Type: 땄.땇
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
  internal class 땇 : 땷
  {
    private 딚 딟;

    public 땇([In] 딟.땇 obj0, [In] 딚 obj1, [In] string obj2)
      : base(obj0)
    {
      this.딟 = obj1;
      this.딟("GET", obj0.땋() + string.Format("/sessions/turnbased/{0}", (object) obj2), 땷.딸.딟);
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.OK)
      {
        this.딟.딟 = new 땞(this.땓<TurnBasedSessionData>(), new Func<Dictionary<string, object>, 땈>(this.딶().땄));
        this.딟.딧(true);
      }
      this.딟.땄(true);
    }

    public override void 땄() => this.딟.땄(true);

    [SpecialName]
    public override 땘 딧() => (땘) this.딟;
  }
}
