// Decompiled with JetBrains decompiler
// Type: EnvironmentSettings
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using 딟;

public class EnvironmentSettings : EnvironmentSettingsBase
{
  public EnvironmentSettings_Game GameSettings;
  public BuildManifestData BuildManifest;
  public NewsData NewsAsset;
  public FeaturedItemsData FeaturedItemsAsset;
  public SceneData ScenesAsset;

  [SpecialName]
  public 땻 딟() => new 땻(this.ContentId, this.BundleVersionOffset, this.UseCDN, true, true);
}
