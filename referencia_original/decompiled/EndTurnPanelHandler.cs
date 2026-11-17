// Decompiled with JetBrains decompiler
// Type: EndTurnPanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class EndTurnPanelHandler : ConfirmationPanelHandler
{
  public GameObject TutorialPulseEffect;
  public GameObject CancelButton;
  public ChatDisplay chatDisplay;

  private void Start()
  {
    bool flag = 딶.딡.땴().땼().떔() is 딶.딖;
    this.TutorialPulseEffect.SetActive(flag);
    if (!flag)
      return;
    this.EnableTutorialHand(((Component) Camera.main).transform, false);
  }

  public void OnConfirmEndTurn()
  {
    if (딶.딡.땴() != null)
    {
      if (Object.op_Inequality((Object) 딶.딡.땴().땢(), (Object) null))
      {
        딶.딡.땴().땢().CloseAllHUDGridsOnEndTurn();
        딶.딡.땴().땢().ShowCoinPot();
      }
      if (ChatDisplay.땄())
        this.SetChatLineOnTurn(true);
    }
    this.CloseConfirmationPanel(false);
    ((Component) 딶.딡.땴().땢().EndTurnButton).gameObject.SetActive(true);
  }

  public void OnCancelEndTurn()
  {
    딶.딡.땴().딷()?.땔();
    this.CloseConfirmationPanel(false);
    ((Component) 딶.딡.땴().땢().EndTurnButton).gameObject.SetActive(true);
    if (딶.딡.땴().땼().떔() is 딶.딖)
      this.EnableTutorialHand(((Component) Camera.main).transform, true);
    CameraController 딟 = 딶.딡.땴().딟;
    if (Object.op_Inequality((Object) 딟, (Object) null))
      딟.SetMode(딢.딸.딟);
    if (!ChatDisplay.땄())
      return;
    this.SetChatLineOnTurn(false);
  }

  private void SetChatLineOnTurn(bool sending)
  {
    string str = this.chatDisplay.GetLineFromNewChat();
    if (!string.IsNullOrEmpty(str))
    {
      int length = str.IndexOf("|", 0);
      if (length != -1)
        str = str.Substring(0, length);
      if (sending)
        딟.딦.딟("Chat_MessageSent");
    }
    딶.딡.땴().땼().떂().딟 = str;
  }

  public void InitailiseEndTurnPanel(
    Vector3 Pos,
    bool APRemaining,
    Transform StartPoint,
    Transform EndPoint)
  {
    this.InitialiseConfirmationPanel(Pos, new ConfirmationPanelHandler.떇(this.OnConfirmEndTurn), new ConfirmationPanelHandler.떇(this.OnCancelEndTurn), StartPoint, EndPoint);
    if (!this.chatDisplay.Init(딶.딡.땴().땼(), 땓.땝.땄))
      return;
    CameraController 딟 = 딶.딡.땴().딟;
    if (!Object.op_Inequality((Object) 딟, (Object) null))
      return;
    딟.SetMode(딢.딸.딢);
  }

  private void EnableTutorialHand(Transform Root, bool enable)
  {
    if (((Object) Root).name == "TutorialFinger_HUD" || ((Object) Root).name == "TutorialGUIPulse")
    {
      ((Component) Root).gameObject.SetActive(enable);
    }
    else
    {
      foreach (Transform Root1 in Root)
        this.EnableTutorialHand(Root1, enable);
    }
  }
}
