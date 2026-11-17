// Decompiled with JetBrains decompiler
// Type: SinglePlayerMissionScore
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;

[딧.딷]
[Serializable]
public sealed class SinglePlayerMissionScore
{
  [딧.떁(Name = "Id")]
  public int MissionIdHash;
  [딧.떁(Name = "S")]
  public int BestScore;
  [딧.떁(Name = "Level")]
  public int BestLevel;

  public SinglePlayerMissionScore([In] int obj0, [In] int obj1, [In] int obj2)
  {
    this.MissionIdHash = obj0;
    this.BestScore = obj1;
    this.BestLevel = obj2;
  }

  public SinglePlayerMissionScore()
  {
  }
}
