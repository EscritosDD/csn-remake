// Decompiled with JetBrains decompiler
// Type: 땺.땒`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using FarseerPhysics.Collision;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using 땥;

namespace 땺
{
  public class 땒<딟>
  {
    internal const int 딟 = (int) new Stack<int>(256);
    private static Stack<int> 딟;
    private int 땄;
    private int 딧;
    private int 딢;
    private int 땃;
    private 땨<딟>[] 딟;
    private int 딶;

    public 땒()
    {
      this.딶 = -1;
      this.딢 = 16;
      this.땃 = 0;
      this.딟 = (int) new 땨<딟>[this.딢];
      for (int index = 0; index < this.딢 - 1; ++index)
      {
        this.딟[index] = (object) new 땨<딟>();
        ((땨<딟>) this.딟[index]).딢 = index + 1;
        ((땨<딟>) this.딟[index]).딧 = 1;
      }
      this.딟[this.딢 - 1] = (object) new 땨<딟>();
      ((땨<딟>) this.딟[this.딢 - 1]).딢 = -1;
      ((땨<딟>) this.딟[this.딢 - 1]).딧 = 1;
      this.땄 = 0;
      this.딧 = 0;
    }

    [SpecialName]
    public int 딟() => throw new NotImplementedException();

    [SpecialName]
    public void 딟([In] int obj0) => throw new NotImplementedException();

    public int 딟([In] ref AABB obj0, [In] 딟 obj1)
    {
      int index = this.땄();
      떁 떁 = new 떁(0.1f, 0.1f);
      ((땨<딟>) this.딟[index]).딟.LowerBound = obj0.LowerBound - 떁;
      ((땨<딟>) this.딟[index]).딟.UpperBound = obj0.UpperBound + 떁;
      ((땨<딟>) this.딟[index]).딟 = (AABB) obj1;
      ((땨<딟>) this.딟[index]).딧 = 0;
      this.딶(index);
      return index;
    }

    public void 땄([In] int obj0)
    {
      this.땓(obj0);
      this.땃(obj0);
    }

    public bool 딟([In] int obj0, [In] ref AABB obj1, [In] 떁 obj2)
    {
      if (((땨<딟>) this.딟[obj0]).딟.땄(ref obj1))
        return false;
      this.땓(obj0);
      AABB aabb = obj1;
      떁 떁1 = new 떁(0.1f, 0.1f);
      aabb.LowerBound -= 떁1;
      aabb.UpperBound += 떁1;
      떁 떁2 = 2f * obj2;
      if ((double) 떁2.딟 < 0.0)
        aabb.LowerBound.딟 += 떁2.딟;
      else
        aabb.UpperBound.딟 += 떁2.딟;
      if ((double) 떁2.땄 < 0.0)
        aabb.LowerBound.땄 += 떁2.땄;
      else
        aabb.UpperBound.땄 += 떁2.땄;
      ((땨<딟>) this.딟[obj0]).딟 = aabb;
      this.딶(obj0);
      return true;
    }

    public 딟 딧([In] int obj0) => (딟) ((땨<딟>) this.딟[obj0]).딟;

    public void 딟([In] int obj0, out AABB _param2) => _param2 = ((땨<딟>) this.딟[obj0]).딟;

    public void 딟([In] Func<int, bool> obj0, [In] ref AABB obj1)
    {
      ((Stack<int>) 땒<딟>.딟).Clear();
      ((Stack<int>) 땒<딟>.딟).Push(this.딶);
      while (((Stack<int>) 땒<딟>.딟).Count > 0)
      {
        int index = ((Stack<int>) 땒<딟>.딟).Pop();
        if (index != -1)
        {
          땨<딟> 땨 = (땨<딟>) this.딟[index];
          if (AABB.땄(ref 땨.딟, ref obj1))
          {
            if (땨.딟())
            {
              if (!obj0(index))
                break;
            }
            else
            {
              ((Stack<int>) 땒<딟>.딟).Push((int) 땨.딟);
              ((Stack<int>) 땒<딟>.딟).Push(땨.땄);
            }
          }
        }
      }
    }

