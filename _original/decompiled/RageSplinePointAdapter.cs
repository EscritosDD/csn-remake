// Decompiled with JetBrains decompiler
// Type: RageSplinePointAdapter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class RageSplinePointAdapter : ScriptableObject, 땺.딛
{
  public RageSpline RageSpline;

  [CompilerGenerated]
  [SpecialName]
  public int 딟() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public void 딟([In] int obj0) => this.딟 = obj0;

  [SpecialName]
  public Vector3 땄() => this.RageSpline.GetPositionWorldSpace(this.딟());

  [SpecialName]
  public void 딟([In] Vector3 obj0) => this.RageSpline.SetPointWorldSpace(this.딟(), obj0);

  [SpecialName]
  public Vector3 딧() => this.RageSpline.GetInControlPositionWorldSpace(this.딟());

  [SpecialName]
  public void 땄([In] Vector3 obj0) => this.RageSpline.SetInControlPositionWorldSpace(this.딟(), obj0);

  [SpecialName]
  public Vector3 땃() => this.RageSpline.GetPosition(this.딟());

  [SpecialName]
  public void 딢([In] Vector3 obj0) => this.RageSpline.SetPoint(this.딟(), obj0);

  [SpecialName]
  public Vector3 딶() => this.RageSpline.GetInControlPositionPointSpace(this.딟());

  [SpecialName]
  public void 땃([In] Vector3 obj0) => this.RageSpline.SetInControlPositionPointSpace(this.딟(), obj0);

  [SpecialName]
  public Vector3 딢() => this.RageSpline.GetOutControlPositionWorldSpace(this.딟());

  [SpecialName]
  public void 딧([In] Vector3 obj0) => this.RageSpline.SetOutControlPositionWorldSpace(this.딟(), obj0);

  [SpecialName]
  public Vector3 땓() => this.RageSpline.GetOutControlPositionPointSpace(this.딟());

  [SpecialName]
  public void 딶([In] Vector3 obj0) => this.RageSpline.SetOutControlPositionPointSpace(this.딟(), obj0);

  [SpecialName]
  public bool 땺() => this.RageSpline.GetNatural(this.딟());

  [SpecialName]
  public void 딟([In] bool obj0) => this.RageSpline.SetNatural(this.딟(), obj0);
}
