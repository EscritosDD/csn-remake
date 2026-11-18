// Decompiled with JetBrains decompiler
// Type: SplashDamage.Mobile.Analytics.MixPanelEventData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using 딧;

namespace SplashDamage.Mobile.Analytics
{
  [딷]
  [Serializable]
  internal sealed class MixPanelEventData
  {
    [떁(Name = "event")]
    public string Event;
    [떁(Name = "properties")]
    public Dictionary<string, string> Properties;
  }
}
