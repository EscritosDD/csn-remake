// Decompiled with JetBrains decompiler
// Type: 딢.딫
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딢
{
  public static class 딫
  {
    public static 떅 딟([In] 딟.땇 obj0) => (떅) new 딫.땏(obj0);

    private class 땙 : 떅
    {
      private Action<딟.땑, ErrorMessagehandler.땶> 딟;
      private 딫.땙.State 딟;
      private List<땃.딷> 딟;
      private 딟.땇 딟;

      public 땙([In] 딟.땇 obj0) => this.딟 = obj0;

      public void 딟()
      {
        if (this.딟 != 딫.땙.State.Idle && this.딟 != 딫.땙.State.Ready || !this.딟.땥())
          return;
        this.딟 = 딫.땙.State.RequestingCatalog;
        this.딟.딟(this.딶(), new Action<땄.딪>(this.딟));
      }

      [SpecialName]
      public 딟.딘 딶() => 딟.딘.땄;

      public string 딟([In] OfferData obj0) => (string) null;

      private void 딟([In] 땄.딪 obj0_1)
      {
        if (!obj0_1.딧())
        {
          this.딟 = 딫.땙.State.Idle;
        }
        else
        {
          this.딟 = 딫.땙.State.Ready;
          this.딟 = ((IEnumerable<땄.땗>) obj0_1.딟).OrderBy<땄.땗, int>((Func<땄.땗, int>) (obj0_6 => (obj0_6.땃() as 땓.딞).땓())).Select<땄.땗, 땃.딷>((Func<땄.땗, 땃.딷>) (obj0_7 => new 땃.딷(obj0_7))).ToList<땃.딷>();
        }
      }

      public void 딟(
        [In] OfferData obj0,
        [In] Action<PurchaseResult> obj1,
        [In] Action<딟.땑, ErrorMessagehandler.땶> obj2)
      {
        obj2(딟.땑.딟, ErrorMessagehandler.땶.딟);
      }

      [SpecialName]
      public bool 땄() => this.딟 == 딫.땙.State.Ready;

      [SpecialName]
      public bool 딧() => this.딟 == 딫.땙.State.RequestingCatalog;

      [SpecialName]
      public bool 딢() => true;

      [SpecialName]
      public ReadOnlyCollection<땃.딷> 땃() => new ReadOnlyCollection<땃.딷>((IList<땃.딷>) this.딟);

      public enum State
      {
        Idle,
        RequestingCatalog,
        Ready,
        Purchasing,
      }
    }

    private class 땏 : 떅
    {
      private static CultureInfo[] 딟 = CultureInfo.GetCultures(CultureTypes.AllCultures);
      private static CultureInfo[] 땄 = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
      private 딟.땇 딟;
      private 딫.땏.State 딟;
      private List<땃.딷> 딟;

      public 땏([In] 딟.땇 obj0) => this.딟 = obj0;

      public void 딟()
      {
        if (this.딟 != 딫.땏.State.Idle && this.딟 != 딫.땏.State.Ready || !this.딟.땥())
          return;
        this.딟 = 딫.땏.State.RequestingCatalog;
        this.딟.딟(this.딶(), new Action<땄.딪>(this.딟));
      }

      [SpecialName]
      public 딟.딘 딶() => 딟.딘.딶;

      public string 딟([In] string obj0)
      {
        foreach (CultureInfo cultureInfo in 딫.땏.땄)
        {
          if (new RegionInfo(cultureInfo.LCID).CurrencySymbol == obj0)
            return cultureInfo.NumberFormat.CurrencySymbol;
        }
        return obj0;
      }

      public string 딟([In] OfferData obj0)
      {
        if (obj0.RealPrice == null)
          return (string) null;
        double num = (double) obj0.RealPrice.Amount * (1.0 + (double) obj0.RealPrice.Tax * 0.01) * 0.01;
        CultureInfo cultureInfo = ((IEnumerable<CultureInfo>) 딫.땏.딟).FirstOrDefault<CultureInfo>((Func<CultureInfo, bool>) (c => c.Name.EndsWith(obj0.RealPrice.Region)));
        if (cultureInfo == null)
          return (string) null;
        NumberFormatInfo numberFormatInfo = cultureInfo.NumberFormat.Clone() as NumberFormatInfo;
        numberFormatInfo.CurrencySymbol = this.딟(obj0.RealPrice.Currency);
        return num.ToString("C", (IFormatProvider) numberFormatInfo);
      }

      public void 딟(
        [In] OfferData obj0,
        [In] Action<PurchaseResult> obj1,
        [In] Action<딟.땑, ErrorMessagehandler.땶> obj2)
      {
        if (this.딟 != 딫.땏.State.Ready || obj0.RealPrice == null)
        {
          obj2(딟.땑.딟, ErrorMessagehandler.땶.딟);
        }
        else
        {
          this.딟 = 딫.땏.State.Purchasing;
          this.딟.딟(obj0.Id, obj0.RealPrice.Region, (Action<땄.떅>) (response => this.딟(obj0, response, obj1, obj2)));
        }
      }

      private void 딟(
        [In] OfferData obj0,
        [In] 땄.떅 obj1,
        [In] Action<PurchaseResult> obj2,
        [In] Action<딟.땑, ErrorMessagehandler.땶> obj3)
      {
        if (!obj1.딧())
        {
          this.딟 = 딫.땏.State.Ready;
          obj3(((땄.땘) obj1).딟, ErrorMessagehandler.땶.딟);
        }
        else
        {
          this.딟 = 딫.땏.State.Ready;
          GoogleWalletJSData googleWalletJsData = new GoogleWalletJSData();
          googleWalletJsData.딟 = obj1.딟();
          if (GlobalAppData.딧().IsLive)
            googleWalletJsData.땄 = new Dictionary<string, object>()
            {
              {
                "env",
                (object) "prod"
              }
            };
          else
            googleWalletJsData.땄 = new Dictionary<string, object>();
          딧.땓.딟("unity_chrome_purchase", 딧.땾.땄((object) googleWalletJsData), (Action<object>) (r => this.딟(obj0, obj2, obj3, r)));
        }
      }

      private void 딟(
        [In] OfferData obj0,
        [In] Action<PurchaseResult> obj1,
        [In] Action<딟.땑, ErrorMessagehandler.땶> obj2,
        [In] object obj3)
      {
        GoogleWalletJSResultData walletJsResultData = 딧.땾.딟<GoogleWalletJSResultData>(obj3);
        if (walletJsResultData.땄 == null)
          walletJsResultData.땄 = new GoogleWalletJSResponseData();
        this.딟 = 딫.땏.State.Ready;
        string empty = string.Empty;
        string str;
        if (!string.IsNullOrEmpty(walletJsResultData.땄.딟))
        {
          if (walletJsResultData.딟 != null)
            딟.딦.딟(walletJsResultData.땄.딟, walletJsResultData.딟.딟, walletJsResultData.딟.땄, walletJsResultData.딟.딧);
          str = "GoogleWallet_PurchaseComplete";
          this.딟.땟();
          obj1((PurchaseResult) null);
        }
        else
        {
          string 땄 = walletJsResultData.땄.땄;
          if (땄 != null)
          {
            // ISSUE: reference to a compiler-generated field
            if (딫.땏.딟 == null)
            {
              // ISSUE: reference to a compiler-generated field
              딫.땏.딟 = new Dictionary<string, int>(1)
              {
                {
                  "PURCHASE_CANCELED",
                  0
                }
              };
            }
            int num;
            // ISSUE: reference to a compiler-generated field
            if (딫.땏.딟.TryGetValue(땄, out num) && num == 0)
            {
              str = "GoogleWallet_PurchaseCancelled";
              obj2(딟.땑.딟, ErrorMessagehandler.땶.떏);
              goto label_12;
            }
          }
          str = "GoogleWallet_PurchaseError";
          obj2(딟.땑.딟, ErrorMessagehandler.땶.딟);
        }
label_12:
        딟.딦.딟(str);
        딟.딦.딟(str + "OfferId", new Dictionary<string, string>()
        {
          {
            "offer_id",
            obj0.Id
          }
        });
      }

      private void 딟([In] 땄.딪 obj0_1)
      {
        if (!obj0_1.딧())
        {
          this.딟 = 딫.땏.State.Idle;
        }
        else
        {
          this.딟 = 딫.땏.State.Ready;
          this.딟 = ((IEnumerable<땄.땗>) obj0_1.딟).OrderBy<땄.땗, int>((Func<땄.땗, int>) (obj0_6 => (obj0_6.땃() as 땓.딞).땓())).Select<땄.땗, 땃.딷>((Func<땄.땗, 땃.딷>) (obj0_7 => new 땃.딷(obj0_7))).ToList<땃.딷>();
        }
      }

      [SpecialName]
      public bool 땄() => this.딟 == 딫.땏.State.Ready;

      [SpecialName]
      public bool 딧() => this.딟 == 딫.땏.State.RequestingCatalog;

      [SpecialName]
      public bool 딢() => true;

      [SpecialName]
      public ReadOnlyCollection<땃.딷> 땃() => new ReadOnlyCollection<땃.딷>((IList<땃.딷>) this.딟);

      public enum State
      {
        Idle,
        RequestingCatalog,
        Ready,
        Purchasing,
      }
    }
  }
}
