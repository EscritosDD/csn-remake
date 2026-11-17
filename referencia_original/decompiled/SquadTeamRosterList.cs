// Decompiled with JetBrains decompiler
// Type: SquadTeamRosterList
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class SquadTeamRosterList : MonoBehaviour
{
  public Material BackgroundGrey;
  public Material BackgroundBlue;
  public Material BackgroundRed;
  public Shader DeadUnitIconShader;
  public SquadRosterUnitPanel[] SquadPanels;
  public int MaxNumPanels;

  public string SetTeamRoster(딶.땖 State, 딶.땂 ActiveTeam, Vector3 ScreenSize, bool InDeploymentMode)
  {
    int index1 = 0;
    string str = string.Empty;
    Material TeamBackgroundMaterial = ActiveTeam != 딶.땂.딟 ? this.BackgroundRed : this.BackgroundBlue;
    this.ResetSquadRosterPanels();
    foreach (int index2 in State.딧(ActiveTeam != 딶.땂.딟 ? 1 : 0))
    {
      if (State.땻()[index2] is 땓.떀 Character1 && index1 < this.SquadPanels.Length)
      {
        if (Character1.땁().ClassType == 땓.땅.땃)
          str = Character1.땹();
        this.SetPanelActive(index1, true);
        땓.땊 UnitData = State.떂().땺()[index2];
        if (!this.SquadPanels[index1].SetUnitData(UnitData, Character1, TeamBackgroundMaterial, this.BackgroundGrey, this.DeadUnitIconShader, InDeploymentMode, false))
          this.SetPanelActive(index1, false);
        ++index1;
      }
    }
    this.PositionTeamRosterPanels(index1, ScreenSize);
    return str;
  }

  private void ResetSquadRosterPanels()
  {
    for (int Index = 0; Index < this.SquadPanels.Length; ++Index)
      this.SetPanelActive(Index, false);
  }

  private void SetPanelActive(int Index, bool Active)
  {
    if (Index >= this.SquadPanels.Length)
      return;
    ((Component) this.SquadPanels[Index]).gameObject.SetActive(Active);
  }

  private void PositionTeamRosterPanels(int NumActivePanels, Vector3 ScreenSize)
  {
    if (this.SquadPanels.Length <= 0)
      return;
    MeshFilter panelBackgroundMesh = this.SquadPanels[0].GetPanelBackgroundMesh();
    if (!Object.op_Inequality((Object) panelBackgroundMesh, (Object) null))
      return;
    Bounds bounds = panelBackgroundMesh.sharedMesh.bounds;
    Vector3 size = ((Bounds) ref bounds).size;
    Vector3 localScale = ((Component) this.SquadPanels[0]).transform.localScale;
    ref Vector3 local1 = ref size;
    local1.x = local1.x * localScale.x;
    float num1 = (float) (ScreenSize.x - size.x * (double) this.MaxNumPanels) / (float) (this.MaxNumPanels + 1);
    float num2 = (float) ((double) NumActivePanels * size.x + (double) (NumActivePanels + 1) * (double) num1);
    float num3 = (float) (size.x * 0.5 + (double) num1 - (double) num2 * 0.5);
    for (int index = 0; index < NumActivePanels; ++index)
    {
      Vector3 position = ((Component) this.SquadPanels[index]).transform.position;
      ref Vector3 local2 = ref position;
      local2.x = (__Null) (local2.x + (double) num3);
      ((Component) this.SquadPanels[index]).transform.position = position;
      num3 += (float) size.x + num1;
    }
  }
}
