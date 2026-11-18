// Decompiled with JetBrains decompiler
// Type: DeployableSelectionHUDGrid
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class DeployableSelectionHUDGrid : BaseHUDGrid
{
  public float GridXOffset;
  public DeployableSelectionHUDButton[] DeployableGridButtons;
  public Material DeployableCoverThumb;
  public Material DeployableGunTurretThumb;
  public Material DeployableMineThumb;
  public Material DeployableRemoteChargeThumb;
  public Material DeployableRocketTurretThumb;
  public Material DeployableUAVThumb;
  public Material DeployableRiotShieldThumb;

  public bool PopulateDeployablesGrid(
    딶.땯 TurnsStage,
    딶.땂 ActiveTeam,
    Material TeamMaterial,
    Material SelectedMaterial,
    float Xposition)
  {
    int NumActiveButtons = 0;
    this.ResetDeployablesGridButtons();
    if (TurnsStage != null)
    {
      for (int index = 0; index < 딶.딡.땴().땼().땻().Count; ++index)
      {
        if (!(딶.딡.땴().땼().땻()[index] is 딶.땉))
          ;
      }
    }
    this.PositionTeamSelectionGridPanels(NumActiveButtons);
    ((Component) this).transform.localPosition = new Vector3(Xposition + this.GridXOffset, (float) ((Component) this).transform.localPosition.y, (float) ((Component) this).transform.localPosition.z);
    this.set_bGridOpen(NumActiveButtons > 0);
    return this.get_bGridOpen();
  }

  public override void ShutDownGrid()
  {
    this.set_bGridOpen(false);
    for (int index = 0; index < this.DeployableGridButtons.Length; ++index)
      this.DeployableGridButtons[index].ShutDownDeployableSelectionButton();
  }

  private void ResetDeployablesGridButtons()
  {
    for (int Index = 0; Index < this.DeployableGridButtons.Length; ++Index)
      this.SetDeployableButtonActive(Index, false);
  }

  private void SetDeployableButtonActive(int Index, bool Active)
  {
    if (Index >= this.DeployableGridButtons.Length)
      return;
    ((Component) this.DeployableGridButtons[Index]).gameObject.SetActive(Active);
  }

  private void PositionTeamSelectionGridPanels(int NumActiveButtons)
  {
    if (this.DeployableGridButtons.Length <= 0)
      return;
    MeshFilter panelBackgroundMesh = this.DeployableGridButtons[0].GetPanelBackgroundMesh();
    if (!Object.op_Inequality((Object) panelBackgroundMesh, (Object) null))
      return;
    Vector3 backgroundLocalScale = this.DeployableGridButtons[0].GetPanelBackgroundLocalScale();
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
    Vector3 CurrPanelPos = Vector3.zero;
    for (int index = 0; index < NumActiveButtons; ++index)
    {
      CurrPanelPos = this.GetNextPanelPosition(ref CurrPanelRowIdx, ref CurrPanelColumnIdx, CurrPanelPos, PanelSize, false);
      ((Component) this.DeployableGridButtons[index]).transform.localPosition = CurrPanelPos;
    }
  }
}
