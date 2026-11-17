// Decompiled with JetBrains decompiler
// Type: WrongVersionMessageHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class WrongVersionMessageHandler : MonoBehaviour
{
  private GameObject 딟;
  private bool 딟;
  public GameObject Overlay;
  public GuiButton3D AcceptButton;
  public GuiMultiLineText3D Text;

  private void Start()
  {
    this.딟 = Object.Instantiate((Object) this.Overlay, new Vector3(0.0f, 2.9f, 0.0f), Quaternion.identity) as GameObject;
    ((Component) this.Text).gameObject.SetActive(false);
    ((Component) this.AcceptButton).gameObject.SetActive(false);
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (WrongVersionMessageHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      WrongVersionMessageHandler.딟 = new Dictionary<string, int>(1)
      {
        {
          "Close",
          0
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!WrongVersionMessageHandler.딟.TryGetValue(key, out num) || num != 0)
      return;
    this.딟.GetComponent<MenuOverlayHandler>().Close();
    Object.Destroy((Object) ((Component) this).gameObject);
  }

  private void Update()
  {
    if (((Component) this).animation.isPlaying || this.딟)
      return;
    ((Component) this.Text).gameObject.SetActive(true);
    ((Component) this.AcceptButton).gameObject.SetActive(true);
    this.딟 = true;
  }
}
