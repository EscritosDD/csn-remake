// Decompiled with JetBrains decompiler
// Type: 땓.땽
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
  public class 땽 : IDisposable
  {
    private 딴 딟;
    private GameObject[] 딟;
    private 딴 땄;
    private List<GameObject> 딟;
    private 딴 딧;
    private List<GameObject> 땄;
    private 딴 딢;
    private List<GameObject> 딧;
    private List<GameTileComponent> 딟;
    private List<땽.땋> 딟;

    public 땽([In] 딴 obj0, [In] 딴 obj1, [In] 딴 obj2, [In] 딴 obj3, [In] 딶.딡 obj4, [In] 땦 obj5)
    {
      this.딟 = obj0;
      this.땄 = obj1;
      this.딧 = obj2;
      this.딢 = obj3;
      this.딟 = new List<GameObject>();
      this.땄 = new List<GameObject>();
      this.딧 = new List<GameObject>();
      // ISSUE: reference to a compiler-generated method
      this.딟(new List<GameTileComponent>());
      this.딟 = new List<땽.땋>();
      this.딟 = new List<GameTileComponent>();
      딲 딲 = obj4.땼().땻()[obj5.땔()];
      int num1 = 딲.땥();
      int num2 = obj5.땴().딢 / num1;
      GameTileComponent[] gameTileComponentArray;
      int[] numArray;
      obj4.땓().get_TileNetwork().딟(obj4.땼(), obj4.땼().떂(), obj5.땴().땃, obj5.땴().딶, num2, 딲, obj5.땴().땄, -1, out gameTileComponentArray, out numArray);
      for (int index = 0; index < obj4.땼().떂().땺().Count; ++index)
      {
        땊 땊 = obj4.땼().떂().땺()[index];
        if (obj5.땴().땄 != 땊.땄 && obj4.땼().딟(obj4.땼().떂(), index, 땊.땃, 땊.딶, obj5.땴().땄, false))
        {
          땽.땋 땋;
          땋.딟 = index;
          땋.딟 = 땊;
          this.딟.Add(땋);
        }
      }
      List<Vector3> vector3List = new List<Vector3>();
      for (int index = 0; index < gameTileComponentArray.Length; ++index)
      {
        int num3 = obj5.땴().딢 - numArray[index] * num1;
        this.딟(obj4, obj5, gameTileComponentArray[index], vector3List);
        this.딟(obj4, obj5, num3, gameTileComponentArray[index]);
      }
      this.딟(obj4, obj5, obj5.땴().딢, obj4.땼().땹().GetTile(obj5.땴().땃, obj5.땴().딶));
      this.딟 = obj0.딟(vector3List.Count);
      for (int index = 0; index < vector3List.Count; ++index)
        this.딟[index].transform.position = vector3List[index];
    }

    private void 딟([In] 딶.딡 obj0, [In] 땦 obj1, [In] GameTileComponent obj2, [In] List<Vector3> obj3)
    {
      int tileIndexX = obj2.TileIndexX;
      int tileIndexY = obj2.TileIndexY;
      int num = obj0.땼().땄(obj0.땼().떂(), obj1.땔(), tileIndexX, tileIndexY, obj1.땴().땄, -1);
      if (num != -1 && obj0.땼().딟(obj0.땼().떂(), num, tileIndexX, tileIndexY, obj1.땴().땄, false) || this.딟().Contains(obj2))
        return;
      Vector3 vector3 = Vector3.op_Addition(obj0.땓().GetTileCentre(tileIndexX, tileIndexY), new Vector3(0.0f, 0.01f, 0.0f));
      obj3.Add(vector3);
      this.딟().Add(obj2);
    }

    private void 딟([In] 딶.딡 obj0, [In] 땦 obj1, [In] int obj2, [In] GameTileComponent obj3)
    {
      int tileIndexX = obj3.TileIndexX;
      int tileIndexY = obj3.TileIndexY;
      int num1 = obj0.땼().땄(obj0.땼().떂(), obj1.땔(), tileIndexX, tileIndexY, obj1.땴().땄, -1);
      if (num1 != -1 && obj0.땼().딟(obj0.땼().떂(), num1, tileIndexX, tileIndexY, obj1.땴().땄, false))
        return;
      UnitWeapon unitWeapon = obj0.땼().땻()[obj1.땔()].딢();
      if (Object.op_Equality((Object) unitWeapon, (Object) null))
        return;
      WeaponGameplayData weaponGameplayData = unitWeapon.딟(obj0.땼());
      if (weaponGameplayData.RequiredActionPoints > obj2 || weaponGameplayData.TwoStageAttack)
        return;
      딶.땯 땯 = obj0.딷();
      float num2 = 0.0f;
      int num3 = -1;
      for (int index = 0; index < this.딟.Count; ++index)
      {
        땽.땋 땋 = this.딟[index];
        if (obj0.땼().땻()[땋.딟].땽())
        {
          int num4 = 땊.딟(tileIndexX, tileIndexY, 땋.딟.땃, 땋.딟.딶);
          if (num4 <= weaponGameplayData.MaxRange && num4 >= weaponGameplayData.MinRange && obj0.땼().딟(obj0.땼().떂(), obj1.땔(), tileIndexX, tileIndexY, 땋.딟, 땋.딟.땃, 땋.딟.딶, true, false))
          {
            float num5 = 0.0f;
            if (땯 != null)
              num5 = 땯.딟(땋.딟, obj3);
            if ((double) num5 > (double) num2)
            {
              num3 = 땋.딟;
              num2 = num5;
            }
          }
        }
      }
      if (num3 == -1)
        return;
      GameObject gameObject;
      if ((double) num2 >= (double) GlobalAppData.딟.GameAssets.HighDamageThreshold)
      {
        gameObject = this.땄.딟();
        this.딟.Add(gameObject);
      }
      else if ((double) num2 >= (double) GlobalAppData.딟.GameAssets.MediumDamageThreshold)
      {
        gameObject = this.딧.딟();
        this.땄.Add(gameObject);
      }
      else
      {
        gameObject = this.딢.딟();
        this.딧.Add(gameObject);
      }
      gameObject.transform.position = Vector3.op_Addition(((Component) obj0.땓().get_Tiles()[tileIndexX, tileIndexY]).transform.position, new Vector3(0.0f, 0.02f, 0.0f));
      this.딟.Add(obj3);
    }

    public void Dispose()
    {
      this.딟().Clear();
      this.딟.딟((IEnumerable<GameObject>) this.딟);
      this.땄.딟((IEnumerable<GameObject>) this.딟);
      this.딧.딟((IEnumerable<GameObject>) this.땄);
      this.딢.딟((IEnumerable<GameObject>) this.딧);
      this.딟.Clear();
    }

    public bool 딟([In] GameTileComponent obj0) => this.딟.Contains(obj0);

    [CompilerGenerated]
    [SpecialName]
    public List<GameTileComponent> 딟() => this.땄;

    private struct 땋
    {
      public 땊 딟;
      public int 딟;
    }
  }
}
