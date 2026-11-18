// Decompiled with JetBrains decompiler
// Type: 땥.땧
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땥
{
  public class 땧 : 딝.땺
  {
    public 떁 딟;
    public 떁 땄;
    private new float 딟;
    private float 땄;
    private float 딧;
    private new int 딟;
    private int 땄;
    private 떁 딧;
    private 떁 딢;
    private 떁 땃;
    private 떁 딶;
    private 떁 땓;
    private float 딢;
    private float 땃;
    private float 딶;
    private float 땓;
    private float 땺;

    internal 땧() => this.딟(딝.딢.딧);

    public 땧([In] 딺 obj0, [In] 딺 obj1, [In] 떁 obj2, [In] 떁 obj3)
      : base(obj0, obj1)
    {
      this.딟(딝.딢.딧);
      this.딟 = obj2;
      this.땄 = obj3;
      this.딧((this.땄() - this.딟()).땃());
    }

    [CompilerGenerated]
    [SpecialName]
    public float 딧() => this.땥;

    [CompilerGenerated]
    [SpecialName]
    public new void 딧([In] float obj0) => this.땥 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public float 딢() => this.딝;

    [CompilerGenerated]
    [SpecialName]
    public void 딢([In] float obj0) => this.딝 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public float 땃() => this.떎;

    [CompilerGenerated]
    [SpecialName]
    public void 땃([In] float obj0) => this.떎 = obj0;

    [SpecialName]
    public override sealed 떁 딟() => base.딢().딶(this.딟);

    [SpecialName]
    public override sealed 떁 땄() => base.땃().딶(this.땄);

    [SpecialName]
    public override sealed void 딟([In] 떁 obj0)
    {
    }

    public override 떁 딟([In] float obj0) => obj0 * this.딧 * this.딧;

    public override float 땄([In] float obj0) => 0.0f;

    internal override void 딟([In] ref 딤 obj0)
    {
      this.딟 = base.딢().딧;
      this.땄 = base.땃().딧;
      this.딶 = base.딢().딟.딧;
      this.땓 = base.땃().딟.딧;
      this.딢 = base.딢().딧;
      this.땃 = base.땃().딧;
      this.딶 = base.딢().땄;
      this.땓 = base.땃().땄;
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
      this.딢 = 땴.딟(딥1, this.딟 - this.딶);
      this.땃 = 땴.딟(딥2, this.땄 - this.땓);
      this.딧 = 딟5 + this.땃 - 딟1 - this.딢;
      float num1 = this.딧.땃();
      if ((double) num1 > 0.00499999988824129)
        this.딧 *= 1f / num1;
      else
        this.딧 = 떁.딟();
      float num2 = 땴.딟(this.딢, this.딧);
      float num3 = 땴.딟(this.땃, this.딧);
      float num4 = (float) ((double) this.딢 + (double) this.딶 * (double) num2 * (double) num2 + (double) this.땃 + (double) this.땓 * (double) num3 * (double) num3);
      this.땺 = (double) num4 == 0.0 ? 0.0f : 1f / num4;
      if ((double) this.딢() > 0.0)
      {
        float num5 = num1 - this.딧();
        float num6 = 6.283185f * this.딢();
        float num7 = 2f * this.땺 * this.땃() * num6;
        float num8 = this.땺 * num6 * num6;
        float 딟9 = obj0.딟.딟;
        this.땄 = 딟9 * (num7 + 딟9 * num8);
        this.땄 = (double) this.땄 == 0.0 ? 0.0f : 1f / this.땄;
        this.딟 = num5 * 딟9 * num8 * this.땄;
        float num9 = num4 + this.땄;
        this.땺 = (double) num9 == 0.0 ? 0.0f : 1f / num9;
      }
      else
      {
        this.땄 = 0.0f;
        this.딟 = 0.0f;
      }
      if (딝.땥.딧)
      {
        this.딧 *= obj0.딟.땄;
        떁 떁 = this.딧 * this.딧;
        딟3 -= this.딢 * 떁;
        딟4 -= this.딶 * 땴.딟(this.딢, 떁);
        딟7 += this.땃 * 떁;
        딟8 += this.땓 * 땴.딟(this.땃, 떁);
      }
      else
        this.딧 = 0.0f;
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
      떁 떁1 = 딟1 + 땴.딟(딟2, this.딢);
      float num1 = (float) (-(double) this.땺 * ((double) 떁.딶(this.딧, 딟3 + 땴.딟(딟4, this.땃) - 떁1) + (double) this.딟 + (double) this.땄 * (double) this.딧));
      this.딧 += num1;
      떁 떁2 = num1 * this.딧;
      떁 떁3 = 딟1 - this.딢 * 떁2;
      float num2 = 딟2 - this.딶 * 땴.딟(this.딢, 떁2);
      떁 떁4 = 딟3 + this.땃 * 떁2;
      float num3 = 딟4 + this.땓 * 땴.딟(this.땃, 떁2);
      obj0.딟[this.딟].딟 = 떁3;
      obj0.딟[this.딟].딟 = num2;
      obj0.딟[this.땄].딟 = 떁4;
      obj0.딟[this.땄].딟 = num3;
    }

    internal override bool 딧([In] ref 딤 obj0)
    {
      if ((double) this.딢() > 0.0)
        return true;
      떁 딟1 = obj0.딟[this.딟].딟;
      float 딟2 = obj0.딟[this.딟].딟;
      떁 딟3 = obj0.딟[this.땄].딟;
      float 딟4 = obj0.딟[this.땄].딟;
      딥 딥1 = new 딥(딟2);
      딥 딥2 = new 딥(딟4);
      떁 떁1 = 땴.딟(딥1, this.딟 - this.딶);
      떁 떁2 = 땴.딟(딥2, this.땄 - this.땓);
      떁 떁3 = 딟3 + 떁2 - 딟1 - 떁1;
      float num1 = 떁3.땃();
      떁3.땓();
      float num2 = 땴.딟(num1 - this.딧(), -0.2f, 0.2f);
      떁 떁4 = -this.땺 * num2 * 떁3;
      떁 떁5 = 딟1 - this.딢 * 떁4;
      float num3 = 딟2 - this.딶 * 땴.딟(떁1, 떁4);
      떁 떁6 = 딟3 + this.땃 * 떁4;
      float num4 = 딟4 + this.땓 * 땴.딟(떁2, 떁4);
      obj0.딟[this.딟].딟 = 떁5;
      obj0.딟[this.딟].딟 = num3;
      obj0.딟[this.땄].딟 = 떁6;
      obj0.딟[this.땄].딟 = num4;
      return (double) Math.Abs(num2) < 0.00499999988824129;
    }
  }
}
