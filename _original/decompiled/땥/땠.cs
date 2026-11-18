// Decompiled with JetBrains decompiler
// Type: 땥.땠
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using FarseerPhysics.Collision;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 땥
{
  public static class 땠
  {
    public static float 딟([In] ref 떁 obj0, [In] ref 떁 obj1)
    {
      떁 떁;
      떁.땓(ref obj0, ref obj1, out 떁);
      return 떁.땃();
    }

    public static float 딟([In] ref 떁 obj0, [In] ref 떁 obj1, [In] ref 떁 obj2)
    {
      떁 떁1 = 떁.딝(obj2, obj1);
      float num1 = 떁.딶(떁.딝(obj0, obj1), 떁1);
      if ((double) num1 <= 0.0)
        return 땠.딟(ref obj0, ref obj1);
      float num2 = 떁.딶(떁1, 떁1);
      if ((double) num2 <= (double) num1)
        return 땠.딟(ref obj0, ref obj2);
      float num3 = num1 / num2;
      떁 떁2 = 떁.땄(obj1, 떁.땄(떁1, num3));
      return 땠.딟(ref obj0, ref 떁2);
    }

    public static bool 딟([In] 떁 obj0, [In] 떁 obj1, [In] 떁 obj2, [In] 떁 obj3, out 떁 _param4)
    {
      _param4 = 떁.딟();
      if (obj0 == obj2 || obj0 == obj3 || obj1 == obj2 || obj1 == obj3)
        return false;
      float 딟1 = obj0.딟;
      float 땄1 = obj0.땄;
      float 딟2 = obj1.딟;
      float 땄2 = obj1.땄;
      float 딟3 = obj2.딟;
      float 땄3 = obj2.땄;
      float 딟4 = obj3.딟;
      float 땄4 = obj3.땄;
      if ((double) Math.Max(딟1, 딟2) < (double) Math.Min(딟3, 딟4) || (double) Math.Max(딟3, 딟4) < (double) Math.Min(딟1, 딟2) || (double) Math.Max(땄1, 땄2) < (double) Math.Min(땄3, 땄4) || (double) Math.Max(땄3, 땄4) < (double) Math.Min(땄1, 땄2))
        return false;
      float num1 = (float) (((double) 딟4 - (double) 딟3) * ((double) 땄1 - (double) 땄3) - ((double) 땄4 - (double) 땄3) * ((double) 딟1 - (double) 딟3));
      float num2 = (float) (((double) 딟2 - (double) 딟1) * ((double) 땄1 - (double) 땄3) - ((double) 땄2 - (double) 땄1) * ((double) 딟1 - (double) 딟3));
      float num3 = (float) (((double) 땄4 - (double) 땄3) * ((double) 딟2 - (double) 딟1) - ((double) 딟4 - (double) 딟3) * ((double) 땄2 - (double) 땄1));
      if ((double) Math.Abs(num3) < 1.19209289550781E-07)
        return false;
      float num4 = num1 / num3;
      float num5 = num2 / num3;
      if (0.0 >= (double) num4 || (double) num4 >= 1.0 || 0.0 >= (double) num5 || (double) num5 >= 1.0)
        return false;
      _param4.딟 = 딟1 + num4 * (딟2 - 딟1);
      _param4.땄 = 땄1 + num4 * (땄2 - 땄1);
      return true;
    }

    public static 떁 딟([In] 떁 obj0, [In] 떁 obj1, [In] 떁 obj2, [In] 떁 obj3)
    {
      떁 떁 = 떁.딟();
      float num1 = obj1.땄 - obj0.땄;
      float num2 = obj0.딟 - obj1.딟;
      float num3 = (float) ((double) num1 * (double) obj0.딟 + (double) num2 * (double) obj0.땄);
      float num4 = obj3.땄 - obj2.땄;
      float num5 = obj2.딟 - obj3.딟;
      float num6 = (float) ((double) num4 * (double) obj2.딟 + (double) num5 * (double) obj2.땄);
      float num7 = (float) ((double) num1 * (double) num5 - (double) num4 * (double) num2);
      if (!땴.딟(num7, 0.0f))
      {
        떁.딟 = (float) ((double) num5 * (double) num3 - (double) num2 * (double) num6) / num7;
        떁.땄 = (float) ((double) num1 * (double) num6 - (double) num4 * (double) num3) / num7;
      }
      return 떁;
    }

    public static bool 딟(
      [In] ref 떁 obj0,
      [In] ref 떁 obj1,
      [In] ref 떁 obj2,
      [In] ref 떁 obj3,
      [In] bool obj4,
      [In] bool obj5,
      out 떁 _param6)
    {
      _param6 = new 떁();
      float num1 = obj3.땄 - obj2.땄;
      float num2 = obj1.딟 - obj0.딟;
      float num3 = obj3.딟 - obj2.딟;
      float num4 = obj1.땄 - obj0.땄;
      float num5 = (float) ((double) num1 * (double) num2 - (double) num3 * (double) num4);
      if ((double) num5 < -1.19209289550781E-07 || (double) num5 > 1.19209289550781E-07)
      {
        float num6 = obj0.땄 - obj2.땄;
        float num7 = obj0.딟 - obj2.딟;
        float num8 = 1f / num5;
        float num9 = (float) ((double) num3 * (double) num6 - (double) num1 * (double) num7) * num8;
        if (!obj4 || (double) num9 >= 0.0 && (double) num9 <= 1.0)
        {
          float num10 = (float) ((double) num2 * (double) num6 - (double) num4 * (double) num7) * num8;
          if ((!obj5 || (double) num10 >= 0.0 && (double) num10 <= 1.0) && ((double) num9 != 0.0 || (double) num10 != 0.0))
          {
            _param6.딟 = obj0.딟 + num9 * num2;
            _param6.땄 = obj0.땄 + num9 * num4;
            return true;
          }
        }
      }
      return false;
    }

    public static bool 딟([In] 떁 obj0, [In] 떁 obj1, [In] 떁 obj2, [In] 떁 obj3, [In] bool obj4, [In] bool obj5, out 떁 _param6) => 땠.딟(ref obj0, ref obj1, ref obj2, ref obj3, obj4, obj5, out _param6);

    public static bool 딟([In] ref 떁 obj0, [In] ref 떁 obj1, [In] ref 떁 obj2, [In] ref 떁 obj3, out 떁 _param4) => 땠.딟(ref obj0, ref obj1, ref obj2, ref obj3, true, true, out _param4);

    public static bool 땄([In] 떁 obj0, [In] 떁 obj1, [In] 떁 obj2, [In] 떁 obj3, out 떁 _param4) => 땠.딟(ref obj0, ref obj1, ref obj2, ref obj3, true, true, out _param4);

    public static void 딟([In] ref 떁 obj0, [In] ref 떁 obj1, [In] 땨 obj2, [In] ref List<떁> obj3)
    {
      for (int index = 0; index < obj2.Count; ++index)
      {
        떁 떁;
        if (땠.딟(obj2[index], obj2[obj2.딟(index)], obj0, obj1, true, true, out 떁))
          obj3.Add(떁);
      }
    }

    public static void 딟([In] ref 떁 obj0, [In] ref 떁 obj1, [In] AABB obj2, [In] ref List<떁> obj3) => 땠.딟(ref obj0, ref obj1, obj2.딢(), ref obj3);
  }
}
