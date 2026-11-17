// Decompiled with JetBrains decompiler
// Type: 땥.땺
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 땥
{
  public class 땺
  {
    public float[] 딟;
    public float[] 땄;

    public 땺([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3, [In] float obj4, [In] float obj5)
    {
      this.딟 = new float[3];
      this.땄 = new float[3];
      float num1 = obj2 - obj0;
      float num2 = obj4 - obj0;
      float num3 = obj3 - obj1;
      float num4 = obj5 - obj1;
      if ((double) num1 * (double) num4 - (double) num2 * (double) num3 > 0.0)
      {
        this.딟[0] = obj0;
        this.딟[1] = obj2;
        this.딟[2] = obj4;
        this.땄[0] = obj1;
        this.땄[1] = obj3;
        this.땄[2] = obj5;
      }
      else
      {
        this.딟[0] = obj0;
        this.딟[1] = obj4;
        this.딟[2] = obj2;
        this.땄[0] = obj1;
        this.땄[1] = obj5;
        this.땄[2] = obj3;
      }
    }

    public 땺([In] 땺 obj0)
    {
      this.딟 = new float[3];
      this.땄 = new float[3];
      this.딟[0] = obj0.딟[0];
      this.딟[1] = obj0.딟[1];
      this.딟[2] = obj0.딟[2];
      this.땄[0] = obj0.땄[0];
      this.땄[1] = obj0.땄[1];
      this.땄[2] = obj0.땄[2];
    }

    public bool 딟([In] float obj0, [In] float obj1)
    {
      if ((double) obj0 < (double) this.딟[0] && (double) obj0 < (double) this.딟[1] && (double) obj0 < (double) this.딟[2] || (double) obj0 > (double) this.딟[0] && (double) obj0 > (double) this.딟[1] && (double) obj0 > (double) this.딟[2] || (double) obj1 < (double) this.땄[0] && (double) obj1 < (double) this.땄[1] && (double) obj1 < (double) this.땄[2] || (double) obj1 > (double) this.땄[0] && (double) obj1 > (double) this.땄[1] && (double) obj1 > (double) this.땄[2])
        return false;
      float num1 = obj0 - this.딟[0];
      float num2 = obj1 - this.땄[0];
      float num3 = this.딟[1] - this.딟[0];
      float num4 = this.땄[1] - this.땄[0];
      float num5 = this.딟[2] - this.딟[0];
      float num6 = this.땄[2] - this.땄[0];
      float num7 = (float) ((double) num5 * (double) num5 + (double) num6 * (double) num6);
      float num8 = (float) ((double) num5 * (double) num3 + (double) num6 * (double) num4);
      float num9 = (float) ((double) num5 * (double) num1 + (double) num6 * (double) num2);
      float num10 = (float) ((double) num3 * (double) num3 + (double) num4 * (double) num4);
      float num11 = (float) ((double) num3 * (double) num1 + (double) num4 * (double) num2);
      float num12 = (float) (1.0 / ((double) num7 * (double) num10 - (double) num8 * (double) num8));
      float num13 = (float) ((double) num10 * (double) num9 - (double) num8 * (double) num11) * num12;
      float num14 = (float) ((double) num7 * (double) num11 - (double) num8 * (double) num9) * num12;
      return (double) num13 > 0.0 && (double) num14 > 0.0 && (double) num13 + (double) num14 < 1.0;
    }
  }
}