    public void 딟([In] Func<딮, int, float> obj0, [In] ref 딮 obj1)
    {
      떁 딟 = obj1.딟;
      떁 땄 = obj1.땄;
      떁 떁1 = 땄 - 딟;
      떁1.땓();
      떁 떁2 = 땥.땴.딟(new 떁(-떁1.땄, 떁1.딟));
      float num1 = obj1.딟;
      AABB aabb = new AABB();
      떁 떁3 = 딟 + num1 * (땄 - 딟);
      떁.땃(ref 딟, ref 떁3, out aabb.LowerBound);
      떁.딢(ref 딟, ref 떁3, out aabb.UpperBound);
      ((Stack<int>) 땒<딟>.딟).Clear();
      ((Stack<int>) 땒<딟>.딟).Push(this.딶);
      while (((Stack<int>) 땒<딟>.딟).Count > 0)
      {
        int index = ((Stack<int>) 땒<딟>.딟).Pop();
        if (index != -1)
        {
          땨<딟> 땨 = (땨<딟>) this.딟[index];
          if (AABB.땄(ref 땨.딟, ref aabb))
          {
            떁 떁4 = 땨.딟.딟();
            떁 떁5 = 땨.딟.땄();
            if ((double) (Math.Abs(떁.딶(new 떁(-떁1.땄, 떁1.딟), 딟 - 떁4)) - 떁.딶(떁2, 떁5)) <= 0.0)
            {
              if (땨.딟())
              {
                딮 딮;
                딮.딟 = obj1.딟;
                딮.땄 = obj1.땄;
                딮.딟 = num1;
                float num2 = obj0(딮, index);
                if ((double) num2 == 0.0)
                  break;
                if ((double) num2 > 0.0)
                {
                  num1 = num2;
                  떁 떁6 = 딟 + num1 * (땄 - 딟);
                  aabb.LowerBound = 떁.땺(딟, 떁6);
                  aabb.UpperBound = 떁.땓(딟, 떁6);
                }
              }
              else
              {
                ((Stack<int>) 땒<딟>.딟).Push((int) 땨.딟);
                ((Stack<int>) 땒<딟>.딟).Push(땨.땄);
              }
            }
          }
        }
      }
    }

    private int 딢([In] int obj0)
    {
      if (obj0 == -1)
        return 0;
      땨<딟> 땨 = (땨<딟>) this.딟[obj0];
      return 땨.딟() ? 1 : this.딢((int) 땨.딟) + this.딢(땨.땄);
    }

    private int 땄()
    {
      if (this.땄 == -1)
      {
        땨<딟>[] 딟 = (땨<딟>[]) this.딟;
        this.딢 *= 2;
        this.딟 = (int) new 땨<딟>[this.딢];
        Array.Copy((Array) 딟, (Array) this.딟, this.땃);
        for (int 땃 = this.땃; 땃 < this.딢 - 1; ++땃)
        {
          this.딟[땃] = (object) new 땨<딟>();
          ((땨<딟>) this.딟[땃]).딢 = 땃 + 1;
          ((땨<딟>) this.딟[땃]).딧 = 1;
        }
        this.딟[this.딢 - 1] = (object) new 땨<딟>();
        ((땨<딟>) this.딟[this.딢 - 1]).딢 = -1;
        ((땨<딟>) this.딟[this.딢 - 1]).딧 = 1;
        this.땄 = this.땃;
      }
      int 땄 = this.땄;
      this.땄 = ((땨<딟>) this.딟[땄]).딢;
      ((땨<딟>) this.딟[땄]).딢 = -1;
      ((땨<딟>) this.딟[땄]).딟 = (AABB) -1;
      ((땨<딟>) this.딟[땄]).땄 = -1;
      ((땨<딟>) this.딟[땄]).딧 = 0;
      ((땨<딟>) this.딟[땄]).딟 = (AABB) default (딟);
      ++this.땃;
      return 땄;
    }

