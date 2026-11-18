// Decompiled with JetBrains decompiler
// Type: 땺.딪
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using 땥;

namespace 땺
{
  public static class 딪
  {
    public static 땨 딟([In] 땨 obj0)
    {
      obj0.Sort((IComparer<떁>) new 딪.떕());
      떁[] 떁Array = new 떁[obj0.Count];
      땨 땨 = new 땨();
      int count = obj0.Count;
      int num1 = -1;
      int index1 = 0;
      float 딟1 = obj0[0].딟;
      int index2 = 1;
      while (index2 < count && (double) obj0[index2].딟 == (double) 딟1)
        ++index2;
      int index3 = index2 - 1;
      if (index3 == count - 1)
      {
        int num2;
        떁Array[num2 = num1 + 1] = obj0[index1];
        if ((double) obj0[index3].땄 != (double) obj0[index1].땄)
          떁Array[++num2] = obj0[index3];
        int num3;
        떁Array[num3 = num2 + 1] = obj0[index1];
        for (int index4 = 0; index4 < num3 + 1; ++index4)
          땨.Add(떁Array[index4]);
        return 땨;
      }
      int num4 = 땨.Count - 1;
      int index5 = count - 1;
      float 딟2 = obj0[count - 1].딟;
      int index6 = count - 2;
      while (index6 >= 0 && (double) obj0[index6].딟 == (double) 딟2)
        --index6;
      int index7 = index6 + 1;
      int index8;
      떁Array[index8 = num4 + 1] = obj0[index1];
      int index9 = index3;
      while (++index9 <= index7)
      {
        if ((double) 땥.땴.땄(obj0[index1], obj0[index7], obj0[index9]) < 0.0 || index9 >= index7)
        {
          while (index8 > 0 && (double) 땥.땴.땄(떁Array[index8 - 1], 떁Array[index8], obj0[index9]) <= 0.0)
            --index8;
          떁Array[++index8] = obj0[index9];
        }
      }
      if (index5 != index7)
        떁Array[++index8] = obj0[index5];
      int num5 = index8;
      int index10 = index7;
      while (--index10 >= index3)
      {
        if ((double) 땥.땴.땄(obj0[index5], obj0[index3], obj0[index10]) < 0.0 || index10 <= index3)
        {
          while (index8 > num5 && (double) 땥.땴.땄(떁Array[index8 - 1], 떁Array[index8], obj0[index10]) <= 0.0)
            --index8;
          떁Array[++index8] = obj0[index10];
        }
      }
      if (index3 != index1)
        떁Array[++index8] = obj0[index1];
      for (int index11 = 0; index11 < index8 + 1; ++index11)
        땨.Add(떁Array[index11]);
      return 땨;
    }

    public class 떕 : Comparer<떁>
    {
      public override int Compare([In] 떁 obj0, [In] 떁 obj1)
      {
        int num = obj0.딟.CompareTo(obj1.딟);
        return num != 0 ? num : obj0.땄.CompareTo(obj1.땄);
      }
    }
  }
}
