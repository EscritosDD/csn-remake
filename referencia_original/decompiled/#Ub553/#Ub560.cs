// Decompiled with JetBrains decompiler
// Type: 땓.땠
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땓
{
  public struct 땠
  {
    private Vector3 딟;

    public void 딟([In] Vector3 obj0)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(true);
      this.딟 = obj0;
    }

    public void 딟([In] Vector3 obj0, [In] Collider obj1)
    {
      if (!this.딟())
        return;
      GuiComponent3D.딟(obj0, obj1);
    }

    public void 딟([In] Vector3 obj0, [In] bool obj1)
    {
      float num = !obj1 ? (float) (obj0.y - this.딟.y) : (float) (obj0.x - this.딟.x);
      if ((double) num * (double) num <= 100.0)
        return;
      // ISSUE: reference to a compiler-generated method
      this.딟(false);
    }

    [CompilerGenerated]
    [SpecialName]
    public bool 딟() => this.딟;
  }
}
