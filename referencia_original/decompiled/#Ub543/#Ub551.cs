// Decompiled with JetBrains decompiler
// Type: 땃.땑
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땃
{
  public class 땑 : 떑
  {
    protected 딢.딴 딟;
    protected WeaponGameplayData 딟;
    protected AbilityGameplayData 딟;
    private int 딟;
    private static int 땄 = 3;

    public 땑([In] 딶.땖 obj0, [In] int obj1, [In] 딢.딴 obj2)
    {
      this.딟 = obj2;
      UnitWeapon unitWeapon = 땓.땎.딢(obj2, obj0.땻()[obj1]);
      if (Object.op_Inequality((Object) unitWeapon, (Object) null))
        this.딟 = unitWeapon.딟(obj0);
      this.딟 = GlobalAppData.딢().딟(obj2);
    }

    public override void 딟([In] 딡 obj0, [In] 딵 obj1)
    {
      딶.땖 땖 = obj1.딣().땼();
      딶.땙 땙 = 땖.떂();
      this.딟 = obj1.땓();
      for (int index1 = 0; index1 < obj1.땻(); ++index1)
      {
        딡 딡 = obj1.땁()[index1];
        if (!딡.딟())
        {
          딡.딟 = int.MaxValue;
        }
        else
        {
          땓.땊 땊1 = 땙.땺()[딡.딟.땔()];
          int num = int.MaxValue;
          for (int index2 = 0; index2 < obj1.땔().Count; ++index2)
          {
            땓.땊 땊2 = 땙.땺()[obj1.땔()[index2].딟.땔()];
            땓.딲 딲 = 땖.땻()[obj1.땔()[index2].딟.땔()];
            List<GameTileComponent> gameTileComponentList = obj1.딣().땓().get_TileNetwork().딟(땖, 땙, 땊1.땃, 땊1.딶, 땊2.땃, 땊2.딶, 딲, true);
            if (gameTileComponentList != null && gameTileComponentList.Count - 1 < num)
              num = gameTileComponentList.Count - 1;
          }
          딡.딟 = num;
        }
      }
    }

    public override bool 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 딡 obj2) => !Object.op_Equality((Object) this.딟, (Object) null) && this.딟.딟(obj0, obj2.딟.땴(), false);

    public override void 딟([In] 딠 obj0, [In] 딩 obj1, [In] GameTileComponent obj2, [In] int obj3, [In] int obj4)
    {
      if (obj3 > obj0.딟.딢 - this.딟.RequiredActionPoints)
        return;
      for (int index = 0; index < obj0.딟.땻(); ++index)
      {
        땓.땊 땊 = obj0.딟.땼().떎()[obj0.딟.땁()[index].딟.땔()];
        GameTileComponent gameTileComponent = obj0.딟.땼().땹().get_Tiles()[땊.땃, 땊.딶];
        int num = 땓.땊.딟(obj2.TileIndexX, obj2.TileIndexY, gameTileComponent.TileIndexX, gameTileComponent.TileIndexY);
        if (num <= this.딟.MaxRange && num >= this.딟.MinRange && (this.딟.IgnoreVisCheck || obj0.딟.땓().get_VisMap().TileIsVisible(obj0.딟.땼(), obj0.딟.땼().떂(), obj0.딟.땄, obj2.TileIndexX, obj2.TileIndexY, gameTileComponent.TileIndexX, gameTileComponent.TileIndexY, this.딟.MaxRange, obj0.딟)))
          this.딟(obj0.딟, obj0.딟.땁()[index], gameTileComponent, obj4, obj0.딟);
      }
    }

    private void 딟([In] 딡 obj0, [In] 딡 obj1, [In] GameTileComponent obj2, [In] int obj3, [In] 딵 obj4)
    {
      if (this.딟 == 1 && obj4.땓(obj1))
      {
        obj0.딟.딟 = obj2;
        obj0.딟.땄 = obj0.딟[obj3];
        obj0.딟.딟 = obj3;
      }
      else
      {
        if (obj1.딟 > 땑.땄)
          return;
        obj0.딟.딟 = obj2;
        obj0.딟.땄 = obj0.딟[obj3];
        obj0.딟.딟 = obj3;
      }
    }
  }
}
