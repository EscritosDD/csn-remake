// Decompiled with JetBrains decompiler
// Type: 땃.떊
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 땃
{
  public class 떊 : 땧
  {
    private int 딟;
    private 딢.딴 딟;
    private 딶.땩 딟;

    public 떊([In] 딶.땋 obj0)
    {
      this.딟 = obj0.딟;
      this.딟 = obj0.딟;
      this.딟 = new 딶.땩(obj0.땄, obj0.딧);
    }

    public 떊([In] TacticsActionData obj0)
    {
      this.딟 = obj0.Index;
      this.딟 = obj0.Ability;
      this.딟.딟 = obj0.TileIndexX;
      this.딟.땄 = obj0.TileIndexY;
    }

    public static int 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] int obj2, [In] 딢.딴 obj3, [In] bool obj4)
    {
      int num1 = 0;
      int num2 = 0;
      while (true)
      {
        int num3 = 떊.딟(obj0, obj1, obj2, obj3, obj4, false, num2);
        if (num3 != -1)
        {
          ++num1;
          num2 = num3 + 1;
        }
        else
          break;
      }
      return num1;
    }

    public static int 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] int obj2, [In] 딢.딴 obj3, [In] bool obj4, [In] bool obj5, [In] int obj6)
    {
      for (int index = obj6; index < obj0.땻().Count; ++index)
      {
        if (obj0.땻()[index] is 딶.땉 땉1 && 땉1.딟() == obj3 && 땉1.땄() == obj2 && (!obj4 || !obj1.땺()[index].땓() || obj1.땺()[index].땺() && obj5))
          return index;
      }
      return -1;
    }

    public static int 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] int obj2, [In] 딢.딴 obj3, [In] bool obj4, [In] bool obj5) => 떊.딟(obj0, obj1, obj2, obj3, obj4, obj5, 0);

    private static int 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] int obj2, [In] 딢.딴 obj3) => 떊.딟(obj0, obj1, obj2, obj3, true, false);

    public static int 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] int obj2, [In] int obj3, [In] 딢.딴 obj4)
    {
      for (int index = 0; index < obj0.땻().Count; ++index)
      {
        if (obj0.땻()[index] is 딶.땉 땉1 && 땉1.딟() == obj4 && obj1.땺()[index].딧 > 0 && obj1.땺()[index].땃 == obj2 && obj1.땺()[index].딶 == obj3)
          return index;
      }
      return -1;
    }

    public override 땓.딟 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 땓.떒 obj2)
    {
      땓.딟 딟 = new 땓.딟();
      딟.딟(떊.딟(obj0, obj1, obj2, this.딟, this.딟, this.딟));
      return 딟;
    }

    public static bool 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] int obj2, [In] 딶.땉 obj3)
    {
      if (obj1.땺()[obj2].딢 < obj3.땺())
        return false;
      딢.딴 딴 = obj3.딟();
      return 떊.땄(obj0, obj1, obj2, 딴) != -1;
    }

    public static int 땄([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] int obj2, [In] 딢.딴 obj3)
    {
      if (땓.땎.땭(obj3) == 딢.떍.딹)
        return 떊.딟(obj0, obj1, obj2, obj3);
      int index = 떊.딟(obj0, obj1, obj2, obj3, true, true);
      if (index != -1 && obj0.땻()[index] is 딶.땷 땷 && 땷.땭() && 떊.딟(obj0, obj1, 땷) == -1)
        index = -1;
      return index;
    }

    public static int 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 딶.땷 obj2)
    {
      int num = -1;
      for (int index = 0; index < obj0.땻().Count; ++index)
      {
        if (obj0.땻()[index] is 딶.땘 땘1)
        {
          땓.땊 땊 = obj1.땺()[index];
          if ((!땊.땓() || 땊.땺()) && 땘1.땳() == obj2.땄() && 땘1.딗() == obj2.딟())
          {
            num = index;
            break;
          }
        }
      }
      return num;
    }

    public static 땓.딟 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 땓.떒 obj2, [In] int obj3, [In] 딶.땩 obj4, [In] 딢.딴 obj5)
    {
      int index = 떊.땄(obj0, obj1, obj3, obj5);
      if (index == -1)
        return (땓.딟) null;
      if (!(obj0.땻()[index] is 딶.땉 땉))
        return (땓.딟) null;
      땓.땊 땊1 = obj1.땺()[obj3];
      if (!떊.딟(obj0, obj1, obj3, 땉))
        return (땓.딟) null;
      if (obj0.딟(obj1, obj3, obj4.딟, obj4.땄, 땊1.땄))
        return (땓.딟) null;
      bool flag = false;
      int num1 = 땉.땥();
      int num2 = 땉.딝() < 0 ? 256 : 땉.딝();
      foreach (GameTileComponent gameTileComponent in obj0.땹().get_TileNetwork().딟(obj0, obj1, 땊1.땃, 땊1.딶, num2, obj0.땻()[땊1.땥()], 땊1.땄, -1))
      {
        if (땓.땊.딟(땊1.땃, 땊1.딶, gameTileComponent.TileIndexX, gameTileComponent.TileIndexY) >= num1 && gameTileComponent.TileIndexX == obj4.딟 && gameTileComponent.TileIndexY == obj4.땄)
        {
          flag = true;
          break;
        }
      }
      if (!flag)
        return (땓.딟) null;
      땓.딟 딟1 = new 땓.딟();
      딢.딯 딟2 = 땊1.딟;
      딢.딯 딯 = 딟2;
      땓.땊 땊2 = obj1.땺()[index];
      if (obj0.떂() != null && obj0.떂().땃() == 땊1.땄 || obj0.땻()[index].딟(땊2, 땊1.땄 != 0 ? 0 : 1))
      {
        if (땊1.딢(딢.떍.딢) >= 0)
          땓.떀.딟(딟1, obj0, obj1, obj2, obj3);
        if (obj0.땉() != null && !obj0.땉().딟.IsInActionFrustum(obj3))
          딟1.딟((딶.땏) new 딶.딜(obj3));
        if (땉.떎() || 땉.딟() != 딢.딴.딚)
          딯 = 땓.땊.땄(땊1.땃, 땊1.딶, obj4.딟, obj4.땄);
        if (딟2 != 딯)
        {
          딟1.딟((딶.땏) new 땓.딝(obj0, obj1, obj2, obj3, new 딶.땩(땊1.땃, 땊1.딶), 딯));
          딟1.딟((딶.땏) new 딶.딬(obj3, 딟2, 딯));
        }
        if (땉.떎())
        {
          string str = 땓.땎.땄(obj5, obj0.땻()[obj3]);
          딟1.딟((딶.땏) new 딶.땐(obj3, obj4));
          딟1.딟((딶.땏) new 딶.땦(obj3, obj5, str));
          Vector3 tileCentre = obj0.땹().GetTileCentre(obj4.딟, obj4.땄);
          UnitWeapon unitWeapon = GlobalAppData.땼().땽(str);
          float num3 = !Object.op_Inequality((Object) unitWeapon, (Object) null) || (double) unitWeapon.ProjectileSpeed <= 0.0 ? 0.5f : unitWeapon.ProjectileSpeed;
          Vector3 vector3 = Vector3.op_Subtraction(tileCentre, obj0.땹().GetTileCentre(땊1.땃, 땊1.딶));
          float num4 = ((Vector3) ref vector3).magnitude / num3;
          딶.떒 떒 = (딶.떒) new 딶.딜(obj4, num4, true);
          ((딶.땏) 떒).딟 = true;
          딟1.딟((딶.땏) 떒);
          딟1.딟((딶.땏) new 딶.땰(new 딶.땩(땊1.땃, 땊1.딶), obj4, str));
        }
        else
        {
          땓.딺 딺 = 땉.딟() != 딢.딴.딚 ? 땓.딺.떎 : 땓.딺.땤;
          string str = obj0.땻()[obj3].딟(obj1.땺()[obj3], 딺);
          딟1.딟((딶.땏) new 딶.땣(obj3, str));
          딶.떒 떒 = (딶.떒) new 딶.딜(obj4, 0.0f);
          ((딶.땏) 떒).딟 = true;
          딟1.딟((딶.땏) 떒);
        }
      }
      딟1.딟((딶.땏) new 땓.땺(obj0, obj1, obj2, obj3, index, obj4));
      딟1.딟((딶.땏) new 딶.땎(index));
      딟1.딟((딶.땏) new 딶.땧(index, true, 0.0f));
      if (!땉.땭())
      {
        switch (obj5)
        {
          case 딢.딴.딚:
            딟1.딟((딶.땏) new 땓.땃(obj0, obj1, obj2, obj3, 딢.떍.떓, 땓.딢.딧, -1));
            break;
          case 딢.딴.땚:
            딟1.딟((딶.땏) new 땓.땃(obj0, obj1, obj2, obj3, 딢.떍.땁, 땓.딢.딧, -1));
            딟1.딟((딶.땏) new 땓.땃(obj0, obj1, obj2, obj3, 딢.떍.땷, 땓.딢.딟, 1));
            break;
        }
      }
      else if (obj0.땻()[index] is 딶.땷)
      {
        int num5 = 떊.딟(obj0, obj1, (딶.땷) obj0.땻()[index]);
        if (num5 != -1)
        {
          땓.딟 딟3 = new 땓.딟();
          딟3.딟((딶.땏) new 딶.딜(obj4));
          딟3.딟((딶.땏) new 땓.땄(obj0, obj1, obj2, index, -obj0.땻()[index].딱()));
          딟3.딟((딶.땏) new 땓.딝(obj0, obj1, obj2, index, 딶.땩.딟, 딢.딯.딟));
          딟3.딟((딶.땏) new 땓.땺(obj0, obj1, obj2, obj3, num5, obj4, true));
          딟3.딟((딶.땏) new 딶.땎(num5));
          딟3.딟((딶.땏) new 땓.땃(obj0, obj1, obj2, obj3, 땓.땎.땭(obj5), 땓.딢.딧, -1));
          딟3.딟((딶.땏) new 딶.땧(num5, true, 0.0f));
          obj1.딟(딟3);
        }
      }
      if (딟2 != 딯 && !땉.떎())
      {
        딟1.딟((딶.땏) new 땓.딝(obj0, obj1, obj2, obj3, new 딶.땩(땊1.땃, 땊1.딶), 딟2));
        딶.떒 떒 = (딶.떒) new 딶.딬(obj3, 딯, 딟2);
        ((딶.땏) 떒).딟 = true;
        딟1.딟((딶.땏) 떒);
      }
      string str1 = obj0.땻()[index].딟(obj1.땺()[index], 땓.딺.떎);
      if (str1 != null)
        딟1.딟((딶.땏) new 딶.땣(index, str1, (WrapMode) 1, 딶.땮.떁, 딶.땮.떁));
      else if (땉.땭())
        딟1.딟((딶.땏) new 딶.땫(index, 땓.딘.떏, 5f, 3f));
      else
        딟1.딟((딶.땏) new 딶.땫(index, 땓.딘.떏));
      딟1.딟((딶.땏) new 땓.떎(obj0, obj1, obj2, index));
      obj2.딟(obj1, obj3, index, obj4.딟, obj4.땄);
      딶.땙 땙 = obj1;
      땙.땄(땙.딢() + obj0.땞().RatingModifiersData.PerAbilityUse);
      return 딟1;
    }

    public override TacticsActionData 딟() => new TacticsActionData()
    {
      Action = 딢.땀.딢,
      Index = this.딟,
      Ability = this.딟,
      TileIndexX = this.딟.딟,
      TileIndexY = this.딟.땄
    };

    public override int 땄() => this.딟;
  }
}
