// Decompiled with JetBrains decompiler
// Type: SplashDamage.Mobile.Fireteam.WriteSessionTurnData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

namespace SplashDamage.Mobile.Fireteam
{
  [딧.딷]
  [Serializable]
  public sealed class WriteSessionTurnData
  {
    [딧.떁(Name = "next_user_id")]
    public string NextUserId;
    [딧.떁(Name = "data")]
    public string Data;
    [딧.떁(DefaultValue = null, Name = "ops")]
    public object[][] Ops;
    [딧.떁(DefaultValue = null, Name = "inventory")]
    public Dictionary<string, int> Inventory;
    [딧.떁(DefaultValue = 딟.땎.딟, Name = "join_slot_type")]
    public 딟.땎 JoinSlotType;
    [딧.떁(DefaultValue = null, Name = "outcomes")]
    public Dictionary<string, 딟.땾> Outcomes;
    [딧.떁(DefaultValue = 딟.딺.땄, Name = "state")]
    public 딟.딺 State;
    [딧.떁(DefaultValue = null, Name = "expire_ops")]
    public object[][] ExpireOps;
  }
}
