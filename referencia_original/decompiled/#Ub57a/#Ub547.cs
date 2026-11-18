// Decompiled with JetBrains decompiler
// Type: 땺.땇
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using 땥;

namespace 땺
{
  internal struct 땇
  {
    internal int 딟;
    internal 딱<딨> 딟;

    internal void 딟([In] ref 딡 obj0, [In] 딞 obj1, [In] ref 땥.떓 obj2, [In] 딞 obj3, [In] ref 땥.떓 obj4)
    {
      this.딟 = (int) obj0.딟;
      for (int index = 0; index < this.딟; ++index)
      {
        딨 딨 = this.딟.딟(index);
        딨.딟 = (int) obj0.딟.딟(index);
        딨.땄 = (int) obj0.땄.딟(index);
        떁 떁1 = obj1.딟[딨.딟];
        떁 떁2 = obj3.딟[딨.땄];
        딨.땄 = 땥.땴.딟(ref obj2, 떁1);
        딨.딧 = 땥.땴.딟(ref obj4, 떁2);
        딨.딟 = 딨.딧 - 딨.땄;
        딨.딟 = 0.0f;
        this.딟.딟(index, 딨);
      }
      if (this.딟 > 1)
      {
        float 딟 = obj0.딟;
        float num = this.딧();
        if ((double) num < 0.5 * (double) 딟 || 2.0 * (double) 딟 < (double) num || (double) num < 1.19209289550781E-07)
          this.딟 = 0;
      }
      if (this.딟 != 0)
        return;
      딨 딨1 = this.딟.딟(0);
      딨1.딟 = 0;
      딨1.땄 = 0;
      떁 떁3 = obj1.딟[0];
      떁 떁4 = obj3.딟[0];
      딨1.땄 = 땥.땴.딟(ref obj2, 떁3);
      딨1.딧 = 땥.땴.딟(ref obj4, 떁4);
      딨1.딟 = 딨1.딧 - 딨1.땄;
      this.딟.딟(0, 딨1);
      this.딟 = 1;
    }

    internal void 딟([In] ref 딡 obj0)
    {
      obj0.딟 = this.딧();
      obj0.딟 = (ushort) this.딟;
      for (int index = 0; index < this.딟; ++index)
      {
        obj0.딟.딟(index, (byte) this.딟.딟(index).딟);
        obj0.땄.딟(index, (byte) this.딟.딟(index).땄);
      }
    }

    internal 떁 딟()
    {
      switch (this.딟)
      {
        case 1:
          return -this.딟.딟(0).딟;
        case 2:
          떁 떁 = this.딟.딟(1).딟 - this.딟.딟(0).딟;
          return (double) 땥.땴.딟(떁, -this.딟.딟(0).딟) > 0.0 ? new 떁(-떁.땄, 떁.딟) : new 떁(떁.땄, -떁.딟);
        default:
          return 떁.딟();
      }
    }

    internal 떁 땄()
    {
      switch (this.딟)
      {
        case 0:
          return 떁.딟();
        case 1:
          return this.딟.딟(0).딟;
        case 2:
          return this.딟.딟(0).딟 * this.딟.딟(0).딟 + this.딟.딟(1).딟 * this.딟.딟(1).딟;
        case 3:
          return 떁.딟();
        default:
          return 떁.딟();
      }
    }

    internal void 딟(out 떁 _param1, out 떁 _param2)
    {
      switch (this.딟)
      {
        case 0:
          _param1 = 떁.딟();
          _param2 = 떁.딟();
          break;
        case 1:
          _param1 = this.딟.딟(0).땄;
          _param2 = this.딟.딟(0).딧;
          break;
        case 2:
          _param1 = this.딟.딟(0).딟 * this.딟.딟(0).땄 + this.딟.딟(1).딟 * this.딟.딟(1).땄;
          _param2 = this.딟.딟(0).딟 * this.딟.딟(0).딧 + this.딟.딟(1).딟 * this.딟.딟(1).딧;
          break;
        case 3:
          _param1 = this.딟.딟(0).딟 * this.딟.딟(0).땄 + this.딟.딟(1).딟 * this.딟.딟(1).땄 + this.딟.딟(2).딟 * this.딟.딟(2).땄;
          _param2 = _param1;
          break;
        default:
          throw new Exception();
      }
    }

    internal float 딧()
    {
      switch (this.딟)
      {
        case 0:
          return 0.0f;
        case 1:
          return 0.0f;
        case 2:
          return (this.딟.딟(0).딟 - this.딟.딟(1).딟).땃();
        case 3:
          return 땥.땴.딟(this.딟.딟(1).딟 - this.딟.딟(0).딟, this.딟.딟(2).딟 - this.딟.딟(0).딟);
        default:
          return 0.0f;
      }
    }

