// Decompiled with JetBrains decompiler
// Type: 땥.땱
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using FarseerPhysics.Collision;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using 딝;

namespace 땥
{
  public class 땱
  {
    public 딝.땳 딟;
    public 딝.땳 땄;
    internal Queue<떆> 딟 = new Queue<떆>(256);
    public 딝.땴 딟;
    public 딝.땴 땄;
    internal 땣 딟;
    public 딝.딗 딟;
    public 딝.딗 땄;
    public 딝.땻 딟;
    public 딝.땻 땄;
    private float 딟;
    public 땅 딟 = new 땅();
    private 딺[] 딟 = new 딺[64];
    private bool 딟;
    private HashSet<딺> 딟 = new HashSet<딺>();
    private HashSet<딺> 땄 = new HashSet<딺>();
    private HashSet<딝.땺> 딟 = new HashSet<딝.땺>();
    private HashSet<딝.땺> 땄 = new HashSet<딝.땺>();
    private 땺.떆 딟 = new 땺.떆();
    public bool 땄 = true;
    private Stopwatch 딟 = new Stopwatch();
    public 떁 딟;

    private 땱()
    {
      this.딟 = 땣.땄;
      // ISSUE: reference to a compiler-generated method
      this.딟(new List<딹>());
      // ISSUE: reference to a compiler-generated method
      this.딟(new List<땾>());
      // ISSUE: reference to a compiler-generated method
      this.딟(new List<딺>(32));
      // ISSUE: reference to a compiler-generated method
      this.딟(new List<딝.땺>(32));
    }

    public 땱([In] 떁 obj0, [In] AABB obj1)
      : this()
    {
      this.딟 = obj0;
      // ISSUE: reference to a compiler-generated method
      this.딟(new 딘((땺.떌) new 땺.떐(obj1)));
    }

    public 땱([In] 떁 obj0)
      : this()
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(new 딘((땺.떌) new 땺.떉()));
      this.딟 = obj0;
    }

    [CompilerGenerated]
    [SpecialName]
    public List<딹> 딟() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public List<땾> 땄() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public float 딧() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public float 딢() => this.딧;

    [CompilerGenerated]
    [SpecialName]
    public float 땃() => this.딢;

    [CompilerGenerated]
    [SpecialName]
    public float 딶() => this.땃;

    [CompilerGenerated]
    [SpecialName]
    public float 땓() => this.딶;

    [CompilerGenerated]
    [SpecialName]
    public float 땺() => this.땓;

    [SpecialName]
    public int 땥() => this.떎().딟.딟();

    [SpecialName]
    public void 딟([In] bool obj0)
    {
      if (obj0)
        this.딟 |= 땣.땄;
      else
        this.딟 &= ~땣.땄;
    }

    [SpecialName]
    public bool 딝() => (this.딟 & 땣.땄) == 땣.땄;

    [CompilerGenerated]
    [SpecialName]
    public 딘 떎() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public List<딺> 떂() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public List<딝.땺> 땭() => this.딟;

    [SpecialName]
    public List<떆> 딦() => this.떎().딟;

    [SpecialName]
    public void 땄([In] bool obj0)
    {
      if (obj0)
        this.딟 |= 땣.딧;
      else
        this.딟 &= ~땣.딧;
    }

    [SpecialName]
    public bool 땤() => (this.딟 & 땣.딧) == 땣.딧;

    internal void 딟([In] 딺 obj0)
    {
      if (this.딟.Contains(obj0))
        return;
      this.딟.Add(obj0);
    }

    public void 땄([In] 딺 obj0)
    {
      if (this.땄.Contains(obj0))
        return;
      this.땄.Add(obj0);
    }

    public void 딟([In] 딝.땺 obj0)
    {
      if (this.딟.Contains(obj0))
        return;
      this.딟.Add(obj0);
    }

    private void 딟([In] 딝.땺 obj0, [In] bool obj1)
    {
      if (!obj1)
        ;
      if (this.땄.Contains(obj0))
        return;
      this.땄.Add(obj0);
    }

    public void 땄([In] 딝.땺 obj0) => this.딟(obj0, true);

