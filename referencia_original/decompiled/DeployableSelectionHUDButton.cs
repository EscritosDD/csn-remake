// Decompiled with JetBrains decompiler
// Type: DeployableSelectionHUDButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using UnityEngine;

public class DeployableSelectionHUDButton : SquadRosterUnitPanel
{
  public GuiButton3D DeployableButton;
  public Material DeadBackgroundMaterial;
  private bool 딟;

  public bool SetDeployableButtonData(
    땓.땊 UnitData,
    int DeployableIdx,
    int ButtonIndex,
    Material ThumbIconMaterial,
    Material TeamBackgroundMaterial)
  {
    bool flag = false;
    int characterHealth = this.GetCharacterHealth(UnitData);
    this.set_bUnitAlive(characterHealth > 0);
    if (this.get_bUnitAlive())
    {
      flag = true;
      // ISSUE: reference to a compiler-generated method
      this.set_DeployableIndex(DeployableIdx);
      if (Object.op_Inequality((Object) this.UnitThumbBackground, (Object) null))
        this.UnitThumbBackground.renderer.sharedMaterial = TeamBackgroundMaterial;
      if (Object.op_Inequality((Object) this.UnitThumb, (Object) null))
        this.UnitThumb.renderer.sharedMaterial = ThumbIconMaterial;
      if (Object.op_Inequality((Object) this.UnitHealthText, (Object) null))
      {
        this.UnitHealthText.Text = characterHealth.ToString();
        this.UnitHealthText.UpdateMesh();
      }
      if (Object.op_Inequality((Object) this.UnitPointsText, (Object) null))
      {
        this.UnitPointsText.Text = this.GetCharacterActionPoints(UnitData).ToString();
        this.UnitPointsText.UpdateMesh();
      }
    }
    if (Object.op_Inequality((Object) this.DeployableButton, (Object) null))
    {
      this.DeployableButton.Disabled = !this.get_bUnitAlive();
      if (this.get_bUnitAlive() && !this.딟)
      {
        this.딟 = true;
        this.DeployableButton.set_CustomPressFunc("OnDeployableButtonPressed");
        this.DeployableButton.set_CustomPressValue((object) ButtonIndex);
      }
    }
    return flag;
  }

  public void ShutDownDeployableSelectionButton()
  {
    if (!Object.op_Inequality((Object) this.DeployableButton, (Object) null))
      return;
    this.DeployableButton.ResetButtonPulseToDefault();
  }

  [CompilerGenerated]
  [SpecialName]
  public int get_DeployableIndex() => this.딟;
}
