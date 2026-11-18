// Decompiled with JetBrains decompiler
// Type: RageGroup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using 땺;

[AddComponentMenu("RageTools/Rage Group")]
[ExecuteInEditMode]
public class RageGroup : MonoBehaviour
{
  public bool Tweak;
  [SerializeField]
  private List<RageGroupElement> _list;
  [SerializeField]
  private bool _visible = true;
  public List<RageGroup> ExcludedGroups;
  public List<RageSplineStyle> Styles;
  public List<string> StyleNames;
  public float AntiAlias = 1f;
  public int Density = 3;
  [SerializeField]
  private float _currentOpacity = 1f;
  public float AaMult = 1f;
  public float DensityMult = 1f;
  [SerializeField]
  private float _currentOpacityMult = 1f;
  public bool Proportional = true;
  public Vector3[] Boundaries;
  public Vector3 Center;
  public bool GroupExclusion;
  public bool UseStyles;
  public int UpdateStep = 8;
  public bool Draft;
  private bool 딟;
  private int 딟;
  private bool 땄;
  private bool 딧;
  [SerializeField]
  private float _currentAa;
  [SerializeField]
  private int _currentDensity;
  [SerializeField]
  private float _currentAaMult;
  [SerializeField]
  private float _currentDensityMult;

  [SpecialName]
  public List<RageGroupElement> get_List()
  {
    if (this._list != null)
      return this._list;
    this._list = new List<RageGroupElement>();
    return this._list;
  }

  [SpecialName]
  public void set_List(List<RageGroupElement> value) => this._list = value;

  [SpecialName]
  public bool get_Visible() => this._visible;

  [SpecialName]
  public void set_Visible(bool value)
  {
    if (this._visible == value)
      return;
    foreach (RageGroupElement rageGroupElement in this.get_List())
      rageGroupElement.딟(value);
    this.QueueRefresh();
    this._visible = value;
  }

  [SpecialName]
  public float get_Opacity() => this._currentOpacity;

  [SpecialName]
  public void set_Opacity(float value)
  {
    if (Mathf.Approximately(this._currentOpacity, value))
      return;
    this._currentOpacity = value;
    this.DoUpdateOpacity();
    this.QueueRefresh();
  }

  [SpecialName]
  public float get_OpacityMult() => this._currentOpacityMult;

  [SpecialName]
  public void set_OpacityMult(float value)
  {
    if (Mathf.Approximately(this._currentOpacityMult, value))
      return;
    this._currentOpacityMult = value;
    this.DoUpdateOpacity();
    this.QueueRefresh();
  }

  [SpecialName]
  public bool get_IsRefreshing() => this.딟;

  public void ApplyStyle()
  {
    if (this.StyleNames.Count <= 0)
      return;
    this.ApplyStyle(this.StyleNames, this.Styles);
  }

  public void ApplyStyle(List<string> names, List<RageSplineStyle> styles)
  {
    if (this.get_List() == null)
      return;
    for (int index = 0; index < names.Count; ++index)
    {
      foreach (RageGroupElement rageGroupElement in this.get_List())
      {
        if (!Object.op_Equality((Object) rageGroupElement.Spline, (Object) null) && ((Object) rageGroupElement.Spline.딦()).name.Contains(names[index]))
        {
          RageSpline rageSpline = rageGroupElement.Spline.땟();
          rageSpline.SetStyle((RageSplineStyle) null);
          rageSpline.SetTexturing1(styles[index].떂());
          rageSpline.SetTexturing2(styles[index].땭());
          rageSpline.SetTextureOffset(styles[index].땋());
          rageSpline.SetTextureOffset2(styles[index].땼());
          rageSpline.SetTextureAngleDeg(styles[index].땲());
          rageSpline.SetTextureAngle2Deg(styles[index].땢());
          rageSpline.SetTextureScale2Inv(styles[index].딷());
          rageSpline.SetTextureScaleInv(styles[index].떏());
          rageSpline.SetFill(styles[index].땓());
          rageSpline.SetFillColor1(styles[index].땺());
          rageSpline.SetFillColor2(styles[index].땥());
          rageSpline.SetGradientAngleDeg(styles[index].땤());
          rageSpline.SetGradientOffset(styles[index].딦());
          rageSpline.SetGradientScaleInv(styles[index].땽());
          rageSpline.SetOutline(styles[index].딟());
          rageSpline.SetOutlineColor1(styles[index].땄());
          rageSpline.SetOutlineColor2(styles[index].딧());
          rageSpline.SetOutlineWidth(styles[index].땷());
          rageSpline.SetOutlineGradient(styles[index].딢());
          rageSpline.SetOutlineNormalOffset(styles[index].땃());
          rageSpline.SetOutlineTexturingScaleInv(styles[index].딸());
          rageSpline.SetCorners(styles[index].딶());
          rageSpline.SetOptimize(styles[index].떔());
          rageSpline.SetOptimizeAngle(styles[index].땘());
          rageSpline.RefreshMesh();
        }
      }
    }
  }

