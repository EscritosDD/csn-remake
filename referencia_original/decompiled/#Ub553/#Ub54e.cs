// Decompiled with JetBrains decompiler
// Type: 땓.땎
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땓
{
  public static class 땎
  {
    private static 딢.딴[] 딟 = new 딢.딴[29]
    {
      딢.딴.땄,
      딢.딴.딝,
      딢.딴.땋,
      딢.딴.떏,
      딢.딴.땟,
      딢.딴.때,
      딢.딴.땴,
      딢.딴.딥,
      딢.딴.딗,
      딢.딴.땻,
      딢.딴.땩,
      딢.딴.땁,
      딢.딴.땷,
      딢.딴.딸,
      딢.딴.땈,
      딢.딴.땞,
      딢.딴.땜,
      딢.딴.땪,
      딢.딴.땕,
      딢.딴.딚,
      딢.딴.따,
      딢.딴.딾,
      딢.딴.땚,
      딢.딴.딣,
      딢.딴.떉,
      딢.딴.떌,
      딢.딴.땛,
      딢.딴.땳,
      딢.딴.떎
    };

    public static 딢.딴 딟([In] 딢.딴 obj0, [In] 딲 obj1)
    {
      int num = 땎.딟(obj0);
      if (num == -1)
        return 땎.딟[0];
      for (int index = 0; index < 땎.딟.Length; ++index)
      {
        딢.딴 딴 = 땎.딟[(num + index + 1) % 땎.딟.Length];
        if (obj1.땄(딴))
          return 딴;
      }
      return obj0;
    }

    public static int 딟([In] 딢.딴 obj0)
    {
      for (int index = 0; index < 땎.딟.Length; ++index)
      {
        if (땎.딟[index] == obj0)
          return index;
      }
      return -1;
    }

    public static bool 땄([In] 딢.딴 obj0) => 땎.딟(obj0) != -1;

    public static bool 딧([In] 딢.딴 obj0)
    {
      딢.딴 딴 = obj0;
      switch (딴)
      {
        case 딢.딴.땴:
        case 딢.딴.딗:
        case 딢.딴.딥:
        case 딢.딴.땁:
        case 딢.딴.땷:
        case 딢.딴.딸:
label_4:
          return true;
        default:
          switch (딴 - 23)
          {
            case 딢.딴.딟:
            case 딢.딴.딢:
              goto label_4;
            default:
              switch (딴 - 75)
              {
                case 딢.딴.딟:
                case 딢.딴.땄:
                case 딢.딴.딧:
                  goto label_4;
                default:
                  if (딴 != 딢.딴.딝)
                    return false;
                  goto label_4;
              }
          }
      }
    }

    public static bool 딢([In] 딢.딴 obj0)
    {
      딢.딴 딴 = obj0;
      switch (딴)
      {
        case 딢.딴.땈:
        case 딢.딴.땞:
        case 딢.딴.땜:
        case 딢.딴.땪:
        case 딢.딴.딚:
        case 딢.딴.땚:
label_3:
          return true;
        default:
          switch (딴 - 23)
          {
            case 딢.딴.딟:
            case 딢.딴.딢:
              goto label_3;
            default:
              if (딴 != 딢.딴.땴 && 딴 != 딢.딴.딥 && 딴 != 딢.딴.딸 && 딴 != 딢.딴.땛)
                return false;
              goto label_3;
          }
      }
    }

    public static int 딟([In] 딶.땖 obj0, [In] int obj1, [In] 딢.딴 obj2)
    {
      if (땎.딶(obj2))
      {
        int index = 딶.딢.딟(obj0, obj0.떂(), obj1, obj2, false);
        if (index != -1)
          return (obj0.땻()[index] as 딶.땚).땃();
      }
      else if (땎.딢(obj2))
      {
        int index = 땃.떊.딟(obj0, obj0.떂(), obj1, obj2, false, false);
        if (index != -1)
          return (obj0.땻()[index] as 딶.땉).땺();
      }
      else if (땎.땺(obj2))
      {
        UnitWeapon unitWeapon = 땎.딢(obj2, obj0.땻()[obj1]);
        if (Object.op_Inequality((Object) unitWeapon, (Object) null))
          return unitWeapon.딟(obj0).RequiredActionPoints;
      }
      return -1;
    }

    public static int 땃([In] 딢.딴 obj0)
    {
      string str = 땎.땄(obj0, (딲) null);
      if (str != null)
      {
        WeaponGameplayData weaponGameplayData = GlobalAppData.딢().딟(str);
        if (Object.op_Inequality((Object) weaponGameplayData, (Object) null) && weaponGameplayData.RequiredActionPoints > 0)
          return weaponGameplayData.RequiredActionPoints;
      }
      return GlobalAppData.딢().딟(obj0).RequiredAP;
    }

    public static bool 딶([In] 딢.딴 obj0)
    {
      switch (obj0)
      {
        case 딢.딴.떏:
        case 딢.딴.땩:
        case 딢.딴.땻:
        case 딢.딴.딣:
          return true;
        default:
          return false;
      }
    }

    public static bool 땓([In] 딢.딴 obj0) => obj0 == 딢.딴.땄;

    public static bool 땺([In] 딢.딴 obj0)
    {
      딢.딴 딴 = obj0;
      switch (딴)
      {
        case 딢.딴.땕:
        case 딢.딴.따:
        case 딢.딴.딾:
          return true;
        default:
          if (딴 != 딢.딴.딝 && 딴 != 딢.딴.떎 && 딴 != 딢.딴.딗 && 딴 != 딢.딴.땳 && 딴 != 딢.딴.땁 && 딴 != 딢.딴.땷 && 딴 != 딢.딴.떉 && 딴 != 딢.딴.떌 && 딴 != 딢.딴.땄 && 딴 != 딢.딴.땋)
            return false;
          goto case 딢.딴.땕;
      }
    }

    public static List<딲> 딟([In] 딶.땖 obj0, [In] 딢.딴 obj1, [In] int obj2, [In] int obj3)
    {
      List<딲> 딲List = new List<딲>();
      딢.딴 딴 = obj1;
      switch (딴)
      {
        case 딢.딴.땟:
          for (int index = 0; index < obj0.땞().딟(딢.딴.땟).MaxDeployables; ++index)
            딲List.Add((딲) new 딶.땈(obj0, obj3++, obj2));
          break;
        case 딢.딴.때:
          딲List.Add((딲) new 딶.딚(obj0, obj3, obj2));
          break;
        case 딢.딴.땩:
          딲List.Add((딲) new 딶.땜(obj0, obj3, obj2));
          break;
        case 딢.딴.땴:
          딲List.Add((딲) new 딶.따(obj0, obj3, obj2));
          break;
        case 딢.딴.땻:
          딲List.Add((딲) new 딶.딳(obj0, obj3, obj2));
          break;
        case 딢.딴.딥:
          딲List.Add((딲) new 딶.딾(obj0, obj3, obj2));
          break;
        case 딢.딴.딣:
          딲List.Add((딲) new 딶.땝(obj0, obj3, obj2));
          break;
        default:
          switch (딴 - 48)
          {
            case 딢.딴.딟:
            case 딢.딴.땄:
            case 딢.딴.딧:
            case 딢.딴.딢:
              딲List.Add((딲) new 딶.땘(obj0, obj3, obj2, obj1));
              딲List.Add((딲) new 딶.땷(obj0, obj3 + 1, obj2, obj1));
              break;
            case 딢.딴.딶:
              딲List.Add((딲) new 딶.떔(obj0, obj3, obj2, obj1));
              break;
            case 딢.딴.땥:
              딲List.Add((딲) new 딶.땷(obj0, obj3, obj2, obj1));
              break;
            default:
              if (딴 != 딢.딴.떏)
              {
                if (딴 != 딢.딴.딸)
                {
                  if (딴 == 딢.딴.땛)
                  {
                    딲List.Add((딲) new 딶.땪(obj0, obj3, obj2));
                    break;
                  }
                  break;
                }
                딲List.Add((딲) new 딶.땞(obj0, obj3, obj2));
                break;
              }
              딲List.Add((딲) new 딶.떇(obj0, obj3, obj2));
              break;
          }
          break;
      }
      return 딲List;
    }

    public static string 땄([In] 딢.딴 obj0, [In] 딲 obj1)
    {
      딢.딴 딴 = obj0;
      switch (딴)
      {
        case 딢.딴.딗:
          return GlobalAppData.딟.EMPGrenadeWeaponId;
        case 딢.딴.땳:
          return GlobalAppData.딟.TeleportGrenadeWeaponId;
        case 딢.딴.땁:
          return GlobalAppData.딟.ExplosiveCrossbowWeaponId;
        case 딢.딴.땷:
          return GlobalAppData.딟.RocketLauncherWeaponId;
        case 딢.딴.딸:
          return GlobalAppData.딟.RemoteChargeWeaponId;
        case 딢.딴.땈:
        case 딢.딴.땞:
        case 딢.딴.땜:
        case 딢.딴.땪:
        case 딢.딴.딚:
        case 딢.딴.땚:
          return GlobalAppData.딟.GrenadeMarkerWeaponId;
        case 딢.딴.땕:
          return GlobalAppData.딟.ArtilleryWeaponId;
        case 딢.딴.따:
          return GlobalAppData.딟.OrbitalLaserWeaponId;
        case 딢.딴.딾:
          return GlobalAppData.딟.BeeBombWeaponId;
        default:
          if (딴 == 딢.딴.딝)
            return GlobalAppData.딟.ClusterGrenadeWeaponId;
          if (딴 == 딢.딴.떎)
            return GlobalAppData.딟.TrunkquilizerWeaponId;
          if (딴 == 딢.딴.떉)
            return GlobalAppData.딟.WaterCannonWeaponId;
          if (딴 == 딢.딴.떌)
            return GlobalAppData.딟.MolotovCocktailWeaponId;
          if (딴 != 딢.딴.땄)
          {
            if (딴 == 딢.딴.땋)
              return GlobalAppData.딟.GasGrenadeWeaponId;
            return 딴 == 딢.딴.땟 ? GlobalAppData.딟.LandmineWeaponId : (string) null;
          }
          return obj1?.딧();
      }
    }

    public static WeaponGameplayData 딧([In] 딢.딴 obj0, [In] 딲 obj1) => obj1.땄().땞().딟(땎.땄(obj0, obj1));

    public static UnitWeapon 딢([In] 딢.딴 obj0, [In] 딲 obj1) => GlobalAppData.땼().땽(땎.땄(obj0, obj1));

    public static AudioShader2 땥([In] 딢.딴 obj0)
    {
      for (int index = 0; index < GlobalAppData.딟.GameAssets.AbilitySoundShaders.Length; ++index)
      {
        AbilitySoundShader abilitySoundShader = GlobalAppData.딟.GameAssets.AbilitySoundShaders[index];
        if (abilitySoundShader != null && abilitySoundShader.Type == obj0)
          return abilitySoundShader.AudioShader;
      }
      return (AudioShader2) null;
    }

    public static bool 딝([In] 딢.딴 obj0)
    {
      switch (obj0)
      {
        case 딢.딴.땕:
        case 딢.딴.따:
        case 딢.딴.딾:
          return true;
        default:
          return false;
      }
    }

    public static 딢.떍 떎([In] 딢.딴 obj0)
    {
      switch (obj0)
      {
        case 딢.딴.땈:
          return 딢.떍.떁;
        case 딢.딴.땞:
          return 딢.떍.땟;
        case 딢.딴.땜:
          return 딢.떍.땂;
        case 딢.딴.땪:
          return 딢.떍.딱;
        case 딢.딴.딾:
          return 딢.떍.땔;
        default:
          return 딢.떍.딹;
      }
    }

    public static 딢.떍 떂([In] 딢.딴 obj0)
    {
      switch (obj0)
      {
        case 딢.딴.땕:
          return 딢.떍.딗;
        case 딢.딴.따:
          return 딢.떍.땻;
        case 딢.딴.딾:
          return 딢.떍.딛;
        default:
          return 딢.떍.딹;
      }
    }

    public static 딢.떍 땭([In] 딢.딴 obj0)
    {
      switch (obj0)
      {
        case 딢.딴.땈:
          return 딢.떍.때;
        case 딢.딴.땞:
          return 딢.떍.땩;
        case 딢.딴.땜:
          return 딢.떍.땠;
        case 딢.딴.땪:
          return 딢.떍.땴;
        case 딢.딴.땕:
          return 딢.떍.땳;
        case 딢.딴.딚:
          return 딢.떍.떓;
        case 딢.딴.따:
          return 딢.떍.딥;
        case 딢.딴.딾:
          return 딢.떍.딣;
        case 딢.딴.땚:
          return 딢.떍.땁;
        default:
          return 딢.떍.딹;
      }
    }

    public static int 딟([In] 딶.땖 obj0, [In] 딢.딴 obj1)
    {
      switch (obj1)
      {
        case 딢.딴.땈:
          return obj0.땞().떏().MaxUses;
        case 딢.딴.땞:
          return obj0.땞().땼().MaxUses;
        case 딢.딴.땜:
          return obj0.땞().땢().MaxUses;
        case 딢.딴.땪:
          return obj0.땞().딷().MaxUses;
        case 딢.딴.땕:
          return obj0.땞().떁().MaxUses;
        case 딢.딴.딚:
          return obj0.땞().딟(딢.딴.딚).MaxUses;
        case 딢.딴.따:
          return obj0.땞().땟().MaxUses;
        case 딢.딴.딾:
          return obj0.땞().땟().MaxUses;
        case 딢.딴.땚:
          return obj0.땞().딱().MaxUses;
        default:
          return -1;
      }
    }

    public static int 땄([In] 딶.땖 obj0, [In] int obj1, [In] 딢.딴 obj2)
    {
      if (땎.땺(obj2))
        return 땎.딧(obj2, obj0.땻()[obj1]).딟(obj0, obj0.떂().땺()[obj1], false, false);
      if (땎.딶(obj2))
      {
        int index = 딶.딢.딟(obj0, obj0.떂(), obj1, obj2);
        if (index == -1)
          return 0;
        딶.땚 땚 = obj0.땻()[index] as 딶.땚;
        int num1 = 땚.땄();
        if (num1 == -1)
          return -1;
        if (땚.딟())
          return AbilitySelectionHUDGrid.땄;
        int num2 = Mathf.Max(0, obj0.떂().땺()[index].딢(딢.떍.땄));
        return num1 - num2;
      }
      if (!땎.딢(obj2))
        return -1;
      int num3 = 땃.떊.딟(obj0, obj0.떂(), obj1, obj2, false);
      int num4 = 땃.떊.딟(obj0, obj0.떂(), obj1, obj2, true);
      if (num3 > 1)
        return num4;
      int index1 = 땃.떊.딟(obj0, obj0.떂(), obj1, obj2, false, false);
      if (index1 == -1)
        return 0;
      딢.딴 딴 = (obj0.땻()[index1] as 딶.땉).딟();
      딢.떍 떍 = 땎.땭(딴);
      int num5 = 땎.딟(obj0, 딴);
      if (num5 < 0)
        return num4;
      int num6 = Mathf.Max(0, obj0.떎()[obj1].딢(떍));
      return num5 - num6;
    }

    public static bool 딟([In] 딶.땖 obj0, [In] int obj1, [In] 딢.딴 obj2, [In] int obj3)
    {
      int 딢 = obj0.떎()[obj1].딢;
      if (땎.땓(obj2))
        return 딢 > 0;
      if (땎.땺(obj2))
      {
        WeaponGameplayData weaponGameplayData = 땎.딧(obj2, obj0.땻()[obj1]);
        return 딢 >= weaponGameplayData.RequiredActionPoints && weaponGameplayData.딟(obj0, obj0.떂().땺()[obj1], false, true) > 0;
      }
      if (땎.딶(obj2))
      {
        int index = 딶.딢.딟(obj0, obj0.떂(), obj1, obj2);
        if (index == -1)
          return false;
        딶.땚 땚 = obj0.땻()[index] as 딶.땚;
        return 딢 >= 땚.땃() && (!땎.딦(obj2) || 땚.딟(obj0.떂(), obj1));
      }
      if (!땎.딢(obj2))
        return true;
      if (obj3 == 0)
        return false;
      int index1 = 땃.떊.딟(obj0, obj0.떂(), obj1, obj2, false, false);
      if (index1 == -1)
        return false;
      딶.땉 땉 = obj0.땻()[index1] as 딶.땉;
      return 땃.떊.딟(obj0, obj0.떂(), obj1, 땉);
    }

    public static bool 딦([In] 딢.딴 obj0)
    {
      switch (obj0)
      {
        case 딢.딴.땻:
        case 딢.딴.딣:
          return true;
        default:
          return false;
      }
    }

    public static bool 땤([In] 딢.딴 obj0)
    {
      switch (obj0)
      {
        case 딢.딴.딟:
        case 딢.딴.땄:
        case 딢.딴.떏:
        case 딢.딴.땩:
          return false;
        default:
          return true;
      }
    }
  }
}
