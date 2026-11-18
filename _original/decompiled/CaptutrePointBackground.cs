// Decompiled with JetBrains decompiler
// Type: CaptutrePointBackground
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using UnityEngine;

[Serializable]
public class CaptutrePointBackground
{
  public GameObject CapturePointFill;

  public void 딟([In] bool obj0)
  {
    if (!Object.op_Inequality((Object) this.CapturePointFill, (Object) null))
      return;
    this.CapturePointFill.SetActive(obj0);
  }

  public void 딟([In] Color obj0)
  {
    if (!Object.op_Inequality((Object) this.CapturePointFill, (Object) null))
      return;
    this.CapturePointFill.renderer.material.color = obj0;
  }
}
