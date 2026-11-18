// Decompiled with JetBrains decompiler
// Type: 땃.땫
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땃
{
  public class 땫
  {
    public static List<int> 딟(
      [In] 딶.땖 obj0,
      [In] 딶.땙 obj1,
      [In] int obj2,
      [In] 딢.딴 obj3,
      [In] int obj4,
      [In] int obj5,
      [In] bool obj6)
    {
      if (obj0.땻()[obj2] == null)
        return (List<int>) null;
      List<int> intList = new List<int>();
      return !땫.딟(obj0, obj1, obj2, obj3, obj4, obj5, obj6, intList) ? (List<int>) null : intList;
    }

    public static bool 딟(
      [In] 딶.땖 obj0,
      [In] 딶.땙 obj1,
      [In] int obj2,
      [In] 딢.딴 obj3,
      [In] int obj4,
      [In] int obj5,
      [In] bool obj6,
      [In] List<int> obj7)
    {
      return 땫.딟(obj0, obj1, obj2, obj1.땺()[obj2].땃, obj1.땺()[obj2].딶, obj3, obj4, obj5, obj6, obj7);
    }

    public static bool 딟(
      [In] 딶.땖 obj0,
      [In] 딶.땙 obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] 딢.딴 obj5,
      [In] int obj6,
      [In] int obj7,
      [In] bool obj8,
      [In] List<int> obj9)
    {
      땓.땊 땊1 = obj1.땺()[obj2];
      if (땊1.딢(딢.떍.딧) > 0 || 땊1.땺())
        return false;
      땓.딲 딲1 = obj0.땻()[obj2];
      if (딲1 == null)
        return false;
      string str = 땓.땎.땄(obj5, 딲1);
      if (str == null)
        return false;
      WeaponGameplayData weaponGameplayData = obj0.땞().딟(str);
      if (Object.op_Equality((Object) weaponGameplayData, (Object) null))
      {
        Debug.LogWarning((object) ("Weapon " + str + " has no associated weapon data"));
        return false;
      }
      if (!weaponGameplayData.딟(obj0, 땊1, obj8) || !obj8 && 땊1.딢 < weaponGameplayData.RequiredActionPoints)
        return false;
      int num1 = (땊1.땄 + 1) % 2;
      if (weaponGameplayData.LineRange > 0)
      {
        int minRange = weaponGameplayData.MinRange;
        int maxRange = weaponGameplayData.MaxRange;
        int num2 = 땓.땊.딟(땊1.땃, 땊1.딶, obj6, obj7);
        if (num2 > maxRange || num2 < minRange)
          return false;
        List<GameTileComponent> gameTileComponentList = 땫.딟(obj0, obj6, obj7, 땊1.땃, 땊1.딶, weaponGameplayData);
        if (gameTileComponentList.Count == 0)
          return false;
        for (int index1 = 0; index1 < gameTileComponentList.Count; ++index1)
        {
          GameTileComponent gameTileComponent = gameTileComponentList[index1];
          int index2 = obj0.딟(obj1, new 딶.땩(gameTileComponent.TileIndexX, gameTileComponent.TileIndexY), -1, -1, true, true);
          if (index2 >= 0)
          {
            땓.땊 땊2 = obj1.땺()[index2];
            if (땊2.딧 > 0 && 땊2.딶() && obj0.땻()[index2].땽())
              obj9.Add(index2);
          }
        }
      }
      else if (weaponGameplayData.딟())
      {
        int minRange = weaponGameplayData.MinRange;
        int maxRange = weaponGameplayData.MaxRange;
        int num3 = 땓.땊.딟(obj3, obj4, obj6, obj7);
        if (num3 > maxRange || num3 < minRange || !weaponGameplayData.IgnoreVisCheck && !obj0.땹().TestLineOfSight(obj0, obj1, obj3, obj4, obj6, obj7, maxRange))
          return false;
        int num4 = !딲1.딷() ? -1 : obj2;
        GameTileComponent[] gameTileComponentArray = obj0.땹().get_TileNetwork().딟(obj0, obj1, obj6, obj7, weaponGameplayData.SplashRange, (땓.딲) null, -1, -1);
        for (int index3 = 0; index3 < gameTileComponentArray.Length; ++index3)
        {
          int index4 = obj0.딟(obj1, new 딶.땩(gameTileComponentArray[index3].TileIndexX, gameTileComponentArray[index3].TileIndexY), -1, num4, true, true);
          if (index4 >= 0)
          {
            땓.땊 땊3 = obj1.땺()[index4];
            if (땊3.딧 > 0 && 땊3.딶())
            {
              땓.딲 딲2 = obj0.땻()[index4];
              if (딲2.땽())
              {
                if (weaponGameplayData.DamageType == 딶.딱.딧 || weaponGameplayData.DamageType == 딶.딱.땺)
                {
                  if (!딲2.떎())
                    continue;
                }
                else if (weaponGameplayData.DamageType == 딶.딱.딢)
                {
                  if (!딲2.떂())
                    continue;
                }
                else if (weaponGameplayData.DamageType == 딶.딱.땥 && !딲2.땋())
                  continue;
                obj9.Add(index4);
              }
            }
          }
        }
      }
      else
      {
        int index = obj0.딟(obj1, new 딶.땩(obj6, obj7), num1, -1, true, false);
        if (index < 0)
          return false;
        땓.땊 땊4 = obj1.땺()[index];
        if (땊4.딧 <= 0 || !땊4.땓() || 땊4.땄 == 땊1.땄)
          return false;
        땓.딲 딲3 = obj0.땻()[index];
        if (!딲3.땽())
          return false;
        if (weaponGameplayData.DamageType == 딶.딱.딧 || weaponGameplayData.DamageType == 딶.딱.땺)
        {
          if (!딲3.떎())
            return false;
        }
        else if (weaponGameplayData.DamageType == 딶.딱.딢)
        {
          if (!딲3.떂())
            return false;
        }
        else if (weaponGameplayData.DamageType == 딶.딱.땥)
        {
          if (!딲3.땋())
            return false;
        }
        else if (weaponGameplayData.DamageType == 딶.딱.딝 && !딲3.땲())
          return false;
        int minRange = weaponGameplayData.MinRange;
        int maxRange = weaponGameplayData.MaxRange;
        int num5 = 땊4.딟(obj3, obj4);
        if (num5 > maxRange || num5 < minRange || !weaponGameplayData.IgnoreVisCheck && !obj0.딟(obj1, obj2, obj3, obj4, index, 땊4.땃, 땊4.딶, true, false))
          return false;
        obj9.Add(index);
      }
      return true;
    }

    public static List<GameTileComponent> 딟(
      [In] 딶.땖 obj0,
      [In] int obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] WeaponGameplayData obj5)
    {
      List<GameTileComponent> gameTileComponentList = new List<GameTileComponent>();
      딢.딯 딯 = 땓.땊.땄(obj3, obj4, obj1, obj2);
      int num1 = 0;
      int num2 = 0;
      switch (딯)
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
      GameTileComponent tile1 = obj0.땹().GetTile(obj3, obj4);
      for (int index = 0; index < obj5.LineRange; ++index)
      {
        int x = obj1 + num1 * index;
        if (x >= 0 && x < obj0.땹().SizeX)
        {
          int y = obj2 + num2 * index;
          if (y >= 0 && y < obj0.땹().SizeY)
          {
            GameTileComponent tile2 = obj0.땹().GetTile(x, y);
            if (obj0.땹().TileCanBeAttacked(tile2) && tile2.GetCoverType(tile1) == 딶.딥.딟)
              gameTileComponentList.Add(tile2);
            else
              break;
          }
          else
            break;
        }
        else
          break;
      }
      return gameTileComponentList;
    }

    public static float 딟(
      [In] 딶.땖 obj0,
      [In] WeaponGameplayData obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] int obj5)
    {
      GameTileComponent gameTileComponent1 = obj0.땹().get_Tiles()[obj2, obj3];
      GameTileComponent gameTileComponent2 = obj0.땹().get_Tiles()[obj4, obj5];
      return 땫.딟(obj0, obj1, gameTileComponent1, gameTileComponent2);
    }

    public static float 딟(
      [In] 딶.땖 obj0,
      [In] WeaponGameplayData obj1,
      [In] GameTileComponent obj2,
      [In] GameTileComponent obj3)
    {
      딶.딥 coverType = obj0.땹().GetCoverType(obj3.TileIndexX, obj3.TileIndexY, obj2.TileIndexX, obj2.TileIndexY);
      return 땫.딟(obj1, coverType);
    }

    public static float 딟([In] WeaponGameplayData obj0, [In] 딶.딥 obj1)
    {
      if (!딶.때.땄(obj0.DamageType))
        return 1f;
      switch (obj1)
      {
        case 딶.딥.땄:
          return 0.5f;
        case 딶.딥.딧:
          return 0.75f;
        case 딶.딥.딢:
          return 0.0f;
        default:
          return 1f;
      }
    }

    public static float 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] int obj2, [In] 딢.딴 obj3, [In] int obj4, [In] float obj5) => 땫.딟(obj0, obj1, obj2, obj3, obj4, obj5, (GameTileComponent) null);

    public static float 딟(
      [In] 딶.땖 obj0,
      [In] 딶.땙 obj1,
      [In] int obj2,
      [In] 딢.딴 obj3,
      [In] int obj4,
      [In] float obj5,
      [In] GameTileComponent obj6)
    {
      땓.딲 딲 = obj0.땻()[obj2];
      string str = 땓.땎.땄(obj3, 딲);
      WeaponGameplayData weaponGameplayData = obj0.땞().딟(str);
      땓.땊 땊1 = obj1.땺()[obj2];
      float num1 = 1f;
      float num2 = 1f;
      float num3 = 1f;
      if (weaponGameplayData.DamageType == 딶.딱.딟 && 땊1.딢(딢.떍.땟) >= 0)
        num1 *= 1f + obj0.땞().딟(딢.딴.땞).DamageModifier;
      땓.땊 땊2 = obj1.땺()[obj4];
      if (땊2.딢(딢.떍.땂) >= 0)
        num2 *= 1f - obj0.땞().땢().DamageReduction;
      if (땊2.딢(딢.떍.딱) >= 0)
        num3 = 1f - obj0.땞().딷().DamageReduction;
      float num4 = 0.0f;
      if (땊1.딢(딢.떍.딷) > 0)
        num4 = obj0.땞().딶().DamageModifier;
      float num5 = 1f;
      딶.땩 땩 = obj1.땺()[obj4].딟(true);
      if (땩 != 딶.땩.딟)
      {
        GameTileComponent gameTileComponent = obj0.땹().get_Tiles()[땩.딟, 땩.땄];
        if (Object.op_Equality((Object) obj6, (Object) null))
          obj6 = obj0.땹().get_Tiles()[obj1.땺()[obj2].땃, obj1.땺()[obj2].딶];
        float num6 = 땫.딟(obj0, weaponGameplayData, gameTileComponent, obj6);
        float num7 = weaponGameplayData.딟(obj6, gameTileComponent);
        num5 = obj5 * num6 * num7 * num1 * num2 * num3;
      }
      return (1f + num4) * num5;
    }

    private static 떃 딟(
      [In] 딶.땖 obj0,
      [In] int obj1,
      [In] int obj2,
      [In] int obj3,
      [In] 딢.딴 obj4,
      [In] int obj5,
      [In] float obj6,
      [In] 딤 obj7)
    {
      obj0.땪().딟(obj0.땕(), obj3, obj4);
      땓.땊 땊1 = obj0.땕().땺()[obj3];
      땓.딲 딲1 = obj0.땻()[obj3];
      string str = 땓.땎.땄(obj4, 딲1);
      WeaponGameplayData weaponGameplayData = obj0.땞().딟(str);
      땓.땊 땊2 = obj0.땕().땺()[obj5];
      땓.딲 딲2 = obj0.땻()[obj5];
      떃 떃 = new 떃();
      떃.딟 = obj7;
      떃.딟 = obj5;
      떃.딟 = new 땣[weaponGameplayData.ShotsPerAttack];
      float num1 = 땫.딟(obj0, obj0.땕(), obj3, obj4, obj5, obj6);
      for (int index = 0; index < weaponGameplayData.ShotsPerAttack; ++index)
      {
        float num2 = (weaponGameplayData.딟(obj0.땞(), 땊1) + obj0.땕().땓().딟(0.0f, weaponGameplayData.DamageSpread)) * num1;
        떃.딟[index].딟 = (double) obj0.땕().땓().딟() < (double) weaponGameplayData.Accuracy;
        if (떃.딟[index].딟)
        {
          떃.딟[index].땄 = (double) obj0.땕().땓().딟() < (double) weaponGameplayData.CritChance;
          if (떃.딟[index].땄)
            num2 *= obj0.땞().GenericData.CriticalHitDamageScale;
          int num3 = Mathf.RoundToInt(num2);
          if (weaponGameplayData.DamageType == 딶.딱.딧)
          {
            떃.땄 += num3;
            땫.딟(obj0, 딲1, obj5, num3, index, 떃);
          }
          else if (weaponGameplayData.DamageType == 딶.딱.딢)
            땫.딟(obj0, obj5, 떃, index);
          else if (weaponGameplayData.DamageType == 딶.딱.땺)
          {
            떃.땄 += num3;
            땫.딟(obj0, obj4, obj5, 떃, index, num3);
          }
          else if (weaponGameplayData.DamageType == 딶.딱.땥)
          {
            떃.땄 += num3;
            땫.딟(떃, index, num3, obj0, obj5);
          }
          else if (weaponGameplayData.DamageType == 딶.딱.딝)
          {
            떃.땄 += num3;
            땫.딟(떃, index, num3);
          }
          else
          {
            떃.땄 += num3;
            if (weaponGameplayData.DamageType == 딶.딱.딶)
              땫.딟(딲2, index, obj0, obj5, 떃, 땊2);
            else
              땫.딟(떃, index, num3, 땊1);
          }
        }
        else
          땫.딟(떃, index);
      }
      떃.딟 = new List<땆>();
      if (떃.땄 > 0)
      {
        떃.땄 = Mathf.Min(떃.땄, 땊2.딧);
        obj0.땪().딟(obj0.땕(), obj3, 땓.떊.딟);
        obj0.땪().딟(obj0.땕(), obj5, obj3, str, weaponGameplayData, 떃.땄, obj7, obj4);
        딶.땙 땙1 = obj0.땕();
        땙1.땄(땙1.딢() + obj0.땞().RatingModifiersData.PerAttack);
        떃.땄 = 떃.땄 >= 땊2.딧;
        if (떃.땄)
        {
          obj0.땪().딟(obj0.땕(), obj3, 땓.떊.땄);
          obj0.땪().딟(obj0.땕(), obj5, obj3, str, weaponGameplayData, obj7, obj4);
          딶.땙 땙2 = obj0.땕();
          땙2.땄(땙2.딢() + obj0.땞().RatingModifiersData.PerKill);
          딲2.딶(땊2);
        }
      }
      if (땫.땄(obj7, weaponGameplayData))
        땫.딟(weaponGameplayData, 땊2, obj1, obj2, 딲2, 땊1, obj0, obj3, obj5, 떃);
      return 떃;
    }

    private static void 딟(
      [In] WeaponGameplayData obj0,
      [In] 땓.땊 obj1,
      [In] int obj2,
      [In] int obj3,
      [In] 땓.딲 obj4,
      [In] 땓.땊 obj5,
      [In] 딶.땖 obj6,
      [In] int obj7,
      [In] int obj8,
      [In] 떃 obj9)
    {
      int knockbackDistance = obj0.KnockbackDistance;
      bool flag = obj0.SplashRange > 0;
      int num1 = obj1.딟(obj2, obj3);
      obj9.딟 = false;
      if (!(obj4 is 땓.떀))
        return;
      int num2 = -1;
      int num3 = -1;
      if (knockbackDistance > 0 && flag && num1 == 0)
      {
        num2 = obj5.땃;
        num3 = obj5.딶;
      }
      else if (knockbackDistance > 0 && num1 > 0 && num1 <= obj0.KnockbackRange)
      {
        num2 = obj2;
        num3 = obj3;
      }
      else if (knockbackDistance > 0 && !flag && obj1.땄(obj5) <= obj0.KnockbackRange)
      {
        num2 = obj5.땃;
        num3 = obj5.딶;
      }
      if (num2 == -1 || num3 == -1)
        return;
      obj9.딟 = 땓.땊.땄(num2, num3, obj1.땃, obj1.딶);
      obj9.딟 = obj6.땹().GetTileCentre(obj1.땃, obj1.딶);
      obj9.딟 = true;
    }

    private static void 딟([In] 떃 obj0, [In] int obj1)
    {
      obj0.딟[obj1].딟 = 0;
      obj0.딟[obj1].딟 = "miss";
      obj0.딟[obj1].딟 = (AutoPositionText) null;
    }

    private static void 딟([In] 떃 obj0, [In] int obj1, [In] int obj2, [In] 땓.땊 obj3)
    {
      TacticsGameAssets gameAssets = GlobalAppData.딟.GameAssets;
      obj0.딟[obj1].딟 = obj2;
      obj0.딟[obj1].딟 = (-obj2).ToString();
      if (obj0.딟[obj1].땄)
        obj0.딟[obj1].딟 = (obj1 & 1) != 0 ? gameAssets.CritDamageTextAlt : gameAssets.CritDamageText;
      else if (obj3.딢(딢.떍.딷) > 0)
        obj0.딟[obj1].딟 = gameAssets.CritDamageTextAlt;
      else
        obj0.딟[obj1].딟 = (obj1 & 1) != 0 ? gameAssets.DamageTextAlt : gameAssets.DamageText;
    }

    private static void 딟([In] 땓.딲 obj0, [In] int obj1, [In] 딶.땖 obj2, [In] int obj3, [In] 떃 obj4, [In] 땓.땊 obj5)
    {
      if (obj0.떂())
      {
        땫.딟(obj2, 딢.떍.딧, obj2.땞().딟(딢.딴.딗).Duration, obj3, obj4);
        obj4.딟[obj1].딟 = "disabled";
      }
      else if (obj0.땭())
      {
        땫.딟(obj2, 딢.떍.땼, obj2.땞().딟(딢.딴.딗).Duration, obj3, obj4);
        obj4.딟[obj1].딟 = "stunned";
      }
      obj4.딟[obj1].딟 = 0;
      obj4.딟[obj1].딟 = GlobalAppData.딟.GameAssets.DamageText;
    }

    private static void 딟([In] 떃 obj0, [In] int obj1, [In] int obj2)
    {
      obj0.딟[obj1].딟 = obj2;
      obj0.딟[obj1].딟 = string.Empty;
      obj0.딟[obj1].딟 = GlobalAppData.딟.GameAssets.FireDamageText;
    }

    private static void 딟([In] 떃 obj0, [In] int obj1, [In] int obj2, [In] 딶.땖 obj3, [In] int obj4)
    {
      obj0.딟[obj1].딟 = obj2;
      obj0.딟[obj1].딟 = (-obj2).ToString();
      obj0.딟[obj1].딟 = GlobalAppData.딟.GameAssets.FireDamageText;
      땫.딟(obj3, obj4, obj0);
      땫.딟(obj3, 딢.떍.떈, obj3.땞().딟(딢.딴.떌).Duration, obj4, obj0);
    }

    private static void 딟([In] 딶.땖 obj0, [In] 딢.딴 obj1, [In] int obj2, [In] 떃 obj3, [In] int obj4, [In] int obj5)
    {
      땫.딟(obj0, obj2, obj3);
      땫.딟(obj0, 땓.땎.떎(obj1), obj0.땞().땂().Duration, obj2, obj3);
      obj3.딟[obj4].딟 = obj5;
      obj3.딟[obj4].딟 = (-obj5).ToString();
      obj3.딟[obj4].딟 = GlobalAppData.딟.GameAssets.BeeDamageText;
    }

    public static void 딟([In] 딶.땖 obj0, [In] 땓.딲 obj1, [In] int obj2, [In] int obj3, [In] int obj4, [In] 떃 obj5)
    {
      if (obj1.땄(딢.딴.땋))
      {
        AbilityGameplayData abilityGameplayData = obj0.땞().딟(딢.딴.땋);
        땫.딟(obj0, obj2, obj5);
        딢.떍 buffType = abilityGameplayData.BuffType;
        땫.딟(obj0, buffType, abilityGameplayData.Duration, obj2, obj5);
      }
      obj5.딟[obj4].딟 = obj3;
      obj5.딟[obj4].딟 = (-obj3).ToString();
      obj5.딟[obj4].딟 = GlobalAppData.딟.GameAssets.PoisonDamageText;
    }

    private static void 딟([In] 딶.땖 obj0, [In] int obj1, [In] 떃 obj2, [In] int obj3)
    {
      땫.딟(obj0, 딢.떍.딧, 2, obj1, obj2);
      obj2.딟[obj3].딟 = 0;
      obj2.딟[obj3].딟 = "disabled";
      obj2.딟[obj3].딟 = GlobalAppData.딟.GameAssets.DamageText;
    }

    public static 땓.딟 딟([In] 딶.땖 obj0, [In] 떃 obj1)
    {
      땓.딟 딟1 = new 땓.딟();
      땓.땊 땊1 = obj0.땕().땺()[obj1.딟];
      딶.땩 땩 = new 딶.땩(땊1.땃, 땊1.딶);
      딶.땊 땊2 = new 딶.땊(땩, ((Component) GlobalAppData.딟.GameAssets.TeleportEffect).gameObject, -1f, -1f);
      딟1.딟((딶.땏) 땊2);
      딟1.딟((딶.땏) new 땓.딝(obj0, obj0.땕(), obj0.땪(), obj1.딟, 딶.땩.딟, 땊1.딟));
      딟1.딟((딶.땏) new 딶.땧(obj1.딟, false, GlobalAppData.딟.GameAssets.TeleportEffectDuration));
      딟1.딟((딶.땏) new 딶.딺(땊2));
      땓.딟 딟2 = new 땓.딟();
      딟2.딟((딶.땏) new 땓.떂(obj0, obj1.딟, 땩));
      딟2.딟((딶.땏) new 딶.딜(obj1.딟, false, true));
      딶.땊 땊3 = new 딶.땊(obj1.딟, ((Component) GlobalAppData.딟.GameAssets.ReverseTeleportEffect).gameObject, -1f, -1f);
      딟2.딟((딶.땏) 땊3);
      딟2.딟((딶.땏) new 딶.땧(obj1.딟, true, GlobalAppData.딟.GameAssets.ReverseTeleportEffectDuration));
      딟2.딟((딶.땏) new 딶.딺(땊3));
      딟2.딟((딶.땏) new 딶.떒(2f));
      obj0.땕().딟(딟2);
      return 딟1;
    }

    public static 땦 딟([In] 땓.딟 obj0, [In] 딶.땖 obj1, [In] int obj2, [In] 딢.딴 obj3, [In] 딶.땩 obj4, [In] float obj5, [In] 딤 obj6)
    {
      땓.땊 땊 = obj1.땕().땺()[obj2];
      딢.딯 딟 = 땊.딟;
      딢.딯 딯 = 땓.땊.땄(땊.땃, 땊.딶, obj4.딟, obj4.땄);
      땦 땦 = 땫.딟(obj1, obj2, obj3, new 딶.땩(obj4.딟, obj4.땄), obj5, obj6);
      땓.딲 딲 = obj1.땻()[obj2];
      string str = 땓.땎.땄(obj3, 딲);
      WeaponGameplayData weaponGameplayData = obj1.땞().딟(str);
      if (땓.땎.딝(obj3))
      {
        땫.딟(obj0, obj1, obj2, obj4, 땊, 딟, 딯, 땦);
        땫.딧(obj0, obj1, obj2, obj3, obj4, 땦, str);
      }
      else
      {
        if (!딶.때.딟(weaponGameplayData.DamageType))
        {
          switch (obj3)
          {
            case 딢.딴.떎:
              obj0.딟((딶.땏) new 땓.딝(obj1, obj1.땕(), obj1.땪(), obj2, new 딶.땩(땊.땃, 땊.딶), 딯));
              obj0.딟((딶.땏) new 딶.딬(obj2, 딟, 딯));
              땫.딟(obj0, obj1, obj2, obj4, 땊, 딟, 딯, 땦);
              땫.땄(obj0, obj1, obj2, obj3, obj4, 땦, str);
              goto label_17;
            case 딢.딴.땳:
            case 딢.딴.딸:
            case 딢.딴.떉:
              break;
            default:
              if (땦.딟())
              {
                땫.딟(obj0, obj1, obj2, obj4, 땊, 딟, 딯, 땦);
                obj0.딟((딶.땏) new 땓.딝(obj1, obj1.땕(), obj1.땪(), obj2, new 딶.땩(땊.땃, 땊.딶), 딯));
                obj0.딟((딶.땏) new 딶.딬(obj2, 딟, 딯));
                obj0.딟((딶.땏) new 딶.땐(obj2, obj4));
                땫.딢(obj0, obj1, obj2, obj3, obj4, 땦, str);
                if (땦.땄 >= 땊.딧)
                  obj0.딟((딶.땏) new 딶.떊(obj2));
                땫.딟(땦, obj0, obj1);
                goto label_17;
              }
              else
                goto label_17;
          }
        }
        if (!(딲 is 딶.땞))
        {
          obj0.딟((딶.땏) new 땓.딝(obj1, obj1.땕(), obj1.땪(), obj2, new 딶.땩(땊.땃, 땊.딶), 딯));
          obj0.딟((딶.땏) new 딶.딬(obj2, 딟, 딯));
          obj0.딟((딶.땏) new 딶.땐(obj2, obj4));
        }
        땫.딟(obj0, obj1, obj2, obj4, 땊, 딟, 딯, 땦);
        땫.딟(obj0, obj1, obj2, obj3, obj4, 땦, str);
        if (obj3 == 딢.딴.땳)
        {
          for (int index = 0; index != 땦.딟.Count; ++index)
            obj0.딟(땫.딟(obj1, 땦.딟[index]));
        }
        if (땦.땄 >= 땊.딧)
          obj0.딟((딶.땏) new 딶.떊(obj2));
      }
label_17:
      if (땦.딟() && 땫.딟(obj6, weaponGameplayData))
        obj0.딟((딶.땏) new 땓.땥(obj1, obj1.땕(), obj1.땪(), obj2, 땦));
      obj0.딟(!땦.딟);
      return 땦;
    }

    private static void 딟([In] 땦 obj0, [In] 땓.딟 obj1, [In] 딶.땖 obj2)
    {
      for (int index1 = 0; index1 < obj0.딟.Count; ++index1)
      {
        떃 떃 = obj0.딟[index1];
        for (int index2 = 0; index2 < 떃.딟.Count; ++index2)
        {
          땱 땱 = 떃.딟[index2];
          땫.딟(obj1, obj2, 떃, 땱);
          obj1.딟((딶.땏) new 땓.땃(obj2, obj2.땕(), obj2.땪(), 땱.땄, 땱.딟, 땱.딟, 땱.딟));
        }
      }
    }

    private static void 딟([In] 땓.딟 obj0, [In] 딶.땖 obj1, [In] 떃 obj2, [In] 땱 obj3)
    {
      땓.땊 땊 = obj1.땕().땺()[obj2.딟];
      if (obj3.딟 != 딢.떍.땼 || 땊.딢(딢.떍.땼) > 0)
        return;
      int num1 = obj1.땻()[obj2.딟].딟((땓.땊) null);
      int num2 = num1 - 땓.떀.딟(obj1, num1);
      obj0.딟((딶.땏) new 땓.딧(obj1, obj1.땕(), obj1.땪(), obj2.딟, -num2));
    }

    private static void 딟([In] 땓.딟 obj0, [In] 딶.땖 obj1, [In] int obj2, [In] 딢.딴 obj3, [In] 딶.땩 obj4, [In] 땦 obj5, [In] string obj6)
    {
      UnitWeapon unitWeapon = GlobalAppData.땼().땽(obj6);
      땓.땊 땊 = obj1.땕().땺()[obj2];
      딭 딭 = 땫.딟(obj1, obj5, obj3, obj2);
      Vector3 tileCentre1 = obj1.땹().GetTileCentre(땊.땃, 땊.딶);
      Vector3 tileCentre2 = obj1.땹().GetTileCentre(obj4.딟, obj4.땄);
      List<Transform> transformList = (List<Transform>) null;
      if (딭 == 딭.딧)
      {
        transformList = 땫.딟(obj0, obj2, obj4, obj5, 땊);
      }
      else
      {
        obj0.딟((딶.땏) new 딶.딜(tileCentre1, 0.0f));
        obj0.딟((딶.땏) new 딶.딜(tileCentre1, 0.3f, 딢.땘.땄));
        if (딭 == 딭.땄)
          obj0.딟((딶.땏) new 딶.떒(0.5f));
      }
      obj0.딟((딶.땏) new 딶.떕(obj2, obj3));
      obj0.딟((딶.땏) new 딶.땦(obj2, obj3, obj6));
      if (Object.op_Inequality((Object) unitWeapon, (Object) null))
      {
        if (Object.op_Inequality((Object) unitWeapon.ProjectileMeshPrefab, (Object) null))
        {
          Vector3 vector3_1 = Vector3.op_Subtraction(tileCentre2, tileCentre1);
          float num1 = ((Vector3) ref vector3_1).magnitude / ((double) unitWeapon.ProjectileSpeed == 0.0 ? 1f : unitWeapon.ProjectileSpeed);
          if (딭 == 딭.딟)
          {
            Vector3 vector3_2 = Vector3.op_Subtraction(tileCentre2, tileCentre1);
            float num2 = ((Vector3) ref vector3_2).magnitude / Mathf.Max(unitWeapon.ProjectileSpeed, 0.1f);
            땫.딟(obj0, 땊, obj5, num2);
          }
          else
            땫.딟(obj0, transformList, num1);
          if (!string.IsNullOrEmpty(unitWeapon.ProjectileSpawnJoint))
            obj0.딟((딶.땏) new 딶.땰(obj2, unitWeapon.ProjectileSpawnJoint, obj4, obj6));
          else
            obj0.딟((딶.땏) new 딶.땰(new 딶.땩(땊.땃, 땊.딶), obj4, obj6));
        }
        if (Object.op_Inequality((Object) unitWeapon.ProjectileExplosionPrefab, (Object) null))
          obj0.딟((딶.땏) new 딶.땊(obj4, ((Component) unitWeapon.ProjectileExplosionPrefab).gameObject, 0.1f, unitWeapon.ProjectileExplosionDuration));
        obj0.딟((딶.땏) new 딶.땗(unitWeapon.CameraShakeTime, unitWeapon.CameraShakeStrength));
        if (Object.op_Inequality((Object) unitWeapon.ProjectileExplosionSoundShader, (Object) null))
          obj0.딟((딶.땏) new 딶.땫(unitWeapon.ProjectileExplosionSoundShader, obj4, 0.0f));
      }
      땫.딟(obj0, obj1, obj2, obj3, obj4, obj5, obj6, unitWeapon);
    }

    private static 딭 딟([In] 딶.땖 obj0, [In] 땦 obj1, [In] 딢.딴 obj2, [In] int obj3)
    {
      딭 딭 = 딭.딧;
      if (obj1.딟.Count == 1)
      {
        if (obj1.딟[0].땄)
          딭 = 딭.딟;
      }
      else
      {
        string str = 땓.땎.땄(obj2, obj0.땻()[obj3]);
        WeaponGameplayData weaponGameplayData = obj0.땞().딟(str);
        if (Object.op_Inequality((Object) weaponGameplayData, (Object) null) && weaponGameplayData.Category == 땓.땍.땥 && obj1.딟.Count == 2 && obj1.딟[1].땄)
          딭 = 딭.땄;
      }
      return 딭;
    }

    private static void 땄([In] 땓.딟 obj0, [In] 딶.땖 obj1, [In] int obj2, [In] 딢.딴 obj3, [In] 딶.땩 obj4, [In] 땦 obj5, [In] string obj6)
    {
      UnitWeapon unitWeapon = GlobalAppData.땼().땽(obj6);
      땓.땊 땊1 = obj1.땕().땺()[obj2];
      딭 딭 = 땫.딟(obj1, obj5, obj3, obj2);
      Vector3 tileCentre = obj1.땹().GetTileCentre(땊1.땃, 땊1.딶);
      if (딭 == 딭.딧)
      {
        땫.딟(obj0, obj2, obj4, obj5, 땊1);
      }
      else
      {
        obj0.딟((딶.땏) new 딶.딜(tileCentre, 0.0f));
        obj0.딟((딶.땏) new 딶.딜(tileCentre, 0.3f, 딢.땘.땄));
      }
      obj0.딟((딶.땏) new 딶.떕(obj2, obj3));
      obj0.딟((딶.땏) new 딶.땦(obj2, obj3, obj6));
      string str1 = 땓.땎.땄(obj3, obj1.땻()[obj2]);
      WeaponGameplayData weaponGameplayData = obj1.땞().딟(str1);
      if (Object.op_Inequality((Object) unitWeapon, (Object) null))
        obj0.딟((딶.땏) new 딶.땗(unitWeapon.CameraShakeTime, unitWeapon.CameraShakeStrength));
      if (딭 == 딭.딟)
        땫.딟(obj0, 땊1, obj5, 0.2f);
      float num = 0.5f;
      List<GameTileComponent> gameTileComponentList = 땫.딟(obj1, obj4.딟, obj4.땄, 땊1.땃, 땊1.딶, weaponGameplayData);
      for (int index1 = 0; index1 < gameTileComponentList.Count; ++index1)
      {
        GameTileComponent gameTileComponent = gameTileComponentList[index1];
        if (Object.op_Inequality((Object) unitWeapon, (Object) null) && Object.op_Inequality((Object) unitWeapon.ProjectileExplosionSoundShader, (Object) null))
          obj0.딟((딶.땏) new 딶.땫(unitWeapon.ProjectileExplosionSoundShader, new 딶.땩(gameTileComponent.TileIndexX, gameTileComponent.TileIndexY), 0.0f));
        if (Object.op_Inequality((Object) unitWeapon, (Object) null) && Object.op_Inequality((Object) unitWeapon.ProjectileExplosionPrefab, (Object) null))
          obj0.딟((딶.땏) new 딶.땊(new 딶.땩(gameTileComponent.TileIndexX, gameTileComponent.TileIndexY), ((Component) unitWeapon.ProjectileExplosionPrefab).gameObject, 0.1f, unitWeapon.ProjectileExplosionDuration));
        for (int index2 = 0; index2 < obj5.딟.Count; ++index2)
        {
          int 딟 = obj5.딟[index2].딟;
          땓.땊 땊2 = obj1.땕().땺()[딟];
          if (gameTileComponent.TileIndexX == 땊2.땃 && gameTileComponent.TileIndexY == 땊2.딶)
          {
            떃 떃 = obj5.딟[index2];
            obj0.딟((딶.땏) new 땓.땄(obj1, obj1.땕(), obj1.땪(), 떃.딟, -떃.땄));
            땓.딺 딺 = 땓.딺.땓;
            if (떃.땄)
              딺 = 땓.딺.땺;
            string str2 = !Object.op_Inequality((Object) unitWeapon, (Object) null) ? (string) null : unitWeapon.딟(obj1, 딺);
            if (str2 != null)
            {
              obj0.딟((딶.땏) new 딶.땆(떃.딟, obj3, str2, obj6));
              num = obj1.땉().딷().딟(떃.딟).딟(str2);
            }
            땫.딟(obj0, obj1, obj2, 떃, obj4, 0.0f, 0.0f);
          }
        }
      }
      bool flag = false;
      for (int index3 = 0; index3 < gameTileComponentList.Count; ++index3)
      {
        GameTileComponent gameTileComponent = gameTileComponentList[index3];
        for (int index4 = 0; index4 < obj5.딟.Count; ++index4)
        {
          int 딟 = obj5.딟[index4].딟;
          땓.땊 땊3 = obj1.땕().땺()[딟];
          if (gameTileComponent.TileIndexX == 땊3.땃 && gameTileComponent.TileIndexY == 땊3.딶)
          {
            떃 떃 = obj5.딟[index4];
            if (떃.땄)
            {
              obj0.딟((딶.땏) new 딶.떊(떃.딟, !flag ? num : 0.0f));
              flag = true;
              break;
            }
          }
        }
      }
      if (!flag)
        obj0.딟((딶.땏) new 딶.떒(num));
      obj0.딟((딶.땏) new 딶.떕(obj2, 딢.딴.땄));
    }

    private static void 딟(
      [In] 땓.딟 obj0,
      [In] 딶.땖 obj1,
      [In] int obj2,
      [In] 딢.딴 obj3,
      [In] 딶.땩 obj4,
      [In] 땦 obj5,
      [In] string obj6,
      [In] UnitWeapon obj7)
    {
      if (obj5.딟())
      {
        float num = 0.5f;
        WeaponGameplayData weaponGameplayData = obj1.땞().딟(obj6);
        for (int index1 = 0; index1 < obj5.딟.Count; ++index1)
        {
          떃 떃 = obj5.딟[index1];
          떃.딟 = 0.5f;
          obj0.딟((딶.땏) new 땓.땄(obj1, obj1.땕(), obj1.땪(), 떃.딟, -떃.땄));
          땓.딺 딺 = 땓.딺.땓;
          if (떃.땄)
            딺 = 땓.딺.땺;
          string str = !Object.op_Inequality((Object) obj7, (Object) null) ? (string) null : obj7.딟(obj1, 딺);
          if (str != null)
          {
            if (obj2 != 떃.딟 || weaponGameplayData.Category != 땓.땍.땥)
              obj0.딟((딶.땏) new 딶.땆(떃.딟, obj3, str, obj6));
            else
              obj0.딟((딶.땏) new 딶.떊(obj2));
          }
          if (str != null && obj1.땉() != null && obj1.땉().딷() != null)
          {
            떃.딟 = obj1.땉().딷().딟(떃.딟).딟(str);
            if ((double) 떃.딟 > (double) num)
              num = 떃.딟;
          }
          if (떃.딟)
          {
            obj0.딟((딶.땏) new 땓.딶(obj1, obj1.땕(), obj1.땪(), 떃.딟, obj2, weaponGameplayData.KnockbackDistance, 떃.딟));
            obj0.딟((딶.땏) new 땓.떎(obj1, obj1.땕(), obj1.땪(), 떃.딟));
          }
          for (int index2 = 0; index2 < 떃.딟.Count; ++index2)
          {
            땱 땱 = 떃.딟[index2];
            땫.딟(obj0, obj1, 떃, 땱);
            obj0.딟((딶.땏) new 땓.땃(obj1, obj1.땕(), obj1.땪(), 땱.땄, 땱.딟, 땱.딟, 땱.딟));
          }
        }
        obj0.딟((딶.땏) new 딶.땅(obj5, num * 0.25f));
        obj0.딟((딶.땏) new 딶.떕(obj2, 딢.딴.땄));
        for (int index = 0; index < obj5.딟.Count; ++index)
          땫.딟(obj0, obj1, obj2, obj5.딟[index], obj4, 0.0f, 0.0f);
        bool flag = false;
        for (int index = 0; index < obj5.딟.Count; ++index)
        {
          if (obj5.딟[index].땄)
          {
            obj0.딟((딶.땏) new 딶.떊(obj5.딟[index].딟, !flag ? obj5.딟[index].딟 : 0.0f));
            flag = true;
          }
        }
        if (flag)
          return;
        obj0.딟((딶.땏) new 딶.떒(num * 0.75f));
      }
      else
        obj0.딟((딶.땏) new 딶.떕(obj2, 딢.딴.땄));
    }

    private static void 딧([In] 땓.딟 obj0, [In] 딶.땖 obj1, [In] int obj2, [In] 딢.딴 obj3, [In] 딶.땩 obj4, [In] 땦 obj5, [In] string obj6)
    {
      땓.땊 땊 = obj1.땕().땺()[obj2];
      UnitWeapon unitWeapon = (UnitWeapon) null;
      switch (obj3)
      {
        case 딢.딴.땕:
          unitWeapon = GlobalAppData.딟.땽();
          break;
        case 딢.딴.따:
          unitWeapon = GlobalAppData.딟.땋();
          break;
        case 딢.딴.딾:
          unitWeapon = GlobalAppData.딟.땲();
          break;
      }
      if (딶.딡.땴() != null && 딶.딡.땴().딷() != null)
      {
        bool flag1 = false;
        if (obj5.딟.Count == 1 && obj5.딟[0].땄)
          flag1 = true;
        Vector3 tileCentre1 = obj1.땹().GetTileCentre(땊.땃, 땊.딶);
        Vector3 tileCentre2 = obj1.땹().GetTileCentre(obj4.딟, obj4.땄);
        List<Transform> transformList = (List<Transform>) null;
        if (!flag1)
        {
          transformList = 땫.딟(obj0, obj2, obj4, obj5, 땊);
        }
        else
        {
          obj0.딟((딶.땏) new 딶.딜(tileCentre1, 0.0f));
          obj0.딟((딶.땏) new 딶.딜(tileCentre1, 0.3f, 딢.땘.땄));
        }
        string str = obj1.땻()[obj2].딟(땊, 땓.딺.땤);
        if (str != null)
          obj0.딟((딶.땏) new 딶.땣(obj2, str));
        if (Object.op_Inequality((Object) unitWeapon, (Object) null))
        {
          bool flag2 = false;
          float maxLength = unitWeapon.FireSoundShader.GetMaxLength();
          if (!flag1)
          {
            땫.딟(obj0, transformList, maxLength);
          }
          else
          {
            Vector3 vector3 = Vector3.op_Subtraction(tileCentre2, tileCentre1);
            float num = ((Vector3) ref vector3).magnitude / Mathf.Max(unitWeapon.ProjectileSpeed, 0.1f);
            땫.딟(obj0, 땊, obj5, num);
          }
          if (Object.op_Inequality((Object) unitWeapon.ProjectileMeshPrefab, (Object) null) && Object.op_Inequality((Object) ((Component) unitWeapon.ProjectileMeshPrefab).animation, (Object) null))
          {
            float length = ((Component) unitWeapon.ProjectileMeshPrefab).animation.clip.length;
            if ((double) maxLength > (double) length)
            {
              obj0.딟((딶.땏) new 딶.땫(unitWeapon.FireSoundShader, obj4, maxLength - length));
              obj0.딟((딶.땏) new 딶.땊(obj4, ((Component) unitWeapon.ProjectileMeshPrefab).gameObject, length, length));
            }
            else
            {
              obj0.딟((딶.땏) new 딶.땊(obj4, ((Component) unitWeapon.ProjectileMeshPrefab).gameObject, length - maxLength, length));
              obj0.딟((딶.땏) new 딶.땫(unitWeapon.FireSoundShader, obj4, maxLength));
            }
          }
          else if ((double) maxLength > 0.0)
            obj0.딟((딶.땏) new 딶.땫(unitWeapon.FireSoundShader, obj4, maxLength));
          obj0.딟((딶.땏) new 딶.땊(obj4, ((Component) unitWeapon.ProjectileExplosionPrefab).gameObject, 0.0f, unitWeapon.ProjectileExplosionDuration));
          if (!flag2)
            obj0.딟((딶.땏) new 딶.땫(unitWeapon.HitSoundShader, obj4, 0.0f));
        }
        obj0.딟((딶.땏) new 딶.땗(unitWeapon.CameraShakeTime, unitWeapon.CameraShakeStrength));
      }
      땫.딟(obj0, obj1, obj2, obj3, obj4, obj5, obj6, unitWeapon);
    }

    private static List<Transform> 딟([In] 땓.딟 obj0, [In] int obj1, [In] 딶.땩 obj2, [In] 땦 obj3, [In] 땓.땊 obj4)
    {
      if (딶.딡.땴() == null || 딶.딡.땴().딷() == null)
        return (List<Transform>) null;
      List<Transform> targets = new List<Transform>();
      GameObject gameObject1 = 딶.딡.땴().딷().딟(obj1).딣();
      if (Object.op_Equality((Object) gameObject1, (Object) null))
      {
        딶.땩 땩 = obj4.딟(true);
        targets.Add(((Component) 딶.딡.땴().땓().GetTile(땩.딟, 땩.땄)).transform);
      }
      else
        targets.Add(gameObject1.transform);
      targets.Add(((Component) 딶.딡.땴().땓().GetTile(obj2.딟, obj2.땄)).transform);
      int num = 0;
      for (int index = 0; index != obj3.딟.Count; ++index)
      {
        GameObject gameObject2 = 딶.딡.땴().딷().딟(obj3.딟[index].딟).딣();
        if (Object.op_Inequality((Object) gameObject2, (Object) null))
        {
          targets.Add(gameObject2.transform);
          ++num;
        }
      }
      int numTargetsInView;
      bool canFitWithoutMoving;
      Vector3 focusOnTargets = 딶.딡.땴().딟.CalculateFocusOnTargets(targets, true, out numTargetsInView, out 딢.땘 _, out canFitWithoutMoving);
      if (canFitWithoutMoving)
        targets = (List<Transform>) null;
      else if ((double) numTargetsInView / ((double) num + 2.0) > 0.850000023841858)
      {
        obj0.딟((딶.땏) new 딶.딜(focusOnTargets, true));
        targets = (List<Transform>) null;
      }
      else
      {
        obj0.딟((딶.땏) new 딶.딜(obj1, true, false, false));
        targets.RemoveAt(0);
      }
      return targets;
    }

    private static void 딟([In] 땓.딟 obj0, [In] List<Transform> obj1, [In] float obj2)
    {
      if (딶.딡.땴() == null || obj1 == null)
        return;
      딶.떒 떒 = (딶.떒) new 딶.딜(딶.딡.땴().딟.CalculateFocusOnTargets(obj1, false, out int _, out 딢.땘 _, out bool _), obj2, true, false);
      ((딶.땏) 떒).딟 = true;
      obj0.딟((딶.땏) 떒);
    }

    private static void 딟([In] 땓.딟 obj0, [In] 땓.땊 obj1, [In] 땦 obj2, [In] float obj3)
    {
      if (딶.딡.땴() == null)
        return;
      List<Transform> targets = new List<Transform>();
      for (int index = 0; index < obj2.딟.Count; ++index)
      {
        GameObject gameObject = 딶.딡.땴().딷().딟(obj2.딟[index].딟).딣();
        if (Object.op_Inequality((Object) gameObject, (Object) null))
          targets.Add(gameObject.transform);
      }
      딶.떒 떒 = (딶.떒) new 딶.딜(딶.딡.땴().딟.CalculateFocusOnTargets(targets, false, out int _, out 딢.땘 _, out bool _), obj3, 딢.땘.땄);
      ((딶.땏) 떒).딟 = true;
      obj0.딟((딶.땏) 떒);
    }

    private static void 딢([In] 땓.딟 obj0, [In] 딶.땖 obj1, [In] int obj2, [In] 딢.딴 obj3, [In] 딶.땩 obj4, [In] 땦 obj5, [In] string obj6)
    {
      UnitWeapon unitWeapon = GlobalAppData.땼().땽(obj6);
      땓.땊 땊 = obj1.땕().땺()[obj2];
      bool flag1 = false;
      for (int index = 0; index < obj5.딟.Count; ++index)
      {
        if (obj5.딟[index].땄)
        {
          flag1 = true;
          break;
        }
      }
      List<Transform> transformList = (List<Transform>) null;
      if (flag1)
      {
        if (obj1.땉() != null)
        {
          obj0.딟((딶.땏) new 딶.딜(((Component) obj1.땉().땓().GetTile(땊.땃, 땊.딶)).transform.position, 0.0f));
          obj0.딟((딶.땏) new 딶.딜(((Component) obj1.땉().땓().GetTile(땊.땃, 땊.딶)).transform.position, 0.3f, 딢.땘.땄));
        }
      }
      else
        transformList = 땫.딟(obj0, obj2, obj4, obj5, 땊);
      bool flag2 = obj1.땉() != null && obj1.땉().딷() != null;
      float num = 0.5f;
      if (땊.딢(딢.떍.딷) > 0)
        obj0.딟((딶.땏) new 딶.땊(obj2, ((Component) GlobalAppData.딟.GameAssets.HeadshotTriggerEffect).gameObject, -1f, GlobalAppData.딟.GameAssets.HeadshotTriggerDuration, true));
      if (Object.op_Inequality((Object) unitWeapon, (Object) null))
      {
        obj0.딟((딶.땏) new 딶.떕(obj2, obj3));
        obj0.딟((딶.땏) new 딶.땦(obj2, obj3, obj6));
        obj0.딟((딶.땏) new 딶.땗(unitWeapon.CameraShakeTime, unitWeapon.CameraShakeStrength));
      }
      for (int index = 0; index < obj5.딟.Count; ++index)
      {
        떃 떃 = obj5.딟[index];
        obj0.딟((딶.땏) new 땓.땄(obj1, obj1.땕(), obj1.땪(), 떃.딟, -떃.땄));
        땓.딺 딺 = 땓.딺.땓;
        if (obj5.딟[index].땄)
          딺 = 땓.딺.땺;
        if (flag1)
          땫.딟(obj0, 땊, obj5, 0.2f);
        else
          땫.딟(obj0, transformList, 0.5f);
        string str = !Object.op_Inequality((Object) unitWeapon, (Object) null) ? (string) null : unitWeapon.딟(obj1, 딺);
        if (str != null && flag2)
        {
          num = obj1.땉().딷().딟(떃.딟).딟(str);
          딶.떒 떒 = (딶.떒) new 딶.땆(obj5.딟[index].딟, obj3, str, obj6);
          ((딶.땏) 떒).딟 = true;
          obj0.딟((딶.땏) 떒);
          if (딺 == 땓.딺.땺)
          {
            Transform transform = obj1.땻()[떃.딟].딟(땓.딺.땺);
            if (Object.op_Inequality((Object) transform, (Object) null))
              obj0.딟((딶.땏) new 딶.땊(떃.딟, ((Component) transform).gameObject, Mathf.Max(0.0f, num - 0.25f), 3f, true));
          }
        }
        if (떃.딟)
        {
          WeaponGameplayData weaponGameplayData = obj1.땞().딟(obj6);
          obj0.딟((딶.땏) new 땓.딶(obj1, obj1.땕(), obj1.땪(), 떃.딟, obj2, weaponGameplayData.KnockbackDistance, 떃.딟));
          obj0.딟((딶.땏) new 땓.떎(obj1, obj1.땕(), obj1.땪(), 떃.딟));
        }
      }
      obj0.딟((딶.땏) new 딶.땅(obj5, num / 4f));
      for (int index = 0; index < obj5.딟.Count; ++index)
      {
        떃 떃 = obj5.딟[index];
        땓.딺 딺 = 땓.딺.땓;
        if (obj5.딟[index].땄)
          딺 = 땓.딺.땺;
        string str = !Object.op_Inequality((Object) unitWeapon, (Object) null) ? (string) null : unitWeapon.딟(obj1, 딺);
        if (flag2)
        {
          if (str != null)
            num = obj1.땉().딷().딟(떃.딟).딟(str);
          if (Object.op_Inequality((Object) unitWeapon.SecondaryEffectPrefab, (Object) null))
            obj0.딟((딶.땏) new 딶.땊(obj2, unitWeapon.SecondaryEffectJointName, ((Component) unitWeapon.SecondaryEffectPrefab).gameObject, 0.0f, unitWeapon.SecondaryEffectDuration, false));
        }
        땫.딟(obj0, obj1, obj2, obj5.딟[index], obj4, num, 0.25f);
        if (obj5.딟[index].땄)
          obj0.딟((딶.땏) new 딶.떊(obj5.딟[index].딟, 0.0f));
      }
      obj0.딟((딶.땏) new 딶.떕(obj2, 딢.딴.땄));
    }

    private static void 딟([In] 땓.딟 obj0, [In] 딶.땖 obj1, [In] int obj2, [In] 떃 obj3, [In] 딶.땩 obj4, [In] float obj5, [In] float obj6)
    {
      float num1 = Mathf.Min(new float[1]
      {
        obj5 / (float) Mathf.Max(1, obj3.딟.Length)
      });
      float num2 = Mathf.Max(obj6, num1);
      for (int index = 0; index < obj3.딟.Length; ++index)
      {
        땣 땣 = obj3.딟[index];
        float num3 = index % 2 != 0 ? 15f : -15f;
        if (obj1.딟(obj1.땕(), obj3.딟, obj4.딟, obj4.땄, obj1.딝(), false))
          obj0.딟((딶.땏) new 딶.땑(땣.딟, obj3.딟, 땣.딟, num3, num2));
      }
    }

    private static void 딟([In] 땓.딟 obj0, [In] 딶.땖 obj1, [In] int obj2, [In] 딶.땩 obj3, [In] 땓.땊 obj4, [In] 딢.딯 obj5, [In] 딢.딯 obj6, [In] 땦 obj7)
    {
      if (obj7 != null)
      {
        for (int index = 0; index < obj7.딟.Count; ++index)
        {
          땱 땱 = obj7.딟[index];
          obj0.딟((딶.땏) new 땓.땃(obj1, obj1.땕(), obj1.땪(), 땱.땄, 땱.딟, 땱.딟, 땱.딟));
        }
      }
      땓.떀.딟(obj0, obj1, obj1.땕(), obj1.땪(), obj2);
      obj0.딟((딶.땏) new 땓.땃(obj1, obj1.땕(), obj1.땪(), obj2, 딢.떍.딷, 땓.딢.땄, -1));
      if (obj7.딟 != 0)
        obj0.딟((딶.땏) new 땓.딧(obj1, obj1.땕(), obj1.땪(), obj2, -obj7.딟));
      if (obj7.땄 == 0)
        return;
      obj0.딟((딶.땏) new 땓.땄(obj1, obj1.땕(), obj1.땪(), obj2, -obj7.땄));
    }

    private static bool 딟([In] 딤 obj0, [In] WeaponGameplayData obj1) => obj1.DamageType != 딶.딱.딝 && (obj0 & 딤.딧) == 딤.딟 && (obj0 & 딤.딢) == 딤.딟;

    private static bool 땄([In] 딤 obj0, [In] WeaponGameplayData obj1) => (obj0 & 딤.딧) == 딤.딟 && (obj0 & 딤.딢) == 딤.딟;

    private static bool 딟([In] 딤 obj0) => (obj0 & 딤.딧) != 딤.딟 || (obj0 & 딤.딶) != 딤.딟;

    public static 땦 딟([In] 딶.땖 obj0, [In] int obj1, [In] 딢.딴 obj2, [In] 딶.땩 obj3, [In] float obj4, [In] 딤 obj5)
    {
      bool flag = 땫.딟(obj5);
      List<int> intList = 땫.딟(obj0, obj0.땕(), obj1, obj2, obj3.딟, obj3.땄, flag);
      땦 땦 = new 땦();
      딤 딤 = obj5;
      땓.땊 땊1 = obj0.땕().땺()[obj1];
      if (땊1.딢(딢.떍.딢) > 0)
      {
        딤 |= 딤.땄;
        땦.딟.Add(new 땱(딢.떍.딢, 땓.딢.땄, -1, obj1));
      }
      if (땊1.딢(딢.떍.딷) > 0)
        딤 |= 딤.땃;
      string str = 땓.땎.땄(obj2, obj0.땻()[obj1]);
      WeaponGameplayData weaponGameplayData = obj0.땞().딟(str);
      땫.딟(obj0, obj1, obj2, weaponGameplayData, 땦);
      if (!flag)
      {
        if ((obj5 & 딤.딢) != 딤.딟)
        {
          if (intList != null && intList.Count > 0)
            땦.딟 = weaponGameplayData.RequiredActionPoints;
        }
        else
          땦.딟 = weaponGameplayData.RequiredActionPoints;
      }
      if (weaponGameplayData.Category == 땓.땍.땥)
        땦.땄 = 땊1.딧;
      if (intList == null || intList.Count == 0)
        return 땦;
      int num1 = 0;
      int num2 = 0;
      for (int index1 = 0; index1 < intList.Count; ++index1)
      {
        땓.땊 땊2 = obj0.땕().땺()[intList[index1]];
        int num3 = 땊2.딟(obj3.딟, obj3.땄);
        float num4 = weaponGameplayData.SplashRange <= 0 ? 1f : weaponGameplayData.딟((float) num3 / (float) weaponGameplayData.SplashRange);
        떃 떃 = 땫.딟(obj0, obj3.딟, obj3.땄, obj1, obj2, intList[index1], obj4 * num4, 딤);
        if (땊2.땄 != 땊1.땄)
        {
          for (int index2 = 0; index2 < 떃.딟.Length; ++index2)
            num1 += 떃.딟[index2].딟;
          if (떃.땄)
            ++num2;
        }
        땦.딟.Add(떃);
      }
      땦.딟 = 땫.딟(obj0, num2, obj5);
      obj0.땪().딟(obj0.땕(), obj1, weaponGameplayData, num1);
      obj0.땪().땄(obj0.땕(), obj1, weaponGameplayData, num2);
      return 땦;
    }

    private static bool 딟([In] 딶.땖 obj0, [In] int obj1, [In] 딤 obj2)
    {
      if ((obj2 & 딤.딧) == 딤.딟 && (obj2 & 딤.딢) == 딤.딟)
        return false;
      int num = 0;
      for (int index = 0; index < obj0.땕().땺().Count; ++index)
      {
        땓.땊 땊 = obj0.땕().땺()[index];
        if (!땊.땺() && 땊.딶() && 땊.땄 == obj0.땕().땃())
          ++num;
      }
      return obj1 == num;
    }

    public static void 딟([In] 땓.딟 obj0, [In] 딶.땖 obj1, [In] int obj2, [In] 땦 obj3)
    {
      땓.땊 땊1 = obj1.땕().땺()[obj2];
      if (obj3.땄 >= 땊1.딧)
        return;
      int 딧 = 땊1.딧;
      int[] numArray = new int[obj1.땻().Count];
      obj0.딟((딶.땏) new 딶.떑("----------------- RETURN FIRE -----------------"));
      for (int index1 = 0; index1 < obj3.딟.Count; ++index1)
      {
        떃 떃 = obj3.딟[index1];
        땓.땊 땊2 = obj1.땕().땺()[떃.딟];
        if (땊2.딢(딢.떍.딢) <= 0 && 땊2.땄 != 땊1.땄)
        {
          if (!떃.땄)
          {
            땓.딲 딲 = obj1.땻()[떃.딟];
            WeaponGameplayData weaponGameplayData = obj1.땞().딟(딲.딧());
            if (Object.op_Inequality((Object) weaponGameplayData, (Object) null) && weaponGameplayData.AllowsReturnFire && 땊2.딢 - numArray[떃.딟] >= weaponGameplayData.RequiredActionPoints)
            {
              float returnFireDamageScale = obj1.땞().GenericData.ReturnFireDamageScale;
              if (땊2.딢(딢.떍.땢) > 0)
                returnFireDamageScale += obj1.땞().땄().DamageModifier;
              땦 땦 = 땫.딟(obj0, obj1, 떃.딟, 딢.딴.땄, new 딶.땩(땊1.땃, 땊1.딶), returnFireDamageScale, 딤.딢);
              numArray[떃.딟] += 땦.딟;
              if (땦.딟.Count > 1)
                Debug.LogError((object) "We don't support more than 1 target in return fire!");
              if (땦.딟.Count == 1)
              {
                땊1.딧 -= 땦.딟[0].땄;
                if (땊1.땺())
                  obj0.딟((딶.땏) new 딶.떊(obj2));
              }
            }
          }
          for (int index2 = 0; index2 < obj1.땻().Count; ++index2)
          {
            if (index2 != 떃.딟 && obj1.땕().땺()[index2].땄 != 땊1.땄 && !obj1.땕().땺()[index2].땺() && obj1.땻()[index2].땄(딢.딴.땤))
            {
              WeaponGameplayData weaponGameplayData = obj1.땞().딟(obj1.땻()[index2].딧());
              if (Object.op_Inequality((Object) weaponGameplayData, (Object) null) && obj1.땕().땺()[index2].딢 - numArray[index2] >= weaponGameplayData.RequiredActionPoints && weaponGameplayData.AllowsReturnFire)
              {
                float damageModifier = obj1.땞().딟(딢.딴.땤).DamageModifier;
                땦 땦 = 땫.딟(obj0, obj1, index2, 딢.딴.땄, new 딶.땩(땊1.땃, 땊1.딶), damageModifier, 딤.딢);
                numArray[index2] += 땦.딟;
                if (땦.딟.Count > 1)
                  Debug.LogError((object) "We don't support more than 1 target in support fire!");
                if (땦.딟.Count == 1)
                  땊1.딧 -= 땦.딟[0].땄;
                if (땊1.땺())
                {
                  obj0.딟((딶.땏) new 딶.떊(obj2));
                  break;
                }
              }
            }
          }
          땊1.딧 = 딧;
        }
      }
    }

    private static int 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 딢.딯 obj2, [In] 땓.땊 obj3, [In] int obj4, [In] ref 딶.땩 obj5)
    {
      int num1 = 0;
      int num2 = 0;
      switch (obj2)
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
      int 땃 = obj3.땃;
      int 딶 = obj3.딶;
      int num3 = 2;
      int num4 = 1;
      for (int index = 0; index < obj4; ++index)
      {
        땃 += num1;
        딶 += num2;
        if (!Object.op_Equality((Object) obj0.땹().GetTile(땃, 딶), (Object) null) && !땫.딟(obj0, obj1, obj3.땥(), 땃, 딶, obj3.땄))
        {
          ++num4;
          List<GameTileComponent> gameTileComponentList = obj0.땹().get_TileNetwork().딟(obj0, obj1, obj3.땃, obj3.딶, 땃, 딶, obj0.땻()[obj3.땥()]);
          if (gameTileComponentList == null || gameTileComponentList.Count > num3)
          {
            --num4;
            break;
          }
          obj5.딟 = 땃;
          obj5.땄 = 딶;
        }
        else
          break;
      }
      return num4 - 1;
    }

    private static bool 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] int obj2, [In] int obj3, [In] int obj4, [In] int obj5)
    {
      if (obj0.딟(obj1, obj2, obj3, obj4, obj5, -1))
        return true;
      bool flag = false;
      for (int index = 0; index < obj1.땺().Count; ++index)
      {
        땓.땊 땊 = obj1.땺()[index];
        if (땊.땓() && !땊.땺() && 땊.땃 == obj3 && 땊.딶 == obj4 && obj0.땻()[index].땃())
        {
          flag = true;
          break;
        }
      }
      return flag;
    }

    private static void 딟([In] 딶.땖 obj0, [In] int obj1, [In] 딢.딴 obj2, [In] WeaponGameplayData obj3, [In] 땦 obj4)
    {
      switch (obj2)
      {
        case 딢.딴.땕:
          obj4.딟.Add(new 땱(딢.떍.땳, 땓.딢.딧, -1, obj1));
          obj4.딟.Add(new 땱(딢.떍.딗, 땓.딢.딟, 1, obj1));
          break;
        case 딢.딴.따:
          obj4.딟.Add(new 땱(딢.떍.딥, 땓.딢.딧, -1, obj1));
          obj4.딟.Add(new 땱(딢.떍.땻, 땓.딢.딟, 1, obj1));
          break;
        case 딢.딴.딾:
          obj4.딟.Add(new 땱(딢.떍.딣, 땓.딢.딧, -1, obj1));
          obj4.딟.Add(new 땱(딢.떍.딛, 땓.딢.딟, 1, obj1));
          break;
        default:
          if (obj3.UseType == 땰.딟)
            break;
          딢.떍 떍 = WeaponGameplayData.딟(obj3.UseType);
          obj4.딟.Add(new 땱(떍, 땓.딢.딧, -1, obj1));
          break;
      }
    }

    private static void 딟([In] 딶.땖 obj0, [In] 딢.떍 obj1, [In] int obj2, [In] int obj3, [In] 떃 obj4)
    {
      if (obj4.딟 == null)
        obj4.딟 = new List<땱>();
      땱 땱 = new 땱(obj1, 땓.딢.딟, obj2, obj3);
      obj4.딟.Add(땱);
    }

    private static void 딟([In] 딶.땖 obj0, [In] int obj1, [In] 떃 obj2)
    {
      땫.딟(obj0, 딢.떍.땓, obj1, obj2);
      땫.딟(obj0, 딢.떍.떈, obj1, obj2);
      땫.딟(obj0, 딢.떍.땔, obj1, obj2);
    }

    private static void 딟([In] 딶.땖 obj0, [In] 딢.떍 obj1, [In] int obj2, [In] 떃 obj3)
    {
      if (obj3.딟 == null)
        obj3.딟 = new List<땱>();
      땱 땱 = new 땱(obj1, 땓.딢.땄, -1, obj2);
      obj3.딟.Add(땱);
    }
  }
}
