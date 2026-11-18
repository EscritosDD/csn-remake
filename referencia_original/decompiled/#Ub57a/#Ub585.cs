// Decompiled with JetBrains decompiler
// Type: 땺.떅
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using FarseerPhysics.Collision;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using 땥;

namespace 땺
{
  public class 떅 : 땏
  {
    public 땨 딟;
    public 땨 땄;

    public 떅([In] 땨 obj0, [In] float obj1)
      : base(obj1)
    {
      this.딟(땙.딢);
      base.땄 = 0.01f;
      this.딟(obj0);
    }

    public 떅([In] float obj0)
      : base(obj0)
    {
      this.딟(땙.딢);
      base.땄 = 0.01f;
      this.딟 = new 땨(딝.땥.땺);
      this.땄 = new 땨(딝.땥.땺);
    }

    internal 떅()
      : base(0.0f)
    {
      this.딟(땙.딢);
      base.땄 = 0.01f;
      this.딟 = new 땨(딝.땥.땺);
      this.땄 = new 땨(딝.땥.땺);
    }

    [SpecialName]
    public override int 딟() => 1;

    public override 땏 땄()
    {
      떅 떅 = new 떅();
      떅.딟(base.딢());
      ((땏) 떅).땄 = base.땄;
      ((땏) 떅).딟 = base.딟;
      if (딝.땥.딶)
      {
        떅.땄 = this.땄;
        떅.딟 = this.딟;
      }
      else
      {
        떅.땄 = new 땨((IList<떁>) this.땄);
        떅.딟 = new 땨((IList<떁>) this.딟);
      }
      ((땏) 떅).딟 = base.딟;
      return (땏) 떅;
    }

    public void 딟([In] 땨 obj0)
    {
      this.땄 = new 땨((IList<떁>) obj0);
      this.딟 = new 땨(this.땄.Count);
      for (int index1 = 0; index1 < this.땄.Count; ++index1)
      {
        int index2 = index1;
        떁 떁1 = this.땄[index1 + 1 >= this.땄.Count ? 0 : index1 + 1] - this.땄[index2];
        떁 떁2 = new 떁(떁1.땄, -떁1.딟);
        떁2.땓();
        this.딟.Add(떁2);
      }
      this.딧();
    }

    protected override void 딧()
    {
      if ((double) base.딟 <= 0.0)
        return;
      떁 떁1 = 떁.딟();
      float num1 = 0.0f;
      float num2 = 0.0f;
      떁 떁2 = 떁.딟();
      for (int index = 0; index < this.땄.Count; ++index)
        떁2 += this.땄[index];
      떁 떁3 = 떁2 * (1f / (float) this.땄.Count);
      for (int index = 0; index < this.땄.Count; ++index)
      {
        떁 떁4 = this.땄[index] - 떁3;
        떁 떁5 = index + 1 >= this.땄.Count ? this.땄[0] - 떁3 : this.땄[index + 1] - 떁3;
        float num3 = 땥.땴.딟(떁4, 떁5);
        float num4 = 0.5f * num3;
        num1 += num4;
        떁1 += num4 * 0.3333333f * (떁4 + 떁5);
        float 딟1 = 떁4.딟;
        float 땄1 = 떁4.땄;
        float 딟2 = 떁5.딟;
        float 땄2 = 떁5.땄;
        float num5 = (float) ((double) 딟1 * (double) 딟1 + (double) 딟2 * (double) 딟1 + (double) 딟2 * (double) 딟2);
        float num6 = (float) ((double) 땄1 * (double) 땄1 + (double) 땄2 * (double) 땄1 + (double) 땄2 * (double) 땄2);
        num2 += (float) (0.0833333358168602 * (double) num3 * ((double) num5 + (double) num6));
      }
      base.딟.딟 = num1;
      base.딟.딧 = base.딟 * num1;
      떁 떁6 = 떁1 * (1f / num1);
      base.딟.딟 = 떁6 + 떁3;
      base.딟.땄 = base.딟 * num2;
      base.딟.땄 += base.딟.딧 * (떁.딶(base.딟.딟, base.딟.딟) - 떁.딶(떁6, 떁6));
    }

    public void 딟([In] float obj0, [In] float obj1) => this.딟(땥.딾.딟(obj0, obj1));

    public void 딟([In] float obj0, [In] float obj1, [In] 떁 obj2, [In] float obj3) => this.딟(땥.딾.딟(obj0, obj1, obj2, obj3));

    public override bool 딟([In] ref 땥.떓 obj0, [In] ref 떁 obj1)
    {
      떁 떁 = 땥.땴.땄(obj0.딟, obj1 - obj0.딟);
      for (int index = 0; index < this.땄.Count; ++index)
      {
        if ((double) 떁.딶(this.딟[index], 떁 - this.땄[index]) > 0.0)
          return false;
      }
      return true;
    }

    public override bool 딟(out 딯 _param1, [In] ref 딮 obj1, [In] ref 땥.떓 obj2, [In] int obj3)
    {
      _param1 = new 딯();
      떁 떁1 = 땥.땴.땄(obj2.딟, obj1.딟 - obj2.딟);
      떁 떁2 = 땥.땴.땄(obj2.딟, obj1.땄 - obj2.딟) - 떁1;
      float num1 = 0.0f;
      float num2 = obj1.딟;
      int index1 = -1;
      for (int index2 = 0; index2 < this.땄.Count; ++index2)
      {
        float num3 = 떁.딶(this.딟[index2], this.땄[index2] - 떁1);
        float num4 = 떁.딶(this.딟[index2], 떁2);
        if ((double) num4 == 0.0)
        {
          if ((double) num3 < 0.0)
            return false;
        }
        else if ((double) num4 < 0.0 && (double) num3 < (double) num1 * (double) num4)
        {
          num1 = num3 / num4;
          index1 = index2;
        }
        else if ((double) num4 > 0.0 && (double) num3 < (double) num2 * (double) num4)
          num2 = num3 / num4;
        if ((double) num2 < (double) num1)
          return false;
      }
      if (index1 < 0)
        return false;
      _param1.딟 = num1;
      _param1.딟 = 땥.땴.딟(obj2.딟, this.딟[index1]);
      return true;
    }

