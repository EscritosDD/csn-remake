// Decompiled with JetBrains decompiler
// Type: 딟.땗
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딟
{
  internal class 땗 : 땄.땷
  {
    private 딜 딟;

    public 땗([In] 땇 obj0, [In] 딜 obj1, [In] string obj2, [In] byte[] obj3, [In] string obj4)
      : base(obj0)
    {
      this.딟 = obj1;
      string str = 딧.땾.땄((object) new FileStoreData()
      {
        Data = Convert.ToBase64String(obj3)
      });
      this.딟("PUT", obj0.땋() + string.Format("/files/{0}", (object) obj2), str, (땄.땷.딸) 0);
      this.딟(obj4);
      ((딧.땋) this).땃();
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.Created)
        this.딟.딧(true);
      this.딟.땄(true);
    }

    public override void 땄() => this.딟.땄(true);

    [SpecialName]
    public override 땄.땘 딧() => (땄.땘) this.딟;
  }
}
