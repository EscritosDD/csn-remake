// Decompiled with JetBrains decompiler
// Type: 땓.딠
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땓
{
  internal sealed class 딠 : 땄.딜
  {
    private FireTeamCatalogEntryDescriptionData 딟;

    public 딠([In] FireTeamCatalogEntryDescriptionData obj0)
    {
      this.딟 = obj0;
      if (obj0.Advert == null)
        return;
      // ISSUE: reference to a compiler-generated method
      this.딟(new 딡(obj0.Advert));
    }

    [SpecialName]
    public string 딟() => this.딟.ChallengeType;

    [SpecialName]
    public string 땄() => this.딟.Name;

    [SpecialName]
    public string 딧() => this.딟.Character;

    [SpecialName]
    public string 딢() => this.딟.Description;

    [SpecialName]
    public string 땃() => this.딟.Free;

    [SpecialName]
    public string 딶() => this.딟.WeaponType;

    [SpecialName]
    public string[] 땓() => this.딟.Classes;

    [SpecialName]
    public string 땺() => this.딟.Weapon;

    [CompilerGenerated]
    [SpecialName]
    public 딡 땥() => this.딟;

    [SpecialName]
    public FireTeamCatalogEntryDescriptionAbilityData[] 딝() => this.딟.Abilities;
  }
}