    public void 땽()
    {
      this.떏();
      this.땲();
      this.땼();
      this.땋();
    }

    private void 땋()
    {
      if (this.땄.Count <= 0)
        return;
      foreach (딝.땺 땺 in this.땄)
      {
        bool flag = 땺.땺();
        this.땭().Remove(땺);
        딺 딺1 = 땺.딢();
        딺 딺2 = 땺.땃();
        딺1.딧(true);
        if (!땺.딝())
          딺2.딧(true);
        if (땺.딟.땄 != null)
          땺.딟.땄.딟 = 땺.딟.딟;
        if (땺.딟.딟 != null)
          땺.딟.딟.땄 = 땺.딟.땄;
        if (땺.딟 == 딺1.땤())
          딺1.딟(땺.딟.딟);
        땺.딟.땄 = (딝.땓) null;
        땺.딟.딟 = (딝.땓) null;
        if (!땺.딝())
        {
          if (땺.땄.땄 != null)
            땺.땄.땄.딟 = 땺.땄.딟;
          if (땺.땄.딟 != null)
            땺.땄.딟.땄 = 땺.땄.땄;
          if (땺.땄 == 딺2.땤())
            딺2.딟(땺.땄.딟);
          땺.땄.땄 = (딝.땓) null;
          땺.땄.딟 = (딝.땓) null;
        }
        if (!땺.딝() && !flag)
        {
          for (땙 땙 = 딺2.땽(); 땙 != null; 땙 = 땙.딟)
          {
            if (땙.딟 == 딺1)
              땙.딟.떂();
          }
        }
        if (this.땄 != null)
          this.땄(땺);
      }
      this.땄.Clear();
    }

    private void 땲()
    {
      if (this.딟.Count <= 0)
        return;
      foreach (딝.땺 땺 in this.딟)
      {
        this.땭().Add(땺);
        땺.딟.딟 = 땺;
        땺.딟.딟 = 땺.땃();
        땺.딟.땄 = (딝.땓) null;
        땺.딟.딟 = 땺.딢().땤();
        if (땺.딢().땤() != null)
          땺.딢().땤().땄 = 땺.딟;
        땺.딢().딟(땺.딟);
        if (!땺.딝())
        {
          땺.땄.딟 = 땺;
          땺.땄.딟 = 땺.딢();
          땺.땄.땄 = (딝.땓) null;
          땺.땄.딟 = 땺.땃().땤();
          if (땺.땃().땤() != null)
            땺.땃().땤().땄 = 땺.땄;
          땺.땃().딟(땺.땄);
          딺 딺1 = 땺.딢();
          딺 딺2 = 땺.땃();
          if (!땺.땺())
          {
            for (땙 땙 = 딺2.땽(); 땙 != null; 땙 = 땙.딟)
            {
              if (땙.딟 == 딺1)
                땙.딟.떂();
            }
          }
        }
        if (this.딟 != null)
          this.딟(땺);
      }
      this.딟.Clear();
    }

    private void 떏()
    {
      if (this.딟.Count <= 0)
        return;
      foreach (딺 딺 in this.딟)
      {
        this.떂().Add(딺);
        딺.딶(true);
        if (this.딟 != null)
          this.딟(딺);
      }
      this.딟.Clear();
    }

    private void 땼()
    {
      if (this.땄.Count <= 0)
        return;
      foreach (딺 딺 in this.땄)
      {
        딝.땓 땓1 = 딺.땤();
        while (땓1 != null)
        {
          딝.땓 땓2 = 땓1;
          땓1 = 땓1.딟;
          this.딟(땓2.딟, false);
        }
        딺.딟((딝.땓) null);
        땙 땙1 = 딺.땽();
        while (땙1 != null)
        {
          땙 땙2 = 땙1;
          땙1 = 땙1.딟;
          this.떎().딟(땙2.딟);
        }
        딺.딟((땙) null);
        for (int index = 0; index < 딺.딦().Count; ++index)
        {
          딺.딦()[index].딟(this.떎().딟);
          딺.딦()[index].땲();
        }
        딺.딟((List<떀>) null);
        this.떂().Remove(딺);
        딺.딶(false);
        if (this.땄 != null)
          this.땄(딺);
      }
      this.땄.Clear();
    }

