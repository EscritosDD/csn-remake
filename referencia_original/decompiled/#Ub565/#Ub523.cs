// Decompiled with JetBrains decompiler
// Type: 땥.딣
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;

namespace 땥
{
  public static class 딣
  {
    public const float 딟 = 2.718282f;
    public const float 땄 = 0.4342945f;
    public const float 딧 = 1.442695f;
    public const float 딢 = 3.141593f;
    public const float 땃 = 1.570796f;
    public const float 딶 = 0.7853982f;
    public const float 땓 = 6.283185f;

    public static float 딟([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3, [In] float obj4) => (float) ((double) obj0 + ((double) obj1 - (double) obj0) * (double) obj3 + ((double) obj2 - (double) obj0) * (double) obj4);

    public static float 땄([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3, [In] float obj4)
    {
      double num1 = (double) obj4 * (double) obj4;
      double num2 = num1 * (double) obj4;
      return (float) (0.5 * (2.0 * (double) obj1 + ((double) obj2 - (double) obj0) * (double) obj4 + (2.0 * (double) obj0 - 5.0 * (double) obj1 + 4.0 * (double) obj2 - (double) obj3) * num1 + (3.0 * (double) obj1 - (double) obj0 - 3.0 * (double) obj2 + (double) obj3) * num2));
    }

    public static float 딟([In] float obj0, [In] float obj1, [In] float obj2)
    {
      obj0 = (double) obj0 <= (double) obj2 ? obj0 : obj2;
      obj0 = (double) obj0 >= (double) obj1 ? obj0 : obj1;
      return obj0;
    }

    public static float 딟([In] float obj0, [In] float obj1) => Math.Abs(obj0 - obj1);

    public static float 딧([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3, [In] float obj4)
    {
      double num1 = (double) obj0;
      double num2 = (double) obj2;
      double num3 = (double) obj1;
      double num4 = (double) obj3;
      double num5 = (double) obj4;
      double num6 = num5 * num5 * num5;
      double num7 = num5 * num5;
      return (double) obj4 != 0.0 ? ((double) obj4 != 1.0 ? (float) ((2.0 * num1 - 2.0 * num2 + num4 + num3) * num6 + (3.0 * num2 - 3.0 * num1 - 2.0 * num3 - num4) * num7 + num3 * num5 + num1) : obj2) : obj0;
    }

    public static float 땄([In] float obj0, [In] float obj1, [In] float obj2) => obj0 + (obj1 - obj0) * obj2;

    public static float 땄([In] float obj0, [In] float obj1) => Math.Max(obj0, obj1);

    public static float 딧([In] float obj0, [In] float obj1) => Math.Min(obj0, obj1);

    public static float 딧([In] float obj0, [In] float obj1, [In] float obj2)
    {
      float num = 딣.딟(obj2, 0.0f, 1f);
      return 딣.딧(obj0, 0.0f, obj1, 0.0f, num);
    }

    public static float 딟([In] float obj0) => obj0 * 57.29578f;

    public static float 땄([In] float obj0) => obj0 * ((float) Math.PI / 180f);

    public static float 딧([In] float obj0)
    {
      obj0 = (float) Math.IEEERemainder((double) obj0, 6.28318548202515);
      if ((double) obj0 <= -3.14159297943115)
      {
        obj0 += 6.283185f;
        return obj0;
      }
      if ((double) obj0 > 3.14159297943115)
        obj0 -= 6.283185f;
      return obj0;
    }
  }
}
