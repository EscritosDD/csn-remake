// Decompiled with JetBrains decompiler
// Type: RageEdgetune
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

[RequireComponent(typeof (RageGroup))]
[ExecuteInEditMode]
[AddComponentMenu("RageTools/Rage EdgeTune")]
[Serializable]
public class RageEdgetune : MonoBehaviour
{
  public bool On;
  public bool StartOnly;
  public GameObject TextMeshGO;
  public RageGroup Group;
  public RageEdgetuneData Data;
  public float StartObjectHeight;
  public TextMesh DebugTextMesh;
  public bool DebugDensity;
  private bool 딟;
  [SerializeField]
  private float _lastZoffset;
  [SerializeField]
  private float _lastObjectHeight;
  [SerializeField]
  private Quaternion _lastObjectRotation = Quaternion.identity;
  [SerializeField]
  private bool _changedResolutionHeight;
  [SerializeField]
  private bool _changedZOffset;
  [SerializeField]
  private bool _changedOrthoSize;
  [SerializeField]
  private bool _changedObjectHeight;
  [SerializeField]
  private bool _changedCameraRotation;
  [SerializeField]
  private bool _changedObjectRotation;
  [SerializeField]
  private RageCamera _rageCamera;
  private Camera 딟;
  private float 딟 = 0.2f;
  private float 땄 = 1f;
  [SerializeField]
  private float _dfScale = 1f;
  [SerializeField]
  private float _dfResolution = 1f;
  [SerializeField]
  private float _dfZoffset = 1f;
  [SerializeField]
  private float _dfOrthoSize = 1f;
  [SerializeField]
  private float _aafResolution = 1f;
  [SerializeField]
  private float _aafZoffset = 1f;
  [SerializeField]
  private float _aafOrthoSize = 1f;

  [SpecialName]
  private RageCamera get_SceneRageCamera()
  {
    if (Object.op_Equality((Object) this._rageCamera, (Object) null))
      this._rageCamera = ((Component) Camera.main).GetComponent<RageCamera>();
    if (Object.op_Equality((Object) this._rageCamera, (Object) null))
      this._rageCamera = ((Component) Camera.main).gameObject.AddComponent<RageCamera>();
    return this._rageCamera;
  }

  [SpecialName]
  private void set_SceneRageCamera(RageCamera value) => this._rageCamera = value;

  [SerializeField]
  private Camera 딟
  {
    get
    {
      if (Object.op_Equality((Object) this.딟, (Object) null))
        this.딟 = Camera.main;
      return this.딟;
    }
    set => this.딟 = value;
  }

  [SpecialName]
  public float get_UpdateThreshold()
  {
    if ((double) this.딟 <= 0.0)
      this.딟 = 0.01f;
    return this.딟;
  }

  [SpecialName]
  public void set_UpdateThreshold(float value) => this.딟 = (double) value > 0.0 ? value : 0.01f;

  [SpecialName]
  private float get_StartCameraDistance()
  {
    if (Mathf.Approximately(this.땄, 0.0f))
      this.땄 = 0.01f;
    return this.땄;
  }

  [SpecialName]
  private void set_StartCameraDistance(float value) => this.땄 = !Mathf.Approximately(value, 0.0f) ? value : 0.01f;

  public void ScheduleInitialize() => this.딟 = true;

  public void Awake() => this.AddReferences();

  public void OnEnable()
  {
    RageCamera.딟(new RageCamera.땥(this.OnChangedResolutionHeight));
    RageCamera.딟(new RageCamera.딝(this.OnChangedOrthoSize));
    RageCamera.딟(new RageCamera.떎(this.OnChangedCameraCameraRotation));
  }

  private void OnChangedResolutionHeight() => this._changedResolutionHeight = true;

  private void OnChangedOrthoSize() => this._changedOrthoSize = true;

  private void OnChangedCameraCameraRotation() => this._changedCameraRotation = true;

  public void OnDisable() => RageCamera.땄(new RageCamera.땥(this.OnChangedResolutionHeight));

