// Decompiled with JetBrains decompiler
// Type: AbilitySelectionHUDHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class AbilitySelectionHUDHandler : BaseHUDScreenHandler
{
  public AbilitySelectionHUDGrid AbilityGrid;
  public GameplayHUDHandler GameplayHUD;
  public AudioShader2 UnableToSelectAbilitySound;

  public override void PositionScreenCameraView() => ((Component) this).transform.position = new Vector3((float) ((Component) this.UICamera).transform.position.x, (float) ((Component) this).transform.position.y, (float) ((Component) this.UICamera).transform.position.z);

  public override void InitailiseScreenData()
  {
    ((Component) this).gameObject.SetActive(true);
    딶.땯 땯 = this.get_Game().딷();
    if (땯 == null)
      return;
    this.AbilityGrid.PopulateAbiltyHUDSelection(this.get_Game().땼().떂().땃(), this.GetCurrentSelectedCharacterUnitContoller(true), this.GetSelectedCharacter(true), 땯.땞());
  }

  private void OnAbilitySelectionButtonPressed(int ButtonIndex)
  {
    if (ButtonIndex >= this.AbilityGrid.AbilityButtons.Length)
      return;
    if (this.AbilityGrid.AbilityButtons[ButtonIndex].get_bAbilitySelectable())
    {
      if (this.get_Game() == null)
        return;
      딶.땯 땯 = this.get_Game().딷();
      this.ResetAbilityButtonAnimations();
      if (땯 == null)
        return;
      딢.딴 딴 = this.AbilityGrid.AbilityButtons[ButtonIndex].get_AbilityType();
      if (땯.땞() == 딴)
      {
        ((Component) this.AbilityGrid.AbilityButtons[ButtonIndex]).animation.Stop();
        땯.딟(딢.딴.땄);
      }
      else
      {
        ((Component) this.AbilityGrid.AbilityButtons[ButtonIndex]).animation.Play();
        땯.딟(딴);
      }
    }
    else
    {
      if (!Object.op_Inequality((Object) this.UnableToSelectAbilitySound, (Object) null))
        return;
      double num = (double) this.UnableToSelectAbilitySound.PlayOneShot(((Component) this).gameObject);
    }
  }

  private void ResetAbilityButtonAnimations()
  {
    foreach (Component abilityButton in this.AbilityGrid.AbilityButtons)
      abilityButton.animation.Stop();
  }

  private void DeactivateAbilityButton(MonoBehaviour Target)
  {
    AbilitySelectionHUDButton selectionHudButton = Target as AbilitySelectionHUDButton;
    if (!Object.op_Inequality((Object) selectionHudButton, (Object) null))
      return;
    selectionHudButton.AbiltyButton.Disabled = true;
    selectionHudButton.AbiltyButton.AnimateButton = false;
  }

  private void ReactivateAbilityButton(MonoBehaviour Target)
  {
    AbilitySelectionHUDButton selectionHudButton = Target as AbilitySelectionHUDButton;
    if (!Object.op_Inequality((Object) selectionHudButton, (Object) null))
      return;
    selectionHudButton.AbiltyButton.Disabled = false;
    selectionHudButton.AbiltyButton.AnimateButton = true;
  }
}
