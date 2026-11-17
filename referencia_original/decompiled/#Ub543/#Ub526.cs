// Decompiled with JetBrains decompiler
// Type: 땃.딦
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땃
{
  public class 딦
  {
    private 땢 딟;
    private 땄.땿 딟;
    private OfferData 딟;
    private 딷 딟;
    private 딦.땤 딟;
    private Action<딟.땑, ErrorMessagehandler.땶> 딟;
    private Action<PurchaseResult> 딟;
    private Action<딟.땑, ErrorMessagehandler.땶> 땄;
    private Action<딷> 딟;

    public 딦([In] string obj0)
    {
      this.딟 = 딦.땤.땄;
      this.딟 = new 땢(obj0);
    }

    public 딦([In] 딷 obj0) => this.딟(obj0);

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 딟([In] Action<딟.땑, ErrorMessagehandler.땶> obj0) => this.딟 += obj0;

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 땄([In] Action<딟.땑, ErrorMessagehandler.땶> obj0) => this.딟 -= obj0;

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 딟([In] Action<PurchaseResult> obj0) => this.딟 += obj0;

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 땄([In] Action<PurchaseResult> obj0) => this.딟 -= obj0;

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 딧([In] Action<딟.땑, ErrorMessagehandler.땶> obj0) => this.땄 += obj0;

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 딢([In] Action<딟.땑, ErrorMessagehandler.땶> obj0) => this.땄 -= obj0;

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 딟([In] Action<딷> obj0) => this.딟 += obj0;

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 땄([In] Action<딷> obj0) => this.딟 -= obj0;

    private void 딟([In] 딷 obj0)
    {
      this.딟 = 딦.땤.딧;
      this.딟 = obj0;
      this.딟();
    }

    private void 딟()
    {
      string str = (string) null;
      if (this.딟.땤())
        str = "StoreWeaponBuyConf";
      else if (this.딟.떏())
        str = "StoreCharacterBuyConf";
      else if (this.딟.땲())
        str = "StoreOutfitBuyConf";
      else if (this.딟.땋())
        str = "StoreBoostBuyConf";
      else if (this.딟.땽())
        str = "StoreBundleBuyConf";
      else if (this.딟.딦())
        str = "StoreExchangeBuyConf";
      else if (this.딟.땂())
        str = "StoreRadBuxBuyConf";
      if (str == null)
        return;
      딟.딦.딟(str, new Dictionary<string, string>()
      {
        {
          "productid",
          this.딟.땃().땄()
        }
      });
    }

    public void 땄()
    {
      switch (this.딟)
      {
        case 딦.땤.땄:
          this.딢();
          break;
        case 딦.땤.딢:
          this.땃();
          break;
      }
    }

    private void 딧()
    {
      Dictionary<string, string> dictionary = new Dictionary<string, string>();
      if (Object.op_Inequality((Object) GlobalAppData.딢(), (Object) null))
      {
        int num = GlobalAppData.땽().때();
        dictionary.Add("level", num.ToString());
      }
      dictionary.Add("productid", this.딟.땃().땄());
      string str;
      if (this.딟.딶())
      {
        str = "PurchaseItemCoins";
        int num1 = GlobalAppData.땽().딟(딢.땹.땓);
        if (num1 < 4)
        {
          int num2 = num1 + 1;
          GlobalAppData.땽().딟(딢.땹.땓, num2);
          딟.딦.딟("UserPurchaseCoins" + num2.ToString(), dictionary);
        }
      }
      else if (this.딟.땃())
      {
        str = "PurchaseItemBux";
        int num3 = GlobalAppData.땽().딟(딢.땹.땺);
        if (num3 < 4)
        {
          int num4 = num3 + 1;
          GlobalAppData.땽().딟(딢.땹.땺, num4);
          딟.딦.딟("UserPurchaseBux" + num4.ToString(), dictionary);
        }
      }
      else
      {
        if (!this.딟.딶())
          return;
        str = "PurchaseItemKeys";
      }
      딟.딦.딟(str, dictionary);
      if (!this.딟.딦())
        return;
      딟.딦.딟("PurchaseCoins-" + this.딟.땃().땄());
    }

    private void 딢()
    {
      if (!this.딟.딟())
        return;
      땢 딟 = this.딟;
      this.딟 = (땢) null;
      if (딟.땄())
      {
        this.딟(딟.땃());
        if (this.딟 == null)
          return;
        this.딟(this.딟);
      }
      else
      {
        this.딟 = 딦.땤.딧;
        if (this.땄 == null)
          return;
        this.땄(딟.딢(), !딟.딧() ? ErrorMessagehandler.땶.딟 : ErrorMessagehandler.땶.땽);
      }
    }

    private void 땃()
    {
      if (!this.딟.땄())
        return;
      땄.땿 딟 = this.딟;
      this.딟 = (땄.땿) null;
      if (딟.딧())
      {
        this.딧();
        GlobalAppData.떏().땟();
        if (Object.op_Inequality((Object) FrontendHub.딟, (Object) null))
        {
          if (this.딟.땤())
            FrontendHub.딟.BarracksScreen.ClearWeaponFallback();
          else if (this.딟.땲())
            FrontendHub.딟.BarracksScreen.ClearOutfitFallback();
        }
        if (GlobalAppData.땽().딟(딢.땹.땃) == 0)
        {
          GlobalAppData.땽().딟(딢.땹.땃, 1);
          딟.딦.딟("Store_PurchasedFirstItem");
        }
        this.딟 = 딦.땤.딧;
        if (this.딟 == null)
          return;
        this.딟(딟.딟);
      }
      else
      {
        this.딟 = 딦.땤.딧;
        if (this.딟 == null)
          return;
        this.딟(((땄.땘) 딟).딟, !딟.딟() ? ErrorMessagehandler.땶.딟 : ErrorMessagehandler.땶.땽);
      }
    }

    public void 딟([In] OfferData obj0)
    {
      if (obj0 == null || this.딟 != 딦.땤.딧)
        return;
      this.딟 = obj0;
      if (obj0.Vendor == GlobalAppData.땋().딶())
      {
        this.딟 = 딦.땤.땃;
        GlobalAppData.땋().딟(obj0, new Action<PurchaseResult>(this.딟), new Action<딟.땑, ErrorMessagehandler.땶>(this.딟));
      }
      else
      {
        this.딟 = 딦.땤.딢;
        this.딟 = GlobalAppData.떏().때(obj0.Id);
      }
    }

    private void 딟([In] 딟.땑 obj0, [In] ErrorMessagehandler.땶 obj1)
    {
      this.딟 = 딦.땤.딧;
      this.딟(obj0, obj1);
    }

    private void 딟([In] PurchaseResult obj0)
    {
      this.딟 = 딦.땤.딧;
      this.딟(obj0);
    }

    [SpecialName]
    public bool 딶() => this.딟 == 딦.땤.딢 || this.딟 == 딦.땤.땃;

    private enum 땤
    {
      딟,
      땄,
      딧,
      딢,
      땃,
    }
  }
}
