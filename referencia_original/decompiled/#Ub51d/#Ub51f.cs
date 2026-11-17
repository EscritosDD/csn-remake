// Decompiled with JetBrains decompiler
// Type: 딝.딟
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using 땥;

namespace 딝
{
  public class 딟 : 딝.땺
  {
    public 떁 딟;
    public 떁 땄;
    private new float 딟;
    private float 땄;
    private float 딧;
    private float 딢;
    private 떁 딧;

    internal 딟() => this.딟(딝.딢.땥);

    public 딟([In] 딺 obj0, [In] 딺 obj1, [In] 떁 obj2, [In] 떁 obj3, [In] float obj4, [In] float obj5)
      : base(obj0, obj1)
    {
      this.딟(딝.딢.땥);
      this.딟 = obj2;
      this.땄 = obj3;
      this.딧(obj5);
      this.딢(obj4);
    }

    [CompilerGenerated]
    [SpecialName]
    public float 딧() => this.땃;

    [CompilerGenerated]
    [SpecialName]
    public new void 딧([In] float obj0) => this.땃 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public float 딢() => this.딶;

    [CompilerGenerated]
    [SpecialName]
    public void 딢([In] float obj0) => this.딶 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public float 땃() => this.땓;

    [CompilerGenerated]
    [SpecialName]
    public void 땃([In] float obj0) => this.땓 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public float 딶() => this.땺;

    [CompilerGenerated]
    [SpecialName]
    public void 딶([In] float obj0) => this.땺 = obj0;

    [SpecialName]
    public override 떁 딟() => base.딢().딶(this.딟);

    [SpecialName]
    public override 떁 땄() => base.땃().딶(this.땄);

    [SpecialName]
    public override void 딟([In] 떁 obj0)
    {
    }

    public override 떁 딟([In] float obj0) => obj0 * this.딧 * this.딧;

    public override float 땄([In] float obj0) => 0.0f;

    internal override void 딟([In] ref 딤 obj0)
    {
      딺 딺1 = base.딢();
      딺 딺2 = base.땃();
      땥.떓 떓1;
      딺1.딟(out 떓1);
      땥.떓 떓2;
      딺2.딟(out 떓2);
      떁 떁1 = 땥.땴.딟(ref 떓1.딟, this.딟 - 딺1.땂());
      떁 떁2 = 땥.땴.딟(ref 떓2.딟, this.땄 - 딺2.땂());
      this.딧 = 딺2.딟.딟 + 떁2 - 딺1.딟.딟 - 떁1;
      float num1 = this.딧.땃();
      if ((double) num1 < (double) this.딧() && (double) num1 > (double) this.딢())
        return;
      if ((double) num1 > 0.00499999988824129)
        this.딧 *= 1f / num1;
      else
        this.딧 = 떁.딟();
      float num2 = 땥.땴.딟(떁1, this.딧);
      float num3 = 땥.땴.딟(떁2, this.딧);
      float num4 = (float) ((double) 딺1.딧 + (double) 딺1.땄 * (double) num2 * (double) num2 + (double) 딺2.딧 + (double) 딺2.땄 * (double) num3 * (double) num3);
      this.딢 = (double) num4 == 0.0 ? 0.0f : 1f / num4;
      if ((double) this.땃() > 0.0)
      {
        float num5 = num1 - this.딧();
        float num6 = 6.283185f * this.땃();
        float num7 = 2f * this.딢 * this.딶() * num6;
        float num8 = this.딢 * num6 * num6;
        this.땄 = obj0.딟.딟 * (num7 + obj0.딟.딟 * num8);
        this.땄 = (double) this.땄 == 0.0 ? 0.0f : 1f / this.땄;
        this.딟 = num5 * obj0.딟.딟 * num8 * this.땄;
        this.딢 = num4 + this.땄;
        this.딢 = (double) this.딢 == 0.0 ? 0.0f : 1f / this.딢;
      }
      if (딝.땥.딧)
      {
        this.딧 *= obj0.딟.땄;
        떁 떁3 = this.딧 * this.딧;
        딺1.땄 -= 딺1.딧 * 떁3;
        딺1.딟 -= 딺1.땄 * 땥.땴.딟(떁1, 떁3);
        딺2.땄 += 딺2.딧 * 떁3;
        딺2.딟 += 딺2.땄 * 땥.땴.딟(떁2, 떁3);
      }
      else
        this.딧 = 0.0f;
    }

    internal override void 땄([In] ref 딤 obj0)
    {
      딺 딺1 = base.딢();
      딺 딺2 = base.땃();
      땥.떓 떓1;
      딺1.딟(out 떓1);
      땥.떓 떓2;
      딺2.딟(out 떓2);
      떁 떁1 = 땥.땴.딟(ref 떓1.딟, this.딟 - 딺1.땂());
      떁 떁2 = 땥.땴.딟(ref 떓2.딟, this.땄 - 딺2.땂());
      float num1 = (딺2.딟.딟 + 떁2 - 딺1.딟.딟 - 떁1).땃();
      if ((double) num1 < (double) this.딧() && (double) num1 > (double) this.딢())
        return;
      떁 떁3 = 딺1.땄 + 땥.땴.딟(딺1.딟, 떁1);
      float num2 = (float) (-(double) this.딢 * ((double) 떁.딶(this.딧, 딺2.땄 + 땥.땴.딟(딺2.딟, 떁2) - 떁3) + (double) this.딟 + (double) this.땄 * (double) this.딧));
      this.딧 += num2;
      떁 떁4 = num2 * this.딧;
      딺1.땄 -= 딺1.딧 * 떁4;
      딺1.딟 -= 딺1.땄 * 땥.땴.딟(떁1, 떁4);
      딺2.땄 += 딺2.딧 * 떁4;
      딺2.딟 += 딺2.땄 * 땥.땴.딟(떁2, 떁4);
    }

    internal override bool 딧([In] ref 딤 obj0)
    {
      if ((double) this.땃() > 0.0)
        return true;
      딺 딺1 = base.딢();
      딺 딺2 = base.땃();
      땥.떓 떓1;
      딺1.딟(out 떓1);
      땥.떓 떓2;
      딺2.딟(out 떓2);
      떁 떁1 = 땥.땴.딟(ref 떓1.딟, this.딟 - 딺1.땂());
      떁 떁2 = 땥.땴.딟(ref 떓2.딟, this.땄 - 딺2.땂());
      떁 떁3 = 딺2.딟.딟 + 떁2 - 딺1.딟.딟 - 떁1;
      float num1 = 떁3.땃();
      if ((double) num1 < (double) this.딧() && (double) num1 > (double) this.딢() || (double) num1 == 0.0)
        return true;
      떁 떁4 = 떁3 / num1;
      float num2 = 땥.땴.딟(num1 - this.딧(), -0.2f, 0.2f);
      float num3 = -this.딢 * num2;
      this.딧 = 떁4;
      떁 떁5 = num3 * this.딧;
      딺1.딟.딟 -= 딺1.딧 * 떁5;
      딺1.딟.딟 -= 딺1.땄 * 땥.땴.딟(떁1, 떁5);
      딺2.딟.딟 += 딺2.딧 * 떁5;
      딺2.딟.딟 += 딺2.땄 * 땥.땴.딟(떁2, 떁5);
      딺1.딣();
      딺2.딣();
      return (double) Math.Abs(num2) < 0.00499999988824129;
    }
  }
}
