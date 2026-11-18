// Decompiled with JetBrains decompiler
// Type: UnitBuff
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;

[딧.딷]
[Serializable]
public sealed class UnitBuff
{
  [딧.떁(Name = "N")]
  public int Turns;
  [딧.떁(Name = "T")]
  public 딢.떍 Type;

  public UnitBuff([In] 딢.떍 obj0, [In] int obj1)
  {
    this.Type = obj0;
    this.Turns = obj1;
  }

  public UnitBuff()
  {
  }
}
