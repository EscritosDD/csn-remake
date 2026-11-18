// Decompiled with JetBrains decompiler
// Type: 땺.땖
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using FarseerPhysics.Collision;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using 땥;

namespace 땺
{
  public class 땖 : 땏
  {
    public bool 딟;
    public bool 땄;
    public 떁 딟;
    public 떁 땄;
    internal 떁 딧;
    internal 떁 딢;

    internal 땖()
      : base(0.0f)
    {
      this.딟(땙.딧);
      base.땄 = 0.01f;
    }

    public 땖([In] 떁 obj0, [In] 떁 obj1)
      : base(0.0f)
    {
      this.딟(땙.딧);
      base.땄 = 0.01f;
      this.딟(obj0, obj1);
    }

    [SpecialName]
    public override int 딟() => 1;

    [SpecialName]
    public 떁 딢() => this.딧;

    [SpecialName]
    public void 딟([In] 떁 obj0)
    {
      this.딧 = obj0;
      this.딧();
    }

    [SpecialName]
    public 떁 땃() => this.딢;

    [SpecialName]
    public void 땄([In] 떁 obj0)
    {
      this.딢 = obj0;
      this.딧();
    }

    public void 딟([In] 떁 obj0, [In] 떁 obj1)
    {
      this.딧 = obj0;
      this.딢 = obj1;
      this.딟 = false;
      this.땄 = false;
      this.딧();
    }

    public override 땏 땄()
    {
      땖 땖 = new 땖();
      ((땏) 땖).땄 = base.땄;
      ((땏) 땖).딟 = base.딟;
      땖.딟 = this.딟;
      땖.땄 = this.땄;
      땖.딟 = this.딟;
      땖.딧 = this.딧;
      땖.딢 = this.딢;
      땖.땄 = this.땄;
      ((땏) 땖).딟 = base.딟;
      return (땏) 땖;
    }

    public override bool 딟([In] ref 땥.떓 obj0, [In] ref 떁 obj1) => false;

    public override bool 딟(out 딯 _param1, [In] ref 딮 obj1, [In] ref 땥.떓 obj2, [In] int obj3)
    {
      _param1 = new 딯();
      떁 떁1 = 땥.땴.땄(obj2.딟, obj1.딟 - obj2.딟);
      떁 떁2 = 땥.땴.땄(obj2.딟, obj1.땄 - obj2.딟) - 떁1;
      떁 딧 = this.딧;
      떁 딢 = this.딢;
      떁 떁3 = 딢 - 딧;
      떁 떁4 = new 떁(떁3.땄, -떁3.딟);
      떁4.땓();
      float num1 = 떁.딶(떁4, 딧 - 떁1);
      float num2 = 떁.딶(떁4, 떁2);
      if ((double) num2 == 0.0)
        return false;
      float num3 = num1 / num2;
      if ((double) num3 < 0.0 || (double) obj1.딟 < (double) num3)
        return false;
      떁 떁5 = 떁1 + num3 * 떁2;
      떁 떁6 = 딢 - 딧;
      float num4 = 떁.딶(떁6, 떁6);
      if ((double) num4 == 0.0)
        return false;
      float num5 = 떁.딶(떁5 - 딧, 떁6) / num4;
      if ((double) num5 < 0.0 || 1.0 < (double) num5)
        return false;
      _param1.딟 = num3;
      _param1.딟 = (double) num1 <= 0.0 ? 떁4 : -떁4;
      return true;
    }

    public override void 딟(out AABB _param1, [In] ref 땥.떓 obj1, [In] int obj2)
    {
      떁 떁1 = 땥.땴.딟(ref obj1, this.딧);
      떁 떁2 = 땥.땴.딟(ref obj1, this.딢);
      떁 떁3 = 떁.땺(떁1, 떁2);
      떁 떁4 = 떁.땓(떁1, 떁2);
      떁 떁5 = new 떁(this.딶(), this.딶());
      _param1.LowerBound = 떁3 - 떁5;
      _param1.UpperBound = 떁4 + 떁5;
    }

    protected override void 딧() => base.딟.딟 = 0.5f * (this.딧 + this.딢);

    public override float 딟([In] 떁 obj0, [In] float obj1, [In] 땥.떓 obj2, out 떁 _param4)
    {
      _param4 = 떁.딟();
      return 0.0f;
    }

    public bool 딟([In] 땖 obj0) => this.딟 == obj0.딟 && this.땄 == obj0.땄 && this.딟 == obj0.딟 && this.딢() == obj0.딢() && this.땃() == obj0.땃() && this.땄 == obj0.땄;
  }
}
