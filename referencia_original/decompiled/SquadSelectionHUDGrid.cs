// Decompiled with JetBrains decompiler
// Type: SquadSelectionHUDGrid
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using UnityEngine;

public class SquadSelectionHUDGrid : BaseHUDGrid
{
  public SquadSelectionHUDUnitButton[] SquadSelectionGridPanels;

  public bool PopulateTeamSelection(
    딶.땯 TurnsStage,
    딶.땂 ActiveTeam,
    Material TeamMaterial,
    Material SelectedMaterial)
  {
    int index = 0;
    this.ResetSquadRosterPanels();
    if (TurnsStage != null)
    {
      int num1 = ActiveTeam != 딶.땂.딟 ? 1 : 0;
      foreach (int num2 in 딶.딡.땴().땼().딧(num1))
      {
        if (딶.딡.땴().땼().땻()[num2] is 땓.떀 Character3 && index < this.SquadSelectionGridPanels.Length)
        {
          this.SetPanelActive(index, true);
          땓.땊 UnitData = 딶.딡.땴().땼().떂().땺()[num2];
          Material TeamBackgroundMaterial = TurnsStage.땈() == null || TurnsStage.땈().땔() != num2 ? TeamMaterial : SelectedMaterial;
          if (!this.SquadSelectionGridPanels[index].SetSelectionButtonData(num2, index, TeamBackgroundMaterial, Character3, UnitData))
            this.SetPanelActive(index, false);
          else if (num1 != 딶.딡.땴().땼().딝())
          {
            if (this.SquadSelectionGridPanels[index].get_bUnitAlive())
            {
              int num3 = 0;
              int num4 = 0;
              TurnsStage.딟(out num4, out num3, num2);
              int num5 = Mathf.FloorToInt((float) (num3 + num4) * 0.5f);
              if (Object.op_Inequality((Object) this.SquadSelectionGridPanels[index].UnitPointsIcon, (Object) null))
                this.SquadSelectionGridPanels[index].UnitPointsIcon.SetActive(false);
              if (Object.op_Inequality((Object) this.SquadSelectionGridPanels[index].UnitPointsText, (Object) null))
                ((Component) this.SquadSelectionGridPanels[index].UnitPointsText).gameObject.SetActive(false);
              if (Object.op_Inequality((Object) this.SquadSelectionGridPanels[index].UnitDamageIcon, (Object) null))
              {
                GameObject unitDamageIcon = this.SquadSelectionGridPanels[index].UnitDamageIcon;
                TacticsGameAssets gameAssets = GlobalAppData.딟.GameAssets;
                if ((double) num5 >= (double) GlobalAppData.딟.GameAssets.HighDamageThreshold)
                {
                  unitDamageIcon.SetActive(true);
                  unitDamageIcon.renderer.material = GlobalAppData.땲().딟(gameAssets.HighDamageMaterial, gameAssets.HighDamageColour);
                }
                else if ((double) num5 >= (double) GlobalAppData.딟.GameAssets.MediumDamageThreshold)
                {
                  unitDamageIcon.SetActive(true);
                  unitDamageIcon.renderer.material = GlobalAppData.땲().딟(gameAssets.MediumDamageMaterial, gameAssets.MediumDamageColour);
                }
                else if (num5 > 0)
                {
                  unitDamageIcon.SetActive(true);
                  unitDamageIcon.renderer.material = GlobalAppData.땲().딟(gameAssets.LowDamageMaterial, gameAssets.LowDamageColour);
                }
                else
                  unitDamageIcon.SetActive(false);
              }
            }
            else
              this.SquadSelectionGridPanels[index].UnitDamageIcon.SetActive(false);
          }
          ++index;
        }
      }
    }
    // ISSUE: reference to a compiler-generated method
    this.set_MaximumXValue((float) ((Component) this).transform.localPosition.x + this.PositionTeamSelectionGridPanels(index));
    this.set_bGridOpen(index > 0);
    return this.get_bGridOpen();
  }

  public override void ShutDownGrid()
  {
    this.set_bGridOpen(false);
    for (int index = 0; index < this.SquadSelectionGridPanels.Length; ++index)
      this.SquadSelectionGridPanels[index].ShutDownSquadSelectionButton();
  }

  private void ResetSquadRosterPanels()
  {
    for (int Index = 0; Index < this.SquadSelectionGridPanels.Length; ++Index)
      this.SetPanelActive(Index, false);
  }

  private void SetPanelActive(int Index, bool Active)
  {
    if (Index >= this.SquadSelectionGridPanels.Length)
      return;
    ((Component) this.SquadSelectionGridPanels[Index]).gameObject.SetActive(Active);
  }

  private float PositionTeamSelectionGridPanels(int NumActivePanels)
  {
    float num = 0.0f;
    if (this.SquadSelectionGridPanels.Length > 0)
    {
      MeshFilter panelBackgroundMesh = this.SquadSelectionGridPanels[0].GetPanelBackgroundMesh();
      if (Object.op_Inequality((Object) panelBackgroundMesh, (Object) null))
      {
        Vector3 backgroundLocalScale = this.SquadSelectionGridPanels[0].GetPanelBackgroundLocalScale();
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
        int CurrPanelColumnIdx = 1;
        Vector3 nextPanelPosition;
        // ISSUE: explicit constructor call
        ((Vector3) ref nextPanelPosition).\u002Ector((float) PanelSize.x, 0.0f, 0.0f);
        for (int index = 0; index < NumActivePanels; ++index)
        {
          nextPanelPosition = this.GetNextPanelPosition(ref CurrPanelRowIdx, ref CurrPanelColumnIdx, nextPanelPosition, PanelSize, true);
          ((Component) this.SquadSelectionGridPanels[index]).transform.localPosition = nextPanelPosition;
          if (nextPanelPosition.x + PanelSize.x > (double) num)
            num = (float) (nextPanelPosition.x + PanelSize.x);
        }
      }
    }
    return num;
  }

  [CompilerGenerated]
  [SpecialName]
  public float get_MaximumXValue() => this.딟;
}
