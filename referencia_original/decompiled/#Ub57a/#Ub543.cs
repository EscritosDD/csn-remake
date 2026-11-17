// Decompiled with JetBrains decompiler
// Type: 땺.땃
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땺
{
  public class 땃 : 땓.떒
  {
    public const 땓.떊 딟 = 땓.떊.딟;
    public const 땓.떊 땄 = 땓.떊.땺;
    public const 땓.떊 딧 = 땓.떊.땥;
    public const 땓.떊 딢 = 땓.떊.땔;
    private 땺.땄 딟;
    private 딶.땖 딟;
    private int[] 딟;
    private int[] 땄;
    private int[] 딧;
    private int[] 딢;
    private int[] 땃;
    private int[] 딶;
    private int[] 땓;
    private int[] 땺;
    private int[] 땥;
    private bool[] 딟;
    private bool[] 땄;
    private bool[] 딧;
    private bool[,] 딟;
    private bool[] 딢;
    private bool[] 땃;
    private bool[] 딶;
    private bool[] 땓;
    private int[] 딝;
    private int 딟;
    private int 땄 = -1;
    private bool 딟;
    private int[,] 딟;
    private int[,] 땄;

    public 땃([In] 딶.땖 obj0) => this.딟(obj0, false);

    public 땃([In] 딶.땖 obj0, [In] bool obj1) => this.딟(obj0, obj1);

    private void 딟([In] 딶.땖 obj0, [In] bool obj1)
    {
      this.딟 = obj0;
      if (this.딟.떔() is 딶.딖)
        obj1 = false;
      this.딟 = new int[this.딟.땻().Count, 38];
      this.땄 = new int[2, 38];
      this.딟 = new 땺.땄(obj0);
      this.딟 = new int[this.딟.땻().Count];
      this.땄 = new int[this.딟.땻().Count];
      this.딧 = new int[this.딟.땻().Count];
      this.딢 = new int[this.딟.땻().Count];
      this.땃 = new int[this.딟.땻().Count];
      this.딶 = new int[this.딟.땻().Count];
      this.땓 = new int[this.딟.땻().Count];
      this.땥 = new int[this.딟.땻().Count];
      this.땺 = new int[this.딟.땻().Count];
      this.딟 = new bool[this.딟.땻().Count];
      this.땄 = new bool[this.딟.땻().Count];
      this.딧 = new bool[this.딟.땻().Count];
      this.딟 = new bool[this.딟.땻().Count, this.딟.땻().Count];
      this.딢 = new bool[2];
      // ISSUE: reference to a compiler-generated method
      this.딟(new bool[2]{ true, true });
      this.땃 = new bool[2];
      this.딶 = new bool[2];
      this.땓 = new bool[2]{ true, true };
      this.딝 = new int[2];
      this.딟 = -1;
      if (obj0.딥().Count == 0)
        return;
      땓.땮.딟((땓.떒) this, obj0, new 땓.땮.딟(this.땺));
      this.딟();
    }

    public void 땄([In] 딶.땙 obj0, [In] int obj1, [In] 땓.떊 obj2) => ++this.땄[obj1, (int) obj2];

    public void 딟([In] 딶.땙 obj0, [In] int obj1, [In] 땓.떊 obj2) => ++this.딟[obj1, (int) obj2];

    private bool 딟([In] int obj0) => this.딟.땻()[obj0] is 땓.떀 떀 && 떀.땁().ClassType == 땓.땅.땃;

    public void 딟(
      [In] 딶.땙 obj0,
      [In] int obj1,
      [In] int obj2,
      [In] string obj3,
      [In] WeaponGameplayData obj4,
      [In] int obj5,
      [In] 땃.딤 obj6,
      [In] 딢.딴 obj7)
    {
      int 땄 = obj0.땺()[obj2].땄;
      if (!this.딟(obj2) && this.딟(obj1))
        this.땓[땄] = false;
      this.딢[obj0.땺()[obj1].땄] = true;
      this.딧[obj1] = true;
      this.땄[obj2] = true;
      this.딟[obj2, obj1] = true;
      if (obj4.DamageType == 딶.딱.땃)
        return;
      this.땄()[땄] = false;
    }

    public void 딟(
      [In] 딶.땙 obj0,
      [In] int obj1,
      [In] int obj2,
      [In] string obj3,
      [In] WeaponGameplayData obj4,
      [In] 땃.딤 obj5,
      [In] 딢.딴 obj6)
    {
      땓.떀 떀 = this.딟.땻()[obj1] as 땓.떀;
      int 땄1 = obj0.땺()[obj1].땄;
      if (떀 != null)
        ++this.딝[땄1];
      this.땃[땄1] = true;
      int 땄2 = obj0.땺()[obj2].땄;
      ++this.땃[obj2];
      if (obj4.DamageType == 딶.딱.땃)
        ++this.딶[obj2];
      if (obj4.Category == 땓.땍.땃)
        ++this.땓[obj2];
      ++this.땄[obj2];
      this.땄 = obj2;
      if (this.딟(obj1) && this.딟(obj2))
        this.딶[땄2] = true;
      if (this.딟)
        return;
      this.딟(obj0, obj2, 땓.떊.때);
      this.딟 = true;
    }

    public void 딟([In] 딶.땙 obj0, [In] int obj1, [In] WeaponGameplayData obj2, [In] int obj3)
    {
      this.땥[obj1] = Mathf.Max(this.땥[obj1], obj3);
      this.땺[obj1] += obj3;
    }

    public void 땄([In] 딶.땙 obj0, [In] int obj1, [In] WeaponGameplayData obj2, [In] int obj3)
    {
    }

    public void 딟([In] 딶.땙 obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4)
    {
      if (!땓.땎.딧((this.딟.땻()[obj2] as 딶.땉).딟()))
        return;
      this.딟[obj1] = true;
    }

    public void 땄([In] 딶.땙 obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4)
    {
      if (!땓.땎.딧((this.딟.땻()[obj2] as 딶.땚).딢()))
        return;
      this.딟[obj1] = true;
    }

    public void 딟([In] 딶.땙 obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
    }

    public void 딟([In] 딶.땙 obj0, [In] int obj1, [In] 딢.딴 obj2)
    {
      if (!땓.땎.딧(obj2))
        return;
      this.딟[obj1] = true;
    }

    public void 땄([In] 딶.땙 obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
    }

    public void 딧([In] 딶.땙 obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
    }

    public void 딟([In] 딶.땙 obj0, [In] int obj1, [In] int obj2)
    {
    }

    public static int 딟([In] 딶.땖 obj0)
    {
      int num = -1;
      if (obj0.떓() == 딶.딹.딧)
      {
        for (int index = 0; index < 2; ++index)
        {
          if (obj0.딟.딟[index] == 딟.땾.딧)
            num = index;
        }
      }
      else
        num = obj0.떔().땃(obj0);
      return num;
    }

    private void 딟()
    {
      for (int index = 0; index < this.딟.땻().Count; ++index)
        this.딟.땻()[index].딟(index, this);
      딶.땙 땙 = this.딟.떂();
      this.딟.떔().딟(this.딟, (땓.떒) this);
      this.딟 = 땺.땃.딟(this.딟);
      if (this.딟 != -1)
        this.땄(땙, this.딟, 땓.떊.딝);
      int num1 = -1;
      List<int> intList1 = new List<int>();
      int num2 = 1;
      bool[] flagArray = new bool[2];
      foreach (int index1 in this.딟.땢())
      {
        땓.떀 떀 = this.딟.땻()[index1] as 땓.떀;
        if (this.땺[index1] > num2)
        {
          intList1.Clear();
          intList1.Add(index1);
          num2 = this.땺[index1];
        }
        else if (this.땺[index1] == num2)
          intList1.Add(index1);
        if (this.땄[index1] && !this.딧[index1])
          this.딟(땙, index1, 땓.떊.딱);
        int num3 = 0;
        int num4 = 0;
        int num5 = 0;
        foreach (int index2 in this.딟.땢())
        {
          if (땙.땺()[index1].땄 != 땙.땺()[index2].땄)
          {
            ++num5;
            if (this.딟[index1, index2])
              ++num4;
            if (this.딟[index2, index1])
              ++num3;
          }
        }
        if (num4 > 0 && num4 == num5)
          this.딟(땙, index1, 땓.떊.땠);
        if (num3 > 0 && num3 == num5)
        {
          int index3 = 땙.땺()[index1].땄 != 0 ? 0 : 1;
          if (!flagArray[index3])
          {
            this.땄(땙, index3, 땓.떊.딗);
            flagArray[index3] = true;
          }
        }
        if (!땙.땺()[index1].땺())
        {
          if (num3 > 0 && num3 == num5)
            this.딟(땙, index1, 땓.떊.땴);
          if (땙.땺()[index1].땄 == this.딟)
          {
            if (떀.땁().ClassType != 땓.땅.땃)
              num1 = -2;
            else if (num1 == -1)
              num1 = index1;
          }
          if (!this.딟(땙, index1))
            this.딟(땙, index1, 땓.떊.땥);
        }
      }
      for (int index = 0; index < intList1.Count; ++index)
        this.딟(땙, intList1[index], 땓.떊.땩);
      if (num1 >= 0)
        this.딟(땙, num1, 땓.떊.땤);
      this.딧(땙);
      this.딢(땙);
      this.땃(땙);
      this.딶(땙);
      this.땄(땙);
      List<int> intList2 = new List<int>();
      int num6 = 1;
      foreach (int index in this.딟.땢())
      {
        if (this.땥[index] > num6)
        {
          intList2.Clear();
          intList2.Add(index);
          num6 = this.땥[index];
        }
        else if (this.땥[index] == num6)
          intList2.Add(index);
      }
      for (int index = 0; index < intList2.Count; ++index)
        this.딟(땙, intList2[index], 땓.떊.땻);
      if (this.땄 != -1)
        this.딟(땙, this.땄, 땓.떊.땽);
      this.땓(땙);
      for (int index4 = 0; index4 < 2; ++index4)
      {
        bool flag = true;
        foreach (int index5 in this.딟.딧(index4))
        {
          if ((this.딟.땻()[index5] as 땓.떀).땁().딟() && !this.딟[index5])
          {
            flag = false;
            break;
          }
        }
        if (flag)
          this.땄(땙, index4, 땓.떊.땋);
      }
      foreach (int index in this.딟.땢())
      {
        if (this.딟(index))
        {
          if (this.딟[index, 7] > 0)
            this.딟(땙, index, 땓.떊.땲);
          int 땄 = 땙.땺()[index].땄;
          if (!땙.땺()[index].땺() && this.딶[땄])
          {
            this.딟(땙, index, 땓.떊.떏);
            if (this.땓[땄])
              this.딟(땙, index, 땓.떊.땼);
          }
        }
      }
      this.딟(땙, 땓.땅.딢, 땓.떊.떁);
      this.딟(땙, 땓.땅.딟, 땓.떊.딷);
      this.딟(땙, 땓.땅.땄, 땓.떊.땟);
      this.딟(땙, 땓.땅.딧, 땓.떊.땢);
      this.딟(땙);
      for (int index6 = 0; index6 < 2; ++index6)
      {
        int num7 = 0;
        foreach (int index7 in this.딟.딧(index6))
        {
          num7 += this.딟[index7, 22];
          num7 += this.딟[index7, 21];
          num7 += this.딟[index7, 23];
          num7 += this.딟[index7, 20];
        }
        if (num7 >= 3)
          this.땄(땙, index6, 땓.떊.땂);
      }
    }

    private bool 딟([In] 딶.땙 obj0, [In] int obj1) => this.딟.딟.딟 != null && this.딟.딟.딟[obj0.땺()[obj1].땄] == 딟.땾.딶;

    private void 딟([In] 딶.땙 obj0)
    {
      List<int> intList = new List<int>();
      int num1 = 1;
      foreach (int num2 in this.딟.땢())
      {
        if (!this.딟(this.딟.떂(), num2))
        {
          int num3 = this.딶(num2);
          if (num3 > num1)
          {
            intList.Clear();
            intList.Add(num2);
            num1 = num3;
          }
          else if (num3 == num1)
            intList.Add(num2);
        }
      }
      for (int index = 0; index < intList.Count; ++index)
        this.딟(obj0, intList[index], 땓.떊.땔);
    }

    private void 땄([In] 딶.땙 obj0)
    {
      List<int> intList = new List<int>();
      int num = 1;
      foreach (int index in this.딟.땢())
      {
        if (this.땓[index] > num)
        {
          intList.Clear();
          intList.Add(index);
          num = this.땓[index];
        }
        else if (this.땓[index] == num)
          intList.Add(index);
      }
      for (int index = 0; index < intList.Count; ++index)
        this.딟(obj0, intList[index], 땓.떊.떓);
    }

    private void 딧([In] 딶.땙 obj0)
    {
      for (int index = 0; index < this.딟.땻().Count; ++index)
      {
        if (this.딟[index] > 3)
          this.딟(obj0, index, 땓.떊.딦);
        else if (this.딟[index] == 3)
          this.딟(obj0, index, 땓.떊.땭);
        else if (this.딟[index] == 2)
          this.딟(obj0, index, 땓.떊.떂);
      }
    }

    private void 딢([In] 딶.땙 obj0)
    {
      List<int> intList = new List<int>();
      int num = 1;
      foreach (int index in this.딟.땢())
      {
        if (this.땃[index] > num)
        {
          intList.Clear();
          intList.Add(index);
          num = this.땃[index];
        }
        else if (this.땃[index] == num)
          intList.Add(index);
      }
      for (int index = 0; index < intList.Count; ++index)
        this.딟(obj0, intList[index], 땓.떊.땳);
    }

    private void 땃([In] 딶.땙 obj0)
    {
      List<int> intList = new List<int>();
      int num = 1;
      foreach (int index in this.딟.땢())
      {
        if (this.딧[index] > num)
        {
          intList.Clear();
          intList.Add(index);
          num = this.딧[index];
        }
        else if (this.딧[index] == num)
          intList.Add(index);
      }
      for (int index = 0; index < intList.Count; ++index)
        this.딟(obj0, intList[index], 땓.떊.딛);
    }

    private void 딶([In] 딶.땙 obj0)
    {
      List<int> intList = new List<int>();
      int num = 1;
      foreach (int index in this.딟.땢())
      {
        if (this.딶[index] > num)
        {
          intList.Clear();
          intList.Add(index);
          num = this.딶[index];
        }
        else if (this.딶[index] == num)
          intList.Add(index);
      }
      for (int index = 0; index < intList.Count; ++index)
        this.딟(obj0, intList[index], 땓.떊.딥);
    }

    private void 딟([In] 딶.땙 obj0, [In] 땓.땅 obj1, [In] 땓.떊 obj2)
    {
      List<int> intList = this.딟(obj1);
      for (int index = 0; index < intList.Count; ++index)
        this.딟(obj0, intList[index], obj2);
    }

    private List<int> 딟([In] 땓.땅 obj0)
    {
      List<int> intList = new List<int>();
      int num1 = 1;
      foreach (int index in this.딟.땢())
      {
        if ((this.딟.땻()[index] as 땓.떀).땁().ClassType == obj0)
        {
          int num2 = this.땄(index);
          if (num2 > num1)
          {
            intList.Clear();
            intList.Add(index);
            num1 = num2;
          }
          else if (num2 == num1)
            intList.Add(index);
        }
      }
      return intList;
    }

    private void 땓([In] 딶.땙 obj0)
    {
      List<int> intList = new List<int>();
      int num1 = 1;
      for (int index = 0; index < 2; ++index)
      {
        int num2 = 0 + this.땃(index, 땓.떊.땳) + this.땃(index, 땓.떊.딛) + this.땃(index, 땓.떊.떓) + this.땃(index, 땓.떊.딥) + this.땃(index, 땓.떊.땻) + this.땃(index, 땓.떊.딗) + this.땃(index, 땓.떊.땩) + this.땃(index, 땓.떊.때);
        if (num2 > num1)
        {
          intList.Clear();
          intList.Add(index);
          num1 = num2;
        }
        else if (num2 == num1)
          intList.Add(index);
      }
      for (int index = 0; index < intList.Count; ++index)
        this.땄(obj0, intList[index], 땓.떊.딣);
    }

    private int 딟([In] int obj0, [In] 땓.떊 obj1) => this.딟[obj0, (int) obj1] * this.딟(obj1);

    private int 땄([In] int obj0, [In] 땓.떊 obj1) => this.땄[obj0, (int) obj1] * this.딟(obj1);

    public int 딟([In] 땓.떊 obj0)
    {
      XPRewardEntry xpRewardEntry = this.딟.딟((int) obj0);
      if (xpRewardEntry != null)
        return xpRewardEntry.XP;
      Debug.LogWarning((object) ("Reward entry missing for " + (object) obj0));
      return 0;
    }

    private int 땄([In] int obj0)
    {
      int num = 0;
      for (땓.떊 떊 = 땓.떊.딟; 떊 <= 땓.떊.땺; ++떊)
        num += this.딟(obj0, 떊);
      return num;
    }

    private int 딧([In] int obj0)
    {
      int num = 0;
      for (땓.떊 떊 = 땓.떊.땥; 떊 <= 땓.떊.땔; ++떊)
        num += this.딟(obj0, 떊);
      return num;
    }

    public int 딢([In] int obj0) => this.땄(obj0) + this.딧(obj0);

    public int 땃([In] int obj0)
    {
      int num = 0;
      for (땓.떊 떊 = 땓.떊.딟; 떊 <= 땓.떊.땺; ++떊)
        num += this.땄(obj0, 떊);
      return num;
    }

    public int 딧([In] int obj0, [In] 땓.떊 obj1) => this.땄[obj0, (int) obj1];

    public int 딢([In] int obj0, [In] 땓.떊 obj1) => this.딟[obj0, (int) obj1];

    public string 땄([In] 땓.떊 obj0) => 딧.딪.딟(this.딟.딟((int) obj0)?.Text);

    public void 딟([In] int obj0, [In] int obj1)
    {
      for (int index = 0; index < 38; ++index)
      {
        this.딟[obj1, index] += this.딟[obj0, index];
        this.딟[obj0, index] = 0;
      }
    }

    private void 땺([In] 딶.땙 obj0)
    {
      for (int index = 0; index < this.딟.땻().Count; ++index)
      {
        if (obj0.땃() == obj0.땺()[index].땄)
        {
          if (this.땄[index] > 0)
          {
            ++this.딢[index];
            this.딧[index] = Mathf.Max(this.딢[index], this.딧[index]);
          }
          else
            this.딢[index] = 0;
        }
        this.딟[index] = Mathf.Max(this.땄[index], this.딟[index]);
        this.땄[index] = 0;
      }
    }

    private int 딶([In] int obj0)
    {
      int num = 0;
      for (땓.떊 떊 = 땓.떊.땥; 떊 <= 땓.떊.땔; ++떊)
        num += this.딟[obj0, (int) 떊];
      return num;
    }

    private int 땃([In] int obj0, [In] 땓.떊 obj1)
    {
      foreach (int index in this.딟.딧(obj0))
      {
        if (this.딟[index, (int) obj1] > 0)
          return 1;
      }
      return this.땄[obj0, (int) obj1] > 0 ? 1 : 0;
    }

    [CompilerGenerated]
    [SpecialName]
    public bool[] 땄() => this.땺;
  }
}
