// Decompiled with JetBrains decompiler
// Type: 땄.떕
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
  internal class 떕 : 땷
  {
    private 딪 딟;
    private Action<딪> 딟;

    public 떕([In] 딟.땇 obj0, [In] 딪 obj1, [In] 딟.딘 obj2, [In] string obj3, [In] Action<딪> obj4)
      : base(obj0)
    {
      this.딟 = obj1;
      ((딧.땋) this).딟 = new TimeSpan(0, 0, 20);
      this.딟 = obj4;
      this.딟("GET", obj0.땋() + "/store/catalog" + string.Format("?vendor={0}&per_page=400", (object) (int) obj2), 땷.딸.딟);
      if (string.IsNullOrEmpty(obj3))
        return;
      this.땄("x-fireteam-country", obj3);
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.OK)
      {
        CatalogPagination catalogPagination = this.땓<CatalogPagination>();
        this.딟.딟 = new 땗[catalogPagination.Items.Length];
        for (int index = 0; index < catalogPagination.Items.Length; ++index)
          this.딟.딟[index] = new 땗(catalogPagination.Items[index], new Func<Dictionary<string, object>, 딻>(base.딶().딧), new Func<string, 딜>(base.딶().딟));
        this.딟.딧(true);
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
