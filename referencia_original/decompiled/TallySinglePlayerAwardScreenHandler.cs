// Decompiled with JetBrains decompiler
// Type: TallySinglePlayerAwardScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using 딶;

public class TallySinglePlayerAwardScreenHandler : TallyBaseScreenHandler
{
  private new int 딟;
  public SingleMissionAwardData BronzeAwardData;
  public SingleMissionAwardData SilverAwardData;
  public SingleMissionAwardData GoldAwardData;
  private Vector3 딟;
  public TallySinglePlayerXPScreenHandler SinglePlayerXPScreen;

  public void ActivateSinglePlayerTallyScreen(
    땖 State,
    Vector3 ScreenPos,
    int ActiveTeam,
    int NumberOfAwards)
  {
    if (NumberOfAwards <= 0)
      return;
    this.딟 = ScreenPos;
    this.딟 = NumberOfAwards;
    this.ActivateTallyScreen(State);
    this.BronzeAwardData.딟(1, new SingleMissionAwardData.딜(this.OnAwardAnimationFinish), (SingleMissionAwardData) null, State);
    this.SilverAwardData.딟(2, new SingleMissionAwardData.딜(this.OnAwardAnimationFinish), this.BronzeAwardData, State);
    this.GoldAwardData.딟(3, new SingleMissionAwardData.딜(this.OnAwardAnimationFinish), this.SilverAwardData, State);
    this.BronzeAwardData.딟(((Component) this).gameObject);
  }

  public override void PositionScreenCameraView() => ((Component) this).transform.position = new Vector3((float) this.딟.x, (float) (this.딟.y + 0.5), (float) this.딟.z);

  public void OnAwardAnimationFinish(int AwardIdx)
  {
    if (AwardIdx == this.딟)
      return;
    if (AwardIdx == 1)
      this.SilverAwardData.딟(((Component) this).gameObject);
    else
      this.GoldAwardData.딟(((Component) this).gameObject);
  }

  private void AwardAnimationsComplete()
  {
    this.SkipButton.gameObject.SetActive(false);
    this.OpenNextTallyScreen();
  }

  private void SkipAwardsAnimation()
  {
    this.SkipButton.gameObject.SetActive(false);
    this.BronzeAwardData.땄();
    if (this.딟 > 1)
      this.SilverAwardData.땄();
    if (this.딟 <= 2)
      return;
    this.GoldAwardData.땄();
  }

  private void Update()
  {
    if (!base.딟)
      return;
    this.BronzeAwardData.땃();
    this.SilverAwardData.땃();
    this.GoldAwardData.땃();
    this.UpdateTallyScreenDisplayTimer();
  }

  public override void OpenNextTallyScreen()
  {
    ((Component) this).gameObject.SetActive(false);
    this.DeactivateTallyScreen();
    this.SinglePlayerXPScreen.StartXPFillAnimation();
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (TallySinglePlayerAwardScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      TallySinglePlayerAwardScreenHandler.딟 = new Dictionary<string, int>(2)
      {
        {
          "Continue",
          0
        },
        {
          "Skip",
          1
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!TallySinglePlayerAwardScreenHandler.딟.TryGetValue(key, out num))
      return;
    if (num != 0)
    {
      if (num != 1)
        return;
      this.SkipAwardsAnimation();
    }
    else
      this.OpenNextTallyScreen();
  }
}
