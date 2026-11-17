// Decompiled with JetBrains decompiler
// Type: RageSpline
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using 땺;

[ExecuteInEditMode]
public class RageSpline : MonoBehaviour, 땓
{
  public RageSpline.떂 outline = RageSpline.떂.땄;
  public Color outlineColor1 = Color.black;
  public Color outlineColor2 = Color.black;
  public float OutlineWidth = 1f;
  public float outlineTexturingScale = 10f;
  public RageSpline.땭 outlineGradient;
  public float outlineNormalOffset;
  public RageSpline.딦 corners;
  public RageSpline.땤 fill = RageSpline.땤.땄;
  public float landscapeBottomDepth = 10f;
  public Color fillColor1 = new Color(0.6f, 0.6f, 0.6f, 1f);
  public Color fillColor2 = new Color(0.4f, 0.4f, 0.4f, 1f);
  public RageSpline.땽 UVMapping1;
  public RageSpline.땽 UVMapping2;
  public Vector2 gradientOffset = new Vector2(-5f, 5f);
  public float gradientAngle;
  public float gradientScale = 0.1f;
  public Vector2 textureOffset = new Vector2(-5f, -5f);
  public float textureAngle;
  public float textureScale = 0.1f;
  public Vector2 textureOffset2 = new Vector2(5f, 5f);
  public float textureAngle2;
  public float textureScale2 = 0.1f;
  public RageSpline.땋 emboss;
  public Color embossColor1 = new Color(0.75f, 0.75f, 0.75f, 1f);
  public Color embossColor2 = new Color(0.25f, 0.25f, 0.25f, 1f);
  public float embossAngle = 180f;
  public float embossOffset = 0.5f;
  public float embossSize = 10f;
  public float embossCurveSmoothness = 10f;
  public RageSpline.땲 physics;
  public bool createPhysicsInEditor;
  public bool createConvexMeshCollider;
  public PhysicMaterial physicsMaterial;
  [SerializeField]
  private int _vertexDensity;
  public int vertexCount = 64;
  public bool LockVertexCount;
  public int physicsColliderCount = 32;
  public bool LockPhysicsToAppearence;
  public float colliderZDepth = 100f;
  public float colliderNormalOffset;
  public float boxColliderDepth = 1f;
  private BoxCollider[] 딟;
  public int lastPhysicsVertsCount;
  public float antiAliasingWidth = 0.5f;
  public float landscapeOutlineAlign = 1f;
  public bool showSplineGizmos = true;
  public bool showOtherGizmos = true;
  public float maxBeakLength = 3f;
  public bool optimize;
  public float optimizeAngle = 5f;
  public RageSpline.떏 showCoordinates;
  public float gridSize = 5f;
  public Color gridColor = new Color(1f, 1f, 1f, 0.2f);
  public bool showGrid = true;
  public int gridExpansion = 2;
  public bool snapToGrid = true;
  public bool snapHandlesToGrid;
  public bool showNumberInputs;
  public RageSplineStyle style;
  public string defaultStyleName = "Stylename";
  public bool styleLocalGradientPositioning;
  public bool styleLocalTexturePositioning;
  public bool styleLocalEmbossPositioning;
  public bool styleLocalAntialiasing;
  public bool styleLocalVertexCount;
  public bool styleLocalPhysicsColliderCount;
  public bool showWireFrameInEditor;
  public bool hideHandles;
  public bool FlattenZ = true;
  public bool FixOverlaps = true;
  public bool isDirty;
  public bool FixUvs;
  public bool AutoRefresh;
  public float AutoRefreshDelay = 0.15f;
  public bool AutoRefreshDelayRandomize = true;
  [SerializeField]
  private bool _perspectiveMode;
  public RageCurve spline;
  public bool lowQualityRender;
  public bool inverseTriangleDrawOrder;
  public float overLappingVertsShift = 0.01f;
  private ArrayList 딟;
  private Mesh 딟;
  private static Quaternion 딟 = Quaternion.AngleAxis(90f, Vector3.forward);
  private static Color 딟 = new Color(1f, 1f, 1f, 1f);
  private static Color 땄 = new Color(1f, 1f, 1f, 0.0f);
  private static readonly Vector3 딟 = new Vector3(0.0f, 0.0f, -0.02f);
  private static readonly Vector3 땄 = new Vector3(0.0f, 0.0f, 0.02f);
  private static readonly Vector3 딧 = new Vector3(0.0f, 0.0f, -0.04f);
  [SerializeField]
  private static ScriptableObject _triangulator;
  [SerializeField]
  private RageCamera _rageCamera;
  public bool DestroyFarseerNow;
  public bool showTriangleCount;
  public bool FarseerPhysicsPointsOnly;

  [SpecialName]
  public int get_VertexDensity() => this._vertexDensity;

  [SpecialName]
  public void set_VertexDensity(int value)
  {
    this._vertexDensity = value;
    this.SetVertexCount((int) Mathf.Max(1f, (float) (this.GetPointCount() * this._vertexDensity)));
  }

  [SpecialName]
  public bool get_PerspectiveMode() => this._perspectiveMode;

  [SpecialName]
  public void set_PerspectiveMode(bool value)
  {
    if (this._perspectiveMode == value)
      return;
    this._perspectiveMode = value;
    this.MaterialApplyCheck(true);
  }

  [SpecialName]
  public 땺.땺 get_Triangulator()
  {
    if (Object.op_Equality((Object) RageSpline._triangulator, (Object) null))
      RageSpline._triangulator = (ScriptableObject) ScriptableObject.CreateInstance<RageTriangulator>();
    return (땺.땺) RageSpline._triangulator;
  }

  [SpecialName]
  public void set_Triangulator(땺.땺 value) => RageSpline._triangulator = (ScriptableObject) value;

  public void OnEnable()
  {
    if (Object.op_Equality((Object) this._rageCamera, (Object) null))
      this._rageCamera = ((Component) Camera.main).GetComponent<RageCamera>();
    if (!Object.op_Equality((Object) this._rageCamera, (Object) null))
      return;
    this._rageCamera = ((Component) Camera.main).gameObject.AddComponent<RageCamera>();
  }

  public void Awake()
  {
    if (this.spline == null)
      this.CreateDefaultSpline();
    this.딟 = new ArrayList();
    this.MeshCreationCheck(((Component) this).GetComponent(typeof (MeshFilter)) as MeshFilter);
    if (!this.AutoRefresh)
      return;
    this.StartCoroutine(this.AutoRefreshScheduler());
  }

  [DebuggerHidden]
  private IEnumerator AutoRefreshScheduler() => (IEnumerator) new RageSpline.\u003CAutoRefreshScheduler\u003Ec__Iterator19()
  {
    딟 = this
  };

  private void MeshCreationCheck(MeshFilter meshFilter)
  {
    if (!Application.isPlaying)
    {
      if (Object.op_Inequality((Object) meshFilter, (Object) null))
        meshFilter.sharedMesh = (Mesh) null;
      this.RefreshMesh();
    }
    else if (Object.op_Equality((Object) meshFilter, (Object) null))
      this.RefreshMesh();
    else if (Object.op_Equality((Object) meshFilter.sharedMesh, (Object) null))
    {
      this.RefreshMesh();
    }
    else
    {
      if (meshFilter.mesh.vertexCount == 0)
        this.RefreshMesh();
      if (this.spline == null)
        this.CreateDefaultSpline();
      this.spline.땺(this.GetVertexCount() + 1);
      if (this.GetPhysics() == RageSpline.땲.땄)
        this.CreateBoxCollidersCache();
      if (this.GetCreatePhysicsInEditor() || this.GetPhysics() == RageSpline.땲.딟)
        return;
      this.RefreshPhysics();
    }
  }

