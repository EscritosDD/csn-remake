// Decompiled with JetBrains decompiler
// Type: FSAngleJointComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;
using 땥;

[AddComponentMenu("FarseerUnity/Dynamics/Joints/Angle Joint Component")]
public class FSAngleJointComponent : FSJointComponent
{
  protected 딼 딟;
  public float BiasFactor = 0.2f;
  public float Softness;

  public override void InitJoint()
  {
    this.딟 = 딝.떂.딟(FSWorldComponent.딟(), this.BodyA.get_PhysicsBody(), this.BodyB.get_PhysicsBody());
    this.딟.딟 = this.BiasFactor;
    this.딟.딧 = this.Softness;
    this.딟.딟(this.CollideConnected);
    base.InitJoint();
  }

  public override void OnDrawGizmos()
  {
    if (Object.op_Equality((Object) this.BodyA, (Object) null) || Object.op_Equality((Object) this.BodyB, (Object) null))
      return;
    Gizmos.color = Color.red;
    Gizmos.DrawLine(((Component) this.BodyA).transform.position, ((Component) this.BodyB).transform.position);
    base.OnDrawGizmos();
  }
}
