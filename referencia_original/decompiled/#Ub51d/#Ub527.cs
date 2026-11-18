// Decompiled with JetBrains decompiler
// Type: 딝.딧
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using 땥;

namespace 딝
{
  public class 딧 : 딝.땺
  {
    private 떁 딟;
    private 떁 땄;
    private new float 딟;
    private float 땄;
    private float 딧;
    private float 딢;
    private float 땃;
    private new bool 딟;
    private new int 딟;
    private int 땄;
    private 떁 딧;
    private 떁 딢;
    private float 딶;
    private float 땓;
    private float 땺;
    private float 땥;
    private 떁 땃;
    private 떁 딶;
    private float 딝;
    private float 떎;
    private float 떂;
    private float 땭;
    private float 딦;
    private float 땤;
    private float 땽;
    private float 땋;
    private float 땲;

    internal 딧() => this.딟(딝.딢.딶);

    public 딧([In] 딺 obj0, [In] 딺 obj1, [In] 떁 obj2, [In] 떁 obj3)
      : base(obj0, obj1)
    {
      this.딟(딝.딢.딶);
      this.땄(obj0.땺(obj2));
      this.딧(obj1.땺(obj2));
      this.딟 = obj0.땥(obj3);
      this.땄 = 땥.땴.딟(1f, this.딟);
    }

    [CompilerGenerated]
    [SpecialName]
    public 떁 딧() => this.땓;

    [CompilerGenerated]
    [SpecialName]
    public void 땄([In] 떁 obj0) => this.땓 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public 떁 딢() => this.땺;

    [CompilerGenerated]
    [SpecialName]
    public void 딧([In] 떁 obj0) => this.땺 = obj0;

    [SpecialName]
    public override 떁 딟() => base.딢().딶(this.딧());

    [SpecialName]
    public override 떁 땄() => base.땃().딶(this.딢());

    [SpecialName]
    public override void 딟([In] 떁 obj0)
    {
    }

    [SpecialName]
    public float 땃() => this.땃;

    [SpecialName]
    public new void 딧([In] float obj0)
    {
      base.땥();
      this.땃 = obj0;
    }

    [SpecialName]
    public float 딶() => this.딢;

    [SpecialName]
    public void 딢([In] float obj0)
    {
      base.땥();
      this.딢 = obj0;
    }

    [CompilerGenerated]
    [SpecialName]
    public float 땓() => this.떏;

    [CompilerGenerated]
    [SpecialName]
    public void 땃([In] float obj0) => this.떏 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public float 땺() => this.땼;

    [CompilerGenerated]
    [SpecialName]
    public void 딶([In] float obj0) => this.땼 = obj0;

    public override 떁 딟([In] float obj0) => obj0 * (this.딟 * this.딶 + this.딧 * this.땃);

    public override float 땄([In] float obj0) => obj0 * this.땄;

