// Decompiled with JetBrains decompiler
// Type: 딟.땇
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using UnityEngine;

namespace 딟
{
  public abstract class 땇 : 딧.땃
  {
    internal const string 딟 = "/auth/token";
    internal const string 땄 = "/core/application/status";
    public const string 딧 = "/sessions";
    internal const string 딢 = "/files";
    internal const string 땃 = "/files/{0}";
    internal const string 딶 = "/users/{0}/friends";
    internal const string 땓 = "/users/{0}/friends/{1}";
    internal const string 땺 = "/users/{0}/friends/requests/{1}";
    internal const string 땥 = "/users/{0}/notifications?per_page=200";
    internal const string 딝 = "/users/{0}/notifications/{1}";
    public const string 떎 = "/objects/{0}/{1}/links/{2}";
    internal const string 떂 = "/users/{0}/push_channels";
    internal const string 땭 = "service={0}&target_id={1}";
    internal const string 딦 = "/users/{0}/push_targets/{1}/{2}";
    internal const string 땤 = "/users/{0}/friends/scores/{1}?select.0={2}";
    internal const string 땽 = "/users/{0}/scores/{1}";
    public const string 땋 = "challenges";
    internal const string 땲 = "/users/{0}/sessions/turnbased";
    internal const string 떏 = "/sessions/turnbased";
    internal const string 땼 = "/sessions/turnbased/{0}";
    internal const string 땢 = "/sessions/{0}/turns?per_page={1}";
    internal const string 딷 = "/sessions/{0}/turns/{1}";
    internal const string 떁 = "/sessions/{0}";
    internal const string 땟 = "/sessions/{0}/{1}";
    internal const string 땂 = "?state={0}";
    internal const string 딱 = "/users/{0}/invites/{1}";
    internal const string 때 = "/mgr/sessions/{0}/expire";
    internal const string 땩 = "/sessions/{0}/turns/{1}/disputes";
    internal const string 땠 = "/users/{0}/facebook";
    internal const string 땴 = "auth_data.id={0}&auth_data.access_token={1}";
    internal const string 딗 = "/users/{0}/facebook/friends?per_page=200&extended=true&auth_data.id={1}&auth_data.access_token={2}";
    internal const string 땳 = "/store/catalog";
    internal const string 땻 = "/users/{0}/inventory";
    internal const string 딥 = "/store/receipts";
    internal const string 떓 = "vendor={0}&receipt={1}";
    internal const string 딛 = "/store/purchases/transactions";
    internal const string 딣 = "offer_id={0}";
    internal const string 땔 = "offer_id={0}&region={1}";
    internal const string 땁 = "/store/purchases/{0}";
    internal const string 땷 = "/store/vouchers/transactions";
    internal const string 딸 = "voucher_id={0}";
    internal const string 땘 = "/store/vouchers/{0}";
    internal const string 떔 = "/store/items/{0}";
    internal const string 딳 = "/store/items/{0}/offers";
    internal const string 땝 = "/store/googlewallet/transactions";
    internal const string 땹 = "/store/android/transactions";
    internal const string 떇 = "/store/android/transactions/{0}";
    internal const string 땉 = "/users/me?extended=true";
    internal const string 땈 = "/users/{0}?extended=true";
    internal const string 땞 = "/users/{0}/profile/public";
    internal const string 땜 = "profile.data";
    internal const string 땪 = "/users/{0}/files/profile.data";
    internal const string 땕 = "private={0}&data={1}";
    internal const string 딚 = "/users";
    internal const string 따 = "/users/facebook";
    internal const string 딾 = "/users/xboxlive";
    internal const string 땚 = "/users/register";
    public const string 딮 = "http://ns.fireteam.net/oauth2/xboxlive/gamertag&gamertag={0}";
    public const string 딯 = "/users/me/xboxlive";
    private 땯 딟;
    private Dictionary<string, 땄.딽> 딟 = new Dictionary<string, 땄.딽>();
    private bool 딟;
    private Dictionary<string, 땄.땉[]> 딟 = new Dictionary<string, 땄.땉[]>();
    private Action<땬> 딟;

