// Decompiled with JetBrains decompiler
// Type: ExitGamePanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;
using 딶;

public class ExitGamePanelHandler : ConfirmationPanelHandler
{
  private bool 딟;
  private bool 땄;
  public LocalisationEntry ExitGameHeader;
  public LocalisationEntry ExitGameText;
  public LocalisationEntry ExitTryoutHeader;
  public LocalisationEntry ExitTryoutText;
  public GuiText3D Header;
  public GuiMultiLineText3D Text;

  private void Start()
  {
    if (딶.딡.땴().땼().떔() is 딴)
    {
      this.Text.LocText = this.ExitTryoutText;
      this.Header.LocText = this.ExitTryoutHeader;
    }
    else
    {
      this.Header.LocText = this.ExitGameHeader;
      this.Text.LocText = this.ExitGameText;
    }
    this.Header.UpdateMesh();
    this.Text.UpdateMesh();
  }

  public void OnConfirmExitGame()
  {
    Time.timeScale = 1f;
    딶.딡.땴().딢(this.딟);
    GlobalAppData.딟(false);
  }

  public void OnCancelExitGame()
  {
    if (this.땄)
      딶.딡.땴().땢().OpenPausePanel();
    this.CloseConfirmationPanel(false);
  }

  public void InitailiseExitGamePanel(
    Vector3 Pos,
    bool QuitToCurrentReturnScreen,
    bool openPausePanelOnClose,
    Transform StartPoint,
    Transform EndPoint)
  {
    this.딟 = QuitToCurrentReturnScreen;
    this.땄 = openPausePanelOnClose;
    this.InitialiseConfirmationPanel(Pos, new ConfirmationPanelHandler.떇(this.OnConfirmExitGame), new ConfirmationPanelHandler.떇(this.OnCancelExitGame), StartPoint, EndPoint);
  }
}
