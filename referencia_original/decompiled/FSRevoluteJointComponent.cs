// Decompiled with JetBrains decompiler
// Type: FSRevoluteJointComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using UnityEngine;
using 땥;

[AddComponentMenu("FarseerUnity/Dynamics/Joints/Revolute Joint Component")]
public class FSRevoluteJointComponent : FSJointComponent
{
  protected 떒 딟;
  public bool LimitEnabled;
  public float LowerLimit = -90f;
  public float UpperLimit = 90f;
  public bool MotorEnabled;
  public float MaxMotorTorque = 400f;
  public float MotorSpeed;
  public Vector2 LocalAnchorB = Vector2.zero;

  public override void InitJoint()
  {
    base.InitJoint();
    Vector3 vector3 = ((Component) this.BodyB).transform.TransformPoint(new Vector3((float) this.LocalAnchorB.x, (float) this.LocalAnchorB.y, -5f));
    this.딟 = 딝.떂.딟(FSWorldComponent.딟(), this.BodyA.get_PhysicsBody(), this.BodyB.get_PhysicsBody(), this.BodyB.get_PhysicsBody().땺(딝.딷.딟(vector3)));
    ((딝.땺) this.딟).딟(this.CollideConnected);
    this.딟.딢(this.LowerLimit * ((float) Math.PI / 180f));
    this.딟.땃(this.UpperLimit * ((float) Math.PI / 180f));
    this.딟.딟(this.LimitEnabled);
    this.딟.땓(this.MaxMotorTorque);
    this.딟.딶(this.MotorSpeed);
    this.딟.땄(this.MotorEnabled);
  }

  public override void OnDrawGizmos()
  {
    base.OnDrawGizmos();
    if (Object.op_Equality((Object) this.BodyA, (Object) null) || Object.op_Equality((Object) this.BodyB, (Object) null))
      return;
    Vector3 vector3_1 = ((Component) this.BodyB).transform.TransformPoint(new Vector3((float) this.LocalAnchorB.x, (float) this.LocalAnchorB.y, -5f));
    Gizmos.color = Color.black;
    Gizmos.DrawSphere(vector3_1, 0.3f);
    if (!this.LimitEnabled)
      return;
    float num1 = this.LowerLimit * ((float) Math.PI / 180f);
    float num2 = this.UpperLimit * ((float) Math.PI / 180f);
    Quaternion rotation = ((Component) this.BodyB).transform.rotation;
    float num3 = (float) (((Quaternion) ref rotation).eulerAngles.z * (Math.PI / 180.0));
    float num4 = num1 + num3;
    float num5 = num2 + num3;
    Vector3 vector3_2 = vector3_1;
    ref Vector3 local1 = ref vector3_2;
    local1.x = (__Null) (local1.x + (double) Mathf.Cos(num4) * 3.0);
    ref Vector3 local2 = ref vector3_2;
    local2.y = (__Null) (local2.y + (double) Mathf.Sin(num4) * 3.0);
    Vector3 vector3_3 = vector3_1;
    ref Vector3 local3 = ref vector3_3;
    local3.x = (__Null) (local3.x + (double) Mathf.Cos(num5) * 3.0);
    ref Vector3 local4 = ref vector3_3;
    local4.y = (__Null) (local4.y + (double) Mathf.Sin(num5) * 3.0);
    Vector3 vector3_4 = vector3_1;
    ref Vector3 local5 = ref vector3_4;
    local5.x = (__Null) (local5.x + (double) Mathf.Cos(num3) * 5.0);
    ref Vector3 local6 = ref vector3_4;
    local6.y = (__Null) (local6.y + (double) Mathf.Sin(num3) * 5.0);
    Gizmos.color = Color.green;
    Gizmos.DrawLine(vector3_1, vector3_2);
    Gizmos.color = Color.red;
    Gizmos.DrawLine(vector3_1, vector3_3);
    Gizmos.color = Color.white;
    Gizmos.DrawLine(vector3_1, vector3_4);
  }
}
