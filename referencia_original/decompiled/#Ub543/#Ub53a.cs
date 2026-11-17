// Decompiled with JetBrains decompiler
// Type: 땃.딺
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땃
{
  public class 딺 : 떑
  {
    public override void 딟([In] 딠 obj0, [In] 딩 obj1, [In] GameTileComponent obj2, [In] int obj3, [In] int obj4)
    {
      if (!(obj0.딟.땼().떔() is 딶.딮))
        return;
      int num = obj0.딟.떔()[obj2.TileIndexX, obj2.TileIndexY];
      if (num != int.MaxValue)
        num *= obj0.딟;
      obj1.땄 = num;
    }

    public static int 딟([In] 딶.딮 obj0, [In] 딶.딡 obj1, [In] GameTileComponent obj2, [In] int obj3)
    {
      int num1 = -1;
      for (int index = 0; index < obj0.딦().Count; ++index)
      {
        GameTileComponent gameTileComponent = obj0.딦()[index];
        List<GameTileComponent> gameTileComponentList = obj1.땓().get_TileNetwork().딟(obj1.땼(), obj1.땼().떂(), obj2.TileIndexX, obj2.TileIndexY, gameTileComponent.TileIndexX, gameTileComponent.TileIndexY, (땓.딲) null);
        int num2 = 딵.떎;
        if (gameTileComponentList != null)
          num2 = Mathf.Clamp(gameTileComponentList.Count - 1, 0, int.MaxValue);
        int num3 = num2 * obj3;
        if (num1 == -1 || num3 < num1)
          num1 = num3;
      }
      return num1;
    }
  }
}
