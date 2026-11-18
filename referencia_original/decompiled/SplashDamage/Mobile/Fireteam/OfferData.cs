// Decompiled with JetBrains decompiler
// Type: SplashDamage.Mobile.Fireteam.OfferData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

namespace SplashDamage.Mobile.Fireteam
{
  [딧.딷]
  [Serializable]
  public sealed class OfferData
  {
    [딧.떁(Name = "id")]
    public string Id;
    [딧.떁(Name = "item_id")]
    public string ItemId;
    [딧.떁(Name = "price")]
    public Dictionary<string, int> Price;
    [딧.떁(Name = "price_original")]
    public Dictionary<string, int> PriceOriginal;
    [딧.떁(Name = "product_id")]
    public string ProductId;
    [딧.떁(Name = "vendor")]
    public 딟.딘 Vendor;
    [딧.떁(Name = "price_real")]
    public OfferRealPriceData RealPrice;
  }
}