    private void 땃([In] int obj0)
    {
      ((땨<딟>) this.딟[obj0]).딢 = this.땄;
      ((땨<딟>) this.딟[obj0]).딧 = -1;
      this.땄 = obj0;
      --this.땃;
    }

    private void 딶([In] int obj0)
    {
      ++this.딧;
      if (this.딶 == -1)
      {
        this.딶 = obj0;
        ((땨<딟>) this.딟[this.딶]).딢 = -1;
      }
      else
      {
        AABB 딟1 = ((땨<딟>) this.딟[obj0]).딟;
        int index1;
        int 딟2;
        int 땄1;
        float num1;
        float num2;
        for (index1 = this.딶; !((땨<딟>) this.딟[index1]).딟(); index1 = (double) num1 >= (double) num2 ? 땄1 : 딟2)
        {
          딟2 = (int) ((땨<딟>) this.딟[index1]).딟;
          땄1 = ((땨<딟>) this.딟[index1]).땄;
          float num3 = ((땨<딟>) this.딟[index1]).딟.딧();
          AABB aabb1 = new AABB();
          aabb1.딟(ref ((땨<딟>) this.딟[index1]).딟, ref 딟1);
          float num4 = aabb1.딧();
          float num5 = 2f * num4;
          float num6 = (float) (2.0 * ((double) num4 - (double) num3));
          if (((땨<딟>) this.딟[딟2]).딟())
          {
            AABB aabb2 = new AABB();
            aabb2.딟(ref 딟1, ref ((땨<딟>) this.딟[딟2]).딟);
            num1 = aabb2.딧() + num6;
          }
          else
          {
            AABB aabb3 = new AABB();
            aabb3.딟(ref 딟1, ref ((땨<딟>) this.딟[딟2]).딟);
            float num7 = ((땨<딟>) this.딟[딟2]).딟.딧();
            num1 = aabb3.딧() - num7 + num6;
          }
          if (((땨<딟>) this.딟[땄1]).딟())
          {
            AABB aabb4 = new AABB();
            aabb4.딟(ref 딟1, ref ((땨<딟>) this.딟[땄1]).딟);
            num2 = aabb4.딧() + num6;
          }
          else
          {
            AABB aabb5 = new AABB();
            aabb5.딟(ref 딟1, ref ((땨<딟>) this.딟[땄1]).딟);
            float num8 = ((땨<딟>) this.딟[땄1]).딟.딧();
            num2 = aabb5.딧() - num8 + num6;
          }
          if ((double) num5 < (double) num1 && (double) num1 < (double) num2)
            break;
        }
        int index2 = index1;
        int 딢1 = ((땨<딟>) this.딟[index1]).딢;
        int index3 = this.땄();
        ((땨<딟>) this.딟[index3]).딢 = 딢1;
        ((땨<딟>) this.딟[index3]).딟 = (AABB) default (딟);
        ((땨<딟>) this.딟[index3]).딟.딟(ref 딟1, ref ((땨<딟>) this.딟[index2]).딟);
        ((땨<딟>) this.딟[index3]).딧 = ((땨<딟>) this.딟[index2]).딧 + 1;
        if (딢1 != -1)
        {
          if (((땨<딟>) this.딟[딢1]).딟 == index2)
            ((땨<딟>) this.딟[딢1]).딟 = (AABB) index3;
          else
            ((땨<딟>) this.딟[딢1]).땄 = index3;
          ((땨<딟>) this.딟[index3]).딟 = (AABB) index2;
          ((땨<딟>) this.딟[index3]).땄 = obj0;
          ((땨<딟>) this.딟[index1]).딢 = index3;
          ((땨<딟>) this.딟[obj0]).딢 = index3;
        }
        else
        {
          ((땨<딟>) this.딟[index3]).딟 = (AABB) index2;
          ((땨<딟>) this.딟[index3]).땄 = obj0;
          ((땨<딟>) this.딟[index1]).딢 = index3;
          ((땨<딟>) this.딟[obj0]).딢 = index3;
          this.딶 = index3;
        }
        int index4;
        for (int 딢2 = ((땨<딟>) this.딟[obj0]).딢; 딢2 != -1; 딢2 = ((땨<딟>) this.딟[index4]).딢)
        {
          index4 = this.땺(딢2);
          int 딟3 = (int) ((땨<딟>) this.딟[index4]).딟;
          int 땄2 = ((땨<딟>) this.딟[index4]).땄;
          ((땨<딟>) this.딟[index4]).딧 = 1 + Math.Max(((땨<딟>) this.딟[딟3]).딧, ((땨<딟>) this.딟[땄2]).딧);
          ((땨<딟>) this.딟[index4]).딟.딟(ref ((땨<딟>) this.딟[딟3]).딟, ref ((땨<딟>) this.딟[땄2]).딟);
        }
      }
    }

