// Decompiled with JetBrains decompiler
// Type: FSPrismaticJointComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("FarseerUnity/Dynamics/Joints/Prismatic Joint Component")]
public class FSPrismaticJointComponent : FSJointComponent
{
  protected 땥.땬 딟;
  public float Frequency = 60f;

  public override void InitJoint()
  {
    base.InitJoint();
    float num = Mathf.Atan2(this.BodyB.get_PhysicsBody().땼().땄 - this.BodyA.get_PhysicsBody().땼().땄, this.BodyB.get_PhysicsBody().땼().딟 - this.BodyA.get_PhysicsBody().땼().딟);
    땥.떁 떁 = new 땥.떁(Mathf.Cos(num), Mathf.Sin(num));
    this.딟 = 딝.떂.땄(FSWorldComponent.딟(), this.BodyA.get_PhysicsBody(), this.BodyB.get_PhysicsBody(), 땥.떁.딟(), 떁);
    ((딝.땺) this.딟).딟(this.CollideConnected);
  }

  public override void Update() => base.Update();

  public override void OnDrawGizmos()
  {
    if (Object.op_Equality((Object) this.BodyA, (Object) null) || Object.op_Equality((Object) this.BodyB, (Object) null))
      return;
    Gizmos.color = Color.cyan;
    Gizmos.DrawLine(((Component) this.BodyA).transform.position, ((Component) this.BodyB).transform.position);
  }
}
