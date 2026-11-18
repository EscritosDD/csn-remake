// Decompiled with JetBrains decompiler
// Type: 딢.딛
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Build;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딢
{
  public class 딛 : 딟.딗
  {
    private TacticsBuildManifestDataJson 딟;
    private 딢.딝 딟 = new 딢.딝();
    private 딢.땳 딟 = new 딢.땳();
    private 딢.딱 딟 = new 딢.딱();
    private 딢.떂 딟 = new 딢.떂();
    private 딢.땭 딟 = new 딢.땭();
    private 딢.딦 딟 = new 딢.딦();
    private 딢.땤 딟 = new 딢.땤();
    private 딢.땴 딟 = new 딢.땴();
    private 딢.땺 딟 = new 딢.땺();
    private 딢.땩 딟 = new 딢.땩();
    private 딢.땄 딟 = new 딢.땄();
    private 딢.딶 딟 = new 딢.딶();
    private 딢.딷 딟 = new 딢.딷();
    private 딢.딢 딟 = new 딢.딢();
    private 딧.땮 딟 = new 딧.땮();

    public 딛([In] BuildManifestDataJson obj0, [In] TacticsBuildManifestDataJson obj1, [In] 딟.땻 obj2)
      : base(obj0, obj2)
    {
      this.딟 = obj1;
    }

    public override void 딟()
    {
      base.딟();
      this.땃();
      this.땓();
      this.땺();
      this.딶();
    }

    protected override void 땄()
    {
      this.딟.딟(this.딟.Weapons, base.딟);
      this.딟.딟(this.딟.Outfits, base.딟);
      this.딟.딟(this.딟.Levels, base.딟);
      this.딟.딟(this.딟.Levels, base.딟);
      this.딟.딟(this.딟.Levels, base.딟);
      this.딟.딟(this.딟.Levels, base.딟);
      this.딟.딟(this.딟.VoicePacks, base.딟);
      this.딟.딟(this.딟.Characters, base.딟);
      this.딟.딟(this.딟.GameData, base.딟);
      this.딟.딟(this.딟.Prefabs, base.딟);
      this.딟.딟(this.딟.Avatars, base.딟);
      this.딟.딟(this.딟.Challenges, base.딟);
      this.딟.딟(this.딟.MapPacks, base.딟);
      this.딟.딟(this.딟.ChallengePacks, base.딟);
      this.딟.딟(this.딟.AtlasPacks, base.딟);
      // ISSUE: reference to a compiler-generated method
      this.딧(this.딟.MaxConcurrentGames);
      // ISSUE: reference to a compiler-generated method
      this.땈(this.딟.AppStoreURL);
      // ISSUE: reference to a compiler-generated method
      this.땞(this.딟.FacebookPostUrlNaCl);
    }

    protected override void 딢()
    {
      this.땃();
      this.땓();
      this.땺();
      this.딶();
    }

    protected override void 딧()
    {
      this.딟.딟();
      ((딢.땂<딢.때, UnitOutfit, BuildManifestOutfitData>) this.딟).딟();
      this.딟.딟();
      this.딟.딟();
      this.딟.딟();
      this.딟.딟();
      this.딟.딟();
      this.딟.딟();
      this.딟.딟();
      this.딟.딟();
      this.딟.딟();
      this.딟.딟();
      this.딟.딟();
      this.딟.딟();
      this.딟.딟();
    }

    public override void 딟([In] List<딟.땩> obj0)
    {
      int num = 0 + this.딟<딢.땻>((IEnumerable<딢.땻>) this.딟.딧(), obj0) + this.딟<딢.때>((IEnumerable<딢.때>) this.딟.딧(), obj0) + this.딟<딢.땢>((IEnumerable<딢.땢>) this.딟.딧(), obj0) + this.딟<딢.땼>((IEnumerable<딢.땼>) this.딟.딧(), obj0) + this.딟<딢.땲>((IEnumerable<딢.땲>) this.딟.딧(), obj0) + this.딟<딢.딗>((IEnumerable<딢.딗>) this.딟.딧(), obj0) + this.딟<딢.땠>((IEnumerable<딢.땠>) this.딟.딧(), obj0) + this.딟<딢.딟>((IEnumerable<딢.딟>) this.딟.딧(), obj0) + this.딟<딢.땃>((IEnumerable<딢.땃>) this.딟.딧(), obj0);
    }

    protected override void 딟([In] Dictionary<string, object> obj0) => this.딟 = 딧.땾.딟<TacticsBuildManifestDataJson>((object) obj0);

    public void 땃() => this.딟.딟(this);

    public void 딶() => this.딟.딟(this);

    public void 땓() => this.딟.딟(this);

    public void 땺() => this.딟.딟(this);

    public List<딟.땩> 딟([In] string obj0, [In] 딢.딛.딣 obj1)
    {
      딢.땢 땢 = GlobalAppData.땼().땻(obj0);
      if (땢 == null)
        return (List<딟.땩>) null;
      List<딟.땩> 땩List = new List<딟.땩>();
      땩List.Add((딟.땩) 땢);
      if ((obj1 & 딢.딛.딣.딟) != (딢.딛.딣) 0)
      {
        딢.땼 땼 = GlobalAppData.땼().떓(obj0);
        땩List.Add((딟.땩) 땼);
      }
      if ((obj1 & 딢.딛.딣.땄) != (딢.딛.딣) 0)
      {
        딢.떏 떏 = GlobalAppData.땼().딥(obj0);
        땩List.Add((딟.땩) 떏);
      }
      if ((obj1 & 딢.딛.딣.딢) != (딢.딛.딣) 0)
      {
        딢.땲 땲 = GlobalAppData.땼().딛(obj0);
        땩List.Add((딟.땩) 땲);
        딢.땠 땠 = GlobalAppData.땼().땁(땢.땺());
        땩List.Add((딟.땩) 땠);
        딢.딟 딟 = GlobalAppData.땼().땹(땢.땥());
        땩List.Add((딟.땩) 딟);
      }
      return 땩List;
    }

    public bool 땄([In] string obj0, [In] 딢.딛.딣 obj1)
    {
      List<딟.땩> 땩List = this.딟(obj0, obj1);
      return 땩List != null && this.딟((IEnumerable<딟.땩>) 땩List);
    }

    public void 땥()
    {
      foreach (딢.땢 땢 in this.딟.딧())
        땢.딦();
    }

    public bool 딟([In] string obj0) => this.딟.딟(this, obj0);

    public bool 땄([In] string obj0) => this.딟.딟(this, obj0);

    public bool 딧([In] string obj0) => this.딟.딟(this, obj0);

    public bool 딢([In] string obj0) => this.딟.딟(this, obj0);

    public bool 땃([In] string obj0) => this.딟.딟(this, obj0);

    public bool 딶([In] string obj0) => this.딟.딟(this, obj0);

    public bool 땓([In] string obj0) => this.딟.딟(this, obj0);

    public bool 땺([In] string obj0) => this.딟.딟(this, obj0);

    public bool 땥([In] string obj0) => this.딟.딟(this, obj0);

    public bool 딝([In] string obj0) => this.딟.딟(this, obj0);

    public bool 떎([In] string obj0) => this.딟.딟(this, obj0);

    public bool 떂([In] string obj0) => this.딟.딟(this, obj0);

    public bool 땭([In] string obj0) => this.딟.딟(this, obj0);

    public bool 딦([In] string obj0) => this.딟.딟(this, obj0);

    public List<딢.때> 땤([In] string obj0) => this.딟.딟(obj0);

    public UnitWeapon 땽([In] string obj0) => this.딟.땄(obj0);

    public GameObject 땋([In] string obj0) => this.딟.땄(obj0);

    public GameObject 땲([In] string obj0) => this.딟.땄(obj0);

    public UnitOutfit 떏([In] string obj0) => this.딟.땄(obj0);

    public UnitVoicePack 땼([In] string obj0) => this.딟.땄(obj0);

    public UnitClass 땢([In] string obj0) => this.딟.땄(obj0);

    public LocalisationEntry 딷([In] string obj0) => this.딟.땄(obj0);

    public VersionedGameData 떁([In] string obj0) => this.딟.땄(obj0);

    public 딢.땽 땟([In] string obj0) => this.딟.땄(obj0);

    public PlayerAvatar 땂([In] string obj0) => this.딟.땄(obj0);

    public 딢.떁 딱([In] string obj0) => this.딟.땄(obj0);

    public SinglePlayerMissionAsset 때([In] string obj0) => this.딟.땄(obj0);

    public ChallengePackAsset 땩([In] string obj0) => this.딟.땄(obj0);

    public string 땠([In] string obj0) => this.딟.딟(obj0)?.땓();

    public string 땴([In] string obj0) => this.딟.딟(obj0)?.땺();

    public string 딗([In] string obj0) => this.딟.딟(obj0)?.땥();

    public string 땳([In] string obj0) => this.딟.딟(obj0)?.딝();

    public VersionedGameData 딟([In] int obj0)
    {
      foreach (딢.떎 떎 in this.딟.딧())
      {
        if (떎.땓().Version == obj0)
          return 떎.땓();
      }
      return (VersionedGameData) null;
    }

    public string 딝()
    {
      int index = Random.Range(0, this.딟.딧().Count);
      return this.딟.딧()[index].딧();
    }

    [SpecialName]
    public ReadOnlyCollection<딢.딧> 떎() => this.딟.딧().AsReadOnly();

    public string 떂()
    {
      int index = Random.Range(0, this.딟.딧().Count);
      return this.딟.딧()[index].딧();
    }

    [SpecialName]
    public ReadOnlyCollection<딢.땥> 땭() => this.딟.딧().AsReadOnly();

    public string 딦()
    {
      List<string> stringList = this.땤();
      if (stringList.Count == 0)
        return (string) null;
      int index = Random.Range(0, stringList.Count);
      return stringList[index];
    }

    public List<string> 땤()
    {
      List<string> stringList = new List<string>();
      foreach (딢.땥 땥 in this.딟.딧())
      {
        if (!string.IsNullOrEmpty(땥.땭()))
          stringList.Add(땥.딧());
      }
      return stringList;
    }

    public List<string> 땽() => this.딟.땄();

    public List<string> 땋() => this.딟.땄();

    public 딢.땢 땻([In] string obj0) => this.딟.딟(obj0);

    public 딢.떏 딥([In] string obj0) => this.딟.딟(obj0);

    public 딢.땼 떓([In] string obj0) => this.딟.딟(obj0);

    public 딢.땲 딛([In] string obj0) => this.딟.딟(obj0);

    public 딢.때 딣([In] string obj0) => ((딢.땂<딢.때, UnitOutfit, BuildManifestOutfitData>) this.딟).딟(obj0);

    public 딢.땻 땔([In] string obj0) => this.딟.딟(obj0);

    public 딢.땠 땁([In] string obj0) => this.딟.딟(obj0);

    public 딢.딗 땷([In] string obj0) => this.딟.딟(obj0);

    public 딢.땥 딸([In] string obj0) => this.딟.딟(obj0);

    public 딢.딧 땘([In] string obj0) => this.딟.딟(obj0);

    public 딢.땓 떔([In] string obj0) => this.딟.딟(obj0);

    public 딢.땟 딳([In] string obj0) => this.딟.딟(obj0);

    public 딢.땃 땝([In] string obj0) => this.딟.딟(obj0);

    public string 땄([In] int obj0) => this.딟.딟(obj0);

    public 딢.딟 땹([In] string obj0) => this.딟.딟(obj0);

    [SpecialName]
    public ReadOnlyCollection<딢.땢> 땲() => this.딟.딧().AsReadOnly();

    public List<string> 떏() => this.딟.땄();

    [SpecialName]
    public ReadOnlyCollection<딢.땟> 땼() => this.딟.딧().AsReadOnly();

    [SpecialName]
    public ReadOnlyCollection<딢.땓> 땢() => this.딟.딧().AsReadOnly();

    [SpecialName]
    public ReadOnlyCollection<딢.땃> 딷() => this.딟.딧().AsReadOnly();

    public 딢.땃[] 떇([In] string obj0) => this.딟.딧().Where<딢.땃>(new Func<딢.땃, bool>(new 딢.딛.땔()
    {
      딟 = obj0
    }.딟)).ToArray<딢.땃>();

    public bool 딟([In] 땓.딲 obj0, [In] 땓.땾 obj1)
    {
      List<딟.땩> 땩List = new List<딟.땩>();
      obj0.딟(땩List, obj1);
      return this.땄((IEnumerable<딟.땩>) 땩List);
    }

    public static Dictionary<string, int> 딟([In] List<땓.떀> obj0) => 딢.딛.딟(obj0, (딢.떇) null);

    public static Dictionary<string, int> 딟([In] List<땓.떀> obj0, [In] 딢.떇 obj1)
    {
      List<딟.땩> 땩List = new List<딟.땩>();
      foreach (땓.떀 떀 in obj0)
        떀.딟(땩List, 땓.땾.딢);
      Dictionary<string, int> dictionary1 = new Dictionary<string, int>();
      foreach (딟.땩 땩 in 땩List)
      {
        if (땩 != null)
        {
          string key1 = 땩.땄();
          if (!string.IsNullOrEmpty(key1) && (!(땩 is 딢.때) || !dictionary1.ContainsKey(key1)))
          {
            if (dictionary1.ContainsKey(key1))
            {
              Dictionary<string, int> dictionary2;
              string key2;
              (dictionary2 = dictionary1)[key2 = key1] = dictionary2[key2] + 1;
            }
            else
              dictionary1.Add(key1, 1);
          }
        }
      }
      foreach (KeyValuePair<string, int> keyValuePair in dictionary1)
      {
        if (obj1 != null && obj1.땃(keyValuePair.Key) < keyValuePair.Value)
          Debug.LogError((object) ("Not enough valid inventory for item: " + keyValuePair.Key));
      }
      return dictionary1;
    }

    public BuildManifestMissionRewardsData 땉([In] string obj0) => ((IEnumerable<BuildManifestMissionRewardsData>) this.딟.MissionRewards).FirstOrDefault<BuildManifestMissionRewardsData>(new Func<BuildManifestMissionRewardsData, bool>(new 딢.딛.땁()
    {
      딟 = obj0
    }.딟));

    [CompilerGenerated]
    [SpecialName]
    public string 떁() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public string 땟() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public int 땂() => this.딟;

    [Flags]
    public enum 딣
    {
      딟 = 1,
      땄 = 2,
      딧 = 땄 | 딟, // 0x00000003
      딢 = 4,
      땃 = 65535, // 0x0000FFFF
    }
  }
}
