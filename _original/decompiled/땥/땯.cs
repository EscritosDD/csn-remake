// Decompiled with JetBrains decompiler
// Type: 땥.땯
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땥
{
  public sealed class 땯
  {
    private const int 딟 = 8;
    private static int[,] 딟 = new int[8, 2]
    {
      {
        -1,
        -1
      },
      {
        0,
        -1
      },
      {
        1,
        -1
      },
      {
        1,
        0
      },
      {
        1,
        1
      },
      {
        0,
        1
      },
      {
        -1,
        1
      },
      {
        -1,
        0
      }
    };
    private uint[] 딟;
    private int 땄;
    private int 딧;
    private int 딢;
    private 딨 딟;
    private uint 딟;
    private float 딟;
    private bool 딟;
    private bool 땄;
    private bool 딧;
    private 딷 딟 = 딷.딟();
    private int 땃;
    private int 딶;

    public 땯() => this.딟((uint[]) null, new int?(), new byte?(), new float?(), new bool?(), new bool?(), new bool?(), new 딷?());

    public 땯([In] byte? obj0, [In] float? obj1, [In] bool? obj2, [In] bool? obj3, [In] bool? obj4, [In] 딷? obj5) => this.딟((uint[]) null, new int?(), obj0, obj1, obj2, obj3, obj4, obj5);

    public 땯([In] uint[] obj0, [In] int obj1) => this.딟(obj0, new int?(obj1), new byte?(), new float?(), new bool?(), new bool?(), new bool?(), new 딷?());

    public 땯(
      [In] uint[] obj0,
      [In] int obj1,
      [In] byte? obj2,
      [In] float? obj3,
      [In] bool? obj4,
      [In] bool? obj5,
      [In] bool? obj6,
      [In] 딷? obj7)
    {
      this.딟(obj0, new int?(obj1), obj2, obj3, obj4, obj5, obj6, obj7);
    }

    [SpecialName]
    public 딨 딟() => this.딟;

    [SpecialName]
    public void 딟([In] 딨 obj0) => this.딟 = obj0;

    [SpecialName]
    public bool 땄() => this.딟;

    [SpecialName]
    public void 딟([In] bool obj0) => this.딟 = obj0;

    [SpecialName]
    public bool 딧() => this.땄;

    [SpecialName]
    public void 땄([In] bool obj0) => this.땄 = obj0;

    [SpecialName]
    public bool 딢() => this.딧;

    [SpecialName]
    public void 딧([In] bool obj0) => this.딧 = obj0;

    [SpecialName]
    public 딷 땃() => this.딟;

    [SpecialName]
    public void 딟([In] 딷 obj0) => this.딟 = obj0;

    [SpecialName]
    public byte 딶() => (byte) (this.딟 >> 24);

    [SpecialName]
    public void 딟([In] byte obj0) => this.딟 = (uint) obj0 << 24;

    [SpecialName]
    public float 땓() => this.딟;

    [SpecialName]
    public void 딟([In] float obj0)
    {
      if ((double) obj0 > 4.0)
        this.딟 = 4f;
      else if ((double) obj0 < 0.899999976158142)
        this.딟 = 0.9f;
      else
        this.딟 = obj0;
    }

    private void 딟(
      [In] uint[] obj0,
      [In] int? obj1,
      [In] byte? obj2,
      [In] float? obj3,
      [In] bool? obj4,
      [In] bool? obj5,
      [In] bool? obj6,
      [In] 딷? obj7)
    {
      if (obj0 != null && !obj1.HasValue)
        throw new ArgumentNullException("width", "'width' can't be null if 'data' is set.");
      if (obj0 == null && obj1.HasValue)
        throw new ArgumentNullException("data", "'data' can't be null if 'width' is set.");
      if (obj0 != null && obj1.HasValue)
        this.딟(obj0, obj1.Value);
      if (obj2.HasValue)
        this.딟(obj2.Value);
      else
        this.딟((byte) 20);
      if (obj3.HasValue)
        this.딟(obj3.Value);
      else
        this.딟(1.5f);
      if (obj4.HasValue)
        this.딟(obj4.Value);
      else
        this.딟(false);
      if (obj5.HasValue)
        this.땄(obj5.Value);
      else
        this.땄(false);
      if (obj6.HasValue)
        this.딧(obj6.Value);
      else
        this.딧(false);
      if (obj7.HasValue)
        this.딟(obj7.Value);
      else
        this.딟(딷.딟());
    }

    private void 딟([In] uint[] obj0, [In] int obj1)
    {
      if (obj0 == null)
        throw new ArgumentNullException("data", "'data' can't be null.");
      if (obj0.Length < 4)
        throw new ArgumentOutOfRangeException("data", "'data' length can't be less then 4. Your texture must be at least 2 x 2 pixels in size.");
      if (obj1 < 2)
        throw new ArgumentOutOfRangeException("width", "'width' can't be less then 2. Your texture must be at least 2 x 2 pixels in size.");
      if (obj0.Length % obj1 != 0)
        throw new ArgumentException("'width' has an invalid value.");
      this.딟 = obj0;
      this.땄 = this.딟.Length;
      this.딧 = obj1;
      this.딢 = this.땄 / obj1;
    }

    public static 땨 땄([In] uint[] obj0, [In] int obj1) => (땨) new 땯(obj0, obj1).땺()[0];

    public static 땨 딟([In] uint[] obj0, [In] int obj1, [In] bool obj2)
    {
      땯 땯 = new 땯(obj0, obj1);
      땯.딟(obj2);
      return (땨) 땯.땺()[0];
    }

    public static List<땨> 딟(
      [In] uint[] obj0,
      [In] int obj1,
      [In] float obj2,
      [In] byte obj3,
      [In] bool obj4,
      [In] bool obj5)
    {
      땯 땯 = new 땯(obj0, obj1);
      땯.딟(obj2);
      땯.딟(obj3);
      땯.땄(obj4);
      땯.딟(obj5);
      List<땇> 땇List = 땯.땺();
      List<땨> 땨List = new List<땨>();
      for (int index = 0; index < 땇List.Count; ++index)
        땨List.Add((땨) 땇List[index]);
      return 땨List;
    }

    public List<땇> 땺()
    {
      if (this.딟 == null)
        throw new Exception("'_data' can't be null. You have to use SetTextureData(uint[] data, int width) before calling this method.");
      if (this.딟.Length < 4)
        throw new Exception("'_data' length can't be less then 4. Your texture must be at least 2 x 2 pixels in size. You have to use SetTextureData(uint[] data, int width) before calling this method.");
      if (this.딧 < 2)
        throw new Exception("'_width' can't be less then 2. Your texture must be at least 2 x 2 pixels in size. You have to use SetTextureData(uint[] data, int width) before calling this method.");
      if (this.딟.Length % this.딧 != 0)
        throw new Exception("'_width' has an invalid value. You have to use SetTextureData(uint[] data, int width) before calling this method.");
      List<땇> 땇List = new List<땇>();
      떁? nullable1 = new 떁?();
      떁? nullable2 = new 떁?();
      List<떁> 떁List = new List<떁>();
      bool flag;
      do
      {
        땇 땇;
        if (땇List.Count == 0)
        {
          땇 = new 땇(this.딟(떁.딟(), 떁.딟()));
          if (땇.Count > 2)
            nullable2 = this.딟((땨) 땇);
        }
        else if (nullable2.HasValue)
          땇 = new 땇(this.딟(nullable2.Value, new 떁(nullable2.Value.딟 - 1f, nullable2.Value.땄)));
        else
          break;
        flag = false;
        if (땇.Count > 2)
        {
          if (this.딟)
          {
            while (true)
            {
              땨 땨;
              int index;
              do
              {
                do
                {
                  nullable1 = this.딟((땨) 땇, nullable1);
                  if (nullable1.HasValue && !떁List.Contains(nullable1.Value))
                  {
                    떁List.Add(nullable1.Value);
                    땨 = this.딟(nullable1.Value, new 떁(nullable1.Value.딟 + 1f, nullable1.Value.땄));
                  }
                  else
                    goto label_24;
                }
                while (땨 == null || 땨.Count <= 2);
                switch (this.딟)
                {
                  case 딨.딟:
                    땨.Add(땨[0]);
                    continue;
                  case 딨.땄:
                    goto label_21;
                  default:
                    continue;
                }
              }
              while (!this.딟((땨) 땇, nullable1.Value, out int _, out index));
              땇.InsertRange(index, (IEnumerable<떁>) 땨);
              continue;
label_21:
              if (땇.딟() == null)
                땇.딟(new List<땨>());
              땇.딟().Add(땨);
            }
          }
label_24:
          땇List.Add(땇);
        }
        if ((this.땄 || 땇.Count <= 2) && this.딟(땇List, nullable2.Value, out nullable2))
          flag = true;
      }
      while (flag);
      if (땇List == null || 땇List != null && 땇List.Count == 0)
        throw new Exception("Couldn't detect any vertices.");
      if (this.딟() == 딨.땄)
        this.딟(ref 땇List);
      if (this.딧)
        this.땄(ref 땇List);
      if (this.딟 != 딷.딟())
        this.딧(ref 땇List);
      return 땇List;
    }

    private void 딟([In] ref List<땇> obj0)
    {
      for (int index1 = 0; index1 < obj0.Count; ++index1)
      {
        obj0[index1].Reverse();
        if (obj0[index1].딟() != null && obj0[index1].딟().Count > 0)
        {
          for (int index2 = 0; index2 < obj0[index1].딟().Count; ++index2)
            obj0[index1].딟()[index2].Reverse();
        }
      }
    }

    private void 땄([In] ref List<땇> obj0)
    {
    }

    private void 딧([In] ref List<땇> obj0)
    {
      for (int index = 0; index < obj0.Count; ++index)
        obj0[index].딟(this.딟);
    }

    public bool 딟([In] ref 떁 obj0)
    {
      this.땃 = (int) obj0.딟;
      this.딶 = (int) obj0.땄;
      return this.땃 >= 0 && this.땃 < this.딧 && this.딶 >= 0 && this.딶 < this.딢 && this.딟[this.땃 + this.딶 * this.딧] >= this.딟;
    }

    public bool 딟([In] ref int obj0, [In] ref int obj1) => obj0 >= 0 && obj0 < this.딧 && obj1 >= 0 && obj1 < this.딢 && this.딟[obj0 + obj1 * this.딧] >= this.딟;

    public bool 딟([In] ref int obj0) => obj0 >= 0 && obj0 < this.땄 && this.딟[obj0] >= this.딟;

    public bool 땄([In] ref 떁 obj0) => (double) obj0.딟 >= 0.0 && (double) obj0.딟 < (double) this.딧 && (double) obj0.땄 >= 0.0 && (double) obj0.땄 < (double) this.딢;

    private 떁? 딟([In] 땨 obj0, [In] 떁? obj1)
    {
      if (obj0 == null)
        throw new ArgumentNullException("'polygon' can't be null.");
      if (obj0.Count < 3)
        throw new ArgumentException("'polygon.MainPolygon.Count' can't be less then 3.");
      int num1 = 0;
      int num2 = !obj1.HasValue ? (int) this.땄(obj0) : (int) obj1.Value.땄;
      int num3 = (int) this.딧(obj0);
      if (num2 > 0 && num2 < this.딢 && num3 > 0 && num3 < this.딢)
      {
        for (int index1 = num2; index1 <= num3; ++index1)
        {
          List<float> floatList = this.딟(obj0, index1);
          if (floatList.Count > 1 && floatList.Count % 2 == 0)
          {
            for (int index2 = 0; index2 < floatList.Count; index2 += 2)
            {
              bool flag1 = false;
              bool flag2 = false;
              for (int index3 = (int) floatList[index2]; index3 <= (int) floatList[index2 + 1]; ++index3)
              {
                if (this.딟(ref index3, ref index1))
                {
                  if (!flag2)
                  {
                    flag1 = true;
                    num1 = index3;
                  }
                  if (flag1 && flag2)
                  {
                    떁? nullable1 = new 떁?(new 떁((float) num1, (float) index1));
                    if (this.딟(obj0, nullable1.Value, true))
                      return nullable1;
                    떁? nullable2 = new 떁?();
                    break;
                  }
                }
                else if (flag1)
                  flag2 = true;
              }
            }
          }
          else if (floatList.Count % 2 != 0)
            ;
        }
      }
      return new 떁?();
    }

    private bool 딟([In] 땇 obj0, [In] 떁 obj1, [In] bool obj2)
    {
      if (obj0 == null)
        throw new ArgumentNullException("polygon", "'polygon' can't be null.");
      if (obj0.Count < 3)
        throw new ArgumentException("'polygon.MainPolygon.Count' can't be less then 3.");
      if (!this.딟((땨) obj0, obj1, obj2))
        return false;
      if (obj0.딟() != null)
      {
        for (int index = 0; index < obj0.딟().Count; ++index)
        {
          if (!this.딟(obj0.딟()[index], obj1, obj2))
            return false;
        }
      }
      return true;
    }

    private bool 딟([In] 땨 obj0, [In] 떁 obj1, [In] bool obj2)
    {
      if (obj0 == null)
        throw new ArgumentNullException("polygon", "'polygon' can't be null.");
      떁 떁1 = obj0.Count >= 3 ? obj0[obj0.Count - 1] : throw new ArgumentException("'polygon.Count' can't be less then 3.");
      if (obj2)
      {
        for (int index = 0; index < obj0.Count; ++index)
        {
          떁 떁2 = obj0[index];
          if ((double) 땠.딟(ref obj1, ref 떁2, ref 떁1) <= (double) this.딟 || (double) 땠.딟(ref obj1, ref 떁2) <= (double) this.딟)
            return false;
          떁1 = obj0[index];
        }
        return true;
      }
      for (int index = 0; index < obj0.Count; ++index)
      {
        떁 떁3 = obj0[index];
        if ((double) 땠.딟(ref obj1, ref 떁3, ref 떁1) <= (double) this.딟)
          return false;
        떁1 = obj0[index];
      }
      return true;
    }

    private bool 딟([In] 땇 obj0, [In] 떁 obj1)
    {
      if (!this.딟(obj0, obj1, true))
        return true;
      List<float> floatList = this.딟(obj0, (int) obj1.땄);
      if (floatList.Count > 0 && floatList.Count % 2 == 0)
      {
        for (int index = 0; index < floatList.Count; index += 2)
        {
          if ((double) floatList[index] <= (double) obj1.딟 && (double) floatList[index + 1] >= (double) obj1.딟)
            return true;
        }
      }
      return false;
    }

    private 떁? 딟([In] 땨 obj0)
    {
      float num = float.MaxValue;
      떁? nullable = new 떁?();
      for (int index = 0; index < obj0.Count; ++index)
      {
        if ((double) num > (double) obj0[index].땄)
        {
          num = obj0[index].땄;
          nullable = new 떁?(obj0[index]);
        }
      }
      return nullable;
    }

    private float 땄([In] 땨 obj0)
    {
      float num = float.MaxValue;
      for (int index = 0; index < obj0.Count; ++index)
      {
        if ((double) num > (double) obj0[index].땄)
          num = obj0[index].땄;
      }
      return num;
    }

    private float 딧([In] 땨 obj0)
    {
      float num = float.MinValue;
      for (int index = 0; index < obj0.Count; ++index)
      {
        if ((double) num < (double) obj0[index].땄)
          num = obj0[index].땄;
      }
      return num;
    }

    private List<float> 딟([In] 땇 obj0, [In] int obj1)
    {
      if (obj0 == null)
        throw new ArgumentNullException("polygon", "'polygon' can't be null.");
      List<float> floatList = obj0.Count >= 3 ? this.딟((땨) obj0, obj1) : throw new ArgumentException("'polygon.MainPolygon.Count' can't be less then 3.");
      if (obj0.딟() != null)
      {
        for (int index = 0; index < obj0.딟().Count; ++index)
          floatList.AddRange((IEnumerable<float>) this.딟(obj0.딟()[index], obj1));
      }
      floatList.Sort();
      return floatList;
    }

    private List<float> 딟([In] 땨 obj0, [In] int obj1)
    {
      List<float> floatList = new List<float>();
      if (obj0.Count > 2)
      {
        떁 떁1 = obj0[obj0.Count - 1];
        for (int index = 0; index < obj0.Count; ++index)
        {
          떁 떁2 = obj0[index];
          if (((double) 떁2.땄 >= (double) obj1 && (double) 떁1.땄 <= (double) obj1 || (double) 떁2.땄 <= (double) obj1 && (double) 떁1.땄 >= (double) obj1) && (double) 떁2.땄 != (double) 떁1.땄)
          {
            bool flag = true;
            떁 떁3 = 떁1 - 떁2;
            if ((double) 떁2.땄 == (double) obj1)
            {
              떁 떁4 = obj0[(index + 1) % obj0.Count];
              떁 떁5 = 떁2 - 떁4;
              flag = (double) 떁3.땄 <= 0.0 ? (double) 떁5.땄 >= 0.0 : (double) 떁5.땄 <= 0.0;
            }
            if (flag)
              floatList.Add(((float) obj1 - 떁2.땄) / 떁3.땄 * 떁3.딟 + 떁2.딟);
          }
          떁1 = 떁2;
        }
      }
      floatList.Sort();
      return floatList;
    }

    private bool 딟([In] 땨 obj0, [In] 떁 obj1, out int _param3, out int _param4)
    {
      int index1 = 0;
      int index2 = 0;
      bool flag1 = false;
      float num1 = float.MaxValue;
      bool flag2 = false;
      떁 떁1 = 떁.딟();
      List<float> floatList = this.딟(obj0, (int) obj1.땄);
      _param3 = 0;
      _param4 = 0;
      떁1.땄 = obj1.땄;
      if (floatList != null && floatList.Count > 1 && floatList.Count % 2 == 0)
      {
        for (int index3 = 0; index3 < floatList.Count; ++index3)
        {
          if ((double) floatList[index3] < (double) obj1.딟)
          {
            float num2 = obj1.딟 - floatList[index3];
            if ((double) num2 < (double) num1)
            {
              num1 = num2;
              떁1.딟 = floatList[index3];
              flag2 = true;
            }
          }
        }
        if (flag2)
        {
          float num3 = float.MaxValue;
          int index4 = obj0.Count - 1;
          for (int index5 = 0; index5 < obj0.Count; ++index5)
          {
            떁 떁2 = obj0[index5];
            떁 떁3 = obj0[index4];
            float num4 = 땠.딟(ref 떁1, ref 떁2, ref 떁3);
            if ((double) num4 < (double) num3)
            {
              num3 = num4;
              index1 = index5;
              index2 = index4;
              flag1 = true;
            }
            index4 = index5;
          }
          if (flag1)
          {
            떁 떁4 = obj0[index2] - obj0[index1];
            떁4.땓();
            떁 떁5 = obj0[index1];
            float num5 = 땠.딟(ref 떁5, ref 떁1);
            _param3 = index1;
            _param4 = index1 + 1;
            obj0.Insert(index1, num5 * 떁4 + obj0[_param3]);
            obj0.Insert(index1, num5 * 떁4 + obj0[_param4]);
            return true;
          }
        }
      }
      return false;
    }

    private 땨 딟([In] 떁 obj0, [In] 떁 obj1)
    {
      bool flag1 = false;
      bool flag2 = false;
      땨 땨1 = new 땨(32);
      땨 땨2 = new 땨(32);
      땨 땨3 = new 땨(32);
      떁 떁1 = 떁.딟();
      if (obj0 == 떁.딟() || !this.땄(ref obj0))
      {
        flag1 = this.딧(out obj0);
        if (flag1)
          떁1 = new 떁(obj0.딟 - 1f, obj0.땄);
      }
      else if (this.딟(ref obj0))
      {
        if (this.딟(ref obj0, ref obj1))
        {
          떁1 = obj1;
          flag1 = true;
        }
        else
        {
          떁 떁2;
          if (this.딟(false, ref obj0, out 떁2))
          {
            떁1 = 떁2;
            flag1 = true;
          }
          else
            flag1 = false;
        }
      }
      if (flag1)
      {
        땨1.Add(obj0);
        땨2.Add(obj0);
        떁 떁3 = obj0;
        while (true)
        {
          do
          {
            do
            {
              떁 떁4;
              if (this.딟(땨2, out 떁4))
              {
                if (flag2)
                {
                  if (땨3.Contains(떁4))
                  {
                    땨1.Add(떁4);
                    goto label_20;
                  }
                  else
                    goto label_20;
                }
                else
                {
                  땨1.Add(떁4);
                  땨2.RemoveRange(0, 땨2.IndexOf(떁4));
                }
              }
              obj1 = 떁1;
              떁1 = 떁3;
              if (this.딟(ref obj1, ref 떁1, out 떁3))
                땨2.Add(떁3);
              else
                goto label_20;
            }
            while (!(떁3 == obj0) || flag2);
            flag2 = true;
            땨3.AddRange((IEnumerable<떁>) 땨2);
          }
          while (!땨3.Contains(obj0));
          땨3.Remove(obj0);
        }
      }
label_20:
      return 땨1;
    }

    private bool 딟([In] bool obj0, [In] ref 떁 obj1, out 떁 _param3)
    {
      for (int index = 0; index < 8; ++index)
      {
        int num1 = (int) obj1.딟 + 땯.딟[index, 0];
        int num2 = (int) obj1.땄 + 땯.딟[index, 1];
        if (!obj0 ^ this.딟(ref num1, ref num2))
        {
          _param3 = new 떁((float) num1, (float) num2);
          return true;
        }
      }
      _param3 = 떁.딟();
      return false;
    }

    private bool 딟([In] ref 떁 obj0, [In] ref 떁 obj1)
    {
      for (int index = 0; index < 8; ++index)
      {
        int num1 = (int) obj0.딟 + 땯.딟[index, 0];
        int num2 = (int) obj0.땄 + 땯.딟[index, 1];
        if (num1 >= 0 && num1 <= this.딧 && num2 >= 0 && num2 <= this.딢 && num1 == (int) obj1.딟 && num2 == (int) obj1.땄)
          return true;
      }
      return false;
    }

    private bool 딧(out 떁 _param1)
    {
      for (int index1 = 0; index1 <= this.딢; ++index1)
      {
        for (int index2 = 0; index2 <= this.딧; ++index2)
        {
          if (this.딟(ref index2, ref index1))
          {
            _param1 = new 떁((float) index2, (float) index1);
            return true;
          }
        }
      }
      _param1 = 떁.딟();
      return false;
    }

    private bool 딟([In] List<땇> obj0, [In] 떁 obj1, out 떁? _param3)
    {
      bool flag1 = false;
      for (int index1 = (int) obj1.딟 + (int) obj1.땄 * this.딧; index1 <= this.땄; ++index1)
      {
        if (this.딟(ref index1))
        {
          if (flag1)
          {
            int num = index1 % this.딧;
            _param3 = new 떁?(new 떁((float) num, (float) (index1 - num) / (float) this.딧));
            bool flag2 = false;
            for (int index2 = 0; index2 < obj0.Count; ++index2)
            {
              if (this.딟(obj0[index2], _param3.Value))
              {
                flag2 = true;
                break;
              }
            }
            if (!flag2)
              return true;
            flag1 = false;
          }
        }
        else
          flag1 = true;
      }
      _param3 = new 떁?();
      return false;
    }

    private bool 딟([In] ref 떁 obj0, [In] ref 떁 obj1, out 떁 _param3)
    {
      int num1 = this.땄(ref obj0, ref obj1);
      for (int index1 = 0; index1 < 8; ++index1)
      {
        int index2 = (num1 + index1) % 8;
        int num2 = (int) obj1.딟 + 땯.딟[index2, 0];
        int num3 = (int) obj1.땄 + 땯.딟[index2, 1];
        if (num2 >= 0 && num2 < this.딧 && num3 >= 0 && num3 <= this.딢 && this.딟(ref num2, ref num3))
        {
          _param3 = new 떁((float) num2, (float) num3);
          return true;
        }
      }
      _param3 = 떁.딟();
      return false;
    }

    private bool 딟([In] 땨 obj0, out 떁 _param2)
    {
      떁 떁1 = 떁.딟();
      bool flag = false;
      if (obj0.Count > 2)
      {
        int index1 = obj0.Count - 1;
        떁 떁2 = obj0[0];
        떁 떁3 = obj0[index1];
        for (int index2 = 1; index2 < index1; ++index2)
        {
          떁 떁4 = obj0[index2];
          if ((double) 땠.딟(ref 떁4, ref 떁2, ref 떁3) >= (double) this.딟)
          {
            떁1 = obj0[index2];
            flag = true;
            break;
          }
        }
      }
      _param2 = 떁1;
      return flag;
    }

    private int 땄([In] ref 떁 obj0, [In] ref 떁 obj1)
    {
      switch ((int) ((double) obj1.딟 - (double) obj0.딟) + 1)
      {
        case 0:
          switch ((int) ((double) obj1.땄 - (double) obj0.땄) + 1)
          {
            case 0:
              return 5;
            case 1:
              return 4;
            case 2:
              return 3;
          }
          break;
        case 1:
          switch ((int) ((double) obj1.땄 - (double) obj0.땄) + 1)
          {
            case 0:
              return 6;
            case 2:
              return 2;
          }
          break;
        case 2:
          switch ((int) ((double) obj1.땄 - (double) obj0.땄) + 1)
          {
            case 0:
              return 7;
            case 1:
              return 0;
            case 2:
              return 1;
          }
          break;
      }
      return 0;
    }
  }
}
