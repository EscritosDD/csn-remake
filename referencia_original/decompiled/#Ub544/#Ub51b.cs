// Decompiled with JetBrains decompiler
// Type: 땄.딛
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땄
{
  internal class 딛 : 땷
  {
    private 떓 딟;

    public 딛([In] 딟.땇 obj0, [In] string obj1, [In] string obj2, [In] 딥 obj3, [In] 떓 obj4, [In] bool obj5)
      : base(obj0)
    {
      this.딟 = obj4;
      string stringToEscape = obj2;
      string str = string.Format("service={0}&target_id={1}", (object) (int) obj3, (object) Uri.EscapeDataString(stringToEscape));
      this.딟("PUT", obj0.땋() + string.Format("/users/{0}/push_channels", (object) obj1), str, 땷.딸.딟);
      ((딧.땋) this).딧();
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
