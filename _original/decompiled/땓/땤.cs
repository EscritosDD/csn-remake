// Decompiled with JetBrains decompiler
// Type: 땓.땤
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
  public class 땤 : IDisposable
  {
    private List<GameObject> 딟;
    private MoveCostBubble 딟;

    public 땤([In] 딶.딡 obj0, [In] 땦 obj1, [In] int obj2, [In] int obj3, [In] int obj4, [In] int obj5, [In] 딢.딯 obj6, [In] int obj7)
    {
      this.딟 = new List<GameObject>();
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0.땓().get_TileNetwork().딟(obj0.땼(), obj0.땼().떂(), obj2, obj3, obj4, obj5, obj0.땼().땻()[obj1.땔()]));
      List<GameTileComponent> gameTileComponentList = new List<GameTileComponent>();
      gameTileComponentList.Add((GameTileComponent) null);
      gameTileComponentList.Add((GameTileComponent) null);
      딢.딯 딯1 = obj6;
      for (int index = 0; index < this.딟().Count - 1; ++index)
      {
        gameTileComponentList[0] = this.딟()[index];
        gameTileComponentList[1] = this.딟()[index + 1];
        딢.딯 딯2 = 땃.땸.딟(딯1, gameTileComponentList, gameTileComponentList.Count);
        float num = 땊.땄(딯2);
        Transform transform1;
        if (index == 0)
          transform1 = GlobalAppData.딟.GameAssets.MovementModelStart;
        else if (딯1 == 딯2)
          transform1 = GlobalAppData.딟.GameAssets.MovementModelStraight;
        else if ((double) 땊.딟(딯1, 딯2) == 90.0)
        {
          num -= 90f;
          transform1 = GlobalAppData.딟.GameAssets.MovementModelTurn;
        }
        else
        {
          num -= 180f;
          transform1 = GlobalAppData.딟.GameAssets.MovementModelTurn2;
        }
        Transform transform2 = (Transform) Object.Instantiate((Object) transform1);
        transform2.position = Vector3.op_Addition(((Component) obj0.땓().get_Tiles()[this.딟()[index].TileIndexX, this.딟()[index].TileIndexY]).transform.position, new Vector3(0.0f, 0.02f, 0.0f));
        transform2.localRotation = Quaternion.Euler(0.0f, num, 0.0f);
        this.딟.Add(((Component) transform2).gameObject);
        딯1 = 딯2;
      }
      float num1 = 땊.땄(딯1);
      Transform transform = (Transform) Object.Instantiate((Object) GlobalAppData.딟.GameAssets.MovementModelEnd);
      transform.position = Vector3.op_Addition(((Component) obj0.땓().get_Tiles()[obj4, obj5]).transform.position, new Vector3(0.0f, 0.02f, 0.0f));
      transform.localRotation = Quaternion.Euler(0.0f, num1, 0.0f);
      this.딟.Add(((Component) transform).gameObject);
      this.딟(obj0, obj1, obj4, obj5);
      this.딟(obj0, obj4, obj5);
    }

    private void 딟([In] 딶.딡 obj0, [In] int obj1, [In] int obj2)
    {
      if (obj1 > 0)
        this.딟(obj0, obj1 - 1, obj2, obj1, obj2, 0.0f);
      if (obj2 + 1 < obj0.땓().SizeY)
        this.딟(obj0, obj1, obj2 + 1, obj1, obj2, 90f);
      if (obj1 + 1 < obj0.땓().SizeX)
        this.딟(obj0, obj1 + 1, obj2, obj1, obj2, 180f);
      if (obj2 <= 0)
        return;
      this.딟(obj0, obj1, obj2 - 1, obj1, obj2, 270f);
    }

    private void 딟([In] 딶.딡 obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4, [In] float obj5)
    {
      GameObject gameObject;
      switch (obj0.땓().GetCoverType(obj1, obj2, obj3, obj4))
      {
        case 딶.딥.땄:
          gameObject = GlobalAppData.딟.GameAssets.CoverHighlightMedium;
          break;
        case 딶.딥.딧:
          gameObject = GlobalAppData.딟.GameAssets.CoverHighlightLow;
          break;
        case 딶.딥.딢:
          gameObject = GlobalAppData.딟.GameAssets.CoverHighlightHigh;
          break;
        default:
          return;
      }
      Vector3 tileCentre = obj0.땓().GetTileCentre(obj3, obj4);
      Quaternion quaternion = Quaternion.Euler(new Vector3(0.0f, obj5, 0.0f));
      this.딟.Add(Object.Instantiate((Object) gameObject, tileCentre, quaternion) as GameObject);
    }

    private void 딟([In] 딶.딡 obj0, [In] 땦 obj1, [In] int obj2, [In] int obj3)
    {
      this.딟 = Object.Instantiate((Object) GlobalAppData.딟.GameAssets.MovementCostBubbleUI) as MoveCostBubble;
      this.딟.ActivateMoveCostBubble(땃.땸.딟(this.딟(), this.딟().Count, obj0.땼().땻()[obj1.땔()]), Vector3.op_Addition(((Component) obj0.땓().get_Tiles()[obj2, obj3]).transform.position, new Vector3(0.0f, 1f, 0.0f)));
      this.딟.Add(((Component) this.딟).gameObject);
    }

    public void Dispose()
    {
      foreach (Object @object in this.딟)
        Object.Destroy(@object);
    }

    [CompilerGenerated]
    [SpecialName]
    public List<GameTileComponent> 딟() => this.딟;
  }
}
