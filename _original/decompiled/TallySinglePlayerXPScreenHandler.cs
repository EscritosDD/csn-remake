// Decompiled with JetBrains decompiler
// Type: TallySinglePlayerXPScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TallySinglePlayerXPScreenHandler : TallyBaseScreenHandler
{
  private TallySinglePlayerXPScreenHandler.땗 딟;
  private float 딟;
  public float timeToWaitPerAward = 1.7f;
  private new int 딟;
  private new bool 딟;
  private new bool 땄;
  public TallyRematchScreenHandler RematchScreenHandler;
  public TallyLevelUpScreenHandler LevelUpScreen;
  public GameObject QuitButton;
  public GameObject bronzeAward;
  public GameObject bronzeAwardRequirements;
  public AudioShader2 bronzeAwardSound;
  public GameObject silverAward;
  public GameObject silverAwardRequirements;
  public AudioShader2 silverAwardSound;
  public GameObject goldAward;
  public GameObject goldAwardRequirements;
  public AudioShader2 goldAwardSound;
  public GuiText3D CoinsText;
  public GameObject CoinsIcon;
  public GuiText3D scoreText;
  public float scoreCountTimeLimit;
  public Animation scorePulse;
  private new int 땄;
  private float 땄 = 1f;
  public TallyXPBar PlayerXPBar;
  private new int 딧;
  private new int 딢;
  public ParticleSystem StarBurst;
  public ToolTipHandler registerForFreeSoldierTooltip;

  public override void InitailiseScreenData()
  {
    if (this.딟 == TallySinglePlayerXPScreenHandler.땗.땓)
      return;
    this.InitialiseTallyScreenData(true, false, true, true, false);
    this.QuitButton.SetActive(false);
    int TotalXPWithBoost;
    int CurrentPlayerXP;
    // ISSUE: reference to a compiler-generated method
    this.set_bPlayerHasXPBoost(this.GetTotalPlayerAwardXP(base.딟, out int _, out TotalXPWithBoost, out CurrentPlayerXP));
    this.딢 = this.딧 = GlobalAppData.딢().GenericData.땄(CurrentPlayerXP);
    if (GlobalAppData.딢().GenericData.딧(this.딧))
      TotalXPWithBoost = 0;
    // ISSUE: reference to a compiler-generated method
    this.set_bPlayerHasLeveledUp(this.PlayerXPBar.IntialiseTallyXPBar(CurrentPlayerXP, TotalXPWithBoost, this.딧, true));
    this.PlayerXPBar.AddOnLevelUpCallback(new TallyXPBar.딪(this.OnPlayerLevelUp));
    this.PlayerXPBar.AddOnXPAnimFinishCallback(new TallyXPBar.떕(this.DeactivateSkipButton));
    this.딟 = base.딟.딱();
    if (Object.op_Inequality((Object) this.bronzeAward, (Object) null))
      this.bronzeAward.SetActive(false);
    if (Object.op_Inequality((Object) this.silverAward, (Object) null))
      this.silverAward.SetActive(false);
    if (Object.op_Inequality((Object) this.goldAward, (Object) null))
      this.goldAward.SetActive(false);
    if (Object.op_Inequality((Object) this.CoinsText, (Object) null))
      ((Component) this.CoinsText).gameObject.SetActive(false);
    if (Object.op_Inequality((Object) this.CoinsIcon, (Object) null))
      this.CoinsIcon.SetActive(false);
    this.bronzeAwardRequirements.SetActive(false);
    this.silverAwardRequirements.SetActive(false);
    this.goldAwardRequirements.SetActive(false);
    this.SetState(TallySinglePlayerXPScreenHandler.땗.땄);
    if (GlobalAppData.땽().땢())
      딟.딦.딟("StartedFirstSPMission");
    딟.딦.딟("Singleplayer_XP", (double) TotalXPWithBoost, new Dictionary<string, string>()
    {
      {
        "level",
        base.딟.딟.땄
      },
      {
        "mission",
        base.딟.딟.딧
      }
    });
    this.UpdateScoreValue();
    this.scoreText.Text = "0";
    this.scoreText.UpdateMesh();
  }

  private void Update()
  {
    this.딟 += Time.deltaTime;
    switch (this.딟)
    {
      case TallySinglePlayerXPScreenHandler.땗.땄:
        if ((double) this.딟 < (double) this.timeToWaitPerAward)
          break;
        this.SetState(TallySinglePlayerXPScreenHandler.땗.딧);
        break;
      case TallySinglePlayerXPScreenHandler.땗.딧:
        if ((double) this.딟 < (double) this.timeToWaitPerAward)
          break;
        this.SetState(TallySinglePlayerXPScreenHandler.땗.딢);
        break;
      case TallySinglePlayerXPScreenHandler.땗.딢:
        if ((double) this.딟 < (double) this.timeToWaitPerAward)
          break;
        this.SetState(TallySinglePlayerXPScreenHandler.땗.땃);
        break;
      case TallySinglePlayerXPScreenHandler.땗.땃:
        if (this.PlayerXPBar.FillAnimation.딧())
          break;
        this.SetState(TallySinglePlayerXPScreenHandler.땗.딶);
        break;
      case TallySinglePlayerXPScreenHandler.땗.딶:
        if (!this.UpdateScoreText())
          break;
        this.scorePulse.Play();
        this.SetState(TallySinglePlayerXPScreenHandler.땗.땓);
        break;
    }
  }

  private void SetState(TallySinglePlayerXPScreenHandler.땗 state)
  {
    this.딟 = state;
    this.딟 = 0.0f;
    switch (state)
    {
      case TallySinglePlayerXPScreenHandler.땗.땄:
        if (this.딟 < 1)
        {
          this.SetState(TallySinglePlayerXPScreenHandler.땗.땃);
          break;
        }
        this.bronzeAward.SetActive(true);
        this.bronzeAward.animation.Play();
        double num1 = (double) this.bronzeAwardSound.PlayOneShot(((Component) this).gameObject);
        this.bronzeAwardRequirements.SetActive(true);
        this.bronzeAwardRequirements.animation.Play();
        this.silverAwardRequirements.SetActive(false);
        this.goldAwardRequirements.SetActive(false);
        break;
      case TallySinglePlayerXPScreenHandler.땗.딧:
        if (this.딟 < 2)
        {
          this.SetState(TallySinglePlayerXPScreenHandler.땗.땃);
          break;
        }
        this.silverAward.SetActive(true);
        this.silverAward.animation.Play();
        double num2 = (double) this.silverAwardSound.PlayOneShot(((Component) this).gameObject);
        this.bronzeAwardRequirements.SetActive(false);
        this.silverAwardRequirements.SetActive(true);
        this.silverAwardRequirements.animation.Play();
        this.goldAwardRequirements.SetActive(false);
        break;
      case TallySinglePlayerXPScreenHandler.땗.딢:
        if (this.딟 < 3)
        {
          this.SetState(TallySinglePlayerXPScreenHandler.땗.땃);
          break;
        }
        this.goldAward.SetActive(true);
        this.goldAward.animation.Play();
        double num3 = (double) this.goldAwardSound.PlayOneShot(((Component) this).gameObject);
        this.bronzeAwardRequirements.SetActive(false);
        this.silverAwardRequirements.SetActive(false);
        this.goldAwardRequirements.SetActive(true);
        this.goldAwardRequirements.animation.Play();
        break;
      case TallySinglePlayerXPScreenHandler.땗.땃:
        this.StartXPFillAnimation();
        this.ShowAwards();
        break;
      case TallySinglePlayerXPScreenHandler.땗.딶:
        this.땄 = Time.realtimeSinceStartup;
        break;
      case TallySinglePlayerXPScreenHandler.땗.땓:
        this.PlayerXPBar.FinishXPBarFillAnimation();
        this.ShowAwards();
        if (!this.bronzeAward.activeInHierarchy)
          this.bronzeAward.SetActive(this.딟 >= 1);
        if (!this.silverAward.activeInHierarchy)
          this.silverAward.SetActive(this.딟 >= 2);
        if (!this.goldAward.activeInHierarchy)
          this.goldAward.SetActive(this.딟 >= 3);
        this.bronzeAwardRequirements.SetActive(this.딟 == 1);
        this.silverAwardRequirements.SetActive(this.딟 == 2);
        this.goldAwardRequirements.SetActive(this.딟 == 3);
        this.OpenNextTallyScreen();
        break;
    }
  }

  public void OnPlayerLevelUp(int CurrentXP, int CurrentLevel)
  {
    this.딢 = CurrentLevel;
    this.UpdatePlayerInfoBar(true, true);
    this.TallyPlayerInfo.PlayerOneInfo.ProfileLevelTextbox.Text = this.딢.ToString();
    this.TallyPlayerInfo.PlayerOneInfo.ProfileLevelTextbox.UpdateMesh();
  }

  public void StartXPFillAnimation()
  {
    this.PlayerXPBar.TriggerTallyXPBarFillAnimation(!GlobalAppData.딢().GenericData.딧(this.딧));
    base.땄 = false;
  }

  public void ShowAwards()
  {
    if (Object.op_Inequality((Object) this.bronzeAward, (Object) null) && !this.bronzeAward.activeInHierarchy)
      this.bronzeAward.SetActive(this.딟 >= 1);
    if (Object.op_Inequality((Object) this.silverAward, (Object) null) && !this.silverAward.activeInHierarchy)
      this.silverAward.SetActive(this.딟 >= 2);
    if (Object.op_Inequality((Object) this.goldAward, (Object) null) && !this.goldAward.activeInHierarchy)
      this.goldAward.SetActive(this.딟 == 3);
    if (this.딟 <= 0)
      return;
    if (Object.op_Inequality((Object) this.CoinsText, (Object) null))
    {
      int num = base.딟.땭(GlobalAppData.땽().떎(base.딟.딟.딧));
      ((Component) this.CoinsText).gameObject.SetActive(true);
      this.CoinsText.Text = num <= 0 ? "-" : num.ToString();
      this.CoinsText.UpdateMesh();
    }
    if (!Object.op_Inequality((Object) this.CoinsIcon, (Object) null))
      return;
    this.CoinsIcon.SetActive(true);
  }

  public void DeactivateSkipButton() => this.SkipButton.gameObject.SetActive(false);

  public override void OpenNextTallyScreen()
  {
    this.DeactivateTallyScreen();
    if (this.get_bPlayerHasLeveledUp())
      this.LevelUpScreen.ActivateLevelUpScreen(base.딟, ((Component) this).transform.position, this.딧, this.딢, base.딟);
    else if (base.딧 == base.딟)
      this.PrepareForQuit();
    else
      this.RematchScreenHandler.ActivateTallyScreen(base.딟);
  }

  private void OnButtonPressed(string Command)
  {
    if (!base.딟)
      return;
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (TallySinglePlayerXPScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      TallySinglePlayerXPScreenHandler.딟 = new Dictionary<string, int>(4)
      {
        {
          "Continue",
          0
        },
        {
          "Skip",
          1
        },
        {
          "Quit",
          2
        },
        {
          "CloseChapterUnlockPanel",
          3
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!TallySinglePlayerXPScreenHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        this.OpenNextTallyScreen();
        break;
      case 1:
        this.SetState(TallySinglePlayerXPScreenHandler.땗.땓);
        break;
      case 2:
        this.QuitFunctionality();
        break;
      case 3:
        this.QuitButton.SetActive(false);
        this.ExitToFrontEnd();
        break;
    }
  }

  public void ReturnToSinglePlayerXPScreen(딶.땖 GameState)
  {
    if (base.딧 == base.딟)
      this.PrepareForQuit();
    else
      this.RematchScreenHandler.ActivateTallyScreen(GameState);
  }

  private void PrepareForQuit()
  {
    base.딟 = true;
    this.SaveXP(out this.딟);
    if (this.ShouldDisplayFreeCharacterTooltip())
    {
      this.땄 = true;
      this.registerForFreeSoldierTooltip.Display(false, ((Component) this).transform);
    }
    else
    {
      this.ShowEventDrivenMessagingPopup();
      this.AskForReview();
    }
    this.QuitButton.SetActive(true);
    this.DeactivateSkipButton();
    this.DisableContinueButton();
    this.scoreText.Text = this.땄.ToString();
    this.scoreText.UpdateMesh();
  }

  private void QuitFunctionality()
  {
    base.딟 = false;
    if (base.딟.딗())
      GlobalAppData.딟.딟(GlobalAppState.땊.땽);
    else if (this.땄)
      GlobalAppData.딟.딟(GlobalAppState.땊.땭);
    else if (this.딟)
      GlobalAppData.딟.딟(GlobalAppState.땊.땤);
    else
      GlobalAppData.딟.딟(GlobalAppState.땊.떂);
    this.SetupChallengePackLoad();
    this.ExitToFrontEnd();
  }

  private void UpdateScoreValue()
  {
    int PlayerXP;
    this.CalculateXP(out PlayerXP, out int _, out int _);
    this.땄 = this.CalculateScore(PlayerXP);
  }

  private bool UpdateScoreText()
  {
    this.scoreText.Text = ((int) ((double) Mathf.Clamp01((Time.realtimeSinceStartup - this.땄) / this.scoreCountTimeLimit) * (double) this.땄)).ToString();
    this.scoreText.UpdateMesh();
    return (double) Time.realtimeSinceStartup > (double) this.땄 + (double) this.scoreCountTimeLimit;
  }

  private bool ShouldDisplayFreeCharacterTooltip() => GlobalAppData.땽().땄(1) && !GlobalAppData.땽().딱() && string.IsNullOrEmpty(((딟.땇) GlobalAppData.떏()).땓()) && !GlobalAppData.땽().땄(딢.딮.땶);

  [CompilerGenerated]
  [SpecialName]
  public bool get_bPlayerHasLeveledUp() => this.딧;

  [CompilerGenerated]
  [SpecialName]
  public bool get_bPlayerHasXPBoost() => this.딢;

  public enum 땗
  {
    딟,
    땄,
    딧,
    딢,
    땃,
    딶,
    땓,
  }
}