    public void 땓([In] float obj0)
    {
      if (딝.땥.딟)
        this.딟.Start();
      this.땽();
      if (딝.땥.딟)
      {
        // ISSUE: reference to a compiler-generated method
        this.딢((float) this.딟.ElapsedTicks);
      }
      if ((double) obj0 == 0.0 || !this.땄)
      {
        if (!딝.땥.딟)
          return;
        this.딟.Stop();
        this.딟.Reset();
      }
      else
      {
        if ((this.딟 & 땣.딟) == 땣.딟)
        {
          this.떎().딟();
          this.딟 &= ~땣.딟;
        }
        딽 딽;
        딽.딧 = 1f / obj0;
        딽.딟 = obj0;
        딽.땄 = this.딟 * obj0;
        for (int index = 0; index < this.딟().Count; ++index)
          this.딟()[index].딟(obj0);
        if (딝.땥.딟)
        {
          // ISSUE: reference to a compiler-generated method
          this.딧((float) this.딟.ElapsedTicks - this.딶());
        }
        this.떎().땄();
        if (딝.땥.딟)
        {
          // ISSUE: reference to a compiler-generated method
          this.땃((float) this.딟.ElapsedTicks - (this.딶() + this.땃()));
        }
        this.딟(ref 딽);
        if (딝.땥.딟)
        {
          // ISSUE: reference to a compiler-generated method
          this.딶((float) this.딟.ElapsedTicks - (this.딶() + this.땃() + this.땓()));
        }
        if (딝.땥.땄)
          this.땄(ref 딽);
        if (딝.땥.딟)
        {
          // ISSUE: reference to a compiler-generated method
          this.땄((float) this.딟.ElapsedTicks - (this.딶() + this.땃() + this.땓() + this.땺()));
        }
        this.딟 = 딽.딧;
        if ((this.딟 & 땣.땄) != (땣) 0)
          this.땢();
        for (int index = 0; index < this.땄().Count; ++index)
          this.땄()[index].딟();
        if (!딝.땥.딟)
          return;
        this.딟.Stop();
        // ISSUE: reference to a compiler-generated method
        this.딟((float) this.딟.ElapsedTicks);
        this.딟.Reset();
      }
    }

    public void 땢()
    {
      for (int index = 0; index < this.떂().Count; ++index)
      {
        딺 딺 = this.떂()[index];
        딺.딟 = 떁.딟();
        딺.땃 = 0.0f;
      }
    }

    public void 딟([In] Func<떀, bool> obj0, [In] ref AABB obj1) => this.떎().딟.딟(new Func<int, bool>(new 땱.땦()
    {
      딟 = obj0,
      딟 = this
    }.딟), ref obj1);

