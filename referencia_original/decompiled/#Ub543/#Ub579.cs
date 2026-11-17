// Decompiled with JetBrains decompiler
// Type: 땃.땹
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땃
{
  public class 땹 : 땁
  {
    private 땕 딟;
    private int 딟;
    private int 땄;
    private int 딧;
    private int 딢;
    private 땝 딟;
    private GameTileComponent 딟;
    protected 땹.떇 딟;

    public 땹([In] 딢.딴 obj0, [In] int obj1, [In] int obj2, [In] GameTileComponent obj3, [In] 땝 obj4)
      : base(obj0)
    {
      this.딟 = obj1;
      this.딢 = obj2;
      this.딟 = 땹.떇.딟;
      this.딟 = obj4;
      this.딟 = obj3;
    }

    public override 땻 딟([In] 딶.딡 obj0, [In] 딡 obj1, [In] 딶.땙 obj2)
    {
      땻 땻 = 땻.땄;
      땓.땊 땊 = obj2.땺()[obj1.딟.땔()];
      switch (this.딟)
      {
        case 땹.떇.딟:
          this.딟(obj0, 땊, obj2, obj1);
          땻 = this.땄(obj0, 땊, obj2, obj1);
          break;
        case 땹.떇.땄:
          땻 = this.땄(obj0, obj1, obj2);
          break;
      }
      return 땻;
    }

    protected bool 딟([In] 딶.땙 obj0)
    {
      if (this.딟.딟 != -1)
      {
        땓.땊 땊 = obj0.땺()[this.딟.딟];
        return !땊.땺() && 땊.땃 == this.땄 && 땊.딶 == this.딧;
      }
      return Object.op_Inequality((Object) this.딟, (Object) null) && this.딟.TileIndexX == this.땄 && this.딟.TileIndexY == this.딧;
    }

    protected 땻 땄([In] 딶.딡 obj0, [In] 딡 obj1, [In] 딶.땙 obj2)
    {
      땻 땻 = 땻.딧;
      if (!this.딟(obj2))
        return 땻.딶;
      GameTileComponent gameTileComponent = (GameTileComponent) null;
      if (this.딟.딟 != -1)
      {
        땓.땊 땊 = obj2.땺()[this.딟.딟];
        gameTileComponent = obj0.땓().get_Tiles()[땊.땃, 땊.딶];
      }
      else if (Object.op_Inequality((Object) this.딟, (Object) null))
        gameTileComponent = this.딟;
      int num = 0;
      for (int index = 0; index < this.딢; ++index)
      {
        딼 딼 = new 딼(new 딶.땽(obj1.딟.땔(), this.딟(), gameTileComponent.TileIndexX, gameTileComponent.TileIndexY));
        if (딼 != null)
        {
          if (땁.딟((땧) 딼, obj0))
            ++num;
          if (!this.딟(obj2))
          {
            땻 = 땻.딶;
            break;
          }
        }
        else
          break;
      }
      return 땻;
    }

    public static string 딟([In] 딶.딡 obj0, [In] int obj1)
    {
      string empty = string.Empty;
      땓.딲 딲 = obj0.땼().땻()[obj1];
      if (딲 != null && 딲 is 땓.떀 떀)
        empty = 떀.땁().ClassType.ToString();
      return empty;
    }

    protected void 딟([In] 딶.딡 obj0, [In] 땓.땊 obj1, [In] 딶.땙 obj2, [In] 딡 obj3)
    {
      this.딟 = obj0.떁().딟(obj3.딟.땔(), this.딟, this.딢, this.딟);
      if (this.딟.딟 != -1)
      {
        땓.땊 땊 = obj2.땺()[this.딟.딟];
        this.땄 = 땊.땃;
        this.딧 = 땊.딶;
      }
      else
      {
        if (!Object.op_Inequality((Object) this.딟, (Object) null))
          return;
        this.땄 = this.딟.TileIndexX;
        this.딧 = this.딟.TileIndexY;
      }
    }

    protected 땻 땄([In] 딶.딡 obj0, [In] 땓.땊 obj1, [In] 딶.땙 obj2, [In] 딡 obj3)
    {
      if (!this.딟(obj2))
        return 땻.딶;
      땻 땻 = 땻.땄;
      if (obj1.땃 == this.딟.땄 && obj1.딶 == this.딟.딧)
      {
        this.딟 = 땹.떇.땄;
      }
      else
      {
        List<GameTileComponent> gameTileComponentList = obj0.땓().get_TileNetwork().딟(obj0.땼(), obj2, obj1.땃, obj1.딶, this.딟.땄, this.딟.딧, obj0.땼().땻()[obj1.땥()]);
        if (gameTileComponentList != null)
        {
          if (obj3.딟[this.딟.땓] * obj3.땄 == Math.Max(0, gameTileComponentList.Count - 1) * obj3.땄)
          {
            int num;
            bool flag = this.딟(obj0, obj3, gameTileComponentList, obj2, this.딟.땄, this.딟.딧, out num);
            if (num != -1)
              this.딟 = 땹.떇.딟;
            else if (flag)
              this.딟 = 땹.떇.땄;
            else
              땻 = 땻.땃;
          }
          else
          {
            obj3.딟[0] = true;
            땻 = 땻.딢;
          }
        }
        else
        {
          obj3.딟[0] = true;
          땻 = 땻.딢;
        }
      }
      return 땻;
    }

    public enum 떇
    {
      딟,
      땄,
      딧,
    }
  }
}
