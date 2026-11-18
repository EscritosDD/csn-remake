// Decompiled with JetBrains decompiler
// Type: 땥.떊
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땥
{
  public class 떊 : 딝.땺
  {
    public 떁 딟;
    public 떁 땄;
    public 떁 딧;
    public 떁 딢;
    private new float 딟;
    protected float 땄;
    protected float 딧;
    private float 딢;
    private new int 딟;
    private int 땄;
    private 떁 땃;
    private 떁 딶;
    private 떁 땓;
    private 떁 땺;
    private 떁 땥;
    private 떁 딝;
    private float 땃;
    private float 딶;
    private float 땓;
    private float 땺;
    private float 땥;

    internal 떊() => this.딟(딝.딢.딢);

    public 떊([In] 딺 obj0, [In] 딺 obj1, [In] 떁 obj2, [In] 떁 obj3, [In] 떁 obj4, [In] 떁 obj5, [In] float obj6)
      : base(obj0, obj1)
    {
      this.딟(딝.딢.딢);
      this.딟 = obj2;
      this.땄 = obj3;
      this.딧 = obj4;
      this.딢 = obj5;
      this.땃(obj6);
      this.딧((base.딢().딶(obj4) - obj2).땃());
      this.딢((base.땃().딶(obj5) - obj3).땃());
      this.딢 = this.딧() + obj6 * this.딢();
      this.딟 = 0.0f;
    }

    [SpecialName]
    public override 떁 딟() => base.딢().딶(this.딧);

    [SpecialName]
    public override 떁 땄() => base.땃().딶(this.딢);

    [SpecialName]
    public override void 딟([In] 떁 obj0)
    {
    }

    [CompilerGenerated]
    [SpecialName]
    public float 딧() => this.딝;

    [CompilerGenerated]
    [SpecialName]
    public new void 딧([In] float obj0) => this.딝 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public float 딢() => this.떎;

    [CompilerGenerated]
    [SpecialName]
    public void 딢([In] float obj0) => this.떎 = obj0;

    [SpecialName]
    public float 땃() => (base.딢().딶(this.딧) - this.딟).땃();

    [SpecialName]
    public float 딶() => (base.땃().딶(this.딢) - this.땄).땃();

    [CompilerGenerated]
    [SpecialName]
    public float 땓() => this.떂;

    [CompilerGenerated]
    [SpecialName]
    public void 땃([In] float obj0) => this.떂 = obj0;

    public override 떁 딟([In] float obj0)
    {
      떁 떁 = this.딟 * this.딶;
      return obj0 * 떁;
    }

    public override float 땄([In] float obj0) => 0.0f;

    internal override void 딟([In] ref 딤 obj0)
    {
      this.딟 = base.딢().딧;
      this.땄 = base.땃().딧;
      this.땥 = base.딢().딟.딧;
      this.딝 = base.땃().딟.딧;
      this.땃 = base.딢().딧;
      this.딶 = base.땃().딧;
      this.땓 = base.딢().땄;
      this.땺 = base.땃().땄;
      떁 딟1 = obj0.딟[this.딟].딟;
      float 딟2 = obj0.딟[this.딟].딟;
      떁 딟3 = obj0.딟[this.딟].딟;
      float 딟4 = obj0.딟[this.딟].딟;
      떁 딟5 = obj0.딟[this.땄].딟;
      float 딟6 = obj0.딟[this.땄].딟;
      떁 딟7 = obj0.딟[this.땄].딟;
      float 딟8 = obj0.딟[this.땄].딟;
      딥 딥1 = new 딥(딟2);
      딥 딥2 = new 딥(딟6);
      this.땓 = 땴.딟(딥1, this.딧 - this.땥);
      this.땺 = 땴.딟(딥2, this.딢 - this.딝);
      this.땃 = 딟1 + this.땓 - this.딟;
      this.딶 = 딟5 + this.땺 - this.땄;
      float num1 = this.땃.땃();
      float num2 = this.딶.땃();
      if ((double) num1 > 0.0499999970197678)
        this.땃 *= 1f / num1;
      else
        this.땃 = 떁.딟();
      if ((double) num2 > 0.0499999970197678)
        this.딶 *= 1f / num2;
      else
        this.딶 = 떁.딟();
      float num3 = 땴.딟(this.땓, this.땃);
      float num4 = 땴.딟(this.땺, this.딶);
      float num5 = this.땃 + this.땓 * num3 * num3;
      float num6 = this.딶 + this.땺 * num4 * num4;
      this.땥 = num5 + this.땓() * this.땓() * num6;
      if ((double) this.땥 > 0.0)
        this.땥 = 1f / this.땥;
      if (딝.땥.딧)
      {
        this.딟 *= obj0.딟.땄;
        떁 떁1 = (float) -((double) this.딟 + (double) this.땄) * this.땃;
        떁 떁2 = (-this.땓() * this.딟 - this.딧) * this.딶;
        딟3 += this.땃 * 떁1;
        딟4 += this.땓 * 땴.딟(this.땓, 떁1);
        딟7 += this.딶 * 떁2;
        딟8 += this.땺 * 땴.딟(this.땺, 떁2);
      }
      else
        this.딟 = 0.0f;
      obj0.딟[this.딟].딟 = 딟3;
      obj0.딟[this.딟].딟 = 딟4;
      obj0.딟[this.땄].딟 = 딟7;
      obj0.딟[this.땄].딟 = 딟8;
    }

    internal override void 땄([In] ref 딤 obj0)
    {
      떁 딟1 = obj0.딟[this.딟].딟;
      float 딟2 = obj0.딟[this.딟].딟;
      떁 딟3 = obj0.딟[this.땄].딟;
      float 딟4 = obj0.딟[this.땄].딟;
      떁 떁1 = 딟1 + 땴.딟(딟2, this.땓);
      떁 떁2 = 딟3 + 땴.딟(딟4, this.땺);
      float num1 = -this.땥 * (float) (-(double) 떁.딶(this.땃, 떁1) - (double) this.땓() * (double) 떁.딶(this.딶, 떁2));
      this.딟 += num1;
      떁 떁3 = -num1 * this.땃;
      떁 떁4 = -this.땓() * num1 * this.딶;
      떁 떁5 = 딟1 + this.땃 * 떁3;
      float num2 = 딟2 + this.땓 * 땴.딟(this.땓, 떁3);
      떁 떁6 = 딟3 + this.딶 * 떁4;
      float num3 = 딟4 + this.땺 * 땴.딟(this.땺, 떁4);
      obj0.딟[this.딟].딟 = 떁5;
      obj0.딟[this.딟].딟 = num2;
      obj0.딟[this.땄].딟 = 떁6;
      obj0.딟[this.땄].딟 = num3;
    }

    internal override bool 딧([In] ref 딤 obj0)
    {
      떁 딟1 = obj0.딟[this.딟].딟;
      float 딟2 = obj0.딟[this.딟].딟;
      떁 딟3 = obj0.딟[this.땄].딟;
      float 딟4 = obj0.딟[this.땄].딟;
      딥 딥1 = new 딥(딟2);
      딥 딥2 = new 딥(딟4);
      떁 떁1 = 땴.딟(딥1, this.딧 - this.땥);
      떁 떁2 = 땴.딟(딥2, this.딢 - this.딝);
      떁 떁3 = 딟1 + 떁1 - this.딟;
      떁 떁4 = 딟3 + 떁2 - this.땄;
      float num1 = 떁3.땃();
      float num2 = 떁4.땃();
      떁 떁5 = (double) num1 <= 0.0499999970197678 ? 떁.딟() : 떁3 * (1f / num1);
      떁 떁6 = (double) num2 <= 0.0499999970197678 ? 떁.딟() : 떁4 * (1f / num2);
      float num3 = 땴.딟(떁1, 떁5);
      float num4 = 땴.딟(떁2, 떁6);
      float num5 = this.땃 + this.땓 * num3 * num3;
      float num6 = this.딶 + this.땺 * num4 * num4;
      float num7 = num5 + this.땓() * this.땓() * num6;
      if ((double) num7 > 0.0)
        num7 = 1f / num7;
      float num8 = (float) ((double) this.딢 - (double) num1 - (double) this.땓() * (double) num2);
      float num9 = Math.Abs(num8);
      float num10 = -num7 * num8;
      떁 떁7 = -num10 * 떁5;
      떁 떁8 = -this.땓() * num10 * 떁6;
      떁 떁9 = 딟1 + this.땃 * 떁7;
      float num11 = 딟2 + this.땓 * 땴.딟(떁1, 떁7);
      떁 떁10 = 딟3 + this.딶 * 떁8;
      float num12 = 딟4 + this.땺 * 땴.딟(떁2, 떁8);
      obj0.딟[this.딟].딟 = 떁9;
      obj0.딟[this.딟].딟 = num11;
      obj0.딟[this.땄].딟 = 떁10;
      obj0.딟[this.땄].딟 = num12;
      return (double) num9 < 0.00499999988824129;
    }
  }
}
