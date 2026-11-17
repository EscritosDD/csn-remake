// Decompiled with JetBrains decompiler
// Type: SinglePlayerMissionAsset
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class SinglePlayerMissionAsset : ScriptableObject
{
  [딟.땢(AllowBlank = false, IsGameDataUnique = true)]
  public string Id;
  [딟.땢(AllowBlank = false, LinkType = typeof (BuildManifestLevelData))]
  public string LevelId;
  public int ScenarioIndex;
  [딟.땢(AllowBlank = false, LinkType = typeof (BuildManifestAvatarData))]
  public string AIAvatarId;
  public bool ShowWeaponWarning;
  public bool DisableMatchWonEvent;
  public int RecommendedMinUnits;
  public LocalisationEntry Title;
  public LocalisationEntry Description;
  public LocalisationEntry LocalNotificationText;
  public int XPOnLoss = 30;
  public SinglePlayerMissionUnit[] PlayerUnits;
  public bool AllowPlayerUnitChoice;
  public bool AllowAIRecklessAdvance;
  public int AIHandicap;
  public float AIDeployVisibilityFractionLimit = 0.25f;
  public bool AllowAIDeployables = true;
  public int PlayerUnitChoiceSquadPointsTier;
  public 딢.딾 NewUserFlowStartIndex = 딢.딾.딟;
  public string[] AdvertIds;
  public SinglePlayerMissionUnit[] AIUnits;
  public PlayerAchievement ChallengePackCompletionAchievement;
  public int lootDropChance = 50;

  [SpecialName]
  public string 딟() => SinglePlayerMissionAsset.딟(this.Id);

  public static string 딟([In] string obj0) => obj0 + ".save";

  public static string 딟([In] 딢.땓 obj0) => SinglePlayerMissionAsset.딟(obj0.딧());

  public List<딟.땩> 땄()
  {
    List<딟.땩> 땩List = GlobalAppData.땼().딟(this.LevelId, 딢.딛.딣.땄 | 딢.딛.딣.딢);
    if (땩List == null)
      return (List<딟.땩>) null;
    foreach (땓.떀 떀 in ((IEnumerable<SinglePlayerMissionUnit>) this.PlayerUnits).Select<SinglePlayerMissionUnit, 땓.떀>((Func<SinglePlayerMissionUnit, 땓.떀>) (obj0 => 딢.딳.땝.딟(obj0))).Concat<땓.떀>(((IEnumerable<SinglePlayerMissionUnit>) this.AIUnits).Select<SinglePlayerMissionUnit, 땓.떀>((Func<SinglePlayerMissionUnit, 땓.떀>) (obj0 => 딢.딳.땝.딟(obj0)))))
      떀.딟(땩List, 땓.땾.딢);
    return 땩List;
  }

  public bool 딧() => GlobalAppData.땼().딟((IEnumerable<딟.땩>) this.땄());
}
