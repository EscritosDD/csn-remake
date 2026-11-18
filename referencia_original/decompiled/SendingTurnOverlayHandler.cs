// Decompiled with JetBrains decompiler
// Type: SendingTurnOverlayHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SendingTurnOverlayHandler : MonoBehaviour
{
  public GuiText3D PleaseWaitText;
  public GuiText3D SendingTurnTextbox;
  public GuiMultiLineText3D UnableToSendTurnText;
  public LocalisationEntry SendingTurnLocText;
  public LocalisationEntry AbandonGameLocText;
  public LocalisationEntry LoadingLocText;
  public LocalisationEntry ServerDownText;
  public LocalisationEntry OpponentTooManyGamesText;
  public LocalisationEntry TooManyGamesText;
  public GameObject LoadingSpinner;
  public GuiButton3D AcceptButton;
  public GuiButton3D CancelButton;
  private string 딟 = Guid.NewGuid().ToString();
  private bool 딟;
  private bool 땄;
  private bool 딧;
  private GlobalAppState.땊 딟;
  private bool 딢;
  private bool 땃;
  private AsyncOperation 딟;
  private 딶.땙 딟;
  private 딶.땙 땄;
  private 딶.땖 딟;
  private 땄.딴 딟;
  private 땄.딮 딟;

  public void InitEndGame(딶.땖 GameState, 땓.땈 MsgType)
  {
    this.딟 = GameState;
    this.땃 = true;
    this.SetSendingText(MsgType);
    this.InstantiateOverlay();
    this.StartCleanup();
  }

  public void Init(딶.땖 GameState, 땓.땈 MsgType, bool Forfeit) => this.Init(GameState, MsgType, Forfeit, true);

  public void Init(딶.땖 GameState, GlobalAppState.땊 ReturnScreen)
  {
    this.딟 = GameState;
    this.딟 = ReturnScreen;
    this.SetSendingText(땓.땈.딧);
    this.InstantiateOverlay();
    this.StartCleanup();
  }

  public void Init(딶.땖 GameState, 땓.땈 MsgType, bool Forfeit, bool ChangeReturnScreen)
  {
    this.딟 = GameState;
    this.딟 = !ChangeReturnScreen ? GlobalAppData.딟.딟() : (!(GameState.떔() is 딶.딖) ? (GameState.떓() != 딶.딹.땄 ? GlobalAppState.땊.땃 : GlobalAppState.땊.딢) : (!GlobalAppData.땟() ? GlobalAppState.땊.딦 : GlobalAppState.땊.땭));
    if (Forfeit)
      딢.떇.땄(GameState.딛());
    this.SetSendingText(MsgType);
    this.InstantiateOverlay();
    this.StartCleanup();
  }

  public void Init(딶.땖 GameState, 땓.땈 MsgType, 딶.땙 CurrentTurn, 딶.땙 NewTurn, bool Forfeit)
  {
    this.딟 = CurrentTurn;
    this.땄 = NewTurn;
    this.딟 = GameState;
    this.딢 = Forfeit;
    this.땃 = !Forfeit ? GameState.떔().딢(GameState) : GameState.딟.땓 > 0;
    this.딟 = GlobalAppState.땊.떂;
    this.SetSendingText(MsgType);
    this.InstantiateOverlay();
    this.Submit();
  }

  private void SetSendingText(땓.땈 MsgType)
  {
    ((Component) this.SendingTurnTextbox).gameObject.SetActive(true);
    ((Component) this.UnableToSendTurnText).gameObject.SetActive(false);
    this.LoadingSpinner.SetActive(true);
    ((Component) this.PleaseWaitText).gameObject.SetActive(true);
    ((Component) this.AcceptButton).gameObject.SetActive(false);
    ((Component) this.CancelButton).gameObject.SetActive(false);
    if (!Object.op_Inequality((Object) this.SendingTurnTextbox, (Object) null))
      return;
    switch (MsgType)
    {
      case 땓.땈.딟:
        this.SendingTurnTextbox.LocText = this.SendingTurnLocText;
        break;
      case 땓.땈.땄:
        this.SendingTurnTextbox.LocText = this.AbandonGameLocText;
        break;
      default:
        this.SendingTurnTextbox.LocText = this.LoadingLocText;
        break;
    }
    this.SendingTurnTextbox.UpdateMesh();
  }

  private void InstantiateOverlay()
  {
    GameplayHUDHandler gameplayHudHandler = 딶.딡.땴().땢();
    if (!Object.op_Inequality((Object) gameplayHudHandler, (Object) null))
      return;
    gameplayHudHandler.CloseAnyOpenPanelInstancesOnExit(true);
    gameplayHudHandler.CloseReplayScreen();
    gameplayHudHandler.SetGameCameraActive(false);
    gameplayHudHandler.SetLoadingBackgroundActive(true);
    gameplayHudHandler.DeactivateGameplayHUD();
    gameplayHudHandler.HideTurnTitleScreen();
  }

  private void Submit()
  {
    ((Component) this.SendingTurnTextbox).gameObject.SetActive(true);
    ((Component) this.UnableToSendTurnText).gameObject.SetActive(false);
    this.LoadingSpinner.SetActive(true);
    ((Component) this.PleaseWaitText).gameObject.SetActive(true);
    ((Component) this.AcceptButton).gameObject.SetActive(false);
    ((Component) this.CancelButton).gameObject.SetActive(false);
    string str1 = 딧.땾.땄((object) this.딟.딟());
    string 딧 = this.딟.딟.딧;
    string str2 = this.딟.딟.땄[this.땄.땃()];
    int 땓 = this.딟.딟.땓;
    EnvironmentSettings_Game gameSettings = GlobalAppData.딧().GameSettings;
    if (this.딢)
    {
      int index1 = this.딟.땂();
      int index2 = (index1 + 1) % 2;
      Dictionary<string, 딟.땾> dictionary = new Dictionary<string, 딟.땾>();
      dictionary.Add(this.딟.딟.땄[index1], 딟.땾.딶);
      this.딟.딟.딟[index1] = 딟.땾.딶;
      if (땓 == 0)
      {
        this.StartCleanup();
      }
      else
      {
        dictionary.Add(this.딟.딟.땄[index2], 딟.땾.딧);
        this.딟.딟.딟[index2] = 딟.땾.딧;
        int num1;
        int num2;
        this.딟.딟(index2, index1, out num1, out num2);
        List<딟.떀> 떀List = new List<딟.떀>();
        떀List.Add((딟.떀) new TurnOp_AddToInventory(this.딟.딟.땄[index2], gameSettings.CurrencyCoinsId, num1));
        떀List.Add((딟.떀) new TurnOp_AddToInventory(this.딟.딟.땄[index1], gameSettings.CurrencyCoinsId, num2));
        this.딧 = true;
        if (땓 == 1)
        {
          TacticsInitialTurnState initialTurnState = new TacticsInitialTurnState(this.딟.딟(1), str1);
          this.딟 = GlobalAppData.떏().딟(딧, 땓, str2, 딧.땾.땄((object) initialTurnState), dictionary, 떀List);
        }
        else
          this.딟 = GlobalAppData.떏().딟(딧, 땓, str2, str1, dictionary, 떀List);
      }
    }
    else
    {
      switch (땓)
      {
        case 0:
          if (!딶.떍.땃(this.딟))
          {
            땓.땙 땙 = new 땓.땙();
            땙.땄 = this.딟.딟.딟;
            if (!string.IsNullOrEmpty(this.딟.딟.땄[1]))
              땙.땄 = this.딟.딟.땄[1];
            땙.딢 = this.딟.딟.딶;
            땙.딟 = this.딟.딟.땄;
            땙.딧 = this.딟.딟.딢;
            땙.딟 = this.딟.딟.땄;
            땙.딟 = this.딟.땜()[0].딟;
            땙.딢 = this.딟;
            TacticsInitialTurnState initialTurnState = new TacticsInitialTurnState(this.딟.딟(0), str1);
            땙.딧 = 딧.땾.땄((object) initialTurnState);
            this.딟 = GlobalAppData.떏().딟(땙);
            break;
          }
          this.StartCleanup();
          break;
        case 1:
          TacticsInitialTurnState initialTurnState1 = new TacticsInitialTurnState(this.딟.딟(1), str1);
          this.딟 = GlobalAppData.떏().딟(딧, 땓, str2, 딧.땾.땄((object) initialTurnState1), this.딟.땜()[1].딟);
          break;
        default:
          if (this.딟.떔().딢(this.딟))
          {
            int index3 = this.딟.떔().땃(this.딟);
            int index4 = (index3 + 1) % 2;
            Dictionary<string, 딟.땾> dictionary = new Dictionary<string, 딟.땾>();
            dictionary.Add(this.딟.딟.땄[index3], 딟.땾.딧);
            this.딟.딟.딟[index3] = 딟.땾.딧;
            dictionary.Add(this.딟.딟.땄[index4], 딟.땾.딢);
            this.딟.딟.딟[index4] = 딟.땾.딢;
            int num3;
            int num4;
            this.딟.딟(index3, index4, out num3, out num4);
            List<딟.떀> 떀List = new List<딟.떀>();
            떀List.Add((딟.떀) new TurnOp_AddToInventory(this.딟.딟.땄[index3], gameSettings.CurrencyCoinsId, num3));
            떀List.Add((딟.떀) new TurnOp_AddToInventory(this.딟.딟.땄[index4], gameSettings.CurrencyCoinsId, num4));
            this.딧 = true;
            this.딟 = GlobalAppData.떏().딟(딧, 땓, str2, str1, dictionary, 떀List);
            break;
          }
          List<딟.떀> 떀List1 = new List<딟.떀>();
          bool flag1 = false;
          bool flag2 = false;
          if (땓 <= 3 && !this.딟)
          {
            if (GlobalAppData.땽().딶(gameSettings.XPBoostId))
            {
              떀List1.Add((딟.떀) new TurnOp_Consume(gameSettings.XPBoostId, 1));
              this.땄 = true;
              flag2 = true;
            }
            if (GlobalAppData.땽().딶(gameSettings.CoinsBoostId))
            {
              떀List1.Add((딟.떀) new TurnOp_Consume(gameSettings.CoinsBoostId, 1));
              this.땄 = true;
              flag1 = true;
            }
          }
          List<딟.떀> 떀List2 = this.딟.땄(flag1, flag2);
          this.딟 = GlobalAppData.떏().딟(딧, 땓, str2, str1, 떀List1, 떀List2);
          break;
      }
    }
  }

  private void StartCleanup()
  {
    if (this.딧)
    {
      this.딧 = false;
      땺.땃 땃 = new 땺.땃(딶.딡.땴().땼(), true);
    }
    딶.딡.땴().땲();
    foreach (땓.딲 딲 in this.딟.땻())
      딲.땴();
    List<딟.땩> 땩List = new List<딟.땩>();
    땩List.Add((딟.땩) GlobalAppData.땼().땻(this.딟.딟.땄));
    GlobalAppData.땃();
    GlobalAppData.딟.떏();
    GlobalAppData.땼().딟(땩List);
    this.딟 = Resources.UnloadUnusedAssets();
    딶.딡.땴().땼().땄();
    딶.딡.딟((딶.딡) null);
  }

  public void Update()
  {
    if (this.딟 != null && this.딟.땄())
    {
      bool flag1 = this.딟.딧() || this.딟.땄;
      bool 딟 = this.딟.딟;
      bool flag2 = this.딟.딟();
      this.딟 = (땄.딴) null;
      if (flag1)
      {
        if (!this.딢)
          SendingTurnOverlayHandler.딟();
        if (this.땄)
          GlobalAppData.떏().땟();
        this.StartCleanup();
      }
      else
      {
        this.딟 = 딟;
        this.땄 = false;
        if (this.딟.떓() == 딶.딹.딧)
        {
          if (flag2)
          {
            this.UnableToSendTurnText.LocText = this.ServerDownText;
            this.UnableToSendTurnText.UpdateMesh();
          }
          ((Component) this.UnableToSendTurnText).gameObject.SetActive(true);
          this.LoadingSpinner.SetActive(false);
          ((Component) this.PleaseWaitText).gameObject.SetActive(false);
          ((Component) this.SendingTurnTextbox).gameObject.SetActive(false);
          ((Component) this.AcceptButton).gameObject.SetActive(true);
          ((Component) this.CancelButton).gameObject.SetActive(true);
        }
      }
    }
    if (this.딟 != null && this.딟.땄())
    {
      bool flag3 = this.딟.딧() || this.딟.딧;
      bool flag4 = this.딟.딟();
      bool 땄 = this.딟.땄;
      bool 딟 = this.딟.딟;
      this.딟 = (땄.딮) null;
      if (flag3)
      {
        딢.땚.딟(this.딟.딟.땄[1]);
        딟.딦.딟("StartedMPSession", new Dictionary<string, string>()
        {
          {
            "levelid",
            this.딟.딟.땄
          },
          {
            "squadpoints",
            this.딟.땞().GenericData.땃(this.딟.딟.딢).MaxUnitSquadPoints.ToString()
          }
        });
        SendingTurnOverlayHandler.딟();
        this.StartCleanup();
      }
      else
      {
        if (flag4)
        {
          this.UnableToSendTurnText.LocText = this.ServerDownText;
          this.UnableToSendTurnText.UpdateMesh();
        }
        else if (땄)
        {
          this.UnableToSendTurnText.LocText = this.OpponentTooManyGamesText;
          this.UnableToSendTurnText.UpdateMesh();
        }
        else if (딟)
        {
          this.UnableToSendTurnText.LocText = this.TooManyGamesText;
          this.UnableToSendTurnText.UpdateMesh();
        }
        ((Component) this.UnableToSendTurnText).gameObject.SetActive(true);
        this.LoadingSpinner.SetActive(false);
        ((Component) this.PleaseWaitText).gameObject.SetActive(false);
        ((Component) this.SendingTurnTextbox).gameObject.SetActive(false);
        ((Component) this.AcceptButton).gameObject.SetActive(true);
        ((Component) this.CancelButton).gameObject.SetActive(true);
      }
    }
    if (this.딟 == null || !this.딟.isDone)
      return;
    this.딟 = (AsyncOperation) null;
    if (this.땃)
    {
      딢.딳.땄(this.딟);
    }
    else
    {
      if (this.딟.떔() is 딶.딖)
        GlobalAppData.딟.딟(this.딟);
      else
        GlobalAppData.딟.딟(GlobalAppState.땊.떂);
      Application.LoadLevelAsync(GlobalAppData.딟.EnvSettings.ScenesAsset.Data.땄());
    }
  }

  private static void 딟()
  {
    if (GlobalAppData.땽().딟(딢.땹.딶) != 0)
      return;
    GlobalAppData.땽().땺(GlobalAppData.딧().GameSettings.MPTurnBonusVoucherId);
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (SendingTurnOverlayHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      SendingTurnOverlayHandler.딟 = new Dictionary<string, int>(2)
      {
        {
          "Resend",
          0
        },
        {
          "Cancel",
          1
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!SendingTurnOverlayHandler.딟.TryGetValue(key, out num))
      return;
    if (num != 0)
    {
      if (num != 1)
        return;
      ((Component) this.AcceptButton).gameObject.SetActive(false);
      ((Component) this.CancelButton).gameObject.SetActive(false);
      this.LoadingSpinner.SetActive(true);
      ((Component) this.PleaseWaitText).gameObject.SetActive(true);
      ((Component) this.UnableToSendTurnText).gameObject.SetActive(false);
      this.SendingTurnTextbox.LocText = this.LoadingLocText;
      this.SendingTurnTextbox.UpdateMesh();
      ((Component) this.SendingTurnTextbox).gameObject.SetActive(true);
      GlobalAppData.딟.딟(this.딟);
      Application.LoadLevelAsync(GlobalAppData.딟.EnvSettings.ScenesAsset.Data.땄());
    }
    else
      this.Submit();
  }
}
