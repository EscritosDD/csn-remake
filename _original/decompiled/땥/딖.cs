// Decompiled with JetBrains decompiler
// Type: 땥.딖
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using FarseerPhysics.Collision;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 땥
{
  public static class 딖
  {
    private static int[] 딟 = new int[16]
    {
      0,
      224,
      56,
      216,
      14,
      238,
      54,
      214,
      131,
      99,
      187,
      91,
      141,
      109,
      181,
      85
    };

    public static List<땨> 딟(
      [In] AABB obj0,
      [In] float obj1,
      [In] float obj2,
      [In] sbyte[,] obj3,
      [In] int obj4,
      [In] bool obj5)
    {
      딖.딞<딖.딠> 딞 = new 딖.딞<딖.딠>();
      List<땨> 땨List = new List<땨>();
      int num1 = (int) ((double) obj0.땄().딟 * 2.0 / (double) obj1);
      bool flag1 = (double) num1 == (double) obj0.땄().딟 * 2.0 / (double) obj1;
      int num2 = (int) ((double) obj0.땄().땄 * 2.0 / (double) obj2);
      bool flag2 = (double) num2 == (double) obj0.땄().땄 * 2.0 / (double) obj2;
      if (!flag1)
        ++num1;
      if (!flag2)
        ++num2;
      sbyte[,] numArray = new sbyte[num1 + 1, num2 + 1];
      딖.딿[,] 딿Array = new 딖.딿[num1 + 1, num2 + 1];
      for (int index1 = 0; index1 < num1 + 1; ++index1)
      {
        int index2 = index1 != num1 ? (int) ((double) index1 * (double) obj1 + (double) obj0.LowerBound.딟) : (int) obj0.UpperBound.딟;
        for (int index3 = 0; index3 < num2 + 1; ++index3)
        {
          int index4 = index3 != num2 ? (int) ((double) index3 * (double) obj2 + (double) obj0.LowerBound.땄) : (int) obj0.UpperBound.땄;
          numArray[index1, index3] = obj3[index2, index4];
        }
      }
      for (int index5 = 0; index5 < num2; ++index5)
      {
        float num3 = (float) index5 * obj2 + obj0.LowerBound.땄;
        float num4 = index5 != num2 - 1 ? num3 + obj2 : obj0.UpperBound.땄;
        딖.딠 딠1 = (딖.딠) null;
        for (int index6 = 0; index6 < num1; ++index6)
        {
          float num5 = (float) index6 * obj1 + obj0.LowerBound.딟;
          float num6 = index6 != num1 - 1 ? num5 + obj1 : obj0.UpperBound.딟;
          딖.딠 딠2 = new 딖.딠();
          int num7 = 딖.딟(obj3, numArray, ref 딠2, index6, index5, num5, num3, num6, num4, obj4);
          if (딠2.딟 != 0)
          {
            if (obj5 && 딠1 != null && (num7 & 9) != 0)
            {
              딖.딟(ref 딠1, ref 딠2);
              딠2 = 딠1;
            }
            else
              딞.딟(딠2);
            딿Array[index6, index5] = new 딖.딿(딠2, num7);
          }
          else
            딠2 = (딖.딠) null;
          딠1 = 딠2;
        }
      }
      if (!obj5)
      {
        foreach (딖.딠 딠 in 딞.땺())
          땨List.Add(new 땨((IList<떁>) 딠.딟.땺()));
        return 땨List;
      }
      for (int index7 = 1; index7 < num2; ++index7)
      {
        int index8 = 0;
        while (index8 < num1)
        {
          딖.딿 딿1 = 딿Array[index8, index7];
          if (딿1 == null)
            ++index8;
          else if ((딿1.딟 & 12) == 0)
          {
            ++index8;
          }
          else
          {
            딖.딿 딿2 = 딿Array[index8, index7 - 1];
            if (딿2 == null)
              ++index8;
            else if ((딿2.딟 & 3) == 0)
            {
              ++index8;
            }
            else
            {
              float num8 = (float) index8 * obj1 + obj0.LowerBound.딟;
              float num9 = (float) index7 * obj2 + obj0.LowerBound.땄;
              딖.딞<떁> 딟1 = 딿1.딟.딟;
              딖.딞<떁> 딟2 = 딿2.딟.딟;
              if (딿2.딟 == 딿1.딟)
              {
                ++index8;
              }
              else
              {
                딖.딡<떁> 딡1 = 딟1.딟();
                while ((double) 딖.딟(딡1.딟().땄 - num9) > 1.19209289550781E-07 || (double) 딡1.딟().딟 < (double) num8)
                  딡1 = 딡1.땄();
                떁 떁 = 딡1.땄().딟();
                if ((double) 딖.딟(떁.땄 - num9) > 1.19209289550781E-07)
                {
                  ++index8;
                }
                else
                {
                  bool flag3 = true;
                  딖.딡<떁> 딡2;
                  for (딡2 = 딟2.딟(); 딡2 != 딟2.땄(); 딡2 = 딡2.땄())
                  {
                    if ((double) 딖.딟(딡2.딟(), 떁) < 1.19209289550781E-07)
                    {
                      flag3 = false;
                      break;
                    }
                  }
                  if (flag3)
                  {
                    ++index8;
                  }
                  else
                  {
                    딖.딡<떁> 딡3 = 딡1.땄().땄();
                    if (딡3 == 딟1.땄())
                      딡3 = 딟1.딟();
                    while (딡3 != 딡1)
                    {
                      딡2 = 딟2.딟(딡2, 딡3.딟());
                      딡3 = 딡3.땄();
                      if (딡3 == 딟1.땄())
                        딡3 = 딟1.딟();
                      ++딿2.딟.딟;
                    }
                    float num10 = (float) (index8 + 1);
                    while ((double) num10 < (double) num1)
                    {
                      딖.딿 딿3 = 딿Array[(int) num10, index7];
                      if (딿3 == null || 딿3.딟 != 딿1.딟)
                      {
                        ++num10;
                      }
                      else
                      {
                        딿3.딟 = 딿2.딟;
                        ++num10;
                      }
                    }
                    float num11 = (float) (index8 - 1);
                    while ((double) num11 >= 0.0)
                    {
                      딖.딿 딿4 = 딿Array[(int) num11, index7];
                      if (딿4 == null || 딿4.딟 != 딿1.딟)
                      {
                        --num11;
                      }
                      else
                      {
                        딿4.딟 = 딿2.딟;
                        --num11;
                      }
                    }
                    딞.땄(딿1.딟);
                    딿1.딟 = 딿2.딟;
                    index8 = (int) (((double) 딡1.땄().딟().딟 - (double) obj0.LowerBound.딟) / (double) obj1) + 1;
                  }
                }
              }
            }
          }
        }
      }
      foreach (딖.딠 딠 in 딞.땺())
        땨List.Add(new 땨((IList<떁>) 딠.딟.땺()));
      return 땨List;
    }

    private static float 딟([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3)
    {
      float num1 = obj2 - obj3;
      float num2 = (double) num1 * (double) num1 >= 1.19209289550781E-07 ? obj2 / num1 : 0.5f;
      return obj0 + num2 * (obj1 - obj0);
    }

    private static float 딟(
      [In] float obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4,
      [In] sbyte[,] obj5,
      [In] int obj6)
    {
      float num1 = 딖.딟(obj0, obj1, obj3, obj4);
      if (obj6 == 0)
        return num1;
      sbyte num2 = obj5[(int) num1, (int) obj2];
      return (double) obj3 * (double) num2 < 0.0 ? 딖.딟(obj0, num1, obj2, obj3, (float) num2, obj5, obj6 - 1) : 딖.딟(num1, obj1, obj2, (float) num2, obj4, obj5, obj6 - 1);
    }

    private static float 땄(
      [In] float obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4,
      [In] sbyte[,] obj5,
      [In] int obj6)
    {
      float num1 = 딖.딟(obj0, obj1, obj3, obj4);
      if (obj6 == 0)
        return num1;
      sbyte num2 = obj5[(int) obj2, (int) num1];
      return (double) obj3 * (double) num2 < 0.0 ? 딖.땄(obj0, num1, obj2, obj3, (float) num2, obj5, obj6 - 1) : 딖.땄(num1, obj1, obj2, (float) num2, obj4, obj5, obj6 - 1);
    }

    private static float 딟([In] float obj0) => obj0 * obj0;

    private static float 딟([In] 떁 obj0, [In] 떁 obj1)
    {
      떁 떁 = obj0 - obj1;
      return (float) ((double) 떁.딟 * (double) 떁.딟 + (double) 떁.땄 * (double) 떁.땄);
    }

    private static float 땄([In] 떁 obj0, [In] 떁 obj1) => (float) ((double) obj0.딟 * (double) obj1.땄 - (double) obj0.땄 * (double) obj1.딟);

    private static int 딟(
      [In] sbyte[,] obj0,
      [In] sbyte[,] obj1,
      [In] ref 딖.딠 obj2,
      [In] int obj3,
      [In] int obj4,
      [In] float obj5,
      [In] float obj6,
      [In] float obj7,
      [In] float obj8,
      [In] int obj9)
    {
      int index1 = 0;
      sbyte num1 = obj1[obj3, obj4];
      if (num1 < (sbyte) 0)
        index1 |= 8;
      sbyte num2 = obj1[obj3 + 1, obj4];
      if (num2 < (sbyte) 0)
        index1 |= 4;
      sbyte num3 = obj1[obj3 + 1, obj4 + 1];
      if (num3 < (sbyte) 0)
        index1 |= 2;
      sbyte num4 = obj1[obj3, obj4 + 1];
      if (num4 < (sbyte) 0)
        index1 |= 1;
      int num5 = 딖.딟[index1];
      if (num5 != 0)
      {
        딖.딡<떁> 딡 = (딖.딡<떁>) null;
        for (int index2 = 0; index2 < 8; ++index2)
        {
          if ((num5 & 1 << index2) != 0)
          {
            떁 떁1;
            if (index2 == 7 && (num5 & 1) == 0)
            {
              딖.딞<떁> 딟 = obj2.딟;
              떁1 = new 떁(obj5, 딖.땄(obj6, obj8, obj5, (float) num1, (float) num4, obj0, obj9));
              떁 떁2 = 떁1;
              딟.딟(떁2);
            }
            else
            {
              떁1 = index2 != 0 ? (index2 != 2 ? (index2 != 4 ? (index2 != 6 ? (index2 != 1 ? (index2 != 5 ? (index2 != 3 ? new 떁(obj5, 딖.땄(obj6, obj8, obj5, (float) num1, (float) num4, obj0, obj9)) : new 떁(obj7, 딖.땄(obj6, obj8, obj7, (float) num2, (float) num3, obj0, obj9))) : new 떁(딖.딟(obj5, obj7, obj8, (float) num4, (float) num3, obj0, obj9), obj8)) : new 떁(딖.딟(obj5, obj7, obj6, (float) num1, (float) num2, obj0, obj9), obj6)) : new 떁(obj5, obj8)) : new 떁(obj7, obj8)) : new 떁(obj7, obj6)) : new 떁(obj5, obj6);
              딡 = obj2.딟.딟(딡, 떁1);
            }
            ++obj2.딟;
          }
        }
      }
      return index1;
    }

    private static void 딟([In] ref 딖.딠 obj0, [In] ref 딖.딠 obj1)
    {
      딖.딞<떁> 딟1 = obj0.딟;
      딖.딞<떁> 딟2 = obj1.딟;
      딖.딡<떁> 딡1 = 딟1.딟();
      딖.딡<떁> 딡2 = 딟2.딟();
      떁 떁1 = 딡2.딟();
      딖.딡<떁> 딡3 = (딖.딡<떁>) null;
      for (; 딡1 != 딟1.땄(); 딡1 = 딡1.땄())
      {
        떁 떁2 = 딡1.딟();
        if ((double) 딖.딟(떁2, 떁1) < 1.19209289550781E-07)
        {
          if (딡3 != null)
          {
            떁 떁3 = 딡3.딟();
            떁 떁4 = 딡2.땄().딟();
            float num = 딖.땄(떁2 - 떁3, 떁4 - 떁2);
            if ((double) num * (double) num < 1.19209289550781E-07)
            {
              딟1.딟(딡3, 딡1);
              --obj0.딟;
              딡1 = 딡3;
            }
          }
          bool flag = true;
          딖.딡<떁> 딡4 = (딖.딡<떁>) null;
          while (!딟2.땃())
          {
            떁 떁5 = 딟2.딧();
            딟2.딢();
            if (!flag && !딟2.땃())
            {
              딡1 = 딟1.딟(딡1, 떁5);
              ++obj0.딟;
              딡4 = 딡1;
            }
            flag = false;
          }
          딖.딡<떁> 딡5 = 딡1.땄();
          떁 떁6 = 딡5.딟();
          딖.딡<떁> 딡6 = 딡5.땄();
          if (딡6 == 딟1.땄())
            딡6 = 딟1.딟();
          떁 떁7 = 딡6.딟();
          떁 떁8 = 딡4.딟();
          float num1 = 딖.땄(떁6 - 떁8, 떁7 - 떁6);
          if ((double) num1 * (double) num1 >= 1.19209289550781E-07)
            break;
          딟1.딟(딡4, 딡4.땄());
          --obj0.딟;
          break;
        }
        딡3 = 딡1;
      }
    }

    internal class 딞<딟>
    {
      private 딖.딡<딟> 딟;
      private int 딟;

      public 딖.딡<딟> 딟() => this.딟;

      public 딖.딡<딟> 땄() => (딖.딡<딟>) null;

      public 딟 딧() => this.딟.딟();

      public 딖.딡<딟> 딟([In] 딟 obj0)
      {
        // ISSUE: unable to decompile the method.
      }

      public bool 땄([In] 딟 obj0)
      {
        // ISSUE: unable to decompile the method.
      }

      public 딖.딡<딟> 딢() => this.딟((딖.딡<딟>) null, this.딟);

      public 딖.딡<딟> 딟([In] 딖.딡<딟> obj0, [In] 딟 obj1)
      {
        // ISSUE: unable to decompile the method.
      }

      public 딖.딡<딟> 딟([In] 딖.딡<딟> obj0, [In] 딖.딡<딟> obj1)
      {
        // ISSUE: unable to decompile the method.
      }

      public bool 땃() => this.딟 == null;

      public int 딶()
      {
        딖.딡<딟> 딡 = this.딟();
        int num = 0;
        do
        {
          ++num;
        }
        while (딡.땄() != null);
        return num;
      }

      public void 땓()
      {
        딖.딡<딟> 딟 = this.딟;
        while (딟 != null)
        {
          딖.딡<딟> 딡 = 딟;
          딟 = (딖.딡<딟>) 딟.딟;
          딡.딟 = (딟) null;
        }
        this.딟 = (딖.딡<딟>) null;
        this.딟 = (딖.딡<딟>) 0;
      }

      public bool 딧([In] 딟 obj0) => this.딢(obj0) != null;

      public 딖.딡<딟> 딢([In] 딟 obj0)
      {
        딖.딡<딟> 딟 = this.딟;
        EqualityComparer<딟> equalityComparer = EqualityComparer<딟>.Default;
        if (딟 != null)
        {
          if ((object) obj0 != null)
          {
            while (!equalityComparer.Equals(딟.딟, obj0))
            {
              딟 = (딖.딡<딟>) 딟.딟;
              if (딟 == this.딟)
                goto label_8;
            }
            return 딟;
          }
          while ((object) 딟.딟 != null)
          {
            딟 = (딖.딡<딟>) 딟.딟;
            if (딟 == this.딟)
              goto label_8;
          }
          return 딟;
        }
label_8:
        return (딖.딡<딟>) null;
      }

      public List<딟> 땺()
      {
        List<딟> 딟List = new List<딟>();
        딖.딡<딟> 딡 = this.딟();
        if (딡 != null)
        {
          do
          {
            딟List.Add(딡.딟);
            딡 = (딖.딡<딟>) 딡.딟;
          }
          while (딡 != null);
        }
        return 딟List;
      }
    }

    internal class 딡<딟>
    {
      internal 딟 딟;
      internal 딖.딡<딟> 딟;

      public 딡([In] 딟 obj0) => this.딟 = obj0;

      public 딟 딟() => this.딟;

      public 딖.딡<딟> 땄() => (딖.딡<딟>) this.딟;
    }

    internal class 딠
    {
      public int 딟;
      public 딖.딞<떁> 딟;

      public 딠()
      {
        this.딟 = new 딖.딞<떁>();
        this.딟 = 0;
      }
    }

    private class 딿
    {
      public int 딟;
      public 딖.딠 딟;

      public 딿([In] 딖.딠 obj0, [In] int obj1)
      {
        this.딟 = obj0;
        this.딟 = obj1;
      }
    }
  }
}
