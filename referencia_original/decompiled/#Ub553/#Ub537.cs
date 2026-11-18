// Decompiled with JetBrains decompiler
// Type: 땓.딷
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
  public class 딷 : IDisposable
  {
    private 딴 딟;
    private List<GameObject> 딟;

    public 딷([In] 딶.딡 obj0, [In] 딴 obj1, [In] 땦 obj2, [In] 딢.딯 obj3)
    {
      this.딟 = obj1;
      // ISSUE: reference to a compiler-generated method
      this.딟(new List<GameTileComponent>());
      this.딟 = new List<GameObject>();
      // ISSUE: reference to a compiler-generated method
      this.딟(obj3);
      UnitWeapon unitWeapon = obj0.땼().땻()[obj2.땔()].딢();
      if (Object.op_Equality((Object) unitWeapon, (Object) null))
        return;
      WeaponGameplayData weaponGameplayData = unitWeapon.딟(obj0.땼());
      List<GameTileComponent> gameTileComponentList = obj0.땓().get_TileNetwork().딟(obj2.땴().땃, obj2.땴().딶, weaponGameplayData.MaxRange);
      for (int index = 0; index < gameTileComponentList.Count; ++index)
      {
        int tileIndexX = gameTileComponentList[index].TileIndexX;
        int tileIndexY = gameTileComponentList[index].TileIndexY;
        if (!gameTileComponentList[index].VisBlocker)
        {
          int num = 땊.딟(tileIndexX, tileIndexY, obj2.땴().땃, obj2.땴().딶);
          if (num <= weaponGameplayData.MaxRange && num >= weaponGameplayData.MinRange && obj0.땓().TestLineOfSight(obj0.땼(), obj0.땼().떂(), obj2.땴().땃, obj2.땴().딶, tileIndexX, tileIndexY, -1))
          {
            GameObject gameObject = obj1.딟();
            gameObject.transform.position = Vector3.op_Addition(((Component) obj0.땓().get_Tiles()[tileIndexX, tileIndexY]).transform.position, new Vector3(0.0f, 0.02f, 0.0f));
            this.딟.Add(gameObject);
            this.딟().Add(gameTileComponentList[index]);
          }
        }
      }
    }

    public void Dispose()
    {
      this.딟.딟((IEnumerable<GameObject>) this.딟);
      this.딟.Clear();
      this.딟().Clear();
    }

    [CompilerGenerated]
    [SpecialName]
    public List<GameTileComponent> 딟() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public 딢.딯 땄() => this.딟;
  }
}
