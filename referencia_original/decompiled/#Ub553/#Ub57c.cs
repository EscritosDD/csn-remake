// Decompiled with JetBrains decompiler
// Type: 땓.땼
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땓
{
  public class 땼 : IDisposable
  {
    private List<GameObject> 딟;
    private 딴 딟;

    public 땼([In] 딶.딡 obj0, [In] 딴 obj1)
    {
      this.딟 = obj1;
      this.딟 = new List<GameObject>();
      foreach (SpawnPointComponent gameComponent in obj0.땼().땃().GetGameComponents<SpawnPointComponent>())
      {
        GameTileComponent component = ((Component) gameComponent).GetComponent<GameTileComponent>();
        Vector3 tileCentre = obj0.땓().GetTileCentre(component.TileIndexX, component.TileIndexY);
        GameObject gameObject = obj1.딟();
        gameObject.transform.position = tileCentre;
        gameObject.transform.rotation = Quaternion.identity;
        int num = gameComponent.Team != 딶.땂.딟 ? 1 : 0;
        땦.딟(gameObject, num, false, 딵.딟);
        this.딟.Add(gameObject);
      }
    }

    public void Dispose() => this.딟.딟((IEnumerable<GameObject>) this.딟);
  }
}