    internal void 딢()
    {
      떁 딟1 = this.딟.딟(0).딟;
      떁 딟2 = this.딟.딟(1).딟;
      떁 떁 = 딟2 - 딟1;
      float num1 = -떁.딶(딟1, 떁);
      if ((double) num1 <= 0.0)
      {
        딨 딨 = this.딟.딟(0);
        딨.딟 = 1f;
        this.딟.딟(0, 딨);
        this.딟 = 1;
      }
      else
      {
        float num2 = 떁.딶(딟2, 떁);
        if ((double) num2 <= 0.0)
        {
          딨 딨 = this.딟.딟(1);
          딨.딟 = 1f;
          this.딟.딟(1, 딨);
          this.딟 = 1;
          this.딟.딟(0, this.딟.딟(1));
        }
        else
        {
          float num3 = (float) (1.0 / ((double) num2 + (double) num1));
          딨 딨1 = this.딟.딟(0);
          딨 딨2 = this.딟.딟(1);
          딨1.딟 = num2 * num3;
          딨2.딟 = num1 * num3;
          this.딟.딟(0, 딨1);
          this.딟.딟(1, 딨2);
          this.딟 = 2;
        }
      }
    }

    internal void 땃()
    {
      떁 딟1 = this.딟.딟(0).딟;
      떁 딟2 = this.딟.딟(1).딟;
      떁 딟3 = this.딟.딟(2).딟;
      떁 떁1 = 딟2 - 딟1;
      float num1 = 떁.딶(딟1, 떁1);
      float num2 = 떁.딶(딟2, 떁1);
      float num3 = -num1;
      떁 떁2 = 딟3 - 딟1;
      float num4 = 떁.딶(딟1, 떁2);
      float num5 = 떁.딶(딟3, 떁2);
      float num6 = -num4;
      떁 떁3 = 딟3 - 딟2;
      float num7 = 떁.딶(딟2, 떁3);
      float num8 = 떁.딶(딟3, 떁3);
      float num9 = -num7;
      float num10 = 땥.땴.딟(떁1, 떁2);
      float num11 = num10 * 땥.땴.딟(딟2, 딟3);
      float num12 = num10 * 땥.땴.딟(딟3, 딟1);
      float num13 = num10 * 땥.땴.딟(딟1, 딟2);
      if ((double) num3 <= 0.0 && (double) num6 <= 0.0)
      {
        딨 딨 = this.딟.딟(0);
        딨.딟 = 1f;
        this.딟.딟(0, 딨);
        this.딟 = 1;
      }
      else if ((double) num2 > 0.0 && (double) num3 > 0.0 && (double) num13 <= 0.0)
      {
        float num14 = (float) (1.0 / ((double) num2 + (double) num3));
        딨 딨1 = this.딟.딟(0);
        딨 딨2 = this.딟.딟(1);
        딨1.딟 = num2 * num14;
        딨2.딟 = num3 * num14;
        this.딟.딟(0, 딨1);
        this.딟.딟(1, 딨2);
        this.딟 = 2;
      }
      else if ((double) num5 > 0.0 && (double) num6 > 0.0 && (double) num12 <= 0.0)
      {
        float num15 = (float) (1.0 / ((double) num5 + (double) num6));
        딨 딨3 = this.딟.딟(0);
        딨 딨4 = this.딟.딟(2);
        딨3.딟 = num5 * num15;
        딨4.딟 = num6 * num15;
        this.딟.딟(0, 딨3);
        this.딟.딟(2, 딨4);
        this.딟 = 2;
        this.딟.딟(1, this.딟.딟(2));
      }
      else if ((double) num2 <= 0.0 && (double) num9 <= 0.0)
      {
        딨 딨 = this.딟.딟(1);
        딨.딟 = 1f;
        this.딟.딟(1, 딨);
        this.딟 = 1;
        this.딟.딟(0, this.딟.딟(1));
      }
      else if ((double) num5 <= 0.0 && (double) num8 <= 0.0)
      {
        딨 딨 = this.딟.딟(2);
        딨.딟 = 1f;
        this.딟.딟(2, 딨);
        this.딟 = 1;
        this.딟.딟(0, this.딟.딟(2));
      }
      else if ((double) num8 > 0.0 && (double) num9 > 0.0 && (double) num11 <= 0.0)
      {
        float num16 = (float) (1.0 / ((double) num8 + (double) num9));
        딨 딨5 = this.딟.딟(1);
        딨 딨6 = this.딟.딟(2);
        딨5.딟 = num8 * num16;
        딨6.딟 = num9 * num16;
        this.딟.딟(1, 딨5);
        this.딟.딟(2, 딨6);
        this.딟 = 2;
        this.딟.딟(0, this.딟.딟(2));
      }
      else
      {
        float num17 = (float) (1.0 / ((double) num11 + (double) num12 + (double) num13));
        딨 딨7 = this.딟.딟(0);
        딨 딨8 = this.딟.딟(1);
        딨 딨9 = this.딟.딟(2);
        딨7.딟 = num11 * num17;
        딨8.딟 = num12 * num17;
        딨9.딟 = num13 * num17;
        this.딟.딟(0, 딨7);
        this.딟.딟(1, 딨8);
        this.딟.딟(2, 딨9);
        this.딟 = 3;
      }
    }
  }
}
