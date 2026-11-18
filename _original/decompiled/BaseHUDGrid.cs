// Decompiled with JetBrains decompiler
// Type: BaseHUDGrid
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using UnityEngine;

public class BaseHUDGrid : MonoBehaviour
{
  public int NumGridColumns;
  public float GridColumnSpacer;
  public float GridRowSpacer;
  public bool GridGrowToLeft;

  public virtual void ShutDownGrid() => this.set_bGridOpen(false);

  protected Vector3 GetNextPanelPosition(
    ref int CurrPanelRowIdx,
    ref int CurrPanelColumnIdx,
    Vector3 CurrPanelPos,
    Vector3 PanelSize,
    bool IsInGame)
  {
    Vector3 vector3 = CurrPanelPos;
    if (CurrPanelColumnIdx >= this.NumGridColumns)
    {
      ++CurrPanelRowIdx;
      CurrPanelColumnIdx = !IsInGame ? 0 : 1;
      vector3.z = (__Null) -(PanelSize.z * (double) CurrPanelRowIdx + (double) this.GridRowSpacer * (double) CurrPanelRowIdx);
    }
    float num = (float) ((double) CurrPanelColumnIdx * PanelSize.x + (double) this.GridColumnSpacer * (double) CurrPanelColumnIdx);
    vector3.x = !this.GridGrowToLeft ? (__Null) (double) num : (__Null) -(double) num;
    ++CurrPanelColumnIdx;
    return vector3;
  }

  [CompilerGenerated]
  [SpecialName]
  public bool get_bGridOpen() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  protected void set_bGridOpen(bool value) => this.딟 = value;
}
