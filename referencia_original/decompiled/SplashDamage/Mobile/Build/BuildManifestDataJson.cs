// Decompiled with JetBrains decompiler
// Type: SplashDamage.Mobile.Build.BuildManifestDataJson
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using 딧;

namespace SplashDamage.Mobile.Build
{
  [딷]
  [Serializable]
  public sealed class BuildManifestDataJson
  {
    [떁(Name = "Bundles")]
    public BuildManifestBundleData[] Bundles;
    [떁(Name = "url_cdn")]
    public string CDNUrl;
    [떁(Name = "output_bundle_manifests")]
    public bool OutputBundleManifests;
    [떁(Name = "version")]
    public int Version;
  }
}
