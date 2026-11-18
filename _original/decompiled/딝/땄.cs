// Decompiled with JetBrains decompiler
// Type: 딝.땄
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using 땥;

namespace 딝
{
  public class 땄 : 딝.땺
  {
    public 떁 딟;
    public 떁 땄;
    private 땥.땟 딟;
    private new float 딟;
    protected float 땄;
    protected float 딧;
    private float 딢;
    private new int 딟;
    private int 땄;
    private 떁 딧;
    private 떁 딢;
    private 떁 땃;
    private 떁 딶;
    private float 땃;
    private float 딶;
    private float 땓;
    private float 땺;
    private 땥.땻 딟;

    internal 땄() => this.딟(딝.딢.땓);

    public 땄([In] 딺 obj0, [In] 딺 obj1, [In] 떁 obj2, [In] 떁 obj3)
      : base(obj0, obj1)
    {
      this.딟(딝.딢.땓);
      this.딟 = obj2;
      this.땄 = obj3;
      // ISSUE: reference to a compiler-generated method
      this.딧(this.땃().땢() - this.딢().땢());
    }

    [SpecialName]
    public override 떁 딟() => this.딢().딶(this.딟);

    [SpecialName]
    public override 떁 땄() => this.땃().딶(this.땄);

    [SpecialName]
    public override void 딟([In] 떁 obj0)
    {
    }

    [CompilerGenerated]
    [SpecialName]
    public float 딧() => this.땥;

    public override 떁 딟([In] float obj0) => obj0 * new 떁(this.딟.딟, this.딟.땄);

    public override float 땄([In] float obj0) => obj0 * this.딟.딧;

