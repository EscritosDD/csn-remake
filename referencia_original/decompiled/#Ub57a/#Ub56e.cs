// Decompiled with JetBrains decompiler
// Type: 땺.땮
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땺
{
  public class 땮
  {
    public double 딟;
    public double 땄;

    public 땮([In] double obj0, [In] double obj1)
    {
      this.딟 = obj0;
      this.땄 = obj1;
    }

    [CompilerGenerated]
    [SpecialName]
    public List<딭> 딟() => this.딟;

    [SpecialName]
    public float 땄() => (float) this.딟;

    [SpecialName]
    public void 딟([In] float obj0) => this.딟 = (double) obj0;

    [SpecialName]
    public float 딧() => (float) this.땄;

    [SpecialName]
    public void 땄([In] float obj0) => this.땄 = (double) obj0;

    [SpecialName]
    public bool 딢() => this.딟() != null;

    public override string ToString() => "[" + (object) this.딟 + "," + (object) this.땄 + "]";

    public void 딟([In] 딭 obj0)
    {
      if (this.딟() == null)
      {
        // ISSUE: reference to a compiler-generated method
        this.딟(new List<딭>());
      }
      this.딟().Add(obj0);
    }
  }
}
