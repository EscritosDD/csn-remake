// Decompiled with JetBrains decompiler
// Type: 땓.땲
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땓
{
  public class 땲 : IDisposable
  {
    private List<GameObject> 딟;

    public 땲([In] 딶.딡 obj0, [In] 땦 obj1, [In] 딢.딴 obj2)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(new List<GameTileComponent>());
      this.딟 = new List<GameObject>();
      int index = 땃.떊.땄(obj0.땼(), obj0.땼().떂(), obj1.땔(), obj2);
      if (index == -1 || !(obj0.땼().땻()[index] is 딶.땉 땉) || !땃.떊.딟(obj0.땼(), obj0.땼().떂(), obj1.땔(), 땉))
        return;
      int num1 = 땉.땥();
      int num2 = 땉.딝() < 0 ? 256 : 땉.딝();
      foreach (GameTileComponent gameTileComponent in obj0.땓().get_TileNetwork().딟(obj0.땼(), obj0.땼().떂(), obj1.땴().땃, obj1.땴().딶, num2, obj0.땼().땻()[obj1.땔()], obj1.땴().땄, -1))
      {
        if (!obj0.땼().딟(obj0.땼().떂(), obj1.땔(), gameTileComponent.TileIndexX, gameTileComponent.TileIndexY, obj1.땴().땄) && 땊.딟(gameTileComponent.TileIndexX, gameTileComponent.TileIndexY, obj1.땴().땃, obj1.땴().딶) >= num1)
        {
          if (num2 > 0)
          {
            Transform transform = (Transform) Object.Instantiate((Object) GlobalAppData.딟.GameAssets.PlacementHighlightModel);
            transform.position = Vector3.op_Addition(((Component) obj0.땓().get_Tiles()[gameTileComponent.TileIndexX, gameTileComponent.TileIndexY]).transform.position, new Vector3(0.0f, 0.01f, 0.0f));
            this.딟.Add(((Component) transform).gameObject);
          }
          this.딟().Add(obj0.땓().get_Tiles()[gameTileComponent.TileIndexX, gameTileComponent.TileIndexY]);
        }
      }
    }

    public void Dispose()
    {
      foreach (Object @object in this.딟)
        Object.Destroy(@object);
      this.딟.Clear();
      this.딟().Clear();
    }

    [CompilerGenerated]
    [SpecialName]
    public List<GameTileComponent> 딟() => this.딟;
  }
}
