// Decompiled with JetBrains decompiler
// Type: GuiScrollList3D
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using 땓;

[AddComponentMenu("Gui3D/Scrolling List")]
public class GuiScrollList3D : GuiComponent3D
{
  private float 딟;
  private float 땄;
  private float 딧;
  private Vector3 딟;
  private 땠 딟;
  private static List<GuiScrollList3D> 딟 = new List<GuiScrollList3D>();
  private static int 딟 = -1;
  private static GuiScrollList3D 딟;
  private List<GuiScrollList3D.땴> 딟 = new List<GuiScrollList3D.땴>();
  private float 딢;
  private bool 딟;
  public bool CodeControlled;
  public float SpringBounds = 0.1f;
  public float SpringSpeed = 3f;
  public bool Horizontal;
  public bool Invert;
  public bool NoRoundToPixel;
  public bool AllowLocalObjectOffset;
  public float mouseWheelScrollSpeed = 0.025f;

  public override void OnDown(Vector3 Position)
  {
    if (this.CodeControlled)
      return;
    this.딟 = true;
    this.딟 = Position;
    this.땄 = 0.0f;
    this.딟.딟(Position);
  }

  public override void OnUp(Vector3 Position)
  {
    if (this.CodeControlled)
    {
      GuiComponent3D.딟(Position, ((Component) this).collider);
    }
    else
    {
      this.딟 = false;
      this.딟.딟(Position, ((Component) this).collider);
    }
  }

  public override void OnHeld(Vector3 Position)
  {
    if (this.CodeControlled)
      return;
    this.딟.딟(Position, this.Horizontal);
    if (!this.딟.딟())
    {
      float num = !this.Horizontal ? (float) (Position.y - this.딟.y) / (float) Screen.height : (float) (Position.x - this.딟.x) / (float) Screen.width;
      if (this.Invert)
        num = -num;
      this.땄 = num / Time.deltaTime;
      this.딢 -= num;
      this.딢 = Mathf.Clamp(this.딢, this.get_MinOffset() - this.SpringBounds, this.get_MaxOffset() + this.SpringBounds);
    }
    // ISSUE: reference to a compiler-generated method
    this.set_Offset(Mathf.SmoothDamp(this.get_Offset(), this.딢, ref this.딟, 0.07f));
    this.UpdateItemPositions();
    this.딟 = Position;
  }

  private void OnEnable() => GuiScrollList3D.딟.Add(this);

  private void OnDisable() => GuiScrollList3D.딟.Remove(this);

  private void Update()
  {
    if (this.CodeControlled)
      return;
    float num1 = this.get_Offset();
    this.UpdateScrollWheel();
    if (!this.딟)
    {
      float num2 = this.get_MinOffset() - this.SpringBounds;
      float num3 = this.get_MaxOffset() + this.SpringBounds;
      if ((double) this.딢 >= (double) num3 || (double) this.딢 <= (double) num2)
        this.땄 = 0.0f;
      this.딢 -= this.땄 * Time.deltaTime;
      this.딢 = Mathf.Clamp(this.딢, num2, num3);
      this.땄 = Mathf.SmoothDamp(this.땄, 0.0f, ref this.딧, 0.25f);
      float num4 = this.딢;
      if ((double) this.딢 < (double) this.get_MinOffset())
        num4 = this.get_MinOffset();
      else if ((double) this.딢 > (double) this.get_MaxOffset())
        num4 = this.get_MaxOffset();
      if ((double) this.딢 < (double) num4)
        this.딢 += (num4 - this.딢) * Mathf.Min(1f, this.SpringSpeed * Time.deltaTime);
      else if ((double) this.get_Offset() > (double) num4)
        this.딢 -= (this.딢 - num4) * Mathf.Min(1f, this.SpringSpeed * Time.deltaTime);
      // ISSUE: reference to a compiler-generated method
      this.set_Offset(Mathf.SmoothDamp(this.get_Offset(), this.딢, ref this.딟, 0.07f));
    }
    if ((double) num1 == (double) this.get_Offset())
      return;
    this.UpdateItemPositions();
  }

  private static bool 딟([In] Transform obj0)
  {
    Vector3 viewportPoint = Camera.main.WorldToViewportPoint(obj0.position);
    return viewportPoint.x >= 0.0 && viewportPoint.x <= 1.0 && viewportPoint.y >= 0.0 && viewportPoint.y <= 1.0;
  }

