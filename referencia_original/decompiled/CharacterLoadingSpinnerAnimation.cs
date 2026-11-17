// Decompiled with JetBrains decompiler
// Type: CharacterLoadingSpinnerAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class CharacterLoadingSpinnerAnimation : MonoBehaviour
{
  public float RotationAmount;

  private void Update()
  {
    Quaternion localRotation = ((Component) this).transform.localRotation;
    Vector3 eulerAngles = ((Quaternion) ref localRotation).eulerAngles;
    ref Vector3 local = ref eulerAngles;
    local.y = (__Null) (local.y + (double) this.RotationAmount * (double) Time.deltaTime * 10.0);
    ((Component) this).transform.localRotation = Quaternion.Euler(eulerAngles);
  }
}
