// Decompiled with JetBrains decompiler
// Type: 땥.딛
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;

namespace 땥
{
  public struct 딛
  {
    public float 딟;
    public float 땄;
    public float 딧;
    public 떁 딟;
    public 떁 땄;
    public 떁 딧;

    public void 딟(out 떓 _param1, [In] float obj1)
    {
      _param1 = new 떓();
      _param1.딟.딟 = (float) ((1.0 - (double) obj1) * (double) this.땄.딟 + (double) obj1 * (double) this.딟.딟);
      _param1.딟.땄 = (float) ((1.0 - (double) obj1) * (double) this.땄.땄 + (double) obj1 * (double) this.딟.땄);
      float num = (float) ((1.0 - (double) obj1) * (double) this.땄 + (double) obj1 * (double) this.딟);
      _param1.딟.딟(num);
      _param1.딟 -= 땴.딟(_param1.딟, this.딧);
    }

    public void 딟([In] float obj0)
    {
      float num = (float) (((double) obj0 - (double) this.딧) / (1.0 - (double) this.딧));
      this.땄.딟 = (float) ((1.0 - (double) num) * (double) this.땄.딟 + (double) num * (double) this.딟.딟);
      this.땄.땄 = (float) ((1.0 - (double) num) * (double) this.땄.땄 + (double) num * (double) this.딟.땄);
      this.땄 = (float) ((1.0 - (double) num) * (double) this.땄 + (double) num * (double) this.딟);
      this.딧 = obj0;
    }

    public void 딟()
    {
      float num = 6.283185f * (float) Math.Floor((double) this.땄 / 6.28318548202515);
      this.땄 -= num;
      this.딟 -= num;
    }
  }
}