  private void UpdateScrollWheel()
  {
    if (this.Horizontal)
      return;
    float num1 = GlobalAppData.떂();
    if ((double) Mathf.Abs(num1) == 0.0)
      return;
    if (GuiScrollList3D.딟 != Time.frameCount)
    {
      float num2 = float.MinValue;
      GuiScrollList3D.딟 = (GuiScrollList3D) null;
      for (int index = 0; index < GuiScrollList3D.딟.Count; ++index)
      {
        GuiScrollList3D guiScrollList3D = GuiScrollList3D.딟[index];
        if (GuiScrollList3D.딟(((Component) guiScrollList3D).transform))
        {
          Collider collider = ((Component) guiScrollList3D).collider;
          if (Object.op_Inequality((Object) collider, (Object) null))
          {
            Bounds bounds1 = collider.bounds;
            if (((Bounds) ref bounds1).center.y > (double) num2)
            {
              Bounds bounds2 = collider.bounds;
              num2 = (float) ((Bounds) ref bounds2).center.y;
              GuiScrollList3D.딟 = guiScrollList3D;
            }
          }
        }
      }
    }
    GuiScrollList3D.딟 = Time.frameCount;
    RaycastHit raycastHit;
    if (!Object.op_Equality((Object) GuiScrollList3D.딟, (Object) this) || !Physics.Raycast(Camera.main.ScreenPointToRay(Camera.main.WorldToScreenPoint(((Component) this).transform.position)), ref raycastHit) || !Object.op_Equality((Object) ((RaycastHit) ref raycastHit).collider, (Object) ((Component) this).collider))
      return;
    this.땄 = -(num1 * this.mouseWheelScrollSpeed) / Time.deltaTime;
  }

  public void UpdateItemClipping()
  {
    Vector4 vector4;
    ref Vector4 local1 = ref vector4;
    Bounds bounds1 = ((Component) this).collider.bounds;
    // ISSUE: variable of the null type
    __Null x1 = ((Bounds) ref bounds1).min.x;
    local1.x = x1;
    ref Vector4 local2 = ref vector4;
    Bounds bounds2 = ((Component) this).collider.bounds;
    // ISSUE: variable of the null type
    __Null z1 = ((Bounds) ref bounds2).min.z;
    local2.y = z1;
    ref Vector4 local3 = ref vector4;
    Bounds bounds3 = ((Component) this).collider.bounds;
    // ISSUE: variable of the null type
    __Null x2 = ((Bounds) ref bounds3).max.x;
    local3.z = x2;
    ref Vector4 local4 = ref vector4;
    Bounds bounds4 = ((Component) this).collider.bounds;
    // ISSUE: variable of the null type
    __Null z2 = ((Bounds) ref bounds4).max.z;
    local4.w = z2;
    foreach (GuiScrollList3D.땴 땴 in this.딟)
    {
      foreach (Renderer componentsInChild in ((Component) 땴.딟).GetComponentsInChildren<Renderer>())
      {
        Material[] materialArray = !Object.op_Inequality((Object) ((Component) componentsInChild).GetComponent<GuiScrollListUseSharedMaterial>(), (Object) null) ? componentsInChild.materials : componentsInChild.sharedMaterials;
        for (int index = 0; index < materialArray.Length; ++index)
        {
          Material material = materialArray[index];
          if (material.HasProperty("_Bounds"))
            material.SetVector("_Bounds", vector4);
          materialArray[index] = material;
        }
      }
    }
  }

  private float RoundToPixel(float Value) => Mathf.Floor(Value * (float) Screen.height) / (float) Screen.height;

  public void UpdateItemPositions()
  {
    Transform transform1 = ((Component) this).transform;
    // ISSUE: reference to a compiler-generated method
    this.set_TotalOffset(0.0f);
    foreach (GuiScrollList3D.땴 땴 in this.딟)
    {
      GuiScrollList3D guiScrollList3D1 = this;
      // ISSUE: reference to a compiler-generated method
      guiScrollList3D1.set_TotalOffset(guiScrollList3D1.get_TotalOffset() + 땴.딟);
      Transform transform2 = ((Component) 땴.딟).transform;
      if (Object.op_Inequality((Object) transform2.parent, (Object) transform1))
        transform2.parent = transform1;
      float num1 = this.get_TotalOffset() + this.get_Offset();
      if (this.Horizontal)
      {
        Bounds bounds = ((Component) this).collider.bounds;
        float num2 = (float) ((Bounds) ref bounds).extents.x - num1;
        if (this.Invert)
          num2 = -num2;
        ((Component) 땴.딟).transform.localPosition = new Vector3(!this.NoRoundToPixel ? this.RoundToPixel(num2) : num2, -0.1f, (float) 땴.딟.z);
      }
      else
      {
        Bounds bounds = ((Component) this).collider.bounds;
        float num3 = (float) ((Bounds) ref bounds).extents.z - num1;
        if (this.Invert)
          num3 = -num3;
        ((Component) 땴.딟).transform.localPosition = new Vector3((float) 땴.딟.x, -0.1f, !this.NoRoundToPixel ? this.RoundToPixel(num3) : num3);
      }
      GuiScrollList3D guiScrollList3D2 = this;
      // ISSUE: reference to a compiler-generated method
      guiScrollList3D2.set_TotalOffset(guiScrollList3D2.get_TotalOffset() + 땴.딟);
    }
  }

  public int GetCurrentIndex() => this.딟.Count;

