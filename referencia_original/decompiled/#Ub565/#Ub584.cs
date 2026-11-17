// Decompiled with JetBrains decompiler
// Type: 땥.떄
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땥
{
  public abstract class 떄 : 딹
  {
    public 땺.땑 딟;
    public 떄.떌 딟;
    protected Random 딟;
    public 땺.땑 땄;

    public 떄()
      : base(떐.딧)
    {
      base.딟 = true;
      this.땄(1f);
      this.딟(new 떁(0.0f, 0.0f));
      this.딧(100f);
      this.딟(떄.땛.딟);
      // ISSUE: reference to a compiler-generated method
      this.땃(0.0f);
      this.딶(1f);
      // ISSUE: reference to a compiler-generated method
      this.딟(false);
      this.땄 = new 땺.땑();
      this.땓(0.0f);
      this.딟 = new Random(1234);
      this.딟(떄.떉.딟);
      this.딟 = new 땺.땑();
      this.땺(0.0f);
      this.땥(0.0f);
      this.땄.땄().Add(new 땺.딲(0.0f, 5f));
      this.땄.땄().Add(new 땺.딲(0.1f, 5f));
      this.땄.땄().Add(new 땺.딲(0.2f, -4f));
      this.땄.땄().Add(new 땺.딲(1f, 0.0f));
    }

    public 떄([In] 떄.땛 obj0)
      : base(떐.딧)
    {
      this.딟(obj0);
      switch (obj0)
      {
        case 떄.땛.딟:
          base.딟 = true;
          break;
        case 떄.땛.땄:
          base.딟 = false;
          break;
        case 떄.땛.딧:
          base.딟 = false;
          break;
      }
    }

    [CompilerGenerated]
    [SpecialName]
    public float 딟() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 땄([In] float obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public 떁 땄() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] 떁 obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public float 딧() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public void 딧([In] float obj0) => this.땄 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public float 딢() => this.딧;

    [CompilerGenerated]
    [SpecialName]
    public void 딢([In] float obj0) => this.딧 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public 떄.땛 땃() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] 떄.땛 obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public float 딶() => this.딢;

    [CompilerGenerated]
    [SpecialName]
    public float 땓() => this.땃;

    [CompilerGenerated]
    [SpecialName]
    public void 딶([In] float obj0) => this.땃 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public bool 땺() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public float 땥() => this.딶;

    [CompilerGenerated]
    [SpecialName]
    public void 땓([In] float obj0) => this.딶 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public 떄.떉 딝() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] 떄.떉 obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public float 떎() => this.땓;

    [CompilerGenerated]
    [SpecialName]
    public void 땺([In] float obj0) => this.땓 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public float 떂() => this.땺;

    [CompilerGenerated]
    [SpecialName]
    public void 땥([In] float obj0) => this.땺 = obj0;

    protected float 땄([In] 딺 obj0)
    {
      float num = (obj0.땼() - this.땄()).땃();
      switch (this.딝())
      {
        case 떄.떉.딟:
          return 1f;
        case 떄.떉.땄:
          return (double) num < (double) this.떂() ? 1f : 0.0f;
        case 떄.떉.딧:
          if ((double) num < (double) this.떎())
            return 1f;
          return (double) num > (double) this.떂() ? 0.0f : this.떂() - this.떎() / num - this.떎();
        case 떄.떉.딢:
          return (double) num < (double) this.떎() ? 1f : (float) (1.0 / (((double) num - (double) this.떎()) * ((double) num - (double) this.떎())));
        case 떄.떉.땃:
          return (double) num < (double) this.떎() ? 1f : this.딟.딟(num - this.떎());
        default:
          return 1f;
      }
    }

    public void 땭()
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(true);
      // ISSUE: reference to a compiler-generated method
      this.땃(0.0f);
    }

    public override void 딟([In] float obj0)
    {
      switch (this.땃())
      {
        case 떄.땛.딟:
          if (!base.딟)
            break;
          this.딟(obj0, this.딟());
          break;
        case 떄.땛.땄:
          if (!base.딟 || !this.땺())
            break;
          if ((double) this.딶() < (double) this.땓())
          {
            this.딟(obj0, this.딟());
            떄 떄 = this;
            // ISSUE: reference to a compiler-generated method
            떄.땃(떄.딶() + obj0);
            break;
          }
          // ISSUE: reference to a compiler-generated method
          this.딟(false);
          break;
        case 떄.땛.딧:
          if (!base.딟 || !this.땺())
            break;
          if ((double) this.딶() < (double) this.땓())
          {
            this.딟(obj0, this.딟() * this.땄.딟(this.딶()));
            떄 떄 = this;
            // ISSUE: reference to a compiler-generated method
            떄.땃(떄.딶() + obj0);
            break;
          }
          // ISSUE: reference to a compiler-generated method
          this.딟(false);
          break;
      }
    }

    public abstract void 딟([In] float obj0, [In] float obj1);

    public enum 떉
    {
      딟,
      땄,
      딧,
      딢,
      땃,
    }

    public enum 떌
    {
      딟,
      땄,
      딧,
    }

    public enum 땛
    {
      딟,
      땄,
      딧,
    }
  }
}
