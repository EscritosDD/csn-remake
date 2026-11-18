// Decompiled with JetBrains decompiler
// Type: 땥.딚
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땥
{
  public static class 딚
  {
    private const float 딟 = 1.192093E-07f;

    public static List<땨> 딟([In] 땨 obj0, [In] 땨 obj1, out 땕 _param2) => 딚.딟(obj0, obj1, 땪.땄, out _param2);

    public static List<땨> 땄([In] 땨 obj0, [In] 땨 obj1, out 땕 _param2) => 딚.딟(obj0, obj1, 땪.딧, out _param2);

    public static List<땨> 딧([In] 땨 obj0, [In] 땨 obj1, out 땕 _param2) => 딚.딟(obj0, obj1, 땪.딟, out _param2);

    private static List<땨> 딟([In] 땨 obj0, [In] 땨 obj1, [In] 땪 obj2, out 땕 _param3)
    {
      땨 땨1;
      땨 땨2;
      딚.딟(obj0, obj1, out 땨1, out 땨2);
      떁 lowerBound1 = obj0.땃().LowerBound;
      떁 lowerBound2 = obj1.땃().LowerBound;
      떁 떁1;
      떁.땃(ref lowerBound1, ref lowerBound2, out 떁1);
      떁 떁2 = 떁.땄() - 떁1;
      if (떁2 != 떁.딟())
      {
        땨1.딟(ref 떁2);
        땨2.딟(ref 떁2);
      }
      땨1.땺();
      땨2.땺();
      List<float> floatList1;
      List<딚.따> 따List1;
      딚.딟(땨1, out floatList1, out 따List1);
      List<float> floatList2;
      List<딚.따> 따List2;
      딚.딟(땨2, out floatList2, out 따List2);
      List<딚.따> 따List3;
      딚.딟(floatList1, 따List1, floatList2, 따List2, obj2, out 따List3);
      List<땨> 땨List;
      _param3 = 딚.딟(따List3, out 땨List);
      떁2 *= -1f;
      for (int index = 0; index < 땨List.Count; ++index)
      {
        땨List[index].딟(ref 떁2);
        땜.딟(땨List[index]);
      }
      return 땨List;
    }

    private static void 딟([In] 땨 obj0, [In] 땨 obj1, out 땨 _param2, out 땨 _param3)
    {
      _param2 = new 땨((IList<떁>) obj0);
      _param3 = new 땨((IList<떁>) obj1);
      for (int index1 = 0; index1 < obj0.Count; ++index1)
      {
        떁 떁1 = obj0[index1];
        떁 떁2 = obj0[obj0.딟(index1)];
        for (int index2 = 0; index2 < obj1.Count; ++index2)
        {
          떁 떁3 = obj1[index2];
          떁 떁4 = obj1[obj1.딟(index2)];
          떁 떁5;
          if (땠.땄(떁1, 떁2, 떁3, 떁4, out 떁5))
          {
            float num1 = 딚.딟(떁1, 떁2, 떁5);
            if ((double) num1 > 0.0 && (double) num1 < 1.0)
            {
              int index3 = _param2.IndexOf(떁1) + 1;
              while (index3 < _param2.Count && (double) 딚.딟(떁1, 떁2, _param2[index3]) <= (double) num1)
                ++index3;
              _param2.Insert(index3, 떁5);
            }
            float num2 = 딚.딟(떁3, 떁4, 떁5);
            if ((double) num2 > 0.0 && (double) num2 < 1.0)
            {
              int index4 = _param3.IndexOf(떁3) + 1;
              while (index4 < _param3.Count && (double) 딚.딟(떁3, 떁4, _param3[index4]) <= (double) num2)
                ++index4;
              _param3.Insert(index4, 떁5);
            }
          }
        }
      }
      for (int index5 = 0; index5 < _param2.Count; ++index5)
      {
        int index6 = _param2.딟(index5);
        if ((double) (_param2[index6] - _param2[index5]).딶() <= 1.19209289550781E-07)
        {
          _param2.RemoveAt(index5);
          --index5;
        }
      }
      for (int index7 = 0; index7 < _param3.Count; ++index7)
      {
        int index8 = _param3.딟(index7);
        if ((double) (_param3[index8] - _param3[index7]).딶() <= 1.19209289550781E-07)
        {
          _param3.RemoveAt(index7);
          --index7;
        }
      }
    }

    private static void 딟([In] 땨 obj0, out List<float> _param1, out List<딚.따> _param2)
    {
      _param2 = new List<딚.따>();
      _param1 = new List<float>();
      for (int index = 0; index < obj0.Count; ++index)
      {
        _param2.Add(new 딚.따(obj0[index], obj0[obj0.딟(index)]));
        _param1.Add(딚.땄(떁.딟(), obj0[index], obj0[obj0.딟(index)]));
      }
    }

    private static void 딟(
      [In] List<float> obj0,
      [In] List<딚.따> obj1,
      [In] List<float> obj2,
      [In] List<딚.따> obj3,
      [In] 땪 obj4,
      out List<딚.따> _param5)
    {
      _param5 = new List<딚.따>();
      for (int index1 = 0; index1 < obj1.Count; ++index1)
      {
        float num = 0.0f;
        if (obj3.Contains(obj1[index1]) || obj3.Contains(-obj1[index1]) && obj4 == 땪.땄)
        {
          num = 1f;
        }
        else
        {
          for (int index2 = 0; index2 < obj3.Count; ++index2)
          {
            if (!obj3.Contains(-obj1[index1]))
              num += 딚.딟(obj1[index1].딧(), obj3[index2], obj2[index2]);
          }
        }
        if (obj4 == 땪.딟)
        {
          if ((double) num == 1.0)
            _param5.Add(obj1[index1]);
        }
        else if ((double) num == 0.0)
          _param5.Add(obj1[index1]);
      }
      for (int index3 = 0; index3 < obj3.Count; ++index3)
      {
        if (!_param5.Contains(obj3[index3]) && !_param5.Contains(-obj3[index3]))
        {
          float num = 0.0f;
          if (obj1.Contains(obj3[index3]) || obj1.Contains(-obj3[index3]) && obj4 == 땪.땄)
          {
            num = 1f;
          }
          else
          {
            for (int index4 = 0; index4 < obj1.Count; ++index4)
            {
              if (!obj1.Contains(-obj3[index3]))
                num += 딚.딟(obj3[index3].딧(), obj1[index4], obj0[index4]);
            }
          }
          if (obj4 == 땪.딟 || obj4 == 땪.딧)
          {
            if ((double) num == 1.0)
              _param5.Add(-obj3[index3]);
          }
          else if ((double) num == 0.0)
            _param5.Add(obj3[index3]);
        }
      }
    }

    private static 땕 딟([In] List<딚.따> obj0, out List<땨> _param1)
    {
      _param1 = new List<땨>();
      땕 땕 = 땕.딟;
      while (obj0.Count > 0)
      {
        땨 땨 = new 땨();
        땨.Add(obj0[0].딟());
        땨.Add(obj0[0].땄());
        obj0.RemoveAt(0);
        bool flag = false;
        int index = 0;
        int count = obj0.Count;
        while (!flag && obj0.Count > 0)
        {
          if (딚.딟(땨[땨.Count - 1], obj0[index].딟()))
          {
            if (딚.딟(obj0[index].땄(), 땨[0]))
              flag = true;
            else
              땨.Add(obj0[index].땄());
            obj0.RemoveAt(index);
            --index;
          }
          else if (딚.딟(땨[땨.Count - 1], obj0[index].땄()))
          {
            if (딚.딟(obj0[index].딟(), 땨[0]))
              flag = true;
            else
              땨.Add(obj0[index].딟());
            obj0.RemoveAt(index);
            --index;
          }
          if (!flag && ++index == obj0.Count)
          {
            if (count == obj0.Count)
            {
              _param1 = new List<땨>();
              return 땕.딢;
            }
            index = 0;
            count = obj0.Count;
          }
        }
        if (땨.Count < 3)
          땕 = 땕.땄;
        _param1.Add(땨);
      }
      return 땕;
    }

    private static float 딟([In] 떁 obj0, [In] 딚.따 obj1, [In] float obj2)
    {
      float num = 0.0f;
      if (딚.딟(obj0, obj1))
        num = obj2;
      if (딚.딧(떁.딟(), obj1.딟(), obj0) || 딚.딧(떁.딟(), obj1.땄(), obj0))
        num = 0.5f * obj2;
      return num;
    }

    private static float 딟([In] 떁 obj0, [In] 떁 obj1, [In] 떁 obj2) => (obj2 - obj0).딶() / (obj1 - obj0).딶();

    private static float 땄([In] 떁 obj0, [In] 떁 obj1, [In] 떁 obj2)
    {
      float num = 땴.딟(ref obj0, ref obj1, ref obj2);
      if ((double) num < 0.0)
        return -1f;
      return (double) num > 0.0 ? 1f : 0.0f;
    }

    private static bool 딟([In] 떁 obj0, [In] 딚.따 obj1)
    {
      땨 땨 = new 땨();
      땨.Add(떁.딟());
      땨.Add(obj1.딟());
      땨.Add(obj1.땄());
      return 땨.딧(ref obj0) == 1;
    }

    private static bool 딧([In] 떁 obj0, [In] 떁 obj1, [In] 떁 obj2)
    {
      떁 떁 = obj1 - obj0;
      return (double) 땴.딟(ref obj0, ref obj1, ref obj2) == 0.0 && (double) 떁.딶(obj2 - obj0, 떁) >= 0.0 && (double) 떁.딶(obj2 - obj1, 떁) <= 0.0;
    }

    private static bool 딟([In] 떁 obj0, [In] 떁 obj1) => (double) (obj1 - obj0).딶() <= 1.19209289550781E-07;

    private sealed class 따
    {
      public 따([In] 떁 obj0, [In] 떁 obj1)
      {
        // ISSUE: reference to a compiler-generated method
        this.딟(obj0);
        // ISSUE: reference to a compiler-generated method
        this.땄(obj1);
      }

      [CompilerGenerated]
      [SpecialName]
      public 떁 딟() => this.딟;

      [CompilerGenerated]
      [SpecialName]
      public 떁 땄() => this.땄;

      public 떁 딧() => (this.딟() + this.땄()) / 2f;

      public override bool Equals([In] object obj0) => obj0 != null && this.딟(obj0 as 딚.따);

      public bool 딟([In] 딚.따 obj0) => obj0 != null && 딚.딟(this.딟(), obj0.딟()) && 딚.딟(this.땄(), obj0.땄());

      public override int GetHashCode() => this.딟().GetHashCode() ^ this.땄().GetHashCode();

      public static 딚.따 operator -([In] 딚.따 obj0) => new 딚.따(obj0.땄(), obj0.딟());
    }
  }
}
