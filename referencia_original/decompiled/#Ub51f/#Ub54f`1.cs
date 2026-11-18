// Decompiled with JetBrains decompiler
// Type: 딟.땏`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using 땄;

namespace 딟
{
  public class 땏<딟> : 땷 where 딟 : 땄.땘
  {
    private Func<FileStoreData, 딟, bool> 딟;
    private 딟 딟;

    public 땏([In] 땇 obj0, [In] 딟 obj1, [In] string obj2, [In] Func<FileStoreData, 딟, bool> obj3)
      : base(obj0)
    {
      this.딟 = (Func<FileStoreData, 딟, bool>) obj1;
      this.딟 = obj3;
      this.딟("GET", obj0.땋() + obj2, 땷.딸.딟);
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.OK)
        this.딟.딧(this.딟(this.땓<FileStoreData>(), (딟) this.딟));
      this.딟.땄(true);
    }

    public override void 땄() => this.딟.땄(true);

    [SpecialName]
    public override 땄.땘 딧() => (땄.땘) this.딟;
  }
}
