// Decompiled with JetBrains decompiler
// Type: TacticsSessionStateData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;

[딧.딷]
[Serializable]
public sealed class TacticsSessionStateData
{
  [딧.떁(Name = "DataVersion")]
  public int GameDataVersion;
  [딧.떁(Name = "LevelName")]
  public string LevelName;
  [딧.떁(Name = "Scenario")]
  public int ScenarioIndex;
  [딧.떁(Name = "Id")]
  public string Id;
  [딧.떁(Name = "SP")]
  public int SquadPointsTier;
  [딧.떁(Name = "Players")]
  public string[] Players;
  [딧.떁(Name = "LootDropTurn")]
  public int LootDropTurn;
}
