// Decompiled with JetBrains decompiler
// Type: 땄.딞
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땄
{
  internal class 딞 : 땷
  {
    private 딖 딟;

    public 딞([In] 딟.땇 obj0, [In] 딖 obj1, [In] string obj2, [In] string obj3)
      : base(obj0)
    {
      this.딟 = obj1;
      this.딟("DELETE", obj0.땋() + string.Format("/users/{0}/invites/{1}", (object) obj2, (object) obj3), 땷.딸.딟);
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
