// Decompiled with JetBrains decompiler
// Type: SquadSelectionHUDHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SquadSelectionHUDHandler : MonoBehaviour
{
  public SquadSelectionHUDGrid SquadGrid;
  public DeployableSelectionHUDGrid DeployableGrid;
  public GameplayHUDHandler GameHUD;
  public GameObject CurrCharacterBG;
  public GameObject CurrCharacterClassIcon;
  public GameObject CurrCharacterThumb;
  public Material BackgroundBlue;
  public Material BackgroundBlueSelected;
  public Material BackgroundRed;
  public Material BackgroundRedSelected;
  public Material BlueFailsafe;
  public Material RedFailsafe;
  public Material BackgroundBlueFailsafe;
  public Material BackgroundRedFailsafe;
  public bool bEnemyHUDScreen;
  public Camera UICamera;
  private Vector3 딟;

  private void Awake()
  {
    // ISSUE: reference to a compiler-generated method
    this.set_SquadSelectionActive(false);
    this.딟 = ((Component) this).transform.position;
  }

  public void ActivateMenu(딶.땂 Team)
  {
    ((Component) this).transform.position = new Vector3((float) ((Component) this.UICamera).transform.position.x, (float) this.딟.y, (float) ((Component) this.UICamera).transform.position.z);
    // ISSUE: reference to a compiler-generated method
    this.set_SquadSelectionActive(true);
    if (딶.딡.땴() == null)
      return;
    딶.땯 TurnsStage = 딶.딡.땴().딷();
    if (TurnsStage == null)
      return;
    int num1 = TurnsStage.땜() != null ? TurnsStage.땜().땔() : -1;
    int num2 = TurnsStage.땈() != null ? TurnsStage.땈().땔() : -1;
    this.InitailiseScreenData(TurnsStage, Team, !this.bEnemyHUDScreen ? num2 : num1);
  }

  private void InitailiseScreenData(딶.땯 TurnsStage, 딶.땂 Team, int GameObjIdx)
  {
    this.SquadGrid.PopulateTeamSelection(TurnsStage, Team, Team != 딶.땂.딟 ? this.BackgroundRed : this.BackgroundBlue, Team != 딶.땂.딟 ? this.BackgroundRedSelected : this.BackgroundBlueSelected);
    if (Object.op_Inequality((Object) this.DeployableGrid, (Object) null))
      this.DeployableGrid.PopulateDeployablesGrid(TurnsStage, Team, Team != 딶.땂.딟 ? this.BackgroundRed : this.BackgroundBlue, Team != 딶.땂.딟 ? this.BackgroundRedSelected : this.BackgroundBlueSelected, this.SquadGrid.get_MaximumXValue());
    땓.떀 CurrCharacter = (땓.떀) null;
    if (GameObjIdx != -1)
      CurrCharacter = 딶.딡.땴().땼().땻()[GameObjIdx] as 땓.떀;
    this.FillCurrentUnitData(CurrCharacter, Team);
  }

  private void FillCurrentUnitData(땓.떀 CurrCharacter, 딶.땂 Team)
  {
    if (CurrCharacter != null)
    {
      this.CurrCharacterThumb.SetActive(true);
      this.CurrCharacterClassIcon.SetActive(true);
      if (Object.op_Inequality((Object) this.CurrCharacterBG, (Object) null))
      {
        this.CurrCharacterBG.renderer.material = Team != 딶.땂.딟 ? this.BackgroundRedSelected : this.BackgroundBlueSelected;
        this.CurrCharacterBG.renderer.material.color = Color.white;
      }
      if (Object.op_Inequality((Object) this.CurrCharacterThumb, (Object) null))
        this.CurrCharacterThumb.renderer.sharedMaterial = CurrCharacter.땁().CharacterIcon;
      if (!Object.op_Inequality((Object) this.CurrCharacterClassIcon, (Object) null))
        return;
      this.CurrCharacterClassIcon.renderer.material = GlobalAppData.땲().딟(CurrCharacter.땁().GUIIcon, Color.white);
    }
    else
    {
      this.CurrCharacterClassIcon.SetActive(false);
      if (Object.op_Inequality((Object) this.CurrCharacterBG, (Object) null))
      {
        this.CurrCharacterBG.renderer.sharedMaterial = Team != 딶.땂.딟 ? this.BackgroundRedFailsafe : this.BackgroundBlueFailsafe;
        Color color = Team != 딶.땂.딟 ? GlobalAppData.딟.GameAssets.Red : GlobalAppData.딟.GameAssets.Blue;
        color.a = (__Null) 0.5;
        this.CurrCharacterBG.renderer.sharedMaterial.color = color;
      }
      if (!Object.op_Inequality((Object) this.CurrCharacterThumb, (Object) null))
        return;
      this.CurrCharacterThumb.renderer.sharedMaterial = Team != 딶.땂.딟 ? this.RedFailsafe : this.BlueFailsafe;
    }
  }

  private void OnSelectUnitButtonPressed(int ButtonIndex)
  {
    if (ButtonIndex >= this.SquadGrid.SquadSelectionGridPanels.Length || 딶.딡.땴() == null)
      return;
    딶.땯 TurnsStage = 딶.딡.땴().딷();
    this.SelectUnitFromGrid(TurnsStage, TurnsStage.딟(this.SquadGrid.SquadSelectionGridPanels[ButtonIndex].get_CharacterIndex()));
    this.CloseSquadSelectionHUD();
    this.GameHUD.UpdateSquadGrids();
  }

  private void OnDeployableButtonPressed(int ButtonIndex)
  {
    if (ButtonIndex >= this.DeployableGrid.DeployableGridButtons.Length || 딶.딡.땴() == null)
      return;
    딶.땯 TurnsStage = 딶.딡.땴().딷();
    this.SelectUnitFromGrid(TurnsStage, TurnsStage.딟(this.DeployableGrid.DeployableGridButtons[ButtonIndex].get_DeployableIndex()));
    this.CloseSquadSelectionHUD();
  }

  private void SelectUnitFromGrid(딶.땯 TurnsStage, 땓.땦 Controller) => TurnsStage?.딟(Controller, true, false);

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (SquadSelectionHUDHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      SquadSelectionHUDHandler.딟 = new Dictionary<string, int>(1)
      {
        {
          "CloseSelection",
          0
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!SquadSelectionHUDHandler.딟.TryGetValue(key, out num) || num != 0)
      return;
    this.CloseSquadSelectionHUD();
    this.GameHUD.UpdateSquadGrids();
  }

  public void CloseSquadSelectionHUD()
  {
    ((Component) this).transform.position = this.딟;
    this.SquadGrid.ShutDownGrid();
    // ISSUE: reference to a compiler-generated method
    this.set_SquadSelectionActive(false);
    if (!Object.op_Inequality((Object) this.DeployableGrid, (Object) null))
      return;
    this.DeployableGrid.ShutDownGrid();
  }

  [CompilerGenerated]
  [SpecialName]
  public bool get_SquadSelectionActive() => this.딟;
}
