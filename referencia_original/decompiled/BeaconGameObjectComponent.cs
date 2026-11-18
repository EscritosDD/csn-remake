// Decompiled with JetBrains decompiler
// Type: BeaconGameObjectComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("Game/Objects/Beacon")]
public class BeaconGameObjectComponent : MonoBehaviour
{
  public Transform ModelPrefab;
  public Transform SkeletonPrefab;
  public LocalisationEntry UnitNameUnknown;
  public LocalisationEntry UnitNameHealth;
  public LocalisationEntry UnitNameHighVelocityAmmo;
  public LocalisationEntry UnitNamePainKillers;
  public LocalisationEntry UnitNameTeamSpirit;
  public LocalisationEntry UnitNameDetectoSweep;
  public Material UnitIconUnknown;
  public Material UnitIconHealth;
  public Material UnitIconHighVelocityAmmo;
  public Material UnitIconPainKillers;
  public Material UnitIconTeamSpirit;
  public Material UnitIconDetectoSweep;
  public AudioShader2 DeployedShader;
}
