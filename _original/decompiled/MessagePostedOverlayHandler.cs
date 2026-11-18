// Decompiled with JetBrains decompiler
// Type: MessagePostedOverlayHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

public class MessagePostedOverlayHandler : MonoBehaviour
{
  private MenuOverlayHandler 딟;
  private bool 딟;
  public MenuOverlayHandler Overlay;
  public GuiButton3D ConfirmButton;
  public GuiText3D HeaderText;
  public GuiMultiLineText3D MessageText;
  public EventHandler OnClosing;

  private void Start()
  {
    ((Component) this.ConfirmButton).gameObject.SetActive(false);
    ((Component) this.HeaderText).gameObject.SetActive(false);
    ((Component) this.MessageText).gameObject.SetActive(false);
    this.딟 = Object.Instantiate((Object) this.Overlay, new Vector3(0.0f, (float) (((Component) this).transform.position.y - 0.100000001490116), 0.0f), Quaternion.identity) as MenuOverlayHandler;
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (MessagePostedOverlayHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      MessagePostedOverlayHandler.딟 = new Dictionary<string, int>(1)
      {
        {
          "Close",
          0
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!MessagePostedOverlayHandler.딟.TryGetValue(key, out num) || num != 0)
      return;
    this.딟.Close();
    if (this.OnClosing != null)
      this.OnClosing((object) this, EventArgs.Empty);
    Object.Destroy((Object) ((Component) this).gameObject);
  }

  private void Update()
  {
    if (((Component) this).animation.isPlaying || this.딟)
      return;
    ((Component) this.ConfirmButton).gameObject.SetActive(true);
    ((Component) this.HeaderText).gameObject.SetActive(true);
    ((Component) this.MessageText).gameObject.SetActive(true);
    this.딟 = true;
    GuiComponent3D.딟((GuiComponent3D) this.ConfirmButton);
  }
}
