// Decompiled with JetBrains decompiler
// Type: FSConcaveShapeComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using UnityEngine;

[AddComponentMenu("FarseerUnity/Collision/Concave Shape Component")]
public class FSConcaveShapeComponent : MonoBehaviour
{
  public float Density = 1f;
  public float Restitution = 0.5f;
  public float Friction = 0.75f;
  [HideInInspector]
  public 땺.땝 CollisionFilter;
  public FSCollisionGroup CollisionGroup;
  public 땥.땑 BelongsTo = 땥.땑.딧;
  public bool BelongsToFold;
  public 땥.땑 CollidesWith = 땥.땑.땄;
  public bool CollidesWithFold;
  [HideInInspector]
  public Vector3[,] ConvertedVertices;
  [HideInInspector]
  public 땺.딳 PointInput = 땺.딳.땄;
  [HideInInspector]
  public Transform[] PointsTransforms;
  [HideInInspector]
  public Vector2[] PointsCoordinates;
  public static float 딟;

  [SpecialName]
  public float get_LocalGizmoScale() => FSConcaveShapeComponent.딟;

  [SpecialName]
  public void set_LocalGizmoScale(float value)
  {
    if ((double) FSConcaveShapeComponent.딟 == (double) value)
      return;
    FSConcaveShapeComponent.딟 = value;
    this.ConvertToConvex();
  }

  public virtual void OnDrawGizmos()
  {
    if (Application.isPlaying)
      return;
    if (this.PointInput == 땺.딳.땄)
    {
      if (this.PointsTransforms == null)
        return;
      List<Transform> transformList = new List<Transform>((IEnumerable<Transform>) this.PointsTransforms);
      foreach (Transform transform in ((Component) this).transform)
      {
        bool flag = transformList.Contains(transform);
        Gizmos.color = !flag ? Color.white : Color.magenta;
        Gizmos.DrawWireSphere(transform.position, !flag ? 0.1f : 0.13f);
      }
      this.DrawConnectionsFromTransforms();
    }
    else
    {
      Gizmos.color = Color.magenta;
      foreach (Vector2 pointsCoordinate in this.PointsCoordinates)
        Gizmos.DrawWireSphere(((Component) this).transform.TransformPoint((float) pointsCoordinate.x, (float) pointsCoordinate.y, (float) ((Component) this).transform.position.z), 0.13f);
      this.DrawConnectionsFromCoordinates();
    }
  }

  private void DrawConnectionsFromTransforms()
  {
    if (this.PointsTransforms == null || this.PointsTransforms.Length <= 2)
      return;
    Transform pointsTransform = this.PointsTransforms[this.PointsTransforms.Length - 1];
    for (int index = 0; index < this.PointsTransforms.Length; ++index)
    {
      if (Object.op_Inequality((Object) pointsTransform, (Object) null) && Object.op_Inequality((Object) this.PointsTransforms[index], (Object) null))
      {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(pointsTransform.position, this.PointsTransforms[index].position);
        Vector3 vector3 = Vector3.op_Addition(pointsTransform.position, Vector3.op_Division(Vector3.op_Subtraction(this.PointsTransforms[index].position, pointsTransform.position), 2f));
        Gizmos.color = Color.white;
        딝.땟.딟(vector3, new Vector3(FSConcaveShapeComponent.딟, FSConcaveShapeComponent.딟), index.ToString());
      }
      pointsTransform = this.PointsTransforms[index];
    }
  }

