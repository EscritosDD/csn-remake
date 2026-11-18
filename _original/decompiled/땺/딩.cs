// Decompiled with JetBrains decompiler
// Type: 땺.딩
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using 땥;

namespace 땺
{
  public static class 딩
  {
    public static void 딟(out 땂<딾> _param0, out 땂<딾> _param1, [In] ref 따 obj2, [In] ref 따 obj3)
    {
      _param0 = new 땂<딾>();
      _param1 = new 땂<딾>();
      for (int index1 = 0; index1 < obj2.딟; ++index1)
      {
        땪 딟 = obj2.딟.딟(index1).딟;
        _param0.딟(index1, 딾.딢);
        for (int index2 = 0; index2 < obj3.딟; ++index2)
        {
          if ((int) obj3.딟.딟(index2).딟.딟 == (int) 딟.딟)
          {
            _param0.딟(index1, 딾.딧);
            break;
          }
        }
      }
      for (int index3 = 0; index3 < obj3.딟; ++index3)
      {
        땪 딟 = obj3.딟.딟(index3).딟;
        _param1.딟(index3, 딾.땄);
        for (int index4 = 0; index4 < obj2.딟; ++index4)
        {
          if ((int) obj2.딟.딟(index4).딟.딟 == (int) 딟.딟)
          {
            _param1.딟(index3, 딾.딧);
            break;
          }
        }
      }
    }

    public static void 딟([In] ref 따 obj0, [In] 땶 obj1, [In] ref 땥.떓 obj2, [In] 땶 obj3, [In] ref 땥.떓 obj4)
    {
      obj0.딟 = 0;
      떁 떁1 = 땥.땴.딟(ref obj2, obj1.딢());
      떁 떁2 = 땥.땴.딟(ref obj4, obj3.딢()) - 떁1;
      float num1 = 떁.딶(떁2, 떁2);
      float num2 = obj1.딶() + obj3.딶();
      if ((double) num1 > (double) num2 * (double) num2)
        return;
      obj0.딟 = 딚.딟;
      obj0.땄 = obj1.딢();
      obj0.딟 = 떁.딟();
      obj0.딟 = 1;
      땕 땕 = obj0.딟.딟(0);
      땕.딟 = obj3.딢();
      땕.딟.딟 = 0U;
      obj0.딟.딟(0, 땕);
    }

