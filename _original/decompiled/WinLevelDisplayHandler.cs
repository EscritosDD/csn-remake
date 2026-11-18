// Decompiled with JetBrains decompiler
// Type: WinLevelDisplayHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class WinLevelDisplayHandler : MonoBehaviour
{
  private bool 딟;
  private GameObject 딟;
  public GameObject Overlay;
  public GuiButton3D AcceptButton;
  public GameObject Ticks;
  public GuiText3D WinLevelstext;

  private void Start()
  {
    ((Component) this.AcceptButton).gameObject.SetActive(false);
    this.Ticks.SetActive(false);
    ((Component) this.WinLevelstext).gameObject.SetActive(false);
    this.딟 = Object.Instantiate((Object) this.Overlay, new Vector3(0.0f, (float) (((Component) this).transform.position.y - 0.100000001490116), 0.0f), Quaternion.identity) as GameObject;
  }

  private void Update()
  {
    if (((Component) this).animation.isPlaying || this.딟)
      return;
    ((Component) this.AcceptButton).gameObject.SetActive(true);
    this.Ticks.SetActive(true);
    ((Component) this.WinLevelstext).gameObject.SetActive(true);
    this.딟 = true;
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (WinLevelDisplayHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      WinLevelDisplayHandler.딟 = new Dictionary<string, int>(1)
      {
        {
          "Close",
          0
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!WinLevelDisplayHandler.딟.TryGetValue(key, out num) || num != 0)
      return;
    this.딟.GetComponent<MenuOverlayHandler>().Close();
    Object.Destroy((Object) ((Component) this).gameObject);
  }
}
