// Decompiled with JetBrains decompiler
// Type: 딢.딳
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딢
{
  public static class 딳
  {
    public const int 딟 = 16;
    private static 딶.땖 딟;

    public static string 딟([In] int obj0) => obj0 < 0 | obj0 >= 16 ? (string) null : "passandplaygame" + (object) obj0;

    public static 딳.땝 딟([In] SinglePlayerMissionAsset obj0) => 딳.땝.땄(obj0);

    public static 딳.땝 땄([In] int obj0)
    {
      string str = 딳.딟(obj0);
      return str == null ? (딳.땝) null : 딳.땝.딟(str);
    }

    public static 딳.땝 딟([In] 땄.땞 obj0, [In] string[] obj1) => 딳.땝.딟(obj0, obj1);

    public static 딳.땝 딟(
      [In] string obj0,
      [In] int obj1,
      [In] int obj2,
      [In] IEnumerable<땓.떀> obj3,
      [In] Dictionary<string, int> obj4,
      [In] string obj5,
      [In] string obj6,
      [In] string obj7,
      [In] int obj8)
    {
      return 딳.땝.딟(obj0, obj1, obj2, obj3, obj4, obj5, obj6, obj7, obj8);
    }

    public static 딳.땝 딟(
      [In] 땄.땞 obj0,
      [In] IEnumerable<땓.떀> obj1,
      [In] Dictionary<string, int> obj2,
      [In] string[] obj3,
      [In] string obj4)
    {
      return 딳.땝.딟(obj0, obj1, obj2, obj3, obj4);
    }

    public static 딳.땝 땄([In] SinglePlayerMissionAsset obj0) => 딳.땝.딟(obj0);

    public static 딳.땝 딟([In] SinglePlayerMissionAsset obj0, [In] IEnumerable<땓.떀> obj1) => 딳.땝.땄(obj0, obj1);

    public static 딳.땝 딟([In] List<땓.떀> obj0, [In] List<땓.떀> obj1, [In] int obj2, [In] string obj3, [In] int obj4)
    {
      string str = (string) null;
      for (int index = 0; index < 16; ++index)
      {
        str = 딳.딟(index);
        if (str != null && !PlayerPrefs.HasKey(str))
          break;
      }
      return str == null ? (딳.땝) null : 딳.땝.딟(obj0, obj1, obj2, obj3, str, obj4);
    }

    public static void 딟([In] 딶.땖 obj0)
    {
      딳.딟 = obj0;
      Application.LoadLevelAsync(GlobalAppData.딟.EnvSettings.ScenesAsset.Data.딧());
    }

    public static void 딟()
    {
      GlobalAppData.땽().땤();
      딳.땄();
      foreach (딢.땓 땓 in GlobalAppData.땼().땢())
        떇.땄(SinglePlayerMissionAsset.딟(땓));
      떇.땄(떇.딟());
      GlobalAppData.딟(new 떇(true));
    }

    public static void 땄()
    {
      for (int index = 0; index < 16; ++index)
        떇.땄(딳.딟(index));
    }

    public static void 땄([In] 딶.땖 obj0)
    {
      딳.딟 = obj0;
      Application.LoadLevel(GlobalAppData.딟.EnvSettings.ScenesAsset.Data.딢());
    }

    public static 딶.땖 딧()
    {
      딶.땖 딟 = 딳.딟;
      딳.딟 = (딶.땖) null;
      return 딟;
    }

    public class 땝
    {
      private 딶.땶 딟 = new 딶.땶();
      private 딶.땿 딟;
      private string 딟;
      private 딶.딹 딟;

      public static 딳.땝 딟(
        [In] List<땓.떀> obj0,
        [In] List<땓.떀> obj1,
        [In] int obj2,
        [In] string obj3,
        [In] string obj4,
        [In] int obj5)
      {
        if (!GlobalAppData.땼().딟(obj3))
          return (딳.땝) null;
        딳.땝 땝 = new 딳.땝();
        땝.딟 = 딶.딹.딟;
        땝.딟 = obj4;
        땝.딟 = new 딶.땿();
        땝.딟.땄()[0] = new 딶.딙(딶.땖.딟((IEnumerable<땓.떀>) obj0));
        땝.딟.땄()[1] = new 딶.딙(딶.땖.딟((IEnumerable<땓.떀>) obj1));
        땝.딟.딟 = GlobalAppData.딢().Version;
        땝.딟.딧 = 2;
        땝.딟.땄 = obj5;
        땝.딟.땄 = obj3;
        땝.딟.딟 = new string[2];
        땝.딟.딟[0] = "Blue Team";
        땝.딟.딟[1] = "Red Team";
        땝.딟.딢 = obj2;
        return 땝;
      }

      public static 딳.땝 딟([In] SinglePlayerMissionAsset obj0)
      {
        if (obj0.AllowPlayerUnitChoice)
        {
          Debug.LogWarning((object) "Incorrect version of NewSkirmish called");
          return (딳.땝) null;
        }
        if (!GlobalAppData.땼().딟(obj0.LevelId))
          return (딳.땝) null;
        딳.땝.딟(obj0, (IEnumerable<땓.떀>) null);
        딳.땝 땝 = new 딳.땝();
        땝.딟 = 딶.딹.땄;
        땝.딟 = obj0.딟();
        List<땓.떀> 떀List1 = new List<땓.떀>();
        for (int index = 0; index < obj0.PlayerUnits.Length; ++index)
        {
          땓.떀 떀 = 딳.땝.딟(obj0.PlayerUnits[index]);
          떀List1.Add(떀);
        }
        List<땓.떀> 떀List2 = new List<땓.떀>();
        for (int index = 0; index < obj0.AIUnits.Length; ++index)
        {
          땓.떀 떀 = 딳.땝.딟(obj0.AIUnits[index]);
          떀List2.Add(떀);
        }
        땝.딟 = new 딶.땿();
        땝.딟.땄()[0] = new 딶.딙(딶.땖.딟((IEnumerable<땓.떀>) 떀List1));
        땝.딟.땄()[1] = new 딶.딙(딶.땖.딟((IEnumerable<땓.떀>) 떀List2));
        땝.딟.딟 = GlobalAppData.딢().Version;
        땝.딟.딧 = 2;
        땝.딟.땄 = obj0.ScenarioIndex;
        땝.딟.땄 = obj0.LevelId;
        땝.딟.딟 = new string[2];
        땝.딟.딟[0] = "Blue Team";
        땝.딟.딟[1] = "Red Team";
        땝.딟.딧 = obj0.Id;
        땝.딟.딢 = 0;
        땝.딟.땃 = 딳.땝.딢(obj0);
        return 땝;
      }

      private static void 딟([In] SinglePlayerMissionAsset obj0, [In] IEnumerable<땓.떀> obj1)
      {
        땚.땄(obj0);
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        GlobalAppData.땽().딟(obj0, obj1, GlobalAppData.딢(), dictionary);
        딟.딦.딟("StartedSPMission", dictionary);
      }

      public static 딳.땝 땄([In] SinglePlayerMissionAsset obj0, [In] IEnumerable<땓.떀> obj1)
      {
        if (!obj0.AllowPlayerUnitChoice)
        {
          Debug.LogWarning((object) "Incorrect version of NewSkirmish called");
          return (딳.땝) null;
        }
        if (!GlobalAppData.땼().딟(obj0.LevelId))
          return (딳.땝) null;
        딳.땝.딟(obj0, obj1);
        딳.땝 땝 = new 딳.땝();
        땝.딟 = 딶.딹.땄;
        땝.딟 = obj0.딟();
        List<땓.떀> 떀List1 = new List<땓.떀>();
        foreach (땓.떀 떀 in obj1)
          떀List1.Add(떀.딗());
        List<땓.떀> 떀List2 = new List<땓.떀>();
        for (int index = 0; index < obj0.AIUnits.Length; ++index)
        {
          땓.떀 떀 = 딳.땝.딟(obj0.AIUnits[index]);
          떀List2.Add(떀);
        }
        땝.딟 = new 딶.땿();
        땝.딟.땄()[0] = new 딶.딙(딶.땖.딟((IEnumerable<땓.떀>) 떀List1));
        땝.딟.땄()[1] = new 딶.딙(딶.땖.딟((IEnumerable<땓.떀>) 떀List2));
        땝.딟.딟 = GlobalAppData.딢().Version;
        땝.딟.딧 = 2;
        땝.딟.땄 = obj0.ScenarioIndex;
        땝.딟.땄 = obj0.LevelId;
        땝.딟.딟 = new string[2];
        땝.딟.딟[0] = "Blue Team";
        땝.딟.딟[1] = "Red Team";
        땝.딟.딧 = obj0.Id;
        땝.딟.딢 = 0;
        땝.딟.땃 = 딳.땝.딢(obj0);
        return 땝;
      }

      public static 땓.떀 딟([In] SinglePlayerMissionUnit obj0)
      {
        땓.떀 떀 = new 땓.떀(-1, obj0.CharacterId);
        떀.딟(obj0.WeaponId);
        떀.땄(obj0.OutfitId);
        떀.땃(obj0.Name);
        for (int index = 0; index < obj0.CommanderAbilities.Length; ++index)
          떀.떓().Add(obj0.CommanderAbilities[index]);
        return 떀;
      }

      public static 딳.땝 땄([In] SinglePlayerMissionAsset obj0)
      {
        if (!딳.땝.딧(obj0))
          return (딳.땝) null;
        딶.땶 땶 = 딶.땖.땄(obj0.딟());
        if (땶 == null)
          return (딳.땝) null;
        땶.딧 = 2;
        딶.땿 땿 = 딶.땖.딧(obj0.딟());
        if (땿 == null)
          return (딳.땝) null;
        if (!GlobalAppData.땼().딟(땶.땄))
          return (딳.땝) null;
        return new 딳.땝()
        {
          딟 = obj0.딟(),
          딟 = 땶,
          딟 = 땿,
          딟 = 딶.딹.땄
        };
      }

      public static bool 딧([In] SinglePlayerMissionAsset obj0) => PlayerPrefs.HasKey(obj0.딟());

      public static 딳.땝 딟([In] string obj0)
      {
        if (!PlayerPrefs.HasKey(obj0))
          return (딳.땝) null;
        딶.땶 땶 = 딶.땖.땄(obj0);
        if (땶 == null)
          return (딳.땝) null;
        땶.딧 = 2;
        딶.땿 땿 = 딶.땖.딧(obj0);
        if (땿 == null)
          return (딳.땝) null;
        if (!GlobalAppData.땼().딟(땶.땄))
          return (딳.땝) null;
        return new 딳.땝() { 딟 = obj0, 딟 = 땶, 딟 = 땿, 딟 = 딶.딹.딟 };
      }

      public static 딳.땝 딟(
        [In] string obj0,
        [In] int obj1,
        [In] int obj2,
        [In] IEnumerable<땓.떀> obj3,
        [In] Dictionary<string, int> obj4,
        [In] string obj5,
        [In] string obj6,
        [In] string obj7,
        [In] int obj8)
      {
        딶.땶 땶 = new 딶.땶();
        땶.딟 = GlobalAppData.딢().Version;
        땶.딧 = 1;
        땶.땄 = obj0;
        땶.땄 = obj1;
        땶.딟 = new string[2]{ obj5, string.Empty };
        땶.땄 = new string[2]{ obj6, obj7 };
        땶.딧 = (string) null;
        땶.딶 = obj8;
        땶.딢 = obj2;
        땶.땓 = 0;
        if (!GlobalAppData.땼().딟(땶.땄))
          return (딳.땝) null;
        string str = 딶.땖.딟(obj3);
        딶.땿 땿 = new 딶.땿();
        딶.딙 딙 = new 딶.딙(str, DateTime.Now, obj4, new List<딟.떀>());
        땿.땄()[0] = 딙;
        return new 딳.땝()
        {
          딟 = "Online-Pending",
          딟 = 땶,
          딟 = 땿,
          딟 = 딶.딹.딧
        };
      }

      private static bool 딟([In] 땄.땞 obj0, [In] int obj1, [In] 딶.땿 obj2)
      {
        TacticsInitialTurnState initialTurnState = 딧.땾.딟<TacticsInitialTurnState>(obj0.딟[obj1].땃());
        if (initialTurnState == null)
          return false;
        obj2.땄()[obj1] = new 딶.딙(initialTurnState.InitialData, obj0.딟[obj1].땄(), obj0.딟[obj1].딶(), obj0.딟[obj1].땓());
        obj2.딧().Add(new 딶.딙(initialTurnState.TurnData, obj0.딟[obj1].땄(), (Dictionary<string, int>) null, (List<딟.떀>) null));
        return true;
      }

      public static 딳.땝 딟(
        [In] 땄.땞 obj0,
        [In] IEnumerable<땓.떀> obj1,
        [In] Dictionary<string, int> obj2,
        [In] string[] obj3,
        [In] string obj4)
      {
        땓.딿 딟 = obj0.딟 as 땓.딿;
        딶.땶 땶 = new 딶.땶();
        땶.딟 = 딟.딟();
        땶.딧 = 2;
        땶.땄 = GlobalAppData.땼().땄(딟.땄());
        땶.땄 = 딟.딧();
        땶.딟 = obj3;
        땶.땄 = new string[2]{ obj0.딟[0].딧(), obj4 };
        땶.딧 = obj0.딟;
        땶.딢 = 딟.딢();
        땶.딟 = obj0;
        땶.딶 = 딟.딶();
        땶.땓 = obj0.딧;
        if (!GlobalAppData.땼().딟(땶.땄))
          return (딳.땝) null;
        if (obj0.딟 == null)
          return (딳.땝) null;
        string str = 딶.땖.딟(obj1);
        딶.땿 땿 = new 딶.땿();
        for (int index = 0; index < obj0.딧; ++index)
          딳.땝.딟(obj0, index, 땿);
        딶.딙 딙 = new 딶.딙(str, DateTime.Now, obj2, new List<딟.떀>());
        땿.땄()[obj0.딧] = 딙;
        return new 딳.땝()
        {
          딟 = "Online-" + obj0.딟,
          딟 = 땶,
          딟 = 땿,
          딟 = 딶.딹.딧
        };
      }

      public static 딳.땝 딟([In] 땄.땞 obj0, [In] string[] obj1)
      {
        땓.딿 딟 = obj0.딟 as 땓.딿;
        딶.땶 땶 = new 딶.땶();
        땶.딟 = 딟.딟();
        땶.딧 = obj0.딟 + obj0.땄;
        땶.땄 = GlobalAppData.땼().땄(딟.땄());
        땶.땄 = 딟.딧();
        땶.딟 = new string[2]{ string.Empty, string.Empty };
        땶.땄 = new string[2]{ string.Empty, string.Empty };
        땶.딧 = obj0.딟;
        땶.딢 = 딟.딢();
        땶.딶 = 딟.딶();
        땶.딟 = obj0;
        땶.땓 = obj0.딟.Length;
        for (int index = 0; index < obj0.딟.Length && index < 2; ++index)
        {
          string str = obj0.딟[index].딧();
          땶.땄[index] = str;
          땶.딟[index] = obj1[index];
          땶.딟[index] = obj0.딟[index].딢();
        }
        if (!GlobalAppData.땼().딟(땶.땄))
          return (딳.땝) null;
        if (obj0.딟 == null)
          return (딳.땝) null;
        딶.땿 땿 = new 딶.땿();
        if (GlobalAppData.땼().딟(땶.딟).GenericData.PlayFirstTurnImmediately)
        {
          for (int index = 0; index < obj0.딟.Length && index < 2; ++index)
            딳.땝.딟(obj0, index, 땿);
          for (int index = 2; index < obj0.딟.Length; ++index)
            땿.딧().Add(new 딶.딙(obj0.딟[index].땃(), obj0.딟[index].땄(), obj0.딟[index].딶(), obj0.딟[index].땓()));
        }
        else
        {
          for (int index = 0; index < obj0.딟.Length; ++index)
          {
            딶.딙 딙 = new 딶.딙(obj0.딟[index].땃(), obj0.딟[index].땄(), obj0.딟[index].딶(), obj0.딟[index].땓());
            if (index < 2)
              땿.땄()[index] = 딙;
            else
              땿.딧().Add(딙);
          }
        }
        return new 딳.땝()
        {
          딟 = "Online-" + obj0.딟,
          딟 = 땶,
          딟 = 땿,
          딟 = 딶.딹.딧
        };
      }

      public 딶.땖 딟()
      {
        if (((딟.딗) GlobalAppData.땼()).땽())
          return (딶.땖) null;
        if (this.딟.딟 > GlobalAppData.딢().Version)
          return (딶.땖) null;
        땽 땽 = GlobalAppData.땼().땟(this.딟.땄);
        if (땽 == null)
          return (딶.땖) null;
        try
        {
          딶.땖 땖 = new 딶.땖(this.딟, this.딟, this.딟, this.딟, 땽);
          if (땖.떓() == 딶.딹.딧)
          {
            int num = !땖.땞().GenericData.PlayFirstTurnImmediately ? 2 : 0;
            if (땖.딟.땓 > num)
              땖.딟(false, false)?.땄(true);
          }
          return 땖;
        }
        catch (딶.딫 ex)
        {
          return (딶.땖) null;
        }
      }

      private static int 딢([In] SinglePlayerMissionAsset obj0)
      {
        if (GlobalAppData.떏().땥())
        {
          딶.떈 떈 = new 딶.떈((int) Time.realtimeSinceStartup);
          if (떈.딟(0, 100) < obj0.lootDropChance)
          {
            int num = 25;
            for (int index = 0; index < 4; ++index)
            {
              if (떈.딟(0, 100) < num)
                return (index + 1) * 2;
              num += 25;
            }
          }
        }
        return -1;
      }

      [SpecialName]
      public bool 땄() => !((딟.딗) GlobalAppData.땼()).땽();
    }
  }
}
