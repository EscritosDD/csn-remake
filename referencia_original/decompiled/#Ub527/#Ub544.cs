// Decompiled with JetBrains decompiler
// Type: 딧.땄
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딧
{
  internal class 땄 : 땄.땷
  {
    private Action<딧.딟> 딟;
    private 딧.딟 딟;

    public 땄([In] 딟.땇 obj0, [In] 딧.딟 obj1, [In] Action<딧.딟> obj2)
      : base(obj0)
    {
      this.딟 = obj1;
      this.딟 = obj2;
      this.딟("GET", obj0.땋() + "/users/me/xboxlive", 땄.땷.딸.딟);
    }

    [SpecialName]
    public override 땄.땘 딧() => (땄.땘) this.딟;

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.OK)
      {
        this.딟.딟(this.땓<XboxXuidLink>());
        this.딟.딧(true);
      }
      this.딟.땄(true);
      this.딟(this.딟);
    }

    public override void 땄()
    {
      this.딟.땄(true);
      this.딟(this.딟);
    }
  }
}
