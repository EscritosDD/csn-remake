// Decompiled with JetBrains decompiler
// Type: 땄.땀
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
  internal class 땀 : 땷
  {
    private 딴 딟;

    public 땀(
      [In] 딟.땇 obj0_1,
      [In] 딴 obj1,
      [In] string obj2,
      [In] int obj3,
      [In] string obj4,
      [In] string obj5,
      [In] Dictionary<string, int> obj6,
      [In] bool obj7,
      [In] List<딟.떀> obj8,
      [In] List<딟.떀> obj9)
      : base(obj0_1)
    {
      this.딟 = obj1;
      string str1 = obj0_1.땋() + string.Format("/sessions/{0}/turns/{1}", (object) obj2, (object) obj3);
      WriteSessionTurnData writeSessionTurnData = new WriteSessionTurnData();
      writeSessionTurnData.NextUserId = obj4;
      writeSessionTurnData.Data = 딟.딥.딟(obj5);
      if (obj8 != null)
        writeSessionTurnData.Ops = obj8.Select<딟.떀, object[]>((Func<딟.떀, object[]>) (obj0_3 => obj0_3.딟())).ToArray<object[]>();
      if (obj9 != null)
        writeSessionTurnData.ExpireOps = obj9.Select<딟.떀, object[]>((Func<딟.떀, object[]>) (obj0_5 => obj0_5.딟())).ToArray<object[]>();
      writeSessionTurnData.Inventory = obj6;
      writeSessionTurnData.JoinSlotType = !obj7 ? 딟.땎.딟 : 딟.땎.땄;
      string str2 = 딧.땾.땄((object) writeSessionTurnData);
      this.딟("PUT", str1, str2, 땷.딸.딟);
      ((딧.땋) this).땃();
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.Created)
        this.딟.딧(true);
      else if (this.딝().땄() == HttpStatusCode.Forbidden)
      {
        switch (((땘) this.딟).딟)
        {
          case 딟.땑.땭:
            this.딟.딟 = true;
            break;
          case 딟.땑.땽:
          case 딟.땑.땋:
            this.딟.땄 = true;
            break;
        }
      }
      this.딟.땄(true);
    }

    public override void 땄() => this.딟.땄(true);

    [SpecialName]
    public override 땘 딧() => (땘) this.딟;
  }
}