    public static void 딟([In] ref 따 obj0, [In] 떅 obj1, [In] ref 땥.떓 obj2, [In] 땶 obj3, [In] ref 땥.떓 obj4)
    {
      obj0.딟 = 0;
      떁 떁1 = 땥.땴.딟(ref obj4, obj3.딢());
      떁 떁2 = 땥.땴.땄(ref obj2, 떁1);
      int index1 = 0;
      float num1 = float.MinValue;
      float num2 = obj1.딶() + obj3.딶();
      int count = obj1.땄.Count;
      for (int index2 = 0; index2 < count; ++index2)
      {
        떁 떁3 = obj1.딟[index2];
        떁 떁4 = 떁2 - obj1.땄[index2];
        float num3 = (float) ((double) 떁3.딟 * (double) 떁4.딟 + (double) 떁3.땄 * (double) 떁4.땄);
        if ((double) num3 > (double) num2)
          return;
        if ((double) num3 > (double) num1)
        {
          num1 = num3;
          index1 = index2;
        }
      }
      int index3 = index1;
      int index4 = index3 + 1 >= count ? 0 : index3 + 1;
      떁 떁5 = obj1.땄[index3];
      떁 떁6 = obj1.땄[index4];
      if ((double) num1 < 1.19209289550781E-07)
      {
        obj0.딟 = 1;
        obj0.딟 = 딚.땄;
        obj0.딟 = obj1.딟[index1];
        obj0.땄 = 0.5f * (떁5 + 떁6);
        땕 땕 = obj0.딟.딟(0);
        땕.딟 = obj3.딢();
        땕.딟.딟 = 0U;
        obj0.딟.딟(0, 땕);
      }
      else
      {
        float num4 = (float) (((double) 떁2.딟 - (double) 떁5.딟) * ((double) 떁6.딟 - (double) 떁5.딟) + ((double) 떁2.땄 - (double) 떁5.땄) * ((double) 떁6.땄 - (double) 떁5.땄));
        float num5 = (float) (((double) 떁2.딟 - (double) 떁6.딟) * ((double) 떁5.딟 - (double) 떁6.딟) + ((double) 떁2.땄 - (double) 떁6.땄) * ((double) 떁5.땄 - (double) 떁6.땄));
        if ((double) num4 <= 0.0)
        {
          if (((double) 떁2.딟 - (double) 떁5.딟) * ((double) 떁2.딟 - (double) 떁5.딟) + ((double) 떁2.땄 - (double) 떁5.땄) * ((double) 떁2.땄 - (double) 떁5.땄) > (double) num2 * (double) num2)
            return;
          obj0.딟 = 1;
          obj0.딟 = 딚.땄;
          obj0.딟 = 떁2 - 떁5;
          float num6 = 1f / (float) Math.Sqrt((double) obj0.딟.딟 * (double) obj0.딟.딟 + (double) obj0.딟.땄 * (double) obj0.딟.땄);
          obj0.딟.딟 *= num6;
          obj0.딟.땄 *= num6;
          obj0.땄 = 떁5;
          땕 땕 = obj0.딟.딟(0);
          땕.딟 = obj3.딢();
          땕.딟.딟 = 0U;
          obj0.딟.딟(0, 땕);
        }
        else if ((double) num5 <= 0.0)
        {
          if (((double) 떁2.딟 - (double) 떁6.딟) * ((double) 떁2.딟 - (double) 떁6.딟) + ((double) 떁2.땄 - (double) 떁6.땄) * ((double) 떁2.땄 - (double) 떁6.땄) > (double) num2 * (double) num2)
            return;
          obj0.딟 = 1;
          obj0.딟 = 딚.땄;
          obj0.딟 = 떁2 - 떁6;
          float num7 = 1f / (float) Math.Sqrt((double) obj0.딟.딟 * (double) obj0.딟.딟 + (double) obj0.딟.땄 * (double) obj0.딟.땄);
          obj0.딟.딟 *= num7;
          obj0.딟.땄 *= num7;
          obj0.땄 = 떁6;
          땕 땕 = obj0.딟.딟(0);
          땕.딟 = obj3.딢();
          땕.딟.딟 = 0U;
          obj0.딟.딟(0, 땕);
        }
        else
        {
          떁 떁7 = 0.5f * (떁5 + 떁6);
          떁 떁8 = 떁2 - 떁7;
          떁 떁9 = obj1.딟[index3];
          if ((double) 떁8.딟 * (double) 떁9.딟 + (double) 떁8.땄 * (double) 떁9.땄 > (double) num2)
            return;
          obj0.딟 = 1;
          obj0.딟 = 딚.땄;
          obj0.딟 = obj1.딟[index3];
          obj0.땄 = 떁7;
          땕 땕 = obj0.딟.딟(0);
          땕.딟 = obj3.딢();
          땕.딟.딟 = 0U;
          obj0.딟.딟(0, 땕);
        }
      }
    }

