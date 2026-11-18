// Decompiled with JetBrains decompiler
// Type: TallyGameOverviewScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using 딶;

public class TallyGameOverviewScreenHandler : TallyBaseScreenHandler
{
  public TallyXPScreenHandler XPScreenHandler;
  public TallySinglePlayerXPScreenHandler SinglePlayerXPHandler;
  public GuiParticleEmitter WinnerStarburst;
  public WinnerBoxData[] TeamWinnerBox = new WinnerBoxData[2];
  public GameObject Team1WinnerAvatarGlow;
  public GameObject Team2WinnerAvatarGlow;
  public GuiAnimation WinnerFadeInAnim;
  public Vector3 MaxWinnerBoxScale;
  public GameObject TutorialCommanderShadow;
  public AudioShader2 WinnerStarburstSound;
  private float 딟;
  private float 땄;

  public override void InitailiseScreenData()
  {
    this.InitialiseTallyScreenData(false, false, false, true, false);
    this.TeamWinnerBox[0].딟(this.딧 == base.딟);
    this.TeamWinnerBox[1].딟(this.딧 == base.땄);
    this.Team1WinnerAvatarGlow.SetActive(this.딧 == base.딟);
    this.Team2WinnerAvatarGlow.SetActive(this.딧 == base.땄);
    ((Component) this.WinnerStarburst).transform.localPosition = this.딧 != base.딟 ? this.TeamWinnerBox[1].WinnerBoxParent.transform.localPosition : this.TeamWinnerBox[0].WinnerBoxParent.transform.localPosition;
    this.WinnerFadeInAnim.딟(new GuiAnimation.때(this.OnWinnerFadeAnimUpdateCallback), true);
    this.WinnerFadeInAnim.딟(new GuiAnimation.땂(this.OnWinnerFadeAnimEnd));
    this.WinnerFadeInAnim.딟();
    this.WinnerStarburst.ActivatePaticleEmitter();
    if (Object.op_Inequality((Object) this.WinnerStarburstSound, (Object) null))
    {
      double num = (double) this.WinnerStarburstSound.PlayOneShot(((Component) this).gameObject, 0.0f);
    }
    if (!Object.op_Inequality((Object) this.TutorialCommanderShadow, (Object) null))
      return;
    this.TutorialCommanderShadow.SetActive(false);
  }

  private void OnWinnerFadeAnimUpdateCallback(float CurrentValue)
  {
    if (this.딧 < 0 || this.딧 > 1)
      return;
    this.TeamWinnerBox[this.딧].WinnerBoxParent.transform.localScale = Vector3.op_Multiply(this.MaxWinnerBoxScale, CurrentValue);
  }

  private void OnWinnerFadeAnimEnd() => this.SkipButton.SetActive(false);

  private void SkipAnyActiveTallyScreenAnimations()
  {
    if (this.WinnerFadeInAnim.딧())
      this.WinnerFadeInAnim.딟(true);
    if (!this.WinnerStarburst.get_bPaticleEmitterActive())
      return;
    this.WinnerStarburst.KillParticleEmitter();
  }

  private void Update()
  {
    if (!base.딟)
      return;
    this.WinnerFadeInAnim.땄();
    this.UpdateTallyScreenDisplayTimer();
    this.딟 += Time.deltaTime;
    if ((double) this.딟 <= (double) this.땄 || GlobalAppData.떎())
      return;
    this.StartSubThemePlaying();
  }

  public override void StopAnyTallyScreenSpecificAudio()
  {
    if (!Object.op_Inequality((Object) this.WinnerStarburstSound, (Object) null))
      ;
  }

  public override void OpenNextTallyScreen()
  {
    this.DeactivateTallyScreen();
    if (base.딟.떓() == 딹.땄)
      this.SinglePlayerXPHandler.ActivateTallyScreen(base.딟);
    else
      this.XPScreenHandler.ActivateTallyScreen(base.딟);
    if (GlobalAppData.떎())
      return;
    this.StartSubThemePlaying();
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (TallyGameOverviewScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      TallyGameOverviewScreenHandler.딟 = new Dictionary<string, int>(2)
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
    if (!TallyGameOverviewScreenHandler.딟.TryGetValue(key, out num))
      return;
    if (num != 0)
    {
      if (num != 1)
        return;
      this.SkipButton.SetActive(false);
      this.SkipAnyActiveTallyScreenAnimations();
    }
    else
      this.OpenNextTallyScreen();
  }
}
