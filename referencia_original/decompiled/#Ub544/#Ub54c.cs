// Decompiled with JetBrains decompiler
// Type: 땄.때
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땄
{
  internal class 때 : 땷
  {
    private 딱 딟;

    public 때([In] 딟.땇 obj0, [In] string obj1, [In] 딱 obj2)
      : base(obj0)
    {
      this.딟 = obj2;
      this.딟("GET", obj0.땋() + string.Format("/users/{0}/notifications?per_page=200", (object) obj1), 땷.딸.딟);
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.OK)
      {
        List<딟.떊> list = ((IEnumerable<NotificationData>) this.땓<NotificationsData>().Items).Select<NotificationData, 딟.떊>((Func<NotificationData, 딟.떊>) (obj0 => new 딟.떊(obj0))).ToList<딟.떊>();
        List<딟.떊> 떊List = new List<딟.떊>();
        foreach (딟.떊 떊 in list)
        {
          if (떊.떎() != null && 떊.떎().딟() && 떊.딟())
            this.딶().땼(떊.땄());
          else
            떊List.Add(떊);
        }
        this.딟.딟 = 떊List.ToArray();
        this.딟.딧(true);
      }
      this.딟.땄(true);
    }

    public override void 땄() => this.딟.땄(true);

    [SpecialName]
    public override 땘 딧() => (땘) this.딟;
  }
}
