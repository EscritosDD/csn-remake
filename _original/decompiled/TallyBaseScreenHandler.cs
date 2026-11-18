// Decompiled with JetBrains decompiler
// Type: TallyBaseScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TallyBaseScreenHandler : BaseHUDScreenHandler
{
  private 딢.땿 딟 = new 딢.땿();
  public float MaximumScreenDisplayTime;
  protected 딶.땖 딟;
  protected bool 딟;
  protected bool 땄;
  protected int 딟 = -1;
  protected int 땄 = -1;
  protected int 딧 = -1;
  protected int 딢 = -1;
  public SquadTeamBackgroundsHandler TallyTeamBackgrounds;
  public PlayerInformationVersusBar TallyPlayerInfo;
  public GameStatusBoxHandler TallyGameStatusBox;
  public TurnCountTextBox TallyTurnInfoBox;
  public SquadTeamRosterGrid TallyTeam1Grid;
  public SquadTeamRosterGrid TallyTeam2Grid;
  public GameObject SkipButton;
  public GameObject ContinueButton;
  public GameObject CharacterFloor;
  public EventDrivenMessagingPopup EventPopupPrefab;
  public EventDrivenMessagingPopupMapPack EventPopupMapPackPrefab;
  public EventDrivenMessagingPopupMapPack EventPopupCharacterPrefab;

  public void ActivateTallyScreen(딶.땖 State)
  {
    this.딟 = State;
    this.ActivateMenu();
    this.딟 = true;
    this.set_ScreenAnimationsSkipped(false);
    if ((double) this.MaximumScreenDisplayTime <= 0.0)
      return;
    this.딟.딟(this.MaximumScreenDisplayTime);
  }

  public void DeactivateTallyScreen()
  {
    this.StopAnyTallyScreenSpecificAudio();
    this.CleanUpTallyScreenData();
    this.딟 = false;
  }

  public void AskForReview()
  {
  }

  public virtual void PreInitailiseTallyScreenData()
  {
  }

  public virtual void StopAnyTallyScreenSpecificAudio()
  {
  }

  public virtual void CleanUpTallyScreenData()
  {
  }

  public virtual void OpenNextTallyScreen()
  {
  }

  public void InitialiseTallyScreenData(
    bool SetTeamBackgroundsActiveTeamColour,
    bool ShowAllTeamMembersAlive,
    bool ShowAlternatePlayerInfoBar,
    bool ShowOppositionInfo,
    bool ShowCharacterFloor)
  {
    if (this.딟 == null)
      return;
    this.딟 = this.딟.땂();
    this.땄 = this.딟 != 0 ? 0 : 1;
    this.딧 = 땺.땃.딟(this.딟);
    this.딢 = this.딧 != 0 ? 0 : 1;
    this.PreInitailiseTallyScreenData();
    if (Object.op_Inequality((Object) this.TallyTeamBackgrounds, (Object) null))
    {
      Color Team1Colour = this.딟 != 0 ? GlobalAppData.딟.GameAssets.Red : GlobalAppData.딟.GameAssets.Blue;
      Color color = this.땄 != 0 ? GlobalAppData.딟.GameAssets.Red : GlobalAppData.딟.GameAssets.Blue;
      this.TallyTeamBackgrounds.InitailiseBackgroundColours(Team1Colour, !SetTeamBackgroundsActiveTeamColour ? color : Team1Colour, ShowOppositionInfo);
    }
    if (Object.op_Inequality((Object) this.TallyPlayerInfo, (Object) null))
      this.TallyPlayerInfo.InitailisePlayerInformationBar(this.딟, this.딟, this.땄, ShowAlternatePlayerInfoBar, (Material) null, (Material) null, ShowOppositionInfo);
    if (Object.op_Inequality((Object) this.TallyGameStatusBox, (Object) null))
      this.TallyGameStatusBox.InitailiseGameStatusBox(this.딟, this.딟, this.땄);
    if (Object.op_Inequality((Object) this.TallyTurnInfoBox, (Object) null))
      this.TallyTurnInfoBox.InitialiseTurnCountBox(this.딟);
    if (Object.op_Inequality((Object) this.TallyTeam1Grid, (Object) null))
      this.TallyTeam1Grid.PopulateTeamRosterGrid(this.딟, this.딟, ShowAllTeamMembersAlive, false);
    if (Object.op_Inequality((Object) this.TallyTeam2Grid, (Object) null))
      this.TallyTeam2Grid.PopulateTeamRosterGrid(this.딟, this.땄, ShowAllTeamMembersAlive, true);
    if (!Object.op_Inequality((Object) this.CharacterFloor, (Object) null))
      return;
    this.CharacterFloor.SetActive(ShowCharacterFloor);
  }

  protected void UpdateTallyScreenDisplayTimer()
  {
    if ((double) this.MaximumScreenDisplayTime <= 0.0 || this.땄)
      return;
    this.딟.딟();
    if (!this.딟.땄())
      return;
    this.DisableContinueButton();
    this.OpenNextTallyScreen();
  }

  protected void DisableContinueButton()
  {
    if (!Object.op_Inequality((Object) this.ContinueButton, (Object) null))
      return;
    this.ContinueButton.SetActive(false);
  }

  public virtual bool GetTotalPlayerAwardXP(
    int TeamIndex,
    out int TotalXP,
    out int TotalXPWithBoost,
    out int CurrentPlayerXP)
  {
    CurrentPlayerXP = GlobalAppData.땽().딣();
    return this.딟.땄(TeamIndex, this.딢, out TotalXP, out TotalXPWithBoost);
  }

  protected virtual void SaveXP(out bool ShouldDisplayIncentivisationScreen)
  {
    ShouldDisplayIncentivisationScreen = false;
    if (this.딟 == null)
      return;
    int PlayerXP;
    int PlayerXPWithBoost;
    this.CalculateXP(out PlayerXP, out PlayerXPWithBoost, out int _);
    this.SaveXP(PlayerXP, PlayerXPWithBoost, out ShouldDisplayIncentivisationScreen);
  }

  protected void SaveXP(int AwardedXPBase, int AwardedXP) => this.SaveXP(AwardedXPBase, AwardedXP, out bool _);

  protected int CalculateScore(int BaseXP)
  {
    int num1 = (this.딟.딥().Count + 1) / 2;
    int num2 = num1 >= 5 ? 0 : Mathf.RoundToInt((float) BaseXP / ((float) num1 * 0.1f));
    return Mathf.RoundToInt((float) BaseXP / 0.3f) + num2;
  }

  protected void SaveXP(
    int AwardedXPBase,
    int AwardedXP,
    out bool ShouldDisplayIncentivisationScreen)
  {
    GlobalAppData.땽().딟(AwardedXP, GlobalAppData.딢().GenericData.딟());
    bool flag = false;
    if (this.딟.떓() == 딶.딹.땄)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      TallyBaseScreenHandler.땐 땐 = new TallyBaseScreenHandler.땐();
      // ISSUE: reference to a compiler-generated field
      땐.딟 = this.딟.땠();
      // ISSUE: reference to a compiler-generated field
      if (Object.op_Inequality((Object) 땐.딟, (Object) null))
      {
        int score = this.CalculateScore(AwardedXPBase);
        GlobalAppData.땽().딟(this.딟, score, out flag);
        딢.떇.땄(this.딟.딛());
        // ISSUE: reference to a compiler-generated method
        딢.땃 땃 = GlobalAppData.땼().딷().FirstOrDefault<딢.땃>(new Func<딢.땃, bool>(땐.딟));
        if (땃 != null && ChallengePackAsset.딟(땃.딝()))
        {
          // ISSUE: reference to a compiler-generated field
          GlobalAppData.땽().땄(땐.딟.ChallengePackCompletionAchievement);
        }
        if (GlobalAppData.떏().땥())
        {
          // ISSUE: reference to a compiler-generated field
          ((딟.땇) GlobalAppData.떏()).딟("challenges", 딟.딗.땃(땐.딟.Id), score);
        }
      }
    }
    else if (this.딟.떓() == 딶.딹.딧)
    {
      int score = this.CalculateScore(AwardedXPBase);
      GlobalAppData.땽().딢(score);
    }
    GlobalAppData.땽().땥();
    if (this.딟.떓() == 딶.딹.딧)
    {
      if (this.딟.딟.딢())
        GlobalAppData.떏().땼(this.딟.딟.딟);
      else if (!this.딟.딟.땄() || !this.DisputeGame())
        GlobalAppData.떏().땂(this.딟.딟.딧);
    }
    ShouldDisplayIncentivisationScreen = false;
    if (this.딟.떔() is 딶.딖 || !GlobalAppData.땽().떁() || GlobalAppData.땽().딢(딢.땹.땲) < GlobalAppData.딟.EmailIncentivisationFrequency)
      return;
    ShouldDisplayIncentivisationScreen = true;
  }

  protected void CalculateXP(out int PlayerXP, out int PlayerXPWithBoost, out int OldPlayerXP)
  {
    땺.땃 땃 = new 땺.땃(this.딟);
    foreach (int index in this.딟.딧(this.딟))
    {
      int num = 땃.딢(index);
      땓.떀 떀1 = this.딟.땻()[index] as 땓.떀;
      땓.떀 떀2 = GlobalAppData.땽().딟(떀1);
      if (떀2 != null)
      {
        땓.떀 떀3 = 떀2.딗();
        땓.떀 떀4 = 떀3;
        떀4.땄(떀4.땝() + num);
        GlobalAppData.땽().딧(떀3);
      }
    }
    this.GetTotalPlayerAwardXP(this.딟, out PlayerXP, out PlayerXPWithBoost, out OldPlayerXP);
  }

  private bool DisputeGame()
  {
    땄.땞 딟 = this.딟.딟.딟;
    if (딟 == null || 딟.딟.Length < 2 || this.딟.땞().IgnoreGameValidation)
      return false;
    if (this.딟.딟(딟.딟[0].딢(), 딟.딟[1].딢()) == null)
      return false;
    GlobalAppData.떏().딟(딟, 딟.딟.Length - 1);
    return true;
  }

  protected bool ShouldShowCoinsScreen() => this.딟.떓() != 딶.딹.땄;

  protected bool HasLocalPlayerBeenAwardedCoins()
  {
    int num1;
    int num2;
    this.딟.딟(this.딧, this.딢, out num1, out num2);
    return this.딟 == this.딧 ? num1 > 0 : num2 > 0;
  }

  public void StartSubThemePlaying() => GlobalAppData.땓();

  public void ExitToFrontEnd() => Application.LoadLevelAsync(GlobalAppData.딟.EnvSettings.ScenesAsset.Data.땄());

  protected void UpdatePlayerInfoBar(bool ShowAlternate, bool ShowOpposing)
  {
    if (!Object.op_Inequality((Object) this.TallyPlayerInfo, (Object) null))
      return;
    this.TallyPlayerInfo.InitailisePlayerInformationBar(this.딟, this.딟, this.땄, ShowAlternate, (Material) null, (Material) null, ShowOpposing);
  }

  protected void ShowEventDrivenMessagingPopup()
  {
    딢.땕 Event = 딢.딚.딟(this.딟, this.딟);
    if (Event == null)
      return;
    Vector3 vector3;
    // ISSUE: explicit constructor call
    ((Vector3) ref vector3).\u002Ector(0.0f, 2f, 0.0f);
    if (Event.딢() == 딢.땪.딶 || Event.딢() == 딢.땪.땺)
    {
      if (!Object.op_Inequality((Object) this.EventPopupMapPackPrefab, (Object) null))
        return;
      EventDrivenMessagingPopupMapPack messagingPopupMapPack = Object.Instantiate((Object) this.EventPopupMapPackPrefab) as EventDrivenMessagingPopupMapPack;
      ((Component) messagingPopupMapPack).transform.position = Vector3.op_Addition(((Component) this).transform.position, vector3);
      messagingPopupMapPack.Init(Event);
    }
    else if (Event.딢() == 딢.땪.땥 || Event.딢() == 딢.땪.딝)
    {
      if (!Object.op_Inequality((Object) this.EventPopupCharacterPrefab, (Object) null))
        return;
      EventDrivenMessagingPopupMapPack messagingPopupMapPack = Object.Instantiate((Object) this.EventPopupCharacterPrefab) as EventDrivenMessagingPopupMapPack;
      ((Component) messagingPopupMapPack).transform.position = Vector3.op_Addition(((Component) this).transform.position, vector3);
      messagingPopupMapPack.Init(Event);
    }
    else
    {
      EventDrivenMessagingPopup drivenMessagingPopup = Object.Instantiate((Object) this.EventPopupPrefab) as EventDrivenMessagingPopup;
      ((Component) drivenMessagingPopup).transform.position = Vector3.op_Addition(((Component) this).transform.position, vector3);
      drivenMessagingPopup.Init(Event);
    }
  }

  protected void SetupChallengePackLoad()
  {
    if (GlobalAppData.딟.딟() != GlobalAppState.땊.떂)
      return;
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    TallyBaseScreenHandler.땡 땡 = new TallyBaseScreenHandler.땡();
    // ISSUE: reference to a compiler-generated field
    땡.딟 = this.딟.땠();
    // ISSUE: reference to a compiler-generated field
    if (!Object.op_Inequality((Object) 땡.딟, (Object) null))
      return;
    // ISSUE: reference to a compiler-generated method
    딢.땃 땃 = GlobalAppData.땼().딷().First<딢.땃>(new Func<딢.땃, bool>(땡.딟));
    if (땃 == null)
      return;
    GlobalAppData.딟.딧(땃.딧());
  }

  [CompilerGenerated]
  [SpecialName]
  public bool get_ScreenAnimationsSkipped() => this.딧;

  [CompilerGenerated]
  [SpecialName]
  protected void set_ScreenAnimationsSkipped(bool value) => this.딧 = value;
}
