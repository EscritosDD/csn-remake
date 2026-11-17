// Decompiled with JetBrains decompiler
// Type: 딶.땁
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public abstract class 땁 : 땓.딲
  {
    public 땁([In] int obj0) => this.딟(obj0);

    [CompilerGenerated]
    [SpecialName]
    public int 딟() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    protected void 딟([In] int obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public 땖 땄() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] 땖 obj0) => this.딟 = obj0;

    public virtual string 딧() => (string) null;

    public virtual UnitWeapon 딢() => (UnitWeapon) null;

    public virtual bool 땃() => false;

    public virtual bool 딶() => true;

    public virtual int 딟([In] 딢.딴 obj0) => 0;

    public virtual int 땓() => 0;

    public virtual bool 땺() => false;

    public virtual int 딟([In] 땓.땊 obj0) => 0;

    public virtual int 땥() => 1;

    public virtual bool 땄([In] 땓.땊 obj0) => false;

    public virtual bool 딟([In] 땓.딲 obj0, [In] 땓.땊 obj1, [In] 땓.땊 obj2) => this.딟(obj2, obj1.땄);

    public virtual bool 딟([In] 땓.땊 obj0, [In] int obj1) => obj0.딢(딢.떍.떏) > 0 || obj0.딢(딢.떍.딢) <= 0 || obj1 == obj0.땄;

    public virtual bool 딧([In] 땓.땊 obj0) => !obj0.땺() && obj0.땓();

    public virtual int 딟([In] 땙 obj0, [In] 땓.딲 obj1, [In] int obj2, [In] bool obj3, [In] bool obj4)
    {
      땓.땊 땊 = obj0.땺()[this.딟()];
      return 땊.땺() || !땊.땓() || !obj4 || obj1 != null && 땊.땄 == obj0.땺()[obj1.딟()].땄 && !(obj1 is 땪) ? 0 : -1;
    }

    public virtual bool 딝() => false;

    public virtual bool 떎() => false;

    public virtual bool 떂() => false;

    public virtual bool 땭() => false;

    public virtual bool 딦() => false;

    public virtual bool 땤() => false;

    public virtual bool 땽() => true;

    public virtual bool 땋() => false;

    public virtual bool 땲() => false;

    public virtual bool 떏() => true;

    public virtual 땓.딵 땼() => 땓.딵.딟;

    public virtual void 딢([In] 땓.땊 obj0)
    {
    }

    public virtual void 딟([In] int obj0, [In] 땺.땃 obj1)
    {
    }

    public virtual bool 딟([In] 땓.땊 obj0, [In] bool obj1) => false;

    public virtual 딢.딴 딟([In] 땙 obj0, [In] int obj1) => 딢.딴.딟;

    public virtual void 땃([In] 땓.땊 obj0)
    {
    }

    public virtual bool 땢() => true;

    public virtual void 딶([In] 땓.땊 obj0)
    {
    }

    public virtual bool 딷() => true;

    public abstract 땓.땑 떁();

    public abstract Material 땟();

    public abstract string 땂();

    public abstract bool 땄([In] 딢.딴 obj0);

    public abstract int 딱();

    public abstract Transform 때();

    public abstract Transform 땩();

    public abstract Transform 딟([In] 땓.딺 obj0);

    public abstract string 딟([In] 땓.땊 obj0, [In] 땓.딺 obj1);

    public abstract AudioShader2 딟([In] 땓.딘 obj0);

    public abstract void 딟([In] List<딟.땩> obj0, [In] 땓.땾 obj1);

    public abstract void 땠();

    public abstract void 땴();
  }
}
