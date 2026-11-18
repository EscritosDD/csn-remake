// Decompiled with JetBrains decompiler
// Type: 땥.땅
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace 땥
{
  public class 땅
  {
    private const float 딟 = 0.0001f;
    private const float 땄 = 0.00121847f;
    public 딺[] 딟;
    public int 딟;
    public int 땄;
    public int 딧;
    public 땰[] 딟;
    public 딵[] 딟;
    public int 딢;
    public int 땃;
    private 딘 딟;
    private 땗 딟 = new 땗();
    private 떆[] 딟;
    public int 딶;
    private 딝.땺[] 딟;
    public float 딧;
    private Stopwatch 딟 = new Stopwatch();
    private float 딢;

    public void 딟([In] int obj0, [In] int obj1, [In] int obj2, [In] 딘 obj3)
    {
      this.딢 = obj0;
      this.땃 = obj1;
      this.딶 = obj2;
      this.딟 = 0;
      this.땄 = 0;
      this.딧 = 0;
      this.딟 = obj3;
      if (this.딟 == null || this.딟.Length < obj0)
      {
        this.딟 = new 딺[obj0];
        this.딟 = new 땰[obj0];
        this.딟 = new 딵[obj0];
      }
      if (this.딟 == null || this.딟.Length < obj1)
        this.딟 = new 떆[obj1 * 2];
      if (this.딟 != null && this.딟.Length >= obj2)
        return;
      this.딟 = new 딝.땺[obj2 * 2];
    }

    public void 딟()
    {
      this.딟 = 0;
      this.땄 = 0;
      this.딧 = 0;
    }

    public void 딟([In] ref 딽 obj0, [In] ref 떁 obj1)
    {
      float 딟1 = obj0.딟;
      for (int index = 0; index < this.딟; ++index)
      {
        딺 딺 = this.딟[index];
        떁 딟2 = 딺.딟.딟;
        float 딟3 = 딺.딟.딟;
        떁 떁1 = 딺.딢();
        float num1 = 딺.땃();
        딺.딟.땄 = 딺.딟.딟;
        딺.딟.땄 = 딺.딟.딟;
        if (딺.딧() == 땎.딧)
        {
          떁 떁2 = 떁1 + 딟1 * (딺.딟() * obj1 + 딺.딧 * 딺.딟);
          float num2 = num1 + 딟1 * 딺.땄 * 딺.땃;
          떁1 = 떁2 * 땴.딟((float) (1.0 - (double) 딟1 * (double) 딺.딶()), 0.0f, 1f);
          num1 = num2 * 땴.딟((float) (1.0 - (double) 딟1 * (double) 딺.땓()), 0.0f, 1f);
        }
        this.딟[index].딟 = 딟2;
        this.딟[index].딟 = 딟3;
        this.딟[index].딟 = 떁1;
        this.딟[index].딟 = num1;
      }
      딤 딤 = new 딤();
      딤.딟 = obj0;
      딤.딟 = this.딟;
      딤.딟 = this.딟;
      this.딟.딟(obj0, this.땄, this.딟, this.딟, this.딟);
      this.딟.딟();
      if (딝.땥.딧)
        this.딟.땄();
      if (딝.땥.딟)
      {
        this.딟.Start();
        this.딢 = 0.0f;
      }
      for (int index = 0; index < this.딧; ++index)
      {
        if (this.딟[index].딟)
          this.딟[index].딟(ref 딤);
      }
      if (딝.땥.딟)
        this.딢 += (float) this.딟.ElapsedTicks;
      for (int index1 = 0; index1 < 딝.땥.딢; ++index1)
      {
        if (딝.땥.딟)
          this.딟.Start();
        for (int index2 = 0; index2 < this.딧; ++index2)
        {
          딝.땺 땺 = this.딟[index2];
          if (땺.딟)
          {
            땺.땄(ref 딤);
            땺.딧(obj0.딧);
          }
        }
        if (딝.땥.딟)
        {
          this.딟.Stop();
          this.딢 += (float) this.딟.ElapsedTicks;
          this.딟.Reset();
        }
        this.딟.딧();
      }
      this.딟.딢();
      for (int index = 0; index < this.딟; ++index)
      {
        떁 딟4 = this.딟[index].딟;
        float 딟5 = this.딟[index].딟;
        떁 딟6 = this.딟[index].딟;
        float 딟7 = this.딟[index].딟;
        떁 떁3 = 딟1 * 딟6;
        if ((double) 떁.딶(떁3, 떁3) > 4.0)
        {
          float num = 2f / 떁3.땃();
          딟6 *= num;
        }
        float num3 = 딟1 * 딟7;
        if ((double) num3 * (double) num3 > 2.46740126609802)
        {
          float num4 = 1.570796f / Math.Abs(num3);
          딟7 *= num4;
        }
        떁 떁4 = 딟4 + 딟1 * 딟6;
        float num5 = 딟5 + 딟1 * 딟7;
        this.딟[index].딟 = 떁4;
        this.딟[index].딟 = num5;
        this.딟[index].딟 = 딟6;
        this.딟[index].딟 = 딟7;
      }
      bool flag1 = false;
      for (int index3 = 0; index3 < 딝.땥.땃; ++index3)
      {
        bool flag2 = this.딟.땃();
        bool flag3 = true;
        if (딝.땥.딟)
          this.딟.Start();
        for (int index4 = 0; index4 < this.딧; ++index4)
        {
          딝.땺 땺 = this.딟[index4];
          if (땺.딟)
          {
            bool flag4 = 땺.딧(ref 딤);
            flag3 = flag3 && flag4;
          }
        }
        if (딝.땥.딟)
        {
          this.딟.Stop();
          this.딢 += (float) this.딟.ElapsedTicks;
          this.딟.Reset();
        }
        if (flag2 && flag3)
        {
          flag1 = true;
          break;
        }
      }
      if (딝.땥.딟)
        this.딧 = this.딢;
      for (int index = 0; index < this.딟; ++index)
      {
        딺 딺 = this.딟[index];
        딺.딟.딟 = this.딟[index].딟;
        딺.딟.딟 = this.딟[index].딟;
        딺.딟(this.딟[index].딟);
        딺.땄(this.딟[index].딟);
        딺.딣();
      }
      this.딟(this.딟.딟);
      if (!딝.땥.딢)
        return;
      float val1 = float.MaxValue;
      for (int index = 0; index < this.딟; ++index)
      {
        딺 딺 = this.딟[index];
        if (딺.딧() != 땎.딟)
        {
          if ((딺.딟 & 떑.딢) == 떑.딟 || (double) 딺.딟 * (double) 딺.딟 > 0.00121846992988139 || (double) 떁.딶(딺.땄, 딺.땄) > 9.99999974737875E-05)
          {
            딺.딢 = 0.0f;
            val1 = 0.0f;
          }
          else
          {
            딺.딢 += 딟1;
            val1 = Math.Min(val1, 딺.딢);
          }
        }
      }
      if ((double) val1 < 0.5 || !flag1)
        return;
      for (int index = 0; index < this.딟; ++index)
        this.딟[index].딧(false);
    }

    internal void 딟([In] ref 딽 obj0, [In] int obj1, [In] int obj2)
    {
      for (int index = 0; index < this.딟; ++index)
      {
        딺 딺 = this.딟[index];
        this.딟[index].딟 = 딺.딟.딟;
        this.딟[index].딟 = 딺.딟.딟;
        this.딟[index].딟 = 딺.딢();
        this.딟[index].딟 = 딺.땃();
      }
      this.딟.딟(obj0, this.땄, this.딟, this.딟, this.딟);
      int num1 = 0;
      while (num1 < 딝.땥.땓 && !this.딟.딟(obj1, obj2))
        ++num1;
      this.딟[obj1].딟.땄 = this.딟[obj1].딟;
      this.딟[obj1].딟.땄 = this.딟[obj1].딟;
      this.딟[obj2].딟.땄 = this.딟[obj2].딟;
      this.딟[obj2].딟.땄 = this.딟[obj2].딟;
      this.딟.딟();
      for (int index = 0; index < 딝.땥.딶; ++index)
        this.딟.딧();
      float 딟1 = obj0.딟;
      for (int index = 0; index < this.딟; ++index)
      {
        떁 딟2 = this.딟[index].딟;
        float 딟3 = this.딟[index].딟;
        떁 딟4 = this.딟[index].딟;
        float 딟5 = this.딟[index].딟;
        떁 떁1 = 딟1 * 딟4;
        if ((double) 떁.딶(떁1, 떁1) > 4.0)
        {
          float num2 = 2f / 떁1.땃();
          딟4 *= num2;
        }
        float num3 = 딟1 * 딟5;
        if ((double) num3 * (double) num3 > 2.46740126609802)
        {
          float num4 = 1.570796f / Math.Abs(num3);
          딟5 *= num4;
        }
        떁 떁2 = 딟2 + 딟1 * 딟4;
        float num5 = 딟3 + 딟1 * 딟5;
        this.딟[index].딟 = 떁2;
        this.딟[index].딟 = num5;
        this.딟[index].딟 = 딟4;
        this.딟[index].딟 = 딟5;
        딺 딺 = this.딟[index];
        딺.딟.딟 = 떁2;
        딺.딟.딟 = num5;
        딺.딟(딟4);
        딺.땄(딟5);
        딺.딣();
      }
      this.딟(this.딟.딟);
    }

    public void 딟([In] 딺 obj0)
    {
      obj0.딧 = this.딟;
      this.딟[this.딟] = obj0;
      ++this.딟;
    }

    public void 딟([In] 떆 obj0) => this.딟[this.땄++] = obj0;

    public void 딟([In] 딝.땺 obj0) => this.딟[this.딧++] = obj0;

    private void 딟([In] 딜[] obj0)
    {
      if (this.딟 == null)
        return;
      for (int index = 0; index < this.땄; ++index)
      {
        떆 떆 = this.딟[index];
        if (떆.딟.딟 != null)
          떆.딟.딟(떆.딟, 떆.땄, 떆);
        if (떆.땄.딟 != null)
          떆.땄.딟(떆.땄, 떆.딟, 떆);
        if (this.딟.딟 != null)
        {
          딜 딜 = obj0[index];
          this.딟.딟(떆, 딜);
        }
      }
    }
  }
}
