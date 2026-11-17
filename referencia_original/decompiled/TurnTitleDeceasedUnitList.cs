// Decompiled with JetBrains decompiler
// Type: TurnTitleDeceasedUnitList
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class TurnTitleDeceasedUnitList : MonoBehaviour
{
  public Shader DeadUnitIconShader;
  public TurnTitleDeceasedUnitPanel[] DeceasedUnitPanels;
  public int MaxNumPanels;

  public void SetDeceasedUnitList(
    딶.땯 TurnsStage,
    int ActiveTeam,
    Vector3 ScreenSize,
    bool InDeploymentState)
  {
    int Index = 0;
    this.ResetDeceasedUnitPanels();
    if (InDeploymentState)
      return;
    foreach (int index in 딶.딡.땴().땼().딧(ActiveTeam))
    {
      땓.떀 Character = 딶.딡.땴().땼().땻()[index] as 땓.떀;
      땓.땦 Controller = TurnsStage.딟(index);
      if (Character != null && Index < this.DeceasedUnitPanels.Length)
      {
        this.SetDeceasedUnitPanelsActive(Index, true);
        if (TurnsStage.땉() == 딶.딨.딢 || !this.DeceasedUnitPanels[Index].SetDeceasedUnitPanelData(Controller, Character, this.DeadUnitIconShader))
          this.SetDeceasedUnitPanelsActive(Index, false);
        else
          ++Index;
      }
    }
  }

  private void PositionDeceasedUnitListPanels(int NumActivePanels, Vector3 ScreenSize)
  {
    if (this.DeceasedUnitPanels.Length <= 0)
      return;
    MeshFilter component = this.DeceasedUnitPanels[0].UnitThumbBackground.GetComponent<MeshFilter>();
    if (!Object.op_Inequality((Object) component, (Object) null))
      return;
    Bounds bounds = component.sharedMesh.bounds;
    Vector3 size = ((Bounds) ref bounds).size;
    Vector3 localScale = ((Component) this.DeceasedUnitPanels[0]).transform.localScale;
    ref Vector3 local = ref size;
    local.x = local.x * localScale.x;
    float num1 = (float) (ScreenSize.x - size.x * (double) this.MaxNumPanels) / (float) (this.MaxNumPanels + 1);
    float num2 = (float) ((double) NumActivePanels * size.x + (double) (NumActivePanels + 1) * (double) num1);
    float num3 = (float) (size.x * 0.5 + (double) num1 - (double) num2 * 0.5);
    for (int index = 0; index < NumActivePanels; ++index)
    {
      ((Component) this.DeceasedUnitPanels[index]).transform.localPosition = new Vector3(num3, (float) ((Component) this.DeceasedUnitPanels[index]).transform.localPosition.y, (float) ((Component) this.DeceasedUnitPanels[index]).transform.localPosition.z);
      num3 += (float) size.x + num1;
    }
  }

  private void ResetDeceasedUnitPanels()
  {
    for (int Index = 0; Index < this.DeceasedUnitPanels.Length; ++Index)
      this.SetDeceasedUnitPanelsActive(Index, false);
  }

  private void SetDeceasedUnitPanelsActive(int Index, bool Active)
  {
    if (Index >= this.DeceasedUnitPanels.Length)
      return;
    ((Component) this.DeceasedUnitPanels[Index]).gameObject.SetActive(Active);
  }
}
