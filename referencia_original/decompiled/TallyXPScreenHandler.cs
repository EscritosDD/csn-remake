// Decompiled with JetBrains decompiler
// Type: TallyXPScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TallyXPScreenHandler : TallyBaseScreenHandler
{
  private new int 딟;
  private new int 땄;
  public TallyCoinsScreenHandler CoinScreen;
  public TallyRematchScreenHandler RematchScreenHandler;
  public TallyLevelUpScreenHandler LevelUpScreen;
  public TallyXPBar PlayerXPBar;
  public TallyXPUnitGrid UnitGrid;
  public GameObject XPBoostIcon;
  public GameObject CoinBoostIcon;
  public GuiText3D NoneText;
  public Material BlueTeamBackgroundMaterial;
  public Material RedTeamBackgroundMaterial;

  public override void InitailiseScreenData()
  {
    this.InitialiseTallyScreenData(true, false, true, true, false);
    int TotalXPWithBoost1;
    int CurrentPlayerXP;
    // ISSUE: reference to a compiler-generated method
    this.set_bPlayerHasXPBoost(this.GetTotalPlayerAwardXP(base.딟, out int _, out TotalXPWithBoost1, out CurrentPlayerXP));
    this.땄 = this.딟 = GlobalAppData.딢().GenericData.땄(CurrentPlayerXP);
    if (GlobalAppData.딢().GenericData.딧(this.딟))
      TotalXPWithBoost1 = 0;
    // ISSUE: reference to a compiler-generated method
    this.set_bPlayerHasLeveledUp(this.PlayerXPBar.IntialiseTallyXPBar(CurrentPlayerXP, TotalXPWithBoost1, this.딟, true));
    bool ShouldPlayAudio = !GlobalAppData.딢().GenericData.딧(this.딟);
    this.PlayerXPBar.AddOnLevelUpCallback(new TallyXPBar.딪(this.OnPlayerLevelUp));
    this.PlayerXPBar.AddOnXPAnimFinishCallback(new TallyXPBar.떕(this.DeactivateSkipButton));
    this.PlayerXPBar.TriggerTallyXPBarFillAnimation(ShouldPlayAudio);
    this.UnitGrid.PopulateUnitXPGrid(base.딟, base.딟, base.딟 != 0 ? this.RedTeamBackgroundMaterial : this.BlueTeamBackgroundMaterial);
    string str = "Multiplayer_XP";
    Dictionary<string, string> dictionary = new Dictionary<string, string>();
    dictionary.Add("level", base.딟.딟.땄);
    딟.딦.딟(str, (double) TotalXPWithBoost1, dictionary);
    int TotalXPWithBoost2;
    this.GetTotalPlayerAwardXP(base.땄, out int _, out TotalXPWithBoost2, out int _);
    딟.딦.딟(str, (double) TotalXPWithBoost2, dictionary);
    if (base.딟.떂(base.딟))
    {
      this.CoinBoostIcon.SetActive(true);
      ((Component) this.NoneText).gameObject.SetActive(false);
    }
    else
      this.CoinBoostIcon.SetActive(false);
    if (base.딟.떎(base.딟))
    {
      this.XPBoostIcon.SetActive(true);
      ((Component) this.NoneText).gameObject.SetActive(false);
    }
    else
      this.XPBoostIcon.SetActive(false);
  }

  public void OnPlayerLevelUp(int CurrentXP, int CurrentLevel)
  {
    this.UpdatePlayerInfoBar(true, true);
    this.땄 = CurrentLevel;
  }

  public void DeactivateSkipButton()
  {
    if (!Object.op_Inequality((Object) this.SkipButton, (Object) null))
      return;
    this.SkipButton.gameObject.SetActive(false);
  }

  private void Update()
  {
    if (!base.딟)
      return;
    base.딟 = base.딟.땂();
    base.땄 = base.딟 != 0 ? 0 : 1;
    this.딧 = 땺.땃.딟(base.딟);
    this.딢 = this.딧 != 0 ? 0 : 1;
    if (Object.op_Inequality((Object) this.TallyTeamBackgrounds, (Object) null))
    {
      Color color = base.딟 != 0 ? GlobalAppData.딟.GameAssets.Red : GlobalAppData.딟.GameAssets.Blue;
      this.TallyTeamBackgrounds.InitailiseBackgroundColours(color, color, false);
    }
    this.UpdateTallyScreenDisplayTimer();
  }

  public override void OpenNextTallyScreen()
  {
    if (this.get_bPlayerHasLeveledUp())
      this.LevelUpScreen.ActivateLevelUpScreen(base.딟, ((Component) this).transform.position, this.딟, this.땄, base.딟);
    else if (this.ShouldShowCoinsScreen() && this.HasLocalPlayerBeenAwardedCoins())
      this.CoinScreen.ActivateTallyScreen(base.딟);
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
    if (TallyXPScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      TallyXPScreenHandler.딟 = new Dictionary<string, int>(2)
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
    if (!TallyXPScreenHandler.딟.TryGetValue(key, out num))
      return;
    if (num != 0)
    {
      if (num != 1)
        return;
      this.UnitGrid.SkipAllXPFillAnims();
      this.PlayerXPBar.FinishXPBarFillAnimation();
      this.DeactivateSkipButton();
    }
    else
      this.OpenNextTallyScreen();
  }

  [CompilerGenerated]
  [SpecialName]
  public bool get_bPlayerHasLeveledUp() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public bool get_bPlayerHasXPBoost() => this.땄;
}