    public static void 딟([In] ref 따 obj0, [In] 떅 obj1, [In] ref 땥.떓 obj2, [In] 떅 obj3, [In] ref 땥.떓 obj4)
    {
      obj0.딟 = 0;
      float num1 = obj1.딶() + obj3.딶();
      int num2 = 0;
      float num3 = 딩.딟(out num2, obj1, ref obj2, obj3, ref obj4);
      if ((double) num3 > (double) num1)
        return;
      int num4 = 0;
      float num5 = 딩.딟(out num4, obj3, ref obj4, obj1, ref obj2);
      if ((double) num5 > (double) num1)
        return;
      떅 떅1;
      떅 떅2;
      땥.떓 떓1;
      땥.떓 떓2;
      int num6;
      bool flag;
      if ((double) num5 > 0.980000019073486 * (double) num3 + 1.0 / 1000.0)
      {
        떅1 = obj3;
        떅2 = obj1;
        떓1 = obj4;
        떓2 = obj2;
        num6 = num4;
        obj0.딟 = 딚.딧;
        flag = true;
      }
      else
      {
        떅1 = obj1;
        떅2 = obj3;
        떓1 = obj2;
        떓2 = obj4;
        num6 = num2;
        obj0.딟 = 딚.땄;
        flag = false;
      }
      땂<땚> 땂1;
      딩.딟(out 땂1, 떅1, ref 떓1, num6, 떅2, ref 떓2);
      int count = 떅1.땄.Count;
      int index1 = num6;
      int index2 = num6 + 1 >= count ? 0 : num6 + 1;
      떁 떁1 = 떅1.땄[index1];
      떁 떁2 = 떅1.땄[index2];
      떁 떁3 = 떁2 - 떁1;
      떁3.땓();
      떁 떁4 = new 떁(떁3.땄, -떁3.딟);
      떁 떁5 = 0.5f * (떁1 + 떁2);
      떁 떁6 = 땥.땴.딟(떓1.딟, 떁3);
      float 땄 = 떁6.땄;
      float num7 = -떁6.딟;
      떁 떁7 = 땥.땴.딟(ref 떓1, 떁1);
      떁 떁8 = 땥.땴.딟(ref 떓1, 떁2);
      float num8 = (float) ((double) 땄 * (double) 떁7.딟 + (double) num7 * (double) 떁7.땄);
      float num9 = (float) -((double) 떁6.딟 * (double) 떁7.딟 + (double) 떁6.땄 * (double) 떁7.땄) + num1;
      float num10 = (float) ((double) 떁6.딟 * (double) 떁8.딟 + (double) 떁6.땄 * (double) 떁8.땄) + num1;
      땂<땚> 땂2;
      땂<땚> 땂3;
      if (딩.딟(out 땂2, ref 땂1, -떁6, num9, index1) < 2 || 딩.딟(out 땂3, ref 땂2, 떁6, num10, index2) < 2)
        return;
      obj0.딟 = 떁4;
      obj0.땄 = 떁5;
      int num11 = 0;
      for (int index3 = 0; index3 < 2; ++index3)
      {
        떁 딟1 = 땂3.딟(index3).딟;
        if ((double) ((float) ((double) 땄 * (double) 딟1.딟 + (double) num7 * (double) 딟1.땄) - num8) <= (double) num1)
        {
          땕 땕 = obj0.딟.딟(num11);
          땕.딟 = 땥.땴.땄(ref 떓2, 땂3.딟(index3).딟);
          땕.딟 = 땂3.딟(index3).딟;
          if (flag)
          {
            땜 딟2 = 땕.딟.딟;
            땕.딟.딟.딟 = 딟2.땄;
            땕.딟.딟.땄 = 딟2.딟;
            땕.딟.딟.딧 = 딟2.딢;
            땕.딟.딟.딢 = 딟2.딧;
          }
          obj0.딟.딟(num11, 땕);
          ++num11;
        }
      }
      obj0.딟 = num11;
    }

    public static void 딟([In] ref 따 obj0, [In] 땖 obj1, [In] ref 땥.떓 obj2, [In] 땶 obj3, [In] ref 땥.떓 obj4)
    {
      obj0.딟 = 0;
      떁 떁1 = 땥.땴.땄(ref obj2, 땥.땴.딟(ref obj4, ref obj3.딟));
      떁 떁2 = obj1.딢();
      떁 떁3 = obj1.땃();
      떁 떁4 = 떁3 - 떁2;
      float num1 = 떁.딶(떁4, 떁3 - 떁1);
      float num2 = 떁.딶(떁4, 떁1 - 떁2);
      float num3 = obj1.딶() + obj3.딶();
      땜 땜;
      땜.땄 = (byte) 0;
      땜.딢 = (byte) 0;
      if ((double) num2 <= 0.0)
      {
        떁 떁5 = 떁2;
        떁 떁6 = 떁1 - 떁5;
        float num4;
        떁.딧(ref 떁6, ref 떁6, out num4);
        if ((double) num4 > (double) num3 * (double) num3)
          return;
        if (obj1.딟)
        {
          떁 딟 = obj1.딟;
          떁 떁7 = 떁2;
          if ((double) 떁.딶(떁7 - 딟, 떁7 - 떁1) > 0.0)
            return;
        }
        땜.딟 = (byte) 0;
        땜.딧 = (byte) 0;
        obj0.딟 = 1;
        obj0.딟 = 딚.딟;
        obj0.딟 = 떁.딟();
        obj0.땄 = 떁5;
        obj0.딟.딟(0, new 땕()
        {
          딟 = {
            딟 = 0U,
            딟 = 땜
          },
          딟 = obj3.딢()
        });
      }
      else if ((double) num1 <= 0.0)
      {
        떁 떁8 = 떁3;
        떁 떁9 = 떁1 - 떁8;
        float num5;
        떁.딧(ref 떁9, ref 떁9, out num5);
        if ((double) num5 > (double) num3 * (double) num3)
          return;
        if (obj1.땄)
        {
          떁 땄 = obj1.땄;
          떁 떁10 = 떁3;
          if ((double) 떁.딶(땄 - 떁10, 떁1 - 떁10) > 0.0)
            return;
        }
        땜.딟 = (byte) 1;
        땜.딧 = (byte) 0;
        obj0.딟 = 1;
        obj0.딟 = 딚.딟;
        obj0.딟 = 떁.딟();
        obj0.땄 = 떁8;
        obj0.딟.딟(0, new 땕()
        {
          딟 = {
            딟 = 0U,
            딟 = 땜
          },
          딟 = obj3.딢()
        });
      }
      else
      {
        float num6;
        떁.딧(ref 떁4, ref 떁4, out num6);
        떁 떁11 = 1f / num6 * (num1 * 떁2 + num2 * 떁3);
        떁 떁12 = 떁1 - 떁11;
        float num7;
        떁.딧(ref 떁12, ref 떁12, out num7);
        if ((double) num7 > (double) num3 * (double) num3)
          return;
        떁 떁13 = new 떁(-떁4.땄, 떁4.딟);
        if ((double) 떁.딶(떁13, 떁1 - 떁2) < 0.0)
          떁13 = new 떁(-떁13.딟, -떁13.땄);
        떁13.땓();
        땜.딟 = (byte) 0;
        땜.딧 = (byte) 1;
        obj0.딟 = 1;
        obj0.딟 = 딚.땄;
        obj0.딟 = 떁13;
        obj0.땄 = 떁2;
        obj0.딟.딟(0, new 땕()
        {
          딟 = {
            딟 = 0U,
            딟 = 땜
          },
          딟 = obj3.딢()
        });
      }
    }

