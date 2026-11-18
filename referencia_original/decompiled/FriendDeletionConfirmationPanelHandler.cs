// Decompiled with JetBrains decompiler
// Type: FriendDeletionConfirmationPanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class FriendDeletionConfirmationPanelHandler : MonoBehaviour
{
  private 땄.딽 딟;
  private GuiScrollList3D 딟;
  private GameObject 딟;
  private bool 딟;
  private 딟.딵 딟;
  private GameObject 땄;
  public GameObject AvatarIcon;
  public GuiButton3D AcceptButton;
  public GuiButton3D CancelButton;
  public GuiMultiLineText3D FriendDeletionMessage;
  public GameObject Overlay;

  private void Start()
  {
    this.땄 = Object.Instantiate((Object) this.Overlay, new Vector3(0.0f, 2.9f, 0.0f), Quaternion.identity) as GameObject;
    this.AvatarIcon.gameObject.SetActive(false);
    ((Component) this.AcceptButton).gameObject.SetActive(false);
    ((Component) this.CancelButton).gameObject.SetActive(false);
    ((Component) this.FriendDeletionMessage).gameObject.SetActive(false);
  }

  public void Init(
    땄.딽 OtherUser,
    Material AvatarMaterial,
    GameObject FriendButton,
    GuiScrollList3D FriendList)
  {
    this.FriendDeletionMessage.set_LocTextParms(new object[1]
    {
      (object) OtherUser.땄()
    });
    this.FriendDeletionMessage.UpdateMesh();
    this.AvatarIcon.renderer.material = GlobalAppData.땲().딟(AvatarMaterial, AvatarMaterial.shader);
    this.딟 = OtherUser;
    this.딟 = FriendButton;
    this.딟 = FriendList;
  }

  private void Update()
  {
    if (!((Component) this).animation.isPlaying && !this.딟)
    {
      this.AvatarIcon.gameObject.SetActive(true);
      ((Component) this.AcceptButton).gameObject.SetActive(true);
      ((Component) this.CancelButton).gameObject.SetActive(true);
      ((Component) this.FriendDeletionMessage).gameObject.SetActive(true);
      this.딟 = true;
    }
    if (this.딟 == null || !this.딟.땄() || !this.딟.딧())
      return;
    GlobalAppData.땢().딟(this.딟.딟());
    this.딟.RemoveItem(this.딟.transform);
    Object.Destroy((Object) this.딟.gameObject);
    this.땄.GetComponent<MenuOverlayHandler>().Close();
    Object.Destroy((Object) ((Component) this).gameObject);
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (FriendDeletionConfirmationPanelHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      FriendDeletionConfirmationPanelHandler.딟 = new Dictionary<string, int>(2)
      {
        {
          "Confirm",
          0
        },
        {
          "Close",
          1
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!FriendDeletionConfirmationPanelHandler.딟.TryGetValue(key, out num))
      return;
    if (num != 0)
    {
      if (num != 1)
        return;
      this.땄.GetComponent<MenuOverlayHandler>().Close();
      Object.Destroy((Object) ((Component) this).gameObject);
    }
    else
      this.딟 = GlobalAppData.떏().땋(this.딟.딟());
  }

  private void OnDestroy() => GlobalAppData.땄(this.AvatarIcon);
}
