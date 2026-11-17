// Decompiled with JetBrains decompiler
// Type: 땓.땀
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땓
{
  public class 땀 : 딟.땇
  {
    public new const string 딟 = "news2.data";
    public new const string 땄 = "/files/news2.data";
    public new const string 딧 = "/files/{0}";
    public new const string 딢 = "version-ios.data";
    public new const string 땃 = "/files/{0}";
    public new const string 딶 = "featureditems.data";
    public new const string 땓 = "/files/featureditems.data";

    public 땀([In] EnvironmentSettingsBase obj0)
      : base(obj0)
    {
    }

    public 떋 딟([In] string obj0, [In] string obj1, [In] int obj2)
    {
      떋 떋 = new 떋();
      ((딧.땋) new 딩((딟.땇) this, 떋, obj0, obj1, obj2)).딶();
      return 떋;
    }

    public 딨 딟([In] 땄.땞 obj0)
    {
      if (obj0.딟 == 딟.딺.딶)
        return 딨.딟;
      int index = this.땃(obj0);
      if (obj0.딟 == 딟.딺.땃 && !obj0.딟[index].딟())
        return 딨.딟;
      return index != -1 && obj0.딟 == obj0.딟[index] || obj0.땄 + obj0.딟 == 2 && obj0.딟 == null ? 딨.딧 : 딨.땄;
    }

    public override int 딢() => (int) Application.internetReachability;

    public override 땄.땅 딟([In] Dictionary<string, object> obj0) => (땄.땅) new 땇(딧.땾.딟<FireTeamUserProfileJsonData>((object) obj0));

    public override 땄.땈 땄([In] Dictionary<string, object> obj0) => (땄.땈) new 딿(딧.땾.딟<FireTeamTurnBasedSessionAttributes>((object) obj0));

    public override 땄.딻 딧([In] Dictionary<string, object> obj0) => (땄.딻) new 딞(딧.땾.딟<FireTeamCatalogEntryData>((object) obj0));

    public override 땄.딜 딟([In] string obj0) => (땄.딜) new 딠(딧.땾.딟<FireTeamCatalogEntryDescriptionData>(obj0));

    public override void 땄() => GlobalAppData.땢().딧();

    public override void 딧() => Application.Quit();

    public override string 땃() => string.Format("{0}-{1}-{2}-{3}", (object) "Tactics", (object) "Unity", (object) ("v" + 10.ToString()), (object) "Web");

    public 땒 딶()
    {
      땒 땒 = new 땒();
      ((딧.땋) new 딟.땏<땒>((딟.땇) this, 땒, "/files/news2.data", new Func<FileStoreData, 땒, bool>(this.딟))).딶();
      return 땒;
    }

    private bool 딟([In] FileStoreData obj0, [In] 땒 obj1)
    {
      NewsDataJson newsDataJson = 딧.땾.딟<NewsDataJson>(obj0.딟());
      if (newsDataJson == null)
        return false;
      obj1.딟 = new 떐(newsDataJson);
      return true;
    }

    public static string 딟([In] 딟.떁 obj0) => "version-ios.data";

    public 떄 땓()
    {
      떄 떄 = new 떄();
      string str = string.Format("/files/{0}", (object) 땀.딟(GlobalAppData.딧().Platform));
      ((딧.땋) new 딟.땏<떄>((딟.땇) this, 떄, str, new Func<FileStoreData, 떄, bool>(this.딟))).딶();
      return 떄;
    }

    private bool 딟([In] FileStoreData obj0, [In] 떄 obj1)
    {
      EngineVersionData engineVersionData = 딧.땾.딟<EngineVersionData>(obj0.딟());
      obj1.딟 = engineVersionData.Version;
      return true;
    }

    public 떉 땺()
    {
      떉 떉 = new 떉();
      ((딧.땋) new 딟.땏<떉>((딟.땇) this, 떉, "/files/featureditems.data", new Func<FileStoreData, 떉, bool>(this.딟))).딶();
      return 떉;
    }

    private bool 딟([In] FileStoreData obj0, [In] 떉 obj1)
    {
      obj1.딟 = 딧.땾.딟<FeaturedItemsDataJson>(obj0.딟());
      return obj1.딟 != null;
    }

    private bool 딟([In] FileStoreData obj0, [In] 떌 obj1)
    {
      obj1.딟(obj0.딟());
      return true;
    }

    public 땄.땕 딟([In] string obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4)
    {
      Dictionary<string, string> dictionary = new Dictionary<string, string>()
      {
        {
          "version",
          obj2.ToString()
        },
        {
          "sublevel_id",
          obj1.ToString()
        },
        {
          "army_size",
          obj3.ToString()
        },
        {
          "tier",
          obj4.ToString()
        }
      };
      if (obj0 != null)
        dictionary.Add("level_id", 딟.딗.딢(obj0).ToString());
      return this.딟("by_all_tier", dictionary);
    }

    public 땄.딮 딟([In] 땙 obj0)
    {
      FireTeamTurnBasedSessionAttributes sessionAttributes = new FireTeamTurnBasedSessionAttributes();
      int num1 = 0;
      int num2 = 0;
      string[] strArray = (string[]) null;
      딟.땎 땎;
      if (!string.IsNullOrEmpty(obj0.땄))
      {
        땎 = 딟.땎.땄;
        num2 = 2;
        sessionAttributes.InviteeId = obj0.땄;
        strArray = new string[1]{ obj0.땄 };
      }
      else
      {
        땎 = 딟.땎.딟;
        num1 = 2;
      }
      sessionAttributes.Name = "Test Session";
      sessionAttributes.LevelId = 딟.딗.딢(obj0.딟);
      sessionAttributes.SubLevelId = obj0.딟;
      sessionAttributes.Version = obj0.땄;
      sessionAttributes.ArmySize = obj0.딧;
      sessionAttributes.MatchMakingTier = obj0.딢;
      return this.딟(딟.딥.딟(obj0.딧), obj0.딟, (object) sessionAttributes, 땎, num1, num2, obj0.딢, strArray);
    }
  }
}
