// Decompiled with JetBrains decompiler
// Type: SplashDamage.Mobile.Fireteam.TurnBasedSessionTurnData
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
  public sealed class TurnBasedSessionTurnData
  {
    [떁(Name = "created_at")]
    public DateTime CompletionTime;
    [떁(Name = "data")]
    public string Data;
    [떁(Name = "expire_ops")]
    public object[][] ExpireOps;
    [떁(Name = "index")]
    public int Index;
    [떁(Name = "inventory")]
    public Dictionary<string, int> Inventory;
    [떁(Name = "next_user_id")]
    public string NextUserId;
    [떁(Name = "ops")]
    public object[][] Ops;
    [떁(Name = "user_id")]
    public string UserId;
  }
}