    private void 땓([In] int obj0)
    {
      if (obj0 == this.딶)
      {
        this.딶 = -1;
      }
      else
      {
        int 딢1 = ((땨<딟>) this.딟[obj0]).딢;
        int 딢2 = ((땨<딟>) this.딟[딢1]).딢;
        int index1 = ((땨<딟>) this.딟[딢1]).딟 != obj0 ? (int) ((땨<딟>) this.딟[딢1]).딟 : ((땨<딟>) this.딟[딢1]).땄;
        if (딢2 != -1)
        {
          if (((땨<딟>) this.딟[딢2]).딟 == 딢1)
            ((땨<딟>) this.딟[딢2]).딟 = (AABB) index1;
          else
            ((땨<딟>) this.딟[딢2]).땄 = index1;
          ((땨<딟>) this.딟[index1]).딢 = 딢2;
          this.땃(딢1);
          int index2;
          for (int index3 = 딢2; index3 != -1; index3 = ((땨<딟>) this.딟[index2]).딢)
          {
            index2 = this.땺(index3);
            int 딟 = (int) ((땨<딟>) this.딟[index2]).딟;
            int 땄 = ((땨<딟>) this.딟[index2]).땄;
            ((땨<딟>) this.딟[index2]).딟.딟(ref ((땨<딟>) this.딟[딟]).딟, ref ((땨<딟>) this.딟[땄]).딟);
            ((땨<딟>) this.딟[index2]).딧 = 1 + Math.Max(((땨<딟>) this.딟[딟]).딧, ((땨<딟>) this.딟[땄]).딧);
          }
        }
        else
        {
          this.딶 = index1;
          ((땨<딟>) this.딟[index1]).딢 = -1;
          this.땃(딢1);
        }
      }
    }

    public int 딧() => this.딶 == -1 ? 0 : ((땨<딟>) this.딟[this.딶]).딧;

