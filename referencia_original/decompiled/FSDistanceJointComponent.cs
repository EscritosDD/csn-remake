// Decompiled with JetBrains decompiler
// Type: FSDistanceJointComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;
using 땥;

[AddComponentMenu("FarseerUnity/Dynamics/Joints/Distance Joint Component")]
public class FSDistanceJointComponent : FSJointComponent
{
  protected 땧 딟;
  public float Frequency = 60f;

  public override void InitJoint()
  {
    base.InitJoint();
    this.딟 = 딝.떂.딢(FSWorldComponent.딟(), this.BodyA.get_PhysicsBody(), this.BodyB.get_PhysicsBody(), 땥.떁.딟(), 땥.떁.딟());
    this.딟.딟(this.CollideConnected);
    this.딟.딢(this.Frequency);
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
