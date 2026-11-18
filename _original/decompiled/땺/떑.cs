// Decompiled with JetBrains decompiler
// Type: 땺.떑
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using 땥;

namespace 땺
{
  public static class 떑
  {
    public static 땨 딟([In] 땨 obj0)
    {
      if (obj0.Count < 3)
        return obj0;
      떁[] 떁Array = new 떁[obj0.Count + 1];
      int index1 = 3;
      int index2 = 0;
      int index3 = 3;
      float num = 땥.땴.땄(obj0[0], obj0[1], obj0[2]);
      if ((double) num == 0.0)
      {
        떁Array[0] = obj0[0];
        떁Array[1] = obj0[2];
        떁Array[2] = obj0[0];
        index1 = 2;
        for (index3 = 3; index3 < obj0.Count; ++index3)
        {
          떁 떁 = obj0[index3];
          if ((double) 땥.땴.딟(ref 떁Array[0], ref 떁Array[1], ref 떁) == 0.0)
            떁Array[1] = obj0[index3];
          else
            break;
        }
      }
      else
      {
        떁Array[0] = 떁Array[3] = obj0[2];
        if ((double) num > 0.0)
        {
          떁Array[1] = obj0[0];
          떁Array[2] = obj0[1];
        }
        else
        {
          떁Array[1] = obj0[1];
          떁Array[2] = obj0[0];
        }
      }
      int index4 = index1 != 0 ? index1 - 1 : 떁Array.Length - 1;
      int index5 = index2 != 떁Array.Length - 1 ? index2 + 1 : 0;
      for (int index6 = index3; index6 < obj0.Count; ++index6)
      {
        떁 떁 = obj0[index6];
        if ((double) 땥.땴.딟(ref 떁Array[index4], ref 떁Array[index1], ref 떁) <= 0.0 || (double) 땥.땴.딟(ref 떁Array[index2], ref 떁Array[index5], ref 떁) <= 0.0)
        {
          for (; (double) 땥.땴.딟(ref 떁Array[index4], ref 떁Array[index1], ref 떁) <= 0.0; index4 = index1 != 0 ? index1 - 1 : 떁Array.Length - 1)
            index1 = index4;
          index1 = index1 != 떁Array.Length - 1 ? index1 + 1 : 0;
          index4 = index1 != 0 ? index1 - 1 : 떁Array.Length - 1;
          떁Array[index1] = 떁;
          for (; (double) 땥.땴.딟(ref 떁Array[index2], ref 떁Array[index5], ref 떁) <= 0.0; index5 = index2 != 떁Array.Length - 1 ? index2 + 1 : 0)
            index2 = index5;
          index2 = index2 != 0 ? index2 - 1 : 떁Array.Length - 1;
          index5 = index2 != 떁Array.Length - 1 ? index2 + 1 : 0;
          떁Array[index2] = 떁;
        }
      }
      땨 땨 = new 땨(obj0.Count + 1);
      if (index2 < index1)
      {
        for (int index7 = index2; index7 < index1; ++index7)
          땨.Add(떁Array[index7]);
      }
      else
      {
        for (int index8 = 0; index8 < index1; ++index8)
          땨.Add(떁Array[index8]);
        for (int index9 = index2; index9 < 떁Array.Length; ++index9)
          땨.Add(떁Array[index9]);
      }
      return 땨;
    }
  }
}
