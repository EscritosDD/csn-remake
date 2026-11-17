// Decompiled with JetBrains decompiler
// Type: AbandonGamePanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using 딶;

public class AbandonGamePanelHandler : ConfirmationPanelHandler
{
  public GuiMultiLineText3D AbandonGameText;
  public LocalisationEntry AbandonGameLocText;
  public LocalisationEntry ExitTryoutLocText;
  public LocalisationEntry ForfeitGameLocText;
  public LocalisationEntry AbandonGameTitle;
  public LocalisationEntry ExitTryoutTitle;
  public GuiText3D TitleText;
  private bool 딟;

  private void Start()
  {
    this.TitleText.LocText = this.AbandonGameTitle;
    if (딶.딡.땴().땼().떓() == 딹.딧)
    {
      this.AbandonGameText.LocText = this.ForfeitGameLocText;
      this.AbandonGameText.set_LocTextParms(new object[1]
      {
        (object) 딶.딡.땴().땼().때()
      });
    }
    else if (딶.딡.땴().땼().떔() is 딶.딴)
    {
      this.AbandonGameText.LocText = this.ExitTryoutLocText;
      this.TitleText.LocText = this.ExitTryoutTitle;
    }
    else
      this.AbandonGameText.LocText = this.AbandonGameLocText;
    this.AbandonGameText.UpdateMesh();
    this.TitleText.UpdateMesh();
  }

  public void OnConfirmAbandonGame()
  {
    Time.timeScale = 1f;
    this.CloseConfirmationPanel(false);
    if (딶.딡.땴().땼().떓() == 딹.딧)
    {
      딟.딦.딟("MP_AbandonGame", new Dictionary<string, string>()
      {
        {
          "level",
          딶.딡.땴().땼().딟.땄
        }
      });
      딶.딡.땴().땼().딟(true);
      딶.딡.땴().땼().딟(true, true);
    }
    else if (딶.딡.땴().땼().떓() == 딹.땄)
    {
      Dictionary<string, string> dictionary = new Dictionary<string, string>();
      GlobalAppData.땽().딟(딶.딡.땴().땼(), dictionary);
      딟.딦.딟("SP_AbandonGame", dictionary);
      딶.딡.땴().떎();
    }
    else
      딶.딡.땴().떎();
  }

  public void OnCancelAbandonGame()
  {
    if (this.딟)
      딶.딡.땴().땢().OpenPausePanel();
    this.CloseConfirmationPanel(false);
  }

  public void InitailiseAbandonGamePanel(
    Vector3 Pos,
    bool openPausePanelOnClose,
    Transform StartPoint,
    Transform EndPoint)
  {
    this.InitialiseConfirmationPanel(Pos, new ConfirmationPanelHandler.떇(this.OnConfirmAbandonGame), new ConfirmationPanelHandler.떇(this.OnCancelAbandonGame), StartPoint, EndPoint);
    this.딟 = openPausePanelOnClose;
  }
}
