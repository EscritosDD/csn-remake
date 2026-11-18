// Decompiled with JetBrains decompiler
// Type: VersionedGameData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using 딢;

public class VersionedGameData : ScriptableObject
{
  private Dictionary<딴, AbilityGameplayData> 딟;
  private Dictionary<string, WeaponGameplayData> 딟;
  public RatingModifiers RatingModifiersData;
  public AbilityGameplayDataPair[] AbilityData;
  public UnitLevels XPLevels;
  public WeaponGameplayDataPair[] WeaponData;
  public GenericGameplayData GenericData;
  public int Version;
  public bool IgnoreGameValidation;

  private void OnEnable()
  {
    this.딟 = new Dictionary<string, WeaponGameplayData>();
    if (this.WeaponData != null)
    {
      for (int index = 0; index < this.WeaponData.Length; ++index)
        this.딟.Add(this.WeaponData[index].WeaponId, this.WeaponData[index].WeaponData);
    }
    this.딟 = new Dictionary<딴, AbilityGameplayData>();
    if (this.AbilityData == null)
      return;
    for (int index = 0; index < this.AbilityData.Length; ++index)
      this.딟.Add(this.AbilityData[index].Type, this.AbilityData[index].Data);
  }

  public AbilityGameplayData 딟([In] 딴 obj0)
  {
    AbilityGameplayData abilityGameplayData;
    return !this.딟.TryGetValue(obj0, out abilityGameplayData) ? (AbilityGameplayData) null : abilityGameplayData;
  }

  public WeaponGameplayData 딟([In] string obj0)
  {
    if (string.IsNullOrEmpty(obj0))
      return (WeaponGameplayData) null;
    WeaponGameplayData weaponGameplayData;
    return !this.딟.TryGetValue(obj0, out weaponGameplayData) ? (WeaponGameplayData) null : weaponGameplayData;
  }

  public UnitLevel 딟([In] int obj0) => this.딟(obj0, out int _, out UnitLevel _);

  public UnitLevel 딟([In] int obj0, out int _param2) => this.딟(obj0, out _param2, out UnitLevel _);

  public int 땄([In] int obj0) => this.땄(obj0, out int _);

  public int 땄([In] int obj0, out int _param2)
  {
    _param2 = obj0;
    for (int index = 0; index < this.XPLevels.Levels.Length; ++index)
    {
      if (_param2 < this.XPLevels.Levels[index].RequiredXP)
        return index - 1;
      _param2 -= this.XPLevels.Levels[index].RequiredXP;
    }
    _param2 = this.XPLevels.Levels[this.XPLevels.Levels.Length - 1].RequiredXP;
    return this.XPLevels.Levels.Length - 1;
  }

  public UnitLevel 딟([In] int obj0, out int _param2, out UnitLevel _param3)
  {
    int index = this.땄(obj0, out _param2);
    _param3 = index != this.XPLevels.Levels.Length - 1 ? this.XPLevels.Levels[index + 1] : (UnitLevel) null;
    return this.XPLevels.Levels[index];
  }

  public int 딟([In] UnitLevel obj0)
  {
    int num = 0;
    int index;
    for (index = 0; obj0 != this.XPLevels.Levels[index]; ++index)
      num += this.XPLevels.Levels[index].RequiredXP;
    return num + obj0.RequiredXP + this.XPLevels.Levels[index + 1].RequiredXP;
  }

  public int 딧([In] int obj0)
  {
    if (obj0 > this.XPLevels.Levels.Length)
      obj0 = this.XPLevels.Levels.Length;
    return this.딟(this.XPLevels.Levels[obj0]);
  }

  public int 땄([In] UnitLevel obj0)
  {
    int num = 0;
    for (int index = 0; obj0 != this.XPLevels.Levels[index]; ++index)
      num += this.XPLevels.Levels[index].RequiredXP;
    return num + obj0.RequiredXP;
  }

  [SpecialName]
  public AbilityGameplayData 딟() => this.딟(딴.딷);

  [SpecialName]
  private void 딟([In] AbilityGameplayData obj0)
  {
  }

  [SpecialName]
  public AbilityGameplayData 땄() => this.딟(딴.딶);

  [SpecialName]
  private void 땄([In] AbilityGameplayData obj0)
  {
  }

  [SpecialName]
  public AbilityGameplayData 딧() => this.딟(딴.땻);

