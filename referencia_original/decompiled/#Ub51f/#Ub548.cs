// Decompiled with JetBrains decompiler
// Type: 딟.땈
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireline;
using SplashDamage.Mobile.Fireline.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using 딧;

namespace 딟
{
  public class 땈 : 딚
  {
    protected new const string 딟 = "/o/{0}/{1}";
    protected new const string 땄 = "/o/{0}";
    protected new const string 딧 = "/o/{0}/{1}";

    protected 땈([In] ClientDescriptor obj0, [In] 딯 obj1, [In] 땉 obj2)
      : base(obj0, obj1, obj2)
    {
    }

    public static void 딟<딟>(
      [In] ClientDescriptor obj0,
      [In] 딯 obj1,
      [In] 땉 obj2,
      [In] Func<ClientDescriptor, 딯, 땉, 딟> obj3,
      [In] Action<딟> obj4,
      [In] Action<땀> obj5)
    {
      if (obj2 == null || !obj2.땄())
        obj5(new 땀(딴.딢));
      else
        obj4(obj3(obj0, obj1, obj2));
    }

    public static void 딟<딟>(
      [In] ClientDescriptor obj0,
      [In] 딯 obj1,
      [In] string obj2,
      [In] string obj3,
      [In] Func<ClientDescriptor, 딯, 땉, 딟> obj4,
      [In] Action<딟> obj5,
      [In] Action<땀> obj6)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      땈.땞<딟> 땞 = new 땈.땞<딟>() { 딟 = obj5 };
      // ISSUE: reference to a compiler-generated field
      땞.딟 = (Action<딟>) obj4;
      // ISSUE: reference to a compiler-generated field
      땞.딟 = (Action<딟>) obj0;
      // ISSUE: reference to a compiler-generated field
      땞.딟 = (Action<딟>) obj1;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      ((딯) 땞.딟).딟(딠.딢(딧.땼.딟(((ClientDescriptor) 땞.딟).딢()).딟("/auth/oauth2/token", 딚.딟(딧.땢.딟().딟("username", obj2).딟("password", obj3).딟("grant_type", "password"), (ClientDescriptor) 땞.딟))).땃(((ClientDescriptor) 땞.딟).딟()).딟<AccessTokenData>(new Action<AccessTokenData>(땞.딟)).딟(obj6).딟());
    }

    public void 딟<딟>([In] string obj0, [In] Guid obj1, [In] 딟 obj2, [In] Action<딟> obj3, [In] Action<땀> obj4)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      땈.땜<딟> 땜 = new 땈.땜<딟>() { 딟 = (string) obj3 };
      // ISSUE: reference to a compiler-generated field
      땜.딟 = (string) obj4;
      // ISSUE: reference to a compiler-generated field
      땜.딟 = (string) this;
      // ISSUE: reference to a compiler-generated field
      땜.딟 = string.Format("/o/{0}/{1}", (object) obj0, (object) obj1);
      // ISSUE: reference to a compiler-generated field
      땜.딟 = (string) new Dictionary<string, object>()
      {
        {
          "fields",
          (object) obj2
        }
      };
      // ISSUE: reference to a compiler-generated method
      this.딟(new Func<딡>(땜.딟));
    }

    public void 딟<딟>([In] string obj0, [In] Guid obj1, [In] Action<딟> obj2, [In] Action<땀> obj3)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      땈.땪<딟> 땪 = new 땈.땪<딟>() { 딟 = (string) obj2 };
      // ISSUE: reference to a compiler-generated field
      땪.딟 = (string) obj3;
      // ISSUE: reference to a compiler-generated field
      땪.딟 = (string) this;
      // ISSUE: reference to a compiler-generated field
      땪.딟 = string.Format("/o/{0}/{1}", (object) obj0, (object) obj1);
      // ISSUE: reference to a compiler-generated method
      this.딟(new Func<딡>(땪.딟));
    }

    public void 딟<딟>([In] string obj0, [In] 떇 obj1, [In] Action<딟[]> obj2, [In] Action<땀> obj3) => this.딟<딟>(obj1, obj2, obj3, string.Format("/o/{0}", (object) obj0));

    public void 딟<딟>([In] string obj0, [In] Action<딟[]> obj1, [In] Action<땀> obj2) => this.딟<딟>(new 떇(), obj1, obj2, string.Format("/o/{0}", (object) obj0));

    private void 딟<딟>([In] 떇 obj0, [In] Action<딟[]> obj1, [In] Action<땀> obj2, [In] string obj3)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      땈.땕<딟> 땕 = new 땈.땕<딟>() { 딟 = obj3 };
      // ISSUE: reference to a compiler-generated field
      땕.딟 = (string) obj1;
      // ISSUE: reference to a compiler-generated field
      땕.딟 = (string) obj2;
      // ISSUE: reference to a compiler-generated field
      땕.딟 = (string) this;
      // ISSUE: reference to a compiler-generated field
      땕.딟 = (string) 딧.땢.딟();
      if (!string.IsNullOrEmpty(obj0.땄()))
      {
        // ISSUE: reference to a compiler-generated field
        땕.딟.딟("where", obj0.땄());
      }
      if (obj0.딟() != null)
      {
        // ISSUE: reference to a compiler-generated field
        땕.딟.딟("args:", 딧.땾.땄((object) obj0.딟()));
      }
      if (obj0.딧() != null)
      {
        // ISSUE: reference to a compiler-generated field
        땕.딟.딟("order_by:", 딧.땾.땄((object) obj0.딧()));
      }
      if (obj0.딢().HasValue)
      {
        // ISSUE: reference to a compiler-generated field
        땕.딟.딟("page", obj0.딢().Value.ToString());
      }
      if (obj0.땃().HasValue)
      {
        // ISSUE: reference to a compiler-generated field
        땕.딟.딟("per_page", obj0.땃().Value.ToString());
      }
      // ISSUE: reference to a compiler-generated method
      this.딟(new Func<딡>(땕.딟));
    }

    public void 딟([In] IEnumerable<떅> obj0_1, [In] Action<string[]> obj1)
    {
      string[] array = obj0_1.Select<떅, string>((Func<떅, string>) (obj0_2 => obj0_2.딟())).ToArray<string>();
      obj1(array);
    }

    protected override 딧.땢 딟() => 딧.땢.딟().딟("grant_type", "refresh_token").딟("refresh_token", this.땃().땃());
  }
}
