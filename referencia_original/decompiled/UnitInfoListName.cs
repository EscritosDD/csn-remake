// Decompiled with JetBrains decompiler
// Type: UnitInfoListName
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;
using 땓;

public class UnitInfoListName : MonoBehaviour
{
  public GuiText3D UnitName;
  public GuiButton3D BuyUnitButton;

  public void SetUnitName(떀 Character)
  {
    if (Character == null || !Object.op_Inequality((Object) this.UnitName, (Object) null))
      return;
    this.UnitName.Text = Character.땹();
    this.UnitName.UpdateMesh();
  }
}
