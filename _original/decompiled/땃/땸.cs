// Decompiled with JetBrains decompiler
// Type: 땃.땸
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땃
{
  public class 땸 : 땧
  {
    private int 딟;
    private int 땄;
    public int 딧;

    public 땸([In] TacticsActionData obj0)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0.Index);
      this.딟 = obj0.TileIndexX;
      this.땄 = obj0.TileIndexY;
      this.딧 = -1;
    }

    public 땸([In] 딶.땤 obj0)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0.딟);
      this.딟 = obj0.땄;
      this.땄 = obj0.딧;
      this.딧 = -1;
    }

    public override TacticsActionData 딟() => new TacticsActionData()
    {
      Action = 딢.땀.땄,
      Index = this.딧(),
      TileIndexX = this.딟,
      TileIndexY = this.땄
    };

    public override int 땄() => this.딧();

    public static int 딟([In] List<GameTileComponent> obj0, [In] int obj1, [In] 땓.딲 obj2) => obj2.땥() * Mathf.Max(0, obj1 - 1);

    public override 땓.딟 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 땓.떒 obj2)
    {
      땓.딟 딟 = new 땓.딟();
      딟.딟(땸.딟(obj0, obj1, obj2, this.딧(), new 딶.땩(this.딟, this.땄), ref this.딧));
      return 딟;
    }

    public static 땓.딟 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 땓.떒 obj2, [In] int obj3, [In] 딶.땩 obj4, [In] ref int obj5)
    {
      if (obj3 < 0 || obj3 >= obj1.땺().Count)
        return (땓.딟) null;
      if (!obj0.땻()[obj3].땄(딢.딴.땔))
        return (땓.딟) null;
      땓.땊 땊 = obj1.땺()[obj3];
      if (땊.땄 != obj1.땃())
        return (땓.딟) null;
      if (땊.땺())
        return (땓.딟) null;
      List<GameTileComponent> gameTileComponentList = obj0.땹().get_TileNetwork().딟(obj0, obj1, 땊.땃, 땊.딶, obj4.딟, obj4.땄, obj0.땻()[obj3]);
      if (gameTileComponentList == null)
        return (땓.딟) null;
      if (땸.딟(gameTileComponentList, gameTileComponentList.Count, obj0.땻()[obj3]) > 땊.딢)
        return (땓.딟) null;
      List<int> intList = new List<int>();
      땸.딟(obj0, obj1, 땊, intList);
      딶.땩 땩 = new 딶.땩(땊.땃, 땊.딶);
      List<딬> 딬List = new List<딬>();
      땸.딟(obj0, obj1, obj3, 땊, gameTileComponentList, intList, 딬List, ref obj5);
      땊.땃 = 땩.딟;
      땊.딶 = 땩.땄;
      if (딬List.Count <= 0)
        return (땓.딟) null;
      땓.딟 딟 = new 땓.딟();
      bool flag = obj0.딟(obj1, obj3, 땊.땃, 땊.딶, obj0.딝(), false);
      땸.딟(딟, obj0, obj1, obj2, obj3, 땊, 딬List, flag);
      땊.땃 = 땩.딟;
      땊.딶 = 땩.땄;
      return 딟;
    }

    public static void 딟(
      [In] 딶.땖 obj0,
      [In] 딶.땙 obj1,
      [In] int obj2,
      [In] 땓.땊 obj3,
      [In] List<GameTileComponent> obj4,
      [In] List<int> obj5,
      [In] List<딬> obj6,
      [In] ref int obj7)
    {
      for (int index = 0; index < obj4.Count; ++index)
      {
        딬 딬 = new 딬(obj4[index]);
        obj6.Add(딬);
        if (!obj0.딟(obj1, obj3.땥(), obj4[index].TileIndexX, obj4[index].TileIndexY, obj3.땄, obj2))
        {
          obj3.땃 = obj4[index].TileIndexX;
          obj3.딶 = obj4[index].TileIndexY;
          땊 땊1 = 땸.딟(obj0, obj1, obj2);
          if (땊1 != null && 땊1.딟 != -1)
            딬.딟 = 땊1;
          땊 땊2 = 땸.땄(obj0, obj1, obj2);
          if (땊2 != null)
            딬.땄 = 땊2;
          if (땸.딟(obj0, obj1, obj2, obj5, 딬, index, ref obj7))
            break;
        }
      }
    }

    private static bool 딟(
      [In] 딶.땖 obj0,
      [In] 딶.땙 obj1,
      [In] int obj2,
      [In] List<int> obj3,
      [In] 딬 obj4,
      [In] int obj5,
      [In] ref int obj6)
    {
      bool flag = false;
      if (obj3 == null)
        return flag;
      for (int index1 = 0; index1 < obj3.Count; ++index1)
      {
        int index2 = obj3[index1];
        딢.딴 딴 = obj0.땻()[index2].딟(obj1, obj2);
        if (딴 != 딢.딴.딟 && (obj5 > 0 || 딴 == 딢.딴.땟))
        {
          obj4.딟 = new 땍();
          obj4.딟.딟 = 딴;
          obj4.딟.딟 = index2;
          if (딴 != 딢.딴.땟)
          {
            obj6 = index2;
            flag = true;
          }
        }
      }
      return flag;
    }

    public static void 딟(
      [In] 땓.딟 obj0,
      [In] 딶.땖 obj1,
      [In] 딶.땙 obj2,
      [In] 땓.떒 obj3,
      [In] int obj4,
      [In] 땓.땊 obj5,
      [In] List<딬> obj6,
      [In] bool obj7)
    {
      딢.딯 딟 = obj5.딟;
      if (obj6.Count < 2)
        return;
      땸.딟(obj1, obj2, obj4, obj6, 딟);
      if (obj7)
      {
        obj0.딟((딶.땏) new 딶.딻(obj4));
        딢.딯 딯 = 땓.땊.땄(obj6[0].딟.TileIndexX, obj6[0].딟.TileIndexY, obj6[1].딟.TileIndexX, obj6[1].딟.TileIndexY);
        if (딟 != 딯)
        {
          obj0.딟((딶.땏) new 땓.딝(obj1, obj2, obj3, obj4, new 딶.땩(obj5.땃, obj5.딶), 딯));
          obj0.딟((딶.땏) new 딶.딬(obj4, 딟, 딯));
        }
      }
      string str = obj1.땻()[obj4].딟(obj5, 땓.딺.딟);
      int num = obj1.땻()[obj4].땥();
      for (int index = 1; index < obj6.Count; ++index)
      {
        딬 딬 = obj6[index];
        obj0.딟((딶.땏) new 땓.딧(obj1, obj2, obj3, obj4, -num));
        obj3?.딟(obj2, obj4, obj6[index].딟.TileIndexX, obj6[index].딟.TileIndexY);
        obj5.땃 = 딬.딟.TileIndexX;
        obj5.딶 = 딬.딟.TileIndexY;
        if (obj7)
          obj0.딟((딶.땏) new 딶.딵(obj4, 딟, obj6, index - 1));
        obj0.딟((딶.땏) new 땓.딝(obj1, obj2, obj3, obj4, new 딶.땩(obj6[index].딟.TileIndexX, obj6[index].딟.TileIndexY), obj6[index].딟.딟));
        if (딬.딟 != null)
        {
          딶.땘 땘 = obj1.땻()[딬.딟.딟] as 딶.땘;
          땘.딟(obj0, obj1, obj2, obj3, obj4);
          땘.딟(obj0, obj1, obj4, obj7);
          obj0.딟((딶.땏) new 땓.딝(obj1, obj2, obj3, 딬.딟.딟, 딶.땩.딟, 딢.딯.딟));
          obj0.딟((딶.땏) new 딶.떊(딬.딟.딟));
        }
        if (딬.땄 != null)
        {
          (obj1.땻()[딬.땄.딟] as 딶.땹).딟(obj0, obj4);
          obj0.딟((딶.땏) new 땓.땃(obj1, obj2, obj3, 딬.땄.딟, 딢.떍.딟, 땓.딢.딟, 1));
          obj0.딟((딶.땏) new 땓.딝(obj1, obj2, obj3, 딬.땄.딟, 딶.땩.딟, 딢.딯.딟));
          obj0.딟((딶.땏) new 딶.떊(딬.땄.딟));
        }
        if (obj7 && 딬.딟 != null)
        {
          if (딬.딟.딟 == 딢.딴.땟)
          {
            if (obj1.땻()[obj4].떏())
              obj0.딟((딶.땏) new 땓.땃(obj1, obj2, obj3, 딬.딟.딟, 딢.떍.땲, 땓.딢.딟, obj4));
          }
          else
          {
            if (str != null)
            {
              딶.땣 땣 = new 딶.땣(obj4, str);
              ((딶.땏) 땣).딟 = true;
              obj0.딟((딶.땏) 땣);
            }
            땫.딟(obj0, obj1, 딬.딟.딟, 딬.딟.딟, new 딶.땩(obj2.땺()[obj4].땃, obj2.땺()[obj4].딶), 1f, 딤.딧);
          }
          obj0.딟((딶.땏) new 땓.땃(obj1, obj2, obj3, 딬.딟.딟, 딢.떍.땺, 땓.딢.딧, -1));
        }
      }
      if (!obj7)
        return;
      obj0.딟((딶.땏) new 딶.땍(obj4));
    }

    private static void 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 땓.땊 obj2, [In] List<int> obj3)
    {
      for (int index = 0; index < obj0.땻().Count; ++index)
      {
        if (obj1.땺()[index].땄 != obj2.땄 && obj0.땻()[index].딟(obj1.땺()[index], false))
          obj3.Add(index);
      }
    }

    private static 땊 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] int obj2)
    {
      땓.땊 땊 = obj1.땺()[obj2];
      for (int index = 0; index < obj1.땺().Count; ++index)
      {
        if (obj1.땺()[index].땃 == 땊.땃 && obj1.땺()[index].딶 == 땊.딶 && obj0.땻()[index] is 딶.땘 && !obj1.땺()[index].땺())
          return new 땊()
          {
            딟 = index,
            땄 = obj1.땺()[index].땃,
            딧 = obj1.땺()[index].딶
          };
      }
      return (땊) null;
    }

    private static 땊 땄([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] int obj2)
    {
      땓.땊 땊 = obj1.땺()[obj2];
      if (땊.땄 != 0)
        return (땊) null;
      for (int index = 0; index < obj1.땺().Count; ++index)
      {
        if (obj1.땺()[index].땃 == 땊.땃 && obj1.땺()[index].딶 == 땊.딶 && obj0.땻()[index] is 딶.땹 && !obj1.땺()[index].땺())
          return new 땊()
          {
            딟 = index,
            땄 = obj1.땺()[index].땃,
            딧 = obj1.땺()[index].딶
          };
      }
      return (땊) null;
    }

    private static void 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] List<땊> obj2)
    {
      if (obj2 == null || obj0 == null)
        return;
      for (int index = 0; index < obj2.Count; ++index)
      {
        땓.땊 땊 = obj1.땺()[obj2[index].딟];
        땊.땃 = -1;
        땊.딶 = -1;
        땊.딧 = 0;
      }
    }

    public static 딢.딯 딟([In] 딢.딯 obj0, [In] List<딬> obj1)
    {
      GameTileComponent 딟 = obj1[0].딟;
      딢.딯 딯 = obj0;
      for (int index = 1; index < obj1.Count; ++index)
      {
        딯 = 땸.딟(딟, obj1[index].딟, 딯);
        딟 = obj1[index].딟;
      }
      return 딯;
    }

    public static 딢.딯 딟([In] 딢.딯 obj0, [In] List<GameTileComponent> obj1, [In] int obj2)
    {
      GameTileComponent gameTileComponent = obj1[0];
      딢.딯 딯 = obj0;
      for (int index = 1; index < obj2; ++index)
      {
        딯 = 땸.딟(gameTileComponent, obj1[index], 딯);
        gameTileComponent = obj1[index];
      }
      return 딯;
    }

    private static void 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] int obj2, [In] List<딬> obj3, [In] 딢.딯 obj4)
    {
      bool flag = (double) Random.value > 0.5;
      obj3[0].딟 = new 딶.딽()
      {
        딟 = 땸.딟(obj3[0].딟, obj3[1].딟, obj4),
        딟 = false,
        딟 = obj0.땹().GetTileCentre(obj3[0].딟.TileIndexX, obj3[0].딟.TileIndexY)
      };
      딢.딯 딯 = 땸.딟(obj4, obj3);
      for (int index = 1; index < obj3.Count - 1; ++index)
        obj3[index].딟 = new 딶.딽()
        {
          딟 = 땸.딟(obj3[index].딟, obj3[index + 1].딟, obj3[index - 1].딟.딟),
          딟 = 땸.땄(obj0, obj1, new 딶.땩(obj3[index].딟.TileIndexX, obj3[index].딟.TileIndexY), obj2),
          딟 = obj0.땹().GetTileCentre(obj3[index].딟.TileIndexX, obj3[index].딟.TileIndexY)
        };
      obj3[obj3.Count - 1].딟 = new 딶.딽()
      {
        딟 = 딯,
        딟 = false,
        딟 = obj0.땹().GetTileCentre(obj3[obj3.Count - 1].딟.TileIndexX, obj3[obj3.Count - 1].딟.TileIndexY)
      };
      for (int index = 0; index < obj3.Count - 1; ++index)
      {
        딶.딽 딟1 = obj3[index].딟;
        딶.딽 딟2 = obj3[index + 1].딟;
        딶.딽 딽1 = index != 0 ? obj3[index - 1].딟 : obj3[0].딟;
        딟1.땄 = Vector3.Lerp(딟1.딟, 딟2.딟, 0.5f);
        if (딟1.딟)
        {
          Vector3 vector3_1 = Vector3.op_Subtraction(딽1.딟, 딟1.딟);
          Vector3 vector3_2 = Vector3.Cross(((Vector3) ref vector3_1).normalized, Vector3.up);
          if (딟1.딟 != 딽1.딟)
          {
            Vector3 vector3_3 = Vector3.op_Addition(딟1.딟, Vector3.op_Multiply(0.5f, vector3_2));
            Vector3 vector3_4 = Vector3.op_Subtraction(딟1.딟, Vector3.op_Multiply(0.5f, vector3_2));
            Vector3 vector3_5 = Vector3.op_Subtraction(vector3_3, 딟2.딟);
            float sqrMagnitude1 = ((Vector3) ref vector3_5).sqrMagnitude;
            Vector3 vector3_6 = Vector3.op_Subtraction(vector3_4, 딟2.딟);
            float sqrMagnitude2 = ((Vector3) ref vector3_6).sqrMagnitude;
            딟1.딟 = (double) sqrMagnitude1 != (double) sqrMagnitude2 ? ((double) sqrMagnitude1 >= (double) sqrMagnitude2 ? vector3_4 : vector3_3) : vector3_3;
          }
          else
          {
            딶.딽 딽2 = 딟1;
            딽2.딟 = Vector3.op_Addition(딽2.딟, !flag ? Vector3.op_Multiply(-0.5f, vector3_2) : Vector3.op_Multiply(0.5f, vector3_2));
            flag = !flag;
          }
        }
      }
      for (int index = 0; index < obj3.Count - 1; ++index)
      {
        딶.딽 딟 = obj3[index].딟;
        딟.딧 = obj3[index + 1].딟.딟;
        if (땸.딟(딟))
          딟.땄 = Vector3.Lerp(딟.딟, 딟.딧, 0.5f);
        딟.딟();
      }
    }

    private static bool 딟([In] 딶.딽 obj0)
    {
      if (obj0.땄.x == obj0.딧.x && obj0.땄.z == obj0.딧.z)
        return true;
      return obj0.땄.x == obj0.딟.x && obj0.땄.z == obj0.딟.z;
    }

    private static int 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 딶.땩 obj2, [In] int obj3)
    {
      if (obj0.땉() == null)
        return -1;
      Vector3 tileCentre = obj0.땹().GetTileCentre(obj2.딟, obj2.땄);
      tileCentre.y = (__Null) 0.0;
      for (int index = 0; index < obj1.땺().Count; ++index)
      {
        if (index != obj3)
        {
          땓.땊 땊 = obj1.땺()[index];
          if (!땊.땺() && obj0.땻()[index].땢() && 땊.땓())
          {
            Vector3 position = ((Component) obj0.땹().get_Tiles()[땊.땃, 땊.딶]).transform.position;
            position.y = (__Null) 0.0;
            Vector3 vector3 = Vector3.op_Subtraction(position, tileCentre);
            if ((double) ((Vector3) ref vector3).magnitude < 0.5)
              return index;
          }
        }
      }
      return -1;
    }

    private static bool 땄([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 딶.땩 obj2, [In] int obj3)
    {
      int num = 땸.딟(obj0, obj1, obj2, obj3);
      return num != -1 && obj0.땉().딷().딟(num, obj0.딝());
    }

    public static 딢.딯 딟([In] GameTileComponent obj0, [In] GameTileComponent obj1, [In] 딢.딯 obj2)
    {
      if (obj1.TileIndexX > obj0.TileIndexX)
        return 딢.딯.딧;
      if (obj1.TileIndexX < obj0.TileIndexX)
        return 딢.딯.딢;
      if (obj1.TileIndexY > obj0.TileIndexY)
        return 딢.딯.딟;
      return obj1.TileIndexY < obj0.TileIndexY ? 딢.딯.땄 : obj2;
    }

    [CompilerGenerated]
    [SpecialName]
    public int 딧() => this.딢;
  }
}
