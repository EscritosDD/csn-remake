// Decompiled with JetBrains decompiler
// Type: MissionSelectionPopupHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MissionSelectionPopupHandler : MonoBehaviour
{
  private 딢.떉 딟;
  private SinglePlayerMissionAsset 딟;
  private List<딟.땩> 딟;
  private MenuOverlayHandler 딟;
  private LoadingScreenOverlayHandler 딟;
  private 딢.딳.땝 딟;
  private bool 딟;
  private 땄.딳 딟;
  private 딢.땿 딟 = new 딢.땿();
  private bool 땄;
  private bool 딧;
  private 딶.땖 딟;
  private 딢.딳.땝 땄;
  private 딢.땫 딟;
  private ScoreBoardDisplay 딟;
  public LoadingScreenOverlayHandler LoadingOverlayPrefab;
  public MenuOverlayHandler OverlayPrefab;
  public GuiText3D MissionName;
  public GuiMultiLineText3D MissionDescription;
  public GameObject BackgroundPrefab;
  public GameObject BackgroundAnchor;
  public GameObject[] OpponentDisplayAnchors;
  public GameObject[] WeaponDisplayAnchors;
  public MissionPopupOpponentDisplay OpponentDisplayPrefab;
  public MissionPopupWeaponDisplay WeaponDisplayPrefab;
  public GuiText3D MissionScoreText;
  public GuiText3D MissionScoreTextShadow;
  public GameObject[] CompletionIcons;

  private void Start()
  {
    GameObject gameObject = Object.Instantiate((Object) this.BackgroundPrefab) as GameObject;
    gameObject.transform.parent = this.BackgroundAnchor.transform;
    gameObject.transform.localPosition = Vector3.zero;
    this.딟 = gameObject.GetComponentInChildren<ScoreBoardDisplay>();
  }

  public void Init(string SPMissionId)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    MissionSelectionPopupHandler.땰 땰 = new MissionSelectionPopupHandler.땰();
    // ISSUE: reference to a compiler-generated field
    땰.딟 = SPMissionId;
    ((Component) FrontendHub.딟.ChallengeMissionMapScreen.QuickPlayButton).gameObject.SetActive(false);
    ((Component) FrontendHub.딟.ChallengeMissionMapScreen.QuickPlayButtonText).gameObject.SetActive(false);
    딢.땵 땵 = FrontendHub.딟.ChallengeMissionMapScreen.get_ChallengePackLoader();
    if (Object.op_Equality((Object) this.딟, (Object) null))
    {
      Vector3 position = ((Component) this).gameObject.transform.position;
      ref Vector3 local = ref position;
      local.y = (__Null) (local.y - 0.100000001490116);
      this.딟 = Object.Instantiate((Object) this.OverlayPrefab, position, Quaternion.identity) as MenuOverlayHandler;
    }
    // ISSUE: reference to a compiler-generated method
    this.딟 = ((IEnumerable<딢.떉>) 땵.딢()).FirstOrDefault<딢.떉>(new Func<딢.떉, bool>(땰.딟));
    if (this.딟 == null)
    {
      Debug.Log((object) "Challenge Info is Null");
    }
    else
    {
      this.MissionName.LocText = this.딟.딧().Title;
      this.MissionName.UpdateMesh();
      this.MissionDescription.LocText = this.딟.딧().Description;
      this.MissionDescription.UpdateMesh();
      this.딟 = this.딟.딧();
      this.딟 = this.딟.땄();
      땓.떀[] array = ((IEnumerable<SinglePlayerMissionUnit>) this.딟.AIUnits).Select<SinglePlayerMissionUnit, 땓.떀>((Func<SinglePlayerMissionUnit, 땓.떀>) (obj0 => 딢.딳.땝.딟(obj0))).ToArray<땓.떀>();
      for (int index = 0; index < array.Length; ++index)
      {
        array[index].땠();
        MissionPopupOpponentDisplay popupOpponentDisplay = Object.Instantiate((Object) this.OpponentDisplayPrefab) as MissionPopupOpponentDisplay;
        ((Component) popupOpponentDisplay).transform.parent = this.OpponentDisplayAnchors[index].transform;
        ((Component) popupOpponentDisplay).transform.localPosition = Vector3.zero;
        popupOpponentDisplay.Init(array[index]);
        MissionPopupWeaponDisplay popupWeaponDisplay = Object.Instantiate((Object) this.WeaponDisplayPrefab) as MissionPopupWeaponDisplay;
        ((Component) popupWeaponDisplay).transform.parent = this.WeaponDisplayAnchors[index].transform;
        ((Component) popupWeaponDisplay).transform.localPosition = Vector3.zero;
        popupWeaponDisplay.Init(array[index]);
      }
      // ISSUE: reference to a compiler-generated field
      int num = GlobalAppData.땽().땥(땰.딟);
      this.MissionScoreText.Text = num.ToString();
      this.MissionScoreText.UpdateMesh();
      this.MissionScoreTextShadow.Text = num.ToString();
      this.MissionScoreTextShadow.UpdateMesh();
      // ISSUE: reference to a compiler-generated field
      this.SetCompletionMedal(땰.딟);
      // ISSUE: reference to a compiler-generated field
      this.딟 = GlobalAppData.떏().딶("challenges", 딟.딗.땃(땰.딟));
      this.딟 = new 딢.땫();
      땄.땣 땣 = GlobalAppData.떏().땄(GlobalAppData.땽().떔(), false);
      if (!땣.땄() || 땣.딟 == null)
        return;
      this.딟.딟(땣.딟.땄(), GlobalAppData.땽().떔(), num);
    }
  }

  private void SetCompletionMedal(string ID)
  {
    foreach (GameObject completionIcon in this.CompletionIcons)
      completionIcon.SetActive(false);
    int num = GlobalAppData.땽().떎(ID);
    if (num == 0)
      return;
    for (int index = 0; index < this.CompletionIcons.Length; ++index)
    {
      if (index == num - 1)
      {
        this.CompletionIcons[index].SetActive(true);
        break;
      }
    }
  }

  private void Update()
  {
    this.딟.딟();
    if (!this.땄 && this.딟.땄())
    {
      if (this.IsContentAvailable())
        this.땄 = true;
      else
        this.딟.딟(0.5f);
    }
    if (this.땄)
    {
      if (!this.딧)
      {
        this.땄 = 딢.딳.딟(this.딟);
        this.딧 = true;
      }
      if (!this.get_GameReady())
      {
        if (this.땄 != null)
        {
          if (this.땄.땄())
          {
            this.딟 = this.땄.딟();
            if (this.딟 != null)
            {
              // ISSUE: reference to a compiler-generated method
              this.set_GameReady(true);
            }
          }
        }
        else
        {
          // ISSUE: reference to a compiler-generated method
          this.set_GameReady(true);
        }
      }
    }
    if (this.딟 != null && this.딟.땄())
    {
      this.딟.Close();
      딶.땖 GameToLoad = this.딟.딟();
      this.딟 = (딢.딳.땝) null;
      FrontendHub.딟.ChallengeMissionMapScreen.DeactivateMenu();
      FrontendHub.딟.LoadingScreen.ActivateMenu(GameToLoad, true);
      this.Close();
    }
    if (this.딟 != null)
    {
      if (!this.딟.땄())
        return;
      if (this.딟.딧())
        this.딟.딟(this.딟.딟, 딟.딗.땃(this.딟.딧().Id));
      this.딟 = (땄.딳) null;
    }
    else
    {
      if (this.딟 == null)
        return;
      this.딟.딟();
      if (!this.딟.딢())
        return;
      this.SetupScoreBoardDisplay();
      this.딟 = (딢.땫) null;
    }
  }

  private void Play()
  {
    if (this.딟 != null)
    {
      if (this.딟.떔().딢(this.딟))
      {
        딢.딳.땄(this.딟);
      }
      else
      {
        FrontendHub.딟.LoadingScreen.ActivateMenu(this.딟, true);
        FrontendHub.딟.ChallengeMissionMapScreen.DeactivateMenu();
        this.Close();
      }
    }
    else
    {
      딢.땚.땃(this.딟);
      if (this.딟.AllowPlayerUnitChoice)
      {
        딧.땧 LoadingInfo = new 딧.땧(GlobalAppData.딢().Version, 딶.딹.땄);
        LoadingInfo.딟(this.딟.Id);
        LoadingInfo.땄(this.딟.PlayerUnitChoiceSquadPointsTier);
        LoadingInfo.딟(딢.땚.딟(this.딟));
        FrontendHub.딟.ChallengeMissionMapScreen.DeactivateMenu();
        FrontendHub.딟.CommanderAbilityScreen.TryActivateMenu(딶.땂.딟, LoadingInfo, (BaseMenuHandler) FrontendHub.딟.ChallengeMissionMapScreen);
        this.Close();
      }
      else
      {
        this.딟 = 딢.딳.땄(this.딟);
        if (this.딟 == null || this.딟)
          return;
        this.딟 = Object.Instantiate((Object) this.LoadingOverlayPrefab, new Vector3(0.0f, 2.2f, 0.0f), Quaternion.identity) as LoadingScreenOverlayHandler;
        this.딟 = true;
      }
    }
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (MissionSelectionPopupHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      MissionSelectionPopupHandler.딟 = new Dictionary<string, int>(2)
      {
        {
          "Play",
          0
        },
        {
          "Close",
          1
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!MissionSelectionPopupHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        if (!this.get_GameReady())
          break;
        this.Play();
        break;
      case 1:
        this.Close();
        break;
    }
  }

  private bool IsContentAvailable() => this.딟 != null && GlobalAppData.땼().딟((IEnumerable<딟.땩>) this.딟);

  private void Close()
  {
    ((Component) FrontendHub.딟.ChallengeMissionMapScreen.QuickPlayButton).gameObject.SetActive(true);
    ((Component) FrontendHub.딟.ChallengeMissionMapScreen.QuickPlayButtonText).gameObject.SetActive(true);
    if (Object.op_Inequality((Object) this.딟, (Object) null))
      this.딟.CloseInstantly();
    Object.Destroy((Object) ((Component) this).gameObject);
  }

  private void OnDestroy() => this.BackgroundPrefab = (GameObject) null;

  private void SetupScoreBoardDisplay() => this.딟.Init(this.딟);

  [CompilerGenerated]
  [SpecialName]
  public bool get_GameReady() => this.딢;

  [CompilerGenerated]
  [SpecialName]
  public MissionSelectionPopupHandler.딵 get_State() => this.딟;

  public enum 딵
  {
    딟,
    땄,
    딧,
  }
}
