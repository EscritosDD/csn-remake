// Decompiled with JetBrains decompiler
// Type: GameInviteMessageHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class GameInviteMessageHandler : MessageEntryHandler
{
  private 땄.떂 딟;
  private GameInviteConfirmPanelHandler 딟;
  private 땄.딚 딟;
  private 땄.땣 딟;
  private 땓.땶 딟;
  private 땄.땞 딟;
  private 땄.딽 딟;
  private LocalisationEntry 딟;
  private bool 딟;
  private bool 땄;
  private bool 딧;
  private bool 딢;
  private int 딟;
  public GuiButton3D Button;
  public GameObject LoadingSpinner;
  public GameObject LevelDisplayLeft;
  public GameObject LevelDisplayRight;
  public GameObject AvatarIcon;
  public GuiText3D OtherPlayerNameText;
  public GuiText3D MapNameText;
  public Shader IconShader;
  public GameObject TierIcon;
  public GuiText3D TierNumberText;
  public GuiText3D PlayerLevelText;
  public GameInviteConfirmPanelHandler GameInvitePanelPrefab;
  public GuiScrollList3D MessageScroller;
  public 딟.떊 Notification;

  public void Init(딟.떊 Message, GuiScrollList3D MessageScroller)
  {
    this.딟 = Message.떎() as 땄.떂;
    this.Notification = Message;
    this.MessageScroller = MessageScroller;
    this.딟 = GlobalAppData.떏().땟(this.딟.땄().SessionId);
    this.딟 = GlobalAppData.떏().땄(this.딟.땄().UserId, false);
    this.TierIcon.renderer.material = GlobalAppData.땲().딟(this.TierIcon.renderer.material, this.IconShader);
    this.LoadingSpinner.renderer.material = GlobalAppData.땲().딟(this.LoadingSpinner.renderer.material, this.IconShader);
    this.LevelDisplayLeft.renderer.sharedMaterial = GlobalAppData.땲().딟(this.LevelDisplayLeft.renderer.material, this.IconShader);
    this.LevelDisplayRight.renderer.sharedMaterial = GlobalAppData.땲().딟(this.LevelDisplayRight.renderer.material, this.IconShader);
  }

  public void Update()
  {
    if (this.딟 != null && this.딟.땄() && this.딟.딧())
    {
      this.딟 = this.딟.딟;
      this.딟 = true;
      this.딟 = (땄.땣) null;
      땓.땇 땇 = this.딟.땃() as 땓.땇;
      this.딟 = 땇.딢();
      this.딟 = 땇.딧();
      this.땄 = true;
    }
    if (this.딟 != null && this.딟.땄())
    {
      if (this.딟.딧())
      {
        this.딟 = this.딟.딟;
        this.ReadSessionInfo();
      }
      this.딟 = (땄.딚) null;
    }
    if (this.딟 != null && this.딟.딟())
    {
      if (this.딟.땄())
      {
        this.AvatarIcon.renderer.material = GlobalAppData.땲().딟(this.딟.딧(), this.IconShader);
        this.AvatarIcon.SetActive(true);
        this.MessageScroller.UpdateItemClipping();
      }
      else
        this.AvatarIcon.SetActive(false);
      this.딟 = (땓.땶) null;
    }
    if (!this.딟 || !this.땄 || !this.딧 || this.딟 != null || this.딢)
      return;
    this.딢 = true;
    this.SetMessageButtonInfo();
  }

  private void ReadSessionInfo()
  {
    땓.딿 딟 = this.딟.딟.딟 as 땓.딿;
    int num1 = 딟.땄();
    string str1 = GlobalAppData.땼().땄(num1);
    this.딟 = GlobalAppData.땼().딷(str1);
    int num2 = 딟.딟();
    VersionedGameData versionedGameData = GlobalAppData.땼().딟(num2);
    int index = 딟.딢();
    string str2 = "?";
    if (Object.op_Inequality((Object) versionedGameData, (Object) null))
    {
      SquadPointsTierEntry[] pointsTierEntries = versionedGameData.GenericData.SquadPointsTierEntries;
      if (index >= 0 && index < pointsTierEntries.Length)
        str2 = pointsTierEntries[index].MaxUnitSquadPoints.ToString();
    }
    this.TierNumberText.Text = str2;
    this.TierNumberText.UpdateMesh();
    this.딧 = true;
  }

  private void SetMessageButtonInfo()
  {
    this.OtherPlayerNameText.Text = this.딟.땄();
    this.OtherPlayerNameText.UpdateMesh();
    this.MapNameText.LocText = this.딟;
    this.MapNameText.UpdateMesh();
    this.PlayerLevelText.Text = this.딟.ToString();
    this.PlayerLevelText.UpdateMesh();
    this.MessageScroller.UpdateItemClipping();
    this.MessageHeader.UpdateMesh();
    this.Button.Disabled = false;
    this.LoadingOverlay.SetActive(false);
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (GameInviteMessageHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      GameInviteMessageHandler.딟 = new Dictionary<string, int>(1)
      {
        {
          "AcceptInvite",
          0
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!GameInviteMessageHandler.딟.TryGetValue(key, out num) || num != 0)
      return;
    this.딟 = Object.Instantiate((Object) this.GameInvitePanelPrefab) as GameInviteConfirmPanelHandler;
    this.딟.Init(this.딟, this.딟.땄().UserId, this.MessageScroller, this, this.딟.땄().InviteId);
  }

  private void OnDestroy()
  {
    GlobalAppData.땄(this.TierIcon);
    GlobalAppData.땄(this.AvatarIcon);
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    this.딟.Close();
  }
}
