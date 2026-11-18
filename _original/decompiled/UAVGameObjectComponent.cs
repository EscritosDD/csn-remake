// Decompiled with JetBrains decompiler
// Type: UAVGameObjectComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("Game/Objects/UAV")]
public class UAVGameObjectComponent : MonoBehaviour
{
  public Transform ModelPrefab;
  public Transform SkeletonPrefab;
  public LocalisationEntry UnitName;
  public Material UnitIcon;
  public AudioShader2 MoveLoopShader;
  public AudioShader2 SelectedShader;
  public AudioShader2 MoveConfirmShader;
  public AudioShader2 EnemySpottedShader;
  public AudioShader2 Deploy1Shader;
  public AudioShader2 Deploy2Shader;
  public AudioShader2 Deploy3Shader;
  public AudioShader2 Recover1Shader;
  public AudioShader2 Recover2Shader;
  public AudioShader2 Recover3Shader;
  public AudioShader2 DisableShader;
  public AudioShader2 TurnShader;
  public AudioShader2 Hit2Shader;
  public AudioShader2 Death2Shader;
  public AudioShader2 Death3Shader;
}
