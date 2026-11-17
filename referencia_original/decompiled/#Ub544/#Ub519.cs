// Decompiled with JetBrains decompiler
// Type: 땄.딙
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땄
{
  internal class 딙 : 땷
  {
    private 딹 딟;

    public 딙([In] 딟.땇 obj0, [In] 딹 obj1, [In] string obj2)
      : base(obj0)
    {
      this.딟 = obj1;
      this.딟("GET", obj0.땋() + string.Format("/users/{0}/facebook", (object) obj2), 땷.딸.딟);
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.OK)
      {
        this.딟.딟 = this.땓<MinimalFacebookInfo>();
        this.딟.딧(true);
        this.딶().딧(this.딟.딟.FacebookId);
      }
      else if (this.딝().땄() == HttpStatusCode.NotFound)
        this.딟.딧(true);
      this.딟.땄(true);
    }

    [SpecialName]
    public override bool 땃() => this.딝().땄() == HttpStatusCode.NotFound;

    public override void 땄() => this.딟.땄(true);

    [SpecialName]
    public override 땘 딧() => (땘) this.딟;
  }
}
