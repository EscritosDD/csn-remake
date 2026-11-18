// Decompiled with JetBrains decompiler
// Type: LogOffConfirmationPanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class LogOffConfirmationPanelHandler : MonoBehaviour
{
  private Vector3 딟;
  private GameObject 딟;
  public GameObject Overlay;

  private void Start()
  {
    this.딟 = Vector3.op_Subtraction(((Component) this).transform.position, new Vector3(0.0f, 0.1f, 0.0f));
    this.딟 = Object.Instantiate((Object) this.Overlay, this.딟, Quaternion.identity) as GameObject;
  }

  public void Close()
  {
    this.딟.GetComponent<MenuOverlayHandler>().Close();
    Object.Destroy((Object) ((Component) this).gameObject);
  }
}
