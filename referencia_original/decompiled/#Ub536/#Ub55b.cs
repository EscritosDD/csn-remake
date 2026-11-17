// Decompiled with JetBrains decompiler
// Type: 딶.땛
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딶
{
  public abstract class 땛
  {
    protected bool 딟;
    protected 땖 딟;

    public bool 딢([In] 땖 obj0) => this.땄(obj0).딟 != 떌.딟;

    public int 땃([In] 땖 obj0) => this.땄(obj0).딟;

    public virtual bool 떂() => true;

    public virtual void 딦() => this.딟 = false;

    public virtual bool 땭() => true;

    public virtual void 딟([In] 땯 obj0, [In] 딨 obj1)
    {
    }

    public virtual bool 딧([In] 땖 obj0) => !this.딟 && !obj0.땉().딷().딸() && !obj0.딟.땄() && this.딢(obj0) && !obj0.땼();

    public virtual void 딟([In] 땖 obj0) => this.딟 = obj0;

    public virtual bool 땤() => true;

    public abstract void 딟([In] 땖 obj0, [In] GameplayHUDHandler obj1);

    public abstract 떉 땄([In] 땖 obj0);

    public abstract void 딟([In] 땖 obj0, [In] 땙 obj1);

    public abstract void 딟([In] 땖 obj0, [In] 땓.떒 obj1);

    public abstract void 딟([In] 땖 obj0, out float _param2, out float _param3);

    public abstract void 딟([In] int obj0, [In] 땓.땊 obj1);

    public abstract bool 땃();

    public abstract bool 딶();

    public abstract void 딟([In] List<딠.딿> obj0);

    public abstract bool 딟([In] 딶.땃 obj0, [In] bool obj1);

    public abstract void 딟([In] List<딟.땩> obj0);

    public abstract void 땓();

    public abstract LocalisationEntry 땺();

    public abstract LocalisationEntry 땥();

    [SpecialName]
    public abstract int 떎();

    public abstract void 딝();

    public abstract void 딟([In] string obj0);

    public abstract void 딟([In] 땖 obj0, [In] 땙 obj1, [In] 땓.떒 obj2);

    public abstract void 땄();

    public abstract void 딧();

    public abstract bool 딢();

    public abstract void 딟();
  }
}
