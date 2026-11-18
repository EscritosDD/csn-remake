// Decompiled with JetBrains decompiler
// Type: BuildManifestOutfitData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;

[딧.딷]
[Serializable]
public sealed class BuildManifestOutfitData
{
  [딟.땢(AllowBlank = false, IsManifestUnique = true)]
  [딧.떁(Name = "id")]
  [딟.딷("ProductId")]
  public string Id;
  [딧.떁(Name = "bundle")]
  public string Package;
  [딟.땢(AllowBlank = false, LinkType = typeof (BuildManifestCharacterData))]
  [딧.떁(Name = "ownerid")]
  public string OwnerId;
  [딧.떁(Name = "prefab")]
  [딟.떏("Package")]
  public string AssetPath;
  [딧.떁(Name = "productid")]
  [딟.땼(AllowBlank = true)]
  public string ProductId;
  [딧.떁(Name = "showifowned")]
  public bool OnlyShowIfOwned;
  [딧.떁(Name = "levelreq")]
  public int LevelRequired;
}
