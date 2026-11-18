// Decompiled with JetBrains decompiler
// Type: 땓.딖
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땓
{
  internal sealed class 딖
  {
    private FireTeamCatalogEntryURL 딟;

    public 딖([In] FireTeamCatalogEntryURL obj0)
    {
      this.딟 = obj0;
      if (this.딟 != null)
        return;
      this.딟 = new FireTeamCatalogEntryURL();
      this.딟.PNG = string.Empty;
      this.딟.PVR = string.Empty;
    }

    [SpecialName]
    public string 딟() => this.딟.PNG;

    [SpecialName]
    public bool 땄() => !string.IsNullOrEmpty(this.딟());
  }
}
