// Decompiled with JetBrains decompiler
// Type: GameInviteConfirmPanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class GameInviteConfirmPanelHandler : MonoBehaviour
{
  private MenuAnimatorHandler 딟;
  private 땄.땞 딟;
  private string 딟;
  private GameObject 딟;
  private string 땄;
  private 딢.딪 딟;
  public GameObject Overlay;
  public GuiScrollList3D Scroller;
  public GameInviteMessageHandler Message;
  public GameLimit GameLimitPrefab;
  public EngineVersionChecker VersionCheckerPrefab;

  private void Start() => this.딟 = Object.Instantiate((Object) this.Overlay, new Vector3(0.0f, 0.9f, 0.0f), Quaternion.identity) as GameObject;

  public void Init(
    땄.땞 InviteSession,
    string UserId,
    GuiScrollList3D Scroller,
    GameInviteMessageHandler Message,
    string InviteId)
  {
    this.딟 = ((Component) this).GetComponent<MenuAnimatorHandler>();
    this.딟.StartPoint = FrontendHub.딟.MultiPlayerScreen.StartPoint;
    this.딟.EndPoint = FrontendHub.딟.MultiPlayerScreen.EndPoint;
    this.딟 = InviteSession;
    this.딟 = UserId;
    this.Message = Message;
    this.Scroller = Scroller;
    this.땄 = InviteId;
  }

  private void Update()
  {
    if (this.딟 == null)
      return;
    this.딟.딟();
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (GameInviteConfirmPanelHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      GameInviteConfirmPanelHandler.딟 = new Dictionary<string, int>(3)
      {
        {
          "Close",
          0
        },
        {
          "ConfirmGameInvite",
          1
        },
        {
          "RejectGameInvite",
          2
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!GameInviteConfirmPanelHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        this.Close();
        break;
      case 1:
        if (this.딟 == null)
          break;
        this.딟 = new 딢.딪();
        this.딟.딟(this.GameLimitPrefab, this.VersionCheckerPrefab, new 딢.딪.떕(this.OnGameStartFailed), new 딢.딪.떕(this.OnGameStartSucceeded));
        break;
      case 2:
        if (Object.op_Inequality((Object) this.Message, (Object) null))
        {
          GlobalAppData.떏().딱(this.땄);
          this.Scroller.RemoveItem(((Component) this.Message).transform);
          Object.Destroy((Object) ((Component) this.Message).gameObject);
        }
        this.딟.Close();
        this.딟.GetComponent<MenuOverlayHandler>().Close();
        break;
    }
  }

  public void Close()
  {
    this.딟.Close();
    this.딟.GetComponent<MenuOverlayHandler>().Close();
  }

  private void OnGameStartFailed() => this.딟 = (딢.딪) null;

  private void OnGameStartSucceeded()
  {
    this.딟 = (딢.딪) null;
    this.딟.Close();
    this.딟.GetComponent<MenuOverlayHandler>().Close();
    if (Object.op_Inequality((Object) this.Message, (Object) null))
    {
      this.Scroller.RemoveItem(((Component) this.Message).transform);
      Object.Destroy((Object) ((Component) this.Message).gameObject);
    }
    땓.딿 딟 = this.딟.딟 as 땓.딿;
    딧.땧 LoadingInfo = new 딧.땧(딟.딟(), 딶.딹.딧);
    LoadingInfo.딟(this.딟);
    LoadingInfo.딧(true);
    LoadingInfo.땄(this.딟);
    LoadingInfo.딟(GlobalAppData.땼().땄(딟.땄()));
    LoadingInfo.땄(딟.딢());
    FrontendHub.딟.MultiPlayerScreen.DeactivateMenu();
    FrontendHub.딟.CommanderAbilityScreen.TryActivateMenu(딶.땂.땄, LoadingInfo, (BaseMenuHandler) FrontendHub.딟.MultiPlayerScreen);
  }
}
