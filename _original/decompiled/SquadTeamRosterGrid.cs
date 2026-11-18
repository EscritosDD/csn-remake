// Decompiled with JetBrains decompiler
// Type: SquadTeamRosterGrid
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class SquadTeamRosterGrid : BaseHUDGrid
{
  public Material BackgroundGrey;
  public Material BackgroundBlue;
  public Material BackgroundRed;
  public Shader DeadUnitIconShader;
  public SquadRosterUnitPanel[] SquadRosterGridPanels;

  public bool PopulateTeamRosterGrid(
    딶.땖 State,
    int TeamIndex,
    bool InDeploymentMode,
    bool IsOnRight)
  {
    return this.PopulateTeamRosterGrid(State, TeamIndex, InDeploymentMode, State.떂(), IsOnRight);
  }

  public bool PopulateTeamRosterGrid(
    딶.땖 State,
    int TeamIndex,
    bool InDeploymentMode,
    딶.땙 Turn,
    bool IsOnRight)
  {
    if (Turn == null)
      Turn = State.떂();
    int index1 = 0;
    Material TeamBackgroundMaterial = TeamIndex != 0 ? this.BackgroundRed : this.BackgroundBlue;
    this.ResetSquadRosterPanels();
    foreach (int index2 in State.딧(TeamIndex))
    {
      if (State.땻()[index2] is 땓.떀 Character1 && index1 < this.SquadRosterGridPanels.Length)
      {
        this.SetPanelActive(index1, true);
        땓.땊 UnitData = Turn.땺()[index2];
        if (!this.SquadRosterGridPanels[index1].SetUnitData(UnitData, Character1, TeamBackgroundMaterial, this.BackgroundGrey, this.DeadUnitIconShader, InDeploymentMode, IsOnRight))
          this.SetPanelActive(index1, false);
        ++index1;
      }
    }
    this.PositionTeamSelectionGridPanels(index1);
    this.set_bGridOpen(index1 > 0);
    return this.get_bGridOpen();
  }

  private void ResetSquadRosterPanels()
  {
    for (int Index = 0; Index < this.SquadRosterGridPanels.Length; ++Index)
      this.SetPanelActive(Index, false);
  }

  private void SetPanelActive(int Index, bool Active)
  {
    if (Index >= this.SquadRosterGridPanels.Length)
      return;
    ((Component) this.SquadRosterGridPanels[Index]).gameObject.SetActive(Active);
  }

  private void PositionTeamSelectionGridPanels(int NumActivePanels)
  {
    if (this.SquadRosterGridPanels.Length <= 0)
      return;
    MeshFilter panelBackgroundMesh = this.SquadRosterGridPanels[0].GetPanelBackgroundMesh();
    if (!Object.op_Inequality((Object) panelBackgroundMesh, (Object) null))
      return;
    Vector3 backgroundLocalScale = this.SquadRosterGridPanels[0].GetPanelBackgroundLocalScale();
    Vector3 PanelSize;
    ref Vector3 local1 = ref PanelSize;
    Bounds bounds1 = panelBackgroundMesh.sharedMesh.bounds;
    // ISSUE: variable of the null type
    __Null local2 = ((Bounds) ref bounds1).size.x * backgroundLocalScale.x;
    Bounds bounds2 = panelBackgroundMesh.sharedMesh.bounds;
    // ISSUE: variable of the null type
    __Null local3 = ((Bounds) ref bounds2).size.y * backgroundLocalScale.y;
    Bounds bounds3 = panelBackgroundMesh.sharedMesh.bounds;
    // ISSUE: variable of the null type
    __Null local4 = ((Bounds) ref bounds3).size.z * backgroundLocalScale.z;
    // ISSUE: explicit constructor call
    ((Vector3) ref local1).\u002Ector((float) local2, (float) local3, (float) local4);
    int CurrPanelRowIdx = 0;
    int CurrPanelColumnIdx = 0;
    Vector3 nextPanelPosition;
    // ISSUE: explicit constructor call
    ((Vector3) ref nextPanelPosition).\u002Ector((float) PanelSize.x, 0.0f, 0.0f);
    for (int index = 0; index < NumActivePanels; ++index)
    {
      nextPanelPosition = this.GetNextPanelPosition(ref CurrPanelRowIdx, ref CurrPanelColumnIdx, nextPanelPosition, PanelSize, false);
      ((Component) this.SquadRosterGridPanels[index]).transform.localPosition = nextPanelPosition;
    }
  }
}
