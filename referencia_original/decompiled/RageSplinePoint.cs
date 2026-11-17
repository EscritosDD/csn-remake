// Decompiled with JetBrains decompiler
// Type: RageSplinePoint
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using UnityEngine;

[Serializable]
public class RageSplinePoint
{
  public Vector3 point;
  public Vector3 inCtrl;
  public Vector3 outCtrl;
  public float widthMultiplier = 1f;
  public bool natural;

  public RageSplinePoint([In] Vector3 obj0, [In] Vector3 obj1, [In] Vector3 obj2, [In] float obj3, [In] bool obj4)
  {
    this.point = obj0;
    this.inCtrl = obj1;
    this.outCtrl = obj2;
    this.widthMultiplier = obj3;
    this.natural = obj4;
  }

  public RageSplinePoint 딟() => new RageSplinePoint(this.point, this.inCtrl, this.outCtrl, this.widthMultiplier, this.natural);
}
