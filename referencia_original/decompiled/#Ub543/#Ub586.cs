// Decompiled with JetBrains decompiler
// Type: 땃.떆
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 땃
{
  public class 떆 : 땶
  {
    private int 딟 = 3;
    private int 땄 = 1;

    public override 딡 딟([In] 딵 obj0)
    {
      딡 딡1 = (딡) null;
      for (int index = 0; index < obj0.땔().Count; ++index)
      {
        딡 딡2 = obj0.땔()[index];
        if (this.딟(obj0, 딡2))
        {
          딡 딡3 = this.딟(obj0, 딡1, 딡2, obj0.딣().땼().떂(), obj0.딣());
          if (딡3 == 딡2)
            딡1 = 딡3;
        }
      }
      if (딡1 != null)
        딡1.딟(땜.땓, new 땯() { 딟 = 딢.딴.땻 });
      return 딡1;
    }

    private 딡 딟([In] 딵 obj0, [In] 딡 obj1, [In] 딡 obj2, [In] 딶.땙 obj3, [In] 딶.딡 obj4)
    {
      if (!(obj4.땼().땻()[obj2.딟.땔()] is 땓.떀 떀))
        return (딡) null;
      if (떀.땄(딢.딴.땻))
      {
        int index = 딶.딢.딟(obj4.땼(), obj3, obj2.딟.땔(), 딢.딴.땻);
        if (index != -1)
        {
          땓.땊 땊 = obj3.땺()[obj2.딟.땔()];
          딶.땚 땚 = obj4.땼().땻()[index] as 딶.땚;
          땓.딲 딲 = obj4.땼().땻()[obj2.딟.땔()];
          if (땊.딢 >= 땚.땃() && this.딟(obj0, obj3, 땊, obj2, 딲, 땚.땃()))
            return obj2;
        }
      }
      return obj1;
    }

    private bool 딟([In] 딵 obj0, [In] 딶.땙 obj1, [In] 땓.땊 obj2, [In] 딡 obj3, [In] 땓.딲 obj4, [In] int obj5)
    {
      bool flag1 = false;
      bool flag2 = obj3.딟();
      int num1 = (obj2.딢 - obj5) / obj3.땄;
      int num2 = int.MaxValue;
      for (int index = 0; index < obj0.땻(); ++index)
      {
        딡 딡 = obj0.땁()[index];
        땓.땊 땊 = obj1.땺()[딡.딟.땔()];
        List<GameTileComponent> gameTileComponentList = obj0.딣().땓().get_TileNetwork().딟(obj0.딣().땼(), obj1, obj2.땃, obj2.딶, 땊.땃, 땊.딶, obj4, true);
        if (gameTileComponentList != null && gameTileComponentList.Count - 1 < num2)
          num2 = gameTileComponentList.Count - 2;
        if (flag2)
        {
          if (num2 <= num1 && num2 > this.땄)
          {
            flag1 = true;
            break;
          }
        }
        else if (num2 < this.딟)
        {
          flag1 = true;
          break;
        }
      }
      return flag1;
    }
  }
}
