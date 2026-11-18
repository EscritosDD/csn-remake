// Decompiled with JetBrains decompiler
// Type: FSShapeComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("FarseerUnity/Collision/Basic Shape Component")]
public class FSShapeComponent : MonoBehaviour
{
  public 땺.땙 SType = 땺.땙.딢;
  public bool UseUnityCollider = true;
  public float Density = 1f;
  public float Restitution = 0.5f;
  public float Friction = 0.75f;
  public bool UseTransforms;
  public Transform[] PolygonTransforms;
  public Vector2[] PolygonCoordinates;
  [HideInInspector]
  public 땺.땝 CollisionFilter;
  [HideInInspector]
  public FSCollisionGroup CollisionGroup;
  [HideInInspector]
  public 땥.땑 BelongsTo = 땥.땑.딧;
  [HideInInspector]
  public bool BelongsToFold;
  [HideInInspector]
  public 땥.땑 CollidesWith = 땥.땑.땄;
  [HideInInspector]
  public bool CollidesWithFold;

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.red;
    if (((Component) this).transform.childCount > 0)
    {
      for (int index = 0; index < ((Component) this).transform.childCount; ++index)
        Gizmos.DrawWireSphere(((Component) this).transform.GetChild(index).position, 0.15f);
    }
    if (this.SType == 땺.땙.땄)
    {
      SphereCollider component = ((Component) this).GetComponent<SphereCollider>();
      if (Object.op_Inequality((Object) component, (Object) null))
      {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(((Component) this).transform.position, component.radius * (float) ((Component) this).transform.lossyScale.x);
      }
    }
    if (this.UseTransforms)
      this.DrawTransformGizmos();
    else
      this.DrawCoordinatesGizmos();
  }

  private void DrawTransformGizmos()
  {
    if (this.PolygonTransforms == null || this.PolygonTransforms.Length < 3)
      return;
    Color yellow = Color.yellow;
    for (int index = 1; index < this.PolygonTransforms.Length; ++index)
    {
      if (!Object.op_Equality((Object) this.PolygonTransforms[index - 1], (Object) null) && !Object.op_Equality((Object) this.PolygonTransforms[index], (Object) null))
      {
        Gizmos.color = yellow;
        Gizmos.DrawLine(this.PolygonTransforms[index - 1].position, this.PolygonTransforms[index].position);
        ref Color local1 = ref yellow;
        local1.r = (__Null) (local1.r + 0.0500000007450581);
        ref Color local2 = ref yellow;
        local2.g = (__Null) (local2.g + 0.0500000007450581);
        ref Color local3 = ref yellow;
        local3.b = (__Null) (local3.b + 0.0500000007450581);
      }
    }
    if (this.PolygonTransforms.Length == 0 || Object.op_Equality((Object) this.PolygonTransforms[this.PolygonTransforms.Length - 1], (Object) null) || Object.op_Equality((Object) this.PolygonTransforms[0], (Object) null))
      return;
    Gizmos.DrawLine(this.PolygonTransforms[this.PolygonTransforms.Length - 1].position, this.PolygonTransforms[0].position);
  }

  private void DrawCoordinatesGizmos()
  {
    if (this.PolygonCoordinates == null || this.PolygonCoordinates.Length < 3)
      return;
    Color yellow = Color.yellow;
    for (int index = 1; index < this.PolygonCoordinates.Length; ++index)
    {
      Gizmos.color = yellow;
      Gizmos.DrawLine(((Component) this).transform.TransformPoint(Vector2.op_Implicit(this.PolygonCoordinates[index - 1])), ((Component) this).transform.TransformPoint(Vector2.op_Implicit(this.PolygonCoordinates[index])));
      ref Color local1 = ref yellow;
      local1.r = (__Null) (local1.r + 0.0500000007450581);
      ref Color local2 = ref yellow;
      local2.g = (__Null) (local2.g + 0.0500000007450581);
      ref Color local3 = ref yellow;
      local3.b = (__Null) (local3.b + 0.0500000007450581);
    }
    Gizmos.DrawLine(((Component) this).transform.TransformPoint(Vector2.op_Implicit(this.PolygonCoordinates[this.PolygonCoordinates.Length - 1])), ((Component) this).transform.TransformPoint(Vector2.op_Implicit(this.PolygonCoordinates[0])));
  }

  public 땺.땏 GetShape()
  {
    if (this.SType == 땺.땙.딢)
      return (땺.땏) this.GetPolyShape();
    if (this.SType != 땺.땙.땄)
      return (땺.땏) null;
    SphereCollider component = ((Component) this).GetComponent<SphereCollider>();
    return Object.op_Equality((Object) component, (Object) null) ? (땺.땏) null : (땺.땏) new 땺.땶(component.radius * (float) ((Component) this).transform.lossyScale.x, this.Density);
  }

  private 땺.떅 GetPolyShape()
  {
    bool hasFsBody = Object.op_Inequality((Object) ((Component) this).GetComponent<FSBodyComponent>(), (Object) null);
    List<땥.떁> shapePoints = new List<땥.떁>();
    if (this.UseUnityCollider)
    {
      if (!this.GetColliderMeasurements(hasFsBody, ref shapePoints))
        return (땺.떅) null;
    }
    else if (this.UseTransforms)
    {
      if (this.PolygonTransforms.Length < 3)
        return (땺.떅) null;
      foreach (Transform polygonTransform in this.PolygonTransforms)
        shapePoints.Add(!hasFsBody ? 딝.딷.딟(딝.딷.딟(((Component) this).transform.parent.InverseTransformPoint(polygonTransform.position), ((Component) this).transform.parent)) : 딝.딷.딟(polygonTransform.localPosition));
    }
    else
    {
      if (this.PolygonCoordinates.Length < 3)
        return (땺.떅) null;
      foreach (Vector2 polygonCoordinate in this.PolygonCoordinates)
        shapePoints.Add(!hasFsBody ? 딝.딷.딟(Vector2.op_Implicit(polygonCoordinate)) : 딝.딷.딟(Vector2.op_Implicit(polygonCoordinate)));
    }
    return new 땺.떅(new 땥.땨(shapePoints.ToArray()), this.Density);
  }

  private bool GetColliderMeasurements(bool hasFsBody, ref List<땥.떁> shapePoints)
  {
    BoxCollider component = ((Component) this).GetComponent<BoxCollider>();
    if (Object.op_Equality((Object) component, (Object) null))
      return false;
    Vector3 lossyScale = ((Component) this).transform.lossyScale;
    Transform transform = ((Component) this).transform;
    Bounds bounds = ((Collider) component).bounds;
    Vector3 center = ((Bounds) ref bounds).center;
    Vector3 vector3_1 = transform.InverseTransformPoint(center);
    Vector3 vector3_2 = Vector3.op_Addition(new Vector3((float) (-component.size.x * 0.5), (float) (-component.size.y * 0.5)), vector3_1);
    Vector3 vector3_3 = Vector3.op_Addition(new Vector3((float) (component.size.x * 0.5), (float) (-component.size.y * 0.5)), vector3_1);
    Vector3 vector3_4 = Vector3.op_Addition(new Vector3((float) (component.size.x * 0.5), (float) (component.size.y * 0.5)), vector3_1);
    Vector3 vector3_5 = Vector3.op_Addition(new Vector3((float) (-component.size.x * 0.5), (float) (component.size.y * 0.5)), vector3_1);
    ((Vector3) ref vector3_2).Scale(lossyScale);
    ((Vector3) ref vector3_3).Scale(lossyScale);
    ((Vector3) ref vector3_4).Scale(lossyScale);
    ((Vector3) ref vector3_5).Scale(lossyScale);
    Vector3 vector3_6 = !hasFsBody ? 딝.딷.딟(vector3_2, ((Component) this).transform) : vector3_2;
    Vector3 vector3_7 = !hasFsBody ? 딝.딷.딟(vector3_3, ((Component) this).transform) : vector3_3;
    Vector3 vector3_8 = !hasFsBody ? 딝.딷.딟(vector3_4, ((Component) this).transform) : vector3_4;
    Vector3 vector3_9 = !hasFsBody ? 딝.딷.딟(vector3_5, ((Component) this).transform) : vector3_5;
    shapePoints.Add(딝.딷.딟(vector3_6));
    shapePoints.Add(딝.딷.딟(vector3_7));
    shapePoints.Add(딝.딷.딟(vector3_8));
    shapePoints.Add(딝.딷.딟(vector3_9));
    return true;
  }
}
