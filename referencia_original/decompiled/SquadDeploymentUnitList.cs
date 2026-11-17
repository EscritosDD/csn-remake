// Decompiled with JetBrains decompiler
// Type: SquadDeploymentUnitList
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class SquadDeploymentUnitList : MonoBehaviour
{
  public Material BackgroundBlue;
  public Material BackgroundSelectedBlue;
  public Material BackgroundRed;
  public Material BackgroundSelectedRed;
  public SquadDeploymentUnitButton[] DeploymentButtons;
  public int MaxNumPanels;

  public void SetSquadDeploymentList(딶.땂 ActiveTeam, Vector3 ScreenSize)
  {
    int index = 0;
    Material TeamBackgroundMaterial = ActiveTeam != 딶.땂.딟 ? this.BackgroundRed : this.BackgroundBlue;
    Material TeamBackgroundSelectedMaterial = ActiveTeam != 딶.땂.딟 ? this.BackgroundSelectedRed : this.BackgroundSelectedBlue;
    this.ResetSquadDeploymentButtons();
    foreach (int num in 딶.딡.땴().땼().딧(ActiveTeam != 딶.땂.딟 ? 1 : 0))
    {
      if (딶.딡.땴().땼().땻()[num] is 땓.떀 Character1 && index < this.DeploymentButtons.Length)
      {
        this.SetButtonActive(index, true);
        if (!this.DeploymentButtons[index].SetDeploymentButtonData(num, index, TeamBackgroundMaterial, TeamBackgroundSelectedMaterial, Character1))
          this.SetButtonActive(index, false);
        ++index;
      }
    }
    this.PositionTeamDeploymentButtons(index, ScreenSize);
  }

  private void PositionTeamDeploymentButtons(int NumActivePanels, Vector3 ScreenSize)
  {
    if (this.DeploymentButtons.Length <= 0)
      return;
    MeshFilter component = this.DeploymentButtons[0].UnitThumbBackground.GetComponent<MeshFilter>();
    if (!Object.op_Inequality((Object) component, (Object) null))
      return;
    Bounds bounds = component.sharedMesh.bounds;
    Vector3 size = ((Bounds) ref bounds).size;
    Vector3 localScale = ((Component) this.DeploymentButtons[0]).transform.localScale;
    ref Vector3 local = ref size;
    local.x = local.x * localScale.x;
    float num1 = (float) (ScreenSize.x - size.x * (double) this.MaxNumPanels) / (float) (this.MaxNumPanels + 1);
    float num2 = (float) ((double) NumActivePanels * size.x + (double) (NumActivePanels + 1) * (double) num1);
    float num3 = (float) (size.x * 0.5 + (double) num1 - (double) num2 * 0.5);
    for (int index = 0; index < NumActivePanels; ++index)
    {
      ((Component) this.DeploymentButtons[index]).transform.localPosition = new Vector3(num3, (float) ((Component) this.DeploymentButtons[index]).transform.localPosition.y, (float) ((Component) this.DeploymentButtons[index]).transform.localPosition.z);
      num3 += (float) size.x + num1;
    }
  }

  private void ResetSquadDeploymentButtons()
  {
    for (int Index = 0; Index < this.DeploymentButtons.Length; ++Index)
      this.SetButtonActive(Index, false);
  }

  private void SetButtonActive(int Index, bool Active)
  {
    if (Index >= this.DeploymentButtons.Length)
      return;
    ((Component) this.DeploymentButtons[Index]).gameObject.SetActive(Active);
  }

  public void SetAllButtonsSelectionState(bool Selected)
  {
    for (int Index = 0; Index < this.DeploymentButtons.Length; ++Index)
    {
      if (!this.DeploymentButtons[Index].get_Deployed())
        this.SetButtonSelected(Index, Selected);
    }
  }

  public void SetButtonSelected(int Index, bool Selected)
  {
    if (Index >= this.DeploymentButtons.Length)
      return;
    this.DeploymentButtons[Index].ToggleDeploymentPanelSelected(Selected);
  }
}
