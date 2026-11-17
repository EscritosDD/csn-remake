// Decompiled with JetBrains decompiler
// Type: GuiCameraAdjust
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GuiCameraAdjust : MonoBehaviour
{
  public float BaseFov;
  private static List<GuiCameraAdjust> 딟 = new List<GuiCameraAdjust>();

  private void Start()
  {
    this.UpdateCameraSize();
    GuiCameraAdjust.딟.Add(this);
  }

  private void OnDestroy() => GuiCameraAdjust.딟.Remove(this);

  private void UpdateCameraSize()
  {
    float num1 = (float) Screen.width / (float) Screen.height;
    if (((Component) this).camera.isOrthoGraphic)
    {
      float num2 = (double) num1 <= 1.5 ? 0.75f / num1 : (float) (0.5 * (double) num1 / 1.5);
      if ((double) ((Component) this).camera.orthographicSize == (double) num2)
        return;
      ((Component) this).camera.orthographicSize = num2;
    }
    else
    {
      float num3 = (double) num1 <= 1.5 ? this.BaseFov * 1.5f / num1 : (float) ((double) this.BaseFov * (double) num1 / 1.5);
      if ((double) ((Component) this).camera.fieldOfView == (double) num3)
        return;
      ((Component) this).camera.fieldOfView = num3;
    }
  }

  public static void 딟()
  {
    foreach (GuiCameraAdjust guiCameraAdjust in GuiCameraAdjust.딟)
      guiCameraAdjust.UpdateCameraSize();
  }
}
