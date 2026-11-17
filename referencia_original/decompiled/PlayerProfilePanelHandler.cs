// Decompiled with JetBrains decompiler
// Type: PlayerProfilePanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProfilePanelHandler : BaseMenuHandler
{
  private const int 딟 = 15;
  private const int 땄 = 5;
  private bool 딟;
  private 땓.땶 딟;
  private 땄.땣 딟;
  private List<Uri> 딟 = new List<Uri>();
  private List<Uri> 땄 = new List<Uri>();
  private List<PlayerProfilePanelHandler.땱> 딟;
  private List<PlayerProfilePanelHandler.땱> 땄;
  private bool 땄;
  private int 딧;
  private int 딢;
  private bool 딧;
  private 딧.딼 딟 = new 딧.딼();
  private 딧.딼 땄 = new 딧.딼();
  private PlayerProfilePanel2Handler 딟;
  public GameObject AvatarScreenComponents;
  public GameObject AchievementDisplay;
  public GameObject LevelScreenComponents;
  public GuiButton3D LevelButton;
  public GuiButton3D AvatarButton;
  public float SelectButtonOpacity = 0.5f;
  public GuiText3D CurrentLevelNumberText;
  public GuiText3D NextLevelNumberText;
  public GuiScrollList3D LevelsList;
  public PlayerLevelDisplay LevelDisplayPrefab;
  public XPProgressBar PlayerProgressBar;
  public GuiText3D PlayerProgressText;
  public PlayerProfilePanel2Handler PlayerProfileAbilityPanelPrefab;
  public GameObject ActiveAvatarIcon;
  public GameObject ActiveAvatarIconLoadingOverlay;
  public GuiText3D PlayerName;
  public GuiButton3D NextSetArrow;
  public GuiButton3D PreviousSetArrow;
  public AvatarIconDisplayHandler[] AvatarIcons = new AvatarIconDisplayHandler[15];
  private Material 딟;
  private Material 땄;
  private Material 딧;
  public Transform PanelStartPoint;
  public Transform PanelEndPoint;
  private new BaseMenuHandler 딟;

  private void Start()
  {
    base.딟 = ((Component) this).transform.position;
    if (Object.op_Equality((Object) this.딟, (Object) null))
      this.딟 = new Material(((Component) this.AvatarButton).renderer.sharedMaterial);
    if (Object.op_Equality((Object) this.땄, (Object) null))
      this.땄 = new Material(((Component) this.LevelButton).renderer.sharedMaterial);
    this.SelectButton(((Component) this.AvatarButton).gameObject, ref this.딟);
    this.UnselectButton(((Component) this.LevelButton).gameObject, ref this.땄);
  }

  public void ActivateMenu(BaseMenuHandler returnScreen)
  {
    this.딟 = returnScreen;
    this.ActivateMenu();
  }

  public override void ActivateMenu()
  {
    base.ActivateMenu();
    this.땄 = true;
    FrontendHub.딟.MoneyDisplay.UpdateDisplay(true, MoneyDisplayHandler.딤.딢);
    this.딟 = GlobalAppData.떏().땄(((딟.땇) GlobalAppData.떏()).땓(), false);
    this.딧 = false;
    this.LevelButton.Disabled = true;
    this.AvatarButton.Disabled = false;
    this.AvatarScreenComponents.SetActive(false);
    this.AchievementDisplay.SetActive(false);
    this.LevelScreenComponents.SetActive(true);
    this.딢 = 0;
    this.ActivateLevelPanel();
  }

  private void ActivateLevelPanel()
  {
    int num1;
    int num2 = GlobalAppData.딢().GenericData.땄(GlobalAppData.땽().딣(), out num1);
    int index = num2;
    if (GlobalAppData.딢().GenericData.딧(num2))
      index = num2 - 1;
    PlayerLevel playerLevel = GlobalAppData.딢().GenericData.PlayerLevels[index];
    for (int Level = 0; Level < GlobalAppData.딢().GenericData.PlayerLevels.Length; ++Level)
    {
      PlayerLevelDisplay playerLevelDisplay = Object.Instantiate((Object) this.LevelDisplayPrefab) as PlayerLevelDisplay;
      playerLevelDisplay.Init(Level, num2);
      this.LevelsList.AddItem(((Component) playerLevelDisplay).transform, 0.1039063f);
    }
    this.LevelsList.ScrollToElement(num2);
    this.PlayerProgressBar.InitForPlayer();
    this.CurrentLevelNumberText.Text = num2.ToString();
    this.CurrentLevelNumberText.UpdateMesh();
    if (!GlobalAppData.딢().GenericData.딧(num2))
    {
      this.NextLevelNumberText.Text = (num2 + 1).ToString();
      this.NextLevelNumberText.UpdateMesh();
      this.PlayerProgressText.Text = num1.ToString() + " / " + playerLevel.RequiredXP.ToString();
      this.PlayerProgressText.UpdateMesh();
    }
    else
    {
      this.NextLevelNumberText.Text = "-";
      this.NextLevelNumberText.UpdateMesh();
    }
    this.SelectButton(((Component) this.LevelButton).gameObject, ref this.땄);
    this.UnselectButton(((Component) this.AvatarButton).gameObject, ref this.딟);
  }

  private void ActivateAvatarPanel()
  {
    땓.땶.딟(GlobalAppData.땽().딳());
    if (this.딟)
      this.ActiveAvatarIconLoadingOverlay.SetActive(false);
    else
      this.ActiveAvatarIconLoadingOverlay.SetActive(true);
    if (this.딟.Count == 0)
    {
      this.딟 = GlobalAppData.땽().땋();
      this.땄 = GlobalAppData.땽().땽();
      this.딟 = new List<PlayerProfilePanelHandler.땱>();
      string str = ((딟.땇) GlobalAppData.떏()).땺();
      if (!string.IsNullOrEmpty(str))
      {
        PlayerProfilePanelHandler.땱 땱 = new PlayerProfilePanelHandler.땱()
        {
          딟 = new Uri("facebook://" + str)
        };
        땱.딟 = 땓.땶.딟(땱.딟);
        this.딟.Add(땱);
      }
      foreach (Uri uri in this.딟)
        this.딟.Add(new PlayerProfilePanelHandler.땱()
        {
          딟 = uri,
          딟 = 땓.땶.딟(uri)
        });
      this.딧 = this.딟.Count;
    }
    if (GlobalAppData.떏().땥())
    {
      if (this.딢 == 0)
      {
        ((Component) this.PreviousSetArrow).gameObject.SetActive(false);
        this.PreviousSetArrow.Disabled = true;
      }
      else
      {
        ((Component) this.PreviousSetArrow).gameObject.SetActive(true);
        this.PreviousSetArrow.Disabled = false;
      }
      if (this.딧 > 15)
      {
        if (this.딢 == 0)
        {
          ((Component) this.NextSetArrow).gameObject.SetActive(true);
          this.NextSetArrow.Disabled = false;
        }
        else if (this.딧 >= 15 + 15 * this.딢)
        {
          ((Component) this.NextSetArrow).gameObject.SetActive(true);
          this.NextSetArrow.Disabled = false;
        }
        else
        {
          ((Component) this.NextSetArrow).gameObject.SetActive(false);
          this.NextSetArrow.Disabled = true;
        }
      }
      else
      {
        ((Component) this.NextSetArrow).gameObject.SetActive(false);
        this.NextSetArrow.Disabled = true;
      }
    }
    else
    {
      ((Component) this.PreviousSetArrow).gameObject.SetActive(false);
      this.PreviousSetArrow.Disabled = true;
      ((Component) this.NextSetArrow).gameObject.SetActive(false);
      this.NextSetArrow.Disabled = true;
    }
    this.RedisplayAvatars();
    this.SelectButton(((Component) this.AvatarButton).gameObject, ref this.딟);
    this.UnselectButton(((Component) this.LevelButton).gameObject, ref this.땄);
  }

  private void OnAbilitySelected(딢.딴 Type)
  {
    PlayerAbilityEntry Entry = GlobalAppData.딢().GenericData.딟(Type);
    this.딟 = Object.Instantiate((Object) this.PlayerProfileAbilityPanelPrefab) as PlayerProfilePanel2Handler;
    this.딟.Init(Entry, this.PanelStartPoint, this.PanelEndPoint);
  }

  public override void DeactivateMenu()
  {
    base.DeactivateMenu();
    this.땄 = false;
    this.ClearAvatarIcons();
    this.DeactivateLevelPanel();
    this.CloseOpenPanels();
  }

  private void DeactivateLevelPanel() => this.LevelsList.Reset();

  private void CloseOpenPanels()
  {
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    this.딟.Close();
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (PlayerProfilePanelHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      PlayerProfilePanelHandler.딟 = new Dictionary<string, int>(6)
      {
        {
          "Close",
          0
        },
        {
          "Level",
          1
        },
        {
          "Avatar",
          2
        },
        {
          "NextSet",
          3
        },
        {
          "PreviousSet",
          4
        },
        {
          "Achievements",
          5
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!PlayerProfilePanelHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        this.딢 = 0;
        this.AvatarButton.Disabled = true;
        this.LevelButton.Disabled = false;
        this.LevelScreenComponents.SetActive(true);
        this.AvatarScreenComponents.SetActive(false);
        if (Object.op_Equality((Object) this.딟, (Object) null))
          FrontendHub.딟.MainScreen.ActivateMenu();
        else
          this.딟.ActivateMenu();
        this.DeactivateMenu();
        break;
      case 1:
        this.딧 = false;
        this.LevelButton.Disabled = true;
        this.AvatarButton.Disabled = false;
        this.AvatarScreenComponents.SetActive(false);
        this.LevelScreenComponents.SetActive(true);
        this.AchievementDisplay.SetActive(false);
        this.딢 = 0;
        this.ClearAvatarIcons();
        this.ActivateLevelPanel();
        break;
      case 2:
        this.딧 = true;
        break;
      case 3:
        ++this.딢;
        this.ClearAvatarIcons();
        this.ActivateAvatarPanel();
        break;
      case 4:
        --this.딢;
        this.ClearAvatarIcons();
        this.ActivateAvatarPanel();
        break;
    }
  }

  private void OnDestroy()
  {
    GlobalAppData.땄(this.ActiveAvatarIcon);
    int num = 0;
    int index = 0;
    for (; num + this.딢 * 15 < this.딟.Count; ++num)
    {
      for (; index < 15; ++index)
      {
        if (index + this.딢 * 15 < this.딟.Count)
          GlobalAppData.땄(this.AvatarIcons[index].Icon);
      }
    }
    this.딟.딟();
    this.땄.딟();
    GlobalAppData.딟(this.딟);
    GlobalAppData.딟(this.땄);
    GlobalAppData.딟(this.딧);
  }

  private void Update()
  {
    if (!this.땄)
      return;
    if (!this.딟)
    {
      if (this.딟 == null)
        this.딟 = 땓.땶.딟(GlobalAppData.땽().딳());
      if (this.딟.딟())
      {
        if (this.딟.땄())
        {
          this.딟 = true;
          GlobalAppData.딟(this.딧);
          this.딧 = new Material(this.딟.딧());
          this.ActiveAvatarIcon.renderer.sharedMaterial = this.딧;
          this.ActiveAvatarIconLoadingOverlay.SetActive(false);
        }
        this.딟 = (땓.땶) null;
      }
    }
    if (this.딟 != null && this.딟.땄())
    {
      if (this.딟.딧())
      {
        this.PlayerName.Text = this.딟.딟.땄();
        this.PlayerName.UpdateMesh();
      }
      this.딟 = (땄.땣) null;
    }
    if (this.딟 != null)
    {
      bool flag = false;
      foreach (PlayerProfilePanelHandler.땱 땱 in this.딟)
      {
        if (!땱.딟.딟())
          flag = true;
      }
      if (!flag)
      {
        this.땄 = this.딟;
        this.딟 = (List<PlayerProfilePanelHandler.땱>) null;
        this.RedisplayAvatars();
      }
    }
    if (!this.딧)
      return;
    if (GlobalAppData.떏().땥())
    {
      this.AvatarButton.Disabled = true;
      this.LevelButton.Disabled = false;
      this.DeactivateLevelPanel();
      this.LevelScreenComponents.SetActive(false);
      this.AvatarScreenComponents.SetActive(true);
      this.ResetAvatarLists();
      this.ActivateAvatarPanel();
    }
    else
      FrontendHub.딟.LoginHandler.LoginAttempt(true);
    this.딧 = false;
  }

  private void RedisplayAvatars()
  {
    if (!this.AvatarScreenComponents.gameObject.activeInHierarchy)
      return;
    this.땄.딟();
    foreach (Component avatarIcon in this.AvatarIcons)
      avatarIcon.gameObject.SetActive(false);
    int num = 0;
    int index = 0;
    if (this.땄 == null)
      return;
    for (; num + this.딢 * 15 < this.땄.Count; ++num)
    {
      for (; index < 15; ++index)
      {
        if (index + this.딢 * 15 < this.땄.Count)
        {
          PlayerProfilePanelHandler.땱 땱 = this.땄[index + this.딢 * 15];
          ((Component) this.AvatarIcons[index]).gameObject.SetActive(true);
          bool IsOwned = 땱.딟 is 땓.딫 || this.땄.Contains(땱.딟);
          this.AvatarIcons[index].Init(땱.딟, IsOwned);
          if (땱.딟.땄())
          {
            this.땄.딟(this.AvatarIcons[index].Icon.renderer.material);
            this.AvatarIcons[index].SetButtonState(true);
            this.AvatarIcons[index].SetIconMaterial(땱.딟.딧());
            this.AvatarIcons[index].SetLoadState(false);
          }
          else
          {
            this.AvatarIcons[index].SetButtonState(false);
            this.AvatarIcons[index].SetLoadState(true);
          }
        }
      }
    }
  }

  public void ChangeActiveAvatar(Uri AvatarUri)
  {
    if (AvatarUri.Equals((object) GlobalAppData.땽().딳()))
      return;
    GlobalAppData.땽().딟(AvatarUri);
    this.ResetAvatarLists();
    this.ActivateAvatarPanel();
  }

  private void ResetAvatarLists()
  {
    this.딟.Clear();
    this.땄.Clear();
    this.딟 = false;
  }

  private void ClearAvatarIcons()
  {
    foreach (AvatarIconDisplayHandler avatarIcon in this.AvatarIcons)
      avatarIcon.ResetAvatarIconDisplay();
  }

  private void SelectButton(GameObject Target, ref Material TargetMaterial) => this.SelectButton(Target, true, ref TargetMaterial);

  private void SelectButton(GameObject Target, bool doScale, ref Material TargetMaterial)
  {
    if (doScale)
      Target.transform.localScale = new Vector3(0.75f, 1f, 0.75f);
    TargetMaterial.color = new Color(1f, 1f, 1f, this.SelectButtonOpacity);
    Target.renderer.sharedMaterial = TargetMaterial;
  }

  private void UnselectButton(GameObject Target, ref Material TargetMaterial) => this.UnselectButton(Target, true, ref TargetMaterial);

  private void UnselectButton(GameObject Target, bool doScale, ref Material TargetMaterial)
  {
    if (doScale)
      Target.transform.localScale = new Vector3(1f, 1f, 1f);
    TargetMaterial.color = new Color(1f, 1f, 1f, 1f);
    Target.renderer.sharedMaterial = TargetMaterial;
  }

  private struct 땱
  {
    public Uri 딟;
    public 땓.땶 딟;
  }
}
