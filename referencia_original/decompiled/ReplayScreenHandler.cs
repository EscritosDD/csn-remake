// Decompiled with JetBrains decompiler
// Type: ReplayScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class ReplayScreenHandler : BaseHUDScreenHandler
{
  public GuiText3D PlayerTurnNumText;
  public GameObject PauseIcon;
  public GuiButton3D RestartReplay;
  public GuiButton3D EndReplay;
  public CoinPotBoxHandler CoinPot;
  public GameStatusBoxHandler GameStatus;
  public GameObject TopBorder;
  private MenuAnimatorHandler 딟;
  public GameObject BottomBorder;
  private MenuAnimatorHandler 땄;
  public LocalisationEntry TurnLocText;

  public override void InitailiseScreenData()
  {
    if (Object.op_Inequality((Object) this.PlayerTurnNumText, (Object) null))
    {
      this.PlayerTurnNumText.set_LocTextParms(new object[1]
      {
        (object) 땓.땞.딟(this.get_Game().땼())
      });
      this.PlayerTurnNumText.TextColor = this.get_Game().땼().딝() != 0 ? GlobalAppData.딟.GameAssets.Blue : GlobalAppData.딟.GameAssets.Red;
      this.PlayerTurnNumText.LocText = this.TurnLocText;
      this.PlayerTurnNumText.UpdateMesh();
    }
    if (Object.op_Inequality((Object) this.PauseIcon, (Object) null))
      this.PauseIcon.renderer.material.color = this.get_Game().땼().딝() != 0 ? GlobalAppData.딟.GameAssets.Blue : GlobalAppData.딟.GameAssets.Red;
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
    if (Object.op_Inequality((Object) this.TopBorder, (Object) null))
    {
      this.딟 = this.TopBorder.GetComponent<MenuAnimatorHandler>();
      if (Object.op_Inequality((Object) this.딟, (Object) null))
        this.딟.StartAnim();
    }
    if (!Object.op_Inequality((Object) this.BottomBorder, (Object) null))
      return;
    this.땄 = this.BottomBorder.GetComponent<MenuAnimatorHandler>();
    if (!Object.op_Inequality((Object) this.땄, (Object) null))
      return;
    this.땄.StartAnim();
  }

  public void InitGameStatus(bool[] ActiveZones, bool[] PrevActiveZones, bool ForceUpdateBlink)
  {
    if (this.get_Game() == null || !this.get_Game().땼().떔().딢())
      return;
    this.GameStatus.InitBlinking(this.get_Game().땼(), ActiveZones, PrevActiveZones, ForceUpdateBlink, true);
  }

  public void UpdateGameStatus() => this.GameStatus.UpdateBlinking();

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (ReplayScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      ReplayScreenHandler.딟 = new Dictionary<string, int>(2)
      {
        {
          "SkipReplay",
          0
        },
        {
          "RewindReplay",
          1
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!ReplayScreenHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        딶.땯 땯 = this.get_Game().딷();
        if (땯 == null)
          break;
        if (땯.떇() == 딶.딨.땄)
        {
          땯.딣();
          break;
        }
        땯.딥();
        break;
      case 1:
        this.get_Game().딷()?.땻();
        break;
    }
  }
}
