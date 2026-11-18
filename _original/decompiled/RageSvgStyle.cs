// Decompiled with JetBrains decompiler
// Type: RageSvgStyle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

public class RageSvgStyle : ScriptableObject
{
  public 땺.땔.딸 OutlineType;
  public Color OutlineColor1;
  public Color OutlineColor2;
  public float OutlineAlpha;
  public float OutlineWidth;
  public 땺.땔.땘 CornersType;
  public 땺.땔.땷 FillType;
  public RageSvgGradient RageSvgGradient;
  public Color FillColor1;
  public Color FillColor2;
  public float FillColor1Alpha;
  public float FillColor2Alpha;
  public bool HasFill;
  public bool HasOutline;
  public bool HasGradient;

  public RageSvgStyle()
  {
    this.OutlineType = 땺.땔.딸.딟;
    this.OutlineColor1 = Color.black;
    this.OutlineColor2 = Color.black;
    this.OutlineAlpha = 1f;
    this.OutlineWidth = 1f;
    this.CornersType = 땺.땔.땘.땄;
    this.FillType = 땺.땔.땷.땄;
    this.RageSvgGradient = (RageSvgGradient) null;
    this.FillColor1 = Color.black;
    this.FillColor2 = Color.black;
    this.FillColor1Alpha = 1f;
    this.FillColor2Alpha = 1f;
    this.HasFill = true;
    this.HasOutline = false;
    this.HasGradient = false;
  }

  public static RageSvgStyle 딟() => ScriptableObject.CreateInstance(typeof (RageSvgStyle)) as RageSvgStyle;

  public void 딟([In] RageSvgStyle obj0)
  {
    this.OutlineType = obj0.OutlineType;
    this.OutlineColor1 = obj0.OutlineColor1;
    this.OutlineColor2 = obj0.OutlineColor2;
    this.OutlineAlpha = obj0.OutlineAlpha;
    this.OutlineWidth = obj0.OutlineWidth;
    this.CornersType = obj0.CornersType;
    this.FillType = obj0.FillType;
    this.RageSvgGradient = obj0.RageSvgGradient;
    this.FillColor1 = obj0.FillColor1;
    this.FillColor2 = obj0.FillColor2;
    this.FillColor1Alpha = obj0.FillColor1Alpha;
    this.FillColor2Alpha = obj0.FillColor2Alpha;
    this.HasFill = obj0.HasFill;
    this.HasOutline = obj0.HasOutline;
    this.HasGradient = obj0.HasGradient;
  }

  public string 땄() => "Style Fill: " + (object) this.FillType + " :: Outline: " + (object) this.OutlineType;
}
