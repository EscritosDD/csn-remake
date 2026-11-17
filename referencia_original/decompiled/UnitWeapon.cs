// Decompiled with JetBrains decompiler
// Type: UnitWeapon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

public class UnitWeapon : ScriptableObject
{
  public 땓.땸 FireMode;
  public Material Icon;
  public LocalisationEntry Name;
  public LocalisationEntry Description;
  public string WeaponId;
  public WeaponModelInfo[] Models;
  public 땓.딬 Stance;
  public AudioShader2 FireSoundShader;
  public AudioShader2 HitSoundShader;
  public AudioShader2 HitMetalSoundShader;
  public AudioShader2 HitWoodSoundShader;
  public AudioShader2 HitConcreteSoundShader;
  public AudioShader2 CockSoundShader;
  public AudioShader2 BulletBySoundShader;
  public AudioShader2 ProjectileBySoundShader;
  public Transform ProjectileMeshPrefab;
  public AnimationCurve ProjectileCurve = AnimationCurve.Linear(0.0f, 1f, 1f, 1f);
  public float ProjectileSpeed = 6f;
  public Transform ProjectileExplosionPrefab;
  public float ProjectileExplosionDuration = 0.15f;
  public float ProjectileExplosionDelay;
  public string ProjectileSpawnJoint;
  public AudioShader2 ProjectileExplosionSoundShader;
  public float CameraShakeTime = 0.5f;
  public float CameraShakeStrength = 0.25f;
  public string SecondaryEffectJointName;
  public Transform SecondaryEffectPrefab;
  public float SecondaryEffectDuration;
  public string MuzzleJointName;
  public string MuzzleJointNameB;
  public Transform MuzzleFlashPrefab;
  public Transform MuzzleFlashPrefabB;
  public bool MuzzleFlashInWorldSpace;
  public float MuzzleFlashDuration = 0.15f;
  public float MuzzleFlashDurationB = 0.15f;
  public Vector3 BarracksRotation;
  public Vector3 BarracksOffset;
  public Vector3 BarracksScale = Vector3.one;

  public bool 딟([In] 딶.땖 obj0, [In] 땓.떀 obj1) => this.딟(obj0).딟(obj1);

  public string 딟([In] 딶.땖 obj0, [In] 땓.딺 obj1)
  {
    WeaponGameplayData weaponGameplayData = this.딟(obj0);
    switch (obj1)
    {
      case 땓.딺.땓:
        if (this.FireMode == 땓.땸.딢 || this.FireMode == 땓.땸.딶)
          return "Hit_Burst";
        switch (weaponGameplayData.DamageType)
        {
          case 딶.딱.땄:
          case 딶.딱.떎:
            return "Hit_Explosion";
          case 딶.딱.딢:
          case 딶.딱.딶:
            return "Disable";
          case 딶.딱.땃:
            return "Hit_Melee";
          default:
            return "Hit";
        }
      case 땓.딺.땺:
        switch (weaponGameplayData.DamageType)
        {
          case 딶.딱.땄:
          case 딶.딱.떎:
            return "Death_Explosion";
          default:
            return "Death_Bullet";
        }
      case 땓.딺.딝:
        return "Throw";
      case 땓.딺.떎:
        return "Deploy";
      case 땓.딺.땤:
        return "Commander_Order";
      default:
        string str1;
        switch (this.Stance)
        {
          case 땓.딬.땄:
            str1 = "1H_";
            break;
          case 땓.딬.딧:
            str1 = "2H_";
            break;
          case 땓.딬.딢:
            str1 = "Melee_";
            break;
          default:
            str1 = string.Empty;
            break;
        }
        string str2;
        switch (obj1)
        {
          case 땓.딺.땄:
            switch (this.FireMode)
            {
              case 땓.땸.땄:
                str2 = "Fire_Light";
                break;
              case 땓.땸.딧:
                str2 = "Fire_Heavy";
                break;
              case 땓.땸.딢:
                str2 = "Fire_Burst";
                break;
              case 땓.땸.땃:
                str2 = "Fire_ShoulderMount";
                break;
              case 땓.땸.딶:
                str2 = "Fire_MiniGun";
                break;
              case 땓.땸.땓:
                str2 = "Throw";
                break;
              default:
                str2 = "Fire";
                break;
            }
            break;
          case 땓.딺.딧:
            str2 = "Turn_R";
            break;
          case 땓.딺.딢:
            str2 = "Turn_L";
            break;
          case 땓.딺.땃:
            str2 = "Turn_180";
            break;
          case 땓.딺.딶:
            str2 = "Walk";
            break;
          case 땓.딺.땭:
            str2 = "Idle_02";
            break;
          default:
            str2 = "Idle_01";
            break;
        }
        return string.Format("{0}{1}", (object) str1, (object) str2);
    }
  }

  public WeaponGameplayData 딟([In] 딶.땖 obj0) => (obj0 != null ? obj0.땞() : GlobalAppData.딢()).딟(this.WeaponId);
}
