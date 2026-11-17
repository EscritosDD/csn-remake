// Decompiled with JetBrains decompiler
// Type: 땥.딾
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 땥
{
  public static class 딾
  {
    public static 땨 딟([In] float obj0, [In] float obj1)
    {
      땨 땨 = new 땨(4);
      땨.Add(new 떁(-obj0, -obj1));
      땨.Add(new 떁(obj0, -obj1));
      땨.Add(new 떁(obj0, obj1));
      땨.Add(new 떁(-obj0, obj1));
      return 땨;
    }

    public static 땨 딟([In] float obj0, [In] float obj1, [In] 떁 obj2, [In] float obj3)
    {
      땨 땨 = 딾.딟(obj0, obj1);
      떓 떓 = new 떓();
      떓.딟 = obj2;
      떓.딟.딟(obj3);
      for (int index = 0; index < 4; ++index)
        땨[index] = 땴.딟(ref 떓, 땨[index]);
      return 땨;
    }

    public static 땨 딟([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3, [In] int obj4)
    {
      if ((double) obj3 > (double) obj1 / 2.0 || (double) obj2 > (double) obj0 / 2.0)
        throw new Exception("Rounding amount can't be more than half the height and width respectively.");
      if (obj4 < 0)
        throw new Exception("Segments must be zero or more.");
      땨 땨 = new 땨();
      if (obj4 == 0)
      {
        땨.Add(new 떁(obj0 * 0.5f - obj2, (float) (-(double) obj1 * 0.5)));
        땨.Add(new 떁(obj0 * 0.5f, (float) (-(double) obj1 * 0.5) + obj3));
        땨.Add(new 떁(obj0 * 0.5f, obj1 * 0.5f - obj3));
        땨.Add(new 떁(obj0 * 0.5f - obj2, obj1 * 0.5f));
        땨.Add(new 떁((float) (-(double) obj0 * 0.5) + obj2, obj1 * 0.5f));
        땨.Add(new 떁((float) (-(double) obj0 * 0.5), obj1 * 0.5f - obj3));
        땨.Add(new 떁((float) (-(double) obj0 * 0.5), (float) (-(double) obj1 * 0.5) + obj3));
        땨.Add(new 떁((float) (-(double) obj0 * 0.5) + obj2, (float) (-(double) obj1 * 0.5)));
      }
      else
      {
        int num1 = obj4 * 4 + 8;
        float num2 = 6.283185f / (float) (num1 - 4);
        int num3 = num1 / 4;
        떁 떁 = new 떁(obj0 / 2f - obj2, obj1 / 2f - obj3);
        땨.Add(떁 + new 떁(obj2, -obj3 + obj3));
        short num4 = 0;
        for (int index = 1; index < num1; ++index)
        {
          if (index - num3 == 0 || index - num3 * 3 == 0)
          {
            떁.딟 *= -1f;
            --num4;
          }
          else if (index - num3 * 2 == 0)
          {
            떁.땄 *= -1f;
            --num4;
          }
          땨.Add(떁 + new 떁(obj2 * (float) Math.Cos((double) num2 * (double) -(index + (int) num4)), -obj3 * (float) Math.Sin((double) num2 * (double) -(index + (int) num4))));
        }
      }
      return 땨;
    }

    public static 땨 딟([In] 떁 obj0, [In] 떁 obj1)
    {
      땨 땨 = new 땨(2);
      땨.Add(obj0);
      땨.Add(obj1);
      return 땨;
    }

    public static 땨 딟([In] float obj0, [In] int obj1) => 딾.딟(obj0, obj0, obj1);

    public static 땨 딟([In] float obj0, [In] float obj1, [In] int obj2)
    {
      땨 땨 = new 땨();
      float num = 6.283185f / (float) obj2;
      땨.Add(new 떁(obj0, 0.0f));
      for (int index = obj2 - 1; index > 0; --index)
        땨.Add(new 떁(obj0 * (float) Math.Cos((double) num * (double) index), -obj1 * (float) Math.Sin((double) num * (double) index)));
      return 땨;
    }

    public static 땨 딟([In] float obj0, [In] int obj1, [In] float obj2)
    {
      땨 땨 = new 땨();
      float num = obj0 / (float) obj1;
      for (int index = obj1 - 1; index > 0; --index)
        땨.Add(new 떁(obj2 * (float) Math.Cos((double) num * (double) index), obj2 * (float) Math.Sin((double) num * (double) index)));
      return 땨;
    }

    public static 땨 땄([In] float obj0, [In] float obj1, [In] int obj2)
    {
      if ((double) obj1 >= (double) obj0 / 2.0)
        throw new ArgumentException("The radius must be lower than height / 2. Higher values of radius would create a circle, and not a half circle.", "endRadius");
      return 딾.딟(obj0, obj1, obj2, obj1, obj2);
    }

    public static 땨 딟([In] float obj0, [In] float obj1, [In] int obj2, [In] float obj3, [In] int obj4)
    {
      if ((double) obj0 <= 0.0)
        throw new ArgumentException("Height must be longer than 0", "height");
      if ((double) obj1 <= 0.0)
        throw new ArgumentException("The top radius must be more than 0", "topRadius");
      if (obj2 <= 0)
        throw new ArgumentException("Top edges must be more than 0", "topEdges");
      if ((double) obj3 <= 0.0)
        throw new ArgumentException("The bottom radius must be more than 0", "bottomRadius");
      if (obj4 <= 0)
        throw new ArgumentException("Bottom edges must be more than 0", "bottomEdges");
      if ((double) obj1 >= (double) obj0 / 2.0)
        throw new ArgumentException("The top radius must be lower than height / 2. Higher values of top radius would create a circle, and not a half circle.", "topRadius");
      if ((double) obj3 >= (double) obj0 / 2.0)
        throw new ArgumentException("The bottom radius must be lower than height / 2. Higher values of bottom radius would create a circle, and not a half circle.", "bottomRadius");
      땨 땨 = new 땨();
      float num1 = (float) (((double) obj0 - (double) obj1 - (double) obj3) * 0.5);
      땨.Add(new 떁(obj1, num1));
      float num2 = 3.141593f / (float) obj2;
      for (int index = 1; index < obj2; ++index)
        땨.Add(new 떁(obj1 * (float) Math.Cos((double) num2 * (double) index), obj1 * (float) Math.Sin((double) num2 * (double) index) + num1));
      땨.Add(new 떁(-obj1, num1));
      땨.Add(new 떁(-obj3, -num1));
      float num3 = 3.141593f / (float) obj4;
      for (int index = 1; index < obj4; ++index)
        땨.Add(new 떁(-obj3 * (float) Math.Cos((double) num3 * (double) index), -obj3 * (float) Math.Sin((double) num3 * (double) index) - num1));
      땨.Add(new 떁(obj3, -num1));
      return 땨;
    }

    public static 땨 딟([In] float obj0, [In] int obj1, [In] float obj2, [In] float obj3)
    {
      땨 땨 = new 땨();
      float num1 = 6.283185f / (float) obj1;
      obj2 /= 100f;
      double num2 = (double) 딣.딟(obj2, 0.0f, 1f);
      float num3 = num1 / 2f * obj2;
      float num4 = (float) (((double) num1 - (double) num3 * 2.0) / 2.0);
      for (int index = obj1 - 1; index >= 0; --index)
      {
        if ((double) num3 > 0.0)
        {
          땨.Add(new 떁(obj0 * (float) Math.Cos((double) num1 * (double) index + (double) num4 * 2.0 + (double) num3), -obj0 * (float) Math.Sin((double) num1 * (double) index + (double) num4 * 2.0 + (double) num3)));
          땨.Add(new 떁((obj0 + obj3) * (float) Math.Cos((double) num1 * (double) index + (double) num4 + (double) num3), (float) -((double) obj0 + (double) obj3) * (float) Math.Sin((double) num1 * (double) index + (double) num4 + (double) num3)));
        }
        땨.Add(new 떁((obj0 + obj3) * (float) Math.Cos((double) num1 * (double) index + (double) num4), (float) -((double) obj0 + (double) obj3) * (float) Math.Sin((double) num1 * (double) index + (double) num4)));
        땨.Add(new 떁(obj0 * (float) Math.Cos((double) num1 * (double) index), -obj0 * (float) Math.Sin((double) num1 * (double) index)));
      }
      return 땨;
    }

    public static 땨 딟([In] uint[] obj0, [In] int obj1) => 땯.땄(obj0, obj1);

    public static 땨 딟([In] uint[] obj0, [In] int obj1, [In] bool obj2) => 땯.딟(obj0, obj1, obj2);

    public static List<땨> 딟(
      [In] uint[] obj0,
      [In] int obj1,
      [In] float obj2,
      [In] byte obj3,
      [In] bool obj4,
      [In] bool obj5)
    {
      return 땯.딟(obj0, obj1, obj2, obj3, obj4, obj5);
    }
  }
}
