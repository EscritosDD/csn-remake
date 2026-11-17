// Decompiled with JetBrains decompiler
// Type: RagePivotools
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using 땺;

[RequireComponent(typeof (RageGroup))]
[AddComponentMenu("RageTools/Rage Pivotools")]
public class RagePivotools : MonoBehaviour
{
  public RagePivotools.땟 CenteringType;
  public GameObject ReferenceGO;
  public bool InPlace = true;
  public bool DeletePivotReferences = true;
  public RageGroup Group;

  public void Awake() => this.FindRageGroup();

  public void CenterPivot()
  {
    switch (this.CenteringType)
    {
      case RagePivotools.땟.딟:
        this.ProcessDefaultCentering();
        break;
      case RagePivotools.땟.땄:
        if (Object.op_Equality((Object) this.ReferenceGO, (Object) null))
          return;
        this.ProcessReferenceCentering();
        break;
      case RagePivotools.땟.딧:
        this.ProcessPerItemCentering();
        break;
      case RagePivotools.땟.딢:
        this.ProcessPerBranchCentering();
        break;
    }
    if (!Object.op_Inequality((Object) this.Group, (Object) null))
      return;
    this.Group.UpdateCenter();
  }

  public void ProcessDefaultCentering()
  {
    if (!this.FindRageGroup())
      return;
    Vector3 center = this.Group.Center;
    if (!this.InPlace)
    {
      ((Component) this).transform.position = Vector3.zero;
      this.Group.UpdatePathList();
    }
    RagePivotools.딟(this.Group, Vector3.op_Subtraction(((Component) this).transform.position, this.Group.Center));
    if (!this.InPlace)
      return;
    ((Component) this).transform.position = center;
    foreach (RageGroupElement rageGroupElement in this.Group.get_List())
    {
      Vector3 position = ((Component) rageGroupElement.Spline.땟()).transform.position;
      Vector3 positionCache = rageGroupElement.PositionCache;
      ((Component) rageGroupElement.Spline.땟()).transform.position = new Vector3((float) position.x, (float) position.y, (float) positionCache.z);
    }
  }

  public void ProcessReferenceCentering()
  {
    if (!this.FindRageGroup())
      return;
    if (this.InPlace)
    {
      RagePivotools.딟(this.Group, Vector3.op_Subtraction(((Component) this).transform.position, this.ReferenceGO.transform.position));
      ((Component) this).transform.position = new Vector3((float) this.ReferenceGO.transform.position.x, (float) this.ReferenceGO.transform.position.y, (float) ((Component) this).transform.position.z);
    }
    else
      RagePivotools.딟(this.Group, Vector3.op_Subtraction(this.ReferenceGO.transform.position, ((Component) this).transform.position));
  }

  public void ProcessPerItemCentering()
  {
    if (!this.FindRageGroup())
      return;
    foreach (RageGroupElement rageGroupElement in this.Group.get_List())
    {
      RageSplineAdapter spline = rageGroupElement.Spline;
      Vector3 vector3 = RagePivotools.딟((딥) spline);
      Vector3 position = spline.딦().transform.position;
      RagePivotools.딟(rageGroupElement, Vector3.op_UnaryNegation(vector3));
      if (this.InPlace)
        spline.딦().transform.position = Vector3.op_Addition(vector3, position);
    }
  }

  public void ProcessPerBranchCentering()
  {
    foreach (Transform transform in ((Component) this).transform)
    {
      if (Object.op_Equality((Object) RagePivotools.딟(transform), (Object) null))
        RagePivotools.딟(((Component) transform).gameObject, (GameObject) null);
    }
    this.AssemblePivotTree(((Component) this).transform).딟(this.DeletePivotReferences);
    this.Group.UpdatePathList();
  }

  private static GameObject 딟([In] Transform obj0)
  {
    GameObject gameObject = (GameObject) null;
    foreach (RageSpline componentsInChild in ((Component) obj0).GetComponentsInChildren<RageSpline>())
    {
      if (((Object) ((Component) componentsInChild).gameObject).name.Contains("pivot"))
      {
        gameObject = ((Component) componentsInChild).gameObject;
        break;
      }
    }
    return gameObject;
  }

