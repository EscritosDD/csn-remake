// Decompiled with JetBrains decompiler
// Type: WinnerBoxData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using UnityEngine;

[Serializable]
public class WinnerBoxData
{
  public GuiText3D WinnerText;
  public GameObject WinnerBoxParent;
  public GameObject WinnerBackground;
  public GameObject WinnerGlow;

  public void 딟([In] bool obj0) => this.WinnerBoxParent.SetActive(obj0);

  public void 딟([In] float obj0)
  {
    this.WinnerText.TextColor = new Color((float) this.WinnerText.TextColor.r, (float) this.WinnerText.TextColor.g, (float) this.WinnerText.TextColor.b, obj0);
    this.WinnerText.UpdateMesh();
    this.WinnerBackground.renderer.material.color = new Color((float) this.WinnerBackground.renderer.material.color.r, (float) this.WinnerBackground.renderer.material.color.g, (float) this.WinnerBackground.renderer.material.color.b, obj0);
    this.WinnerGlow.renderer.material.color = new Color((float) this.WinnerGlow.renderer.material.color.r, (float) this.WinnerGlow.renderer.material.color.g, (float) this.WinnerGlow.renderer.material.color.b, obj0);
  }
}
