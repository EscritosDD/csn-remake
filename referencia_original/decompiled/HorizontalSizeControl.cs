// Decompiled with JetBrains decompiler
// Type: HorizontalSizeControl
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using UnityEngine;

public class HorizontalSizeControl : MonoBehaviour
{
  [SerializeField]
  private float StartPct;
  [SerializeField]
  private float EndPct = 1f;

  private void Start() => this.UpdateSize();

  private void UpdateSize()
  {
    Bounds bounds1 = ((Component) this).renderer.bounds;
    float x1 = (float) ((Bounds) ref bounds1).min.x;
    Bounds bounds2 = ((Component) this).renderer.bounds;
    float x2 = (float) ((Bounds) ref bounds2).max.x;
    float num = x2 - x1;
    Vector4 vector = ((Component) this).renderer.sharedMaterial.GetVector("_Bounds");
    Vector4 vector4;
    // ISSUE: explicit constructor call
    ((Vector4) ref vector4).\u002Ector(x1 + this.StartPct * num, (float) vector.y, x2 - (1f - this.EndPct) * num, (float) vector.w);
    ((Component) this).renderer.sharedMaterial.SetVector("_Bounds", vector4);
  }

  [SpecialName]
  public float get_StartPercent() => this.StartPct;

  [SpecialName]
  public void set_StartPercent(float value)
  {
    this.StartPct = value;
    this.UpdateSize();
  }

  [SpecialName]
  public float get_EndPercent() => this.EndPct;

  [SpecialName]
  public void set_EndPercent(float value)
  {
    this.EndPct = value;
    this.UpdateSize();
  }
}
