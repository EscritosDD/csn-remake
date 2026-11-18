// Decompiled with JetBrains decompiler
// Type: RageConstraint
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using 땥;

[ExecuteInEditMode]
[AddComponentMenu("RageTools/Rage Constraint")]
public class RageConstraint : MonoBehaviour
{
  [SerializeField]
  private GameObject _follower;
  [SerializeField]
  private Transform _followerTransform;
  public bool Live;
  public bool FollowPosition;
  public bool FollowPositionX = true;
  public bool FollowPositionY = true;
  public bool FollowPositionZ = true;
  public bool FollowRotation;
  public bool FollowRotationX = true;
  public bool FollowRotationY = true;
  public bool FollowRotationZ = true;
  public bool FollowScale;
  public bool FollowScaleX = true;
  public bool FollowScaleY = true;
  public bool FollowScaleZ = true;
  public bool Local;
  public bool Visible;
  public float RotationSnap;
  public float PositionSnap;
  public float ScaleSnap;
  public RageGroup FollowerGroup;
  private RageEdgetune 딟;

  [SpecialName]
  public GameObject get_Follower() => this._follower;

  [SpecialName]
  public void set_Follower(GameObject value)
  {
    if (Object.op_Equality((Object) this._follower, (Object) value))
      return;
    this._follower = value;
    this.FollowerGroup = this._follower.GetComponent<RageGroup>();
  }

  [SpecialName]
  public Transform get_FollowerTransform()
  {
    if (Object.op_Equality((Object) this._followerTransform, (Object) null))
      this._followerTransform = this.get_Follower().transform;
    return this._followerTransform;
  }

  [SpecialName]
  public void set_FollowerTransform(Transform value)
  {
    if (Object.op_Equality((Object) this._followerTransform, (Object) value))
      return;
    this._followerTransform = value;
  }

  [SpecialName]
  public bool get_GroupVisible()
  {
    if (Object.op_Equality((Object) this.FollowerGroup, (Object) null))
      return false;
    this.Visible = this.FollowerGroup.get_Visible();
    return this.FollowerGroup.get_Visible();
  }

  [SpecialName]
  public void set_GroupVisible(bool value) => this.SetGroupVisibility(value);

  public void Update()
  {
    this.UpdateFollower();
    if (!this.Live || Object.op_Equality((Object) this.get_Follower(), (Object) null))
      return;
    if (Object.op_Equality((Object) this.딟, (Object) null))
      this.딟 = this.get_Follower().GetComponent<RageEdgetune>();
    if (Object.op_Equality((Object) this.딟, (Object) null))
      return;
    this.딟.Group.QueueRefresh();
  }

  private void UpdateFollower()
  {
    if (!this.Live || !Object.op_Implicit((Object) this.get_Follower()))
      return;
    this.SetGroupVisibility(this.Visible);
    if (this.FollowPosition)
      this.CopyPosition();
    if (this.FollowRotation)
      this.CopyRotation();
    if (!this.FollowScale)
      return;
    this.CopyScale();
  }

  private void CopyScale()
  {
    Vector3 localScale = this.get_FollowerTransform().localScale;
    if (((Vector3) ref localScale).Equals((object) ((Component) this).transform.localScale))
      return;
    this.get_FollowerTransform().localScale = !Mathf.Approximately(this.ScaleSnap, 0.0f) ? Vector3.Lerp(this.get_Follower().transform.localScale, ((Component) this).transform.localScale, this.ScaleSnap * Time.deltaTime) : ((Component) this).transform.localScale;
  }

  private void SetGroupVisibility(bool value)
  {
    if (Object.op_Equality((Object) this.FollowerGroup, (Object) null) || this.FollowerGroup.get_Visible() == value)
      return;
    this.FollowerGroup.set_Visible(value);
    this.Visible = value;
  }

  private void CopyPosition()
  {
    if (this.Local)
    {
      Vector3 localPosition = this.get_FollowerTransform().localPosition;
      if (((Vector3) ref localPosition).Equals((object) ((Component) this).transform.localPosition))
        return;
      this.get_FollowerTransform().localPosition = ((Component) this).transform.localPosition;
    }
    else
    {
      FSBodyComponent component = this.get_Follower().GetComponent<FSBodyComponent>();
      if (Object.op_Inequality((Object) component, (Object) null) && component.body != null)
        component.body.땄(new 땥.떁((float) ((Component) this).transform.position.x, (float) ((Component) this).transform.position.y));
      else
        this.CopyTransformPosition();
    }
  }

  private void CopyTransformPosition()
  {
    Vector3 position = this.get_FollowerTransform().position;
    if (((Vector3) ref position).Equals((object) ((Component) this).transform.position))
      return;
    Vector3 vector3 = !this.FollowPositionX || !this.FollowPositionY || !this.FollowPositionZ ? new Vector3(!this.FollowPositionX ? (float) this.get_FollowerTransform().position.x : (float) ((Component) this).transform.position.x, !this.FollowPositionY ? (float) this.get_FollowerTransform().position.y : (float) ((Component) this).transform.position.y, !this.FollowPositionZ ? (float) this.get_FollowerTransform().position.z : (float) ((Component) this).transform.position.z) : ((Component) this).transform.position;
    this.get_FollowerTransform().position = !Mathf.Approximately(this.PositionSnap, 0.0f) ? Vector3.Lerp(this.get_FollowerTransform().position, vector3, this.PositionSnap * Time.deltaTime) : vector3;
  }

  private void CopyRotation()
  {
    if (this.Local)
    {
      Quaternion localRotation = this.get_FollowerTransform().localRotation;
      if (((Quaternion) ref localRotation).Equals((object) ((Component) this).transform.localRotation))
        return;
      this.get_FollowerTransform().localRotation = ((Component) this).transform.localRotation;
    }
    else
    {
      FSBodyComponent component = this.get_Follower().GetComponent<FSBodyComponent>();
      if (Object.op_Inequality((Object) component, (Object) null) && component.body != null)
      {
        딺 body = component.body;
        Quaternion rotation = ((Component) this).transform.rotation;
        double num = ((Quaternion) ref rotation).eulerAngles.z * (Math.PI / 180.0);
        body.땃((float) num);
      }
      else
      {
        Quaternion rotation = this.get_FollowerTransform().rotation;
        if (((Quaternion) ref rotation).Equals((object) ((Component) this).transform.rotation))
          return;
        this.get_FollowerTransform().rotation = !Mathf.Approximately(this.RotationSnap, 0.0f) ? Quaternion.Slerp(this.get_FollowerTransform().rotation, ((Component) this).transform.rotation, this.RotationSnap * Time.deltaTime) : ((Component) this).transform.rotation;
      }
    }
  }
}