    public static void 딟([In] ref 따 obj0, [In] 땖 obj1, [In] ref 땥.떓 obj2, [In] 떅 obj3, [In] ref 땥.떓 obj4) => new 딩.딖().딟(ref obj0, obj1, ref obj2, obj3, ref obj4);

    private static int 딟(out 땂<땚> _param0, [In] ref 땂<땚> obj1, [In] 떁 obj2, [In] float obj3, [In] int obj4)
    {
      _param0 = new 땂<땚>();
      땚 땚1 = obj1.딟(0);
      땚 땚2 = obj1.딟(1);
      int num1 = 0;
      float num2 = (float) ((double) obj2.딟 * (double) 땚1.딟.딟 + (double) obj2.땄 * (double) 땚1.딟.땄) - obj3;
      float num3 = (float) ((double) obj2.딟 * (double) 땚2.딟.딟 + (double) obj2.땄 * (double) 땚2.딟.땄) - obj3;
      if ((double) num2 <= 0.0)
        _param0.딟(num1++, 땚1);
      if ((double) num3 <= 0.0)
        _param0.딟(num1++, 땚2);
      if ((double) num2 * (double) num3 < 0.0)
      {
        float num4 = num2 / (num2 - num3);
        땚 땚3 = _param0.딟(num1);
        땚3.딟.딟 = 땚1.딟.딟 + num4 * (땚2.딟.딟 - 땚1.딟.딟);
        땚3.딟.땄 = 땚1.딟.땄 + num4 * (땚2.딟.땄 - 땚1.딟.땄);
        땚3.딟.딟.딟 = (byte) obj4;
        땚3.딟.딟.땄 = 땚1.딟.딟.땄;
        땚3.딟.딟.딧 = (byte) 0;
        땚3.딟.딟.딢 = (byte) 1;
        _param0.딟(num1, 땚3);
        ++num1;
      }
      return num1;
    }

    private static float 딟([In] 떅 obj0, [In] ref 땥.떓 obj1, [In] int obj2, [In] 떅 obj3, [In] ref 땥.떓 obj4)
    {
      List<떁> 땄1 = (List<떁>) obj0.땄;
      List<떁> 딟 = (List<떁>) obj0.딟;
      int count = obj3.땄.Count;
      List<떁> 땄2 = (List<떁>) obj3.땄;
      떁 떁1 = 땥.땴.딟(obj1.딟, 딟[obj2]);
      떁 떁2 = 땥.땴.땄(obj4.딟, 떁1);
      int index1 = 0;
      float num1 = float.MaxValue;
      for (int index2 = 0; index2 < count; ++index2)
      {
        float num2 = 떁.딶(땄2[index2], 떁2);
        if ((double) num2 < (double) num1)
        {
          num1 = num2;
          index1 = index2;
        }
      }
      떁 떁3 = 땥.땴.딟(ref obj1, 땄1[obj2]);
      return 떁.딶(땥.땴.딟(ref obj4, 땄2[index1]) - 떁3, 떁1);
    }

