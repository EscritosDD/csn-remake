// Decompiled with JetBrains decompiler
// Type: 땥.딺
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땥
{
  public class 딺 : IDisposable
  {
    private static int 딟;
    internal float 딟;
    public int 땄;
    public 떈 딟;
    internal 떑 딟;
    internal 땥.떁 딟;
    internal float 땄;
    internal float 딧;
    internal 땥.떁 땄;
    public 떇 딟;
    internal float 딢;
    internal 땥.딛 딟;
    internal float 땃;
    internal 땱 딟;
    internal 땥.떓 딟;
    private float 딶;
    private 땎 딟;
    private float 땓;
    private float 땺;
    private float 땥;
    public int 딧;

    internal 딺() => this.딟(new List<떀>(32));

    public 딺([In] 땱 obj0)
      : this(obj0, (object) null)
    {
    }

    public 딺([In] 땱 obj0, [In] object obj1)
    {
      this.딟(new List<떀>(32));
      this.땄 = 딺.딟++;
      this.딟 = obj0;
      this.딟(obj1);
      this.딟(1f);
      this.땃(false);
      this.딟(false);
      this.땄(true);
      this.딧(true);
      this.딟(땎.딟);
      this.딢(true);
      this.딟.딟.딟(0.0f);
      obj0.딟(this);
    }

    [SpecialName]
    public void 딟([In] 딝.딣 obj0)
    {
      for (int index = 0; index < this.딦().Count; ++index)
        this.딦()[index].딟 += obj0;
    }

    [SpecialName]
    public void 땄([In] 딝.딣 obj0)
    {
      for (int index = 0; index < this.딦().Count; ++index)
        this.딦()[index].딟 -= obj0;
    }

    [SpecialName]
    public void 딟([In] 딝.땁 obj0)
    {
      for (int index = 0; index < this.딦().Count; ++index)
        this.딦()[index].딟 += obj0;
    }

    [SpecialName]
    public void 땄([In] 딝.땁 obj0)
    {
      for (int index = 0; index < this.딦().Count; ++index)
        this.딦()[index].딟 -= obj0;
    }

    [CompilerGenerated]
    [SpecialName]
    public float 딟() => this.딝;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] float obj0) => this.딝 = obj0;

    [SpecialName]
    public float 땄() => this.땢() / 3.141593f;

    [SpecialName]
    public 땎 딧() => this.딟;

    [SpecialName]
    public void 딟([In] 땎 obj0)
    {
      if (this.딟 == obj0)
        return;
      this.딟 = obj0;
      this.땻();
      if (this.딟 == 땎.딟)
      {
        this.땄 = 땥.떁.딟();
        this.딟 = 0.0f;
        this.딟.땄 = this.딟.딟;
        this.딟.땄 = this.딟.딟;
        this.딛();
      }
      this.딧(true);
      this.딟 = 땥.떁.딟();
      this.땃 = 0.0f;
      땙 땙1 = this.땽();
      while (땙1 != null)
      {
        땙 땙2 = 땙1;
        땙1 = 땙1.딟;
        this.딟.떎().딟(땙2.딟);
      }
      this.딟((땙) null);
      땺.떌 딟 = this.딟.떎().딟;
      for (int index1 = 0; index1 < this.딦().Count; ++index1)
      {
        떀 떀 = this.딦()[index1];
        int 땄 = 떀.땄;
        for (int index2 = 0; index2 < 땄; ++index2)
          딟.땄(떀.딟[index2].땄);
      }
      for (int index = 0; index < this.딦().Count; ++index)
        this.딦()[index].땤();
    }

    [SpecialName]
    public void 딟([In] 땥.떁 obj0)
    {
      if (this.딟 == 땎.딟)
        return;
      if ((double) 땥.떁.딶(obj0, obj0) > 0.0)
        this.딧(true);
      this.땄 = obj0;
    }

    [SpecialName]
    public 땥.떁 딢() => this.땄;

    [SpecialName]
    public void 땄([In] float obj0)
    {
      if (this.딟 == 땎.딟)
        return;
      if ((double) obj0 * (double) obj0 > 0.0)
        this.딧(true);
      this.딟 = obj0;
    }

    [SpecialName]
    public float 땃() => this.딟;

    [SpecialName]
    public float 딶() => this.땺;

    [SpecialName]
    public void 딧([In] float obj0) => this.땺 = obj0;

    [SpecialName]
    public float 땓() => this.딶;

    [SpecialName]
    public void 딢([In] float obj0) => this.딶 = obj0;

    [SpecialName]
    public void 딟([In] bool obj0)
    {
      if (obj0)
        this.딟 |= 떑.땃;
      else
        this.딟 &= ~떑.땃;
    }

    [SpecialName]
    public bool 땺() => (this.딟 & 떑.땃) == 떑.땃;

    [SpecialName]
    public void 땄([In] bool obj0)
    {
      if (obj0)
      {
        this.딟 |= 떑.딢;
      }
      else
      {
        this.딟 &= ~떑.딢;
        this.딧(true);
      }
    }

    [SpecialName]
    public bool 땥() => (this.딟 & 떑.딢) == 떑.딢;

    [SpecialName]
    public void 딧([In] bool obj0)
    {
      if (obj0)
      {
        if ((this.딟 & 떑.딧) != 떑.딟)
          return;
        this.딟 |= 떑.딧;
        this.딢 = 0.0f;
        this.딟.떎().딟(this.땽(), true);
      }
      else
      {
        this.딟 &= ~떑.딧;
        this.딢 = 0.0f;
        this.땄 = 땥.떁.딟();
        this.딟 = 0.0f;
        this.딟 = 땥.떁.딟();
        this.땃 = 0.0f;
        this.딟.떎().딟(this.땽(), false);
      }
    }

    [SpecialName]
    public bool 딝() => this.딧() != 땎.딟 && (this.딟 & 떑.딧) == 떑.딧;

    [SpecialName]
    public void 딢([In] bool obj0)
    {
      if (obj0 == this.떎())
        return;
      if (obj0)
      {
        this.딟 |= 떑.땓;
        땺.떌 딟 = this.딟.떎().딟;
        for (int index = 0; index < this.딦().Count; ++index)
          this.딦()[index].딟(딟, ref this.딟);
      }
      else
      {
        this.딟 &= ~떑.땓;
        땺.떌 딟 = this.딟.떎().딟;
        for (int index = 0; index < this.딦().Count; ++index)
          this.딦()[index].딟(딟);
        땙 땙1 = this.땽();
        while (땙1 != null)
        {
          땙 땙2 = 땙1;
          땙1 = 땙1.딟;
          this.딟.떎().딟(땙2.딟);
        }
        this.딟((땙) null);
      }
    }

    [SpecialName]
    public bool 떎() => (this.딟 & 떑.땓) == 떑.땓;

    [SpecialName]
    public void 땃([In] bool obj0)
    {
      if (obj0)
        this.딟 |= 떑.딶;
      else
        this.딟 &= ~떑.딶;
      this.땻();
    }

    [SpecialName]
    public bool 떂() => (this.딟 & 떑.딶) == 떑.딶;

    [CompilerGenerated]
    [SpecialName]
    public bool 땭() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    internal void 딶([In] bool obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public List<떀> 딦() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    internal void 딟([In] List<떀> obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public 딝.땓 땤() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    internal void 딟([In] 딝.땓 obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public 땙 땽() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    internal void 딟([In] 땙 obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public object 땋() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] object obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public string 땲() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] string obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public FSBodyComponent 떏() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] FSBodyComponent obj0) => this.딟 = obj0;

    [SpecialName]
    public 땥.떁 땼() => this.딟.딟;

    [SpecialName]
    public void 땄([In] 땥.떁 obj0) => this.딟(ref obj0, this.땢());

    [SpecialName]
    public float 땢() => this.딟.딟;

    [SpecialName]
    public void 땃([In] float obj0) => this.딟(ref this.딟.딟, obj0);

    [SpecialName]
    public bool 딷() => this.딟 == 땎.딟;

    [SpecialName]
    public void 땓([In] bool obj0)
    {
      if (obj0)
        this.딟(땎.딟);
      else
        this.딟(땎.딧);
    }

    [SpecialName]
    public bool 떁() => (this.딟 & 떑.땺) == 떑.땺;

    [SpecialName]
    public void 땺([In] bool obj0)
    {
      if (obj0)
        this.딟 |= 떑.땺;
      else
        this.딟 &= ~떑.땺;
    }

    [SpecialName]
    public 땥.떁 땟() => this.딟.딟;

    [SpecialName]
    public 땥.떁 땂() => this.딟.딧;

    [SpecialName]
    public void 딧([In] 땥.떁 obj0)
    {
      if (this.딟 != 땎.딧)
        return;
      땥.떁 딟 = this.딟.딟;
      this.딟.딧 = obj0;
      this.딟.땄 = this.딟.딟 = 땥.땴.딟(ref this.딟, ref this.딟.딧);
      땥.떁 떁 = this.딟.딟 - 딟;
      this.땄 += new 땥.떁(-this.딟 * 떁.땄, this.딟 * 떁.딟);
    }

    [SpecialName]
    public float 딱() => this.땥;

    [SpecialName]
    public void 딶([In] float obj0)
    {
      if (this.딟 != 땎.딧)
        return;
      this.땥 = obj0;
      if ((double) this.땥 <= 0.0)
        this.땥 = 1f;
      this.딧 = 1f / this.땥;
    }

    [SpecialName]
    public float 때() => this.땓 + this.딱() * 땥.떁.딶(this.딟.딧, this.딟.딧);

    [SpecialName]
    public void 땓([In] float obj0)
    {
      if (this.딟 != 땎.딧 || (double) obj0 <= 0.0 || (this.딟 & 떑.딶) != 떑.딟)
        return;
      this.땓 = obj0 - this.딱() * 땥.떁.딶(this.땂(), this.땂());
      this.땄 = 1f / this.땓;
    }

    [SpecialName]
    public float 땩()
    {
      float num = 0.0f;
      for (int index = 0; index < this.딦().Count; ++index)
      {
        떀 떀 = this.딦()[index];
        num += 떀.떂();
      }
      return num / (float) this.딦().Count;
    }

    [SpecialName]
    public void 땺([In] float obj0)
    {
      for (int index = 0; index < this.딦().Count; ++index)
        this.딦()[index].땄(obj0);
    }

    [SpecialName]
    public float 땠()
    {
      float num = 0.0f;
      for (int index = 0; index < this.딦().Count; ++index)
      {
        떀 떀 = this.딦()[index];
        num += 떀.떎();
      }
      return num / (float) this.딦().Count;
    }

    [SpecialName]
    public void 땥([In] float obj0)
    {
      for (int index = 0; index < this.딦().Count; ++index)
        this.딦()[index].딟(obj0);
    }

    [SpecialName]
    public void 딟([In] 땑 obj0)
    {
      for (int index = 0; index < this.딦().Count; ++index)
        this.딦()[index].땄(obj0);
    }

    [SpecialName]
    public void 땄([In] 땑 obj0)
    {
      for (int index = 0; index < this.딦().Count; ++index)
        this.딦()[index].딟(obj0);
    }

    [SpecialName]
    public void 딧([In] 땑 obj0)
    {
      for (int index = 0; index < this.딦().Count; ++index)
        this.딦()[index].딧 = obj0;
    }

    [SpecialName]
    public void 딟([In] short obj0)
    {
      for (int index = 0; index < this.딦().Count; ++index)
        this.딦()[index].딟(obj0);
    }

    [SpecialName]
    public void 땥([In] bool obj0)
    {
      for (int index = 0; index < this.딦().Count; ++index)
        this.딦()[index].딟(obj0);
    }

    [SpecialName]
    public bool 땴() => (this.딟 & 떑.땥) == 떑.땥;

    [SpecialName]
    public void 딝([In] bool obj0)
    {
      if (obj0)
        this.딟 |= 떑.땥;
      else
        this.딟 &= ~떑.땥;
    }

    [CompilerGenerated]
    [SpecialName]
    public bool 딗() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public void 떎([In] bool obj0) => this.땄 = obj0;

    public void Dispose()
    {
      if (this.딗())
        return;
      this.딟.땄(this);
      this.떎(true);
      GC.SuppressFinalize((object) this);
    }

    public void 땳()
    {
      this.땃 = 0.0f;
      this.딟 = 0.0f;
      this.딟 = 땥.떁.딟();
      this.땄 = 땥.떁.딟();
    }

    public 떀 딟([In] 땺.땏 obj0) => new 떀(this, obj0);

    public 떀 딟([In] 땺.땏 obj0, [In] object obj1) => new 떀(this, obj0, obj1);

    public void 딟([In] 떀 obj0)
    {
      땙 땙 = this.땽();
      while (땙 != null)
      {
        떆 딟1 = 땙.딟;
        땙 = 땙.딟;
        떀 딟2 = 딟1.딟;
        떀 땄 = 딟1.땄;
        if (obj0 == 딟2 || obj0 == 땄)
          this.딟.떎().딟(딟1);
      }
      if ((this.딟 & 떑.땓) == 떑.땓)
      {
        땺.떌 딟 = this.딟.떎().딟;
        obj0.딟(딟);
      }
      this.딦().Remove(obj0);
      obj0.땲();
      obj0.딟((딺) null);
      this.땻();
    }

    public void 딟([In] ref 땥.떁 obj0, [In] float obj1)
    {
      this.땄(ref obj0, obj1);
      this.딟.떎().딟();
    }

    public void 딟([In] 땥.떁 obj0, [In] float obj1) => this.딟(ref obj0, obj1);

    public void 땄([In] ref 땥.떁 obj0, [In] float obj1)
    {
      this.딟.딟.딟(obj1);
      this.딟.딟 = obj0;
      this.딟.딟 = 땥.땴.딟(ref this.딟, this.딟.딧);
      this.딟.딟 = obj1;
      this.딟.땄 = this.딟.딟;
      this.딟.땄 = obj1;
      땺.떌 딟 = this.딟.떎().딟;
      for (int index = 0; index < this.딦().Count; ++index)
        this.딦()[index].딟(딟, ref this.딟, ref this.딟);
    }

    public void 딟(out 땥.떓 _param1) => _param1 = this.딟;

    public void 딟([In] 땥.떁 obj0, [In] 땥.떁 obj1) => this.딟(ref obj0, ref obj1);

    public void 딟([In] ref 땥.떁 obj0) => this.딟(ref obj0, ref this.딟.딟);

    public void 딢([In] 땥.떁 obj0) => this.딟(ref obj0, ref this.딟.딟);

    public void 딟([In] ref 땥.떁 obj0, [In] ref 땥.떁 obj1)
    {
      if (this.딟 != 땎.딧)
        return;
      if (!this.딝())
        this.딧(true);
      this.딟 += obj0;
      this.땃 += (float) (((double) obj1.딟 - (double) this.딟.딟.딟) * (double) obj0.땄 - ((double) obj1.땄 - (double) this.딟.딟.땄) * (double) obj0.딟);
    }

    public void 딝([In] float obj0)
    {
      if (this.딟 != 땎.딧)
        return;
      if (!this.딝())
        this.딧(true);
      this.땃 += obj0;
    }

    public void 땃([In] 땥.떁 obj0) => this.땄(ref obj0);

    public void 땄([In] 땥.떁 obj0, [In] 땥.떁 obj1) => this.땄(ref obj0, ref obj1);

    public void 땄([In] ref 땥.떁 obj0)
    {
      if (this.딟 != 땎.딧)
        return;
      if (!this.딝())
        this.딧(true);
      this.땄 += this.딧 * obj0;
    }

    public void 땄([In] ref 땥.떁 obj0, [In] ref 땥.떁 obj1)
    {
      if (this.딟 != 땎.딧)
        return;
      if (!this.딝())
        this.딧(true);
      this.땄 += this.딧 * obj0;
      this.딟 += this.땄 * (float) (((double) obj1.딟 - (double) this.딟.딟.딟) * (double) obj0.땄 - ((double) obj1.땄 - (double) this.딟.딟.땄) * (double) obj0.딟);
    }

    public void 떎([In] float obj0)
    {
      if (this.딟 != 땎.딧)
        return;
      if (!this.딝())
        this.딧(true);
      this.딟 += this.땄 * obj0;
    }

    public void 땻()
    {
      this.땥 = 0.0f;
      this.딧 = 0.0f;
      this.땓 = 0.0f;
      this.땄 = 0.0f;
      this.딟.딧 = 땥.떁.딟();
      if (this.딧() == 땎.땄)
      {
        this.딟.땄 = this.딟.딟;
        this.딟.딟 = this.딟.딟;
        this.딟.땄 = this.딟.딟;
      }
      else
      {
        땥.떁 떁1 = 땥.떁.딟();
        foreach (떀 떀 in this.딦())
        {
          if (떀.땃() != null && (double) 떀.땃().딟 != 0.0)
          {
            땺.딫 딟 = 떀.땃().딟;
            this.땥 += 딟.딧;
            떁1 += 딟.딧 * 딟.딟;
            this.땓 += 딟.땄;
          }
        }
        if (this.딧() == 땎.딟)
        {
          this.딟.땄 = this.딟.딟 = this.딟.딟;
        }
        else
        {
          if ((double) this.땥 > 0.0)
          {
            this.딧 = 1f / this.땥;
            떁1 *= this.딧;
          }
          else
          {
            this.땥 = 1f;
            this.딧 = 1f;
          }
          if ((double) this.땓 > 0.0 && (this.딟 & 떑.딶) == 떑.딟)
          {
            this.땓 -= this.땥 * 땥.떁.딶(떁1, 떁1);
            this.땄 = 1f / this.땓;
          }
          else
          {
            this.땓 = 0.0f;
            this.땄 = 0.0f;
          }
          땥.떁 딟 = this.딟.딟;
          this.딟.딧 = 떁1;
          this.딟.땄 = this.딟.딟 = 땥.땴.딟(ref this.딟, ref this.딟.딧);
          땥.떁 떁2 = this.딟.딟 - 딟;
          this.땄 += new 땥.떁(-this.딟 * 떁2.땄, this.딟 * 떁2.딟);
        }
      }
    }

    public 땥.떁 딧([In] ref 땥.떁 obj0) => 땥.땴.딟(ref this.딟, ref obj0);

    public 땥.떁 딶([In] 땥.떁 obj0) => this.딧(ref obj0);

    public 땥.떁 딢([In] ref 땥.떁 obj0) => 땥.땴.딟(this.딟.딟, obj0);

    public 땥.떁 땓([In] 땥.떁 obj0) => this.딢(ref obj0);

    public 땥.떁 땃([In] ref 땥.떁 obj0) => 땥.땴.땄(ref this.딟, obj0);

    public 땥.떁 땺([In] 땥.떁 obj0) => this.땃(ref obj0);

    public 땥.떁 딶([In] ref 땥.떁 obj0) => 땥.땴.땄(this.딟.딟, obj0);

    public 땥.떁 땥([In] 땥.떁 obj0) => this.딶(ref obj0);

    public 땥.떁 딝([In] 땥.떁 obj0) => this.땓(ref obj0);

    public 땥.떁 땓([In] ref 땥.떁 obj0) => this.땄 + new 땥.떁((float) (-(double) this.딟 * ((double) obj0.땄 - (double) this.딟.딟.땄)), this.딟 * (obj0.딟 - this.딟.딟.딟));

    public 땥.떁 떎([In] 땥.떁 obj0) => this.땺(ref obj0);

    public 땥.떁 땺([In] ref 땥.떁 obj0) => this.딝(this.딧(ref obj0));

    public 딺 딥()
    {
      딺 딺 = this.떓();
      for (int index = 0; index < this.딦().Count; ++index)
        this.딦()[index].땄(딺);
      return 딺;
    }

    public 딺 떓()
    {
      딺 딺 = new 딺();
      딺.딟 = this.딟;
      딺.딟(this.땋());
      딺.딧(this.딶());
      딺.땄 = this.땄;
      딺.딢(this.땓());
      딺.딟 = this.딟;
      딺.땄(this.땼());
      딺.땃(this.땢());
      딺.딟 = this.딟;
      딺.딟 = this.딟;
      this.딟.딟(딺);
      return 딺;
    }

    internal void 딛()
    {
      땥.떓 떓 = new 땥.떓();
      떓.딟.딟(this.딟.땄);
      떓.딟 = this.딟.땄 - 땥.땴.딟(떓.딟, this.딟.딧);
      땺.떌 딟 = this.딟.떎().딟;
      for (int index = 0; index < this.딦().Count; ++index)
        this.딦()[index].딟(딟, ref 떓, ref this.딟);
    }

    internal void 딣()
    {
      this.딟.딟.딟(this.딟.딟);
      this.딟.딟 = this.딟.딟 - 땥.땴.딟(this.딟.딟, this.딟.딧);
    }

    internal bool 딟([In] 딺 obj0)
    {
      if (this.딟 != 땎.딧 && obj0.딟 != 땎.딧)
        return false;
      for (딝.땓 땓 = this.땤(); 땓 != null; 땓 = 땓.딟)
      {
        if (땓.딟 == obj0 && !땓.딟.땺())
          return false;
      }
      return true;
    }

    internal void 떂([In] float obj0)
    {
      this.딟.딟(obj0);
      this.딟.딟 = this.딟.땄;
      this.딟.딟 = this.딟.땄;
      this.딟.딟.딟(this.딟.딟);
      this.딟.딟 = this.딟.딟 - 땥.땴.딟(this.딟.딟, this.딟.딧);
    }

    public void 땄([In] 딺 obj0)
    {
      for (int index1 = 0; index1 < this.딦().Count; ++index1)
      {
        떀 떀1 = this.딦()[index1];
        for (int index2 = 0; index2 < obj0.딦().Count; ++index2)
        {
          떀 떀2 = obj0.딦()[index2];
          떀1.땄(떀2);
        }
      }
    }

    public void 딧([In] 딺 obj0)
    {
      for (int index1 = 0; index1 < this.딦().Count; ++index1)
      {
        떀 떀1 = this.딦()[index1];
        for (int index2 = 0; index2 < obj0.딦().Count; ++index2)
        {
          떀 떀2 = obj0.딦()[index2];
          떀1.딟(떀2);
        }
      }
    }
  }
}
