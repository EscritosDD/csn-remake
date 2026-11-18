// Decompiled with JetBrains decompiler
// Type: FriendRequestPanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

public class FriendRequestPanelHandler : MonoBehaviour
{
  private GuiScrollList3D 딟;
  private GameObject 딟;
  private FriendRequestSentPanel 딟;
  private 땓.땶 딟;
  private 딟.땣 딟;
  private bool 딟;
  private FriendRequestSentPanel 땄;
  public GameObject Overlay;
  public LoadingScreenOverlayHandler ProcessingOverlayPrefab;
  public MenuAnimatorHandler MenuAnim;
  public GuiMultiLineText3D PanelText;
  public GuiText3D ProfileName;
  public GameObject AvatarIcon;
  public LocalisationEntry FriendRequestText;
  public LocalisationEntry FriendRequestReceivedText;
  private 땄.딽 딟;
  private GameObject 땄;
  private LoadingScreenOverlayHandler 딟;
  public ErrorMessagehandler ErrorMessage;
  public EventHandler OnConfirmed;

  private void Start()
  {
  }

  public void Init(
    string MessageId,
    땄.딽 OtherUser,
    bool RequestReceived,
    FriendRequestSentPanel FriendRequestSentPanelPrefab,
    Transform StartPoint,
    Transform EndPoint)
  {
    this.MenuAnim = ((Component) this).GetComponent<MenuAnimatorHandler>();
    this.MenuAnim.StartPoint = StartPoint;
    this.MenuAnim.EndPoint = EndPoint;
    this.땄 = Object.Instantiate((Object) this.Overlay, new Vector3(0.0f, 0.79f, 0.0f), Quaternion.identity) as GameObject;
    this.딟 = OtherUser;
    this.딟 = FriendRequestSentPanelPrefab;
    this.딟 = RequestReceived;
    this.ProfileName.Text = OtherUser.땄();
    this.ProfileName.UpdateMesh();
    this.딟 = (OtherUser.땃() as 땓.땇).딧();
    this.PanelText.LocText = !RequestReceived ? this.FriendRequestText : this.FriendRequestReceivedText;
    this.PanelText.UpdateMesh();
  }

  public void PassMessageAndScoller(GameObject Message, GuiScrollList3D Scroller)
  {
    this.딟 = Message;
    this.딟 = Scroller;
  }

  private void DisplayErrorMessage(딟.땑 ErrorCode, ErrorMessagehandler.땶 ErrorType)
  {
    if (!Object.op_Inequality((Object) this.ErrorMessage, (Object) null))
      return;
    (Object.Instantiate((Object) this.ErrorMessage) as ErrorMessagehandler).Init(ErrorType, ErrorCode);
  }

  private void Update()
  {
    if (this.딟 != null && this.딟.딟())
    {
      if (this.딟.땄())
        this.AvatarIcon.renderer.sharedMaterial = this.딟.딧();
      this.딟 = (땓.땶) null;
    }
    if (this.딟 != null && this.딟.땄())
    {
      if (this.딟.땄)
        this.DisplayErrorMessage(((땄.땘) this.딟).딟, ErrorMessagehandler.땶.땺);
      else if (this.딟.딟)
        this.DisplayErrorMessage(((땄.땘) this.딟).딟, ErrorMessagehandler.땶.땥);
      else if (this.딟.딧)
      {
        this.DisplayErrorMessage(((땄.땘) this.딟).딟, ErrorMessagehandler.땶.땤);
      }
      else
      {
        if (GlobalAppData.땽().딟(딢.땹.땟) == 0)
        {
          GlobalAppData.땽().딟(딢.땹.땟, 1, true);
          Debug.Log((object) "Marking Adding Friend Offer Done");
          string addedOfferVoucherId = GlobalAppData.딧().GameSettings.FriendAddedOfferVoucherId;
          GlobalAppData.땽().땺(addedOfferVoucherId);
        }
        GlobalAppData.땽().딧(딢.땹.딧);
        if (Object.op_Inequality((Object) this.딟, (Object) null))
        {
          this.딟.RemoveItem(this.딟.transform);
          Object.Destroy((Object) this.딟.gameObject);
        }
        if (Object.op_Inequality((Object) this.딟, (Object) null))
        {
          this.땄 = Object.Instantiate((Object) this.딟, new Vector3(0.0f, 3f, 0.0f), Quaternion.identity) as FriendRequestSentPanel;
          this.땄.Init(this.딟.땄());
        }
      }
      this.MenuAnim.Close();
      this.땄.GetComponent<MenuOverlayHandler>().Close();
      if (this.OnConfirmed != null)
        this.OnConfirmed((object) this, EventArgs.Empty);
      this.딟 = (딟.땣) null;
    }
    if (this.딟 != null)
    {
      if (!Object.op_Equality((Object) this.딟, (Object) null))
        return;
      this.딟 = Object.Instantiate((Object) this.ProcessingOverlayPrefab, new Vector3(0.0f, 2f, 0.0f), Quaternion.identity) as LoadingScreenOverlayHandler;
    }
    else
    {
      if (!Object.op_Inequality((Object) this.딟, (Object) null))
        return;
      this.딟.Close();
      this.딟 = (LoadingScreenOverlayHandler) null;
    }
  }

  public void Close() => this.MenuAnim.Close();

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (FriendRequestPanelHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      FriendRequestPanelHandler.딟 = new Dictionary<string, int>(3)
      {
        {
          "ConfirmFriendRequest",
          0
        },
        {
          "Close",
          1
        },
        {
          "Reject",
          2
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!FriendRequestPanelHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        this.딟 = GlobalAppData.떏().땲(this.딟.딟());
        if (this.딟)
          break;
        딟.딦.딟("Friends_RequestSent");
        break;
      case 1:
        this.MenuAnim.Close();
        this.땄.GetComponent<MenuOverlayHandler>().Close();
        break;
      case 2:
        if (Object.op_Inequality((Object) this.딟, (Object) null))
        {
          this.딟.RemoveItem(this.딟.transform);
          Object.Destroy((Object) this.딟.gameObject);
        }
        GlobalAppData.떏().떏(this.딟.딟());
        this.MenuAnim.Close();
        this.땄.GetComponent<MenuOverlayHandler>().Close();
        break;
    }
  }

  private void OnDestroy()
  {
    GlobalAppData.땄(this.AvatarIcon);
    if (!Object.op_Inequality((Object) this.땄, (Object) null))
      return;
    Object.Destroy((Object) this.땄.gameObject);
  }
}
