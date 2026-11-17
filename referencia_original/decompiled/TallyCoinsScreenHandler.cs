// Decompiled with JetBrains decompiler
// Type: TallyCoinsScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class TallyCoinsScreenHandler : TallyBaseScreenHandler
{
  public GuiParticleEmitter CoinsFallEmitter;
  public GuiParticleEmitter Team1CoinsEmitter;
  public GuiParticleEmitter Team2CoinsEmitter;
  public GuiText3D Team1CoinsTotalText;
  public GuiText3D Team2CoinsTotalText;
  public GuiText3D CoinPotText;
  public GameObject CoinRewardGlare;
  public GameObject CoinTrayGlowGlare;
  public GameObject CoinPot;
  private Vector3 딟;
  private Vector3 땄;
  private Vector3 딧;
  public Vector3 MaxCoinPotScale;
  public TallyCoinLines Team1CoinLines;
  public TallyCoinLines Team2CoinLines;
  public GuiAnimation CoinPotGrowAnim;
  public GuiAnimation CoinPotDistributeAnim;
  public TallyRematchScreenHandler RematchScreenHandler;
  private new int 딟;
  private new int 땄;
  private new int 딧;
  public AudioShader2 CoinPotFillSound;
  public AudioShader2 CoinPotEmptySound;
  private AudioShader2 딟;
  private AudioShader2 땄;
  private TallyLevelUpScreenHandler 딟;

  public void ActivateTallyScreen(딶.땖 State, TallyLevelUpScreenHandler ReturnScreen)
  {
    this.ActivateTallyScreen(State);
    this.딟 = ReturnScreen;
  }

  public override void InitailiseScreenData()
  {
    this.InitialiseTallyScreenData(false, false, false, true, false);
    int num1;
    if (base.딟 == base.딧)
    {
      base.딟.딟(base.딧, this.딢, out this.땄, out this.딧);
      num1 = this.땄;
    }
    else
    {
      base.딟.딟(base.딧, this.딢, out this.딧, out this.땄);
      num1 = this.딧;
    }
    this.딟 = this.땄 + this.딧;
    float PercentToCreate1 = this.딟 <= 0 ? 0.0f : (float) this.땄 / (float) this.딟;
    float PercentToCreate2 = this.딟 <= 0 ? 0.0f : (float) this.딧 / (float) this.딟;
    땓.땞.딟(this.CoinPotText, "0");
    땓.땞.딟(this.Team1CoinsTotalText, "0");
    땓.땞.딟(this.Team2CoinsTotalText, "0");
    this.딟 = this.CoinPot.transform.localScale;
    this.땄 = this.CoinTrayGlowGlare.transform.localScale;
    this.딧 = this.CoinRewardGlare.transform.localScale;
    this.CoinPotGrowAnim.딟(new GuiAnimation.때(this.OnCoinPotGrowAnimUpdateCallback), true);
    this.CoinPotGrowAnim.딟(new GuiAnimation.땂(this.OnCoinPotGrowAnimEnd));
    this.CoinPotDistributeAnim.딟(new GuiAnimation.때(this.OnCoinDistributeAnimUpdateCallback), false);
    this.CoinPotDistributeAnim.딟(new GuiAnimation.땂(this.OnCoinPotDistributeAnimEnd));
    this.Team1CoinLines.InitailiseCoinLineData(this.CoinPotDistributeAnim.TotalAnimTime, PercentToCreate1);
    this.Team2CoinLines.InitailiseCoinLineData(this.CoinPotDistributeAnim.TotalAnimTime, PercentToCreate2);
    if (Object.op_Inequality((Object) this.CoinsFallEmitter, (Object) null))
      this.CoinsFallEmitter.ActivatePaticleEmitter();
    this.CoinPotGrowAnim.딟();
    if (Object.op_Inequality((Object) this.CoinPotFillSound, (Object) null))
    {
      double num2 = (double) this.CoinPotFillSound.PlayOneShot(((Component) this).gameObject, 0.0f, out this.딟);
    }
    if (GlobalAppData.떏().땥())
      GlobalAppData.떏().땟();
    if (base.딟.떓() != 딶.딹.딧)
      return;
    딟.딦.딟("Multiplayer_CoinPot", (double) this.딟, new Dictionary<string, string>()
    {
      {
        "level",
        base.딟.딟.땄
      },
      {
        "type",
        "Total"
      }
    });
    딟.딦.딟("Multiplayer_CoinPot", (double) num1, new Dictionary<string, string>()
    {
      {
        "level",
        base.딟.딟.땄
      },
      {
        "type",
        "Winner"
      }
    });
    딟.딦.딟("Multiplayer_CoinPot", (double) (this.딟 - num1), new Dictionary<string, string>()
    {
      {
        "level",
        base.딟.딟.땄
      },
      {
        "type",
        "Loser"
      }
    });
  }

  public override void CleanUpTallyScreenData()
  {
    this.SkipAnyActiveCoinScreenAnimations();
    this.Team1CoinLines.DeactivateCoinLines();
    this.Team2CoinLines.DeactivateCoinLines();
  }

  private void SkipAnyActiveCoinScreenAnimations()
  {
    if (this.get_ScreenAnimationsSkipped())
      return;
    this.set_ScreenAnimationsSkipped(true);
    if (this.CoinsFallEmitter.get_bPaticleEmitterActive())
      this.CoinsFallEmitter.KillParticleEmitter();
    if (this.Team1CoinsEmitter.get_bPaticleEmitterActive())
      this.Team1CoinsEmitter.KillParticleEmitter();
    if (this.Team2CoinsEmitter.get_bPaticleEmitterActive())
      this.Team2CoinsEmitter.KillParticleEmitter();
    if (this.CoinPotGrowAnim.딧())
      this.CoinPotGrowAnim.딟(true);
    if (this.CoinPotDistributeAnim.딧())
      this.CoinPotDistributeAnim.딟(true);
    this.Team1CoinLines.ShowAllCoinLinesNow();
    this.Team2CoinLines.ShowAllCoinLinesNow();
    if (Object.op_Inequality((Object) this.딟, (Object) null))
      Object.Destroy((Object) ((Component) this.딟).gameObject);
    if (!Object.op_Inequality((Object) this.땄, (Object) null))
      return;
    Object.Destroy((Object) ((Component) this.땄).gameObject);
  }

  public void OnCoinPotGrowAnimUpdateCallback(float CurrentValue)
  {
    this.ScaleCoinPot(Vector3.op_Addition(this.딟, Vector3.op_Multiply(Vector3.op_Subtraction(this.MaxCoinPotScale, this.딟), CurrentValue)));
    this.CoinTrayGlowGlare.transform.localScale = Vector3.op_Multiply(this.땄, CurrentValue);
    땓.땞.딟(this.CoinPotText, Mathf.CeilToInt((float) this.딟 * CurrentValue).ToString());
  }

  public void OnCoinPotGrowAnimEnd()
  {
    this.CoinRewardGlare.SetActive(true);
    this.CoinPotDistributeAnim.딟();
    float num1 = this.CoinPotDistributeAnim.TotalAnimTime - 1f;
    if ((double) num1 == 0.0)
      num1 = 0.1f;
    this.Team1CoinsEmitter.MaxParticles = this.땄;
    this.Team1CoinsEmitter.NumParticlesToInitailisePerTick = Mathf.CeilToInt(this.Team1CoinsEmitter.TickInitailiseDelay / num1 * (float) this.땄);
    this.Team2CoinsEmitter.MaxParticles = this.딧;
    this.Team2CoinsEmitter.NumParticlesToInitailisePerTick = Mathf.CeilToInt(this.Team2CoinsEmitter.TickInitailiseDelay / num1 * (float) this.딧);
    if (this.get_ScreenAnimationsSkipped())
      return;
    this.Team1CoinsEmitter.ActivatePaticleEmitter();
    this.Team2CoinsEmitter.ActivatePaticleEmitter();
    this.Team1CoinLines.ActivateCoinLines();
    this.Team2CoinLines.ActivateCoinLines();
    if (!Object.op_Inequality((Object) this.CoinPotEmptySound, (Object) null))
      return;
    double num2 = (double) this.CoinPotEmptySound.PlayOneShot(((Component) this).gameObject, 0.0f, out this.땄);
  }

  public void OnCoinDistributeAnimUpdateCallback(float CurrentValue)
  {
    땓.땞.딟(this.CoinPotText, Mathf.CeilToInt((float) this.딟 * (1f - CurrentValue)).ToString());
    땓.땞.딟(this.Team1CoinsTotalText, Mathf.CeilToInt((float) this.땄 * CurrentValue).ToString());
    땓.땞.딟(this.Team2CoinsTotalText, Mathf.CeilToInt((float) this.딧 * CurrentValue).ToString());
    this.ScaleCoinPot(Vector3.op_Addition(this.딟, Vector3.op_Multiply(Vector3.op_Subtraction(this.MaxCoinPotScale, this.딟), 1f - CurrentValue)));
    this.CoinTrayGlowGlare.transform.localScale = Vector3.op_Multiply(this.땄, 1f - CurrentValue);
    this.CoinRewardGlare.transform.localScale = Vector3.op_Multiply(this.딧, 1f - CurrentValue);
  }

  private void ScaleCoinPot(Vector3 NewScaleVal)
  {
    if (!Object.op_Inequality((Object) this.CoinPot, (Object) null))
      return;
    NewScaleVal.y = this.딟.y;
    this.CoinPot.transform.localScale = NewScaleVal;
  }

  public void OnCoinPotDistributeAnimEnd()
  {
    this.CoinRewardGlare.SetActive(false);
    this.SkipButton.SetActive(false);
  }

  private void Update()
  {
    if (!base.딟)
      return;
    this.CoinPotGrowAnim.땄();
    this.CoinPotDistributeAnim.땄();
    this.UpdateTallyScreenDisplayTimer();
  }

  public override void OpenNextTallyScreen()
  {
    this.DeactivateTallyScreen();
    if (Object.op_Inequality((Object) this.딟, (Object) null))
      this.딟.ReturnToLevelUpScreen(base.딟, ((Component) this).transform.position);
    else
      this.RematchScreenHandler.ActivateTallyScreen(base.딟);
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (TallyCoinsScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      TallyCoinsScreenHandler.딟 = new Dictionary<string, int>(2)
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
    if (!TallyCoinsScreenHandler.딟.TryGetValue(key, out num))
      return;
    if (num != 0)
    {
      if (num != 1)
        return;
      this.SkipButton.SetActive(false);
      this.SkipAnyActiveCoinScreenAnimations();
    }
    else
      this.OpenNextTallyScreen();
  }
}
