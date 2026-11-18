// Decompiled with JetBrains decompiler
// Type: PassAndPlayScreen1Handler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Gui3D/Screens/Pass and Play")]
public class PassAndPlayScreen1Handler : BaseMenuHandler
{
  public Transform panelStart;
  public Transform panelEnd;
  private bool 딟;
  private bool 땄 = true;
  private bool 딧 = true;
  private bool 딢;
  private List<딢.딳.땝> 딟 = new List<딢.딳.땝>();
  private List<PassAndPlayActiveGameHandler> 딟 = new List<PassAndPlayActiveGameHandler>();
  public Camera IntroCamera;
  public PassAndPlayNewGameConfirmHandler PassAndPlayNewGamePanel;
  public GuiScrollList3D MatchList;
  public Transform HeaderTextPrefab;
  public PassAndPlayActiveGameHandler ActiveGameButtonPrefab;
  public Transform InProgressDividerPrefab;
  public ToolTipHandler PassAndPlayToolTipPrefab;
  public ToolTipHandler NewGameToolTipPrefab;
  public ToolTipHandler GameStatusToolTipPrefab;
  public FrontendHub Hub;

  private void Start() => base.딟 = ((Component) this).transform.position;

  private void StartLoadingMatches()
  {
    this.땄 = true;
    this.딟.Clear();
    for (int index = 0; index < 16; ++index)
    {
      딢.딳.땝 땝 = 딢.딳.땄(index);
      if (땝 != null)
        this.딟.Add(땝);
    }
  }

  private void FinishLoadingMatches()
  {
    this.MatchList.RemoveAll(true);
    this.MatchList.AddItem(Object.Instantiate((Object) this.HeaderTextPrefab) as Transform, 0.034375f);
    int num = 0;
    for (int index = 0; index < this.딟.Count; ++index)
    {
      딶.땖 GameState = this.딟[index].딟();
      if (GameState != null && !GameState.떔().딢(GameState))
      {
        ++num;
        PassAndPlayActiveGameHandler activeGameHandler = Object.Instantiate((Object) this.ActiveGameButtonPrefab) as PassAndPlayActiveGameHandler;
        activeGameHandler.Init(GameState);
        activeGameHandler.OkButton.set_CustomPressFunc("OnContinueGame");
        activeGameHandler.OkButton.set_CustomPressValue((object) GameState);
        this.MatchList.AddItem(((Component) activeGameHandler).transform, 0.346875f);
        this.딟.Add(activeGameHandler);
      }
    }
  }

  private void Update()
  {
    if (!((딟.딗) GlobalAppData.땼()).땽())
    {
      if (this.딟)
      {
        this.딟 = false;
        this.StartLoadingMatches();
      }
      else if (this.땄)
      {
        this.땄 = false;
        this.FinishLoadingMatches();
      }
    }
    if (this.딧)
    {
      foreach (PassAndPlayActiveGameHandler activeGameHandler in this.딟)
      {
        if (activeGameHandler.LoadingComplete)
          this.딧 = false;
      }
    }
    if (this.딧 || this.딢)
      return;
    this.MatchList.UpdateItemClipping();
    this.딢 = true;
  }

  private void OnButtonPressed(string Command)
  {
    if (((딟.딗) GlobalAppData.땼()).땽())
      return;
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (PassAndPlayScreen1Handler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      PassAndPlayScreen1Handler.딟 = new Dictionary<string, int>(3)
      {
        {
          "Back",
          0
        },
        {
          "SinglePlayer",
          1
        },
        {
          "NewGame",
          2
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!PassAndPlayScreen1Handler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        this.DeactivateMenu();
        this.Hub.ChallengeLocationSelectionScreen.ActivateMenu();
        break;
      case 1:
        this.DeactivateMenu();
        this.Hub.ChallengeLocationSelectionScreen.ActivateMenu();
        break;
      case 2:
        if (this.딟.Count == 0)
        {
          딧.땧 LoadingInfo = new 딧.땧(GlobalAppData.딢().Version, 딶.딹.딟);
          LoadingInfo.땄("PassAndPlay");
          this.DeactivateMenu();
          this.Hub.SquadPointSelectionScreen.ActivateMenu(true, LoadingInfo, (BaseMenuHandler) this);
          break;
        }
        (Object.Instantiate((Object) this.PassAndPlayNewGamePanel) as PassAndPlayNewGameConfirmHandler).Init(this, this.Hub.SquadPointSelectionScreen, this.panelStart, this.panelEnd);
        break;
    }
  }

  private void OnContinueGame(딶.땖 GameState)
  {
    if (GameState.떔().딢(GameState))
    {
      딢.딳.땄(GameState);
    }
    else
    {
      this.DeactivateMenu();
      this.Hub.LoadingScreen.ActivateMenu(GameState, true);
    }
  }

  public void ClearMatchList()
  {
    this.딟.Clear();
    this.MatchList.RemoveAll(true);
  }

  public override void ActivateMenu()
  {
    base.ActivateMenu();
    this.MatchList.UpdateItemClipping();
    this.딟 = true;
    this.Hub.MoneyDisplay.UpdateDisplay(true, MoneyDisplayHandler.딤.땥);
    if (!((Component) this.IntroCamera).gameObject.activeInHierarchy)
      return;
    ((Component) this.IntroCamera).gameObject.SetActive(false);
  }

  public override void DeactivateMenu()
  {
    base.DeactivateMenu();
    this.MatchList.UpdateItemClipping();
  }
}
