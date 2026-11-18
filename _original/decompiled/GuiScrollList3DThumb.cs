// Decompiled with JetBrains decompiler
// Type: GuiScrollList3DThumb
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using UnityEngine;

public class GuiScrollList3DThumb : GuiComponent3D
{
  private Vector3 딟;
  public Transform StartPos;
  public Transform EndPos;
  public GuiScrollList3D Parent;
  public GuiScroller3D ParentScroller;

  public override void OnDown(Vector3 Position)
  {
    this.딟 = Position;
    if (!Object.op_Inequality((Object) this.ParentScroller, (Object) null))
      return;
    this.ParentScroller.LockAutoScroll();
  }

  public override void OnUp(Vector3 Position)
  {
    if (!Object.op_Inequality((Object) this.ParentScroller, (Object) null))
      return;
    this.ParentScroller.UnlockAutoScroll();
  }

  public override void OnHeld(Vector3 Position)
  {
    Vector3 vector3_1 = Vector3.op_Subtraction(Camera.main.ScreenToWorldPoint(Position), Camera.main.ScreenToWorldPoint(this.딟));
    vector3_1.y = (__Null) 0.0;
    this.딟 = Position;
    Vector3 vector3_2 = Vector3.op_Subtraction(this.EndPos.position, this.StartPos.position);
    vector3_2.y = (__Null) 0.0;
    float magnitude = ((Vector3) ref vector3_2).magnitude;
    vector3_2 = ((Vector3) ref vector3_2).normalized;
    float num1 = Vector3.Dot(vector3_2, vector3_1) / magnitude;
    float num2 = this.get_MaxOffset();
    float num3 = this.get_MinOffset();
    float num4 = (num3 - num2) * num1 * this.get_OffsetScale();
    this.set_Offset(Mathf.Clamp(this.get_Offset() - num4, num3, num2));
  }

  private void Update()
  {
    float num = this.get_MaxOffset() - this.get_MinOffset();
    Vector3 vector3 = Vector3.Lerp(this.StartPos.position, this.EndPos.position, (double) num != 0.0 ? Mathf.Clamp01(this.get_Offset() * this.get_OffsetScale() / num) : 0.0f);
    vector3.y = ((Component) this).transform.position.y;
    ((Component) this).transform.position = vector3;
  }

  [SpecialName]
  private float get_MinOffset()
  {
    if (Object.op_Inequality((Object) this.Parent, (Object) null))
      return this.Parent.get_MinOffset();
    return Object.op_Inequality((Object) this.ParentScroller, (Object) null) ? this.ParentScroller.MinOffset : 0.0f;
  }

  [SpecialName]
  private float get_MaxOffset()
  {
    if (Object.op_Inequality((Object) this.Parent, (Object) null))
      return this.Parent.get_MaxOffset();
    return Object.op_Inequality((Object) this.ParentScroller, (Object) null) ? this.ParentScroller.MaxOffset : 0.0f;
  }

  [SpecialName]
  private float get_OffsetScale()
  {
    if (Object.op_Inequality((Object) this.Parent, (Object) null))
      return -1f;
    return Object.op_Inequality((Object) this.ParentScroller, (Object) null) ? 1f : 1f;
  }

  [SpecialName]
  private float get_Offset()
  {
    if (Object.op_Inequality((Object) this.Parent, (Object) null))
      return this.Parent.get_Offset();
    return Object.op_Inequality((Object) this.ParentScroller, (Object) null) ? this.ParentScroller.get_Offset() : 0.0f;
  }

  [SpecialName]
  private void set_Offset(float value)
  {
    if (Object.op_Inequality((Object) this.Parent, (Object) null))
      this.Parent.SetOffset(value);
    if (!Object.op_Inequality((Object) this.ParentScroller, (Object) null))
      return;
    this.ParentScroller.SetOffset(value);
  }
}
