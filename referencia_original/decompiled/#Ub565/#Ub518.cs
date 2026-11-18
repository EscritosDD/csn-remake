// Decompiled with JetBrains decompiler
// Type: 땥.딘
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using 딝;

namespace 땥
{
  public class 딘
  {
    public 때 딟;
    public 땺.떌 딟;
    public 딝.딥 딟;
    public List<떆> 딟 = new List<떆>(128);
    public 딱 딟;
    public 딝.떓 딟;
    public 딝.땠 딟;
    public 딝.땩 딟;

    internal 딘([In] 땺.떌 obj0)
    {
      this.딟 = obj0;
      this.딟 = new 딝.떓(this.딟);
    }

    private void 딟([In] ref 딲 obj0, [In] ref 딲 obj1)
    {
      떀 딟1 = obj0.딟;
      떀 딟2 = obj1.딟;
      int 딟3 = obj0.딟;
      int 딟4 = obj1.딟;
      딺 딺1 = 딟1.땓();
      딺 딺2 = 딟2.땓();
      if (딺1 == 딺2)
        return;
      for (땙 땙 = 딺2.땽(); 땙 != null; 땙 = 땙.딟)
      {
        if (땙.딟 == 딺1)
        {
          떀 딟5 = 땙.딟.딟;
          떀 땄 = 땙.딟.땄;
          int num1 = 땙.딟.땥();
          int num2 = 땙.딟.딝();
          if (딟5 == 딟1 && 땄 == 딟2 && num1 == 딟3 && num2 == 딟4 || 딟5 == 딟2 && 땄 == 딟1 && num1 == 딟4 && num2 == 딟3)
            return;
        }
      }
      if (!딺2.딟(딺1) || !딘.딟(딟1, 딟2) || this.딟 != null && !this.딟(딟1, 딟2) || 딟1.딟 != null && !딟1.딟(딟1, 딟2) || 딟2.딟 != null && !딟2.딟(딟2, 딟1))
        return;
      떆 떆 = 떆.땄(딟1, 딟3, 딟2, 딟4);
      떀 딟6 = 떆.딟;
      떀 땄1 = 떆.땄;
      딺 딺3 = 딟6.땓();
      딺 딺4 = 땄1.땓();
      this.딟.Add(떆);
      떆.딟.딟 = 떆;
      떆.딟.딟 = 딺4;
      떆.딟.땄 = (땙) null;
      떆.딟.딟 = 딺3.땽();
      if (딺3.땽() != null)
        딺3.땽().땄 = 떆.딟;
      딺3.딟(떆.딟);
      떆.땄.딟 = 떆;
      떆.땄.딟 = 딺3;
      떆.땄.땄 = (땙) null;
      떆.땄.딟 = 딺4.땽();
      if (딺4.땽() != null)
        딺4.땽().땄 = 떆.땄;
      딺4.딟(떆.땄);
    }

    internal void 딟() => this.딟.딟(this.딟);

    internal void 딟([In] 떆 obj0)
    {
      떀 딟 = obj0.딟;
      떀 땄 = obj0.땄;
      딺 딺1 = 딟.땓();
      딺 딺2 = 땄.땓();
      if (this.딟 != null && obj0.떎())
        this.딟(obj0);
      this.딟.Remove(obj0);
      if (obj0.딟.땄 != null)
        obj0.딟.땄.딟 = obj0.딟.딟;
      if (obj0.딟.딟 != null)
        obj0.딟.딟.땄 = obj0.딟.땄;
      if (obj0.딟 == 딺1.땽())
        딺1.딟(obj0.딟.딟);
      if (obj0.땄.땄 != null)
        obj0.땄.땄.딟 = obj0.땄.딟;
      if (obj0.땄.딟 != null)
        obj0.땄.딟.땄 = obj0.땄.땄;
      if (obj0.땄 == 딺2.땽())
        딺2.딟(obj0.땄.딟);
      obj0.땭();
    }

    internal void 땄()
    {
      for (int index1 = 0; index1 < this.딟.Count; ++index1)
      {
        떆 떆 = this.딟[index1];
        떀 딟 = 떆.딟;
        떀 땄 = 떆.땄;
        int index2 = 떆.땥();
        int index3 = 떆.딝();
        딺 딺1 = 딟.땓();
        딺 딺2 = 땄.땓();
        if (딺1.딝() || 딺2.딝())
        {
          if ((떆.딟 & 땏.땃) == 땏.땃)
          {
            if (!딺2.딟(딺1))
            {
              this.딟(떆);
              continue;
            }
            if (!딘.딟(딟, 땄))
            {
              this.딟(떆);
              continue;
            }
            if (this.딟 != null && !this.딟(딟, 땄))
            {
              this.딟(떆);
              continue;
            }
            떆.딟 &= ~땏.땃;
          }
          if (!this.딟.딟(딟.딟[index2].땄, 땄.딟[index3].땄))
            this.딟(떆);
          else
            떆.딟(this);
        }
      }
    }

    private static bool 딟([In] 떀 obj0, [In] 떀 obj1)
    {
      if (딝.땥.땃)
        return ((int) obj0.딟() != (int) obj1.딟() || obj0.딟() == (short) 0 || obj1.딟() == (short) 0) && !((obj0.딧() & obj1.땄()) == 땑.딟 & (obj1.딧() & obj0.땄()) == 땑.딟) && !obj0.딧(obj1) && !obj1.딧(obj0);
      if ((int) obj0.딟() == (int) obj1.딟() && obj0.딟() != (short) 0)
        return obj0.딟() > (short) 0;
      bool flag = (obj0.땄() & obj1.딧()) != 땑.딟 && (obj0.딧() & obj1.땄()) != 땑.딟;
      return (!flag || !obj0.딧(obj1) && !obj1.딧(obj0)) && flag;
    }

    internal void 딟([In] 땙 obj0, [In] bool obj1)
    {
    }
  }
}
