// Decompiled with JetBrains decompiler
// Type: 땥.땸
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땥
{
  public class 땸 : 딝.땺
  {
    private 딝.딢 딟;
    private 딝.딢 땄;
    private 딺 딟;
    private 딺 땄;
    private 떁 딟;
    private 떁 땄;
    private 떁 딧;
    private 떁 딢;
    private 떁 땃;
    private 떁 딶;
    private new float 딟;
    private float 땄;
    private float 딧;
    private float 딢;
    private float 땃;
    private new int 딟;
    private int 땄;
    private int 딧;
    private int 딢;
    private 떁 땓;
    private 떁 땺;
    private 떁 땥;
    private 떁 딝;
    private float 딶;
    private float 땓;
    private float 땺;
    private float 땥;
    private float 딝;
    private float 떎;
    private float 떂;
    private float 땭;
    private 떁 떎;
    private 떁 떂;
    private float 딦;
    private float 땤;
    private float 땽;
    private float 땋;
    private float 땲;

    public 땸([In] 딝.땺 obj0, [In] 딝.땺 obj1, [In] float obj2)
      : base(obj0.딢(), obj0.땃())
    {
      this.딟(딝.딢.땃);
      this.딟(obj0);
      this.땄(obj1);
      this.딧(obj2);
      this.딟 = obj0.딧();
      this.땄 = obj1.딧();
      this.딟 = this.딢().딢();
      this.딟(this.딢().땃());
      떓 딟1 = base.딢().딟;
      float 딟2 = base.딢().딟.딟;
      떓 딟3 = this.딟.딟;
      float 딟4 = this.딟.딟.딟;
      float num1;
      if (this.딟 == 딝.딢.딟)
      {
        떒 떒 = (떒) obj0;
        this.딧 = 떒.딟;
        this.딟 = 떒.땄;
        this.딟 = 떒.딧();
        this.땃 = 떁.딟();
        num1 = 딟2 - 딟4 - this.딟;
      }
      else
      {
        땬 땬 = (땬) obj0;
        this.딧 = 땬.딟;
        this.딟 = 땬.땄;
        this.딟 = 땬.땭();
        this.땃 = 땬.떂();
        떁 딧 = this.딧;
        num1 = 떁.딶(땴.땄(딟3.딟, 땴.딟(딟1.딟, this.딟) + (딟1.딟 - 딟3.딟)) - 딧, this.땃);
      }
      this.땄 = this.땃().딢();
      this.땄(this.땃().땃());
      떓 딟5 = base.땃().딟;
      float 딟6 = base.땃().딟.딟;
      떓 딟7 = this.땄.딟;
      float 딟8 = this.땄.딟.딟;
      float num2;
      if (this.땄 == 딝.딢.딟)
      {
        떒 떒 = (떒) obj1;
        this.딢 = 떒.딟;
        this.땄 = 떒.땄;
        this.땄 = 떒.딧();
        this.딶 = 떁.딟();
        num2 = 딟6 - 딟8 - this.땄;
      }
      else
      {
        땬 땬 = (땬) obj1;
        this.딢 = 땬.딟;
        this.땄 = 땬.땄;
        this.땄 = 땬.땭();
        this.딶 = 땬.떂();
        떁 딢 = this.딢;
        num2 = 떁.딶(땴.땄(딟7.딟, 땴.딟(딟5.딟, this.땄) + (딟5.딟 - 딟7.딟)) - 딢, this.딶);
      }
      this.딢 = obj2;
      this.딧 = num1 + this.딢 * num2;
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
    public new void 딧([In] float obj0) => this.딢 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public 딝.땺 딢() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] 딝.땺 obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public 딝.땺 땃() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public void 땄([In] 딝.땺 obj0) => this.땄 = obj0;

    public override 떁 딟([In] float obj0)
    {
      떁 떁 = this.땃 * this.떎;
      return obj0 * 떁;
    }

    public override float 땄([In] float obj0)
    {
      float num = this.땃 * this.딦;
      return obj0 * num;
    }

    internal override void 딟([In] ref 딤 obj0)
    {
      this.딟 = base.딢().딧;
      this.땄 = base.땃().딧;
      this.딧 = this.딟.딧;
      this.딢 = this.땄.딧;
      this.땓 = base.딢().딟.딧;
      this.땺 = base.땃().딟.딧;
      this.땥 = this.딟.딟.딧;
      this.딝 = this.땄.딟.딧;
      this.딶 = base.딢().딧;
      this.땓 = base.땃().딧;
      this.땺 = this.딟.딧;
      this.땥 = this.땄.딧;
      this.딝 = base.딢().땄;
      this.떎 = base.땃().땄;
      this.떂 = this.딟.땄;
      this.땭 = this.땄.땄;
      float 딟1 = obj0.딟[this.딟].딟;
      떁 딟2 = obj0.딟[this.딟].딟;
      float 딟3 = obj0.딟[this.딟].딟;
      float 딟4 = obj0.딟[this.땄].딟;
      떁 딟5 = obj0.딟[this.땄].딟;
      float 딟6 = obj0.딟[this.땄].딟;
      float 딟7 = obj0.딟[this.딧].딟;
      떁 딟8 = obj0.딟[this.딧].딟;
      float 딟9 = obj0.딟[this.딧].딟;
      float 딟10 = obj0.딟[this.딢].딟;
      떁 딟11 = obj0.딟[this.딢].딟;
      float 딟12 = obj0.딟[this.딢].딟;
      딥 딥1 = new 딥(딟1);
      딥 딥2 = new 딥(딟4);
      딥 딥3 = new 딥(딟7);
      딥 딥4 = new 딥(딟10);
      this.땲 = 0.0f;
      if (this.딟 == 딝.딢.딟)
      {
        this.떎 = 떁.딟();
        this.딦 = 1f;
        this.땽 = 1f;
        this.땲 += this.딝 + this.떂;
      }
      else
      {
        떁 떁1 = 땴.딟(딥3, this.땃);
        떁 떁2 = 땴.딟(딥3, this.딧 - this.땥);
        떁 떁3 = 땴.딟(딥1, this.딟 - this.땓);
        this.떎 = 떁1;
        this.땽 = 땴.딟(떁2, 떁1);
        this.딦 = 땴.딟(떁3, 떁1);
        this.땲 += (float) ((double) this.땺 + (double) this.딶 + (double) this.떂 * (double) this.땽 * (double) this.땽 + (double) this.딝 * (double) this.딦 * (double) this.딦);
      }
      if (this.땄 == 딝.딢.딟)
      {
        this.떂 = 떁.딟();
        this.땤 = this.딢;
        this.땋 = this.딢;
        this.땲 += (float) ((double) this.딢 * (double) this.딢 * ((double) this.떎 + (double) this.땭));
      }
      else
      {
        떁 떁4 = 땴.딟(딥4, this.딶);
        떁 떁5 = 땴.딟(딥4, this.딢 - this.딝);
        떁 떁6 = 땴.딟(딥2, this.땄 - this.땺);
        this.떂 = this.딢 * 떁4;
        this.땋 = this.딢 * 땴.딟(떁5, 떁4);
        this.땤 = this.딢 * 땴.딟(떁6, 떁4);
        this.땲 += (float) ((double) this.딢 * (double) this.딢 * ((double) this.땥 + (double) this.땓) + (double) this.땭 * (double) this.땋 * (double) this.땋 + (double) this.떎 * (double) this.땤 * (double) this.땤);
      }
      this.땲 = (double) this.땲 <= 0.0 ? 0.0f : 1f / this.땲;
      if (딝.땥.딧)
      {
        딟2 += this.딶 * this.땃 * this.떎;
        딟3 += this.딝 * this.땃 * this.딦;
        딟5 += this.땓 * this.땃 * this.떂;
        딟6 += this.떎 * this.땃 * this.땤;
        딟8 -= this.땺 * this.땃 * this.떎;
        딟9 -= this.떂 * this.땃 * this.땽;
        딟11 -= this.땥 * this.땃 * this.떂;
        딟12 -= this.땭 * this.땃 * this.땋;
      }
      else
        this.땃 = 0.0f;
      obj0.딟[this.딟].딟 = 딟2;
      obj0.딟[this.딟].딟 = 딟3;
      obj0.딟[this.땄].딟 = 딟5;
      obj0.딟[this.땄].딟 = 딟6;
      obj0.딟[this.딧].딟 = 딟8;
      obj0.딟[this.딧].딟 = 딟9;
      obj0.딟[this.딢].딟 = 딟11;
      obj0.딟[this.딢].딟 = 딟12;
    }

    internal override void 땄([In] ref 딤 obj0)
    {
      떁 딟1 = obj0.딟[this.딟].딟;
      float 딟2 = obj0.딟[this.딟].딟;
      떁 딟3 = obj0.딟[this.땄].딟;
      float 딟4 = obj0.딟[this.땄].딟;
      떁 딟5 = obj0.딟[this.딧].딟;
      float 딟6 = obj0.딟[this.딧].딟;
      떁 딟7 = obj0.딟[this.딢].딟;
      float 딟8 = obj0.딟[this.딢].딟;
      float num1 = -this.땲 * (떁.딶(this.떎, 딟1 - 딟5) + 떁.딶(this.떂, 딟3 - 딟7) + (float) ((double) this.딦 * (double) 딟2 - (double) this.땽 * (double) 딟6 + ((double) this.땤 * (double) 딟4 - (double) this.땋 * (double) 딟8)));
      this.땃 += num1;
      떁 떁1 = 딟1 + this.딶 * num1 * this.떎;
      float num2 = 딟2 + this.딝 * num1 * this.딦;
      떁 떁2 = 딟3 + this.땓 * num1 * this.떂;
      float num3 = 딟4 + this.떎 * num1 * this.땤;
      떁 떁3 = 딟5 - this.땺 * num1 * this.떎;
      float num4 = 딟6 - this.떂 * num1 * this.땽;
      떁 떁4 = 딟7 - this.땥 * num1 * this.떂;
      float num5 = 딟8 - this.땭 * num1 * this.땋;
      obj0.딟[this.딟].딟 = 떁1;
      obj0.딟[this.딟].딟 = num2;
      obj0.딟[this.땄].딟 = 떁2;
      obj0.딟[this.땄].딟 = num3;
      obj0.딟[this.딧].딟 = 떁3;
      obj0.딟[this.딧].딟 = num4;
      obj0.딟[this.딢].딟 = 떁4;
      obj0.딟[this.딢].딟 = num5;
    }

    internal override bool 딧([In] ref 딤 obj0)
    {
      떁 딟1 = obj0.딟[this.딟].딟;
      float 딟2 = obj0.딟[this.딟].딟;
      떁 딟3 = obj0.딟[this.땄].딟;
      float 딟4 = obj0.딟[this.땄].딟;
      떁 딟5 = obj0.딟[this.딧].딟;
      float 딟6 = obj0.딟[this.딧].딟;
      떁 딟7 = obj0.딟[this.딢].딟;
      float 딟8 = obj0.딟[this.딢].딟;
      딥 딥1 = new 딥(딟2);
      딥 딥2 = new 딥(딟4);
      딥 딥3 = new 딥(딟6);
      딥 딥4 = new 딥(딟8);
      float num1 = 0.0f;
      float num2 = 0.0f;
      떁 떁1;
      float num3;
      float num4;
      float num5;
      float num6;
      if (this.딟 == 딝.딢.딟)
      {
        떁1 = 떁.딟();
        num3 = 1f;
        num4 = 1f;
        num5 = num2 + (this.딝 + this.떂);
        num6 = 딟2 - 딟6 - this.딟;
      }
      else
      {
        떁 떁2 = 땴.딟(딥3, this.땃);
        떁 떁3 = 땴.딟(딥3, this.딧 - this.땥);
        떁 떁4 = 땴.딟(딥1, this.딟 - this.땓);
        떁1 = 떁2;
        num4 = 땴.딟(떁3, 떁2);
        num3 = 땴.딟(떁4, 떁2);
        num5 = num2 + (float) ((double) this.땺 + (double) this.딶 + (double) this.떂 * (double) num4 * (double) num4 + (double) this.딝 * (double) num3 * (double) num3);
        떁 떁5 = this.딧 - this.땥;
        num6 = 떁.딶(땴.땄(딥3, 떁4 + (딟1 - 딟5)) - 떁5, this.땃);
      }
      떁 떁6;
      float num7;
      float num8;
      float num9;
      float num10;
      if (this.땄 == 딝.딢.딟)
      {
        떁6 = 떁.딟();
        num7 = this.딢;
        num8 = this.딢;
        num9 = num5 + (float) ((double) this.딢 * (double) this.딢 * ((double) this.떎 + (double) this.땭));
        num10 = 딟4 - 딟8 - this.땄;
      }
      else
      {
        떁 떁7 = 땴.딟(딥4, this.딶);
        떁 떁8 = 땴.딟(딥4, this.딢 - this.딝);
        떁 떁9 = 땴.딟(딥2, this.땄 - this.땺);
        떁6 = this.딢 * 떁7;
        num8 = this.딢 * 땴.딟(떁8, 떁7);
        num7 = this.딢 * 땴.딟(떁9, 떁7);
        num9 = num5 + (float) ((double) this.딢 * (double) this.딢 * ((double) this.땥 + (double) this.땓) + (double) this.땭 * (double) num8 * (double) num8 + (double) this.떎 * (double) num7 * (double) num7);
        떁 떁10 = this.딢 - this.딝;
        num10 = 떁.딶(땴.땄(딥4, 떁9 + (딟3 - 딟7)) - 떁10, this.딶);
      }
      float num11 = num6 + this.딢 * num10 - this.딧;
      float num12 = 0.0f;
      if ((double) num9 > 0.0)
        num12 = -num11 / num9;
      떁 떁11 = 딟1 + this.딶 * num12 * 떁1;
      float num13 = 딟2 + this.딝 * num12 * num3;
      떁 떁12 = 딟3 + this.땓 * num12 * 떁6;
      float num14 = 딟4 + this.떎 * num12 * num7;
      떁 떁13 = 딟5 - this.땺 * num12 * 떁1;
      float num15 = 딟6 - this.떂 * num12 * num4;
      떁 떁14 = 딟7 - this.땥 * num12 * 떁6;
      float num16 = 딟8 - this.땭 * num12 * num8;
      obj0.딟[this.딟].딟 = 떁11;
      obj0.딟[this.딟].딟 = num13;
      obj0.딟[this.땄].딟 = 떁12;
      obj0.딟[this.땄].딟 = num14;
      obj0.딟[this.딧].딟 = 떁13;
      obj0.딟[this.딧].딟 = num15;
      obj0.딟[this.딢].딟 = 떁14;
      obj0.딟[this.딢].딟 = num16;
      return (double) num1 < 0.00499999988824129;
    }
  }
}
