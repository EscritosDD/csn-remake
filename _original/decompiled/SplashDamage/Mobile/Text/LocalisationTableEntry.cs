// Decompiled with JetBrains decompiler
// Type: SplashDamage.Mobile.Text.LocalisationTableEntry
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace SplashDamage.Mobile.Text
{
  [Serializable]
  public class LocalisationTableEntry
  {
    [SerializeField]
    private string id = string.Empty;
    [SerializeField]
    private LocalisationEntry entry;

    [SpecialName]
    public string 딟() => this.id;

    [SpecialName]
    public LocalisationEntry 땄() => this.entry;
  }
}
