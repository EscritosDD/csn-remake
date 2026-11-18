// Decompiled with JetBrains decompiler
// Type: GuiGameTouchInputComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

public class GuiGameTouchInputComponent : GuiComponent3D
{
  private const float 딟 = 0.5f;
  private Vector2 딟;
  private float 땄;
  private bool 딟;
  private bool 땄;
  private bool 딧;
  private Collider 딟;

  public override void OnDown(Vector3 Position)
  {
    if (딶.딡.땴() == null)
      return;
    this.딟 = Vector2.op_Implicit(Position);
    딶.딡.땴().땓(true);
    딶.딡.땴().땥(true);
    딶.딡.땴().땃(false);
    this.딟 = true;
    this.땄 = Time.time;
    this.땄 = true;
  }

  public override void OnUp(Vector3 Position)
  {
    if (딶.딡.땴() == null)
      return;
    if (딶.딡.땴().땠())
    {
      Vector3 vector3 = Position;
      int num = ~(1 << LayerMask.NameToLayer("CameraCollision"));
      Camera camera = ((Component) 딶.딡.땴().딟).camera;
      Ray ray1 = camera.ScreenPointToRay(Vector2.op_Implicit(this.딟));
      Ray ray2 = camera.ScreenPointToRay(vector3);
      RaycastHit raycastHit1;
      RaycastHit raycastHit2;
      if (Physics.Raycast(ray1, ref raycastHit1, float.PositiveInfinity, num) && Physics.Raycast(ray2, ref raycastHit2, float.PositiveInfinity, num) && Object.op_Inequality((Object) ((RaycastHit) ref raycastHit1).collider, (Object) null) && Object.op_Equality((Object) ((RaycastHit) ref raycastHit1).collider, (Object) ((RaycastHit) ref raycastHit2).collider))
        ((Component) ((RaycastHit) ref raycastHit1).collider).SendMessageUpwards("OnClicked", (SendMessageOptions) 1);
    }
    else if (딶.딡.땴().땂() && Object.op_Inequality((Object) this.딟, (Object) null))
    {
      ((Component) this.딟).SendMessageUpwards("OnHoldStop", (SendMessageOptions) 1);
      this.딟 = (Collider) null;
    }
    딶.딡.땴().땓(false);
    딶.딡.땴().땃(false);
    this.딧 = true;
  }

  public override void OnRightButtonDown(Vector3 Position)
  {
    if (딶.딡.땴() == null)
      return;
    딶.딡.땴().딶(true);
    Screen.lockCursor = true;
  }

  public override void OnRightButtonUp(Vector3 Position)
  {
    if (딶.딡.땴() == null)
      return;
    딶.딡.땴().딶(false);
  }

  private static Vector2 딟([In] Vector2 obj0) => obj0;

  public void Update()
  {
    if (!this.땄)
    {
      this.딧 = false;
    }
    else
    {
      if (Input.GetMouseButtonDown(1) && 딶.딡.땴().때())
      {
        딶.딡.땴().땥(false);
        딶.딡.땴().땺(true);
      }
      if (Input.GetMouseButtonDown(0) && 딶.딡.땴().딱())
      {
        딶.딡.땴().땥(false);
        딶.딡.땴().땺(true);
      }
      if (딶.딡.땴().땩())
      {
        if (Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(0))
          딶.딡.땴().땺(false);
      }
      else if (딶.딡.땴().때())
      {
        Vector2 vector2 = Vector2.op_Subtraction(GuiGameTouchInputComponent.딟(Vector2.op_Implicit(Input.mousePosition)), this.딟);
        if ((double) ((Vector2) ref vector2).sqrMagnitude > 2.0)
          this.딟 = false;
        if (this.딟 && (double) Time.time - (double) this.땄 > 0.5)
        {
          this.딟 = false;
          딶.딡.땴().땃(true);
          if (딶.딡.땴().땠())
          {
            Vector3 vector3 = Vector2.op_Implicit(GuiGameTouchInputComponent.딟(Vector2.op_Implicit(Input.mousePosition)));
            int num = ~(1 << LayerMask.NameToLayer("CameraCollision"));
            Camera camera = ((Component) 딶.딡.땴().딟).camera;
            Ray ray1 = camera.ScreenPointToRay(Vector2.op_Implicit(this.딟));
            Ray ray2 = camera.ScreenPointToRay(vector3);
            RaycastHit raycastHit1;
            RaycastHit raycastHit2;
            if (Physics.Raycast(ray1, ref raycastHit1, float.PositiveInfinity, num) && Physics.Raycast(ray2, ref raycastHit2, float.PositiveInfinity, num) && Object.op_Inequality((Object) ((RaycastHit) ref raycastHit1).collider, (Object) null) && Object.op_Equality((Object) ((RaycastHit) ref raycastHit1).collider, (Object) ((RaycastHit) ref raycastHit2).collider))
            {
              ((Component) ((RaycastHit) ref raycastHit1).collider).SendMessageUpwards("OnHoldStart", (SendMessageOptions) 1);
              this.딟 = ((RaycastHit) ref raycastHit1).collider;
            }
            딶.딡.땴().땥(false);
          }
        }
        if (딶.딡.땴().땂())
          딶.딡.땴().딟(Vector2.op_Implicit(GuiGameTouchInputComponent.딟(Vector2.op_Implicit(Input.mousePosition))));
      }
      if (!this.딧)
        return;
      this.땄 = false;
    }
  }
}
