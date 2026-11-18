// Decompiled with JetBrains decompiler
// Type: GuiScreenARComponentEdgeAnchor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class GuiScreenARComponentEdgeAnchor : GuiScreenARComponentAdjustBase
{
  public bool AnchorTop;
  public bool AnchorBottom;
  public bool AnchorLeft;
  public bool AnchorRight;

  public override void UpdateComponent(float AR)
  {
    float num1 = (double) AR >= 1.0 ? 0.5f * AR : 0.5f / AR;
    float num2 = 1.5f / AR * num1;
    Vector3 vector3 = this.get_DefaultObjectPosition();
    if (this.AnchorTop)
    {
      float num3 = (float) (0.5 - vector3.z);
      vector3.z = (__Null) ((double) num1 - (double) num3);
    }
    else if (this.AnchorBottom)
    {
      float num4 = (float) (-0.5 - vector3.z);
      vector3.z = (__Null) (-(double) num1 - (double) num4);
    }
    if (this.AnchorRight)
    {
      float num5 = (float) (0.75 - vector3.x);
      vector3.x = (__Null) ((double) num2 - (double) num5);
    }
    else if (this.AnchorLeft)
    {
      float num6 = (float) (-0.75 - vector3.x);
      vector3.x = (__Null) (-(double) num2 - (double) num6);
    }
    ((Component) this).transform.localPosition = vector3;
  }
}