    private static float 딟(out int _param0, [In] 떅 obj1, [In] ref 땥.떓 obj2, [In] 떅 obj3, [In] ref 땥.떓 obj4)
    {
      int count = obj1.땄.Count;
      List<떁> 딟 = (List<떁>) obj1.딟;
      떁 떁1 = 땥.땴.딟(ref obj4, ((땏) obj3).딟.딟) - 땥.땴.딟(ref obj2, ((땏) obj1).딟.딟);
      떁 떁2 = 땥.땴.땄(obj2.딟, 떁1);
      int num1 = 0;
      float num2 = float.MinValue;
      for (int index = 0; index < count; ++index)
      {
        float num3 = 떁.딶(딟[index], 떁2);
        if ((double) num3 > (double) num2)
        {
          num2 = num3;
          num1 = index;
        }
      }
      float num4 = 딩.딟(obj1, ref obj2, num1, obj3, ref obj4);
      int num5 = num1 - 1 < 0 ? count - 1 : num1 - 1;
      float num6 = 딩.딟(obj1, ref obj2, num5, obj3, ref obj4);
      int num7 = num1 + 1 >= count ? 0 : num1 + 1;
      float num8 = 딩.딟(obj1, ref obj2, num7, obj3, ref obj4);
      int num9;
      int num10;
      float num11;
      if ((double) num6 > (double) num4 && (double) num6 > (double) num8)
      {
        num9 = -1;
        num10 = num5;
        num11 = num6;
      }
      else if ((double) num8 > (double) num4)
      {
        num9 = 1;
        num10 = num7;
        num11 = num8;
      }
      else
      {
        _param0 = num1;
        return num4;
      }
      while (true)
      {
        int num12 = num9 != -1 ? (num10 + 1 >= count ? 0 : num10 + 1) : (num10 - 1 < 0 ? count - 1 : num10 - 1);
        float num13 = 딩.딟(obj1, ref obj2, num12, obj3, ref obj4);
        if ((double) num13 > (double) num11)
        {
          num10 = num12;
          num11 = num13;
        }
        else
          break;
      }
      _param0 = num10;
      return num11;
    }

    private static void 딟(out 땂<땚> _param0, [In] 떅 obj1, [In] ref 땥.떓 obj2, [In] int obj3, [In] 떅 obj4, [In] ref 땥.떓 obj5)
    {
      _param0 = new 땂<땚>();
      땨 딟1 = obj1.딟;
      int count = obj4.땄.Count;
      땨 땄 = obj4.땄;
      땨 딟2 = obj4.딟;
      떁 떁 = 땥.땴.땄(obj5.딟, 땥.땴.딟(obj2.딟, 딟1[obj3]));
      int num1 = 0;
      float num2 = float.MaxValue;
      for (int index = 0; index < count; ++index)
      {
        float num3 = 떁.딶(떁, 딟2[index]);
        if ((double) num3 < (double) num2)
        {
          num2 = num3;
          num1 = index;
        }
      }
      int index1 = num1;
      int index2 = index1 + 1 >= count ? 0 : index1 + 1;
      땚 땚1 = _param0.딟(0);
      땚1.딟 = 땥.땴.딟(ref obj5, 땄[index1]);
      땚1.딟.딟.딟 = (byte) obj3;
      땚1.딟.딟.땄 = (byte) index1;
      땚1.딟.딟.딧 = (byte) 1;
      땚1.딟.딟.딢 = (byte) 0;
      _param0.딟(0, 땚1);
      땚 땚2 = _param0.딟(1);
      땚2.딟 = 땥.땴.딟(ref obj5, 땄[index2]);
      땚2.딟.딟.딟 = (byte) obj3;
      땚2.딟.딟.땄 = (byte) index2;
      땚2.딟.딟.딧 = (byte) 1;
      땚2.딟.딟.딢 = (byte) 0;
      _param0.딟(1, 땚2);
    }