    public override void 딟(out AABB _param1, [In] ref 땥.떓 obj1, [In] int obj2)
    {
      떁 떁1 = 땥.땴.딟(ref obj1, this.땄[0]);
      떁 떁2 = 떁1;
      for (int index = 1; index < this.땄.Count; ++index)
      {
        떁 떁3 = 땥.땴.딟(ref obj1, this.땄[index]);
        떁1 = 떁.땺(떁1, 떁3);
        떁2 = 떁.땓(떁2, 떁3);
      }
      떁 떁4 = new 떁(this.딶(), this.딶());
      _param1.LowerBound = 떁1 - 떁4;
      _param1.UpperBound = 떁2 + 떁4;
    }

    public bool 딟([In] 떅 obj0)
    {
      if (this.땄.Count != obj0.땄.Count)
        return false;
      for (int index = 0; index < this.땄.Count; ++index)
      {
        if (this.땄[index] != obj0.땄[index])
          return false;
      }
      return (double) this.딶() == (double) obj0.딶() && base.딟 == ((땏) obj0).딟;
    }

    public override float 딟([In] 떁 obj0, [In] float obj1, [In] 땥.떓 obj2, out 떁 _param4)
    {
      _param4 = 떁.딟();
      떁 떁1 = 땥.땴.땄(obj2.딟, obj0);
      float num1 = obj1 - 떁.딶(obj0, obj2.딟);
      float[] numArray = new float[딝.땥.땺];
      int num2 = 0;
      int index1 = -1;
      int index2 = -1;
      bool flag1 = false;
      for (int index3 = 0; index3 < this.땄.Count; ++index3)
      {
        numArray[index3] = 떁.딶(떁1, this.땄[index3]) - num1;
        bool flag2 = (double) numArray[index3] < -1.19209289550781E-07;
        if (index3 > 0)
        {
          if (flag2)
          {
            if (!flag1)
            {
              index1 = index3 - 1;
              ++num2;
            }
          }
          else if (flag1)
          {
            index2 = index3 - 1;
            ++num2;
          }
        }
        flag1 = flag2;
      }
      switch (num2)
      {
        case 0:
          if (!flag1)
            return 0.0f;
          _param4 = 땥.땴.딟(ref obj2, base.딟.딟);
          return base.딟.딧 / this.땃();
        case 1:
          if (index1 == -1)
          {
            index1 = this.땄.Count - 1;
            break;
          }
          index2 = this.땄.Count - 1;
          break;
      }
      int index4 = (index1 + 1) % this.땄.Count;
      int index5 = (index2 + 1) % this.땄.Count;
      float num3 = (float) ((0.0 - (double) numArray[index1]) / ((double) numArray[index4] - (double) numArray[index1]));
      float num4 = (float) ((0.0 - (double) numArray[index2]) / ((double) numArray[index5] - (double) numArray[index2]));
      떁 떁2 = new 떁((float) ((double) this.땄[index1].딟 * (1.0 - (double) num3) + (double) this.땄[index4].딟 * (double) num3), (float) ((double) this.땄[index1].땄 * (1.0 - (double) num3) + (double) this.땄[index4].땄 * (double) num3));
      떁 떁3 = new 떁((float) ((double) this.땄[index2].딟 * (1.0 - (double) num4) + (double) this.땄[index5].딟 * (double) num4), (float) ((double) this.땄[index2].땄 * (1.0 - (double) num4) + (double) this.땄[index5].땄 * (double) num4));
      float num5 = 0.0f;
      떁 떁4 = new 떁(0.0f, 0.0f);
      떁 떁5 = this.땄[index4];
      float num6 = 0.3333333f;
      int index6 = index4;
      while (index6 != index5)
      {
        index6 = (index6 + 1) % this.땄.Count;
        떁 떁6 = index6 != index5 ? this.땄[index6] : 떁3;
        float num7 = 0.5f * 땥.땴.딟(떁5 - 떁2, 떁6 - 떁2);
        num5 += num7;
        떁4 += num7 * num6 * (떁2 + 떁5 + 떁6);
        떁5 = 떁6;
      }
      떁 떁7 = 떁4 * (1f / num5);
      _param4 = 땥.땴.딟(ref obj2, 떁7);
      return num5;
    }

    public bool 딢()
    {
      for (int index1 = 0; index1 < this.땄.Count; ++index1)
      {
        int index2 = index1;
        int index3 = index1 >= this.땄.Count - 1 ? 0 : index2 + 1;
        떁 떁1 = this.땄[index2];
        떁 떁2 = this.땄[index3] - 떁1;
        for (int index4 = 0; index4 < this.땄.Count; ++index4)
        {
          if (index4 != index2 && index4 != index3)
          {
            떁 떁3 = this.땄[index4] - 떁1;
            if ((double) 땥.땴.딟(떁2, 떁3) < 0.0)
              return false;
          }
        }
      }
      return true;
    }
  }
}
