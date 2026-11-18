// Decompiled with JetBrains decompiler
// Type: 땥.딟
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 땥
{
  public class 딟
  {
    public static double 딟 = 1E-12;

    public static bool 딟([In] 땺.땮 obj0, [In] 땺.땮 obj1, [In] 땺.땮 obj2, [In] 땺.땮 obj3)
    {
      double 딟 = obj3.딟;
      double 땄 = obj3.땄;
      double num1 = obj0.딟 - 딟;
      double num2 = obj0.땄 - 땄;
      double num3 = obj1.딟 - 딟;
      double num4 = obj1.땄 - 땄;
      double num5 = num1 * num4 - num3 * num2;
      if (num5 <= 0.0)
        return false;
      double num6 = obj2.딟 - 딟;
      double num7 = obj2.땄 - 땄;
      double num8 = num6 * num2 - num1 * num7;
      if (num8 <= 0.0)
        return false;
      double num9 = num3 * num7;
      double num10 = num6 * num4;
      double num11 = num1 * num1 + num2 * num2;
      double num12 = num3 * num3 + num4 * num4;
      double num13 = num6 * num6 + num7 * num7;
      return num11 * (num9 - num10) + num12 * num8 + num13 * num5 > 0.0;
    }

    public static bool 땄([In] 땺.땮 obj0, [In] 땺.땮 obj1, [In] 땺.땮 obj2, [In] 땺.땮 obj3)
    {
      double 딟 = obj3.딟;
      double 땄 = obj3.땄;
      double num1 = obj0.딟 - 딟;
      double num2 = obj0.땄 - 땄;
      double num3 = obj1.딟 - 딟;
      double num4 = obj1.땄 - 땄;
      if (num1 * num4 - num3 * num2 <= 0.0)
        return false;
      double num5 = obj2.딟 - 딟;
      double num6 = obj2.땄 - 땄;
      return num5 * num2 - num1 * num6 > 0.0;
    }

    public static 땺.딼 딟([In] 땺.땮 obj0, [In] 땺.땮 obj1, [In] 땺.땮 obj2)
    {
      double num = (obj0.딟 - obj2.딟) * (obj1.땄 - obj2.땄) - (obj0.땄 - obj2.땄) * (obj1.딟 - obj2.딟);
      if (num > -땥.딟.딟 && num < 땥.딟.딟)
        return 땺.딼.딧;
      return num > 0.0 ? 땺.딼.땄 : 땺.딼.딟;
    }
  }
}
