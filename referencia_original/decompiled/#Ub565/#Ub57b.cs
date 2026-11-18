// Decompiled with JetBrains decompiler
// Type: 땥.땻
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 땥
{
  public struct 땻
  {
    public 땟 딟;
    public 땟 땄;
    public 땟 딧;

    public 땻([In] 땟 obj0, [In] 땟 obj1, [In] 땟 obj2)
    {
      this.딟 = obj0;
      this.땄 = obj1;
      this.딧 = obj2;
    }

    public void 딟()
    {
      this.딟 = 땟.딟();
      this.땄 = 땟.딟();
      this.딧 = 땟.딟();
    }

    public 땟 딟([In] 땟 obj0)
    {
      float num = 땟.딶(this.딟, 땟.땄(this.땄, this.딧));
      if ((double) num != 0.0)
        num = 1f / num;
      return new 땟(num * 땟.딶(obj0, 땟.땄(this.땄, this.딧)), num * 땟.딶(this.딟, 땟.땄(obj0, this.딧)), num * 땟.딶(this.딟, 땟.땄(this.땄, obj0)));
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

    public void 딟([In] ref 땻 obj0)
    {
      float 딟1 = this.딟.딟;
      float 딟2 = this.땄.딟;
      float 땄1 = this.딟.땄;
      float 땄2 = this.땄.땄;
      float num = (float) ((double) 딟1 * (double) 땄2 - (double) 딟2 * (double) 땄1);
      if ((double) num != 0.0)
        num = 1f / num;
      obj0.딟.딟 = num * 땄2;
      obj0.땄.딟 = -num * 딟2;
      obj0.딟.딧 = 0.0f;
      obj0.딟.땄 = -num * 땄1;
      obj0.땄.땄 = num * 딟1;
      obj0.땄.딧 = 0.0f;
      obj0.딧.딟 = 0.0f;
      obj0.딧.땄 = 0.0f;
      obj0.딧.딧 = 0.0f;
    }

    public void 땄([In] ref 땻 obj0)
    {
      float num = 땴.땄(this.딟, 땴.딟(this.땄, this.딧));
      if ((double) num != 0.0)
        num = 1f / num;
      float 딟1 = this.딟.딟;
      float 딟2 = this.땄.딟;
      float 딟3 = this.딧.딟;
      float 땄1 = this.땄.땄;
      float 땄2 = this.딧.땄;
      float 딧 = this.딧.딧;
      obj0.딟.딟 = num * (float) ((double) 땄1 * (double) 딧 - (double) 땄2 * (double) 땄2);
      obj0.딟.땄 = num * (float) ((double) 딟3 * (double) 땄2 - (double) 딟2 * (double) 딧);
      obj0.딟.딧 = num * (float) ((double) 딟2 * (double) 땄2 - (double) 딟3 * (double) 땄1);
      obj0.땄.딟 = obj0.딟.땄;
      obj0.땄.땄 = num * (float) ((double) 딟1 * (double) 딧 - (double) 딟3 * (double) 딟3);
      obj0.땄.딧 = num * (float) ((double) 딟3 * (double) 딟2 - (double) 딟1 * (double) 땄2);
      obj0.딧.딟 = obj0.딟.딧;
      obj0.딧.땄 = obj0.땄.딧;
      obj0.딧.딧 = num * (float) ((double) 딟1 * (double) 땄1 - (double) 딟2 * (double) 딟2);
    }
  }
}
