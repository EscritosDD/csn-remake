// Decompiled with JetBrains decompiler
// Type: RageGroupStyleData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using 땺;

[Serializable]
public class RageGroupStyleData : ScriptableObject
{
  public 땺.땔.땷 FillType = 땺.땔.땷.땄;
  public Color FillColor = Color.gray;
  [SerializeField]
  private RageGroupGradientData _fillGradient;
  public Color OutlineColor = Color.black;
  public 땺.땔.딸 OutlineType;
  public float OutlineWidth = 1f;
  [SerializeField]
  private RageGroupGradientData _outlineGradient;
  public float OutlineNormalOffset = 1f;
  public bool OutlineBehindFill;
  public bool Optimize;
  public float OptimizeAngle = 5f;
  public float OutlineTexturingScale = 0.1f;
  public RageSpline.땽 UvMapping1 = RageSpline.땽.땄;
  public RageSpline.땽 UvMapping2;
  public float LandscapeBottomDepth;
  public float LandscapeOutlineAlign;

  [SpecialName]
  public RageGroupGradientData 딟()
  {
    if (Object.op_Inequality((Object) this._fillGradient, (Object) null))
      return this._fillGradient;
    this._fillGradient = ScriptableObject.CreateInstance<RageGroupGradientData>();
    return this._fillGradient;
  }

  [SpecialName]
  public void 딟([In] RageGroupGradientData obj0)
  {
    if (Object.op_Equality((Object) obj0, (Object) this._fillGradient))
      return;
    this._fillGradient = obj0;
  }

  [SpecialName]
  public RageGroupGradientData 땄()
  {
    if (Object.op_Inequality((Object) this._outlineGradient, (Object) null))
      return this._outlineGradient;
    this._outlineGradient = ScriptableObject.CreateInstance<RageGroupGradientData>();
    return this._outlineGradient;
  }

  [SpecialName]
  public void 땄([In] RageGroupGradientData obj0)
  {
    if (Object.op_Equality((Object) obj0, (Object) this._outlineGradient))
      return;
    this._outlineGradient = obj0;
  }

  public void 딟([In] 딥 obj0)
  {
    obj0.딟(this.FillColor);
    obj0.땄(this.OutlineColor);
    obj0.딟(this.FillType);
    this.딟().딟(obj0.땥());
    this.땄().딟(obj0.떎());
    obj0.딟(this.OutlineType);
    obj0.땄(this.OutlineWidth);
    obj0.딟(this.OutlineBehindFill);
    obj0.땓(this.Optimize);
    obj0.딧(this.OptimizeAngle);
  }
}
