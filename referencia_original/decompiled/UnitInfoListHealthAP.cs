// Decompiled with JetBrains decompiler
// Type: UnitInfoListHealthAP
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;
using 땓;

public class UnitInfoListHealthAP : MonoBehaviour
{
  public GuiText3D UnitHealthText;
  public GuiText3D UnitActionPointsText;

  public void SetUnitHealthActionPoints(떀 Character, 땓.땦 Controller)
  {
    if (Character == null || Controller == null)
      return;
    if (Object.op_Inequality((Object) this.UnitHealthText, (Object) null))
    {
      this.UnitHealthText.Text = Controller.땴().딧.ToString() + " / " + (object) Character.딱();
      this.UnitHealthText.UpdateMesh();
    }
    if (!Object.op_Inequality((Object) this.UnitActionPointsText, (Object) null))
      return;
    this.UnitActionPointsText.Text = Controller.땴().딢.ToString() + " / " + (object) Character.땷().BasicActionPoints;
    this.UnitActionPointsText.UpdateMesh();
  }
}
