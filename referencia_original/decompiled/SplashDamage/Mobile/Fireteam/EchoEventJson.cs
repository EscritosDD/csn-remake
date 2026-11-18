// Decompiled with JetBrains decompiler
// Type: SplashDamage.Mobile.Fireteam.EchoEventJson
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
  public sealed class EchoEventJson
  {
    [떁(Name = "type")]
    public string Type;
    [떁(Name = "users")]
    public string[] Users;
    [떁(Name = "event_id")]
    public string EventId;
    [떁(Name = "timestamp")]
    public long Timestamp;
    [떁(Name = "session_id")]
    public string SessionId;
    [떁(Name = "time")]
    public long Time;
    [떁(Name = "data")]
    public Dictionary<string, object> Data;
  }
}
