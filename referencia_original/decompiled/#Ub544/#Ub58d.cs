// Decompiled with JetBrains decompiler
// Type: 땄.떍
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
  internal class 떍 : 땷
  {
    private 딮 딟;

    public 떍(
      [In] 딟.땇 obj0,
      [In] 딮 obj1,
      [In] string obj2,
      [In] Dictionary<string, int> obj3,
      [In] object obj4,
      [In] 딟.땎 obj5,
      [In] int obj6,
      [In] int obj7,
      [In] string obj8,
      [In] string[] obj9)
      : base(obj0)
    {
      this.딟 = obj1;
      string str = 딧.땾.땄((object) new SessionCreationWriteData()
      {
        Attributes = obj4,
        JoinSlotType = obj5,
        PublicSlots = obj6,
        PrivateSlots = obj7,
        Nonce = obj8,
        TurnData = obj2,
        TurnInventory = obj3,
        Invitees = obj9
      });
      this.딟("POST", obj0.땋() + "/sessions/turnbased", str, 땷.딸.딟);
      ((딧.땋) this).땃();
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.Created)
        this.딟.딧(true);
      else if (this.딝().땄() == HttpStatusCode.Forbidden)
      {
        switch (((땘) this.딟).딟)
        {
          case 딟.땑.딝:
            this.딟.딟 = true;
            break;
          case 딟.땑.떎:
            this.딟.땄 = true;
            break;
          case 딟.땑.땋:
            this.딟.딧 = true;
            break;
        }
      }
      this.딟.땄(true);
    }

    public override void 땄() => this.딟.땄(true);

    [SpecialName]
    public override 땘 딧() => (땘) this.딟;
  }
}
