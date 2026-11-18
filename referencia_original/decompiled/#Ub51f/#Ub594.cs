// Decompiled with JetBrains decompiler
// Type: 딟.떔
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireline;
using SplashDamage.Mobile.Fireline.Data;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 딟
{
  public class 떔 : 딚
  {
    public new const string 딟 = "/o";
    public new const string 땄 = "/o/{0}";

    private 떔([In] ClientDescriptor obj0, [In] 딯 obj1, [In] 땉 obj2)
      : base(obj0, obj1, obj2)
    {
    }

    public static void 딟([In] ClientDescriptor obj0, [In] 딯 obj1, [In] Action<떔> obj2, [In] Action<땀> obj3)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      떔.딳 딳 = new 떔.딳();
      // ISSUE: reference to a compiler-generated field
      딳.딟 = obj2;
      // ISSUE: reference to a compiler-generated field
      딳.딟 = obj0;
      // ISSUE: reference to a compiler-generated field
      딳.딟 = obj1;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      딳.딟.딟(딠.딢(딧.땼.딟(딳.딟.딢()).딟("/auth/oauth2/token", 딚.딟(떔.땄(), 딳.딟))).땃(딳.딟.딟()).딟<AccessTokenData>(new Action<AccessTokenData>(딳.딟)).딟(obj3).딟());
    }

    private static 딧.땢 땄() => 딧.땢.딟().딟("grant_type", "client_credentials");

    protected override 딧.땢 딟() => 떔.땄();

    public void 딟([In] IEnumerable<ObjectTypeSpec> obj0, [In] Action<딨> obj1, [In] Action<땀> obj2) => this.딟(new Func<딡>(new 떔.땝()
    {
      딟 = obj1,
      딟 = obj2,
      딟 = this,
      딟 = new Dictionary<string, object>()
      {
        {
          "object_types",
          (object) obj0
        }
      }
    }.딟));

    public void 딟([In] string obj0, [In] Action<딨> obj1, [In] Action<땀> obj2) => this.딟(new Func<딡>(new 떔.땹()
    {
      딟 = obj1,
      딟 = obj2,
      딟 = this,
      딟 = string.Format("/o/{0}", (object) obj0)
    }.딟));
  }
}
