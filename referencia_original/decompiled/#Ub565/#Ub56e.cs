// Decompiled with JetBrains decompiler
// Type: 땥.땮
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땥
{
  public class 땮 : 딝.땺
  {
    private new float 딟;
    private float 땄;
    private new int 딟;
    private int 땄;
    private 떁 딟;
    private 떁 땄;
    private float 딧;
    private float 딢;
    private float 땃;
    private float 딶;
    private float 땓;
    private 떁 딧;
    private 떁 딢;
    private 딝.땃 딟;
    private 떁 땃;

    internal 땮() => this.딟(딝.딢.떎);

    public 땮([In] 딺 obj0, [In] 딺 obj1, [In] 떁 obj2, [In] 떁 obj3)
      : base(obj0, obj1)
    {
      this.딟(딝.딢.떎);
      this.땄(obj2);
      this.딧(obj3);
      this.딧((this.땄() - this.딟()).땃());
    }

    [CompilerGenerated]
    [SpecialName]
    public float 딧() => this.땺;

    [CompilerGenerated]
    [SpecialName]
    public new void 딧([In] float obj0) => this.땺 = obj0;

    [SpecialName]
    public 딝.땃 딢() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public 떁 땃() => this.딶;

    [CompilerGenerated]
    [SpecialName]
    public void 땄([In] 떁 obj0) => this.딶 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public 떁 딶() => this.땓;

    [CompilerGenerated]
    [SpecialName]
    public void 딧([In] 떁 obj0) => this.땓 = obj0;

    [SpecialName]
    public override sealed 떁 딟() => base.딢().딶(this.땃());

    [SpecialName]
    public override sealed 떁 땄() => base.땃().딶(this.딶());

    [SpecialName]
    public override sealed void 딟([In] 떁 obj0)
    {
    }

    public override 떁 딟([In] float obj0) => obj0 * this.딟 * this.땃;

    public override float 땄([In] float obj0) => 0.0f;

    internal override void 딟([In] ref 딤 obj0)
    {
      this.딟 = base.딢().딧;
      this.땄 = base.땃().딧;
      this.딟 = base.딢().딟.딧;
      this.땄 = base.땃().딟.딧;
      this.딧 = base.딢().딧;
      this.딢 = base.땃().딧;
      this.땃 = base.딢().땄;
      this.딶 = base.땃().땄;
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
      this.딧 = 땴.딟(딥1, this.땃() - this.딟);
      this.딢 = 땴.딟(딥2, this.딶() - this.땄);
      this.땃 = 딟5 + this.딢 - 딟1 - this.딧;
      this.땄 = this.땃.땃();
      this.딟 = (double) (this.땄 - this.딧()) <= 0.0 ? 딝.땃.딟 : 딝.땃.딧;
      if ((double) this.땄 > 0.00499999988824129)
      {
        this.땃 *= 1f / this.땄;
        float num1 = 땴.딟(this.딧, this.땃);
        float num2 = 땴.딟(this.딢, this.땃);
        float num3 = (float) ((double) this.딧 + (double) this.땃 * (double) num1 * (double) num1 + (double) this.딢 + (double) this.딶 * (double) num2 * (double) num2);
        this.땓 = (double) num3 == 0.0 ? 0.0f : 1f / num3;
        if (딝.땥.딧)
        {
          this.딟 *= obj0.딟.땄;
          떁 떁 = this.딟 * this.땃;
          딟3 -= this.딧 * 떁;
          딟4 -= this.땃 * 땴.딟(this.딧, 떁);
          딟7 += this.딢 * 떁;
          딟8 += this.딶 * 땴.딟(this.딢, 떁);
        }
        else
          this.딟 = 0.0f;
        obj0.딟[this.딟].딟 = 딟3;
        obj0.딟[this.딟].딟 = 딟4;
        obj0.딟[this.땄].딟 = 딟7;
        obj0.딟[this.땄].딟 = 딟8;
      }
      else
      {
        this.땃 = 떁.딟();
        this.땓 = 0.0f;
        this.딟 = 0.0f;
      }
    }

    internal override void 땄([In] ref 딤 obj0)
    {
      떁 딟1 = obj0.딟[this.딟].딟;
      float 딟2 = obj0.딟[this.딟].딟;
      떁 딟3 = obj0.딟[this.땄].딟;
      float 딟4 = obj0.딟[this.땄].딟;
      떁 떁1 = 딟1 + 땴.딟(딟2, this.딧);
      떁 떁2 = 딟3 + 땴.딟(딟4, this.딢);
      float num1 = this.땄 - this.딧();
      float num2 = 떁.딶(this.땃, 떁2 - 떁1);
      if ((double) num1 < 0.0)
        num2 += obj0.딟.딧 * num1;
      float num3 = -this.땓 * num2;
      float 딟5 = this.딟;
      this.딟 = Math.Min(0.0f, this.딟 + num3);
      떁 떁3 = (this.딟 - 딟5) * this.땃;
      떁 떁4 = 딟1 - this.딧 * 떁3;
      float num4 = 딟2 - this.땃 * 땴.딟(this.딧, 떁3);
      떁 떁5 = 딟3 + this.딢 * 떁3;
      float num5 = 딟4 + this.딶 * 땴.딟(this.딢, 떁3);
      obj0.딟[this.딟].딟 = 떁4;
      obj0.딟[this.딟].딟 = num4;
      obj0.딟[this.땄].딟 = 떁5;
      obj0.딟[this.땄].딟 = num5;
    }

    internal override bool 딧([In] ref 딤 obj0)
    {
      떁 딟1 = obj0.딟[this.딟].딟;
      float 딟2 = obj0.딟[this.딟].딟;
      떁 딟3 = obj0.딟[this.땄].딟;
      float 딟4 = obj0.딟[this.땄].딟;
      딥 딥1 = new 딥(딟2);
      딥 딥2 = new 딥(딟4);
      떁 떁1 = 땴.딟(딥1, this.땃() - this.딟);
      떁 떁2 = 땴.딟(딥2, this.딶() - this.땄);
      떁 떁3 = 딟3 + 떁2 - 딟1 - 떁1;
      float num1 = 떁3.땃();
      떁3.땓();
      떁 떁4 = -this.땓 * 땴.딟(num1 - this.딧(), 0.0f, 0.2f) * 떁3;
      떁 떁5 = 딟1 - this.딧 * 떁4;
      float num2 = 딟2 - this.땃 * 땴.딟(떁1, 떁4);
      떁 떁6 = 딟3 + this.딢 * 떁4;
      float num3 = 딟4 + this.딶 * 땴.딟(떁2, 떁4);
      obj0.딟[this.딟].딟 = 떁5;
      obj0.딟[this.딟].딟 = num2;
      obj0.딟[this.땄].딟 = 떁6;
      obj0.딟[this.땄].딟 = num3;
      return (double) num1 - (double) this.딧() < 0.00499999988824129;
    }
  }
}
