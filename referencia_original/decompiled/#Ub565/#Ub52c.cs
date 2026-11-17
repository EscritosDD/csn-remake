// Decompiled with JetBrains decompiler
// Type: 땥.딬
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땥
{
  public class 딬 : 딝.땺
  {
    public 떁 딟;
    public 떁 땄;
    private 떁 딧;
    private new float 딟;
    private new int 딟;
    private int 땄;
    private 떁 딢;
    private 떁 땃;
    private 떁 딶;
    private 떁 땓;
    private float 땄;
    private float 딧;
    private float 딢;
    private float 땃;
    private float 딶;
    private 땳 딟;

    internal 딬() => this.딟(딝.딢.땺);

    public 딬([In] 딺 obj0, [In] 딺 obj1, [In] 떁 obj2, [In] 떁 obj3)
      : base(obj0, obj1)
    {
      this.딟(딝.딢.땺);
      this.딟 = obj2;
      this.땄 = obj3;
    }

    [SpecialName]
    public override 떁 딟() => base.딢().딶(this.딟);

    [SpecialName]
    public override 떁 땄() => this.땃().딶(this.땄);

    [SpecialName]
    public override void 딟([In] 떁 obj0)
    {
    }

    [CompilerGenerated]
    [SpecialName]
    public float 딧() => this.땓;

    [CompilerGenerated]
    [SpecialName]
    public new void 딧([In] float obj0) => this.땓 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public float 딢() => this.땺;

    [CompilerGenerated]
    [SpecialName]
    public void 딢([In] float obj0) => this.땺 = obj0;

    public override 떁 딟([In] float obj0) => obj0 * this.딧;

    public override float 땄([In] float obj0) => obj0 * this.딟;

    internal override void 딟([In] ref 딤 obj0)
    {
      this.딟 = base.딢().딧;
      this.땄 = this.땃().딧;
      this.딶 = base.딢().딟.딧;
      this.땓 = this.땃().딟.딧;
      this.땄 = base.딢().딧;
      this.딧 = this.땃().딧;
      this.딢 = base.딢().땄;
      this.땃 = this.땃().땄;
      float 딟1 = obj0.딟[this.딟].딟;
      떁 딟2 = obj0.딟[this.딟].딟;
      float 딟3 = obj0.딟[this.딟].딟;
      float 딟4 = obj0.딟[this.땄].딟;
      떁 딟5 = obj0.딟[this.땄].딟;
      float 딟6 = obj0.딟[this.땄].딟;
      딥 딥1 = new 딥(딟1);
      딥 딥2 = new 딥(딟4);
      this.딢 = 땴.딟(딥1, this.딟 - this.딶);
      this.땃 = 땴.딟(딥2, this.땄 - this.땓);
      float 땄 = this.땄;
      float 딧 = this.딧;
      float 딢 = this.딢;
      float 땃 = this.땃;
      땳 땳 = new 땳()
      {
        딟 = {
          딟 = (float) ((double) 땄 + (double) 딧 + (double) 딢 * (double) this.딢.땄 * (double) this.딢.땄 + (double) 땃 * (double) this.땃.땄 * (double) this.땃.땄),
          땄 = (float) (-(double) 딢 * (double) this.딢.딟 * (double) this.딢.땄 - (double) 땃 * (double) this.땃.딟 * (double) this.땃.땄)
        }
      };
      땳.땄.딟 = 땳.딟.땄;
      땳.땄.땄 = (float) ((double) 땄 + (double) 딧 + (double) 딢 * (double) this.딢.딟 * (double) this.딢.딟 + (double) 땃 * (double) this.땃.딟 * (double) this.땃.딟);
      this.딟 = 땳.딟();
      this.딶 = 딢 + 땃;
      if ((double) this.딶 > 0.0)
        this.딶 = 1f / this.딶;
      if (딝.땥.딧)
      {
        this.딧 *= obj0.딟.땄;
        this.딟 *= obj0.딟.땄;
        떁 떁 = new 떁(this.딧.딟, this.딧.땄);
        딟2 -= 땄 * 떁;
        딟3 -= 딢 * (땴.딟(this.딢, 떁) + this.딟);
        딟5 += 딧 * 떁;
        딟6 += 땃 * (땴.딟(this.땃, 떁) + this.딟);
      }
      else
      {
        this.딧 = 떁.딟();
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
      float 땄 = this.땄;
      float 딧1 = this.딧;
      float 딢 = this.딢;
      float 땃 = this.땃;
      float 딟5 = obj0.딟.딟;
      float num1 = -this.딶 * (딟4 - 딟2);
      float 딟6 = this.딟;
      float num2 = 딟5 * this.딢();
      this.딟 = 땴.딟(this.딟 + num1, -num2, num2);
      float num3 = this.딟 - 딟6;
      float num4 = 딟2 - 딢 * num3;
      float num5 = 딟4 + 땃 * num3;
      떁 떁1 = -땴.딟(ref this.딟, 딟3 + 땴.딟(num5, this.땃) - 딟1 - 땴.딟(num4, this.딢));
      떁 딧2 = this.딧;
      this.딧 += 떁1;
      float num6 = 딟5 * this.딧();
      if ((double) this.딧.딶() > (double) num6 * (double) num6)
      {
        this.딧.땓();
        this.딧 *= num6;
      }
      떁 떁2 = this.딧 - 딧2;
      떁 떁3 = 딟1 - 땄 * 떁2;
      float num7 = num4 - 딢 * 땴.딟(this.딢, 떁2);
      떁 떁4 = 딟3 + 딧1 * 떁2;
      float num8 = num5 + 땃 * 땴.딟(this.땃, 떁2);
      obj0.딟[this.딟].딟 = 떁3;
      obj0.딟[this.딟].딟 = num7;
      obj0.딟[this.땄].딟 = 떁4;
      obj0.딟[this.땄].딟 = num8;
    }

    internal override bool 딧([In] ref 딤 obj0) => true;
  }
}
