// Decompiled with JetBrains decompiler
// Type: 땄.땸
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땄
{
  internal class 땸 : 딟.땨
  {
    private 딬 딟;

    public 땸([In] 딟.땇 obj0, [In] 딬 obj1)
      : base(obj0, obj1.딟(), obj1.땄())
    {
      this.딟 = obj1;
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.OK)
        this.딟.딧(true);
      else if (base.땄())
      {
        ((딧.땋) new 땬(this.딶(), this.딟)).딶();
        return;
      }
      this.딟.땄(true);
    }

    public override void 땄() => this.딟.땄(true);

    [SpecialName]
    public override 땘 딧() => (땘) this.딟;
  }
}
