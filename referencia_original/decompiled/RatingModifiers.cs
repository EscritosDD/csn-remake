// Decompiled with JetBrains decompiler
// Type: RatingModifiers
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class RatingModifiers : ScriptableObject
{
  public int PerAttack = 1;
  public int PerKill = 5;
  public int PerAbilityUse = 5;
  public int PerCapture = 3;
  public int PerCaptureInterrupt = 3;
  public bool CoinPotRoundingMethodCeil;
}
