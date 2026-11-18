// Decompiled with JetBrains decompiler
// Type: 땄.땶
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땄
{
  internal class 땶 : 땷
  {
    private 땿 딟;

    public 땶([In] 딟.땇 obj0, [In] 땿 obj1, [In] string obj2)
      : base(obj0)
    {
      this.딟 = obj1;
      string str = string.Format("offer_id={0}", (object) obj2);
      this.딟("POST", obj0.땋() + "/store/purchases/transactions", str, 땷.딸.딟);
      ((딧.땋) this).딧();
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.Created)
      {
        TransactionData transactionData = this.땓<TransactionData>();
        ((딧.땋) new 땖(this.딶(), this.딟, transactionData.TransactionId)).딶();
      }
      else
        this.딟.땄(true);
    }

    public override void 땄() => this.딟.땄(true);

    [SpecialName]
    public override 땘 딧() => (땘) this.딟;
  }
}