    internal override void 딟([In] ref 딤 obj0)
    {
      this.딟 = this.딢().딧;
      this.땄 = this.땃().딧;
      this.땃 = this.딢().딟.딧;
      this.딶 = this.땃().딟.딧;
      this.땃 = this.딢().딧;
      this.딶 = this.땃().딧;
      this.땓 = this.딢().땄;
      this.땺 = this.땃().땄;
      float 딟1 = obj0.딟[this.딟].딟;
      떁 딟2 = obj0.딟[this.딟].딟;
      float 딟3 = obj0.딟[this.딟].딟;
      float 딟4 = obj0.딟[this.땄].딟;
      떁 딟5 = obj0.딟[this.땄].딟;
      float 딟6 = obj0.딟[this.땄].딟;
      땥.딥 딥1 = new 땥.딥(딟1);
      땥.딥 딥2 = new 땥.딥(딟4);
      this.딧 = 땥.땴.딟(딥1, this.딟 - this.땃);
      this.딢 = 땥.땴.딟(딥2, this.땄 - this.딶);
      float 땃 = this.땃;
      float 딶 = this.딶;
      float 땓 = this.땓;
      float 땺 = this.땺;
      땥.땻 땻 = new 땥.땻()
      {
        딟 = {
          딟 = (float) ((double) 땃 + (double) 딶 + (double) this.딧.땄 * (double) this.딧.땄 * (double) 땓 + (double) this.딢.땄 * (double) this.딢.땄 * (double) 땺)
        },
        땄 = {
          딟 = (float) (-(double) this.딧.땄 * (double) this.딧.딟 * (double) 땓 - (double) this.딢.땄 * (double) this.딢.딟 * (double) 땺)
        },
        딧 = {
          딟 = (float) (-(double) this.딧.땄 * (double) 땓 - (double) this.딢.땄 * (double) 땺)
        }
      };
      땻.딟.땄 = 땻.땄.딟;
      땻.땄.땄 = (float) ((double) 땃 + (double) 딶 + (double) this.딧.딟 * (double) this.딧.딟 * (double) 땓 + (double) this.딢.딟 * (double) this.딢.딟 * (double) 땺);
      땻.딧.땄 = (float) ((double) this.딧.딟 * (double) 땓 + (double) this.딢.딟 * (double) 땺);
      땻.딟.딧 = 땻.딧.딟;
      땻.땄.딧 = 땻.딧.땄;
      땻.딧.딧 = 땓 + 땺;
      if ((double) this.땄 > 0.0)
      {
        땻.딟(ref this.딟);
        float num1 = 땓 + 땺;
        float num2 = (double) num1 <= 0.0 ? 0.0f : 1f / num1;
        float num3 = 딟4 - 딟1 - this.딧();
        float num4 = 6.283185f * this.땄;
        float num5 = 2f * num2 * this.딧 * num4;
        float num6 = num2 * num4 * num4;
        float 딟7 = obj0.딟.딟;
        this.딟 = 딟7 * (num5 + 딟7 * num6);
        this.딟 = (double) this.딟 == 0.0 ? 0.0f : 1f / this.딟;
        this.딢 = num3 * 딟7 * num6 * this.딟;
        float num7 = num1 + this.딟;
        this.딟.딧.딧 = (double) num7 == 0.0 ? 0.0f : 1f / num7;
      }
      else
      {
        땻.땄(ref this.딟);
        this.딟 = 0.0f;
        this.딢 = 0.0f;
      }
      if (딝.땥.딧)
      {
        this.딟 *= obj0.딟.땄;
        떁 떁 = new 떁(this.딟.딟, this.딟.땄);
        딟2 -= 땃 * 떁;
        딟3 -= 땓 * (땥.땴.딟(this.딧, 떁) + this.딟.딧);
        딟5 += 딶 * 떁;
        딟6 += 땺 * (땥.땴.딟(this.딢, 떁) + this.딟.딧);
      }
      else
        this.딟 = 땥.땟.딟();
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
      float 땃 = this.땃;
      float 딶 = this.딶;
      float 땓 = this.땓;
      float 땺 = this.땺;
      떁 떁1;
      float num1;
      떁 떁2;
      float num2;
      if ((double) this.땄 > 0.0)
      {
        float num3 = (float) (-(double) this.딟.딧.딧 * ((double) (딟4 - 딟2) + (double) this.딢 + (double) this.딟 * (double) this.딟.딧));
        this.딟.딧 += num3;
        float num4 = 딟2 - 땓 * num3;
        float num5 = 딟4 + 땺 * num3;
        떁 떁3 = -땥.땴.딟(this.딟, 딟3 + 땥.땴.딟(num5, this.딢) - 딟1 - 땥.땴.딟(num4, this.딧));
        this.딟.딟 += 떁3.딟;
        this.딟.땄 += 떁3.땄;
        떁 떁4 = 떁3;
        떁1 = 딟1 - 땃 * 떁4;
        num1 = num4 - 땓 * 땥.땴.딟(this.딧, 떁4);
        떁2 = 딟3 + 딶 * 떁4;
        num2 = num5 + 땺 * 땥.땴.딟(this.딢, 떁4);
      }
      else
      {
        떁 떁5 = 딟3 + 땥.땴.딟(딟4, this.딢) - 딟1 - 땥.땴.딟(딟2, this.딧);
        float num6 = 딟4 - 딟2;
        땥.땟 땟 = -땥.땴.딟(this.딟, new 땥.땟(떁5.딟, 떁5.땄, num6));
        this.딟 += 땟;
        떁 떁6 = new 떁(땟.딟, 땟.땄);
        떁1 = 딟1 - 땃 * 떁6;
        num1 = 딟2 - 땓 * (땥.땴.딟(this.딧, 떁6) + 땟.딧);
        떁2 = 딟3 + 딶 * 떁6;
        num2 = 딟4 + 땺 * (땥.땴.딟(this.딢, 떁6) + 땟.딧);
      }
      obj0.딟[this.딟].딟 = 떁1;
      obj0.딟[this.딟].딟 = num1;
      obj0.딟[this.땄].딟 = 떁2;
      obj0.딟[this.땄].딟 = num2;
    }

