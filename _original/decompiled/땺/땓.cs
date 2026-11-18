// Decompiled with JetBrains decompiler
// Type: 땺.땓
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 땺
{
  public interface 땓
  {
    Vector3 GetNormal([In] float obj0);

    Vector3 GetNormalInterpolated([In] float obj0);

    Vector3 GetNormal([In] int obj0);

    void SetOutControlPosition([In] int obj0, [In] Vector3 obj1);

    void SetOutControlPositionPointSpace([In] int obj0, [In] Vector3 obj1);

    void SetOutControlPositionWorldSpace([In] int obj0, [In] Vector3 obj1);

    void SetInControlPosition([In] int obj0, [In] Vector3 obj1);

    void SetInControlPositionPointSpace([In] int obj0, [In] Vector3 obj1);

    void SetInControlPositionWorldSpace([In] int obj0, [In] Vector3 obj1);

    Vector3 GetOutControlPosition([In] int obj0);

    Vector3 GetInControlPosition([In] int obj0);

    Vector3 GetOutControlPositionPointSpace([In] int obj0);

    Vector3 GetInControlPositionPointSpace([In] int obj0);

    Vector3 GetOutControlPositionWorldSpace([In] int obj0);

    Vector3 GetInControlPositionWorldSpace([In] int obj0);

    Vector3 GetPosition([In] int obj0);

    int GetPointCount();

    Vector3 GetPositionWorldSpace([In] int obj0);

    Vector3 GetPosition([In] float obj0);

    Vector3 GetPositionWorldSpace([In] float obj0);

    Vector3 GetMiddle();

    Rect GetBounds();

    float GetLength();

    float GetNearestSplinePosition([In] Vector3 obj0, [In] int obj1);

    float GetNearestSplinePositionWorldSpace([In] Vector3 obj0, [In] int obj1);

    Vector3 GetNearestPositionWorldSpace([In] Vector3 obj0);

    int GetNearestPointIndex([In] float obj0);

    int GetNearestPointIndex([In] Vector3 obj0);

    Vector3 GetNearestPosition([In] Vector3 obj0);

    void ClearPoints();

    void RemovePoint([In] int obj0);

    void AddPoint([In] int obj0, [In] Vector3 obj1, [In] Vector3 obj2, [In] Vector3 obj3, [In] float obj4, [In] bool obj5);

    void AddPoint([In] int obj0, [In] Vector3 obj1, [In] Vector3 obj2);

    void AddPoint([In] int obj0, [In] Vector3 obj1);

    int AddPoint([In] float obj0);

    void AddPointWorldSpace(
      [In] int obj0,
      [In] Vector3 obj1,
      [In] Vector3 obj2,
      [In] Vector3 obj3,
      [In] float obj4,
      [In] bool obj5);

    void AddPointWorldSpace([In] int obj0, [In] Vector3 obj1, [In] Vector3 obj2, [In] float obj3);

    void AddPointWorldSpace([In] int obj0, [In] Vector3 obj1, [In] Vector3 obj2);

    void AddPointWorldSpace([In] int obj0, [In] Vector3 obj1);

    void SetPoint([In] int obj0, [In] Vector3 obj1, [In] Vector3 obj2, [In] Vector3 obj3, [In] float obj4, [In] bool obj5);

    void SetPoint([In] int obj0, [In] Vector3 obj1, [In] Vector3 obj2, [In] Vector3 obj3, [In] bool obj4);

    void SetPoint([In] int obj0, [In] Vector3 obj1, [In] Vector3 obj2, [In] Vector3 obj3);

    void SetPoint([In] int obj0, [In] Vector3 obj1, [In] Vector3 obj2);

    void SetPoint([In] int obj0, [In] Vector3 obj1);

    void SetPointWorldSpace(
      [In] int obj0,
      [In] Vector3 obj1,
      [In] Vector3 obj2,
      [In] Vector3 obj3,
      [In] float obj4,
      [In] bool obj5);

    void SetPointWorldSpace([In] int obj0, [In] Vector3 obj1, [In] Vector3 obj2, [In] Vector3 obj3, [In] float obj4);

    void SetPointWorldSpace([In] int obj0, [In] Vector3 obj1, [In] Vector3 obj2, [In] Vector3 obj3);

    void SetPointWorldSpace([In] int obj0, [In] Vector3 obj1, [In] Vector3 obj2);

    void SetPointWorldSpace([In] int obj0, [In] Vector3 obj1);

    bool GetNatural([In] int obj0);

    void SetNatural([In] int obj0, [In] bool obj1);

    float GetOutlineWidth([In] float obj0);

    float GetOutlineWidth([In] int obj0);

    float GetOutlineWidthMultiplier([In] int obj0);

    void SetOutlineWidthMultiplier([In] int obj0, [In] float obj1);

    void RefreshMesh();

    void RefreshMesh([In] bool obj0, [In] bool obj1, [In] bool obj2);

    void SetOutline([In] RageSpline.떂 obj0);

    RageSpline.떂 GetOutline();

    void SetOutlineColor1([In] Color obj0);

    Color GetOutlineColor1();

    void SetOutlineColor2([In] Color obj0);

    Color GetOutlineColor2();

    RageSpline.땭 GetOutlineGradient();

    void SetOutlineGradient([In] RageSpline.땭 obj0);

    float GetOutlineNormalOffset();

    void SetOutlineNormalOffset([In] float obj0);

    RageSpline.딦 GetCorners();

    void SetCorners([In] RageSpline.딦 obj0);

    void SetFill([In] RageSpline.땤 obj0);

    RageSpline.땤 GetFill();

    void SetFillColor1([In] Color obj0);

    Color GetFillColor1();

    void SetFillColor2([In] Color obj0);

    Color GetFillColor2();

    void SetLandscapeBottomDepth([In] float obj0);

    float GetLandscapeBottomDepth();

    void SetLandscapeOutlineAlign([In] float obj0);

    float GetLandscapeOutlineAlign();

    void SetTexturing1([In] RageSpline.땽 obj0);

    RageSpline.땽 GetTexturing1();

    void SetTexturing2([In] RageSpline.땽 obj0);

    RageSpline.땽 GetTexturing2();

    void SetGradientOffset([In] Vector2 obj0);

    Vector2 GetGradientOffset();

    void SetGradientAngleDeg([In] float obj0);

    float GetGradientAngleDeg();

    void SetGradientScaleInv([In] float obj0);

    float GetGradientScaleInv();

    void SetTextureOffset([In] Vector2 obj0);

    Vector2 GetTextureOffset();

    void SetTextureAngleDeg([In] float obj0);

    float GetTextureAngleDeg();

    void SetTextureScaleInv([In] float obj0);

    float GetTextureScaleInv();

    void SetTextureOffset2([In] Vector2 obj0);

    Vector2 GetTextureOffset2();

    void SetTextureAngle2Deg([In] float obj0);

    float GetTextureAngle2Deg();

    void SetTextureScale2Inv([In] float obj0);

    float GetTextureScale2Inv();

    void SetEmboss([In] RageSpline.땋 obj0);

    RageSpline.땋 GetEmboss();

    void SetEmbossColor1([In] Color obj0);

    Color GetEmbossColor1();

    void SetEmbossColor2([In] Color obj0);

    Color GetEmbossColor2();

    void SetEmbossAngleDeg([In] float obj0);

    float GetEmbossAngleDeg();

    void SetEmbossOffset([In] float obj0);

    float GetEmbossOffset();

    void SetEmbossSize([In] float obj0);

    float GetEmbossSize();

    void SetEmbossSmoothness([In] float obj0);

    float GetEmbossSmoothness();

    void SetPhysics([In] RageSpline.땲 obj0);

    RageSpline.땲 GetPhysics();

    void SetCreatePhysicsInEditor([In] bool obj0);

    bool GetCreatePhysicsInEditor();

    void SetPhysicsMaterial([In] PhysicMaterial obj0);

    PhysicMaterial GetPhysicsMaterial();

    void SetVertexCount([In] int obj0);

    int GetVertexCount();

    void SetPhysicsColliderCount([In] int obj0);

    int GetPhysicsColliderCount();

    void SetCreateConvexMeshCollider([In] bool obj0);

    bool GetCreateConvexMeshCollider();

    void SetPhysicsZDepth([In] float obj0);

    float GetPhysicsZDepth();

    void SetPhysicsNormalOffset([In] float obj0);

    float GetPhysicsNormalOffset();

    void SetBoxColliderDepth([In] float obj0);

    float GetBoxColliderDepth();

    void SetAntialiasingWidth([In] float obj0);

    float GetAntialiasingWidth();

    void SetOutlineWidth([In] float obj0);

    float GetOutlineWidth();

    void SetOutlineTexturingScaleInv([In] float obj0);

    float GetOutlineTexturingScaleInv();

    void SetOptimizeAngle([In] float obj0);

    float GetOptimizeAngle();

    void SetOptimize([In] bool obj0);

    bool GetOptimize();

    void SetStyle([In] RageSplineStyle obj0);

    RageSplineStyle GetStyle();
  }
}
