// Decompiled with JetBrains decompiler
// Type: 땥.땲
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 땥
{
  internal class 땲
  {
    public 땋 딟;
    public bool 딟;
    public 땽 딟;
    public 땲 딟;
    public 땲 땄;
    public 땽 땄;
    public 딦 딟;
    public 땋 땄;
    public 땲 딧;
    public 땲 딢;

    public 땲([In] 땽 obj0, [In] 땽 obj1, [In] 땋 obj2, [In] 땋 obj3)
    {
      this.딟 = obj0;
      this.땄 = obj1;
      this.땄 = obj2;
      this.딟 = obj3;
      this.딧 = (땲) null;
      this.딢 = (땲) null;
      this.딟 = (땲) null;
      this.땄 = (땲) null;
      this.딟 = true;
      this.딟 = (딦) null;
    }

    public void 딟([In] 땲 obj0, [In] 땲 obj1)
    {
      this.딧 = obj0;
      if (obj0 != null)
        obj0.딢 = this;
      this.딟 = obj1;
      if (obj1 == null)
        return;
      obj1.땄 = this;
    }

    public void 땄([In] 땲 obj0, [In] 땲 obj1)
    {
      this.딢 = obj0;
      if (obj0 != null)
        obj0.딧 = this;
      this.땄 = obj1;
      if (obj1 == null)
        return;
      obj1.딟 = this;
    }

    public void 딟([In] 땲 obj0, [In] 땲 obj1, [In] 땲 obj2, [In] 땲 obj3)
    {
      this.딧 = obj0;
      if (obj0 != null)
        obj0.딢 = this;
      this.딟 = obj1;
      if (obj1 != null)
        obj1.땄 = this;
      this.딢 = obj2;
      if (obj2 != null)
        obj2.딧 = this;
      this.땄 = obj3;
      if (obj3 == null)
        return;
      obj3.딟 = this;
    }

    public void 딟()
    {
      if (!this.딟)
        return;
      this.딟 = false;
      if (this.딧 != null)
        this.딧.딟();
      if (this.딟 != null)
        this.딟.딟();
      if (this.딢 != null)
        this.딢.딟();
      if (this.땄 == null)
        return;
      this.땄.딟();
    }

    public bool 딟([In] 땽 obj0) => (double) obj0.딟 > (double) this.딟.딟 && (double) obj0.딟 < (double) this.땄.딟 && this.땄.딟(obj0) && this.딟.땄(obj0);

    public List<땽> 땄() => new List<땽>(4)
    {
      this.딟(this.땄, this.딟.딟),
      this.딟(this.딟, this.딟.딟),
      this.딟(this.딟, this.땄.딟),
      this.딟(this.땄, this.땄.딟)
    };

    private 땽 딟([In] 땋 obj0, [In] float obj1)
    {
      float num = obj0.땄 * obj1 + obj0.딟;
      return new 땽(obj1, num);
    }

    public void 딧()
    {
      if (this.딟 != this.딟.딟)
        this.딟.딧(this.딟);
      if (this.땄 != this.딟.땄)
        this.딟.딧(this.땄);
      if (this.딟 != this.땄.딟)
        this.땄.딧(this.딟);
      if (this.땄 == this.땄.땄)
        return;
      this.땄.딧(this.땄);
    }
  }
}
