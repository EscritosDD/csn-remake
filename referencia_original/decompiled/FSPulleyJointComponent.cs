// Decompiled with JetBrains decompiler
// Type: FSPulleyJointComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("FarseerUnity/Dynamics/Joints/Pulley Joint Component")]
public class FSPulleyJointComponent : FSJointComponent
{
  protected 땥.떊 딟;
  public Transform GroundAnchorA;
  public Transform GroundAnchorB;
  public Vector2 LocalAnchorA = Vector2.zero;
  public Vector2 LocalAnchorB = Vector2.zero;
  public float ForceRatio = 1f;

  public override void InitJoint()
  {
    base.InitJoint();
    Vector3 vector3_1 = ((Component) this.BodyA).transform.TransformPoint(new Vector3((float) this.LocalAnchorA.x, (float) this.LocalAnchorA.y, -5f));
    Vector3 vector3_2 = ((Component) this.BodyB).transform.TransformPoint(new Vector3((float) this.LocalAnchorB.x, (float) this.LocalAnchorB.y, -5f));
    this.딟 = 딝.떂.딟(FSWorldComponent.딟(), this.BodyA.get_PhysicsBody(), this.BodyB.get_PhysicsBody(), 딝.딷.딟(this.GroundAnchorA.position), 딝.딷.딟(this.GroundAnchorB.position), this.BodyA.get_PhysicsBody().땺(딝.딷.딟(vector3_1)), this.BodyB.get_PhysicsBody().땺(딝.딷.딟(vector3_2)), this.ForceRatio);
    this.딟.딟(this.CollideConnected);
  }

  public override void OnDrawGizmos()
  {
    if (Object.op_Inequality((Object) this.BodyA, (Object) null) && Object.op_Inequality((Object) this.BodyB, (Object) null) && Object.op_Inequality((Object) this.GroundAnchorA, (Object) null) && Object.op_Inequality((Object) this.GroundAnchorB, (Object) null))
    {
      Vector3 vector3_1 = ((Component) this.BodyA).transform.TransformPoint(new Vector3((float) this.LocalAnchorA.x, (float) this.LocalAnchorA.y, -5f));
      Vector3 vector3_2 = ((Component) this.BodyB).transform.TransformPoint(new Vector3((float) this.LocalAnchorB.x, (float) this.LocalAnchorB.y, -5f));
      Gizmos.color = Color.red;
      Gizmos.DrawLine(vector3_1, this.GroundAnchorA.position);
      Gizmos.DrawLine(this.GroundAnchorA.position, this.GroundAnchorB.position);
      Gizmos.DrawLine(this.GroundAnchorB.position, vector3_2);
    }
    if (Object.op_Inequality((Object) this.GroundAnchorA, (Object) null))
      Gizmos.DrawIcon(this.GroundAnchorA.position, "Shape");
    if (Object.op_Inequality((Object) this.GroundAnchorB, (Object) null))
      Gizmos.DrawIcon(this.GroundAnchorB.position, "Shape");
    base.OnDrawGizmos();
  }
}
