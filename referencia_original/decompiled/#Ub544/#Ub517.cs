// Decompiled with JetBrains decompiler
// Type: 땄.딗
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땄
{
  internal class 딗 : 땷
  {
    private 땴 딟;

    public 딗([In] 딟.땇 obj0, [In] string obj1, [In] string obj2, [In] 땴 obj3)
      : base(obj0)
    {
      this.딟 = obj3;
      MarkNotificationReadData notificationReadData = new MarkNotificationReadData()
      {
        UpdateData = new MarkNotificationReadUpdateData()
      };
      notificationReadData.UpdateData.Read = true;
      string str = 딧.땾.땄((object) notificationReadData);
      this.딟("POST", obj0.땋() + string.Format("/users/{0}/notifications/{1}", (object) obj1, (object) obj2), str, 땷.딸.딟);
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
