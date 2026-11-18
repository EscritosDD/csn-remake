// Decompiled with JetBrains decompiler
// Type: FakeLoadingScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class FakeLoadingScreen : MonoBehaviour
{
  private float 딟;
  private Vector3 딟;
  private bool 딟;
  private 딶.땖 딟;
  private AsyncOperation 딟;
  public MoneyDisplayHandler MoneyDisplay;
  public SplashScreenHandler SplashScreen;
  public SquadTeamBackgroundsHandler TeamBackgrounds;
  public PlayerInformationVersusBar PlayerInfo;
  public GameStatusBoxHandler GameStatusBox;
  public TurnCountTextBox TurnInfoBox;
  public SquadTeamRosterGrid Team1Grid;
  public SquadTeamRosterGrid Team2Grid;
  public GameObject loadingInfoBox;
  public GuiText3D MapNameText;
  public GameObject turnCountBox;

  private void Start() => this.딟 = ((Component) this).transform.position;

  public void ActivateMenu(딶.땖 GameToLoad, bool LoadingIntoGame)
  {
    ((Component) this).transform.position = Vector3.zero;
    this.딟 = LoadingIntoGame;
    if (Object.op_Inequality((Object) this.loadingInfoBox, (Object) null))
      this.loadingInfoBox.SetActive(true);
    if (GameToLoad == null)
      return;
    this.딟 = GameToLoad;
    if (LoadingIntoGame)
    {
      List<딟.땩> 땩List = GameToLoad.땟();
      GlobalAppData.딟.떏();
      GlobalAppData.땼().딟(땩List);
      if (GlobalAppData.딝())
        GlobalAppData.땺();
      if (GlobalAppData.떎())
        GlobalAppData.땥();
      this.딟 = Time.time + 0.25f;
      if (GameToLoad.떔() is 딶.딖)
        ((Component) this).transform.position = this.딟;
    }
    if (Object.op_Inequality((Object) this.MoneyDisplay, (Object) null))
      ((Component) this.MoneyDisplay).gameObject.SetActive(false);
    int num1 = GameToLoad.땂();
    int num2 = num1 != 0 ? 0 : 1;
    Color Team1Colour = num1 != 0 ? GlobalAppData.딟.GameAssets.Red : GlobalAppData.딟.GameAssets.Blue;
    Color Team2Colour = num2 != 0 ? GlobalAppData.딟.GameAssets.Red : GlobalAppData.딟.GameAssets.Blue;
    if (Object.op_Inequality((Object) this.TeamBackgrounds, (Object) null))
      this.TeamBackgrounds.InitailiseBackgroundColours(Team1Colour, Team2Colour, true);
    if (Object.op_Inequality((Object) this.PlayerInfo, (Object) null))
    {
      this.PlayerInfo.InitailisePlayerInformationBar(GameToLoad, num1, num2, false, (Material) null, (Material) null, true);
      ((Component) this.PlayerInfo).gameObject.SetActive(true);
    }
    if (Object.op_Inequality((Object) this.GameStatusBox, (Object) null))
    {
      딶.땙 Turn = !LoadingIntoGame ? GameToLoad.떂() : GameToLoad.딦();
      if (GameToLoad.떓() == 딶.딹.딧)
        this.GameStatusBox.InitailiseGameStatusBox(GameToLoad, num1, num2, Turn);
      else
        this.GameStatusBox.InitailiseGameStatusBox(GameToLoad, num1, num2);
    }
    if (Object.op_Inequality((Object) this.TurnInfoBox, (Object) null))
    {
      this.TurnInfoBox.InitialiseTurnCountBox(GameToLoad);
      this.turnCountBox.SetActive(true);
    }
    bool InDeploymentMode = GameToLoad.떁() || !땓.땞.딧(GameToLoad);
    딶.땙 Turn1 = !LoadingIntoGame ? GameToLoad.떂() : GameToLoad.딦();
    if (Object.op_Inequality((Object) this.Team1Grid, (Object) null))
    {
      if (GameToLoad.떓() == 딶.딹.딧)
        this.Team1Grid.PopulateTeamRosterGrid(GameToLoad, num1, InDeploymentMode, Turn1, false);
      else
        this.Team1Grid.PopulateTeamRosterGrid(GameToLoad, num1, InDeploymentMode, false);
    }
    if (Object.op_Inequality((Object) this.Team2Grid, (Object) null))
    {
      if (GameToLoad.떓() == 딶.딹.딧)
        this.Team2Grid.PopulateTeamRosterGrid(GameToLoad, num2, InDeploymentMode, Turn1, true);
      else
        this.Team2Grid.PopulateTeamRosterGrid(GameToLoad, num2, InDeploymentMode, true);
    }
    if (!Object.op_Inequality((Object) this.MapNameText, (Object) null))
      return;
    this.MapNameText.LocText = GlobalAppData.땼().딷(GameToLoad.딟.땄);
    this.MapNameText.UpdateMesh();
  }

  public void DeactivateMenu()
  {
    ((Component) this).transform.position = this.딟;
    if (!Object.op_Inequality((Object) this.MoneyDisplay, (Object) null))
      return;
    ((Component) this.MoneyDisplay).gameObject.SetActive(true);
  }

  private void Update()
  {
    if (!this.딟)
      return;
    if (this.딟 != null && this.딟.isDone)
    {
      this.딟 = (AsyncOperation) null;
      딢.딳.딟(this.딟);
    }
    if ((double) this.딟 == 0.0 || (double) Time.time <= (double) this.딟)
      return;
    this.딟 = 0.0f;
    딢.딳.딟(this.딟);
  }
}
