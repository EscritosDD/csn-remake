// Decompiled with JetBrains decompiler
// Type: ChallengeNodeHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using 딢;

public class ChallengeNodeHandler : MonoBehaviour
{
  private 떉 딟;
  private MissionSelectionPopupHandler 딟;
  private GameObject 딟;
  private GameObject 땄;
  private GameObject 딧;
  private GameObject 딢;
  private int 딟;
  public GameObject CurrentMissionIcon;
  public GameObject LockIcon;
  public GameObject[] CompletionIcons;
  public GameObject LockedMissionNode;
  public float ScrollerOffset;
  public MissionSelectionPopupHandler MissionPopupPrefab;

  public void Init(int Index) => this.딟 = Index;

  private void Start()
  {
    땵 땵 = FrontendHub.딟.ChallengeMissionMapScreen.get_ChallengePackLoader();
    this.딟 = ((IEnumerable<떉>) 땵.딢()).FirstOrDefault<떉>((Func<떉, bool>) (M => M.땄() == this.딟));
    this.SetMissionNodeState(땵.땃());
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (ChallengeNodeHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      ChallengeNodeHandler.딟 = new Dictionary<string, int>(1)
      {
        {
          "Play",
          0
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!ChallengeNodeHandler.딟.TryGetValue(key, out num) || num != 0)
      return;
    this.ActivatePopup();
  }

  public void ActivatePopup()
  {
    this.딟 = Object.Instantiate((Object) this.MissionPopupPrefab) as MissionSelectionPopupHandler;
    this.딟.Init(this.딟.딧().Id);
  }

  private void SetMissionNodeState(int CurrentProgress)
  {
    if (CurrentProgress + 1 == this.딟.땄())
    {
      this.SetNodeState(떄.딟);
      this.SetMedalState(false);
    }
    else if (CurrentProgress + 1 > this.딟.땄())
    {
      if (FrontendHub.딟.ChallengeMissionMapScreen.get_ChallengePackLoader().딢()[this.딟.땄()].딟() == 3)
        this.SetNodeState(떄.딢);
      else
        this.SetNodeState(떄.딧);
      this.SetMedalState(true);
    }
    else
    {
      this.SetNodeState(떄.땄);
      this.SetMedalState(false);
    }
  }

  private void SetNodeState(떄 State)
  {
    if (딢.딳.땝.딧(GlobalAppData.땼().때(this.딟.딧().Id)))
    {
      this.SetNode(3);
    }
    else
    {
      GuiButton3D component = ((Component) this).GetComponent<GuiButton3D>();
      switch (State)
      {
        case 떄.딟:
          this.SetCurrentMissionIconState(true);
          this.SetLockIconState(false);
          component.Disabled = false;
          this.SetNode(0);
          break;
        case 떄.땄:
          this.SetCurrentMissionIconState(false);
          this.SetLockIconState(true);
          component.Disabled = true;
          this.DisplayLockedNode();
          break;
        case 떄.딧:
          this.SetCurrentMissionIconState(false);
          this.SetLockIconState(false);
          component.Disabled = false;
          this.SetNode(0);
          break;
        case 떄.딢:
          this.SetCurrentMissionIconState(false);
          this.SetLockIconState(false);
          component.Disabled = false;
          this.SetNode(1);
          break;
      }
    }
  }

  private void DisplayLockedNode()
  {
    GameObject gameObject = Object.Instantiate((Object) this.LockedMissionNode) as GameObject;
    gameObject.transform.parent = ((Component) this).transform;
    gameObject.transform.localPosition = Vector3.zero;
  }

  private void SetCurrentMissionIconState(bool Display)
  {
    if (Object.op_Inequality((Object) this.딧, (Object) null))
    {
      Object.Destroy((Object) this.딧);
      this.딧 = (GameObject) null;
    }
    if (!Display)
      return;
    this.딧 = Object.Instantiate((Object) this.CurrentMissionIcon) as GameObject;
    this.딧.transform.parent = ((Component) this).transform;
    this.딧.transform.localPosition = Vector3.zero;
  }

  private void SetNode(int Index)
  {
    if (Object.op_Inequality((Object) this.딟, (Object) null))
    {
      Object.Destroy((Object) this.딟);
      this.딟 = (GameObject) null;
    }
    LevelIconHandler levelIconHandler1 = ((IEnumerable<LevelIconHandler>) FrontendHub.딟.ChallengeMissionMapScreen.LevelIcons).FirstOrDefault<LevelIconHandler>((Func<LevelIconHandler, bool>) (M => M.LevelID == this.딟.딧().LevelId));
    if (!Object.op_Inequality((Object) levelIconHandler1, (Object) null))
      return;
    LevelIconHandler levelIconHandler2 = Object.Instantiate((Object) levelIconHandler1) as LevelIconHandler;
    ((Component) levelIconHandler2).transform.parent = ((Component) this).transform;
    ((Component) levelIconHandler2).transform.localPosition = Vector3.zero;
    levelIconHandler2.SetNodeState(Index);
  }

  private void SetMedalState(bool DisplayMedals)
  {
    if (Object.op_Inequality((Object) this.땄, (Object) null))
    {
      Object.Destroy((Object) this.땄);
      this.땄 = (GameObject) null;
    }
    if (!DisplayMedals || this.딟.딟() <= 0)
      return;
    this.땄 = Object.Instantiate((Object) this.CompletionIcons[this.딟.딟() - 1]) as GameObject;
    this.땄.transform.parent = ((Component) this).transform;
    this.땄.transform.localPosition = Vector3.zero;
  }

  private void SetLockIconState(bool Display)
  {
    if (Object.op_Inequality((Object) this.딢, (Object) null))
    {
      Object.Destroy((Object) this.딢);
      this.딢 = (GameObject) null;
    }
    if (!Display)
      return;
    this.딢 = Object.Instantiate((Object) this.LockIcon) as GameObject;
    this.딢.transform.parent = ((Component) this).transform;
    this.딢.transform.localPosition = Vector3.zero;
  }

  private void OnDestroy()
  {
    this.MissionPopupPrefab = (MissionSelectionPopupHandler) null;
    this.LockedMissionNode = (GameObject) null;
    this.CurrentMissionIcon = (GameObject) null;
    this.LockIcon = (GameObject) null;
  }
}
