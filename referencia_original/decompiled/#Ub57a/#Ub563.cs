// Decompiled with JetBrains decompiler
// Type: 땺.땣
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땺
{
  public class 땣 : 떊
  {
    private const float 딟 = 0.3f;
    public 땣.땱 딟 = new 땣.땱();
    public 땣.땦 딟 = new 땣.땦();
    private 떃 딟 = new 떃();
    public 딵 딟;

    public 땣() => this.딟();

    [CompilerGenerated]
    [SpecialName]
    public 땮 땄() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] 땮 obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public 땮 딧() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public void 땄([In] 땮 obj0) => this.땄 = obj0;

    public void 딟([In] 딽 obj0) => base.딟.Remove(obj0);

    public void 땄([In] 딽 obj0) => this.딧(obj0);

    private void 딧([In] 딽 obj0)
    {
      if (obj0 == null || obj0.딟())
        return;
      obj0.딟(true);
      base.딧().딟(obj0);
      for (int index = 0; index < 3; ++index)
      {
        if (!obj0.딟.딟(index))
          this.딧(obj0.딟.딟(index));
      }
    }

    public override void 딟()
    {
      base.딟();
      base.딟.Clear();
    }

    public void 딟([In] 땰 obj0) => this.딟.딟(obj0);

    public void 땄([In] 땰 obj0) => this.딟.땄(obj0);

    public 땰 딧([In] 땮 obj0) => this.딟.딟(obj0);

    public void 딢()
    {
      딽 딽 = new 딽(base.딟[0], this.딧(), this.땄());
      base.딟.Add(딽);
      땰 땰1 = new 땰(딽.딟.딟(1));
      땰1.딟 = 딽;
      땰 땰2 = new 땰(딽.딟.딟(0));
      땰2.딟 = 딽;
      땰 땰3 = new 땰(딽.딟.딟(2));
      this.딟 = new 딵(땰1, 땰3);
      this.딟.딟(땰2);
      this.딟.딟.딟 = 땰2;
      땰2.딟 = this.딟.딧;
      땰2.땄 = this.딟.딟;
      this.딟.딧.땄 = 땰2;
    }

    public void 딢([In] 딽 obj0)
    {
      for (int index = 0; index < 3; ++index)
      {
        if (obj0.딟.딟(index) == null)
        {
          땰 땰 = this.딟.땄(obj0.땥(obj0.딟.딟(index)));
          if (땰 != null)
            땰.딟 = obj0;
        }
      }
    }

    public override void 딟([In] 땫 obj0)
    {
      base.딟(obj0);
      double 딟;
      double num1 = 딟 = base.딟[0].딟;
      double 땄;
      double num2 = 땄 = base.딟[0].땄;
      foreach (땮 땮 in base.딟)
      {
        if (땮.딟 > num1)
          num1 = 땮.딟;
        if (땮.딟 < 딟)
          딟 = 땮.딟;
        if (땮.땄 > num2)
          num2 = 땮.땄;
        if (땮.땄 < 땄)
          땄 = 땮.땄;
      }
      double num3 = 0.300000011920929 * (num1 - 딟);
      double num4 = 0.300000011920929 * (num2 - 땄);
      땮 땮1 = new 땮(num1 + num3, 땄 - num4);
      땮 땮2 = new 땮(딟 - num3, 땄 - num4);
      this.딟(땮1);
      this.땄(땮2);
      base.딟.Sort((IComparer<땮>) this.딟);
    }

    public void 땃()
    {
      base.딧().딟((IEnumerable<딽>) base.딟);
      base.딟.Clear();
    }

    public override 땬 딟([In] 땮 obj0, [In] 땮 obj1) => (땬) new 딭(obj0, obj1);

    public class 땱
    {
      public 땰 딟;
      public bool 딟;
      public 땰 땄;
      public 땰 딧;
      public double 딟;
    }

    public class 땦
    {
      public 딭 딟;
      public bool 딟;
    }
  }
}
