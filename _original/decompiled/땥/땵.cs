// Decompiled with JetBrains decompiler
// Type: 땥.땵
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using FarseerPhysics.Collision;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땥
{
  public sealed class 땵 : 딹
  {
    public float 딟;
    public float 땄;
    public float 딧;
    public 떁 딟;
    private AABB 딟;
    private 떁 땄;
    private 떁 딧;
    private float 딢;
    private Dictionary<int, 딺> 딟 = new Dictionary<int, 딺>();

    public 땵([In] AABB obj0, [In] float obj1, [In] float obj2, [In] float obj3, [In] 떁 obj4)
      : base(떐.딢)
    {
      this.딟(obj0);
      this.딧 = new 떁(0.0f, 1f);
      this.땄 = obj1;
      this.딧 = obj2;
      this.딟 = obj3;
      this.땄 = obj4;
    }

    [SpecialName]
    public AABB 딟() => this.딟;

    [SpecialName]
    public void 딟([In] AABB obj0)
    {
      this.딟 = obj0;
      this.딢 = this.딟.UpperBound.땄;
    }

    public override void 딟([In] float obj0_1)
    {
      this.딟.Clear();
      base.딟.딟((Func<떀, bool>) (obj0_2 =>
      {
        if (obj0_2.땓().딷() || !obj0_2.땓().딝() || this.딟.ContainsKey(obj0_2.땓().땄))
          return true;
        this.딟.Add(obj0_2.땓().땄, obj0_2.땓());
        return true;
      }), ref this.딟);
      foreach (KeyValuePair<int, 딺> keyValuePair in this.딟)
      {
        딺 딺 = keyValuePair.Value;
        떁 떁1 = 떁.딟();
        떁 떁2 = 떁.딟();
        float num1 = 0.0f;
        float num2 = 0.0f;
        for (int index = 0; index < 딺.딦().Count; ++index)
        {
          떀 떀 = 딺.딦()[index];
          if (떀.땃().딢() == 땺.땙.딢 || 떀.땃().딢() == 땺.땙.땄)
          {
            땺.땏 땏 = 떀.땃();
            떁 떁3;
            float num3 = 땏.딟(this.딧, this.딢, 딺.딟, out 떁3);
            num1 += num3;
            떁1.딟 += num3 * 떁3.딟;
            떁1.땄 += num3 * 떁3.땄;
            num2 += num3 * 땏.땃();
            떁2.딟 += num3 * 떁3.딟 * 땏.땃();
            떁2.땄 += num3 * 떁3.땄 * 땏.땃();
          }
        }
        떁1.딟 /= num1;
        떁1.땄 /= num1;
        떁2.딟 /= num2;
        떁2.땄 /= num2;
        if ((double) num1 >= 1.19209289550781E-07)
        {
          떁 떁4 = -this.땄 * num1 * this.땄;
          딺.딟(떁4, 떁2);
          떁 떁5 = (딺.딝(떁1) - this.딟) * (-this.딧 * num1);
          딺.딟(떁5, 떁1);
          딺.딝(-딺.때() / 딺.딱() * num1 * 딺.땃() * this.딟);
        }
      }
    }
  }
}
