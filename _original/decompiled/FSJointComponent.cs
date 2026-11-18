// Decompiled with JetBrains decompiler
// Type: FSJointComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class FSJointComponent : MonoBehaviour
{
  public FSBodyComponent BodyA;
  public FSBodyComponent BodyB;
  public bool CollideConnected;

  [DebuggerHidden]
  private IEnumerator Start() => (IEnumerator) new FSJointComponent.\u003CStart\u003Ec__Iterator21()
  {
    딟 = this
  };

  public virtual void InitJoint()
  {
  }

  public virtual void Update()
  {
  }

  public virtual void OnDrawGizmos()
  {
  }
}