    internal override void 딟([In] ref 딤 obj0)
    {
      this.딟 = base.딢().딧;
      this.땄 = base.땃().딧;
      this.딧 = base.딢().딟.딧;
      this.딢 = base.땃().딟.딧;
      this.딶 = base.딢().딧;
      this.땓 = base.땃().딧;
      this.땺 = base.딢().땄;
      this.땥 = base.땃().땄;
      float 딶 = this.딶;
      float 땓 = this.땓;
      float 땺 = this.땺;
      float 땥 = this.땥;
      떁 딟1 = obj0.딟[this.딟].딟;
      float 딟2 = obj0.딟[this.딟].딟;
      떁 딟3 = obj0.딟[this.딟].딟;
      float 딟4 = obj0.딟[this.딟].딟;
      떁 딟5 = obj0.딟[this.땄].딟;
      float 딟6 = obj0.딟[this.땄].딟;
      떁 딟7 = obj0.딟[this.땄].딟;
      float 딟8 = obj0.딟[this.땄].딟;
      땥.딥 딥1 = new 땥.딥(딟2);
      땥.딥 딥2 = new 땥.딥(딟6);
      떁 떁1 = 땥.땴.딟(딥1, this.딧() - this.딧);
      떁 떁2 = 땥.땴.딟(딥2, this.딢() - this.딢);
      떁 떁3 = 딟5 + 떁2 - 딟1 - 떁1;
      this.딶 = 땥.땴.딟(딥1, this.땄);
      this.떂 = 땥.땴.딟(떁3 + 떁1, this.딶);
      this.땭 = 땥.땴.딟(떁2, this.딶);
      this.딦 = (float) ((double) 딶 + (double) 땓 + (double) 땺 * (double) this.떂 * (double) this.떂 + (double) 땥 * (double) this.땭 * (double) this.땭);
      if ((double) this.딦 > 0.0)
        this.딦 = 1f / this.딦;
      this.땽 = 0.0f;
      this.땋 = 0.0f;
      this.땲 = 0.0f;
      if ((double) this.땓() > 0.0)
      {
        this.땃 = 땥.땴.딟(딥1, this.딟);
        this.딝 = 땥.땴.딟(떁3 + 떁1, this.땃);
        this.떎 = 땥.땴.딟(떁2, this.땃);
        float num1 = (float) ((double) 딶 + (double) 땓 + (double) 땺 * (double) this.딝 * (double) this.딝 + (double) 땥 * (double) this.떎 * (double) this.떎);
        if ((double) num1 > 0.0)
        {
          this.땽 = 1f / num1;
          float num2 = 떁.딶(떁3, this.땃);
          float num3 = 6.283185f * this.땓();
          float num4 = 2f * this.땽 * this.땺() * num3;
          float num5 = this.땽 * num3 * num3;
          float 딟9 = obj0.딟.딟;
          this.땲 = 딟9 * (num4 + 딟9 * num5);
          if ((double) this.땲 > 0.0)
            this.땲 = 1f / this.땲;
          this.땋 = num2 * 딟9 * num5 * this.땲;
          this.땽 = num1 + this.땲;
          if ((double) this.땽 > 0.0)
            this.땽 = 1f / this.땽;
        }
      }
      else
        this.딧 = 0.0f;
      if (this.딟)
      {
        this.땤 = 땺 + 땥;
        if ((double) this.땤 > 0.0)
          this.땤 = 1f / this.땤;
      }
      else
      {
        this.땤 = 0.0f;
        this.땄 = 0.0f;
      }
      if (딝.땥.딧)
      {
        this.딟 *= obj0.딟.땄;
        this.딧 *= obj0.딟.땄;
        this.땄 *= obj0.딟.땄;
        떁 떁4 = this.딟 * this.딶 + this.딧 * this.땃;
        float num6 = (float) ((double) this.딟 * (double) this.떂 + (double) this.딧 * (double) this.딝) + this.땄;
        float num7 = (float) ((double) this.딟 * (double) this.땭 + (double) this.딧 * (double) this.떎) + this.땄;
        딟3 -= this.딶 * 떁4;
        딟4 -= this.땺 * num6;
        딟7 += this.땓 * 떁4;
        딟8 += this.땥 * num7;
      }
      else
      {
        this.딟 = 0.0f;
        this.딧 = 0.0f;
        this.땄 = 0.0f;
      }
      obj0.딟[this.딟].딟 = 딟3;
      obj0.딟[this.딟].딟 = 딟4;
      obj0.딟[this.땄].딟 = 딟7;
      obj0.딟[this.땄].딟 = 딟8;
    }

