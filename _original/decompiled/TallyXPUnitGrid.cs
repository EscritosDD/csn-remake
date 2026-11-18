// Decompiled with JetBrains decompiler
// Type: TallyXPUnitGrid
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using UnityEngine;

public class TallyXPUnitGrid : BaseHUDGrid
{
  public TallyXPUnitGridPanel[] XPUnitGridPanels;

  public bool PopulateUnitXPGrid(딶.땖 GameState, int PlayerIndex, Material TeamMaterial)
  {
    int index = 0;
    땺.땃 XPStore = new 땺.땃(GameState);
    this.ResetXPGridPanels();
    foreach (int num in GameState.딧(PlayerIndex))
    {
      if (GameState.땻()[num] is 땓.떀 Character1 && index < this.XPUnitGridPanels.Length)
      {
        this.SetPanelActive(index, true);
        땓.땊 UnitData = GameState.떂().땺()[num];
        if (!this.XPUnitGridPanels[index].InitaliseXPUnitGridPanel(XPStore, UnitData, num, Character1, TeamMaterial, true))
          this.SetPanelActive(index, false);
        ++index;
      }
    }
    this.PositionUnitXPGridPanels(index);
    this.set_bGridOpen(index > 0);
    return this.get_bGridOpen();
  }

  public void SkipAllXPFillAnims()
  {
    for (int index = 0; index < this.XPUnitGridPanels.Length; ++index)
      this.XPUnitGridPanels[index].SkipXPFillAnim();
  }

  private void ResetXPGridPanels()
  {
    for (int Index = 0; Index < this.XPUnitGridPanels.Length; ++Index)
      this.SetPanelActive(Index, false);
  }

  private void SetPanelActive(int Index, bool Active)
  {
    if (Index >= this.XPUnitGridPanels.Length)
      return;
    ((Component) this.XPUnitGridPanels[Index]).gameObject.SetActive(Active);
  }

  private void PositionUnitXPGridPanels(int NumActivePanels)
  {
    if (this.XPUnitGridPanels.Length <= 0)
      return;
    MeshFilter panelBackgroundMesh = this.XPUnitGridPanels[0].GetPanelBackgroundMesh();
    if (!Object.op_Inequality((Object) panelBackgroundMesh, (Object) null))
      return;
    Vector3 backgroundLocalScale = this.XPUnitGridPanels[0].GetPanelBackgroundLocalScale();
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
      ((Component) this.XPUnitGridPanels[index]).transform.localPosition = nextPanelPosition;
    }
  }

  [CompilerGenerated]
  [SpecialName]
  public float get_MaximumXValue() => this.딟;
}