  public void OnDestroy()
  {
    if (!Application.isPlaying || !Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    Object.Destroy((Object) this.딟);
    this.딟 = (Mesh) null;
  }

  public void OnDrawGizmosSelected()
  {
    if (this.showSplineGizmos)
      this.DrawSplineGizmos();
    if (this.showGrid && this.showCoordinates != RageSpline.떏.딟)
      this.DrawGrid();
    if (!this.showOtherGizmos)
      return;
    if (this.GetEmboss() != RageSpline.땋.딟)
      this.DrawEmbossGizmos();
    if (this.GetFill() == RageSpline.땤.딧)
      this.DrawGradientGizmos();
    if (this.GetTexturing1() != RageSpline.땽.딟 && this.GetTexturing1() == RageSpline.땽.땄 && this.GetFill() != RageSpline.땤.딟)
      this.DrawTexturingGizmos();
    if (this.GetTexturing2() == RageSpline.땽.딟 || this.GetTexturing2() != RageSpline.땽.땄 || this.GetFill() == RageSpline.땤.딟)
      return;
    this.DrawTexturingGizmos2();
  }

  public void RefreshMesh()
  {
    this.SetVertexCount(this.GetVertexCount());
    if (this.딟 == null)
      this.딟 = new ArrayList();
    if (Object.op_Equality((Object) (((Component) this).GetComponent(typeof (MeshFilter)) as MeshFilter), (Object) null))
      ((Component) this).gameObject.AddComponent(typeof (MeshFilter));
    this.MaterialApplyCheck(false);
    if ((double) Mathf.Abs((float) ((Component) this).gameObject.transform.localScale.x) <= 0.0 || (double) Mathf.Abs((float) ((Component) this).gameObject.transform.localScale.y) <= 0.0 || (double) Mathf.Abs((float) ((Component) this).gameObject.transform.localScale.z) <= 0.0)
      return;
    if (this.spline == null)
      this.CreateDefaultSpline();
    this.spline.땺(this.GetVertexCount() + 1);
    this.GenerateMesh(true);
    this.RefreshPhysics();
  }

  public void RefreshMesh(bool refreshFillTriangulation, bool refreshNormals, bool refreshPhysics)
  {
    this.SetVertexCount(this.GetVertexCount());
    if ((double) Mathf.Abs((float) ((Component) this).gameObject.transform.localScale.x) <= 0.0 || (double) Mathf.Abs((float) ((Component) this).gameObject.transform.localScale.y) <= 0.0 || (double) Mathf.Abs((float) ((Component) this).gameObject.transform.localScale.z) <= 0.0)
      return;
    if (refreshNormals)
      this.spline.땺(this.GetVertexCount() + 1);
    this.GenerateMesh(refreshFillTriangulation);
    if (!refreshPhysics)
      return;
    this.RefreshPhysics();
  }

  public void RefreshMeshInEditor(bool forceRefresh, bool triangulation, bool precalcNormals)
  {
    this.SetVertexCount(this.GetVertexCount());
    if (this.딟 == null)
      this.딟 = new ArrayList();
    this.lowQualityRender = !forceRefresh && this.GetVertexCount() > 128;
    this.FlattenZ = true;
    if (this.GetVertexCount() > 128 && !forceRefresh)
      return;
    if (Object.op_Equality((Object) (((Component) this).GetComponent(typeof (MeshFilter)) as MeshFilter), (Object) null))
      ((Component) this).gameObject.AddComponent(typeof (MeshFilter));
    this.MaterialApplyCheck(false);
    if ((double) Mathf.Abs((float) ((Component) this).gameObject.transform.localScale.x) <= 0.0 || (double) Mathf.Abs((float) ((Component) this).gameObject.transform.localScale.y) <= 0.0 || (double) Mathf.Abs((float) ((Component) this).gameObject.transform.localScale.z) <= 0.0)
      return;
    if (forceRefresh && !this.pointsAreInClockWiseOrder())
      this.flipPointOrder();
    if (precalcNormals)
      this.spline.땺(this.GetVertexCount() + 1);
    this.GenerateMesh(triangulation);
    if (!forceRefresh)
      return;
    this.RefreshPhysics();
  }

  private void MaterialApplyCheck(bool changeMode)
  {
    MeshRenderer meshRenderer = ((Component) this).GetComponent<MeshRenderer>();
    if (Object.op_Inequality((Object) meshRenderer, (Object) null) && !changeMode)
      return;
    if (Object.op_Equality((Object) meshRenderer, (Object) null))
      meshRenderer = ((Component) this).gameObject.AddComponent(typeof (MeshRenderer)) as MeshRenderer;
    if (this._perspectiveMode)
    {
      Material[] materialArray = new Material[2]
      {
        Resources.Load("RS3DBasicFill") as Material,
        Resources.Load("RS3DAA") as Material
      };
      ((Renderer) meshRenderer).sharedMaterials = materialArray;
      this.RefreshMeshInEditor(true, true, true);
    }
    else
    {
      ((Renderer) meshRenderer).sharedMaterials = new Material[1];
      ((Renderer) meshRenderer).sharedMaterial = Resources.Load("RageSplineMaterial") as Material;
      this.RefreshMeshInEditor(true, true, true);
    }
  }

  public void GenerateMesh(bool refreshTriangulation)
  {
    if (this.FlattenZ)
      this.ForceZeroZ();
    if (this.GetFill() != RageSpline.땤.딟 && this.FixOverlaps)
      this.ShiftOverlappingControlPoints();
    bool flag1 = false;
    float antialiasingWidth = this.GetAntialiasingWidth();
    if ((double) antialiasingWidth > 0.0)
    {
      if (this.inverseTriangleDrawOrder)
        flag1 = true;
      else if (this.GetOutline() == RageSpline.떂.딟 || (double) Mathf.Abs(this.GetOutlineNormalOffset()) > (double) this.GetOutlineWidth() + (double) antialiasingWidth)
        flag1 = true;
    }
    bool flag2 = (double) antialiasingWidth > 0.0;
    bool flag3 = (double) antialiasingWidth > 0.0;
    bool multipleMaterials = false;
    MeshRenderer component1 = ((Component) this).GetComponent(typeof (MeshRenderer)) as MeshRenderer;
    if (Object.op_Inequality((Object) component1, (Object) null) && ((Renderer) component1).sharedMaterials.GetLength(0) > 1)
      multipleMaterials = true;
    RageSpline.땼[] outlineVerts = this.GenerateOutlineVerts(flag2, multipleMaterials);
    RageSpline.땼[] fillVerts = this.GenerateFillVerts(flag1, multipleMaterials);
    RageSpline.땼[] embossVerts = this.GenerateEmbossVerts(flag3);
    int length = outlineVerts.Length + fillVerts.Length + embossVerts.Length + 2;
    Vector3[] vector3Array = new Vector3[length];
    Vector2[] vector2Array1 = new Vector2[length];
    Vector2[] vector2Array2 = new Vector2[length];
    Color[] colorArray = new Color[length];
    int index1 = 0;
    for (int index2 = 0; index2 < fillVerts.Length; ++index2)
    {
      vector3Array[index1] = fillVerts[index2].딟;
      vector2Array1[index1] = fillVerts[index2].딟;
      vector2Array2[index1] = fillVerts[index2].땄;
      colorArray[index1] = fillVerts[index2].딟;
      ++index1;
    }
    for (int index3 = 0; index3 < embossVerts.Length; ++index3)
    {
      vector3Array[index1] = embossVerts[index3].딟;
      vector2Array1[index1] = embossVerts[index3].딟;
      vector2Array2[index1] = embossVerts[index3].땄;
      colorArray[index1] = embossVerts[index3].딟;
      ++index1;
    }
    for (int index4 = 0; index4 < outlineVerts.Length; ++index4)
    {
      vector3Array[index1] = outlineVerts[index4].딟;
      vector2Array1[index1] = outlineVerts[index4].딟;
      vector2Array2[index1] = outlineVerts[index4].땄;
      colorArray[index1] = outlineVerts[index4].딟;
      ++index1;
    }
    vector3Array[index1] = new Vector3(-1000f, -1000f, -1000f);
    vector2Array1[index1] = new Vector2();
    vector2Array2[index1] = new Vector2();
    colorArray[index1] = new Color();
    int index5 = index1 + 1;
    vector3Array[index5] = new Vector3(1000f, 1000f, 1000f);
    vector2Array1[index5] = new Vector2();
    vector2Array2[index5] = new Vector2();
    colorArray[index5] = new Color();
    MeshFilter component2 = ((Component) this).GetComponent(typeof (MeshFilter)) as MeshFilter;
    if (vector3Array.Length > 0)
    {
      ref Vector3 local = ref vector3Array[0];
      local = Vector3.op_Addition(local, new Vector3(0.0f, 0.0f, -1f / 1000f));
    }
    Mesh mesh = component2.sharedMesh;
    if (Object.op_Equality((Object) mesh, (Object) null))
    {
      mesh = new Mesh();
      this.딟 = mesh;
    }
    if (refreshTriangulation)
      mesh.Clear();
    mesh.vertices = vector3Array;
    if (refreshTriangulation)
      this.GenerateTriangles(mesh, fillVerts, embossVerts, outlineVerts, flag1, flag3, flag2, multipleMaterials);
    mesh.colors = colorArray;
    mesh.RecalculateBounds();
    component2.sharedMesh = mesh;
    if (this.GetFill() == RageSpline.땤.딟 || !this.FixOverlaps)
      return;
    this.UnshiftOverlappingControlPoints();
  }

  public void scalePoints(Vector3 middle, float scale)
  {
    for (int index = 0; index < this.GetPointCount(); ++index)
    {
      Vector3 position = this.GetPosition(index);
      this.SetPoint(index, Vector3.op_Addition(Vector3.op_Multiply(Vector3.op_Subtraction(position, middle), scale), middle));
    }
  }

  public void scaleHandles(float scale)
  {
    for (int index = 0; index < this.GetPointCount(); ++index)
    {
      Vector3 positionPointSpace1 = this.GetInControlPositionPointSpace(index);
      Vector3 positionPointSpace2 = this.GetOutControlPositionPointSpace(index);
      this.SetPoint(index, this.GetPosition(index), Vector3.op_Multiply(positionPointSpace1, scale), Vector3.op_Multiply(positionPointSpace2, scale));
    }
  }

  public void setPivotCenter()
  {
    Vector3 middle = this.GetMiddle();
    for (int index = 0; index < this.GetPointCount(); ++index)
      this.SetPoint(index, Vector3.op_Subtraction(this.GetPosition(index), middle));
    Transform transform = ((Component) this).transform;
    transform.position = Vector3.op_Addition(transform.position, Vector3.op_Subtraction(((Component) this).transform.TransformPoint(middle), ((Component) this).transform.position));
  }

  public void CreateBoxCollidersCache()
  {
    this.딟 = new BoxCollider[this.GetPhysicsColliderCount()];
    int childCount = ((Component) this).transform.GetChildCount();
    int num = 0;
    for (int index = 0; index < childCount; ++index)
    {
      GameObject gameObject = ((Component) ((Component) this).transform.GetChild(index)).gameObject;
      if (((Object) gameObject).name.Substring(0, 4).Equals("ZZZ_"))
      {
        BoxCollider component = gameObject.GetComponent(typeof (BoxCollider)) as BoxCollider;
        if (Object.op_Inequality((Object) component, (Object) null))
        {
          if (num < this.딟.Length)
            this.딟[num++] = component;
          else
            Debug.Log((object) "Error caching the boxcolliders. Amount of the boxcolliders doesn't match the count variable.");
        }
      }
    }
  }

  public void ShiftOverlappingControlPoints()
  {
    if (this.딟 == null)
      return;
    this.딟.Clear();
    int pointCount = this.GetPointCount();
    for (int index1 = 0; index1 < pointCount; ++index1)
    {
      for (int index2 = index1 + 1; index2 < pointCount; ++index2)
      {
        if (땺.땢.딟((float) this.GetPosition(index1).x, (float) this.GetPosition(index2).x) && 땺.땢.딟((float) this.GetPosition(index1).y, (float) this.GetPosition(index2).y))
        {
          this.SetPoint(index1, Vector3.op_Addition(this.GetPosition(index1), Vector3.op_Multiply(Vector3.op_Multiply(this.GetNormal(index1), -1f), this.overLappingVertsShift)));
          this.SetPoint(index2, Vector3.op_Addition(this.GetPosition(index2), Vector3.op_Multiply(Vector3.op_Multiply(this.GetNormal(index2), -1f), this.overLappingVertsShift)));
          this.딟.Add((object) index1);
          this.딟.Add((object) index2);
        }
      }
    }
  }

  public void UnshiftOverlappingControlPoints()
  {
    if (this.딟 == null)
      return;
    foreach (int index in this.딟)
      this.SetPoint(index, Vector3.op_Addition(this.GetPosition(index), Vector3.op_Multiply(this.GetNormal(index), this.overLappingVertsShift)));
  }

  public RageSpline.땼[] GenerateOutlineVerts(bool antialiasing, bool multipleMaterials)
  {
    RageSpline.땼[] 땼Array = this.GetOutline() != RageSpline.떂.딟 ? this.OutlineVerts(antialiasing, multipleMaterials) : new RageSpline.땼[0];
    for (int index = 0; index < 땼Array.Length; ++index)
    {
      ref RageSpline.땼 local = ref 땼Array[index];
      local.딟 = Vector3.op_Addition(local.딟, RageSpline.딧);
    }
    return 땼Array;
  }

  private RageSpline.땼[] OutlineVerts(bool antialiasing, bool multipleMaterials)
  {
    RageSpline.땼[] splits = this.GetOutline() != RageSpline.떂.딧 || this.GetFill() == RageSpline.땤.딟 || this.GetFill() == RageSpline.땤.딢 ? this.GetSplits(this.GetVertexCount(), 0.0f, 1f) : this.GetSplits(this.GetVertexCount() - Mathf.FloorToInt((float) this.GetVertexCount() * 1f / (float) this.GetPointCount()), 0.0f, (float) (1.0 - 1.0 / (double) this.GetPointCount()));
    int length = splits.Length;
    float uvPos = 0.0f;
    RageSpline.땼[] 땼Array1;
    if (antialiasing)
    {
      땼Array1 = new RageSpline.땼[splits.Length * 4];
    }
    else
    {
      RageSpline.땼[] 땼Array2 = 땼Array1 = new RageSpline.땼[splits.Length * 2];
    }
    RageSpline.땼[] outlineVerts = 땼Array1;
    for (int v = 0; v < splits.Length; ++v)
    {
      float outlineWidth = this.GetOutlineWidth(splits[v].딟 * this.GetLastSplinePosition());
      float antialiasingWidth = this.GetAntialiasingWidth(splits[v].딟 * this.GetLastSplinePosition());
      Vector3 normal = this.OutlineVertsCheckCorner(splits, v, ref outlineWidth);
      if (v > 0)
      {
        double num = (double) uvPos;
        Vector3 vector3 = Vector3.op_Subtraction(splits[v].딟, splits[v - 1].딟);
        double magnitude = (double) ((Vector3) ref vector3).magnitude;
        uvPos = (float) (num + magnitude);
      }
      Vector3 local = this.ScaleToLocal(((Vector3) ref normal).normalized);
      Vector3 normalized = ((Vector3) ref normal).normalized;
      float outlineNormalOffset = this.GetOutlineNormalOffset();
      outlineVerts = this.OutlineVertsProcessSplit(antialiasing, local, length, outlineWidth, outlineNormalOffset, normalized, outlineVerts, v, normal, splits, antialiasingWidth);
      Color color1 = RageSpline.딟;
      Color color2 = RageSpline.딟;
      switch (this.GetOutlineGradient())
      {
        case RageSpline.땭.딟:
          color1 = this.GetOutlineColor1();
          color2 = this.GetOutlineColor1();
          break;
        case RageSpline.땭.땄:
          color1 = this.GetOutlineColor1();
          color2 = this.GetOutlineColor2();
          break;
        case RageSpline.땭.딧:
          color1 = this.GetOutlineColor2();
          color2 = this.GetOutlineColor1();
          break;
      }
      if (antialiasing)
      {
        outlineVerts[v + 0 * length].딟 = Color.op_Multiply(color2, RageSpline.땄);
        outlineVerts[v + 1 * length].딟 = Color.op_Multiply(color2, RageSpline.딟);
        outlineVerts[v + 2 * length].딟 = Color.op_Multiply(color1, RageSpline.딟);
        outlineVerts[v + 3 * length].딟 = Color.op_Multiply(color1, RageSpline.땄);
      }
      else
      {
        outlineVerts[v + 0 * length].딟 = Color.op_Multiply(color2, RageSpline.딟);
        outlineVerts[v + 1 * length].딟 = Color.op_Multiply(color1, RageSpline.딟);
      }
      float AAWidthRelatedToEdgeWidth = 0.0f;
      if ((double) antialiasingWidth > 0.0 && (double) outlineWidth > 0.0 && antialiasing)
        AAWidthRelatedToEdgeWidth = antialiasingWidth / outlineWidth;
      if (!multipleMaterials)
        this.OutlineVertsSingleMaterial(antialiasing, uvPos, AAWidthRelatedToEdgeWidth, outlineVerts, v, length);
      else if (antialiasing)
      {
        outlineVerts[v + 0 * length].딟 = new Vector2(uvPos / this.GetOutlineTexturingScaleInv(), 1f);
        outlineVerts[v + 1 * length].딟 = new Vector2(uvPos / this.GetOutlineTexturingScaleInv(), (float) (1.0 - (double) AAWidthRelatedToEdgeWidth * 0.5));
        outlineVerts[v + 2 * length].딟 = new Vector2(uvPos / this.GetOutlineTexturingScaleInv(), AAWidthRelatedToEdgeWidth * 0.5f);
        outlineVerts[v + 3 * length].딟 = new Vector2(uvPos / this.GetOutlineTexturingScaleInv(), 0.0f);
      }
      else
      {
        outlineVerts[v + 0 * length].딟 = new Vector2(uvPos / this.GetOutlineTexturingScaleInv(), 0.99f);
        outlineVerts[v + 1 * length].딟 = new Vector2(uvPos / this.GetOutlineTexturingScaleInv(), 0.01f);
      }
    }
    return outlineVerts;
  }

  private Vector3 OutlineVertsCheckCorner(RageSpline.땼[] splits, int v, ref float edgeWidth)
  {
    Vector3 vector3;
    if (this.corners != RageSpline.딦.땄)
    {
      if (this.GetFill() != RageSpline.땤.딢)
      {
        vector3 = this.GetNormal(splits[v].딟);
      }
      else
      {
        vector3 = Vector3.op_Addition(Vector3.op_Multiply(Vector3.up, this.GetLandscapeOutlineAlign()), Vector3.op_Multiply(this.GetNormal(splits[v].딟), 1f - this.GetLandscapeOutlineAlign()));
        ((Vector3) ref vector3).Normalize();
      }
    }
    else
    {
      if (this.outline != RageSpline.떂.딧 || v < splits.Length - 1 && v > 0)
      {
        vector3 = Vector3.op_Multiply(this.FindNormal(splits[this.GetIndex(v - 1, splits.Length)].딟, splits[v].딟, splits[this.GetIndex(v + 1, splits.Length)].딟, edgeWidth), -1f);
        edgeWidth = 1f;
      }
      else if (v < splits.Length - 1 && v > 0)
        vector3 = this.GetNormal(splits[v].딟 * this.GetLastSplinePosition());
      else if (v == 0)
      {
        vector3 = Vector3.op_Multiply(this.FindNormal(Vector3.op_Addition(splits[0].딟, Vector3.op_Subtraction(splits[0].딟, splits[1].딟)), splits[0].딟, splits[1].딟, edgeWidth), -1f);
        edgeWidth = 1f;
      }
      else
      {
        vector3 = this.FindNormal(Vector3.op_Addition(splits[splits.Length - 1].딟, Vector3.op_Subtraction(splits[splits.Length - 1].딟, splits[splits.Length - 2].딟)), splits[splits.Length - 1].딟, splits[splits.Length - 2].딟, edgeWidth);
        edgeWidth = 1f;
      }
      if ((double) ((Vector3) ref vector3).magnitude > (double) this.maxBeakLength * (double) this.OutlineWidth)
        vector3 = Vector3.op_Multiply(Vector3.op_Multiply(((Vector3) ref vector3).normalized, this.maxBeakLength), this.OutlineWidth);
    }
    return vector3;
  }

  private RageSpline.땼[] OutlineVertsProcessSplit(
    bool antialiasing,
    Vector3 scaledNormal,
    int vertsInBand,
    float edgeWidth,
    float outlineNormalOffset,
    Vector3 normalizedNormal,
    RageSpline.땼[] outlineVerts,
    int v,
    Vector3 normal,
    RageSpline.땼[] splits,
    float AAWidth)
  {
    Vector3 vector3_1 = 땺.땢.딟(ref normal, ref edgeWidth, 0.5f);
    if (antialiasing)
    {
      Vector3 vector3_2 = v != 0 || this.GetOutline() != RageSpline.떂.딧 ? (v != splits.Length - 1 || this.GetOutline() != RageSpline.떂.딧 ? Vector3.zero : Vector3.Cross(normal, 땺.땢.딟(Vector3.back, -AAWidth))) : Vector3.Cross(normal, 땺.땢.딟(Vector3.back, AAWidth));
      Vector3 vector3_3 = 땺.땢.딟(ref normalizedNormal, ref outlineNormalOffset);
      Vector3 vector3_4 = 땺.땢.딟(ref scaledNormal, ref AAWidth);
      outlineVerts[v + 0 * vertsInBand].딟 = Vector3.op_Addition(땺.땢.딟(ref splits[v].딟, ref vector3_4, ref vector3_1, ref vector3_3, ref vector3_2), RageSpline.딟);
      outlineVerts[v + 1 * vertsInBand].딟 = 땺.땢.딟(ref splits[v].딟, ref vector3_1, ref vector3_3);
      outlineVerts[v + 2 * vertsInBand].딟 = Vector3.op_Addition(Vector3.op_Subtraction(splits[v].딟, vector3_1), vector3_3);
      outlineVerts[v + 3 * vertsInBand].딟 = Vector3.op_Addition(Vector3.op_Addition(Vector3.op_Subtraction(Vector3.op_Subtraction(splits[v].딟, vector3_4), vector3_1), 땺.땢.딟(ref vector3_3, ref vector3_2)), RageSpline.딟);
    }
    else
    {
      Vector3 vector3_5 = 땺.땢.딟(ref normal, ref outlineNormalOffset);
      outlineVerts[v + 0 * vertsInBand].딟 = 땺.땢.딟(ref splits[v].딟, ref vector3_1, ref vector3_5);
      outlineVerts[v + 1 * vertsInBand].딟 = Vector3.op_Addition(Vector3.op_Subtraction(splits[v].딟, vector3_1), vector3_5);
    }
    return outlineVerts;
  }

  private void OutlineVertsSingleMaterial(
    bool antialiasing,
    float uvPos,
    float AAWidthRelatedToEdgeWidth,
    RageSpline.땼[] outlineVerts,
    int v,
    int vertsInBand)
  {
    switch (this.GetTexturing1())
    {
      case RageSpline.땽.딟:
      case RageSpline.땽.땄:
        outlineVerts[v + 0 * vertsInBand].딟 = Vector2.zero;
        outlineVerts[v + 1 * vertsInBand].딟 = Vector2.zero;
        if (antialiasing)
        {
          outlineVerts[v + 2 * vertsInBand].딟 = Vector2.zero;
          outlineVerts[v + 3 * vertsInBand].딟 = Vector2.zero;
          break;
        }
        break;
      case RageSpline.땽.딧:
        if (antialiasing)
        {
          outlineVerts[v + 0 * vertsInBand].딟 = new Vector2(uvPos / this.GetOutlineTexturingScaleInv(), 1f);
          outlineVerts[v + 1 * vertsInBand].딟 = new Vector2(uvPos / this.GetOutlineTexturingScaleInv(), (float) (1.0 - (double) AAWidthRelatedToEdgeWidth * 0.5));
          outlineVerts[v + 2 * vertsInBand].딟 = new Vector2(uvPos / this.GetOutlineTexturingScaleInv(), AAWidthRelatedToEdgeWidth * 0.5f);
          outlineVerts[v + 3 * vertsInBand].딟 = new Vector2(uvPos / this.GetOutlineTexturingScaleInv(), 0.0f);
          break;
        }
        outlineVerts[v + 0 * vertsInBand].딟 = new Vector2(uvPos / this.GetOutlineTexturingScaleInv(), 1f);
        outlineVerts[v + 1 * vertsInBand].딟 = new Vector2(uvPos / this.GetOutlineTexturingScaleInv(), 0.0f);
        break;
    }
    switch (this.GetTexturing2())
    {
      case RageSpline.땽.딟:
      case RageSpline.땽.땄:
        if (antialiasing)
        {
          outlineVerts[v + 0 * vertsInBand].땄 = Vector2.zero;
          outlineVerts[v + 1 * vertsInBand].땄 = Vector2.zero;
          outlineVerts[v + 2 * vertsInBand].땄 = Vector2.zero;
          outlineVerts[v + 3 * vertsInBand].땄 = Vector2.zero;
          break;
        }
        outlineVerts[v + 0 * vertsInBand].땄 = Vector2.zero;
        outlineVerts[v + 1 * vertsInBand].땄 = Vector2.zero;
        break;
      case RageSpline.땽.딧:
        if (antialiasing)
        {
          outlineVerts[v + 0 * vertsInBand].딟 = new Vector2(uvPos / this.GetOutlineTexturingScaleInv(), 1f);
          outlineVerts[v + 1 * vertsInBand].딟 = new Vector2(uvPos / this.GetOutlineTexturingScaleInv(), (float) (1.0 - (double) AAWidthRelatedToEdgeWidth * 0.5));
          outlineVerts[v + 2 * vertsInBand].딟 = new Vector2(uvPos / this.GetOutlineTexturingScaleInv(), AAWidthRelatedToEdgeWidth * 0.5f);
          outlineVerts[v + 3 * vertsInBand].딟 = new Vector2(uvPos / this.GetOutlineTexturingScaleInv(), 0.0f);
          break;
        }
        outlineVerts[v + 0 * vertsInBand].땄 = new Vector2(uvPos / this.GetOutlineTexturingScaleInv(), 0.99f);
        outlineVerts[v + 1 * vertsInBand].땄 = new Vector2(uvPos / this.GetOutlineTexturingScaleInv(), 0.01f);
        break;
    }
  }

  public RageSpline.땼[] GenerateFillVerts(bool antialiasing, bool multipleMaterials)
  {
    RageSpline.땼[] 땼Array = new RageSpline.땼[0];
    switch (this.GetFill())
    {
      case RageSpline.땤.땄:
      case RageSpline.땤.딧:
        RageSpline.땼[] splits1 = this.GetSplits(this.GetVertexCount() - 1, 0.0f, (float) (1.0 - 1.0 / (double) this.GetVertexCount()));
        땼Array = !antialiasing ? new RageSpline.땼[splits1.Length] : new RageSpline.땼[splits1.Length * 2];
        for (int index = 0; index < splits1.Length; ++index)
        {
          Vector3 local = this.ScaleToLocal(this.GetNormal(splits1[index].딟));
          if (antialiasing)
          {
            땼Array[index].딟 = splits1[index].딟;
            땼Array[index + splits1.Length].딟 = Vector3.op_Addition(Vector3.op_Addition(splits1[index].딟, Vector3.op_Multiply(local, this.GetAntialiasingWidth())), RageSpline.땄);
            땼Array[index].딟 = this.GetFillColor(땼Array[index].딟);
            땼Array[index + splits1.Length].딟 = Color.op_Multiply(this.GetFillColor(땼Array[index + splits1.Length].딟), RageSpline.땄);
          }
          else
          {
            땼Array[index].딟 = splits1[index].딟;
            땼Array[index].딟 = this.GetFillColor(땼Array[index].딟);
          }
          if (!multipleMaterials)
          {
            switch (this.GetTexturing1())
            {
              case RageSpline.땽.딟:
              case RageSpline.땽.딧:
                땼Array[index].딟 = new Vector2(0.0f, 0.0f);
                break;
              case RageSpline.땽.땄:
                땼Array[index].딟 = this.GetFillUV(땼Array[index].딟);
                if (antialiasing)
                {
                  땼Array[index + splits1.Length].딟 = this.GetFillUV(땼Array[index + splits1.Length].딟);
                  break;
                }
                break;
            }
            switch (this.GetTexturing2())
            {
              case RageSpline.땽.딟:
              case RageSpline.땽.딧:
                땼Array[index].땄 = new Vector2(0.0f, 0.0f);
                continue;
              case RageSpline.땽.땄:
                땼Array[index].땄 = this.GetFillUV2(땼Array[index].딟);
                if (antialiasing)
                {
                  땼Array[index + splits1.Length].땄 = this.GetFillUV2(땼Array[index + splits1.Length].딟);
                  continue;
                }
                continue;
              default:
                continue;
            }
          }
          else
          {
            땼Array[index].딟 = this.GetFillUV(땼Array[index].딟);
            if (antialiasing)
              땼Array[index + splits1.Length].딟 = this.GetFillUV(땼Array[index + splits1.Length].딟);
          }
        }
        break;
      case RageSpline.땤.딢:
        RageSpline.땼[] splits2 = this.GetSplits(this.GetVertexCount(), 0.0f, 1f);
        Rect bounds = this.GetBounds();
        float num = ((Rect) ref bounds).yMin - Mathf.Clamp(this.GetLandscapeBottomDepth(), 1f, 1E+08f);
        땼Array = !antialiasing ? new RageSpline.땼[splits2.Length * 2] : new RageSpline.땼[splits2.Length * 3];
        for (int index = 0; index < splits2.Length; ++index)
        {
          Vector3 local = this.ScaleToLocal(this.GetNormal(splits2[index].딟));
          if (antialiasing)
          {
            땼Array[index].딟 = new Vector3((float) splits2[index].딟.x, num);
            땼Array[index + splits2.Length].딟 = splits2[index].딟;
            땼Array[index + splits2.Length * 2].딟 = Vector3.op_Addition(Vector3.op_Addition(splits2[index].딟, Vector3.op_Multiply(local, this.GetAntialiasingWidth())), RageSpline.땄);
            땼Array[index].딟 = this.GetFillColor2();
            땼Array[index + splits2.Length].딟 = this.GetFillColor1();
            땼Array[index + splits2.Length * 2].딟 = Color.op_Multiply(this.GetFillColor1(), new Color(1f, 1f, 1f, 0.0f));
          }
          else
          {
            땼Array[index].딟 = new Vector3((float) splits2[index].딟.x, num);
            땼Array[index + splits2.Length].딟 = splits2[index].딟;
            땼Array[index].딟 = this.GetFillColor2();
            땼Array[index + splits2.Length].딟 = this.GetFillColor1();
          }
          if (!multipleMaterials)
          {
            switch (this.GetTexturing1())
            {
              case RageSpline.땽.딟:
              case RageSpline.땽.딧:
                땼Array[index].딟 = new Vector2(0.0f, 0.0f);
                땼Array[index + splits2.Length].딟 = new Vector2(0.0f, 0.0f);
                if (antialiasing)
                {
                  땼Array[index + splits2.Length * 2].딟 = new Vector2(0.0f, 0.0f);
                  break;
                }
                break;
              case RageSpline.땽.땄:
                땼Array[index].딟 = this.GetFillUV(땼Array[index].딟);
                땼Array[index + splits2.Length].딟 = this.GetFillUV(땼Array[index + splits2.Length].딟);
                if (antialiasing)
                {
                  땼Array[index + splits2.Length * 2].딟 = this.GetFillUV(땼Array[index + splits2.Length * 2].딟);
                  break;
                }
                break;
            }
            switch (this.GetTexturing2())
            {
              case RageSpline.땽.딟:
              case RageSpline.땽.딧:
                땼Array[index].땄 = new Vector2(0.0f, 0.0f);
                땼Array[index + splits2.Length].땄 = new Vector2(0.0f, 0.0f);
                if (antialiasing)
                {
                  땼Array[index + splits2.Length * 2].땄 = new Vector2(0.0f, 0.0f);
                  continue;
                }
                continue;
              case RageSpline.땽.땄:
                땼Array[index].땄 = this.GetFillUV(땼Array[index].딟);
                땼Array[index + splits2.Length].땄 = this.GetFillUV(땼Array[index + splits2.Length].딟);
                if (antialiasing)
                {
                  땼Array[index + splits2.Length * 2].땄 = this.GetFillUV(땼Array[index + splits2.Length * 2].딟);
                  continue;
                }
                continue;
              default:
                continue;
            }
          }
          else
          {
            땼Array[index].딟 = this.GetFillUV(땼Array[index].딟);
            땼Array[index + splits2.Length].딟 = this.GetFillUV(땼Array[index + splits2.Length].딟);
            if (antialiasing)
              땼Array[index + splits2.Length * 2].딟 = this.GetFillUV(땼Array[index + splits2.Length * 2].딟);
          }
        }
        break;
    }
    return 땼Array;
  }

  public RageSpline.땼[] GenerateEmbossVerts(bool antialiasing)
  {
    RageSpline.땼[] 땼Array1 = new RageSpline.땼[0];
    RageSpline.땼[] 땼Array2;
    if (this.GetEmboss() != RageSpline.땋.딟)
    {
      RageSpline.땼[] splits = this.GetSplits(this.GetVertexCount(), 0.0f, 1f);
      int length = splits.Length;
      땼Array2 = !antialiasing ? new RageSpline.땼[splits.Length * 2] : new RageSpline.땼[splits.Length * 4];
      Vector3 vector3_1 = Vector2.op_Implicit(this.RotatePoint2D_CCW(new Vector3(0.0f, -1f, 0.0f), this.GetEmbossAngleDeg() / 57.29578f));
      Vector3[] vector3Array1 = new Vector3[splits.Length];
      Vector3[] vector3Array2 = new Vector3[splits.Length];
      float[] numArray1 = new float[splits.Length];
      float[] numArray2 = new float[splits.Length];
      for (int index = 0; index < splits.Length; ++index)
      {
        float num = (float) index / (float) splits.Length;
        vector3Array2[index] = this.spline.딟(num * this.GetLastSplinePosition(), 0.05f, 3);
        if (index == splits.Length - 1)
          vector3Array2[index] = vector3Array2[0];
        numArray1[index] = Vector3.Dot(vector3_1, vector3Array2[index]);
        numArray2[index] = Mathf.Clamp01(Mathf.Abs(numArray1[index]) - this.GetEmbossOffset());
        if ((double) numArray1[index] > 0.0)
        {
          ref Vector3 local = ref vector3Array1[index];
          Vector3 vector3_2 = Vector3.op_Subtraction(vector3_1, Vector3.op_Multiply(vector3Array2[index], 2f));
          Vector3 vector3_3 = Vector3.op_Multiply(Vector3.op_Multiply(((Vector3) ref vector3_2).normalized, this.GetEmbossSize()), numArray2[index]);
          local = vector3_3;
        }
        else
        {
          ref Vector3 local = ref vector3Array1[index];
          Vector3 vector3_4 = Vector3.op_Addition(vector3_1, Vector3.op_Multiply(vector3Array2[index], 2f));
          Vector3 vector3_5 = Vector3.op_Multiply(Vector3.op_Multiply(Vector3.op_Multiply(((Vector3) ref vector3_4).normalized, this.GetEmbossSize()), numArray2[index]), -1f);
          local = vector3_5;
        }
      }
      for (int index1 = 0; index1 < splits.Length; ++index1)
      {
        Vector3 vector3_6 = new Vector3();
        int num = index1;
        if (index1 == splits.Length - 1)
          num = 0;
        for (int index2 = -Mathf.FloorToInt(this.GetEmbossSmoothness()); index2 <= Mathf.FloorToInt(this.GetEmbossSmoothness()) + 1; ++index2)
          vector3_6 = index2 == 0 ? Vector3.op_Addition(vector3_6, vector3Array1[this.mod(num - index2, splits.Length)]) : Vector3.op_Addition(vector3_6, Vector3.op_Multiply(vector3Array1[this.mod(num - index2, splits.Length)], (float) (1.0 - (double) Mathf.Abs(index2) / ((double) this.GetEmbossSmoothness() + 1.0))));
        Vector3 vector3_7 = Vector3.op_Multiply(vector3_6, 1f / (float) (Mathf.FloorToInt(this.GetEmbossSmoothness()) * 2 + 1));
        if (antialiasing)
        {
          땼Array2[index1 + 0 * length].딟 = Vector3.op_Subtraction(splits[index1].딟, Vector3.op_Multiply(Vector3.op_Multiply(((Vector3) ref vector3_7).normalized, this.GetAntialiasingWidth()), 1f));
          땼Array2[index1 + 1 * length].딟 = splits[index1].딟;
          땼Array2[index1 + 2 * length].딟 = Vector3.op_Addition(splits[index1].딟, vector3_7);
          땼Array2[index1 + 3 * length].딟 = Vector3.op_Addition(Vector3.op_Addition(splits[index1].딟, vector3_7), Vector3.op_Multiply(((Vector3) ref vector3_7).normalized, this.GetAntialiasingWidth()));
        }
        else
        {
          땼Array2[index1 + 0 * length].딟 = splits[index1].딟;
          땼Array2[index1 + 1 * length].딟 = Vector3.op_Addition(splits[index1].딟, vector3_7);
        }
        if ((double) ((Vector3) ref vector3_7).sqrMagnitude > 9.99999974737875E-05)
        {
          if ((double) numArray1[index1] < 0.0)
          {
            if (this.GetEmboss() == RageSpline.땋.땄)
            {
              if (antialiasing)
              {
                땼Array2[index1 + 0 * length].딟 = Color.op_Multiply(this.GetEmbossColor1(), new Color(1f, 1f, 1f, 0.0f));
                땼Array2[index1 + 1 * length].딟 = Color.op_Multiply(this.GetEmbossColor1(), new Color(1f, 1f, 1f, Mathf.Clamp01(numArray2[index1] * 4f)));
                땼Array2[index1 + 2 * length].딟 = Color.op_Multiply(this.GetEmbossColor1(), new Color(1f, 1f, 1f, Mathf.Clamp01(numArray2[index1] * 4f)));
                땼Array2[index1 + 3 * length].딟 = Color.op_Multiply(this.GetEmbossColor1(), new Color(1f, 1f, 1f, 0.0f));
              }
              else
              {
                땼Array2[index1 + 0 * length].딟 = Color.op_Multiply(this.GetEmbossColor1(), new Color(1f, 1f, 1f, Mathf.Clamp01(numArray2[index1] * 4f)));
                땼Array2[index1 + 1 * length].딟 = Color.op_Multiply(this.GetEmbossColor1(), new Color(1f, 1f, 1f, Mathf.Clamp01(numArray2[index1] * 4f)));
              }
            }
            else if (antialiasing)
            {
              땼Array2[index1 + 0 * length].딟 = Color.op_Multiply(this.GetEmbossColor1(), new Color(1f, 1f, 1f, 0.0f));
              땼Array2[index1 + 1 * length].딟 = Color.op_Multiply(this.GetEmbossColor1(), new Color(1f, 1f, 1f, Mathf.Clamp01(numArray2[index1] * 4f)));
              땼Array2[index1 + 2 * length].딟 = Color.op_Multiply(this.GetEmbossColor1(), new Color(1f, 1f, 1f, 0.0f));
              땼Array2[index1 + 3 * length].딟 = Color.op_Multiply(this.GetEmbossColor1(), new Color(1f, 1f, 1f, 0.0f));
            }
            else
            {
              땼Array2[index1 + 0 * length].딟 = Color.op_Multiply(this.GetEmbossColor1(), new Color(1f, 1f, 1f, Mathf.Clamp01(numArray2[index1] * 4f)));
              땼Array2[index1 + 1 * length].딟 = Color.op_Multiply(this.GetEmbossColor1(), new Color(1f, 1f, 1f, 0.0f));
            }
          }
          else if (this.GetEmboss() == RageSpline.땋.땄)
          {
            if (antialiasing)
            {
              땼Array2[index1 + 0 * length].딟 = Color.op_Multiply(this.GetEmbossColor2(), new Color(1f, 1f, 1f, 0.0f));
              땼Array2[index1 + 1 * length].딟 = Color.op_Multiply(this.GetEmbossColor2(), new Color(1f, 1f, 1f, Mathf.Clamp01(numArray2[index1] * 4f)));
              땼Array2[index1 + 2 * length].딟 = Color.op_Multiply(this.GetEmbossColor2(), new Color(1f, 1f, 1f, Mathf.Clamp01(numArray2[index1] * 4f)));
              땼Array2[index1 + 3 * length].딟 = Color.op_Multiply(this.GetEmbossColor2(), new Color(1f, 1f, 1f, 0.0f));
            }
            else
            {
              땼Array2[index1 + 0 * length].딟 = Color.op_Multiply(this.GetEmbossColor2(), new Color(1f, 1f, 1f, Mathf.Clamp01(numArray2[index1] * 4f)));
              땼Array2[index1 + 1 * length].딟 = Color.op_Multiply(this.GetEmbossColor2(), new Color(1f, 1f, 1f, Mathf.Clamp01(numArray2[index1] * 4f)));
            }
          }
          else if (antialiasing)
          {
            땼Array2[index1 + 0 * length].딟 = Color.op_Multiply(this.GetEmbossColor2(), new Color(1f, 1f, 1f, 0.0f));
            땼Array2[index1 + 1 * length].딟 = Color.op_Multiply(this.GetEmbossColor2(), new Color(1f, 1f, 1f, Mathf.Clamp01(numArray2[index1] * 4f)));
            땼Array2[index1 + 2 * length].딟 = Color.op_Multiply(this.GetEmbossColor2(), new Color(1f, 1f, 1f, 0.0f));
            땼Array2[index1 + 3 * length].딟 = Color.op_Multiply(this.GetEmbossColor2(), new Color(1f, 1f, 1f, 0.0f));
          }
          else
          {
            땼Array2[index1 + 0 * length].딟 = Color.op_Multiply(this.GetEmbossColor2(), new Color(1f, 1f, 1f, Mathf.Clamp01(numArray2[index1] * 4f)));
            땼Array2[index1 + 1 * length].딟 = Color.op_Multiply(this.GetEmbossColor2(), new Color(1f, 1f, 1f, 0.0f));
          }
        }
        else
        {
          if (antialiasing)
          {
            땼Array2[index1 + 0 * length].딟 = Vector3.op_Subtraction(splits[index1].딟, Vector3.op_Multiply(((Vector3) ref vector3_7).normalized, this.GetAntialiasingWidth()));
            땼Array2[index1 + 1 * length].딟 = splits[index1].딟;
            땼Array2[index1 + 2 * length].딟 = splits[index1].딟;
            땼Array2[index1 + 3 * length].딟 = splits[index1].딟;
          }
          else
          {
            땼Array2[index1 + 0 * length].딟 = splits[index1].딟;
            땼Array2[index1 + 1 * length].딟 = splits[index1].딟;
          }
          if (antialiasing)
          {
            땼Array2[index1 + 0 * length].딟 = Color.op_Multiply(this.GetEmbossColor1(), new Color(1f, 1f, 1f, 0.0f));
            땼Array2[index1 + 1 * length].딟 = Color.op_Multiply(this.GetEmbossColor1(), new Color(1f, 1f, 1f, 0.0f));
            땼Array2[index1 + 2 * length].딟 = Color.op_Multiply(this.GetEmbossColor1(), new Color(1f, 1f, 1f, 0.0f));
            땼Array2[index1 + 3 * length].딟 = Color.op_Multiply(this.GetEmbossColor1(), new Color(1f, 1f, 1f, 0.0f));
          }
          else
          {
            땼Array2[index1 + 0 * length].딟 = Color.op_Multiply(this.GetEmbossColor1(), new Color(1f, 1f, 1f, 0.0f));
            땼Array2[index1 + 1 * length].딟 = Color.op_Multiply(this.GetEmbossColor1(), new Color(1f, 1f, 1f, 0.0f));
          }
        }
        if (antialiasing)
        {
          땼Array2[index1 + 0 * length].딟 = new Vector2(0.0f, 0.0f);
          땼Array2[index1 + 1 * length].딟 = new Vector2(0.0f, 0.0f);
          땼Array2[index1 + 2 * length].딟 = new Vector2(0.0f, 0.0f);
          땼Array2[index1 + 3 * length].딟 = new Vector2(0.0f, 0.0f);
        }
        else
        {
          땼Array2[index1 + 0 * length].딟 = new Vector2(0.0f, 0.0f);
          땼Array2[index1 + 1 * length].딟 = new Vector2(0.0f, 0.0f);
        }
      }
    }
    else
      땼Array2 = new RageSpline.땼[0];
    return 땼Array2;
  }

  public RageSpline.땼[] GetSplits(int vertCount, float start, float end)
  {
    RageSpline.땼[] array = new RageSpline.땼[vertCount + 1];
    float lastSplinePosition = this.GetLastSplinePosition();
    for (int index = 0; index < array.Length; ++index)
    {
      array[index].딟 = Mathf.Clamp01((float) ((double) index / (double) vertCount * ((double) end - (double) start)) + start);
      if (땺.땢.딟(array[index].딟, 1f) && !this.SplineIsOpenEnded())
        array[index].딟 = 0.0f;
      array[index].땄 = this.spline.땥(array[index].딟);
      array[index].딟 = this.spline.땺(array[index].딟 * lastSplinePosition);
      array[index].딟 = this.spline.points[this.spline.딢(array[index].딟)];
      array[index].땄 = this.spline.points[this.spline.땃(array[index].딟)];
      array[index].딟 = new Color(1f, 1f, 1f, 1f);
    }
    if (this.GetOptimize())
      array = this.Optimize(array);
    if (array.Length == vertCount)
      ;
    return array;
  }

  private RageSpline.땼[] Optimize(RageSpline.땼[] array)
  {
    BitArray bitArray = new BitArray(array.Length, false);
    int num = 0;
    int index1 = 0;
    for (int index2 = 1; index2 < array.Length - 1; ++index2)
    {
      Vector3 딟1 = array[index1].딟;
      Vector3 딟2 = array[index2].딟;
      Vector3 딟3 = array[index2 + 1].딟;
      Vector3 vector3_1 = Vector3.op_Subtraction(딟1, 딟2);
      Vector3 vector3_2 = Vector3.op_Subtraction(딟3, 딟2);
      if (180.0 - 57.2957801818848 * (double) Mathf.Acos(Vector3.Dot(vector3_1, vector3_2) / (((Vector3) ref vector3_1).magnitude * ((Vector3) ref vector3_2).magnitude)) < (double) this.GetOptimizeAngle())
      {
        bitArray[index2] = true;
        ++num;
      }
      else
        index1 = index2;
    }
    if (num == 0)
      return array;
    RageSpline.땼[] 땼Array = new RageSpline.땼[array.Length - num];
    int index3 = 0;
    for (int index4 = 0; index4 < 땼Array.Length; ++index4)
    {
      while (bitArray[index3])
        ++index3;
      땼Array[index4] = array[index3];
      ++index3;
    }
    return 땼Array;
  }

  public int GetOutlineTriangleCount(RageSpline.땼[] outlineVerts, bool AAoutline)
  {
    if (this.GetOutline() == RageSpline.떂.딟)
      return 0;
    if (!AAoutline)
      return outlineVerts.Length - 2;
    return this.GetOutline() == RageSpline.떂.딧 ? (outlineVerts.Length / 4 - 1) * 6 + 4 : (outlineVerts.Length / 4 - 1) * 6;
  }

  public int GetFillTriangleCount(RageSpline.땼[] fillVerts, bool AAfill)
  {
    switch (this.GetFill())
    {
      case RageSpline.땤.딟:
        return 0;
      case RageSpline.땤.땄:
      case RageSpline.땤.딧:
        return AAfill ? fillVerts.Length / 2 - 2 + fillVerts.Length : fillVerts.Length - 2;
      case RageSpline.땤.딢:
        return AAfill ? (fillVerts.Length / 3 - 1) * 4 : (fillVerts.Length / 2 - 1) * 2;
      default:
        return 0;
    }
  }

  public int GetEmbossTriangleCount(RageSpline.땼[] embossVerts, bool AAemboss)
  {
    if (this.GetEmboss() == RageSpline.땋.딟)
      return 0;
    return AAemboss ? (embossVerts.Length / 4 - 1) * 6 : embossVerts.Length - 2;
  }

  public void GenerateTriangles(
    Mesh mesh,
    RageSpline.땼[] fillVerts,
    RageSpline.땼[] embossVerts,
    RageSpline.땼[] outlineVerts,
    bool AAfill,
    bool AAemboss,
    bool AAoutline,
    bool multipleMaterials)
  {
    Vector2[] vector2Array = new Vector2[0];
    if (this.GetFill() != RageSpline.땤.딢)
    {
      vector2Array = !AAfill ? new Vector2[fillVerts.Length] : new Vector2[fillVerts.Length / 2];
      for (int index = 0; index < vector2Array.Length; ++index)
        vector2Array[index] = new Vector2((float) fillVerts[index].딟.x, (float) fillVerts[index].딟.y);
    }
    int[] numArray1 = new int[this.GetOutlineTriangleCount(outlineVerts, AAoutline) * 3 + this.GetFillTriangleCount(fillVerts, AAfill) * 3 + this.GetEmbossTriangleCount(embossVerts, AAemboss) * 3];
    int num1 = 0;
    switch (this.GetFill())
    {
      case RageSpline.땤.땄:
      case RageSpline.땤.딧:
        foreach (int num2 in this.get_Triangulator().딟(vector2Array))
          numArray1[num1++] = num2;
        break;
      case RageSpline.땤.딢:
        int num3;
        int num4;
        if (AAfill)
        {
          num3 = 2;
          num4 = fillVerts.Length / 3;
        }
        else
        {
          num3 = 1;
          num4 = fillVerts.Length / 2;
        }
        for (int index1 = 0; index1 < num4 - 1; ++index1)
        {
          for (int index2 = 0; index2 < num3; ++index2)
          {
            int[] numArray2 = numArray1;
            int index3 = num1;
            int num5 = index3 + 1;
            int num6 = index1 + index2 * num4;
            numArray2[index3] = num6;
            int[] numArray3 = numArray1;
            int index4 = num5;
            int num7 = index4 + 1;
            int num8 = index1 + (index2 + 1) * num4;
            numArray3[index4] = num8;
            int[] numArray4 = numArray1;
            int index5 = num7;
            int num9 = index5 + 1;
            int num10 = index1 + (index2 + 1) * num4 + 1;
            numArray4[index5] = num10;
            int[] numArray5 = numArray1;
            int index6 = num9;
            int num11 = index6 + 1;
            int num12 = index1 + index2 * num4;
            numArray5[index6] = num12;
            int[] numArray6 = numArray1;
            int index7 = num11;
            int num13 = index7 + 1;
            int num14 = index1 + (index2 + 1) * num4 + 1;
            numArray6[index7] = num14;
            int[] numArray7 = numArray1;
            int index8 = num13;
            num1 = index8 + 1;
            int num15 = index1 + index2 * num4 + 1;
            numArray7[index8] = num15;
          }
        }
        break;
    }
    int length1 = 0;
    if (AAfill)
      length1 += vector2Array.Length * 6;
    if (AAoutline && outlineVerts.Length != 0)
      length1 += 2 * (outlineVerts.Length / 4 - 1) * 6;
    if (this.GetOutline() == RageSpline.떂.딧 && AAoutline)
      length1 += 12;
    int[] numArray8 = new int[0];
    int num16 = 0;
    int[] numArray9 = length1 <= 0 ? new int[0] : new int[length1];
    if (AAfill)
    {
      int num17 = vector2Array.Length - 1;
      if (this._perspectiveMode)
      {
        for (int index9 = 0; index9 <= num17; ++index9)
        {
          for (int index10 = 0; index10 < 1; ++index10)
          {
            int[] numArray10 = numArray9;
            int index11 = num16;
            int num18 = index11 + 1;
            int num19 = index9 + index10 * num17;
            numArray10[index11] = num19;
            int[] numArray11 = numArray9;
            int index12 = num18;
            int num20 = index12 + 1;
            int num21 = index9 + (index10 + 1) * num17;
            numArray11[index12] = num21;
            int[] numArray12 = numArray9;
            int index13 = num20;
            int num22 = index13 + 1;
            int num23 = index9 + (index10 + 1) * num17 + 1;
            numArray12[index13] = num23;
            int[] numArray13 = numArray9;
            int index14 = num22;
            int num24 = index14 + 1;
            int num25 = index9 + index10 * num17;
            numArray13[index14] = num25;
            int[] numArray14 = numArray9;
            int index15 = num24;
            int num26 = index15 + 1;
            int num27 = index9 + (index10 + 1) * num17 + 1;
            numArray14[index15] = num27;
            int[] numArray15 = numArray9;
            int index16 = num26;
            num16 = index16 + 1;
            int num28 = index9 + index10 * num17 + 1;
            numArray15[index16] = num28;
          }
        }
      }
      else
      {
        for (int index17 = 0; index17 <= num17; ++index17)
        {
          for (int index18 = 0; index18 < 1; ++index18)
          {
            int[] numArray16 = numArray1;
            int index19 = num1;
            int num29 = index19 + 1;
            int num30 = index17 + index18 * num17;
            numArray16[index19] = num30;
            int[] numArray17 = numArray1;
            int index20 = num29;
            int num31 = index20 + 1;
            int num32 = index17 + (index18 + 1) * num17;
            numArray17[index20] = num32;
            int[] numArray18 = numArray1;
            int index21 = num31;
            int num33 = index21 + 1;
            int num34 = index17 + (index18 + 1) * num17 + 1;
            numArray18[index21] = num34;
            int[] numArray19 = numArray1;
            int index22 = num33;
            int num35 = index22 + 1;
            int num36 = index17 + index18 * num17;
            numArray19[index22] = num36;
            int[] numArray20 = numArray1;
            int index23 = num35;
            int num37 = index23 + 1;
            int num38 = index17 + (index18 + 1) * num17 + 1;
            numArray20[index23] = num38;
            int[] numArray21 = numArray1;
            int index24 = num37;
            num1 = index24 + 1;
            int num39 = index17 + index18 * num17 + 1;
            numArray21[index24] = num39;
          }
        }
      }
    }
    int num40;
    int num41;
    if (AAemboss)
    {
      num40 = embossVerts.Length / 4;
      num41 = 3;
    }
    else
    {
      num40 = embossVerts.Length / 2;
      num41 = 1;
    }
    for (int index25 = 0; index25 < num40 - 1; ++index25)
    {
      for (int index26 = 0; index26 < num41; ++index26)
      {
        if (index25 < num40 - 1)
        {
          int[] numArray22 = numArray1;
          int index27 = num1;
          int num42 = index27 + 1;
          int num43 = index25 + index26 * num40 + fillVerts.Length;
          numArray22[index27] = num43;
          int[] numArray23 = numArray1;
          int index28 = num42;
          int num44 = index28 + 1;
          int num45 = index25 + (index26 + 1) * num40 + 1 + fillVerts.Length;
          numArray23[index28] = num45;
          int[] numArray24 = numArray1;
          int index29 = num44;
          int num46 = index29 + 1;
          int num47 = index25 + (index26 + 1) * num40 + fillVerts.Length;
          numArray24[index29] = num47;
          int[] numArray25 = numArray1;
          int index30 = num46;
          int num48 = index30 + 1;
          int num49 = index25 + index26 * num40 + fillVerts.Length;
          numArray25[index30] = num49;
          int[] numArray26 = numArray1;
          int index31 = num48;
          int num50 = index31 + 1;
          int num51 = index25 + index26 * num40 + 1 + fillVerts.Length;
          numArray26[index31] = num51;
          int[] numArray27 = numArray1;
          int index32 = num50;
          num1 = index32 + 1;
          int num52 = index25 + (index26 + 1) * num40 + 1 + fillVerts.Length;
          numArray27[index32] = num52;
        }
      }
    }
    int num53;
    int num54;
    if (AAoutline)
    {
      num53 = outlineVerts.Length / 4;
      num54 = 3;
    }
    else
    {
      num53 = outlineVerts.Length / 2;
      num54 = 1;
    }
    for (int index33 = 0; index33 < num53 - 1; ++index33)
    {
      for (int index34 = 0; index34 < num54; ++index34)
      {
        if (index34 == 1 || !this.get_PerspectiveMode() || !AAoutline)
        {
          int[] numArray28 = numArray1;
          int index35 = num1;
          int num55 = index35 + 1;
          int num56 = index33 + index34 * num53 + embossVerts.Length + fillVerts.Length;
          numArray28[index35] = num56;
          int[] numArray29 = numArray1;
          int index36 = num55;
          int num57 = index36 + 1;
          int num58 = index33 + (index34 + 1) * num53 + 1 + embossVerts.Length + fillVerts.Length;
          numArray29[index36] = num58;
          int[] numArray30 = numArray1;
          int index37 = num57;
          int num59 = index37 + 1;
          int num60 = index33 + (index34 + 1) * num53 + embossVerts.Length + fillVerts.Length;
          numArray30[index37] = num60;
          int[] numArray31 = numArray1;
          int index38 = num59;
          int num61 = index38 + 1;
          int num62 = index33 + index34 * num53 + embossVerts.Length + fillVerts.Length;
          numArray31[index38] = num62;
          int[] numArray32 = numArray1;
          int index39 = num61;
          int num63 = index39 + 1;
          int num64 = index33 + index34 * num53 + 1 + embossVerts.Length + fillVerts.Length;
          numArray32[index39] = num64;
          int[] numArray33 = numArray1;
          int index40 = num63;
          num1 = index40 + 1;
          int num65 = index33 + (index34 + 1) * num53 + 1 + embossVerts.Length + fillVerts.Length;
          numArray33[index40] = num65;
        }
        else
        {
          if (numArray9.Length != 0)
          {
            int[] numArray34 = numArray1;
            int index41 = num1;
            int num66 = index41 + 1;
            numArray34[index41] = 0;
            int[] numArray35 = numArray1;
            int index42 = num66;
            int num67 = index42 + 1;
            numArray35[index42] = 0;
            int[] numArray36 = numArray1;
            int index43 = num67;
            int num68 = index43 + 1;
            numArray36[index43] = 0;
            int[] numArray37 = numArray1;
            int index44 = num68;
            int num69 = index44 + 1;
            numArray37[index44] = 0;
            int[] numArray38 = numArray1;
            int index45 = num69;
            int num70 = index45 + 1;
            numArray38[index45] = 0;
            int[] numArray39 = numArray1;
            int index46 = num70;
            num1 = index46 + 1;
            numArray39[index46] = 0;
          }
          if (num53 > 0 && numArray9.Length != 0)
          {
            int[] numArray40 = numArray9;
            int index47 = num16;
            int num71 = index47 + 1;
            int num72 = index33 + index34 * num53 + embossVerts.Length + fillVerts.Length;
            numArray40[index47] = num72;
            int[] numArray41 = numArray9;
            int index48 = num71;
            int num73 = index48 + 1;
            int num74 = index33 + (index34 + 1) * num53 + 1 + embossVerts.Length + fillVerts.Length;
            numArray41[index48] = num74;
            int[] numArray42 = numArray9;
            int index49 = num73;
            int num75 = index49 + 1;
            int num76 = index33 + (index34 + 1) * num53 + embossVerts.Length + fillVerts.Length;
            numArray42[index49] = num76;
            int[] numArray43 = numArray9;
            int index50 = num75;
            int num77 = index50 + 1;
            int num78 = index33 + index34 * num53 + embossVerts.Length + fillVerts.Length;
            numArray43[index50] = num78;
            int[] numArray44 = numArray9;
            int index51 = num77;
            int num79 = index51 + 1;
            int num80 = index33 + index34 * num53 + 1 + embossVerts.Length + fillVerts.Length;
            numArray44[index51] = num80;
            int[] numArray45 = numArray9;
            int index52 = num79;
            num16 = index52 + 1;
            int num81 = index33 + (index34 + 1) * num53 + 1 + embossVerts.Length + fillVerts.Length;
            numArray45[index52] = num81;
          }
        }
      }
    }
    if (this.GetOutline() == RageSpline.떂.딧 && AAoutline)
    {
      int num82 = outlineVerts.Length / 4;
      int[] numArray46 = numArray1;
      int index53 = num1;
      int num83 = index53 + 1;
      int num84 = 0 + embossVerts.Length + fillVerts.Length;
      numArray46[index53] = num84;
      int[] numArray47 = numArray1;
      int index54 = num83;
      int num85 = index54 + 1;
      int num86 = num82 * 2 + embossVerts.Length + fillVerts.Length;
      numArray47[index54] = num86;
      int[] numArray48 = numArray1;
      int index55 = num85;
      int num87 = index55 + 1;
      int num88 = num82 + embossVerts.Length + fillVerts.Length;
      numArray48[index55] = num88;
      int[] numArray49 = numArray1;
      int index56 = num87;
      int num89 = index56 + 1;
      int num90 = 0 + embossVerts.Length + fillVerts.Length;
      numArray49[index56] = num90;
      int[] numArray50 = numArray1;
      int index57 = num89;
      int num91 = index57 + 1;
      int num92 = num82 * 3 + embossVerts.Length + fillVerts.Length;
      numArray50[index57] = num92;
      int[] numArray51 = numArray1;
      int index58 = num91;
      int num93 = index58 + 1;
      int num94 = num82 * 2 + embossVerts.Length + fillVerts.Length;
      numArray51[index58] = num94;
      int[] numArray52 = numArray1;
      int index59 = num93;
      int num95 = index59 + 1;
      int num96 = num82 * 1 - 1 + embossVerts.Length + fillVerts.Length;
      numArray52[index59] = num96;
      int[] numArray53 = numArray1;
      int index60 = num95;
      int num97 = index60 + 1;
      int num98 = num82 * 3 - 1 + embossVerts.Length + fillVerts.Length;
      numArray53[index60] = num98;
      int[] numArray54 = numArray1;
      int index61 = num97;
      int num99 = index61 + 1;
      int num100 = num82 * 2 - 1 + embossVerts.Length + fillVerts.Length;
      numArray54[index61] = num100;
      int[] numArray55 = numArray1;
      int index62 = num99;
      int num101 = index62 + 1;
      int num102 = num82 * 1 - 1 + embossVerts.Length + fillVerts.Length;
      numArray55[index62] = num102;
      int[] numArray56 = numArray1;
      int index63 = num101;
      int num103 = index63 + 1;
      int num104 = num82 * 4 - 1 + embossVerts.Length + fillVerts.Length;
      numArray56[index63] = num104;
      int[] numArray57 = numArray1;
      int index64 = num103;
      int num105 = index64 + 1;
      int num106 = num82 * 3 - 1 + embossVerts.Length + fillVerts.Length;
      numArray57[index64] = num106;
    }
    if (!this._perspectiveMode && multipleMaterials)
    {
      int index = 0;
      int[] numArray58 = new int[this.GetOutlineTriangleCount(outlineVerts, AAoutline) * 3];
      int[] numArray59 = new int[numArray1.Length - this.GetOutlineTriangleCount(outlineVerts, AAoutline) * 3];
      mesh.subMeshCount = 2;
      for (; index < numArray59.Length; ++index)
        numArray59[index] = numArray1[index];
      if (this.GetTexturing1() == RageSpline.땽.땄)
        mesh.SetTriangles(numArray59, 0);
      if (this.GetTexturing2() == RageSpline.땽.땄)
        mesh.SetTriangles(numArray59, 1);
      for (; index < numArray1.Length; ++index)
        numArray58[index - numArray59.Length] = numArray1[index];
      if (this.GetTexturing1() == RageSpline.땽.딧)
        mesh.SetTriangles(numArray58, 0);
      if (this.GetTexturing2() != RageSpline.땽.딧)
        return;
      mesh.SetTriangles(numArray58, 1);
    }
    else
    {
      if (this.inverseTriangleDrawOrder)
      {
        int length2 = numArray1.Length;
        int[] numArray60 = new int[numArray1.Length];
        for (int index = 0; index < length2; index += 3)
        {
          numArray60[length2 - index - 3] = numArray1[index];
          numArray60[length2 - index - 3 + 1] = numArray1[index + 1];
          numArray60[length2 - index - 3 + 2] = numArray1[index + 2];
        }
        numArray1 = numArray60;
      }
      mesh.triangles = numArray1;
      mesh.subMeshCount = 2;
      mesh.SetTriangles(numArray1, 0);
      mesh.SetTriangles(numArray9, 1);
    }
  }

  public Color GetFillColor(Vector3 position)
  {
    switch (this.GetFill())
    {
      case RageSpline.땤.땄:
        return this.GetFillColor1();
      case RageSpline.땤.딧:
        Vector3 vector3 = Vector2.op_Implicit(this.GetGradientOffset());
        float num = (float) (Vector2.op_Multiply(Vector2.op_Multiply(this.RotatePoint2D_CCW(Vector3.op_Subtraction(position, vector3), (float) (-(double) this.GetGradientAngleDeg() / 57.2957763671875)), this.GetGradientScaleInv()), 0.5f).y + 0.5);
        return Color.op_Addition(Color.op_Multiply(Mathf.Clamp(num, 0.0f, 1f), this.GetFillColor1()), Color.op_Multiply(1f - Mathf.Clamp(num, 0.0f, 1f), this.GetFillColor2()));
      default:
        return this.GetFillColor1();
    }
  }

  public Vector2 GetFillUV(Vector3 position)
  {
    Vector3 vector3 = Vector2.op_Implicit(this.GetTextureOffset());
    return Vector2.op_Addition(Vector2.op_Multiply(this.RotatePoint2D_CCW(Vector3.op_Subtraction(position, vector3), (float) (-(double) this.GetTextureAngleDeg() / 57.2957763671875)), this.GetTextureScaleInv()), new Vector2(0.5f, 0.5f));
  }

  public Vector2 GetFillUV2(Vector3 position)
  {
    Vector3 vector3 = Vector2.op_Implicit(this.GetTextureOffset2());
    return Vector2.op_Addition(Vector2.op_Multiply(this.RotatePoint2D_CCW(Vector3.op_Subtraction(position, vector3), (float) (-(double) this.GetTextureAngle2Deg() / 57.2957763671875)), this.GetTextureScale2Inv()), new Vector2(0.5f, 0.5f));
  }

  public Vector2 RotatePoint2D_CCW(Vector3 p, float angle) => new Vector2((float) (p.x * (double) Mathf.Cos(-angle) - p.y * (double) Mathf.Sin(-angle)), (float) (p.y * (double) Mathf.Cos(-angle) + p.x * (double) Mathf.Sin(-angle)));

  public float Vector2Angle_CCW(Vector2 normal)
  {
    Vector3 vector3;
    // ISSUE: explicit constructor call
    ((Vector3) ref vector3).\u002Ector(0.0f, 1f, 0.0f);
    return normal.x < 0.0 ? (float) ((double) Mathf.Acos((float) (vector3.x * normal.x + vector3.y * normal.y)) * 57.2957801818848 * -1.0 + 360.0) : (float) (((double) Mathf.Acos((float) (vector3.x * normal.x + vector3.y * normal.y)) * 57.2957801818848 * -1.0 + 360.0) * -1.0 + 360.0);
  }

  public int mod(int x, int m) => (x % m + m) % m;

  private float mod(float x, float m) => (x % m + m) % m;

  public float SnapToGrid(float val, float gridsize) => (double) this.mod(val, gridsize) < (double) gridsize * 0.5 ? val - this.mod(val, gridsize) : val + (gridsize - this.mod(val, gridsize));

  public Vector3 SnapToGrid(Vector3 val, float gridsize) => new Vector3(this.SnapToGrid((float) val.x, gridsize), this.SnapToGrid((float) val.y, gridsize));

  public void RefreshPhysics()
  {
    if (this.딟 == null && this.GetPhysics() == RageSpline.땲.땄)
      this.딟 = new BoxCollider[1];
    if (!Application.isPlaying && !this.GetCreatePhysicsInEditor())
      this.DestroyPhysicsChildren();
    if (!Application.isPlaying && !this.GetCreatePhysicsInEditor())
      return;
    switch (this.GetPhysics())
    {
      case RageSpline.땲.딟:
        this.DestroyPhysicsChildren();
        break;
      case RageSpline.땲.땄:
        this.DestroyMeshCollider();
        this.DestroyFarseerPhysics();
        if (this.lastPhysicsVertsCount != this.GetSplits(this.GetPhysicsColliderCount(), 0.0f, 1f).Length || Object.op_Equality((Object) this.딟[0], (Object) null))
        {
          if (!Application.isPlaying)
            this.DestroyPhysicsChildren();
          this.lastPhysicsVertsCount = this.GetSplits(this.GetPhysicsColliderCount(), 0.0f, 1f).Length;
          RageSpline.땼[] splits = this.GetSplits(this.GetPhysicsColliderCount(), 0.0f, 1f);
          this.딟 = new BoxCollider[splits.Length - 1];
          int num1 = splits.Length - 1;
          for (int index1 = 0; index1 < num1; ++index1)
          {
            GameObject gameObject = new GameObject();
            ((Object) gameObject).name = "ZZZ_" + ((Object) ((Component) this).gameObject).name + "_BoxCollider";
            gameObject.transform.parent = ((Component) this).transform;
            BoxCollider boxCollider = gameObject.AddComponent(typeof (BoxCollider)) as BoxCollider;
            ((Collider) boxCollider).material = this.GetPhysicsMaterial();
            int index2 = index1 + 1;
            Vector3 normal1 = this.GetNormal(splits[index1].딟);
            Vector3 normal2 = this.GetNormal(splits[index2].딟);
            Vector3 vector3_1 = Vector3.op_Subtraction(splits[index1].딟, Vector3.op_Multiply(normal1, this.GetBoxColliderDepth() * 0.5f - this.GetPhysicsNormalOffset()));
            Vector3 vector3_2 = Vector3.op_Subtraction(splits[index2].딟, Vector3.op_Multiply(normal2, this.GetBoxColliderDepth() * 0.5f - this.GetPhysicsNormalOffset()));
            gameObject.layer = ((Component) ((Component) this).transform).gameObject.layer;
            gameObject.tag = ((Component) ((Component) this).transform).gameObject.tag;
            gameObject.gameObject.transform.localPosition = Vector3.op_Multiply(Vector3.op_Addition(vector3_1, vector3_2), 0.5f);
            Transform transform1 = gameObject.gameObject.transform;
            Transform transform2 = ((Component) this).transform;
            Vector3 localPosition = gameObject.gameObject.transform.localPosition;
            Vector3 vector3_3 = Vector3.op_Subtraction(vector3_1, vector3_2);
            Vector3 vector3_4 = Vector3.Cross(((Vector3) ref vector3_3).normalized, new Vector3(0.0f, 0.0f, -1f));
            Vector3 vector3_5 = Vector3.op_Addition(localPosition, vector3_4);
            Vector3 vector3_6 = transform2.TransformPoint(vector3_5);
            Vector3 vector3_7 = new Vector3(1f, 0.0f, 0.0f);
            transform1.LookAt(vector3_6, vector3_7);
            Transform transform3 = gameObject.gameObject.transform;
            double physicsZdepth = (double) this.GetPhysicsZDepth();
            Vector3 vector3_8 = Vector3.op_Subtraction(Vector3.op_Addition(vector3_1, Vector3.op_Multiply(Vector3.op_Multiply(normal1, this.GetBoxColliderDepth()), 0.5f)), Vector3.op_Addition(vector3_2, Vector3.op_Multiply(Vector3.op_Multiply(normal2, this.GetBoxColliderDepth()), 0.5f)));
            double magnitude = (double) ((Vector3) ref vector3_8).magnitude;
            double num2 = 1.0 * (double) this.GetBoxColliderDepth();
            Vector3 vector3_9 = new Vector3((float) physicsZdepth, (float) magnitude, (float) num2);
            transform3.localScale = vector3_9;
            this.딟[index1] = boxCollider;
          }
          break;
        }
        int index3 = 0;
        RageSpline.땼[] splits1 = this.GetSplits(this.GetPhysicsColliderCount(), 0.0f, 1f);
        foreach (BoxCollider boxCollider in this.딟)
        {
          ((Collider) boxCollider).material = this.GetPhysicsMaterial();
          int index4 = index3 + 1;
          Vector3 normal3 = this.GetNormal(splits1[index3].딟);
          Vector3 normal4 = this.GetNormal(splits1[index4].딟);
          Vector3 vector3_10 = Vector3.op_Subtraction(splits1[index3].딟, Vector3.op_Multiply(normal3, this.GetBoxColliderDepth() * 0.5f - this.GetPhysicsNormalOffset()));
          Vector3 vector3_11 = Vector3.op_Subtraction(splits1[index4].딟, Vector3.op_Multiply(normal4, this.GetBoxColliderDepth() * 0.5f - this.GetPhysicsNormalOffset()));
          ((Component) boxCollider).gameObject.transform.localPosition = Vector3.op_Multiply(Vector3.op_Addition(vector3_10, vector3_11), 0.5f);
          Transform transform4 = ((Component) boxCollider).gameObject.transform;
          Transform transform5 = ((Component) this).transform;
          Vector3 localPosition = ((Component) boxCollider).gameObject.transform.localPosition;
          Vector3 vector3_12 = Vector3.op_Subtraction(vector3_10, vector3_11);
          Vector3 vector3_13 = Vector3.Cross(((Vector3) ref vector3_12).normalized, new Vector3(0.0f, 0.0f, -1f));
          Vector3 vector3_14 = Vector3.op_Addition(localPosition, vector3_13);
          Vector3 vector3_15 = transform5.TransformPoint(vector3_14);
          Vector3 vector3_16 = new Vector3(1f, 0.0f, 0.0f);
          transform4.LookAt(vector3_15, vector3_16);
          Transform transform6 = ((Component) boxCollider).gameObject.transform;
          double physicsZdepth = (double) this.GetPhysicsZDepth();
          Vector3 vector3_17 = Vector3.op_Subtraction(Vector3.op_Addition(vector3_10, Vector3.op_Multiply(Vector3.op_Multiply(normal3, this.GetBoxColliderDepth()), 0.5f)), Vector3.op_Addition(vector3_11, Vector3.op_Multiply(Vector3.op_Multiply(normal4, this.GetBoxColliderDepth()), 0.5f)));
          double magnitude = (double) ((Vector3) ref vector3_17).magnitude;
          double num = 1.0 * (double) this.GetBoxColliderDepth();
          Vector3 vector3_18 = new Vector3((float) physicsZdepth, (float) magnitude, (float) num);
          transform6.localScale = vector3_18;
          ++index3;
        }
        this.lastPhysicsVertsCount = this.GetPhysicsColliderCount();
        break;
      case RageSpline.땲.딧:
        this.DestroyBoxColliders();
        this.DestroyFarseerPhysics();
        if (this.GetPhysicsColliderCount() <= 2 || !this.GetCreatePhysicsInEditor() && !Application.isPlaying)
          break;
        int index5 = 0;
        Vector3[] vector3Array1;
        int[] numArray1;
        if (this.GetFill() != RageSpline.땤.딢)
        {
          RageSpline.땼[] splits2 = this.GetSplits(this.GetPhysicsColliderCount(), 0.0f, 1f);
          vector3Array1 = new Vector3[splits2.Length * 2];
          numArray1 = new int[vector3Array1.Length * 3 + (vector3Array1.Length - 2) * 6];
          for (int index6 = 0; index6 < vector3Array1.Length; index6 += 2)
          {
            vector3Array1[index6] = Vector3.op_Addition(Vector3.op_Addition(splits2[index6 / 2].딟, new Vector3(0.0f, 0.0f, this.GetPhysicsZDepth() * 0.5f)), Vector3.op_Multiply(this.GetNormal(splits2[index6 / 2].딟), this.GetPhysicsNormalOffset()));
            vector3Array1[index6 + 1] = Vector3.op_Addition(Vector3.op_Addition(splits2[index6 / 2].딟, new Vector3(0.0f, 0.0f, this.GetPhysicsZDepth() * -0.5f)), Vector3.op_Multiply(this.GetNormal(splits2[index6 / 2].딟), this.GetPhysicsNormalOffset()));
            if (index6 < vector3Array1.Length - 2)
            {
              numArray1[index5] = index6;
              numArray1[index5 + 1] = index6 + 2;
              numArray1[index5 + 2] = index6 + 1;
              numArray1[index5 + 3] = index6 + 1;
              numArray1[index5 + 4] = index6 + 2;
              numArray1[index5 + 5] = index6 + 3;
            }
            else
            {
              numArray1[index5] = index6;
              numArray1[index5 + 1] = 0;
              numArray1[index5 + 2] = index6 + 1;
              numArray1[index5 + 3] = index6 + 1;
              numArray1[index5 + 4] = 0;
              numArray1[index5 + 5] = 1;
            }
            index5 += 6;
          }
        }
        else
        {
          RageSpline.땼[] splits3 = this.GetSplits(this.GetPhysicsColliderCount(), 0.0f, 1f);
          vector3Array1 = new Vector3[splits3.Length * 2 + 4];
          numArray1 = new int[vector3Array1.Length * 3 + (vector3Array1.Length - 2) * 6];
          Rect bounds = this.GetBounds();
          float num = ((Rect) ref bounds).yMin - Mathf.Clamp(this.GetLandscapeBottomDepth(), 1f, 1E+08f);
          vector3Array1[0] = new Vector3((float) splits3[0].딟.x, num, this.GetPhysicsZDepth() * 0.5f);
          vector3Array1[1] = new Vector3((float) splits3[0].딟.x, num, this.GetPhysicsZDepth() * -0.5f);
          for (int index7 = 2; index7 < vector3Array1.Length - 2; index7 += 2)
          {
            vector3Array1[index7] = Vector3.op_Addition(Vector3.op_Addition(splits3[(index7 - 2) / 2].딟, new Vector3(0.0f, 0.0f, this.GetPhysicsZDepth() * 0.5f)), Vector3.op_Multiply(this.GetNormal(splits3[(index7 - 2) / 2].딟), this.GetPhysicsNormalOffset()));
            vector3Array1[index7 + 1] = Vector3.op_Addition(Vector3.op_Addition(splits3[(index7 - 2) / 2].딟, new Vector3(0.0f, 0.0f, this.GetPhysicsZDepth() * -0.5f)), Vector3.op_Multiply(this.GetNormal(splits3[(index7 - 2) / 2].딟), this.GetPhysicsNormalOffset()));
          }
          for (int index8 = 0; index8 < vector3Array1.Length; index8 += 2)
          {
            if (index8 < vector3Array1.Length - 2)
            {
              numArray1[index5] = index8;
              numArray1[index5 + 1] = index8 + 2;
              numArray1[index5 + 2] = index8 + 1;
              numArray1[index5 + 3] = index8 + 1;
              numArray1[index5 + 4] = index8 + 2;
              numArray1[index5 + 5] = index8 + 3;
            }
            else
            {
              numArray1[index5] = index8;
              numArray1[index5 + 1] = 0;
              numArray1[index5 + 2] = index8 + 1;
              numArray1[index5 + 3] = index8 + 1;
              numArray1[index5 + 4] = 0;
              numArray1[index5 + 5] = 1;
            }
            index5 += 6;
          }
          vector3Array1[vector3Array1.Length - 2] = new Vector3((float) splits3[splits3.Length - 1].딟.x, num, this.GetPhysicsZDepth() * 0.5f);
          vector3Array1[vector3Array1.Length - 1] = new Vector3((float) splits3[splits3.Length - 1].딟.x, num, this.GetPhysicsZDepth() * -0.5f);
        }
        Vector2[] vector2Array1 = new Vector2[vector3Array1.Length / 2];
        for (int index9 = 0; index9 < vector2Array1.Length; ++index9)
          vector2Array1[index9] = new Vector2((float) vector3Array1[index9 * 2].x, (float) vector3Array1[index9 * 2].y);
        Vector2[] vector2Array2 = new Vector2[vector3Array1.Length / 2];
        for (int index10 = 0; index10 < vector2Array2.Length; ++index10)
          vector2Array2[index10] = new Vector2((float) vector3Array1[index10 * 2 + 1].x, (float) vector3Array1[index10 * 2 + 1].y);
        foreach (int num in this.get_Triangulator().딟(vector2Array1))
          numArray1[index5++] = num * 2;
        int[] numArray2 = this.get_Triangulator().딟(vector2Array2);
        for (int index11 = numArray2.Length - 1; index11 >= 0; --index11)
          numArray1[index5++] = numArray2[index11] * 2 + 1;
        MeshCollider meshCollider1 = ((Component) this).gameObject.GetComponent(typeof (MeshCollider)) as MeshCollider;
        bool flag1 = Object.op_Equality((Object) meshCollider1, (Object) null);
        Mesh mesh1 = !flag1 ? (!Object.op_Equality((Object) meshCollider1.sharedMesh, (Object) null) ? meshCollider1.sharedMesh : new Mesh()) : new Mesh();
        mesh1.Clear();
        mesh1.vertices = vector3Array1;
        mesh1.triangles = numArray1;
        mesh1.RecalculateBounds();
        mesh1.RecalculateNormals();
        mesh1.Optimize();
        if (flag1)
          meshCollider1 = ((Component) this).gameObject.AddComponent(typeof (MeshCollider)) as MeshCollider;
        meshCollider1.sharedMesh = (Mesh) null;
        meshCollider1.sharedMesh = mesh1;
        ((Collider) meshCollider1).sharedMaterial = this.physicsMaterial;
        meshCollider1.convex = this.GetCreateConvexMeshCollider();
        break;
      case RageSpline.땲.딢:
        this.DestroyBoxColliders();
        this.DestroyFarseerPhysics();
        if (this.GetPhysicsColliderCount() <= 2 || !this.GetCreatePhysicsInEditor() && !Application.isPlaying)
          break;
        int physicsColliderCount = this.GetPhysicsColliderCount();
        Vector3[] vector3Array2 = new Vector3[(physicsColliderCount + 1) * 4];
        int[] numArray3 = new int[physicsColliderCount * 24];
        int num3 = 0;
        for (int index12 = 0; index12 <= physicsColliderCount; ++index12)
        {
          float splinePosition = (float) index12 / (float) physicsColliderCount;
          Vector3 normal = this.GetNormal(splinePosition);
          Vector3[] vector3Array3 = vector3Array2;
          int index13 = num3;
          int num4 = index13 + 1;
          vector3Array3[index13] = Vector3.op_Addition(Vector3.op_Addition(Vector3.op_Addition(this.GetPosition(splinePosition), Vector3.op_Multiply(Vector3.op_Multiply(normal, this.GetOutlineWidth()), 0.5f)), Vector3.op_Multiply(normal, this.GetOutlineNormalOffset())), new Vector3(0.0f, 0.0f, this.GetPhysicsZDepth() * 0.5f));
          Vector3[] vector3Array4 = vector3Array2;
          int index14 = num4;
          int num5 = index14 + 1;
          vector3Array4[index14] = Vector3.op_Addition(Vector3.op_Addition(Vector3.op_Addition(this.GetPosition(splinePosition), Vector3.op_Multiply(Vector3.op_Multiply(normal, this.GetOutlineWidth()), -0.5f)), Vector3.op_Multiply(normal, this.GetOutlineNormalOffset())), new Vector3(0.0f, 0.0f, this.GetPhysicsZDepth() * 0.5f));
          Vector3[] vector3Array5 = vector3Array2;
          int index15 = num5;
          int num6 = index15 + 1;
          vector3Array5[index15] = Vector3.op_Subtraction(Vector3.op_Addition(Vector3.op_Addition(this.GetPosition(splinePosition), Vector3.op_Multiply(Vector3.op_Multiply(normal, this.GetOutlineWidth()), -0.5f)), Vector3.op_Multiply(normal, this.GetOutlineNormalOffset())), new Vector3(0.0f, 0.0f, this.GetPhysicsZDepth() * 0.5f));
          Vector3[] vector3Array6 = vector3Array2;
          int index16 = num6;
          num3 = index16 + 1;
          vector3Array6[index16] = Vector3.op_Subtraction(Vector3.op_Addition(Vector3.op_Addition(this.GetPosition(splinePosition), Vector3.op_Multiply(Vector3.op_Multiply(normal, this.GetOutlineWidth()), 0.5f)), Vector3.op_Multiply(normal, this.GetOutlineNormalOffset())), new Vector3(0.0f, 0.0f, this.GetPhysicsZDepth() * 0.5f));
        }
        int num7 = 0;
        for (int index17 = 0; index17 < physicsColliderCount; ++index17)
        {
          int[] numArray4 = numArray3;
          int index18 = num7;
          int num8 = index18 + 1;
          int num9 = index17 * 4;
          numArray4[index18] = num9;
          int[] numArray5 = numArray3;
          int index19 = num8;
          int num10 = index19 + 1;
          int num11 = index17 * 4 + 4 + 1;
          numArray5[index19] = num11;
          int[] numArray6 = numArray3;
          int index20 = num10;
          int num12 = index20 + 1;
          int num13 = index17 * 4 + 4;
          numArray6[index20] = num13;
          int[] numArray7 = numArray3;
          int index21 = num12;
          int num14 = index21 + 1;
          int num15 = index17 * 4;
          numArray7[index21] = num15;
          int[] numArray8 = numArray3;
          int index22 = num14;
          int num16 = index22 + 1;
          int num17 = index17 * 4 + 1;
          numArray8[index22] = num17;
          int[] numArray9 = numArray3;
          int index23 = num16;
          int num18 = index23 + 1;
          int num19 = index17 * 4 + 4 + 1;
          numArray9[index23] = num19;
          int[] numArray10 = numArray3;
          int index24 = num18;
          int num20 = index24 + 1;
          int num21 = index17 * 4 + 1;
          numArray10[index24] = num21;
          int[] numArray11 = numArray3;
          int index25 = num20;
          int num22 = index25 + 1;
          int num23 = index17 * 4 + 1 + 4 + 1;
          numArray11[index25] = num23;
          int[] numArray12 = numArray3;
          int index26 = num22;
          int num24 = index26 + 1;
          int num25 = index17 * 4 + 1 + 4;
          numArray12[index26] = num25;
          int[] numArray13 = numArray3;
          int index27 = num24;
          int num26 = index27 + 1;
          int num27 = index17 * 4 + 1;
          numArray13[index27] = num27;
          int[] numArray14 = numArray3;
          int index28 = num26;
          int num28 = index28 + 1;
          int num29 = index17 * 4 + 1 + 1;
          numArray14[index28] = num29;
          int[] numArray15 = numArray3;
          int index29 = num28;
          int num30 = index29 + 1;
          int num31 = index17 * 4 + 1 + 4 + 1;
          numArray15[index29] = num31;
          int[] numArray16 = numArray3;
          int index30 = num30;
          int num32 = index30 + 1;
          int num33 = index17 * 4 + 2;
          numArray16[index30] = num33;
          int[] numArray17 = numArray3;
          int index31 = num32;
          int num34 = index31 + 1;
          int num35 = index17 * 4 + 2 + 4 + 1;
          numArray17[index31] = num35;
          int[] numArray18 = numArray3;
          int index32 = num34;
          int num36 = index32 + 1;
          int num37 = index17 * 4 + 2 + 4;
          numArray18[index32] = num37;
          int[] numArray19 = numArray3;
          int index33 = num36;
          int num38 = index33 + 1;
          int num39 = index17 * 4 + 2;
          numArray19[index33] = num39;
          int[] numArray20 = numArray3;
          int index34 = num38;
          int num40 = index34 + 1;
          int num41 = index17 * 4 + 2 + 1;
          numArray20[index34] = num41;
          int[] numArray21 = numArray3;
          int index35 = num40;
          int num42 = index35 + 1;
          int num43 = index17 * 4 + 2 + 4 + 1;
          numArray21[index35] = num43;
          int[] numArray22 = numArray3;
          int index36 = num42;
          int num44 = index36 + 1;
          int num45 = index17 * 4 + 3;
          numArray22[index36] = num45;
          int[] numArray23 = numArray3;
          int index37 = num44;
          int num46 = index37 + 1;
          int num47 = index17 * 4 + 3 + 1;
          numArray23[index37] = num47;
          int[] numArray24 = numArray3;
          int index38 = num46;
          int num48 = index38 + 1;
          int num49 = index17 * 4 + 3 + 4;
          numArray24[index38] = num49;
          int[] numArray25 = numArray3;
          int index39 = num48;
          int num50 = index39 + 1;
          int num51 = index17 * 4 + 3;
          numArray25[index39] = num51;
          int[] numArray26 = numArray3;
          int index40 = num50;
          int num52 = index40 + 1;
          int num53 = index17 * 4;
          numArray26[index40] = num53;
          int[] numArray27 = numArray3;
          int index41 = num52;
          num7 = index41 + 1;
          int num54 = index17 * 4 + 3 + 1;
          numArray27[index41] = num54;
        }
        MeshCollider meshCollider2 = ((Component) this).gameObject.GetComponent(typeof (MeshCollider)) as MeshCollider;
        bool flag2 = Object.op_Equality((Object) meshCollider2, (Object) null);
        Mesh mesh2 = !flag2 ? (!Object.op_Equality((Object) meshCollider2.sharedMesh, (Object) null) ? meshCollider2.sharedMesh : new Mesh()) : new Mesh();
        mesh2.Clear();
        mesh2.vertices = vector3Array2;
        mesh2.triangles = numArray3;
        mesh2.RecalculateBounds();
        mesh2.RecalculateNormals();
        mesh2.Optimize();
        if (flag2)
          meshCollider2 = ((Component) this).gameObject.AddComponent(typeof (MeshCollider)) as MeshCollider;
        meshCollider2.sharedMesh = (Mesh) null;
        meshCollider2.sharedMesh = mesh2;
        ((Collider) meshCollider2).sharedMaterial = this.physicsMaterial;
        meshCollider2.convex = this.GetCreateConvexMeshCollider();
        break;
      case RageSpline.땲.땃:
        this.DestroyMeshCollider();
        this.DestroyBoxColliders();
        this.UpdateFarseerPhysics();
        break;
    }
  }

  public void ForceZeroZ() => this.spline.딢();

  public void DestroyFarseerPhysics()
  {
    FSConcaveShapeComponent component1 = ((Component) this).GetComponent<FSConcaveShapeComponent>();
    if (Object.op_Inequality((Object) component1, (Object) null))
      Object.DestroyImmediate((Object) component1);
    FSBodyComponent component2 = ((Component) this).GetComponent<FSBodyComponent>();
    if (Object.op_Inequality((Object) component2, (Object) null))
      Object.DestroyImmediate((Object) component2);
    this.DestroyFarseerNow = true;
  }

  public void DestroyBoxColliders()
  {
    int num1 = 0;
    int num2 = ((Component) this).transform.childCount + 1;
    while (((Component) this).transform.childCount > 0 && num1 < ((Component) this).transform.childCount && num2 > 0)
    {
      --num2;
      if (Object.op_Inequality((Object) ((Component) ((Component) this).transform.GetChild(num1)).GetComponent(typeof (BoxCollider)), (Object) null))
      {
        if (((Object) ((Component) this).transform.GetChild(num1)).name.Substring(0, 3).Equals("ZZZ"))
          Object.DestroyImmediate((Object) ((Component) ((Component) this).transform.GetChild(num1)).gameObject);
      }
      else
        ++num1;
    }
  }

  public void DestroyMeshCollider()
  {
    MeshCollider component = ((Component) this).gameObject.GetComponent(typeof (MeshCollider)) as MeshCollider;
    if (!Object.op_Inequality((Object) component, (Object) null))
      return;
    Object.DestroyImmediate((Object) component.sharedMesh);
    Object.DestroyImmediate((Object) component);
  }

  public void DestroyPhysicsChildren()
  {
    this.DestroyFarseerPhysics();
    this.DestroyMeshCollider();
    this.DestroyBoxColliders();
  }

  public Vector3 ScaleToGlobal(Vector3 vec) => new Vector3((float) (vec.x * ((Component) this).transform.lossyScale.x), (float) (vec.y * ((Component) this).transform.lossyScale.y), (float) (vec.z * ((Component) this).transform.lossyScale.z));

  public Vector3 ScaleToLocal(Vector3 vec) => new Vector3((float) (vec.x * (1.0 / ((Component) this).transform.lossyScale.x)), (float) (vec.y * (1.0 / ((Component) this).transform.lossyScale.y)), (float) (vec.z * (1.0 / ((Component) this).transform.lossyScale.z)));

  public int GetNearestPointIndex(float splinePosition) => this.spline.떂(splinePosition);

  public int GetNearestPointIndex(Vector3 pos)
  {
    if (!땺.땢.딟((float) pos.z, 0.0f))
    {
      // ISSUE: explicit constructor call
      ((Vector3) ref pos).\u002Ector((float) pos.x, (float) pos.y, 0.0f);
    }
    Vector3 vector3_1 = Vector3.op_Subtraction(pos, this.spline.points[0].point);
    float sqrMagnitude = ((Vector3) ref vector3_1).sqrMagnitude;
    int num = 0;
    for (int index = 1; index < this.spline.points.Length; ++index)
    {
      Vector3 vector3_2 = Vector3.op_Subtraction(pos, this.spline.points[index].point);
      if ((double) ((Vector3) ref vector3_2).sqrMagnitude < (double) sqrMagnitude)
      {
        Vector3 vector3_3 = Vector3.op_Subtraction(pos, this.spline.points[index].point);
        sqrMagnitude = ((Vector3) ref vector3_3).sqrMagnitude;
        num = index;
      }
    }
    return num;
  }

  public void CreateDefaultSpline()
  {
    Vector3[] vector3Array1 = new Vector3[2];
    Vector3[] vector3Array2 = new Vector3[4];
    float[] numArray = new float[2];
    bool[] flagArray = new bool[2];
    vector3Array1[0] = new Vector3(0.0f, (float) (-(double) Camera.main.orthographicSize * 0.400000005960464), 0.0f);
    numArray[0] = 1f;
    vector3Array2[0] = new Vector3(Camera.main.orthographicSize * 0.3f, 0.0f, 0.0f);
    vector3Array2[1] = new Vector3(Camera.main.orthographicSize * -0.3f, 0.0f, 0.0f);
    flagArray[0] = true;
    vector3Array1[1] = new Vector3(0.0f, Camera.main.orthographicSize * 0.4f, 0.0f);
    numArray[1] = 1f;
    vector3Array2[2] = new Vector3(Camera.main.orthographicSize * -0.3f, 0.0f, 0.0f);
    vector3Array2[3] = new Vector3(Camera.main.orthographicSize * 0.3f, 0.0f, 0.0f);
    flagArray[1] = true;
    this.spline = new RageCurve(vector3Array1, vector3Array2, flagArray, numArray);
  }

  public bool pointsAreInClockWiseOrder()
  {
    float num = 0.0f;
    int pointCount = this.GetPointCount();
    if (pointCount < 3 || this.GetFill() == RageSpline.땤.딢)
      return true;
    for (int index = 0; index < pointCount; ++index)
    {
      Vector3 position = this.GetPosition(index);
      Vector3 vector3 = index + 1 <= pointCount - 1 ? this.GetPosition(index + 1) : this.GetPosition(0);
      num += (float) (position.x * vector3.y - vector3.x * position.y);
    }
    return (double) num < 0.0 || this.GetFill() == RageSpline.땤.딢 || this.GetOutline() == RageSpline.떂.딧;
  }

  public void flipPointOrder()
  {
    RageSplinePoint[] rageSplinePointArray = new RageSplinePoint[this.GetPointCount()];
    for (int index = 0; index < this.GetPointCount(); ++index)
    {
      Vector3 inCtrl = this.spline.points[this.GetPointCount() - index - 1].inCtrl;
      Vector3 outCtrl = this.spline.points[this.GetPointCount() - index - 1].outCtrl;
      rageSplinePointArray[index] = this.spline.points[this.GetPointCount() - index - 1];
      rageSplinePointArray[index].inCtrl = outCtrl;
      rageSplinePointArray[index].outCtrl = inCtrl;
    }
    this.spline.points = rageSplinePointArray;
  }

  public void DrawSplineGizmos()
  {
    Vector3 vector3 = this.GetPosition(0.0f);
    Gizmos.color = new Color(1f, 1f, 1f, 1f);
    for (int index = 1; index <= this.GetVertexCount(); ++index)
    {
      Vector3 position = this.GetPosition(Mathf.Clamp01((float) index / (float) this.GetVertexCount()));
      Gizmos.DrawLine(((Component) this).transform.TransformPoint(vector3), ((Component) this).transform.TransformPoint(position));
      vector3 = position;
    }
    if (this.hideHandles)
      return;
    Gizmos.color = Color.red;
    for (int index = 0; index < this.GetPointCount(); ++index)
    {
      Gizmos.DrawLine(this.GetPositionWorldSpace(index), this.GetInControlPositionWorldSpace(index));
      Gizmos.DrawLine(this.GetPositionWorldSpace(index), this.GetOutControlPositionWorldSpace(index));
    }
  }

  public void DrawEmbossGizmos()
  {
    Vector3 p;
    // ISSUE: explicit constructor call
    ((Vector3) ref p).\u002Ector(0.0f, 1f, 0.0f);
    Vector3 vector3_1 = this.spline.딧(10);
    Vector3 vector3_2 = Vector2.op_Implicit(Vector2.op_Multiply(this.RotatePoint2D_CCW(p, this.GetEmbossAngleDeg() * ((float) Math.PI / 180f)), this.GetEmbossSize() * 4f));
    Gizmos.color = Color.blue;
    Gizmos.DrawLine(((Component) this).transform.TransformPoint(vector3_1), ((Component) this).transform.TransformPoint(Vector3.op_Addition(vector3_1, vector3_2)));
  }

  public void DrawGradientGizmos()
  {
    Vector3 p;
    // ISSUE: explicit constructor call
    ((Vector3) ref p).\u002Ector(0.0f, 1f, 0.0f);
    Vector3 vector3_1 = Vector2.op_Implicit(this.GetGradientOffset());
    Vector3 vector3_2 = Vector2.op_Implicit(Vector2.op_Multiply(this.RotatePoint2D_CCW(p, this.GetGradientAngleDeg() * ((float) Math.PI / 180f)), 1f / this.GetGradientScaleInv()));
    Gizmos.color = Color.green;
    Gizmos.DrawLine(((Component) this).transform.TransformPoint(vector3_1), ((Component) this).transform.TransformPoint(Vector3.op_Addition(vector3_1, vector3_2)));
    Gizmos.color = Color.op_Multiply(Color.green, new Color(1f, 1f, 1f, 0.2f));
    Vector3 vector3_3 = ((Component) this).transform.TransformPoint(vector3_1);
    for (int index = 4; index <= 360; index += 4)
      Gizmos.DrawLine(Vector3.op_Addition(vector3_3, this.ScaleToGlobal(Vector2.op_Implicit(Vector2.op_Multiply(this.RotatePoint2D_CCW(p, (float) (index - 4) * ((float) Math.PI / 180f)), 1f / this.GetGradientScaleInv())))), Vector3.op_Addition(vector3_3, this.ScaleToGlobal(Vector2.op_Implicit(Vector2.op_Multiply(this.RotatePoint2D_CCW(p, (float) index * ((float) Math.PI / 180f)), 1f / this.GetGradientScaleInv())))));
  }

  public void DrawTexturingGizmos()
  {
    Vector3 p;
    // ISSUE: explicit constructor call
    ((Vector3) ref p).\u002Ector(0.0f, 1f, 0.0f);
    Vector3 vector3_1 = Vector2.op_Implicit(this.GetTextureOffset());
    Vector3 vector3_2 = Vector2.op_Implicit(Vector2.op_Multiply(this.RotatePoint2D_CCW(p, this.GetTextureAngleDeg() * ((float) Math.PI / 180f)), 1f / this.GetTextureScaleInv()));
    Gizmos.color = Color.magenta;
    Gizmos.DrawLine(((Component) this).transform.TransformPoint(vector3_1), ((Component) this).transform.TransformPoint(Vector3.op_Addition(vector3_1, vector3_2)));
    Vector2 vector2 = Vector2.op_Implicit(vector3_1);
    Gizmos.color = Color.op_Multiply(Color.magenta, new Color(1f, 1f, 1f, 0.5f));
    Gizmos.DrawLine(((Component) this).transform.TransformPoint(Vector2.op_Implicit(Vector2.op_Addition(vector2, Vector2.op_Multiply(this.RotatePoint2D_CCW(new Vector3(0.5f, 0.5f, 0.0f), this.GetTextureAngleDeg() * ((float) Math.PI / 180f)), 1f / this.GetTextureScaleInv())))), ((Component) this).transform.TransformPoint(Vector2.op_Implicit(Vector2.op_Addition(vector2, Vector2.op_Multiply(this.RotatePoint2D_CCW(new Vector3(-0.5f, 0.5f, 0.0f), this.GetTextureAngleDeg() * ((float) Math.PI / 180f)), 1f / this.GetTextureScaleInv())))));
    Gizmos.DrawLine(((Component) this).transform.TransformPoint(Vector2.op_Implicit(Vector2.op_Addition(vector2, Vector2.op_Multiply(this.RotatePoint2D_CCW(new Vector3(-0.5f, 0.5f, 0.0f), this.GetTextureAngleDeg() * ((float) Math.PI / 180f)), 1f / this.GetTextureScaleInv())))), ((Component) this).transform.TransformPoint(Vector2.op_Implicit(Vector2.op_Addition(vector2, Vector2.op_Multiply(this.RotatePoint2D_CCW(new Vector3(-0.5f, -0.5f, 0.0f), this.GetTextureAngleDeg() * ((float) Math.PI / 180f)), 1f / this.GetTextureScaleInv())))));
    Gizmos.DrawLine(((Component) this).transform.TransformPoint(Vector2.op_Implicit(Vector2.op_Addition(vector2, Vector2.op_Multiply(this.RotatePoint2D_CCW(new Vector3(-0.5f, -0.5f, 0.0f), this.GetTextureAngleDeg() * ((float) Math.PI / 180f)), 1f / this.GetTextureScaleInv())))), ((Component) this).transform.TransformPoint(Vector2.op_Implicit(Vector2.op_Addition(vector2, Vector2.op_Multiply(this.RotatePoint2D_CCW(new Vector3(0.5f, -0.5f, 0.0f), this.GetTextureAngleDeg() * ((float) Math.PI / 180f)), 1f / this.GetTextureScaleInv())))));
    Gizmos.DrawLine(((Component) this).transform.TransformPoint(Vector2.op_Implicit(Vector2.op_Addition(vector2, Vector2.op_Multiply(this.RotatePoint2D_CCW(new Vector3(0.5f, -0.5f, 0.0f), this.GetTextureAngleDeg() * ((float) Math.PI / 180f)), 1f / this.GetTextureScaleInv())))), ((Component) this).transform.TransformPoint(Vector2.op_Implicit(Vector2.op_Addition(vector2, Vector2.op_Multiply(this.RotatePoint2D_CCW(new Vector3(0.5f, 0.5f, 0.0f), this.GetTextureAngleDeg() * ((float) Math.PI / 180f)), 1f / this.GetTextureScaleInv())))));
  }

  public void DrawTexturingGizmos2()
  {
    Vector3 p;
    // ISSUE: explicit constructor call
    ((Vector3) ref p).\u002Ector(0.0f, 1f, 0.0f);
    Vector3 vector3_1 = Vector2.op_Implicit(this.GetTextureOffset2());
    Vector3 vector3_2 = Vector2.op_Implicit(Vector2.op_Multiply(this.RotatePoint2D_CCW(p, this.GetTextureAngle2Deg() * ((float) Math.PI / 180f)), 1f / this.GetTextureScale2Inv()));
    Gizmos.color = Color.magenta;
    Gizmos.DrawLine(((Component) this).transform.TransformPoint(vector3_1), ((Component) this).transform.TransformPoint(Vector3.op_Addition(vector3_1, vector3_2)));
    Vector2 vector2 = Vector2.op_Implicit(vector3_1);
    Gizmos.color = Color.op_Multiply(Color.magenta, new Color(1f, 1f, 1f, 0.5f));
    Gizmos.DrawLine(((Component) this).transform.TransformPoint(Vector2.op_Implicit(Vector2.op_Addition(vector2, Vector2.op_Multiply(this.RotatePoint2D_CCW(new Vector3(0.5f, 0.5f, 0.0f), this.GetTextureAngle2Deg() * ((float) Math.PI / 180f)), 1f / this.GetTextureScale2Inv())))), ((Component) this).transform.TransformPoint(Vector2.op_Implicit(Vector2.op_Addition(vector2, Vector2.op_Multiply(this.RotatePoint2D_CCW(new Vector3(-0.5f, 0.5f, 0.0f), this.GetTextureAngle2Deg() * ((float) Math.PI / 180f)), 1f / this.GetTextureScale2Inv())))));
    Gizmos.DrawLine(((Component) this).transform.TransformPoint(Vector2.op_Implicit(Vector2.op_Addition(vector2, Vector2.op_Multiply(this.RotatePoint2D_CCW(new Vector3(-0.5f, 0.5f, 0.0f), this.GetTextureAngle2Deg() * ((float) Math.PI / 180f)), 1f / this.GetTextureScale2Inv())))), ((Component) this).transform.TransformPoint(Vector2.op_Implicit(Vector2.op_Addition(vector2, Vector2.op_Multiply(this.RotatePoint2D_CCW(new Vector3(-0.5f, -0.5f, 0.0f), this.GetTextureAngle2Deg() * ((float) Math.PI / 180f)), 1f / this.GetTextureScale2Inv())))));
    Gizmos.DrawLine(((Component) this).transform.TransformPoint(Vector2.op_Implicit(Vector2.op_Addition(vector2, Vector2.op_Multiply(this.RotatePoint2D_CCW(new Vector3(-0.5f, -0.5f, 0.0f), this.GetTextureAngle2Deg() * ((float) Math.PI / 180f)), 1f / this.GetTextureScale2Inv())))), ((Component) this).transform.TransformPoint(Vector2.op_Implicit(Vector2.op_Addition(vector2, Vector2.op_Multiply(this.RotatePoint2D_CCW(new Vector3(0.5f, -0.5f, 0.0f), this.GetTextureAngle2Deg() * ((float) Math.PI / 180f)), 1f / this.GetTextureScale2Inv())))));
    Gizmos.DrawLine(((Component) this).transform.TransformPoint(Vector2.op_Implicit(Vector2.op_Addition(vector2, Vector2.op_Multiply(this.RotatePoint2D_CCW(new Vector3(0.5f, -0.5f, 0.0f), this.GetTextureAngle2Deg() * ((float) Math.PI / 180f)), 1f / this.GetTextureScale2Inv())))), ((Component) this).transform.TransformPoint(Vector2.op_Implicit(Vector2.op_Addition(vector2, Vector2.op_Multiply(this.RotatePoint2D_CCW(new Vector3(0.5f, 0.5f, 0.0f), this.GetTextureAngle2Deg() * ((float) Math.PI / 180f)), 1f / this.GetTextureScale2Inv())))));
  }

  public void DrawGrid()
  {
    Rect bounds = this.GetBounds();
    Gizmos.color = this.gridColor;
    if (this.showCoordinates == RageSpline.떏.딧)
    {
      Vector3 vector3_1 = ((Component) this).transform.TransformPoint(new Vector3(((Rect) ref bounds).xMin, ((Rect) ref bounds).yMin));
      Vector3 vector3_2 = ((Component) this).transform.TransformPoint(new Vector3(((Rect) ref bounds).xMax, ((Rect) ref bounds).yMax));
      float grid1 = this.SnapToGrid((float) (vector3_1.x - (double) this.gridSize * (double) this.gridExpansion), this.gridSize);
      float grid2 = this.SnapToGrid((float) (vector3_2.x + (double) this.gridSize * (double) this.gridExpansion), this.gridSize);
      float grid3 = this.SnapToGrid((float) (vector3_1.y - (double) this.gridSize * (double) this.gridExpansion), this.gridSize);
      float grid4 = this.SnapToGrid((float) (vector3_2.y + (double) this.gridSize * (double) this.gridExpansion), this.gridSize);
      if (((double) grid2 - (double) grid1) / (double) this.gridSize >= 500.0 || ((double) grid4 - (double) grid3) / (double) this.gridSize >= 500.0)
        return;
      for (float num = grid1; (double) num < (double) grid2 + (double) this.gridSize * 0.5; num += this.gridSize)
        Gizmos.DrawLine(Vector2.op_Implicit(new Vector2(num, grid4)), Vector2.op_Implicit(new Vector2(num, grid3)));
      for (float num = grid3; (double) num < (double) grid4 + (double) this.gridSize * 0.5; num += this.gridSize)
        Gizmos.DrawLine(Vector2.op_Implicit(new Vector2(grid2, num)), Vector2.op_Implicit(new Vector2(grid1, num)));
    }
    else
    {
      float num1 = this.SnapToGrid(((Rect) ref bounds).xMin, this.gridSize) - this.gridSize * (float) this.gridExpansion;
      float num2 = this.SnapToGrid(((Rect) ref bounds).xMax, this.gridSize) + this.gridSize * (float) this.gridExpansion;
      float num3 = this.SnapToGrid(((Rect) ref bounds).yMin, this.gridSize) - this.gridSize * (float) this.gridExpansion;
      float num4 = this.SnapToGrid(((Rect) ref bounds).yMax, this.gridSize) + this.gridSize * (float) this.gridExpansion;
      if (((double) num2 - (double) num1) / (double) this.gridSize >= 500.0 || ((double) num4 - (double) num3) / (double) this.gridSize >= 500.0)
        return;
      for (float num5 = num1; (double) num5 < (double) num2 + (double) this.gridSize * 0.5; num5 += this.gridSize)
        Gizmos.DrawLine(((Component) this).transform.TransformPoint(Vector2.op_Implicit(new Vector2(num5, num4))), ((Component) this).transform.TransformPoint(Vector2.op_Implicit(new Vector2(num5, num3))));
      for (float num6 = num3; (double) num6 < (double) num4 + (double) this.gridSize * 0.5; num6 += this.gridSize)
        Gizmos.DrawLine(((Component) this).transform.TransformPoint(Vector2.op_Implicit(new Vector2(num2, num6))), ((Component) this).transform.TransformPoint(Vector2.op_Implicit(new Vector2(num1, num6))));
    }
  }

  public bool IsSharpCorner(int index)
  {
    if (!this.GetNatural(index))
    {
      Vector3 position1 = this.GetPosition(index);
      float splinePosition1 = (float) ((double) index / (double) this.GetPointCount() - 1.0 / (double) this.GetVertexCount());
      float splinePosition2 = (float) ((double) index / (double) this.GetPointCount() + 1.0 / (double) this.GetVertexCount());
      Vector3 position2 = this.GetPosition(splinePosition1);
      Vector3 position3 = this.GetPosition(splinePosition2);
      if (Vector3.Cross(Vector3.op_Subtraction(position1, position2), Vector3.op_Subtraction(position3, position1)).z < 0.0)
        return true;
    }
    return false;
  }

  public float GetLastSplinePosition() => this.SplineIsOpenEnded() ? (float) (this.GetPointCount() - 1) / (float) this.GetPointCount() : 1f;

  public bool SplineIsOpenEnded() => this.GetOutline() == RageSpline.떂.딧 && this.GetFill() == RageSpline.땤.딟 || this.GetFill() == RageSpline.땤.딢;

  public Vector3 GetNormal(float splinePosition) => this.spline.땄(splinePosition * this.GetLastSplinePosition());

  public Vector3 GetNormalInterpolated(float splinePosition) => this.spline.딧(splinePosition * this.GetLastSplinePosition());

  public Vector3 GetNormal(int index) => this.spline.땄((float) index / (float) this.GetPointCount());

  public void SetOutControlPosition(int index, Vector3 position)
  {
    this.spline.땄(index).outCtrl = Vector3.op_Subtraction(position, this.spline.땄(index).point);
    if (!this.spline.땄(index).natural)
      return;
    this.spline.땄(index).inCtrl = Vector3.op_Multiply(this.spline.땄(index).outCtrl, -1f);
  }

  public void SetOutControlPositionPointSpace(int index, Vector3 position)
  {
    this.spline.땄(index).outCtrl = position;
    if (!this.spline.땄(index).natural)
      return;
    this.spline.땄(index).inCtrl = Vector3.op_Multiply(this.spline.땄(index).outCtrl, -1f);
  }

  public void SetOutControlPositionWorldSpace(int index, Vector3 position)
  {
    this.spline.땄(index).outCtrl = Vector3.op_Subtraction(((Component) this).transform.InverseTransformPoint(position), this.spline.땄(index).point);
    if (!this.spline.땄(index).natural)
      return;
    this.spline.땄(index).inCtrl = Vector3.op_Multiply(this.spline.땄(index).outCtrl, -1f);
  }

  public void SetInControlPosition(int index, Vector3 position)
  {
    this.spline.땄(index).inCtrl = Vector3.op_Subtraction(position, this.spline.땄(index).point);
    if (!this.spline.땄(index).natural)
      return;
    this.spline.땄(index).outCtrl = Vector3.op_Multiply(this.spline.땄(index).inCtrl, -1f);
  }

  public void SetInControlPositionPointSpace(int index, Vector3 position)
  {
    this.spline.땄(index).inCtrl = position;
    if (!this.spline.땄(index).natural)
      return;
    this.spline.땄(index).outCtrl = Vector3.op_Multiply(this.spline.땄(index).inCtrl, -1f);
  }

  public void SetInControlPositionWorldSpace(int index, Vector3 position)
  {
    this.spline.땄(index).inCtrl = Vector3.op_Subtraction(((Component) this).transform.InverseTransformPoint(position), this.spline.땄(index).point);
    if (!this.spline.땄(index).natural)
      return;
    this.spline.땄(index).outCtrl = Vector3.op_Multiply(this.spline.땄(index).inCtrl, -1f);
  }

  public Vector3 GetOutControlPosition(int index) => Vector3.op_Addition(this.spline.땄(index).point, this.spline.땄(index).outCtrl);

  public Vector3 GetInControlPosition(int index) => Vector3.op_Addition(this.spline.땄(index).point, this.spline.땄(index).inCtrl);

  public Vector3 GetOutControlPositionPointSpace(int index) => this.spline.땄(index).outCtrl;

  public Vector3 GetInControlPositionPointSpace(int index) => this.spline.땄(index).inCtrl;

  public Vector3 GetOutControlPositionWorldSpace(int index) => ((Component) this).transform.TransformPoint(Vector3.op_Addition(this.spline.땄(index).point, this.spline.땄(index).outCtrl));

  public Vector3 GetInControlPositionWorldSpace(int index) => ((Component) this).transform.TransformPoint(Vector3.op_Addition(this.spline.땄(index).point, this.spline.땄(index).inCtrl));

  public Vector3 GetPosition(int index) => this.spline.땄(index).point;

  public int GetPointCount() => this.spline.points.Length;

  public Vector3 GetPositionWorldSpace(int index) => ((Component) this).transform.TransformPoint(this.spline.땄(index).point);

  public Vector3 GetPosition(float splinePosition) => this.spline.땺(splinePosition * this.GetLastSplinePosition());

  public Vector3 GetPositionWorldSpace(float splinePosition) => ((Component) this).transform.TransformPoint(this.spline.땺(splinePosition * this.GetLastSplinePosition()));

  public Vector3 GetMiddle() => this.spline.딧(100);

  public Rect GetBounds()
  {
    Vector3 vector3_1 = this.spline.땄(100, 0.0f, this.GetLastSplinePosition());
    Vector3 vector3_2 = this.spline.딟(100, 0.0f, this.GetLastSplinePosition());
    return new Rect((float) vector3_2.x, (float) vector3_2.y, (float) (vector3_1.x - vector3_2.x), (float) (vector3_1.y - vector3_2.y));
  }

  public float GetLength() => this.spline.딢(128);

  public float GetNearestSplinePosition(Vector3 position, int accuracy)
  {
    float num1 = 1E+11f;
    float num2 = 0.0f;
    for (int index = 0; index < accuracy; ++index)
    {
      Vector3 vector3_1 = this.spline.땺((float) index / (float) accuracy * this.GetLastSplinePosition());
      Vector3 vector3_2 = Vector3.op_Subtraction(position, vector3_1);
      if ((double) ((Vector3) ref vector3_2).sqrMagnitude < (double) num1)
      {
        num2 = (float) index / (float) accuracy;
        Vector3 vector3_3 = Vector3.op_Subtraction(position, vector3_1);
        num1 = ((Vector3) ref vector3_3).sqrMagnitude;
      }
    }
    return num2;
  }

  public float GetNearestSplinePositionWorldSpace(Vector3 position, int accuracy) => this.GetNearestSplinePosition(((Component) this).transform.InverseTransformPoint(position), accuracy);

  public Vector3 GetNearestPosition(Vector3 position) => this.spline.땺(this.GetNearestSplinePosition(position, 100));

  public Vector3 GetNearestPositionWorldSpace(Vector3 position) => ((Component) this).transform.TransformPoint(this.spline.땺(this.spline.딟(((Component) this).transform.InverseTransformPoint(position), 100)));

  public void ClearPoints() => this.spline.딧();

  public void AddPoint(
    int index,
    Vector3 position,
    Vector3 inCtrl,
    Vector3 outCtrl,
    float width,
    bool natural)
  {
    this.spline.딟(index, position, inCtrl, outCtrl, width, natural);
  }

  public void AddPoint(int index, Vector3 position, Vector3 outCtrl) => this.spline.딟(index, position, Vector3.op_Multiply(outCtrl, -1f), outCtrl, 1f, true);

  public void AddPoint(int index, Vector3 position)
  {
    if (this.GetPointCount() >= 2)
      this.spline.딟(index, position);
    else
      Debug.Log((object) "ERROR: You can only call AddPoint(index, position), when there are 2 or more points in the RageSpline already");
  }

  public int AddPoint(float splinePosition) => this.spline.떎(splinePosition * this.GetLastSplinePosition());

  public void AddPointWorldSpace(
    int index,
    Vector3 position,
    Vector3 inCtrl,
    Vector3 outCtrl,
    float width,
    bool natural)
  {
    this.spline.딟(index, ((Component) this).transform.InverseTransformPoint(position), inCtrl, outCtrl, width, natural);
  }

  public void AddPointWorldSpace(int index, Vector3 position, Vector3 outCtrl, float width) => this.spline.딟(index, ((Component) this).transform.InverseTransformPoint(position), Vector3.op_Multiply(outCtrl, -1f), outCtrl, width, true);

  public void AddPointWorldSpace(int index, Vector3 position, Vector3 outCtrl) => this.spline.딟(index, ((Component) this).transform.InverseTransformPoint(position), Vector3.op_Multiply(outCtrl, -1f), outCtrl, 1f, true);

  public void AddPointWorldSpace(int index, Vector3 position)
  {
    if (this.GetPointCount() >= 2)
      this.spline.딟(index, ((Component) this).transform.InverseTransformPoint(position));
    else
      Debug.Log((object) "ERROR: You can only call AddPoint(index, position), when there are 2 or more points in the RageSpline already");
  }

  public void SetPoint(
    int index,
    Vector3 position,
    Vector3 inCtrl,
    Vector3 outCtrl,
    float width,
    bool natural)
  {
    this.spline.points[index].point = position;
    this.spline.points[index].inCtrl = inCtrl;
    this.spline.points[index].outCtrl = outCtrl;
    this.spline.points[index].widthMultiplier = width;
    this.spline.points[index].natural = natural;
  }

  public void SetPoint(
    int index,
    Vector3 position,
    Vector3 inCtrl,
    Vector3 outCtrl,
    bool natural)
  {
    this.spline.points[index].point = position;
    this.spline.points[index].inCtrl = inCtrl;
    this.spline.points[index].outCtrl = outCtrl;
    this.spline.points[index].natural = natural;
  }

  public void SetPoint(int index, Vector3 position, Vector3 inCtrl, Vector3 outCtrl)
  {
    this.spline.points[index].point = position;
    this.spline.points[index].inCtrl = inCtrl;
    this.spline.points[index].outCtrl = outCtrl;
  }

  public void SetPoint(int index, Vector3 position, Vector3 outCtrl)
  {
    this.spline.points[index].point = position;
    this.spline.points[index].inCtrl = Vector3.op_Multiply(outCtrl, -1f);
    this.spline.points[index].outCtrl = outCtrl;
    this.spline.points[index].natural = true;
  }

  public void SetPoint(int index, Vector3 position) => this.spline.points[index].point = position;

  public void SetPointWorldSpace(
    int index,
    Vector3 position,
    Vector3 inCtrl,
    Vector3 outCtrl,
    float width,
    bool natural)
  {
    this.spline.points[index].point = ((Component) this).transform.InverseTransformPoint(position);
    this.spline.points[index].inCtrl = Vector3.op_Multiply(outCtrl, -1f);
    this.spline.points[index].outCtrl = outCtrl;
    this.spline.points[index].widthMultiplier = width;
    this.spline.points[index].natural = natural;
  }

  public void SetPointWorldSpace(
    int index,
    Vector3 position,
    Vector3 inCtrl,
    Vector3 outCtrl,
    float width)
  {
    this.spline.points[index].point = ((Component) this).transform.InverseTransformPoint(position);
    this.spline.points[index].inCtrl = Vector3.op_Multiply(outCtrl, -1f);
    this.spline.points[index].outCtrl = outCtrl;
    this.spline.points[index].widthMultiplier = width;
  }

  public void SetPointWorldSpace(int index, Vector3 position, Vector3 inCtrl, Vector3 outCtrl)
  {
    this.spline.points[index].point = ((Component) this).transform.InverseTransformPoint(position);
    this.spline.points[index].inCtrl = Vector3.op_Multiply(outCtrl, -1f);
    this.spline.points[index].outCtrl = outCtrl;
  }

  public void SetPointWorldSpace(int index, Vector3 position, Vector3 outCtrl)
  {
    this.spline.points[index].point = ((Component) this).transform.InverseTransformPoint(position);
    this.spline.points[index].inCtrl = Vector3.op_Multiply(outCtrl, -1f);
    this.spline.points[index].outCtrl = outCtrl;
    this.spline.points[index].natural = true;
  }

  public void SetPointWorldSpace(int index, Vector3 position) => this.spline.points[index].point = ((Component) this).transform.InverseTransformPoint(position);

  public void SmartRemovePoint(int index) => this.spline.딶(index);

  public void RemovePoint(int index) => this.spline.땓(index);

  public bool GetNatural(int index) => this.spline.땄(index).natural;

  public void SetNatural(int index, bool natural)
  {
    this.spline.땄(index).natural = natural;
    if (!natural)
      return;
    this.spline.땄(index).outCtrl = Vector3.op_Multiply(this.spline.땄(index).inCtrl, -1f);
  }

  public float GetOutlineWidth(float splinePosition) => this.spline.딟(splinePosition) * this.GetOutlineWidth();

  public float GetAntialiasingWidth(float splinePosition) => this.GetAntialiasingWidth();

  public Vector3 FindNormal(Vector3 v1, Vector3 v2, Vector3 v3, float outlineWidth)
  {
    Quaternion 딟1 = RageSpline.딟;
    Vector3 vector3_1 = Vector3.op_Subtraction(v1, v2);
    Vector3 normalized1 = ((Vector3) ref vector3_1).normalized;
    Vector3 vector3_2 = Vector3.op_Multiply(Quaternion.op_Multiply(딟1, normalized1), outlineWidth);
    Quaternion 딟2 = RageSpline.딟;
    Vector3 vector3_3 = Vector3.op_Subtraction(v2, v3);
    Vector3 normalized2 = ((Vector3) ref vector3_3).normalized;
    Vector3 vector3_4 = Vector3.op_Multiply(Quaternion.op_Multiply(딟2, normalized2), outlineWidth);
    return Vector3.op_Subtraction(this.Crossing(Vector3.op_Addition(v1, vector3_2), Vector3.op_Addition(v2, vector3_2), Vector3.op_Addition(v2, vector3_4), Vector3.op_Addition(v3, vector3_4)), v2);
  }

  public Vector3 Crossing(Vector3 p11, Vector3 p12, Vector3 p21, Vector3 p22)
  {
    float num1 = (float) ((p12.y - p11.y) * (p21.x - p22.x) - (p21.y - p22.y) * (p12.x - p11.x));
    float num2 = (float) ((p21.y - p11.y) * (p21.x - p22.x) - (p21.y - p22.y) * (p21.x - p11.x));
    return (double) num1 > -1.0 / 1000.0 && (double) num1 < 1.0 / 1000.0 || (double) num2 > -1.0 / 1000.0 && (double) num2 < 1.0 / 1000.0 ? p12 : new Vector3((float) (p11.x + (p12.x - p11.x) * (double) num2 / (double) num1), (float) (p11.y + (p12.y - p11.y) * (double) num2 / (double) num1));
  }

  public int GetIndex(int index, int length)
  {
    if (index >= length)
      return length - index + 1;
    return index < 0 ? length + index - 1 : index;
  }

  public float GetOutlineWidth(int index) => this.GetOutlineWidth((float) index / (float) this.GetPointCount());

  public float GetOutlineWidthMultiplier(int index) => this.spline.땄(index).widthMultiplier;

  public void SetOutlineWidthMultiplier(int index, float width) => this.spline.땄(index).widthMultiplier = width;

  public void SetOutline(RageSpline.떂 outline)
  {
    this.outline = outline;
    if (!Object.op_Inequality((Object) this.style, (Object) null))
      return;
    this.style.딟(outline, this);
  }

  public RageSpline.떂 GetOutline() => Object.op_Equality((Object) this.style, (Object) null) ? this.outline : this.style.딟();

  public void SetOutlineColor1(Color color)
  {
    this.outlineColor1 = color;
    if (!Object.op_Inequality((Object) this.style, (Object) null))
      return;
    this.style.딟(color, this);
  }

  public Color GetOutlineColor1() => Object.op_Equality((Object) this.style, (Object) null) ? this.outlineColor1 : this.style.땄();

  public Color GetOutlineColor2() => Object.op_Equality((Object) this.style, (Object) null) ? this.outlineColor2 : this.style.딧();

  public void SetOutlineColor2(Color color)
  {
    this.outlineColor2 = color;
    if (!Object.op_Inequality((Object) this.style, (Object) null))
      return;
    this.style.땄(color, this);
  }

  public RageSpline.땭 GetOutlineGradient() => Object.op_Equality((Object) this.style, (Object) null) ? this.outlineGradient : this.style.딢();

  public void SetOutlineGradient(RageSpline.땭 outlineGradient)
  {
    this.outlineGradient = outlineGradient;
    if (!Object.op_Inequality((Object) this.style, (Object) null))
      return;
    this.style.딟(outlineGradient, this);
  }

  public float GetOutlineNormalOffset() => Object.op_Equality((Object) this.style, (Object) null) ? this.outlineNormalOffset : this.style.땃();

  public void SetOutlineNormalOffset(float outlineNormalOffset)
  {
    this.outlineNormalOffset = outlineNormalOffset;
    if (!Object.op_Inequality((Object) this.style, (Object) null))
      return;
    this.style.딟(outlineNormalOffset, this);
  }

  public void SetCorners(RageSpline.딦 corners)
  {
    this.corners = corners;
    if (!Object.op_Inequality((Object) this.style, (Object) null))
      return;
    this.style.딟(corners, this);
  }

  public RageSpline.딦 GetCorners() => Object.op_Equality((Object) this.style, (Object) null) ? this.corners : this.style.딶();

  public void SetFill(RageSpline.땤 fill)
  {
    this.fill = fill;
    if (!Object.op_Inequality((Object) this.style, (Object) null))
      return;
    this.style.딟(fill, this);
  }

  public RageSpline.땤 GetFill() => Object.op_Equality((Object) this.style, (Object) null) ? this.fill : this.style.땓();

  public void SetFillColor1(Color color)
  {
    this.fillColor1 = color;
    if (!Object.op_Inequality((Object) this.style, (Object) null))
      return;
    this.style.딧(color, this);
  }

  public Color GetFillColor1() => Object.op_Equality((Object) this.style, (Object) null) ? this.fillColor1 : this.style.땺();

  public void SetFillColor2(Color color)
  {
    this.fillColor2 = color;
    if (!Object.op_Inequality((Object) this.style, (Object) null))
      return;
    this.style.딢(color, this);
  }

  public Color GetFillColor2() => Object.op_Equality((Object) this.style, (Object) null) ? this.fillColor2 : this.style.땥();

  public void SetLandscapeBottomDepth(float landscapeBottomDepth)
  {
    this.landscapeBottomDepth = landscapeBottomDepth;
    if (!Object.op_Inequality((Object) this.style, (Object) null))
      return;
    this.style.땄(landscapeBottomDepth, this);
  }

  public float GetLandscapeBottomDepth() => Object.op_Equality((Object) this.style, (Object) null) ? this.landscapeBottomDepth : this.style.딝();

  public void SetLandscapeOutlineAlign(float landscapeOutlineAlign)
  {
    landscapeOutlineAlign = Mathf.Clamp01(landscapeOutlineAlign);
    this.landscapeOutlineAlign = landscapeOutlineAlign;
    if (!Object.op_Inequality((Object) this.style, (Object) null))
      return;
    this.style.딧(landscapeOutlineAlign, this);
  }

  public float GetLandscapeOutlineAlign() => Object.op_Equality((Object) this.style, (Object) null) ? this.landscapeOutlineAlign : this.style.떎();

  public void SetTexturing1(RageSpline.땽 texturing)
  {
    this.UVMapping1 = texturing;
    if (!Object.op_Inequality((Object) this.style, (Object) null))
      return;
    this.style.딟(texturing, this);
  }

  public RageSpline.땽 GetTexturing1() => Object.op_Equality((Object) this.style, (Object) null) ? this.UVMapping1 : this.style.떂();

  public void SetTexturing2(RageSpline.땽 texturing)
  {
    this.UVMapping2 = texturing;
    if (!Object.op_Inequality((Object) this.style, (Object) null))
      return;
    this.style.땄(texturing, this);
  }

  public RageSpline.땽 GetTexturing2() => Object.op_Equality((Object) this.style, (Object) null) ? this.UVMapping2 : this.style.땭();

  public void SetGradientOffset(Vector2 offset)
  {
    this.gradientOffset = offset;
    if (!Object.op_Inequality((Object) this.style, (Object) null) || this.styleLocalGradientPositioning)
      return;
    this.style.딟(offset, this);
  }

  public Vector2 GetGradientOffset() => Object.op_Equality((Object) this.style, (Object) null) || this.styleLocalGradientPositioning ? this.gradientOffset : this.style.딦();

  public void SetGradientAngleDeg(float angle)
  {
    this.gradientAngle = Mathf.Clamp(angle, 0.0f, 360f);
    if (!Object.op_Inequality((Object) this.style, (Object) null) || this.styleLocalGradientPositioning)
      return;
    this.style.딢(angle, this);
  }

  public float GetGradientAngleDeg() => Object.op_Equality((Object) this.style, (Object) null) || this.styleLocalGradientPositioning ? this.gradientAngle : this.style.땤();

  public void SetGradientScaleInv(float scale)
  {
    this.gradientScale = Mathf.Clamp(scale, 1E-05f, 100f);
    if (!Object.op_Inequality((Object) this.style, (Object) null) || this.styleLocalGradientPositioning)
      return;
    this.style.땃(scale, this);
  }

  public float GetGradientScaleInv() => Object.op_Equality((Object) this.style, (Object) null) || this.styleLocalGradientPositioning ? this.gradientScale : this.style.땽();

  public void SetTextureOffset(Vector2 offset)
  {
    this.textureOffset = offset;
    if (!Object.op_Inequality((Object) this.style, (Object) null) || this.styleLocalTexturePositioning)
      return;
    this.style.땄(offset, this);
  }

  public Vector2 GetTextureOffset() => Object.op_Equality((Object) this.style, (Object) null) || this.styleLocalTexturePositioning ? this.textureOffset : this.style.땋();

  public void SetTextureAngleDeg(float angle)
  {
    this.textureAngle = Mathf.Clamp(angle, 0.0f, 360f);
    if (!Object.op_Inequality((Object) this.style, (Object) null) || this.styleLocalTexturePositioning)
      return;
    this.style.딶(angle, this);
  }

  public float GetTextureAngleDeg() => Object.op_Equality((Object) this.style, (Object) null) || this.styleLocalTexturePositioning ? this.textureAngle : this.style.땲();

  public void SetTextureScaleInv(float scale)
  {
    this.textureScale = Mathf.Clamp(scale, 1E-05f, 100f);
    if (!Object.op_Inequality((Object) this.style, (Object) null) || this.styleLocalTexturePositioning)
      return;
    this.style.땓(scale, this);
  }

  public float GetTextureScaleInv() => Object.op_Equality((Object) this.style, (Object) null) || this.styleLocalTexturePositioning ? this.textureScale : this.style.떏();

  public void SetTextureOffset2(Vector2 offset)
  {
    this.textureOffset2 = offset;
    if (!Object.op_Inequality((Object) this.style, (Object) null) || this.styleLocalTexturePositioning)
      return;
    this.style.딧(offset, this);
  }

  public Vector2 GetTextureOffset2() => Object.op_Equality((Object) this.style, (Object) null) || this.styleLocalTexturePositioning ? this.textureOffset2 : this.style.땼();

  public void SetTextureAngle2Deg(float angle)
  {
    this.textureAngle2 = Mathf.Clamp(angle, 0.0f, 360f);
    if (!Object.op_Inequality((Object) this.style, (Object) null) || this.styleLocalTexturePositioning)
      return;
    this.style.땺(angle, this);
  }

  public float GetTextureAngle2Deg() => Object.op_Equality((Object) this.style, (Object) null) || this.styleLocalTexturePositioning ? this.textureAngle2 : this.style.땢();

  public void SetTextureScale2Inv(float scale)
  {
    this.textureScale2 = Mathf.Clamp(scale, 1E-05f, 100f);
    if (!Object.op_Inequality((Object) this.style, (Object) null) || this.styleLocalTexturePositioning)
      return;
    this.style.땥(scale, this);
  }

  public float GetTextureScale2Inv() => Object.op_Equality((Object) this.style, (Object) null) || this.styleLocalTexturePositioning ? this.textureScale2 : this.style.딷();

  public void SetEmboss(RageSpline.땋 emboss)
  {
    this.emboss = emboss;
    if (!Object.op_Inequality((Object) this.style, (Object) null))
      return;
    this.style.딟(emboss, this);
  }

  public RageSpline.땋 GetEmboss() => Object.op_Equality((Object) this.style, (Object) null) ? this.emboss : this.style.떁();

  public void SetEmbossColor1(Color color)
  {
    this.embossColor1 = color;
    if (!Object.op_Inequality((Object) this.style, (Object) null))
      return;
    this.style.땃(color, this);
  }

  public Color GetEmbossColor1() => Object.op_Equality((Object) this.style, (Object) null) ? this.embossColor1 : this.style.땟();

  public void SetEmbossColor2(Color color)
  {
    this.embossColor2 = color;
    if (!Object.op_Inequality((Object) this.style, (Object) null))
      return;
    this.style.딶(color, this);
  }

  public Color GetEmbossColor2() => Object.op_Equality((Object) this.style, (Object) null) ? this.embossColor2 : this.style.땂();

  public void SetEmbossAngleDeg(float angle)
  {
    this.embossAngle = Mathf.Clamp(angle, 0.0f, 360f);
    if (!Object.op_Inequality((Object) this.style, (Object) null) || this.styleLocalEmbossPositioning)
      return;
    this.style.딝(angle, this);
  }

  public float GetEmbossAngleDeg() => Object.op_Equality((Object) this.style, (Object) null) || this.styleLocalEmbossPositioning ? this.embossAngle : this.style.딱();

  public void SetEmbossOffset(float offset)
  {
    this.embossOffset = offset;
    if (!Object.op_Inequality((Object) this.style, (Object) null) || this.styleLocalEmbossPositioning)
      return;
    this.style.떎(offset, this);
  }

  public float GetEmbossOffset() => Object.op_Equality((Object) this.style, (Object) null) || this.styleLocalEmbossPositioning ? this.embossOffset : this.style.때();

  public void SetEmbossSize(float size)
  {
    this.embossSize = Mathf.Clamp(size, 0.00061f, 1000f);
    if (!Object.op_Inequality((Object) this.style, (Object) null) || this.styleLocalEmbossPositioning)
      return;
    this.style.떂(size, this);
  }

  public float GetEmbossSize() => Object.op_Equality((Object) this.style, (Object) null) ? this.embossSize : this.style.땩();

  public void SetEmbossSmoothness(float smoothness)
  {
    this.embossCurveSmoothness = Mathf.Clamp(smoothness, 0.0f, 100f);
    if (!Object.op_Inequality((Object) this.style, (Object) null))
      return;
    this.style.땭(smoothness, this);
  }

  public float GetEmbossSmoothness() => Object.op_Equality((Object) this.style, (Object) null) ? this.embossCurveSmoothness : this.style.땠();

  public void SetPhysics(RageSpline.땲 physics)
  {
    this.physics = physics;
    if (!Object.op_Inequality((Object) this.style, (Object) null))
      return;
    this.style.딟(physics, this);
  }

  public RageSpline.땲 GetPhysics() => Object.op_Equality((Object) this.style, (Object) null) ? this.physics : this.style.땴();

  public void SetCreatePhysicsInEditor(bool createInEditor)
  {
    this.createPhysicsInEditor = createInEditor;
    if (!Object.op_Inequality((Object) this.style, (Object) null))
      return;
    this.style.딟(createInEditor, this);
  }

  public bool GetCreatePhysicsInEditor() => Object.op_Equality((Object) this.style, (Object) null) ? this.createPhysicsInEditor : this.style.딗();

  public void SetPhysicsMaterial(PhysicMaterial physicsMaterial)
  {
    this.physicsMaterial = physicsMaterial;
    if (!Object.op_Inequality((Object) this.style, (Object) null))
      return;
    this.style.딟(physicsMaterial, this);
  }

  public PhysicMaterial GetPhysicsMaterial() => Object.op_Equality((Object) this.style, (Object) null) ? this.physicsMaterial : this.style.땳();

  public void SetVertexCount(int count)
  {
    if (this.lowQualityRender)
      return;
    int num1 = 0;
    int pointCount = this.GetPointCount();
    if (this.outline == RageSpline.떂.딧 && this.fill == RageSpline.땤.딟)
      num1 = -1;
    int num2 = this.mod(count, pointCount + num1) != 0 ? (this.mod(count, pointCount + num1) < (pointCount + num1) / 2 ? count - this.mod(count, pointCount + num1) : count + (pointCount + num1 - this.mod(count, pointCount + num1))) : count;
    if (num2 < pointCount + num1)
      num2 = pointCount + num1;
    this.vertexCount = num2;
    this._vertexDensity = num2 / pointCount;
    if (!Object.op_Inequality((Object) this.style, (Object) null) || this.styleLocalVertexCount)
      return;
    if (count <= 0)
      count = 1;
    this.style.딟(count, this);
  }

  public int GetVertexCount()
  {
    if (Object.op_Equality((Object) this.style, (Object) null) || this.lowQualityRender || this.styleLocalVertexCount)
    {
      if (this.lowQualityRender)
        return 128;
      return this.vertexCount >= this.GetPointCount() || this.outline == RageSpline.떂.딧 && this.fill == RageSpline.땤.딟 ? this.vertexCount : this.GetPointCount();
    }
    return this.mod(this.style.땻(), this.GetPointCount()) == 0 ? this.style.땻() : this.style.땻() + (this.GetPointCount() - this.mod(this.style.땻(), this.GetPointCount()));
  }

  public void SetPhysicsColliderCount(int count)
  {
    this.physicsColliderCount = count;
    if (!Object.op_Inequality((Object) this.style, (Object) null) || this.styleLocalPhysicsColliderCount)
      return;
    this.style.땄(count, this);
  }

  public int GetPhysicsColliderCount()
  {
    if (!Object.op_Equality((Object) this.style, (Object) null) && !this.styleLocalPhysicsColliderCount)
      return this.style.딥();
    return this.LockPhysicsToAppearence ? this.vertexCount : this.physicsColliderCount;
  }

  public void SetCreateConvexMeshCollider(bool createConvexMeshCollider)
  {
    this.createConvexMeshCollider = createConvexMeshCollider;
    if (!Object.op_Inequality((Object) this.style, (Object) null))
      return;
    this.style.땄(createConvexMeshCollider, this);
  }

  public bool GetCreateConvexMeshCollider() => Object.op_Equality((Object) this.style, (Object) null) ? this.createConvexMeshCollider : this.style.떓();

  public void SetPhysicsZDepth(float depth)
  {
    this.colliderZDepth = Mathf.Clamp(depth, 0.0001f, 10000f);
    if (!Object.op_Inequality((Object) this.style, (Object) null))
      return;
    this.style.딦(depth, this);
  }

  public float GetPhysicsZDepth() => Object.op_Equality((Object) this.style, (Object) null) ? this.colliderZDepth : this.style.딛();

  public void SetPhysicsNormalOffset(float offset)
  {
    this.colliderNormalOffset = Mathf.Clamp(offset, -1000f, 1000f);
    if (!Object.op_Inequality((Object) this.style, (Object) null))
      return;
    this.style.땤(offset, this);
  }

  public float GetPhysicsNormalOffset() => Object.op_Equality((Object) this.style, (Object) null) ? this.colliderNormalOffset : this.style.딣();

  public void SetBoxColliderDepth(float depth)
  {
    this.boxColliderDepth = Mathf.Clamp(depth, -1000f, 1000f);
    if (!Object.op_Inequality((Object) this.style, (Object) null))
      return;
    this.style.땽(depth, this);
  }

  public float GetBoxColliderDepth() => Object.op_Equality((Object) this.style, (Object) null) ? this.boxColliderDepth : this.style.땔();

  public void SetAntialiasingWidth(float width)
  {
    this.antiAliasingWidth = Mathf.Clamp(width, 0.0f, 1000f);
    if (!Object.op_Inequality((Object) this.style, (Object) null) || this.styleLocalAntialiasing)
      return;
    this.style.땋(width, this);
  }

  public float GetAntialiasingWidth() => Object.op_Equality((Object) this.style, (Object) null) || this.styleLocalAntialiasing ? this.antiAliasingWidth : this.style.땁();

  public void SetOutlineWidth(float width)
  {
    this.OutlineWidth = Mathf.Clamp(width, 0.0001f, 1000f);
    if (!Object.op_Inequality((Object) this.style, (Object) null))
      return;
    this.style.땲(width, this);
  }

  public float GetOutlineWidth() => Object.op_Equality((Object) this.style, (Object) null) ? this.OutlineWidth : this.style.땷();

  public void SetOutlineTexturingScaleInv(float scale)
  {
    this.outlineTexturingScale = Mathf.Clamp(scale, 1f / 1000f, 1000f);
    if (!Object.op_Inequality((Object) this.style, (Object) null))
      return;
    this.style.떏(scale, this);
  }

  public float GetOutlineTexturingScaleInv() => Object.op_Equality((Object) this.style, (Object) null) ? this.outlineTexturingScale : this.style.딸();

  public void SetOptimizeAngle(float angle)
  {
    this.optimizeAngle = angle;
    if (!Object.op_Inequality((Object) this.style, (Object) null))
      return;
    this.style.땼(angle, this);
  }

  public float GetOptimizeAngle() => Object.op_Equality((Object) this.style, (Object) null) ? this.optimizeAngle : this.style.땘();

  public void SetOptimize(bool optimize)
  {
    this.optimize = optimize;
    if (!Object.op_Inequality((Object) this.style, (Object) null))
      return;
    this.style.딧(optimize, this);
  }

  public bool GetOptimize() => Object.op_Equality((Object) this.style, (Object) null) ? this.optimize : this.style.떔();

  public void SetStyle(RageSplineStyle style) => this.style = style;

  public RageSplineStyle GetStyle() => this.style;

  [ContextMenu("Refresh all RageSplines")]
  public void RefreshAllRageSplines()
  {
    foreach (RageSpline rageSpline in Object.FindObjectsOfType(typeof (RageSpline)) as RageSpline[])
      rageSpline.RefreshMeshInEditor(true, true, true);
  }

  [ContextMenu("All RageSplines to 3D")]
  public void AllRageSplinesTo3D()
  {
    foreach (RageSpline rageSpline in Object.FindObjectsOfType(typeof (RageSpline)) as RageSpline[])
      rageSpline.set_PerspectiveMode(true);
  }

  [ContextMenu("All RageSplines to 2D")]
  public void AllRageSplinesTo2D()
  {
    foreach (RageSpline rageSpline in Object.FindObjectsOfType(typeof (RageSpline)) as RageSpline[])
      rageSpline.set_PerspectiveMode(false);
  }

  public void UpdateFarseerPhysics()
  {
    FSConcaveShapeComponent concaveShapeComponent = ((Component) this).GetComponent<FSConcaveShapeComponent>();
    if (Object.op_Equality((Object) concaveShapeComponent, (Object) null))
      concaveShapeComponent = ((Component) this).gameObject.AddComponent<FSConcaveShapeComponent>();
    if (Object.op_Equality((Object) ((Component) this).GetComponent<FSBodyComponent>(), (Object) null))
      ((Component) this).gameObject.AddComponent<FSBodyComponent>();
    concaveShapeComponent.PointInput = 땺.딳.딟;
    List<Vector2> vector2List = new List<Vector2>();
    if (this.FarseerPhysicsPointsOnly)
    {
      for (int index = 0; index < this.GetPointCount(); ++index)
        vector2List.Add(Vector2.op_Implicit(this.GetPosition(index)));
    }
    else
    {
      int num = !this.LockPhysicsToAppearence ? this.GetPhysicsColliderCount() : this.GetVertexCount();
      for (int index = 0; index < num; ++index)
      {
        float splinePosition = (float) index / (float) num;
        Vector3 normal = this.GetNormal(splinePosition);
        vector2List.Add(Vector2.op_Implicit(Vector3.op_Addition(this.GetPosition(splinePosition), Vector3.op_Multiply(normal, this.GetPhysicsNormalOffset()))));
      }
    }
    concaveShapeComponent.PointsCoordinates = vector2List.ToArray();
    concaveShapeComponent.ConvertToConvex();
  }

  public float GetTriangleCount() => (float) ((Component) this).GetComponent<MeshFilter>().sharedMesh.triangles.Length / 3f;

  public enum 떂
  {
    딟,
    땄,
    딧,
  }

  public enum 땭
  {
    딟,
    땄,
    딧,
  }

  public enum 딦
  {
    딟,
    땄,
  }

  public enum 땤
  {
    딟,
    땄,
    딧,
    딢,
  }

  public enum 땽
  {
    딟,
    땄,
    딧,
  }

  public enum 땋
  {
    딟,
    땄,
    딧,
  }

  public enum 땲
  {
    딟,
    땄,
    딧,
    딢,
    땃,
  }

  public enum 떏
  {
    딟,
    땄,
    딧,
  }

  public struct 땼
  {
    public Vector3 딟;
    public Vector2 딟;
    public Vector2 땄;
    public Color 딟;
    public Vector3 땄;
    public float 딟;
    public float 땄;
    public RageSplinePoint 딟;
    public RageSplinePoint 땄;
  }
}
