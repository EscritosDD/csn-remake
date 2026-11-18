// Decompiled with JetBrains decompiler
// Type: SinglePlayerMissionUnit
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;

[Serializable]
public class SinglePlayerMissionUnit
{
  [딟.땢(AllowBlank = false, LinkType = typeof (BuildManifestCharacterData))]
  public string CharacterId;
  [딟.땢(AllowBlank = false, LinkType = typeof (BuildManifestWeaponData))]
  public string WeaponId;
  [딟.땢(AllowBlank = false, LinkType = typeof (BuildManifestOutfitData))]
  public string OutfitId;
  public string Name;
  public 딢.딴[] CommanderAbilities;
}
