// Decompiled with JetBrains decompiler
// Type: 땄.떄
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땄
{
  internal class 떄 : 땷
  {
    private 딾 딟;

    public 떄([In] 딟.땇 obj0, [In] 땞 obj1, [In] int obj2, [In] 딾 obj3)
      : base(obj0)
    {
      this.딟 = obj3;
      this.딟("POST", obj0.땋() + string.Format("/sessions/{0}/turns/{1}/disputes", (object) obj1.딟, (object) obj2), 땷.딸.딟);
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.OK)
        this.딟.딧(true);
      this.딟.땄(true);
    }

    public override void 땄() => this.딟.땄(true);

    [SpecialName]
    public override 땘 딧() => (땘) this.딟;
  }
}