  public void ApplyStylePhysics() => this.ApplyStylePhysics(this.StyleNames, this.Styles);

  public void ApplyStylePhysics(List<string> names, List<RageSplineStyle> styles)
  {
    if (this.get_List() == null)
      return;
    for (int index = 0; index < names.Count; ++index)
    {
      foreach (RageGroupElement rageGroupElement in this.get_List())
      {
        if (!Object.op_Equality((Object) rageGroupElement.Spline, (Object) null) && ((Object) rageGroupElement.Spline.딦()).name.Contains(names[index]))
        {
          RageSpline rageSpline = (RageSpline) rageGroupElement.Spline.땤();
          rageSpline.SetPhysics(styles[index].땴());
          rageSpline.SetPhysicsMaterial(styles[index].땳());
          rageSpline.SetPhysicsColliderCount(styles[index].딥());
          rageSpline.SetPhysicsNormalOffset(styles[index].딣());
          rageSpline.SetPhysicsZDepth(styles[index].딛());
          rageSpline.SetCreatePhysicsInEditor(styles[index].딗());
          rageSpline.RefreshMesh();
        }
      }
    }
  }

  public void Awake()
  {
    if (this.get_List() != null && this.get_List().Count != 0)
      return;
    this.UpdatePathList();
  }

  public void Update()
  {
    if (this.Tweak)
      this.TweakCheck();
    this.ProgressiveUpdateCheck();
  }

  private void ProgressiveUpdateCheck()
  {
    if (this.딟)
    {
      this.ProgressiveUpdater();
    }
    else
    {
      if (!this.딧)
        return;
      this.딧 = false;
      this.딟 = true;
      this.ProgressiveUpdater();
    }
  }

  private void TweakCheck()
  {
    if (this.Proportional)
    {
      if (!Mathf.Approximately(this.AaMult, this._currentAaMult))
        this.DoUpdateAa();
      if (!Mathf.Approximately(this.get_OpacityMult(), this._currentOpacityMult))
        this.DoUpdateOpacity();
      if (!Mathf.Approximately(this.DensityMult, this._currentDensityMult))
        this.DoUpdateDensity();
      this.QueueRefresh();
    }
    else
    {
      if (!Mathf.Approximately(this.AntiAlias, this._currentAa))
        this.DoUpdateAa();
      if (!Mathf.Approximately(this.get_Opacity(), this._currentOpacity))
        this.DoUpdateOpacity();
      if (!Mathf.Approximately((float) this.Density, (float) this._currentDensity))
        this.DoUpdateDensity();
      this.QueueRefresh();
    }
  }

  private void DoUpdateOpacity()
  {
    if (this.Proportional)
    {
      this.get_List().땄(this.get_OpacityMult(), true, false);
      this._currentOpacityMult = this.get_OpacityMult();
    }
    else
    {
      this.get_List().땄(this.get_Opacity(), false, false);
      this._currentOpacity = this.get_Opacity();
    }
  }

  private void DoUpdateAa()
  {
    if (this.Proportional)
    {
      this.get_List().딟(this.AaMult, true, false);
      this._currentAaMult = this.AaMult;
    }
    else
    {
      this.get_List().딟(this.AntiAlias, false, false);
      this._currentAa = this.AntiAlias;
    }
  }