    public 땇([In] EnvironmentSettingsBase obj0)
      : base(obj0.LogHTTPInfo)
    {
      this.딟 = obj0.UseSandboxPushChannel;
      // ISSUE: reference to a compiler-generated method
      this.딝(obj0.Fireteam.ClientId);
      // ISSUE: reference to a compiler-generated method
      this.떎(obj0.Fireteam.ClientSecret);
      // ISSUE: reference to a compiler-generated method
      this.떂(obj0.Fireteam.ServiceURL);
      // ISSUE: reference to a compiler-generated method
      this.땭(obj0.Fireteam.EchoURL);
      // ISSUE: reference to a compiler-generated method
      this.딦(obj0.Fireteam.EchoId);
      // ISSUE: reference to a compiler-generated method
      this.땤(obj0.Fireteam.EchoSecret);
      // ISSUE: reference to a compiler-generated method
      this.땄(new 땬(this));
      // ISSUE: reference to a compiler-generated method
      this.딟(Convert.FromBase64String(obj0.Fireteam.CKey64));
    }

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 딟([In] Action<땬> obj0) => this.딟 += obj0;

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 땄([In] Action<땬> obj0) => this.딟 -= obj0;

    private void 딢()
    {
      if (this.딟 != null)
        return;
      this.딟 = this.땃();
    }

    public 땯 딟([In] string obj0, [In] string obj1)
    {
      땯 땯 = new 땯();
      ((딧.땋) new 땒(this, 땯, obj0, obj1)).딶();
      return 땯;
    }

    public 떄 땄([In] string obj0, [In] string obj1)
    {
      떄 떄 = new 떄();
      ((딧.땋) new 떉(this, 떄, obj0, obj1)).딶();
      return 떄;
    }

    public 땯 땃()
    {
      땯 땯 = new 땯();
      ((딧.땋) new 떌(this, 땯)).딶();
      return 땯;
    }

    public override void 딟()
    {
      base.딟();
      if (this.딟 == null || !this.딟.땄())
        return;
      if (this.딟.딧())
        땇.딧(this.딟.딟, this.딟.땄);
      this.딟 = (땯) null;
    }

    protected override bool 딟([In] 딧.땋 obj0)
    {
      땄.땷 땷 = obj0 as 땄.땷;
      if (땷.딝().땄() == HttpStatusCode.ServiceUnavailable)
      {
        땷.딧().딢();
        return true;
      }
      if (!(땷 is 땒) && !(땷 is 떌))
      {
        if (땷.딝().땄() == HttpStatusCode.BadRequest)
        {
          ErrorData errorData = 땷.땓<ErrorData>();
          if (errorData != null && errorData.Error != null && errorData.Error == "invalid_grant")
            this.딢();
        }
        else if (땷.딝().땄() == HttpStatusCode.Unauthorized)
        {
          switch (땷.딝().딧())
          {
            case "invalid_token":
              this.딢();
              break;
          }
        }
      }
      this.딟(땷);
      return base.딟(obj0);
    }

    public override void 땄([In] 딧.땋 obj0) => obj0.딟(this.떎());

    public static void 딧([In] string obj0, [In] string obj1)
    {
      딧.땱.딟("FireTeamAccessToken", obj0);
      딧.땱.딟("FireTeamRefreshToken", obj1);
    }

    public static void 딶()
    {
      딧.땱.땄("FireTeamAccessToken");
      딧.땱.땄("FireTeamRefreshToken");
    }

    [CompilerGenerated]
    [SpecialName]
    public string 땓() => this.떍;

    [CompilerGenerated]
    [SpecialName]
    public void 땄([In] string obj0) => this.떍 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public string 땺() => this.딴;

