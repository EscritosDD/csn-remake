// Decompiled with JetBrains decompiler
// Type: 땥.땬
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땥
{
  public class 땬 : 딝.땺
  {
    public 떁 딟;
    public 떁 땄;
    private 떁 딧;
    private 떁 딢;
    private new float 딟;
    private 땟 딟;
    private float 땄;
    private float 딧;
    private float 딢;
    private float 땃;
    private float 딶;
    private new bool 딟;
    private new bool 땄;
    private 딝.땃 딟;
    private new int 딟;
    private int 땄;
    private 떁 땃;
    private 떁 딶;
    private float 땓;
    private float 땺;
    private float 땥;
    private float 딝;
    private 떁 땓;
    private 떁 땺;
    private float 떎;
    private float 떂;
    private float 땭;
    private float 딦;
    private 땻 딟;
    private float 땤;

    internal 땬() => this.딟(딝.딢.땄);

    public 땬([In] 딺 obj0, [In] 딺 obj1, [In] 떁 obj2, [In] 떁 obj3, [In] 떁 obj4)
      : base(obj0, obj1)
    {
      this.딟(딝.딢.땄);
      this.딟 = obj2;
      this.땄 = obj3;
      this.딧 = base.딢().땥(obj4);
      this.딧.땓();
      this.딢 = 땴.딟(1f, this.딧);
      this.딟 = base.땃().땢() - base.딢().땢();
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
    public float 딧() => 떁.딶(base.땃().딶(this.땄) - base.딢().딶(this.딟), base.딢().딢(ref this.딧));

    [SpecialName]
    public float 딢()
    {
      떓 떓1;
      base.딢().딟(out 떓1);
      떓 떓2;
      base.땃().딟(out 떓2);
      떁 떁1 = 땴.딟(ref 떓1.딟, this.딟 - base.딢().땂());
      떁 떁2 = 땴.딟(ref 떓2.딟, this.땄 - base.땃().땂());
      떁 떁3 = base.딢().딟.딟 + 떁1;
      떁 떁4 = base.땃().딟.딟 + 떁2 - 떁3;
      떁 떁5 = base.딢().딢(ref this.딧);
      떁 땄1 = base.딢().땄;
      떁 땄2 = base.땃().땄;
      float 딟1 = base.딢().딟;
      float 딟2 = base.땃().딟;
      return 떁.딶(떁4, 땴.딟(딟1, 떁5)) + 떁.딶(떁5, 땄2 + 땴.딟(딟2, 떁2) - 땄1 - 땴.딟(딟1, 떁1));
    }

    [SpecialName]
    public bool 땃() => this.딟;

    [SpecialName]
    public new void 딟([In] bool obj0)
    {
      if (obj0 == this.딟)
        return;
      base.땥();
      this.딟 = obj0;
      this.딟.딧 = 0.0f;
    }

    [SpecialName]
    public float 딶() => this.딧;

    [SpecialName]
    public new void 딧([In] float obj0)
    {
      if ((double) obj0 == (double) this.딧)
        return;
      base.땥();
      this.딧 = obj0;
      this.딟.딧 = 0.0f;
    }

    [SpecialName]
    public float 땓() => this.딢;

    [SpecialName]
    public void 딢([In] float obj0)
    {
      if ((double) obj0 == (double) this.딢)
        return;
      base.땥();
      this.딢 = obj0;
      this.딟.딧 = 0.0f;
    }

    public void 딟([In] float obj0, [In] float obj1)
    {
      if ((double) obj1 == (double) this.딢 && (double) obj0 == (double) this.딧)
        return;
      base.땥();
      this.딢 = obj1;
      this.딧 = obj0;
      this.딟.딧 = 0.0f;
    }

    [SpecialName]
    public new bool 땺() => this.땄;

    [SpecialName]
    public void 땄([In] bool obj0)
    {
      base.땥();
      this.땄 = obj0;
    }

    [SpecialName]
    public void 땃([In] float obj0)
    {
      base.땥();
      this.딶 = obj0;
    }

    [SpecialName]
    public float 땥() => this.딶;

    [SpecialName]
    public float 딝() => this.땃;

    [SpecialName]
    public void 딶([In] float obj0)
    {
      base.땥();
      this.땃 = obj0;
    }

    [SpecialName]
    public float 떎() => this.땄;

    [SpecialName]
    public void 땓([In] float obj0) => this.땄 = obj0;

    public float 땺([In] float obj0) => obj0 * this.땄;

    [SpecialName]
    public 떁 떂() => this.딧;

    [SpecialName]
    public void 땄([In] 떁 obj0)
    {
      this.딧 = base.딢().땥(obj0);
      this.딢 = 땴.딟(1f, this.딧);
    }

    [SpecialName]
    public float 땭() => this.딟;

    [SpecialName]
    public void 땥([In] float obj0) => this.딟 = obj0;

    public override 떁 딟([In] float obj0) => obj0 * (this.딟.딟 * this.땺 + (this.땄 + this.딟.딧) * this.땓);

    public override float 땄([In] float obj0) => obj0 * this.딟.땄;

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
      떁 떁1 = 땴.딟(딥1, this.딟 - this.땃);
      떁 떁2 = 땴.딟(딥2, this.땄 - this.딶);
      떁 떁3 = 딟5 - 딟1 + 떁2 - 떁1;
      float 땓 = this.땓;
      float 땺 = this.땺;
      float 땥 = this.땥;
      float 딝 = this.딝;
      this.땓 = 땴.딟(딥1, this.떂());
      this.땭 = 땴.딟(떁3 + 떁1, this.땓);
      this.딦 = 땴.딟(떁2, this.땓);
      this.땤 = (float) ((double) 땓 + (double) 땺 + (double) 땥 * (double) this.땭 * (double) this.땭 + (double) 딝 * (double) this.딦 * (double) this.딦);
      if ((double) this.땤 > 0.0)
        this.땤 = 1f / this.땤;
      this.땺 = 땴.딟(딥1, this.딢);
      this.떎 = 땴.딟(떁3 + 떁1, this.땺);
      this.떂 = 땴.딟(떁2, this.땺);
      float num1 = (float) ((double) 땓 + (double) 땺 + (double) 땥 * (double) this.떎 * (double) this.떎 + (double) 딝 * (double) this.떂 * (double) this.떂);
      float num2 = (float) ((double) 땥 * (double) this.떎 + (double) 딝 * (double) this.떂);
      float num3 = (float) ((double) 땥 * (double) this.떎 * (double) this.땭 + (double) 딝 * (double) this.떂 * (double) this.딦);
      float num4 = 땥 + 딝;
      if ((double) num4 == 0.0)
        num4 = 1f;
      float num5 = (float) ((double) 땥 * (double) this.땭 + (double) 딝 * (double) this.딦);
      float num6 = (float) ((double) 땓 + (double) 땺 + (double) 땥 * (double) this.땭 * (double) this.땭 + (double) 딝 * (double) this.딦 * (double) this.딦);
      this.딟.딟 = new 땟(num1, num2, num3);
      this.딟.땄 = new 땟(num2, num4, num5);
      this.딟.딧 = new 땟(num3, num5, num6);
      if (this.딟)
      {
        float num7 = 떁.딶(this.땓, 떁3);
        if ((double) Math.Abs(this.딢 - this.딧) < 0.00999999977648258)
          this.딟 = 딝.땃.딢;
        else if ((double) num7 <= (double) this.딧)
        {
          if (this.딟 != 딝.땃.땄)
          {
            this.딟 = 딝.땃.땄;
            this.딟.딧 = 0.0f;
          }
        }
        else if ((double) num7 >= (double) this.딢)
        {
          if (this.딟 != 딝.땃.딧)
          {
            this.딟 = 딝.땃.딧;
            this.딟.딧 = 0.0f;
          }
        }
        else
        {
          this.딟 = 딝.땃.딟;
          this.딟.딧 = 0.0f;
        }
      }
      else
        this.딟 = 딝.땃.딟;
      if (!this.땄)
        this.땄 = 0.0f;
      if (딝.땥.딧)
      {
        this.딟 *= obj0.딟.땄;
        this.땄 *= obj0.딟.땄;
        떁 떁4 = this.딟.딟 * this.땺 + (this.땄 + this.딟.딧) * this.땓;
        float num8 = (float) ((double) this.딟.딟 * (double) this.떎 + (double) this.딟.땄 + ((double) this.땄 + (double) this.딟.딧) * (double) this.땭);
        float num9 = (float) ((double) this.딟.딟 * (double) this.떂 + (double) this.딟.땄 + ((double) this.땄 + (double) this.딟.딧) * (double) this.딦);
        딟3 -= 땓 * 떁4;
        딟4 -= 땥 * num8;
        딟7 += 땺 * 떁4;
        딟8 += 딝 * num9;
      }
      else
      {
        this.딟 = 땟.딟();
        this.땄 = 0.0f;
      }
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
      float 땓 = this.땓;
      float 땺 = this.땺;
      float 땥 = this.땥;
      float 딝 = this.딝;
      if (this.땄 && this.딟 != 딝.땃.딢)
      {
        float num1 = this.땤 * (this.딶 - (float) ((double) 떁.딶(this.땓, 딟3 - 딟1) + (double) this.딦 * (double) 딟4 - (double) this.땭 * (double) 딟2));
        float 땄 = this.땄;
        float num2 = obj0.딟.딟 * this.땃;
        this.땄 = 땴.딟(this.땄 + num1, -num2, num2);
        float num3 = this.땄 - 땄;
        떁 떁 = num3 * this.땓;
        float num4 = num3 * this.땭;
        float num5 = num3 * this.딦;
        딟1 -= 땓 * 떁;
        딟2 -= 땥 * num4;
        딟3 += 땺 * 떁;
        딟4 += 딝 * num5;
      }
      떁 떁1 = new 떁();
      떁1.딟 = (float) ((double) 떁.딶(this.땺, 딟3 - 딟1) + (double) this.떂 * (double) 딟4 - (double) this.떎 * (double) 딟2);
      떁1.땄 = 딟4 - 딟2;
      떁 떁2;
      float num6;
      떁 떁3;
      float num7;
      if (this.딟 && this.딟 != 딝.땃.딟)
      {
        float num8 = (float) ((double) 떁.딶(this.땓, 딟3 - 딟1) + (double) this.딦 * (double) 딟4 - (double) this.땭 * (double) 딟2);
        땟 땟1 = new 땟(떁1.딟, 떁1.땄, num8);
        땟 딟5 = this.딟;
        this.딟 += this.딟.딟(-땟1);
        if (this.딟 == 딝.땃.땄)
          this.딟.딧 = Math.Max(this.딟.딧, 0.0f);
        else if (this.딟 == 딝.땃.딧)
          this.딟.딧 = Math.Min(this.딟.딧, 0.0f);
        떁 떁4 = this.딟.딟(-떁1 - (this.딟.딧 - 딟5.딧) * new 떁(this.딟.딧.딟, this.딟.딧.땄)) + new 떁(딟5.딟, 딟5.땄);
        this.딟.딟 = 떁4.딟;
        this.딟.땄 = 떁4.땄;
        땟 땟2 = this.딟 - 딟5;
        떁 떁5 = 땟2.딟 * this.땺 + 땟2.딧 * this.땓;
        float num9 = (float) ((double) 땟2.딟 * (double) this.떎 + (double) 땟2.땄 + (double) 땟2.딧 * (double) this.땭);
        float num10 = (float) ((double) 땟2.딟 * (double) this.떂 + (double) 땟2.땄 + (double) 땟2.딧 * (double) this.딦);
        떁2 = 딟1 - 땓 * 떁5;
        num6 = 딟2 - 땥 * num9;
        떁3 = 딟3 + 땺 * 떁5;
        num7 = 딟4 + 딝 * num10;
      }
      else
      {
        떁 떁6 = this.딟.딟(-떁1);
        this.딟.딟 += 떁6.딟;
        this.딟.땄 += 떁6.땄;
        떁 떁7 = 떁6.딟 * this.땺;
        float num11 = 떁6.딟 * this.떎 + 떁6.땄;
        float num12 = 떁6.딟 * this.떂 + 떁6.땄;
        떁2 = 딟1 - 땓 * 떁7;
        num6 = 딟2 - 땥 * num11;
        떁3 = 딟3 + 땺 * 떁7;
        num7 = 딟4 + 딝 * num12;
        떁1.딟 = (float) ((double) 떁.딶(this.땺, 떁3 - 떁2) + (double) this.떂 * (double) num7 - (double) this.떎 * (double) num6);
        떁1.땄 = num7 - num6;
        if ((double) Math.Abs(떁1.딟) > 0.00999999977648258 || (double) Math.Abs(떁1.땄) > 0.00999999977648258)
        {
          ref 떁 local = ref 떁1;
          local.딟 = local.딟;
        }
      }
      obj0.딟[this.딟].딟 = 떁2;
      obj0.딟[this.딟].딟 = num6;
      obj0.딟[this.땄].딟 = 떁3;
      obj0.딟[this.땄].딟 = num7;
    }

    internal override bool 딧([In] ref 딤 obj0)
    {
      떁 딟1 = obj0.딟[this.딟].딟;
      float 딟2 = obj0.딟[this.딟].딟;
      떁 딟3 = obj0.딟[this.땄].딟;
      float 딟4 = obj0.딟[this.땄].딟;
      딥 딥1 = new 딥(딟2);
      딥 딥2 = new 딥(딟4);
      float 땓 = this.땓;
      float 땺 = this.땺;
      float 땥 = this.땥;
      float 딝 = this.딝;
      떁 떁1 = 땴.딟(딥1, this.딟 - this.땃);
      떁 떁2 = 땴.딟(딥2, this.땄 - this.딶);
      떁 떁3 = 딟3 + 떁2 - 딟1 - 떁1;
      떁 떁4 = 땴.딟(딥1, this.떂());
      float num1 = 땴.딟(떁3 + 떁1, 떁4);
      float num2 = 땴.딟(떁2, 떁4);
      떁 떁5 = 땴.딟(딥1, this.딢);
      float num3 = 땴.딟(떁3 + 떁1, 떁5);
      float num4 = 땴.딟(떁2, 떁5);
      떁 떁6 = new 떁();
      떁6.딟 = 떁.딶(떁5, 떁3);
      떁6.땄 = 딟4 - 딟2 - this.딟;
      float val1 = Math.Abs(떁6.딟);
      float num5 = Math.Abs(떁6.땄);
      bool flag = false;
      float num6 = 0.0f;
      if (this.딟)
      {
        float num7 = 떁.딶(떁4, 떁3);
        if ((double) Math.Abs(this.딢 - this.딧) < 0.00999999977648258)
        {
          num6 = 땴.딟(num7, -0.2f, 0.2f);
          val1 = Math.Max(val1, Math.Abs(num7));
          flag = true;
        }
        else if ((double) num7 <= (double) this.딧)
        {
          num6 = 땴.딟((float) ((double) num7 - (double) this.딧 + 0.00499999988824129), -0.2f, 0.0f);
          val1 = Math.Max(val1, this.딧 - num7);
          flag = true;
        }
        else if ((double) num7 >= (double) this.딢)
        {
          num6 = 땴.딟((float) ((double) num7 - (double) this.딢 - 0.00499999988824129), 0.0f, 0.2f);
          val1 = Math.Max(val1, num7 - this.딢);
          flag = true;
        }
      }
      땟 땟;
      if (flag)
      {
        float num8 = (float) ((double) 땓 + (double) 땺 + (double) 땥 * (double) num3 * (double) num3 + (double) 딝 * (double) num4 * (double) num4);
        float num9 = (float) ((double) 땥 * (double) num3 + (double) 딝 * (double) num4);
        float num10 = (float) ((double) 땥 * (double) num3 * (double) num1 + (double) 딝 * (double) num4 * (double) num2);
        float num11 = 땥 + 딝;
        if ((double) num11 == 0.0)
          num11 = 1f;
        float num12 = (float) ((double) 땥 * (double) num1 + (double) 딝 * (double) num2);
        float num13 = (float) ((double) 땓 + (double) 땺 + (double) 땥 * (double) num1 * (double) num1 + (double) 딝 * (double) num2 * (double) num2);
        땟 = new 땻()
        {
          딟 = new 땟(num8, num9, num10),
          땄 = new 땟(num9, num11, num12),
          딧 = new 땟(num10, num12, num13)
        }.딟(-new 땟() { 딟 = 떁6.딟, 땄 = 떁6.땄, 딧 = num6 });
      }
      else
      {
        float num14 = (float) ((double) 땓 + (double) 땺 + (double) 땥 * (double) num3 * (double) num3 + (double) 딝 * (double) num4 * (double) num4);
        float num15 = (float) ((double) 땥 * (double) num3 + (double) 딝 * (double) num4);
        float num16 = 땥 + 딝;
        if ((double) num16 == 0.0)
          num16 = 1f;
        떁 떁7 = new 땳()
        {
          딟 = new 떁(num14, num15),
          땄 = new 떁(num15, num16)
        }.딟(-떁6);
        땟 = new 땟();
        땟.딟 = 떁7.딟;
        땟.땄 = 떁7.땄;
        땟.딧 = 0.0f;
      }
      떁 떁8 = 땟.딟 * 떁5 + 땟.딧 * 떁4;
      float num17 = (float) ((double) 땟.딟 * (double) num3 + (double) 땟.땄 + (double) 땟.딧 * (double) num1);
      float num18 = (float) ((double) 땟.딟 * (double) num4 + (double) 땟.땄 + (double) 땟.딧 * (double) num2);
      떁 떁9 = 딟1 - 땓 * 떁8;
      float num19 = 딟2 - 땥 * num17;
      떁 떁10 = 딟3 + 땺 * 떁8;
      float num20 = 딟4 + 딝 * num18;
      obj0.딟[this.딟].딟 = 떁9;
      obj0.딟[this.딟].딟 = num19;
      obj0.딟[this.땄].딟 = 떁10;
      obj0.딟[this.땄].딟 = num20;
      return (double) val1 <= 0.00499999988824129 && (double) num5 <= 0.0349065884947777;
    }
  }
}
