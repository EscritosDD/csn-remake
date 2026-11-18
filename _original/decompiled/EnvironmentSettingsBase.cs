// Decompiled with JetBrains decompiler
// Type: EnvironmentSettingsBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class EnvironmentSettingsBase : ScriptableObject
{
  public string MenuPath;
  public string ContentId;
  public List<string> WebPlayerDomains;
  public EnvironmentSettings_Fireteam Fireteam;
  public bool LogHTTPInfo;
  public bool AllowDebugInput;
  public bool UseSandboxPushChannel;
  public bool UseCDN;
  public bool Enabled;
  public bool AllowManifestFailure;
  public bool IsLive;
  public bool SplitAndroidBinaries;
  public int BundleVersionOffset;
  public 딟.떁 Platform;
  public ScriptableObject PlatformEnvironment;
  public BundleSettings BundleSettings;

  [SpecialName]
  public string 딟() => "manifest-" + this.ContentId + ".data";
}
