// Decompiled with JetBrains decompiler
// Type: RageGroupPhysicsData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class RageGroupPhysicsData : ScriptableObject
{
  public 땺.땔.땁 Type;
  public bool CreatePhysicsInEditor;
  public bool CreateConvexMeshCollider;
  public PhysicMaterial PhysicsMaterial;
  public int PhysicsColliderCount = 32;
  public float ColliderZDepth = 100f;
  public float BoxColliderDepth = 1f;
  public float ColliderNormalOffset;
}
