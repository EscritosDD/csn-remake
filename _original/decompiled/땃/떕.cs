// Decompiled with JetBrains decompiler
// Type: 땃.떕
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땃
{
  public class 떕 : 땶
  {
    public override bool 딟([In] 딵 obj0, [In] 딡 obj1) => base.딟(obj0, obj1) && obj1.딟 == 땪.땓;

    public override 딡 딟([In] 딵 obj0)
    {
      딡 딡1 = (딡) null;
      int index1 = -1;
      for (int index2 = 0; index2 < obj0.땔().Count; ++index2)
      {
        딡 딡2 = obj0.땔()[index2];
        if (this.딟(obj0, 딡2) && obj0.딣().땼().떂().땺()[딡2.딟.땔()].딢 >= 딡2.땄)
        {
          딡 딡3 = this.딟(딡1, 딡2, obj0.딣().땼().떂());
          if (딡3 == 딡2)
          {
            int num = this.딟(obj0, obj0.딣().땼(), obj0.딣().땼().떂(), 딡3);
            if (num != -1)
            {
              index1 = num;
              딡1 = 딡3;
            }
          }
        }
      }
      if (딡1 != null)
      {
        땯 땯 = new 땯();
        땯.땄 = 딡1.딟[index1];
        땯.땄 = 1;
        땯.딟 = 딢.딴.땄;
        땯.딟 = 땝.딢;
        땯.딟 = -1;
        딡1.딟.딟 = index1;
        딡1.딟(땜.딟, 땯);
      }
      return 딡1;
    }

    private int 딟([In] 딵 obj0, [In] 딶.땖 obj1, [In] 딶.땙 obj2, [In] 딡 obj3)
    {
      int num1 = -1;
      땓.땊 땊 = obj2.땺()[obj3.딟.땔()];
      List<int> intList = obj1.땹().GatherBlockingTiles(obj1, obj2);
      float num2 = 0.0f;
      for (int index = 0; index < obj3.딟.Length; ++index)
      {
        int num3 = obj3.딟[index] * obj3.땄;
        if (땊.딢 - num3 - obj3.딟.RequiredActionPoints >= 0)
        {
          float num4 = this.딟(obj0, obj3, obj3.딟[index], obj3.딟, intList);
          if ((double) num4 > (double) num2)
          {
            num2 = num4;
            num1 = index;
          }
        }
      }
      return num1;
    }

    private float 딟(
      [In] 딵 obj0,
      [In] 딡 obj1,
      [In] GameTileComponent obj2,
      [In] WeaponGameplayData obj3,
      [In] List<int> obj4)
    {
      float num1 = 0.0f;
      float num2 = obj3.땄();
      int num3 = Mathf.Min(obj0.땻(), 1);
      int num4 = 0;
      bool flag = false;
      GameGridComponent gameGridComponent = obj0.딣().땓();
      for (int index = 0; index < obj0.땻(); ++index)
      {
        땓.땊 땊 = obj0.땁()[index].딟.땴();
        int num5 = obj0.땁()[index].딟(obj2, obj0.딣().땼());
        if (num5 <= obj3.SplashRange && gameGridComponent.get_VisMap().TileIsVisible(obj0.딣().땼(), obj0.딣().땼().떂(), 1, obj2.TileIndexX, obj2.TileIndexY, 땊.땃, 땊.딶, -1, obj4) && gameGridComponent.GetCoverType(obj2.TileIndexX, obj2.TileIndexY, 땊.땃, 땊.딶) == 딶.딥.딟)
        {
          float num6 = this.딟(num2 + obj3.DamageSpread, 땊, obj3, num5);
          if ((double) num6 >= (double) 땊.딧)
            flag = true;
          num1 += num6;
          ++num4;
        }
      }
      for (int index = 0; index < obj0.땔().Count; ++index)
      {
        if (obj1.딟.땔() != obj0.땔()[index].딟.땔())
        {
          땓.땊 땊 = obj0.땔()[index].딟.땴();
          int num7 = 땊.딟(obj2.TileIndexX, obj2.TileIndexY);
          if (num7 <= obj3.SplashRange)
          {
            float num8 = this.딟(num2 + obj3.DamageSpread, 땊, obj3, num7);
            if ((double) num8 > 0.0 && ((double) num8 >= (double) 땊.딧 || !flag))
            {
              num1 = 0.0f;
              break;
            }
          }
        }
      }
      if (!flag && num4 < num3)
        num1 = 0.0f;
      return num1;
    }

    private float 딟([In] float obj0, [In] 땓.땊 obj1, [In] WeaponGameplayData obj2, [In] int obj3)
    {
      float num = obj2.딟((float) obj3 / (float) obj2.SplashRange);
      return Mathf.Min(obj0 * num, (float) obj1.딧);
    }

    private 딡 딟([In] 딡 obj0, [In] 딡 obj1, [In] 딶.땙 obj2) => !obj1.땃 || obj0 != null && obj2.땺()[obj1.딟.땔()].딧 >= obj2.땺()[obj0.딟.땔()].딧 ? obj0 : obj1;
  }
}
