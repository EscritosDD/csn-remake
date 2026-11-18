// Decompiled with JetBrains decompiler
// Type: 땃.딷
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땃
{
  public class 딷
  {
    public const string 딟 = "featured";
    public const string 땄 = "exchange";
    public const string 딧 = "weapon";
    public const string 딢 = "bundles";
    public const string 땃 = "boosters";
    public const string 딶 = "skins";
    public const string 땓 = "character";
    public const string 땺 = "character02";
    public const string 땥 = "avatar";
    public const string 딝 = "Maps";
    public const string 떎 = "Maps02";
    public const string 떂 = "Maps03";
    public const string 땭 = "Map";
    public const string 딦 = "Challenge";
    public const string 땤 = "currency";
    public const string 땽 = "Keys";
    public const string 땋 = "Sort";

    public 딷([In] 땄.땗 obj0)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0);
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0.딟());
    }

    public 딷([In] 땄.땗 obj0, [In] OfferData[] obj1)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0);
      // ISSUE: reference to a compiler-generated method
      this.딟(obj1);
    }

    public bool 딟() => this.땃().땓() == null || ((IEnumerable<string>) this.땃().땓()).All<string>((Func<string, bool>) (obj0 => GlobalAppData.땽().딶(obj0)));

    public bool 땄() => this.땃().딝() != null && this.땃().딝().All<KeyValuePair<string, int>>((Func<KeyValuePair<string, int>, bool>) (obj0 => GlobalAppData.땽().땃(obj0.Key) >= obj0.Value));

    public bool 딟([In] string obj0) => ((IEnumerable<string>) this.땃().딶()).Any<string>(new Func<string, bool>(new 땃.딷.떁()
    {
      딟 = obj0
    }.딟));

    public bool 딟([In] 딟.떕 obj0) => (this.땃().땥() & obj0) == obj0;

    [SpecialName]
    public string 딧() => this.땃().땄();

    [SpecialName]
    public string 딢() => this.땃().딧();

    [CompilerGenerated]
    [SpecialName]
    public 땄.땗 땃() => this.딟;

    [SpecialName]
    public OfferData 딶() => this.떎() != null ? ((IEnumerable<OfferData>) this.떎()).FirstOrDefault<OfferData>((Func<OfferData, bool>) (obj0 => obj0.Price.ContainsKey(GlobalAppData.딧().GameSettings.CurrencyCoinsId))) : (OfferData) null;

    [SpecialName]
    public OfferData 땓() => this.떎() != null ? ((IEnumerable<OfferData>) this.떎()).FirstOrDefault<OfferData>((Func<OfferData, bool>) (obj0 => obj0.Price.ContainsKey(GlobalAppData.딧().GameSettings.CurrencyWarBucksId))) : (OfferData) null;

    [SpecialName]
    public OfferData 땺() => this.떎() != null ? ((IEnumerable<OfferData>) this.떎()).FirstOrDefault<OfferData>((Func<OfferData, bool>) (obj0 => obj0.Price.ContainsKey(GlobalAppData.딧().GameSettings.CurrencyKeysId))) : (OfferData) null;

    [SpecialName]
    public OfferData 땥() => this.떎() != null ? ((IEnumerable<OfferData>) this.떎()).FirstOrDefault<OfferData>((Func<OfferData, bool>) (obj0 => obj0.Vendor == GlobalAppData.땋().딶())) : (OfferData) null;

    [SpecialName]
    public OfferData 딝() => this.떎() != null ? ((IEnumerable<OfferData>) this.떎()).FirstOrDefault<OfferData>((Func<OfferData, bool>) (obj0 => obj0.Price.ContainsKey(GlobalAppData.딧().GameSettings.CurrencyQuatlooId))) : (OfferData) null;

    [CompilerGenerated]
    [SpecialName]
    public OfferData[] 떎() => this.딟;

    [SpecialName]
    public bool 떂()
    {
      if (!this.땢())
        return true;
      return this.땃().땺() == 딟.딪.땄 ? !this.땄() : !GlobalAppData.땽().딶(this.딧());
    }

    [SpecialName]
    public bool 땭() => this.딟("featured");

    [SpecialName]
    public bool 딦() => this.딟("exchange");

    [SpecialName]
    public bool 땤() => this.딟("weapon");

    [SpecialName]
    public bool 땽() => this.딟("bundles");

    [SpecialName]
    public bool 땋() => this.딟("boosters");

    [SpecialName]
    public bool 땲() => this.딟("skins");

    [SpecialName]
    public bool 떏() => this.딟("character") || this.딟("character02");

    [SpecialName]
    public bool 땼() => this.딟("avatar");

    [SpecialName]
    public bool 땢() => this.딟(딟.떕.딟);

    [SpecialName]
    public bool 딷() => this.딟("Maps") || this.딟("Maps02") || this.딟("Maps03");

    [SpecialName]
    public bool 떁() => this.딟("Map");

    [SpecialName]
    public bool 땟() => this.딟("Challenge");

    [SpecialName]
    public bool 땂() => this.딟("currency");

    [SpecialName]
    public bool 딱() => this.딟("Keys");

    [SpecialName]
    public int 때() => (this.땃().땃() as 땓.딞).땓();

    private static bool 딟([In] OfferData obj0)
    {
      if (obj0 == null || obj0.PriceOriginal == null)
        return false;
      foreach (KeyValuePair<string, int> keyValuePair in obj0.Price)
      {
        int num;
        if (obj0.PriceOriginal.TryGetValue(keyValuePair.Key, out num) && num != keyValuePair.Value)
          return true;
      }
      return false;
    }

    [SpecialName]
    public bool 땩() => 땃.딷.딟(this.땓()) || 땃.딷.딟(this.딶());

    [SpecialName]
    public int 땠()
    {
      if (this.떏())
        return 0;
      if (this.땤())
        return 1;
      if (this.땲())
        return 2;
      return this.땋() ? 3 : 100;
    }
  }
}
