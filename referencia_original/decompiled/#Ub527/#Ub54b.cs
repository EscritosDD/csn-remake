// Decompiled with JetBrains decompiler
// Type: 딧.땋
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace 딧
{
  public abstract class 땋
  {
    protected TimeSpan 딟 = 땋.땄;
    protected static readonly TimeSpan 땄 = new TimeSpan(0, 0, 10);
    protected DateTime 딟;
    protected 딧.땃 딟;
    protected 딧.딝 딟;

    public 땋([In] 딧.땃 obj0) => this.딟 = obj0;

    protected void 딟([In] string obj0, [In] string obj1) => this.딟(obj0, obj1, (byte[]) null, false);

    protected void 딟([In] string obj0, [In] string obj1, [In] string obj2) => this.딟(obj0, obj1, Encoding.UTF8.GetBytes(obj2), false);

    protected void 딟([In] string obj0, [In] string obj1, [In] byte[] obj2) => this.딟(obj0, obj1, obj2, false);

    protected void 딟([In] string obj0, [In] string obj1, [In] byte[] obj2, [In] bool obj3)
    {
      if (this.딟.땄())
        떀.딟(obj0 + " " + obj1);
      this.딟 = (딧.딝) new 땭(obj0, obj1, obj2);
    }

    public void 딟([In] string obj0) => this.땄("Authorization", "Bearer " + obj0);

    private void 땄([In] string obj0) => this.땄("Accept-Language", obj0);

    public void 땄([In] string obj0, [In] string obj1) => this.딟.딟(obj0, obj1);

    public void 딧([In] string obj0) => this.땄("X-HTTP-Method", obj0);

    public void 딧() => this.땄("Content-Type", "application/x-www-form-urlencoded;charset=UTF-8");

    public void 땃() => this.땄("Content-Type", "application/json;charset=UTF-8");

    public void 딶()
    {
      if (this.딟 == null)
        return;
      this.딟.딧(this);
      this.딟.딟();
      this.딟 = DateTime.Now;
    }

    public 딟 땓<딟>() => 땾.딟<딟>(this.딝().딧());

    [SpecialName]
    public bool 땺() => this.딟.딧();

    [SpecialName]
    public string 땥() => this.딟.땄();

    public virtual void 딢()
    {
      if (this.딟.딢() == null)
        return;
      this.딟(new 땽(this.딟, this.딟.딢()));
    }

    public abstract void 딟();

    public abstract void 땄();

    [CompilerGenerated]
    [SpecialName]
    public 땽 딝() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    protected void 딟([In] 땽 obj0) => this.딟 = obj0;

    [SpecialName]
    public bool 떎() => DateTime.Now - this.딟 > this.딟;
  }
}
