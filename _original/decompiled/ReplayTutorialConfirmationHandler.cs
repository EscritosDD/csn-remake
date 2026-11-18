// Decompiled with JetBrains decompiler
// Type: ReplayTutorialConfirmationHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class ReplayTutorialConfirmationHandler : MonoBehaviour
{
  private bool 딟;
  private MenuOverlayHandler 딟;
  public MenuOverlayHandler OverlayPrefab;
  public GameObject AnimatingComponents;

  private void Start()
  {
    this.AnimatingComponents.SetActive(false);
    Vector3 position = ((Component) this).gameObject.transform.position;
    ref Vector3 local = ref position;
    local.y = (__Null) (local.y - 0.100000001490116);
    this.딟 = Object.Instantiate((Object) this.OverlayPrefab, position, Quaternion.identity) as MenuOverlayHandler;
  }

  private void Update()
  {
    if (this.딟 || ((Component) this).animation.isPlaying)
      return;
    this.AnimatingComponents.SetActive(true);
    this.딟 = true;
  }

  public void Close()
  {
    if (Object.op_Inequality((Object) this.딟, (Object) null))
      this.딟.Close();
    Object.Destroy((Object) ((Component) this).gameObject);
  }
}
