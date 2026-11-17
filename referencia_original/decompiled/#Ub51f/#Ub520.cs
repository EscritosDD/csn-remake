// Decompiled with JetBrains decompiler
// Type: 딟.딠
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딟
{
  public struct 딠
  {
    public const string 딟 = "GET";
    public const string 땄 = "PUT";
    public const string 딧 = "POST";
    public const string 딢 = "DELETE";
    private 딡 딟;

    private 딠([In] 딡 obj0) => this.딟 = obj0;

    public static 딠 딟([In] string obj0) => 딠.딟("GET", obj0, (byte[]) null);

    public static 딠 땄([In] string obj0) => 딠.딟("DELETE", obj0, (byte[]) null);

    public static 딠 딟([In] string obj0, [In] byte[] obj1) => 딠.딟("PUT", obj0, obj1);

    public static 딠 딧([In] string obj0) => 딠.딟("PUT", obj0, (byte[]) null);

    public static 딠 땄([In] string obj0, [In] byte[] obj1) => 딠.딟("POST", obj0, obj1);

    public static 딠 딟([In] string obj0, [In] 딧.땢 obj1) => 딠.딟(딠.딟("POST", obj0, obj1.딧()), obj1);

    private static 딠 딟([In] 딠 obj0, [In] 딧.땢 obj1) => obj0.딟("Content-Type", "application/x-www-form-urlencoded;charset=UTF-8");

    public static 딠 딢([In] string obj0) => 딠.땄(obj0, (byte[]) null);

    public static 딠 딟([In] string obj0, [In] string obj1, [In] byte[] obj2) => new 딠(new 딡(obj0, obj1, obj2));

    public 딠 땃([In] string obj0) => this.딟("X-Domain", obj0);

    public 딠 딟([In] string obj0, [In] string obj1)
    {
      this.딟.딟(obj0, obj1);
      return this;
    }

    public static 딟 딟<딟>([In] 딨 obj0)
    {
      Debug.Log((object) ("Deserialize " + obj0.땄() + " -> " + typeof (딟).Name));
      return 딧.땾.딟<딟>(obj0.땄());
    }

    public 딠 딟([In] Action<딨> obj0)
    {
      this.딟.딟(obj0);
      return this;
    }

    public 딠 딟<딟>([In] Action<딟> obj0)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      this.딟.딟(new Action<딨>(new 딠.딿<딟>()
      {
        딟 = obj0
      }.딟));
      return this;
    }

    public 딠 딟([In] Action<땀> obj0)
    {
      this.딟.딟(obj0);
      return this;
    }

    public 딠 딶([In] string obj0) => this.딟("Authorization", string.Format("Bearer {0}", (object) obj0));

    public 딡 딟() => this.딟;
  }
}
