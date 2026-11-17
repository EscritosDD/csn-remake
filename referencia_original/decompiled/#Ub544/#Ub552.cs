// Decompiled with JetBrains decompiler
// Type: 땄.땒
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
  internal class 땒 : 땷
  {
    private 딴 딟;

    public 땒(
      [In] 딟.땇 obj0_1,
      [In] 딴 obj1,
      [In] string obj2,
      [In] int obj3,
      [In] string obj4,
      [In] string obj5,
      [In] Dictionary<string, 딟.땾> obj6,
      [In] List<딟.떀> obj7)
      : base(obj0_1)
    {
      this.딟 = obj1;
      this.딟("PUT", obj0_1.땋() + string.Format("/sessions/{0}/turns/{1}", (object) obj2, (object) obj3), 딧.땾.땄((object) new WriteSessionTurnData()
      {
        NextUserId = obj4,
        Data = 딟.딥.딟(obj5),
        State = 딟.딺.딶,
        Outcomes = obj6,
        Ops = (obj7 != null ? obj7.Select<딟.떀, object[]>((Func<딟.떀, object[]>) (obj0_2 => obj0_2.딟())).ToArray<object[]>() : (object[][]) null)
      }), 땷.딸.딟);
      ((딧.땋) this).땃();
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.Created)
        this.딟.딧(true);
      this.딟.땄(true);
    }

    public override void 땄() => this.딟.땄(true);

    [SpecialName]
    public override 땘 딧() => (땘) this.딟;
  }
}
