// Decompiled with JetBrains decompiler
// Type: 딟.땸
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using 땄;

namespace 딟
{
  internal class 땸 : 땷
  {
    private 딬 딟;

    public 땸([In] 땇 obj0, [In] 딬 obj1, [In] string obj2)
      : base(obj0)
    {
      this.딟 = obj1;
      this.딟("GET", obj0.땋() + string.Format("/users/{0}/inventory", (object) obj2), 땷.딸.딟);
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.OK)
      {
        InventoryData inventoryData = this.땓<InventoryData>();
        this.딶().딦().딟(inventoryData);
        this.딟.딧(true);
      }
      this.딟.땄(true);
    }

    public override void 땄() => this.딟.땄(true);

    [SpecialName]
    public override 땄.땘 딧() => (땄.땘) this.딟;
  }
}
