// Decompiled with JetBrains decompiler
// Type: 땥.떀
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using FarseerPhysics.Collision;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땥
{
  public class 떀 : IDisposable
  {
    private static int 딟;
    public 딝.땔 딟;
    public 딝.딛 딟;
    public 딝.딣 딟;
    public 딝.땁 딟;
    public 딲[] 딟;
    public int 땄;
    internal 땑 딟;
    internal 땑 땄;
    internal short 딟;
    internal Dictionary<int, bool> 딟;
    public 땑 딧;
    private float 딟;
    private float 땄;
    private bool 딟;

    internal 떀()
    {
    }

    public 떀([In] 딺 obj0, [In] 땺.땏 obj1)
      : this(obj0, obj1, (object) null)
    {
    }

    public 떀([In] 딺 obj0, [In] 땺.땏 obj1, [In] object obj2)
    {
      this.땄 = 딝.땥.딟;
      this.딟 = 딝.땥.땄;
      this.딟 = (short) 0;
      this.딧 = 딝.땥.딧;
      this.딟(0.2f);
      this.땄(0.0f);
      this.딟(obj0);
      this.딟(false);
      this.딟(obj2);
      if (딝.땥.딶)
        this.딟(obj1);
      else if (obj1 != null)
        this.딟(obj1.땄());
      this.땽();
    }

    [SpecialName]
    public void 딟([In] short obj0)
    {
      if ((int) this.딟 == (int) obj0)
        return;
      this.딟 = obj0;
      this.땤();
    }

    [SpecialName]
    public short 딟() => this.딟;

    [SpecialName]
    public 땑 땄() => this.딟;

    [SpecialName]
    public void 딟([In] 땑 obj0)
    {
      if (this.딟 == obj0)
        return;
      this.딟 = obj0;
      this.땤();
    }

    [SpecialName]
    public 땑 딧() => this.땄;

    [SpecialName]
    public void 땄([In] 땑 obj0)
    {
      if (this.땄 == obj0)
        return;
      this.땄 = obj0;
      this.땤();
    }

    [SpecialName]
    public 땺.땙 딢() => this.땃().딢();

    [CompilerGenerated]
    [SpecialName]
    public 땺.땏 땃() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    internal void 딟([In] 땺.땏 obj0) => this.딟 = obj0;

    [SpecialName]
    public bool 딶() => this.딟;

    [SpecialName]
    public void 딟([In] bool obj0)
    {
      this.땓().딧(true);
      this.딟 = obj0;
    }

    [CompilerGenerated]
    [SpecialName]
    public 딺 땓() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    internal void 딟([In] 딺 obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public object 땺() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] object obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public string 땥() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] string obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public long 딝() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] long obj0) => this.딟 = obj0;

    [SpecialName]
    public float 떎() => this.딟;

    [SpecialName]
    public void 딟([In] float obj0) => this.딟 = obj0;

    [SpecialName]
    public float 떂() => this.땄;

    [SpecialName]
    public void 땄([In] float obj0) => this.땄 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public int 땭() => this.딧;

    [CompilerGenerated]
    [SpecialName]
    public bool 딦() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public void 땄([In] bool obj0) => this.땄 = obj0;

    public void Dispose()
    {
      if (this.딦())
        return;
      this.땓().딟(this);
      this.땄(true);
      GC.SuppressFinalize((object) this);
    }

    public void 딟([In] 떀 obj0)
    {
      if (this.딟 == null || !this.딟.ContainsKey(obj0.땭()))
        return;
      this.딟[obj0.땭()] = false;
      this.땤();
    }

    public void 땄([In] 떀 obj0)
    {
      if (this.딟 == null)
        this.딟 = new Dictionary<int, bool>();
      if (this.딟.ContainsKey(obj0.땭()))
        this.딟[obj0.땭()] = true;
      else
        this.딟.Add(obj0.땭(), true);
      this.땤();
    }

    public bool 딧([In] 떀 obj0) => this.딟 != null && this.딟.ContainsKey(obj0.땭()) && this.딟[obj0.땭()];

    internal void 땤()
    {
      for (땙 땙 = this.땓().땽(); 땙 != null; 땙 = 땙.딟)
      {
        떆 딟1 = 땙.딟;
        떀 딟2 = 딟1.딟;
        떀 땄 = 딟1.땄;
        if (딟2 == this || 땄 == this)
          딟1.떂();
      }
      땱 딟3 = this.땓().딟;
      if (딟3 == null)
        return;
      땺.떌 딟4 = 딟3.떎().딟;
      for (int index = 0; index < this.땄; ++index)
        딟4.땄(this.딟[index].땄);
    }

    private void 땽()
    {
      this.딟 = this.땃() == null ? new 딲[0] : new 딲[this.땃().딟()];
      this.땄 = 0;
      // ISSUE: reference to a compiler-generated method
      this.딟(떀.딟++);
      if ((this.땓().딟 & 떑.땓) == 떑.땓)
        this.딟(this.땓().딟.떎().딟, ref this.땓().딟);
      this.땓().딦().Add(this);
      if (this.땃() != null && (double) this.땃().딟 > 0.0)
        this.땓().땻();
      this.땓().딟.딟 |= 땣.딟;
      if (this.땓().딟.딟 == null)
        return;
      this.땓().딟.딟(this);
    }

    public bool 딟([In] ref 떁 obj0) => this.땃().딟(ref this.땓().딟, ref obj0);

    public bool 딟(out 땺.딯 _param1, [In] ref 땺.딮 obj1, [In] int obj2) => this.땃().딟(out _param1, ref obj1, ref this.땓().딟, obj2);

    public void 딟(out AABB _param1, [In] int obj1) => _param1 = this.딟[obj1].딟;

    public 떀 땄([In] 딺 obj0)
    {
      떀 떀 = new 떀();
      떀.딟(obj0);
      if (딝.땥.딶)
        떀.딟(this.땃());
      else
        떀.딟(this.땃().땄());
      떀.딟(this.땺());
      떀.딟(this.딝());
      떀.땄(this.떂());
      떀.딟(this.떎());
      떀.딟(this.딶());
      떀.딟 = this.딟();
      떀.땄 = this.딧();
      떀.딟 = this.땄();
      if (this.딟 != null)
      {
        떀.딟 = new Dictionary<int, bool>();
        foreach (KeyValuePair<int, bool> keyValuePair in this.딟)
          떀.딟.Add(keyValuePair.Key, keyValuePair.Value);
      }
      떀.땽();
      return 떀;
    }

    public 떀 땋() => this.땄(this.땓().떓());

    internal void 땲()
    {
      this.딟 = (딲[]) null;
      this.딟((땺.땏) null);
      this.딟 = (딝.딛) null;
      this.딟 = (딝.딣) null;
      this.딟 = (딝.땁) null;
      this.딟 = (딝.땔) null;
      if (this.땓().딟.땄 != null)
        this.땓().딟.땄(this);
      this.땓().딟.딟 = (딝.땴) null;
      this.땓().딟.땄 = (딝.땴) null;
      this.딟 = (딝.땁) null;
      this.딟 = (딝.딣) null;
    }

    internal void 딟([In] 땺.떌 obj0, [In] ref 떓 obj1)
    {
      if (this.땃() == null)
        return;
      this.땄 = this.땃().딟();
      for (int index = 0; index < this.땄; ++index)
      {
        딲 딲 = new 딲();
        this.땃().딟(out 딲.딟, ref obj1, index);
        딲.딟 = this;
        딲.딟 = index;
        딲.땄 = obj0.딟(ref 딲);
        this.딟[index] = 딲;
      }
    }

    internal void 딟([In] 땺.떌 obj0)
    {
      for (int index = 0; index < this.땄; ++index)
      {
        obj0.딟(this.딟[index].땄);
        this.딟[index].땄 = -1;
      }
      this.땄 = 0;
    }

    internal void 딟([In] 땺.떌 obj0, [In] ref 떓 obj1, [In] ref 떓 obj2)
    {
      if (this.땄 == 0)
        return;
      for (int index = 0; index < this.땄; ++index)
      {
        딲 딲 = this.딟[index];
        AABB aabb1;
        this.땃().딟(out aabb1, ref obj1, 딲.딟);
        AABB aabb2;
        this.땃().딟(out aabb2, ref obj2, 딲.딟);
        딲.딟.딟(ref aabb1, ref aabb2);
        떁 떁 = obj2.딟 - obj1.딟;
        obj0.딟(딲.땄, ref 딲.딟, 떁);
      }
    }

    internal bool 딢([In] 떀 obj0) => this.땄() == obj0.땄() && this.딧() == obj0.딧() && (int) this.딟() == (int) obj0.딟() && (double) this.떎() == (double) obj0.떎() && this.딶() == obj0.딶() && (double) this.떂() == (double) obj0.떂() && this.땃().딟(obj0.땃()) && this.땺() == obj0.땺() && this.딝() == obj0.딝();
  }
}
