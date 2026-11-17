// Decompiled with JetBrains decompiler
// Type: RageGroupElement
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

[Serializable]
public class RageGroupElement : ScriptableObject
{
  public RageSplineAdapter Spline;
  public float DefaultAa;
  public int DefaultDensity;
  public Color DefaultFillColor1;
  public Color DefaultFillColor2;
  public Color DefaultOutlineColor;
  public Vector3 PositionCache;
  public RageGroupPointCache[] GroupPointCache;
  public Vector3 GradientOffsetCache;
  public Quaternion RotationCache;
  public Vector3 ScaleCache;
  public Vector2 TextureOffsetCache;
  public float TextureAngleCache;
  public float TextureScaleCache;
  public Vector2 TextureOffsetCache2;
  public float TextureAngleCache2;
  public float TextureScaleCache2;
  public MeshRenderer MeshRenderer;
  [SerializeField]
  private bool _visible;

  public RageGroupElement()
  {
    this.Spline = (RageSplineAdapter) null;
    this.DefaultAa = 0.0f;
    this.DefaultDensity = 0;
    this.DefaultFillColor1 = Color.black;
    this.DefaultFillColor2 = Color.black;
    this.DefaultOutlineColor = Color.black;
    this.PositionCache = Vector3.zero;
    this.GroupPointCache = (RageGroupPointCache[]) null;
    this.GradientOffsetCache = Vector3.zero;
    this.RotationCache = Quaternion.identity;
    this.ScaleCache = Vector3.zero;
    this.TextureOffsetCache = Vector2.zero;
    this.TextureAngleCache = 0.0f;
    this.TextureScaleCache = 0.1f;
    this.TextureOffsetCache2 = Vector2.zero;
    this.TextureAngleCache2 = 0.0f;
    this.TextureScaleCache2 = 0.1f;
    this.MeshRenderer = (MeshRenderer) null;
  }

  [SpecialName]
  public bool 딟() => this._visible;

  [SpecialName]
  public void 딟([In] bool obj0)
  {
    ((Renderer) this.MeshRenderer).enabled = obj0;
    this._visible = obj0;
  }
}
