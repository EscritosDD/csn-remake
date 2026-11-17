// Decompiled with JetBrains decompiler
// Type: LocationPicker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class LocationPicker : GuiComponent3D
{
  public Camera PickCamera;

  public override void OnPressed(Vector3 Position)
  {
    int num1 = -1;
    RaycastHit raycastHit;
    if (!Physics.Raycast(this.PickCamera.ScreenPointToRay(Position), ref raycastHit, float.PositiveInfinity, num1) || !Object.op_Inequality((Object) ((RaycastHit) ref raycastHit).collider, (Object) null))
      return;
    LocationMarker component = ((Component) ((RaycastHit) ref raycastHit).collider).gameObject.GetComponent<LocationMarker>();
    if (!Object.op_Inequality((Object) component, (Object) null))
      return;
    double num2 = (double) component.SelectionAudio.PlayOneShot(((Component) this).gameObject);
    if (!component.TutorialMarker)
      ((Component) this).SendMessageUpwards("OnLocationSelected", (object) component.LocationId);
    else
      ((Component) this).SendMessageUpwards("OpenTutorialConfirmation");
  }
}
