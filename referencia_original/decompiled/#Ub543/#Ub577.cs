// Decompiled with JetBrains decompiler
// Type: 땃.땷
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 땃
{
  public class 땷 : 땁
  {
    protected 땷.딸 딟;
    protected int 딟;
    protected GameTileComponent 딟;
    protected GameTileComponent 땄;

    public 땷([In] 딢.딴 obj0, [In] int obj1, [In] GameTileComponent obj2)
      : base(obj0)
    {
      this.딟 = obj1;
      this.땄 = obj2;
    }

    public override 땻 딟([In] 딶.딡 obj0, [In] 딡 obj1, [In] 딶.땙 obj2)
    {
      땻 땻 = 땻.땄;
      땓.땊 땊 = obj2.땺()[obj1.딟.땔()];
      switch (this.딟)
      {
        case 땷.딸.딟:
          this.딟 = obj1.딟[this.딟];
          땻 = this.딟(obj0, 땊, obj2, obj1);
          break;
        case 땷.딸.땄:
          땻 = this.땄(obj0, obj1, obj2);
          break;
      }
      return 땻;
    }

    protected 땻 딟([In] 딶.딡 obj0, [In] 땓.땊 obj1, [In] 딶.땙 obj2, [In] 딡 obj3)
    {
      땻 땻 = 땻.땄;
      if (obj1.땃 == this.땄.TileIndexX && obj1.딶 == this.땄.TileIndexY)
      {
        this.딟 = 땷.딸.땄;
      }
      else
      {
        List<GameTileComponent> gameTileComponentList = obj0.땓().get_TileNetwork().딟(obj0.땼(), obj2, obj1.땃, obj1.딶, this.땄.TileIndexX, this.땄.TileIndexY, obj0.땼().땻()[obj1.땥()]);
        if (gameTileComponentList != null)
        {
          int num;
          bool flag = this.딟(obj0, obj3, gameTileComponentList, obj2, this.땄.TileIndexX, this.땄.TileIndexY, out num);
          if (num != -1)
            this.딟 = 땷.딸.딟;
          else if (flag)
            this.딟 = 땷.딸.땄;
          else
            땻 = 땻.땃;
        }
        else
          땻 = 땻.딢;
      }
      return 땻;
    }

    protected 땻 땄([In] 딶.딡 obj0, [In] 딡 obj1, [In] 딶.땙 obj2)
    {
      int index = 떊.땄(obj0.땼(), obj2, obj1.딟.땔(), this.딟());
      if (index == -1)
        return 땻.딢;
      if (obj2.땺()[obj1.딟.땔()].딢 >= (obj0.땼().땻()[index] as 딶.땉).땺())
        땁.딟(new 딶.땋(obj1.딟.땔(), this.딟(), this.딟.TileIndexX, this.딟.TileIndexY).딟(), obj0);
      return 땻.딧;
    }

    protected enum 딸
    {
      딟,
      땄,
    }
  }
}