    internal override bool 딧([In] ref 딤 obj0)
    {
      떁 딟1 = obj0.딟[this.딟].딟;
      float 딟2 = obj0.딟[this.딟].딟;
      떁 딟3 = obj0.딟[this.땄].딟;
      float 딟4 = obj0.딟[this.땄].딟;
      땥.딥 딥1 = new 땥.딥(딟2);
      땥.딥 딥2 = new 땥.딥(딟4);
      float 땃 = this.땃;
      float 딶 = this.딶;
      float 땓 = this.땓;
      float 땺 = this.땺;
      떁 떁1 = 땥.땴.딟(딥1, this.딟 - this.땃);
      떁 떁2 = 땥.땴.딟(딥2, this.땄 - this.딶);
      땥.땻 땻 = new 땥.땻()
      {
        딟 = {
          딟 = (float) ((double) 땃 + (double) 딶 + (double) 떁1.땄 * (double) 떁1.땄 * (double) 땓 + (double) 떁2.땄 * (double) 떁2.땄 * (double) 땺)
        },
        땄 = {
          딟 = (float) (-(double) 떁1.땄 * (double) 떁1.딟 * (double) 땓 - (double) 떁2.땄 * (double) 떁2.딟 * (double) 땺)
        },
        딧 = {
          딟 = (float) (-(double) 떁1.땄 * (double) 땓 - (double) 떁2.땄 * (double) 땺)
        }
      };
      땻.딟.땄 = 땻.땄.딟;
      땻.땄.땄 = (float) ((double) 땃 + (double) 딶 + (double) 떁1.딟 * (double) 떁1.딟 * (double) 땓 + (double) 떁2.딟 * (double) 떁2.딟 * (double) 땺);
      땻.딧.땄 = (float) ((double) 떁1.딟 * (double) 땓 + (double) 떁2.딟 * (double) 땺);
      땻.딟.딧 = 땻.딧.딟;
      땻.땄.딧 = 땻.딧.땄;
      땻.딧.딧 = 땓 + 땺;
      float num1;
      float num2;
      떁 떁3;
      float num3;
      떁 떁4;
      float num4;
      if ((double) this.땄 > 0.0)
      {
        떁 떁5 = 딟3 + 떁2 - 딟1 - 떁1;
        num1 = 떁5.땃();
        num2 = 0.0f;
        떁 떁6 = -땻.딟(떁5);
        떁3 = 딟1 - 땃 * 떁6;
        num3 = 딟2 - 땓 * 땥.땴.딟(떁1, 떁6);
        떁4 = 딟3 + 딶 * 떁6;
        num4 = 딟4 + 땺 * 땥.땴.딟(떁2, 떁6);
      }
      else
      {
        떁 떁7 = 딟3 + 떁2 - 딟1 - 떁1;
        float num5 = 딟4 - 딟2 - this.딧();
        num1 = 떁7.땃();
        num2 = Math.Abs(num5);
        땥.땟 땟1 = new 땥.땟(떁7.딟, 떁7.땄, num5);
        땥.땟 땟2 = -땻.딟(땟1);
        떁 떁8 = new 떁(땟2.딟, 땟2.땄);
        떁3 = 딟1 - 땃 * 떁8;
        num3 = 딟2 - 땓 * (땥.땴.딟(떁1, 떁8) + 땟2.딧);
        떁4 = 딟3 + 딶 * 떁8;
        num4 = 딟4 + 땺 * (땥.땴.딟(떁2, 떁8) + 땟2.딧);
      }
      obj0.딟[this.딟].딟 = 떁3;
      obj0.딟[this.딟].딟 = num3;
      obj0.딟[this.땄].딟 = 떁4;
      obj0.딟[this.땄].딟 = num4;
      return (double) num1 <= 0.00499999988824129 && (double) num2 <= 0.0349065884947777;
    }
  }
}