  private static void 딟([In] GameObject obj0, [In] GameObject obj1)
  {
    bool flag1 = Object.op_Implicit((Object) obj0.GetComponent<RageGroup>());
    bool flag2 = Object.op_Implicit((Object) obj0.GetComponent<RagePivotools>());
    RageGroup rageGroup = obj0.GetComponent<RageGroup>() ?? obj0.AddComponent<RageGroup>();
    rageGroup.UpdatePathList();
    RagePivotools ragePivotools = obj0.GetComponent<RagePivotools>() ?? obj0.AddComponent<RagePivotools>();
    if (Object.op_Equality((Object) obj1, (Object) null))
    {
      ragePivotools.ProcessDefaultCentering();
    }
    else
    {
      ragePivotools.ReferenceGO = obj1;
      ragePivotools.ProcessReferenceCentering();
    }
    if (!flag2)
      ((Object) ragePivotools).딟();
    if (flag1)
      return;
    ((Object) rageGroup).딟();
  }

  private RagePivotools.땂 AssemblePivotTree(Transform root)
  {
    RagePivotools.땂 parent = new RagePivotools.땂((RagePivotools.땂) null, root);
    this.RecursiveSearchPivot(root, parent);
    return parent;
  }

  private void RecursiveSearchPivot(Transform root, RagePivotools.땂 parent)
  {
    if (((Object) ((Component) root).gameObject).name.Contains("pivot"))
    {
      RagePivotools.땂 땂 = new RagePivotools.땂(parent, root);
      parent.딟.Add(땂);
      parent = 땂;
    }
    foreach (Transform root1 in ((Component) root).transform)
      this.RecursiveSearchPivot(root1, parent);
  }

  private static void 딟([In] RageGroup obj0, [In] Vector3 obj1)
  {
    foreach (RageGroupElement rageGroupElement in obj0.get_List())
      RagePivotools.딟(rageGroupElement, obj1);
    obj0.UpdatePathList();
  }

  private static void 딟([In] RageGroupElement obj0, [In] Vector3 obj1)
  {
    RageSplineAdapter spline = obj0.Spline;
    bool flag1 = spline.땺() == 땺.땔.땷.딧 || spline.땟().GetOutlineGradient() != RageSpline.땭.딟;
    bool flag2 = spline.땟().GetTexturing1() != RageSpline.땽.딟 || spline.땟().GetTexturing2() != RageSpline.땽.딟;
    Vector2 zero;
    Vector2 vector2_1 = zero = Vector2.zero;
    Vector2 vector2_2 = zero;
    Vector2 vector2_3 = zero;
    if (flag1)
      vector2_2 = Vector2.op_Implicit(obj0.GradientOffsetCache);
    if (flag2)
    {
      vector2_1 = obj0.TextureOffsetCache;
      vector2_3 = obj0.TextureOffsetCache2;
    }
    RagePivotools.딟((딥) spline, obj1);
    if (flag1)
    {
      // ISSUE: explicit constructor call
      ((Vector2) ref vector2_2).\u002Ector((float) (vector2_2.x + obj1.x), (float) (vector2_2.y + obj1.y));
      spline.땥().딟(Vector2.op_Implicit(spline.딦().transform.InverseTransformPoint(Vector2.op_Implicit(vector2_2))));
    }
    if (flag2)
    {
      // ISSUE: explicit constructor call
      ((Vector2) ref vector2_1).\u002Ector((float) (vector2_1.x + obj1.x), (float) (vector2_1.y + obj1.y));
      // ISSUE: explicit constructor call
      ((Vector2) ref vector2_3).\u002Ector((float) (vector2_3.x + obj1.x), (float) (vector2_3.y + obj1.y));
      spline.땟().SetTextureOffset(Vector2.op_Implicit(spline.딦().transform.InverseTransformPoint(Vector2.op_Implicit(vector2_1))));
      spline.땟().SetTextureOffset2(Vector2.op_Implicit(spline.딦().transform.InverseTransformPoint(Vector2.op_Implicit(vector2_3))));
    }
    spline.땟().RefreshMeshInEditor(true, true, true);
  }

  private static void 딟([In] 딥 obj0, [In] Vector3 obj1)
  {
    for (int index = 0; index < obj0.땟().GetPointCount(); ++index)
    {
      Vector3 positionWorldSpace = obj0.땟().GetPositionWorldSpace(index);
      // ISSUE: explicit constructor call
      ((Vector3) ref positionWorldSpace).\u002Ector((float) (positionWorldSpace.x + obj1.x), (float) (positionWorldSpace.y + obj1.y), (float) (positionWorldSpace.z + obj1.z));
      obj0.땟().SetPointWorldSpace(index, positionWorldSpace);
    }
  }

