// Decompiled with JetBrains decompiler
// Type: 땄.떌
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땄
{
  internal class 떌 : 땷
  {
    private 떉 딟;

    public 떌([In] 딟.땇 obj0, [In] 떉 obj1, [In] string obj2)
      : base(obj0)
    {
      this.딟 = obj1;
      this.딟("DELETE", obj0.땋() + string.Format("/users/{0}/facebook", (object) obj2), 땷.딸.딟);
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.NoContent)
      {
        this.딶().딧((string) null);
        this.딟.딧(true);
      }
      this.딟.땄(true);
    }

    public override void 땄() => this.딟.땄(true);

    [SpecialName]
    public override 땘 딧() => (땘) this.딟;
  }
}
