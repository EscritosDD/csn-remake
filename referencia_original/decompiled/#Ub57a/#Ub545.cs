// Decompiled with JetBrains decompiler
// Type: 땺.땅
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using 땥;

namespace 땺
{
  public static class 땅
  {
    private static 떁 딟([In] int obj0, [In] 땨 obj1)
    {
      int count = obj1.Count;
      int index1 = obj0 >= 0 ? obj0 % count : count - -obj0 % count;
      int index2 = count - 1;
      if (index1 > index2)
        return obj1[index2];
      return index1 < 0 ? obj1[0] : obj1[index1];
    }

    private static 땨 딟([In] int obj0, [In] int obj1, [In] 땨 obj2)
    {
      땨 땨 = new 땨();
      while (obj1 < obj0)
        obj1 += obj2.Count;
      for (; obj0 <= obj1; ++obj0)
        땨.Add(땅.딟(obj0, obj2));
      return 땨;
    }

    public static List<땨> 딟([In] 땨 obj0)
    {
      obj0.땺();
      List<땨> 땨List = new List<땨>();
      떁 떁1 = new 떁();
      떁 떁2 = new 떁();
      int num1 = 0;
      int num2 = 0;
      for (int index1 = 0; index1 < obj0.Count; ++index1)
      {
        if (땅.땄(index1, obj0))
        {
          float num3;
          float num4 = num3 = float.MaxValue;
          for (int index2 = 0; index2 < obj0.Count; ++index2)
          {
            if (땅.딟(땅.딟(index1 - 1, obj0), 땅.딟(index1, obj0), 땅.딟(index2, obj0)) && 땅.딢(땅.딟(index1 - 1, obj0), 땅.딟(index1, obj0), 땅.딟(index2 - 1, obj0)))
            {
              떁 떁3 = 땥.땠.딟(땅.딟(index1 - 1, obj0), 땅.딟(index1, obj0), 땅.딟(index2, obj0), 땅.딟(index2 - 1, obj0));
              if (땅.딧(땅.딟(index1 + 1, obj0), 땅.딟(index1, obj0), 떁3))
              {
                float num5 = 땅.딟(땅.딟(index1, obj0), 떁3);
                if ((double) num5 < (double) num4)
                {
                  num4 = num5;
                  떁1 = 떁3;
                  num1 = index2;
                }
              }
            }
            if (땅.딟(땅.딟(index1 + 1, obj0), 땅.딟(index1, obj0), 땅.딟(index2 + 1, obj0)) && 땅.딢(땅.딟(index1 + 1, obj0), 땅.딟(index1, obj0), 땅.딟(index2, obj0)))
            {
              떁 떁4 = 땥.땠.딟(땅.딟(index1 + 1, obj0), 땅.딟(index1, obj0), 땅.딟(index2, obj0), 땅.딟(index2 + 1, obj0));
              if (땅.딟(땅.딟(index1 - 1, obj0), 땅.딟(index1, obj0), 떁4))
              {
                float num6 = 땅.딟(땅.딟(index1, obj0), 떁4);
                if ((double) num6 < (double) num3)
                {
                  num3 = num6;
                  num2 = index2;
                  떁2 = 떁4;
                }
              }
            }
          }
          땨 땨1;
          땨 땨2;
          if (num1 == (num2 + 1) % obj0.Count)
          {
            떁 떁5 = (떁1 + 떁2) / 2f;
            땨1 = 땅.딟(index1, num2, obj0);
            땨1.Add(떁5);
            땨2 = 땅.딟(num1, index1, obj0);
            땨2.Add(떁5);
          }
          else
          {
            double num7 = 0.0;
            double num8 = (double) num1;
            while (num2 < num1)
              num2 += obj0.Count;
            for (int index3 = num1; index3 <= num2; ++index3)
            {
              if (땅.땄(index1, index3, obj0))
              {
                double num9 = 1.0 / ((double) 땅.딟(땅.딟(index1, obj0), 땅.딟(index3, obj0)) + 1.0);
                double num10 = !땅.땄(index3, obj0) ? num9 + 1.0 : (!땅.딢(땅.딟(index3 - 1, obj0), 땅.딟(index3, obj0), 땅.딟(index1, obj0)) || !땅.땄(땅.딟(index3 + 1, obj0), 땅.딟(index3, obj0), 땅.딟(index1, obj0)) ? num9 + 2.0 : num9 + 3.0);
                if (num10 > num7)
                {
                  num8 = (double) index3;
                  num7 = num10;
                }
              }
            }
            땨1 = 땅.딟(index1, (int) num8, obj0);
            땨2 = 땅.딟((int) num8, index1, obj0);
          }
          땨List.AddRange((IEnumerable<땨>) 땅.딟(땨1));
          땨List.AddRange((IEnumerable<땨>) 땅.딟(땨2));
          return 땨List;
        }
      }
      if (obj0.Count > 딝.땥.땺)
      {
        땨 땨3 = 땅.딟(0, obj0.Count / 2, obj0);
        땨 땨4 = 땅.딟(obj0.Count / 2, 0, obj0);
        땨List.AddRange((IEnumerable<땨>) 땅.딟(땨3));
        땨List.AddRange((IEnumerable<땨>) 땅.딟(땨4));
      }
      else
        땨List.Add(obj0);
      for (int index = 0; index < 땨List.Count; ++index)
        땨List[index] = 땥.땜.딟(땨List[index], 0.0f);
      for (int index = 땨List.Count - 1; index >= 0; --index)
      {
        if (땨List[index].Count == 0)
          땨List.RemoveAt(index);
      }
      return 땨List;
    }

