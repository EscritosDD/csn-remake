// Decompiled with JetBrains decompiler
// Type: SplashDamage.Mobile.Analytics.GAEvent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using 딧;

namespace SplashDamage.Mobile.Analytics
{
  [딷]
  [Serializable]
  public sealed class GAEvent
  {
    [떁(Name = "category")]
    public string Category;
    [떁(Name = "action")]
    public string Action;
    [떁(Name = "label")]
    public string Label;
    [떁(Name = "value")]
    public double Value;
  }
}
