// Decompiled with JetBrains decompiler
// Type: 땓.땢
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
  public class 땢 : IDisposable
  {
    private 딴 딟;
    private 딴 땄;
    private List<GameObject> 딟;
    private List<GameObject> 땄;
    private UnitEmoteBubble 딟;

    public 땢([In] 딶.딡 obj0, [In] 딴 obj1, [In] 딴 obj2, [In] 땦 obj3, [In] GameTileComponent obj4, [In] 딢.딴 obj5, [In] 땦 obj6)
    {
      this.딟 = obj1;
      this.땄 = obj2;
      int index1;
      int index2;
      if (Object.op_Inequality((Object) obj4, (Object) null))
      {
        index1 = obj4.TileIndexX;
        index2 = obj4.TileIndexY;
      }
      else
      {
        index1 = obj3.땴().땃;
        index2 = obj3.땴().딶;
      }
      // ISSUE: reference to a compiler-generated method
      this.딟(new List<GameTileComponent>());
      this.땄 = new List<GameObject>();
      this.딟 = new List<GameObject>();
      딲 딲 = obj0.땼().땻()[obj3.땔()];
      UnitWeapon unitWeapon = 땎.딢(obj5, 딲);
      if (Object.op_Equality((Object) unitWeapon, (Object) null))
        return;
      WeaponGameplayData weaponGameplayData = unitWeapon.딟(obj0.땼());
      List<GameTileComponent> gameTileComponentList1 = obj0.땓().get_TileNetwork().딟(index1, index2, weaponGameplayData.MaxRange);
      List<int> intList = new List<int>();
      for (int index3 = 0; index3 < gameTileComponentList1.Count; ++index3)
      {
        intList.Clear();
        if (땃.땫.딟(obj0.땼(), obj0.땼().떂(), obj3.땔(), index1, index2, obj5, gameTileComponentList1[index3].TileIndexX, gameTileComponentList1[index3].TileIndexY, false, intList) && obj0.땓().TileCanBeAttacked(gameTileComponentList1[index3]))
        {
          int tileIndexX = gameTileComponentList1[index3].TileIndexX;
          int tileIndexY = gameTileComponentList1[index3].TileIndexY;
          List<GameTileComponent> gameTileComponentList2 = this.딟(obj0.땼(), obj3, weaponGameplayData, obj5, gameTileComponentList1[index3], obj6, intList);
          if (gameTileComponentList2 != null && gameTileComponentList2.Count != 0)
          {
            for (int index4 = 0; index4 < gameTileComponentList2.Count; ++index4)
            {
              GameTileComponent gameTileComponent = gameTileComponentList2[index4];
              if (!this.딟().Contains(gameTileComponent))
              {
                GameObject gameObject = obj1.딟();
                gameObject.transform.position = Vector3.op_Addition(((Component) gameTileComponent).transform.position, new Vector3(0.0f, 0.01f, 0.0f));
                this.땄.Add(gameObject.gameObject);
                this.딟().Add(gameTileComponent);
              }
            }
            if (!weaponGameplayData.딟())
            {
              딶.딥 Cover = gameTileComponentList1[index3].GetCoverType(obj0.땓().get_Tiles()[index1, index2]);
              if (Cover != 딶.딥.딢)
              {
                if (!딶.때.땄(weaponGameplayData.DamageType))
                  Cover = 딶.딥.딟;
                float num = 땃.땫.딟(obj0.땼(), obj0.땼().떂(), obj3.땔(), obj5, intList[0], 1f, obj4);
                int DamageScale = Mathf.RoundToInt((weaponGameplayData.딟(obj0.땼().땞(), obj3.땴()) + weaponGameplayData.DamageSpread * 0.5f) * num) * weaponGameplayData.ShotsPerAttack;
                GameObject gameObject = obj2.딟();
                if (this.딟(obj0))
                {
                  this.딟 = gameObject.GetComponent<UnitEmoteBubble>();
                  this.딟.ActivateUnitEmoteBubble(Cover, ((Component) obj0.땓().get_Tiles()[tileIndexX, tileIndexY]).transform.position, weaponGameplayData.RequiredActionPoints, DamageScale);
                  this.딟.Add(gameObject);
                }
              }
            }
          }
        }
      }
    }

    public void Dispose()
    {
      this.딟.딟((IEnumerable<GameObject>) this.땄);
      this.땄.Clear();
      foreach (GameObject gameObject in this.딟)
        gameObject.transform.parent = (Transform) null;
      this.땄.딟((IEnumerable<GameObject>) this.딟);
      this.딟.Clear();
      this.딟().Clear();
    }

    private bool 딟([In] 딶.딡 obj0) => true;

    private List<GameTileComponent> 딟(
      [In] 딶.땖 obj0,
      [In] 땦 obj1,
      [In] WeaponGameplayData obj2,
      [In] 딢.딴 obj3,
      [In] GameTileComponent obj4,
      [In] 땦 obj5,
      [In] List<int> obj6)
    {
      List<GameTileComponent> gameTileComponentList = new List<GameTileComponent>();
      if (obj2.TwoStageAttack)
      {
        if (obj5 == null)
        {
          for (int index = 0; index < obj6.Count; ++index)
          {
            땊 땊 = obj0.떎()[obj6[index]];
            if (땊.땄 != obj0.딝() && 땊.땓())
              gameTileComponentList.Add(obj0.땹().get_Tiles()[땊.땃, 땊.딶]);
          }
          return gameTileComponentList;
        }
        for (int index = 0; index < obj6.Count; ++index)
        {
          if (obj5.땔() == obj6[index])
          {
            gameTileComponentList.Add(obj4);
            break;
          }
        }
        return gameTileComponentList;
      }
      gameTileComponentList.Add(obj4);
      return gameTileComponentList;
    }

    [CompilerGenerated]
    [SpecialName]
    public List<GameTileComponent> 딟() => this.딟;
  }
}
