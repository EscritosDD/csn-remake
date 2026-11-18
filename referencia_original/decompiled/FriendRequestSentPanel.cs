// Decompiled with JetBrains decompiler
// Type: FriendRequestSentPanel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class FriendRequestSentPanel : MonoBehaviour
{
  private GameObject 딟;
  private bool 딟;
  public GuiMultiLineText3D FriendRequestSentText;
  public GameObject Overlay;
  public GuiButton3D AcceptButton;
  public GuiMultiLineText3D FriendRequestText;

  private void Start()
  {
    this.딟 = Object.Instantiate((Object) this.Overlay, new Vector3(0.0f, 2.9f, 0.0f), Quaternion.identity) as GameObject;
    ((Component) this.AcceptButton).gameObject.SetActive(false);
    ((Component) this.FriendRequestText).gameObject.SetActive(false);
  }

  public void Init(string OtherProfileName)
  {
    this.FriendRequestSentText.set_LocTextParms(new object[1]
    {
      (object) OtherProfileName
    });
    this.FriendRequestSentText.UpdateMesh();
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (FriendRequestSentPanel.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      FriendRequestSentPanel.딟 = new Dictionary<string, int>(1)
      {
        {
          "Close",
          0
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!FriendRequestSentPanel.딟.TryGetValue(key, out num) || num != 0)
      return;
    this.딟.GetComponent<MenuOverlayHandler>().Close();
    Object.Destroy((Object) ((Component) this).gameObject);
  }

  private void Update()
  {
    if (((Component) this).animation.isPlaying || this.딟)
      return;
    ((Component) this.AcceptButton).gameObject.SetActive(true);
    ((Component) this.FriendRequestText).gameObject.SetActive(true);
    this.딟 = true;
    GuiComponent3D.딟((GuiComponent3D) this.AcceptButton);
  }
}
