// Decompiled with JetBrains decompiler
// Type: 땥.딢
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 땥
{
  public class 딢
  {
    private static readonly Random 딟 = new Random();

    public static List<땺.땮> 딟([In] int obj0, [In] double obj1)
    {
      List<땺.땮> 땮List = new List<땺.땮>();
      for (int index = 0; index < obj0; ++index)
        땮List.Add(new 땺.땮(obj1 * (0.5 - 딢.딟.NextDouble()), obj1 * (0.5 - 딢.딟.NextDouble())));
      return 땮List;
    }

    public static List<땺.땮> 땄([In] int obj0, [In] double obj1)
    {
      double num1 = obj1 / (double) obj0;
      double num2 = 0.5 * obj1;
      List<땺.땮> 땮List = new List<땺.땮>();
      for (int index1 = 0; index1 < obj0 + 1; ++index1)
      {
        double num3 = num2 - (double) index1 * num1;
        for (int index2 = 0; index2 < obj0 + 1; ++index2)
          땮List.Add(new 땺.땮(num3, num2 - (double) index2 * num1));
      }
      return 땮List;
    }
  }
}
