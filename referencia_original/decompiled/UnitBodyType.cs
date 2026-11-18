// Decompiled with JetBrains decompiler
// Type: UnitBodyType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class UnitBodyType : ScriptableObject
{
  public int MaxHealth;
  public int BasicActionPoints;
  public int ActionPointsPerMove;
  public AudioShader2 FootStepShader;
  public AudioShader2 FoleyShader;
  public AudioShader2 BodyFallShader;
  public AudioShader2 SwishShader;
  public AudioShader2 WeaponDropShader;
  public string Id;
}
