// Decompiled with JetBrains decompiler
// Type: TacticsInitialTurnState
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;

[딧.딷]
[Serializable]
public sealed class TacticsInitialTurnState
{
  [딧.떁(Name = "Initial")]
  public string InitialData;
  [딧.떁(Name = "Turn")]
  public string TurnData;

  public TacticsInitialTurnState([In] string obj0, [In] string obj1)
  {
    this.InitialData = obj0;
    this.TurnData = obj1;
  }

  public TacticsInitialTurnState()
  {
  }
}
