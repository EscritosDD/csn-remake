// Decompiled with JetBrains decompiler
// Type: BuildManifestLevelData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;

[딧.딷]
[Serializable]
public sealed class BuildManifestLevelData
{
  [딟.땢(AllowBlank = false, IsManifestUnique = true)]
  [딟.딷("ProductId")]
  [딧.떁(Name = "id")]
  public string Id;
  [딧.떁(Name = "bundle")]
  public string GameplayPackage;
  [딧.떁(Name = "gameplay")]
  [딟.떏("GameplayPackage")]
  public string GameplayPrefabPath;
  [딧.떁(Name = "prettynamepackage")]
  public string PrettyNamePackage;
  [딧.떁(Name = "prettynameprefab")]
  [딟.떏("PrettyNamePackage")]
  public string PrettyNamePrefabPath;
  [딧.떁(Name = "ingamepackage")]
  public string InGamePackage;
  [딟.떏("InGamePackage")]
  [딧.떁(Name = "lighting")]
  public string LightingPrefabPath;
  [딧.떁(Name = "audio")]
  [딟.떏("InGamePackage")]
  public string AudioPrefabPath;
  [딟.떏("InGamePackage")]
  [딧.떁(Name = "geometry")]
  public string GeometryPrefabPath;
  [딟.떏("InGamePackage")]
  [딧.떁(Name = "vfx")]
  public string VFXPrefabPath;
  [딧.떁(Name = "oob")]
  [딟.떏("InGamePackage")]
  public string OOBPrefabPath;
  [딧.떁(Name = "clip")]
  [딟.떏("InGamePackage")]
  public string ClipPrefabPath;
  [딧.떁(Name = "covermap")]
  [딟.떏("InGamePackage")]
  public string CoverMapPrefabPath;
  [딧.떁(Name = "vismap")]
  [딟.떏("InGamePackage")]
  public string VisMapPrefabPath;
  [딟.떏("InGamePackage")]
  [딧.떁(Name = "lightmaps")]
  public string[] Lightmaps;
  [딧.떁(Name = "iconpackage")]
  public string IconPackage;
  [딟.떏("IconPackage")]
  [딧.떁(Name = "mapselecticon")]
  public string IconPrefabPath;
  [딟.땢(AllowBlank = true, LinkType = typeof (BuildManifestPrefabData))]
  [딧.떁(Name = "sharedaudio")]
  public string SharedAudioPrefabId;
  [딧.떁(Name = "productid")]
  [딟.땼(AllowBlank = true)]
  public string ProductId;
  [딧.떁(Name = "atlaspackid")]
  [딟.땢(AllowBlank = false, LinkType = typeof (BuildManifestAtlasPackData))]
  public string AtlasPackId;
  [딧.떁(Name = "singleplayeronly")]
  public bool SinglePlayerOnly;
}
