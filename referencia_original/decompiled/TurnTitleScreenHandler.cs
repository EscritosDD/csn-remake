// Decompiled with JetBrains decompiler
// Type: TurnTitleScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TurnTitleScreenHandler : BaseHUDScreenHandler
{
  public GuiText3D PlayerNameText;
  public GuiText3D PlayerTurnNumText;
  public GameObject BackgroundRightCap;
  public GameObject BackgroundLeftCap;
  public GameObject Background;
  public CoinPotBoxHandler CoinPot;
  public GameStatusBoxHandler GameStatus;
  public TurnTitleDeceasedUnitList DeadUnitList;
  public ChatDisplay chatDisplay;
  public float BGWidthBuffer;
  public LocalisationEntry TurnLocText;

  public override void InitailiseScreenData()
  {
    if (Object.op_Inequality((Object) this.PlayerNameText, (Object) null))
    {
      this.PlayerNameText.TextColor = this.get_Game().땼().딝() != 0 ? GlobalAppData.딟.GameAssets.Red : GlobalAppData.딟.GameAssets.Blue;
      this.PlayerNameText.UpdateMesh();
    }
    if (Object.op_Inequality((Object) this.PlayerTurnNumText, (Object) null))
    {
      this.PlayerTurnNumText.set_LocTextParms(new object[1]
      {
        (object) 땓.땞.땄(this.get_Game().땼())
      });
      this.PlayerTurnNumText.LocText = this.TurnLocText;
      this.PlayerTurnNumText.UpdateMesh();
    }
    if (Object.op_Inequality((Object) this.CoinPot, (Object) null))
    {
      if (this.get_Game().땼().떓() == 딶.딹.땄)
      {
        ((Component) this.CoinPot).gameObject.SetActive(false);
      }
      else
      {
        ((Component) this.CoinPot).gameObject.SetActive(true);
        this.CoinPot.InitailiseCoinValueData();
      }
    }
    if (Object.op_Inequality((Object) this.GameStatus, (Object) null))
    {
      if (this.get_Game().땼().떔().딢())
        this.GameStatus.InitailiseGameStatusBox(this.get_Game().땼(), 0, 1);
      else
        ((Component) this.GameStatus).gameObject.SetActive(false);
    }
    if (Object.op_Inequality((Object) this.DeadUnitList, (Object) null))
    {
      딶.땯 TurnsStage = this.get_Game().딷();
      Vector3 ScreenSize = Vector3.one;
      BoxCollider component = ((Component) this).GetComponent<BoxCollider>();
      if (Object.op_Inequality((Object) component, (Object) null))
        ScreenSize = component.size;
      bool InDeploymentState = this.get_Game().땼().떁();
      if (TurnsStage != null)
        this.DeadUnitList.SetDeceasedUnitList(TurnsStage, this.get_Game().땼().딝(), ScreenSize, InDeploymentState);
    }
    this.PositionTurnTitleBackground();
    if (this.chatDisplay.Init(딶.딡.땴().땼(), 땓.땝.딟))
    {
      CameraController 딟 = 딶.딡.땴().딟;
      if (Object.op_Inequality((Object) 딟, (Object) null))
        딟.SetMode(딢.딸.딢);
    }
    // ISSUE: reference to a compiler-generated method
    this.set_Active(true);
  }

  public void Deactivate()
  {
    // ISSUE: reference to a compiler-generated method
    this.set_Active(false);
    CameraController 딟 = 딶.딡.땴().딟;
    if (!Object.op_Inequality((Object) 딟, (Object) null))
      return;
    딟.SetMode(딢.딸.딟);
  }

  public void InitGameStatus(bool[] ActiveZones, bool[] PrevActiveZones, bool ForceUpdateBlink)
  {
    if (this.get_Game() == null)
      return;
    this.GameStatus.InitBlinking(this.get_Game().땼(), ActiveZones, PrevActiveZones, ForceUpdateBlink, false);
  }

  public void UpdateGameStatus() => this.GameStatus.UpdateBlinking();

  private void PositionTurnTitleBackground()
  {
    Vector3 textWidthHeight1 = this.PlayerNameText.GetTextWidthHeight();
    Vector3 textWidthHeight2 = this.PlayerTurnNumText.GetTextWidthHeight();
    땓.땞.딟(ref this.Background, ref this.BackgroundLeftCap, ref this.BackgroundRightCap, textWidthHeight1.x <= textWidthHeight2.x ? (float) (textWidthHeight2.x + 2.0 * (double) this.BGWidthBuffer) : (float) (double) textWidthHeight1.x);
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (TurnTitleScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      TurnTitleScreenHandler.딟 = new Dictionary<string, int>(1)
      {
        {
          "StartGame",
          0
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!TurnTitleScreenHandler.딟.TryGetValue(key, out num) || num != 0)
      return;
    딶.땯 땯 = this.get_Game().딷();
    if (땯 == null)
      return;
    if (땯.땉() == 딶.딨.딢 || 땯.땉() == 딶.딨.땓 || 땯.땉() == 딶.딨.딶)
    {
      this.get_Game().땼().떔().딧();
      딶.딡.땴().땢().ActivateGameplayHUD();
    }
    else
    {
      if (땯.떇() != 딶.딨.땄)
        return;
      땯.딟(딶.딨.땃);
    }
  }

  [CompilerGenerated]
  [SpecialName]
  public bool get_Active() => this.딟;
}
