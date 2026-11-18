// Decompiled with JetBrains decompiler
// Type: 땥.땴
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;

namespace 땥
{
  public static class 땴
  {
    public static float 딟([In] 떁 obj0, [In] 떁 obj1) => (float) ((double) obj0.딟 * (double) obj1.땄 - (double) obj0.땄 * (double) obj1.딟);

    public static 땟 딟([In] 땟 obj0, [In] 땟 obj1) => new 땟((float) ((double) obj0.땄 * (double) obj1.딧 - (double) obj0.딧 * (double) obj1.땄), (float) ((double) obj0.딧 * (double) obj1.딟 - (double) obj0.딟 * (double) obj1.딧), (float) ((double) obj0.딟 * (double) obj1.땄 - (double) obj0.땄 * (double) obj1.딟));

    public static 떁 딟([In] 떁 obj0, [In] float obj1) => new 떁(obj1 * obj0.땄, -obj1 * obj0.딟);

    public static 떁 딟([In] float obj0, [In] 떁 obj1) => new 떁(-obj0 * obj1.땄, obj0 * obj1.딟);

    public static 떁 딟([In] 떁 obj0) => new 떁(Math.Abs(obj0.딟), Math.Abs(obj0.땄));

    public static 떁 딟([In] ref 땳 obj0, [In] 떁 obj1) => 땴.딟(ref obj0, ref obj1);

    public static 떁 딟([In] ref 땳 obj0, [In] ref 떁 obj1) => new 떁((float) ((double) obj0.딟.딟 * (double) obj1.딟 + (double) obj0.땄.딟 * (double) obj1.땄), (float) ((double) obj0.딟.땄 * (double) obj1.딟 + (double) obj0.땄.땄 * (double) obj1.땄));

    public static 떁 딟([In] ref 떓 obj0, [In] 떁 obj1) => 땴.딟(ref obj0, ref obj1);

    public static 떁 딟([In] ref 떓 obj0, [In] ref 떁 obj1) => new 떁((float) ((double) obj0.딟.땄 * (double) obj1.딟 - (double) obj0.딟.딟 * (double) obj1.땄) + obj0.딟.딟, (float) ((double) obj0.딟.딟 * (double) obj1.딟 + (double) obj0.딟.땄 * (double) obj1.땄) + obj0.딟.땄);

    public static 떁 땄([In] ref 땳 obj0, [In] 떁 obj1) => 땴.땄(ref obj0, ref obj1);

    public static 떁 땄([In] ref 땳 obj0, [In] ref 떁 obj1) => new 떁((float) ((double) obj1.딟 * (double) obj0.딟.딟 + (double) obj1.땄 * (double) obj0.딟.땄), (float) ((double) obj1.딟 * (double) obj0.땄.딟 + (double) obj1.땄 * (double) obj0.땄.땄));

    public static 떁 땄([In] ref 떓 obj0, [In] 떁 obj1) => 땴.땄(ref obj0, ref obj1);

    public static 떁 땄([In] ref 떓 obj0, [In] ref 떁 obj1)
    {
      float num1 = obj1.딟 - obj0.딟.딟;
      float num2 = obj1.땄 - obj0.딟.땄;
      return new 떁((float) ((double) obj0.딟.땄 * (double) num1 + (double) obj0.딟.딟 * (double) num2), (float) (-(double) obj0.딟.딟 * (double) num1 + (double) obj0.딟.땄 * (double) num2));
    }

    public static void 딟([In] ref 땳 obj0, [In] ref 땳 obj1, out 땳 _param2)
    {
      _param2 = new 땳();
      _param2.딟.딟 = (float) ((double) obj0.딟.딟 * (double) obj1.딟.딟 + (double) obj0.딟.땄 * (double) obj1.딟.땄);
      _param2.딟.땄 = (float) ((double) obj0.땄.딟 * (double) obj1.딟.딟 + (double) obj0.땄.땄 * (double) obj1.딟.땄);
      _param2.땄.딟 = (float) ((double) obj0.딟.딟 * (double) obj1.땄.딟 + (double) obj0.딟.땄 * (double) obj1.땄.땄);
      _param2.땄.땄 = (float) ((double) obj0.땄.딟 * (double) obj1.땄.딟 + (double) obj0.땄.땄 * (double) obj1.땄.땄);
    }

