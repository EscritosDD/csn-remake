// Decompiled with JetBrains decompiler
// Type: AutoPositionText
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class AutoPositionText : MonoBehaviour
{
  private Camera 딟;
  private Vector3 딟;
  private Vector3 땄;
  private float 딟;
  private float 땄;
  public GuiText3D Text;
  public float Speed = 30f;
  public float Lifetime = 1f;
  public Vector3 StartOffset = new Vector3(0.0f, 1f, 0.0f);
  public Transform Parent;

  public void Init(
    Camera Cam,
    string Value,
    Vector3 Position,
    Vector3 ScreenPosOffset,
    Transform Parent)
  {
    GameObject gameObject = ((Component) 딶.딡.땴().땢()).gameObject;
    if (!gameObject.activeInHierarchy)
      gameObject = ((Component) 딶.딡.땴().땢().ReplayScreen).gameObject;
    ((Component) this).transform.parent = gameObject.transform;
    ((Component) this).transform.localRotation = Quaternion.identity;
    ((Component) this).transform.localPosition = Vector3.zero;
    this.Text.Text = Value;
    this.Text.UpdateMesh();
    this.Parent = Parent;
    this.딟 = Cam;
    this.딟 = Vector3.op_Addition(Position, this.StartOffset);
    this.땄 = this.Speed / 320f;
    this.딟 = 0.0f;
    this.땄 = ScreenPosOffset;
    this.SetPosition();
    Object.Destroy((Object) ((Component) this).gameObject, this.Lifetime);
  }

  private void LateUpdate()
  {
    this.딟 += Time.deltaTime;
    this.SetPosition();
  }

  private void SetPosition()
  {
    if (Object.op_Inequality((Object) this.Parent, (Object) null))
      this.딟 = new Vector3((float) this.Parent.position.x, (float) this.딟.y, (float) this.Parent.position.z);
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    Vector3 screenPoint = this.딟.WorldToScreenPoint(this.딟);
    Vector3 worldPoint = 딶.딡.땴().땢().UICamera.ScreenToWorldPoint(screenPoint);
    worldPoint.y = ((Component) this).transform.position.y;
    ref Vector3 local = ref worldPoint;
    local.z = (__Null) (local.z + (double) this.딟 * (double) this.땄);
    ((Component) this).transform.position = Vector3.op_Addition(worldPoint, this.땄);
  }
}