  public void Start()
  {
    if (!this.On)
      return;
    if (!this.StartOnly)
    {
      this.DoEdgeTune();
    }
    else
    {
      int updateStep = this.Group.UpdateStep;
      this.Group.UpdateStep = 0;
      this.DoEdgeTune();
      this.Group.UpdateStep = updateStep;
    }
  }

  public void Update()
  {
    if (this.딟)
    {
      this.Initialize();
      this.딟 = false;
    }
    if (this.StartOnly || !this.RefreshCheck())
      return;
    this.DoEdgeTune();
  }

  private void AddReferences()
  {
    if (Object.op_Equality((Object) this.Group, (Object) null))
      this.Group = ((Component) this).gameObject.GetComponent<RageGroup>();
    if (!Object.op_Equality((Object) this.Data, (Object) null))
      return;
    this.Data = ScriptableObject.CreateInstance<RageEdgetuneData>();
  }

  public void Initialize()
  {
    if (Object.op_Equality((Object) this.Group, (Object) null))
      this.Group = ((Component) this).gameObject.GetComponent<RageGroup>();
    this.get_SceneRageCamera().Initialize();
    this.딟 = Camera.main;
    this.set_UpdateThreshold(this.get_SceneRageCamera().get_UpdateThreshold());
    this._lastObjectHeight = this.StartObjectHeight = (float) ((Component) this).gameObject.transform.lossyScale.y;
    float num = this.OffsetFromCamera();
    this.set_StartCameraDistance(num);
    this._lastZoffset = num;
  }

  public bool RefreshCheck()
  {
    if (!this.On)
      return false;
    this._changedZOffset = this.ChangedZOffset();
    this._changedObjectHeight = this.ChangedObjectHeight();
    this._changedObjectRotation = this.ChangedObjectRotation();
    return this._changedResolutionHeight || this._changedOrthoSize || this._changedCameraRotation || this._changedObjectHeight || this._changedZOffset || this._changedObjectRotation;
  }

  private bool ChangedZOffset()
  {
    float num = this.OffsetFromCamera();
    if ((double) RageEdgetune.딟(num, this._lastZoffset) < (double) this.get_UpdateThreshold())
      return false;
    this._lastZoffset = num;
    return true;
  }

  private bool ChangedObjectHeight()
  {
    float y = (float) ((Component) this).gameObject.transform.lossyScale.y;
    if ((double) RageEdgetune.딟(y, this._lastObjectHeight) < (double) this.get_UpdateThreshold())
      return false;
    this._lastObjectHeight = y;
    return true;
  }

  private bool ChangedObjectRotation()
  {
    if (Mathf.Approximately(this.Data.PerspectiveBlur, 0.0f))
      return false;
    Quaternion rotation = ((Component) this).gameObject.transform.rotation;
    if ((double) (Quaternion.Angle(rotation, this._lastObjectRotation) / 100f) < (double) this.get_UpdateThreshold() / 2.0)
      return false;
    this._lastObjectRotation = rotation;
    return true;
  }

  public void DoEdgeTune()
  {
    this.CheckRageGroupAndList();
    double andUpdateAa = (double) this.CalculateAndUpdateAa();
    if (Object.op_Equality((Object) this.Data, (Object) null))
      this.Data = ScriptableObject.CreateInstance<RageEdgetuneData>();
    if (this.Data.AutomaticLod)
    {
      double andUpdateDensity = (double) this.CalculateAndUpdateDensity();
    }
    this.Group.QueueRefresh();
    this._changedResolutionHeight = this._changedOrthoSize = this._changedCameraRotation = false;
  }

  private float CalculateAndUpdateAa()
  {
    if (this._changedResolutionHeight)
      this._aafResolution = this.AaFactorInResolution();
    if (this._changedZOffset)
      this._aafZoffset = this.AaFactorInZOffset();
    if (this._changedOrthoSize)
      this._aafOrthoSize = this.AaFactorInOrthoSize();
    float num1 = this.AaZoomOutAttenuation(this._aafResolution * this._aafZoffset * this._aafOrthoSize) + this.AaFactorInAngleDelta();
    if (Object.op_Equality((Object) this.Data, (Object) null))
      this.Data = ScriptableObject.CreateInstance<RageEdgetuneData>();
    float num2 = Mathf.Pow(num1, this.Data.AaFactor);
    if (Object.op_Inequality((Object) this.DebugTextMesh, (Object) null) && !this.DebugDensity)
      this.DebugTextMesh.text = num2.ToString() + string.Empty;
    this.Group.get_List().딟(num2, true, !this.Data.AutomaticLod);
    return num2;
  }

