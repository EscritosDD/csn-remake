// Decompiled with JetBrains decompiler
// Type: 땥.떔
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using FarseerPhysics.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using 딝;

namespace 땥
{
  public sealed class 떔 : 땉
  {
    private const float 딟 = 0.03490658f;
    public float 땄 = 0.025f;
    public bool 딟;
    public float 딧 = 0.2094395f;
    public new int 딟 = 100;
    public new int 땄 = 5;
    private List<딸> 딟 = new List<딸>();
    private Dictionary<떀, List<떁>> 딟;
    private 땘 딟;

    public 떔([In] 땱 obj0)
      : base(obj0, 땹.딟)
    {
      this.딟 = new Dictionary<떀, List<떁>>();
      this.딟 = new 땘();
      this.딟 = new List<딸>();
    }

    public Dictionary<떀, List<떁>> 딟([In] 떁 obj0, [In] float obj1, [In] float obj2)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      떔.딳 딳 = new 떔.딳();
      // ISSUE: reference to a compiler-generated field
      딳.딟 = obj0;
      // ISSUE: reference to a compiler-generated field
      딳.딟 = this;
      this.딟.Clear();
      AABB aabb;
      // ISSUE: reference to a compiler-generated field
      aabb.LowerBound = 딳.딟 + new 떁(-obj1, -obj1);
      // ISSUE: reference to a compiler-generated field
      aabb.UpperBound = 딳.딟 + new 떁(obj1, obj1);
      // ISSUE: reference to a compiler-generated field
      딳.땄 = new 떀[this.딟];
      // ISSUE: reference to a compiler-generated field
      딳.딟 = new 떀[5];
      // ISSUE: reference to a compiler-generated field
      딳.딟 = false;
      // ISSUE: reference to a compiler-generated field
      딳.땄 = 0;
      // ISSUE: reference to a compiler-generated field
      딳.딟 = 0;
      // ISSUE: reference to a compiler-generated method
      base.딟.딟(new Func<떀, bool>(딳.딟), ref aabb);
      // ISSUE: reference to a compiler-generated field
      if (딳.딟)
        return this.딟;
      // ISSUE: reference to a compiler-generated field
      float[] array = new float[딳.땄 * 2];
      int length = 0;
      // ISSUE: reference to a compiler-generated field
      for (int index1 = 0; index1 < 딳.땄; ++index1)
      {
        땺.떅 떅;
        // ISSUE: reference to a compiler-generated field
        if (딳.땄[index1].땃() is 땺.땶 땶2)
        {
          땨 땨 = new 땨();
          떁 떁1 = 떁.딟() + new 떁(땶2.딶(), 0.0f);
          땨.Add(떁1);
          떁 떁2 = 떁.딟() + new 떁(0.0f, 땶2.딶());
          땨.Add(떁2);
          떁 떁3 = 떁.딟() + new 떁(-땶2.딶(), 땶2.딶());
          땨.Add(떁3);
          떁 떁4 = 떁.딟() + new 떁(0.0f, -땶2.딶());
          땨.Add(떁4);
          떅 = new 땺.떅(땨, 0.0f);
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          떅 = 딳.땄[index1].땃() as 땺.떅;
        }
        // ISSUE: reference to a compiler-generated field
        if (딳.땄[index1].땓().딧() == 땎.딧 && 떅 != null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          떁 떁5 = 딳.땄[index1].땓().딶(((땺.땏) 떅).딟.딟) - 딳.딟;
          float num1 = (float) Math.Atan2((double) 떁5.땄, (double) 떁5.딟);
          float num2 = float.MaxValue;
          float num3 = float.MinValue;
          float num4 = 0.0f;
          float num5 = 0.0f;
          for (int index2 = 0; index2 < 떅.땄.Count<떁>(); ++index2)
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            떁 떁6 = 딳.땄[index1].땓().딶(떅.땄[index2]) - 딳.딟;
            float num6 = (float) Math.Atan2((double) 떁6.땄, (double) 떁6.딟);
            float num7 = (float) (((double) (num6 - num1) - 3.14159274101257) % 6.28318548202515);
            if ((double) num7 < 0.0)
              num7 += 6.283185f;
            float num8 = num7 - 3.141593f;
            if ((double) Math.Abs(num8) > 3.14159274101257)
              throw new ArgumentException("OMG!");
            if ((double) num8 > (double) num3)
            {
              num3 = num8;
              num5 = num6;
            }
            if ((double) num8 < (double) num2)
            {
              num2 = num8;
              num4 = num6;
            }
          }
          array[length] = num4;
          int index3 = length + 1;
          array[index3] = num5;
          length = index3 + 1;
        }
      }
      Array.Sort<float>(array, 0, length, (IComparer<float>) this.딟);
      this.딟.Clear();
      bool flag = true;
      for (int index4 = 0; index4 < length; ++index4)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        떔.땝 땝 = new 떔.땝();
        // ISSUE: reference to a compiler-generated field
        땝.딟 = this;
        // ISSUE: reference to a compiler-generated field
        땝.딟 = (떀) null;
        int index5 = index4 != length - 1 ? index4 + 1 : 0;
        if ((double) array[index4] != (double) array[index5])
        {
          float num = (index4 != length - 1 ? array[index4 + 1] + array[index4] : array[0] + 6.283185f + array[index4]) / 2f;
          // ISSUE: reference to a compiler-generated field
          떁 딟 = 딳.딟;
          // ISSUE: reference to a compiler-generated field
          떁 떁 = obj1 * new 떁((float) Math.Cos((double) num), (float) Math.Sin((double) num)) + 딳.딟;
          // ISSUE: reference to a compiler-generated field
          땝.딟 = false;
          // ISSUE: reference to a compiler-generated method
          base.딟.딟(new 땂(땝.딟), 딟, 떁);
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          if (땝.딟 && 땝.딟.땓().딧() == 땎.딧)
          {
            // ISSUE: reference to a compiler-generated field
            if (this.딟.Count<딸>() > 0 && this.딟.Last<딸>().딟 == 땝.딟.땓() && !flag)
            {
              int index6 = this.딟.Count - 1;
              딸 딸 = this.딟[index6];
              딸.딟 = array[index5];
              this.딟[index6] = 딸;
            }
            else
            {
              딸 딸;
              // ISSUE: reference to a compiler-generated field
              딸.딟 = 땝.딟.땓();
              딸.땄 = array[index4];
              딸.딟 = array[index5];
              this.딟.Add(딸);
            }
            if (this.딟.Count<딸>() > 1 && index4 == length - 1 && this.딟.Last<딸>().딟 == this.딟.First<딸>().딟 && (double) this.딟.Last<딸>().딟 == (double) this.딟.First<딸>().땄)
            {
              딸 딸 = this.딟[0];
              딸.땄 = this.딟.Last<딸>().땄;
              this.딟.RemoveAt(this.딟.Count<딸>() - 1);
              this.딟[0] = 딸;
              while ((double) this.딟.First<딸>().땄 >= (double) this.딟.First<딸>().딟)
              {
                딸.땄 -= 6.283185f;
                this.딟[0] = 딸;
              }
            }
            int index7 = this.딟.Count - 1;
            딸 딸1 = this.딟[index7];
            while (this.딟.Count<딸>() > 0 && (double) this.딟.Last<딸>().땄 >= (double) this.딟.Last<딸>().딟)
            {
              딸1.땄 = this.딟.Last<딸>().땄 - 6.283185f;
              this.딟[index7] = 딸1;
            }
            flag = false;
          }
          else
            flag = true;
        }
      }
      for (int index8 = 0; index8 < this.딟.Count<딸>(); ++index8)
      {
        if (this.딟(this.딟[index8].딟))
        {
          float num9 = this.딟[index8].딟 - this.딟[index8].땄;
          float num10 = 딣.딧((float) Math.PI / 90f, this.땄 * num9);
          int num11 = (int) Math.Ceiling(((double) num9 - 2.0 * (double) num10 - (double) (this.땄 - 1) * (double) this.딧) / (double) this.딧);
          if (num11 < 0)
            num11 = 0;
          float num12 = (float) (((double) num9 - (double) num10 * 2.0) / ((double) this.땄 + (double) num11 - 1.0));
          for (float num13 = this.딟[index8].땄 + num10; (double) num13 < (double) this.딟[index8].딟 || 땴.땄(num13, this.딟[index8].딟, 0.0001f); num13 += num12)
          {
            // ISSUE: reference to a compiler-generated field
            떁 딟 = 딳.딟;
            // ISSUE: reference to a compiler-generated field
            떁 떁7 = 딳.딟 + obj1 * new 떁((float) Math.Cos((double) num13), (float) Math.Sin((double) num13));
            떁 떁8 = 떁.딟();
            float val2 = float.MaxValue;
            List<떀> 떀List = this.딟[index8].딟.딦();
            for (int index9 = 0; index9 < 떀List.Count; ++index9)
            {
              떀 key = 떀List[index9];
              땺.딮 딮;
              딮.딟 = 딟;
              딮.땄 = 떁7;
              딮.딟 = 50f;
              땺.딯 딯;
              if (key.딟(out 딯, ref 딮, 0) && (double) val2 > (double) 딯.딟)
              {
                val2 = 딯.딟;
                떁8 = 딯.딟 * 떁7 + (1f - 딯.딟) * 딟;
              }
              떁 떁9 = 떁.딶((float) ((double) num9 / (double) (this.땄 + num11) * (double) obj2 * 180.0 / 3.14159274101257 * (1.0 - (double) Math.Min(1f, val2))) * new 떁((float) Math.Cos((double) num13), (float) Math.Sin((double) num13)), -딯.딟) * new 떁((float) Math.Cos((double) num13), (float) Math.Sin((double) num13));
              this.딟[index8].딟.땄(ref 떁9, ref 떁8);
              떁 떁10 = 떁.딟();
              List<떁> 떁List;
              if (this.딟.TryGetValue(key, out 떁List))
              {
                떁10.딟 += Math.Abs(떁9.딟);
                떁10.땄 += Math.Abs(떁9.땄);
                떁List.Add(떁10);
              }
              else
              {
                떁List = new List<떁>();
                떁10.딟 = Math.Abs(떁9.딟);
                떁10.땄 = Math.Abs(떁9.땄);
                떁List.Add(떁10);
                this.딟.Add(key, 떁List);
              }
              if ((double) val2 > 1.0)
                떁8 = 떁7;
            }
          }
        }
      }
      // ISSUE: reference to a compiler-generated field
      for (int index = 0; index < 딳.딟; ++index)
      {
        // ISSUE: reference to a compiler-generated field
        떀 key = 딳.딟[index];
        if (this.딟(key.땓()))
        {
          float num = (float) ((double) this.땄 * (double) obj2 * 180.0 / 3.14159274101257);
          떁 떁11;
          if (key.땃() is 땺.땶 땶7)
          {
            떁11 = key.땓().딶(땶7.딢());
          }
          else
          {
            땺.떅 떅 = key.땃() as 땺.떅;
            떁11 = key.땓().딶(((땺.땏) 떅).딟.딟);
          }
          // ISSUE: reference to a compiler-generated field
          떁 떁12 = num * (떁11 - 딳.딟);
          List<떁> 떁List = new List<떁>();
          떁List.Add(떁12);
          key.땓().땄(ref 떁12, ref 떁11);
          if (!this.딟.ContainsKey(key))
            this.딟.Add(key, 떁List);
        }
      }
      return this.딟;
    }
  }
}
