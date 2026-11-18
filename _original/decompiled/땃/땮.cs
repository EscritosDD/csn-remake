// Decompiled with JetBrains decompiler
// Type: 땃.땮
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땃
{
  public class 땮 : 땧
  {
    public 땮([In] TacticsActionData obj0)
    {
    }

    public 땮()
    {
    }

    public override TacticsActionData 딟() => new TacticsActionData()
    {
      Action = 딢.땀.딶
    };

    public override 땓.딟 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 땓.떒 obj2)
    {
      땓.딟 딟 = new 땓.딟();
      딟.딟(땮.땄(obj0, obj1, obj2));
      return 딟;
    }

    public static void 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 땓.떒 obj2, [In] 땓.딟 obj3, [In] int obj4, [In] 땓.땊 obj5, [In] 딢.떍 obj6)
    {
      if (obj5.딢(obj6) < 0)
        return;
      obj3.딟((딶.땏) new 땓.땃(obj0, obj1, obj2, obj4, obj6, 땓.딢.땄, -1));
    }

    public static void 땄([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 땓.떒 obj2, [In] 땓.딟 obj3, [In] int obj4, [In] 땓.땊 obj5, [In] 딢.떍 obj6)
    {
      if (obj5.딢(obj6) <= 0)
        return;
      obj3.딟((딶.땏) new 땓.땃(obj0, obj1, obj2, obj4, obj6, 땓.딢.딢, -1));
    }

    private static 땓.딟 땄([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 땓.떒 obj2)
    {
      땓.딟 딟 = new 땓.딟();
      딟.딟((딶.땏) new 딶.떑(string.Format("--------- START PRE TURN for Team: {0} ActiveTeam: {1} -------------", (object) obj1.땃(), (object) obj0.딝())));
      obj0.떔().딟(obj0, obj1, obj2);
      for (int index = 0; index < obj1.땺().Count; ++index)
        땮.딟(obj0, obj1, index, 딟, obj2);
      List<땮.딟> 딟List = new List<땮.딟>();
      List<땮.땄> 땄List = new List<땮.땄>();
      for (int index = 0; index < obj1.땺().Count; ++index)
      {
        땓.땊 땊 = obj1.땺()[index];
        땓.딲 딲 = obj0.땻()[index];
        if (딲 is 딶.땚 땚2 && 땚2.딟())
          땮.딟(obj0, obj1, obj2, 딟, index, 땊, 딢.떍.땄);
        if (땊.딧 > 0)
        {
          if (땊.딢(딢.떍.딢) > 0)
            땮.딟(obj0, obj1, obj2, 딟, index, 땊);
          if (땊.땄 == obj1.땃())
          {
            if (obj0.땉() != null)
              obj0.땉().딷()?.딟(index).땩();
            땮.딟(obj0, obj1, obj2, 딟, index, 땊, 딢.떍.땺);
            땮.딟(obj0, obj1, obj2, 딟, index, 땊, 딢.떍.딗);
            땮.딟(obj0, obj1, obj2, 딟, index, 땊, 딢.떍.땻);
            땮.딟(obj0, obj1, obj2, 딟, index, 땊, 딢.떍.딛);
            땮.딟(obj0, obj1, obj2, 딟, index, 땊, 딢.떍.땷);
            int num = 땊.딢(딢.떍.딧);
            bool flag = num > 0;
            땮.땄(obj0, obj1, obj2, 딟, index, 땊, 딢.떍.딧);
            if (flag)
              딟.딟((딶.땏) new 딶.딼(index, num - 1));
            땊.딢 = obj0.땻()[index].딟(땊);
            땮.땄(obj0, obj1, obj2, 딟, index, 땊, 딢.떍.땟);
            땮.땄(obj0, obj1, obj2, 딟, index, 땊, 딢.떍.땂);
            땮.땄(obj0, obj1, obj2, 딟, index, 땊, 딢.떍.딱);
            if (딲.딝())
              땮.딟(딟, obj0, obj1, obj2, 딟List, index, 땊, 딲);
            if (!flag && 딲.땄(딢.딴.딢))
              땮.딟(obj0, obj1, 딟, 땊, 딲, obj2, index);
            땮.딟(obj0, 땊, index, 땄List);
            땮.땄(obj0, 땊, index, 땄List);
            땮.딟(땊, 딲, obj0, obj1, index, 딟, obj2);
            땮.딟(obj0, 땊, 딲, index, 땄List);
          }
        }
      }
      for (int index1 = 0; index1 < 딟List.Count; ++index1)
      {
        땓.땊 땊 = obj1.땺()[딟List[index1].딟];
        딟.딟((딶.땏) new 딶.땾(땊.땃, 땊.딶, 딢.딴.딷, 딟List[index1].딟));
        딟.딟((딶.땏) new 딶.떀(딟List[index1].딟, 딟List[index1].땄));
        for (int index2 = 0; index2 != 딟List[index1].딟.Count; ++index2)
          딟.딟((딶.땏) new 땓.땄(obj0, obj1, obj2, 딟List[index1].딟[index2], 딟List[index1].땄[index2]));
      }
      땮.딟(obj0, obj1, obj2, 딟, 땄List);
      땮.딟(obj1, obj0, obj2, 딟);
      딟.딟((딶.땏) new 딶.떑("--------------------- END PRE TURN---------------------------"));
      return 딟;
    }

    private static void 딟([In] 딶.땙 obj0, [In] 딶.땖 obj1, [In] 땓.떒 obj2, [In] 땓.딟 obj3)
    {
      if (!obj1.떔().땤() || obj0.땃() != 0 || obj0.딧() != obj1.딟.땃 || obj1.떔().딢(obj1))
        return;
      딶.땩 땩 = 땮.땄(obj1, obj0);
      if (!(땩 != 딶.땩.딟))
        return;
      땓.딟 딟 = new 땓.딟();
      int index = 땮.딟(obj1, obj0);
      딟.딦.딟("LootCrate_Dropped");
      딟.딟((딶.땏) new 땓.딝(obj1, obj0, obj2, index, 땩, 딢.딯.딧));
      딟.딟((딶.땏) new 딶.딜(땩));
      딟.딟((딶.땏) new 딶.땎(index));
      딟.딟((딶.땏) new 땓.땄(obj1, obj0, obj2, index, obj1.땻()[index].딱()));
      딟.딟((딶.땏) new 딶.땧(index, true, 0.0f));
      obj3.딟(딟);
    }

    private static void 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 땓.떒 obj2, [In] 땓.딟 obj3, [In] List<땮.땄> obj4)
    {
      if (obj4.Count == 0)
        return;
      List<int> intList = new List<int>();
      for (int index = 0; index < obj4.Count; ++index)
        intList.Add(obj4[index].딟);
      for (int index1 = 0; index1 < obj4.Count; ++index1)
      {
        int 딟1 = obj4[index1].딟;
        땓.땊 땊 = obj1.땺()[딟1];
        int num = 0;
        for (int index2 = 0; index2 < obj4[index1].딟.Count; ++index2)
        {
          int 딟2 = obj4[index1].딟[index2].딟;
          딢.떍 딟3 = obj4[index1].딟[index2].딟;
          땮.땄(obj0, obj1, obj2, obj3, 딟1, 땊, 딟3);
          obj3.딟((딶.땏) new 땓.땄(obj0, obj1, obj2, 딟1, -딟2));
          num += 딟2;
          if (obj0.땉() != null)
          {
            obj3.딟((딶.땏) new 딶.딘(딟1, 딟2, 딟3));
            if (num >= 땊.딧)
            {
              if (땊.딢(딢.떍.딢) > 0)
              {
                obj3.딟((딶.땏) new 땓.땓(obj0, obj1, obj2, 딟1, 땊.딟));
                땓.떀.딟(obj3, obj0, obj1, obj2, 딟1);
              }
              obj3.딟((딶.땏) new 딶.땱(obj0, obj1, 딟1, "Death_Bullet"));
              obj4[index1].딟 = true;
              obj3.딟((딶.땏) new 딶.떊(딟1));
              break;
            }
            obj3.딟((딶.땏) new 딶.떒(1f));
          }
        }
      }
    }

    private static void 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 땓.떒 obj2, [In] 땓.딟 obj3, [In] int obj4, [In] 땓.땊 obj5)
    {
      if (obj5.땄 == obj1.땃())
      {
        obj3.딟((딶.땏) new 땓.땓(obj0, obj1, obj2, obj4, obj5.딟));
        obj3.딟((딶.땏) new 땓.땃(obj0, obj1, obj2, obj4, 딢.떍.딢, 땓.딢.딢, -1));
        obj3.딟((딶.땏) new 딶.떊(obj4));
        if (obj5.땄 == obj0.딝())
          obj3.딟((딶.땏) new 딶.딜(obj4));
        obj3.딟((딶.땏) new 땓.땃(obj0, obj1, obj2, obj4, 딢.떍.땥, 땓.딢.땄, -1));
        obj3.딟((딶.땏) new 땓.땃(obj0, obj1, obj2, obj4, 딢.떍.딝, 땓.딢.땄, -1));
        obj3.딟((딶.땏) new 땓.떎(obj0, obj1, obj2, obj4));
      }
      else
      {
        if (obj5.땄 != obj0.딝())
          return;
        딶.땩 땩 = 땓.떀.땓(obj5);
        딶.땊 땊 = new 딶.땊(new 딶.땩(땩.딟, 땩.땄), ((Component) 땓.땧.딟(딢.떍.딢)).gameObject, 0.0f, -1f);
        obj3.딟((딶.땏) 땊);
        obj1.딟((딶.땏) new 딶.딺(땊));
      }
    }

    private static void 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 땓.딟 obj2, [In] 땓.땊 obj3, [In] 땓.딲 obj4, [In] 땓.떒 obj5, [In] int obj6)
    {
      List<int> intList = new List<int>();
      for (int index = 0; index < obj1.땺().Count; ++index)
      {
        땓.땊 땊 = obj1.땺()[index];
        if (obj3.땄 != 땊.땄 && !땊.땺() && !obj0.땻()[index].딟(obj4, obj3, 땊))
        {
          int radius = obj0.땞().딢().Radius;
          if (땮.딟(obj3, 땊, radius))
          {
            obj2.딟((딶.땏) new 땓.땃(obj0, obj1, obj5, index, 딢.떍.떏, 땓.딢.딟, 1));
            if (땊.딢(딢.떍.딢) > 0)
            {
              obj5.딟(obj1, obj6, index);
              obj2.딟((딶.땏) new 땓.땓(obj0, obj1, obj5, index, obj3.딟));
              땓.떀.딟(obj2, obj0, obj1, obj5, index);
            }
            intList.Add(index);
          }
        }
      }
      if (intList.Count <= 0)
        return;
      obj2.딟((딶.땏) new 딶.땾(obj3.땃, obj3.딶, 딢.딴.딢, intList));
    }

    private static void 딟(
      [In] 땓.딟 obj0,
      [In] 딶.땖 obj1,
      [In] 딶.땙 obj2,
      [In] 땓.떒 obj3,
      [In] List<땮.딟> obj4,
      [In] int obj5,
      [In] 땓.땊 obj6,
      [In] 땓.딲 obj7)
    {
      AbilityGameplayData abilityGameplayData = obj1.땞().딟();
      for (int index1 = 0; index1 < obj2.땺().Count; ++index1)
      {
        땓.땊 땊 = obj2.땺()[index1];
        if (obj6.땄 == 땊.땄 && !땊.땺() && (abilityGameplayData.CanHealSelf || index1 != obj5) && obj1.땻()[index1].땄(딢.딴.딷))
        {
          int maxRange = abilityGameplayData.MaxRange;
          if (obj6.땄(obj2.땺()[index1]) <= maxRange)
          {
            int num1 = obj7.딱();
            int 딧 = obj6.딧;
            int num2 = Mathf.Min(obj6.딧 + abilityGameplayData.HealAmount, num1) - 딧;
            if (num2 > 0)
            {
              int index2 = -1;
              for (int index3 = 0; index3 < obj4.Count; ++index3)
              {
                if (obj4[index3].딟 == index1)
                {
                  index2 = index3;
                  break;
                }
              }
              if (index2 == -1)
              {
                index2 = obj4.Count;
                obj4.Add(new 땮.딟());
                obj4[index2].딟 = index1;
              }
              obj4[index2].딟.Add(obj5);
              obj4[index2].땄.Add(num2);
            }
          }
        }
      }
    }

    private static 땮.땄 딟([In] int obj0, [In] List<땮.땄> obj1)
    {
      for (int index = 0; index < obj1.Count; ++index)
      {
        if (obj0 == obj1[index].딟)
          return obj1[index];
      }
      땮.땄 땄 = new 땮.땄(obj0);
      obj1.Add(땄);
      return 땄;
    }

    private static void 딟([In] 딶.땖 obj0, [In] 땓.땊 obj1, [In] int obj2, [In] List<땮.땄> obj3)
    {
      if (obj1.딢(딢.떍.땓) <= 0)
        return;
      int tickDamage = obj0.땞().딝().TickDamage;
      땮.딟(obj2, obj3).딟(tickDamage, 딢.떍.땓);
    }

    private static void 딟([In] 딶.땖 obj0, [In] 땓.땊 obj1, [In] 땓.딲 obj2, [In] int obj3, [In] List<땮.땄> obj4)
    {
      if (!obj2.땋() || obj1.딢(딢.떍.떈) <= 0)
        return;
      float tickDamage = (float) obj0.땞().떎().TickDamage;
      땮.딟(obj3, obj4).딟((int) tickDamage, 딢.떍.떈);
    }

    private static void 땄([In] 딶.땖 obj0, [In] 땓.땊 obj1, [In] int obj2, [In] List<땮.땄> obj3)
    {
      if (obj1.딢(딢.떍.땔) <= 0)
        return;
      int num = Mathf.RoundToInt((float) obj0.땞().땂().TickDamage);
      땮.딟(obj2, obj3).딟(num, 딢.떍.땔);
    }

    private static void 딟([In] 땓.땊 obj0, [In] 땓.딲 obj1, [In] 딶.땖 obj2, [In] 딶.땙 obj3, [In] int obj4, [In] 땓.딟 obj5, [In] 땓.떒 obj6)
    {
      if (!obj0.땓() || !(obj1 is 딶.땷) || !obj1.땄(딢.딴.땚))
        return;
      List<int> intList = new List<int>();
      for (int index = 0; index < obj3.땺().Count; ++index)
      {
        if (index != obj4)
        {
          땓.땊 땊 = obj3.땺()[index];
          if (!땊.땺() && 땊.딶() && !obj2.땻()[index].딟(obj1, obj0, 땊))
          {
            int radius = obj2.땞().딱().Radius;
            if (땮.딟(obj0, 땊, radius))
            {
              obj5.딟((딶.땏) new 땓.땃(obj2, obj3, obj6, index, 딢.떍.떏, 땓.딢.딟, 1));
              if (땊.딢(딢.떍.딢) > 0)
              {
                obj6.딟(obj3, obj4, index);
                obj5.딟((딶.땏) new 땓.땓(obj2, obj3, obj6, index, obj0.딟));
                땓.떀.딟(obj5, obj2, obj3, obj6, index);
              }
              intList.Add(index);
            }
          }
        }
      }
      obj5.딟((딶.땏) new 딶.땾(obj0.땃, obj0.딶, 딢.딴.땚, intList));
      obj5.딟((딶.땏) new 땓.딝(obj2, obj3, obj6, obj4, 딶.땩.딟, 딢.딯.딟));
    }

    private static void 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] int obj2, [In] 땓.딟 obj3, [In] 땓.떒 obj4)
    {
      땓.땊 땊1 = obj1.땺()[obj2];
      if (땊1.땺() || !땊1.땓() || 땊1.땄 != obj1.땃())
        return;
      땓.딲 딲 = obj0.땻()[obj2];
      if (!(딲 is 딶.땉) || 딲.땄(딢.딴.땔) || !딲.땄(딢.딴.땟))
        return;
      bool flag1 = 딲.땄(딢.딴.땟);
      딢.딴 딴 = 딢.딴.땟;
      bool flag2 = false;
      if (flag1)
      {
        int index = 땊1.딢(딢.떍.땲);
        if (index >= 0 && !obj1.땺()[index].땺() && obj1.땺()[index].땓())
        {
          딶.땩 땩 = new 딶.땩(땊1.땃, 땊1.딶);
          땓.땊 땊2 = obj1.땺()[index];
          obj3.딟((딶.땏) new 땓.땃(obj0, obj1, obj4, obj2, 딢.떍.떏, 땓.딢.딟, 1));
          obj3.딟((딶.땏) new 딶.떊(obj2));
          if (땊1.땃 != 땊2.땃 || 땊1.딶 != 땊2.딶)
          {
            List<GameTileComponent> gameTileComponentList = obj0.땹().get_TileNetwork().딟(obj0, obj1, 땊1.땃, 땊1.딶, 땊2.땃, 땊2.딶, (땓.딲) null, true);
            if (gameTileComponentList != null)
            {
              List<딬> 딬List = new List<딬>();
              int num = -1;
              땸.딟(obj0, obj1, obj2, 땊1, gameTileComponentList, (List<int>) null, 딬List, ref num);
              땸.딟(obj3, obj0, obj1, obj4, obj2, 땊1, 딬List, true);
            }
            else
              Debug.LogError((object) "Mine failed to find path. Should never happen");
          }
          땦 땦 = 땫.딟(obj3, obj0, obj2, 딴, new 딶.땩(땊1.땃, 땊1.딶), 1f, 딤.딶);
          땊1.땃 = 땩.딟;
          땊1.딶 = 땩.땄;
          obj3.딟((딶.땏) new 딶.떒(2f));
          flag2 = 땦 != null;
        }
        else if (index >= 0)
          obj3.딟((딶.땏) new 땓.땃(obj0, obj1, obj4, obj2, 딢.떍.땲, 땓.딢.땄, -1));
      }
      if (!flag2)
        return;
      obj3.딟((딶.땏) new 땓.땄(obj0, obj1, obj4, obj2, -땊1.딧));
    }

    private static bool 딟([In] 땓.땊 obj0, [In] 땓.땊 obj1, [In] int obj2)
    {
      if (obj0.땄(obj1) <= obj2)
        return true;
      int num1 = obj1.딢(딢.떍.땥);
      int num2 = obj1.딢(딢.떍.딝);
      return num1 != -1 && num2 != -1 && 땓.땊.딟(obj0.땃, obj0.딶, num1, num2) <= obj2;
    }

    private static int 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1)
    {
      for (int index = 0; index < obj0.땻().Count; ++index)
      {
        if (obj0.땻()[index] is 딶.땹)
        {
          땓.땊 땊 = obj1.땺()[index];
          if (!땊.땓() || 땊.땺())
            return index;
        }
      }
      return -1;
    }

    private static 딶.땩 땄([In] 딶.땖 obj0, [In] 딶.땙 obj1)
    {
      딶.땩 땩 = 딶.땩.딟;
      GameTileComponent gameTileComponent = (GameTileComponent) null;
      for (int index1 = 0; index1 < obj0.땻().Count; ++index1)
      {
        if (obj0.땻()[index1] is 땓.떀 떀1)
        {
          땓.땊 땊 = obj1.땺()[index1];
          if (땊.딶() && !땊.땺() && 땊.땄 == obj1.땃())
          {
            int num = 떀1.딟(땊) / 떀1.땷().ActionPointsPerMove;
            do
            {
              GameTileComponent[] gameTileComponentArray = obj0.땹().get_TileNetwork().딟(obj0, obj1, 땊.땃, 땊.딶, num, (땓.딲) null, -1, num);
              for (int index2 = 0; index2 != gameTileComponentArray.Length; ++index2)
              {
                int index3 = obj1.땓().딟(0, gameTileComponentArray.Length);
                if (obj0.딟(obj1, gameTileComponentArray[index3].TileIndexX, gameTileComponentArray[index3].TileIndexY, -1) == -1)
                {
                  gameTileComponent = gameTileComponentArray[index3];
                  break;
                }
              }
              num += 2;
            }
            while (Object.op_Equality((Object) gameTileComponent, (Object) null));
            if (Object.op_Inequality((Object) gameTileComponent, (Object) null))
              break;
          }
        }
      }
      if (Object.op_Inequality((Object) gameTileComponent, (Object) null))
        땩 = new 딶.땩(gameTileComponent.TileIndexX, gameTileComponent.TileIndexY);
      return 땩;
    }

    private class 딟
    {
      public int 딟;
      public List<int> 딟 = new List<int>();
      public List<int> 땄 = new List<int>();
    }

    private class 땄
    {
      public int 딟;
      public bool 딟;
      public List<땮.딧> 딟 = new List<땮.딧>();

      public 땄([In] int obj0) => this.딟 = obj0;

      public void 딟([In] int obj0, [In] 딢.떍 obj1) => this.딟.Add(new 땮.딧(obj0, obj1));
    }

    private class 딧
    {
      public int 딟;
      public 딢.떍 딟;

      public 딧([In] int obj0, [In] 딢.떍 obj1)
      {
        this.딟 = obj0;
        this.딟 = obj1;
      }
    }
  }
}
