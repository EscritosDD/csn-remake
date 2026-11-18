// Decompiled with JetBrains decompiler
// Type: 땥.땈
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using 딝;

namespace 땥
{
  public static class 땈
  {
    public static void 딟([In] 떀 obj0, [In] 떁 obj1, [In] 떁 obj2, [In] float obj3, out 땨 _param4, out 땨 _param5)
    {
      떁 떁1 = obj0.땓().땃(ref obj1);
      떁 떁2 = obj0.땓().땃(ref obj2);
      if (!(obj0.땃() is 땺.떅 떅))
      {
        _param4 = new 땨();
        _param5 = new 땨();
      }
      else
      {
        땨 땨1 = new 땨((IList<떁>) 떅.땄);
        땨[] 땨Array = new 땨[2];
        for (int index = 0; index < 땨Array.Length; ++index)
          땨Array[index] = new 땨(땨1.Count);
        int[] numArray = new int[2]{ -1, -1 };
        int index1 = -1;
        for (int index2 = 0; index2 < 땨1.Count; ++index2)
        {
          int index3 = (double) 떁.딶(땴.딟(떁2 - 떁1, 1f), 땨1[index2] - 떁1) <= 1.19209289550781E-07 ? 1 : 0;
          if (index1 != index3)
          {
            if (index1 == 0)
            {
              numArray[0] = 땨Array[index1].Count;
              땨Array[index1].Add(떁2);
              땨Array[index1].Add(떁1);
            }
            if (index1 == 1)
            {
              numArray[index1] = 땨Array[index1].Count;
              땨Array[index1].Add(떁1);
              땨Array[index1].Add(떁2);
            }
          }
          땨Array[index3].Add(땨1[index2]);
          index1 = index3;
        }
        if (numArray[0] == -1)
        {
          numArray[0] = 땨Array[0].Count;
          땨Array[0].Add(떁2);
          땨Array[0].Add(떁1);
        }
        if (numArray[1] == -1)
        {
          numArray[1] = 땨Array[1].Count;
          땨Array[1].Add(떁1);
          땨Array[1].Add(떁2);
        }
        for (int index4 = 0; index4 < 2; ++index4)
        {
          떁 떁3 = numArray[index4] <= 0 ? 땨Array[index4][땨Array[index4].Count - 1] - 땨Array[index4][0] : 땨Array[index4][numArray[index4] - 1] - 땨Array[index4][numArray[index4]];
          떁3.땓();
          땨 땨2;
          int index5;
          (땨2 = 땨Array[index4])[index5 = numArray[index4]] = 땨2[index5] + obj3 * 떁3;
          떁 떁4 = numArray[index4] >= 땨Array[index4].Count - 2 ? 땨Array[index4][0] - 땨Array[index4][땨Array[index4].Count - 1] : 땨Array[index4][numArray[index4] + 2] - 땨Array[index4][numArray[index4] + 1];
          떁4.땓();
          땨 땨3;
          int index6;
          (땨3 = 땨Array[index4])[index6 = numArray[index4] + 1] = 땨3[index6] + obj3 * 떁4;
        }
        _param4 = 땨Array[0];
        _param5 = 땨Array[1];
      }
    }

    public static void 딟([In] 땱 obj0, [In] 떁 obj1, [In] 떁 obj2, [In] float obj3)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      땈.땞 땞 = new 땈.땞();
      // ISSUE: reference to a compiler-generated field
      땞.딟 = new List<떀>();
      // ISSUE: reference to a compiler-generated field
      땞.딟 = new List<떁>();
      // ISSUE: reference to a compiler-generated field
      땞.땄 = new List<떁>();
      if (obj0.딟(obj1) != null || obj0.딟(obj2) != null)
        return;
      // ISSUE: reference to a compiler-generated method
      obj0.딟(new 땂(땞.딟), obj1, obj2);
      // ISSUE: reference to a compiler-generated method
      obj0.딟(new 땂(땞.땄), obj2, obj1);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      if (땞.딟.Count + 땞.땄.Count < 2)
        return;
      // ISSUE: reference to a compiler-generated field
      for (int index = 0; index < 땞.딟.Count; ++index)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if (땞.딟[index].땃().딢() == 땺.땙.딢 && 땞.딟[index].땓().딧() != 땎.딟)
        {
          땨 땨1;
          땨 땨2;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          땈.딟(땞.딟[index], 땞.딟[index], 땞.땄[index], obj3, out 땨1, out 땨2);
          if (땈.딟(땨1))
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            딺 딺 = 딝.딝.딟(obj0, 땨1, 땞.딟[index].땃().땃(), 땞.딟[index].땓().땼());
            // ISSUE: reference to a compiler-generated field
            딺.땃(땞.딟[index].땓().땢());
            // ISSUE: reference to a compiler-generated field
            딺.딟(땞.딟[index].땓().딢());
            // ISSUE: reference to a compiler-generated field
            딺.땄(땞.딟[index].땓().땃());
            딺.딟(땎.딧);
          }
          if (땈.딟(땨2))
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            딺 딺 = 딝.딝.딟(obj0, 땨2, 땞.딟[index].땃().땃(), 땞.딟[index].땓().땼());
            // ISSUE: reference to a compiler-generated field
            딺.땃(땞.딟[index].땓().땢());
            // ISSUE: reference to a compiler-generated field
            딺.딟(땞.딟[index].땓().딢());
            // ISSUE: reference to a compiler-generated field
            딺.땄(땞.딟[index].땓().땃());
            딺.딟(땎.딧);
          }
          // ISSUE: reference to a compiler-generated field
          obj0.땄(땞.딟[index].땓());
        }
      }
    }

    private static bool 딟([In] 땨 obj0)
    {
      if (obj0.Count < 3 || (double) obj0.땄() < 9.99999974737875E-06)
        return false;
      for (int index1 = 0; index1 < obj0.Count; ++index1)
      {
        int index2 = index1;
        int index3 = index1 + 1 >= obj0.Count ? 0 : index1 + 1;
        if ((double) (obj0[index3] - obj0[index2]).딶() < 1.4210854715202E-14)
          return false;
      }
      for (int index4 = 0; index4 < obj0.Count; ++index4)
      {
        int index5 = index4;
        int index6 = index4 + 1 >= obj0.Count ? 0 : index4 + 1;
        떁 떁1 = obj0[index6] - obj0[index5];
        for (int index7 = 0; index7 < obj0.Count; ++index7)
        {
          if (index7 != index5 && index7 != index6)
          {
            떁 떁2 = obj0[index7] - obj0[index5];
            if ((double) 떁1.딟 * (double) 떁2.땄 - (double) 떁1.땄 * (double) 떁2.딟 < 0.0)
              return false;
          }
        }
      }
      return true;
    }
  }
}
