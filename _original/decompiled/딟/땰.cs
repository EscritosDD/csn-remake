// Decompiled with JetBrains decompiler
// Type: 딟.땰
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using 땄;

namespace 딟
{
  internal class 땰 : 땷
  {
    private 딵 딟;

    public 땰([In] 땇 obj0, [In] string obj1, [In] string obj2, [In] 딵 obj3)
      : base(obj0)
    {
      this.딟 = obj3;
      this.딟("DELETE", obj0.땋() + string.Format("/users/{0}/friends/{1}", (object) obj1, (object) obj2), 땷.딸.딟);
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.NoContent)
        this.딟.딧(true);
      this.딟.땄(true);
    }

    public override void 땄() => this.딟.땄(true);

    [SpecialName]
    public override 땄.땘 딧() => (땄.땘) this.딟;
  }
}
