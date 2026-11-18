// Decompiled with JetBrains decompiler
// Type: TallyRematchScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class TallyRematchScreenHandler : TallyBaseScreenHandler
{
  public FakeLoadingScreen LoadingScreen;
  private new bool 딟;
  private new bool 땄 = true;
  private bool 딧;
  public Transform RematchButton;

  public override void PreInitailiseTallyScreenData()
  {
    this.ShowEventDrivenMessagingPopup();
    this.SaveXP(out this.딧);
    this.UpdatePlayerInfoBar(false, true);
    this.SetRematchButtonVisibleState();
  }

  private void SetRematchButtonVisibleState()
  {
    if (base.딟.떓() == 딶.딹.땄 && 땺.땃.딟(base.딟) == 0)
      ((Component) this.RematchButton).gameObject.SetActive(false);
    else
      ((Component) this.RematchButton).gameObject.SetActive(true);
  }

  public override void InitailiseScreenData()
  {
    this.InitialiseTallyScreenData(false, false, false, true, false);
    this.AskForReview();
  }

  private void Update()
  {
    if (!this.딟)
      return;
    딢.딳.땝 땝 = 딢.딳.땄(base.딟.땠());
    if (!땝.땄())
      return;
    this.딟 = false;
    딶.땖 GameToLoad = 땝.딟();
    if (GameToLoad == null)
      Debug.Log((object) "Game State is null");
    else
      this.LoadingScreen.ActivateMenu(GameToLoad, true);
  }

  private void OnButtonPressed(string Command)
  {
    if (!base.딟)
      return;
    this.SetReturnToMainMenuScreen();
    string key = Command;
    if (key != null)
    {
      // ISSUE: reference to a compiler-generated field
      if (TallyRematchScreenHandler.딟 == null)
      {
        // ISSUE: reference to a compiler-generated field
        TallyRematchScreenHandler.딟 = new Dictionary<string, int>(2)
        {
          {
            "Quit",
            0
          },
          {
            "Rematch",
            1
          }
        };
      }
      int num;
      // ISSUE: reference to a compiler-generated field
      if (TallyRematchScreenHandler.딟.TryGetValue(key, out num) && num != 0 && num == 1)
      {
        this.땄 = false;
        if (base.딟.떓() == 딶.딹.딧)
        {
          딧.땧 땧 = new 딧.땧(GlobalAppData.딢().Version, 딶.딹.딧);
          땧.땄(base.딟.딟.땄[base.땄]);
          GlobalAppData.딟.딟(땧);
          GlobalAppData.딟.딟(GlobalAppState.땊.땺);
        }
        else if (base.딟.떓() == 딶.딹.땄)
        {
          string 딧 = base.딟.딟.딧;
          SinglePlayerMissionAsset playerMissionAsset = GlobalAppData.땃(딧);
          if (playerMissionAsset.AllowPlayerUnitChoice)
          {
            딧.땧 땧 = new 딧.땧(GlobalAppData.딢().Version, 딶.딹.땄);
            땧.딟(딧);
            땧.땄(playerMissionAsset.PlayerUnitChoiceSquadPointsTier);
            GlobalAppData.딟.딟(땧);
            GlobalAppData.딟.딟(GlobalAppState.땊.딝);
          }
          else
            this.딟 = true;
        }
        else if (base.딟.떓() == 딶.딹.딟 && string.IsNullOrEmpty(base.딟.딟.딧))
        {
          딧.땧 땧 = new 딧.땧(GlobalAppData.딢().Version, 딶.딹.딟);
          GlobalAppData.딟.딟(땧);
        }
      }
    }
    base.딟 = false;
    if (this.땄 && this.딧)
      GlobalAppData.딟.딟(GlobalAppState.땊.땤);
    this.SetupChallengePackLoad();
    if (this.딟)
      return;
    this.ExitToFrontEnd();
  }

  private void SetReturnToMainMenuScreen() => GlobalAppData.딟.딟(GlobalAppState.땊.떂);
}
