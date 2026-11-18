// Decompiled with JetBrains decompiler
// Type: GuiScroller3D
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

[AddComponentMenu("Gui3D/Scroller")]
public class GuiScroller3D : GuiComponent3D
{
  private GuiScroller3D.딗 딟;
  private bool 딟;
  private Vector3 딟;
  private Vector3 땄;
  private bool 땄;
  private float 딟;
  private float 땄;
  private float 딧;
  private float 딢;
  public AnimationCurve SlideAnim;
  public float ScrollTime = 0.5f;
  private static List<GuiScroller3D> 딟 = new List<GuiScroller3D>();
  private static int 딟 = -1;
  private static GuiScroller3D 딟;
  private float 땃;
  private float 딶;
  public bool Vertical;
  public int NumElements;
  public float Speed;
  public float MinOffset;
  public float MaxOffset;
  public float SpringBounds;
  public float SpringSpeed;
  public float mouseWheelScrollSpeed = 0.025f;
  public float threshold = 0.005f;

  public void UpdateControl()
  {
    if (this.NumElements == 0)
      this.NumElements = 1;
    if (this.NumElements <= 1)
      return;
    this.딟 = (this.MaxOffset - this.MinOffset) / (float) (this.NumElements - 1);
  }

  private void Start() => this.UpdateControl();

  private void OnEnable()
  {
    GuiScroller3D.딟.Add(this);
    this.딟 = GuiScroller3D.딗.딟;
  }

  private void OnDisable() => GuiScroller3D.딟.Remove(this);

  public override void OnDown(Vector3 Position)
  {
    this.딟 = Position;
    this.땄 = Position;
    this.땄 = true;
    this.딟 = true;
    this.땃 = 0.0f;
  }

  public override void OnHeld(Vector3 Position)
  {
    Vector3 vector3 = Vector3.op_Subtraction(Position, this.땄);
    this.땄 = Position;
    float num1 = !this.Vertical ? (float) vector3.x / (float) Screen.width * this.Speed : (float) vector3.y / (float) Screen.height * this.Speed;
    float num2 = this.Vertical ? (float) (Position.y - this.딟.y) : (float) (Position.x - this.딟.x);
    if ((double) num2 * (double) num2 > 100.0)
      this.딟 = false;
    GuiScroller3D guiScroller3D = this;
    // ISSUE: reference to a compiler-generated method
    guiScroller3D.set_Offset(guiScroller3D.get_Offset() - num1);
    float num3 = num1 / Time.deltaTime;
    if ((double) Mathf.Abs(num3) < (double) Mathf.Abs(this.땃 / 2f))
      this.땃 /= 2f;
    else
      this.땃 = num3;
    // ISSUE: reference to a compiler-generated method
    this.set_Offset(Mathf.Clamp(this.get_Offset(), this.MinOffset - this.SpringBounds, this.MaxOffset + this.SpringBounds));
  }

  public override void OnUp(Vector3 Position)
  {
    this.땄 = false;
    if (this.딟)
      GuiComponent3D.딟(Position, ((Component) this).collider);
    this.UpdateActiveElement();
  }

  private void UpdateScrollWheel()
  {
    if (!this.Vertical)
      return;
    float num1 = GlobalAppData.떂();
    if ((double) Mathf.Abs(num1) == 0.0)
      return;
    if (GuiScroller3D.딟 != Time.frameCount)
    {
      float num2 = float.MinValue;
      GuiScroller3D.딟 = (GuiScroller3D) null;
      for (int index = 0; index < GuiScroller3D.딟.Count; ++index)
      {
        GuiScroller3D guiScroller3D = GuiScroller3D.딟[index];
        if (GuiScroller3D.딟(((Component) guiScroller3D).transform))
        {
          Collider collider = ((Component) guiScroller3D).collider;
          if (Object.op_Inequality((Object) collider, (Object) null))
          {
            Bounds bounds1 = collider.bounds;
            if (((Bounds) ref bounds1).center.y > (double) num2)
            {
              Bounds bounds2 = collider.bounds;
              num2 = (float) ((Bounds) ref bounds2).center.y;
              GuiScroller3D.딟 = guiScroller3D;
            }
          }
        }
      }
    }
    GuiScroller3D.딟 = Time.frameCount;
    RaycastHit raycastHit;
    if (!Object.op_Equality((Object) GuiScroller3D.딟, (Object) this) || !Physics.Raycast(Camera.main.ScreenPointToRay(Camera.main.WorldToScreenPoint(((Component) this).transform.position)), ref raycastHit) || !Object.op_Equality((Object) ((RaycastHit) ref raycastHit).collider, (Object) ((Component) this).collider))
      return;
    this.땃 = -(num1 * this.mouseWheelScrollSpeed) / Time.deltaTime;
  }

  private static bool 딟([In] Transform obj0)
  {
    Vector3 viewportPoint = Camera.main.WorldToViewportPoint(obj0.position);
    return viewportPoint.x >= 0.0 && viewportPoint.x <= 1.0 && viewportPoint.y >= 0.0 && viewportPoint.y <= 1.0;
  }

  private void UpdateActiveElement()
  {
    if (this.NumElements == 1 || (double) this.get_Offset() <= (double) this.MinOffset)
      this.set_ActiveElement(0);
    else if ((double) this.get_Offset() > (double) this.MaxOffset)
      this.set_ActiveElement(this.NumElements - 1);
    else
      this.set_ActiveElement(Mathf.RoundToInt((this.get_Offset() - this.MinOffset) / this.딟));
  }

