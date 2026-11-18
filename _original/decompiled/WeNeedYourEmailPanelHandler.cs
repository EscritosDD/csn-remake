// Decompiled with JetBrains decompiler
// Type: WeNeedYourEmailPanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class WeNeedYourEmailPanelHandler : MonoBehaviour
{
  private bool 딟;
  private GameObject 딟;
  public GuiButton3D ContinueButton;
  public GuiText3D HeaderText;
  public GuiMultiLineText3D DescriptionText;
  public GameObject Overlay;

  private void Start()
  {
    ((Component) this.ContinueButton).gameObject.SetActive(false);
    ((Component) this.HeaderText).gameObject.SetActive(false);
    ((Component) this.DescriptionText).gameObject.SetActive(false);
    this.딟 = Object.Instantiate((Object) this.Overlay, new Vector3(0.0f, (float) (((Component) this).transform.position.y - 0.100000001490116), 0.0f), Quaternion.identity) as GameObject;
  }

  private void Update()
  {
    if (this.딟 || ((Component) this).animation.isPlaying)
      return;
    ((Component) this.ContinueButton).gameObject.SetActive(true);
    ((Component) this.HeaderText).gameObject.SetActive(true);
    ((Component) this.DescriptionText).gameObject.SetActive(true);
    this.딟 = true;
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (WeNeedYourEmailPanelHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      WeNeedYourEmailPanelHandler.딟 = new Dictionary<string, int>(1)
      {
        {
          "Close",
          0
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!WeNeedYourEmailPanelHandler.딟.TryGetValue(key, out num) || num != 0)
      return;
    this.딟.GetComponent<MenuOverlayHandler>().Close();
    Object.Destroy((Object) ((Component) this).gameObject);
  }
}
