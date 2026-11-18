// Decompiled with JetBrains decompiler
// Type: TallyLoadingScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Linq;
using UnityEngine;

public class TallyLoadingScreenHandler : MonoBehaviour
{
  private 딶.땖 딟;
  private 딢.딳.땝 딟;
  private bool 딟;
  private bool 땄;
  private 땓.떀 딟;
  private bool 딧;
  private Vector3 딟;
  private bool 딢;
  public TallyGameOverviewScreenHandler TallyGameOverviewScreen;
  public TallyTutorialScreenHandler TallyTutorialScreen;
  public FakeLoadingScreen LoadingScreen;
  public TallyVideoScreenHandler VideoScreen;

  private void Start()
  {
    GlobalAppData.땼().땥();
    this.딟 = ((Component) this).transform.position;
    this.ActivateMenu();
  }

  public void ActivateMenu()
  {
    ((Component) this).transform.position = Vector3.zero;
    this.딟 = true;
    this.딢 = true;
  }

  public void DeactivateMenu()
  {
    this.딢 = false;
    ((Component) this).transform.position = this.딟;
  }

  private void OnButtonPressed(string Command)
  {
    if (!this.딟)
      ;
  }

  private void UnlockAchievement(PlayerAchievement Achievement)
  {
    if (!this.딧)
      return;
    GlobalAppData.땽().땄(Achievement);
  }

  private void OnGameStateLoaded()
  {
    this.딧 = !(this.딟.떔() is 딶.딖);
    if (this.딟.떓() == 딶.딹.딧 && this.딟.딟.딧())
      this.딧 = false;
    int index1 = this.딟.땂();
    int num1 = (index1 + 1) % 2;
    int num2 = 땺.땃.딟(this.딟);
    if (index1 != num2)
      return;
    this.UnlockAchievement(this.딟.땹().WinAchievement);
    this.UnlockAchievement(GlobalAppData.딟.Achievements.OnceUponATime);
    if ((double) this.딟.땓(index1) >= 0.5)
      this.UnlockAchievement(GlobalAppData.딟.Achievements.SilverMedal);
    bool flag1 = true;
    땓.딽? nullable = new 땓.딽?();
    bool flag2 = true;
    foreach (int index2 in this.딟.딧(index1))
    {
      if (this.딟.떂().땺()[index2].땺())
        flag2 = false;
      땓.떀 떀 = this.딟.땻()[index2] as 땓.떀;
      if (떀.땁().ClassType != 땓.땅.땃)
      {
        if (!nullable.HasValue)
          nullable = new 땓.딽?(떀.땁().Gender);
        else if (nullable.Value != 떀.땁().Gender)
          flag1 = false;
      }
    }
    if (flag1 && nullable.HasValue)
    {
      if (nullable.Value == 땓.딽.딟)
        this.UnlockAchievement(GlobalAppData.딟.Achievements.ItsRainingWho);
      else
        this.UnlockAchievement(GlobalAppData.딟.Achievements.DietColaRules);
    }
    if (flag2)
      this.UnlockAchievement(GlobalAppData.딟.Achievements.GoldMedal);
    땺.땃 땃 = new 땺.땃(this.딟);
    if (땃 != null && 땃.땄()[index1])
      this.UnlockAchievement(GlobalAppData.딟.Achievements.HandsOn);
    if (this.딟.딥().Count <= 8)
      this.UnlockAchievement(GlobalAppData.딟.Achievements.FastTracker);
    if (this.딟.딥().Count <= 12)
      this.UnlockAchievement(GlobalAppData.딟.Achievements.SpeedPass);
    if (this.딟.딥().Count <= 16)
      this.UnlockAchievement(GlobalAppData.딟.Achievements.QuickDraw);
    if (this.딟.떓() == 딶.딹.딧)
      this.UnlockAchievement(GlobalAppData.딟.Achievements.IBeatInternet);
    if (!(this.딟.떔() is 딶.딮 딮))
      return;
    int num3 = this.딟.딝(index1);
    if (num3 != 1 || 딮.딢(this.딟) != index1)
      return;
    int num4 = this.딟.딝(num1);
    int num5 = this.딟.땃(index1);
    int num6 = this.딟.땃(num1);
    if (num3 >= num4 && num5 >= num6)
      return;
    this.UnlockAchievement(GlobalAppData.딟.Achievements.BackFromTheBrink);
  }

  public void Update()
  {
    if (!this.딢)
      return;
    if (!((딟.딗) GlobalAppData.땼()).땽())
    {
      if (this.딟)
      {
        this.딟 = 딢.딳.딧();
        if (this.딟 == null)
        {
          this.딟 = 딢.딳.딟(GlobalAppData.땃("com.warchestgames.radtactics.spmission302"));
        }
        else
        {
          this.StartLoadingCharacters();
          this.OnGameStateLoaded();
        }
        this.딟 = false;
      }
      else if (this.땄)
      {
        this.땄 = false;
        if (this.딟 != null)
          this.딟.땠();
      }
    }
    if (this.딟 != null && this.딟.땄())
    {
      this.딟 = this.딟.딟();
      this.OnGameStateLoaded();
      this.딟 = (딢.딳.땝) null;
    }
    if (!this.딢 || this.딟 || this.땄)
      return;
    this.OpenNextTallyNextScreen();
  }

  private void StartLoadingCharacters()
  {
    if (this.딟.떔() is 딶.딖)
    {
      this.딟 = GlobalAppData.땽().딧(GlobalAppData.땽().땝());
      if (this.딟 != null)
      {
        this.딟.땠();
        GlobalAppData.땼().딟((땓.딲) this.딟, 땓.땾.딟);
      }
    }
    else
    {
      foreach (int index in this.딟.땢())
        GlobalAppData.땼().딟(this.딟.땻()[index], 땓.땾.딟);
    }
    this.땄 = true;
  }

  private void OpenNextTallyNextScreen()
  {
    this.DeactivateMenu();
    if (this.딟.떔() is 딶.딖)
    {
      this.TallyTutorialScreen.ActivateTallyScreen(this.딟);
    }
    else
    {
      딢.땃 challengePack = this.GetChallengePack();
      if (this.HasCompletedChallengePack(challengePack))
      {
        this.VideoScreen.SetActiveVideoPath(this.IsLondonPack(challengePack));
        this.VideoScreen.ActivateTallyScreen(this.딟);
      }
      else
        this.TallyGameOverviewScreen.ActivateTallyScreen(this.딟);
    }
  }

  private bool HasCompletedChallengePack(딢.땃 pack) => pack != null && !ChallengePackAsset.딟(this.딟.땠().Id) && ChallengePackAsset.땄(pack.딝());

  private 딢.땃 GetChallengePack()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    TallyLoadingScreenHandler.딻 딻 = new TallyLoadingScreenHandler.딻();
    // ISSUE: reference to a compiler-generated field
    딻.딟 = this.딟.땠();
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated method
    return Object.op_Inequality((Object) 딻.딟, (Object) null) ? GlobalAppData.땼().딷().FirstOrDefault<딢.땃>(new Func<딢.땃, bool>(딻.딟)) : (딢.땃) null;
  }

  private bool IsLondonPack(딢.땃 pack) => pack.땺().Contains("london");
}
