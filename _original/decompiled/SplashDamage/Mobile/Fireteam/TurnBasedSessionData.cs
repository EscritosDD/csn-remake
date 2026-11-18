// Decompiled with JetBrains decompiler
// Type: SplashDamage.Mobile.Fireteam.TurnBasedSessionData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

namespace SplashDamage.Mobile.Fireteam
{
  [딧.딷]
  [Serializable]
  public sealed class TurnBasedSessionData
  {
    [딧.떁(Name = "attributes")]
    public Dictionary<string, object> Attributes;
    [딧.떁(Name = "current_user_id")]
    public string CurrentUserId;
    [딧.떁(Name = "expires_at")]
    public DateTime ExpiresAtTime;
    [딧.떁(Name = "filled_private_slots")]
    public int FilledPrivateSlots;
    [딧.떁(Name = "filled_public_slots")]
    public int FilledPublicSlots;
    [딧.떁(Name = "id")]
    public string Id;
    [딧.떁(Name = "num_turns")]
    public int NumTurns;
    [딧.떁(Name = "outcomes")]
    public Dictionary<string, 딟.땾> Outcomes;
    [딧.떁(Name = "private_slots")]
    public int PrivateSlots;
    [딧.떁(Name = "public_slots")]
    public int PublicSlots;
    [딧.떁(Name = "session_type")]
    public int SessionType;
    [딧.떁(Name = "state")]
    public 딟.딺 State;
    [딧.떁(Name = "updated_at")]
    public DateTime UpdatedAtTime;
    [딧.떁(Name = "users")]
    public SessionUserData[] Users;
  }
}
