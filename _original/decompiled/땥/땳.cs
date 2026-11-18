// Decompiled with JetBrains decompiler
// Type: 땥.땳
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땥
{
  public struct 땳
  {
    public 떁 딟;
    public 떁 땄;

    public 땳([In] 떁 obj0, [In] 떁 obj1)
    {
      this.딟 = obj0;
      this.땄 = obj1;
    }

    public 땳([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3)
    {
      this.딟 = new 떁(obj0, obj2);
      this.땄 = new 떁(obj1, obj3);
    }

    [SpecialName]
    public 땳 딟()
    {
      float 딟1 = this.딟.딟;
      float 딟2 = this.땄.딟;
      float 땄1 = this.딟.땄;
      float 땄2 = this.땄.땄;
      float num = (float) ((double) 딟1 * (double) 땄2 - (double) 딟2 * (double) 땄1);
      if ((double) num != 0.0)
        num = 1f / num;
      return new 땳()
      {
        딟 = {
          딟 = num * 땄2,
          땄 = -num * 땄1
        },
        땄 = {
          딟 = -num * 딟2,
          땄 = num * 딟1
        }
      };
    }

    public void 딟([In] 떁 obj0, [In] 떁 obj1)
    {
      this.딟 = obj0;
      this.땄 = obj1;
    }

    public void 땄()
    {
      this.딟.딟 = 1f;
      this.땄.딟 = 0.0f;
      this.딟.땄 = 0.0f;
      this.땄.땄 = 1f;
    }

    public void 딧()
    {
      this.딟.딟 = 0.0f;
      this.땄.딟 = 0.0f;
      this.딟.땄 = 0.0f;
      this.땄.땄 = 0.0f;
    }

    public 떁 딟([In] 떁 obj0)
    {
      float 딟1 = this.딟.딟;
      float 딟2 = this.땄.딟;
      float 땄1 = this.딟.땄;
      float 땄2 = this.땄.땄;
      float num = (float) ((double) 딟1 * (double) 땄2 - (double) 딟2 * (double) 땄1);
      if ((double) num != 0.0)
        num = 1f / num;
      return new 떁(num * (float) ((double) 땄2 * (double) obj0.딟 - (double) 딟2 * (double) obj0.땄), num * (float) ((double) 딟1 * (double) obj0.땄 - (double) 땄1 * (double) obj0.딟));
    }

    public static void 딟([In] ref 땳 obj0, [In] ref 땳 obj1, out 땳 _param2)
    {
      _param2.딟 = obj0.딟 + obj1.딟;
      _param2.땄 = obj0.땄 + obj1.땄;
    }
  }
}
