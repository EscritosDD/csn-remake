// Decompiled with JetBrains decompiler
// Type: 땓.떂
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땓
{
  public class 떂 : 딦
  {
    public 떂([In] 딶.땖 obj0, [In] int obj1, [In] 딶.땩 obj2)
      : base(obj0, obj0.땕(), obj0.땪(), obj1, obj2)
    {
    }

    public override void 딟([In] bool obj0)
    {
      base.딟(obj0);
      if (((딶.땏) this).딟 < 0)
        return;
      땊 땊 = this.딟.땺()[((딶.땏) this).딟];
      GameTileComponent gameTileComponent1 = (GameTileComponent) null;
      this.딟.땻()[((딶.땏) this).딟].땥();
      int num1 = 1;
      딶.땂 땂 = 땊.땄 != 0 ? 딶.땂.땄 : 딶.땂.딟;
      GameTileComponent gameTileComponent2 = (GameTileComponent) null;
      List<GameTileComponent> gameTileComponentList = new List<GameTileComponent>((IEnumerable<GameTileComponent>) this.딟.딳());
      foreach (GameTileComponent gameTileComponent3 in this.딟.딳())
      {
        SpawnPointComponent component = ((Component) gameTileComponent3).GetComponent<SpawnPointComponent>();
        if (Object.op_Equality((Object) component, (Object) null) || component.Team != 땂)
        {
          gameTileComponentList.Remove(gameTileComponent3);
        }
        else
        {
          if (Object.op_Equality((Object) gameTileComponent2, (Object) null))
            gameTileComponent2 = gameTileComponent3;
          int num2 = this.딟.딟(this.딟, gameTileComponent3.TileIndexX, gameTileComponent3.TileIndexY, -1);
          if (num2 != -1 && num2 != ((딶.땏) this).딟)
            gameTileComponentList.Remove(gameTileComponent3);
        }
      }
      if (gameTileComponentList.Count > 0)
      {
        int index = this.딟.땓().딟(0, gameTileComponentList.Count);
        gameTileComponent1 = gameTileComponentList[index];
      }
      else
      {
        do
        {
          GameTileComponent[] gameTileComponentArray = this.딟.땹().get_TileNetwork().딟(this.딟, this.딟, gameTileComponent2.TileIndexX, gameTileComponent2.TileIndexY, num1, (딲) null, -1, -1);
          for (int index1 = 0; index1 != gameTileComponentArray.Length; ++index1)
          {
            int index2 = this.딟.땓().딟(0, gameTileComponentArray.Length);
            int num3 = this.딟.딟(this.딟, gameTileComponentArray[index2].TileIndexX, gameTileComponentArray[index2].TileIndexY, -1);
            if (num3 == -1 || num3 == ((딶.땏) this).딟)
            {
              gameTileComponent1 = gameTileComponentArray[index2];
              break;
            }
          }
          num1 += 2;
        }
        while (Object.op_Equality((Object) gameTileComponent1, (Object) null));
      }
      if (!Object.op_Inequality((Object) gameTileComponent1, (Object) null))
        return;
      땊.땃 = gameTileComponent1.TileIndexX;
      땊.딶 = gameTileComponent1.TileIndexY;
    }

    public override string ToString() => string.Format("[TeleportLogicEvent] Teleporting {0}", (object) ((딶.땏) this).딟);
  }
}
