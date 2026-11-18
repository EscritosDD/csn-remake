// Decompiled with JetBrains decompiler
// Type: 땃.땼
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 땃
{
  public static class 땼
  {
    public static int 딟([In] this OfferData obj0) => 땼.딟(obj0.PriceOriginal, GlobalAppData.딧().GameSettings.CurrencyWarBucksId);

    public static int 땄([In] this OfferData obj0) => 땼.딟(obj0.PriceOriginal, GlobalAppData.딧().GameSettings.CurrencyCoinsId);

    public static int 딧([In] this OfferData obj0) => 땼.딟(obj0.Price, GlobalAppData.딧().GameSettings.CurrencyWarBucksId);

    public static int 딢([In] this OfferData obj0) => 땼.딟(obj0.Price, GlobalAppData.딧().GameSettings.CurrencyCoinsId);

    public static bool 땃([In] this OfferData obj0) => obj0.Price.ContainsKey(GlobalAppData.딧().GameSettings.CurrencyWarBucksId);

    public static bool 딶([In] this OfferData obj0) => obj0.Price.ContainsKey(GlobalAppData.딧().GameSettings.CurrencyCoinsId);

    public static bool 땓([In] this OfferData obj0) => obj0.Price.ContainsKey(GlobalAppData.딧().GameSettings.CurrencyKeysId);

    private static int 딟([In] Dictionary<string, int> obj0, [In] string obj1)
    {
      int num;
      return !obj0.TryGetValue(obj1, out num) ? 0 : num;
    }
  }
}
