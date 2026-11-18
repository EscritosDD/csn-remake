// Decompiled with JetBrains decompiler
// Type: AbilityGameplayData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class AbilityGameplayData : ScriptableObject
{
  public int RequiredAP;
  public int MaxUses;
  public int MinRange;
  public int MaxRange;
  public int Radius;
  public int MaxHealth;
  public int ActionPoints;
  public int ThermalVisionRange;
  public int MaxDeployables;
  public int HealAmount;
  public bool CanHealSelf = true;
  public int TickDamage;
  public float DamageBonus;
  public float DamageReduction;
  public float DamageModifier;
  public int MaxOpFirePerTurn;
  public bool DoWeaponCheck;
  public string WeaponId;
  public int Duration;
  public 딢.떍 BuffType = 딢.떍.딹;
  public 땓.떊 XPForUse = 땓.떊.땁;
  public float APFraction;
}
