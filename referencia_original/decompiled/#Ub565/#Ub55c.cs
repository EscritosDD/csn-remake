// Decompiled with JetBrains decompiler
// Type: 땥.땜
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 땥
{
  public static class 땜
  {
    private static bool[] 딟;
    private static double 딟;

    public static 땨 딟([In] 땨 obj0, [In] float obj1)
    {
      if (obj0.Count < 3)
        return obj0;
      땨 땨 = new 땨();
      for (int index1 = 0; index1 < obj0.Count; ++index1)
      {
        int index2 = obj0.딧(index1);
        int index3 = obj0.딟(index1);
        떁 떁1 = obj0[index2];
        떁 떁2 = obj0[index1];
        떁 떁3 = obj0[index3];
        if (!땴.딟(ref 떁1, ref 떁2, ref 떁3, obj1))
          땨.Add(떁2);
      }
      return 땨;
    }

    public static 땨 딟([In] 땨 obj0) => 땜.딟(obj0, 0.0f);

    public static 땨 땄([In] 땨 obj0, [In] float obj1)
    {
      땜.딟 = (double) obj1;
      땜.딟 = new bool[obj0.Count];
      for (int index = 0; index < obj0.Count; ++index)
        땜.딟[index] = true;
      땜.딟(obj0, 0, obj0.Count - 1);
      땨 땨 = new 땨();
      for (int index = 0; index < obj0.Count; ++index)
      {
        if (땜.딟[index])
          땨.Add(obj0[index]);
      }
      return 땨;
    }

    private static void 딟([In] 땨 obj0, [In] int obj1, [In] int obj2)
    {
      if (obj1 + 1 == obj2)
        return;
      떁 떁1 = obj0[obj1];
      떁 떁2 = obj0[obj2];
      double num1 = -1.0;
      int num2 = obj1;
      for (int index = obj1 + 1; index < obj2; ++index)
      {
        double num3 = 땜.딟(obj0[index], 떁1, 떁2);
        if (num3 > num1)
        {
          num1 = num3;
          num2 = index;
        }
      }
      if (num1 <= 땜.딟)
      {
        for (int index = obj1 + 1; index < obj2; ++index)
          땜.딟[index] = false;
      }
      else
      {
        땜.딟(obj0, obj1, num2);
        땜.딟(obj0, num2, obj2);
      }
    }

    private static double 딟([In] 떁 obj0, [In] 떁 obj1)
    {
      double num1 = (double) obj0.딟 - (double) obj1.딟;
      double num2 = (double) obj0.땄 - (double) obj1.딟;
      return Math.Sqrt(num1 * num1 + num2 * num2);
    }

    private static double 딟([In] 떁 obj0, [In] 떁 obj1, [In] 떁 obj2)
    {
      if ((double) obj1.딟 == (double) obj2.딟 && (double) obj1.땄 == (double) obj2.땄)
        return 땜.딟(obj0, obj1);
      double num = (((double) obj0.딟 - (double) obj1.딟) * ((double) obj2.딟 - (double) obj1.딟) + ((double) obj0.땄 - (double) obj1.땄) * ((double) obj2.땄 - (double) obj1.땄)) / (((double) obj2.딟 - (double) obj1.딟) * ((double) obj2.딟 - (double) obj1.딟) + ((double) obj2.땄 - (double) obj1.땄) * ((double) obj2.땄 - (double) obj1.땄));
      if (num <= 0.0)
        return 땜.딟(obj0, obj1);
      return num >= 1.0 ? 땜.딟(obj0, obj2) : Math.Abs((((double) obj1.땄 - (double) obj0.땄) * ((double) obj2.딟 - (double) obj1.딟) - ((double) obj1.딟 - (double) obj0.딟) * ((double) obj2.땄 - (double) obj1.땄)) / (((double) obj2.딟 - (double) obj1.딟) * ((double) obj2.딟 - (double) obj1.딟) + ((double) obj2.땄 - (double) obj1.땄) * ((double) obj2.땄 - (double) obj1.땄))) * Math.Sqrt(((double) obj2.딟 - (double) obj1.딟) * ((double) obj2.딟 - (double) obj1.딟) + ((double) obj2.땄 - (double) obj1.땄) * ((double) obj2.땄 - (double) obj1.땄));
    }

    public static 땨 딧([In] 땨 obj0, [In] float obj1)
    {
      if (obj0.Count <= 3)
        return obj0;
      if ((double) obj1 < 0.0)
        throw new ArgumentOutOfRangeException("areaTolerance", "must be equal to or greater then zero.");
      땨 땨 = new 땨();
      떁 떁1 = obj0[obj0.Count - 2];
      떁 떁2 = obj0[obj0.Count - 1];
      obj1 *= 2f;
      int index = 0;
      while (index < obj0.Count)
      {
        떁 떁3;
        if (index == obj0.Count - 1)
          떁3 = 땨.Count != 0 ? 땨[0] : throw new ArgumentOutOfRangeException("areaTolerance", "The tolerance is too high!");
        else
          떁3 = obj0[index];
        float num1;
        땴.딟(ref 떁1, ref 떁2, out num1);
        float num2;
        땴.딟(ref 떁2, ref 떁3, out num2);
        float num3;
        땴.딟(ref 떁1, ref 떁3, out num3);
        if ((double) Math.Abs(num3 - (num1 + num2)) > (double) obj1)
        {
          땨.Add(떁2);
          떁1 = 떁2;
        }
        ++index;
        떁2 = 떁3;
      }
      return 땨;
    }

    public static void 딢([In] 땨 obj0, [In] float obj1)
    {
      if (obj0.Count <= 3)
        return;
      bool[] flagArray = new bool[obj0.Count];
      int count = obj0.Count;
      for (int index1 = 0; index1 < obj0.Count; ++index1)
      {
        int index2 = index1 != 0 ? index1 - 1 : obj0.Count - 1;
        int index3 = index1;
        int index4 = index1 != obj0.Count - 1 ? index1 + 1 : 0;
        float num1 = obj0[index3].딟 - obj0[index2].딟;
        float num2 = obj0[index3].땄 - obj0[index2].땄;
        float num3 = obj0[index4].땄 - obj0[index3].딟;
        float num4 = obj0[index4].땄 - obj0[index3].땄;
        float num5 = (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2);
        float num6 = (float) Math.Sqrt((double) num3 * (double) num3 + (double) num4 * (double) num4);
        if (((double) num5 <= 0.0 || (double) num6 <= 0.0) && count > 3)
        {
          flagArray[index1] = true;
          --count;
        }
        float num7 = num1 / num5;
        float num8 = num2 / num5;
        float num9 = num3 / num6;
        float num10 = num4 / num6;
        float num11 = (float) ((double) num7 * (double) num10 - (double) num9 * (double) num8);
        float num12 = (float) ((double) num7 * (double) num9 + (double) num8 * (double) num10);
        if ((double) Math.Abs(num11) < (double) obj1 && (double) num12 > 0.0 && count > 3)
        {
          flagArray[index1] = true;
          --count;
        }
        else
          flagArray[index1] = false;
      }
      if (count == obj0.Count || count == 0)
        return;
      int num = 0;
      땨 땨 = new 땨((IList<떁>) obj0);
      obj0.Clear();
      for (int index = 0; index < 땨.Count; ++index)
      {
        if (!flagArray[index] && count != 0 && num != count)
        {
          obj0.Add(땨[index]);
          ++num;
        }
      }
    }

    public static 땨 땄([In] 땨 obj0)
    {
      HashSet<떁> 떁Set = new HashSet<떁>();
      for (int index = 0; index < obj0.Count; ++index)
        떁Set.Add(obj0[index]);
      땨 땨 = new 땨();
      foreach (떁 떁 in 떁Set)
        땨.Add(떁);
      return 땨;
    }

    public static 땨 땃([In] 땨 obj0, [In] float obj1)
    {
      if (obj0.Count < 3)
        return obj0;
      땨 땨 = new 땨();
      for (int index = 0; index < obj0.Count; ++index)
      {
        떁 떁 = obj0[index];
        if ((double) (obj0.땄(index) - 떁).딶() > (double) obj1)
          땨.Add(떁);
      }
      return 땨;
    }

    public static 땨 딟([In] 땨 obj0, [In] int obj1)
    {
      if (obj0.Count < 3 || obj1 == 0)
        return obj0;
      땨 땨 = new 땨(obj0.Count);
      for (int index = 0; index < obj0.Count; ++index)
      {
        if (index % obj1 != 0)
          땨.Add(obj0[index]);
      }
      return 땨;
    }
  }
}