    private static bool 땄([In] int obj0, [In] int obj1, [In] 땨 obj2)
    {
      if (땅.땄(obj0, obj2))
      {
        if (땅.땄(땅.딟(obj0, obj2), 땅.딟(obj0 - 1, obj2), 땅.딟(obj1, obj2)) && 땅.딢(땅.딟(obj0, obj2), 땅.딟(obj0 + 1, obj2), 땅.딟(obj1, obj2)))
          return false;
      }
      else if (땅.딢(땅.딟(obj0, obj2), 땅.딟(obj0 + 1, obj2), 땅.딟(obj1, obj2)) || 땅.땄(땅.딟(obj0, obj2), 땅.딟(obj0 - 1, obj2), 땅.딟(obj1, obj2)))
        return false;
      if (땅.땄(obj1, obj2))
      {
        if (땅.땄(땅.딟(obj1, obj2), 땅.딟(obj1 - 1, obj2), 땅.딟(obj0, obj2)) && 땅.딢(땅.딟(obj1, obj2), 땅.딟(obj1 + 1, obj2), 땅.딟(obj0, obj2)))
          return false;
      }
      else if (땅.딢(땅.딟(obj1, obj2), 땅.딟(obj1 + 1, obj2), 땅.딟(obj0, obj2)) || 땅.땄(땅.딟(obj1, obj2), 땅.딟(obj1 - 1, obj2), 땅.딟(obj0, obj2)))
        return false;
      for (int index = 0; index < obj2.Count; ++index)
      {
        if ((index + 1) % obj2.Count != obj0 && index != obj0 && (index + 1) % obj2.Count != obj1 && index != obj1 && 땥.땠.땄(땅.딟(obj0, obj2), 땅.딟(obj1, obj2), 땅.딟(index, obj2), 땅.딟(index + 1, obj2), out 떁 _))
          return false;
      }
      return true;
    }

    private static bool 땄([In] int obj0, [In] 땨 obj1) => 땅.딧(obj0, obj1);

    private static bool 딧([In] int obj0, [In] 땨 obj1) => 땅.딧(땅.딟(obj0 - 1, obj1), 땅.딟(obj0, obj1), 땅.딟(obj0 + 1, obj1));

    private static bool 딟([In] 떁 obj0, [In] 떁 obj1, [In] 떁 obj2) => (double) 땥.땴.딟(ref obj0, ref obj1, ref obj2) > 0.0;

    private static bool 땄([In] 떁 obj0, [In] 떁 obj1, [In] 떁 obj2) => (double) 땥.땴.딟(ref obj0, ref obj1, ref obj2) >= 0.0;

    private static bool 딧([In] 떁 obj0, [In] 떁 obj1, [In] 떁 obj2) => (double) 땥.땴.딟(ref obj0, ref obj1, ref obj2) < 0.0;

    private static bool 딢([In] 떁 obj0, [In] 떁 obj1, [In] 떁 obj2) => (double) 땥.땴.딟(ref obj0, ref obj1, ref obj2) <= 0.0;

    private static float 딟([In] 떁 obj0, [In] 떁 obj1)
    {
      float num1 = obj1.딟 - obj0.딟;
      float num2 = obj1.땄 - obj0.땄;
      return (float) ((double) num1 * (double) num1 + (double) num2 * (double) num2);
    }
  }
}
