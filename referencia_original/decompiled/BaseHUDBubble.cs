// Decompiled with JetBrains decompiler
// Type: BaseHUDBubble
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class BaseHUDBubble : MonoBehaviour
{
  private Camera 딟;
  private Vector3 딟;
  protected float 딟;
  public float BubbleContentsEdgeOffset;
  public Vector3 BubblePositionOffset;
  public GameObject BubbleBackground;

  public void ActivateHUDBubble(Vector3 Position)
  {
    GameObject gameObject = ((Component) 딶.딡.땴().땢()).gameObject;
    if (!gameObject.activeInHierarchy)
      gameObject = ((Component) 딶.딡.땴().땢().ReplayScreen).gameObject;
    ((Component) this).transform.parent = gameObject.transform;
    ((Component) this).transform.localRotation = Quaternion.identity;
    ((Component) this).transform.localPosition = new Vector3(0.0f, -0.5f, 0.0f);
    this.딟 = ((Component) 딶.딡.땴().딷().딟().딟).camera;
    this.딟 = Position;
    this.딟 = this.GetBubbleHeight();
    this.UpdateBubble();
    this.PoisitionBubble();
  }

  public virtual void UpdateBubble()
  {
  }

  private void LateUpdate() => this.PoisitionBubble();

  protected void PoisitionBubble()
  {
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    Vector3 screenPoint = this.딟.WorldToScreenPoint(Vector3.op_Addition(this.딟, this.BubblePositionOffset));
    Vector3 worldPoint = 딶.딡.땴().땢().UICamera.ScreenToWorldPoint(screenPoint);
    worldPoint.y = ((Component) this).transform.position.y;
    ref Vector3 local = ref worldPoint;
    local.z = (__Null) (local.z + (double) this.딟 * 0.5);
    ((Component) this).transform.position = worldPoint;
  }

  public float GetBubbleHeight() => (float) 땓.땞.딟(this.BubbleBackground).z;
}
