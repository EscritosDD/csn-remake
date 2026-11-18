// Decompiled with JetBrains decompiler
// Type: 딝.땺
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using 땥;

namespace 딝
{
  public abstract class 땺
  {
    public float 딟 = float.MaxValue;
    internal 딝.땓 딟 = new 딝.땓();
    internal 딝.땓 땄 = new 딝.땓();
    public bool 딟 = true;
    internal bool 땄;
    protected int 딟;
    private Action<딝.땺, float> 딟;

    protected 땺()
    {
    }

    protected 땺([In] 딺 obj0, [In] 딺 obj1)
    {
      this.딟(obj0);
      this.땄(obj1);
      this.딟(false);
    }

    protected 땺([In] 딺 obj0)
    {
      this.딟(obj0);
      this.딟(false);
    }

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 딟([In] Action<딝.땺, float> obj0) => this.딟 += obj0;

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 땄([In] Action<딝.땺, float> obj0) => this.딟 -= obj0;

    [CompilerGenerated]
    [SpecialName]
    public 딝.딢 딧() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    protected void 딟([In] 딝.딢 obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public 딺 딢() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] 딺 obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public 딺 땃() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public void 땄([In] 딺 obj0) => this.땄 = obj0;

    [SpecialName]
    public abstract 떁 딟();

    [SpecialName]
    public abstract 떁 땄();

    [SpecialName]
    public abstract void 딟([In] 떁 obj0);

    [CompilerGenerated]
    [SpecialName]
    public object 딶() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] object obj0) => this.딟 = obj0;

    [SpecialName]
    public bool 땓() => this.딢().떎() && this.땃().떎();

    [CompilerGenerated]
    [SpecialName]
    public bool 땺() => this.딧;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] bool obj0) => this.딧 = obj0;

    public abstract 떁 딟([In] float obj0);

    public abstract float 땄([In] float obj0);

    protected void 땥()
    {
      this.딢().딧(true);
      if (this.땃() == null)
        return;
      this.땃().딧(true);
    }

    public bool 딝() => this.딧() == 딝.딢.땭 || this.딧() == 딝.딢.딦 || this.딧() == 딝.딢.땽 || this.딧() == 딝.딢.땤 || this.딧() == 딝.딢.떂 || this.딧() == 딝.딢.땋 || this.딧() == 딝.딢.땲;

    internal abstract void 딟([In] ref 딤 obj0);

    internal void 딧([In] float obj0)
    {
      if (!this.딟)
        return;
      float num = this.딟(obj0).땃();
      if ((double) Math.Abs(num) <= (double) this.딟)
        return;
      this.딟 = false;
      if (this.딟 == null)
        return;
      this.딟(this, num);
    }

    internal abstract void 땄([In] ref 딤 obj0);

    internal abstract bool 딧([In] ref 딤 obj0);
  }
}
