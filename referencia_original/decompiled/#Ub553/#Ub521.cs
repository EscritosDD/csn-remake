// Decompiled with JetBrains decompiler
// Type: 땓.딡
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땓
{
  internal sealed class 딡
  {
    private FireTeamCatalogEntryAdvertData 딟;

    public 딡([In] FireTeamCatalogEntryAdvertData obj0)
    {
      this.딟 = obj0;
      // ISSUE: reference to a compiler-generated method
      this.딟(new 딖(obj0.ImageURL));
    }

    [SpecialName]
    public string 딟() => this.딟.Description;

    [SpecialName]
    public string 땄() => this.딟.SmallTitle;

    [SpecialName]
    public string 딧() => this.딟.Title;

    [CompilerGenerated]
    [SpecialName]
    public 딖 딢() => this.딟;
  }
}
