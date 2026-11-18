// Decompiled with JetBrains decompiler
// Type: UnitTurnDataJson
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;

[딧.딷]
[Serializable]
public sealed class UnitTurnDataJson
{
  [딧.떁(Name = "X")]
  public int TileX;
  [딧.떁(Name = "Y")]
  public int TileY;
  [딧.떁(Name = "AP")]
  public int ActionPoints;
  [딧.떁(Name = "HP")]
  public int Health;
  [딧.떁(Name = "T")]
  public int TeamIndex;
  [딧.떁(Name = "D")]
  public 딢.딯 Direction;
  [딧.떁(Name = "B")]
  public UnitBuff[] Buffs = new UnitBuff[0];
}
