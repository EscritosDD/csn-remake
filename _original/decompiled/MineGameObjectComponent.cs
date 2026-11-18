// Decompiled with JetBrains decompiler
// Type: MineGameObjectComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("Game/Objects/Mine")]
public class MineGameObjectComponent : MonoBehaviour
{
  public Transform ModelPrefab;
  public Transform SkeletonPrefab;
  public LocalisationEntry UnitName;
  public Material UnitIcon;
  public AudioShader2 TrapDetectedShader;
  public AudioShader2 DeployedShader;
  public AudioShader2 ActivateShader;
  public AudioShader2 MoveShader;
}
