// Decompiled with JetBrains decompiler
// Type: 땓.딞
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땓
{
  internal sealed class 딞 : 땄.딻
  {
    private FireTeamCatalogEntryData 딟;

    public 딞([In] FireTeamCatalogEntryData obj0)
    {
      this.딟 = obj0;
      // ISSUE: reference to a compiler-generated method
      this.딟(new 딖(obj0.IconUrl));
      // ISSUE: reference to a compiler-generated method
      this.땄(new 딖(obj0.PreviewUrl));
    }

    [SpecialName]
    public string 딟() => this.딟.Range;

    [SpecialName]
    public string 땄() => this.딟.Special;

    [SpecialName]
    public string 딧() => this.딟.Damage;

    [SpecialName]
    public string 딢() => this.딟.APCost;

    [SpecialName]
    public string 땃() => this.딟.Class;

    [SpecialName]
    public int 딶() => this.딟.LevelRequired;

    [SpecialName]
    public int 땓() => this.딟.Sort;

    [SpecialName]
    public int 땺() => this.딟.Version;

    [SpecialName]
    public bool 땥() => this.딟.Hide;

    [SpecialName]
    public bool 딝() => this.딟.IsNew;

    [SpecialName]
    public string 떎() => this.딟.SquadPoints;

    [SpecialName]
    public string 떂() => this.딟.ActionPoints;

    [SpecialName]
    public string 땭() => this.딟.Health;

    [CompilerGenerated]
    [SpecialName]
    public 딖 딦() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public 딖 땤() => this.땄;
  }
}
