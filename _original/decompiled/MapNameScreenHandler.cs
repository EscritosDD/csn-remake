// Decompiled with JetBrains decompiler
// Type: MapNameScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using 딶;

public class MapNameScreenHandler : BaseHUDScreenHandler
{
  public SquadDeploymentScreenHandler SquadDeploymentScreen;
  public GuiText3D MapNameText;
  public GuiText3D MapObjectiveText;
  public GuiText3D MapObjectiveSubText;
  private bool 딟;
  private bool 땄;
  private bool 딧;

  public override void InitailiseScreenData()
  {
    this.SetMapNameScreenButtonDisabled(false);
    if (Object.op_Inequality((Object) this.MapNameText, (Object) null))
    {
      LocalisationEntry localisationEntry = GlobalAppData.땼().딷(this.get_Game().땼().딟.땄);
      if (Object.op_Inequality((Object) localisationEntry, (Object) null))
      {
        this.MapNameText.LocText = localisationEntry;
        this.MapNameText.UpdateMesh();
      }
    }
    if (Object.op_Inequality((Object) this.MapObjectiveText, (Object) null))
    {
      this.MapObjectiveText.LocText = this.get_Game().땼().떔().땺();
      this.MapObjectiveText.UpdateMesh();
    }
    if (Object.op_Inequality((Object) this.MapObjectiveSubText, (Object) null))
    {
      this.MapObjectiveSubText.LocText = this.get_Game().땼().떔().땥();
      this.MapObjectiveSubText.UpdateMesh();
    }
    this.딟 = true;
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (MapNameScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      MapNameScreenHandler.딟 = new Dictionary<string, int>(1)
      {
        {
          "Dismiss",
          0
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!MapNameScreenHandler.딟.TryGetValue(key, out num) || num != 0)
      return;
    this.TriggerWaitingToOpenNextScreen();
  }

  private void Update()
  {
    if (!this.딟)
      return;
    if (this.get_Game() != null && Object.op_Inequality((Object) this.get_Game().딟.CameraAnimation, (Object) null))
    {
      bool 딧 = this.딧;
      this.딧 = this.get_Game().딟.CameraAnimation.IsPlaying();
      if (딧 && !this.딧)
        this.TriggerWaitingToOpenNextScreen();
    }
    else
      this.딧 = false;
    if (!this.땄 || this.딧)
      return;
    this.땄 = false;
    this.OpenSquadDeploymentScreen();
  }

  private void TriggerWaitingToOpenNextScreen()
  {
    if (this.땄)
      return;
    this.땄 = true;
    if (this.딧)
      this.get_Game().딟.ClearCinematics();
    this.SetMapNameScreenButtonDisabled(true);
  }

  private void OpenSquadDeploymentScreen()
  {
    this.딟 = false;
    if (this.get_Game().땼().떔() is 딖)
    {
      this.get_Game().땢().DeactivateGameplayHUD();
      this.get_Game().땢().ActivateGameplayHUD();
    }
    ((Component) this).gameObject.SetActive(false);
    if (this.get_Game().땼() == null || this.get_Game().땼().떔() == null)
      return;
    this.get_Game().땼().떔().딧();
  }

  private void SetMapNameScreenButtonDisabled(bool Disabled)
  {
    GuiButton3D component = ((Component) this).GetComponent<GuiButton3D>();
    if (!Object.op_Inequality((Object) component, (Object) null))
      return;
    component.Disabled = Disabled;
  }
}
