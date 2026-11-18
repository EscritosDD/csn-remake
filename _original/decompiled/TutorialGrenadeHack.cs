// Decompiled with JetBrains decompiler
// Type: TutorialGrenadeHack
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class TutorialGrenadeHack : MonoBehaviour
{
  private Vector3 딟;
  public Vector3 Offset;

  private void Start() => this.딟 = ((Component) this).transform.localPosition;

  private void Update()
  {
    Vector3 vector3 = !딶.딡.땴().땢().AbilitySelection.AbilityGrid.get_bGridOpen() ? this.딟 : Vector3.op_Addition(this.Offset, this.딟);
    if (!Vector3.op_Inequality(vector3, ((Component) this).transform.localPosition))
      return;
    ((Component) this).transform.localPosition = vector3;
  }
}
