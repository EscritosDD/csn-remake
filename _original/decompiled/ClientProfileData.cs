// Decompiled with JetBrains decompiler
// Type: ClientProfileData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

[딧.딷]
[Serializable]
public sealed class ClientProfileData
{
  [딧.떁(Name = "Characters")]
  public UnitCharacterData[] Characters = new UnitCharacterData[0];
  [딧.떁(Name = "PlayerXP")]
  public int PlayerXP;
  [딧.떁(Name = "PlayerMPScore")]
  public int PlayerMPScore;
  [딧.떁(Name = "LastModified")]
  public DateTime LastModified;
  [딧.떁(Name = "UserId")]
  public string UserId;
  [딧.떁(Name = "Avatar2")]
  public string Avatar2;
  [딧.떁(Name = "Avatar")]
  public string Avatar;
  [딧.떁(Name = "CommanderId")]
  public string ActiveCommanderId;
  [딧.떁(Name = "ToolTips")]
  public 딢.딮[] ToolTipsWatched = new 딢.딮[0];
  [딧.떁(Name = "Achievements")]
  public int[] UnlockedAchievements = new int[0];
  [딧.떁(Name = "Cookies")]
  public Dictionary<string, int> Cookies = new Dictionary<string, int>();
  [딧.떁(Name = "Inventory")]
  public Dictionary<string, int> Inventory = new Dictionary<string, int>();
  [딧.떁(Name = "Missions")]
  public SinglePlayerMissionScore[] MissionScores = new SinglePlayerMissionScore[0];
  [딧.떁(Name = "Vouchers")]
  public string[] PendingVouchers = new string[0];
}
