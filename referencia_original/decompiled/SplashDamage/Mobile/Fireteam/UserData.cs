// Decompiled with JetBrains decompiler
// Type: SplashDamage.Mobile.Fireteam.UserData
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
  public sealed class UserData
  {
    [떁(Name = "email_address")]
    public string Email;
    [떁(Name = "public_profile_data")]
    public Dictionary<string, object> PublicProfileData = new Dictionary<string, object>();
    [떁(Name = "user_id")]
    public string UserId;
    [떁(Name = "username")]
    public string UserName;
  }
}
