// Decompiled with JetBrains decompiler
// Type: GlobalAppState
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

[Serializable]
public class GlobalAppState
{
  public FireTeamRequestInformationPanel FireTeamRequestInformationPanelPrefab;
  public AchievementList Achievements;
  public UnitBodyType[] BodyTypes;
  public SkeletonInfo[] Skeletons;
  public string MinePrefabId;
  public string SentryGunPrefabId;
  public string SentryRocketsPrefabId;
  public string DeployableCoverPrefabId;
  public string UAVPrefabId;
  public string RemoteChargePrefabId;
  public string RiotShieldPrefabId;
  public string HealthCratePrefabId;
  public string HighVelocityAmmoCratePrefabId;
  public string PainKillersCratePrefabId;
  public string TeamSpiritCratePrefabId;
  public string BeaconPrefabId;
  public string LootDropPrefabId;
  public DefeaultInventoryItem[] DefaultInventory;
  public string DefaultPlayerAvatarId;
  public string DefaultCommanderId;
  public Transform PosisonEffectPrefab;
  public float PoisonEffectDuration = 1f;
  public AudioShader2 PoisonShader;
  public Transform HealEffectPrefab;
  public float HealEffectDuration = 1f;
  public Transform AdrenalineEffectPrefab;
  public float AdrenalineEffectDuration = 1f;
  public Transform HackEffectPrefab;
  public float HackEffectDuration = 1f;
  public Transform BeeEffectPrefab;
  public float BeeEffectDuration = 1f;
  public AudioShader2 BeeShader;
  public Transform FireEffectPrefab;
  public float FireEffectDuration = 1f;
  public AudioShader2 FireShader;
  public Transform HealthCrateEffectPrefab;
  public AudioShader2 HealthCrateShader;
  public float HealthCrateDuration = 1f;
  public Transform ImprovedAmmoCrateEffectPrefab;
  public AudioShader2 ImprovedAmmoCrateShader;
  public float ImprovedAmmoCrateDuration = 1f;
  public Transform PainKillerCrateEffectPrefab;
  public AudioShader2 PainKillerCrateShader;
  public float PainKillerCrateDuration = 1f;
  public Transform TeamSpiritCrateEffectPrefab;
  public AudioShader2 TeamSpiritCrateShader;
  public float TeamSpiritCrateDuration = 1f;
  public Transform LootCrateEffectPrefab;
  public AudioShader2 LootCrateShader;
  public float LootCrateDuration = 1f;
  public string ClusterGrenadeWeaponId;
  public string MolotovCocktailWeaponId;
  public string GasGrenadeWeaponId;
  public string EMPGrenadeWeaponId;
  public string LandmineWeaponId;
  public string ExplosiveCrossbowWeaponId;
  public string RocketLauncherWeaponId;
  public string WaterCannonWeaponId;
  public string RemoteChargeWeaponId;
  public string GrenadeMarkerWeaponId;
  public string ArtilleryWeaponId;
  public string OrbitalLaserWeaponId;
  public string BeeBombWeaponId;
  public string TeleportGrenadeWeaponId;
  public string TrunkquilizerWeaponId;
  public TacticsGameAssets GameAssets;
  public string TutorialLevelId;
  public int TutorialLevelScenario;
  public EnvironmentSettings EnvSettings;
  public int EmailIncentivisationFrequency;
  public LocalisationEntry[] CharacterLocalNotificationText;

  [CompilerGenerated]
  [SpecialName]
  public GlobalAppState.땊 딟() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public void 딟([In] GlobalAppState.땊 obj0) => this.딟 = obj0;

  [CompilerGenerated]
  [SpecialName]
  public 딧.땧 땄() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public void 딟([In] 딧.땧 obj0) => this.딟 = obj0;

  [CompilerGenerated]
  [SpecialName]
  public 땃.땽 딧() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public void 딟([In] 땃.땽 obj0) => this.딟 = obj0;

  [CompilerGenerated]
  [SpecialName]
  public string 딢() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public void 딟([In] string obj0) => this.딟 = obj0;

  [CompilerGenerated]
  [SpecialName]
  public string 땃() => this.땄;

  [CompilerGenerated]
  [SpecialName]
  public void 땄([In] string obj0) => this.땄 = obj0;

  [CompilerGenerated]
  [SpecialName]
  public string 딶() => this.딧;