  public void FreezeRotationAndScale()
  {
    if (!this.FindRageGroup())
      return;
    this.Group.UpdatePathList();
    this.ResetRotationAndScale(((Component) this).gameObject.transform);
    if (this.Group.get_List() == null)
      return;
    foreach (RageGroupElement rageGroupElement in this.Group.get_List())
    {
      RageSplineAdapter spline = rageGroupElement.Spline;
      for (int index = 0; index < spline.딷(); ++index)
      {
        땺.딛 딛 = spline.딧(index);
        딛.딟(rageGroupElement.GroupPointCache[index].PointPos);
        딛.땄(rageGroupElement.GroupPointCache[index].InCtrlPos);
        딛.딧(rageGroupElement.GroupPointCache[index].OutCtrlPos);
      }
      if (spline.땺() == 땺.땔.땷.딧)
      {
        float num1 = spline.땥().땄();
        float num2 = (float) (1.0 / rageGroupElement.ScaleCache.x);
        spline.땥().딟(num1 * num2);
        땺.떓 떓 = spline.땥();
        떓.땄(떓.딧() + (float) -((Quaternion) ref rageGroupElement.RotationCache).eulerAngles.z);
        spline.땥().딟(Vector2.op_Implicit(spline.딦().transform.InverseTransformPoint(rageGroupElement.GradientOffsetCache)));
      }
      spline.땟().RefreshMeshInEditor(true, true, true);
    }
  }

  public void ResetRotationAndScale(Transform thisTransform)
  {
    if (Object.op_Equality((Object) thisTransform, (Object) null))
      return;
    thisTransform.localScale = Vector3.one;
    thisTransform.rotation = Quaternion.identity;
    foreach (Transform thisTransform1 in thisTransform)
    {
      thisTransform1.localRotation = Quaternion.identity;
      thisTransform1.localScale = Vector3.one;
      if (((Component) thisTransform1).gameObject.transform.childCount > 0)
        this.ResetRotationAndScale(thisTransform1);
    }
  }

  private static Vector3 딟([In] 딥 obj0)
  {
    MeshFilter component = obj0.딦().GetComponent<MeshFilter>();
    Bounds bounds1 = component.sharedMesh.bounds;
    // ISSUE: variable of the null type
    __Null local1 = ((Bounds) ref bounds1).center.x * obj0.딦().transform.lossyScale.x;
    Bounds bounds2 = component.sharedMesh.bounds;
    // ISSUE: variable of the null type
    __Null local2 = ((Bounds) ref bounds2).center.y * obj0.딦().transform.lossyScale.y;
    Bounds bounds3 = component.sharedMesh.bounds;
    // ISSUE: variable of the null type
    __Null local3 = ((Bounds) ref bounds3).center.z * obj0.딦().transform.lossyScale.z;
    return new Vector3((float) local1, (float) local2, (float) local3);
  }

  public bool FindRageGroup()
  {
    if (Object.op_Equality((Object) this.Group, (Object) null))
      this.Group = ((Component) this).GetComponent<RageGroup>();
    if (Object.op_Equality((Object) this.Group, (Object) null))
    {
      Debug.Log((object) "Error: No group found. Aborting.");
      return false;
    }
    this.Group.UpdatePathList();
    return true;
  }

  public enum 땟
  {
    딟,
    땄,
    딧,
    딢,
  }

  public class 땂 : IComparable<RagePivotools.땂>
  {
    public Transform 딟;
    public RagePivotools.땂 딟;
    public int 딟;
    public List<RagePivotools.땂> 딟 = new List<RagePivotools.땂>();

    public 땂([In] RagePivotools.땂 obj0, [In] Transform obj1)
    {
      this.딟 = obj0;
      this.딟 = this.딟(obj1, 0);
      this.딟 = obj1;
    }

    private int 딟([In] Transform obj0, [In] int obj1) => Object.op_Equality((Object) obj0.parent, (Object) null) ? obj1 : this.딟(obj0.parent, ++obj1);

    public void 딟([In] bool obj0)
    {
      this.딟.Sort();
      foreach (RagePivotools.땂 땂 in this.딟)
      {
        RagePivotools.딟(((Component) 땂.딟).gameObject, (GameObject) null);
        RagePivotools.딟(((Component) 땂.딟.parent).gameObject, ((Component) 땂.딟).gameObject);
      }
      foreach (RagePivotools.땂 땂 in this.딟)
        땂.딟(obj0);
      if (!obj0 || !((Object) ((Component) this.딟).gameObject).name.Contains("pivot"))
        return;
      ((Object) ((Component) this.딟).gameObject).딟();
    }

    public int CompareTo([In] RagePivotools.땂 obj0) => this.딟.CompareTo(obj0.딟);
  }
}
