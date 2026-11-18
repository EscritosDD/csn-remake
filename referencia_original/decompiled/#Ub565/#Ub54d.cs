// Decompiled with JetBrains decompiler
// Type: 땥.땍
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땥
{
  public class 땍 : 딝.땺
  {
    private 떁 딟;
    private new float 딟;
    private float 땄;
    private float 딧;
    private 떁 땄;
    private float 딢;
    private float 땃;
    private new int 딟;
    private int 땄;
    private 떁 딧;
    private 떁 딢;
    private float 딶;
    private float 땓;
    private 땳 딟;
    private 떁 땃;

    public 땍([In] 딺 obj0, [In] 떁 obj1)
      : base(obj0)
    {
      this.딟(딝.딢.떂);
      this.딢(5f);
      this.땃(0.7f);
      this.딧(1000f * obj0.딱());
      this.딟 = obj1;
      this.땄(땴.딟(base.딢().딟, obj1));
    }

    [CompilerGenerated]
    [SpecialName]
    public 떁 딧() => this.딶;

    [CompilerGenerated]
    [SpecialName]
    public void 땄([In] 떁 obj0) => this.딶 = obj0;

    [SpecialName]
    public override 떁 딟() => base.딢().딶(this.딧());

    [SpecialName]
    public override 떁 땄() => this.딟;

    [SpecialName]
    public override void 딟([In] 떁 obj0)
    {
      base.딢().딧(true);
      this.딟 = obj0;
    }

    [SpecialName]
    public float 딢() => this.딢;

    [SpecialName]
    public new void 딧([In] float obj0) => this.딢 = obj0;

    [SpecialName]
    public float 땃() => this.딟;

    [SpecialName]
    public void 딢([In] float obj0) => this.딟 = obj0;

    [SpecialName]
    public float 딶() => this.땄;

    [SpecialName]
    public void 땃([In] float obj0) => this.땄 = obj0;

    public override 떁 딟([In] float obj0) => obj0 * this.땄;

    public override float 땄([In] float obj0) => obj0 * 0.0f;

    internal override void 딟([In] ref 딤 obj0)
    {
      this.땄 = base.딢().딧;
      this.딢 = base.딢().딟.딧;
      this.딶 = base.딢().딧;
      this.땓 = 0.0f;
      떁 딟1 = obj0.딟[this.땄].딟;
      float 딟2 = obj0.딟[this.땄].딟;
      떁 딟3 = obj0.딟[this.땄].딟;
      float 딟4 = obj0.딟[this.땄].딟;
      딥 딥 = new 딥(딟2);
      float num1 = base.딢().딱();
      float num2 = 6.283185f * this.땃();
      float num3 = 2f * num1 * this.딶() * num2;
      float num4 = num1 * (num2 * num2);
      float 딟5 = obj0.딟.딟;
      this.땃 = 딟5 * (num3 + 딟5 * num4);
      if (!Mathf.Approximately(this.땃, 0.0f))
        this.땃 = 1f / this.땃;
      this.딧 = 딟5 * num4 * this.땃;
      this.딧 = 땴.딟(딥, this.딧() - this.딢);
      땳 땳 = new 땳()
      {
        딟 = {
          딟 = this.딶 + this.땓 * this.딧.땄 * this.딧.땄 + this.땃,
          땄 = -this.땓 * this.딧.딟 * this.딧.땄
        }
      };
      땳.땄.딟 = 땳.딟.땄;
      땳.땄.땄 = this.딶 + this.땓 * this.딧.딟 * this.딧.딟 + this.땃;
      this.딟 = 땳.딟();
      this.땃 = 딟1 + this.딧 - this.딟;
      this.땃 *= this.딧;
      float num5 = 딟4 * 0.98f;
      this.땄 *= obj0.딟.땄;
      떁 떁 = 딟3 + this.딶 * this.땄;
      float num6 = num5 + this.땓 * 땴.딟(this.딧, this.땄);
      obj0.딟[this.땄].딟 = 떁;
      obj0.딟[this.땄].딟 = num6;
    }

    internal override void 땄([In] ref 딤 obj0)
    {
      떁 딟1 = obj0.딟[this.땄].딟;
      float 딟2 = obj0.딟[this.땄].딟;
      떁 떁1 = 땴.딟(ref this.딟, -(딟1 + 땴.딟(딟2, this.딧) + this.땃 + this.땃 * this.땄));
      떁 땄 = this.땄;
      this.땄 += 떁1;
      float num1 = obj0.딟.딟 * this.딢();
      if ((double) this.땄.딶() > (double) num1 * (double) num1)
        this.땄 *= num1 / this.땄.땃();
      떁 떁2 = this.땄 - 땄;
      떁 떁3 = 딟1 + this.딶 * 떁2;
      float num2 = 딟2 + this.땓 * 땴.딟(this.딧, 떁2);
      obj0.딟[this.땄].딟 = 떁3;
      obj0.딟[this.땄].딟 = num2;
    }

    internal override bool 딧([In] ref 딤 obj0) => true;
  }
}
