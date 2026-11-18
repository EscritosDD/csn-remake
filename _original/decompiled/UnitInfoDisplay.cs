// Decompiled with JetBrains decompiler
// Type: UnitInfoDisplay
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;
using 땓;

public class UnitInfoDisplay : MonoBehaviour
{
  public GuiText3D SquadPointsText;
  public GuiText3D HealthPointsText;
  public GuiText3D ActionPointsText;

  public void Init(떀 Char)
  {
    this.SquadPointsText.Text = Char.딟(GlobalAppData.딢()).ToString();
    this.SquadPointsText.UpdateMesh();
    this.HealthPointsText.Text = Char.땷().MaxHealth.ToString();
    this.HealthPointsText.UpdateMesh();
    this.ActionPointsText.Text = Char.딟((땓.땊) null).ToString();
    this.ActionPointsText.UpdateMesh();
  }
}
