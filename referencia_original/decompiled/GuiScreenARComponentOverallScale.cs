// Decompiled with JetBrains decompiler
// Type: GuiScreenARComponentOverallScale
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class GuiScreenARComponentOverallScale : GuiScreenARComponentAdjustBase
{
  public override void UpdateComponent(float acpectRatioFactor)
  {
    Vector3 vector3 = this.get_DefaultObjectScale();
    if ((double) acpectRatioFactor < 1.0)
    {
      ref Vector3 local = ref vector3;
      local.z = (__Null) (local.z / (double) acpectRatioFactor);
    }
    else
    {
      ref Vector3 local = ref vector3;
      local.z = (__Null) (local.z * (double) acpectRatioFactor);
    }
    float num1 = (float) Screen.width / (float) Screen.height;
    float num2 = (float) (vector3.z * 0.5) * num1;
    ref Vector3 local1 = ref vector3;
    local1.x = (__Null) (local1.x * ((double) num2 / 0.75));
    ((Component) this).transform.localScale = vector3;
  }
}
