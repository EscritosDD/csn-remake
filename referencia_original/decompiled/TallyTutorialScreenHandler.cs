// Decompiled with JetBrains decompiler
// Type: TallyTutorialScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TallyTutorialScreenHandler : TallyBaseScreenHandler
{
  private 땓.떀 딟;
  private GameObject 딟;
  private new int 딟;
  private new int 땄;
  public Camera TutorialCommanderCamera;
  public GameObject TutorialCommanderSpawn;
  public TallyLevelUpScreenHandler LevelUpScreen;
  public TallyTutorialTooltipScreenHandler TutorialTooltipScreen;
  public TallyXPBar PlayerXPBar;
  public WinnerBoxData TutorialWinnerBox;
  public Vector3 MaxTutorialWinnerBoxScale;
  public GuiAnimation TutorialWinnerFadeInAnim;
  public GuiParticleEmitter TutorialWinnerStarburst;
  private new bool 딟;
  public Material BlueTeamBackgroundMaterial;
  public Material RedTeamBackgroundMaterial;
  public AudioShader2 WinTheme;
  public AudioShader2 WinnerStarburstSound;
  private float 딟;
  private float 땄;

  public override void InitailiseScreenData()
  {
    this.InitialiseTallyScreenData(true, false, true, false, true);
    this.TutorialWinnerBox.딟(true);
    int AwardedXPWithBoost;
    int CurrentPlayerXP;
    this.GetTotalPlayerAwardXP(base.딟, out int _, out AwardedXPWithBoost, out CurrentPlayerXP);
    this.땄 = this.딟 = GlobalAppData.딢().GenericData.땄(CurrentPlayerXP);
    if (GlobalAppData.딢().GenericData.딧(this.딟))
      AwardedXPWithBoost = 0;
    // ISSUE: reference to a compiler-generated method
    this.set_bPlayerHasLeveledUp(this.PlayerXPBar.IntialiseTallyXPBar(CurrentPlayerXP, AwardedXPWithBoost, this.딟, true));
    this.PlayerXPBar.AddOnLevelUpCallback(new TallyXPBar.딪(this.OnPlayerLevelUp));
    this.PlayerXPBar.AddOnXPAnimFinishCallback(new TallyXPBar.떕(this.DeactivateSkipButton));
    this.PlayerXPBar.TriggerTallyXPBarFillAnimation(true);
    this.TutorialWinnerFadeInAnim.딟(new GuiAnimation.때(this.OnTutorialWinnerFadeAnimUpdateCallback), true);
    this.TutorialWinnerFadeInAnim.딟();
    if (Object.op_Inequality((Object) this.WinnerStarburstSound, (Object) null))
    {
      double num = (double) this.WinnerStarburstSound.PlayOneShot(((Component) this).gameObject, 0.0f);
    }
    this.TutorialWinnerStarburst.ActivatePaticleEmitter();
    this.땄 = this.WinTheme.PlayOneShot(((Component) this).gameObject, 0.0f);
    if ((double) this.땄 > (double) this.MaximumScreenDisplayTime)
      this.MaximumScreenDisplayTime = this.땄 + 1f;
    this.PrepareCharacterInformation();
  }

  public override bool GetTotalPlayerAwardXP(
    int TeamIndex,
    out int AwardedXP,
    out int AwardedXPWithBoost,
    out int CurrentPlayerXP)
  {
    CurrentPlayerXP = GlobalAppData.땽().딣();
    AwardedXP = GlobalAppData.딢().GenericData.TutorialXP;
    AwardedXPWithBoost = AwardedXP;
    return false;
  }

  protected override void SaveXP(out bool ShouldDisplayIncentivisationScreen)
  {
    ShouldDisplayIncentivisationScreen = false;
    if (base.딟 == null)
      return;
    int tutorialXp = GlobalAppData.딢().GenericData.TutorialXP;
    this.SaveXP(tutorialXp, tutorialXp);
  }

  public override void StopAnyTallyScreenSpecificAudio()
  {
    if (!Object.op_Inequality((Object) this.WinnerStarburstSound, (Object) null))
      ;
  }

  private void OnTutorialWinnerFadeAnimUpdateCallback(float CurrentValue) => this.TutorialWinnerBox.WinnerBoxParent.transform.localScale = Vector3.op_Multiply(this.MaxTutorialWinnerBoxScale, CurrentValue);

  private void OnTutorialWinnerFadeAnimEnd() => this.SkipButton.SetActive(false);

  private void Update()
  {
    if (base.딟)
    {
      this.TutorialWinnerFadeInAnim.땄();
      this.딟 += Time.deltaTime;
      if ((double) this.딟 > (double) this.땄 && !GlobalAppData.떎())
        this.StartSubThemePlaying();
      this.UpdateTallyScreenDisplayTimer();
    }
    if (!this.딟 || ((딟.딗) GlobalAppData.땼()).땽())
      return;
    this.딟 = false;
    this.SpawnCharacter();
  }

  public void OnPlayerLevelUp(int CurrentXP, int CurrentLevel)
  {
    딟.딦.딟("NUF_Tutorial_Level_Up");
    this.UpdatePlayerInfoBar(true, false);
    this.땄 = CurrentLevel;
  }

  public void DeactivateSkipButton()
  {
    if (!Object.op_Inequality((Object) this.SkipButton, (Object) null))
      return;
    this.SkipButton.gameObject.SetActive(false);
  }

  public void SkipTutorialTallyAnimations()
  {
    this.PlayerXPBar.FinishXPBarFillAnimation();
    if (this.TutorialWinnerFadeInAnim.딧())
      this.TutorialWinnerFadeInAnim.딟(true);
    if (this.TutorialWinnerStarburst.get_bPaticleEmitterActive())
      this.TutorialWinnerStarburst.KillParticleEmitter();
    this.DeactivateSkipButton();
  }

  public override void OpenNextTallyScreen()
  {
    this.SaveXP(out bool _);
    if (this.get_bPlayerHasLeveledUp())
      this.LevelUpScreen.ActivateLevelUpScreen(base.딟, ((Component) this).transform.position, this.딟, this.땄, base.딟);
    else if (GlobalAppData.땟())
    {
      GlobalAppData.딟(false);
      this.TutorialTooltipScreen.ActivateTutorialTooltipScreen(base.딟, ((Component) this).transform.position);
    }
    else
    {
      GlobalAppData.딟.딟(GlobalAppState.땊.땄);
      this.ExitToFrontEnd();
    }
    this.ClearCharacter();
    this.DeactivateTallyScreen();
  }

  private void OnButtonPressed(string Command)
  {
    if (!base.딟)
      return;
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (TallyTutorialScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      TallyTutorialScreenHandler.딟 = new Dictionary<string, int>(2)
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
    if (!TallyTutorialScreenHandler.딟.TryGetValue(key, out num))
      return;
    if (num != 0)
    {
      if (num != 1)
        return;
      this.SkipTutorialTallyAnimations();
    }
    else
      this.OpenNextTallyScreen();
  }

  private void PrepareCharacterInformation()
  {
    GlobalAppData.땽().땲();
    this.딟 = GlobalAppData.땽().딧(GlobalAppData.땽().땝());
    GlobalAppData.땼().딟((땓.딲) this.딟, 땓.땾.딟);
    this.딟 = true;
  }

  private void SpawnCharacter()
  {
    this.ClearCharacter();
    if (this.딟 == null)
      return;
    this.딟 = new GameObject();
    땓.떀 딟1 = this.딟;
    딟1.땠();
    GameObject 딟2 = this.딟;
    UnitTesterComponent.딟(딟2.transform, 딟1.딣(), 딟1.딛(), 딟1.땷(), 딟1.땔(), (Material) null, 딟1.딛().딟((딶.땖) null, 땓.딺.딟), 0);
    딟2.transform.parent = this.TutorialCommanderSpawn.transform;
    딟2.transform.localPosition = Vector3.zero;
    딟2.transform.localRotation = Quaternion.identity;
  }

  private void ClearCharacter()
  {
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    Object.Destroy((Object) this.딟);
    this.딟 = (GameObject) null;
  }

  [CompilerGenerated]
  [SpecialName]
  public bool get_bPlayerHasLeveledUp() => this.땄;
}
