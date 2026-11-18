// Decompiled with JetBrains decompiler
// Type: 땥.딫
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땥
{
  public abstract class 딫
  {
    protected 딫([In] 땱 obj0) => this.딟(obj0);

    [CompilerGenerated]
    [SpecialName]
    protected 땱 딟() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public 떅 땄() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] 떅 obj0) => this.딟 = obj0;

    public void 땄([In] 떅 obj0)
    {
      딫 딫 = this;
      딫.딟(딫.땄() | obj0);
    }

    public void 딧([In] 떅 obj0)
    {
      딫 딫 = this;
      딫.딟(딫.땄() & ~obj0);
    }

    public abstract void 딟([In] 떁[] obj0, [In] int obj1, [In] float obj2, [In] float obj3, [In] float obj4);

    public abstract void 땄([In] 떁[] obj0, [In] int obj1, [In] float obj2, [In] float obj3, [In] float obj4);

    public abstract void 딟([In] 떁 obj0, [In] float obj1, [In] float obj2, [In] float obj3, [In] float obj4);

    public abstract void 딟([In] 떁 obj0, [In] float obj1, [In] 떁 obj2, [In] float obj3, [In] float obj4, [In] float obj5);

    public abstract void 딟([In] 떁 obj0, [In] 떁 obj1, [In] float obj2, [In] float obj3, [In] float obj4);

    public abstract void 딟([In] ref 떓 obj0);
  }
}
