// Decompiled with JetBrains decompiler
// Type: ChallengeMissionMapScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ChallengeMissionMapScreenHandler : BaseMenuHandler
{
  private 딢.땃 딟;
  private LoadingScreenOverlayHandler 딟;
  private ChallengeMissionMapHandler 딟;
  private int 딟;
  private bool 딟;
  private bool 땄;
  private CloudCoverLoadingScreen 딟;
  private bool 딧;
  public LoadingScreenOverlayHandler LoadingOverlayPrefab;
  public GuiButton3D BackButton;
  public GuiButton3D QuickPlayButton;
  public GuiText3D QuickPlayButtonText;
  public ChallengePackFriendLabel FriendLabelPrefab;
  public GameObject AddFriendLabel;
  public GuiScrollList3D MapScroller;
  public LocalisationEntry ReturnToWorldScreen;
  public LevelIconHandler[] LevelIcons;
  private bool 딢;

  private void Awake() => base.딟 = ((Component) this).transform.position;

  public override void ActivateMenu()
  {
    base.ActivateMenu();
    GlobalAppData.땼().딝(this.딟.땥());
    GlobalAppData.땼().딧((딟.땩) this.딟);
    this.AddFriendLabel.SetActive(false);
    GlobalAppData.땢().딟();
    FrontendHub.딟.MoneyDisplay.UpdateDisplay(false, MoneyDisplayHandler.딤.땓);
  }

  public void ActivateMenu(
    딢.땃 Pack,
    CloudCoverLoadingScreen CloudCoverInstance,
    bool AutoSelectNextMission)
  {
    this.딢 = true;
    this.딟 = CloudCoverInstance;
    this.딟 = Pack;
    this.딧 = AutoSelectNextMission;
    this.ActivateMenu();
  }

  private void InitialiseMissionMap(GameObject Prefab)
  {
    GameObject gameObject = Object.Instantiate((Object) Prefab) as GameObject;
    gameObject.SetActive(true);
    this.딟 = gameObject.GetComponent<ChallengeMissionMapHandler>();
    this.딟.Init();
    this.MapScroller.AddItem(((Component) this.딟).transform, (float) ((double) this.딟.MissionMapLength * 0.5 / 320.0));
    if (this.get_ChallengePackLoader().땃() >= this.딟.MissionNodes.Length - 1)
      this.MapScroller.SetOffset(this.딟.MissionNodes[0].ScrollerOffset);
    else
      this.MapScroller.SetOffset(this.딟.MissionNodes[this.get_ChallengePackLoader().땃() + 1].ScrollerOffset);
  }

  private void OnErrorLoadingPack()
  {
    Debug.Log((object) "Error loading pack");
    this.CloseLoadingOverlay();
    this.DeactivateMenu();
    FrontendHub.딟.ChallengeLocationSelectionScreen.ActivateMenu();
  }

  private void OnSuccessLoadingPack() => this.땄 = true;

  private void OnVisualsLoaded(GameObject Prefab)
  {
    this.InitialiseMissionMap(Prefab);
    this.InitialisePath();
    this.InitialiseQuickPlayButton();
    this.딟 = true;
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    this.딟.Close(new Action(this.OnCloudsClosed));
  }

  private void OnCloudsClosed()
  {
    this.딢 = false;
    if (!this.딧)
      return;
    if (this.딟 != -1)
      this.딟.MissionNodes[this.딟].ActivatePopup();
    this.딧 = false;
  }

  private void InitialisePath()
  {
    ChallengePathHandler[] challengePaths = this.딟.ChallengePaths;
    int num = this.get_ChallengePackLoader().땃();
    for (int index = 0; index < challengePaths.Length; ++index)
    {
      if (num < index)
        challengePaths[index].SetState(ChallengePathHandler.딙.딟);
      else if (num == index)
        challengePaths[index].SetState(ChallengePathHandler.딙.땄);
      else if (this.get_ChallengePackLoader().딢()[index].딟() == 3 && this.get_ChallengePackLoader().딢()[index + 1].딟() == 3)
        challengePaths[index].SetState(ChallengePathHandler.딙.딧);
      else
        challengePaths[index].SetState(ChallengePathHandler.딙.땄);
    }
  }

  private void OpenLoadingOverlay()
  {
    if (Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    this.딟 = Object.Instantiate((Object) this.LoadingOverlayPrefab) as LoadingScreenOverlayHandler;
  }

  private void CloseLoadingOverlay()
  {
    if (Object.op_Equality((Object) this.딟, (Object) null))
      return;
    this.딟.Close();
    this.딟 = (LoadingScreenOverlayHandler) null;
  }

  private void InitialiseQuickPlayButton()
  {
    this.딟 = this.get_ChallengePackLoader().땃() + 1;
    if (this.딟 == this.get_ChallengePackLoader().딢().Length)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      ChallengeMissionMapScreenHandler.땒 땒 = new ChallengeMissionMapScreenHandler.땒();
      // ISSUE: reference to a compiler-generated field
      땒.딟 = 1;
      // ISSUE: reference to a compiler-generated method
      딢.떉 떉 = ((IEnumerable<딢.떉>) this.get_ChallengePackLoader().딢()).FirstOrDefault<딢.떉>(new Func<딢.떉, bool>(땒.딟));
      if (떉 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ++땒.딟;
        // ISSUE: reference to a compiler-generated method
        떉 = ((IEnumerable<딢.떉>) this.get_ChallengePackLoader().딢()).FirstOrDefault<딢.떉>(new Func<딢.떉, bool>(땒.땄));
      }
      else
      {
        this.딟 = 떉.땄();
        this.QuickPlayButtonText.LocText = this.get_ChallengePackLoader().딢()[this.딟].딧().Title;
      }
      if (떉 == null)
      {
        this.QuickPlayButtonText.LocText = this.ReturnToWorldScreen;
        this.딟 = -1;
      }
      else
      {
        this.딟 = 떉.땄();
        this.QuickPlayButtonText.LocText = this.get_ChallengePackLoader().딢()[this.딟].딧().Title;
      }
    }
    else
      this.QuickPlayButtonText.LocText = this.get_ChallengePackLoader().딢()[this.딟].딧().Title;
    this.QuickPlayButtonText.UpdateMesh();
  }

  private void OnButtonPressed(string Command)
  {
    if (this.딢)
      return;
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (ChallengeMissionMapScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      ChallengeMissionMapScreenHandler.딟 = new Dictionary<string, int>(3)
      {
        {
          "Back",
          0
        },
        {
          "Continue",
          1
        },
        {
          "AddFriend",
          2
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!ChallengeMissionMapScreenHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        this.딟 = (딢.땃) null;
        this.DeactivateMenu();
        FrontendHub.딟.ChallengeLocationSelectionScreen.ActivateMenu();
        break;
      case 1:
        if (this.딟 == -1)
        {
          this.DeactivateMenu();
          FrontendHub.딟.ChallengeLocationSelectionScreen.ActivateMenu();
          break;
        }
        this.딟.MissionNodes[this.딟].ActivatePopup();
        break;
      case 2:
        if (GlobalAppData.떏().땥())
        {
          this.DeactivateMenu();
          FrontendHub.딟.ChallengeFriendScreen.ActivateMenu(ChallengeFriendScreenHandler.땯.딢);
          break;
        }
        FrontendHub.딟.LoginHandler.LoginAttempt(true);
        break;
    }
  }

  private void Update()
  {
    if (!Object.op_Equality((Object) this, (Object) BaseMenuHandler.딟))
      return;
    if (this.get_ChallengePackLoader() != null)
      this.get_ChallengePackLoader().딟();
    else if (this.딟 != null && this.딟.딢())
    {
      // ISSUE: reference to a compiler-generated method
      this.set_ChallengePackLoader(new 딢.땵(this.딟.땓(), new Action(this.OnErrorLoadingPack), new Action(this.OnSuccessLoadingPack)));
    }
    if (this.땄)
    {
      GameObject Prefab = GlobalAppData.땼().땋(this.딟.땥());
      if (Object.op_Inequality((Object) Prefab, (Object) null))
      {
        this.OnVisualsLoaded(Prefab);
        this.땄 = false;
      }
    }
    this.UpdateFriends();
  }

  private void UpdateFriends()
  {
    if (!this.딟 || GlobalAppData.땢().떂())
      return;
    this.딟 = false;
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: reference to a compiler-generated method
    // ISSUE: reference to a compiler-generated method
    // ISSUE: reference to a compiler-generated method
    // ISSUE: reference to a compiler-generated method
    딢.떌[] array = ((IEnumerable<땄.딽>) GlobalAppData.땢().떎()).Select<땄.딽, 딝.땘<땄.딽, FireTeamUserProfileChallengeJsonData>>((Func<땄.딽, 딝.땘<땄.딽, FireTeamUserProfileChallengeJsonData>>) (f => new 딝.땘<땄.딽, FireTeamUserProfileChallengeJsonData>(f, (f.땃() as 땓.땇).땄(this.get_ChallengePackLoader().땓())))).Where<딝.땘<땄.딽, FireTeamUserProfileChallengeJsonData>>((Func<딝.땘<땄.딽, FireTeamUserProfileChallengeJsonData>, bool>) (obj0 => obj0.땄() != null && obj0.땄().Position != -1)).Select<딝.땘<땄.딽, FireTeamUserProfileChallengeJsonData>, 딢.떌>((Func<딝.땘<땄.딽, FireTeamUserProfileChallengeJsonData>, 딢.떌>) (obj0 => new 딢.떌(obj0.딟(), obj0.땄()))).ToArray<딢.떌>();
    if (array.Length == 0)
    {
      if (this.딟 + 1 >= this.딟.MissionNodes.Length)
        return;
      this.AddFriendLabel.SetActive(true);
    }
    else
    {
      foreach (IGrouping<int, 딢.떌> source in ((IEnumerable<딢.떌>) array).GroupBy<딢.떌, int>((Func<딢.떌, int>) (obj0 => obj0.딢().Position)).ToArray<IGrouping<int, 딢.떌>>())
      {
        if (source.Key >= 0 && source.Key < this.딟.MissionNodes.Length)
        {
          ChallengePackFriendLabel challengePackFriendLabel = Object.Instantiate((Object) this.FriendLabelPrefab) as ChallengePackFriendLabel;
          ChallengeNodeHandler missionNode = this.딟.MissionNodes[source.Key];
          ((Component) challengePackFriendLabel).transform.parent = ((Component) missionNode).transform;
          ((Component) challengePackFriendLabel).transform.localPosition = new Vector3(0.0f, 0.2f, 0.0f);
          challengePackFriendLabel.Init(source.ToArray<딢.떌>());
        }
      }
    }
  }

  private void DestroyMap() => this.MapScroller.Reset();

  public override void DeactivateMenu()
  {
    base.DeactivateMenu();
    this.DestroyMap();
    // ISSUE: reference to a compiler-generated method
    this.set_ChallengePackLoader((딢.땵) null);
    this.땄 = false;
  }

  private void OnDestroy() => this.LevelIcons = (LevelIconHandler[]) null;

  [CompilerGenerated]
  [SpecialName]
  public 딢.땵 get_ChallengePackLoader() => this.딟;
}
