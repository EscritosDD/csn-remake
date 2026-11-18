// Decompiled with JetBrains decompiler
// Type: SplashDamage.Mobile.Text.LocalisationTable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace SplashDamage.Mobile.Text
{
  public class LocalisationTable : ScriptableObject
  {
    [SerializeField]
    private LocalisationTableEntry[] entries;
    private Dictionary<string, LocalisationEntry> 딟;

    [SpecialName]
    public LocalisationTableEntry[] 딟() => this.entries;

    public Dictionary<string, string> 딟([In] string obj0) => this.딟((IEnumerable<string>) new string[1]
    {
      obj0
    });

    public Dictionary<string, string> 딟([In] IEnumerable<string> obj0_1)
    {
      this.땄();
      return obj0_1.Distinct<string>().ToDictionary<string, string, string>((Func<string, string>) (obj0_2 => obj0_2), (Func<string, string>) (obj0_3 => this.땄(obj0_3)));
    }

    private string 땄([In] string obj0)
    {
      LocalisationEntry localisationEntry;
      return this.딟.TryGetValue(obj0, out localisationEntry) ? 딧.딪.딟(localisationEntry) : string.Format("<{0}>", (object) obj0);
    }

    private void 땄()
    {
      if (!Application.isEditor && this.딟 != null)
        return;
      this.딟 = ((IEnumerable<LocalisationTableEntry>) this.entries).ToDictionary<LocalisationTableEntry, string, LocalisationEntry>((Func<LocalisationTableEntry, string>) (obj0 => obj0.딟()), (Func<LocalisationTableEntry, LocalisationEntry>) (obj0 => obj0.땄()));
    }
  }
}
