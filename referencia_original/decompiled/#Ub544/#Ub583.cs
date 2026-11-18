// Decompiled with JetBrains decompiler
// Type: 땄.떃
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땄
{
  internal class 떃 : 땷
  {
    private 땦 딟;
    private 땅 딟;
    private new string 딟;

    public 떃([In] 딟.땇 obj0, [In] string obj1, [In] 땅 obj2, [In] 땦 obj3)
      : base(obj0)
    {
      this.딟 = obj3;
      this.딟 = obj2;
      this.딟 = obj1;
      string str = 딧.땾.땄((object) new PublicProfileWriteData()
      {
        Data = obj2.딟()
      });
      this.딟("PUT", obj0.땋() + string.Format("/users/{0}/profile/public", (object) obj1), str, 땷.딸.딟);
      ((딧.땋) this).땃();
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.NoContent)
      {
        this.딟.딧(true);
        this.딶().딟(this.딟, this.딟);
      }
      this.딟.땄(true);
    }

    public override void 땄() => this.딟.땄(true);

    [SpecialName]
    public override 땘 딧() => (땘) this.딟;
  }
}