  private void Update()
  {
    this.UpdateScrollWheel();
    if (this.딟 == GuiScroller3D.딗.딟)
    {
      if (this.땄)
        return;
      float num1 = this.MinOffset - this.SpringBounds;
      float num2 = this.MaxOffset + this.SpringBounds;
      if ((double) this.get_Offset() >= (double) num2 || (double) this.get_Offset() <= (double) num1)
        this.땃 = 0.0f;
      GuiScroller3D guiScroller3D1 = this;
      // ISSUE: reference to a compiler-generated method
      guiScroller3D1.set_Offset(guiScroller3D1.get_Offset() - this.땃 * Time.deltaTime);
      // ISSUE: reference to a compiler-generated method
      this.set_Offset(Mathf.Clamp(this.get_Offset(), num1, num2));
      this.땃 = Mathf.SmoothDamp(this.땃, 0.0f, ref this.딶, 0.25f);
      this.UpdateActiveElement();
      if ((double) Mathf.Abs(this.땃) >= 1.5)
        return;
      float num3 = this.MinOffset + (float) this.get_ActiveElement() * this.딟;
      if ((double) this.get_Offset() < (double) num3)
      {
        GuiScroller3D guiScroller3D2 = this;
        // ISSUE: reference to a compiler-generated method
        guiScroller3D2.set_Offset(guiScroller3D2.get_Offset() + (num3 - this.get_Offset()) * Mathf.Min(1f, this.SpringSpeed * Time.deltaTime));
      }
      else
      {
        if ((double) this.get_Offset() <= (double) num3)
          return;
        GuiScroller3D guiScroller3D3 = this;
        // ISSUE: reference to a compiler-generated method
        guiScroller3D3.set_Offset(guiScroller3D3.get_Offset() - (this.get_Offset() - num3) * Mathf.Min(1f, this.SpringSpeed * Time.deltaTime));
      }
    }
    else
    {
      if (this.딟 != GuiScroller3D.딗.땄)
        return;
      this.딢 += Time.deltaTime / this.ScrollTime;
      this.딢 = Mathf.Clamp(this.딢, 0.0f, 1f);
      // ISSUE: reference to a compiler-generated method
      this.set_Offset(Mathf.Lerp(this.딧, this.땄, this.SlideAnim.Evaluate(this.딢)));
      if ((double) Mathf.Abs(this.get_Offset() - this.땄) >= (double) this.threshold)
        return;
      this.UpdateActiveElement();
      // ISSUE: reference to a compiler-generated method
      this.set_IsAutoScrolling(false);
      if (this.get_ScrollEndCallback() != null)
        this.get_ScrollEndCallback()();
      this.딢 = 0.0f;
      this.땄 = -100f;
      this.딟 = GuiScroller3D.딗.딟;
    }
  }

  [SpecialName]
  public bool get_IsHeld() => this.땄;

  public void IncrementScroller()
  {
    if (this.get_ActiveElement() == this.NumElements || this.get_IsAutoScrolling())
      return;
    // ISSUE: reference to a compiler-generated method
    this.set_IsAutoScrolling(true);
    if (this.get_ScrollStartCallback() != null)
      this.get_ScrollStartCallback()();
    this.딟 = GuiScroller3D.딗.땄;
    this.땄 = this.MinOffset + (float) (this.get_ActiveElement() + 1) * this.딟;
    this.딧 = this.get_Offset();
  }

  public void DecrementScroller()
  {
    if (this.get_ActiveElement() == 0 || this.get_IsAutoScrolling())
      return;
    // ISSUE: reference to a compiler-generated method
    this.set_IsAutoScrolling(true);
    if (this.get_ScrollStartCallback() != null)
      this.get_ScrollStartCallback()();
    this.딟 = GuiScroller3D.딗.땄;
    this.땄 = this.MinOffset + (float) (this.get_ActiveElement() - 1) * this.딟;
    this.딧 = this.get_Offset();
  }

  public void Reset()
  {
    this.set_ActiveElement(0);
    // ISSUE: reference to a compiler-generated method
    this.set_Offset(0.0f);
    this.딶 = 0.0f;
    this.땃 = 0.0f;
    this.땄 = false;
  }

  public void ResetToActive()
  {
    // ISSUE: reference to a compiler-generated method
    this.set_Offset(this.MinOffset + (float) this.get_ActiveElement() * this.딟);
    this.딶 = 0.0f;
    this.땃 = 0.0f;
    this.땄 = false;
  }

  public void SetOffset(float Value)
  {
    // ISSUE: reference to a compiler-generated method
    this.set_Offset(Value);
    this.딶 = 0.0f;
    this.땃 = 0.0f;
  }

  public void LockAutoScroll() => this.땄 = true;

  public void UnlockAutoScroll() => this.땄 = false;

  [CompilerGenerated]
  [SpecialName]
  public float get_Offset() => this.땓;

  [CompilerGenerated]
  [SpecialName]
  public int get_ActiveElement() => this.땄;

  [CompilerGenerated]
  [SpecialName]
  public void set_ActiveElement(int value) => this.땄 = value;

  [CompilerGenerated]
  [SpecialName]
  public Action get_ScrollStartCallback() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public void set_ScrollStartCallback(Action value) => this.딟 = value;

  [CompilerGenerated]
  [SpecialName]
  public Action get_ScrollEndCallback() => this.땄;

  [CompilerGenerated]
  [SpecialName]
  public void set_ScrollEndCallback(Action value) => this.땄 = value;

  [CompilerGenerated]
  [SpecialName]
  public bool get_IsAutoScrolling() => this.딧;

  private enum 딗
  {
    딟,
    땄,
  }
}
