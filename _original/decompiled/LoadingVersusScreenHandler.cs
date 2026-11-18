// Decompiled with JetBrains decompiler
// Type: LoadingVersusScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class LoadingVersusScreenHandler : MonoBehaviour
{
  public SquadTeamBackgroundsHandler TeamBackgrounds;
  public PlayerInformationVersusBar PlayerInfo;
  public GameStatusBoxHandler GameStatusBox;
  public TurnCountTextBox TurnInfoBox;
  public SquadTeamRosterGrid Team1Grid;
  public SquadTeamRosterGrid Team2Grid;
  public GuiText3D MapNameText;

  public void InitailiseVersusLoadScreen(딶.땖 State)
  {
    if (State == null)
      return;
    int num1 = State.땂();
    int num2 = num1 != 0 ? 0 : 1;
    Color Team1Colour = num1 != 0 ? GlobalAppData.딟.GameAssets.Red : GlobalAppData.딟.GameAssets.Blue;
    Color Team2Colour = num2 != 0 ? GlobalAppData.딟.GameAssets.Red : GlobalAppData.딟.GameAssets.Blue;
    if (Object.op_Inequality((Object) this.TeamBackgrounds, (Object) null))
      this.TeamBackgrounds.InitailiseBackgroundColours(Team1Colour, Team2Colour, true);
    if (Object.op_Inequality((Object) this.PlayerInfo, (Object) null))
      this.PlayerInfo.InitailisePlayerInformationBar(State, num1, num2, false, (Material) null, (Material) null, true);
    if (Object.op_Inequality((Object) this.GameStatusBox, (Object) null))
    {
      if (State.떓() == 딶.딹.딧)
        this.GameStatusBox.InitailiseGameStatusBox(State, num1, num2, State.딦());
      else
        this.GameStatusBox.InitailiseGameStatusBox(State, num1, num2);
    }
    if (Object.op_Inequality((Object) this.TurnInfoBox, (Object) null))
      this.TurnInfoBox.InitialiseTurnCountBox(State);
    bool InDeploymentMode = State.떁() || !땓.땞.딧(State);
    if (Object.op_Inequality((Object) this.Team1Grid, (Object) null))
    {
      if (State.떓() == 딶.딹.딧)
        this.Team1Grid.PopulateTeamRosterGrid(State, num1, InDeploymentMode, State.딦(), false);
      else
        this.Team1Grid.PopulateTeamRosterGrid(State, num1, InDeploymentMode, false);
    }
    if (Object.op_Inequality((Object) this.Team2Grid, (Object) null))
    {
      if (State.떓() == 딶.딹.딧)
        this.Team2Grid.PopulateTeamRosterGrid(State, num2, InDeploymentMode, State.딦(), true);
      else
        this.Team2Grid.PopulateTeamRosterGrid(State, num2, InDeploymentMode, true);
    }
    if (!Object.op_Inequality((Object) this.MapNameText, (Object) null))
      return;
    this.MapNameText.LocText = GlobalAppData.땼().딷(State.딟.땄);
    this.MapNameText.UpdateMesh();
  }
}