  private void DoUpdateDensity()
  {
    if (this.Proportional)
    {
      this.DensityMult = Mathf.Max(0.1f, this.DensityMult);
      this.get_List().딟(this.DensityMult, 100);
      this._currentDensityMult = this.DensityMult;
    }
    else
    {
      this.get_List().딟(this.Density);
      this._currentDensity = this.Density;
    }
  }

  private static bool 딟([In] Object obj0) => Object.op_Equality(obj0, (Object) null);

  public void AddExcludedGroupIfPossible(RageGroup group)
  {
    if (group.ExcludedGroups.Contains(this))
      return;
    this.ExcludedGroups.Add(group);
  }

  public void AddStyle(RageSplineStyle style)
  {
    this.Styles.Add(style);
    this.StyleNames.Add(string.Empty);
  }

  public void UpdatePathList()
  {
    if (this.get_List() == null)
      this.set_List(new List<RageGroupElement>());
    if (this.ExcludedGroups == null)
      this.ExcludedGroups = new List<RageGroup>();
    this.ExcludedGroups.RemoveAll(new Predicate<RageGroup>(RageGroup.딟));
    List<long> longList = new List<long>();
    if (this.GroupExclusion)
    {
      foreach (RageGroup excludedGroup in this.ExcludedGroups)
      {
        excludedGroup.UpdatePathList();
        foreach (RageGroupElement rageGroupElement in excludedGroup.get_List())
          longList.Add(rageGroupElement.Spline.땽());
      }
    }
    딥[] 딥Array = 땺.땔.딟(((Component) this).gameObject);
    if (딥Array.Length == 0)
    {
      this.get_List().Clear();
    }
    else
    {
      List<RageGroupElement> rageGroupElementList = this.get_List();
      this.set_List(new List<RageGroupElement>());
      foreach (RageSplineAdapter rageSplineAdapter in 딥Array)
      {
        if (!longList.Contains(rageSplineAdapter.땽()))
        {
          int length = rageSplineAdapter.딷();
          RageGroupElement instance;
          if (rageGroupElementList.Count > 0)
          {
            instance = rageGroupElementList[0];
            rageGroupElementList.RemoveAt(0);
          }
          else
            instance = ScriptableObject.CreateInstance<RageGroupElement>();
          if (!Object.op_Equality((Object) instance, (Object) null))
          {
            instance.Spline = rageSplineAdapter;
            instance.DefaultAa = rageSplineAdapter.딝().땃();
            instance.DefaultDensity = rageSplineAdapter.땲();
            instance.DefaultFillColor1 = rageSplineAdapter.땄();
            instance.DefaultFillColor2 = rageSplineAdapter.땟().GetFillColor2();
            instance.DefaultOutlineColor = rageSplineAdapter.땓();
            instance.GroupPointCache = new RageGroupPointCache[length];
            instance.GradientOffsetCache = rageSplineAdapter.딦().transform.TransformPoint(Vector2.op_Implicit(rageSplineAdapter.땥().딟()));
            instance.TextureOffsetCache = Vector2.op_Implicit(rageSplineAdapter.딦().transform.TransformPoint(Vector2.op_Implicit(rageSplineAdapter.땟().GetTextureOffset())));
            instance.TextureOffsetCache2 = Vector2.op_Implicit(rageSplineAdapter.딦().transform.TransformPoint(Vector2.op_Implicit(rageSplineAdapter.땟().GetTextureOffset2())));
            instance.TextureScaleCache = rageSplineAdapter.땟().GetTextureScaleInv();
            instance.TextureScaleCache2 = rageSplineAdapter.땟().GetTextureScale2Inv();
            instance.TextureAngleCache = rageSplineAdapter.땟().GetTextureAngleDeg();
            instance.TextureAngleCache2 = rageSplineAdapter.땟().GetTextureAngle2Deg();
            instance.PositionCache = rageSplineAdapter.딦().transform.position;
            instance.RotationCache = rageSplineAdapter.딦().transform.rotation;
            instance.ScaleCache = rageSplineAdapter.딦().transform.lossyScale;
            if (Object.op_Equality((Object) instance.MeshRenderer, (Object) null))
              instance.MeshRenderer = rageSplineAdapter.딦().GetComponent<MeshRenderer>();
            RageGroup.딟((딥) rageSplineAdapter, instance, length);
            this.get_List().Add(instance);
          }
        }
      }
      rageGroupElementList.Clear();
      this.UpdateCenter();
      this.AaMult = 1f;
      this.DensityMult = 1f;
    }
  }

