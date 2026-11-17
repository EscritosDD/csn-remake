// Decompiled with JetBrains decompiler
// Type: 땥.땽
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 땥
{
  internal class 땽
  {
    public 땽 딟;
    public 땽 땄;
    public float 딟;
    public float 땄;

    public 땽([In] float obj0, [In] float obj1)
    {
      this.딟 = obj0;
      this.땄 = obj1;
      this.딟 = (땽) null;
      this.땄 = (땽) null;
    }

    public float 딟([In] 땽 obj0) => (float) ((double) this.딟 * (double) obj0.땄 - (double) this.땄 * (double) obj0.딟);

    public float 땄([In] 땽 obj0) => (float) ((double) this.딟 * (double) obj0.딟 + (double) this.땄 * (double) obj0.땄);

    public bool 딧([In] 땽 obj0) => (double) obj0.딟 != (double) this.딟 || (double) obj0.땄 != (double) this.땄;

    public float 딟([In] 땽 obj0, [In] 땽 obj1)
    {
      float num1 = this.딟 - obj1.딟;
      float num2 = obj0.딟 - obj1.딟;
      float num3 = this.땄 - obj1.땄;
      float num4 = obj0.땄 - obj1.땄;
      return (float) ((double) num1 * (double) num4 - (double) num3 * (double) num2);
    }

    public static 땽 operator -([In] 땽 obj0, [In] 땽 obj1) => new 땽(obj0.딟 - obj1.딟, obj0.땄 - obj1.땄);

    public static 땽 operator +([In] 땽 obj0, [In] 땽 obj1) => new 땽(obj0.딟 + obj1.딟, obj0.땄 + obj1.땄);

    public static 땽 operator -([In] 땽 obj0, [In] float obj1) => new 땽(obj0.딟 - obj1, obj0.땄 - obj1);

    public static 땽 operator +([In] 땽 obj0, [In] float obj1) => new 땽(obj0.딟 + obj1, obj0.땄 + obj1);
  }
}
