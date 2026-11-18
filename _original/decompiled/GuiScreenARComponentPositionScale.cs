// Decompiled with JetBrains decompiler
// Type: GuiScreenARComponentPositionScale
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class GuiScreenARComponentPositionScale : GuiScreenARComponentAdjustBase
{
  public override void UpdateComponent(float AR)
  {
    Vector3 vector3 = this.get_DefaultObjectPosition();
    ref Vector3 local = ref vector3;
    local.z = (__Null) (local.z * (double) AR);
    ((Component) this).transform.localPosition = vector3;
  }
}
