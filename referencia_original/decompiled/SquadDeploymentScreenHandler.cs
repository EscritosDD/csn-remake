// Decompiled with JetBrains decompiler
// Type: SquadDeploymentScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class SquadDeploymentScreenHandler : BaseHUDScreenHandler
{
  public SquadDeploymentUnitList DeploymentList;
  public GuiButton2State3D AutoDeployButton;
  public GuiButton2State3D NextButton;
  public GuiButton2State3D RevertDeploymentButton;
  public ToolTipHandler DeploymentTooltipPrefab;
  private bool 딟;
  private int 딟;
  private 딶.땯 딟;

  public override void InitailiseScreenData()
  {
    Vector3 ScreenSize = Vector3.one;
    BoxCollider component = ((Component) this).GetComponent<BoxCollider>();
    this.딟 = this.get_Game().땼().딝();
    if (Object.op_Inequality((Object) component, (Object) null))
      ScreenSize = component.size;
    if (Object.op_Inequality((Object) this.DeploymentList, (Object) null))
      this.DeploymentList.SetSquadDeploymentList(this.딟 != 0 ? 딶.땂.땄 : 딶.땂.딟, ScreenSize);
    this.딟 = this.get_Game().딷();
    this.SetAutoDeployButtonActive(true, true);
    this.SetNextButtonActive(false, true);
    this.SetRevertDeployButtonActive(false, true);
    this.OnDeployButtonPressed(0);
    this.DeploymentTooltipPrefab.Display();
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (SquadDeploymentScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      SquadDeploymentScreenHandler.딟 = new Dictionary<string, int>(3)
      {
        {
          "DeployNext",
          0
        },
        {
          "DeployRevert",
          1
        },
        {
          "AutoDeploy",
          2
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!SquadDeploymentScreenHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        this.OpenNextScreen();
        break;
      case 1:
        if (this.딟 == null)
          break;
        this.딟.땪().땄();
        break;
      case 2:
        if (this.딟 == null)
          break;
        this.딟.땪().딢();
        this.딟 = true;
        break;
    }
  }

  private void OnDeployButtonPressed(int ButtonIndex)
  {
    if (ButtonIndex >= this.DeploymentList.DeploymentButtons.Length)
      return;
    if (this.DeploymentList.DeploymentButtons[ButtonIndex].get_Deployed())
    {
      if (this.딟 == null)
        return;
      this.딟.땪().딟(ButtonIndex);
    }
    else
    {
      if (this.DeploymentList.DeploymentButtons[ButtonIndex].get_Selected())
        return;
      bool flag = this.DeploymentList.DeploymentButtons[ButtonIndex].get_Selected();
      this.DeploymentList.SetAllButtonsSelectionState(false);
      this.DeploymentList.SetButtonSelected(ButtonIndex, !flag);
      if (this.딟 != null && !flag)
        this.딟.땪().딟 = ButtonIndex;
      else
        this.딟.땪().딟 = -1;
    }
  }

  private void OpenNextScreen()
  {
    this.딟.땪().땓();
    ((Component) this).gameObject.SetActive(false);
  }

  private void Update() => this.UpdateDeploymentListButtonStates();

  private void UpdateDeploymentListButtonStates()
  {
    int num = 0;
    bool flag = false;
    if (this.딟 != null && this.딟.땪() != null)
    {
      for (int index = 0; index < this.딟.땪().딟.Count; ++index)
      {
        if (index < this.DeploymentList.DeploymentButtons.Length)
        {
          if (Object.op_Inequality((Object) this.딟.땪().딟[index].딟, (Object) null))
            ++num;
          if (Object.op_Inequality((Object) this.딟.땪().딟[index].딟, (Object) null) && !this.DeploymentList.DeploymentButtons[index].get_Deployed())
          {
            this.DeploymentList.DeploymentButtons[index].SetDeploymentPanelDeployedStatus(true);
            flag = true;
          }
          else if (Object.op_Equality((Object) this.딟.땪().딟[index].딟, (Object) null) && this.DeploymentList.DeploymentButtons[index].get_Deployed())
          {
            this.DeploymentList.DeploymentButtons[index].SetDeploymentPanelDeployedStatus(false);
            flag = true;
          }
        }
      }
      bool Active = this.IsDeploymentFinished();
      this.SetAutoDeployButtonActive(!Active, false);
      this.SetNextButtonActive(Active, false);
      this.SetRevertDeployButtonActive(num > 0, false);
      if (this.딟)
        this.딟 = !Active;
    }
    if (!flag || this.딟)
      return;
    this.SelectAnUndeployedUnit();
  }

  private bool IsDeploymentFinished() => this.딟 != null && this.딟.땪() != null && this.딟.땪().딶();

  private void SelectAnUndeployedUnit()
  {
    int ButtonIndex = -1;
    for (int index = 0; index < this.DeploymentList.DeploymentButtons.Length; ++index)
    {
      if (this.DeploymentList.DeploymentButtons[index].get_Selected())
        return;
      if (!this.DeploymentList.DeploymentButtons[index].get_Deployed())
      {
        ButtonIndex = index;
        break;
      }
    }
    if (ButtonIndex == -1)
      return;
    this.OnDeployButtonPressed(ButtonIndex);
  }

  private void SetAutoDeployButtonActive(bool Active, bool ForceUpdate)
  {
    if (this.AutoDeployButton.Disabled != Active && !ForceUpdate)
      return;
    this.AutoDeployButton.SetButtonDisabled(!Active);
  }

  private void SetNextButtonActive(bool Active, bool ForceUpdate)
  {
    if (this.NextButton.Disabled != Active && !ForceUpdate)
      return;
    this.NextButton.SetButtonDisabled(!Active);
  }

  private void SetRevertDeployButtonActive(bool Active, bool ForceUpdate)
  {
    if (this.RevertDeploymentButton.Disabled != Active && !ForceUpdate)
      return;
    this.RevertDeploymentButton.SetButtonDisabled(!Active);
  }
}
