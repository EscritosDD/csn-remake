// Decompiled with JetBrains decompiler
// Type: RageSplineAdapter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using 땺;

public class RageSplineAdapter : ScriptableObject, 딥
{
  [SerializeField]
  private RageSpline _rageSpline;
  private int 딟;
  [SerializeField]
  private ScriptableObject _fillGradient;
  [SerializeField]
  private ScriptableObject _outline;
  [SerializeField]
  private ScriptableObject _outlineGradient;

  [SpecialName]
  public bool 땃() => this._rageSpline.spline.Triangulate;

  [SpecialName]
  public void 땄([In] bool obj0) => this._rageSpline.spline.Triangulate = obj0;

  [SpecialName]
  public bool 딶() => this._rageSpline.FixUvs;

  [SpecialName]
  public void 딧([In] bool obj0) => this._rageSpline.FixUvs = obj0;

  [SpecialName]
  public float 딢() => this._rageSpline.spline.PercentPrecalcNormals;

  [SpecialName]
  public void 딟([In] float obj0)
  {
    if ((double) obj0 > 1.0)
      this._rageSpline.spline.PercentPrecalcNormals = 1f;
    else if ((double) obj0 < 0.0)
      this._rageSpline.spline.PercentPrecalcNormals = 0.0f;
    else
      this._rageSpline.spline.PercentPrecalcNormals = obj0;
  }

  [SpecialName]
  public Color 땓() => this._rageSpline.outlineColor1;

  [SpecialName]
  public void 땄([In] Color obj0) => this._rageSpline.SetOutlineColor1(obj0);

  public void 딟([In] MonoBehaviour obj0)
  {
    this._rageSpline = (RageSpline) obj0;
    this.딟((땺.떓) ScriptableObject.CreateInstance<RageSplineGradientAdapter>());
    this.딟((땺.딣) ScriptableObject.CreateInstance<RageSplineOutlineAdapter>());
    ((RageSplineGradientAdapter) this.땥()).RageSpline = this._rageSpline;
    ((RageSplineOutlineAdapter) this.딝()).RageSpline = this._rageSpline;
  }

  [SpecialName]
  public 땺.떓 땥() => (땺.떓) this._fillGradient;

  [SpecialName]
  public void 딟([In] 땺.떓 obj0) => this._fillGradient = (ScriptableObject) obj0;

  [SpecialName]
  public bool 땢() => this._rageSpline.isDirty;

  [SpecialName]
  public void 딶([In] bool obj0)
  {
    if (!Object.op_Implicit((Object) this._rageSpline))
      return;
    this._rageSpline.isDirty = obj0;
  }

  [SpecialName]
  public 땺.딣 딝() => (땺.딣) this._outline;

  [SpecialName]
  public void 딟([In] 땺.딣 obj0) => this._outline = (ScriptableObject) obj0;

  [SpecialName]
  public 땺.떓 떎() => (땺.떓) this._outlineGradient;

  [SpecialName]
  public void 땄([In] 땺.떓 obj0) => this._outlineGradient = (ScriptableObject) obj0;

  [SpecialName]
  public 땺.땔.딸 땭() => RageSplineAdapter.딟(this._rageSpline.GetOutline());

  [SpecialName]
  public void 딟([In] 땺.땔.딸 obj0) => this._rageSpline.SetOutline(RageSplineAdapter.땄(obj0));

  [SpecialName]
  public GameObject 딦() => ((Component) this._rageSpline).gameObject;

  [SpecialName]
  public MonoBehaviour 땤() => (MonoBehaviour) this._rageSpline;

  [SpecialName]
  public long 땽() => (long) ((Object) this._rageSpline).GetHashCode();

  [CompilerGenerated]
  [SpecialName]
  public bool 땋() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public void 딢([In] bool obj0) => this.딟 = obj0;

  [SpecialName]
  public bool 딧() => this._rageSpline.inverseTriangleDrawOrder;

