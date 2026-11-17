// Decompiled with JetBrains decompiler
// Type: SinglePlayerMissionBriefingPanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class SinglePlayerMissionBriefingPanelHandler : MonoBehaviour
{
  private MenuAnimatorHandler 딟;
  private SinglePlayerMissionAsset 딟;
  private 딧.땧 딟;
  private GameObject 딟;
  private 딢.딳.땝 딟;
  private bool 딟;
  private LoadingScreenOverlayHandler 딟;
  private bool 땄;
  public GuiText3D MissionTitle;
  public GuiMultiLineText3D MissionDescription;
  public LoadingScreenOverlayHandler LoadingOverlayPrefab;
  public WinLevelDisplayHandler WinLevelsPanelPrefab;
  public GameObject Overlay;

  private void Start()
  {
  }

  public void Init(
    SinglePlayerMissionAsset Mission,
    bool FirstMission,
    Transform StartPoint,
    Transform EndPoint)
  {
    this.딟 = Mission;
    this.땄 = FirstMission;
    this.MissionTitle.LocText = Mission.Title;
    this.MissionTitle.UpdateMesh();
    this.MissionDescription.LocText = Mission.Description;
    this.MissionDescription.UpdateMesh();
    this.딟 = new 딧.땧(GlobalAppData.딢().Version, 딶.딹.땄);
    this.딟.딟(Mission.Id);
    this.딟 = ((Component) this).GetComponent<MenuAnimatorHandler>();
    this.딟.StartPoint = StartPoint;
    this.딟.EndPoint = EndPoint;
    this.딟 = Object.Instantiate((Object) this.Overlay, new Vector3(0.0f, 0.9f, 0.0f), Quaternion.identity) as GameObject;
  }

  private void Update()
  {
    if (this.딟 == null || !this.딟.땄())
      return;
    this.딟.Close();
    딶.땖 GameToLoad = this.딟.딟();
    this.딟 = (딢.딳.땝) null;
    this.딟.GetComponent<MenuOverlayHandler>().Close();
    this.딟.Close();
    FrontendHub.딟.LoadingScreen.ActivateMenu(GameToLoad, true);
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (SinglePlayerMissionBriefingPanelHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      SinglePlayerMissionBriefingPanelHandler.딟 = new Dictionary<string, int>(3)
      {
        {
          "Close",
          0
        },
        {
          "Play",
          1
        },
        {
          "WinConditions",
          2
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!SinglePlayerMissionBriefingPanelHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        this.Close();
        break;
      case 1:
        딢.땚.땃(this.딟);
        if (this.딟.AllowPlayerUnitChoice)
        {
          딧.땧 땧 = new 딧.땧(GlobalAppData.딢().Version, 딶.딹.땄);
          땧.딟(this.딟.Id);
          땧.땄(this.딟.PlayerUnitChoiceSquadPointsTier);
          땧.딟(딢.땚.딟(this.딟));
        }
        else
        {
          this.딟 = 딢.딳.땄(this.딟);
          if (this.딟 != null && !this.딟)
          {
            this.딟 = Object.Instantiate((Object) this.LoadingOverlayPrefab, new Vector3(0.0f, 2.2f, 0.0f), Quaternion.identity) as LoadingScreenOverlayHandler;
            this.딟 = true;
          }
        }
        if (!this.땄)
          break;
        딟.딦.딟("StartedFirstSPMission");
        break;
      case 2:
        Object.Instantiate((Object) this.WinLevelsPanelPrefab);
        break;
    }
  }

  public void Close()
  {
    if (Object.op_Inequality((Object) this.딟, (Object) null))
      this.딟.GetComponent<MenuOverlayHandler>().Close();
    this.딟.Close();
  }
}
