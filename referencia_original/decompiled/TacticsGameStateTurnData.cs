// Decompiled with JetBrains decompiler
// Type: TacticsGameStateTurnData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;

[딧.딷]
[Serializable]
public sealed class TacticsGameStateTurnData
{
  [딧.떁(Name = "ActiveTeam")]
  public int ActiveTeam;
  [딧.떁(Name = "StartSeed")]
  public int StartSeed;
  [딧.떁(Name = "Seed")]
  public int Seed;
  [딧.떁(Name = "RatingValue")]
  public int RatingValue;
  [딧.떁(Name = "Units")]
  public UnitTurnDataJson[] Units;
  [딧.떁(Name = "Actions")]
  public TacticsActionData[] Actions;
  [딧.떁(Name = "Chat")]
  public string chatLine;
}
