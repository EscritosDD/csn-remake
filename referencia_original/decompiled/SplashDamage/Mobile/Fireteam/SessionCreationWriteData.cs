// Decompiled with JetBrains decompiler
// Type: SplashDamage.Mobile.Fireteam.SessionCreationWriteData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

namespace SplashDamage.Mobile.Fireteam
{
  [딧.딷]
  [Serializable]
  public sealed class SessionCreationWriteData
  {
    [딧.떁(Name = "public_slots")]
    public int PublicSlots;
    [딧.떁(Name = "private_slots")]
    public int PrivateSlots;
    [딧.떁(Name = "join_slot_type")]
    public 딟.땎 JoinSlotType;
    [딧.떁(Name = "attributes")]
    public object Attributes;
    [딧.떁(Name = "nonce")]
    public string Nonce;
    [딧.떁(Name = "turn_data")]
    public string TurnData;
    [딧.떁(Name = "turn_inventory")]
    public Dictionary<string, int> TurnInventory;
    [딧.떁(Name = "invitees")]
    public string[] Invitees;
  }
}
