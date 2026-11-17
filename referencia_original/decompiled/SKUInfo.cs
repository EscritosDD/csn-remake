// Decompiled with JetBrains decompiler
// Type: SKUInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using UnityEngine;

public class SKUInfo : ScriptableObject
{
  public SKUInfo.EnvironmentSet[] EnvironmentSets;

  [Serializable]
  public class EnvironmentSet
  {
    public string Name;
    public EnvironmentSettingsBase[] Environments;
    public bool IsLive;
  }
}
