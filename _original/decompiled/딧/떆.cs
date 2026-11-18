// Decompiled with JetBrains decompiler
// Type: 딧.떆
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

namespace 딧
{
  public static class 떆
  {
    public static 땙 딟([In] 딟.땇 obj0) => (땙) new 떆.딻(obj0);

    public static 땏 딟() => 떆.땄();

    public static 땏 땄() => (땏) new 떆.땐();

    private class 땐 : 땏
    {
      private string[] 딟;

      public void 딟([In] IEnumerable<string> obj0) => this.딟 = obj0.ToArray<string>();

      public string 딟([In] string obj0) => this.땄(obj0) ? "�1.99" : (string) null;

      public void 딟([In] string obj0, [In] Action<PurchaseResult> obj1, [In] Action<딫> obj2)
      {
        if (this.땄(obj0))
          obj1((PurchaseResult) null);
        else
          obj2(딫.딟);
      }

      private bool 땄([In] string obj0) => this.딟() && ((IEnumerable<string>) this.딟).Contains<string>(obj0);

      [SpecialName]
      public bool 딟() => this.딟 != null;

      public void 딟([In] Action<떅[]> obj0) => obj0((떅[]) null);
    }

    private class 땡 : 땙
    {
      private Action<딟.땑, 딫> 딟;
      private 떆.땡.State 딟;
      private List<땄.땗> 딟;
      private 딟.땇 딟;

      public 땡([In] 딟.땇 obj0) => this.딟 = obj0;

      public void 딟()
      {
        if (this.딟 != 떆.땡.State.Idle && this.딟 != 떆.땡.State.Ready || !this.딟.땥())
          return;
        this.딟 = 떆.땡.State.RequestingCatalog;
        this.딟.딟(this.땃(), new Action<땄.딪>(this.딟));
      }

      [SpecialName]
      public 딟.딘 땃() => 딟.딘.땄;

      public string 딟([In] OfferData obj0) => (string) null;

      private void 딟([In] 땄.딪 obj0)
      {
        if (!obj0.딧())
        {
          this.딟 = 떆.땡.State.Idle;
        }
        else
        {
          this.딟 = 떆.땡.State.Ready;
          this.딟 = ((IEnumerable<땄.땗>) obj0.딟).ToList<땄.땗>();
        }
      }

      public void 딟([In] OfferData obj0, [In] Action<PurchaseResult> obj1, [In] Action<딟.땑, 딫> obj2) => obj2(딟.땑.딟, 딫.딟);

      [SpecialName]
      public bool 땄() => this.딟 == 떆.땡.State.Ready;

      [SpecialName]
      public bool 딧() => this.딟 == 떆.땡.State.RequestingCatalog;

      [SpecialName]
      public ReadOnlyCollection<땄.땗> 딢() => new ReadOnlyCollection<땄.땗>((IList<땄.땗>) this.딟);

      public enum State
      {
        Idle,
        RequestingCatalog,
        Ready,
        Purchasing,
      }
    }

    private class 딻 : 땙
    {
      private static CultureInfo[] 딟 = CultureInfo.GetCultures(CultureTypes.AllCultures);
      private 딟.땇 딟;
      private 떆.딻.State 딟;
      private List<땄.땗> 딟;

      public 딻([In] 딟.땇 obj0) => this.딟 = obj0;

      public void 딟()
      {
        if (this.딟 != 떆.딻.State.Idle && this.딟 != 떆.딻.State.Ready || !this.딟.땥())
          return;
        this.딟 = 떆.딻.State.RequestingCatalog;
        this.딟.딟(this.땃(), new Action<땄.딪>(this.딟));
      }

      [SpecialName]
      public 딟.딘 땃() => 딟.딘.딶;

      public string 딟([In] OfferData obj0)
      {
        if (obj0.RealPrice == null)
          return (string) null;
        double num = (double) obj0.RealPrice.Amount * (1.0 + (double) obj0.RealPrice.Tax * 0.01) * 0.01;
        CultureInfo cultureInfo = ((IEnumerable<CultureInfo>) 떆.딻.딟).FirstOrDefault<CultureInfo>((Func<CultureInfo, bool>) (c => c.Name.EndsWith(obj0.RealPrice.Region)));
        return cultureInfo == null ? (string) null : num.ToString("C", (IFormatProvider) cultureInfo);
      }

      public void 딟([In] OfferData obj0, [In] Action<PurchaseResult> obj1, [In] Action<딟.땑, 딫> obj2)
      {
        if (this.딟 != 떆.딻.State.Ready || obj0.RealPrice == null)
        {
          obj2(딟.땑.딟, 딫.딟);
        }
        else
        {
          this.딟 = 떆.딻.State.Purchasing;
          this.딟.딟(obj0.Id, obj0.RealPrice.Region, (Action<땄.떅>) (response => this.딟(obj0, response, obj1, obj2)));
        }
      }

      private void 딟([In] OfferData obj0, [In] 땄.떅 obj1, [In] Action<PurchaseResult> obj2, [In] Action<딟.땑, 딫> obj3)
      {
        if (!obj1.딧())
        {
          this.딟 = 떆.딻.State.Ready;
          obj3(((땄.땘) obj1).딟, 딫.딟);
        }
        else
        {
          this.딟 = 떆.딻.State.Ready;
          SplashDamage.Mobile.Store.GoogleWalletJSData googleWalletJsData = new SplashDamage.Mobile.Store.GoogleWalletJSData();
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
          땓.딟("unity_chrome_purchase", 땾.땄((object) googleWalletJsData), (Action<object>) (r => this.딟(obj0, obj2, obj3, r)));
        }
      }

      private void 딟([In] OfferData obj0, [In] Action<PurchaseResult> obj1, [In] Action<딟.땑, 딫> obj2, [In] object obj3)
      {
        SplashDamage.Mobile.Store.GoogleWalletJSResultData walletJsResultData = 땾.딟<SplashDamage.Mobile.Store.GoogleWalletJSResultData>(obj3);
        if (walletJsResultData.땄 == null)
          walletJsResultData.땄 = new SplashDamage.Mobile.Store.GoogleWalletJSResponseData();
        this.딟 = 떆.딻.State.Ready;
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
            if (떆.딻.딟 == null)
            {
              // ISSUE: reference to a compiler-generated field
              떆.딻.딟 = new Dictionary<string, int>(1)
              {
                {
                  "PURCHASE_CANCELED",
                  0
                }
              };
            }
            int num;
            // ISSUE: reference to a compiler-generated field
            if (떆.딻.딟.TryGetValue(땄, out num) && num == 0)
            {
              str = "GoogleWallet_PurchaseCancelled";
              obj2(딟.땑.딟, 딫.땄);
              goto label_12;
            }
          }
          str = "GoogleWallet_PurchaseError";
          obj2(딟.땑.딟, 딫.딟);
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

      private void 딟([In] 땄.딪 obj0)
      {
        if (!obj0.딧())
        {
          this.딟 = 떆.딻.State.Idle;
        }
        else
        {
          this.딟 = 떆.딻.State.Ready;
          this.딟 = ((IEnumerable<땄.땗>) obj0.딟).ToList<땄.땗>();
        }
      }

      [SpecialName]
      public bool 땄() => this.딟 == 떆.딻.State.Ready;

      [SpecialName]
      public bool 딧() => this.딟 == 떆.딻.State.RequestingCatalog;

      [SpecialName]
      public ReadOnlyCollection<땄.땗> 딢() => new ReadOnlyCollection<땄.땗>((IList<땄.땗>) this.딟);

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