    public class 딖
    {
      private 떍 딟 = new 떍();
      private 땥.떓 딟;
      private 떁 딟;
      private 떁 땄;
      private 떁 딧;
      private 떁 딢;
      private 떁 땃;
      private 떁 딶;
      private 떁 땓;
      private 떁 땺;
      private 떁 땥;
      private 딩.딖.VertexType 딟;
      private 딩.딖.VertexType 땄;
      private 떁 딝;
      private 떁 떎;
      private float 딟;
      private bool 딟;

      public void 딟([In] ref 따 obj0, [In] 땖 obj1, [In] ref 땥.떓 obj2, [In] 떅 obj3, [In] ref 땥.떓 obj4)
      {
        this.딟 = 땥.땴.땄(obj2, obj4);
        this.딟 = 땥.땴.딟(ref this.딟, ((땏) obj3).딟.딟);
        this.땄 = obj1.딟;
        this.딧 = obj1.딧;
        this.딢 = obj1.딢;
        this.땃 = obj1.땄;
        bool 딟 = obj1.딟;
        bool 땄 = obj1.땄;
        떁 떁1 = this.딢 - this.딧;
        떁1.땓();
        this.땓 = new 떁(떁1.땄, -떁1.딟);
        float num1 = 떁.딶(this.땓, this.딟 - this.딧);
        float num2 = 0.0f;
        float num3 = 0.0f;
        bool flag1 = false;
        bool flag2 = false;
        if (딟)
        {
          떁 떁2 = this.딧 - this.땄;
          떁2.땓();
          this.딶 = new 떁(떁2.땄, -떁2.딟);
          flag1 = (double) 땥.땴.딟(떁2, 떁1) >= 0.0;
          num2 = 떁.딶(this.딶, this.딟 - this.땄);
        }
        if (땄)
        {
          떁 떁3 = this.땃 - this.딢;
          떁3.땓();
          this.땺 = new 떁(떁3.땄, -떁3.딟);
          flag2 = (double) 땥.땴.딟(떁1, 떁3) > 0.0;
          num3 = 떁.딶(this.땺, this.딟 - this.딢);
        }
        if (딟 && 땄)
        {
          if (flag1 && flag2)
          {
            this.딟 = (double) num2 >= 0.0 || (double) num1 >= 0.0 || (double) num3 >= 0.0;
            if (this.딟)
            {
              this.땥 = this.땓;
              this.딝 = this.딶;
              this.떎 = this.땺;
            }
            else
            {
              this.땥 = -this.땓;
              this.딝 = -this.땓;
              this.떎 = -this.땓;
            }
          }
          else if (flag1)
          {
            this.딟 = (double) num2 >= 0.0 || (double) num1 >= 0.0 && (double) num3 >= 0.0;
            if (this.딟)
            {
              this.땥 = this.땓;
              this.딝 = this.딶;
              this.떎 = this.땓;
            }
            else
            {
              this.땥 = -this.땓;
              this.딝 = -this.땺;
              this.떎 = -this.땓;
            }
          }
          else if (flag2)
          {
            this.딟 = (double) num3 >= 0.0 || (double) num2 >= 0.0 && (double) num1 >= 0.0;
            if (this.딟)
            {
              this.땥 = this.땓;
              this.딝 = this.땓;
              this.떎 = this.땺;
            }
            else
            {
              this.땥 = -this.땓;
              this.딝 = -this.땓;
              this.떎 = -this.딶;
            }
          }
          else
          {
            this.딟 = (double) num2 >= 0.0 && (double) num1 >= 0.0 && (double) num3 >= 0.0;
            if (this.딟)
            {
              this.땥 = this.땓;
              this.딝 = this.땓;
              this.떎 = this.땓;
            }
            else
            {
              this.땥 = -this.땓;
              this.딝 = -this.땺;
              this.떎 = -this.딶;
            }
          }
        }
        else if (딟)
        {
          if (flag1)
          {
            this.딟 = (double) num2 >= 0.0 || (double) num1 >= 0.0;
            if (this.딟)
            {
              this.땥 = this.땓;
              this.딝 = this.딶;
              this.떎 = -this.땓;
            }
            else
            {
              this.땥 = -this.땓;
              this.딝 = this.땓;
              this.떎 = -this.땓;
            }
          }
          else
          {
            this.딟 = (double) num2 >= 0.0 && (double) num1 >= 0.0;
            if (this.딟)
            {
              this.땥 = this.땓;
              this.딝 = this.땓;
              this.떎 = -this.땓;
            }
            else
            {
              this.땥 = -this.땓;
              this.딝 = this.땓;
              this.떎 = -this.딶;
            }
          }
        }
        else if (땄)
        {
          if (flag2)
          {
            this.딟 = (double) num1 >= 0.0 || (double) num3 >= 0.0;
            if (this.딟)
            {
              this.땥 = this.땓;
              this.딝 = -this.땓;
              this.떎 = this.땺;
            }
            else
            {
              this.땥 = -this.땓;
              this.딝 = -this.땓;
              this.떎 = this.땓;
            }
          }
          else
          {
            this.딟 = (double) num1 >= 0.0 && (double) num3 >= 0.0;
            if (this.딟)
            {
              this.땥 = this.땓;
              this.딝 = -this.땓;
              this.떎 = this.땓;
            }
            else
            {
              this.땥 = -this.땓;
              this.딝 = -this.땺;
              this.떎 = this.땓;
            }
          }
        }
        else
        {
          this.딟 = (double) num1 >= 0.0;
          if (this.딟)
          {
            this.땥 = this.땓;
            this.딝 = -this.땓;
            this.떎 = -this.땓;
          }
          else
          {
            this.땥 = -this.땓;
            this.딝 = this.땓;
            this.떎 = this.땓;
          }
        }
        this.딟.딟 = obj3.땄.Count;
        for (int index = 0; index < obj3.땄.Count; ++index)
        {
          this.딟.땄[index] = 땥.땴.딟(ref this.딟, obj3.땄[index]);
          this.딟.딟[index] = 땥.땴.딟(this.딟.딟, obj3.딟[index]);
        }
        this.딟 = 0.02f;
        obj0.딟 = 0;
        딴 딴1 = this.딟();
        if (딴1.딟 == 떋.딟 || (double) 딴1.딟 > (double) this.딟)
          return;
        딴 딴2 = this.땄();
        if (딴2.딟 != 떋.딟 && (double) 딴2.딟 > (double) this.딟)
          return;
        딴 딴3 = 딴2.딟 != 떋.딟 ? ((double) 딴2.딟 <= 0.980000019073486 * (double) 딴1.딟 + 1.0 / 1000.0 ? 딴1 : 딴2) : 딴1;
        땂<땚> 땂1 = new 땂<땚>();
        땀 땀;
        if (딴3.딟 == 떋.땄)
        {
          obj0.딟 = 딚.땄;
          int num4 = 0;
          float num5 = 떁.딶(this.땥, this.딟.딟[0]);
          for (int index = 1; index < this.딟.딟; ++index)
          {
            float num6 = 떁.딶(this.땥, this.딟.딟[index]);
            if ((double) num6 < (double) num5)
            {
              num5 = num6;
              num4 = index;
            }
          }
          int index1 = num4;
          int index2 = index1 + 1 >= this.딟.딟 ? 0 : index1 + 1;
          땚 땚1 = 땂1.딟(0);
          땚1.딟 = this.딟.땄[index1];
          땚1.딟.딟.딟 = (byte) 0;
          땚1.딟.딟.땄 = (byte) index1;
          땚1.딟.딟.딧 = (byte) 1;
          땚1.딟.딟.딢 = (byte) 0;
          땂1.딟(0, 땚1);
          땚 땚2 = 땂1.딟(1);
          땚2.딟 = this.딟.땄[index2];
          땚2.딟.딟.딟 = (byte) 0;
          땚2.딟.딟.땄 = (byte) index2;
          땚2.딟.딟.딧 = (byte) 1;
          땚2.딟.딟.딢 = (byte) 0;
          땂1.딟(1, 땚2);
          if (this.딟)
          {
            땀.딟 = 0;
            땀.땄 = 1;
            땀.딟 = this.딧;
            땀.땄 = this.딢;
            땀.딧 = this.땓;
          }
          else
          {
            땀.딟 = 1;
            땀.땄 = 0;
            땀.딟 = this.딢;
            땀.땄 = this.딧;
            땀.딧 = -this.땓;
          }
        }
        else
        {
          obj0.딟 = 딚.딧;
          땚 땚3 = 땂1.딟(0);
          땚3.딟 = this.딧;
          땚3.딟.딟.딟 = (byte) 0;
          땚3.딟.딟.땄 = (byte) 딴3.딟;
          땚3.딟.딟.딧 = (byte) 0;
          땚3.딟.딟.딢 = (byte) 1;
          땂1.딟(0, 땚3);
          땚 땚4 = 땂1.딟(1);
          땚4.딟 = this.딢;
          땚4.딟.딟.딟 = (byte) 0;
          땚4.딟.딟.땄 = (byte) 딴3.딟;
          땚4.딟.딟.딧 = (byte) 0;
          땚4.딟.딟.딢 = (byte) 1;
          땂1.딟(1, 땚4);
          땀.딟 = 딴3.딟;
          땀.땄 = 땀.딟 + 1 >= this.딟.딟 ? 0 : 땀.딟 + 1;
          땀.딟 = this.딟.땄[땀.딟];
          땀.땄 = this.딟.땄[땀.땄];
          땀.딧 = this.딟.딟[땀.딟];
        }
        땀.딢 = new 떁(땀.딧.땄, -땀.딧.딟);
        땀.땃 = -땀.딢;
        땀.딟 = 떁.딶(땀.딢, 땀.딟);
        땀.땄 = 떁.딶(땀.땃, 땀.땄);
        땂<땚> 땂2;
        땂<땚> 땂3;
        if (딩.딟(out 땂2, ref 땂1, 땀.딢, 땀.딟, 땀.딟) < 2 || 딩.딟(out 땂3, ref 땂2, 땀.땃, 땀.땄, 땀.땄) < 2)
          return;
        if (딴3.딟 == 떋.땄)
        {
          obj0.딟 = 땀.딧;
          obj0.땄 = 땀.딟;
        }
        else
        {
          obj0.딟 = obj3.딟[땀.딟];
          obj0.땄 = obj3.땄[땀.딟];
        }
        int num7 = 0;
        for (int index = 0; index < 2; ++index)
        {
          if ((double) 떁.딶(땀.딧, 땂3.딟(index).딟 - 땀.딟) <= (double) this.딟)
          {
            땕 땕 = obj0.딟.딟(num7);
            if (딴3.딟 == 떋.땄)
            {
              땕.딟 = 땥.땴.땄(ref this.딟, 땂3.딟(index).딟);
              땕.딟 = 땂3.딟(index).딟;
            }
            else
            {
              땕.딟 = 땂3.딟(index).딟;
              땕.딟.딟.딧 = 땂3.딟(index).딟.딟.딢;
              땕.딟.딟.딢 = 땂3.딟(index).딟.딟.딧;
              땕.딟.딟.딟 = 땂3.딟(index).딟.딟.땄;
              땕.딟.딟.땄 = 땂3.딟(index).딟.딟.딟;
            }
            obj0.딟.딟(num7, 땕);
            ++num7;
          }
        }
        obj0.딟 = num7;
      }

