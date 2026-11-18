// Decompiled with JetBrains decompiler
// Type: 땥.땃
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 땥
{
  public class 땃
  {
    private static readonly Random 딟 = new Random();
    private static double 딟 = 2.0 * Math.PI;

    public static 땺.땧 딟([In] double obj0, [In] int obj1)
    {
      double num1 = obj0 / 4.0;
      땺.땊[] 땊Array = new 땺.땊[obj1];
      for (int index = 0; index < obj1; ++index)
      {
        do
        {
          double num2 = index % 250 != 0 ? (index % 50 != 0 ? num1 + 25.0 * obj0 / (double) obj1 * (0.5 - 땃.딟.NextDouble()) : num1 + obj0 / 5.0 * (0.5 - 땃.딟.NextDouble())) : num1 + obj0 / 2.0 * (0.5 - 땃.딟.NextDouble());
          double num3 = num2 <= obj0 / 2.0 ? num2 : obj0 / 2.0;
          num1 = num3 >= obj0 / 10.0 ? num3 : obj0 / 10.0;
        }
        while (num1 < obj0 / 10.0 || num1 > obj0 / 2.0);
        땺.땊 땊 = new 땺.땊(num1 * Math.Cos(땃.딟 * (double) index / (double) obj1), num1 * Math.Sin(땃.딟 * (double) index / (double) obj1));
        땊Array[index] = 땊;
      }
      return new 땺.땧((IList<땺.땊>) 땊Array);
    }

    public static 땺.땧 땄([In] double obj0, [In] int obj1)
    {
      double num1 = obj0 / 4.0;
      땺.땊[] 땊Array = new 땺.땊[obj1];
      for (int index = 0; index < obj1; ++index)
      {
        do
        {
          double num2 = num1 + obj0 / 5.0 * (0.5 - 땃.딟.NextDouble());
          double num3 = num2 <= obj0 / 2.0 ? num2 : obj0 / 2.0;
          num1 = num3 >= obj0 / 10.0 ? num3 : obj0 / 10.0;
        }
        while (num1 < obj0 / 10.0 || num1 > obj0 / 2.0);
        땺.땊 땊 = new 땺.땊(num1 * Math.Cos(땃.딟 * (double) index / (double) obj1), num1 * Math.Sin(땃.딟 * (double) index / (double) obj1));
        땊Array[index] = 땊;
      }
      return new 땺.땧((IList<땺.땊>) 땊Array);
    }
  }
}