    [CompilerGenerated]
    [SpecialName]
    public void 딧([In] string obj0) => this.딴 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public bool 땥() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] bool obj0) => this.땄 = obj0;

    public bool 딢([In] string obj0) => this.땓().Equals(obj0);

    private 땄.딽 땃([In] string obj0)
    {
      if (string.IsNullOrEmpty(obj0))
        return (땄.딽) null;
      땄.딽 딽;
      return !this.딟.TryGetValue(obj0, out 딽) ? (땄.딽) null : 딽;
    }

    public void 딟([In] IEnumerable<땄.딽> obj0)
    {
      foreach (땄.딽 딽 in obj0)
        this.딟(딽);
    }

    public void 딟([In] 땄.딽 obj0)
    {
      if (this.딟.TryGetValue(obj0.딟(), out 땄.딽 _))
        this.딟[obj0.딟()] = obj0;
      else
        this.딟.Add(obj0.딟(), obj0);
    }

    public void 딢([In] string obj0, [In] string obj1) => this.땃(obj0)?.딧(obj1);

    public void 딟([In] string obj0, [In] 땄.땅 obj1) => this.땃(obj0)?.딟(obj1);

    public void 딟([In] 땬 obj0)
    {
      if (this.딟 == null)
        return;
      this.딟(obj0);
    }

    public static DateTime? 딶([In] string obj0)
    {
      DateTime result;
      return !DateTime.TryParse(obj0, out result) ? new DateTime?() : new DateTime?(result);
    }

    public static DateTime 딟([In] string obj0, [In] DateTime obj1)
    {
      DateTime result;
      return !DateTime.TryParse(obj0, out result) ? obj1 : result;
    }

    [CompilerGenerated]
    [SpecialName]
    public string 딝() => this.땀;

    [CompilerGenerated]
    [SpecialName]
    public void 땓([In] string obj0) => this.땀 = obj0;

    [SpecialName]
    public string 떎() => 딧.땱.딟("FireTeamAccessToken");

    [SpecialName]
    public string 떂() => 딧.땱.딟("FireTeamRefreshToken");

    public void 땭()
    {
      this.땄();
      땇.딶();
      this.딟(false);
      this.땄((string) null);
      this.딧((string) null);
    }

    public static bool 땺([In] string obj0) => obj0.Length < 2 || obj0.Length > 15;

    public static bool 땥([In] string obj0) => Regex.IsMatch(obj0, "[^A-Za-z0-9._-]+");

    private void 딟([In] 땄.땷 obj0)
    {
      if (obj0.딝().땄() < HttpStatusCode.BadRequest)
        return;
      obj0.딧().딟 = obj0.땓();
      if (!obj0.땃())
      {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        dictionary.Add("Status", obj0.딝().땄().ToString());
        dictionary.Add("Uri", obj0.땥());
        if (obj0.딧().딟 != 땑.딟)
          dictionary.Add("ErrorCode", ((int) obj0.딧().딟).ToString());
        딟.딦.딟("ConnectionError", dictionary);
      }
      string s = obj0.딝().딟("x-ratelimit-remaining");
      int result;
      if (string.IsNullOrEmpty(s) || !int.TryParse(s, out result) || result != 0)
        return;
      this.딧();
    }

    public static void 딟<딟>([In] ref 딟 obj0, [In] Action<딟> obj1, [In] Action<딟> obj2) where 딟 : 땄.땘
    {
      if ((object) obj0 == null || !obj0.땄())
        return;
      딟 딟 = obj0;
      obj0 = (딟) null;
      if (딟.딧())
      {
        if (obj1 == null)
          return;
        obj1(딟);
      }
      else
      {
        if (obj2 == null)
          return;
        obj2(딟);
      }
    }

    public abstract 땄.땅 딟([In] Dictionary<string, object> obj0);

    public abstract 땄.땈 땄([In] Dictionary<string, object> obj0);

    public abstract 땄.딻 딧([In] Dictionary<string, object> obj0);

    public abstract 땄.딜 딟([In] string obj0);

    public abstract void 땄();

    public abstract void 딧();

    [CompilerGenerated]
    [SpecialName]
    public 땬 딦() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public string 땤() => this.떋;

    [CompilerGenerated]
    [SpecialName]
    public string 땽() => this.딩;

    [CompilerGenerated]
    [SpecialName]
    public string 땋() => this.딖;

    [CompilerGenerated]
    [SpecialName]
    public string 땲() => this.딞;

    [CompilerGenerated]
    [SpecialName]
    public string 떏() => this.딡;

    [CompilerGenerated]
    [SpecialName]
    public string 땼() => this.딠;

    [CompilerGenerated]
    [SpecialName]
    public byte[] 땢() => this.딟;

    public 땵 딷()
    {
      땵 땵 = new 땵();
      ((딧.땋) new 떐(this, 땵)).딶();
      return 땵;
    }

    public void 딟<딟>([In] string obj0, [In] int obj1, [In] Action<딙<딟>> obj2)
    {
      딙<딟> 딙 = new 딙<딟>();
      ((딧.땋) new 땿<딟>(this, obj0, obj1, 딙, obj2)).딶();
    }

    public void 딟<딟>([In] 땶 obj0, [In] Action<딫<딟>> obj1)
    {
      딫<딟> 딫 = new 딫<딟>();
      ((딧.땋) new 땙<딟>(this, obj0, 딫, obj1)).딶();
    }

    public 딜 딟([In] string obj0, [In] byte[] obj1, [In] string obj2)
    {
      딜 딜 = new 딜();
      ((딧.땋) new 땗(this, 딜, obj0, obj1, obj2)).딶();
      return 딜;
    }

    public 떆 땽([In] string obj0)
    {
      떆 떆 = new 떆();
      ((딧.땋) new 땐(this, 떆, obj0)).딶();
      return 떆;
    }

    public 땡 땃([In] string obj0, [In] string obj1)
    {
      땡 땡 = new 땡();
      ((딧.땋) new 딻(this, 땡, obj1, obj0)).딶();
      return 땡;
    }

    public 딵 땋([In] string obj0)
    {
      딵 딵 = new 딵();
      ((딧.땋) new 땰(this, this.땓(), obj0, 딵)).딶();
      return 딵;
    }

    public 딤 떁()
    {
      딤 딤 = new 딤();
      ((딧.땋) new 딭(this, this.땓(), 딤)).딶();
      return 딤;
    }

    public 땣 땲([In] string obj0)
    {
      땣 땣 = new 땣();
      ((딧.땋) new 땱(this, this.땓(), obj0, 땣)).딶();
      return 땣;
    }

    public 땦 떏([In] string obj0)
    {
      땦 땦 = new 땦();
      ((딧.땋) new 떃(this, this.땓(), obj0, 땦)).딶();
      return 땦;
    }

    public 땧 딟([In] string obj0, [In] Action obj1, [In] Action<Texture2D> obj2)
    {
      땧 땧 = new 땧();
      ((딧.땋) new 땊(this, 땧, obj0, obj1, obj2)).딶();
      return 땧;
    }

    public 딬 땟()
    {
      딬 딬 = new 딬();
      ((딧.땋) new 땸(this, 딬, this.땓())).딶();
      return 딬;
    }

    public 땄.딱 땂()
    {
      땄.딱 딱 = new 땄.딱();
      ((딧.땋) new 땄.때(this, this.땓(), 딱)).딶();
      return 딱;
    }

    public 땄.땩 땼([In] string obj0)
    {
      땄.땩 땩 = new 땄.땩();
      ((딧.땋) new 땄.땠(this, this.땓(), obj0, 땩)).딶();
      return 땩;
    }

    public 땄.땴 땢([In] string obj0)
    {
      땄.땴 땴 = new 땄.땴();
      ((딧.땋) new 땄.딗(this, this.땓(), obj0, 땴)).딶();
      return 땴;
    }

    public void 딟([In] string obj0, [In] string obj1, [In] string obj2, [In] Action<땄.땳> obj3)
    {
      땄.땳 땳 = new 땄.땳();
      ((딧.땋) new 땄.땻(this, obj0, obj1, obj2, 땳, obj3)).딶();
    }

    public 땄.딣 딷([In] string obj0)
    {
      땄.딣 딣 = new 땄.딣();
      딣.땄(true);
      딣.딧(false);
      return 딣;
    }

    public 땄.떓 떁([In] string obj0)
    {
      땄.떓 떓 = new 땄.떓();
      ((딧.땋) new 땄.딛(this, this.땓(), obj0, 땄.딥.땄, 떓, this.딟)).딶();
      return 떓;
    }

    public 땄.딳 딶([In] string obj0, [In] string obj1)
    {
      땄.딳 딳 = new 땄.딳();
      ((딧.땋) new 땄.땝(this, 딳, obj0, obj1)).딶();
      return 딳;
    }

    public 땄.떔 딟([In] string obj0, [In] string obj1, [In] int obj2)
    {
      땄.떔 떔 = new 땄.떔();
      ((딧.땋) new 땄.땹(this, 떔, obj0, obj1, obj2)).딶();
      return 떔;
    }

    public 땄.땕 딱()
    {
      땄.땕 땕 = new 땄.땕();
      ((딧.땋) new 땄.딿(this, 땕)).딶();
      return 땕;
    }

    public 땄.땕 딟([In] string obj0, [In] Dictionary<string, string> obj1)
    {
      땄.땕 땕 = new 땄.땕();
      ((딧.땋) new 땄.딨(this, 땕, obj0, obj1)).딶();
      return 땕;
    }

    public 땄.딚 땟([In] string obj0)
    {
      땄.딚 딚 = new 땄.딚();
      ((딧.땋) new 땄.땇(this, 딚, obj0)).딶();
      return 딚;
    }

    public 땄.땚 딟([In] 땄.땞 obj0)
    {
      땄.땚 땚 = new 땄.땚();
      땄.땉[] 땉Array = this.딧(obj0);
      if (땉Array != null)
      {
        obj0.딟 = 땉Array;
        땚.땄(true);
        땚.딧(true);
        return 땚;
      }
      if (obj0.딧 == 0)
      {
        obj0.딟 = new 땄.땉[0];
        땚.땄(true);
        땚.딧(true);
        return 땚;
      }
      ((딧.땋) new 땄.땯(this, obj0, 땚)).딶();
      return 땚;
    }

    public 땄.딮 딟(
      [In] string obj0,
      [In] Dictionary<string, int> obj1,
      [In] object obj2,
      [In] 땎 obj3,
      [In] int obj4,
      [In] int obj5,
      [In] string obj6,
      [In] string[] obj7)
    {
      땄.딮 딮 = new 땄.딮();
      ((딧.땋) new 땄.떍(this, 딮, obj0, obj1, obj2, obj3, obj4, obj5, obj6, obj7)).딶();
      return 딮;
    }

    public 땄.따 딟([In] string obj0, [In] bool obj1)
    {
      땄.따 따 = new 땄.따();
      ((딧.땋) new 땄.땨(this, 따, obj0, this.땓(), obj1)).딶();
      return 따;
    }

    public 땄.딴 딟(
      [In] string obj0,
      [In] int obj1,
      [In] string obj2,
      [In] string obj3,
      [In] Dictionary<string, int> obj4,
      [In] bool obj5,
      [In] List<떀> obj6,
      [In] List<떀> obj7)
    {
      땄.딴 딴 = new 땄.딴();
      ((딧.땋) new 땄.땀(this, 딴, obj0, obj1, obj2, obj3, obj4, obj5, obj6, obj7)).딶();
      return 딴;
    }

    public 땄.딴 딟([In] string obj0, [In] int obj1, [In] string obj2, [In] string obj3, [In] Dictionary<string, int> obj4) => this.딟(obj0, obj1, obj2, obj3, obj4, false, (List<떀>) null, (List<떀>) null);

    public 땄.딴 딟([In] string obj0, [In] int obj1, [In] string obj2, [In] string obj3, [In] List<떀> obj4, [In] List<떀> obj5) => this.딟(obj0, obj1, obj2, obj3, (Dictionary<string, int>) null, false, obj4, obj5);

    public 땄.딴 딟(
      [In] string obj0,
      [In] int obj1,
      [In] string obj2,
      [In] string obj3,
      [In] Dictionary<string, 땾> obj4,
      [In] List<떀> obj5)
    {
      땄.딴 딴 = new 땄.딴();
      ((딧.땋) new 땄.땒(this, 딴, obj0, obj1, obj2, obj3, obj4, obj5)).딶();
      return 딴;
    }

    public 땄.떋 땂([In] string obj0)
    {
      땄.떋 떋 = new 땄.떋();
      ((딧.땋) new 땄.딩(this, 떋, obj0)).딶();
      return 떋;
    }

    public 땄.딾 딟([In] 땄.땞 obj0, [In] int obj1)
    {
      땄.딾 딾 = new 땄.딾();
      ((딧.땋) new 땄.떄(this, obj0, obj1, 딾)).딶();
      return 딾;
    }

    public 땄.딖 딱([In] string obj0)
    {
      땄.딖 딖 = new 땄.딖();
      ((딧.땋) new 땄.딞(this, 딖, this.땓(), obj0)).딶();
      return 딖;
    }

    public 땄.딡 땓([In] string obj0, [In] string obj1)
    {
      땄.딡 딡 = new 땄.딡();
      ((딧.땋) new 땄.딠(this, 딡, obj0, obj1)).딶();
      return 딡;
    }

    public void 땄([In] 땄.땞 obj0) => this.딟[obj0.딟] = obj0.딟;

    public 땄.땉[] 딧([In] 땄.땞 obj0)
    {
      땄.땉[] 땉Array;
      if (!this.딟.TryGetValue(obj0.딟, out 땉Array))
        return (땄.땉[]) null;
      return 땉Array.Length != obj0.딧 ? (땄.땉[]) null : 땉Array;
    }

    public bool 딢([In] 땄.땞 obj0) => obj0.딟 != null && obj0.딟.딧().Equals(this.땓());

    public int 땃([In] 땄.땞 obj0)
    {
      if (obj0 == null)
        return 0;
      for (int index = 0; index < obj0.딟.Length; ++index)
      {
        if (obj0.딟[index].딧().Equals(this.땓()))
          return index;
      }
      return -1;
    }

    public static string 딶([In] 땄.땞 obj0)
    {
      int num = -1;
      for (int index = 0; index < obj0.딟.Length; ++index)
      {
        if (obj0.딟 == obj0.딟[index])
        {
          num = index;
          break;
        }
      }
      return obj0.딟[(num + 1) % obj0.딟.Length].딧();
    }

    public 땄.땛 땺([In] string obj0, [In] string obj1)
    {
      땄.땛 땛 = new 땄.땛();
      ((딧.땋) new 땄.땵(this, 땛, this.땓(), obj0, obj1)).딶();
      return 땛;
    }

    public 땄.떉 때()
    {
      땄.떉 떉 = new 땄.떉();
      ((딧.땋) new 땄.떌(this, 떉, this.땓())).딶();
      return 떉;
    }

    public 땄.딹 땩()
    {
      땄.딹 딹 = new 땄.딹();
      ((딧.땋) new 땄.딙(this, 딹, this.땓())).딶();
      return 딹;
    }

    public 땄.떐 땥([In] string obj0, [In] string obj1)
    {
      땄.떐 떐 = new 땄.떐();
      ((딧.땋) new 땄.떈(this, 떐, this.땓(), obj0, obj1)).딶();
      return 떐;
    }

    public 땄.땿 때([In] string obj0)
    {
      땄.땿 땿 = new 땄.땿();
      ((딧.땋) new 땄.땶(this, 땿, obj0)).딶();
      return 땿;
    }

    public void 딟([In] string obj0, [In] string obj1, [In] Action<땄.떅> obj2) => ((딧.땋) new 땄.딫(this, obj2, obj0, obj1)).딶();

    public 땄.땙 땩([In] string obj0)
    {
      땄.땙 땙 = new 땄.땙();
      ((딧.땋) new 땄.땏(this, 땙, obj0)).딶();
      return 땙;
    }

    public 땄.땐 땠([In] string obj0)
    {
      땄.땐 땐 = new 땄.땐();
      ((딧.땋) new 땄.땡(this, 땐, obj0)).딶();
      return 땐;
    }

    public 땄.딪 딟([In] 딘 obj0)
    {
      땄.딪 딪 = new 땄.딪();
      ((딧.땋) new 땄.떕(this, 딪, obj0, (string) null, (Action<땄.딪>) null)).딶();
      return 딪;
    }

    public void 딟([In] 딘 obj0, [In] Action<땄.딪> obj1) => this.딟(obj0, (string) null, obj1);

    public void 딟([In] 딘 obj0, [In] string obj1, [In] Action<땄.딪> obj2) => ((딧.땋) new 땄.떕(this, new 땄.딪(), obj0, obj1, obj2)).딶();

    public 땄.땎 땄([In] byte[] obj0)
    {
      땄.땎 땎 = new 땄.땎();
      ((딧.땋) new 땄.떑(this, 땎, obj0, (Action<땄.땎>) null)).딶();
      return 땎;
    }

    public void 딟([In] byte[] obj0, [In] Action<땄.땎> obj1) => ((딧.땋) new 땄.떑(this, new 땄.땎(), obj0, obj1)).딶();

    public 땄.딺 땴([In] string obj0)
    {
      땄.딺 딺 = new 땄.딺();
      ((딧.땋) new 땄.땾(this, 딺, obj0)).딶();
      return 딺;
    }

    public 땄.딘 딟([In] string obj0, [In] Action<땄.딘> obj1)
    {
      땄.딘 딘 = new 땄.딘();
      ((딧.땋) new 땄.땑(this, 딘, obj0, obj1)).딶();
      return 딘;
    }

    public 땄.땿 딟([In] string obj0, [In] string obj1, [In] string obj2, [In] Action<땄.땿> obj3)
    {
      땄.땿 땿 = new 땄.땿();
      ((딧.땋) new 땄.딲(this, 땿, obj0, obj1, obj2, obj3)).딶();
      return 땿;
    }

    public 땄.딵 땠()
    {
      땄.딵 딵 = new 땄.딵();
      ((딧.땋) new 땄.땰(this, 딵)).딶();
      return 딵;
    }

    public 땄.딤 딝([In] string obj0, [In] string obj1)
    {
      땄.딤 딤 = new 땄.딤();
      ((딧.땋) new 땄.딭(this, 딤, obj0, obj1)).딶();
      return 딤;
    }

    public 땄.땣 땄([In] string obj0, [In] bool obj1)
    {
      땄.땣 땣 = new 땄.땣();
      if (string.IsNullOrEmpty(obj0))
      {
        땣.땄(true);
        땣.딧(false);
        return 땣;
      }
      if (!obj1)
      {
        땄.딽 딽 = this.땃(obj0);
        if (딽 != null)
        {
          땣.딟 = 딽;
          땣.땄(true);
          땣.딧(true);
          return 땣;
        }
      }
      ((딧.땋) new 땄.땱(this, obj0, 땣)).딶();
      return 땣;
    }

    public 땄.땦 딟([In] 땄.땅 obj0)
    {
      땄.땦 땦 = new 땄.땦();
      ((딧.땋) new 땄.떃(this, this.땓(), obj0, 땦)).딶();
      return 땦;
    }

    public 땄.땆 땴()
    {
      땄.땆 땆 = new 땄.땆();
      ((딧.땋) new 땄.땫(this, 땆, this.땓())).딶();
      return 땆;
    }

    public 땄.딼 딗([In] string obj0)
    {
      땄.딼 딼 = new 땄.딼();
      ((딧.땋) new 땄.땧(this, 딼, obj0, this.땓())).딶();
      return 딼;
    }

    public 땄.땊 딟([In] string obj0, [In] 땄.떀 obj1)
    {
      땄.땊 땊 = new 땄.땊();
      ((딧.땋) new 땄.땍(this, obj0, obj1, 땊, (Action<땄.땊>) null)).딶();
      return 땊;
    }

    public void 딟([In] string obj0, [In] 땄.떀 obj1, [In] Action<땄.땊> obj2)
    {
      땄.땊 땊 = new 땄.땊();
      ((딧.땋) new 땄.땍(this, obj0, obj1, 땊, obj2)).딶();
    }

    public static string 딗()
    {
      byte[] inArray = new byte[8];
      for (int index = 0; index < inArray.Length; ++index)
        inArray[index] = (byte) Random.Range(1, (int) byte.MaxValue);
      return Convert.ToBase64String(inArray);
    }

    public 땄.딬 딟([In] string obj0, [In] string obj1, [In] bool obj2)
    {
      땄.딬 딬 = new 땄.딬(obj0, obj1);
      if (obj2)
        ((딧.땋) new 땄.땸(this, 딬)).딶();
      else
        ((딧.땋) new 땄.땬(this, 딬)).딶();
      return 딬;
    }

    public void 딟([In] string obj0, [In] Action<땄.떒> obj1) => ((딧.땋) new 땄.땮(this, new 땄.떒(), obj0, obj1)).딶();

    public void 딟([In] Action<딧.딟> obj0) => ((딧.땋) new 딧.땄(this, new 딧.딟(), obj0)).딶();
  }
}
