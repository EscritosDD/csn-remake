// Decompiled with JetBrains decompiler
// Type: 땺.땶
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using FarseerPhysics.Collision;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using 땥;

namespace 땺
{
  public class 땶 : 땏
  {
    internal 떁 딟;

    public 땶([In] float obj0, [In] float obj1)
      : base(obj1)
    {
      this.딟(땙.땄);
      this.땄 = obj0;
      this.딟 = 떁.딟();
      this.딧();
    }

    internal 땶()
      : base(0.0f)
    {
      this.딟(땙.땄);
      this.땄 = 0.0f;
      this.딟 = 떁.딟();
    }

    [SpecialName]
    public override int 딟() => 1;

    [SpecialName]
    public 떁 딢() => this.딟;

    [SpecialName]
    public void 딟([In] 떁 obj0)
    {
      this.딟 = obj0;
      this.딧();
    }

    public override 땏 땄()
    {
      땶 땶 = new 땶();
      땶.땄 = this.딶();
      ((땏) 땶).딟 = base.딟;
      땶.딟 = this.딟;
      땶.딟(base.딢());
      ((땏) 땶).딟 = base.딟;
      return (땏) 땶;
    }

    public override bool 딟([In] ref 땥.떓 obj0, [In] ref 떁 obj1)
    {
      떁 떁1 = obj0.딟 + 땥.땴.딟(obj0.딟, this.딢());
      떁 떁2 = obj1 - 떁1;
      return (double) 떁.딶(떁2, 떁2) <= (double) this.딶() * (double) this.딶();
    }

    public override bool 딟(out 딯 _param1, [In] ref 딮 obj1, [In] ref 땥.떓 obj2, [In] int obj3)
    {
      _param1 = new 딯();
      떁 떁1 = obj2.딟 + 땥.땴.딟(obj2.딟, this.딢());
      떁 떁2 = obj1.딟 - 떁1;
      float num1 = 떁.딶(떁2, 떁2) - this.딶() * this.딶();
      떁 떁3 = obj1.땄 - obj1.딟;
      float num2 = 떁.딶(떁2, 떁3);
      float num3 = 떁.딶(떁3, 떁3);
      float num4 = (float) ((double) num2 * (double) num2 - (double) num3 * (double) num1);
      if ((double) num4 < 0.0 || (double) num3 < 1.19209289550781E-07)
        return false;
      float num5 = (float) -((double) num2 + Math.Sqrt((double) num4));
      if (0.0 > (double) num5 || (double) num5 > (double) obj1.딟 * (double) num3)
        return false;
      float num6 = num5 / num3;
      _param1.딟 = num6;
      _param1.딟 = 떁2 + num6 * 떁3;
      _param1.딟.땓();
      return true;
    }

    public override void 딟(out AABB _param1, [In] ref 땥.떓 obj1, [In] int obj2)
    {
      떁 떁 = obj1.딟 + 땥.땴.딟(obj1.딟, this.딢());
      _param1.LowerBound = new 떁(떁.딟 - this.딶(), 떁.땄 - this.딶());
      _param1.UpperBound = new 떁(떁.딟 + this.딶(), 떁.땄 + this.딶());
    }

    protected override sealed void 딧()
    {
      float num = 3.141593f * this.딶() * this.딶();
      base.딟.딟 = num;
      base.딟.딧 = this.땃() * num;
      base.딟.딟 = this.딢();
      base.딟.땄 = base.딟.딧 * (0.5f * this.딶() * this.딶() + 떁.딶(this.딢(), this.딢()));
    }

    public bool 딟([In] 땶 obj0) => (double) this.딶() == (double) obj0.딶() && this.딢() == obj0.딢();

    public override float 딟([In] 떁 obj0, [In] float obj1, [In] 땥.떓 obj2, out 떁 _param4)
    {
      _param4 = 떁.딟();
      떁 떁 = 땥.땴.딟(ref obj2, this.딢());
      float num1 = (float) -((double) 떁.딶(obj0, 떁) - (double) obj1);
      if ((double) num1 < -(double) this.딶() + 1.19209289550781E-07)
        return 0.0f;
      if ((double) num1 > (double) this.딶())
      {
        _param4 = 떁;
        return 3.141593f * this.딶() * this.딶();
      }
      float num2 = this.딶() * this.딶();
      float num3 = num1 * num1;
      float num4 = num2 * (float) (Math.Asin((double) num1 / (double) this.딶()) + 1.57079637050629 + (double) num1 * Math.Sqrt((double) num2 - (double) num3));
      float num5 = -0.6666667f * (float) Math.Pow((double) num2 - (double) num3, 1.5) / num4;
      _param4.딟 = 떁.딟 + obj0.딟 * num5;
      _param4.땄 = 떁.땄 + obj0.땄 * num5;
      return num4;
    }
  }
}
