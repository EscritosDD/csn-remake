// Decompiled with JetBrains decompiler
// Type: RageEdgetuneData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class RageEdgetuneData : ScriptableObject
{
  public float AaFactor = 1f;
  public float DensityFactor = 0.5f;
  public float PerspectiveBlur = 3f;
  public bool AutomaticLod = true;
  public int MaxDensity = 7;

  public RageEdgetuneData 딟() => (RageEdgetuneData) ((object) this).MemberwiseClone();
}
