// Decompiled with JetBrains decompiler
// Type: MoveCostBubble
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;
using 땓;

public class MoveCostBubble : BaseHUDBubble
{
  public GuiText3D MoveCostText;
  public GameObject BubbleIcon;

  public void ActivateMoveCostBubble(int MoveAPCost, Vector3 Position)
  {
    if (Object.op_Inequality((Object) this.MoveCostText, (Object) null))
    {
      this.MoveCostText.Text = MoveAPCost.ToString();
      this.MoveCostText.UpdateMesh();
    }
    this.ActivateHUDBubble(Position);
  }

  public override void UpdateBubble() => 땞.딟(this.BubbleIcon, this.MoveCostText, true, 0.0f);
}
