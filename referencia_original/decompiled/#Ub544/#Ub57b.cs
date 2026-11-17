// Decompiled with JetBrains decompiler
// Type: 땄.땻
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땄
{
  public class 땻 : 땷
  {
    private Action<땳> 딟;
    private 땳 딟;

    public 땻([In] 딟.땇 obj0, [In] string obj1, [In] string obj2, [In] string obj3, [In] 땳 obj4, [In] Action<땳> obj5)
      : base(obj0)
    {
      this.딟 = obj4;
      this.딟 = obj5;
      this.딟("GET", this.딶().땋() + string.Format("/objects/{0}/{1}/links/{2}", (object) obj1, (object) obj2, (object) obj3), 땷.딸.딟);
    }

    [SpecialName]
    public override 땘 딧() => (땘) this.딟;

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.OK)
      {
        this.딟.딟(this.땓<Dictionary<string, object>>());
        this.딟.딧(true);
      }
      this.딟.땄(true);
      this.딟(this.딟);
    }

    public override void 땄()
    {
      this.딟.땄(true);
      this.딟(this.딟);
    }
  }
}
