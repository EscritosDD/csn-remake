// Decompiled with JetBrains decompiler
// Type: PlayerLevelDisplay
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class PlayerLevelDisplay : MonoBehaviour
{
  public Material ActiveBackgroundMaterial;
  public Material LockedBackgroundMaterial;
  public Material UnlockedBackgroundMaterial;
  public Material LockedAbilityBackground;
  public Material UnlockedAbilityBackground;
  public Shader IconShader;
  public GameObject Background;
  public UnitAbilityButton AbilityButton;
  public GuiText3D LevelNumberText;
  public GuiText3D LockedLevelNumberText;
  public GameObject LockedIcon;
  public GameObject CoinsAwardIcon;
  public GameObject CoinsAwardIconDisabled;
  public GuiText3D CoinsAwardText;

  public void Init(int Level, int CurrentLevel)
  {
    this.LockedIcon.SetActive(false);
    this.CoinsAwardIcon.SetActive(false);
    this.CoinsAwardIconDisabled.SetActive(false);
    ((Component) this.CoinsAwardText).gameObject.SetActive(false);
    PlayerAbilityEntry PlayerAbility = GlobalAppData.딢().GenericData.딟(Level);
    if (Level == CurrentLevel)
    {
      if (GlobalAppData.딢().GenericData.딧(CurrentLevel))
      {
        this.Background.renderer.sharedMaterial = this.UnlockedBackgroundMaterial;
        ((Component) this.LevelNumberText).gameObject.SetActive(true);
        this.LevelNumberText.Text = (Level + 1).ToString();
        this.LevelNumberText.UpdateMesh();
        this.AbilityButton.Init(PlayerAbility, this.IconShader);
        ((Component) this.AbilityButton).renderer.sharedMaterial = GlobalAppData.땲().딟(this.UnlockedAbilityBackground, this.IconShader);
      }
      else
      {
        this.Background.renderer.sharedMaterial = this.ActiveBackgroundMaterial;
        ((Component) this.LockedLevelNumberText).gameObject.SetActive(true);
        this.LockedLevelNumberText.Text = (Level + 1).ToString();
        this.LockedLevelNumberText.UpdateMesh();
        this.AbilityButton.Init(PlayerAbility, this.IconShader);
        ((Component) this.AbilityButton).renderer.sharedMaterial = GlobalAppData.땲().딟(this.LockedAbilityBackground, this.IconShader);
        if (PlayerAbility != null)
          this.LockedIcon.SetActive(true);
      }
    }
    else if (CurrentLevel > Level)
    {
      this.Background.renderer.sharedMaterial = this.UnlockedBackgroundMaterial;
      ((Component) this.LevelNumberText).gameObject.SetActive(true);
      this.LevelNumberText.Text = (Level + 1).ToString();
      this.LevelNumberText.UpdateMesh();
      this.AbilityButton.Init(PlayerAbility, this.IconShader);
      ((Component) this.AbilityButton).renderer.sharedMaterial = GlobalAppData.땲().딟(this.UnlockedAbilityBackground, this.IconShader);
    }
    else
    {
      this.Background.renderer.sharedMaterial = this.LockedBackgroundMaterial;
      ((Component) this.LockedLevelNumberText).gameObject.SetActive(true);
      this.LockedLevelNumberText.Text = (Level + 1).ToString();
      this.LockedLevelNumberText.UpdateMesh();
      this.AbilityButton.Init(PlayerAbility, this.IconShader);
      ((Component) this.AbilityButton).renderer.sharedMaterial = GlobalAppData.땲().딟(this.LockedAbilityBackground, this.IconShader);
      if (PlayerAbility != null)
        this.LockedIcon.SetActive(true);
    }
    PlayerLevel playerLevel = GlobalAppData.딢().GenericData.PlayerLevels[Level];
    if (string.IsNullOrEmpty(playerLevel.CoinsToken) || string.IsNullOrEmpty(playerLevel.CoinsAwardValue))
      return;
    ((Component) this.CoinsAwardText).gameObject.SetActive(true);
    this.CoinsAwardText.Text = playerLevel.CoinsAwardValue;
    if (CurrentLevel > Level)
    {
      this.CoinsAwardIcon.SetActive(true);
      this.CoinsAwardIconDisabled.SetActive(false);
      this.CoinsAwardText.TextColor = Color.white;
    }
    else
    {
      this.CoinsAwardIcon.SetActive(false);
      this.CoinsAwardIconDisabled.SetActive(true);
      this.CoinsAwardText.TextColor = Color.grey;
    }
    this.CoinsAwardText.UpdateMesh();
  }
}