  private void DrawConnectionsFromCoordinates()
  {
    if (this.PointsCoordinates == null || this.PointsCoordinates.Length <= 2)
      return;
    Vector2 vector2 = this.PointsCoordinates[this.PointsCoordinates.Length - 1];
    for (int index = 0; index < this.PointsCoordinates.Length; ++index)
    {
      Gizmos.color = Color.magenta;
      Vector3 vector3_1;
      // ISSUE: explicit constructor call
      ((Vector3) ref vector3_1).\u002Ector((float) vector2.x, (float) vector2.y, (float) ((Component) this).transform.position.z);
      Vector3 vector3_2;
      // ISSUE: explicit constructor call
      ((Vector3) ref vector3_2).\u002Ector((float) this.PointsCoordinates[index].x, (float) this.PointsCoordinates[index].y, (float) ((Component) this).transform.position.z);
      Gizmos.DrawLine(((Component) this).transform.TransformPoint(vector3_1), ((Component) this).transform.TransformPoint(vector3_2));
      Vector3 vector3_3 = Vector3.op_Addition(vector3_1, Vector3.op_Division(Vector3.op_Subtraction(vector3_2, vector3_1), 2f));
      Gizmos.color = Color.white;
      딝.땟.딟(((Component) this).transform.TransformPoint(vector3_3), new Vector3(FSConcaveShapeComponent.딟, FSConcaveShapeComponent.딟), index.ToString());
      vector2 = Vector2.op_Implicit(vector3_2);
    }
  }

  public void ConvertToConvex()
  {
    foreach (FSShapeComponent componentsInChild in ((Component) this).GetComponentsInChildren<FSShapeComponent>())
    {
      if (!Object.op_Equality((Object) ((Component) componentsInChild).gameObject, (Object) null))
        Object.DestroyImmediate((Object) ((Component) componentsInChild).gameObject);
    }
    땥.땨 땨 = new 땥.땨();
    if (this.PointInput == 땺.딳.땄)
    {
      for (int index = 0; index < this.PointsTransforms.Length; ++index)
        땨.Add(딝.딷.딟(this.PointsTransforms[index].localPosition));
    }
    if (this.PointInput == 땺.딳.딟)
    {
      foreach (Vector2 pointsCoordinate in this.PointsCoordinates)
        땨.Add(딝.딷.딟(Vector2.op_Implicit(((Component) this).transform.TransformPoint(Vector2.op_Implicit(pointsCoordinate)))));
    }
    List<땥.땨> 땨List = 땺.땅.딟(땨);
    for (int index1 = 0; index1 < 땨List.Count; ++index1)
    {
      GameObject gameObject = new GameObject("convexShape" + index1.ToString());
      gameObject.transform.parent = ((Component) this).transform;
      gameObject.transform.localPosition = Vector3.zero;
      gameObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
      gameObject.transform.localScale = Vector3.one;
      FSShapeComponent fsShapeComponent = gameObject.AddComponent<FSShapeComponent>();
      fsShapeComponent.CollidesWith = this.CollidesWith;
      fsShapeComponent.CollisionFilter = this.CollisionFilter;
      fsShapeComponent.BelongsTo = this.BelongsTo;
      fsShapeComponent.CollisionGroup = this.CollisionGroup;
      fsShapeComponent.Friction = this.Friction;
      fsShapeComponent.Restitution = this.Restitution;
      fsShapeComponent.Density = this.Density;
      fsShapeComponent.UseUnityCollider = false;
      fsShapeComponent.UseTransforms = this.PointInput == 땺.딳.땄;
      if (this.PointInput == 땺.딳.땄)
      {
        fsShapeComponent.PolygonTransforms = new Transform[땨List[index1].Count];
        for (int index2 = 0; index2 < 땨List[index1].Count; ++index2)
          fsShapeComponent.PolygonTransforms[index2] = new GameObject("p" + index2.ToString((IFormatProvider) CultureInfo.InvariantCulture))
          {
            transform = {
              parent = ((Component) fsShapeComponent).transform,
              localPosition = 딝.딷.딟(땨List[index1][index2])
            }
          }.transform;
      }
      else
      {
        fsShapeComponent.PolygonCoordinates = new Vector2[땨List[index1].Count];
        for (int index3 = 0; index3 < 땨List[index1].Count; ++index3)
          fsShapeComponent.PolygonCoordinates[index3] = Vector2.op_Implicit(gameObject.transform.InverseTransformPoint(딝.딷.딟(땨List[index1][index3])));
      }
    }
  }
}
