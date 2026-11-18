// Decompiled with JetBrains decompiler
// Type: 땥.땤
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 땥
{
  internal class 땤
  {
    public HashSet<땲> 딟;
    private 땋 딟;
    private 땋 땄;
    private float 딟;

    public 땤()
    {
      this.딟 = new HashSet<땲>();
      this.딟 = 50f;
      this.딟 = (땋) null;
      this.땄 = (땋) null;
    }

    public void 딟()
    {
      this.딟 = (땋) null;
      this.땄 = (땋) null;
    }

    public 땲[] 딟([In] 땲 obj0, [In] 땋 obj1)
    {
      땲[] 땲Array = new 땲[4]
      {
        new 땲(obj0.딟, obj1.딟, obj0.땄, obj0.딟),
        new 땲(obj1.딟, obj1.땄, obj0.땄, obj1),
        new 땲(obj1.딟, obj1.땄, obj1, obj0.딟),
        new 땲(obj1.땄, obj0.땄, obj0.땄, obj0.딟)
      };
      땲Array[0].딟(obj0.딧, obj0.딟);
      땲Array[1].딟(땲Array[0], (땲) null, 땲Array[3], (땲) null);
      땲Array[2].딟((땲) null, 땲Array[0], (땲) null, 땲Array[3]);
      땲Array[3].땄(obj0.딢, obj0.땄);
      return 땲Array;
    }

    public 땲[] 땄([In] 땲 obj0, [In] 땋 obj1)
    {
      땽 땽 = (double) obj1.땄.딟 != (double) obj0.땄.딟 ? obj0.땄 : obj1.땄;
      땲[] 땲Array = new 땲[3]
      {
        new 땲(obj0.딟, obj1.딟, obj0.땄, obj0.딟),
        new 땲(obj1.딟, 땽, obj0.땄, obj1),
        new 땲(obj1.딟, 땽, obj1, obj0.딟)
      };
      땲Array[0].딟(obj0.딧, obj0.딟);
      땲Array[1].딟(땲Array[0], (땲) null, obj0.딢, (땲) null);
      땲Array[2].딟((땲) null, 땲Array[0], (땲) null, obj0.땄);
      this.딟 = obj0.딟;
      this.땄 = obj0.땄;
      obj1.딟 = 땲Array[1];
      obj1.땄 = 땲Array[2];
      return 땲Array;
    }

    public 땲[] 딧([In] 땲 obj0, [In] 땋 obj1)
    {
      땽 땽1 = (double) obj1.딟.딟 != (double) obj0.딟.딟 ? obj0.딟 : obj1.딟;
      땽 땽2 = (double) obj1.땄.딟 != (double) obj0.땄.딟 ? obj0.땄 : obj1.땄;
      땲[] 땲Array = new 땲[2];
      if (this.땄 == obj0.땄)
      {
        땲Array[0] = obj0.딧;
        땲Array[0].땄(obj0.딢, (땲) null);
        땲Array[0].땄 = 땽2;
      }
      else
      {
        땲Array[0] = new 땲(땽1, 땽2, obj0.땄, obj1);
        땲Array[0].딟(obj0.딧, obj1.딟, obj0.딢, (땲) null);
      }
      if (this.딟 == obj0.딟)
      {
        땲Array[1] = obj0.딟;
        땲Array[1].땄((땲) null, obj0.땄);
        땲Array[1].땄 = 땽2;
      }
      else
      {
        땲Array[1] = new 땲(땽1, 땽2, obj1, obj0.딟);
        땲Array[1].딟(obj1.땄, obj0.딟, (땲) null, obj0.땄);
      }
      this.딟 = obj0.딟;
      this.땄 = obj0.땄;
      obj1.딟 = 땲Array[0];
      obj1.땄 = 땲Array[1];
      return 땲Array;
    }

    public 땲[] 딢([In] 땲 obj0, [In] 땋 obj1)
    {
      땽 땽 = (double) obj1.딟.딟 != (double) obj0.딟.딟 ? obj0.딟 : obj1.딟;
      땲[] 땲Array = new 땲[3];
      if (this.땄 == obj0.땄)
      {
        땲Array[0] = obj0.딧;
        땲Array[0].땄 = obj1.땄;
      }
      else
      {
        땲Array[0] = new 땲(땽, obj1.땄, obj0.땄, obj1);
        땲Array[0].딟(obj0.딧, obj1.딟);
      }
      if (this.딟 == obj0.딟)
      {
        땲Array[1] = obj0.딟;
        땲Array[1].땄 = obj1.땄;
      }
      else
      {
        땲Array[1] = new 땲(땽, obj1.땄, obj1, obj0.딟);
        땲Array[1].딟(obj1.땄, obj0.딟);
      }
      땲Array[2] = new 땲(obj1.땄, obj0.땄, obj0.땄, obj0.딟);
      땲Array[2].딟(땲Array[0], 땲Array[1], obj0.딢, obj0.땄);
      return 땲Array;
    }

    public 땲 딟([In] List<땋> obj0)
    {
      땽 땽1 = obj0[0].딟 + this.딟;
      땽 땽2 = obj0[0].땄 - this.딟;
      foreach (땋 땋 in obj0)
      {
        if ((double) 땋.딟.딟 > (double) 땽1.딟)
          땽1 = new 땽(땋.딟.딟 + this.딟, 땽1.땄);
        if ((double) 땋.딟.땄 > (double) 땽1.땄)
          땽1 = new 땽(땽1.딟, 땋.딟.땄 + this.딟);
        if ((double) 땋.땄.딟 > (double) 땽1.딟)
          땽1 = new 땽(땋.땄.딟 + this.딟, 땽1.땄);
        if ((double) 땋.땄.땄 > (double) 땽1.땄)
          땽1 = new 땽(땽1.딟, 땋.땄.땄 + this.딟);
        if ((double) 땋.딟.딟 < (double) 땽2.딟)
          땽2 = new 땽(땋.딟.딟 - this.딟, 땽2.땄);
        if ((double) 땋.딟.땄 < (double) 땽2.땄)
          땽2 = new 땽(땽2.딟, 땋.딟.땄 - this.딟);
        if ((double) 땋.땄.딟 < (double) 땽2.딟)
          땽2 = new 땽(땋.땄.딟 - this.딟, 땽2.땄);
        if ((double) 땋.땄.땄 < (double) 땽2.땄)
          땽2 = new 땽(땽2.딟, 땋.땄.땄 - this.딟);
      }
      땋 땋1 = new 땋(new 땽(땽2.딟, 땽1.땄), new 땽(땽1.딟, 땽1.땄));
      땋 땋2 = new 땋(new 땽(땽2.딟, 땽2.땄), new 땽(땽1.딟, 땽2.땄));
      return new 땲(땋2.딟, 땋1.땄, 땋1, 땋2);
    }
  }
}
