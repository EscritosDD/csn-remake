// Decompiled with JetBrains decompiler
// Type: 땄.땨
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땄
{
  internal class 땨 : 땷
  {
    private 따 딟;

    public 땨([In] 딟.땇 obj0, [In] 따 obj1, [In] string obj2, [In] string obj3, [In] bool obj4)
      : base(obj0)
    {
      this.딟 = obj1;
      string str = 딧.땾.땄((object) new SessionJoinData()
      {
        SlotType = (!obj4 ? 딟.땎.딟 : 딟.땎.땄)
      });
      this.딟("PUT", obj0.땋() + string.Format("/sessions/{0}/{1}", (object) obj2, (object) obj3), str, 땷.딸.딟);
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
    public override 땘 딧() => (땘) this.딟;
  }
}
