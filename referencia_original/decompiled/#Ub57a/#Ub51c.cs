// Decompiled with JetBrains decompiler
// Type: 땺.딜
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using 땥;

namespace 땺
{
  public static class 딜
  {
    private static 떁 딟;
    private static 떁 땄;
    private static 딞 딟 = new 딞();
    private static 딞 땄 = new 딞();
    private static 땥.딛 딟;
    private static 땥.딛 땄;
    private static 딻 딟;

    public static void 딟([In] ref 딡 obj0, [In] 딞 obj1, [In] ref 땥.딛 obj2, [In] 딞 obj3, [In] ref 땥.딛 obj4, [In] float obj5)
    {
      딜.땄 = 떁.딟();
      딜.딟 = obj1;
      딜.땄 = obj3;
      int 딟 = (int) obj0.딟;
      딜.딟 = obj2;
      딜.땄 = obj4;
      땥.떓 떓1;
      딜.딟.딟(out 떓1, obj5);
      땥.떓 떓2;
      딜.땄.딟(out 떓2, obj5);
      if (딟 == 1)
      {
        딜.딟 = 딻.딟;
        떁 떁1 = 딜.딟.딟[(int) obj0.딟.딟(0)];
        떁 떁2 = 딜.땄.딟[(int) obj0.땄.딟(0)];
        떁 떁3 = 땥.땴.딟(ref 떓1, 떁1);
        딜.딟 = 땥.땴.딟(ref 떓2, 떁2) - 떁3;
        딜.딟.땓();
      }
      else if ((int) obj0.딟.딟(0) == (int) obj0.딟.딟(1))
      {
        딜.딟 = 딻.딧;
        떁 떁4 = obj3.딟[(int) obj0.땄.딟(0)];
        떁 떁5 = obj3.딟[(int) obj0.땄.딟(1)];
        떁 떁6 = 떁5 - 떁4;
        딜.딟 = new 떁(떁6.땄, -떁6.딟);
        딜.딟.땓();
        떁 떁7 = 땥.땴.딟(ref 떓2.딟, 딜.딟);
        딜.땄 = 0.5f * (떁4 + 떁5);
        떁 떁8 = 땥.땴.딟(ref 떓2, 딜.땄);
        떁 떁9 = obj1.딟[(int) obj0.딟.딟(0)];
        float num1 = 떁.딶(땥.땴.딟(ref 떓1, 떁9) - 떁8, 떁7);
        if ((double) num1 >= 0.0)
          return;
        딜.딟 = -딜.딟;
        float num2 = -num1;
      }
      else
      {
        딜.딟 = 딻.땄;
        떁 떁10 = 딜.딟.딟[(int) obj0.딟.딟(0)];
        떁 떁11 = 딜.딟.딟[(int) obj0.딟.딟(1)];
        떁 떁12 = 떁11 - 떁10;
        딜.딟 = new 떁(떁12.땄, -떁12.딟);
        딜.딟.땓();
        떁 떁13 = 땥.땴.딟(ref 떓1.딟, 딜.딟);
        딜.땄 = 0.5f * (떁10 + 떁11);
        떁 떁14 = 땥.땴.딟(ref 떓1, 딜.땄);
        떁 떁15 = 딜.땄.딟[(int) obj0.땄.딟(0)];
        float num3 = 떁.딶(땥.땴.딟(ref 떓2, 떁15) - 떁14, 떁13);
        if ((double) num3 >= 0.0)
          return;
        딜.딟 = -딜.딟;
        float num4 = -num3;
      }
    }

    public static float 딟(out int _param0, out int _param1, [In] float obj2)
    {
      땥.떓 떓1;
      딜.딟.딟(out 떓1, obj2);
      땥.떓 떓2;
      딜.땄.딟(out 떓2, obj2);
      switch (딜.딟)
      {
        case 딻.딟:
          떁 떁1 = 땥.땴.땄(ref 떓1.딟, 딜.딟);
          떁 떁2 = 땥.땴.땄(ref 떓2.딟, -딜.딟);
          _param0 = 딜.딟.딟(떁1);
          _param1 = 딜.땄.딟(떁2);
          떁 떁3 = 딜.딟.딟[_param0];
          떁 떁4 = 딜.땄.딟[_param1];
          떁 떁5 = 땥.땴.딟(ref 떓1, 떁3);
          return 떁.딶(땥.땴.딟(ref 떓2, 떁4) - 떁5, 딜.딟);
        case 딻.땄:
          떁 떁6 = 땥.땴.딟(ref 떓1.딟, 딜.딟);
          떁 떁7 = 땥.땴.딟(ref 떓1, 딜.땄);
          떁 떁8 = 땥.땴.땄(ref 떓2.딟, -떁6);
          _param0 = -1;
          _param1 = 딜.땄.딟(떁8);
          떁 떁9 = 딜.땄.딟[_param1];
          return 떁.딶(땥.땴.딟(ref 떓2, 떁9) - 떁7, 떁6);
        case 딻.딧:
          떁 떁10 = 땥.땴.딟(ref 떓2.딟, 딜.딟);
          떁 떁11 = 땥.땴.딟(ref 떓2, 딜.땄);
          떁 떁12 = 땥.땴.땄(ref 떓1.딟, -떁10);
          _param1 = -1;
          _param0 = 딜.딟.딟(떁12);
          떁 떁13 = 딜.딟.딟[_param0];
          return 떁.딶(땥.땴.딟(ref 떓1, 떁13) - 떁11, 떁10);
        default:
          _param0 = -1;
          _param1 = -1;
          return 0.0f;
      }
    }

    public static float 딟([In] int obj0, [In] int obj1, [In] float obj2)
    {
      땥.떓 떓1;
      딜.딟.딟(out 떓1, obj2);
      땥.떓 떓2;
      딜.땄.딟(out 떓2, obj2);
      switch (딜.딟)
      {
        case 딻.딟:
          떁 떁1 = 딜.딟.딟[obj0];
          떁 떁2 = 딜.땄.딟[obj1];
          떁 떁3 = 땥.땴.딟(ref 떓1, 떁1);
          return 떁.딶(땥.땴.딟(ref 떓2, 떁2) - 떁3, 딜.딟);
        case 딻.땄:
          떁 떁4 = 땥.땴.딟(ref 떓1.딟, 딜.딟);
          떁 떁5 = 땥.땴.딟(ref 떓1, 딜.땄);
          떁 떁6 = 딜.땄.딟[obj1];
          return 떁.딶(땥.땴.딟(ref 떓2, 떁6) - 떁5, 떁4);
        case 딻.딧:
          떁 떁7 = 땥.땴.딟(ref 떓2.딟, 딜.딟);
          떁 떁8 = 땥.땴.딟(ref 떓2, 딜.땄);
          떁 떁9 = 딜.딟.딟[obj0];
          return 떁.딶(땥.땴.딟(ref 떓1, 떁9) - 떁8, 떁7);
        default:
          return 0.0f;
      }
    }
  }
}
