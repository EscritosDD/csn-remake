// Decompiled with JetBrains decompiler
// Type: 땃.땬
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 땃
{
  public class 땬 : 땧
  {
    private int 딟;
    private int 땄;
    private int 딧;
    private 딢.딯 딟;

    public 땬([In] TacticsActionData obj0)
    {
      this.딟 = obj0.Index;
      this.땄 = obj0.TileIndexX;
      this.딧 = obj0.TileIndexY;
      this.딟 = obj0.Direction;
    }

    public 땬([In] int obj0, [In] int obj1, [In] int obj2, [In] 딢.딯 obj3)
    {
      this.딟 = obj0;
      this.땄 = obj1;
      this.딧 = obj2;
      this.딟 = obj3;
    }

    public override TacticsActionData 딟() => new TacticsActionData()
    {
      Action = 딢.땀.딧,
      Index = this.딟,
      TileIndexX = this.땄,
      TileIndexY = this.딧,
      Direction = this.딟
    };

    public override 땓.딟 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 땓.떒 obj2)
    {
      땓.딟 딟 = new 땓.딟();
      딟.딟(땬.딟(obj0, obj1, obj2, this.딟, new 딶.땩(this.땄, this.딧), this.딟));
      return 딟;
    }

    private static 땓.딟 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 땓.떒 obj2, [In] int obj3, [In] 딶.땩 obj4, [In] 딢.딯 obj5)
    {
      if (obj3 < 0 || obj3 >= obj1.땺().Count)
        return (땓.딟) null;
      if (!obj0.땻()[obj3].땺())
        return (땓.딟) null;
      GameTileComponent gameTileComponent1 = (GameTileComponent) null;
      if (obj0.떔().딶())
      {
        gameTileComponent1 = obj0.땹().GetTile(obj4.딟, obj4.땄);
      }
      else
      {
        for (int index = 0; index < obj0.딳().Count; ++index)
        {
          GameTileComponent gameTileComponent2 = obj0.딳()[index];
          if (gameTileComponent2.TileIndexX == obj4.딟 && gameTileComponent2.TileIndexY == obj4.땄)
          {
            gameTileComponent1 = gameTileComponent2;
            break;
          }
        }
      }
      if (Object.op_Equality((Object) gameTileComponent1, (Object) null))
        return (땓.딟) null;
      if (!obj0.떔().딶())
      {
        SpawnPointComponent component = ((Component) gameTileComponent1).GetComponent<SpawnPointComponent>();
        if ((component.Team != 딶.땂.딟 ? 1 : 0) != obj1.땃())
          return (땓.딟) null;
        if (component.Direction != obj5)
          return (땓.딟) null;
      }
      땓.땊 땊 = obj1.땺()[obj3];
      if (땊.땄 != obj1.땃())
        return (땓.딟) null;
      if (땊.땓())
        return (땓.딟) null;
      땓.딟 딟 = new 땓.딟();
      딟.딟((딶.땏) new 땓.딝(obj0, obj1, obj2, obj3, obj4, obj5));
      딟.딟((딶.땏) new 땓.땄(obj0, obj1, obj2, obj3, obj0.땻()[obj3].딱()));
      딟.딟((딶.땏) new 땓.딧(obj0, obj1, obj2, obj3, obj0.땻()[obj3].딟(땊)));
      if (obj0 != null && obj0.땉() != null)
        obj0.땉().딷()?.딟(obj3).딟(땓.땊.딟(땊.딟));
      딟.딟((딶.땏) new 딶.딭(obj3, obj4.딟, obj4.땄));
      return 딟;
    }

    private static GameTileComponent 딟([In] 딶.땖 obj0, [In] int obj1)
    {
      if (obj0.딳().Count == 0)
        return (GameTileComponent) null;
      int num1 = int.MaxValue;
      int num2 = int.MaxValue;
      int num3 = -1;
      int num4 = -1;
      for (int index = 0; index < obj0.딳().Count; ++index)
      {
        GameTileComponent gameTileComponent = obj0.딳()[index];
        if ((((Component) gameTileComponent).GetComponent<SpawnPointComponent>().Team != 딶.땂.딟 ? 1 : 0) == obj1)
        {
          if (gameTileComponent.TileIndexX > num3)
            num3 = gameTileComponent.TileIndexX;
          if (gameTileComponent.TileIndexY > num4)
            num4 = gameTileComponent.TileIndexY;
          if (gameTileComponent.TileIndexX < num1)
            num1 = gameTileComponent.TileIndexX;
          if (gameTileComponent.TileIndexY < num2)
            num2 = gameTileComponent.TileIndexY;
        }
      }
      int index1 = (num1 + num3) / 2;
      int index2 = (num2 + num4) / 2;
      return obj0.땹().get_Tiles()[index1, index2];
    }
  }
}
