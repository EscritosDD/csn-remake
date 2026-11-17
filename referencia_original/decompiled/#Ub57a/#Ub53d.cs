// Decompiled with JetBrains decompiler
// Type: 땺.딽
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땺
{
  public class 딽
  {
    public 땥.딧 딟;
    public 땥.딧 땄;
    public 땥.땄<딽> 딟;
    public 땥.땄<땮> 딟;

    public 딽([In] 땮 obj0, [In] 땮 obj1, [In] 땮 obj2)
    {
      this.딟.딟(0, obj0);
      this.딟.딟(1, obj1);
      this.딟.딟(2, obj2);
    }

    [CompilerGenerated]
    [SpecialName]
    public bool 딟() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] bool obj0) => this.딟 = obj0;

    public int 딟([In] 땮 obj0)
    {
      int num = this.딟.땄(obj0);
      return num != -1 ? num : throw new Exception("Calling index with a point that doesn't exist in triangle");
    }

    public int 땄([In] 땮 obj0)
    {
      switch (this.딟(obj0))
      {
        case 0:
          return 2;
        case 1:
          return 0;
        default:
          return 1;
      }
    }

    public int 딧([In] 땮 obj0)
    {
      switch (this.딟(obj0))
      {
        case 0:
          return 1;
        case 1:
          return 2;
        default:
          return 0;
      }
    }

    public bool 딢([In] 땮 obj0) => obj0 == this.딟.딟(0) || obj0 == this.딟.딟(1) || obj0 == this.딟.딟(2);

    public bool 딟([In] 딭 obj0) => this.딢(obj0.딟) && this.딢(obj0.땄);

    public bool 딟([In] 땮 obj0, [In] 땮 obj1) => this.딢(obj0) && this.딢(obj1);

    private void 딟([In] 땮 obj0, [In] 땮 obj1, [In] 딽 obj2)
    {
      if (obj0 == this.딟.딟(2) && obj1 == this.딟.딟(1) || obj0 == this.딟.딟(1) && obj1 == this.딟.딟(2))
        this.딟.딟(0, obj2);
      else if (obj0 == this.딟.딟(0) && obj1 == this.딟.딟(2) || obj0 == this.딟.딟(2) && obj1 == this.딟.딟(0))
      {
        this.딟.딟(1, obj2);
      }
      else
      {
        if ((obj0 != this.딟.딟(0) || obj1 != this.딟.딟(1)) && (obj0 != this.딟.딟(1) || obj1 != this.딟.딟(0)))
          return;
        this.딟.딟(2, obj2);
      }
    }

    public void 딟([In] 딽 obj0)
    {
      if (obj0.딟(this.딟.딟(1), this.딟.딟(2)))
      {
        this.딟.딟(0, obj0);
        obj0.딟(this.딟.딟(1), this.딟.딟(2), this);
      }
      else if (obj0.딟(this.딟.딟(0), this.딟.딟(2)))
      {
        this.딟.딟(1, obj0);
        obj0.딟(this.딟.딟(0), this.딟.딟(2), this);
      }
      else
      {
        if (!obj0.딟(this.딟.딟(0), this.딟.딟(1)))
          return;
        this.딟.딟(2, obj0);
        obj0.딟(this.딟.딟(0), this.딟.딟(1), this);
      }
    }

    public void 땄()
    {
      ref 땥.땄<딽> local = ref this.딟;
      딽 딽1 = (딽) null;
      this.딟.딟(2, 딽1);
      딽 딽2 = 딽1;
      this.딟.딟(1, 딽2);
      딽 딽3 = 딽2;
      local.딟(0, 딽3);
    }

    public void 땄([In] 딽 obj0)
    {
      if (this.딟.딟(0) == obj0)
        this.딟.딟(0, (딽) null);
      else if (this.딟.딟(1) == obj0)
        this.딟.딟(1, (딽) null);
      else
        this.딟.딟(2, (딽) null);
    }

    public void 딧()
    {
      for (int index = 0; index < 3; ++index)
        this.딟.딟(index)?.땄(this);
      this.땄();
      ref 땥.땄<땮> local = ref this.딟;
      땮 땮1 = (땮) null;
      this.딟.딟(2, 땮1);
      땮 땮2 = 땮1;
      this.딟.딟(1, 땮2);
      땮 땮3 = 땮2;
      local.딟(0, 땮3);
    }

    public 땮 딟([In] 딽 obj0, [In] 땮 obj1) => this.땥(obj0.땥(obj1));

    public 딽 땃([In] 땮 obj0) => this.딟.딟((this.딟.땄(obj0) + 1) % 3);

    public 딽 딶([In] 땮 obj0) => this.딟.딟((this.딟.땄(obj0) + 2) % 3);

    public 딽 땓([In] 땮 obj0) => this.딟.딟(this.딟.땄(obj0));

    public 땮 땺([In] 땮 obj0) => this.딟.딟((this.딟(obj0) + 1) % 3);

    public 땮 땥([In] 땮 obj0) => this.딟.딟((this.딟(obj0) + 2) % 3);

    private void 딢()
    {
      땮 땮 = this.딟.딟(2);
      this.딟.딟(2, this.딟.딟(1));
      this.딟.딟(1, this.딟.딟(0));
      this.딟.딟(0, 땮);
    }

    public void 땄([In] 땮 obj0, [In] 땮 obj1)
    {
      this.딢();
      this.딟.딟(this.딧(obj0), obj1);
    }

    public override string ToString() => this.딟.딟(0).ToString() + "," + (object) this.딟.딟(1) + "," + (object) this.딟.딟(2);

    public void 땃()
    {
      for (int index = 0; index < 3; ++index)
      {
        if (this.딟.딟(index) && this.딟.딟(index) != null)
          this.딟.딟(index).딧(this.딟.딟((index + 1) % 3), this.딟.딟((index + 2) % 3));
      }
    }

    public void 딧([In] 딽 obj0)
    {
      for (int index = 0; index < 3; ++index)
      {
        if (this.딟.딟(index))
          obj0.딧(this.딟.딟((index + 1) % 3), this.딟.딟((index + 2) % 3));
      }
    }

    public void 딟([In] List<딽> obj0)
    {
      foreach (딽 딽 in obj0)
      {
        for (int index = 0; index < 3; ++index)
        {
          if (딽.딟.딟(index))
            this.딧(딽.딟.딟((index + 1) % 3), 딽.딟.딟((index + 2) % 3));
        }
      }
    }

    public void 딟([In] int obj0) => this.딟.딟(obj0, true);

    public void 땄([In] 딭 obj0) => this.딧(obj0.딟, obj0.땄);

    public void 딧([In] 땮 obj0, [In] 땮 obj1)
    {
      int num = this.딢(obj0, obj1);
      if (num == -1)
        return;
      this.딟.딟(num, true);
    }

    public double 딶() => Math.Abs((this.딟.딟(0).딟 - this.딟.딟(1).딟) * (this.딟.딟(2).땄 - this.딟.딟(1).땄) * 0.5);

    public 땮 땓() => new 땮((this.딟.딟(0).딟 + this.딟.딟(1).딟 + this.딟.딟(2).딟) / 3.0, (this.딟.딟(0).땄 + this.딟.딟(1).땄 + this.딟.딟(2).땄) / 3.0);

    public int 딢([In] 땮 obj0, [In] 땮 obj1)
    {
      int num1 = this.딟.땄(obj0);
      int num2 = this.딟.땄(obj1);
      bool flag1 = num1 == 0 || num2 == 0;
      bool flag2 = num1 == 1 || num2 == 1;
      bool flag3 = num1 == 2 || num2 == 2;
      if (flag2 && flag3)
        return 0;
      if (flag1 && flag3)
        return 1;
      return flag1 && flag2 ? 2 : -1;
    }

    public bool 딝([In] 땮 obj0) => this.딟.딟((this.딟(obj0) + 2) % 3);

    public bool 떎([In] 땮 obj0) => this.딟.딟((this.딟(obj0) + 1) % 3);

    public bool 떂([In] 땮 obj0) => this.딟.딟(this.딟(obj0));

    public void 딟([In] 땮 obj0, [In] bool obj1) => this.딟.딟((this.딟(obj0) + 2) % 3, obj1);

    public void 땄([In] 땮 obj0, [In] bool obj1) => this.딟.딟((this.딟(obj0) + 1) % 3, obj1);

    public void 딧([In] 땮 obj0, [In] bool obj1) => this.딟.딟(this.딟(obj0), obj1);

    public bool 땭([In] 땮 obj0) => this.땄.딟((this.딟(obj0) + 2) % 3);

    public bool 딦([In] 땮 obj0) => this.땄.딟((this.딟(obj0) + 1) % 3);

    public bool 땤([In] 땮 obj0) => this.땄.딟(this.딟(obj0));

    public void 딢([In] 땮 obj0, [In] bool obj1) => this.땄.딟((this.딟(obj0) + 2) % 3, obj1);

    public void 땃([In] 땮 obj0, [In] bool obj1) => this.땄.딟((this.딟(obj0) + 1) % 3, obj1);

    public void 딶([In] 땮 obj0, [In] bool obj1) => this.땄.딟(this.딟(obj0), obj1);
  }
}
