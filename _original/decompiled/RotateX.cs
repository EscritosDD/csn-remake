// Decompiled with JetBrains decompiler
// Type: RotateX
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class RotateX : MonoBehaviour
{
  private Vector3 딟;
  public float Speed = 1f;

  private void Start()
  {
    Quaternion localRotation = ((Component) this).transform.localRotation;
    this.딟 = ((Quaternion) ref localRotation).eulerAngles;
  }

  private void Update()
  {
    ref Vector3 local = ref this.딟;
    local.x = (__Null) (local.x - (double) Time.deltaTime * (double) this.Speed);
    ((Component) this).transform.localRotation = Quaternion.Euler(this.딟);
  }
}
