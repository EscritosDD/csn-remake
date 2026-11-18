// Decompiled with JetBrains decompiler
// Type: StoreChallengeInfoPanelhandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StoreChallengeInfoPanelhandler : StorePanel
{
  private MenuAnimatorHandler 딟;
  private MenuOverlayHandler 딟;
  private 땃.딷 딟;
  public GuiMultiLineText3D ChallengeTitleText;
  public GuiMultiLineText3D Description;
  public GameObject ItemIcon;
  public Material AvatarIconMaterial;
  public GameObject LoadingIcon;
  public MenuOverlayHandler OverlayPrefab;

  private void Start()
  {
  }

  public void Init(StoreItemButton.떎 StoreItemInfo, Transform StartPoint, Transform EndPoint)
  {
    // ISSUE: reference to a compiler-generated method
    this.set_LocalImageCache(new 딟.땫(256, (딟.땇) GlobalAppData.떏()));
    this.딟 = StoreItemInfo.딟;
    땓.딠 딠 = this.딟.땃().딢() as 땓.딠;
    땓.딞 딞 = this.딟.땃().땃() as 땓.딞;
    this.딟 = ((Component) this).GetComponent<MenuAnimatorHandler>();
    this.딟.StartPoint = StartPoint;
    this.딟.EndPoint = EndPoint;
    this.딟 = Object.Instantiate((Object) this.OverlayPrefab, new Vector3(0.0f, this.딟.YVal - 0.1f, 0.0f), Quaternion.identity) as MenuOverlayHandler;
    this.ItemIcon.SetActive(false);
    this.get_LocalImageCache().딟(딞.땤().딟(), new Action(this.OnImageDownloadFailure), new Action<Texture2D>(this.OnImageDownloadSuccess));
    this.ChallengeTitleText.Text = 딠.땄();
    this.ChallengeTitleText.UpdateMesh();
    this.Description.Text = 딠.딢();
    this.Description.UpdateMesh();
  }

  private void OnImageDownloadFailure()
  {
  }

  private void OnImageDownloadSuccess(Texture2D Image)
  {
    if (Object.op_Equality((Object) this.ItemIcon, (Object) null))
      return;
    this.LoadingIcon.SetActive(false);
    GlobalAppData.딟(this.ItemIcon.renderer.material);
    딧.딼.딟(this.ItemIcon, this.AvatarIconMaterial, Image);
    this.ItemIcon.SetActive(true);
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (StoreChallengeInfoPanelhandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      StoreChallengeInfoPanelhandler.딟 = new Dictionary<string, int>(1)
      {
        {
          "Close",
          0
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!StoreChallengeInfoPanelhandler.딟.TryGetValue(key, out num) || num != 0)
      return;
    this.Close();
  }

  public override void Close()
  {
    this.딟.Close();
    this.딟.Close();
  }

  private void OnDestroy()
  {
    GlobalAppData.땄(this.ItemIcon);
    if (this.get_LocalImageCache() == null)
      return;
    this.get_LocalImageCache().Dispose();
    // ISSUE: reference to a compiler-generated method
    this.set_LocalImageCache((딟.땫) null);
  }

  [CompilerGenerated]
  [SpecialName]
  public 딟.땫 get_LocalImageCache() => this.딟;
}