    public static 땟 딟([In] 땻 obj0, [In] 땟 obj1) => obj1.딟 * obj0.딟 + obj1.땄 * obj0.땄 + obj1.딧 * obj0.딧;

    public static 떓 딟([In] 떓 obj0, [In] 떓 obj1) => new 떓()
    {
      딟 = 땴.딟(obj0.딟, obj1.딟),
      딟 = 땴.딟(obj0.딟, obj1.딟) + obj0.딟
    };

    public static void 딟([In] ref 떓 obj0, [In] ref 떓 obj1, out 떓 _param2)
    {
      _param2 = new 떓();
      _param2.딟 = 땴.땄(obj0.딟, obj1.딟);
      _param2.딟 = 땴.땄(obj0.딟, obj1.딟 - obj0.딟);
    }

    public static void 딟<딟>([In] ref 딟 obj0, [In] ref 딟 obj1)
    {
      딟 딟 = obj0;
      obj0 = obj1;
      obj1 = 딟;
    }

    public static 떁 딟([In] 땻 obj0, [In] 떁 obj1) => new 떁((float) ((double) obj0.딟.딟 * (double) obj1.딟 + (double) obj0.땄.딟 * (double) obj1.땄), (float) ((double) obj0.딟.땄 * (double) obj1.딟 + (double) obj0.땄.땄 * (double) obj1.땄));

    public static 딥 딟([In] 딥 obj0, [In] 딥 obj1)
    {
      딥 딥;
      딥.딟 = (float) ((double) obj0.딟 * (double) obj1.땄 + (double) obj0.땄 * (double) obj1.딟);
      딥.땄 = (float) ((double) obj0.땄 * (double) obj1.땄 - (double) obj0.딟 * (double) obj1.딟);
      return 딥;
    }

    public static 떁 딟([In] 떓 obj0, [In] 떁 obj1)
    {
      float num1 = obj1.딟 - obj0.딟.딟;
      float num2 = obj1.땄 - obj0.딟.땄;
      return new 떁((float) ((double) obj0.딟.땄 * (double) num1 + (double) obj0.딟.딟 * (double) num2), (float) (-(double) obj0.딟.딟 * (double) num1 + (double) obj0.딟.땄 * (double) num2));
    }

    public static 딥 땄([In] 딥 obj0, [In] 딥 obj1)
    {
      딥 딥;
      딥.딟 = (float) ((double) obj0.땄 * (double) obj1.딟 - (double) obj0.딟 * (double) obj1.땄);
      딥.땄 = (float) ((double) obj0.땄 * (double) obj1.땄 + (double) obj0.딟 * (double) obj1.딟);
      return 딥;
    }

    public static 떓 땄([In] 떓 obj0, [In] 떓 obj1) => new 떓()
    {
      딟 = 땴.땄(obj0.딟, obj1.딟),
      딟 = 땴.땄(obj0.딟, obj1.딟 - obj0.딟)
    };

    public static 떁 딟([In] 딥 obj0, [In] 떁 obj1) => new 떁((float) ((double) obj0.땄 * (double) obj1.딟 - (double) obj0.딟 * (double) obj1.땄), (float) ((double) obj0.딟 * (double) obj1.딟 + (double) obj0.땄 * (double) obj1.땄));

    public static 떁 땄([In] 딥 obj0, [In] 떁 obj1) => new 떁((float) ((double) obj0.땄 * (double) obj1.딟 + (double) obj0.딟 * (double) obj1.땄), (float) (-(double) obj0.딟 * (double) obj1.딟 + (double) obj0.땄 * (double) obj1.땄));

    public static 떁 땄([In] 떁 obj0) => new 떁(-obj0.땄, obj0.딟);

    public static bool 딟([In] float obj0) => !float.IsNaN(obj0) && !float.IsInfinity(obj0);

    public static bool 딧([In] this 떁 obj0) => 땴.딟(obj0.딟) && 땴.딟(obj0.땄);

