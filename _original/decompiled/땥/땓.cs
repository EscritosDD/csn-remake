// Decompiled with JetBrains decompiler
// Type: 땥.땓
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 땥
{
  public static class 땓
  {
    private const float 딟 = 0.001f;

    public static List<땨> 딟([In] 땨 obj0) => 땓.딟(obj0, int.MaxValue, 0.0f);

    public static List<땨> 딟([In] 땨 obj0, [In] int obj1, [In] float obj2)
    {
      if (obj0.Count < 3)
        return new List<땨>() { obj0 };
      List<땺> 땺List;
      if (obj0.땓())
      {
        땨 땨 = new 땨((IList<떁>) obj0);
        땨.Reverse();
        땺List = 땓.땄(땨);
      }
      else
        땺List = 땓.땄(obj0);
      if (땺List.Count < 1)
        throw new Exception("Can't triangulate your polygon.");
      List<땨> 땨List = 땓.딟(땺List, obj1, obj2);
      for (int index = 0; index < 땨List.Count; ++index)
        땨List[index] = 땜.딟(땨List[index], 0.0f);
      for (int index = 땨List.Count - 1; index >= 0; --index)
      {
        if (땨List[index].Count == 0)
          땨List.RemoveAt(index);
      }
      return 땨List;
    }

    public static List<땨> 딟([In] List<땺> obj0, [In] int obj1, [In] float obj2)
    {
      List<땨> 땨List = new List<땨>(50);
      int num1 = 0;
      if (obj0.Count <= 0)
        return 땨List;
      bool[] flagArray = new bool[obj0.Count];
      for (int index = 0; index < obj0.Count; ++index)
      {
        flagArray[index] = false;
        if ((double) obj0[index].딟[0] == (double) obj0[index].딟[1] && (double) obj0[index].땄[0] == (double) obj0[index].땄[1] || (double) obj0[index].딟[1] == (double) obj0[index].딟[2] && (double) obj0[index].땄[1] == (double) obj0[index].땄[2] || (double) obj0[index].딟[0] == (double) obj0[index].딟[2] && (double) obj0[index].땄[0] == (double) obj0[index].땄[2])
          flagArray[index] = true;
      }
      bool flag = true;
      while (flag)
      {
        int index1 = -1;
        for (int index2 = 0; index2 < obj0.Count; ++index2)
        {
          if (!flagArray[index2])
          {
            index1 = index2;
            break;
          }
        }
        if (index1 == -1)
        {
          flag = false;
        }
        else
        {
          땨 땨1 = new 땨(3);
          for (int index3 = 0; index3 < 3; ++index3)
            땨1.Add(new 떁(obj0[index1].딟[index3], obj0[index1].땄[index3]));
          flagArray[index1] = true;
          int index4 = 0;
          int num2 = 0;
          while (num2 < 2 * obj0.Count)
          {
            while (index4 >= obj0.Count)
              index4 -= obj0.Count;
            if (!flagArray[index4])
            {
              땨 땨2 = 땓.딟(obj0[index4], 땨1);
              if (땨2 != null && 땨2.Count <= 딝.땥.땺 && 땨2.딶())
              {
                땨1 = new 땨((IList<떁>) 땨2);
                flagArray[index4] = true;
              }
            }
            ++num2;
            ++index4;
          }
          if (num1 < obj1 && 땨1.Count >= 3)
            땨List.Add(new 땨((IList<떁>) 땨1));
          if (땨1.Count >= 3)
            ++num1;
        }
      }
      return 땨List;
    }

    public static List<땺> 땄([In] 땨 obj0)
    {
      List<땺> 땺List1 = new List<땺>();
      if (obj0.Count < 3)
        return new List<땺>();
      땨 땨1;
      땨 땨2;
      if (땓.딟(new 땨((IList<떁>) obj0), out 땨1, out 땨2))
      {
        List<땺> 땺List2 = 땓.땄(땨1);
        List<땺> 땺List3 = 땓.땄(땨2);
        if (땺List2.Count == -1 || 땺List3.Count == -1)
          throw new Exception("Can't triangulate your polygon.");
        for (int index = 0; index < 땺List2.Count; ++index)
          땺List1.Add(new 땺(땺List2[index]));
        for (int index = 0; index < 땺List3.Count; ++index)
          땺List1.Add(new 땺(땺List3[index]));
        return 땺List1;
      }
      땺[] 땺Array = new 땺[obj0.Count - 2];
      int index1 = 0;
      float[] numArray1 = new float[obj0.Count];
      float[] numArray2 = new float[obj0.Count];
      for (int index2 = 0; index2 < obj0.Count; ++index2)
      {
        numArray1[index2] = obj0[index2].딟;
        numArray2[index2] = obj0[index2].땄;
      }
      int count = obj0.Count;
      while (count > 3)
      {
        int index3 = -1;
        float num1 = -10f;
        for (int index4 = 0; index4 < count; ++index4)
        {
          if (땓.딟(index4, numArray1, numArray2, count))
          {
            int index5 = 땓.딟(index4 - 1, count);
            int index6 = 땓.딟(index4 + 1, count);
            떁 떁1 = new 떁(numArray1[index6] - numArray1[index4], numArray2[index6] - numArray2[index4]);
            떁 떁2 = new 떁(numArray1[index4] - numArray1[index5], numArray2[index4] - numArray2[index5]);
            떁 떁3 = new 떁(numArray1[index5] - numArray1[index6], numArray2[index5] - numArray2[index6]);
            떁1.땓();
            떁2.땓();
            떁3.땓();
            float val1_1;
            땴.딟(ref 떁1, ref 떁2, out val1_1);
            val1_1 = Math.Abs(val1_1);
            float val1_2;
            땴.딟(ref 떁2, ref 떁3, out val1_2);
            val1_2 = Math.Abs(val1_2);
            float val2;
            땴.딟(ref 떁3, ref 떁1, out val2);
            val2 = Math.Abs(val2);
            float num2 = Math.Min(val1_1, Math.Min(val1_2, val2));
            if ((double) num2 > (double) num1)
            {
              index3 = index4;
              num1 = num2;
            }
          }
        }
        if (index3 == -1)
        {
          for (int index7 = 0; index7 < index1; ++index7)
            땺List1.Add(new 땺(땺Array[index7]));
          return 땺List1;
        }
        --count;
        float[] numArray3 = new float[count];
        float[] numArray4 = new float[count];
        int index8 = 0;
        for (int index9 = 0; index9 < count; ++index9)
        {
          if (index8 == index3)
            ++index8;
          numArray3[index9] = numArray1[index8];
          numArray4[index9] = numArray2[index8];
          ++index8;
        }
        int index10 = index3 != 0 ? index3 - 1 : count;
        int index11 = index3 != count ? index3 + 1 : 0;
        땺 땺 = new 땺(numArray1[index3], numArray2[index3], numArray1[index11], numArray2[index11], numArray1[index10], numArray2[index10]);
        땺Array[index1] = 땺;
        ++index1;
        numArray1 = numArray3;
        numArray2 = numArray4;
      }
      땺 땺1 = new 땺(numArray1[1], numArray2[1], numArray1[2], numArray2[2], numArray1[0], numArray2[0]);
      땺Array[index1] = 땺1;
      int num = index1 + 1;
      for (int index12 = 0; index12 < num; ++index12)
        땺List1.Add(new 땺(땺Array[index12]));
      return 땺List1;
    }

    private static bool 딟([In] 땨 obj0, out 땨 _param1, out 땨 _param2)
    {
      _param1 = new 땨();
      _param2 = new 땨();
      if (obj0.Count < 3)
        return false;
      bool flag = false;
      int num1 = -1;
      int num2 = -1;
      for (int index1 = 0; index1 < obj0.Count; ++index1)
      {
        for (int index2 = index1 + 1; index2 < obj0.Count; ++index2)
        {
          if ((double) Math.Abs(obj0[index1].딟 - obj0[index2].딟) < 1.0 / 1000.0 && (double) Math.Abs(obj0[index1].땄 - obj0[index2].땄) < 1.0 / 1000.0 && index2 != index1 + 1)
          {
            num1 = index1;
            num2 = index2;
            flag = true;
            break;
          }
        }
        if (flag)
          break;
      }
      if (flag)
      {
        int num3 = num2 - num1;
        if (num3 == obj0.Count)
          return false;
        for (int index3 = 0; index3 < num3; ++index3)
        {
          int index4 = 땓.딟(num1 + index3, obj0.Count);
          _param1.Add(obj0[index4]);
        }
        int num4 = obj0.Count - num3;
        for (int index5 = 0; index5 < num4; ++index5)
        {
          int index6 = 땓.딟(num2 + index5, obj0.Count);
          _param2.Add(obj0[index6]);
        }
      }
      return flag;
    }

    private static int 딟([In] int obj0, [In] int obj1)
    {
      int num = obj0 % obj1;
      while (num < 0)
        num += obj1;
      return num;
    }

    private static 땨 딟([In] 땺 obj0, [In] 땨 obj1)
    {
      int num1 = -1;
      int num2 = -1;
      int num3 = -1;
      int num4 = -1;
      for (int index = 0; index < obj1.Count; ++index)
      {
        if ((double) obj0.딟[0] == (double) obj1[index].딟 && (double) obj0.땄[0] == (double) obj1[index].땄)
        {
          if (num1 == -1)
          {
            num1 = index;
            num2 = 0;
          }
          else
          {
            num3 = index;
            num4 = 0;
          }
        }
        else if ((double) obj0.딟[1] == (double) obj1[index].딟 && (double) obj0.땄[1] == (double) obj1[index].땄)
        {
          if (num1 == -1)
          {
            num1 = index;
            num2 = 1;
          }
          else
          {
            num3 = index;
            num4 = 1;
          }
        }
        else if ((double) obj0.딟[2] == (double) obj1[index].딟 && (double) obj0.땄[2] == (double) obj1[index].땄)
        {
          if (num1 == -1)
          {
            num1 = index;
            num2 = 2;
          }
          else
          {
            num3 = index;
            num4 = 2;
          }
        }
      }
      if (num1 == 0 && num3 == obj1.Count - 1)
      {
        num1 = obj1.Count - 1;
        num3 = 0;
      }
      if (num3 == -1)
        return (땨) null;
      int index1 = 0;
      if (index1 == num2 || index1 == num4)
        index1 = 1;
      if (index1 == num2 || index1 == num4)
        index1 = 2;
      땨 땨 = new 땨(obj1.Count + 1);
      for (int index2 = 0; index2 < obj1.Count; ++index2)
      {
        땨.Add(obj1[index2]);
        if (index2 == num1)
          땨.Add(new 떁(obj0.딟[index1], obj0.땄[index1]));
      }
      return 땨;
    }

    private static bool 딟([In] int obj0, [In] float[] obj1, [In] float[] obj2, [In] int obj3)
    {
      if (obj0 >= obj3 || obj0 < 0 || obj3 < 3)
        return false;
      int index1 = obj0 + 1;
      int index2 = obj0 - 1;
      float num1;
      float num2;
      float num3;
      float num4;
      if (obj0 == 0)
      {
        num1 = obj1[0] - obj1[obj3 - 1];
        num2 = obj2[0] - obj2[obj3 - 1];
        num3 = obj1[1] - obj1[0];
        num4 = obj2[1] - obj2[0];
        index2 = obj3 - 1;
      }
      else if (obj0 == obj3 - 1)
      {
        num1 = obj1[obj0] - obj1[obj0 - 1];
        num2 = obj2[obj0] - obj2[obj0 - 1];
        num3 = obj1[0] - obj1[obj0];
        num4 = obj2[0] - obj2[obj0];
        index1 = 0;
      }
      else
      {
        num1 = obj1[obj0] - obj1[obj0 - 1];
        num2 = obj2[obj0] - obj2[obj0 - 1];
        num3 = obj1[obj0 + 1] - obj1[obj0];
        num4 = obj2[obj0 + 1] - obj2[obj0];
      }
      if ((double) num1 * (double) num4 - (double) num3 * (double) num2 > 0.0)
        return false;
      땺 땺 = new 땺(obj1[obj0], obj2[obj0], obj1[index1], obj2[index1], obj1[index2], obj2[index2]);
      for (int index3 = 0; index3 < obj3; ++index3)
      {
        if (index3 != obj0 && index3 != index2 && index3 != index1 && 땺.딟(obj1[index3], obj2[index3]))
          return false;
      }
      return true;
    }
  }
}
