// Decompiled with JetBrains decompiler
// Type: SplashDamage.Mobile.Fireteam.XboxXuidLink
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using 딧;

namespace SplashDamage.Mobile.Fireteam
{
  [딷]
  [Serializable]
  public sealed class XboxXuidLink
  {
    [떁(Name = "xuid")]
    public long XuidValue;
    [떁(Name = "pxuid")]
    public string Pxuid;

    public string 딟() => this.XuidValue.ToString("x").PadLeft(16, '0');
  }
}
