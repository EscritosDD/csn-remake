// Decompiled with JetBrains decompiler
// Type: FriendRequestButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Gui3D/Controls/Friend Request Button")]
public class FriendRequestButton : MonoBehaviour
{
  private 땄.떏 딟;
  private string 딟;
  private object[] 딟;
  private FriendRequestPanelHandler 딟;
  private 땄.땣 딟;
  private GuiScrollList3D 딟;
  private ChallengeFriendScreenHandler 딟;
  private 땓.땶 딟;
  private 땄.딽 딟;
  public GuiMultiLineText3D MessageHeader;
  public GuiButton3D SelectionButton;
  public GameObject AvatarBackground;
  public GameObject AvatarIcon;
  public GameObject FacebookIcon;
  public GameObject ProfileRankBackground;
  public GuiText3D ProfileRank;
  public GameObject ButtonLeft;
  public GameObject ButtonMiddle;
  public GameObject ButtonRight;
  public Material AvatarBackgroundMaterial;
  public Shader IconShader;
  public FriendRequestPanelHandler FriendRequestPanelPrefab;
  public LocalisationEntry FriendRequestReceived;
  public LocalisationEntry FriendRequestRejected;
  public LocalisationEntry FriendRequestAccepted;
  public LocalisationEntry FriendshipEnded;

  public void Init(딟.떊 Message, GuiScrollList3D List, ChallengeFriendScreenHandler ChallengeScreen)
  {
    this.딟 = Message.떎() as 땄.떏;
    this.딟 = List;
    this.딟 = Message.땄();
    this.딟 = ChallengeScreen;
    this.딟 = GlobalAppData.떏().땄(this.딟.땄().UserId, false);
    this.FacebookIcon.SetActive(false);
    this.ProfileRankBackground.renderer.sharedMaterial = GlobalAppData.땲().딟(this.ProfileRankBackground.renderer.material, this.IconShader);
    this.ButtonLeft.renderer.sharedMaterial = GlobalAppData.땲().딟(this.ButtonLeft.renderer.material, this.IconShader);
    this.ButtonMiddle.renderer.sharedMaterial = GlobalAppData.땲().딟(this.ButtonMiddle.renderer.material, this.IconShader);
    this.ButtonRight.renderer.sharedMaterial = GlobalAppData.땲().딟(this.ButtonRight.renderer.material, this.IconShader);
    this.SelectionButton.Disabled = false;
  }

  private void Update()
  {
    if (this.딟 != null && this.딟.땄())
    {
      if (this.딟.딧())
      {
        this.딟 = this.딟.딟;
        this.SetMessageButtonInfo();
        땓.땇 땇 = this.딟.땃() as 땓.땇;
        this.ProfileRank.Text = 땇.딢().ToString();
        this.ProfileRank.UpdateMesh();
        this.딟 = 땇.딧();
        this.딟.UpdateItemClipping();
      }
      this.딟 = (땄.땣) null;
    }
    if (this.딟 == null || !this.딟.딟())
      return;
    if (this.딟.땄())
    {
      this.AvatarIcon.renderer.material = GlobalAppData.땲().딟(this.딟.딧(), this.IconShader);
      this.AvatarBackground.renderer.sharedMaterial = GlobalAppData.땲().딟(this.AvatarBackgroundMaterial, this.IconShader);
      this.딟.UpdateItemClipping();
    }
    this.딟 = (땓.땶) null;
  }

  private void SetMessageButtonInfo()
  {
    this.딟 = new object[1];
    this.딟[0] = (object) this.딟.땄();
    if (this.딟 is 땄.땼)
    {
      this.SelectionButton.Command = "AcceptInvite";
      this.MessageHeader.LocText = this.FriendRequestReceived;
    }
    else if (this.딟 is 땄.딷)
    {
      this.SelectionButton.Command = "MessageRead";
      this.MessageHeader.LocText = this.FriendRequestRejected;
    }
    else if (this.딟 is 땄.땢)
    {
      this.SelectionButton.Command = "MessageRead";
      this.MessageHeader.LocText = this.FriendRequestAccepted;
    }
    else if (this.딟 is 땄.떁)
    {
      this.SelectionButton.Command = "MessageRead";
      this.MessageHeader.LocText = this.FriendshipEnded;
    }
    this.MessageHeader.set_LocTextParms(this.딟);
    this.MessageHeader.UpdateMesh();
    this.SelectionButton.Disabled = false;
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (FriendRequestButton.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      FriendRequestButton.딟 = new Dictionary<string, int>(2)
      {
        {
          "AcceptInvite",
          0
        },
        {
          "MessageRead",
          1
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!FriendRequestButton.딟.TryGetValue(key, out num))
      return;
    if (num != 0)
    {
      if (num != 1)
        return;
      GlobalAppData.떏().땢(this.딟);
      GlobalAppData.땢().땄(this.딟);
      this.딟.RemoveItem(((Component) this).transform);
      Object.Destroy((Object) ((Component) this).gameObject);
    }
    else
    {
      Transform startPoint = FrontendHub.딟.ChallengeFriendScreen.StartPoint;
      Transform endPoint = FrontendHub.딟.ChallengeFriendScreen.EndPoint;
      this.딟 = Object.Instantiate((Object) this.FriendRequestPanelPrefab) as FriendRequestPanelHandler;
      ((Component) this.딟).transform.parent = ((Component) this).transform;
      this.딟.Init(this.딟, this.딟, true, (FriendRequestSentPanel) null, startPoint, endPoint);
      this.딟.PassMessageAndScoller(((Component) this).gameObject, this.딟);
      this.딟.OnConfirmed += new EventHandler(this.RefreshChallengeScreen);
      GlobalAppData.떏().땢(this.딟);
    }
  }

  private void RefreshChallengeScreen(object Sender, EventArgs Args) => this.딟.Refresh();

  public void SetAvatarIcon(Texture2D Image)
  {
    if (Object.op_Equality((Object) Image, (Object) null) || !Object.op_Inequality((Object) this.AvatarIcon, (Object) null))
      return;
    this.AvatarIcon.renderer.material.mainTexture = (Texture) Image;
  }

  private void OnDestroy()
  {
    if (Object.op_Inequality((Object) this.딟, (Object) null))
      Object.Destroy((Object) ((Component) this.딟).gameObject);
    GlobalAppData.땄(this.AvatarIcon);
  }
}
