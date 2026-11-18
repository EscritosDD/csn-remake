// Decompiled with JetBrains decompiler
// Type: SquadPointSelectionScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using 딧;

public class SquadPointSelectionScreenHandler : BaseMenuHandler
{
  private SquadPointSelectionScreenHandler.땊 딟;
  private 땧 딟;
  private new BaseMenuHandler 딟;
  public ToolTipHandler SquadPointsToolTip;
  public GuiText3D[] TierTexts;
  public GameObject[] TierButtons;

  private void Awake()
  {
    base.딟 = ((Component) this).transform.position;
    this.ChangeState(SquadPointSelectionScreenHandler.땊.땄);
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (SquadPointSelectionScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      SquadPointSelectionScreenHandler.딟 = new Dictionary<string, int>(4)
      {
        {
          "Back",
          0
        },
        {
          "50SquadPoints",
          1
        },
        {
          "100SquadPoints",
          2
        },
        {
          "150SquadPoints",
          3
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!SquadPointSelectionScreenHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        this.DeactivateMenu();
        this.딟.ActivateMenu();
        break;
      case 1:
        this.SelectTier(0, (BaseMenuHandler) this);
        break;
      case 2:
        this.SelectTier(1, (BaseMenuHandler) this);
        break;
      case 3:
        this.SelectTier(2, (BaseMenuHandler) this);
        break;
    }
  }

  private void SelectTier(int Index, BaseMenuHandler ReturnScreen)
  {
    땧 LoadingInfo = this.딟.딟();
    LoadingInfo.땄(Index);
    this.DeactivateMenu();
    FrontendHub.딟.MapSelectionScreen.ActivateMenu(true, LoadingInfo, ReturnScreen);
  }

  public void ActivateMenu(bool Restart, 땧 LoadingInfo, BaseMenuHandler ReturnScreen)
  {
    this.ActivateMenu();
    this.ChangeState(SquadPointSelectionScreenHandler.땊.딧);
    if (Restart)
    {
      this.딟 = LoadingInfo;
      this.딟 = ReturnScreen;
    }
    if (this.SetSPTexts() <= 1 || this.딟.땄())
      this.SelectTier(0, ReturnScreen);
    else
      this.SquadPointsToolTip.Display();
  }

  public override void ActivateMenu()
  {
    base.ActivateMenu();
    FrontendHub.딟.MoneyDisplay.UpdateDisplay(true, MoneyDisplayHandler.딤.딦);
  }

  private void ChangeState(SquadPointSelectionScreenHandler.땊 NewState)
  {
    if (this.딟 == SquadPointSelectionScreenHandler.땊.딢)
      this.TransformToView();
    if (this.딟 == SquadPointSelectionScreenHandler.땊.딟)
    {
      this.딟 = NewState;
    }
    else
    {
      if ((NewState != SquadPointSelectionScreenHandler.땊.땄 || this.딟 != SquadPointSelectionScreenHandler.땊.딧) && (NewState != SquadPointSelectionScreenHandler.땊.딧 || this.딟 != SquadPointSelectionScreenHandler.땊.땄))
        return;
      this.TransformToView();
      this.딟 = SquadPointSelectionScreenHandler.땊.딢;
    }
  }

  private void TransformToView() => ((Component) this).transform.position = Vector3.zero;

  public override void DeactivateMenu() => base.DeactivateMenu();

  private int SetSPTexts()
  {
    int count = GlobalAppData.땽().땲().Count;
    int index = 0;
    int num = 0;
    while (true)
    {
      SquadPointsTierEntry squadPointsTierEntry = GlobalAppData.딢().GenericData.땃(index);
      if (!Object.op_Equality((Object) squadPointsTierEntry, (Object) null))
      {
        if (index < this.TierTexts.Length)
        {
          this.TierTexts[index].Text = squadPointsTierEntry.MaxUnitSquadPoints.ToString();
          this.TierTexts[index].UpdateMesh();
        }
        bool flag = count >= squadPointsTierEntry.MinOwnedUnits;
        if (flag)
          ++num;
        if (index < this.TierButtons.Length)
          this.TierButtons[index].SetActive(flag);
        ++index;
      }
      else
        break;
    }
    return num;
  }

  public enum 땊
  {
    딟,
    땄,
    딧,
    딢,
  }
}
