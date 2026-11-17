// Decompiled with JetBrains decompiler
// Type: 땥.땋
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 땥
{
  internal class 땋
  {
    public 땲 딟;
    public float 딟;
    public 땲 땄;
    public HashSet<땽> 딟;
    public 땽 딟;
    public 땽 땄;
    public float 땄;

    public 땋([In] 땽 obj0, [In] 땽 obj1)
    {
      this.딟 = obj0;
      this.땄 = obj1;
      this.땄 = (double) obj1.딟 - (double) obj0.딟 == 0.0 ? 0.0f : (float) (((double) obj1.땄 - (double) obj0.땄) / ((double) obj1.딟 - (double) obj0.딟));
      this.딟 = obj0.땄 - obj0.딟 * this.땄;
      this.딟 = (땲) null;
      this.땄 = (땲) null;
      this.딟 = new HashSet<땽>();
      this.딟.Add(obj0);
      this.딟.Add(obj1);
    }

    public bool 딟([In] 땽 obj0) => (double) this.딟.딟(this.땄, obj0) < 0.0;

    public bool 땄([In] 땽 obj0) => (double) this.딟.딟(this.땄, obj0) > 0.0;

    public void 딧([In] 땽 obj0)
    {
      foreach (땽 땽 in this.딟)
      {
        if (!땽.딧(obj0))
          return;
      }
      this.딟.Add(obj0);
    }
  }
}
