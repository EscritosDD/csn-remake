// Decompiled with JetBrains decompiler
// Type: CrateGameObjectComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("Game/Objects/Crate")]
public class CrateGameObjectComponent : MonoBehaviour
{
  public Transform ModelPrefab;
  public Transform SkeletonPrefab;
  public Transform SecondarySkeletonPrefab;
  public Transform SecondaryModelPrefab;
  public LocalisationEntry UnitName;
  public Material UnitIcon;
  public AudioShader2 DeployShader;
  public AudioShader2 DeathShader;
  public Transform DeathEffectPrefab;
}
