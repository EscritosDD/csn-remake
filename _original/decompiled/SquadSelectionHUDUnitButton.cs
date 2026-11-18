// Decompiled with JetBrains decompiler
// Type: SquadSelectionHUDUnitButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using UnityEngine;
using 땓;

public class SquadSelectionHUDUnitButton : SquadRosterUnitPanel
{
  public GuiButton3D SquadButton;
  public GameObject UnitDamageIcon;
  public Material DeadBackgroundMaterial;
  public Shader DeadUnitIconShader;
  private bool 딟;

  public bool SetSelectionButtonData(
    int CharIdx,
    int ButtonIndex,
    Material TeamBackgroundMaterial,
    떀 Character,
    땓.땊 UnitData)
  {
    this.set_CharacterIndex(CharIdx);
    bool flag = this.SetUnitData(UnitData, Character, TeamBackgroundMaterial, this.DeadBackgroundMaterial, this.DeadUnitIconShader, false, false);
    if (Object.op_Inequality((Object) this.SquadButton, (Object) null))
    {
      this.SquadButton.Disabled = !this.get_bUnitAlive();
      this.SquadButton.AnimateButton = this.get_bUnitAlive();
      if (this.get_bUnitAlive() && !this.딟)
      {
        this.딟 = true;
        this.SquadButton.set_CustomPressFunc("OnSelectUnitButtonPressed");
        this.SquadButton.set_CustomPressValue((object) ButtonIndex);
      }
    }
    return flag;
  }

  public void ShutDownSquadSelectionButton()
  {
    if (!Object.op_Inequality((Object) this.SquadButton, (Object) null))
      return;
    this.SquadButton.ResetButtonPulseToDefault();
  }

  [CompilerGenerated]
  [SpecialName]
  public bool get_bSelected() => this.땄;

  [CompilerGenerated]
  [SpecialName]
  public void set_bSelected(bool value) => this.땄 = value;
}
