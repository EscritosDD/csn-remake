// Decompiled with JetBrains decompiler
// Type: WeaponGameplayData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class WeaponGameplayData : ScriptableObject
{
  public bool IsPrimaryWeapon;
  public bool IgnoreVisCheck;
  public int MinRange;
  public int MaxRange;
  public int SplashRange;
  public int LineRange;
  public int ShotsPerAttack = 1;
  public int MaxUses = 1;
  [Obsolete("Call CalcMinDamage instead")]
  public float MinDamage;
  public float DamageSpread;
  public float Accuracy;
  public float CritChance;
  public int RequiredActionPoints;
  public bool AllowsReturnFire = true;
  public 땃.땰 UseType;
  public 딶.딱 DamageType;
  public 딢.딴 RequiredAbility;
  public 땓.땍 Category;
  public WeaponFalloffCurve WeaponDamageFallOffCurve;
  public WeaponFalloffCurve WeaponSplashDamageFallOffCurve;
  public int KnockbackDistance;
  public int KnockbackRange = 1;
  public int SquadPoints = 3;
  public bool TwoStageAttack;

  public bool 딟([In] 땓.떀 obj0)
  {
    if (!this.IsPrimaryWeapon || this.RequiredAbility != 딢.딴.딟 && !obj0.땄(this.RequiredAbility))
      return false;
    foreach (땓.땍 supportedWeaponCategory in obj0.땁().SupportedWeaponCategories)
    {
      if (supportedWeaponCategory == this.Category)
        return true;
    }
    return false;
  }

  public bool 딟([In] 딶.땖 obj0, [In] 땓.땊 obj1, [In] bool obj2) => this.딟(obj0, obj1, obj2, true) > 0;

  public int 딟([In] 딶.땖 obj0, [In] 땓.땊 obj1, [In] bool obj2, [In] bool obj3)
  {
    딢.떍 떍1 = 땓.땎.떂(this.RequiredAbility);
    딢.떍 떍2 = 땓.땎.땭(this.RequiredAbility);
    if (떍1 != 딢.떍.딹)
    {
      int num1 = 땓.땎.딟(obj0, this.RequiredAbility);
      if (obj1.딢(떍1) > 0 && obj3)
        return 0;
      int num2 = obj1.딢(떍2);
      return num2 >= num1 ? 0 : num1 - Mathf.Max(0, num2);
    }
    if (this.UseType != 땃.땰.딟)
    {
      딢.떍 떍3 = WeaponGameplayData.딟(this.UseType);
      return Mathf.Max(0, this.MaxUses - Mathf.Max(0, obj1.딢(떍3)));
    }
    if (this.RequiredActionPoints <= 0)
      return 0;
    return obj2 ? 1 : obj1.딢 / this.RequiredActionPoints;
  }

  public static 딢.떍 딟([In] 땃.땰 obj0)
  {
    switch (obj0)
    {
      case 땃.땰.땄:
        return 딢.떍.땃;
      case 땃.땰.딧:
        return 딢.떍.땵;
      case 땃.땰.딢:
        return 딢.떍.땛;
      case 땃.땰.땃:
        return 딢.떍.떐;
      case 땃.땰.딶:
        return 딢.떍.땘;
      default:
        return 딢.떍.딹;
    }
  }

  public float 딟([In] 딶.땖 obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4) => this.딟(obj0.땹().get_Tiles()[obj1, obj2], obj0.땹().get_Tiles()[obj3, obj4]);

  public float 딟([In] GameTileComponent obj0, [In] GameTileComponent obj1) => Object.op_Equality((Object) this.WeaponDamageFallOffCurve, (Object) null) ? 1f : this.WeaponDamageFallOffCurve.WeaponDamageFallOffCurve.Evaluate((float) 땓.땊.딟(obj0.TileIndexX, obj0.TileIndexY, obj1.TileIndexX, obj1.TileIndexY) / (float) this.MaxRange);

  public float 딟([In] float obj0)
  {
    if (Object.op_Equality((Object) this.WeaponSplashDamageFallOffCurve, (Object) null) || this.SplashRange == 0)
      return 1f;
    obj0 = Mathf.Clamp01(obj0);
    return this.WeaponSplashDamageFallOffCurve.WeaponDamageFallOffCurve.Evaluate(obj0);
  }

  public bool 딟() => this.SplashRange > 0 || this.LineRange > 0;

  public float 땄() => this.MinDamage;

  public float 딟([In] VersionedGameData obj0, [In] 땓.땊 obj1)
  {
    float minDamage = this.MinDamage;
    if (obj1.딢(딢.떍.딷) > 0)
      minDamage += obj0.딶().DamageBonus / (float) this.ShotsPerAttack;
    return minDamage;
  }
}