    private int 땺([In] int obj0)
    {
      땨<딟> 땨1 = (땨<딟>) this.딟[obj0];
      if (땨1.딟() || 땨1.딧 < 2)
        return obj0;
      int 딟1 = (int) 땨1.딟;
      int 땄1 = 땨1.땄;
      땨<딟> 땨2 = (땨<딟>) this.딟[딟1];
      땨<딟> 땨3 = (땨<딟>) this.딟[땄1];
      int num = 땨3.딧 - 땨2.딧;
      if (num > 1)
      {
        int 딟2 = (int) 땨3.딟;
        int 땄2 = 땨3.땄;
        땨<딟> 땨4 = (땨<딟>) this.딟[딟2];
        땨<딟> 땨5 = (땨<딟>) this.딟[땄2];
        땨3.딟 = (AABB) obj0;
        땨3.딢 = 땨1.딢;
        땨1.딢 = 땄1;
        if (땨3.딢 != -1)
        {
          if (((땨<딟>) this.딟[땨3.딢]).딟 == obj0)
            ((땨<딟>) this.딟[땨3.딢]).딟 = (AABB) 땄1;
          else
            ((땨<딟>) this.딟[땨3.딢]).땄 = 땄1;
        }
        else
          this.딶 = 땄1;
        if (땨4.딧 > 땨5.딧)
        {
          땨3.땄 = 딟2;
          땨1.땄 = 땄2;
          땨5.딢 = obj0;
          땨1.딟.딟(ref 땨2.딟, ref 땨5.딟);
          땨3.딟.딟(ref 땨1.딟, ref 땨4.딟);
          땨1.딧 = 1 + Math.Max(땨2.딧, 땨5.딧);
          땨3.딧 = 1 + Math.Max(땨1.딧, 땨4.딧);
        }
        else
        {
          땨3.땄 = 땄2;
          땨1.땄 = 딟2;
          땨4.딢 = obj0;
          땨1.딟.딟(ref 땨2.딟, ref 땨4.딟);
          땨3.딟.딟(ref 땨1.딟, ref 땨5.딟);
          땨1.딧 = 1 + Math.Max(땨2.딧, 땨4.딧);
          땨3.딧 = 1 + Math.Max(땨1.딧, 땨5.딧);
        }
        return 땄1;
      }
      if (num >= -1)
        return obj0;
      int 딟3 = (int) 땨2.딟;
      int 땄3 = 땨2.땄;
      땨<딟> 땨6 = (땨<딟>) this.딟[딟3];
      땨<딟> 땨7 = (땨<딟>) this.딟[땄3];
      땨2.딟 = (AABB) obj0;
      땨2.딢 = 땨1.딢;
      땨1.딢 = 딟1;
      if (땨2.딢 != -1)
      {
        if (((땨<딟>) this.딟[땨2.딢]).딟 == obj0)
          ((땨<딟>) this.딟[땨2.딢]).딟 = (AABB) 딟1;
        else
          ((땨<딟>) this.딟[땨2.딢]).땄 = 딟1;
      }
      else
        this.딶 = 딟1;
      if (땨6.딧 > 땨7.딧)
      {
        땨2.땄 = 딟3;
        땨1.딟 = (AABB) 땄3;
        땨7.딢 = obj0;
        땨1.딟.딟(ref 땨3.딟, ref 땨7.딟);
        땨2.딟.딟(ref 땨1.딟, ref 땨6.딟);
        땨1.딧 = 1 + Math.Max(땨3.딧, 땨7.딧);
        땨2.딧 = 1 + Math.Max(땨1.딧, 땨6.딧);
      }
      else
      {
        땨2.땄 = 땄3;
        땨1.딟 = (AABB) 딟3;
        땨6.딢 = obj0;
        땨1.딟.딟(ref 땨3.딟, ref 땨6.딟);
        땨2.딟.딟(ref 땨1.딟, ref 땨7.딟);
        땨1.딧 = 1 + Math.Max(땨3.딧, 땨6.딧);
        땨2.딧 = 1 + Math.Max(땨1.딧, 땨7.딧);
      }
      return 딟1;
    }

    private float 딢()
    {
      if (this.딶 == -1)
        return 0.0f;
      float num1 = ((땨<딟>) this.딟[this.딶]).딟.딧();
      float num2 = 0.0f;
      for (int index = 0; index < this.딢; ++index)
      {
        땨<딟> 땨 = (땨<딟>) this.딟[index];
        if (땨.딧 >= 0)
          num2 += 땨.딟.딧();
      }
      return num2 / num1;
    }

    private int 땥([In] int obj0)
    {
      땨<딟> 땨 = (땨<딟>) this.딟[obj0];
      return 땨.딟() ? 0 : 1 + Math.Max(this.땥((int) 땨.딟), this.땥(땨.땄));
    }

