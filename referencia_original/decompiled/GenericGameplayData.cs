// Decompiled with JetBrains decompiler
// Type: GenericGameplayData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;
using 딢;

public class GenericGameplayData : ScriptableObject
{
  public float ReturnFireDamageScale;
  public float CriticalHitDamageScale;
  public float XPBoostScale = 1.5f;
  public int TutorialXP;
  public float CoinsBoostScale = 1.5f;
  public bool PlayFirstTurnImmediately;
  public XPRewardEntry[] XPRewards;
  public PlayerAbilityEntry[] PlayerAbilities;
  public AbilityInfo[] CharacterAbilities;
  public PlayerLevel[] PlayerLevels;
  public SquadPointsTierEntry[] SquadPointsTierEntries;
  public PotSizeEntry[] MatchRatings;
  public SinglePlayerCoinReward[] SinglePlayerCoinAwards;

  public PlayerAbilityEntry 딟([In] int obj0)
  {
    foreach (PlayerAbilityEntry playerAbility in this.PlayerAbilities)
    {
      if (playerAbility.RequiredLevel == obj0)
        return playerAbility;
    }
    return (PlayerAbilityEntry) null;
  }

  public PlayerAbilityEntry 딟([In] 딴 obj0)
  {
    foreach (PlayerAbilityEntry playerAbility in this.PlayerAbilities)
    {
      if (playerAbility.AbilityInfo.Ability == obj0)
        return playerAbility;
    }
    return (PlayerAbilityEntry) null;
  }

  public AbilityInfo 땄([In] 딴 obj0)
  {
    foreach (AbilityInfo characterAbility in this.CharacterAbilities)
    {
      if (characterAbility.Ability == obj0)
        return characterAbility;
    }
    return (AbilityInfo) null;
  }

  public int 땄([In] int obj0) => this.땄(obj0, out int _);

  public PlayerLevel 딟([In] int obj0, out int _param2)
  {
    int index = this.땄(obj0, out _param2);
    return !this.딧(index) ? this.PlayerLevels[index] : this.PlayerLevels[index - 1];
  }

  public int 딟()
  {
    int num = 0;
    for (int index = 0; index < this.PlayerLevels.Length; ++index)
      num += this.PlayerLevels[index].RequiredXP;
    return num;
  }

  public int 땄([In] int obj0, out int _param2)
  {
    _param2 = obj0;
    for (int index = 0; index < this.PlayerLevels.Length; ++index)
    {
      if (_param2 < this.PlayerLevels[index].RequiredXP)
        return index;
      _param2 -= this.PlayerLevels[index].RequiredXP;
    }
    _param2 = this.PlayerLevels[this.PlayerLevels.Length - 1].RequiredXP;
    return this.PlayerLevels.Length;
  }

  public bool 딧([In] int obj0) => obj0 == this.PlayerLevels.Length;

  public int 딢([In] int obj0)
  {
    if (this.딧(obj0))
      return this.PlayerLevels[this.PlayerLevels.Length - 1].RequiredXP;
    int num = 0;
    if (obj0 >= this.PlayerLevels.Length)
      obj0 = this.PlayerLevels.Length - 1;
    for (int index = 0; index <= obj0; ++index)
      num += this.PlayerLevels[index].RequiredXP;
    return num;
  }

  public SquadPointsTierEntry 땃([In] int obj0)
  {
    foreach (SquadPointsTierEntry squadPointsTierEntry in this.SquadPointsTierEntries)
    {
      if (squadPointsTierEntry.Tier == obj0)
        return squadPointsTierEntry;
    }
    return (SquadPointsTierEntry) null;
  }

  public int 딶([In] int obj0)
  {
    int num1 = 0;
    int num2 = obj0;
    for (int index = 0; index < this.MatchRatings.Length && num2 >= this.MatchRatings[index].RatingRequired; ++index)
    {
      num1 = this.MatchRatings[index].PotSize;
      num2 -= this.MatchRatings[index].RatingRequired;
    }
    return num1;
  }
}