  private float CalculateAndUpdateDensity()
  {
    if (this._changedObjectHeight)
      this._dfScale = this.DensityFactorInScale();
    if (this._changedResolutionHeight)
      this._dfResolution = this.DensityFactorInResolution();
    if (this._changedZOffset)
      this._dfZoffset = this.DensityFactorInZOffset();
    if (this._changedOrthoSize)
      this._dfOrthoSize = this.DensityFactorInOrthoSize();
    float num = this.DensityZoomOutAttenuation(this._dfScale * this._dfZoffset * this._dfResolution * this._dfOrthoSize);
    if (Object.op_Inequality((Object) this.DebugTextMesh, (Object) null) && this.DebugDensity)
      this.DebugTextMesh.text = "Scl: " + (object) this._dfScale + "  Res: " + (object) this._dfResolution + "  Zoffs: " + (object) this._dfZoffset + "  Ortho: " + (object) this._dfOrthoSize;
    this.Group.get_List().딟(num, this.Data.MaxDensity);
    return num;
  }

  private float AaFactorInResolution() => this.get_SceneRageCamera().DefaultResolutionHeight / (float) 땺.딗.딟().y;

  private float AaFactorInZOffset() => this.딟.isOrthoGraphic ? 1f : this.OffsetFromCamera() / this.get_StartCameraDistance();

  private float AaFactorInOrthoSize() => this.딟.orthographicSize / this.get_SceneRageCamera().DefaultOrthoSize;

  private float AaFactorInAngleDelta() => Mathf.Approximately(this.Data.PerspectiveBlur, 0.0f) ? 0.0f : Mathf.Lerp(0.0f, this.Data.PerspectiveBlur, Mathf.Pow(Vector3.Distance(Vector3.zero, Vector3.Cross(((Component) this.딟).transform.forward, ((Component) this).transform.forward)), 10f));

  private float AaZoomOutAttenuation(float factor)
  {
    if ((double) factor <= 1.0)
      return factor;
    return (double) factor >= 40.0 ? 40f : factor - Mathf.Pow(factor, 2f) / 75f;
  }

  private float DensityFactorInScale() => 1f / Mathf.Pow(this.StartObjectHeight / Mathf.Abs((float) ((Component) this).gameObject.transform.lossyScale.y), this.Data.DensityFactor);

  private float DensityFactorInResolution() => (float) 땺.딗.딟().y / this.get_SceneRageCamera().DefaultResolutionHeight;

  private float DensityFactorInZOffset() => this.딟.isOrthoGraphic ? 1f : Mathf.Pow(this.get_StartCameraDistance() / this.OffsetFromCamera(), this.Data.DensityFactor);

  private float DensityFactorInOrthoSize() => !this.딟.isOrthoGraphic ? 1f : this.get_SceneRageCamera().DefaultOrthoSize / this.딟.orthographicSize;

  private float DensityZoomOutAttenuation(float factor) => (double) factor >= 1.0 ? factor : Mathf.Pow(factor, 0.6f);

  private float OffsetFromCamera() => Vector3.Distance(((Component) this).gameObject.transform.position, ((Component) this.get_SceneRageCamera()).transform.position);

  private void CheckRageGroupAndList()
  {
    if (Object.op_Inequality((Object) this.Group, (Object) null) && this.Group.get_List() != null && this.Group.get_List().Count != 0)
      return;
    this.Group = ((Component) this).GetComponent<RageGroup>();
    this.Group.UpdatePathList();
  }

  public void GuessMaxDensity() => this.Data.MaxDensity = this.Group.GetMaxDensity() * 2;

  private static float 딟([In] float obj0, [In] float obj1) => Mathf.Abs(obj0 - obj1) / obj0;
}
