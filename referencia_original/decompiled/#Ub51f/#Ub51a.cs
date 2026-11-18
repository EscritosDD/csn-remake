// Decompiled with JetBrains decompiler
// Type: 딟.딚
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireline;
using SplashDamage.Mobile.Fireline.Data;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딟
{
  public abstract class 딚
  {
    protected const string 딟 = "/auth/oauth2/token";
    protected const string 땄 = "/auth/state";
    public const string 딧 = "_identities";
    protected 딚.따 딟;
    protected ClientDescriptor 딟;
    protected 딯 딟;
    private List<Func<딡>> 딟 = new List<Func<딡>>();
    private Action<땉> 딟;
    private Action 딟;

    protected 딚([In] ClientDescriptor obj0, [In] 딯 obj1, [In] 땉 obj2)
    {
      this.딟 = obj0;
      this.딟 = obj1;
      // ISSUE: reference to a compiler-generated method
      this.딟(obj2);
      this.딟 = 딚.따.딟;
    }

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 딟([In] Action<땉> obj0) => this.딟 += obj0;

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 땄([In] Action<땉> obj0) => this.딟 -= obj0;

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 딟([In] Action obj0) => this.딟 += obj0;

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 땄([In] Action obj0) => this.딟 -= obj0;

    protected static 딧.땢 딟([In] 딧.땢 obj0, [In] ClientDescriptor obj1) => obj0.딟("client_id", obj1.땄()).딟("client_secret", obj1.딧());

    protected 딧.땢 딟([In] 딧.땢 obj0) => 딚.딟(obj0, this.딟);

    protected 딠 딟([In] 딠 obj0) => obj0.땃(this.딟.딟()).딶(this.땃().딧());

    protected string 딟([In] string obj0) => 딧.땼.딟(this.딟.딢()).땄(obj0);

    protected string 딟([In] string obj0, [In] 딧.땢 obj1) => 딧.땼.딟(this.딟.딢()).딟(obj0, obj1);

    protected 딠 땄([In] string obj0) => this.딟(딠.딟(this.딟(obj0)));

    protected 딠 딧([In] string obj0) => this.딟(딠.땄(this.딟(obj0)));

    protected 딠 땄([In] string obj0, [In] 딧.땢 obj1) => this.딟(딠.딟(this.딟(obj0, obj1)));

    protected 딠 딟([In] string obj0, [In] 딧.땤 obj1) => this.딟(this.딟(딠.딟(this.딟(obj0), obj1.딟())), obj1);

    protected 딠 땄([In] string obj0, [In] 딧.땤 obj1) => this.딟(this.딟(딠.땄(this.딟(obj0), obj1.딟())), obj1);

    private 딠 딟([In] 딠 obj0, [In] 딧.땤 obj1) => obj0.딟("Content-Type", "application/json");

    protected void 딟([In] Func<딡> obj0) => this.딟.Add(obj0);

    public void 땄()
    {
      if (this.딟 != 딚.따.딟)
        return;
      this.딟.ForEach(new Action<Func<딡>>(this.땄));
      this.딟.Clear();
    }

    private void 땄([In] Func<딡> obj0)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      딚.딾 딾 = new 딚.딾();
      // ISSUE: reference to a compiler-generated field
      딾.딟 = obj0;
      // ISSUE: reference to a compiler-generated field
      딾.딟 = this;
      // ISSUE: reference to a compiler-generated field
      딡 딡 = 딾.딟();
      // ISSUE: reference to a compiler-generated field
      딾.딟 = this.땃().딧();
      // ISSUE: reference to a compiler-generated field
      딾.딟 = 딡.땓();
      // ISSUE: reference to a compiler-generated method
      딡.딟(new Action<땀>(딾.딟));
      this.딟.딟(딡);
    }

    private void 딟([In] 땀 obj0, [In] string obj1, [In] Func<딡> obj2, [In] Action<땀> obj3)
    {
      if (this.땄(obj0))
      {
        if (obj1 == this.땃().딧())
          this.딧();
        this.딟(obj2);
      }
      else
        obj3(obj0);
    }

    private void 딟([In] 땀 obj0)
    {
      this.딟 = 딚.따.딧;
      Debug.Log((object) "OnGotRefreshTokenFailed");
    }

    private void 딟([In] AccessTokenData obj0)
    {
      this.딟 = 딚.따.딟;
      // ISSUE: reference to a compiler-generated method
      this.딟(new 땉(obj0));
      if (this.딟 != null)
        this.딟(this.땃());
      Debug.Log((object) "OnGotRefreshToken");
    }

    private bool 땄([In] 땀 obj0) => obj0.딟() == 딴.딧 && obj0.딧().딟 == "invalid_token";

    public void 딟([In] Action<AuthStateData> obj0, [In] Action<땀> obj1) => this.딟(new Func<딡>(new 딚.땚()
    {
      딟 = obj0,
      딟 = obj1,
      딟 = this
    }.딟));

    protected abstract 딧.땢 딟();

    private void 딧()
    {
      if (this.딟 != 딚.따.딟)
        return;
      this.딟 = 딚.따.땄;
      딧.땢 땢 = this.딟();
      this.딟.딟(딠.딢(딧.땼.딟(this.딟.딢()).딟("/auth/oauth2/token", 딚.딟(땢, this.딟))).땃(this.딟.딟()).딟<AccessTokenData>(new Action<AccessTokenData>(this.딟)).딟(new Action<땀>(this.딟)).딟());
    }

    [SpecialName]
    public Guid 딢() => this.땃().땓();

    [CompilerGenerated]
    [SpecialName]
    public 땉 땃() => this.딟;

    protected enum 따
    {
      딟,
      땄,
      딧,
    }
  }
}
