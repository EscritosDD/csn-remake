// Decompiled with JetBrains decompiler
// Type: HUDPlacementHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class HUDPlacementHandler : MonoBehaviour
{
  public float RotationOffset;
  public float RotationX;
  public Transform PlacementArrow;

  private void Update()
  {
    Quaternion flatRotation = 딶.딡.땴().딟.GetFlatRotation(this.RotationOffset);
    this.PlacementArrow.rotation = Quaternion.Euler(this.RotationX, (float) ((Quaternion) ref flatRotation).eulerAngles.y + GlobalAppData.딟.GameAssets.FriendlyDisplayInfo.StartAngle, 0.0f);
  }
}
