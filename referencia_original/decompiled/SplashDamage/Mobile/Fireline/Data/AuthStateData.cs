// Decompiled with JetBrains decompiler
// Type: SplashDamage.Mobile.Fireline.Data.AuthStateData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using 딧;

namespace SplashDamage.Mobile.Fireline.Data
{
  [딷]
  [Serializable]
  public class AuthStateData
  {
    [떁(Name = "identity")]
    public string 딟 { get; [param: In] set; }

    [떁(Name = "client")]
    public string 땄 { get; [param: In] set; }

    [떁(Name = "domain")]
    public string 딧 { get; [param: In] set; }

    [떁(Name = "roles")]
    public string[] 딢 { get; [param: In] set; }

    [떁(Name = "remote_addr")]
    public string 땃 { get; [param: In] set; }
  }
}
