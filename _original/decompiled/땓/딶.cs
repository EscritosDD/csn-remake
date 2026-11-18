// Decompiled with JetBrains decompiler
// Type: 땓.딶
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땓
{
  public class 딶 : 딦
  {
    private new int 딟;
    private int 땄;
    private 딢.딯 딟;

    public 딶([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 떒 obj2, [In] int obj3, [In] int obj4, [In] int obj5, [In] 딢.딯 obj6)
      : base(obj0, obj1, obj2, obj3)
    {
      this.딟 = obj5;
      this.땄 = obj4;
      this.딟 = obj6;
    }

    public override void 딟([In] bool obj0)
    {
      땊 땊 = base.딟.땺()[((딶.땏) this).딟];
      딶.땩 땩 = new 딶.땩(땊.땃, 땊.딶);
      int num = this.딟(this.딟, 땊, this.딟, ref 땩);
      땊.땃 = 땩.딟;
      땊.딶 = 땩.땄;
      base.딟.딧(base.딟, this.땄, ((딶.땏) this).딟, num);
      base.딟(obj0);
    }

    public override string ToString() => string.Format("[KnockbackLogicEvent] Unit: {0} Pos: {1} ", (object) ((딶.땏) this).딟, (object) new 딶.땩(base.딟.땺()[((딶.땏) this).딟].땃, base.딟.땺()[((딶.땏) this).딟].딶));

    private int 딟([In] 딢.딯 obj0, [In] 땊 obj1, [In] int obj2, [In] ref 딶.땩 obj3)
    {
      int num1 = 0;
      int num2 = 0;
      switch (obj0)
      {
        case 딢.딯.딟:
          num2 = 1;
          break;
        case 딢.딯.땄:
          num2 = -1;
          break;
        case 딢.딯.딧:
          num1 = 1;
          break;
        case 딢.딯.딢:
          num1 = -1;
          break;
      }
      int 땃 = obj1.땃;
      int 딶 = obj1.딶;
      int num3 = 2;
      int num4 = 1;
      for (int index = 0; index < obj2; ++index)
      {
        땃 += num1;
        딶 += num2;
        if (!Object.op_Equality((Object) base.딟.땹().GetTile(땃, 딶), (Object) null) && !this.딟(obj1.땥(), 땃, 딶, obj1.땄))
        {
          ++num4;
          List<GameTileComponent> gameTileComponentList = base.딟.땹().get_TileNetwork().딟(base.딟, base.딟, obj3.딟, obj3.땄, 땃, 딶, base.딟.땻()[obj1.땥()]);
          if (gameTileComponentList == null || gameTileComponentList.Count > num3)
          {
            --num4;
            break;
          }
          obj3.딟 = 땃;
          obj3.땄 = 딶;
        }
        else
          break;
      }
      return num4 - 1;
    }

    private bool 딟([In] int obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
      if (base.딟.딟(base.딟, obj0, obj1, obj2, obj3, -1))
        return true;
      bool flag = false;
      for (int index = 0; index < base.딟.땺().Count; ++index)
      {
        땊 땊 = base.딟.땺()[index];
        if (땊.땓() && !땊.땺() && 땊.땃 == obj1 && 땊.딶 == obj2 && base.딟.땻()[index].땃())
        {
          flag = true;
          break;
        }
      }
      return flag;
    }
  }
}
