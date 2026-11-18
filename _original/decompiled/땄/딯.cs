// Decompiled with JetBrains decompiler
// Type: 땄.딯
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
  internal class 딯 : 땷
  {
    protected 땕 딟;

    public 딯([In] 딟.땇 obj0, [In] 땕 obj1)
      : base(obj0)
    {
      this.딟 = obj1;
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.OK)
      {
        this.딟.딟 = ((IEnumerable<TurnBasedSessionData>) this.땓<SessionListData>().Items).Select<TurnBasedSessionData, 땞>((Func<TurnBasedSessionData, 땞>) (obj0 => new 땞(obj0, new Func<Dictionary<string, object>, 땈>(this.딶().땄)))).ToArray<땞>();
        this.딟.딧(true);
      }
      this.딟.땄(true);
    }

    public override void 땄() => this.딟.땄(true);

    [SpecialName]
    public override 땘 딧() => (땘) this.딟;
  }
}
