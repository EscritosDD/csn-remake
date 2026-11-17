// Decompiled with JetBrains decompiler
// Type: 땓.딩
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땓
{
  public class 딩 : 땄.땷
  {
    private new const string 딟 = "/mgr/store/blindboxes/{0}/{1}?blindbox_id={2}&times={3}";
    private const string 땄 = "test";
    private 떋 딟;

    public 딩([In] 딟.땇 obj0, [In] 떋 obj1, [In] string obj2, [In] string obj3, [In] int obj4)
      : base(obj0)
    {
      this.딟 = obj1;
      this.딟("GET", this.딶().땋() + string.Format("/mgr/store/blindboxes/{0}/{1}?blindbox_id={2}&times={3}", (object) obj3, (object) "test", (object) obj3, (object) obj4), (땄.땷.딸) 0);
      this.딟(obj2);
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.OK)
      {
        this.딟.딟 = this.땓<BlindBoxTestResult>();
        this.딟.딧(true);
      }
      this.딟.땄(true);
    }

    public override void 땄() => this.딟.땄(true);

    [SpecialName]
    public override 땄.땘 딧() => (땄.땘) this.딟;
  }
}
