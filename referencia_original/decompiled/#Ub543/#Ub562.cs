// Decompiled with JetBrains decompiler
// Type: 땃.땢
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땃
{
  public class 땢
  {
    private 딷 딟;
    private 땄.땐 딟;
    private 땄.딺 딟;

    public 땢([In] string obj0)
    {
      this.딟 = GlobalAppData.떏().땠(obj0);
      this.딟 = GlobalAppData.떏().땴(obj0);
    }

    [SpecialName]
    public bool 딟() => this.딟.땄() && this.딟.땄();

    [SpecialName]
    public bool 땄() => this.딟.딧() && this.딟.딧();

    [SpecialName]
    public bool 딧() => this.딟.딟() || this.딟.딟();

    [SpecialName]
    public 딟.땑 딢()
    {
      if (!this.딟.딧())
        return ((땄.땘) this.딟).딟;
      return !this.딟.딧() ? ((땄.땘) this.딟).딟 : 딟.땑.딟;
    }

    [SpecialName]
    public 딷 땃()
    {
      if (this.딟 == null)
        this.딟 = new 딷(this.딟.딟, this.딟.딟);
      return this.딟;
    }
  }
}
