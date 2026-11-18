// Decompiled with JetBrains decompiler
// Type: 땥.딷
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땥
{
  public struct 딷 : IEquatable<딷>
  {
    public float 딟;
    public float 땄;
    public float 딧;
    public float 딢;
    public float 땃;
    public float 딶;
    public float 땓;
    public float 땺;
    public float 땥;
    public float 딝;
    public float 떎;
    public float 떂;
    public float 땭;
    public float 딦;
    public float 땤;
    public float 땽;
    private static 딷 딟 = new 딷(1f, 0.0f, 0.0f, 0.0f, 0.0f, 1f, 0.0f, 0.0f, 0.0f, 0.0f, 1f, 0.0f, 0.0f, 0.0f, 0.0f, 1f);

    public 딷(
      [In] float obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4,
      [In] float obj5,
      [In] float obj6,
      [In] float obj7,
      [In] float obj8,
      [In] float obj9,
      [In] float obj10,
      [In] float obj11,
      [In] float obj12,
      [In] float obj13,
      [In] float obj14,
      [In] float obj15)
    {
      this.딟 = obj0;
      this.땄 = obj1;
      this.딧 = obj2;
      this.딢 = obj3;
      this.땃 = obj4;
      this.딶 = obj5;
      this.땓 = obj6;
      this.땺 = obj7;
      this.땥 = obj8;
      this.딝 = obj9;
      this.떎 = obj10;
      this.떂 = obj11;
      this.땭 = obj12;
      this.딦 = obj13;
      this.땤 = obj14;
      this.땽 = obj15;
    }

    [SpecialName]
    public static 딷 딟() => 딷.딟;

    [SpecialName]
    public 땟 땄() => new 땟(this.땥, this.딝, this.떎);

    [SpecialName]
    public void 딟([In] 땟 obj0)
    {
      this.땥 = obj0.딟;
      this.딝 = obj0.땄;
      this.떎 = obj0.딧;
    }

    [SpecialName]
    public 땟 딧() => new 땟(-this.땃, -this.딶, -this.땓);

    [SpecialName]
    public void 땄([In] 땟 obj0)
    {
      this.땃 = -obj0.딟;
      this.딶 = -obj0.땄;
      this.땓 = -obj0.딧;
    }

    [SpecialName]
    public 땟 딢() => new 땟(-this.땥, -this.딝, -this.떎);

    [SpecialName]
    public void 딧([In] 땟 obj0)
    {
      this.땥 = -obj0.딟;
      this.딝 = -obj0.땄;
      this.떎 = -obj0.딧;
    }

    [SpecialName]
    public 땟 땃() => new 땟(-this.딟, -this.땄, -this.딧);

    [SpecialName]
    public void 딢([In] 땟 obj0)
    {
      this.딟 = -obj0.딟;
      this.땄 = -obj0.땄;
      this.딧 = -obj0.딧;
    }

    [SpecialName]
    public 땟 딶() => new 땟(this.딟, this.땄, this.딧);

    [SpecialName]
    public void 땃([In] 땟 obj0)
    {
      this.딟 = obj0.딟;
      this.땄 = obj0.땄;
      this.딧 = obj0.딧;
    }

    [SpecialName]
    public 땟 땓() => new 땟(this.땭, this.딦, this.땤);

    [SpecialName]
    public void 딶([In] 땟 obj0)
    {
      this.땭 = obj0.딟;
      this.딦 = obj0.땄;
      this.땤 = obj0.딧;
    }

    [SpecialName]
    public 땟 땺() => new 땟(this.땃, this.딶, this.땓);

    [SpecialName]
    public void 땓([In] 땟 obj0)
    {
      this.땃 = obj0.딟;
      this.딶 = obj0.땄;
      this.땓 = obj0.딧;
    }

    public static 딷 딟([In] 땟 obj0, [In] 땟 obj1, [In] 땟 obj2)
    {
      딷 딷;
      딷.딟(ref obj0, ref obj1, ref obj2, out 딷);
      return 딷;
    }

    public static void 딟([In] ref 땟 obj0, [In] ref 땟 obj1, [In] ref 땟 obj2, out 딷 _param3)
    {
      땟 땟1;
      땟.땄(ref obj1, out 땟1);
      땟 땟2;
      땟.땄(ref obj1, ref obj2, out 땟2);
      땟 땟3;
      땟.땄(ref 땟2, ref obj1, out 땟3);
      땟2.딦();
      땟3.딦();
      _param3 = new 딷();
      _param3.땃(땟2);
      _param3.땓(땟3);
      _param3.딧(땟1);
      _param3.딶(obj0);
      _param3.땽 = 1f;
    }

    public static 딷 딟([In] 딷 obj0, [In] 딷 obj1)
    {
      obj0.딟 += obj1.딟;
      obj0.땄 += obj1.땄;
      obj0.딧 += obj1.딧;
      obj0.딢 += obj1.딢;
      obj0.땃 += obj1.땃;
      obj0.딶 += obj1.딶;
      obj0.땓 += obj1.땓;
      obj0.땺 += obj1.땺;
      obj0.땥 += obj1.땥;
      obj0.딝 += obj1.딝;
      obj0.떎 += obj1.떎;
      obj0.떂 += obj1.떂;
      obj0.땭 += obj1.땭;
      obj0.딦 += obj1.딦;
      obj0.땤 += obj1.땤;
      obj0.땽 += obj1.땽;
      return obj0;
    }

    public static void 딟([In] ref 딷 obj0, [In] ref 딷 obj1, out 딷 _param2)
    {
      _param2.딟 = obj0.딟 + obj1.딟;
      _param2.땄 = obj0.땄 + obj1.땄;
      _param2.딧 = obj0.딧 + obj1.딧;
      _param2.딢 = obj0.딢 + obj1.딢;
      _param2.땃 = obj0.땃 + obj1.땃;
      _param2.딶 = obj0.딶 + obj1.딶;
      _param2.땓 = obj0.땓 + obj1.땓;
      _param2.땺 = obj0.땺 + obj1.땺;
      _param2.땥 = obj0.땥 + obj1.땥;
      _param2.딝 = obj0.딝 + obj1.딝;
      _param2.떎 = obj0.떎 + obj1.떎;
      _param2.떂 = obj0.떂 + obj1.떂;
      _param2.땭 = obj0.땭 + obj1.땭;
      _param2.딦 = obj0.딦 + obj1.딦;
      _param2.땤 = obj0.땤 + obj1.땤;
      _param2.땽 = obj0.땽 + obj1.땽;
    }

    public static 딷 딟([In] 땟 obj0, [In] 땟 obj1, [In] 땟 obj2, [In] 땟? obj3)
    {
      딷 딷;
      딷.딟(ref obj0, ref obj1, ref obj2, obj3, out 딷);
      return 딷;
    }

    public static void 딟([In] ref 땟 obj0, [In] ref 땟 obj1, [In] ref 땟 obj2, [In] 땟? obj3, out 딷 _param4)
    {
      땟 땟1 = obj0 - obj1;
      땟 땟2;
      땟.땄(ref 땟1, out 땟2);
      땟 땟3;
      땟.땄(ref obj2, out 땟3);
      땟 땟4;
      땟.땄(ref 땟2, ref 땟3, out 땟4);
      땟.땄(ref 땟2, ref 땟4, out 땟3);
      _param4 = 딷.딟();
      _param4.딟(땟2);
      _param4.땃(땟4);
      _param4.땓(땟3);
      _param4.딶(땟1);
    }

    public static 딷 딟([In] 땟 obj0, [In] 땟 obj1, [In] 땟 obj2, [In] 땟? obj3, [In] 땟? obj4) => throw new NotImplementedException();

    public static void 딟([In] ref 땟 obj0, [In] ref 땟 obj1, [In] ref 땟 obj2, [In] 땟? obj3, [In] 땟? obj4, out 딷 _param5) => throw new NotImplementedException();

    public static 딷 딟([In] 땟 obj0, [In] float obj1) => throw new NotImplementedException();

    public static void 딟([In] ref 땟 obj0, [In] float obj1, out 딷 _param2) => throw new NotImplementedException();

    public static 딷 땄([In] 땟 obj0, [In] 땟 obj1, [In] 땟 obj2)
    {
      딷 딷;
      딷.땄(ref obj0, ref obj1, ref obj2, out 딷);
      return 딷;
    }

    public static void 땄([In] ref 땟 obj0, [In] ref 땟 obj1, [In] ref 땟 obj2, out 딷 _param3)
    {
      땟 땟1 = 땟.땄(obj0 - obj1);
      땟 땟2 = 땟.땄(땟.땄(obj2, 땟1));
      땟 땟3 = 땟.땄(땟1, 땟2);
      _param3 = 딷.딟();
      _param3.딟 = 땟2.딟;
      _param3.땄 = 땟3.딟;
      _param3.딧 = 땟1.딟;
      _param3.땃 = 땟2.땄;
      _param3.딶 = 땟3.땄;
      _param3.땓 = 땟1.땄;
      _param3.땥 = 땟2.딧;
      _param3.딝 = 땟3.딧;
      _param3.떎 = 땟1.딧;
      _param3.땭 = -땟.딶(땟2, obj0);
      _param3.딦 = -땟.딶(땟3, obj0);
      _param3.땤 = -땟.딶(땟1, obj0);
    }

    public static 딷 딟([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3)
    {
      딷 딷;
      딷.딟(obj0, obj1, obj2, obj3, out 딷);
      return 딷;
    }

    public static void 딟([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3, out 딷 _param4)
    {
      _param4.딟 = 2f / obj0;
      _param4.땄 = 0.0f;
      _param4.딧 = 0.0f;
      _param4.딢 = 0.0f;
      _param4.땃 = 0.0f;
      _param4.딶 = 2f / obj1;
      _param4.땓 = 0.0f;
      _param4.땺 = 0.0f;
      _param4.땥 = 0.0f;
      _param4.딝 = 0.0f;
      _param4.떎 = (float) (1.0 / ((double) obj2 - (double) obj3));
      _param4.떂 = 0.0f;
      _param4.땭 = 0.0f;
      _param4.딦 = 0.0f;
      _param4.땤 = obj2 / (obj2 - obj3);
      _param4.땽 = 1f;
    }

    public static 딷 딟([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3, [In] float obj4, [In] float obj5)
    {
      딷 딷;
      딷.딟(obj0, obj1, obj2, obj3, obj4, obj5, out 딷);
      return 딷;
    }

    public static void 딟(
      [In] float obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4,
      [In] float obj5,
      out 딷 _param6)
    {
      _param6.딟 = (float) (2.0 / ((double) obj1 - (double) obj0));
      _param6.땄 = 0.0f;
      _param6.딧 = 0.0f;
      _param6.딢 = 0.0f;
      _param6.땃 = 0.0f;
      _param6.딶 = (float) (2.0 / ((double) obj3 - (double) obj2));
      _param6.땓 = 0.0f;
      _param6.땺 = 0.0f;
      _param6.땥 = 0.0f;
      _param6.딝 = 0.0f;
      _param6.떎 = (float) (1.0 / ((double) obj4 - (double) obj5));
      _param6.떂 = 0.0f;
      _param6.땭 = (float) (((double) obj0 + (double) obj1) / ((double) obj0 - (double) obj1));
      _param6.딦 = (float) (((double) obj2 + (double) obj3) / ((double) obj2 - (double) obj3));
      _param6.땤 = obj4 / (obj4 - obj5);
      _param6.땽 = 1f;
    }

    public static 딷 땄([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3) => throw new NotImplementedException();

    public static void 땄([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3, out 딷 _param4) => throw new NotImplementedException();

    public static 딷 딧([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3)
    {
      딷 딷;
      딷.딧(obj0, obj1, obj2, obj3, out 딷);
      return 딷;
    }

    public static void 딧([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3, out 딷 _param4)
    {
      _param4 = new 딷(0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
      if ((double) obj0 < 0.0 || (double) obj0 > 3.14159250259399)
        throw new ArgumentOutOfRangeException("fieldOfView", "fieldOfView takes a value between 0 and Pi (180 degrees) in radians.");
      if ((double) obj2 <= 0.0)
        throw new ArgumentOutOfRangeException("nearPlaneDistance", "You should specify positive value for nearPlaneDistance.");
      if ((double) obj3 <= 0.0)
        throw new ArgumentOutOfRangeException("farPlaneDistance", "You should specify positive value for farPlaneDistance.");
      if ((double) obj3 <= (double) obj2)
        throw new ArgumentOutOfRangeException("nearPlaneDistance", "Near plane distance is larger than Far plane distance. Near plane distance must be smaller than Far plane distance.");
      float num1 = 1f / (float) Math.Tan((double) obj0 / 2.0);
      float num2 = num1 / obj1;
      _param4.딟 = num2;
      _param4.딶 = num1;
      _param4.떎 = obj3 / (obj2 - obj3);
      _param4.떂 = -1f;
      _param4.땤 = (float) ((double) obj2 * (double) obj3 / ((double) obj2 - (double) obj3));
    }

    public static 딷 땄([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3, [In] float obj4, [In] float obj5) => throw new NotImplementedException();

    public static void 땄(
      [In] float obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4,
      [In] float obj5,
      out 딷 _param6)
    {
      throw new NotImplementedException();
    }

    public static 딷 딟([In] float obj0)
    {
      딷 딷 = 딷.딟();
      딷.딶 = (float) Math.Cos((double) obj0);
      딷.땓 = (float) Math.Sin((double) obj0);
      딷.딝 = -딷.땓;
      딷.떎 = 딷.딶;
      return 딷;
    }

    public static void 딟([In] float obj0, out 딷 _param1)
    {
      _param1 = 딷.딟();
      _param1.딶 = (float) Math.Cos((double) obj0);
      _param1.땓 = (float) Math.Sin((double) obj0);
      _param1.딝 = -_param1.땓;
      _param1.떎 = _param1.딶;
    }

    public static 딷 땄([In] float obj0)
    {
      딷 딷 = 딷.딟();
      딷.딟 = (float) Math.Cos((double) obj0);
      딷.딧 = (float) Math.Sin((double) obj0);
      딷.땥 = -딷.딧;
      딷.떎 = 딷.딟;
      return 딷;
    }

    public static void 땄([In] float obj0, out 딷 _param1)
    {
      _param1 = 딷.딟();
      _param1.딟 = (float) Math.Cos((double) obj0);
      _param1.딧 = (float) Math.Sin((double) obj0);
      _param1.땥 = -_param1.딧;
      _param1.떎 = _param1.딟;
    }

    public static 딷 딧([In] float obj0)
    {
      딷 딷 = 딷.딟();
      딷.딟 = (float) Math.Cos((double) obj0);
      딷.땄 = (float) Math.Sin((double) obj0);
      딷.땃 = -딷.땄;
      딷.딶 = 딷.딟;
      return 딷;
    }

    public static void 딧([In] float obj0, out 딷 _param1)
    {
      _param1 = 딷.딟();
      _param1.딟 = (float) Math.Cos((double) obj0);
      _param1.땄 = (float) Math.Sin((double) obj0);
      _param1.땃 = -_param1.땄;
      _param1.딶 = _param1.딟;
    }

    public static 딷 딢([In] float obj0)
    {
      딷 딷 = 딷.딟();
      딷.딟 = obj0;
      딷.딶 = obj0;
      딷.떎 = obj0;
      return 딷;
    }

    public static void 딢([In] float obj0, out 딷 _param1)
    {
      _param1 = 딷.딟();
      _param1.딟 = obj0;
      _param1.딶 = obj0;
      _param1.떎 = obj0;
    }

    public static 딷 딟([In] float obj0, [In] float obj1, [In] float obj2)
    {
      딷 딷 = 딷.딟();
      딷.딟 = obj0;
      딷.딶 = obj1;
      딷.떎 = obj2;
      return 딷;
    }

    public static void 딟([In] float obj0, [In] float obj1, [In] float obj2, out 딷 _param3)
    {
      _param3 = 딷.딟();
      _param3.딟 = obj0;
      _param3.딶 = obj1;
      _param3.떎 = obj2;
    }

    public static 딷 땺([In] 땟 obj0)
    {
      딷 딷 = 딷.딟();
      딷.딟 = obj0.딟;
      딷.딶 = obj0.땄;
      딷.떎 = obj0.딧;
      return 딷;
    }

    public static void 딟([In] ref 땟 obj0, out 딷 _param1)
    {
      _param1 = 딷.딟();
      _param1.딟 = obj0.딟;
      _param1.딶 = obj0.땄;
      _param1.떎 = obj0.딧;
    }

    public static 딷 땄([In] float obj0, [In] float obj1, [In] float obj2)
    {
      딷 딷 = 딷.딟();
      딷.땭 = obj0;
      딷.딦 = obj1;
      딷.땤 = obj2;
      return 딷;
    }

    public static void 땄([In] float obj0, [In] float obj1, [In] float obj2, out 딷 _param3)
    {
      _param3 = 딷.딟();
      _param3.땭 = obj0;
      _param3.딦 = obj1;
      _param3.땤 = obj2;
    }

    public static 딷 땥([In] 땟 obj0)
    {
      딷 딷 = 딷.딟();
      딷.땭 = obj0.딟;
      딷.딦 = obj0.땄;
      딷.땤 = obj0.딧;
      return 딷;
    }

    public static void 땄([In] ref 땟 obj0, out 딷 _param1)
    {
      _param1 = 딷.딟();
      _param1.땭 = obj0.딟;
      _param1.딦 = obj0.땄;
      _param1.땤 = obj0.딧;
    }

    public static 딷 땄([In] 딷 obj0, [In] 딷 obj1)
    {
      딷 딷;
      딷.땄(ref obj0, ref obj1, out 딷);
      return 딷;
    }

    public static void 땄([In] ref 딷 obj0, [In] ref 딷 obj1, out 딷 _param2)
    {
      딷 딷 = 딷.딟(obj1);
      딷.딧(ref obj0, ref 딷, out _param2);
    }

    public static 딷 딟([In] 딷 obj0, [In] float obj1)
    {
      딷 딷;
      딷.딟(ref obj0, obj1, out 딷);
      return 딷;
    }

    public static void 딟([In] ref 딷 obj0, [In] float obj1, out 딷 _param2)
    {
      float num = 1f / obj1;
      딷.땄(ref obj0, num, out _param2);
    }

    public static 딷 딟([In] 딷 obj0)
    {
      딷.딟(ref obj0, out obj0);
      return obj0;
    }

    public static void 딟([In] ref 딷 obj0, out 딷 _param1)
    {
      float num1 = (float) ((double) obj0.딟 * (double) obj0.딶 - (double) obj0.땄 * (double) obj0.땃);
      float num2 = (float) ((double) obj0.딟 * (double) obj0.땓 - (double) obj0.딧 * (double) obj0.땃);
      float num3 = (float) ((double) obj0.딟 * (double) obj0.땺 - (double) obj0.딢 * (double) obj0.땃);
      float num4 = (float) ((double) obj0.땄 * (double) obj0.땓 - (double) obj0.딧 * (double) obj0.딶);
      float num5 = (float) ((double) obj0.땄 * (double) obj0.땺 - (double) obj0.딢 * (double) obj0.딶);
      float num6 = (float) ((double) obj0.딧 * (double) obj0.땺 - (double) obj0.딢 * (double) obj0.땓);
      float num7 = (float) ((double) obj0.땥 * (double) obj0.딦 - (double) obj0.딝 * (double) obj0.땭);
      float num8 = (float) ((double) obj0.땥 * (double) obj0.땤 - (double) obj0.떎 * (double) obj0.땭);
      float num9 = (float) ((double) obj0.땥 * (double) obj0.땽 - (double) obj0.떂 * (double) obj0.땭);
      float num10 = (float) ((double) obj0.딝 * (double) obj0.땤 - (double) obj0.떎 * (double) obj0.딦);
      float num11 = (float) ((double) obj0.딝 * (double) obj0.땽 - (double) obj0.떂 * (double) obj0.딦);
      float num12 = (float) ((double) obj0.떎 * (double) obj0.땽 - (double) obj0.떂 * (double) obj0.땤);
      float num13 = 1f / (float) ((double) num1 * (double) num12 - (double) num2 * (double) num11 + (double) num3 * (double) num10 + (double) num4 * (double) num9 - (double) num5 * (double) num8 + (double) num6 * (double) num7);
      딷 딷;
      딷.딟 = (float) ((double) obj0.딶 * (double) num12 - (double) obj0.땓 * (double) num11 + (double) obj0.땺 * (double) num10) * num13;
      딷.땄 = (float) (-(double) obj0.땄 * (double) num12 + (double) obj0.딧 * (double) num11 - (double) obj0.딢 * (double) num10) * num13;
      딷.딧 = (float) ((double) obj0.딦 * (double) num6 - (double) obj0.땤 * (double) num5 + (double) obj0.땽 * (double) num4) * num13;
      딷.딢 = (float) (-(double) obj0.딝 * (double) num6 + (double) obj0.떎 * (double) num5 - (double) obj0.떂 * (double) num4) * num13;
      딷.땃 = (float) (-(double) obj0.땃 * (double) num12 + (double) obj0.땓 * (double) num9 - (double) obj0.땺 * (double) num8) * num13;
      딷.딶 = (float) ((double) obj0.딟 * (double) num12 - (double) obj0.딧 * (double) num9 + (double) obj0.딢 * (double) num8) * num13;
      딷.땓 = (float) (-(double) obj0.땭 * (double) num6 + (double) obj0.땤 * (double) num3 - (double) obj0.땽 * (double) num2) * num13;
      딷.땺 = (float) ((double) obj0.땥 * (double) num6 - (double) obj0.떎 * (double) num3 + (double) obj0.떂 * (double) num2) * num13;
      딷.땥 = (float) ((double) obj0.땃 * (double) num11 - (double) obj0.딶 * (double) num9 + (double) obj0.땺 * (double) num7) * num13;
      딷.딝 = (float) (-(double) obj0.딟 * (double) num11 + (double) obj0.땄 * (double) num9 - (double) obj0.딢 * (double) num7) * num13;
      딷.떎 = (float) ((double) obj0.땭 * (double) num5 - (double) obj0.딦 * (double) num3 + (double) obj0.땽 * (double) num1) * num13;
      딷.떂 = (float) (-(double) obj0.땥 * (double) num5 + (double) obj0.딝 * (double) num3 - (double) obj0.떂 * (double) num1) * num13;
      딷.땭 = (float) (-(double) obj0.땃 * (double) num10 + (double) obj0.딶 * (double) num8 - (double) obj0.땓 * (double) num7) * num13;
      딷.딦 = (float) ((double) obj0.딟 * (double) num10 - (double) obj0.땄 * (double) num8 + (double) obj0.딧 * (double) num7) * num13;
      딷.땤 = (float) (-(double) obj0.땭 * (double) num4 + (double) obj0.딦 * (double) num2 - (double) obj0.땤 * (double) num1) * num13;
      딷.땽 = (float) ((double) obj0.땥 * (double) num4 - (double) obj0.딝 * (double) num2 + (double) obj0.떎 * (double) num1) * num13;
      _param1 = 딷;
    }

    public static 딷 딟([In] 딷 obj0, [In] 딷 obj1, [In] float obj2) => throw new NotImplementedException();

    public static void 딟([In] ref 딷 obj0, [In] ref 딷 obj1, [In] float obj2, out 딷 _param3) => throw new NotImplementedException();

    public static 딷 딧([In] 딷 obj0, [In] 딷 obj1)
    {
      딷 딷;
      딷.딧(ref obj0, ref obj1, out 딷);
      return 딷;
    }

    public static void 딧([In] ref 딷 obj0, [In] ref 딷 obj1, out 딷 _param2)
    {
      _param2.딟 = (float) ((double) obj0.딟 * (double) obj1.딟 + (double) obj0.땄 * (double) obj1.땃 + (double) obj0.딧 * (double) obj1.땥 + (double) obj0.딢 * (double) obj1.땭);
      _param2.땄 = (float) ((double) obj0.딟 * (double) obj1.땄 + (double) obj0.땄 * (double) obj1.딶 + (double) obj0.딧 * (double) obj1.딝 + (double) obj0.딢 * (double) obj1.딦);
      _param2.딧 = (float) ((double) obj0.딟 * (double) obj1.딧 + (double) obj0.땄 * (double) obj1.땓 + (double) obj0.딧 * (double) obj1.떎 + (double) obj0.딢 * (double) obj1.땤);
      _param2.딢 = (float) ((double) obj0.딟 * (double) obj1.딢 + (double) obj0.땄 * (double) obj1.땺 + (double) obj0.딧 * (double) obj1.떂 + (double) obj0.딢 * (double) obj1.땽);
      _param2.땃 = (float) ((double) obj0.땃 * (double) obj1.딟 + (double) obj0.딶 * (double) obj1.땃 + (double) obj0.땓 * (double) obj1.땥 + (double) obj0.땺 * (double) obj1.땭);
      _param2.딶 = (float) ((double) obj0.땃 * (double) obj1.땄 + (double) obj0.딶 * (double) obj1.딶 + (double) obj0.땓 * (double) obj1.딝 + (double) obj0.땺 * (double) obj1.딦);
      _param2.땓 = (float) ((double) obj0.땃 * (double) obj1.딧 + (double) obj0.딶 * (double) obj1.땓 + (double) obj0.땓 * (double) obj1.떎 + (double) obj0.땺 * (double) obj1.땤);
      _param2.땺 = (float) ((double) obj0.땃 * (double) obj1.딢 + (double) obj0.딶 * (double) obj1.땺 + (double) obj0.땓 * (double) obj1.떂 + (double) obj0.땺 * (double) obj1.땽);
      _param2.땥 = (float) ((double) obj0.땥 * (double) obj1.딟 + (double) obj0.딝 * (double) obj1.땃 + (double) obj0.떎 * (double) obj1.땥 + (double) obj0.떂 * (double) obj1.땭);
      _param2.딝 = (float) ((double) obj0.땥 * (double) obj1.땄 + (double) obj0.딝 * (double) obj1.딶 + (double) obj0.떎 * (double) obj1.딝 + (double) obj0.떂 * (double) obj1.딦);
      _param2.떎 = (float) ((double) obj0.땥 * (double) obj1.딧 + (double) obj0.딝 * (double) obj1.땓 + (double) obj0.떎 * (double) obj1.떎 + (double) obj0.떂 * (double) obj1.땤);
      _param2.떂 = (float) ((double) obj0.땥 * (double) obj1.딢 + (double) obj0.딝 * (double) obj1.땺 + (double) obj0.떎 * (double) obj1.떂 + (double) obj0.떂 * (double) obj1.땽);
      _param2.땭 = (float) ((double) obj0.땭 * (double) obj1.딟 + (double) obj0.딦 * (double) obj1.땃 + (double) obj0.땤 * (double) obj1.땥 + (double) obj0.땽 * (double) obj1.땭);
      _param2.딦 = (float) ((double) obj0.땭 * (double) obj1.땄 + (double) obj0.딦 * (double) obj1.딶 + (double) obj0.땤 * (double) obj1.딝 + (double) obj0.땽 * (double) obj1.딦);
      _param2.땤 = (float) ((double) obj0.땭 * (double) obj1.딧 + (double) obj0.딦 * (double) obj1.땓 + (double) obj0.땤 * (double) obj1.떎 + (double) obj0.땽 * (double) obj1.땤);
      _param2.땽 = (float) ((double) obj0.땭 * (double) obj1.딢 + (double) obj0.딦 * (double) obj1.땺 + (double) obj0.땤 * (double) obj1.떂 + (double) obj0.땽 * (double) obj1.땽);
    }

    public static 딷 땄([In] 딷 obj0, [In] float obj1)
    {
      obj0.딟 *= obj1;
      obj0.땄 *= obj1;
      obj0.딧 *= obj1;
      obj0.딢 *= obj1;
      obj0.땃 *= obj1;
      obj0.딶 *= obj1;
      obj0.땓 *= obj1;
      obj0.땺 *= obj1;
      obj0.땥 *= obj1;
      obj0.딝 *= obj1;
      obj0.떎 *= obj1;
      obj0.떂 *= obj1;
      obj0.땭 *= obj1;
      obj0.딦 *= obj1;
      obj0.땤 *= obj1;
      obj0.땽 *= obj1;
      return obj0;
    }

    public static void 땄([In] ref 딷 obj0, [In] float obj1, out 딷 _param2)
    {
      _param2.딟 = obj0.딟 * obj1;
      _param2.땄 = obj0.땄 * obj1;
      _param2.딧 = obj0.딧 * obj1;
      _param2.딢 = obj0.딢 * obj1;
      _param2.땃 = obj0.땃 * obj1;
      _param2.딶 = obj0.딶 * obj1;
      _param2.땓 = obj0.땓 * obj1;
      _param2.땺 = obj0.땺 * obj1;
      _param2.땥 = obj0.땥 * obj1;
      _param2.딝 = obj0.딝 * obj1;
      _param2.떎 = obj0.떎 * obj1;
      _param2.떂 = obj0.떂 * obj1;
      _param2.땭 = obj0.땭 * obj1;
      _param2.딦 = obj0.딦 * obj1;
      _param2.땤 = obj0.땤 * obj1;
      _param2.땽 = obj0.땽 * obj1;
    }

    public static 딷 땄([In] 딷 obj0)
    {
      딷.땄(ref obj0, -1f, out obj0);
      return obj0;
    }

    public static void 땄([In] ref 딷 obj0, out 딷 _param1) => 딷.땄(ref obj0, -1f, out _param1);

    public static 딷 딢([In] 딷 obj0, [In] 딷 obj1)
    {
      obj0.딟 -= obj1.딟;
      obj0.땄 -= obj1.땄;
      obj0.딧 -= obj1.딧;
      obj0.딢 -= obj1.딢;
      obj0.땃 -= obj1.땃;
      obj0.딶 -= obj1.딶;
      obj0.땓 -= obj1.땓;
      obj0.땺 -= obj1.땺;
      obj0.땥 -= obj1.땥;
      obj0.딝 -= obj1.딝;
      obj0.떎 -= obj1.떎;
      obj0.떂 -= obj1.떂;
      obj0.땭 -= obj1.땭;
      obj0.딦 -= obj1.딦;
      obj0.땤 -= obj1.땤;
      obj0.땽 -= obj1.땽;
      return obj0;
    }

    public static void 딢([In] ref 딷 obj0, [In] ref 딷 obj1, out 딷 _param2)
    {
      _param2.딟 = obj0.딟 - obj1.딟;
      _param2.땄 = obj0.땄 - obj1.땄;
      _param2.딧 = obj0.딧 - obj1.딧;
      _param2.딢 = obj0.딢 - obj1.딢;
      _param2.땃 = obj0.땃 - obj1.땃;
      _param2.딶 = obj0.딶 - obj1.딶;
      _param2.땓 = obj0.땓 - obj1.땓;
      _param2.땺 = obj0.땺 - obj1.땺;
      _param2.땥 = obj0.땥 - obj1.땥;
      _param2.딝 = obj0.딝 - obj1.딝;
      _param2.떎 = obj0.떎 - obj1.떎;
      _param2.떂 = obj0.떂 - obj1.떂;
      _param2.땭 = obj0.땭 - obj1.땭;
      _param2.딦 = obj0.딦 - obj1.딦;
      _param2.땤 = obj0.땤 - obj1.땤;
      _param2.땽 = obj0.땽 - obj1.땽;
    }

    public static 딷 딧([In] 딷 obj0)
    {
      딷 딷;
      딷.딧(ref obj0, out 딷);
      return 딷;
    }

    public static void 딧([In] ref 딷 obj0, out 딷 _param1)
    {
      _param1.딟 = obj0.딟;
      _param1.땄 = obj0.땃;
      _param1.딧 = obj0.땥;
      _param1.딢 = obj0.땭;
      _param1.땃 = obj0.땄;
      _param1.딶 = obj0.딶;
      _param1.땓 = obj0.딝;
      _param1.땺 = obj0.딦;
      _param1.땥 = obj0.딧;
      _param1.딝 = obj0.땓;
      _param1.떎 = obj0.떎;
      _param1.떂 = obj0.땤;
      _param1.땭 = obj0.딢;
      _param1.딦 = obj0.땺;
      _param1.땤 = obj0.떂;
      _param1.땽 = obj0.땽;
    }

    public float 땥()
    {
      float num1 = (float) ((double) this.땥 * (double) this.딦 - (double) this.딝 * (double) this.땭);
      float num2 = (float) ((double) this.땥 * (double) this.땤 - (double) this.떎 * (double) this.땭);
      float num3 = (float) ((double) this.땥 * (double) this.땽 - (double) this.떂 * (double) this.땭);
      float num4 = (float) ((double) this.딝 * (double) this.땤 - (double) this.떎 * (double) this.딦);
      float num5 = (float) ((double) this.딝 * (double) this.땽 - (double) this.떂 * (double) this.딦);
      float num6 = (float) ((double) this.떎 * (double) this.땽 - (double) this.떂 * (double) this.땤);
      return (float) ((double) this.딟 * ((double) this.딶 * (double) num6 - (double) this.땓 * (double) num5 + (double) this.땺 * (double) num4) - (double) this.땄 * ((double) this.땃 * (double) num6 - (double) this.땓 * (double) num3 + (double) this.땺 * (double) num2) + (double) this.딧 * ((double) this.땃 * (double) num5 - (double) this.딶 * (double) num3 + (double) this.땺 * (double) num1) - (double) this.딢 * ((double) this.땃 * (double) num4 - (double) this.딶 * (double) num2 + (double) this.땓 * (double) num1));
    }

    public bool Equals([In] 딷 obj0) => this == obj0;

    public override bool Equals([In] object obj0) => this == (딷) obj0;

    public override int GetHashCode() => throw new NotImplementedException();

    public override string ToString() => "{ {M11:" + (object) this.딟 + " M12:" + (object) this.땄 + " M13:" + (object) this.딧 + " M14:" + (object) this.딢 + "} {M21:" + (object) this.땃 + " M22:" + (object) this.딶 + " M23:" + (object) this.땓 + " M24:" + (object) this.땺 + "} {M31:" + (object) this.땥 + " M32:" + (object) this.딝 + " M33:" + (object) this.떎 + " M34:" + (object) this.떂 + "} {M41:" + (object) this.땭 + " M42:" + (object) this.딦 + " M43:" + (object) this.땤 + " M44:" + (object) this.땽 + "} }";

    public static 딷 operator +([In] 딷 obj0, [In] 딷 obj1)
    {
      딷.딟(ref obj0, ref obj1, out obj0);
      return obj0;
    }

    public static 딷 operator /([In] 딷 obj0, [In] 딷 obj1)
    {
      딷 딷;
      딷.땄(ref obj0, ref obj1, out 딷);
      return 딷;
    }

    public static 딷 operator /([In] 딷 obj0, [In] float obj1)
    {
      딷 딷;
      딷.딟(ref obj0, obj1, out 딷);
      return 딷;
    }

    public static bool operator ==([In] 딷 obj0, [In] 딷 obj1) => (double) obj0.딟 == (double) obj1.딟 && (double) obj0.땄 == (double) obj1.땄 && (double) obj0.딧 == (double) obj1.딧 && (double) obj0.딢 == (double) obj1.딢 && (double) obj0.땃 == (double) obj1.땃 && (double) obj0.딶 == (double) obj1.딶 && (double) obj0.땓 == (double) obj1.땓 && (double) obj0.땺 == (double) obj1.땺 && (double) obj0.땥 == (double) obj1.땥 && (double) obj0.딝 == (double) obj1.딝 && (double) obj0.떎 == (double) obj1.떎 && (double) obj0.떂 == (double) obj1.떂 && (double) obj0.땭 == (double) obj1.땭 && (double) obj0.딦 == (double) obj1.딦 && (double) obj0.땤 == (double) obj1.땤 && (double) obj0.땽 == (double) obj1.땽;

    public static bool operator !=([In] 딷 obj0, [In] 딷 obj1) => !(obj0 == obj1);

    public static 딷 operator *([In] 딷 obj0, [In] 딷 obj1)
    {
      딷 딷 = new 딷();
      딷.딧(ref obj0, ref obj1, out 딷);
      return 딷;
    }

    public static 딷 operator *([In] 딷 obj0, [In] float obj1)
    {
      딷.땄(ref obj0, obj1, out obj0);
      return obj0;
    }

    public static 딷 operator *([In] float obj0, [In] 딷 obj1)
    {
      딷 딷;
      딷.딟 = obj1.딟 * obj0;
      딷.땄 = obj1.땄 * obj0;
      딷.딧 = obj1.딧 * obj0;
      딷.딢 = obj1.딢 * obj0;
      딷.땃 = obj1.땃 * obj0;
      딷.딶 = obj1.딶 * obj0;
      딷.땓 = obj1.땓 * obj0;
      딷.땺 = obj1.땺 * obj0;
      딷.땥 = obj1.땥 * obj0;
      딷.딝 = obj1.딝 * obj0;
      딷.떎 = obj1.떎 * obj0;
      딷.떂 = obj1.떂 * obj0;
      딷.땭 = obj1.땭 * obj0;
      딷.딦 = obj1.딦 * obj0;
      딷.땤 = obj1.땤 * obj0;
      딷.땽 = obj1.땽 * obj0;
      return 딷;
    }

    public static 딷 operator -([In] 딷 obj0, [In] 딷 obj1)
    {
      딷 딷 = new 딷();
      딷.딢(ref obj0, ref obj1, out 딷);
      return 딷;
    }

    public static 딷 operator -([In] 딷 obj0)
    {
      딷.땄(ref obj0, out obj0);
      return obj0;
    }
  }
}