  public void AddItem(Transform Item, float Spacing)
  {
    this.AddItemNoUpdate(Item, Spacing);
    this.UpdateItemPositions();
    this.UpdateItemClipping();
  }

  public void AddItemNoUpdate(Transform Item, float Spacing)
  {
    GuiScrollList3D.땴 땴 = new GuiScrollList3D.땴();
    땴.딟 = Item;
    땴.딟 = Spacing;
    if (this.AllowLocalObjectOffset)
      땴.딟 = ((Component) Item).transform.localPosition;
    this.딟.Add(땴);
  }

  public void ForceItemsUpdate()
  {
    this.UpdateItemPositions();
    this.UpdateItemClipping();
  }

  public void RemoveItem(Transform Item)
  {
    foreach (GuiScrollList3D.땴 땴 in this.딟)
    {
      if (Object.op_Equality((Object) 땴.딟, (Object) Item))
      {
        this.딟.Remove(땴);
        GlobalAppData.땄(((Component) 땴.딟).gameObject);
        break;
      }
    }
    this.UpdateItemPositions();
    this.UpdateItemClipping();
  }

  public GuiScrollList3D.땴[] GetItems() => this.딟.ToArray();

  public void Reset()
  {
    this.RemoveAll(true);
    this.딟 = 0.0f;
    this.땄 = 0.0f;
    this.딧 = 0.0f;
    // ISSUE: reference to a compiler-generated method
    this.set_Offset(0.0f);
    this.딢 = 0.0f;
    // ISSUE: reference to a compiler-generated method
    this.set_TotalOffset(0.0f);
  }

  public void RemoveAll(bool DestroyObjects)
  {
    if (DestroyObjects)
    {
      for (int index1 = 0; index1 < this.딟.Count; ++index1)
      {
        foreach (Renderer componentsInChild in ((Component) this.딟[index1].딟).GetComponentsInChildren<Renderer>())
        {
          for (int index2 = 0; index2 < componentsInChild.materials.Length; ++index2)
            GlobalAppData.딟(componentsInChild.materials[index2]);
        }
        Object.Destroy((Object) ((Component) this.딟[index1].딟).gameObject);
      }
    }
    this.딟.Clear();
  }

  public void ScrollToElement(int ElementIndex) => this.MoveToElement(ElementIndex, true);

  public void PositionToElement(int ElementIndex) => this.MoveToElement(ElementIndex, false);

  private void MoveToElement(int ElementIndex, bool scroll)
  {
    float offsetValue = 0.0f;
    for (int index = 0; index < ElementIndex - 1; ++index)
    {
      if (this.Horizontal)
      {
        if (!this.Invert)
          offsetValue += 2f * this.딟[index].딟;
        else
          offsetValue -= 2f * this.딟[index].딟;
      }
      else if (!this.Invert)
        offsetValue -= 2f * this.딟[index].딟;
      else
        offsetValue += 2f * this.딟[index].딟;
    }
    float num = this.ClampOffset(offsetValue);
    if (!scroll)
    {
      // ISSUE: reference to a compiler-generated method
      this.set_Offset(num);
    }
    this.딢 = num;
    this.UpdateItemPositions();
    this.UpdateItemClipping();
  }

  [SpecialName]
  public float get_MinOffset()
  {
    // ISSUE: variable of the null type
    __Null local;
    if (this.Horizontal)
    {
      Bounds bounds = ((Component) this).collider.bounds;
      local = ((Bounds) ref bounds).size.x;
    }
    else
    {
      Bounds bounds = ((Component) this).collider.bounds;
      local = ((Bounds) ref bounds).size.z;
    }
    return Mathf.Min(0.0f, (float) local - this.get_TotalOffset());
  }

  [SpecialName]
  public float get_MaxOffset() => 0.0f;

  public void SetOffset(float Amount)
  {
    // ISSUE: reference to a compiler-generated method
    this.set_Offset(Amount);
    this.딢 = this.get_Offset();
    this.UpdateItemPositions();
  }

  public void Scroll(float Amount)
  {
    GuiScrollList3D guiScrollList3D = this;
    // ISSUE: reference to a compiler-generated method
    guiScrollList3D.set_Offset(guiScrollList3D.get_Offset() + Amount);
    this.딢 = this.get_Offset();
    this.UpdateItemPositions();
  }

  public void SetScrollVel(float Amount) => this.땄 = Amount;

  private float ClampOffset(float offsetValue)
  {
    if ((double) offsetValue > (double) this.get_MaxOffset())
      return this.get_MaxOffset();
    return (double) offsetValue < (double) this.get_MinOffset() ? this.get_MinOffset() : offsetValue;
  }

  [SpecialName]
  public int get_TotalItemCount() => this.딟.Count;

  [CompilerGenerated]
  [SpecialName]
  public float get_Offset() => this.땃;

  [CompilerGenerated]
  [SpecialName]
  public float get_TotalOffset() => this.딶;

  public struct 땴
  {
    public Transform 딟;
    public float 딟;
    public Vector3 딟;
  }
}
