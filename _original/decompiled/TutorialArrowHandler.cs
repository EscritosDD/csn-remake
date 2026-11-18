// Decompiled with JetBrains decompiler
// Type: TutorialArrowHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class TutorialArrowHandler : MonoBehaviour
{
  public float RotationOffset;
  public float RotationX;
  public Transform PlacementArrow;

  private void Start() => ((Component) this.PlacementArrow).gameObject.animation.wrapMode = (WrapMode) 2;

  private void Update()
  {
    딶.딡 딡 = 딶.딡.땴();
    if (딡 == null)
      return;
    Quaternion flatRotation = 딡.딟.GetFlatRotation(this.RotationOffset);
    this.PlacementArrow.rotation = Quaternion.Euler(this.RotationX, (float) ((double) (float) ((Quaternion) ref flatRotation).eulerAngles.y + (double) GlobalAppData.딟.GameAssets.FriendlyDisplayInfo.StartAngle + 180.0), 0.0f);
  }
}