  [SpecialName]
  private void 딧([In] AbilityGameplayData obj0)
  {
  }

  [SpecialName]
  public AbilityGameplayData 딢() => this.딟(딴.딢);

  [SpecialName]
  private void 딢([In] AbilityGameplayData obj0)
  {
  }

  [SpecialName]
  public AbilityGameplayData 땃() => this.딟(딴.떏);

  [SpecialName]
  private void 땃([In] AbilityGameplayData obj0)
  {
  }

  [SpecialName]
  public AbilityGameplayData 딶() => this.딟(딴.딣);

  [SpecialName]
  private void 딶([In] AbilityGameplayData obj0)
  {
  }

  [SpecialName]
  public AbilityGameplayData 땓() => this.딟(딴.땟);

  [SpecialName]
  private void 땓([In] AbilityGameplayData obj0)
  {
  }

  [SpecialName]
  public AbilityGameplayData 땺() => this.딟(딴.딸);

  [SpecialName]
  private void 땺([In] AbilityGameplayData obj0)
  {
  }

  [SpecialName]
  public AbilityGameplayData 땥() => this.딟(딴.딚);

  [SpecialName]
  private void 땥([In] AbilityGameplayData obj0)
  {
  }

  [SpecialName]
  public AbilityGameplayData 딝() => this.딟(딴.땋);

  [SpecialName]
  private void 딝([In] AbilityGameplayData obj0)
  {
  }

  [SpecialName]
  public AbilityGameplayData 떎() => this.딟(딴.떌);

  [SpecialName]
  private void 떎([In] AbilityGameplayData obj0)
  {
  }

  [SpecialName]
  public AbilityGameplayData 떂() => this.딟(딴.딗);

  [SpecialName]
  private void 떂([In] AbilityGameplayData obj0)
  {
  }

  [SpecialName]
  public AbilityGameplayData 땭() => this.딟(딴.때);

  [SpecialName]
  private void 땭([In] AbilityGameplayData obj0)
  {
  }

  [SpecialName]
  public AbilityGameplayData 딦() => this.딟(딴.땴);

  [SpecialName]
  private void 딦([In] AbilityGameplayData obj0)
  {
  }

  [SpecialName]
  public AbilityGameplayData 땤() => this.딟(딴.땩);

  [SpecialName]
  private void 땤([In] AbilityGameplayData obj0)
  {
  }

  [SpecialName]
  public AbilityGameplayData 땽() => this.딟(딴.딥);

  [SpecialName]
  private void 땽([In] AbilityGameplayData obj0)
  {
  }

  [SpecialName]
  public AbilityGameplayData 땋() => this.딟(딴.땛);

  [SpecialName]
  private void 땋([In] AbilityGameplayData obj0)
  {
  }

  [SpecialName]
  public AbilityGameplayData 땲() => this.딟(딴.땤);

  [SpecialName]
  private void 땲([In] AbilityGameplayData obj0)
  {
  }

  [SpecialName]
  public AbilityGameplayData 떏() => this.딟(딴.땈);

  [SpecialName]
  private void 떏([In] AbilityGameplayData obj0)
  {
  }

  [SpecialName]
  public AbilityGameplayData 땼() => this.딟(딴.땞);

  [SpecialName]
  private void 땼([In] AbilityGameplayData obj0)
  {
  }

  [SpecialName]
  public AbilityGameplayData 땢() => this.딟(딴.땜);

  [SpecialName]
  private void 땢([In] AbilityGameplayData obj0)
  {
  }

  [SpecialName]
  public AbilityGameplayData 딷() => this.딟(딴.땪);

  [SpecialName]
  private void 딷([In] AbilityGameplayData obj0)
  {
  }

  [SpecialName]
  public AbilityGameplayData 떁() => this.딟(딴.땕);

  [SpecialName]
  private void 떁([In] AbilityGameplayData obj0)
  {
  }

  [SpecialName]
  public AbilityGameplayData 땟() => this.딟(딴.따);

  [SpecialName]
  private void 땟([In] AbilityGameplayData obj0)
  {
  }

  [SpecialName]
  public AbilityGameplayData 땂() => this.딟(딴.딾);

  [SpecialName]
  private void 땂([In] AbilityGameplayData obj0)
  {
  }

  [SpecialName]
  public AbilityGameplayData 딱() => this.딟(딴.땚);

  [SpecialName]
  private void 딱([In] AbilityGameplayData obj0)
  {
  }
}