  public void UpdateCenter()
  {
    if (this.get_List().Count == 0)
      return;
    RageSpline firstValidSpline = this.FindFirstValidSpline();
    if (Object.op_Equality((Object) firstValidSpline, (Object) null))
      return;
    Vector3 positionWorldSpace = firstValidSpline.GetPositionWorldSpace(0);
    this.Boundaries = new Vector3[2];
    this.Boundaries[0] = this.Boundaries[1] = new Vector3((float) positionWorldSpace.x, (float) positionWorldSpace.y, (float) positionWorldSpace.z);
    foreach (RageGroupElement rageGroupElement in this.get_List())
    {
      if (Object.op_Inequality((Object) rageGroupElement.Spline.땟(), (Object) null))
        this.Boundaries = this.CheckBoundaries((딥) rageGroupElement.Spline, this.Boundaries);
    }
    this.Center = new Vector3((float) ((this.Boundaries[0].x + this.Boundaries[1].x) / 2.0), (float) ((this.Boundaries[0].y + this.Boundaries[1].y) / 2.0), (float) ((this.Boundaries[0].z + this.Boundaries[1].z) / 2.0));
  }

  private RageSpline FindFirstValidSpline()
  {
    RageSpline rageSpline = (RageSpline) null;
    foreach (RageGroupElement rageGroupElement in this.get_List())
    {
      if (!Object.op_Equality((Object) rageGroupElement.Spline.땟(), (Object) null))
        rageSpline = rageGroupElement.Spline.땟();
    }
    return rageSpline;
  }

  private Vector3[] CheckBoundaries(딥 path, Vector3[] boundaries)
  {
    float num1 = (float) boundaries[0].x;
    float num2 = (float) boundaries[0].y;
    float num3 = (float) boundaries[1].x;
    float num4 = (float) boundaries[1].y;
    for (int index = 0; index < path.땟().GetPointCount(); ++index)
    {
      Vector3 positionWorldSpace = path.땟().GetPositionWorldSpace(index);
      num1 = Mathf.Min((float) positionWorldSpace.x, num1);
      num2 = Mathf.Min((float) positionWorldSpace.y, num2);
      num3 = Mathf.Max((float) positionWorldSpace.x, num3);
      num4 = Mathf.Max((float) positionWorldSpace.y, num4);
    }
    float num5 = Mathf.Min((float) ((Component) path.땟()).transform.position.z, (float) boundaries[0].z);
    float num6 = Mathf.Max((float) ((Component) path.땟()).transform.position.z, (float) boundaries[1].z);
    boundaries[0] = new Vector3(num1, num2, num5);
    boundaries[1] = new Vector3(num3, num4, num6);
    return boundaries;
  }

  private static void 딟([In] 딥 obj0, [In] RageGroupElement obj1, [In] int obj2)
  {
    for (int index = 0; index < obj2; ++index)
    {
      obj1.GroupPointCache[index] = new RageGroupPointCache();
      땺.딛 딛 = obj0.딧(index);
      obj1.GroupPointCache[index].PointPos = 딛.땄();
      obj1.GroupPointCache[index].InCtrlPos = 딛.딧();
      obj1.GroupPointCache[index].OutCtrlPos = 딛.딢();
    }
  }

  public void Reset()
  {
    if (this.get_List() == null)
      return;
    this._currentAaMult = this.AaMult = 1f;
    this._currentDensityMult = this.DensityMult = 1f;
    this.Proportional = true;
    this.Tweak = false;
    this.DoUpdateDensity();
    this.DoUpdateAa();
    foreach (RageGroupElement rageGroupElement in this.get_List())
      rageGroupElement.Spline.땟().RefreshMeshInEditor(true, true, true);
  }

