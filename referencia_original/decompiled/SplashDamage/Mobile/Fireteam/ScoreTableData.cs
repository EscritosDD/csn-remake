// Decompiled with JetBrains decompiler
// Type: SplashDamage.Mobile.Fireteam.ScoreTableData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using 딧;

namespace SplashDamage.Mobile.Fireteam
{
  [딷]
  [Serializable]
  public sealed class ScoreTableData
  {
    [떁(Name = "table_name")]
    public string TableName;
    [떁(Name = "users")]
    public Dictionary<string, Dictionary<string, ScoreTableEntryData>> Users;
  }
}