    public void 딟([In] 땂 obj0, [In] 떁 obj1, [In] 떁 obj2)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      땱.떃 떃 = new 땱.떃() { 딟 = obj0, 딟 = this, 딟 = new 땺.딮() };
      // ISSUE: reference to a compiler-generated field
      떃.딟.딟 = 1f;
      // ISSUE: reference to a compiler-generated field
      떃.딟.딟 = obj1;
      // ISSUE: reference to a compiler-generated field
      떃.딟.땄 = obj2;
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated field
      this.떎().딟.딟(new Func<땺.딮, int, float>(떃.딟), ref 떃.딟);
    }

    private void 딧([In] 딺 obj0) => obj0.딟 |= 떑.땄;

    private void 딟([In] ref 딽 obj0)
    {
      this.딟.딟(this.떂().Count, this.떎().딟.Count, this.땭().Count, this.떎());
      foreach (딺 딺 in this.떂())
        딺.딟 &= ~떑.땄;
      for (int index = 0; index < this.떎().딟.Count; ++index)
        this.떎().딟[index].딟 &= ~땏.땄;
      foreach (딝.땺 땺 in this.땭())
        땺.땄 = false;
      int count = this.떂().Count;
      if (count > this.딟.Length)
        this.딟 = new 딺[Math.Max(this.딟.Length * 2, count)];
      for (int index1 = this.떂().Count - 1; index1 >= 0; --index1)
      {
        딺 딺1 = this.떂()[index1];
        if ((딺1.딟 & 떑.땄) == 떑.딟 && 딺1.딝() && 딺1.떎() && 딺1.딧() != 땎.딟)
        {
          this.딟.딟();
          int num1 = 0;
          딺[] 딟1 = this.딟;
          int index2 = num1;
          int num2 = index2 + 1;
          딺 딺2 = 딺1;
          딟1[index2] = 딺2;
          this.딧(딺1);
          while (num2 > 0)
          {
            딺 딺3 = this.딟[--num2];
            this.딟.딟(딺3);
            딺3.딧(true);
            if (딺3.딧() != 땎.딟)
            {
              for (땙 땙 = 딺3.땽(); 땙 != null; 땙 = 땙.딟)
              {
                떆 딟2 = 땙.딟;
                if ((딟2.딟 & 땏.땄) == 땏.딟 && 땙.딟.딶() && 땙.딟.떎())
                {
                  bool flag1 = 딟2.딟.딶();
                  bool flag2 = 딟2.땄.딶();
                  if (!flag1 && !flag2)
                  {
                    this.딟.딟(딟2);
                    딟2.딟 |= 땏.땄;
                    딺 딟3 = 땙.딟;
                    if ((딟3.딟 & 떑.땄) == 떑.딟)
                    {
                      this.딟[num2++] = 딟3;
                      this.딧(딟3);
                    }
                  }
                }
              }
              for (딝.땓 땓 = 딺3.땤(); 땓 != null; 땓 = 땓.딟)
              {
                if (!땓.딟.땄)
                {
                  딺 딟4 = 땓.딟;
                  if (딟4 != null)
                  {
                    if (딟4.떎())
                    {
                      this.딟.딟(땓.딟);
                      땓.딟.땄 = true;
                      if ((딟4.딟 & 떑.땄) == 떑.딟)
                      {
                        this.딟[num2++] = 딟4;
                        this.딧(딟4);
                      }
                    }
                  }
                  else
                  {
                    this.딟.딟(땓.딟);
                    땓.딟.땄 = true;
                  }
                }
              }
            }
          }
          this.딟.딟(ref obj0, ref this.딟);
          for (int index3 = 0; index3 < this.딟.딟; ++index3)
          {
            딺 딺4 = this.딟.딟[index3];
            if (딺4.딧() == 땎.딟)
              딺4.딟 &= ~떑.땄;
          }
        }
      }
      foreach (딺 딺 in this.떂())
      {
        if ((딺.딟 & 떑.땄) == 떑.땄 && 딺.딧() != 땎.딟)
          딺.딛();
      }
      this.떎().딟();
    }

    private void 땄([In] ref 딽 obj0)
    {
      this.딟.딟(64, 32, 0, this.떎());
      if (this.딟)
      {
        for (int index = 0; index < this.떂().Count; ++index)
        {
          this.떂()[index].딟 &= ~떑.땄;
          this.떂()[index].딟.딧 = 0.0f;
        }
        for (int index = 0; index < this.떎().딟.Count; ++index)
        {
          떆 떆 = this.떎().딟[index];
          떆.딟 &= ~(땏.땄 | 땏.땓);
          떆.딟 = 0;
          떆.딟 = 1f;
        }
      }
      do
      {
        떆 떆1 = (떆) null;
        float num1 = 1f;
        for (int index = 0; index < this.떎().딟.Count; ++index)
        {
          떆 떆2 = this.떎().딟[index];
          if (떆2.딶() && 떆2.딟 <= 8)
          {
            float num2;
            if ((떆2.딟 & 땏.땓) == 땏.땓)
            {
              num2 = 떆2.딟;
            }
            else
            {
              떀 딟1 = 떆2.딟;
              떀 땄 = 떆2.땄;
              if (!딟1.딶() && !땄.딶())
              {
                딺 딺1 = 딟1.땓();
                딺 딺2 = 땄.땓();
                땎 땎1 = 딺1.딧();
                땎 땎2 = 딺2.딧();
                bool flag1 = 딺1.딝() && 땎1 != 땎.딟;
                bool flag2 = 딺2.딝() && 땎2 != 땎.딟;
                if (flag1 || flag2)
                {
                  bool flag3 = (딺1.땺() || 땎1 != 땎.딧) && (딟1.딧 & 땄.딧()) == 땑.딟;
                  bool flag4 = (딺2.땺() || 땎2 != 땎.딧) && (땄.딧 & 딟1.딧()) == 땑.딟;
                  if (flag3 || flag4)
                  {
                    float 딧 = 딺1.딟.딧;
                    if ((double) 딺1.딟.딧 < (double) 딺2.딟.딧)
                    {
                      딧 = 딺2.딟.딧;
                      딺1.딟.딟(딧);
                    }
                    else if ((double) 딺2.딟.딧 < (double) 딺1.딟.딧)
                    {
                      딧 = 딺1.딟.딧;
                      딺2.딟.딟(딧);
                    }
                    this.딟.딟.딟(딟1.땃(), 떆2.땥());
                    this.딟.땄.딟(땄.땃(), 떆2.딝());
                    this.딟.딟 = 딺1.딟;
                    this.딟.땄 = 딺2.딟;
                    this.딟.딟 = 1f;
                    땺.땡 땡;
                    땺.땗.딟(out 땡, this.딟);
                    float 딟2 = 땡.딟;
                    num2 = 땡.딟 != 땺.땐.딢 ? 1f : Math.Min(딧 + (1f - 딧) * 딟2, 1f);
                    떆2.딟 = num2;
                    떆2.딟 |= 땏.땓;
                  }
                  else
                    continue;
                }
                else
                  continue;
              }
              else
                continue;
            }
            if ((double) num2 < (double) num1)
            {
              떆1 = 떆2;
              num1 = num2;
            }
          }
        }
        if (떆1 == null || 0.999998807907104 < (double) num1)
        {
          this.딟 = true;
          return;
        }
        떀 딟3 = 떆1.딟;
        떀 땄1 = 떆1.땄;
        딺 딺3 = 딟3.땓();
        딺 딺4 = 땄1.땓();
        딛 딟4 = 딺3.딟;
        딛 딟5 = 딺4.딟;
        딺3.떂(num1);
        딺4.떂(num1);
        떆1.딟(this.떎());
        떆1.딟 &= ~땏.땓;
        ++떆1.딟;
        if (!떆1.딶() || !떆1.떎())
        {
          떆1.딟(false);
          딺3.딟 = 딟4;
          딺4.딟 = 딟5;
          딺3.딣();
          딺4.딣();
        }
        else
        {
          딺3.딧(true);
          딺4.딧(true);
          this.딟.딟();
          this.딟.딟(딺3);
          this.딟.딟(딺4);
          this.딟.딟(떆1);
          딺3.딟 |= 떑.땄;
          딺4.딟 |= 떑.땄;
          떆1.딟 |= 땏.땄;
          딺[] 딺Array = new 딺[2]{ 딺3, 딺4 };
          for (int index = 0; index < 2; ++index)
          {
            딺 딺5 = 딺Array[index];
            if (딺5.딧() == 땎.딧)
            {
              for (땙 땙 = 딺5.땽(); 땙 != null; 땙 = 땙.딟)
              {
                떆 딟6 = 땙.딟;
                if (this.딟.딟 != this.딟.딢 && this.딟.땄 != this.딟.땃)
                {
                  if ((딟6.딟 & 땏.땄) != 땏.땄)
                  {
                    딺 딟7 = 땙.딟;
                    if ((딟7.딧() != 땎.딧 || 딺5.땺() || 딟7.땺()) && !딟6.딟.딶() && !딟6.땄.딶())
                    {
                      딛 딟8 = 딟7.딟;
                      if ((딟7.딟 & 떑.땄) == 떑.딟)
                        딟7.떂(num1);
                      딟6.딟(this.떎());
                      if (!딟6.딶())
                      {
                        딟7.딟 = 딟8;
                        딟7.딣();
                      }
                      else if (!딟6.떎())
                      {
                        딟7.딟 = 딟8;
                        딟7.딣();
                      }
                      else
                      {
                        딟6.딟 |= 땏.땄;
                        this.딟.딟(딟6);
                        if ((딟7.딟 & 떑.땄) != 떑.땄)
                        {
                          딟7.딟 |= 떑.땄;
                          if (딟7.딧() != 땎.딟)
                            딟7.딧(true);
                          this.딟.딟(딟7);
                        }
                      }
                    }
                  }
                }
                else
                  break;
              }
            }
          }
          딽 딽;
          딽.딟 = (1f - num1) * obj0.딟;
          딽.딧 = 1f / 딽.딟;
          딽.땄 = 1f;
          this.딟.딟(ref 딽, 딺3.딧, 딺4.딧);
          for (int index = 0; index < this.딟.딟; ++index)
          {
            딺 딺6 = this.딟.딟[index];
            딺6.딟 &= ~떑.땄;
            if (딺6.딧() == 땎.딧)
            {
              딺6.딛();
              for (땙 땙 = 딺6.땽(); 땙 != null; 땙 = 땙.딟)
                땙.딟.딟 &= ~(땏.땄 | 땏.땓);
            }
          }
          this.떎().딟();
        }
      }
      while (!this.땤());
      this.딟 = false;
    }

    public void 딟([In] 딹 obj0)
    {
      obj0.딟 = this;
      this.딟().Add(obj0);
      if (this.딟 == null)
        return;
      this.딟(obj0);
    }

    public void 땄([In] 딹 obj0)
    {
      if (!this.딟().Contains(obj0))
        return;
      this.딟().Remove(obj0);
      if (this.땄 == null)
        return;
      this.땄(obj0);
    }

    public void 딟([In] 땾 obj0) => this.땄().Add(obj0);

    public void 땄([In] 땾 obj0) => this.땄().Remove(obj0);

    public 떀 딟([In] 떁 obj0)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      땱.땆 땆 = new 땱.땆();
      // ISSUE: reference to a compiler-generated field
      땆.딟 = obj0;
      떁 떁 = new 떁(1.192093E-07f, 1.192093E-07f);
      AABB aabb;
      // ISSUE: reference to a compiler-generated field
      aabb.LowerBound = 땆.딟 - 떁;
      // ISSUE: reference to a compiler-generated field
      aabb.UpperBound = 땆.딟 + 떁;
      // ISSUE: reference to a compiler-generated field
      땆.딟 = (떀) null;
      // ISSUE: reference to a compiler-generated method
      this.딟(new Func<떀, bool>(땆.딟), ref aabb);
      // ISSUE: reference to a compiler-generated field
      return 땆.딟;
    }

    public List<떀> 땄([In] 떁 obj0)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      땱.땫 땫 = new 땱.땫();
      // ISSUE: reference to a compiler-generated field
      땫.딟 = obj0;
      떁 떁 = new 떁(1.192093E-07f, 1.192093E-07f);
      AABB aabb;
      // ISSUE: reference to a compiler-generated field
      aabb.LowerBound = 땫.딟 - 떁;
      // ISSUE: reference to a compiler-generated field
      aabb.UpperBound = 땫.딟 + 떁;
      // ISSUE: reference to a compiler-generated field
      땫.딟 = new List<떀>();
      // ISSUE: reference to a compiler-generated method
      this.딟(new Func<떀, bool>(땫.딟), ref aabb);
      // ISSUE: reference to a compiler-generated field
      return 땫.딟;
    }

    public void 딷()
    {
      this.땽();
      for (int index = this.떂().Count - 1; index >= 0; --index)
        this.땄(this.떂()[index]);
      for (int index = this.딟().Count - 1; index >= 0; --index)
        this.땄(this.딟()[index]);
      for (int index = this.땄().Count - 1; index >= 0; --index)
        this.땄(this.땄()[index]);
      this.땽();
    }
  }
}