  public void CheckForEdgetune()
  {
    RageEdgetune component = ((Component) this).GetComponent<RageEdgetune>();
    if (Object.op_Equality((Object) component, (Object) null) || !component.On)
      return;
    component.On = false;
    Debug.LogWarning((object) "Edgetune disabled to prevent conflict with Group Tweak.");
  }

  private void ProgressiveUpdater() => this.ProgressiveUpdater(this.UpdateStep);

  [ExecuteInEditMode]
  private void ProgressiveUpdater(int updateStep)
  {
    bool flag = false;
    int num = this.딟 + updateStep;
    if (num > this.get_List().Count || updateStep <= 0)
    {
      num = this.get_List().Count;
      flag = true;
    }
    while (this.딟 < num)
    {
      RageSplineAdapter spline = this.get_List()[this.딟].Spline;
      ++this.딟;
      if (!Object.op_Equality((Object) spline, (Object) null) && (!this.땄 || spline.땢()))
      {
        RageGroup.딟((딥) spline, this.Draft);
        spline.딶(false);
      }
    }
    if (!flag)
      return;
    this.딟 = 0;
    this.딟 = false;
  }

  private static void 딟([In] 딥 obj0, [In] bool obj1)
  {
    if (obj1)
      obj0.딟(false, true, false, true);
    else
      obj0.땃(false);
  }

  [ContextMenu("UV Fit")]
  public void UvFit() => this.RageGroupUvFit(this);

  [ContextMenu("Refresh Layers")]
  public void RefreshLayers()
  {
    foreach (RageGroupElement rageGroupElement in this.get_List())
    {
      RageLayer component = rageGroupElement.Spline.딦().GetComponent<RageLayer>();
      if (!Object.op_Equality((Object) component, (Object) null))
        component.SetMaterialRenderQueue();
    }
    Debug.LogWarning((object) "RageTools: Please disregard error messages above.");
  }

  [ContextMenu("Cleanup Names")]
  public void CleanupExtensions()
  {
    ((Component) this).gameObject.딟();
    this.UpdatePathList();
  }

  public void RageGroupUvFit(RageGroup group)
  {
    this.UpdateCenter();
    Vector3 boundary1 = group.Boundaries[0];
    Vector3 boundary2 = group.Boundaries[1];
    foreach (RageGroupElement rageGroupElement in group.get_List())
    {
      Vector3 vector3 = Vector3.op_Subtraction(group.Center, ((Component) rageGroupElement.Spline.땟()).gameObject.transform.position);
      rageGroupElement.Spline.땟().SetTextureOffset(Vector2.op_Implicit(vector3));
      rageGroupElement.Spline.땟().SetTextureOffset2(Vector2.op_Implicit(vector3));
      Vector2 vector2 = Vector2.op_Subtraction(new Vector2(0.0f, (float) boundary2.y), new Vector2(0.0f, (float) boundary1.y));
      float scale = (float) (1.0 / (double) ((Vector2) ref vector2).magnitude);
      rageGroupElement.Spline.땟().SetTextureScaleInv(scale);
      rageGroupElement.Spline.땟().SetTextureScale2Inv(scale);
      rageGroupElement.Spline.땟().SetTextureAngleDeg(0.0f);
      rageGroupElement.Spline.땟().SetTextureAngle2Deg(0.0f);
      rageGroupElement.Spline.땟().RefreshMeshInEditor(true, true, true);
    }
  }

  public void QueueRefresh()
  {
    if (!this.딟)
      this.딟 = true;
    else
      this.딧 = true;
    this.땄 = false;
  }

  public void QueueDirtyRefresh()
  {
    if (!this.딟)
      this.딟 = true;
    else
      this.딧 = true;
    this.땄 = true;
  }

  public int GetMaxDensity()
  {
    int num = 0;
    foreach (RageGroupElement rageGroupElement in this.get_List())
      num = rageGroupElement.DefaultDensity <= num ? num : rageGroupElement.DefaultDensity;
    return num;
  }

  public void SetVisibility(bool visible) => this.set_Visible(visible);

  public void SetOpacity(float opacity)
  {
    if (!this.get_Visible())
      return;
    if (this.Proportional)
      this.set_OpacityMult(opacity);
    else
      this.set_Opacity(opacity);
    this.DoUpdateOpacity();
    this.QueueRefresh();
  }
}
