// Decompiled with JetBrains decompiler
// Type: 땺.딬
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땺
{
  public class 딬 : 땸
  {
    private List<땮> 딟;

    public 딬([In] List<땮> obj0, [In] int[] obj1)
      : base(obj0)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj1);
    }

    public 딬([In] List<땮> obj0, [In] IEnumerable<땮> obj1)
      : base(obj0)
    {
      this.딟 = new List<땮>();
      this.딟.AddRange(obj1);
    }

    [CompilerGenerated]
    [SpecialName]
    public int[] 땃() => this.딟;

    [SpecialName]
    public override 떒 딧() => 떒.땄;

    public override void 딟([In] 떊 obj0)
    {
      base.딟(obj0);
      if (this.딟 != null)
      {
        List<땮>.Enumerator enumerator = this.딟.GetEnumerator();
        while (enumerator.MoveNext())
        {
          땮 current1 = enumerator.Current;
          enumerator.MoveNext();
          땮 current2 = enumerator.Current;
          obj0.딟(current1, current2);
        }
      }
      else
      {
        for (int index = 0; index < this.땃().Length; index += 2)
          obj0.딟(this.딟()[this.땃()[index]], this.딟()[this.땃()[index + 1]]);
      }
    }

    public bool 딶() => true;
  }
}
