// Decompiled with JetBrains decompiler
// Type: PlayerInformationVersusBar
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using UnityEngine;

public class PlayerInformationVersusBar : MonoBehaviour
{
  public PlayerInfoData PlayerOneInfo;
  public PlayerInfoData PlayerTwoInfo;
  public GuiText3D AdditionalUseTextbox;
  public GameObject VsImage;
  public GameObject AdditionalUseImage;
  public LocalisationEntry AINameLocText;
  public LocalisationEntry PlayerNameLocText;

  public void InitailisePlayerInformationBar(
    딶.땖 State,
    int LocalTeamIdx,
    int EnemyTeamIndex,
    bool ShowAlternateInfo,
    Material Team1Avatar,
    Material Team2Avatar,
    bool ShowOppositionInfo)
  {
    if (State == null)
      return;
    this.PlayerOneInfo.땓(false);
    this.InitPlayerInfo(State, this.PlayerOneInfo, LocalTeamIdx, Team1Avatar);
    if (!ShowAlternateInfo && ShowOppositionInfo)
    {
      this.PlayerTwoInfo.땓(true);
      this.InitPlayerInfo(State, this.PlayerTwoInfo, EnemyTeamIndex, Team2Avatar);
    }
    else
      this.PlayerTwoInfo.딧(false);
    this.VsImage.SetActive(!ShowAlternateInfo);
    ((Component) this.AdditionalUseTextbox).gameObject.SetActive(ShowAlternateInfo && ShowOppositionInfo);
    this.AdditionalUseImage.SetActive(ShowAlternateInfo && ShowOppositionInfo);
  }

  private void Update()
  {
    this.PlayerOneInfo.딟();
    this.PlayerTwoInfo.딟();
  }

  private void InitPlayerInfo(
    딶.땖 State,
    PlayerInfoData PlayerData,
    int TeamIdx,
    Material TeamAvatarImg)
  {
    PlayerData.TeamIndex = TeamIdx;
    PlayerData.GameState = State;
    this.SetPlayerAvatarImage(State, PlayerData, TeamIdx, TeamAvatarImg);
    this.SetPlayerProfileLevelTextbox(State, PlayerData, TeamIdx);
    this.SetPlayerNameTextbox(State, PlayerData, TeamIdx);
  }

  public void SetPlayerAvatarImage(
    딶.땖 State,
    PlayerInfoData PlayerData,
    int TeamIdx,
    Material TeamAvatarImg)
  {
    if (Object.op_Inequality((Object) PlayerData.AvatarImg, (Object) null))
    {
      if (Object.op_Inequality((Object) TeamAvatarImg, (Object) null))
      {
        PlayerData.AvatarImg.SetActive(true);
        PlayerData.AvatarImg.renderer.material = TeamAvatarImg;
        if (Object.op_Inequality((Object) PlayerData.AvatarImgLoadingSpinner, (Object) null))
          PlayerData.AvatarImgLoadingSpinner.SetActive(false);
        PlayerData.딟(false);
      }
      else
      {
        PlayerData.AvatarImg.SetActive(false);
        if (Object.op_Inequality((Object) PlayerData.AvatarImgLoadingSpinner, (Object) null))
          PlayerData.AvatarImgLoadingSpinner.SetActive(true);
        switch (State.떓())
        {
          case 딶.딹.딟:
            PlayerData.딟(GlobalAppData.땽().딳());
            break;
          case 딶.딹.땄:
            Uri uri = GlobalAppData.땽().딳();
            if (TeamIdx == 1)
            {
              SinglePlayerMissionAsset playerMissionAsset = State.땠();
              if (Object.op_Inequality((Object) playerMissionAsset, (Object) null))
                uri = 땓.땶.딟(playerMissionAsset.AIAvatarId);
            }
            PlayerData.딟(uri);
            break;
          case 딶.딹.딧:
            string str = State.딟.땄[TeamIdx];
            if (PlayerData.땄() == null)
              PlayerData.딟(GlobalAppData.떏().땄(str, false));
            PlayerData.딟(true);
            break;
        }
      }
    }
    if (!Object.op_Inequality((Object) PlayerData.AvatarImgBackground, (Object) null))
      return;
    PlayerData.AvatarImgBackground.renderer.material.color = TeamIdx != 0 ? GlobalAppData.딟.GameAssets.Red : GlobalAppData.딟.GameAssets.Blue;
    PlayerData.AvatarImgBackground.SetActive(true);
  }

  public void SetPlayerProfileLevelTextbox(딶.땖 State, PlayerInfoData PlayerData, int TeamIdx)
  {
    if (Object.op_Equality((Object) PlayerData.PlayerLevelBackground, (Object) null) || Object.op_Equality((Object) PlayerData.ProfileLevelTextbox, (Object) null))
      return;
    int num = 0;
    switch (State.떓())
    {
      case 딶.딹.딟:
        num = GlobalAppData.땽().때();
        break;
      case 딶.딹.땄:
        PlayerData.PlayerLevelBackground.SetActive(TeamIdx == 0);
        num = GlobalAppData.땽().때();
        break;
      case 딶.딹.딧:
        PlayerData.땄(true);
        break;
    }
    PlayerData.ProfileLevelTextbox.Text = num.ToString();
    PlayerData.ProfileLevelTextbox.UpdateMesh();
  }

  public void SetPlayerNameTextbox(딶.땖 State, PlayerInfoData PlayerData, int TeamIdx)
  {
    if (Object.op_Equality((Object) PlayerData.NameTextbox, (Object) null))
      return;
    switch (State.떓())
    {
      case 딶.딹.딟:
        PlayerData.딟(GlobalAppData.떏().땄(((딟.땇) GlobalAppData.떏()).땓(), false));
        break;
      case 딶.딹.땄:
        if (TeamIdx == 0)
        {
          if (GlobalAppData.떏().땥())
            PlayerData.딟(GlobalAppData.떏().땄(((딟.땇) GlobalAppData.떏()).땓(), false));
          else
            PlayerData.NameTextbox.LocText = this.PlayerNameLocText;
        }
        else
          PlayerData.NameTextbox.LocText = this.AINameLocText;
        PlayerData.NameTextbox.UpdateMesh();
        break;
      case 딶.딹.딧:
        PlayerData.딟(GlobalAppData.떏().땄(State.딟.땄[TeamIdx], false));
        break;
    }
    ((Component) PlayerData.NameTextbox).gameObject.SetActive(true);
  }
}
