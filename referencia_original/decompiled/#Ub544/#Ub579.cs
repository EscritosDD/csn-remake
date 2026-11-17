// Decompiled with JetBrains decompiler
// Type: 땄.땹
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땄
{
  internal class 땹 : 땷
  {
    private 떔 딟;

    public 땹([In] 딟.땇 obj0, [In] 떔 obj1, [In] string obj2, [In] string obj3, [In] int obj4)
      : base(obj0)
    {
      this.딟 = obj1;
      string str = 딧.땾.땄((object) new ScoreBoardOps()
      {
        ops = new Dictionary<string, List<object>>()
        {
          {
            obj3,
            new List<object>() { (object) "max", (object) obj4 }
          }
        }
      });
      this.딟("POST", obj0.땋() + string.Format("/users/{0}/scores/{1}", (object) obj0.땓(), (object) obj2), str, 땷.딸.딟);
      this.딧("PATCH");
      ((딧.땋) this).땃();
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.NoContent)
        this.딟.딧(true);
      this.딟.땄(true);
    }

    public override void 땄() => this.딟.땄(true);

    [SpecialName]
    public override 땘 딧() => (땘) this.딟;
  }
}
