// Decompiled with JetBrains decompiler
// Type: GuiButton2State3D
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("Gui3D/Button (2 State)")]
public class GuiButton2State3D : GuiButton3D
{
  public GameObject ButtonActiveBackground;
  public GameObject ButtonDisabledBackground;

  public virtual void SetButtonDisabled(bool ShouldDisable)
  {
    this.Disabled = ShouldDisable;
    this.AnimateButton = !ShouldDisable;
    if (Object.op_Inequality((Object) this.ButtonActiveBackground, (Object) null))
      this.ButtonActiveBackground.SetActive(!this.Disabled);
    if (!Object.op_Inequality((Object) this.ButtonDisabledBackground, (Object) null))
      return;
    this.ButtonDisabledBackground.SetActive(this.Disabled);
  }

  private void OnEnable() => this.SetButtonDisabled(this.Disabled);
}
