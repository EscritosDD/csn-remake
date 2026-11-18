// Decompiled with JetBrains decompiler
// Type: RageGroupGradientData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

public class RageGroupGradientData : ScriptableObject
{
  public Color StartColor = Color.black;
  public Color EndColor = Color.blue;
  public Vector2 Offset = Vector2.zero;
  public float Scale = 1f;
  public float Angle;
  public bool StyleLocalPositioning = true;

  public void 딟([In] 땺.떓 obj0)
  {
    obj0.땄(this.Angle);
    obj0.땄(this.EndColor);
    obj0.딟(this.Offset);
    obj0.딟(this.Scale);
    obj0.딟(this.StartColor);
    obj0.딟(this.StyleLocalPositioning);
  }
}
