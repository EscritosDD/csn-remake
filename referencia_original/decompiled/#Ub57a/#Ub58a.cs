// Decompiled with JetBrains decompiler
// Type: 땺.떊
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땺
{
  public abstract class 떊
  {
    public readonly List<땮> 딟 = new List<땮>(200);
    public readonly List<딽> 딟 = new List<딽>();

    public 떊() => this.땄(false);

    [CompilerGenerated]
    [SpecialName]
    public 떒 땄() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    protected void 딟([In] 떒 obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public 땫 딧() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public bool 딢() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public bool 땃() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public void 땄([In] bool obj0) => this.땄 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public int 딶() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public virtual bool 땓() => this.딧;

    [CompilerGenerated]
    [SpecialName]
    protected virtual void 딧([In] bool obj0) => this.딧 = obj0;

    public void 땺()
    {
      떊 떊 = this;
      // ISSUE: reference to a compiler-generated method
      떊.딟(떊.딶() + 1);
    }

    public virtual void 딟([In] 땫 obj0)
    {
      // ISSUE: reference to a compiler-generated method
      this.땄(obj0);
      this.딟(obj0.딧());
      obj0.딟(this);
    }

    public abstract 땬 딟([In] 땮 obj0, [In] 땮 obj1);

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 딟([In] string obj0)
    {
    }

    public virtual void 딟()
    {
      this.딟.Clear();
      this.땄(false);
      // ISSUE: reference to a compiler-generated method
      this.딟(0);
    }
  }
}
