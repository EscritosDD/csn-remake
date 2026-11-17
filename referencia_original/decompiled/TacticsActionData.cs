// Decompiled with JetBrains decompiler
// Type: TacticsActionData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;

[딧.딷]
[Serializable]
public sealed class TacticsActionData
{
  [딧.떁(Name = "Idx")]
  public int Index;
  [딧.떁(DefaultValue = 0, Name = "X")]
  public int TileIndexX;
  [딧.떁(DefaultValue = 0, Name = "Y")]
  public int TileIndexY;
  [딧.떁(DefaultValue = 딢.땀.딟, Name = "Act")]
  public 딢.땀 Action;
  [딧.떁(DefaultValue = 딢.딯.딟, Name = "D")]
  public 딢.딯 Direction;
  [딧.떁(DefaultValue = 딢.딴.딟, Name = "Abi")]
  public 딢.딴 Ability;
  [딧.떁(DefaultValue = 0, Name = "Tgt")]
  public int TargetIndex;
  [딧.떁(DefaultValue = 0, Name = "Atk")]
  public int AttackerIndex;
}
