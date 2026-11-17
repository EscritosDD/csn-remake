// Decompiled with JetBrains decompiler
// Type: 땺.땯
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using 땥;

namespace 땺
{
  public static class 땯
  {
    public static int 딟;
    public static int 땄;
    public static int 딧;

    public static void 딟(out 딿 _param0, out 딡 _param1, [In] 딠 obj2)
    {
      _param1 = new 딡();
      ++땯.딟;
      땇 땇 = new 땇();
      땇.딟(ref _param1, obj2.딟, ref obj2.딟, obj2.땄, ref obj2.땄);
      딱<int> 딱1 = new 딱<int>();
      딱<int> 딱2 = new 딱<int>();
      float num1 = 땇.땄().딶();
      int val2 = 0;
      while (val2 < 20)
      {
        int 딟 = 땇.딟;
        for (int index = 0; index < 딟; ++index)
        {
          딱1.딟(index, 땇.딟.딟(index).딟);
          딱2.딟(index, 땇.딟.딟(index).땄);
        }
        switch (땇.딟)
        {
          case 2:
            땇.딢();
            break;
          case 3:
            땇.땃();
            break;
        }
        if (땇.딟 != 3)
        {
          float num2 = 땇.땄().딶();
          if ((double) num2 < (double) num1)
            ;
          num1 = num2;
          떁 떁 = 땇.딟();
          if ((double) 떁.딶() >= 1.4210854715202E-14)
          {
            딨 딨 = 땇.딟.딟(땇.딟);
            딨.딟 = obj2.딟.딟(땥.땴.땄(obj2.딟.딟, -떁));
            딨.땄 = 땥.땴.딟(ref obj2.딟, obj2.딟.딟[딨.딟]);
            딨.땄 = obj2.땄.딟(땥.땴.땄(obj2.땄.딟, 떁));
            딨.딧 = 땥.땴.딟(ref obj2.땄, obj2.땄.딟[딨.땄]);
            딨.딟 = 딨.딧 - 딨.땄;
            땇.딟.딟(땇.딟, 딨);
            ++val2;
            ++땯.땄;
            bool flag = false;
            for (int index = 0; index < 딟; ++index)
            {
              if (딨.딟 == 딱1.딟(index) && 딨.땄 == 딱2.딟(index))
              {
                flag = true;
                break;
              }
            }
            if (!flag)
              ++땇.딟;
            else
              break;
          }
          else
            break;
        }
        else
          break;
      }
      땯.딧 = Math.Max(땯.딧, val2);
      땇.딟(out _param0.딟, out _param0.땄);
      _param0.딟 = (_param0.딟 - _param0.땄).땃();
      _param0.딟 = val2;
      땇.딟(ref _param1);
      if (!obj2.딟)
        return;
      float 딟1 = obj2.딟.딟;
      float 딟2 = obj2.땄.딟;
      if ((double) _param0.딟 > (double) 딟1 + (double) 딟2 && (double) _param0.딟 > 1.19209289550781E-07)
      {
        _param0.딟 -= 딟1 + 딟2;
        떁 떁 = _param0.땄 - _param0.딟;
        떁.땓();
        _param0.딟 += 딟1 * 떁;
        _param0.땄 -= 딟2 * 떁;
      }
      else
      {
        떁 떁 = 0.5f * (_param0.딟 + _param0.땄);
        _param0.딟 = 떁;
        _param0.땄 = 떁;
        _param0.딟 = 0.0f;
      }
    }
  }
}
