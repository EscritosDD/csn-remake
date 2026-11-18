// Decompiled with JetBrains decompiler
// Type: RageSplineOutlineAdapter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class RageSplineOutlineAdapter : ScriptableObject, 땺.딣
{
  public RageSpline RageSpline;

  [SpecialName]
  public float 땃() => Object.op_Implicit((Object) this.RageSpline) ? this.RageSpline.GetAntialiasingWidth() : 0.0f;

  [SpecialName]
  public void 땄([In] float obj0)
  {
    if (!Object.op_Implicit((Object) this.RageSpline))
      return;
    this.RageSpline.SetAntialiasingWidth(obj0);
  }

  [SpecialName]
  public Color 땄() => this.RageSpline.GetOutlineColor1();

  [SpecialName]
  public void 딟([In] Color obj0) => this.RageSpline.SetOutlineColor1(obj0);

  [SpecialName]
  public Color 딧() => this.RageSpline.GetOutlineColor2();

  [SpecialName]
  public void 땄([In] Color obj0) => this.RageSpline.SetOutlineColor2(obj0);

  [SpecialName]
  public 땺.땔.딸 딟() => RageSplineOutlineAdapter.딟(this.RageSpline.GetOutline());

  [SpecialName]
  public void 딟([In] 땺.땔.딸 obj0) => this.RageSpline.SetOutline(RageSplineOutlineAdapter.땄(obj0));

  [SpecialName]
  public 땺.땔.땘 딶() => RageSplineOutlineAdapter.딟(this.RageSpline.GetCorners());

  [SpecialName]
  public void 딟([In] 땺.땔.땘 obj0) => this.RageSpline.SetCorners(this.땄(obj0));

  public float 딟([In] int obj0) => this.RageSpline.GetOutlineWidth(obj0);

  [SpecialName]
  public float 딢() => this.RageSpline.GetOutlineWidth();

  [SpecialName]
  public void 딟([In] float obj0) => this.RageSpline.SetOutlineWidth(obj0);

  private static RageSpline.떂 땄([In] 땺.땔.딸 obj0)
  {
    switch (obj0)
    {
      case 땺.땔.딸.딟:
        return RageSpline.떂.딟;
      case 땺.땔.딸.땄:
        return RageSpline.떂.땄;
      case 땺.땔.딸.딧:
        return RageSpline.떂.딧;
      default:
        return RageSpline.떂.딟;
    }
  }

  private static 땺.땔.딸 딟([In] RageSpline.떂 obj0)
  {
    switch (obj0)
    {
      case RageSpline.떂.딟:
        return 땺.땔.딸.딟;
      case RageSpline.떂.땄:
        return 땺.땔.딸.땄;
      case RageSpline.떂.딧:
        return 땺.땔.딸.딧;
      default:
        return 땺.땔.딸.딟;
    }
  }

  private static 땺.땔.땘 딟([In] RageSpline.딦 obj0)
  {
    switch (obj0)
    {
      case RageSpline.딦.딟:
        return 땺.땔.땘.딟;
      case RageSpline.딦.땄:
        return 땺.땔.땘.땄;
      default:
        return 땺.땔.땘.딟;
    }
  }

  private RageSpline.딦 땄([In] 땺.땔.땘 obj0)
  {
    switch (obj0)
    {
      case 땺.땔.땘.딟:
        return RageSpline.딦.딟;
      case 땺.땔.땘.땄:
        return RageSpline.딦.땄;
      default:
        return RageSpline.딦.딟;
    }
  }
}