  [SpecialName]
  public void 딟([In] bool obj0) => this._rageSpline.inverseTriangleDrawOrder = obj0;

  [SpecialName]
  public float 떂() => this._rageSpline.OutlineWidth;

  [SpecialName]
  public void 땄([In] float obj0) => this._rageSpline.SetOutlineWidth(obj0);

  [SpecialName]
  public Color 땄() => this._rageSpline.GetFillColor1();

  [SpecialName]
  public void 딟([In] Color obj0) => this._rageSpline.SetFillColor1(obj0);

  [SpecialName]
  public 땺.땔.땷 땺() => RageSplineAdapter.딟(this._rageSpline.GetFill());

  [SpecialName]
  public void 딟([In] 땺.땔.땷 obj0) => this._rageSpline.SetFill(RageSplineAdapter.땄(obj0));

  [SpecialName]
  public 땺.땔.땘 땠() => RageSplineAdapter.딟(this._rageSpline.GetCorners());

  [SpecialName]
  public void 딟([In] 땺.땔.땘 obj0) => this._rageSpline.SetCorners(RageSplineAdapter.땄(obj0));

  [SpecialName]
  private int 땴() => this._rageSpline.GetVertexCount();

  [SpecialName]
  private void 딢([In] int obj0) => this._rageSpline.SetVertexCount(obj0);

  [SpecialName]
  public Rect 딟() => this._rageSpline.GetBounds();

  [SpecialName]
  public RageSpline 땟() => this._rageSpline;

  [SpecialName]
  public void 딟([In] RageSpline obj0) => this._rageSpline = obj0;

  private static 땺.땔.땷 딟([In] RageSpline.땤 obj0)
  {
    switch (obj0)
    {
      case RageSpline.땤.딟:
        return 땺.땔.땷.딟;
      case RageSpline.땤.땄:
        return 땺.땔.땷.땄;
      case RageSpline.땤.딧:
        return 땺.땔.땷.딧;
      case RageSpline.땤.딢:
        return 땺.땔.땷.딢;
      default:
        return 땺.땔.땷.딟;
    }
  }

  private static RageSpline.땤 땄([In] 땺.땔.땷 obj0)
  {
    switch (obj0)
    {
      case 땺.땔.땷.딟:
        return RageSpline.땤.딟;
      case 땺.땔.땷.땄:
        return RageSpline.땤.땄;
      case 땺.땔.땷.딧:
        return RageSpline.땤.딧;
      case 땺.땔.땷.딢:
        return RageSpline.땤.딢;
      default:
        return RageSpline.땤.딟;
    }
  }

  private static 땺.땔.딸 딟([In] RageSpline.떂 obj0)
  {
    switch (obj0)
    {
      case RageSpline.떂.딟:
        return 땺.땔.딸.딟;
      case RageSpline.떂.땄:
        return 땺.땔.딸.땄;
      case RageSpline.떂.딧:
        return 땺.땔.딸.딧;
      default:
        return 땺.땔.딸.딟;
    }
  }

  private static RageSpline.떂 땄([In] 땺.땔.딸 obj0)
  {
    switch (obj0)
    {
      case 땺.땔.딸.딟:
        return RageSpline.떂.딟;
      case 땺.땔.딸.땄:
        return RageSpline.떂.땄;
      case 땺.땔.딸.딧:
        return RageSpline.떂.딧;
      default:
        return RageSpline.떂.딟;
    }
  }

  private static 땺.땔.땘 딟([In] RageSpline.딦 obj0)
  {
    switch (obj0)
    {
      case RageSpline.딦.딟:
        return 땺.땔.땘.딟;
      case RageSpline.딦.땄:
        return 땺.땔.땘.땄;
      default:
        return 땺.땔.땘.딟;
    }
  }

  private static RageSpline.딦 땄([In] 땺.땔.땘 obj0)
  {
    switch (obj0)
    {
      case 땺.땔.땘.딟:
        return RageSpline.딦.딟;
      case 땺.땔.땘.땄:
        return RageSpline.딦.땄;
      default:
        return RageSpline.딦.딟;
    }
  }

