// Decompiled with JetBrains decompiler
// Type: UnitEmoteBubble
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;
using 딶;

public class UnitEmoteBubble : BaseHUDBubble
{
  public GameObject EmoteIcon;
  public Material WallCoverMaterial;
  public Material HighCoverMaterial;
  public Material LedgeCoverMaterial;
  public GameObject UnitAPCostIcon;
  public GameObject UnitDamageIcon;
  public GuiText3D UnitAPCostText;
  public GuiText3D UnitDamageText;

  public void ActivateUnitEmoteBubble(
    딥 Cover,
    Vector3 Position,
    int APCostToFire,
    int DamageScale)
  {
    this.ActivateHUDBubble(Position);
    switch (Cover)
    {
      case 딥.딟:
        this.EmoteIcon.SetActive(false);
        break;
      case 딥.땄:
        this.EmoteIcon.renderer.material = this.HighCoverMaterial;
        break;
      case 딥.딧:
        this.EmoteIcon.renderer.material = this.LedgeCoverMaterial;
        break;
      case 딥.딢:
        this.EmoteIcon.renderer.material = this.WallCoverMaterial;
        break;
    }
    this.UnitAPCostText.Text = APCostToFire.ToString();
    this.UnitAPCostText.UpdateMesh();
    this.UnitDamageText.Text = DamageScale.ToString();
    this.UnitDamageText.UpdateMesh();
  }

  private void LateUpdate() => this.PoisitionBubble();
}
