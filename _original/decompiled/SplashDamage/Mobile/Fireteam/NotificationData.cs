// Decompiled with JetBrains decompiler
// Type: SplashDamage.Mobile.Fireteam.NotificationData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;

namespace SplashDamage.Mobile.Fireteam
{
  [딧.딷]
  [Serializable]
  public sealed class NotificationData
  {
    [딧.떁(Name = "id")]
    public string Id;
    [딧.떁(Name = "receiver_id")]
    public string ReceiverId;
    [딧.떁(Name = "app_id")]
    public string AppId;
    [딧.떁(Name = "realm_level")]
    public bool IsRealmLevel;
    [딧.떁(Name = "deletion_policy")]
    public 딟.땅 DeletionPolicy;
    [딧.떁(Name = "read")]
    public bool Read;
    [딧.떁(Name = "cancelled")]
    public bool Cancelled;
    [딧.떁(Name = "expires")]
    public DateTime Expires;
    [딧.떁(Name = "sent_date")]
    public DateTime SentDate;
    [딧.떁(Name = "declaration")]
    public object[] Declaration;
  }
}
