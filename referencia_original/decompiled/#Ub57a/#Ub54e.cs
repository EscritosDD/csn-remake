// Decompiled with JetBrains decompiler
// Type: 땺.땎
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using 땥;

namespace 땺
{
  public static class 땎
  {
    public static 땨 딟([In] 땨 obj0)
    {
      int index1 = 0;
      float num1 = obj0[0].딟;
      for (int index2 = 1; index2 < obj0.Count; ++index2)
      {
        float 딟 = obj0[index2].딟;
        if ((double) 딟 > (double) num1 || (double) 딟 == (double) num1 && (double) obj0[index2].땄 < (double) obj0[index1].땄)
        {
          index1 = index2;
          num1 = 딟;
        }
      }
      int[] numArray = new int[obj0.Count];
      int index3 = 0;
      int num2 = index1;
      int index4;
      do
      {
        numArray[index3] = num2;
        index4 = 0;
        for (int index5 = 1; index5 < obj0.Count; ++index5)
        {
          if (index4 == num2)
          {
            index4 = index5;
          }
          else
          {
            떁 떁1 = obj0[index4] - obj0[numArray[index3]];
            떁 떁2 = obj0[index5] - obj0[numArray[index3]];
            float num3 = 땥.땴.딟(떁1, 떁2);
            if ((double) num3 < 0.0)
              index4 = index5;
            if ((double) num3 == 0.0 && (double) 떁2.딶() > (double) 떁1.딶())
              index4 = index5;
          }
        }
        ++index3;
        num2 = index4;
      }
      while (index4 != index1);
      땨 땨 = new 땨();
      for (int index6 = 0; index6 < index3; ++index6)
        땨.Add(obj0[numArray[index6]]);
      return 땨;
    }
  }
}
