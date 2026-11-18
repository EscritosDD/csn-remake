// Decompiled with JetBrains decompiler
// Type: 땓.떏
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
  public class 떏 : IDisposable
  {
    private List<GameObject> 딟;

    public 떏([In] 딶.딡 obj0, [In] 땦 obj1, [In] 딢.딴 obj2)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(new List<GameTileComponent>());
      this.딟 = new List<GameObject>();
      int index1 = 딶.딢.딟(obj0.땼(), obj0.땼().떂(), obj1.땔(), obj2);
      if (index1 == -1)
        return;
      딶.땚 땚 = obj0.땼().땻()[index1] as 딶.땚;
      if (obj1.땴().딢 < 땚.땃())
        return;
      for (int index2 = 0; index2 < obj0.땼().땻().Count; ++index2)
      {
        if (땚.딟(obj0.땼().떂(), index2))
        {
          땊 땊 = obj0.땼().떎()[index2];
          GameTileComponent gameTileComponent = obj0.땓().get_Tiles()[땊.땃, 땊.딶];
          Transform transform = (Transform) Object.Instantiate((Object) GlobalAppData.딟.GameAssets.HealHighlightModel);
          transform.position = Vector3.op_Addition(((Component) obj0.땓().get_Tiles()[gameTileComponent.TileIndexX, gameTileComponent.TileIndexY]).transform.position, new Vector3(0.0f, 0.01f, 0.0f));
          this.딟.Add(((Component) transform).gameObject);
          this.딟().Add(gameTileComponent);
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
