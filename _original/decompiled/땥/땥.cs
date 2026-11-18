// Decompiled with JetBrains decompiler
// Type: 땥.땥
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 땥
{
  public static class 땥
  {
    private static 떁 딟;
    private static 떁 땄;
    private static 떁 딧;

    private static bool 딟([In] ref 떁 obj0, [In] ref 떁 obj1, [In] ref 떁 obj2, [In] ref 떁 obj3)
    {
      float num1 = (float) (((double) obj2.딟 - (double) obj1.딟) * ((double) obj3.땄 - (double) obj1.땄) - ((double) obj2.땄 - (double) obj1.땄) * ((double) obj3.딟 - (double) obj1.딟));
      float num2 = (float) (((double) obj1.딟 - (double) obj0.딟) * ((double) obj3.땄 - (double) obj0.땄) - ((double) obj1.땄 - (double) obj0.땄) * ((double) obj3.딟 - (double) obj0.딟));
      float num3 = (float) (((double) obj0.딟 - (double) obj2.딟) * ((double) obj3.땄 - (double) obj2.땄) - ((double) obj0.땄 - (double) obj2.땄) * ((double) obj3.딟 - (double) obj2.딟));
      return (double) num1 >= 0.0 && (double) num3 >= 0.0 && (double) num2 >= 0.0;
    }

    private static bool 딟([In] 땨 obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4, [In] int[] obj5)
    {
      if (1.19209289550781E-07 > (double) 땴.딟(ref 땥.땥.딟, ref 땥.땥.땄, ref 땥.땥.딧))
        return false;
      for (int index = 0; index < obj4; ++index)
      {
        if (index != obj1 && index != obj2 && index != obj3)
        {
          떁 떁 = obj0[obj5[index]];
          if (땥.땥.딟(ref 땥.땥.딟, ref 땥.땥.땄, ref 땥.땥.딧, ref 떁))
            return false;
        }
      }
      return true;
    }

    public static List<땨> 딟([In] 땨 obj0)
    {
      int count = obj0.Count;
      if (count < 3)
        return new List<땨>();
      int[] numArray = new int[count];
      if (obj0.땓())
      {
        for (int index = 0; index < count; ++index)
          numArray[index] = index;
      }
      else
      {
        for (int index = 0; index < count; ++index)
          numArray[index] = count - 1 - index;
      }
      int num1 = count;
      int num2 = 2 * num1;
      List<땨> 땨List = new List<땨>();
      int index1 = num1 - 1;
      while (num1 > 2)
      {
        if (0 >= num2--)
          return new List<땨>();
        int index2 = index1;
        if (num1 <= index2)
          index2 = 0;
        index1 = index2 + 1;
        if (num1 <= index1)
          index1 = 0;
        int index3 = index1 + 1;
        if (num1 <= index3)
          index3 = 0;
        땥.땥.딟 = obj0[numArray[index2]];
        땥.땥.땄 = obj0[numArray[index1]];
        땥.땥.딧 = obj0[numArray[index3]];
        if (땥.땥.딟(obj0, index2, index1, index3, num1, numArray))
        {
          땨 땨 = new 땨(3);
          땨.Add(땥.땥.딟);
          땨.Add(땥.땥.땄);
          땨.Add(땥.땥.딧);
          땨List.Add(땨);
          int index4 = index1;
          for (int index5 = index1 + 1; index5 < num1; ++index5)
          {
            numArray[index4] = numArray[index5];
            ++index4;
          }
          --num1;
          num2 = 2 * num1;
        }
      }
      return 땨List;
    }
  }
}
