// Decompiled with JetBrains decompiler
// Type: 땥.땊
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땥
{
  public class 땊 : 딝.땺
  {
    public new float 딟;
    public float 땄;
    public float 딧;
    private float 딢;
    private float 땃;
    private float 딶;
    private float 땓;

    public 땊([In] 딺 obj0)
      : base(obj0)
    {
      this.딟(딝.딢.땋);
      this.딧(0.0f);
      this.딟 = 0.2f;
      this.딧 = 0.0f;
      this.땄 = float.MaxValue;
    }

    [SpecialName]
    public float 딧() => this.땓;

    [SpecialName]
    public new void 딧([In] float obj0)
    {
      if ((double) obj0 == (double) this.땓)
        return;
      this.땓 = obj0;
      this.땥();
    }

    [SpecialName]
    public override 떁 딟() => this.딢().땼();

    [SpecialName]
    public override 떁 땄() => this.딢().땼();

    [SpecialName]
    public override void 딟([In] 떁 obj0)
    {
    }

    public override 떁 딟([In] float obj0) => 떁.딟();

    public override float 땄([In] float obj0) => 0.0f;

    internal override void 딟([In] ref 딤 obj0)
    {
      this.땃 = this.딢().딟.딟 - this.딧();
      this.딢 = -this.딟 * obj0.딟.딧 * this.땃;
      this.딶 = (1f - this.딧) / this.딢().땄;
    }

    internal override void 땄([In] ref 딤 obj0)
    {
      float num = (this.딢 - this.딢().땃()) * this.딶;
      딺 딺 = this.딢();
      딺.땄(딺.땃() + this.딢().땄 * (float) Math.Sign(num) * Math.Min(Math.Abs(num), this.땄));
    }

    internal override bool 딧([In] ref 딤 obj0) => true;
  }
}
