// Decompiled with JetBrains decompiler
// Type: RageGroupPointCache
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using UnityEngine;

[Serializable]
public class RageGroupPointCache
{
  public Vector3 PointPos;
  public Vector3 InCtrlPos;
  public Vector3 OutCtrlPos;

  public RageGroupPointCache() => this.PointPos = this.InCtrlPos = this.OutCtrlPos = Vector3.zero;
}
