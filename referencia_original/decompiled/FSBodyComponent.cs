// Decompiled with JetBrains decompiler
// Type: FSBodyComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using UnityEngine;

[AddComponentMenu("FarseerUnity/Dynamics/Body Component")]
public class FSBodyComponent : MonoBehaviour
{
  public 땥.딺 body;
  public 땥.땎 Type = 땥.땎.딧;
  protected bool 딟;
  public FSBodyComponent.땢 UpdateMode;

  public virtual void Start()
  {
    if (this.딟)
      return;
    this.딟 = true;
    this.body = new 땥.딺(FSWorldComponent.딟());
    FSShapeComponent[] componentsInChildren = ((Component) this).GetComponentsInChildren<FSShapeComponent>();
    foreach (FSShapeComponent fsShapeComponent in componentsInChildren)
    {
      땥.떀 떀 = this.body.딟(fsShapeComponent.GetShape());
      떀.딟(fsShapeComponent.Friction);
      떀.땄(fsShapeComponent.Restitution);
      if (((Component) fsShapeComponent).tag.Length > 0)
        떀.딟(((Component) fsShapeComponent).tag);
      if (fsShapeComponent.CollisionFilter == 땺.땝.딧)
      {
        떀.땄(fsShapeComponent.BelongsTo);
        떀.딟(fsShapeComponent.CollidesWith);
      }
      else if (fsShapeComponent.CollisionFilter == 땺.땝.땄 && Object.op_Inequality((Object) fsShapeComponent.CollisionGroup, (Object) null))
      {
        떀.땄(fsShapeComponent.CollisionGroup.BelongsTo);
        떀.딟(fsShapeComponent.CollisionGroup.CollidesWith);
      }
    }
    if (componentsInChildren.Length < 1)
    {
      FSShapeComponent component = ((Component) this).GetComponent<FSShapeComponent>();
      if (Object.op_Inequality((Object) component, (Object) null))
      {
        땥.떀 떀 = this.body.딟(component.GetShape());
        떀.딟(component.Friction);
        떀.땄(component.Restitution);
        if (((Component) component).tag.Length > 0)
          떀.딟(((Component) component).tag);
        if (component.CollisionFilter == 땺.땝.딧)
        {
          떀.땄(component.BelongsTo);
          떀.딟(component.CollidesWith);
        }
        else if (component.CollisionFilter == 땺.땝.땄 && Object.op_Inequality((Object) component.CollisionGroup, (Object) null))
        {
          떀.땄(component.CollisionGroup.BelongsTo);
          떀.딟(component.CollisionGroup.CollidesWith);
        }
      }
    }
    this.body.딟(this.Type);
    this.body.땄(new 땥.떁((float) ((Component) this).transform.position.x, (float) ((Component) this).transform.position.y));
    땥.딺 body = this.body;
    Quaternion rotation = ((Component) this).transform.rotation;
    double num = ((Quaternion) ref rotation).eulerAngles.z * (Math.PI / 180.0);
    body.땃((float) num);
    if (((Component) this).tag.Length > 0)
      this.body.딟(((Component) this).tag);
    this.body.딟(this);
  }

  private void Update()
  {
    if (this.UpdateMode != FSBodyComponent.땢.딟)
      return;
    this.CopyBodyTransformData();
  }

  private void FixedUpdate()
  {
    if (this.UpdateMode != FSBodyComponent.땢.딟)
      return;
    this.CopyBodyTransformData();
  }

  private void LateUpdate()
  {
    if (this.UpdateMode != FSBodyComponent.땢.딧)
      return;
    this.CopyBodyTransformData();
  }

  private void CopyBodyTransformData()
  {
    Vector3 position = ((Component) this).transform.position;
    position.x = (__Null) (double) this.body.땼().딟;
    position.y = (__Null) (double) this.body.땼().땄;
    Quaternion rotation = ((Component) this).transform.rotation;
    Vector3 eulerAngles = ((Quaternion) ref rotation).eulerAngles;
    eulerAngles.z = (__Null) ((double) this.body.땢() * 57.2957801818848);
    ((Component) this).transform.position = position;
    ((Component) this).transform.rotation = Quaternion.Euler(eulerAngles);
  }

  public void ApplyTransformToBody(Transform thisTransform)
  {
    this.body.땄(new 땥.떁((float) thisTransform.position.x, (float) thisTransform.position.y));
    this.body.땃((float) thisTransform.rotation.z);
  }

  protected virtual void OnDestroy() => FSWorldComponent.딟().땄(this.get_PhysicsBody());

  [SpecialName]
  public 땥.딺 get_PhysicsBody()
  {
    if (!this.딟)
      this.Start();
    return this.body;
  }

  public enum 땢
  {
    딟,
    땄,
    딧,
  }
}
