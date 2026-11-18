// Decompiled with JetBrains decompiler
// Type: StoreQuickPurchaseWarbuxButtonHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using UnityEngine;

public class StoreQuickPurchaseWarbuxButtonHandler : MonoBehaviour
{
  public GuiButton3D Button;
  public GameObject ItemIcon;
  public GuiText3D ButtonText;
  public Material AvatarIconMaterial;

  public void Init(딟.땫 ImageCache, 땃.딷 Item)
  {
    this.ItemIcon.gameObject.SetActive(false);
    ImageCache?.딟((Item.땃().땃() as 땓.딞).딦().딟(), new Action(this.OnImageDownloadFailure), new Action<Texture2D>(this.OnImageDownloadSuccess));
    this.Button.set_CustomPressFunc("QuickPurchaseWarbux");
    this.Button.set_CustomPressValue((object) Item);
    this.ButtonText.Text = Item.딢();
    this.ButtonText.UpdateMesh();
  }

  private void OnImageDownloadFailure()
  {
  }

  private void OnImageDownloadSuccess(Texture2D Image)
  {
    if (Object.op_Equality((Object) this.ItemIcon, (Object) null))
      return;
    GlobalAppData.딟(this.ItemIcon.renderer.material);
    딧.딼.딟(this.ItemIcon, this.AvatarIconMaterial, Image);
    this.ItemIcon.SetActive(true);
  }

  private void OnDestroy() => GlobalAppData.땄(this.ItemIcon);
}
