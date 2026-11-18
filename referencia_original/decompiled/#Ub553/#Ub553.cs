// Decompiled with JetBrains decompiler
// Type: 땓.땓
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 땓
{
  public class 땓 : 딦
  {
    private 딢.딯 딟;

    public 땓([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 떒 obj2, [In] int obj3, [In] 딢.딯 obj4)
      : base(obj0, obj1, obj2, obj3)
    {
      this.딟 = obj4;
    }

    public override void 딟([In] bool obj0)
    {
      base.딟(obj0);
      땊 땊 = base.딟.땺()[((딶.땏) this).딟];
      딶.땩 땩 = 떀.땓(땊);
      GameTileComponent gameTileComponent = base.딟.땹().get_Tiles()[땩.딟, 땩.땄];
      if (base.딟.딟(base.딟, ((딶.땏) this).딟, 땩.딟, 땩.땄, 땊.땄, -1))
        gameTileComponent = base.딟.땹().get_TileNetwork().딟(base.딟, base.딟, 땩.딟, 땩.땄, 20, (딲) null, -1);
      땊.땃 = gameTileComponent.TileIndexX;
      땊.딶 = gameTileComponent.TileIndexY;
      땊.딟 = this.딟;
    }

    public override string ToString() => string.Format("[PlaceGhostedUnitLogicEvent] Unit: {0} Dir: {1} ", (object) ((딶.땏) this).딟, (object) this.딟);
  }
}
