// Decompiled with JetBrains decompiler
// Type: 딢.떇
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딢
{
  public class 떇 : IDisposable
  {
    public const int 딟 = 4;

    public 떇()
    {
      this.딟(false);
      this.땺();
      GlobalAppData.떏().딟(new Action<딟.땬>(this.딟));
    }

    public 떇([In] bool obj0)
    {
      this.딟(obj0);
      this.땺();
      GlobalAppData.떏().딟(new Action<딟.땬>(this.딟));
    }

    public 떇([In] ClientProfileData obj0)
    {
      this.딟(obj0);
      this.땺();
      GlobalAppData.떏().딟(new Action<딟.땬>(this.딟));
    }

    [SpecialName]
    public static string 딟() => "profile" + (object) 4;

    public void Dispose() => GlobalAppData.떏().땄(new Action<딟.땬>(this.딟));

    private void 딟([In] 딟.땬 obj0)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(new Dictionary<string, int>((IDictionary<string, int>) obj0.땄()));
      this.땄();
      this.땄(false);
    }

    private void 땄()
    {
      bool flag1 = false;
      // ISSUE: reference to a compiler-generated method
      foreach (땓.떀 떀 in this.딥())
      {
        bool flag2 = true;
        딢.때 때 = GlobalAppData.땼().딣(떀.땘());
        if (때 == null)
          flag2 = false;
        else if (!string.IsNullOrEmpty(때.땄()) && !this.딶(때.땄()))
          flag2 = false;
        if (!flag2)
          떀.땄(GlobalAppData.땼().땳(떀.떔()));
        int num1 = this.딟(떀.딸(), (땓.떀) null);
        딢.땻 땻 = GlobalAppData.땼().땔(떀.딸());
        if (땻 == null)
        {
          flag1 = true;
        }
        else
        {
          int num2 = this.땃(땻.땄());
          if (num1 > num2)
            flag1 = true;
        }
      }
      if (!flag1)
        return;
      // ISSUE: reference to a compiler-generated method
      foreach (땓.떀 떀 in this.딥())
        떀.딟(GlobalAppData.땼().딗(떀.떔()));
    }

    public bool 딟([In] 떇 obj0) => this.떔() != obj0.떔() || this.땘() > obj0.땘();

    public ClientProfileData 딧()
    {
      ClientProfileData clientProfileData = new ClientProfileData();
      // ISSUE: reference to a compiler-generated method
      clientProfileData.Characters = this.딥().Select<땓.떀, UnitCharacterData>((Func<땓.떀, UnitCharacterData>) (obj0 => obj0.땻())).ToArray<UnitCharacterData>();
      clientProfileData.PlayerXP = this.딣();
      clientProfileData.PlayerMPScore = this.땔();
      clientProfileData.LastModified = this.땘();
      clientProfileData.UserId = this.떔();
      if (this.딳().Scheme == "avatar")
        clientProfileData.Avatar = this.딳().Host;
      clientProfileData.Avatar2 = this.딳().ToString();
      clientProfileData.ActiveCommanderId = this.땝();
      clientProfileData.ToolTipsWatched = this.땷().ToArray();
      clientProfileData.UnlockedAchievements = this.떓().ToArray();
      clientProfileData.Inventory = this.딸();
      clientProfileData.Cookies = this.딛().ToDictionary<KeyValuePair<딢.땹, int>, string, int>((Func<KeyValuePair<딢.땹, int>, string>) (obj0 => ((int) obj0.Key).ToString()), (Func<KeyValuePair<딢.땹, int>, int>) (obj0 => obj0.Value));
      clientProfileData.MissionScores = this.땁().ToArray();
      clientProfileData.PendingVouchers = this.땻().ToArray();
      return clientProfileData;
    }

    public void 딟([In] ClientProfileData obj0_1)
    {
      List<땓.떀> 떀List = new List<땓.떀>();
      foreach (UnitCharacterData unitCharacterData in 딧.땾.딟<UnitCharacterData>(obj0_1.Characters))
      {
        땓.떀 떀 = new 땓.떀(-1, unitCharacterData);
        if (GlobalAppData.땼().딸(떀.떔()) != null)
          떀List.Add(떀);
      }
      // ISSUE: reference to a compiler-generated method
      this.딟(떀List);
      // ISSUE: reference to a compiler-generated method
      this.땃(obj0_1.PlayerXP);
      // ISSUE: reference to a compiler-generated method
      this.딶(obj0_1.PlayerMPScore);
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0_1.LastModified);
      // ISSUE: reference to a compiler-generated method
      this.땄(땓.땶.딟(!string.IsNullOrEmpty(obj0_1.Avatar2) ? obj0_1.Avatar2 : obj0_1.Avatar));
      this.딦(obj0_1.ActiveCommanderId);
      // ISSUE: reference to a compiler-generated method
      this.딟(((IEnumerable<딮>) 딧.땾.딟<딮>(obj0_1.ToolTipsWatched)).ToList<딮>());
      // ISSUE: reference to a compiler-generated method
      this.딟(((IEnumerable<int>) 딧.땾.딟<int>(obj0_1.UnlockedAchievements)).ToList<int>());
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      this.딟(딧.땾.딟<Dictionary<string, int>>(obj0_1.Cookies).Select<KeyValuePair<string, int>, 딝.딸<int, bool, int>>((Func<KeyValuePair<string, int>, 딝.딸<int, bool, int>>) (obj0_2 =>
      {
        int result;
        bool flag = int.TryParse(obj0_2.Key, out result);
        // ISSUE: object of a compiler-generated type is created
        return new 딝.딸<int, bool, int>(result, flag, obj0_2.Value);
      })).Where<딝.딸<int, bool, int>>((Func<딝.딸<int, bool, int>, bool>) (obj0_3 => obj0_3.땄())).ToDictionary<딝.딸<int, bool, int>, 딢.땹, int>((Func<딝.딸<int, bool, int>, 딢.땹>) (obj0_4 => (딢.땹) obj0_4.딟()), (Func<딝.딸<int, bool, int>, int>) (obj0_5 => obj0_5.딧())));
      // ISSUE: reference to a compiler-generated method
      this.딟(딧.땾.딟<Dictionary<string, int>>(obj0_1.Inventory));
      // ISSUE: reference to a compiler-generated method
      this.딟(((IEnumerable<SinglePlayerMissionScore>) 딧.땾.딟<SinglePlayerMissionScore>(obj0_1.MissionScores)).ToList<SinglePlayerMissionScore>());
      // ISSUE: reference to a compiler-generated method
      this.딟(((IEnumerable<string>) 딧.땾.딟<string>(obj0_1.PendingVouchers)).ToList<string>());
      // ISSUE: reference to a compiler-generated method
      this.땭(obj0_1.UserId);
    }

    public bool 딢() => !string.IsNullOrEmpty(떇.딟(떇.딟()));

    public void 딟([In] bool obj0)
    {
      bool flag = false;
      if (!obj0)
      {
        string str = 떇.딟(떇.딟());
        if (!string.IsNullOrEmpty(str))
        {
          ClientProfileData clientProfileData = 딧.땾.딟<ClientProfileData>(str);
          if (clientProfileData != null)
          {
            this.딟(clientProfileData);
            flag = true;
          }
        }
      }
      if (flag)
        return;
      this.딝();
    }

    public void 땃()
    {
      if (((딟.딗) GlobalAppData.땼()).땽() || !this.딢())
        return;
      switch (Random.Range(0, 2))
      {
        case 1:
          if (this.딶())
            break;
          this.땓();
          break;
        default:
          this.땓();
          break;
      }
    }

    private bool 딶()
    {
      List<LocalisationEntry> localisationEntryList = new List<LocalisationEntry>();
      foreach (딢.땃 땃 in GlobalAppData.땼().딷())
      {
        if (땃.떎())
        {
          foreach (SinglePlayerMissionAsset playerMissionAsset in ((IEnumerable<SinglePlayerMissionAsset>) ((IEnumerable<string>) 땃.딝()).Select<string, SinglePlayerMissionAsset>((Func<string, SinglePlayerMissionAsset>) (obj0 => GlobalAppData.땼().때(obj0))).ToArray<SinglePlayerMissionAsset>()).Take<SinglePlayerMissionAsset>(ChallengePackAsset.딧(땃.딝()) + 1))
          {
            if (!Object.op_Equality((Object) playerMissionAsset.LocalNotificationText, (Object) null) && this.떎(playerMissionAsset.Id) <= 0)
              localisationEntryList.Add(playerMissionAsset.LocalNotificationText);
          }
        }
      }
      return this.딟(localisationEntryList.ToArray(), (object[]) null);
    }

    private bool 땓()
    {
      if (GlobalAppData.딟.CharacterLocalNotificationText.Length == 0)
        return false;
      List<땓.떀> 떀List = this.딢(false);
      if (떀List.Count == 0)
        return false;
      int index = Random.Range(0, 떀List.Count);
      string str = 떀List[index].땹();
      return this.딟(GlobalAppData.딟.CharacterLocalNotificationText, new object[1]
      {
        (object) str
      });
    }

    private bool 딟([In] LocalisationEntry[] obj0, [In] object[] obj1) => obj0.Length != 0;

    private void 땺()
    {
      if (this.딳() == (Uri) null)
      {
        // ISSUE: reference to a compiler-generated method
        this.땄(땓.땶.딟(GlobalAppData.딟.땓()));
      }
      if (!string.IsNullOrEmpty(this.땝()))
        return;
      this.딦(GlobalAppData.딟.DefaultCommanderId);
    }

    public void 땥() => this.땄(true);

    public void 땄([In] bool obj0)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(DateTime.Now.ToUniversalTime());
      if (GlobalAppData.떏().땥())
      {
        // ISSUE: reference to a compiler-generated method
        this.땭(((딟.땇) GlobalAppData.떏()).땓());
      }
      string str = 딧.땾.땄((object) this.딧());
      떇.딟(떇.딟(), str);
      if (!obj0 || !GlobalAppData.떏().땥())
        return;
      GlobalAppData.떏().딗(str);
      땓.땇 땇 = new 땓.땇(this);
      GlobalAppData.떏().딟((땄.땅) 땇);
    }

    private void 딝()
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(new List<땓.떀>());
      if (this.땷() == null)
      {
        // ISSUE: reference to a compiler-generated method
        this.딟(new List<딮>());
      }
      if (this.떓() == null)
      {
        // ISSUE: reference to a compiler-generated method
        this.딟(new List<int>());
      }
      if (this.딛() == null)
      {
        // ISSUE: reference to a compiler-generated method
        this.딟(new Dictionary<딢.땹, int>());
      }
      if (this.땁() == null)
      {
        // ISSUE: reference to a compiler-generated method
        this.딟(new List<SinglePlayerMissionScore>());
      }
      if (this.땻() == null)
      {
        // ISSUE: reference to a compiler-generated method
        this.딟(new List<string>());
      }
      // ISSUE: reference to a compiler-generated method
      this.딟(DateTime.MinValue);
      // ISSUE: reference to a compiler-generated method
      this.딟(new Dictionary<string, int>());
      foreach (DefeaultInventoryItem defeaultInventoryItem in GlobalAppData.딟.DefaultInventory)
        this.딸().Add(defeaultInventoryItem.ItemId, defeaultInventoryItem.Count);
    }

    public static void 딟([In] string obj0, [In] string obj1)
    {
      string str = 딟.딥.딟(obj1);
      PlayerPrefs.SetString(obj0, str);
    }

    public static string 딟([In] string obj0) => !PlayerPrefs.HasKey(obj0) ? string.Empty : 딟.딥.딧(PlayerPrefs.GetString(obj0));

    public static void 땄([In] string obj0) => PlayerPrefs.DeleteKey(obj0);

    public 땓.떀 딟([In] 땓.떀 obj0)
    {
      int index = this.땄(obj0);
      // ISSUE: reference to a compiler-generated method
      return index == -1 ? (땓.떀) null : this.딥()[index];
    }

    public 땓.떀 딧([In] string obj0)
    {
      int index = this.딢(obj0);
      // ISSUE: reference to a compiler-generated method
      return index == -1 ? (땓.떀) null : this.딥()[index];
    }

    public int 딢([In] string obj0)
    {
      // ISSUE: reference to a compiler-generated method
      for (int index = 0; index < this.딥().Count; ++index)
      {
        // ISSUE: reference to a compiler-generated method
        if (this.딥()[index].떔() == obj0)
          return index;
      }
      return -1;
    }

    public int 땄([In] 땓.떀 obj0)
    {
      // ISSUE: reference to a compiler-generated method
      for (int index = 0; index < this.딥().Count; ++index)
      {
        // ISSUE: reference to a compiler-generated method
        if (this.딥()[index].딳() == obj0.딳())
          return index;
      }
      return -1;
    }

    public void 딟([In] int obj0, [In] int obj1)
    {
      떇 떇 = this;
      // ISSUE: reference to a compiler-generated method
      떇.땃(떇.딣() + obj0);
      // ISSUE: reference to a compiler-generated method
      this.땃(Mathf.Clamp(this.딣(), 0, obj1));
    }

    public static bool 떎() => 떇.딟(out string _, out string _);

    public static string 떂() => PlayerPrefs.GetString("FireTeamAccessToken");

    public static string 땭() => PlayerPrefs.GetString("FireTeamRefreshToken");

    public static bool 딟(out string _param0, out string _param1)
    {
      _param0 = 떇.떂();
      _param1 = 떇.땭();
      return !string.IsNullOrEmpty(_param0) && !string.IsNullOrEmpty(_param1);
    }

    public static void 딟([In] Action<땞> obj0) => 땞.딟(obj0);

    public static void 딦() => 떇.딧(true);

    public static void 딧([In] bool obj0)
    {
      딟.땇.딶();
      if (!obj0)
        return;
      땞.딧();
    }

    public static void 딟([In] string obj0, [In] string obj1, [In] string obj2) => new 땞(obj0, obj1, obj2).땄();

    public void 딟([In] 딮 obj0)
    {
      if (this.땷().Contains(obj0))
        return;
      this.땷().Add(obj0);
      this.땄(false);
    }

    public bool 땄([In] 딮 obj0) => this.땷().Contains(obj0);

    public void 땤()
    {
      this.땷().Clear();
      this.땄(false);
    }

    public int 딟([In] string obj0, [In] 땓.떀 obj1)
    {
      int num = 0;
      // ISSUE: reference to a compiler-generated method
      foreach (땓.떀 떀 in this.딥())
      {
        if ((obj1 == null || !(떀.딳() == obj1.딳())) && !(떀.딸() != obj0))
          ++num;
      }
      return num;
    }

    public int 땃([In] string obj0)
    {
      if (string.IsNullOrEmpty(obj0))
        return 1000;
      int num;
      return !this.딸().TryGetValue(obj0, out num) ? 0 : num;
    }

    public bool 딶([In] string obj0) => this.땃(obj0) > 0;

    public List<Uri> 땽()
    {
      List<Uri> uriList = new List<Uri>();
      foreach (딢.딧 딧 in GlobalAppData.땼().떎())
      {
        if (string.IsNullOrEmpty(딧.땄()) || this.딶(딧.땄()))
          uriList.Add(new Uri("avatar://" + 딧.딧()));
      }
      return uriList;
    }

    public List<Uri> 땋()
    {
      List<Uri> uriList = new List<Uri>();
      foreach (딢.딧 딧 in GlobalAppData.땼().떎())
        uriList.Add(new Uri("avatar://" + 딧.딧()));
      return uriList;
    }

    public List<땓.떀> 땲() => this.딢(true);

    private List<땓.떀> 딢([In] bool obj0)
    {
      List<string> stringList = new List<string>();
      foreach (딢.땥 땥 in GlobalAppData.땼().땭())
      {
        if (!Object.op_Equality((Object) 땥.떂(), (Object) null) && !string.IsNullOrEmpty(땥.땄()))
        {
          int num = this.땃(땥.땄());
          for (int index = 0; index < num; ++index)
            stringList.Add(땥.딧());
        }
      }
      stringList.Add(this.땝());
      bool flag = false;
      List<땓.떀> 떀List = new List<땓.떀>();
      // ISSUE: reference to a compiler-generated method
      foreach (땓.떀 떀 in this.딥())
      {
        int index = stringList.IndexOf(떀.떔());
        if (index != -1)
        {
          stringList.RemoveAt(index);
          if (string.IsNullOrEmpty(떀.딳()))
          {
            떀.딥();
            flag = true;
          }
          떀List.Add(떀.땳());
        }
      }
      for (int index = 0; index < stringList.Count; ++index)
      {
        땓.떀 떀 = new 땓.떀(-1, stringList[index]);
        떀List.Add(떀);
        flag = true;
      }
      if (obj0)
      {
        for (int index = 0; index < 떀List.Count; ++index)
          this.딧(떀List[index]);
        if (flag)
          this.땥();
      }
      return 떀List;
    }

    public List<string> 떏()
    {
      List<string> stringList1 = GlobalAppData.땼().땽();
      List<string> stringList2 = new List<string>();
      foreach (string str in stringList1)
      {
        딢.땻 땻 = GlobalAppData.땼().땔(str);
        if (string.IsNullOrEmpty(땻.땄()) || this.딶(땻.땄()))
          stringList2.Add(str);
      }
      return stringList2;
    }

    public List<string> 땼()
    {
      List<string> stringList1 = GlobalAppData.땼().땋();
      List<string> stringList2 = new List<string>();
      foreach (string str in stringList1)
      {
        딢.때 때 = GlobalAppData.땼().딣(str);
        if (string.IsNullOrEmpty(때.땄()) || this.딶(때.땄()))
          stringList2.Add(str);
      }
      return stringList2;
    }

    public void 딧([In] 땓.떀 obj0)
    {
      int index = this.땄(obj0);
      if (index != -1)
      {
        // ISSUE: reference to a compiler-generated method
        this.딥()[index] = obj0.딗();
      }
      else
      {
        // ISSUE: reference to a compiler-generated method
        this.딥().Add(obj0.딗());
      }
    }

    public void 땓([In] string obj0) => this.딟(new Uri(obj0));

    public void 딟([In] Uri obj0) => this.딟(obj0, true);

    public void 딟([In] Uri obj0, [In] bool obj1)
    {
      if (this.딳().Equals((object) obj0))
        return;
      // ISSUE: reference to a compiler-generated method
      this.땄(obj0);
      if (!obj1)
        return;
      this.땥();
    }

    public bool 딟([In] PlayerAchievement obj0)
    {
      int num = 딟.딗.딢(obj0.Id);
      return this.떓().Contains(num);
    }

    public void 땄([In] PlayerAchievement obj0)
    {
      if (Object.op_Equality((Object) obj0, (Object) null) || this.딟(obj0))
        return;
      int num = 딟.딗.딢(obj0.Id);
      this.떓().Add(num);
      this.땺(obj0.FireTeamRewardId);
    }

    public int 딟([In] 딢.땹 obj0)
    {
      int num;
      return !this.딛().TryGetValue(obj0, out num) ? 0 : num;
    }

    public 딟 땄<딟>([In] 딢.땹 obj0)
    {
      int num;
      return !this.딛().TryGetValue(obj0, out num) ? default (딟) : (딟) Enum.ToObject(typeof (딟), num);
    }

    public void 딟([In] 딢.땹 obj0, [In] int obj1, [In] bool obj2)
    {
      this.딛()[obj0] = obj1;
      this.땄(obj2);
    }

    public void 딟([In] 딢.땹 obj0, [In] int obj1) => this.딟(obj0, obj1, false);

    public void 딟<딟>([In] 딢.땹 obj0, [In] 딟 obj1) where 딟 : IConvertible => this.딟(obj0, obj1.ToInt32((IFormatProvider) null), false);

    public void 딧([In] 딢.땹 obj0) => this.딟(obj0, this.딟(obj0) + 1);

    public int 딢([In] 딢.땹 obj0)
    {
      int num = this.딟(obj0) + 1;
      this.딟(obj0, num);
      return num;
    }

    public void 딟([In] 딶.땖 obj0, [In] int obj1, out bool _param3)
    {
      SinglePlayerMissionAsset playerMissionAsset = obj0.땠();
      if (Object.op_Equality((Object) playerMissionAsset, (Object) null))
      {
        _param3 = false;
      }
      else
      {
        int num1 = 딟.딗.딢(playerMissionAsset.Id);
        int index1 = this.딟(num1);
        obj1 = Mathf.Max(this.땁()[index1].BestScore, obj1);
        int num2 = obj0.딱();
        _param3 = num2 > 0 && 땚.딧(playerMissionAsset);
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        dictionary.Add("score", num2.ToString());
        this.딟(obj0, dictionary);
        딟.딦.딟("SPMissionComplete", dictionary);
        this.땁()[index1] = new SinglePlayerMissionScore(num1, obj1, Mathf.Max(this.땁()[index1].BestLevel, num2));
        BuildManifestMissionRewardsData missionRewardsData = GlobalAppData.땼().땉(playerMissionAsset.Id);
        if (missionRewardsData != null)
        {
          int num3 = Mathf.Min(num2, missionRewardsData.Rewards.Length);
          for (int index2 = 0; index2 < num3; ++index2)
            this.땺(missionRewardsData.Rewards[index2].VoucherId);
        }
        else
          Debug.LogError((object) ("Rewards missing for mission " + playerMissionAsset.Id));
      }
    }

    public void 딟([In] 딶.땖 obj0, [In] Dictionary<string, string> obj1) => this.딟(obj0.땠(), (IEnumerable<땓.떀>) obj0.딢(obj0.땂()), obj0.땞(), obj1);

    public void 딟(
      [In] SinglePlayerMissionAsset obj0,
      [In] IEnumerable<땓.떀> obj1,
      [In] VersionedGameData obj2,
      [In] Dictionary<string, string> obj3)
    {
      obj3.Add("mission", obj0.Id);
      obj3.Add("player_level", this.때().ToString());
      if (!obj0.AllowPlayerUnitChoice)
        return;
      int num1 = 0;
      int num2 = 0;
      foreach (땓.떀 떀 in obj1)
      {
        num2 += 떀.딟(obj2);
        ++num1;
      }
      obj3.Add("squad_points", num2.ToString());
      obj3.Add("unit_count", num1.ToString());
    }

    private int 딟([In] int obj0)
    {
      int index = 0;
      while (index < this.땁().Count && this.땁()[index].MissionIdHash != obj0)
        ++index;
      if (index == this.땁().Count)
        this.땁().Add(new SinglePlayerMissionScore());
      return index;
    }

    public void 땺([In] string obj0)
    {
      if (string.IsNullOrEmpty(obj0))
        return;
      this.땻().Add(obj0);
    }

    public int 땥([In] string obj0)
    {
      SinglePlayerMissionScore playerMissionScore = this.딝(obj0);
      return playerMissionScore == null ? 0 : playerMissionScore.BestScore;
    }

    public SinglePlayerMissionScore 딝([In] string obj0) => this.땁().FirstOrDefault<SinglePlayerMissionScore>(new Func<SinglePlayerMissionScore, bool>(new 떇.땉()
    {
      딟 = 딟.딗.딢(obj0)
    }.딟));

    public int 떎([In] string obj0)
    {
      SinglePlayerMissionScore playerMissionScore = this.딝(obj0);
      return playerMissionScore == null ? 0 : playerMissionScore.BestLevel;
    }

    public bool 땢() => this.땁().Count == 0;

    public void 딷()
    {
      if (this.땳() != null && this.땳().땄())
      {
        bool flag = false;
        if (this.땳().딧())
        {
          flag = true;
          if (this.땳().딟 == GlobalAppData.딧().GameSettings.MPTurnBonusVoucherId)
            this.딶(true);
          GlobalAppData.떏().땟();
        }
        else if (((땄.땘) this.땳()).딟 == 딟.땑.땤)
        {
          if (this.땳().딟 == GlobalAppData.딧().GameSettings.MPTurnBonusVoucherId)
            this.딟(딢.땹.딶, 1);
          flag = true;
        }
        else if (((땄.땘) this.땳()).딟 == 딟.땑.딧 || ((땄.땘) this.땳()).딟 == 딟.땑.딦)
        {
          Debug.LogError((object) ("Invalid voucher id : " + this.땳().딟));
          flag = true;
        }
        if (flag)
          this.땻().Remove(this.땳().딟);
        this.딟((땄.땙) null);
        this.땄(false);
      }
      if (this.땳() != null || this.땻().Count <= 0 || !GlobalAppData.떏().땥())
        return;
      this.딟(GlobalAppData.떏().땩(this.땻()[0]));
    }

    [SpecialName]
    public bool 떁() => GlobalAppData.떏().땥() && !this.땟();

    public bool 땄([In] int obj0)
    {
      int num = 0;
      for (int index = 0; index < this.땁().Count; ++index)
      {
        if (this.땁()[index].BestScore > 0 && this.땁()[index].BestLevel > 0)
          ++num;
        if (num > obj0)
          return true;
      }
      return false;
    }

    [SpecialName]
    public bool 땟()
    {
      땄.땣 땣 = GlobalAppData.떏().땄(((딟.땇) GlobalAppData.떏()).땓(), false);
      return 땣.땄() && 땣.딧() && !string.IsNullOrEmpty(땣.딟.딧());
    }

    [SpecialName]
    public bool 땂() => !this.딱() && GlobalAppData.떏().땥() && this.땄(1);

    [SpecialName]
    public bool 딱() => this.딟(딢.땹.땋) > 0;

    [SpecialName]
    public void 땃([In] bool obj0) => this.딟(딢.땹.땋, !obj0 ? 0 : 1, true);

    [SpecialName]
    public int 때() => GlobalAppData.딢().GenericData.땄(this.딣());

    [SpecialName]
    public int 땩()
    {
      int num = this.때();
      if (num < 5)
        return 0;
      return num < 11 ? 1 : 2;
    }

    public void 땠() => this.딧(3);

    public void 딧([In] int obj0)
    {
      foreach (딢.땓 땓 in GlobalAppData.땼().땢())
      {
        int num = 딟.딗.딢(땓.딧());
        int index = this.딟(num);
        this.땁()[index] = new SinglePlayerMissionScore(num, 0, obj0);
      }
    }

    public void 땴()
    {
      딢.땃 땃 = GlobalAppData.땼().딷()[0];
      for (int index1 = 0; index1 < 땃.딝().Length - 1; ++index1)
      {
        int num = 딟.딗.딢(GlobalAppData.땼().떔(땃.딝()[index1]).딧());
        int index2 = this.딟(num);
        this.땁()[index2] = new SinglePlayerMissionScore(num, 0, 1);
      }
    }

    public void 딗()
    {
      if (this.딟(딢.땹.때) > 0)
        return;
      this.딟(딢.땹.때, 1);
      int num = this.때();
      for (int index = 0; index < num; ++index)
        this.땺(GlobalAppData.딢().GenericData.PlayerLevels[index].CoinsToken);
      this.땄(true);
    }

    public bool 딟([In] SinglePlayerMissionAsset obj0)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      떇.땈 땈 = new 떇.땈();
      // ISSUE: reference to a compiler-generated field
      땈.딟 = obj0;
      // ISSUE: reference to a compiler-generated field
      땈.딟 = this;
      // ISSUE: reference to a compiler-generated method
      딢.땃 땃 = GlobalAppData.땼().딷().FirstOrDefault<딢.땃>(new Func<딢.땃, bool>(땈.딟));
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      return 땃 != null && !this.떂(땈.딟.Id) && ((IEnumerable<string>) 땃.딝()).Count<string>(new Func<string, bool>(땈.딟)) == 1;
    }

    private bool 떂([In] string obj0) => this.떎(obj0) > 0;

    public void 딢([In] int obj0)
    {
      떇 떇 = this;
      // ISSUE: reference to a compiler-generated method
      떇.딶(떇.땔() + obj0);
    }

    [CompilerGenerated]
    [SpecialName]
    public 땄.땙 땳() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] 땄.땙 obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public List<string> 땻() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public List<int> 떓() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public Dictionary<딢.땹, int> 딛() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public int 딣() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public int 땔() => this.딧;

    [CompilerGenerated]
    [SpecialName]
    public List<SinglePlayerMissionScore> 땁() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public List<딮> 땷() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public Dictionary<string, int> 딸() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public DateTime 땘() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public string 떔() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public Uri 딳() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public string 땝() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public void 딦([In] string obj0) => this.땄 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public bool 땹() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딶([In] bool obj0) => this.딟 = obj0;
  }
}
