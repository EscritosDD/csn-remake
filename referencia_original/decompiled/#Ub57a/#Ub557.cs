// Decompiled with JetBrains decompiler
// Type: 땺.땗
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;

namespace 땺
{
  public static class 땗
  {
    public static int 딟;
    public static int 땄;
    public static int 딧;
    public static int 딢;
    public static int 땃;
    private static 딠 딟 = new 딠();

    public static void 딟(out 땡 _param0, [In] 떆 obj1)
    {
      ++땗.딟;
      _param0 = new 땡();
      _param0.딟 = 땐.딟;
      _param0.딟 = obj1.딟;
      땥.딛 딟1 = obj1.딟;
      땥.딛 땄 = obj1.땄;
      딟1.딟();
      땄.딟();
      float 딟2 = obj1.딟;
      float num1 = Math.Max(0.005f, obj1.딟.딟 + obj1.땄.딟 - 0.015f);
      float num2 = 0.0f;
      int val2_1 = 0;
      땗.딟.딟 = obj1.딟;
      땗.딟.땄 = obj1.땄;
      땗.딟.딟 = false;
      do
      {
        땥.떓 떓1;
        딟1.딟(out 떓1, num2);
        땥.떓 떓2;
        땄.딟(out 떓2, num2);
        땗.딟.딟 = 떓1;
        땗.딟.땄 = 떓2;
        딿 딿;
        딡 딡;
        땯.딟(out 딿, out 딡, 땗.딟);
        if ((double) 딿.딟 <= 0.0)
        {
          _param0.딟 = 땐.딧;
          _param0.딟 = 0.0f;
          goto label_25;
        }
        else if ((double) 딿.딟 < (double) num1 + 1.0 / 800.0)
        {
          _param0.딟 = 땐.딢;
          _param0.딟 = num2;
          goto label_25;
        }
        else
        {
          딜.딟(ref 딡, obj1.딟, ref 딟1, obj1.땄, ref 땄, num2);
          bool flag = false;
          float num3 = 딟2;
          int num4 = 0;
          do
          {
            int num5;
            int num6;
            float num7 = 딜.딟(out num5, out num6, num3);
            if ((double) num7 > (double) num1 + 1.0 / 800.0)
            {
              _param0.딟 = 땐.땃;
              _param0.딟 = 딟2;
              flag = true;
              break;
            }
            if ((double) num7 > (double) num1 - 1.0 / 800.0)
            {
              num2 = num3;
              break;
            }
            float num8 = 딜.딟(num5, num6, num2);
            if ((double) num8 < (double) num1 - 1.0 / 800.0)
            {
              _param0.딟 = 땐.땄;
              _param0.딟 = num2;
              flag = true;
              break;
            }
            if ((double) num8 <= (double) num1 + 1.0 / 800.0)
            {
              _param0.딟 = 땐.딢;
              _param0.딟 = num2;
              flag = true;
              break;
            }
            int val2_2 = 0;
            float num9 = num2;
            float num10 = num3;
            do
            {
              float num11 = (val2_2 & 1) == 0 ? (float) (0.5 * ((double) num9 + (double) num10)) : num9 + (float) (((double) num1 - (double) num8) * ((double) num10 - (double) num9) / ((double) num7 - (double) num8));
              float num12 = 딜.딟(num5, num6, num11);
              if ((double) Math.Abs(num12 - num1) < 1.0 / 800.0)
              {
                num3 = num11;
                break;
              }
              if ((double) num12 > (double) num1)
              {
                num9 = num11;
                num8 = num12;
              }
              else
              {
                num10 = num11;
                num7 = num12;
              }
              ++val2_2;
              ++땗.딢;
            }
            while (val2_2 != 50);
            땗.땃 = Math.Max(땗.땃, val2_2);
            ++num4;
          }
          while (num4 != 딝.땥.땺);
          ++val2_1;
          ++땗.땄;
          if (flag)
            goto label_25;
        }
      }
      while (val2_1 != 20);
      _param0.딟 = 땐.땄;
      _param0.딟 = num2;
label_25:
      땗.딧 = Math.Max(땗.딧, val2_1);
    }
  }
}