  [CompilerGenerated]
  [SpecialName]
  public void 딧([In] string obj0) => this.딧 = obj0;

  [SpecialName]
  public string 땓() => "avatar://" + this.DefaultPlayerAvatarId;

  [CompilerGenerated]
  [SpecialName]
  public UnitWeapon 땺() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public UnitWeapon 땥() => this.땄;

  [CompilerGenerated]
  [SpecialName]
  public UnitWeapon 딝() => this.딧;

  [CompilerGenerated]
  [SpecialName]
  public UnitWeapon 떎() => this.딢;

  [CompilerGenerated]
  [SpecialName]
  public UnitWeapon 떂() => this.땃;

  [CompilerGenerated]
  [SpecialName]
  public UnitWeapon 땭() => this.딶;

  [CompilerGenerated]
  [SpecialName]
  public UnitWeapon 딦() => this.땓;

  [CompilerGenerated]
  [SpecialName]
  public UnitWeapon 땤() => this.땺;

  [CompilerGenerated]
  [SpecialName]
  public UnitWeapon 땽() => this.땥;

  [CompilerGenerated]
  [SpecialName]
  public UnitWeapon 땋() => this.딝;

  [CompilerGenerated]
  [SpecialName]
  public UnitWeapon 땲() => this.떎;

  public void 딟([In] 딶.땖 obj0)
  {
    // ISSUE: reference to a compiler-generated method
    this.딟(GlobalAppData.땼().땽(this.ClusterGrenadeWeaponId));
    // ISSUE: reference to a compiler-generated method
    this.땄(GlobalAppData.땼().땽(this.GasGrenadeWeaponId));
    // ISSUE: reference to a compiler-generated method
    this.딧(GlobalAppData.땼().땽(this.EMPGrenadeWeaponId));
    // ISSUE: reference to a compiler-generated method
    this.딢(GlobalAppData.땼().땽(this.LandmineWeaponId));
    // ISSUE: reference to a compiler-generated method
    this.땃(GlobalAppData.땼().땽(this.ExplosiveCrossbowWeaponId));
    // ISSUE: reference to a compiler-generated method
    this.딶(GlobalAppData.땼().땽(this.RocketLauncherWeaponId));
    // ISSUE: reference to a compiler-generated method
    this.땓(GlobalAppData.땼().땽(this.RemoteChargeWeaponId));
    // ISSUE: reference to a compiler-generated method
    this.땺(GlobalAppData.땼().땽(this.GrenadeMarkerWeaponId));
    // ISSUE: reference to a compiler-generated method
    this.땥(GlobalAppData.땼().땽(this.ArtilleryWeaponId));
    // ISSUE: reference to a compiler-generated method
    this.딝(GlobalAppData.땼().땽(this.OrbitalLaserWeaponId));
    // ISSUE: reference to a compiler-generated method
    this.떎(GlobalAppData.땼().땽(this.BeeBombWeaponId));
  }

  public void 떏()
  {
    // ISSUE: reference to a compiler-generated method
    this.딟((UnitWeapon) null);
    // ISSUE: reference to a compiler-generated method
    this.땄((UnitWeapon) null);
    // ISSUE: reference to a compiler-generated method
    this.딧((UnitWeapon) null);
    // ISSUE: reference to a compiler-generated method
    this.딢((UnitWeapon) null);
    // ISSUE: reference to a compiler-generated method
    this.땃((UnitWeapon) null);
    // ISSUE: reference to a compiler-generated method
    this.딶((UnitWeapon) null);
    // ISSUE: reference to a compiler-generated method
    this.땓((UnitWeapon) null);
    // ISSUE: reference to a compiler-generated method
    this.땺((UnitWeapon) null);
    // ISSUE: reference to a compiler-generated method
    this.땥((UnitWeapon) null);
    // ISSUE: reference to a compiler-generated method
    this.딝((UnitWeapon) null);
    // ISSUE: reference to a compiler-generated method
    this.떎((UnitWeapon) null);
    GlobalAppData.땲().딟();
  }

  public enum 땊
  {
    딟,
    땄,
    딧,
    딢,
    땃,
    딶,
    땓,
    땺,
    땥,
    딝,
    떎,
    떂,
    땭,
    딦,
    땤,
    땽,
  }
}
