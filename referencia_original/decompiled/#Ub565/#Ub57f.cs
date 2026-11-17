// Decompiled with JetBrains decompiler
// Type: 땥.땿
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땥
{
  public class 땿 : 딹
  {
    public List<딺> 딟 = new List<딺>();
    public List<떁> 딟 = new List<떁>();

    public 땿([In] float obj0)
      : base(떐.딟)
    {
      this.딢(obj0);
      this.딧(float.MaxValue);
    }

    public 땿([In] float obj0, [In] float obj1, [In] float obj2)
      : base(떐.딟)
    {
      this.땄(obj2);
      this.딧(obj1);
      this.딢(obj0);
    }

    [CompilerGenerated]
    [SpecialName]
    public float 딟() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 땄([In] float obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public float 땄() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public void 딧([In] float obj0) => this.땄 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public float 딧() => this.딧;

    [CompilerGenerated]
    [SpecialName]
    public void 딢([In] float obj0) => this.딧 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public 딙 딢() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] 딙 obj0) => this.딟 = obj0;

    public override void 딟([In] float obj0)
    {
      떁 떁1 = 떁.딟();
      foreach (딺 딺1 in base.딟.떂())
      {
        if (this.딟(딺1))
        {
          foreach (딺 딺2 in this.딟)
          {
            if (딺1 != 딺2 && (!딺1.딷() || !딺2.딷()) && 딺2.떎())
            {
              떁 떁2 = 딺2.땟() - 딺1.땟();
              float num1 = 떁2.딶();
              if ((double) num1 >= 1.19209289550781E-07)
              {
                float num2 = 떁2.땃();
                if ((double) num2 < (double) this.땄() && (double) num2 > (double) this.딟())
                {
                  switch (this.딢())
                  {
                    case 딙.딟:
                      떁1 = this.딧() / num1 * 딺1.딱() * 딺2.딱() * 떁2;
                      break;
                    case 딙.땄:
                      떁1 = (float) ((double) this.딧() / (double) num1 / Math.Sqrt((double) num1)) * 딺1.딱() * 딺2.딱() * 떁2;
                      break;
                  }
                  딺1.딟(ref 떁1);
                  떁.딟(ref 떁1, out 떁1);
                  딺2.딟(ref 떁1);
                }
              }
            }
          }
          foreach (떁 떁3 in this.딟)
          {
            떁 떁4 = 떁3 - 딺1.땼();
            float num3 = 떁4.딶();
            if ((double) num3 >= 1.19209289550781E-07)
            {
              float num4 = 떁4.땃();
              if ((double) num4 < (double) this.땄() && (double) num4 > (double) this.딟())
              {
                switch (this.딢())
                {
                  case 딙.딟:
                    떁1 = this.딧() / num3 * 딺1.딱() * 떁4;
                    break;
                  case 딙.땄:
                    떁1 = this.딧() / num3 / (float) Math.Sqrt((double) num3) * 딺1.딱() * 떁4;
                    break;
                }
                딺1.딟(ref 떁1);
              }
            }
          }
        }
      }
    }

    public void 땄([In] 딺 obj0) => this.딟.Add(obj0);

    public void 딟([In] 떁 obj0) => this.딟.Add(obj0);
  }
}
