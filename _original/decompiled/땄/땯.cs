// Decompiled with JetBrains decompiler
// Type: 땄.땯
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
  internal class 땯 : 땷
  {
    private 땞 딟;
    private 땚 딟;

    public 땯([In] 딟.땇 obj0, [In] 땞 obj1, [In] 땚 obj2)
      : base(obj0)
    {
      this.딟 = obj2;
      this.딟 = obj1;
      this.딟("GET", obj0.땋() + string.Format("/sessions/{0}/turns?per_page={1}", (object) obj1.딟, (object) obj1.딧), 땷.딸.딟);
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.OK)
      {
        this.딟.딟 = ((IEnumerable<TurnBasedSessionTurnData>) this.땓<SessionTurnsListData>().Items).Select<TurnBasedSessionTurnData, 땉>((Func<TurnBasedSessionTurnData, 땉>) (obj0 => new 땉(obj0))).ToArray<땉>();
        this.딟.딧(true);
        this.딶().땄(this.딟);
      }
      this.딟.땄(true);
    }

    public override void 땄() => this.딟.땄(true);

    [SpecialName]
    public override 땘 딧() => (땘) this.딟;
  }
}
