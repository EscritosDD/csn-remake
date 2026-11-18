// Decompiled with JetBrains decompiler
// Type: TallyNewCoinAwardScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class TallyNewCoinAwardScreenHandler : TallyBaseScreenHandler
{
  private Vector3 딟;
  private Vector3 땄;
  private TallyLevelUpScreenHandler 딟;
  private PlayerLevel 딟;
  public GameObject AbilityUnlockBox;
  public GameObject AbilityGlare;
  public GuiAnimation AbilityUnlockAnimation;
  public GuiAnimation AbilityGlareGlowAnimation;
  public GuiText3D AbilityNameText;
  public TallyCoinsScreenHandler CoinScreen;
  public TallyRematchScreenHandler RematchScreenHandler;
  public TallyTutorialTooltipScreenHandler TutorialTooltipScreen;
  private Vector3 딧;
  public AudioShader2 NewAbilitySound;

  public void ActivateNewCoinsScreen(
    딶.땖 State,
    Vector3 ScreenPos,
    PlayerLevel NewLevel,
    TallyLevelUpScreenHandler ReturnScreen)
  {
    this.딟 = NewLevel;
    this.딧 = ScreenPos;
    this.딟 = ReturnScreen;
    this.ActivateTallyScreen(State);
    ((Component) this).gameObject.SetActive(true);
    this.AbilityGlare.SetActive(false);
    this.딟 = this.AbilityUnlockBox.transform.localScale;
    this.땄 = this.AbilityGlare.transform.localScale;
    땓.땞.딟(this.AbilityNameText, NewLevel.CoinsAwardValue);
    this.AbilityUnlockAnimation.딟(new GuiAnimation.땂(this.OnAbilityUnlockAnimationFinish));
    this.AbilityUnlockAnimation.딟(new GuiAnimation.때(this.OnAbilityUnlockAnimationUpdate), true);
    this.AbilityGlareGlowAnimation.딟(new GuiAnimation.때(this.OnAbilityGlareGlowAnimationUpdate), true);
    this.AbilityGlareGlowAnimation.딟();
    this.AbilityUnlockAnimation.딟();
    if (!Object.op_Inequality((Object) this.NewAbilitySound, (Object) null))
      return;
    double num = (double) this.NewAbilitySound.PlayOneShot(((Component) this).gameObject, 0.0f);
  }

  public override void PositionScreenCameraView() => ((Component) this).transform.position = new Vector3((float) this.딧.x, (float) (this.딧.y + 0.5), (float) this.딧.z);

  public override void StopAnyTallyScreenSpecificAudio()
  {
    if (!Object.op_Inequality((Object) this.NewAbilitySound, (Object) null))
      ;
  }

  public void OnAbilityUnlockAnimationUpdate(float CurrentValue) => this.AbilityUnlockBox.transform.localScale = Vector3.op_Multiply(this.딟, CurrentValue);

  public void OnAbilityGlareGlowAnimationUpdate(float CurrentValue)
  {
    if (!this.AbilityGlare.activeInHierarchy)
      this.AbilityGlare.SetActive(true);
    this.AbilityGlare.renderer.material.color = new Color((float) this.AbilityGlare.renderer.material.color.r, (float) this.AbilityGlare.renderer.material.color.g, (float) this.AbilityGlare.renderer.material.color.b, CurrentValue);
    this.AbilityGlare.transform.localScale = Vector3.op_Multiply(this.땄, CurrentValue);
  }

  public void OnAbilityUnlockAnimationFinish() => this.SkipButton.gameObject.SetActive(false);

  private void SkipLevelUpAnimation()
  {
    this.SkipButton.gameObject.SetActive(false);
    if (this.AbilityUnlockAnimation.딧())
      this.AbilityUnlockAnimation.딟(true);
    if (!this.AbilityGlareGlowAnimation.딧())
      return;
    this.AbilityGlareGlowAnimation.딟(true);
  }

  private void Update()
  {
    if (!base.딟)
      return;
    this.AbilityUnlockAnimation.땄();
    this.AbilityGlareGlowAnimation.땄();
    this.UpdateTallyScreenDisplayTimer();
  }

  public override void OpenNextTallyScreen()
  {
    if (base.딟.떔() is 딶.딖)
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
    else if (Object.op_Equality((Object) this.딟, (Object) null) && this.ShouldShowCoinsScreen() && this.HasLocalPlayerBeenAwardedCoins())
      this.CoinScreen.ActivateTallyScreen(base.딟, this.딟);
    else if (Object.op_Inequality((Object) this.딟, (Object) null))
    {
      ((Component) this).gameObject.SetActive(false);
      this.딟.ReturnToLevelUpScreen(base.딟, ((Component) this).transform.position);
    }
    else if (base.딟.떓() == 딶.딹.땄)
    {
      if (base.딧 == base.딟)
      {
        ((Component) this).gameObject.SetActive(false);
        TallyHub.딟.SinglePlayerXPScreen.ReturnToSinglePlayerXPScreen(base.딟);
      }
      else
        this.RematchScreenHandler.ActivateTallyScreen(base.딟);
    }
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
    if (TallyNewCoinAwardScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      TallyNewCoinAwardScreenHandler.딟 = new Dictionary<string, int>(2)
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
    if (!TallyNewCoinAwardScreenHandler.딟.TryGetValue(key, out num))
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
}