    public static float 땄([In] float obj0)
    {
      땴.딗 딗 = new 땴.딗();
      딗.딟 = obj0;
      float num = 0.5f * obj0;
      딗.딟 = 1597463007 - (딗.딟 >> 1);
      obj0 = 딗.딟;
      obj0 *= (float) (1.5 - (double) num * (double) obj0 * (double) obj0);
      return obj0;
    }

    public static int 딟([In] int obj0, [In] int obj1, [In] int obj2) => Math.Max(obj1, Math.Min(obj0, obj2));

    public static float 딟([In] float obj0, [In] float obj1, [In] float obj2) => Math.Max(obj1, Math.Min(obj0, obj2));

    public static 떁 딟([In] 떁 obj0, [In] 떁 obj1, [In] 떁 obj2) => 떁.땓(obj1, 떁.땺(obj0, obj2));

    public static void 딟([In] ref 떁 obj0, [In] ref 떁 obj1, out float _param2) => _param2 = (float) ((double) obj0.딟 * (double) obj1.땄 - (double) obj0.땄 * (double) obj1.딟);

    public static double 딟([In] ref 떁 obj0, [In] ref 떁 obj1)
    {
      double num1 = Math.Atan2((double) obj0.땄, (double) obj0.딟);
      double num2 = Math.Atan2((double) obj1.땄, (double) obj1.딟) - num1;
      while (num2 > Math.PI)
        num2 -= 2.0 * Math.PI;
      while (num2 < -1.0 * Math.PI)
        num2 += 2.0 * Math.PI;
      return num2;
    }

    public static float 땄([In] 땟 obj0, [In] 땟 obj1) => (float) ((double) obj0.딟 * (double) obj1.딟 + (double) obj0.땄 * (double) obj1.땄 + (double) obj0.딧 * (double) obj1.딧);

    public static double 땄([In] 떁 obj0, [In] 떁 obj1) => 땴.딟(ref obj0, ref obj1);

    public static float 땄([In] 떁 obj0, [In] 떁 obj1, [In] 떁 obj2) => 땴.딟(ref obj0, ref obj1, ref obj2);

    public static float 딟([In] ref 떁 obj0, [In] ref 떁 obj1, [In] ref 떁 obj2) => (float) ((double) obj0.딟 * ((double) obj1.땄 - (double) obj2.땄) + (double) obj1.딟 * ((double) obj2.땄 - (double) obj0.땄) + (double) obj2.딟 * ((double) obj0.땄 - (double) obj1.땄));

    public static bool 땄([In] ref 떁 obj0, [In] ref 떁 obj1, [In] ref 떁 obj2) => 땴.딟(ref obj0, ref obj1, ref obj2, 0.0f);

    public static bool 딟([In] ref 떁 obj0, [In] ref 떁 obj1, [In] ref 떁 obj2, [In] float obj3) => 땴.딧(땴.딟(ref obj0, ref obj1, ref obj2), -obj3, obj3);

    public static void 딟([In] float obj0, [In] ref 떁 obj1, out 떁 _param2) => _param2 = new 떁(-obj0 * obj1.땄, obj0 * obj1.딟);

    public static bool 딟([In] float obj0, [In] float obj1) => (double) Math.Abs(obj0 - obj1) <= 1.19209289550781E-07;

    public static bool 땄([In] float obj0, [In] float obj1, [In] float obj2) => 땴.딧(obj0, obj1 - obj2, obj1 + obj2);

    public static bool 딧([In] float obj0, [In] float obj1, [In] float obj2) => (double) obj0 >= (double) obj1 && (double) obj0 <= (double) obj2;

    public static 떁 딟([In] ref 딥 obj0, [In] 떁 obj1) => 땴.딟(obj0, obj1);

    public static 떁 땄([In] ref 딥 obj0, [In] 떁 obj1) => 땴.땄(obj0, obj1);

    [StructLayout(LayoutKind.Explicit)]
    private struct 딗
    {
      [FieldOffset(0)]
      public float 딟;
      [FieldOffset(0)]
      public int 딟;
    }
  }
}
