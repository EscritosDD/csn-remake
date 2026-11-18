// Decompiled with JetBrains decompiler
// Type: 땥.딥
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;

namespace 땥
{
  public struct 딥
  {
    public float 딟;
    public float 땄;

    public 딥([In] float obj0)
    {
      this.딟 = (float) Math.Sin((double) obj0);
      this.땄 = (float) Math.Cos((double) obj0);
    }

    public void 딟([In] float obj0)
    {
      this.딟 = (float) Math.Sin((double) obj0);
      this.땄 = (float) Math.Cos((double) obj0);
    }

    public void 딟()
    {
      this.딟 = 0.0f;
      this.땄 = 1f;
    }

    public float 땄() => (float) Math.Atan2((double) this.딟, (double) this.땄);

    public 떁 딧() => new 떁(this.땄, this.딟);

    public 떁 딢() => new 떁(-this.딟, this.땄);
  }
}
