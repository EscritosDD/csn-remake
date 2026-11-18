// Decompiled with JetBrains decompiler
// Type: TallyLevelUpScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TallyLevelUpScreenHandler : TallyBaseScreenHandler
{
  private new int 딟;
  private new int 땄;
  private new int 딧;
  private Vector3 딟;
  private Vector3 땄;
  public Vector3 LevelUpTextBackgroundMaxScale;
  public GameObject LevelUpTextBackground;
  public GameObject LevelUpGlare;
  public GuiAnimation LevelUpAnimation;
  public GuiAnimation LevelUpGlareGlowAnimation;
  public ParticleSystem LevelUpStarburst;
  public GuiText3D LevelNumberText;
  public GuiText3D LevelText;
  public GuiText3D LevelUnlockText;
  public TallyCoinsScreenHandler CoinScreen;
  public TallyRematchScreenHandler RematchScreenHandler;
  public TallyTutorialTooltipScreenHandler TutorialTooltipScreen;
  public TallyNewAbilityScreenHandler AbilityUnlockScreen;
  public TallyNewCoinAwardScreenHandler CoinUnlockScreen;
  private Vector3 딧;
  public AudioShader2 LevelUpSound;

  public void ActivateLevelUpScreen(
    딶.땖 State,
    Vector3 ScreenPos,
    int OldLevel,
    int NewLevel,
    int TeamIndex)
  {
    this.딧 = ScreenPos;
    this.ActivateTallyScreen(State);
    this.딧 = TeamIndex;
    this.LevelUpGlare.SetActive(false);
    this.딟 = NewLevel;
    this.땄 = OldLevel;
    this.딟 = this.LevelUpTextBackground.transform.localScale;
    this.땄 = this.LevelUpGlare.transform.localScale;
    땓.땞.딟(this.LevelNumberText, OldLevel.ToString());
    this.LevelUpAnimation.딟(new GuiAnimation.땂(this.OnLevelUpAnimationFinish));
    this.LevelUpAnimation.딟(new GuiAnimation.때(this.OnLevelUpAnimationUpdate), true);
    this.LevelUpGlareGlowAnimation.딟(new GuiAnimation.때(this.OnLevelUpGlareGlowAnimationUpdate), true);
    this.LevelUpGlareGlowAnimation.딟();
    this.LevelUpAnimation.딟();
    this.LevelUpStarburst.Play();
    ((Component) this).gameObject.SetActive(true);
    if (Object.op_Inequality((Object) this.LevelUpSound, (Object) null))
    {
      double num = (double) this.LevelUpSound.PlayOneShot(((Component) this).gameObject, 0.0f);
    }
    딟.딦.딟("PlayerPromotion", new Dictionary<string, string>()
    {
      {
        "rank",
        NewLevel.ToString()
      }
    });
  }

  public void ReturnToLevelUpScreen(딶.땖 State, Vector3 Pos) => this.ActivateLevelUpScreen(State, Pos, this.땄 + 1, this.딟, this.딧);

  public override void PositionScreenCameraView() => ((Component) this).transform.position = new Vector3((float) this.딧.x, (float) (this.딧.y + 0.5), (float) this.딧.z);

  public override void StopAnyTallyScreenSpecificAudio()
  {
    if (!Object.op_Inequality((Object) this.LevelUpSound, (Object) null))
      ;
  }

  public void OnLevelUpAnimationUpdate(float CurrentValue)
  {
    Vector3 localScale = this.LevelUpTextBackground.transform.localScale;
    this.LevelUpTextBackground.transform.localScale = Vector3.op_Addition(this.딟, Vector3.op_Multiply(Vector3.op_Subtraction(this.LevelUpTextBackgroundMaxScale, this.딟), CurrentValue));
  }

  public void OnLevelUpGlareGlowAnimationUpdate(float CurrentValue)
  {
    if (!this.LevelUpGlare.activeInHierarchy)
      this.LevelUpGlare.SetActive(true);
    this.LevelUpGlare.renderer.material.color = new Color((float) this.LevelUpGlare.renderer.material.color.r, (float) this.LevelUpGlare.renderer.material.color.g, (float) this.LevelUpGlare.renderer.material.color.b, CurrentValue);
    this.LevelUpGlare.transform.localScale = Vector3.op_Multiply(this.땄, CurrentValue);
  }

  public void OnLevelUpAnimationFinish()
  {
    땓.땞.딟(this.LevelNumberText, (!this.get_MultiLevelUp() ? this.딟 : this.땄 + 1).ToString());
    this.SkipButton.gameObject.SetActive(false);
  }

  private void SkipLevelUpAnimation()
  {
    this.SkipButton.gameObject.SetActive(false);
    if (this.LevelUpAnimation.딧())
      this.LevelUpAnimation.딟(true);
    if (this.LevelUpGlareGlowAnimation.딧())
      this.LevelUpGlareGlowAnimation.딟(true);
    if (!this.LevelUpStarburst.isPlaying)
      return;
    this.LevelUpStarburst.Clear(true);
  }

  private void Update()
  {
    if (!base.딟)
      return;
    this.LevelUpAnimation.땄();
    this.LevelUpGlareGlowAnimation.땄();
    this.UpdateTallyScreenDisplayTimer();
  }

  public override void OpenNextTallyScreen()
  {
    int index = !this.get_MultiLevelUp() ? this.딟 - 1 : this.땄;
    PlayerAbilityEntry NewAbility = GlobalAppData.딢().GenericData.딟(index);
    PlayerLevel playerLevel = GlobalAppData.딢().GenericData.PlayerLevels[index];
    if (!string.IsNullOrEmpty(playerLevel.CoinsToken))
      GlobalAppData.땽().땺(playerLevel.CoinsToken);
    if (NewAbility != null)
    {
      ((Component) this).gameObject.SetActive(false);
      this.AbilityUnlockScreen.ActivateNewAbilityScreen(base.딟, playerLevel, ((Component) this).transform.position, NewAbility, this.딧, !this.get_MultiLevelUp() ? (TallyLevelUpScreenHandler) null : this);
    }
    else if (!string.IsNullOrEmpty(playerLevel.CoinsAwardValue))
    {
      ((Component) this).gameObject.SetActive(false);
      this.CoinUnlockScreen.ActivateNewCoinsScreen(base.딟, ((Component) this).transform.position, playerLevel, !this.get_MultiLevelUp() ? (TallyLevelUpScreenHandler) null : this);
    }
    else if (base.딟.떔() is 딶.딖)
    {
      if (GlobalAppData.땟())
      {
        GlobalAppData.딟(false);
        this.TutorialTooltipScreen.ActivateTutorialTooltipScreen(base.딟, ((Component) this).transform.position);
      }
      else
      {
        GlobalAppData.딟.딟(GlobalAppState.땊.땄);
        this.ExitToFrontEnd();
      }
    }
    else if (this.ShouldShowCoinsScreen() && this.HasLocalPlayerBeenAwardedCoins())
      this.CoinScreen.ActivateTallyScreen(base.딟);
    else if (base.딟.떓() == 딶.딹.땄)
      TallyHub.딟.SinglePlayerXPScreen.ReturnToSinglePlayerXPScreen(base.딟);
    else
      this.RematchScreenHandler.ActivateTallyScreen(base.딟);
    this.DeactivateTallyScreen();
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (TallyLevelUpScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      TallyLevelUpScreenHandler.딟 = new Dictionary<string, int>(2)
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
    if (!TallyLevelUpScreenHandler.딟.TryGetValue(key, out num))
      return;
    if (num != 0)
    {
      if (num != 1)
        return;
      this.SkipLevelUpAnimation();
    }
    else
      this.OpenNextTallyScreen();
  }

  [SpecialName]
  private bool get_MultiLevelUp() => this.딟 - this.땄 > 1;

  [SpecialName]
  private void set_MultiLevelUp(bool value)
  {
  }
}
