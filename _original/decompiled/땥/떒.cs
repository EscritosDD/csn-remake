// Decompiled with JetBrains decompiler
// Type: 땥.떒
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땥
{
  public class 떒 : 딝.땺
  {
    public 떁 딟;
    public 떁 땄;
    private 땟 딟;
    private new float 딟;
    private new bool 딟;
    private float 땄;
    private float 딧;
    private new bool 땄;
    private float 딢;
    private float 땃;
    private float 딶;
    private new int 딟;
    private int 땄;
    private 떁 딧;
    private 떁 딢;
    private 떁 땃;
    private 떁 딶;
    private float 땓;
    private float 땺;
    private float 땥;
    private float 딝;
    private 땻 딟;
    private float 떎;
    private 딝.땃 딟;

    internal 떒() => this.딟(딝.딢.딟);

    public 떒([In] 딺 obj0, [In] 딺 obj1, [In] 떁 obj2, [In] 떁 obj3)
      : base(obj0, obj1)
    {
      this.딟(딝.딢.딟);
      this.딟 = obj2;
      this.땄 = obj3;
      this.딧(base.땃().땢() - base.딢().땢());
      this.딟 = 땟.딟();
      this.딟 = 딝.땃.딟;
    }

    public 떒([In] 딺 obj0, [In] 딺 obj1, [In] 떁 obj2)
      : base(obj0, obj1)
    {
      this.딟(딝.딢.딟);
      this.딟 = obj0.땺(obj2);
      this.땄 = obj1.땺(obj2);
      this.딧(base.땃().땢() - base.딢().땢());
      this.딟 = 땟.딟();
      this.딟 = 딝.땃.딟;
    }

    [SpecialName]
    public override 떁 딟() => base.딢().딶(this.딟);

    [SpecialName]
    public override 떁 땄() => base.땃().딶(this.땄);

    [SpecialName]
    public override void 딟([In] 떁 obj0)
    {
    }

    [SpecialName]
    public float 딧() => this.딢;

    [SpecialName]
    public new void 딧([In] float obj0)
    {
      base.땥();
      this.딢 = obj0;
    }

    [SpecialName]
    public float 딢() => base.땃().딟.딟 - base.딢().딟.딟 - this.딧();

    [SpecialName]
    public float 땃() => base.땃().딟 - base.딢().딟;

    [SpecialName]
    public bool 딶() => this.땄;

    [SpecialName]
    public new void 딟([In] bool obj0)
    {
      if (this.땄 == obj0)
        return;
      base.땥();
      this.땄 = obj0;
      this.딟.딧 = 0.0f;
    }

    [SpecialName]
    public float 땓() => this.땃;

    [SpecialName]
    public void 딢([In] float obj0)
    {
      if ((double) this.땃 == (double) obj0)
        return;
      base.땥();
      this.땃 = obj0;
      this.딟.딧 = 0.0f;
    }

    [SpecialName]
    public float 땺() => this.딶;

    [SpecialName]
    public void 땃([In] float obj0)
    {
      if ((double) this.딶 == (double) obj0)
        return;
      base.땥();
      this.딶 = obj0;
      this.딟.딧 = 0.0f;
    }

    public void 딟([In] float obj0, [In] float obj1)
    {
      if ((double) obj0 == (double) this.땃 && (double) obj1 == (double) this.딶)
        return;
      base.땥();
      this.딶 = obj1;
      this.땃 = obj0;
      this.딟.딧 = 0.0f;
    }

    [SpecialName]
    public bool 땥() => this.딟;

    [SpecialName]
    public void 땄([In] bool obj0)
    {
      base.땥();
      this.딟 = obj0;
    }

    [SpecialName]
    public void 딶([In] float obj0)
    {
      base.땥();
      this.딧 = obj0;
    }

    [SpecialName]
    public float 딝() => this.딧;

    [SpecialName]
    public void 땓([In] float obj0)
    {
      base.땥();
      this.땄 = obj0;
    }

    [SpecialName]
    public float 떎() => this.땄;

    [SpecialName]
    public float 떂() => this.딟;

    [SpecialName]
    public void 땺([In] float obj0)
    {
      base.땥();
      this.딟 = obj0;
    }

    public float 땥([In] float obj0) => obj0 * this.딟;

    public override 떁 딟([In] float obj0)
    {
      떁 떁 = new 떁(this.딟.딟, this.딟.땄);
      return obj0 * 떁;
    }

    public override float 땄([In] float obj0) => obj0 * this.딟.딧;

    internal override void 딟([In] ref 딤 obj0)
    {
      this.딟 = base.딢().딧;
      this.땄 = base.땃().딧;
      this.땃 = base.딢().딟.딧;
      this.딶 = base.땃().딟.딧;
      this.땓 = base.딢().딧;
      this.땺 = base.땃().딧;
      this.땥 = base.딢().땄;
      this.딝 = base.땃().땄;
      float 딟1 = obj0.딟[this.딟].딟;
      떁 딟2 = obj0.딟[this.딟].딟;
      float 딟3 = obj0.딟[this.딟].딟;
      float 딟4 = obj0.딟[this.땄].딟;
      떁 딟5 = obj0.딟[this.땄].딟;
      float 딟6 = obj0.딟[this.땄].딟;
      딥 딥1 = new 딥(딟1);
      딥 딥2 = new 딥(딟4);
      this.딧 = 땴.딟(딥1, this.딟 - this.땃);
      this.딢 = 땴.딟(딥2, this.땄 - this.딶);
      float 땓 = this.땓;
      float 땺 = this.땺;
      float 땥 = this.땥;
      float 딝 = this.딝;
      bool flag = (double) 땥 + (double) 딝 == 0.0;
      this.딟.딟.딟 = (float) ((double) 땓 + (double) 땺 + (double) this.딧.땄 * (double) this.딧.땄 * (double) 땥 + (double) this.딢.땄 * (double) this.딢.땄 * (double) 딝);
      this.딟.땄.딟 = (float) (-(double) this.딧.땄 * (double) this.딧.딟 * (double) 땥 - (double) this.딢.땄 * (double) this.딢.딟 * (double) 딝);
      this.딟.딧.딟 = (float) (-(double) this.딧.땄 * (double) 땥 - (double) this.딢.땄 * (double) 딝);
      this.딟.딟.땄 = this.딟.땄.딟;
      this.딟.땄.땄 = (float) ((double) 땓 + (double) 땺 + (double) this.딧.딟 * (double) this.딧.딟 * (double) 땥 + (double) this.딢.딟 * (double) this.딢.딟 * (double) 딝);
      this.딟.딧.땄 = (float) ((double) this.딧.딟 * (double) 땥 + (double) this.딢.딟 * (double) 딝);
      this.딟.딟.딧 = this.딟.딧.딟;
      this.딟.땄.딧 = this.딟.딧.땄;
      this.딟.딧.딧 = 땥 + 딝;
      this.떎 = 땥 + 딝;
      if ((double) this.떎 > 0.0)
        this.떎 = 1f / this.떎;
      if (!this.딟 || flag)
        this.딟 = 0.0f;
      if (this.땄 && !flag)
      {
        float num = 딟4 - 딟1 - this.딧();
        if ((double) Math.Abs(this.딶 - this.땃) < 0.0698131769895554)
          this.딟 = 딝.땃.딢;
        else if ((double) num <= (double) this.땃)
        {
          if (this.딟 != 딝.땃.땄)
            this.딟.딧 = 0.0f;
          this.딟 = 딝.땃.땄;
        }
        else if ((double) num >= (double) this.딶)
        {
          if (this.딟 != 딝.땃.딧)
            this.딟.딧 = 0.0f;
          this.딟 = 딝.땃.딧;
        }
        else
        {
          this.딟 = 딝.땃.딟;
          this.딟.딧 = 0.0f;
        }
      }
      else
        this.딟 = 딝.땃.딟;
      if (딝.땥.딧)
      {
        this.딟 *= obj0.딟.땄;
        this.딟 *= obj0.딟.땄;
        떁 떁 = new 떁(this.딟.딟, this.딟.땄);
        딟2 -= 땓 * 떁;
        딟3 -= 땥 * (땴.딟(this.딧, 떁) + this.떂() + this.딟.딧);
        딟5 += 땺 * 떁;
        딟6 += 딝 * (땴.딟(this.딢, 떁) + this.떂() + this.딟.딧);
      }
      else
      {
        this.딟 = 땟.딟();
        this.딟 = 0.0f;
      }
      obj0.딟[this.딟].딟 = 딟2;
      obj0.딟[this.딟].딟 = 딟3;
      obj0.딟[this.땄].딟 = 딟5;
      obj0.딟[this.땄].딟 = 딟6;
    }

    internal override void 땄([In] ref 딤 obj0)
    {
      떁 딟1 = obj0.딟[this.딟].딟;
      float 딟2 = obj0.딟[this.딟].딟;
      떁 딟3 = obj0.딟[this.땄].딟;
      float 딟4 = obj0.딟[this.땄].딟;
      float 땓 = this.땓;
      float 땺 = this.땺;
      float 땥 = this.땥;
      float 딝 = this.딝;
      bool flag = (double) 땥 + (double) 딝 == 0.0;
      if (this.딟 && this.딟 != 딝.땃.딢 && !flag)
      {
        float num1 = this.떎 * -(딟4 - 딟2 - this.딧);
        float 딟5 = this.딟;
        float num2 = obj0.딟.딟 * this.땄;
        this.딟 = 땴.딟(this.딟 + num1, -num2, num2);
        float num3 = this.딟 - 딟5;
        딟2 -= 땥 * num3;
        딟4 += 딝 * num3;
      }
      떁 떁1;
      float num4;
      떁 떁2;
      float num5;
      if (this.땄 && this.딟 != 딝.땃.딟 && !flag)
      {
        떁 떁3 = 딟3 + 땴.딟(딟4, this.딢) - 딟1 - 땴.딟(딟2, this.딧);
        float num6 = 딟4 - 딟2;
        땟 땟 = -this.딟.딟(new 땟(떁3.딟, 떁3.땄, num6));
        if (this.딟 == 딝.땃.딢)
          this.딟 += 땟;
        else if (this.딟 == 딝.땃.땄)
        {
          if ((double) (this.딟.딧 + 땟.딧) < 0.0)
          {
            떁 떁4 = this.딟.딟(-떁3 + this.딟.딧 * new 떁(this.딟.딧.딟, this.딟.딧.땄));
            땟.딟 = 떁4.딟;
            땟.땄 = 떁4.땄;
            땟.딧 = -this.딟.딧;
            this.딟.딟 += 떁4.딟;
            this.딟.땄 += 떁4.땄;
            this.딟.딧 = 0.0f;
          }
          else
            this.딟 += 땟;
        }
        else if (this.딟 == 딝.땃.딧)
        {
          if ((double) (this.딟.딧 + 땟.딧) > 0.0)
          {
            떁 떁5 = this.딟.딟(-떁3 + this.딟.딧 * new 떁(this.딟.딧.딟, this.딟.딧.땄));
            땟.딟 = 떁5.딟;
            땟.땄 = 떁5.땄;
            땟.딧 = -this.딟.딧;
            this.딟.딟 += 떁5.딟;
            this.딟.땄 += 떁5.땄;
            this.딟.딧 = 0.0f;
          }
          else
            this.딟 += 땟;
        }
        떁 떁6 = new 떁(땟.딟, 땟.땄);
        떁1 = 딟1 - 땓 * 떁6;
        num4 = 딟2 - 땥 * (땴.딟(this.딧, 떁6) + 땟.딧);
        떁2 = 딟3 + 땺 * 떁6;
        num5 = 딟4 + 딝 * (땴.딟(this.딢, 떁6) + 땟.딧);
      }
      else
      {
        떁 떁7 = this.딟.딟(-(딟3 + 땴.딟(딟4, this.딢) - 딟1 - 땴.딟(딟2, this.딧)));
        this.딟.딟 += 떁7.딟;
        this.딟.땄 += 떁7.땄;
        떁1 = 딟1 - 땓 * 떁7;
        num4 = 딟2 - 땥 * 땴.딟(this.딧, 떁7);
        떁2 = 딟3 + 땺 * 떁7;
        num5 = 딟4 + 딝 * 땴.딟(this.딢, 떁7);
      }
      obj0.딟[this.딟].딟 = 떁1;
      obj0.딟[this.딟].딟 = num4;
      obj0.딟[this.땄].딟 = 떁2;
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
      float num1 = 0.0f;
      bool flag = (double) this.땥 + (double) this.딝 == 0.0;
      if (this.땄 && this.딟 != 딝.땃.딟 && !flag)
      {
        float num2 = 딟4 - 딟2 - this.딧();
        float num3 = 0.0f;
        if (this.딟 == 딝.땃.딢)
        {
          float num4 = 땴.딟(num2 - this.땃, -0.1396264f, 0.1396264f);
          num3 = -this.떎 * num4;
          num1 = Math.Abs(num4);
        }
        else if (this.딟 == 딝.땃.땄)
        {
          float num5 = num2 - this.땃;
          num1 = -num5;
          num3 = -this.떎 * 땴.딟(num5 + 0.03490659f, -0.1396264f, 0.0f);
        }
        else if (this.딟 == 딝.땃.딧)
        {
          float num6 = num2 - this.딶;
          num1 = num6;
          num3 = -this.떎 * 땴.딟(num6 - 0.03490659f, 0.0f, 0.1396264f);
        }
        딟2 -= this.땥 * num3;
        딟4 += this.딝 * num3;
      }
      딥1.딟(딟2);
      딥2.딟(딟4);
      떁 떁1 = 땴.딟(딥1, this.딟 - this.땃);
      떁 떁2 = 땴.딟(딥2, this.땄 - this.딶);
      떁 떁3 = 딟3 + 떁2 - 딟1 - 떁1;
      float num7 = 떁3.땃();
      float 땓 = this.땓;
      float 땺 = this.땺;
      float 땥 = this.땥;
      float 딝 = this.딝;
      땳 땳 = new 땳()
      {
        딟 = {
          딟 = (float) ((double) 땓 + (double) 땺 + (double) 땥 * (double) 떁1.땄 * (double) 떁1.땄 + (double) 딝 * (double) 떁2.땄 * (double) 떁2.땄),
          땄 = (float) (-(double) 땥 * (double) 떁1.딟 * (double) 떁1.땄 - (double) 딝 * (double) 떁2.딟 * (double) 떁2.땄)
        }
      };
      땳.땄.딟 = 땳.딟.땄;
      땳.땄.땄 = (float) ((double) 땓 + (double) 땺 + (double) 땥 * (double) 떁1.딟 * (double) 떁1.딟 + (double) 딝 * (double) 떁2.딟 * (double) 떁2.딟);
      떁 떁4 = -땳.딟(떁3);
      떁 떁5 = 딟1 - 땓 * 떁4;
      float num8 = 딟2 - 땥 * 땴.딟(떁1, 떁4);
      떁 떁6 = 딟3 + 땺 * 떁4;
      float num9 = 딟4 + 딝 * 땴.딟(떁2, 떁4);
      obj0.딟[this.딟].딟 = 떁5;
      obj0.딟[this.딟].딟 = num8;
      obj0.딟[this.땄].딟 = 떁6;
      obj0.딟[this.땄].딟 = num9;
      return (double) num7 <= 0.00499999988824129 && (double) num1 <= 0.0349065884947777;
    }
  }
}
