// Decompiled with JetBrains decompiler
// Type: 딟.땬
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딟
{
  public class 땬
  {
    private 땇 딟;

    public 땬([In] 땇 obj0)
    {
      this.딟 = obj0;
      // ISSUE: reference to a compiler-generated method
      this.딟(new Dictionary<string, int>());
    }

    public void 딟([In] InventoryData obj0)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0.Inventory);
      this.딟.딟(this);
    }

    public int 딟([In] string obj0)
    {
      int num;
      return !this.땄().TryGetValue(obj0, out num) ? 0 : num;
    }

    public bool 딟([In] OfferData obj0_1) => obj0_1.Price.All<KeyValuePair<string, int>>((Func<KeyValuePair<string, int>, bool>) (obj0_2 => this.딟(obj0_2.Key) >= obj0_2.Value));

    public void 딟()
    {
      this.땄().Clear();
      this.딟.딟(this);
    }

    [CompilerGenerated]
    [SpecialName]
    public Dictionary<string, int> 땄() => this.딟;
  }
}
