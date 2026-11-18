// Decompiled with JetBrains decompiler
// Type: 땺.땏
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using FarseerPhysics.Collision;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using 땥;

namespace 땺
{
  public abstract class 땏
  {
    private static int 딟;
    public 딫 딟;
    public int 땄;
    internal float 딟;
    internal float 땄;

    protected 땏([In] float obj0)
    {
      this.딟 = obj0;
      this.딟(땙.딟);
      this.땄 = 땏.딟++;
    }

    [CompilerGenerated]
    [SpecialName]
    public 땙 딢() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    internal void 딟([In] 땙 obj0) => this.딟 = obj0;

    [SpecialName]
    public abstract int 딟();

    [SpecialName]
    public float 땃() => this.딟;

    [SpecialName]
    public void 딟([In] float obj0)
    {
      this.딟 = obj0;
      this.딧();
    }

    [SpecialName]
    public float 딶() => this.땄;

    [SpecialName]
    public void 땄([In] float obj0)
    {
      this.땄 = obj0;
      this.딧();
    }

    public abstract 땏 땄();

    public abstract bool 딟([In] ref 땥.떓 obj0, [In] ref 떁 obj1);

    public abstract bool 딟(out 딯 _param1, [In] ref 딮 obj1, [In] ref 땥.떓 obj2, [In] int obj3);

    public abstract void 딟(out AABB _param1, [In] ref 땥.떓 obj1, [In] int obj2);

    protected abstract void 딧();

    public bool 딟([In] 땏 obj0)
    {
      switch (obj0)
      {
        case 떅 _ when this is 떅:
          return ((떅) this).딟((떅) obj0);
        case 땶 _ when this is 땶:
          return ((땶) this).딟((땶) obj0);
        case 땖 _ when this is 땖:
          return ((땖) this).딟((땖) obj0);
        default:
          return false;
      }
    }

    public abstract float 딟([In] 떁 obj0, [In] float obj1, [In] 땥.떓 obj2, out 떁 _param4);
  }
}
