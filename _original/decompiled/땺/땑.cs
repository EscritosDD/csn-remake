// Decompiled with JetBrains decompiler
// Type: 땺.땑
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땺
{
  public class 땑
  {
    private 떀 딟;
    private 딺 딟;
    private 딺 땄;

    public 땑() => this.딟 = new 떀();

    [SpecialName]
    public bool 딟() => this.딟.get_Count() <= 1;

    [SpecialName]
    public 떀 땄() => this.딟;

    [SpecialName]
    public 딺 딧() => this.딟;

    [SpecialName]
    public void 딟([In] 딺 obj0) => this.딟 = obj0;

    [SpecialName]
    public 딺 딢() => this.땄;

    [SpecialName]
    public void 땄([In] 딺 obj0) => this.땄 = obj0;

    public void 딟([In] int obj0, [In] 딘 obj1, [In] 딘 obj2) => throw new NotImplementedException();

    public void 딟([In] int obj0, [In] 딘 obj1) => this.딟(obj0, obj1, obj1);

    public void 딟([In] 딘 obj0, [In] 딘 obj1) => throw new NotImplementedException();

    public void 딟([In] 딘 obj0) => this.딟(obj0, obj0);

    public 땑 땃() => new 땑()
    {
      딟 = this.딟.땄(),
      땄 = this.땄,
      딟 = this.딟
    };

    public float 딟([In] float obj0)
    {
      딲 딲1 = this.딟.딟(0);
      딲 딲2 = this.딟.딟(this.딟.get_Count() - 1);
      if ((double) obj0 < (double) 딲1.땄())
      {
        switch (this.딢())
        {
          case 딺.딟:
            return 딲1.땃();
          case 딺.땄:
            int num1 = this.땄(obj0);
            return this.딧(obj0 - (float) num1 * (딲2.땄() - 딲1.땄()));
          case 딺.딧:
            int num2 = this.땄(obj0);
            return this.딧(obj0 - (float) num2 * (딲2.땄() - 딲1.땄())) + (float) num2 * (딲2.땃() - 딲1.땃());
          case 딺.딢:
            int num3 = this.땄(obj0);
            return this.딧((double) num3 % 2.0 != 0.0 ? (float) ((double) 딲2.땄() - (double) obj0 + (double) 딲1.땄() + (double) num3 * ((double) 딲2.땄() - (double) 딲1.땄())) : obj0 - (float) num3 * (딲2.땄() - 딲1.땄()));
          case 딺.땃:
            return 딲1.땃() - 딲1.딧() * (딲1.땄() - obj0);
        }
      }
      else if ((double) obj0 > (double) 딲2.땄())
      {
        switch (this.딧())
        {
          case 딺.딟:
            return 딲2.땃();
          case 딺.땄:
            int num4 = this.땄(obj0);
            return this.딧(obj0 - (float) num4 * (딲2.땄() - 딲1.땄()));
          case 딺.딧:
            int num5 = this.땄(obj0);
            return this.딧(obj0 - (float) num5 * (딲2.땄() - 딲1.땄())) + (float) num5 * (딲2.땃() - 딲1.땃());
          case 딺.딢:
            int num6 = this.땄(obj0);
            float num7 = obj0 - (float) num6 * (딲2.땄() - 딲1.땄());
            return this.딧((double) num6 % 2.0 != 0.0 ? (float) ((double) 딲2.땄() - (double) obj0 + (double) 딲1.땄() + (double) num6 * ((double) 딲2.땄() - (double) 딲1.땄())) : obj0 - (float) num6 * (딲2.땄() - 딲1.땄()));
          case 딺.땃:
            return 딲2.땃() + 딲1.딢() * (obj0 - 딲2.땄());
        }
      }
      return this.딧(obj0);
    }

    private int 땄([In] float obj0)
    {
      float num = (float) (((double) obj0 - (double) this.딟.딟(0).땄()) / ((double) this.딟.딟(this.딟.get_Count() - 1).땄() - (double) this.딟.딟(0).땄()));
      if ((double) num < 0.0)
        --num;
      return (int) num;
    }

    private float 딧([In] float obj0)
    {
      딲 딲1 = this.딟.딟(0);
      for (int index = 1; index < this.딟.get_Count(); ++index)
      {
        딲 딲2 = this.땄().딟(index);
        if ((double) 딲2.땄() >= (double) obj0)
        {
          if (딲1.딟() == 땾.땄)
            return (double) obj0 >= 1.0 ? 딲2.땃() : 딲1.땃();
          float num1 = (float) (((double) obj0 - (double) 딲1.땄()) / ((double) 딲2.땄() - (double) 딲1.땄()));
          float num2 = num1 * num1;
          float num3 = num2 * num1;
          return (float) ((2.0 * (double) num3 - 3.0 * (double) num2 + 1.0) * (double) 딲1.땃() + ((double) num3 - 2.0 * (double) num2 + (double) num1) * (double) 딲1.딢() + (3.0 * (double) num2 - 2.0 * (double) num3) * (double) 딲2.땃() + ((double) num3 - (double) num2) * (double) 딲2.딧());
        }
        딲1 = 딲2;
      }
      return 0.0f;
    }
  }
}