    private int 땃() => this.땥(this.딶);

    private void 딝([In] int obj0)
    {
      if (obj0 == -1)
        return;
      if (obj0 != this.딶)
        ;
      땨<딟> 땨 = (땨<딟>) this.딟[obj0];
      int 딟 = (int) 땨.딟;
      int 땄 = 땨.땄;
      if (땨.딟())
        return;
      this.딝(딟);
      this.딝(땄);
    }

    private void 떎([In] int obj0)
    {
      if (obj0 == -1)
        return;
      땨<딟> 땨 = (땨<딟>) this.딟[obj0];
      int 딟 = (int) 땨.딟;
      int 땄 = 땨.땄;
      if (땨.딟())
        return;
      int num = 1 + Math.Max(((땨<딟>) this.딟[딟]).딧, ((땨<딟>) this.딟[땄]).딧);
      new AABB().딟(ref ((땨<딟>) this.딟[딟]).딟, ref ((땨<딟>) this.딟[땄]).딟);
      this.떎(딟);
      this.떎(땄);
    }

    private void 딶()
    {
      this.딝(this.딶);
      this.떎(this.딶);
      int num = 0;
      int index = this.땄;
      while (index != -1)
      {
        index = ((땨<딟>) this.딟[index]).딢;
        ++num;
      }
    }

    private int 땓()
    {
      int val1 = 0;
      for (int index = 0; index < this.딢; ++index)
      {
        땨<딟> 땨 = (땨<딟>) this.딟[index];
        if (땨.딧 > 1)
        {
          int 딟 = (int) 땨.딟;
          int val2 = Math.Abs(((땨<딟>) this.딟[땨.땄]).딧 - ((땨<딟>) this.딟[딟]).딧);
          val1 = Math.Max(val1, val2);
        }
      }
      return val1;
    }

    private void 땺()
    {
      int[] numArray = new int[this.땃];
      int index1 = 0;
      for (int index2 = 0; index2 < this.딢; ++index2)
      {
        if (((땨<딟>) this.딟[index2]).딧 >= 0)
        {
          if (((땨<딟>) this.딟[index2]).딟())
          {
            ((땨<딟>) this.딟[index2]).딢 = -1;
            numArray[index1] = index2;
            ++index1;
          }
          else
            this.땃(index2);
        }
      }
      for (; index1 > 1; --index1)
      {
        float num1 = float.MaxValue;
        int index3 = -1;
        int index4 = -1;
        for (int index5 = 0; index5 < index1; ++index5)
        {
          AABB 딟1 = ((땨<딟>) this.딟[numArray[index5]]).딟;
          for (int index6 = index5 + 1; index6 < index1; ++index6)
          {
            AABB 딟2 = ((땨<딟>) this.딟[numArray[index6]]).딟;
            AABB aabb = new AABB();
            aabb.딟(ref 딟1, ref 딟2);
            float num2 = aabb.딧();
            if ((double) num2 < (double) num1)
            {
              index3 = index5;
              index4 = index6;
              num1 = num2;
            }
          }
        }
        int index7 = numArray[index3];
        int index8 = numArray[index4];
        땨<딟> 땨1 = (땨<딟>) this.딟[index7];
        땨<딟> 땨2 = (땨<딟>) this.딟[index8];
        int index9 = this.땄();
        땨<딟> 땨3 = (땨<딟>) this.딟[index9];
        땨3.딟 = (AABB) index7;
        땨3.땄 = index8;
        땨3.딧 = 1 + Math.Max(땨1.딧, 땨2.딧);
        땨3.딟.딟(ref 땨1.딟, ref 땨2.딟);
        땨3.딢 = -1;
        땨1.딢 = index9;
        땨2.딢 = index9;
        numArray[index4] = numArray[index1 - 1];
        numArray[index3] = index9;
      }
      this.딶 = numArray[0];
      this.딶();
    }
  }
}
