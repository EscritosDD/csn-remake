// Decompiled with JetBrains decompiler
// Type: BuildManifestCharacterData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;

[딧.딷]
[Serializable]
public sealed class BuildManifestCharacterData
{
  [딟.땢(AllowBlank = false, IsManifestUnique = true)]
  [딟.딷("ProductId")]
  [딧.떁(Name = "id")]
  public string Id;
  [딧.떁(Name = "bundle")]
  public string Package;
  [딧.떁(Name = "prefab")]
  [딟.떏("Package")]
  public string AssetPath;
  [딟.땼(AllowBlank = true)]
  [딧.떁(Name = "productid")]
  public string ProductId;
  [딟.땼(AllowBlank = true, AllowEdit = true)]
  [딧.떁(Name = "bundleproductid")]
  public string BundleProductId;
  [딟.땢(AllowBlank = false, LinkType = typeof (BuildManifestWeaponData))]
  [딧.떁(Name = "defaultweapon")]
  public string DefaultWeaponId;
  [딧.떁(Name = "defaultvoicepack")]
  [딟.땢(AllowBlank = false, LinkType = typeof (BuildManifestVoicePackData))]
  public string VoicePackId;
  [딧.떁(Name = "fallbackvoicepack")]
  [딟.땢(AllowBlank = false, LinkType = typeof (BuildManifestVoicePackData))]
  public string FallbackVoicePackId;
  [딧.떁(Name = "levelreq")]
  public int LevelRequired;
  [딧.떁(Name = "defaultoutfit")]
  [딟.땢(AllowBlank = false, LinkType = typeof (BuildManifestOutfitData))]
  public string DefaultOutfitId;
  [딧.떁(Name = "advertise")]
  public bool Advertise;
  [딧.떁(Name = "tryoutmissionid")]
  public string TryoutMissionId;
}
