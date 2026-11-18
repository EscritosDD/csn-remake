// Decompiled with JetBrains decompiler
// Type: 땄.딩
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땄
{
  internal class 딩 : 땷
  {
    private 떋 딟;

    public 딩([In] 딟.땇 obj0, [In] 떋 obj1, [In] string obj2)
      : base(obj0)
    {
      this.딟 = obj1;
      this.딟("POST", obj0.땋() + string.Format("/sessions/{0}", (object) obj2) + string.Format("?state={0}", (object) 4), 땷.딸.딟);
      this.딧("PATCH");
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.NoContent)
        this.딟.딧(true);
      this.딟.땄(true);
    }

    public override void 땄() => this.딟.땄(true);

    [SpecialName]
    public override 땘 딧() => (땘) this.딟;
  }
}
