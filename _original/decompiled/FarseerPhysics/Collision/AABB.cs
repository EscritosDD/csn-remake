// Decompiled with JetBrains decompiler
// Type: FarseerPhysics.Collision.AABB
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using 땥;
using 땺;

namespace FarseerPhysics.Collision
{
  [Serializable]
  public struct AABB
  {
    private static 땺.딠 딟 = new 땺.딠();
    public 떁 LowerBound;
    public 떁 UpperBound;

    public AABB([In] 떁 obj0, [In] 떁 obj1)
      : this(ref obj0, ref obj1)
    {
    }

    public AABB([In] ref 떁 obj0, [In] ref 떁 obj1)
    {
      this.LowerBound = obj0;
      this.UpperBound = obj1;
    }

    public AABB([In] 떁 obj0, [In] float obj1, [In] float obj2)
    {
      this.LowerBound = obj0 - new 떁(obj1 / 2f, obj2 / 2f);
      this.UpperBound = obj0 + new 떁(obj1 / 2f, obj2 / 2f);
    }

    [SpecialName]
    public 떁 딟() => 0.5f * (this.LowerBound + this.UpperBound);

    [SpecialName]
    public 떁 땄() => 0.5f * (this.UpperBound - this.LowerBound);

    [SpecialName]
    public float 딧() => (float) (2.0 * ((double) (this.UpperBound.딟 - this.LowerBound.딟) + (double) (this.UpperBound.땄 - this.LowerBound.땄)));

    [SpecialName]
    public 땨 딢()
    {
      땨 땨 = new 땨();
      땨.Add(this.LowerBound);
      땨.Add(new 떁(this.LowerBound.딟, this.UpperBound.땄));
      땨.Add(this.UpperBound);
      땨.Add(new 떁(this.UpperBound.딟, this.LowerBound.땄));
      return 땨;
    }

    [SpecialName]
    public AABB 땃() => new AABB(this.딟(), this.UpperBound);

    [SpecialName]
    public AABB 딶() => new AABB(new 떁(this.LowerBound.딟, this.딟().땄), new 떁(this.딟().딟, this.UpperBound.땄));

    [SpecialName]
    public AABB 땓() => new AABB(this.LowerBound, this.딟());

    [SpecialName]
    public AABB 땺() => new AABB(new 떁(this.딟().딟, this.LowerBound.땄), new 떁(this.UpperBound.딟, this.딟().땄));

    public 떁[] 땥() => new 떁[4]
    {
      this.UpperBound,
      new 떁(this.UpperBound.딟, this.LowerBound.땄),
      this.LowerBound,
      new 떁(this.LowerBound.딟, this.UpperBound.땄)
    };

    public bool 딝()
    {
      떁 떁 = this.UpperBound - this.LowerBound;
      return (double) 떁.딟 >= 0.0 && (double) 떁.땄 >= 0.0 && 땥.땴.딧(this.LowerBound) && 땥.땴.딧(this.UpperBound);
    }

    public void 딟([In] ref AABB obj0)
    {
      this.LowerBound = 떁.땺(this.LowerBound, obj0.LowerBound);
      this.UpperBound = 떁.땓(this.UpperBound, obj0.UpperBound);
    }

    public void 딟([In] ref AABB obj0, [In] ref AABB obj1)
    {
      this.LowerBound = 떁.땺(obj0.LowerBound, obj1.LowerBound);
      this.UpperBound = 떁.땓(obj0.UpperBound, obj1.UpperBound);
    }

    public bool 땄([In] ref AABB obj0) => (double) this.LowerBound.딟 <= (double) obj0.LowerBound.딟 && (double) this.LowerBound.땄 <= (double) obj0.LowerBound.땄 && (double) obj0.UpperBound.딟 <= (double) this.UpperBound.딟 && (double) obj0.UpperBound.땄 <= (double) this.UpperBound.땄;

    public bool 딟([In] ref 떁 obj0) => (double) obj0.딟 > (double) this.LowerBound.딟 + 1.19209289550781E-07 && (double) obj0.딟 < (double) this.UpperBound.딟 - 1.19209289550781E-07 && (double) obj0.땄 > (double) this.LowerBound.땄 + 1.19209289550781E-07 && (double) obj0.땄 < (double) this.UpperBound.땄 - 1.19209289550781E-07;

    public static bool 딟([In] AABB obj0, [In] AABB obj1) => AABB.땄(ref obj0, ref obj1);

    public static bool 땄([In] ref AABB obj0, [In] ref AABB obj1)
    {
      떁 떁1 = obj1.LowerBound - obj0.UpperBound;
      떁 떁2 = obj0.LowerBound - obj1.UpperBound;
      return (double) 떁1.딟 <= 0.0 && (double) 떁1.땄 <= 0.0 && (double) 떁2.딟 <= 0.0 && (double) 떁2.땄 <= 0.0;
    }

    public static bool 딟([In] 땺.땏 obj0, [In] int obj1, [In] 땺.땏 obj2, [In] int obj3, [In] ref 땥.떓 obj4, [In] ref 땥.떓 obj5)
    {
      AABB.딟.딟.딟(obj0, obj1);
      AABB.딟.땄.딟(obj2, obj3);
      AABB.딟.딟 = obj4;
      AABB.딟.땄 = obj5;
      AABB.딟.딟 = true;
      땺.딿 딿;
      땺.땯.딟(out 딿, out 딡 _, AABB.딟);
      return (double) 딿.딟 < 1.19209289550781E-06;
    }

    public bool 딟(out 땺.딯 _param1, [In] ref 땺.딮 obj1)
    {
      _param1 = new 땺.딯();
      float num1 = float.MinValue;
      float val1 = float.MaxValue;
      떁 딟 = obj1.딟;
      떁 떁1 = obj1.땄 - obj1.딟;
      떁 떁2 = 땥.땴.딟(떁1);
      떁 떁3 = 떁.딟();
      for (int index = 0; index < 2; ++index)
      {
        float num2 = index != 0 ? 떁2.땄 : 떁2.딟;
        float num3 = index != 0 ? this.LowerBound.땄 : this.LowerBound.딟;
        float num4 = index != 0 ? this.UpperBound.땄 : this.UpperBound.딟;
        float num5 = index != 0 ? 딟.땄 : 딟.딟;
        if ((double) num2 < 1.19209289550781E-07)
        {
          if ((double) num5 < (double) num3 || (double) num4 < (double) num5)
            return false;
        }
        else
        {
          float num6 = 1f / (index != 0 ? 떁1.땄 : 떁1.딟);
          float num7 = (num3 - num5) * num6;
          float val2 = (num4 - num5) * num6;
          float num8 = -1f;
          if ((double) num7 > (double) val2)
          {
            땥.땴.Swap<float>(ref num7, ref val2);
            num8 = 1f;
          }
          if ((double) num7 > (double) num1)
          {
            if (index == 0)
              떁3.딟 = num8;
            else
              떁3.땄 = num8;
            num1 = num7;
          }
          val1 = Math.Min(val1, val2);
          if ((double) num1 > (double) val1)
            return false;
        }
      }
      if ((double) num1 < 0.0 || (double) obj1.딟 < (double) num1)
        return false;
      _param1.딟 = num1;
      _param1.딟 = 떁3;
      return true;
    }
  }
}
