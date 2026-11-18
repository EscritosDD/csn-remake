// Decompiled with JetBrains decompiler
// Type: 땥.떁
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace 땥
{
  public struct 떁 : IEquatable<떁>
  {
    private static 떁 딟 = new 떁(0.0f, 0.0f);
    private static 떁 땄 = new 떁(1f, 1f);
    private static 떁 딧 = new 떁(1f, 0.0f);
    private static 떁 딢 = new 떁(0.0f, 1f);
    public float 딟;
    public float 땄;

    public 떁([In] float obj0, [In] float obj1)
    {
      this.딟 = obj0;
      this.땄 = obj1;
    }

    public 떁([In] float obj0)
    {
      this.딟 = obj0;
      this.땄 = obj0;
    }

    [SpecialName]
    public static 떁 딟() => 떁.딟;

    [SpecialName]
    public static 떁 땄() => 떁.땄;

    [SpecialName]
    public static 떁 딧() => 떁.딧;

    [SpecialName]
    public static 떁 딢() => 떁.딢;

    public static void 딟([In] ref 떁 obj0, [In] ref 떁 obj1, out 떁 _param2)
    {
      float num = 떁.딶(obj0, obj1);
      _param2.딟 = obj0.딟 - 2f * num * obj1.딟;
      _param2.땄 = obj0.땄 - 2f * num * obj1.땄;
    }

    public static 떁 딟([In] 떁 obj0, [In] 떁 obj1)
    {
      떁 떁;
      떁.딟(ref obj0, ref obj1, out 떁);
      return 떁;
    }

    public static 떁 땄([In] 떁 obj0, [In] 떁 obj1)
    {
      obj0.딟 += obj1.딟;
      obj0.땄 += obj1.땄;
      return obj0;
    }

    public static void 땄([In] ref 떁 obj0, [In] ref 떁 obj1, out 떁 _param2)
    {
      _param2.딟 = obj0.딟 + obj1.딟;
      _param2.땄 = obj0.땄 + obj1.땄;
    }

    public static 떁 딟([In] 떁 obj0, [In] 떁 obj1, [In] 떁 obj2, [In] float obj3, [In] float obj4) => new 떁(딣.딟(obj0.딟, obj1.딟, obj2.딟, obj3, obj4), 딣.딟(obj0.땄, obj1.땄, obj2.땄, obj3, obj4));

    public static void 딟(
      [In] ref 떁 obj0,
      [In] ref 떁 obj1,
      [In] ref 떁 obj2,
      [In] float obj3,
      [In] float obj4,
      out 떁 _param5)
    {
      _param5 = new 떁(딣.딟(obj0.딟, obj1.딟, obj2.딟, obj3, obj4), 딣.딟(obj0.땄, obj1.땄, obj2.땄, obj3, obj4));
    }

    public static 떁 딟([In] 떁 obj0, [In] 떁 obj1, [In] 떁 obj2, [In] 떁 obj3, [In] float obj4) => new 떁(딣.땄(obj0.딟, obj1.딟, obj2.딟, obj3.딟, obj4), 딣.땄(obj0.땄, obj1.땄, obj2.땄, obj3.땄, obj4));

    public static void 딟(
      [In] ref 떁 obj0,
      [In] ref 떁 obj1,
      [In] ref 떁 obj2,
      [In] ref 떁 obj3,
      [In] float obj4,
      out 떁 _param5)
    {
      _param5 = new 떁(딣.땄(obj0.딟, obj1.딟, obj2.딟, obj3.딟, obj4), 딣.땄(obj0.땄, obj1.땄, obj2.땄, obj3.땄, obj4));
    }

    public static 떁 딟([In] 떁 obj0, [In] 떁 obj1, [In] 떁 obj2) => new 떁(딣.딟(obj0.딟, obj1.딟, obj2.딟), 딣.딟(obj0.땄, obj1.땄, obj2.땄));

    public static void 딟([In] ref 떁 obj0, [In] ref 떁 obj1, [In] ref 떁 obj2, out 떁 _param3) => _param3 = new 떁(딣.딟(obj0.딟, obj1.딟, obj2.딟), 딣.딟(obj0.땄, obj1.땄, obj2.땄));

    public static float 딧([In] 떁 obj0, [In] 떁 obj1)
    {
      float num;
      떁.땄(ref obj0, ref obj1, out num);
      return (float) Math.Sqrt((double) num);
    }

    public static void 딟([In] ref 떁 obj0, [In] ref 떁 obj1, out float _param2)
    {
      떁.땄(ref obj0, ref obj1, out _param2);
      _param2 = (float) Math.Sqrt((double) _param2);
    }

    public static float 딢([In] 떁 obj0, [In] 떁 obj1)
    {
      float num;
      떁.땄(ref obj0, ref obj1, out num);
      return num;
    }

    public static void 땄([In] ref 떁 obj0, [In] ref 떁 obj1, out float _param2) => _param2 = (float) (((double) obj0.딟 - (double) obj1.딟) * ((double) obj0.딟 - (double) obj1.딟) + ((double) obj0.땄 - (double) obj1.땄) * ((double) obj0.땄 - (double) obj1.땄));

    public static 떁 땃([In] 떁 obj0, [In] 떁 obj1)
    {
      obj0.딟 /= obj1.딟;
      obj0.땄 /= obj1.땄;
      return obj0;
    }

    public static void 딧([In] ref 떁 obj0, [In] ref 떁 obj1, out 떁 _param2)
    {
      _param2.딟 = obj0.딟 / obj1.딟;
      _param2.땄 = obj0.땄 / obj1.땄;
    }

    public static 떁 딟([In] 떁 obj0, [In] float obj1)
    {
      float num = 1f / obj1;
      obj0.딟 *= num;
      obj0.땄 *= num;
      return obj0;
    }

    public static void 딟([In] ref 떁 obj0, [In] float obj1, out 떁 _param2)
    {
      float num = 1f / obj1;
      _param2.딟 = obj0.딟 * num;
      _param2.땄 = obj0.땄 * num;
    }

    public static float 딶([In] 떁 obj0, [In] 떁 obj1) => (float) ((double) obj0.딟 * (double) obj1.딟 + (double) obj0.땄 * (double) obj1.땄);

    public static void 딧([In] ref 떁 obj0, [In] ref 떁 obj1, out float _param2) => _param2 = (float) ((double) obj0.딟 * (double) obj1.딟 + (double) obj0.땄 * (double) obj1.땄);

    public override bool Equals([In] object obj0) => obj0 is 떁 떁 && this == 떁;

    public bool Equals([In] 떁 obj0) => this == obj0;

    public override int GetHashCode() => (int) ((double) this.딟 + (double) this.땄);

    public static 떁 땄([In] 떁 obj0, [In] 떁 obj1, [In] 떁 obj2, [In] 떁 obj3, [In] float obj4)
    {
      떁 떁 = new 떁();
      떁.땄(ref obj0, ref obj1, ref obj2, ref obj3, obj4, out 떁);
      return 떁;
    }

    public static void 땄(
      [In] ref 떁 obj0,
      [In] ref 떁 obj1,
      [In] ref 떁 obj2,
      [In] ref 떁 obj3,
      [In] float obj4,
      out 떁 _param5)
    {
      _param5.딟 = 딣.딧(obj0.딟, obj1.딟, obj2.딟, obj3.딟, obj4);
      _param5.땄 = 딣.딧(obj0.땄, obj1.땄, obj2.땄, obj3.땄, obj4);
    }

    public float 땃()
    {
      float num;
      떁.땄(ref this, ref 떁.딟, out num);
      return (float) Math.Sqrt((double) num);
    }

    public float 딶()
    {
      float num;
      떁.땄(ref this, ref 떁.딟, out num);
      return num;
    }

    public static 떁 딟([In] 떁 obj0, [In] 떁 obj1, [In] float obj2) => new 떁(딣.땄(obj0.딟, obj1.딟, obj2), 딣.땄(obj0.땄, obj1.땄, obj2));

    public static void 딟([In] ref 떁 obj0, [In] ref 떁 obj1, [In] float obj2, out 떁 _param3) => _param3 = new 떁(딣.땄(obj0.딟, obj1.딟, obj2), 딣.땄(obj0.땄, obj1.땄, obj2));

    public static 떁 땓([In] 떁 obj0, [In] 떁 obj1) => new 떁(딣.땄(obj0.딟, obj1.딟), 딣.땄(obj0.땄, obj1.땄));

    public static void 딢([In] ref 떁 obj0, [In] ref 떁 obj1, out 떁 _param2) => _param2 = new 떁(딣.땄(obj0.딟, obj1.딟), 딣.땄(obj0.땄, obj1.땄));

    public static 떁 땺([In] 떁 obj0, [In] 떁 obj1) => new 떁(딣.딧(obj0.딟, obj1.딟), 딣.딧(obj0.땄, obj1.땄));

    public static void 땃([In] ref 떁 obj0, [In] ref 떁 obj1, out 떁 _param2) => _param2 = new 떁(딣.딧(obj0.딟, obj1.딟), 딣.딧(obj0.땄, obj1.땄));

    public static 떁 땥([In] 떁 obj0, [In] 떁 obj1)
    {
      obj0.딟 *= obj1.딟;
      obj0.땄 *= obj1.땄;
      return obj0;
    }

    public static 떁 땄([In] 떁 obj0, [In] float obj1)
    {
      obj0.딟 *= obj1;
      obj0.땄 *= obj1;
      return obj0;
    }

    public static void 땄([In] ref 떁 obj0, [In] float obj1, out 떁 _param2)
    {
      _param2.딟 = obj0.딟 * obj1;
      _param2.땄 = obj0.땄 * obj1;
    }

    public static void 딶([In] ref 떁 obj0, [In] ref 떁 obj1, out 떁 _param2)
    {
      _param2.딟 = obj0.딟 * obj1.딟;
      _param2.땄 = obj0.땄 * obj1.땄;
    }

    public static 떁 딟([In] 떁 obj0)
    {
      obj0.딟 = -obj0.딟;
      obj0.땄 = -obj0.땄;
      return obj0;
    }

    public static void 딟([In] ref 떁 obj0, out 떁 _param1)
    {
      _param1.딟 = -obj0.딟;
      _param1.땄 = -obj0.땄;
    }

    public void 땓() => 떁.땄(ref this, out this);

    public static 떁 땄([In] 떁 obj0)
    {
      떁.땄(ref obj0, out obj0);
      return obj0;
    }

    public static void 땄([In] ref 떁 obj0, out 떁 _param1)
    {
      float num1;
      떁.땄(ref obj0, ref 떁.딟, out num1);
      float num2 = 1f / (float) Math.Sqrt((double) num1);
      _param1.딟 = obj0.딟 * num2;
      _param1.땄 = obj0.땄 * num2;
    }

    public static 떁 땄([In] 떁 obj0, [In] 떁 obj1, [In] float obj2) => new 떁(딣.딧(obj0.딟, obj1.딟, obj2), 딣.딧(obj0.땄, obj1.땄, obj2));

    public static void 땄([In] ref 떁 obj0, [In] ref 떁 obj1, [In] float obj2, out 떁 _param3) => _param3 = new 떁(딣.딧(obj0.딟, obj1.딟, obj2), 딣.딧(obj0.땄, obj1.땄, obj2));

    public static 떁 딝([In] 떁 obj0, [In] 떁 obj1)
    {
      obj0.딟 -= obj1.딟;
      obj0.땄 -= obj1.땄;
      return obj0;
    }

    public static void 땓([In] ref 떁 obj0, [In] ref 떁 obj1, out 떁 _param2)
    {
      _param2.딟 = obj0.딟 - obj1.딟;
      _param2.땄 = obj0.땄 - obj1.땄;
    }

    public static 떁 딟([In] 떁 obj0, [In] 딷 obj1)
    {
      떁.딟(ref obj0, ref obj1, out obj0);
      return obj0;
    }

    public static void 딟([In] ref 떁 obj0, [In] ref 딷 obj1, out 떁 _param2) => _param2 = new 떁((float) ((double) obj0.딟 * (double) obj1.딟 + (double) obj0.땄 * (double) obj1.땃) + obj1.땭, (float) ((double) obj0.딟 * (double) obj1.땄 + (double) obj0.땄 * (double) obj1.딶) + obj1.딦);

    public static void 딟([In] 떁[] obj0, [In] ref 딷 obj1, [In] 떁[] obj2) => throw new NotImplementedException();

    public static void 딟([In] 떁[] obj0, [In] int obj1, [In] ref 딷 obj2, [In] 떁[] obj3, [In] int obj4, [In] int obj5) => throw new NotImplementedException();

    public static 떁 땄([In] 떁 obj0, [In] 딷 obj1)
    {
      떁.땄(ref obj0, ref obj1, out obj0);
      return obj0;
    }

    public static void 땄([In] ref 떁 obj0, [In] ref 딷 obj1, out 떁 _param2) => _param2 = new 떁((float) ((double) obj0.딟 * (double) obj1.딟 + (double) obj0.땄 * (double) obj1.땃), (float) ((double) obj0.딟 * (double) obj1.땄 + (double) obj0.땄 * (double) obj1.딶));

    public static void 땄([In] 떁[] obj0, [In] ref 딷 obj1, [In] 떁[] obj2) => throw new NotImplementedException();

    public static void 땄([In] 떁[] obj0, [In] int obj1, [In] ref 딷 obj2, [In] 떁[] obj3, [In] int obj4, [In] int obj5) => throw new NotImplementedException();

    public override string ToString()
    {
      StringBuilder stringBuilder = new StringBuilder(24);
      stringBuilder.Append("{X:");
      stringBuilder.Append(this.딟);
      stringBuilder.Append(" Y:");
      stringBuilder.Append(this.땄);
      stringBuilder.Append("}");
      return stringBuilder.ToString();
    }

    public static 떁 operator -([In] 떁 obj0)
    {
      obj0.딟 = -obj0.딟;
      obj0.땄 = -obj0.땄;
      return obj0;
    }

    public static bool operator ==([In] 떁 obj0, [In] 떁 obj1) => (double) obj0.딟 == (double) obj1.딟 && (double) obj0.땄 == (double) obj1.땄;

    public static bool operator !=([In] 떁 obj0, [In] 떁 obj1) => (double) obj0.딟 != (double) obj1.딟 || (double) obj0.땄 != (double) obj1.땄;

    public static 떁 operator +([In] 떁 obj0, [In] 떁 obj1)
    {
      obj0.딟 += obj1.딟;
      obj0.땄 += obj1.땄;
      return obj0;
    }

    public static 떁 operator -([In] 떁 obj0, [In] 떁 obj1)
    {
      obj0.딟 -= obj1.딟;
      obj0.땄 -= obj1.땄;
      return obj0;
    }

    public static 떁 operator *([In] 떁 obj0, [In] 떁 obj1)
    {
      obj0.딟 *= obj1.딟;
      obj0.땄 *= obj1.땄;
      return obj0;
    }

    public static 떁 operator *([In] 떁 obj0, [In] float obj1)
    {
      obj0.딟 *= obj1;
      obj0.땄 *= obj1;
      return obj0;
    }

    public static 떁 operator *([In] float obj0, [In] 떁 obj1)
    {
      obj1.딟 *= obj0;
      obj1.땄 *= obj0;
      return obj1;
    }

    public static 떁 operator /([In] 떁 obj0, [In] 떁 obj1)
    {
      obj0.딟 /= obj1.딟;
      obj0.땄 /= obj1.땄;
      return obj0;
    }

    public static 떁 operator /([In] 떁 obj0, [In] float obj1)
    {
      float num = 1f / obj1;
      obj0.딟 *= num;
      obj0.땄 *= num;
      return obj0;
    }
  }
}
