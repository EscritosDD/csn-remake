// Decompiled with JetBrains decompiler
// Type: 땄.땍
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땄
{
  public class 땍 : 땷
  {
    private Action<땊> 딟;
    private 땊 딟;

    public 땍([In] 딟.땇 obj0, [In] string obj1, [In] 떀 obj2, [In] 땊 obj3, [In] Action<땊> obj4)
      : base(obj0)
    {
      this.딟 = obj3;
      this.딟 = obj4;
      string str1;
      string str2;
      switch (obj2)
      {
        case 떀.땄:
          str1 = "?extended=true&email_address=" + Uri.EscapeDataString(obj1);
          str2 = "/users";
          break;
        case 떀.딧:
          str1 = "?extended=true&facebook_id=" + Uri.EscapeDataString(obj1);
          str2 = "/users/facebook";
          break;
        case 떀.딢:
          str1 = "?xuid=" + Uri.EscapeDataString(obj1);
          str2 = "/users/xboxlive";
          break;
        case 떀.땃:
          str1 = "?gamertag=" + Uri.EscapeDataString(obj1);
          str2 = "/users/xboxlive";
          break;
        default:
          str1 = "?extended=true&username=" + Uri.EscapeDataString(obj1);
          str2 = "/users";
          break;
      }
      this.딟("GET", obj0.땋() + str2 + str1, 땷.딸.딟);
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.OK)
      {
        this.딟.딟 = new 딽(this.땓<UserData>(), new Func<Dictionary<string, object>, 땅>(base.딶().딟));
        this.딟.딧(true);
        base.딶().딟(this.딟.딟);
      }
      this.딟.땄(true);
      this.딶();
    }

    public override void 땄()
    {
      this.딟.땄(true);
      this.딶();
    }

    private new void 딶()
    {
      if (this.딟 == null)
        return;
      this.딟(this.딟);
    }

    [SpecialName]
    public override 땘 딧() => (땘) this.딟;
  }
}
