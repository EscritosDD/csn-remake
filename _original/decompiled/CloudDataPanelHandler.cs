// Decompiled with JetBrains decompiler
// Type: CloudDataPanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using 딢;

public class CloudDataPanelHandler : MonoBehaviour
{
  private MenuOverlayHandler 딟;
  private bool 딟;
  private Action 딟;
  private Action 땄;
  public MenuOverlayHandler Overlay;
  public GuiButton3D ConfirmButton;
  public GuiButton3D CancelButton;
  public GuiMultiLineText3D MessageText;

  private void Start()
  {
    ((Component) this.ConfirmButton).gameObject.SetActive(false);
    ((Component) this.CancelButton).gameObject.SetActive(false);
    ((Component) this.MessageText).gameObject.SetActive(false);
    this.딟 = Object.Instantiate((Object) this.Overlay, new Vector3(0.0f, (float) (((Component) this).transform.position.y - 0.100000001490116), 0.0f), Quaternion.identity) as MenuOverlayHandler;
  }

  public void Init(땞 cloudData, Action onAccept, Action onCancel)
  {
    this.딟 = onAccept;
    this.땄 = onCancel;
    this.MessageText.set_LocTextParms(new object[1]
    {
      (object) cloudData.딢()
    });
    this.MessageText.UpdateMesh();
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (CloudDataPanelHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      CloudDataPanelHandler.딟 = new Dictionary<string, int>(2)
      {
        {
          "Accept",
          0
        },
        {
          "Cancel",
          1
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!CloudDataPanelHandler.딟.TryGetValue(key, out num))
      return;
    if (num != 0)
    {
      if (num != 1)
        return;
      this.땄();
      this.딟.Close();
      Object.Destroy((Object) ((Component) this).gameObject);
    }
    else
    {
      this.딟();
      this.딟.Close();
      Object.Destroy((Object) ((Component) this).gameObject);
    }
  }

  private void Update()
  {
    if (((Component) this).animation.isPlaying || this.딟)
      return;
    ((Component) this.ConfirmButton).gameObject.SetActive(true);
    ((Component) this.CancelButton).gameObject.SetActive(true);
    ((Component) this.MessageText).gameObject.SetActive(true);
    this.딟 = true;
  }
}