    internal override void 땄([In] ref 딤 obj0)
    {
      float 딶 = this.딶;
      float 땓 = this.땓;
      float 땺 = this.땺;
      float 땥 = this.땥;
      떁 딟1 = obj0.딟[this.딟].딟;
      float 딟2 = obj0.딟[this.딟].딟;
      떁 딟3 = obj0.딟[this.땄].딟;
      float 딟4 = obj0.딟[this.땄].딟;
      float num1 = (float) (-(double) this.땽 * ((double) 떁.딶(this.땃, 딟3 - 딟1) + (double) this.떎 * (double) 딟4 - (double) this.딝 * (double) 딟2 + (double) this.땋 + (double) this.땲 * (double) this.딧));
      this.딧 += num1;
      떁 떁1 = num1 * this.땃;
      float num2 = num1 * this.딝;
      float num3 = num1 * this.떎;
      떁 떁2 = 딟1 - 딶 * 떁1;
      float num4 = 딟2 - 땺 * num2;
      떁 떁3 = 딟3 + 땓 * 떁1;
      float num5 = 딟4 + 땥 * num3;
      float num6 = -this.땤 * (num5 - num4 - this.땃);
      float 땄 = this.땄;
      float num7 = obj0.딟.딟 * this.딢;
      this.땄 = 땥.땴.딟(this.땄 + num6, -num7, num7);
      float num8 = this.땄 - 땄;
      float num9 = num4 - 땺 * num8;
      float num10 = num5 + 땥 * num8;
      float num11 = -this.딦 * (float) ((double) 떁.딶(this.딶, 떁3 - 떁2) + (double) this.땭 * (double) num10 - (double) this.떂 * (double) num9);
      this.딟 += num11;
      떁 떁4 = num11 * this.딶;
      float num12 = num11 * this.떂;
      float num13 = num11 * this.땭;
      떁 떁5 = 떁2 - 딶 * 떁4;
      float num14 = num9 - 땺 * num12;
      떁 떁6 = 떁3 + 땓 * 떁4;
      float num15 = num10 + 땥 * num13;
      obj0.딟[this.딟].딟 = 떁5;
      obj0.딟[this.딟].딟 = num14;
      obj0.딟[this.땄].딟 = 떁6;
      obj0.딟[this.땄].딟 = num15;
    }

    internal override bool 딧([In] ref 딤 obj0)
    {
      떁 딟1 = obj0.딟[this.딟].딟;
      float 딟2 = obj0.딟[this.딟].딟;
      떁 딟3 = obj0.딟[this.땄].딟;
      float 딟4 = obj0.딟[this.땄].딟;
      땥.딥 딥1 = new 땥.딥(딟2);
      땥.딥 딥2 = new 땥.딥(딟4);
      떁 떁1 = 땥.땴.딟(딥1, this.딧() - this.딧);
      떁 떁2 = 땥.땴.딟(딥2, this.딢() - this.딢);
      떁 떁3 = 딟3 - 딟1 + 떁2 - 떁1;
      떁 떁4 = 땥.땴.딟(딥1, this.땄);
      float num1 = 땥.땴.딟(떁3 + 떁1, 떁4);
      float num2 = 땥.땴.딟(떁2, 떁4);
      float num3 = 떁.딶(떁3, 떁4);
      float num4 = (float) ((double) this.딶 + (double) this.땓 + (double) this.땺 * (double) this.떂 * (double) this.떂 + (double) this.땥 * (double) this.땭 * (double) this.땭);
      float num5 = (double) num4 == 0.0 ? 0.0f : -num3 / num4;
      떁 떁5 = num5 * 떁4;
      float num6 = num5 * num1;
      float num7 = num5 * num2;
      떁 떁6 = 딟1 - this.딶 * 떁5;
      float num8 = 딟2 - this.땺 * num6;
      떁 떁7 = 딟3 + this.땓 * 떁5;
      float num9 = 딟4 + this.땥 * num7;
      obj0.딟[this.딟].딟 = 떁6;
      obj0.딟[this.딟].딟 = num8;
      obj0.딟[this.땄].딟 = 떁7;
      obj0.딟[this.땄].딟 = num9;
      return (double) Math.Abs(num3) <= 0.00499999988824129;
    }

    [SpecialName]
    public float 땥()
    {
      딺 딺1 = base.딢();
      딺 딺2 = base.땃();
      떁 떁 = 딺1.딶(this.딧());
      return 떁.딶(딺2.딶(this.딢()) - 떁, 딺1.땓(this.딟));
    }

    [SpecialName]
    public float 딝()
    {
      float num = base.딢().땃();
      return base.땃().땃() - num;
    }

    [SpecialName]
    public bool 떎() => this.딟;

    [SpecialName]
    public new void 딟([In] bool obj0)
    {
      base.땥();
      this.딟 = obj0;
    }

    public float 땓([In] float obj0) => obj0 * this.땄;
  }
}
