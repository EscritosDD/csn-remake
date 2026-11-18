// Decompiled with JetBrains decompiler
// Type: 땃.땈
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땃
{
  public class 땈 : 땁
  {
    private GameTileComponent 딟;
    private int 딟;

    public 땈([In] 딢.딴 obj0, [In] int obj1)
      : base(obj0)
    {
      this.딟 = obj1;
    }

    public override 땻 딟([In] 딶.딡 obj0, [In] 딡 obj1, [In] 딶.땙 obj2)
    {
      this.딟 = obj1.딟[this.딟];
      if (!Object.op_Inequality((Object) this.딟, (Object) null))
        return 땻.딧;
      땓.땊 땊 = obj2.땺()[obj1.딟.땔()];
      return this.딟(obj0, 땊, obj2, obj1);
    }

    protected 땻 딟([In] 딶.딡 obj0, [In] 땓.땊 obj1, [In] 딶.땙 obj2, [In] 딡 obj3)
    {
      땻 땻 = 땻.땄;
      if (obj1.땃 == this.딟.TileIndexX && obj1.딶 == this.딟.TileIndexY)
      {
        땻 = 땻.딧;
      }
      else
      {
        List<GameTileComponent> gameTileComponentList = obj0.땓().get_TileNetwork().딟(obj0.땼(), obj2, obj1.땃, obj1.딶, this.딟.TileIndexX, this.딟.TileIndexY, obj0.땼().땻()[obj1.땥()]);
        if (gameTileComponentList != null)
        {
          if (obj3.딟[this.딟] * obj3.땄 == Math.Max(0, gameTileComponentList.Count - 1) * obj3.땄)
          {
            int num;
            bool flag = this.딟(obj0, obj3, gameTileComponentList, obj2, this.딟.TileIndexX, this.딟.TileIndexY, out num);
            if (num == -1)
              땻 = !flag ? 땻.땃 : 땻.딧;
          }
          else
          {
            obj3.딟[4] = true;
            땻 = 땻.딢;
          }
        }
        else
        {
          obj3.딟[4] = true;
          땻 = 땻.딢;
        }
      }
      return 땻;
    }
  }
}
