// Decompiled with JetBrains decompiler
// Type: 땺.땍
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땺
{
  public class 땍
  {
    protected List<땧> 딟 = new List<땧>();

    public 땍()
    {
    }

    public 땍([In] 땧 obj0) => this.딟.Add(obj0);

    [SpecialName]
    public IEnumerable<땧> 딟() => (IEnumerable<땧>) this.딟;

    public void 딟([In] 땧 obj0) => this.딟.Add(obj0);
  }
}
