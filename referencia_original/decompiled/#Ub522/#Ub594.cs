// Decompiled with JetBrains decompiler
// Type: 딢.떔
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 딢
{
  public class 떔
  {
    public Plane[] 딟;
    public Ray 딟;
    public Ray 땄;
    private Vector3 딟;
    private Vector3 땄;
    private Camera 딟;
    private Transform 딟;
    private Quaternion 딟;
    private float 딟;

    public 떔([In] Camera obj0)
    {
      this.딟 = obj0;
      this.딟 = ((Component) obj0).transform;
      this.딟 = new Vector3(1f, 1f, 0.0f);
      this.땄 = Vector3.zero;
      this.딟 = GeometryUtility.CalculateFrustumPlanes(obj0);
      this.딟(new Rect(0.0f, 0.0f, 1f, 1f));
    }

    public void 딟([In] Vector3 obj0)
    {
      Vector3 forward = this.딟.forward;
      ((Plane) ref this.딟[0]).SetNormalAndPosition(((Plane) ref this.딟[0]).normal, obj0);
      ((Plane) ref this.딟[1]).SetNormalAndPosition(((Plane) ref this.딟[1]).normal, obj0);
      ((Plane) ref this.딟[2]).SetNormalAndPosition(((Plane) ref this.딟[2]).normal, obj0);
      ((Plane) ref this.딟[3]).SetNormalAndPosition(((Plane) ref this.딟[3]).normal, obj0);
      ((Plane) ref this.딟[4]).SetNormalAndPosition(((Plane) ref this.딟[4]).normal, Vector3.op_Addition(obj0, Vector3.op_Multiply(forward, this.딟.nearClipPlane)));
      ((Plane) ref this.딟[5]).SetNormalAndPosition(((Plane) ref this.딟[5]).normal, Vector3.op_Addition(obj0, Vector3.op_Multiply(forward, this.딟.farClipPlane)));
    }

    public void 딟([In] Rect obj0)
    {
      Vector3 position = this.딟.position;
      Quaternion rotation = this.딟.rotation;
      if ((double) this.딟 != (double) this.딟.fieldOfView || Quaternion.op_Inequality(this.딟, rotation))
      {
        this.딟 = this.딟.fieldOfView;
        this.딟 = rotation;
        this.딟.x = (__Null) (double) ((Rect) ref obj0).xMax;
        this.딟.y = (__Null) (double) ((Rect) ref obj0).xMax;
        this.땄.x = (__Null) (double) ((Rect) ref obj0).xMin;
        this.땄.y = (__Null) (double) ((Rect) ref obj0).yMin;
        this.딟 = this.딟.ViewportPointToRay(this.딟);
        this.땄 = this.딟.ViewportPointToRay(this.땄);
        Vector3 vector3_1 = Vector3.Cross(((Ray) ref this.딟).direction, this.딟.up);
        Vector3 vector3_2 = Vector3.Cross(((Ray) ref this.땄).direction, Vector3.op_UnaryNegation(this.딟.up));
        Vector3 vector3_3 = Vector3.Cross(((Ray) ref this.딟).direction, Vector3.op_UnaryNegation(this.딟.right));
        Vector3 vector3_4 = Vector3.Cross(((Ray) ref this.땄).direction, this.딟.right);
        Vector3 forward = this.딟.forward;
        Vector3 vector3_5 = Vector3.op_UnaryNegation(forward);
        ((Plane) ref this.딟[0]).SetNormalAndPosition(vector3_1, position);
        ((Plane) ref this.딟[1]).SetNormalAndPosition(vector3_2, position);
        ((Plane) ref this.딟[2]).SetNormalAndPosition(vector3_3, position);
        ((Plane) ref this.딟[3]).SetNormalAndPosition(vector3_4, position);
        ((Plane) ref this.딟[4]).SetNormalAndPosition(forward, Vector3.op_Addition(position, Vector3.op_Multiply(forward, this.딟.nearClipPlane)));
        ((Plane) ref this.딟[5]).SetNormalAndPosition(vector3_5, Vector3.op_Addition(position, Vector3.op_Multiply(forward, this.딟.farClipPlane)));
      }
      else
        this.딟(position);
    }

    public bool 땄([In] Vector3 obj0) => GeometryUtility.TestPlanesAABB(this.딟, new Bounds(obj0, Vector3.zero));

    public bool 딟([In] Bounds obj0) => GeometryUtility.TestPlanesAABB(this.딟, obj0);
  }
}
