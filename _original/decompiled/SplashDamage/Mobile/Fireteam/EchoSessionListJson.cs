// Decompiled with JetBrains decompiler
// Type: SplashDamage.Mobile.Fireteam.EchoSessionListJson
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using 딧;

namespace SplashDamage.Mobile.Fireteam
{
  [딷]
  [Serializable]
  public sealed class EchoSessionListJson
  {
    [떁(Name = "user_name")]
    public string UserName;
    [떁(Name = "app_id")]
    public string AppId;
    [떁(Name = "user_sessions")]
    public EchoSessionJson[] Sessions;
  }
}
