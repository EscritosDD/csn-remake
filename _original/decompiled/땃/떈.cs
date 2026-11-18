// Decompiled with JetBrains decompiler
// Type: 땃.떈
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땃
{
  public class 떈
  {
    public 떈([In] int obj0)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0);
      // ISSUE: reference to a compiler-generated method
      this.딟(new List<떌>());
      // ISSUE: reference to a compiler-generated method
      this.딟(new 떉());
    }

    [CompilerGenerated]
    [SpecialName]
    public List<떌> 딟() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public int 땄() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public int 딧() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public 떉 딢() => this.딟;

    public void 딟([In] 떌 obj0) => this.딟().Add(obj0);

    public bool 땃() => this.딟().Count == 0;

    public float 딶() => this.딢().딟 / (float) this.딧();

    public void 땄([In] 떉 obj0)
    {
      떈 떈 = this;
      // ISSUE: reference to a compiler-generated method
      떈.땄(떈.딧() + 1);
      this.딢().딟 += obj0.딟;
    }

    public List<떌> 땓()
    {
      List<떌> 떌List = new List<떌>();
      for (int index = 0; index < this.딟().Count; ++index)
      {
        if (this.딟()[index].딟.딧() == 0)
          떌List.Add(this.딟()[index]);
      }
      return 떌List;
    }
  }
}
