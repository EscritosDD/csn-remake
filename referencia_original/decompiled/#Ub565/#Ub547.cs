// Decompiled with JetBrains decompiler
// Type: 땥.땇
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땥
{
  public class 땇 : 땨
  {
    private List<땨> 딟;

    public 땇()
    {
    }

    public 땇([In] 땨 obj0)
      : base((IList<떁>) obj0)
    {
    }

    [SpecialName]
    public List<땨> 딟() => this.딟;

    [SpecialName]
    public void 딟([In] List<땨> obj0) => this.딟 = obj0;

    public void 딟([In] 딷 obj0)
    {
      for (int index = 0; index < this.Count; ++index)
        this[index] = 떁.딟(this[index], obj0);
      if (this.딟 == null || this.딟.Count <= 0)
        return;
      for (int index = 0; index < this.딟.Count; ++index)
      {
        떁[] array = this.딟[index].ToArray();
        떁.딟(array, ref obj0, array);
        this.딟[index] = new 땨(array);
      }
    }
  }
}
