// Decompiled with JetBrains decompiler
// Type: 땃.땎
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 땃
{
  public class 땎
  {
    public static 떑 딟([In] 딶.땖 obj0, [In] int obj1, [In] 딢.딴 obj2)
    {
      딢.딴 딴 = obj2;
      switch (딴)
      {
        case 딢.딴.땕:
        case 딢.딴.따:
        case 딢.딴.딾:
          return (떑) new 땾(obj0, obj1, obj2);
        default:
          if (딴 != 딢.딴.딝 && 딴 != 딢.딴.떎 && 딴 != 딢.딴.딗)
          {
            if (딴 == 딢.딴.땳)
              return (떑) new 땑(obj0, obj1, obj2);
            if (딴 != 딢.딴.땁 && 딴 != 딢.딴.땷)
            {
              if (딴 != 딢.딴.땄)
              {
                if (딴 != 딢.딴.땋 && 딴 != 딢.딴.떌)
                  return (떑) null;
                goto case 딢.딴.땕;
              }
              else
                return obj0.땻()[obj1] is 땓.떀 떀6 && GlobalAppData.딢().딟(떀6.딧()).TwoStageAttack ? (떑) new 땾(obj0, obj1, obj2) : (떑) new 딲();
            }
            else
              goto case 딢.딴.땕;
          }
          else
            goto case 딢.딴.땕;
      }
    }
  }
}
