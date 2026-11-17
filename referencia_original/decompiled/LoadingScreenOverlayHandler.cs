// Decompiled with JetBrains decompiler
// Type: LoadingScreenOverlayHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class LoadingScreenOverlayHandler : MonoBehaviour
{
  public GameObject Overlay;
  private GameObject 딟;
  private Vector3 딟;
  private bool 딟;

  private void Start()
  {
    this.딟 = Vector3.op_Subtraction(((Component) this).transform.position, new Vector3(0.0f, 0.1f, 0.0f));
    this.딟 = Object.Instantiate((Object) this.Overlay, this.딟, Quaternion.identity) as GameObject;
  }

  private void Update()
  {
    if (!this.딟)
      return;
    GlobalAppData.땄(((Component) this).gameObject);
    GlobalAppData.땄(this.딟);
    Object.Destroy((Object) this.딟);
    Object.Destroy((Object) ((Component) this).gameObject);
  }

  public void Close() => this.딟 = true;

  private void OnDestroy()
  {
    GlobalAppData.땄(this.딟);
    GlobalAppData.땄(((Component) this).gameObject);
  }
}
