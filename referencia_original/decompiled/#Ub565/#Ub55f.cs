// Decompiled with JetBrains decompiler
// Type: 땥.땟
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace 땥
{
  public struct 땟 : IEquatable<땟>
  {
    private static 땟 딟 = new 땟(0.0f, 0.0f, 0.0f);
    private static 땟 땄 = new 땟(1f, 1f, 1f);
    private static 땟 딧 = new 땟(1f, 0.0f, 0.0f);
    private static 땟 딢 = new 땟(0.0f, 1f, 0.0f);
    private static 땟 땃 = new 땟(0.0f, 0.0f, 1f);
    private static 땟 딶 = new 땟(0.0f, 1f, 0.0f);
    private static 땟 땓 = new 땟(0.0f, -1f, 0.0f);
    private static 땟 땺 = new 땟(1f, 0.0f, 0.0f);
    private static 땟 땥 = new 땟(-1f, 0.0f, 0.0f);
    private static 땟 딝 = new 땟(0.0f, 0.0f, -1f);
    private static 땟 떎 = new 땟(0.0f, 0.0f, 1f);
    public float 딟;
    public float 땄;
    public float 딧;

    public 땟([In] float obj0, [In] float obj1, [In] float obj2)
    {
      this.딟 = obj0;
      this.땄 = obj1;
      this.딧 = obj2;
    }

    public 땟([In] float obj0)
    {
      this.딟 = obj0;
      this.땄 = obj0;
      this.딧 = obj0;
    }

    public 땟([In] 떁 obj0, [In] float obj1)
    {
      this.딟 = obj0.딟;
      this.땄 = obj0.땄;
      this.딧 = obj1;
    }

    [SpecialName]
    public static 땟 딟() => 땟.딟;

    [SpecialName]
    public static 땟 땄() => 땟.땄;

    [SpecialName]
    public static 땟 딧() => 땟.딧;

    [SpecialName]
    public static 땟 딢() => 땟.딢;

    [SpecialName]
    public static 땟 땃() => 땟.땃;

    [SpecialName]
    public static 땟 딶() => 땟.딶;

    [SpecialName]
    public static 땟 땓() => 땟.땓;

    [SpecialName]
    public static 땟 땺() => 땟.땺;

    [SpecialName]
    public static 땟 땥() => 땟.땥;

    [SpecialName]
    public static 땟 딝() => 땟.딝;

    [SpecialName]
    public static 땟 떎() => 땟.떎;

    public static 땟 딟([In] 땟 obj0, [In] 땟 obj1)
    {
      obj0.딟 += obj1.딟;
      obj0.땄 += obj1.땄;
      obj0.딧 += obj1.딧;
      return obj0;
    }

    public static void 딟([In] ref 땟 obj0, [In] ref 땟 obj1, out 땟 _param2)
    {
      _param2.딟 = obj0.딟 + obj1.딟;
      _param2.땄 = obj0.땄 + obj1.땄;
      _param2.딧 = obj0.딧 + obj1.딧;
    }

    public static 땟 딟([In] 땟 obj0, [In] 땟 obj1, [In] 땟 obj2, [In] float obj3, [In] float obj4) => new 땟(딣.딟(obj0.딟, obj1.딟, obj2.딟, obj3, obj4), 딣.딟(obj0.땄, obj1.땄, obj2.땄, obj3, obj4), 딣.딟(obj0.딧, obj1.딧, obj2.딧, obj3, obj4));

    public static void 딟(
      [In] ref 땟 obj0,
      [In] ref 땟 obj1,
      [In] ref 땟 obj2,
      [In] float obj3,
      [In] float obj4,
      out 땟 _param5)
    {
      _param5 = new 땟(딣.딟(obj0.딟, obj1.딟, obj2.딟, obj3, obj4), 딣.딟(obj0.땄, obj1.땄, obj2.땄, obj3, obj4), 딣.딟(obj0.딧, obj1.딧, obj2.딧, obj3, obj4));
    }

    public static 땟 딟([In] 땟 obj0, [In] 땟 obj1, [In] 땟 obj2, [In] 땟 obj3, [In] float obj4) => new 땟(딣.땄(obj0.딟, obj1.딟, obj2.딟, obj3.딟, obj4), 딣.땄(obj0.땄, obj1.땄, obj2.땄, obj3.땄, obj4), 딣.땄(obj0.딧, obj1.딧, obj2.딧, obj3.딧, obj4));

    public static void 딟(
      [In] ref 땟 obj0,
      [In] ref 땟 obj1,
      [In] ref 땟 obj2,
      [In] ref 땟 obj3,
      [In] float obj4,
      out 땟 _param5)
    {
      _param5 = new 땟(딣.땄(obj0.딟, obj1.딟, obj2.딟, obj3.딟, obj4), 딣.땄(obj0.땄, obj1.땄, obj2.땄, obj3.땄, obj4), 딣.땄(obj0.딧, obj1.딧, obj2.딧, obj3.딧, obj4));
    }

    public static 땟 딟([In] 땟 obj0, [In] 땟 obj1, [In] 땟 obj2) => new 땟(딣.딟(obj0.딟, obj1.딟, obj2.딟), 딣.딟(obj0.땄, obj1.땄, obj2.땄), 딣.딟(obj0.딧, obj1.딧, obj2.딧));

    public static void 딟([In] ref 땟 obj0, [In] ref 땟 obj1, [In] ref 땟 obj2, out 땟 _param3) => _param3 = new 땟(딣.딟(obj0.딟, obj1.딟, obj2.딟), 딣.딟(obj0.땄, obj1.땄, obj2.땄), 딣.딟(obj0.딧, obj1.딧, obj2.딧));

    public static 땟 땄([In] 땟 obj0, [In] 땟 obj1)
    {
      땟.땄(ref obj0, ref obj1, out obj0);
      return obj0;
    }

    public static void 땄([In] ref 땟 obj0, [In] ref 땟 obj1, out 땟 _param2) => _param2 = new 땟((float) ((double) obj0.땄 * (double) obj1.딧 - (double) obj1.땄 * (double) obj0.딧), (float) -((double) obj0.딟 * (double) obj1.딧 - (double) obj1.딟 * (double) obj0.딧), (float) ((double) obj0.딟 * (double) obj1.땄 - (double) obj1.딟 * (double) obj0.땄));

    public static float 딧([In] 땟 obj0, [In] 땟 obj1)
    {
      float num;
      땟.땄(ref obj0, ref obj1, out num);
      return (float) Math.Sqrt((double) num);
    }

    public static void 딟([In] ref 땟 obj0, [In] ref 땟 obj1, out float _param2)
    {
      땟.땄(ref obj0, ref obj1, out _param2);
      _param2 = (float) Math.Sqrt((double) _param2);
    }

    public static float 딢([In] 땟 obj0, [In] 땟 obj1)
    {
      float num;
      땟.땄(ref obj0, ref obj1, out num);
      return num;
    }

    public static void 땄([In] ref 땟 obj0, [In] ref 땟 obj1, out float _param2) => _param2 = (float) (((double) obj0.딟 - (double) obj1.딟) * ((double) obj0.딟 - (double) obj1.딟) + ((double) obj0.땄 - (double) obj1.땄) * ((double) obj0.땄 - (double) obj1.땄) + ((double) obj0.딧 - (double) obj1.딧) * ((double) obj0.딧 - (double) obj1.딧));

    public static 땟 땃([In] 땟 obj0, [In] 땟 obj1)
    {
      obj0.딟 /= obj1.딟;
      obj0.땄 /= obj1.땄;
      obj0.딧 /= obj1.딧;
      return obj0;
    }

    public static 땟 딟([In] 땟 obj0, [In] float obj1)
    {
      float num = 1f / obj1;
      obj0.딟 *= num;
      obj0.땄 *= num;
      obj0.딧 *= num;
      return obj0;
    }

    public static void 딟([In] ref 땟 obj0, [In] float obj1, out 땟 _param2)
    {
      float num = 1f / obj1;
      _param2.딟 = obj0.딟 * num;
      _param2.땄 = obj0.땄 * num;
      _param2.딧 = obj0.딧 * num;
    }

    public static void 딧([In] ref 땟 obj0, [In] ref 땟 obj1, out 땟 _param2)
    {
      _param2.딟 = obj0.딟 / obj1.딟;
      _param2.땄 = obj0.땄 / obj1.땄;
      _param2.딧 = obj0.딧 / obj1.딧;
    }

    public static float 딶([In] 땟 obj0, [In] 땟 obj1) => (float) ((double) obj0.딟 * (double) obj1.딟 + (double) obj0.땄 * (double) obj1.땄 + (double) obj0.딧 * (double) obj1.딧);

    public static void 딧([In] ref 땟 obj0, [In] ref 땟 obj1, out float _param2) => _param2 = (float) ((double) obj0.딟 * (double) obj1.딟 + (double) obj0.땄 * (double) obj1.땄 + (double) obj0.딧 * (double) obj1.딧);

    public override bool Equals([In] object obj0) => obj0 is 땟 땟 && this == 땟;

    public bool Equals([In] 땟 obj0) => this == obj0;

    public override int GetHashCode() => (int) ((double) this.딟 + (double) this.땄 + (double) this.딧);

    public static 땟 땄([In] 땟 obj0, [In] 땟 obj1, [In] 땟 obj2, [In] 땟 obj3, [In] float obj4)
    {
      땟 땟 = new 땟();
      땟.땄(ref obj0, ref obj1, ref obj2, ref obj3, obj4, out 땟);
      return 땟;
    }

    public static void 땄(
      [In] ref 땟 obj0,
      [In] ref 땟 obj1,
      [In] ref 땟 obj2,
      [In] ref 땟 obj3,
      [In] float obj4,
      out 땟 _param5)
    {
      _param5.딟 = 딣.딧(obj0.딟, obj1.딟, obj2.딟, obj3.딟, obj4);
      _param5.땄 = 딣.딧(obj0.땄, obj1.땄, obj2.땄, obj3.땄, obj4);
      _param5.딧 = 딣.딧(obj0.딧, obj1.딧, obj2.딧, obj3.딧, obj4);
    }

    public float 떂()
    {
      float num;
      땟.땄(ref this, ref 땟.딟, out num);
      return (float) Math.Sqrt((double) num);
    }

    public float 땭()
    {
      float num;
      땟.땄(ref this, ref 땟.딟, out num);
      return num;
    }

    public static 땟 딟([In] 땟 obj0, [In] 땟 obj1, [In] float obj2) => new 땟(딣.땄(obj0.딟, obj1.딟, obj2), 딣.땄(obj0.땄, obj1.땄, obj2), 딣.땄(obj0.딧, obj1.딧, obj2));

    public static void 딟([In] ref 땟 obj0, [In] ref 땟 obj1, [In] float obj2, out 땟 _param3) => _param3 = new 땟(딣.땄(obj0.딟, obj1.딟, obj2), 딣.땄(obj0.땄, obj1.땄, obj2), 딣.땄(obj0.딧, obj1.딧, obj2));

    public static 땟 땓([In] 땟 obj0, [In] 땟 obj1) => new 땟(딣.땄(obj0.딟, obj1.딟), 딣.땄(obj0.땄, obj1.땄), 딣.땄(obj0.딧, obj1.딧));

    public static void 딢([In] ref 땟 obj0, [In] ref 땟 obj1, out 땟 _param2) => _param2 = new 땟(딣.땄(obj0.딟, obj1.딟), 딣.땄(obj0.땄, obj1.땄), 딣.땄(obj0.딧, obj1.딧));

    public static 땟 땺([In] 땟 obj0, [In] 땟 obj1) => new 땟(딣.딧(obj0.딟, obj1.딟), 딣.딧(obj0.땄, obj1.땄), 딣.딧(obj0.딧, obj1.딧));

    public static void 땃([In] ref 땟 obj0, [In] ref 땟 obj1, out 땟 _param2) => _param2 = new 땟(딣.딧(obj0.딟, obj1.딟), 딣.딧(obj0.땄, obj1.땄), 딣.딧(obj0.딧, obj1.딧));

    public static 땟 땥([In] 땟 obj0, [In] 땟 obj1)
    {
      obj0.딟 *= obj1.딟;
      obj0.땄 *= obj1.땄;
      obj0.딧 *= obj1.딧;
      return obj0;
    }

    public static 땟 땄([In] 땟 obj0, [In] float obj1)
    {
      obj0.딟 *= obj1;
      obj0.땄 *= obj1;
      obj0.딧 *= obj1;
      return obj0;
    }

    public static void 땄([In] ref 땟 obj0, [In] float obj1, out 땟 _param2)
    {
      _param2.딟 = obj0.딟 * obj1;
      _param2.땄 = obj0.땄 * obj1;
      _param2.딧 = obj0.딧 * obj1;
    }

    public static void 딶([In] ref 땟 obj0, [In] ref 땟 obj1, out 땟 _param2)
    {
      _param2.딟 = obj0.딟 * obj1.딟;
      _param2.땄 = obj0.땄 * obj1.땄;
      _param2.딧 = obj0.딧 * obj1.딧;
    }

    public static 땟 딟([In] 땟 obj0)
    {
      obj0 = new 땟(-obj0.딟, -obj0.땄, -obj0.딧);
      return obj0;
    }

    public static void 딟([In] ref 땟 obj0, out 땟 _param1) => _param1 = new 땟(-obj0.딟, -obj0.땄, -obj0.딧);

    public void 딦() => 땟.땄(ref this, out this);

    public static 땟 땄([In] 땟 obj0)
    {
      땟.땄(ref obj0, out obj0);
      return obj0;
    }

    public static void 땄([In] ref 땟 obj0, out 땟 _param1)
    {
      float num1;
      땟.딟(ref obj0, ref 땟.딟, out num1);
      float num2 = 1f / num1;
      _param1.딟 = obj0.딟 * num2;
      _param1.땄 = obj0.땄 * num2;
      _param1.딧 = obj0.딧 * num2;
    }

    public static 땟 딝([In] 땟 obj0, [In] 땟 obj1)
    {
      땟 땟;
      땟.땓(ref obj0, ref obj1, out 땟);
      return 땟;
    }

    public static void 땓([In] ref 땟 obj0, [In] ref 땟 obj1, out 땟 _param2)
    {
      float num = 땟.딶(obj0, obj1);
      _param2.딟 = obj0.딟 - 2f * num * obj1.딟;
      _param2.땄 = obj0.땄 - 2f * num * obj1.땄;
      _param2.딧 = obj0.딧 - 2f * num * obj1.딧;
    }

    public static 땟 땄([In] 땟 obj0, [In] 땟 obj1, [In] float obj2) => new 땟(딣.딧(obj0.딟, obj1.딟, obj2), 딣.딧(obj0.땄, obj1.땄, obj2), 딣.딧(obj0.딧, obj1.딧, obj2));

    public static void 땄([In] ref 땟 obj0, [In] ref 땟 obj1, [In] float obj2, out 땟 _param3) => _param3 = new 땟(딣.딧(obj0.딟, obj1.딟, obj2), 딣.딧(obj0.땄, obj1.땄, obj2), 딣.딧(obj0.딧, obj1.딧, obj2));

    public static 땟 떎([In] 땟 obj0, [In] 땟 obj1)
    {
      obj0.딟 -= obj1.딟;
      obj0.땄 -= obj1.땄;
      obj0.딧 -= obj1.딧;
      return obj0;
    }

    public static void 땺([In] ref 땟 obj0, [In] ref 땟 obj1, out 땟 _param2)
    {
      _param2.딟 = obj0.딟 - obj1.딟;
      _param2.땄 = obj0.땄 - obj1.땄;
      _param2.딧 = obj0.딧 - obj1.딧;
    }

    public override string ToString()
    {
      StringBuilder stringBuilder = new StringBuilder(32);
      stringBuilder.Append("{X:");
      stringBuilder.Append(this.딟);
      stringBuilder.Append(" Y:");
      stringBuilder.Append(this.땄);
      stringBuilder.Append(" Z:");
      stringBuilder.Append(this.딧);
      stringBuilder.Append("}");
      return stringBuilder.ToString();
    }

    public static 땟 딟([In] 땟 obj0, [In] 딷 obj1)
    {
      땟.딟(ref obj0, ref obj1, out obj0);
      return obj0;
    }

    public static void 딟([In] ref 땟 obj0, [In] ref 딷 obj1, out 땟 _param2) => _param2 = new 땟((float) ((double) obj0.딟 * (double) obj1.딟 + (double) obj0.땄 * (double) obj1.땃 + (double) obj0.딧 * (double) obj1.땥) + obj1.땭, (float) ((double) obj0.딟 * (double) obj1.땄 + (double) obj0.땄 * (double) obj1.딶 + (double) obj0.딧 * (double) obj1.딝) + obj1.딦, (float) ((double) obj0.딟 * (double) obj1.딧 + (double) obj0.땄 * (double) obj1.땓 + (double) obj0.딧 * (double) obj1.떎) + obj1.땤);

    public static void 딟([In] 땟[] obj0, [In] ref 딷 obj1, [In] 땟[] obj2) => throw new NotImplementedException();

    public static void 딟([In] 땟[] obj0, [In] int obj1, [In] ref 딷 obj2, [In] 땟[] obj3, [In] int obj4, [In] int obj5) => throw new NotImplementedException();

    public static void 땄([In] 땟[] obj0, [In] ref 딷 obj1, [In] 땟[] obj2) => throw new NotImplementedException();

    public static void 땄([In] 땟[] obj0, [In] int obj1, [In] ref 딷 obj2, [In] 땟[] obj3, [In] int obj4, [In] int obj5) => throw new NotImplementedException();

    public static 땟 땄([In] 땟 obj0, [In] 딷 obj1)
    {
      땟.땄(ref obj0, ref obj1, out obj0);
      return obj0;
    }

    public static void 땄([In] ref 땟 obj0, [In] ref 딷 obj1, out 땟 _param2) => _param2 = new 땟((float) ((double) obj0.딟 * (double) obj1.딟 + (double) obj0.땄 * (double) obj1.땃 + (double) obj0.딧 * (double) obj1.땥), (float) ((double) obj0.딟 * (double) obj1.땄 + (double) obj0.땄 * (double) obj1.딶 + (double) obj0.딧 * (double) obj1.딝), (float) ((double) obj0.딟 * (double) obj1.딧 + (double) obj0.땄 * (double) obj1.땓 + (double) obj0.딧 * (double) obj1.떎));

    public static bool operator ==([In] 땟 obj0, [In] 땟 obj1) => (double) obj0.딟 == (double) obj1.딟 && (double) obj0.땄 == (double) obj1.땄 && (double) obj0.딧 == (double) obj1.딧;

    public static bool operator !=([In] 땟 obj0, [In] 땟 obj1) => !(obj0 == obj1);

    public static 땟 operator +([In] 땟 obj0, [In] 땟 obj1)
    {
      obj0.딟 += obj1.딟;
      obj0.땄 += obj1.땄;
      obj0.딧 += obj1.딧;
      return obj0;
    }

    public static 땟 operator -([In] 땟 obj0)
    {
      obj0 = new 땟(-obj0.딟, -obj0.땄, -obj0.딧);
      return obj0;
    }

    public static 땟 operator -([In] 땟 obj0, [In] 땟 obj1)
    {
      obj0.딟 -= obj1.딟;
      obj0.땄 -= obj1.땄;
      obj0.딧 -= obj1.딧;
      return obj0;
    }

    public static 땟 operator *([In] 땟 obj0, [In] 땟 obj1)
    {
      obj0.딟 *= obj1.딟;
      obj0.땄 *= obj1.땄;
      obj0.딧 *= obj1.딧;
      return obj0;
    }

    public static 땟 operator *([In] 땟 obj0, [In] float obj1)
    {
      obj0.딟 *= obj1;
      obj0.땄 *= obj1;
      obj0.딧 *= obj1;
      return obj0;
    }

    public static 땟 operator *([In] float obj0, [In] 땟 obj1)
    {
      obj1.딟 *= obj0;
      obj1.땄 *= obj0;
      obj1.딧 *= obj0;
      return obj1;
    }

    public static 땟 operator /([In] 땟 obj0, [In] 땟 obj1)
    {
      obj0.딟 /= obj1.딟;
      obj0.땄 /= obj1.땄;
      obj0.딧 /= obj1.딧;
      return obj0;
    }

    public static 땟 operator /([In] 땟 obj0, [In] float obj1)
    {
      float num = 1f / obj1;
      obj0.딟 *= num;
      obj0.땄 *= num;
      obj0.딧 *= num;
      return obj0;
    }
  }
}
