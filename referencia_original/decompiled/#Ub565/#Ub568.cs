// Decompiled with JetBrains decompiler
// Type: 땥.땨
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using FarseerPhysics.Collision;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace 땥
{
  [DebuggerDisplay("Count = {Count} Vertices = {ToString()}")]
  public class 땨 : List<떁>
  {
    public 땨()
    {
    }

    public 땨([In] int obj0) => this.Capacity = obj0;

    public 땨([In] 떁[] obj0)
    {
      for (int index = 0; index < obj0.Length; ++index)
        this.Add(obj0[index]);
    }

    public 땨([In] IList<떁> obj0)
    {
      for (int index = 0; index < obj0.Count; ++index)
        this.Add(obj0[index]);
    }

    public int 딟([In] int obj0) => obj0 == this.Count - 1 ? 0 : obj0 + 1;

    public 떁 땄([In] int obj0) => this[this.딟(obj0)];

    public int 딧([In] int obj0) => obj0 == 0 ? this.Count - 1 : obj0 - 1;

    public 떁 딢([In] int obj0) => this[this.딧(obj0)];

    public float 딟()
    {
      float num = 0.0f;
      for (int index1 = 0; index1 < this.Count; ++index1)
      {
        int index2 = (index1 + 1) % this.Count;
        num = (float) ((double) num + (double) this[index1].딟 * (double) this[index2].땄 - (double) this[index1].땄 * (double) this[index2].딟);
      }
      return num / 2f;
    }

    public float 땄()
    {
      float num1 = 0.0f;
      for (int index1 = 0; index1 < this.Count; ++index1)
      {
        int index2 = (index1 + 1) % this.Count;
        num1 = (float) ((double) num1 + (double) this[index1].딟 * (double) this[index2].땄 - (double) this[index1].땄 * (double) this[index2].딟);
      }
      float num2 = num1 / 2f;
      return (double) num2 < 0.0 ? -num2 : num2;
    }

    public 떁 딧()
    {
      떁 떁1 = 떁.딟();
      float num1 = 0.0f;
      떁 떁2 = 떁.딟();
      for (int index = 0; index < this.Count; ++index)
      {
        떁 떁3 = 떁2;
        떁 떁4 = this[index];
        떁 떁5 = index + 1 >= this.Count ? this[0] : this[index + 1];
        float num2 = 0.5f * 땴.딟(떁4 - 떁3, 떁5 - 떁3);
        num1 += num2;
        떁1 += num2 * 0.3333333f * (떁3 + 떁4 + 떁5);
      }
      return 떁1 * (1f / num1);
    }

    public float 딢()
    {
      double d = (double) this.딟() / 3.14159274101257;
      if (d < 0.0)
        d *= -1.0;
      return (float) Math.Sqrt(d);
    }

    public AABB 땃()
    {
      떁 떁1 = new 떁(float.MaxValue, float.MaxValue);
      떁 떁2 = new 떁(float.MinValue, float.MinValue);
      for (int index = 0; index < this.Count; ++index)
      {
        if ((double) this[index].딟 < (double) 떁1.딟)
          떁1.딟 = this[index].딟;
        if ((double) this[index].딟 > (double) 떁2.딟)
          떁2.딟 = this[index].딟;
        if ((double) this[index].땄 < (double) 떁1.땄)
          떁1.땄 = this[index].땄;
        if ((double) this[index].땄 > (double) 떁2.땄)
          떁2.땄 = this[index].땄;
      }
      AABB aabb;
      aabb.LowerBound = 떁1;
      aabb.UpperBound = 떁2;
      return aabb;
    }

    public void 딟([In] 떁 obj0) => this.딟(ref obj0);

    public void 딟([In] ref 떁 obj0)
    {
      for (int index = 0; index < this.Count; ++index)
        this[index] = 떁.땄(this[index], obj0);
    }

    public void 땄([In] ref 떁 obj0)
    {
      for (int index = 0; index < this.Count; ++index)
        this[index] = 떁.땥(this[index], obj0);
    }

    public void 딟([In] float obj0)
    {
      딷 딷;
      딷.딧(obj0, out 딷);
      for (int index = 0; index < this.Count; ++index)
        this[index] = 떁.딟(this[index], 딷);
    }

    public bool 딶()
    {
      for (int index1 = 0; index1 < this.Count; ++index1)
      {
        int index2 = index1;
        int index3 = index1 + 1 >= this.Count ? 0 : index1 + 1;
        떁 떁1 = this[index3] - this[index2];
        for (int index4 = 0; index4 < this.Count; ++index4)
        {
          if (index4 != index2 && index4 != index3)
          {
            떁 떁2 = this[index4] - this[index2];
            if ((double) 떁1.딟 * (double) 떁2.땄 - (double) 떁1.땄 * (double) 떁2.딟 <= 0.0)
              return false;
          }
        }
      }
      return true;
    }

    public bool 땓() => this.Count < 3 || (double) this.딟() > 0.0;

    public void 땺()
    {
      if (this.땓())
        return;
      this.Reverse();
    }

    public bool 땥()
    {
      for (int index1 = 0; index1 < this.Count; ++index1)
      {
        int index2 = index1 + 1 <= this.Count - 1 ? index1 + 1 : 0;
        떁 떁1 = new 떁(this[index1].딟, this[index1].땄);
        떁 떁2 = new 떁(this[index2].딟, this[index2].땄);
        for (int index3 = index1 + 1; index3 < this.Count; ++index3)
        {
          int index4 = index3 + 1 <= this.Count - 1 ? index3 + 1 : 0;
          떁 떁3 = new 떁(this[index3].딟, this[index3].땄);
          떁 떁4 = new 떁(this[index4].딟, this[index4].땄);
          if (땠.딟(떁1, 떁2, 떁3, 떁4, out 떁 _))
            return false;
        }
      }
      return true;
    }

    public bool 딝()
    {
      for (int index1 = 0; index1 < this.Count; ++index1)
      {
        if (index1 < this.Count - 1)
        {
          for (int index2 = index1 + 1; index2 < this.Count; ++index2)
          {
            if (this[index1] == this[index2])
              return true;
          }
        }
        int index3 = (index1 + 1) % this.Count;
        떁 떁1 = this[index3] - this[index1];
        떁 떁2 = new 떁(떁1.땄, -떁1.딟);
        int num1 = (index3 + 1) % this.Count;
        int num2 = (index1 - 1 + this.Count) % this.Count;
        int num3 = num2 + (num1 >= num2 ? num1 + 1 : 0);
        int index4 = num1;
        bool flag = (double) 떁.딶(this[index4] - this[index1], 떁2) >= 0.0;
        떁 떁3 = this[index4];
        for (int index5 = index4 + 1; index5 <= num3; ++index5)
        {
          int index6 = index5 % this.Count;
          떁 떁4 = this[index6] - this[index1];
          if (flag != (double) 떁.딶(떁4, 떁2) >= 0.0)
          {
            떁 떁5 = this[index6] - 떁3;
            떁 떁6 = new 떁(떁5.땄, -떁5.딟);
            if ((double) 떁.딶(this[index1] - 떁3, 떁6) >= 0.0 != (double) 떁.딶(this[index3] - 떁3, 떁6) >= 0.0)
              return true;
          }
          flag = (double) 떁.딶(떁4, 떁2) > 0.0;
          떁3 = this[index6];
        }
      }
      return false;
    }

    public bool 딟(out int _param1, out string _param2)
    {
      _param1 = -1;
      _param2 = (string) null;
      if (this.Count < 3 || this.Count > 딝.땥.땺)
        _param1 = 0;
      if (!this.딶())
        _param1 = 1;
      if (!this.땥())
        _param1 = 2;
      if ((double) this.땄() < 1.19209289550781E-07)
        _param1 = 3;
      떁[] 떁Array = new 떁[this.Count];
      땨 땨 = new 땨(this.Count);
      for (int index1 = 0; index1 < this.Count; ++index1)
      {
        땨.Add(new 떁(this[index1].딟, this[index1].땄));
        int index2 = index1;
        int index3 = index1 + 1 >= this.Count ? 0 : index1 + 1;
        떁 떁 = new 떁(this[index3].딟 - this[index2].딟, this[index3].땄 - this[index2].땄);
        떁Array[index1] = 땴.딟(떁, 1f);
        떁Array[index1].땓();
      }
      for (int index4 = 0; index4 < this.Count; ++index4)
      {
        int index5 = index4 != 0 ? index4 - 1 : this.Count - 1;
        if (Math.Asin((double) 땴.딟(땴.딟(떁Array[index5], 떁Array[index4]), -1f, 1f)) <= 0.0349065884947777)
        {
          _param1 = 4;
          break;
        }
        for (int index6 = 0; index6 < this.Count; ++index6)
        {
          if (index6 != index4 && index6 != (index4 + 1) % this.Count && (double) 떁.딶(떁Array[index4], 땨[index6] - 땨[index4]) >= -0.00499999988824129)
            _param1 = 5;
        }
        떁 떁1 = 땨.딧();
        떁 떁2 = 떁Array[index5];
        떁 떁3 = 떁Array[index4];
        떁 떁4 = 땨[index4] - 떁1;
        떁 떁5 = new 떁();
        떁5.딟 = 떁.딶(떁2, 떁4);
        떁5.땄 = 떁.딶(떁3, 떁4);
        if ((double) 떁5.딟 < 0.0 || (double) 떁5.땄 < 0.0)
          _param1 = 6;
      }
      if (_param1 != -1)
      {
        switch (_param1)
        {
          case 0:
            _param2 = string.Format("Polygon error: must have between 3 and {0} vertices.", (object) 딝.땥.땺);
            break;
          case 1:
            _param2 = "Polygon error: must be convex.";
            break;
          case 2:
            _param2 = "Polygon error: must be simple (cannot intersect itself).";
            break;
          case 3:
            _param2 = "Polygon error: area is too small.";
            break;
          case 4:
            _param2 = "Polygon error: sides are too close to parallel.";
            break;
          case 5:
            _param2 = "Polygon error: polygon is too thin.";
            break;
          case 6:
            _param2 = "Polygon error: core shape generation would move edge past centroid (too thin).";
            break;
          default:
            _param2 = "Polygon error: error " + _param1.ToString();
            break;
        }
      }
      return _param1 != -1;
    }

    public bool 떎()
    {
      string str;
      bool flag = this.딟(out int _, out str);
      if (flag || str == null)
        ;
      return flag;
    }

    public 땨 딟([In] 땨 obj0)
    {
      땨.땒[] 땒Array = new 땨.땒[obj0.Count * obj0.Count];
      int index1 = 0;
      for (int index2 = 0; index2 < obj0.Count; ++index2)
      {
        떁 떁 = new 떁(obj0[index2].딟, obj0[index2].땄);
        땒Array[index2].딟 = 떁;
        ++index1;
        int index3 = index2 != obj0.Count - 1 ? index2 + 1 : 0;
        int index4 = index2 != 0 ? index2 - 1 : obj0.Count - 1;
        땒Array[index2].딟(땒Array[index3]);
        땒Array[index2].딟(땒Array[index4]);
      }
      bool flag1 = true;
      int num1 = 0;
      while (flag1)
      {
        flag1 = false;
        for (int index5 = 0; index5 < index1; ++index5)
        {
          for (int index6 = 0; index6 < 땒Array[index5].땄; ++index6)
          {
            for (int index7 = 0; index7 < index1; ++index7)
            {
              if (index7 != index5 && 땒Array[index7] != 땒Array[index5].딟[index6])
              {
                for (int index8 = 0; index8 < 땒Array[index7].땄; ++index8)
                {
                  떁 떁;
                  if (땒Array[index7].딟[index8] != 땒Array[index5].딟[index6] && 땒Array[index7].딟[index8] != 땒Array[index5] && 땠.땄(땒Array[index5].딟, 땒Array[index5].딟[index6].딟, 땒Array[index7].딟, 땒Array[index7].딟[index8].딟, out 떁))
                  {
                    flag1 = true;
                    땨.땒 땒1 = 땒Array[index5].딟[index6];
                    땨.땒 땒2 = 땒Array[index7].딟[index8];
                    땒Array[index5].딟[index6].땄(땒Array[index5]);
                    땒Array[index5].땄(땒1);
                    땒Array[index7].딟[index8].땄(땒Array[index7]);
                    땒Array[index7].땄(땒2);
                    땒Array[index1] = new 땨.땒(떁);
                    땒Array[index1].딟(땒Array[index5]);
                    땒Array[index5].딟(땒Array[index1]);
                    땒Array[index1].딟(땒Array[index7]);
                    땒Array[index7].딟(땒Array[index1]);
                    땒Array[index1].딟(땒1);
                    땒1.딟(땒Array[index1]);
                    땒Array[index1].딟(땒2);
                    땒2.딟(땒Array[index1]);
                    ++index1;
                    goto label_19;
                  }
                }
              }
            }
          }
        }
label_19:
        ++num1;
      }
      bool flag2 = true;
      int num2 = index1;
      while (flag2)
      {
        flag2 = false;
        for (int index9 = 0; index9 < index1; ++index9)
        {
          if (땒Array[index9].땄 != 0)
          {
            for (int index10 = index9 + 1; index10 < index1; ++index10)
            {
              if (땒Array[index10].땄 != 0 && (double) (땒Array[index9].딟 - 땒Array[index10].딟).딶() <= 1.4210854715202E-14)
              {
                if (num2 <= 3)
                  return new 땨();
                --num2;
                flag2 = true;
                땨.땒 땒3 = 땒Array[index9];
                땨.땒 땒4 = 땒Array[index10];
                int 땄 = 땒4.땄;
                for (int index11 = 0; index11 < 땄; ++index11)
                {
                  땨.땒 땒5 = 땒4.딟[index11];
                  if (땒5 != 땒3)
                  {
                    땒3.딟(땒5);
                    땒5.딟(땒3);
                  }
                  땒5.땄(땒4);
                }
                땒4.땄 = 0;
              }
            }
          }
        }
      }
      float num3 = float.MaxValue;
      float num4 = float.MinValue;
      int index12 = -1;
      for (int index13 = 0; index13 < index1; ++index13)
      {
        if ((double) 땒Array[index13].딟.땄 < (double) num3 && 땒Array[index13].땄 > 1)
        {
          num3 = 땒Array[index13].딟.땄;
          index12 = index13;
          num4 = 땒Array[index13].딟.딟;
        }
        else if ((double) 땒Array[index13].딟.땄 == (double) num3 && (double) 땒Array[index13].딟.딟 > (double) num4 && 땒Array[index13].땄 > 1)
        {
          index12 = index13;
          num4 = 땒Array[index13].딟.딟;
        }
      }
      떁 떁1 = new 떁(1f, 0.0f);
      떁[] 떁Array = new 떁[4 * index1];
      int num5 = 0;
      땨.땒 땒6 = 땒Array[index12];
      땨.땒 땒7 = 땒6;
      땨.땒 땒8 = 땒6.딟(떁1);
      if (땒8 == null)
      {
        땨 땨 = new 땨(num5);
        for (int index14 = 0; index14 < num5; ++index14)
          땨.Add(떁Array[index14]);
        return 땨;
      }
      떁Array[0] = 땒7.딟;
      int num6 = num5 + 1;
      while (땒8 != 땒7)
      {
        if (num6 <= 4 * index1)
          ;
        떁Array[num6++] = 땒8.딟;
        땨.땒 땒9 = 땒6;
        땒6 = 땒8;
        땒8 = 땒6.딧(땒9);
        if (땒8 == null)
        {
          땨 땨 = new 땨(num6);
          for (int index15 = 0; index15 < num6; ++index15)
            땨.Add(떁Array[index15]);
          return 땨;
        }
      }
      return new 땨();
    }

    public List<땨> 떂()
    {
      List<땨> 땨List = new List<땨>();
      List<떁> 떁List = new List<떁>();
      int num = 0;
      int index1 = 0;
      bool flag = false;
      땨List.Add(new 땨());
      for (int index2 = 0; index2 < this.Count; ++index2)
      {
        for (int index3 = index2 + 1; index3 < this.Count; ++index3)
        {
          if (this[index2] == this[index3])
            떁List.Add(this[index2]);
        }
        if (flag)
        {
          flag = false;
        }
        else
        {
          땨List[index1].Add(this[index2]);
          if (떁List.Contains(this[index2]))
          {
            if (index1 == 0)
            {
              ++num;
              index1 = num;
              땨List.Add(new 땨());
            }
            else
              index1 = 0;
            flag = true;
          }
        }
      }
      return 땨List;
    }

    public override string ToString()
    {
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < this.Count; ++index)
      {
        stringBuilder.Append(this[index].ToString());
        if (index < this.Count - 1)
          stringBuilder.Append(" ");
      }
      return stringBuilder.ToString();
    }

    public void 딟([In] ref 떁 obj0, out float _param2, out float _param3)
    {
      float num1 = 떁.딶(obj0, this[0]);
      _param2 = num1;
      _param3 = num1;
      for (int index = 0; index < this.Count; ++index)
      {
        float num2 = 떁.딶(this[index], obj0);
        if ((double) num2 < (double) _param2)
          _param2 = num2;
        else if ((double) num2 > (double) _param3)
          _param3 = num2;
      }
    }

    public int 딧([In] ref 떁 obj0)
    {
      int num1 = 0;
      for (int index = 0; index < this.Count; ++index)
      {
        떁 떁1 = this[index];
        떁 떁2 = this[this.딟(index)];
        떁 떁3 = 떁2 - 떁1;
        float num2 = 땴.딟(ref 떁1, ref 떁2, ref obj0);
        if ((double) num2 == 0.0 && (double) 떁.딶(obj0 - 떁1, 떁3) >= 0.0 && (double) 떁.딶(obj0 - 떁2, 떁3) <= 0.0)
          return 0;
        if ((double) 떁1.땄 <= (double) obj0.땄)
        {
          if ((double) 떁2.땄 > (double) obj0.땄 && (double) num2 > 0.0)
            ++num1;
        }
        else if ((double) 떁2.땄 <= (double) obj0.땄 && (double) num2 < 0.0)
          --num1;
      }
      return num1 == 0 ? -1 : 1;
    }

    public bool 딢([In] ref 떁 obj0)
    {
      double num = 0.0;
      for (int index = 0; index < this.Count; ++index)
      {
        떁 떁1 = this[index] - obj0;
        떁 떁2 = this[this.딟(index)] - obj0;
        num += 땴.딟(ref 떁1, ref 떁2);
      }
      return Math.Abs(num) >= Math.PI;
    }

    private class 땒
    {
      private const int 딟 = 32;
      public 땨.땒[] 딟 = new 땨.땒[32];
      public int 땄;
      public 떁 딟;

      public 땒([In] 떁 obj0)
      {
        this.딟 = obj0;
        this.땄 = 0;
      }

      private bool 딟([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3) => (double) obj0 < 0.0 ? (double) obj2 > 0.0 || (double) obj1 <= (double) obj3 : (double) obj2 >= 0.0 && (double) obj1 > (double) obj3;

      public void 딟([In] 땨.땒 obj0)
      {
        for (int index = 0; index < this.땄; ++index)
        {
          if (this.딟[index] == obj0)
            return;
        }
        this.딟[this.땄] = obj0;
        ++this.땄;
      }

      public void 땄([In] 땨.땒 obj0)
      {
        bool flag = false;
        int num = -1;
        for (int index = 0; index < this.땄; ++index)
        {
          if (obj0 == this.딟[index])
          {
            flag = true;
            num = index;
            break;
          }
        }
        --this.땄;
        for (int index = num; index < this.땄; ++index)
          this.딟[index] = this.딟[index + 1];
      }

      public 땨.땒 딧([In] 땨.땒 obj0)
      {
        if (this.땄 != 0)
          ;
        if (this.땄 == 1)
          return obj0;
        떁 떁1 = this.딟 - obj0.딟;
        떁1.땃();
        떁1.땓();
        땨.땒 땒 = (땨.땒) null;
        for (int index = 0; index < this.땄; ++index)
        {
          if (this.딟[index] != obj0)
          {
            떁 떁2 = this.딟[index].딟 - this.딟;
            떁2.딶();
            떁2.땓();
            float num1 = 떁.딶(떁1, 떁2);
            float num2 = 땴.딟(떁1, 떁2);
            if (땒 != null)
            {
              떁 떁3 = 땒.딟 - this.딟;
              떁3.땓();
              float num3 = 떁.딶(떁1, 떁3);
              float num4 = 땴.딟(떁1, 떁3);
              if (this.딟(num2, num1, num4, num3))
                땒 = this.딟[index];
            }
            else
              땒 = this.딟[index];
          }
        }
        return 땒;
      }

      public 땨.땒 딟([In] 떁 obj0) => this.딧(new 땨.땒(this.딟 - obj0));
    }
  }
}