      private 딴 딟()
      {
        딴 딴;
        딴.딟 = 떋.땄;
        딴.딟 = !this.딟 ? 1 : 0;
        딴.딟 = float.MaxValue;
        for (int index = 0; index < this.딟.딟; ++index)
        {
          float num = 떁.딶(this.땥, this.딟.땄[index] - this.딧);
          if ((double) num < (double) 딴.딟)
            딴.딟 = num;
        }
        return 딴;
      }

      private 딴 땄()
      {
        딴 딴;
        딴.딟 = 떋.딟;
        딴.딟 = -1;
        딴.딟 = float.MinValue;
        떁 떁1 = new 떁(-this.땥.땄, this.땥.딟);
        for (int index = 0; index < this.딟.딟; ++index)
        {
          떁 떁2 = -this.딟.딟[index];
          float num = Math.Min(떁.딶(떁2, this.딟.땄[index] - this.딧), 떁.딶(떁2, this.딟.땄[index] - this.딢));
          if ((double) num > (double) this.딟)
          {
            딴.딟 = 떋.딧;
            딴.딟 = index;
            딴.딟 = num;
            return 딴;
          }
          if ((double) 떁.딶(떁2, 떁1) >= 0.0)
          {
            if ((double) 떁.딶(떁2 - this.떎, this.땥) < -0.0349065884947777)
              continue;
          }
          else if ((double) 떁.딶(떁2 - this.딝, this.땥) < -0.0349065884947777)
            continue;
          if ((double) num > (double) 딴.딟)
          {
            딴.딟 = 떋.딧;
            딴.딟 = index;
            딴.딟 = num;
          }
        }
        return 딴;
      }

      private enum VertexType
      {
        e_isolated,
        e_concave,
        e_convex,
      }
    }
  }
}
