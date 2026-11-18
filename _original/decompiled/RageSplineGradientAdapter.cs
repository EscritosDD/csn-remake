// Decompiled with JetBrains decompiler
// Type: RageSplineGradientAdapter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class RageSplineGradientAdapter : ScriptableObject, 땺.떓
{
  public RageSpline RageSpline;

  [SpecialName]
  public Vector2 딟() => this.RageSpline.GetGradientOffset();

  [SpecialName]
  public void 딟([In] Vector2 obj0) => this.RageSpline.SetGradientOffset(obj0);

  [SpecialName]
  public float 땄() => this.RageSpline.gradientScale;

  [SpecialName]
  public void 딟([In] float obj0) => this.RageSpline.gradientScale = obj0;

  [SpecialName]
  public float 딧() => this.RageSpline.GetGradientAngleDeg();

  [SpecialName]
  public void 땄([In] float obj0) => this.RageSpline.SetGradientAngleDeg(obj0);

  [SpecialName]
  public bool 딶() => this.RageSpline.styleLocalTexturePositioning;

  [SpecialName]
  public void 딟([In] bool obj0) => this.RageSpline.styleLocalTexturePositioning = obj0;

  [SpecialName]
  public Color 딢() => this.RageSpline.GetFillColor1();

  [SpecialName]
  public void 딟([In] Color obj0) => this.RageSpline.SetFillColor1(obj0);

  [SpecialName]
  public Color 땃() => this.RageSpline.GetFillColor2();

  [SpecialName]
  public void 땄([In] Color obj0) => this.RageSpline.SetFillColor2(obj0);
}
