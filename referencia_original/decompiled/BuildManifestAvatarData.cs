// Decompiled with JetBrains decompiler
// Type: BuildManifestAvatarData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;

[딧.딷]
[Serializable]
public sealed class BuildManifestAvatarData
{
  [딟.딷("ProductId")]
  [딧.떁(Name = "id")]
  [딟.땢(AllowBlank = false, IsManifestUnique = true)]
  public string Id;
  [딧.떁(Name = "bundle")]
  public string Package;
  [딟.떏("Package")]
  [딧.떁(Name = "prefab")]
  public string AssetPath;
  [딟.땼(AllowBlank = true)]
  [딧.떁(Name = "productid")]
  public string ProductId;
}