  public bool 떏() => this._rageSpline.pointsAreInClockWiseOrder();

  public void 땼() => this._rageSpline.flipPointOrder();

  public void 땃(bool _param1 = false) => this.딟(true, true, true, _param1);

  public void 딟([In] bool obj0, [In] bool obj1) => this.딟(true, obj0, obj1, false);

  public void 딟([In] bool obj0, [In] bool obj1, [In] bool obj2, [In] bool obj3)
  {
    if (Object.op_Equality((Object) this._rageSpline, (Object) null))
      return;
    this._rageSpline.FlattenZ = false;
    this._rageSpline.FixOverlaps = !obj3;
    if (!obj3)
      this._rageSpline.RefreshMeshInEditor(true, true, true);
    else
      this.딟 = this._rageSpline.딟(this._rageSpline.spline.Triangulate, obj1, obj2, this.딟, 0.5f);
  }

  [SpecialName]
  public int 땲() => this.땴() / this.딷();

  [SpecialName]
  public void 딟([In] int obj0)
  {
    if (obj0 < 1)
      this.딢(this.딷());
    else
      this.딢(this.딷() * obj0);
  }

  public void 떁() => this._rageSpline.ClearPoints();

  public void 땄([In] int obj0) => this._rageSpline.RemovePoint(obj0);

  public void 딟([In] 땺.딛 obj0) => this._rageSpline.RemovePoint(obj0.딟());

  public 땺.딛 딧([In] int obj0) => this.땃(obj0);

  [SpecialName]
  public Mesh 땂() => ((Component) this._rageSpline).GetComponent<MeshFilter>().sharedMesh;

  [SpecialName]
  public bool 딱() => this._rageSpline.GetOptimize();

  [SpecialName]
  public void 땓([In] bool obj0) => this._rageSpline.SetOptimize(obj0);

  [SpecialName]
  public float 때() => this._rageSpline.GetOptimizeAngle();

  [SpecialName]
  public void 딧([In] float obj0) => this._rageSpline.SetOptimizeAngle(obj0);

  public bool 땩() => true;

  public int 딟([In] int obj0, [In] float obj1, [In] bool obj2)
  {
    땺.딛 딛1 = this.딧(obj0 - 1);
    땺.딛 딛2 = this.딧(obj0);
    if (obj0 > 0 || (double) Vector3.Distance(딛1.땄(), 딛2.땄()) >= (double) obj1)
      return obj0 + 1;
    if (obj2)
      Debug.Log((object) ("overlap path pos = " + (object) 딛1.땄()));
    딛2.딟(false);
    딛2.땄(딛1.땄());
    this.딟(딛1);
    return obj0;
  }

  [SpecialName]
  public int 딷() => this._rageSpline.GetPointCount();

  public 땺.딛 딟([In] int obj0, [In] Vector3 obj1, [In] Vector3 obj2)
  {
    this._rageSpline.AddPoint(obj0, obj1, obj2);
    return this.땃(obj0);
  }

  public 땺.딛 딟([In] int obj0, [In] Vector3 obj1, [In] Vector3 obj2, [In] Vector3 obj3, [In] float obj4, [In] bool obj5)
  {
    this._rageSpline.AddPoint(obj0, obj1, obj2, obj3, obj4, obj5);
    return this.땃(obj0);
  }

  public 땺.딛 땄([In] int obj0, [In] Vector3 obj1, [In] Vector3 obj2)
  {
    this._rageSpline.AddPointWorldSpace(obj0, obj1, obj2);
    return this.땃(obj0);
  }

  private 땺.딛 땃([In] int obj0)
  {
    RageSplinePointAdapter instance = ScriptableObject.CreateInstance<RageSplinePointAdapter>();
    instance.딟(obj0);
    instance.RageSpline = this._rageSpline;
    return (땺.딛) instance;
  }
}
