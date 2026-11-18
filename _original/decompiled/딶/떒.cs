// Decompiled with JetBrains decompiler
// Type: 딶.떒
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 떒 : 땏
  {
    public float 딟;
    protected float 땄;

    public 떒()
      : base(-1, 땩.딟)
    {
      base.딟 = false;
    }

    public 떒([In] int obj0, [In] float obj1)
      : base(obj0, 땩.딟)
    {
      base.딟 = false;
      this.딟 = obj1;
    }

    public 떒([In] int obj0)
      : this(obj0, 0.0f)
    {
    }

    public 떒([In] 땩 obj0, [In] float obj1)
      : base(-1, obj0)
    {
      base.딟 = false;
      this.딟 = obj1;
    }

    public 떒([In] float obj0)
      : this(-1, obj0)
    {
    }

    protected override void 딟()
    {
      this.딧(base.딟);
      this.땄(true);
      this.땄 = Time.time + this.딟;
    }

    protected override void 땄()
    {
      if ((double) Time.time <= (double) this.땄)
        return;
      this.딧(true);
      this.땄(false);
    }

    protected override void 딧()
    {
      if ((double) Time.time <= (double) this.땄)
        return;
      this.땄(false);
    }

    public virtual bool 딟([In] int obj0, [In] 땮 obj1) => base.딟 == obj0;

    public override string ToString() => string.Format("[CinematicEvent] Cinematic Object: {0}", (object) this.딟);
  }
}
