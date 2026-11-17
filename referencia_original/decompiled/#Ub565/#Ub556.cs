// Decompiled with JetBrains decompiler
// Type: 땥.땖
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땥
{
  public class 땖 : 딹
  {
    public new bool 딟 = true;
    public bool 땄 = true;
    private List<딺> 딟 = new List<딺>();
    private float 딟;
    private float 땄;
    private float 딧;
    private float 딢;

    public 땖()
      : base(떐.땄)
    {
      this.딧(2f);
      this.땄(1.570796f);
    }

    public 땖([In] float obj0, [In] float obj1)
      : base(떐.땄)
    {
      if ((double) obj0 == 0.0 || (double) obj0 == 3.40282346638529E+38)
        this.땄 = false;
      if ((double) obj1 == 0.0 || (double) obj1 == 3.40282346638529E+38)
        this.딟 = false;
      this.딧(obj0);
      this.땄(obj1);
    }

    [SpecialName]
    public float 딟() => this.땄;

    [SpecialName]
    public void 땄([In] float obj0)
    {
      this.땄 = obj0;
      this.딟 = this.땄 * this.땄;
    }

    [SpecialName]
    public float 땄() => this.딢;

    [SpecialName]
    public void 딧([In] float obj0)
    {
      this.딢 = obj0;
      this.딧 = this.딢 * this.딢;
    }

    public override void 딟([In] float obj0)
    {
      foreach (딺 딺 in this.딟)
      {
        if (this.딟(딺))
        {
          if (this.땄)
          {
            float num1 = obj0 * 딺.땄.딟;
            float num2 = obj0 * 딺.땄.땄;
            float num3 = (float) ((double) num1 * (double) num1 + (double) num2 * (double) num2);
            if ((double) num3 > (double) obj0 * (double) this.딧)
            {
              float num4 = this.딢 / (float) Math.Sqrt((double) num3);
              딺.땄.딟 *= num4;
              딺.땄.땄 *= num4;
            }
          }
          if (this.딟)
          {
            float num5 = obj0 * 딺.딟;
            if ((double) num5 * (double) num5 > (double) this.딟)
            {
              float num6 = this.땄 / Math.Abs(num5);
              딺.딟 *= num6;
            }
          }
        }
      }
    }

    public void 땄([In] 딺 obj0) => this.딟.Add(obj0);

    public void 딧([In] 딺 obj0) => this.딟.Remove(obj0);
  }
}
