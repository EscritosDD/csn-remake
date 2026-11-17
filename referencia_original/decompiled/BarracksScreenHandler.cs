// Decompiled with JetBrains decompiler
// Type: BarracksScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class BarracksScreenHandler : BaseMenuHandler
{
  private 딢.딩 딟;
  private bool 딟;
  private new Vector3 딟;
  private BarracksFilterPanelHandler 딟;
  private BarracksWeaponsPanelHandler 딟;
  private BarracksOutfitPanelHandler 딟;
  private BarracksAbilitiesPanelHandler 딟;
  private BarracksBioPanelHandler 딟;
  private BarracksWeaponInfoPanelHandler 딟;
  private BarracksScreenHandler.딡 딟;
  private string 딟;
  private string 땄;
  private string 딧;
  private GameObject 딟;
  private int 딟 = -1;
  private int 땄 = -1;
  private int 딧 = -1;
  private bool 땄;
  private bool 딧;
  private bool 딢;
  private Vector3 땄;
  private GameObject 땄;
  private List<BarracksScreenHandler.딠> 딟 = new List<BarracksScreenHandler.딠>();
  private List<BarracksScreenHandler.딡> 딟 = new List<BarracksScreenHandler.딡>();
  private List<BarracksScreenHandler.딞> 딟 = new List<BarracksScreenHandler.딞>();
  public BarracksFilterPanelHandler BarracksFilterPanelPrefab;
  public BarracksWeaponsPanelHandler BarracksWeaponsPanelPrefab;
  public BarracksOutfitPanelHandler BarracksOutfitPanelPrefab;
  public BarracksAbilitiesPanelHandler BarracksAbilitiesPanelPrefab;
  public BarracksBioPanelHandler BarracksBioPanelPrefab;
  public BarracksWeaponInfoPanelHandler BarracksWeaponInfoPanelPrefab;
  public BarracksCollectPanelHandler BarracksCollectPanelPrefab;
  public LoadingScreenOverlayHandler LoadingOverlayPrefab;
  public Camera BarracksCamera;
  public Transform BarracksSpawnPoint;
  public GuiScroller3D BarracksScroller;
  public float BarracksSpacing;
  public Camera BarracksWeaponCamera;
  public Transform BarracksWeaponSpawnPointStart;
  public Transform BarracksWeaponSpawnPointEnd;
  public GuiScroller3D BarracksWeaponScroller;
  public float BarracksWeaponSpacing;
  public Vector3 BarracksWeaponScale;
  public Vector3 BarracksWeaponRotation;
  public Camera BarracksOutfitCamera;
  public Transform BarracksOutfitSpawnPointStart;
  public Transform BarracksOutfitSpawnPointEnd;
  public GuiScroller3D BarracksOutfitScroller;
  public float BarracksOutfitSpacing;
  public Vector3 BarracksOutfitScale;
  public Vector3 BarracksOutfitRotation;
  public Camera BarracksWeaponInfoCamera;
  public Transform BarracksWeaponInfoSpawnPoint;
  public Transform BarracksWeaponInfoSpawnPointStart;
  public Transform BarracksWeaponInfoSpawnPointEnd;
  public float UnitFocusSpacing;
  public GameObject UnitButtons;
  public GameObject UnitButtonsFocusPos;
  public GuiText3D UnitNameText;
  public GuiText3D UnitClassNameText;
  public GuiTextField3D UnitNameTextField;
  public float CharacterAnimBuffer = -0.8f;
  public GameObject[] FilterIcons = new GameObject[6];
  public GameObject FilterButton;
  public Color InactiveButtonColor = new Color(1f, 1f, 1f, 0.5f);
  public GameObject WeaponButton;
  private Material 딟;
  public GameObject WeaponButtonStoreIcon;
  private Material 땄;
  public GameObject OutfitButton;
  private Material 딧;
  public GameObject OutfitButtonStoreIcon;
  private Material 딢;
  public GameObject BioButton;
  private Material 땃;
  public GameObject CharacterButton;
  private Material 딶;
  public GameObject CharacterButtonStoreIcon;
  private Material 땓;
  public GameObject AbilitiesButton;
  private Material 땺;
  public GuiButton3D BackButton;
  public GuiButton3D ContinueButton;
  public GameObject NamePanel;
  public Renderer ClassIcon;
  public SquadSelectionUnitButtonNew CharacterInfoCard;
  public Shader ButtonNAShader;
  public ToolTipHandler FilteringByClassToolTipPrefab;
  public ToolTipHandler UnitStatsToolTipPrefab;
  public ToolTipHandler WeaponSkinBioToolTipPrefab;
  public CharacterSilhouetteHandler CharacterSilhouettePrefab;
  public GameObject WeaponSilhouettePrefab;
  private bool 땃;
  private 딢.딖 딟;
  private bool 딶;
  private string 딢;
  private BarracksScreenHandler.딡 땄;
  private string 땃;
  private BarracksScreenHandler.딡 딧;
  public Transform PanelStart_Left;
  public Transform PanelEnd_Left;
  public Transform PanelStart_Right;
  public Transform PanelEnd_Right;
  public GuiButton3D LeftScrollButton;
  public GuiButton3D RightScrollButton;
  private bool 땓;

  private void Start()
  {
    base.딟 = ((Component) this).transform.position;
    this.땄 = this.UnitButtons.transform.localPosition;
    this.딟 = ((Component) this.BarracksSpawnPoint).transform.position;
    this.UnitNameTextField.add_TextChangedEvent(new GuiTextField3D.딣(this.OnCharacterNameChanged));
    this.CharacterInfoCard.CharacterIcon.SetActive(false);
    this.CharacterInfoCard.WeaponIcon.SetActive(false);
    this.딟 = 딢.딖.땓;
    this.딟 = this.WeaponButton.renderer.material;
    this.딧 = this.OutfitButton.renderer.material;
    this.땃 = this.BioButton.renderer.material;
    this.땺 = this.AbilitiesButton.renderer.material;
    this.딶 = this.CharacterButton.renderer.material;
    this.땄 = this.WeaponButtonStoreIcon.renderer.material;
    this.딢 = this.OutfitButtonStoreIcon.renderer.material;
    this.땓 = this.CharacterButtonStoreIcon.renderer.material;
  }

  private void ClearCharacters()
  {
    foreach (BarracksScreenHandler.딡 딡 in this.딟)
      딡.Dispose();
    this.딟.Clear();
  }

  private void ClearWeapons()
  {
    foreach (BarracksScreenHandler.딠 딠 in this.딟)
      딠.Dispose();
    this.딟.Clear();
  }

  private void StartCharacterAndWeaponLoads()
  {
    this.ClearCharacters();
    this.ClearWeapons();
    List<땓.떀> 떀List = GlobalAppData.땽().땲();
    for (int index = 0; index < 떀List.Count; ++index)
      this.딟.Add(new BarracksScreenHandler.딡(떀List[index], ((Component) this.BarracksSpawnPoint).transform, (float) -index * this.BarracksSpacing, this.CharacterSilhouettePrefab));
    VersionedGameData versionedGameData = GlobalAppData.딢();
    List<string> stringList = GlobalAppData.땼().땽();
    for (int index = 0; index < stringList.Count; ++index)
    {
      WeaponGameplayData weaponGameplayData = versionedGameData.딟(stringList[index]);
      if (!Object.op_Equality((Object) weaponGameplayData, (Object) null) && weaponGameplayData.IsPrimaryWeapon)
        this.딟.Add(new BarracksScreenHandler.딠(stringList[index], weaponGameplayData, this.BarracksWeaponScale, this.BarracksWeaponRotation, this.WeaponSilhouettePrefab));
    }
    this.CreateCharactersAndWeapons();
  }

  private void CreateCharactersAndWeapons() => this.ApplyFilter(false, 땓.땅.딧);

  private void ApplyFilter(bool UseFilter, 땓.땅 ClassType)
  {
    int num1 = -1;
    this.UpdateFilterIcon(UseFilter, ClassType);
    if (!string.IsNullOrEmpty(this.딧))
    {
      for (int index = 0; index < this.딟.Count; ++index)
      {
        if (this.딟[index].딝().딳() == this.딧)
        {
          num1 = index;
          break;
        }
      }
      this.딧 = (string) null;
    }
    for (int index = 0; index < this.딟.Count; ++index)
    {
      if (this.딟 != -1 && this.딟[index].떎() == this.딟)
        num1 = index;
      this.딟[index].딟(-1);
      this.딟[index].땄();
    }
    this.딟 = -1;
    this.BarracksScroller.set_ActiveElement(0);
    int num2 = 0;
    for (int index = 0; index < this.딟.Count; ++index)
    {
      if (!UseFilter || this.딟[index].딝().땁().ClassType == ClassType)
      {
        if (index == num1)
          this.BarracksScroller.set_ActiveElement(num2);
        this.딟[index].딟(num2);
        this.딟[index].딟((float) -num2 * this.BarracksSpacing);
        ++num2;
      }
    }
    this.BarracksScroller.MinOffset = 0.0f;
    this.BarracksScroller.MaxOffset = (float) (num2 - 1) * this.BarracksSpacing;
    this.BarracksScroller.SpringBounds = this.BarracksSpacing * 0.5f;
    this.BarracksScroller.NumElements = num2;
    this.BarracksScroller.UpdateControl();
    this.BarracksScroller.ResetToActive();
    this.BarracksScroller.set_ScrollStartCallback(new Action(this.ScrollingStarted));
    this.BarracksScroller.set_ScrollEndCallback(new Action(this.ScrollingStopped));
    this.UpdateSpawnPositions();
  }

  private void UpdateFilterIcon(bool UsingFilter, 땓.땅 ClassType)
  {
    foreach (GameObject filterIcon in this.FilterIcons)
      filterIcon.SetActive(false);
    if (!this.get_ShouldShowFilterButton())
      return;
    if (!UsingFilter)
    {
      this.FilterIcons[5].SetActive(true);
      this.딟 = this.FilterIcons[5];
    }
    else
    {
      switch (ClassType)
      {
        case 땓.땅.딟:
          this.FilterIcons[2].SetActive(true);
          this.딟 = this.FilterIcons[2];
          break;
        case 땓.땅.땄:
          this.FilterIcons[3].SetActive(true);
          this.딟 = this.FilterIcons[3];
          break;
        case 땓.땅.딧:
          this.FilterIcons[4].SetActive(true);
          this.딟 = this.FilterIcons[4];
          break;
        case 땓.땅.딢:
          this.FilterIcons[0].SetActive(true);
          this.딟 = this.FilterIcons[0];
          break;
        case 땓.땅.땃:
          this.FilterIcons[1].SetActive(true);
          this.딟 = this.FilterIcons[1];
          break;
      }
    }
  }

  private void HideWeaponInfo() => Object.Destroy((Object) this.땄);

  private void SetupWeaponInfo()
  {
    this.딟 = this.딟.딝().딸();
    UnitWeapon unitWeapon = GlobalAppData.땼().땽(this.딟);
    Object.Destroy((Object) this.땄);
    this.땄 = new GameObject();
    if (Object.op_Inequality((Object) unitWeapon, (Object) null))
    {
      this.땄.transform.localRotation = Quaternion.Euler(unitWeapon.BarracksRotation);
      this.땄.transform.localScale = unitWeapon.BarracksScale;
      UnitTesterComponent.딟(this.땄.transform, unitWeapon);
    }
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    this.딟.UpdateWeaponInfo(this.딟, this.GetNumWeaponsInUse(this.딟, (땓.떀) null));
  }

  private void HideOutfits()
  {
    foreach (BarracksScreenHandler.딞 딞 in this.딟)
      딞.Dispose();
    this.딟.Clear();
  }

  private void SetupCharacterOutfits()
  {
    List<string> stringList = GlobalAppData.땼().땋();
    List<string> OutfitIDs1 = new List<string>();
    List<string> OutfitIDs2 = new List<string>();
    foreach (string str in stringList)
    {
      딢.때 때 = GlobalAppData.땼().딣(str);
      if (!(때.땓() != this.딟.딝().떔()))
      {
        if (string.IsNullOrEmpty(때.땄()))
          OutfitIDs1.Add(str);
        else if (GlobalAppData.땽().딶(때.땄()))
          OutfitIDs1.Add(str);
        else if (!때.땥())
          OutfitIDs2.Add(str);
      }
    }
    if (GlobalAppData.떏().땥())
      this.PopulateOutfitsList(OutfitIDs2);
    this.PopulateOutfitsList(OutfitIDs1);
    for (int index = 0; index < this.딟.Count; ++index)
    {
      if (this.딟[index].땃() == this.딟.딝().땘())
      {
        this.BarracksOutfitScroller.set_ActiveElement(index);
        this.딧 = index;
      }
    }
    this.BarracksOutfitScroller.MinOffset = 0.0f;
    this.BarracksOutfitScroller.MaxOffset = (float) (this.딟.Count - 1) * this.BarracksOutfitSpacing;
    this.BarracksOutfitScroller.SpringBounds = this.BarracksOutfitSpacing * 0.5f;
    this.BarracksOutfitScroller.NumElements = this.딟.Count;
    this.BarracksOutfitScroller.UpdateControl();
    this.BarracksOutfitScroller.ResetToActive();
    this.UpdateSpawnPositions();
  }

  private void PopulateOutfitsList(List<string> OutfitIDs)
  {
    foreach (string outfitId in OutfitIDs)
      this.딟.Add(new BarracksScreenHandler.딞(outfitId, this.딟, this.BarracksOutfitScale, this.BarracksOutfitRotation, this.CharacterSilhouettePrefab));
  }

  private void HideWeapons()
  {
    foreach (BarracksScreenHandler.딠 딠 in this.딟)
      딠.딢();
  }

  private int CompareLevelLockedItems(
    BarracksScreenHandler.딠 Weapon1,
    BarracksScreenHandler.딠 Weapon2)
  {
    return Weapon2.땃().땓() - Weapon1.땃().땓();
  }

  private int SortBySquadPoints(BarracksScreenHandler.딠 Weapon1, BarracksScreenHandler.딠 Weapon2) => Weapon2.땓().SquadPoints - Weapon1.땓().SquadPoints;

  private void SetupCharacterWeapons(string ActiveWeaponId)
  {
    int SelectedIndex = -1;
    List<BarracksScreenHandler.딠> AvailableWeapons1 = new List<BarracksScreenHandler.딠>();
    List<BarracksScreenHandler.딠> AvailableWeapons2 = new List<BarracksScreenHandler.딠>();
    List<BarracksScreenHandler.딠> AvailableWeapons3 = new List<BarracksScreenHandler.딠>();
    VersionedGameData versionedGameData = GlobalAppData.딢();
    BarracksScreenHandler.딠 CurrentlySelectedWeapon = (BarracksScreenHandler.딠) null;
    foreach (BarracksScreenHandler.딠 딠 in this.딟)
    {
      string WeaponId = 딠.땃().딧();
      WeaponGameplayData weaponGameplayData = versionedGameData.딟(WeaponId);
      딢.땻 땻 = GlobalAppData.땼().땔(WeaponId);
      string str = 땻.땄();
      int num1 = GlobalAppData.땽().땃(str);
      int numWeaponsInUse = this.GetNumWeaponsInUse(WeaponId, this.딟.딝());
      int num2 = GlobalAppData.땽().때();
      if (!weaponGameplayData.딟(this.딟.딝()))
      {
        딠.딢();
      }
      else
      {
        if (WeaponId == ActiveWeaponId)
          CurrentlySelectedWeapon = 딠;
        if (num1 > numWeaponsInUse)
          AvailableWeapons1.Add(딠);
        else if (땻.땓() >= num2)
          AvailableWeapons3.Add(딠);
        else if (!땻.땺() || num1 > 0)
          AvailableWeapons2.Add(딠);
      }
    }
    AvailableWeapons3.Sort(new Comparison<BarracksScreenHandler.딠>(this.CompareLevelLockedItems));
    AvailableWeapons1.Sort(new Comparison<BarracksScreenHandler.딠>(this.SortBySquadPoints));
    AvailableWeapons2.Sort(new Comparison<BarracksScreenHandler.딠>(this.SortBySquadPoints));
    int Index = 0;
    if (GlobalAppData.떏().땥())
    {
      this.AddWeaponsToScroller(ref SelectedIndex, AvailableWeapons3, CurrentlySelectedWeapon, ref Index);
      this.AddWeaponsToScroller(ref SelectedIndex, AvailableWeapons2, CurrentlySelectedWeapon, ref Index);
    }
    this.AddWeaponsToScroller(ref SelectedIndex, AvailableWeapons1, CurrentlySelectedWeapon, ref Index);
    this.BarracksWeaponScroller.MinOffset = 0.0f;
    this.BarracksWeaponScroller.MaxOffset = (float) (Index - 1) * this.BarracksWeaponSpacing;
    this.BarracksWeaponScroller.SpringBounds = this.BarracksWeaponSpacing * 0.5f;
    this.BarracksWeaponScroller.NumElements = Index;
    this.BarracksWeaponScroller.UpdateControl();
    this.BarracksWeaponScroller.set_ActiveElement(SelectedIndex);
    this.BarracksWeaponScroller.ResetToActive();
    this.UpdateSpawnPositions();
  }

  private int GetNumWeaponsInUse(string WeaponId, 땓.떀 SkipCharacter)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    BarracksScreenHandler.딿 딿 = new BarracksScreenHandler.딿();
    // ISSUE: reference to a compiler-generated field
    딿.딟 = SkipCharacter;
    // ISSUE: reference to a compiler-generated field
    딿.딟 = WeaponId;
    // ISSUE: reference to a compiler-generated method
    // ISSUE: reference to a compiler-generated method
    return this.딟.Where<BarracksScreenHandler.딡>(new Func<BarracksScreenHandler.딡, bool>(딿.딟)).Count<BarracksScreenHandler.딡>(new Func<BarracksScreenHandler.딡, bool>(딿.땄));
  }

  private void AddWeaponsToScroller(
    ref int SelectedIndex,
    List<BarracksScreenHandler.딠> AvailableWeapons,
    BarracksScreenHandler.딠 CurrentlySelectedWeapon,
    ref int Index)
  {
    foreach (BarracksScreenHandler.딠 availableWeapon in AvailableWeapons)
    {
      availableWeapon.딟(Index);
      if (availableWeapon == CurrentlySelectedWeapon)
      {
        SelectedIndex = Index;
        this.땄 = Index;
      }
      ++Index;
    }
  }

  private void UpdateOutfitSelection()
  {
    if (Object.op_Equality((Object) this.딟, (Object) null) || this.딟.IsClosing || this.딟.Count == 0 || this.딧 == this.BarracksOutfitScroller.get_ActiveElement())
      return;
    this.딧 = this.BarracksOutfitScroller.get_ActiveElement();
    if (this.딟[this.딧].땄())
      this.딟.딟(this.딟[this.딧].땃());
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    this.딟.UpdateOutfitInfo(this.딟[this.딧].땃());
  }

  private void UpdateCharacterSelection()
  {
    if (this.딟 == this.BarracksScroller.get_ActiveElement())
      return;
    this.딟 = this.BarracksScroller.get_ActiveElement();
    this.FixSelectedCharacterName();
    this.딟 = (BarracksScreenHandler.딡) null;
    foreach (BarracksScreenHandler.딡 딡 in this.딟)
    {
      if (딡.떎() == this.딟)
      {
        this.딟 = 딡;
        this.SetupWeaponInfo();
        break;
      }
    }
    if (this.딟 == null)
      return;
    this.땄 = this.딟.딝().땹();
    this.ClassIcon.sharedMaterial = this.딟.딝().땁().GUIIcon;
    this.ClassIcon.sharedMaterial.color = this.UnitNameText.TextColor;
    ((Component) this.ClassIcon).gameObject.SetActive(true);
    this.UnitNameTextField.SetText(this.땄);
    this.UnitClassNameText.Text = 딧.딪.딟(this.딟.딝().땁().ClassName);
    this.UnitClassNameText.UpdateMesh();
    this.딧 = true;
    this.CharacterInfoCard.Init(this.딟.딝(), true, this.ButtonNAShader, false);
  }

  private void FixSelectedCharacterName()
  {
    if (this.딟 == null || this.UnitNameTextField.get_Text().ToString().Trim().Length != 0)
      return;
    this.딟.딝().땃(this.땄);
  }

  private void UpdateWeaponSelection()
  {
    if (Object.op_Equality((Object) this.딟, (Object) null) || this.딟.IsClosing || this.땄 == this.BarracksWeaponScroller.get_ActiveElement())
      return;
    this.땄 = this.BarracksWeaponScroller.get_ActiveElement();
    foreach (BarracksScreenHandler.딠 딠 in this.딟)
    {
      if (this.땄 == 딠.땺())
      {
        this.딟.땄(딠.땃().딧());
        break;
      }
    }
    this.SetupWeaponInfo();
    this.딶 = true;
  }

  public void SetSelectedCharacterWeapon()
  {
    if (this.딢 == null)
      return;
    this.땄.땄(this.딢);
    this.SetupWeaponInfo();
    this.딶 = true;
    this.ClearWeaponFallback();
  }

  public void ClearWeaponFallback()
  {
    this.땄 = (BarracksScreenHandler.딡) null;
    this.딢 = (string) null;
  }

  public void SetSelectedCharacterOutfit()
  {
    if (this.땃 == null)
      return;
    this.딧.딟(this.땃);
    this.ClearOutfitFallback();
  }

  public void ClearOutfitFallback()
  {
    this.딧 = (BarracksScreenHandler.딡) null;
    this.땃 = (string) null;
  }

  private void UpdateSpawnPositions()
  {
    this.UpdateMainSpawnPoint();
    this.UpdateWeaponSpawnPoint();
    this.UpdateOutfitSpawnPoint();
    this.UpdateWeaponInfoSpawnPoint();
  }

  private void UpdateMainSpawnPoint()
  {
    Vector3 딟 = this.딟;
    ref Vector3 local = ref 딟;
    local.x = (__Null) (local.x - (double) this.BarracksScroller.get_Offset());
    GameObject Panel = (GameObject) null;
    if (Object.op_Inequality((Object) this.딟, (Object) null))
      Panel = ((Component) this.딟).gameObject;
    else if (Object.op_Inequality((Object) this.딟, (Object) null))
      Panel = ((Component) this.딟).gameObject;
    else if (Object.op_Inequality((Object) this.딟, (Object) null))
      Panel = ((Component) this.딟).gameObject;
    else if (Object.op_Inequality((Object) this.딟, (Object) null))
      Panel = ((Component) this.딟).gameObject;
    if (Object.op_Inequality((Object) Panel, (Object) null))
    {
      딟.x = (__Null) (double) this.UpdateCharacterSpawnPosition(Panel, (float) 딟.x);
      this.UnitButtons.transform.localPosition = this.UpdateUnitButtonPos(Panel);
    }
    else
      this.UnitButtons.transform.localPosition = Vector3.zero;
    ((Component) this.BarracksSpawnPoint).transform.position = 딟;
  }

  private void UpdateWeaponSpawnPoint()
  {
    Vector3 vector3_1 = !Object.op_Inequality((Object) this.딟, (Object) null) ? this.BarracksWeaponSpawnPointStart.position : this.UpdateUIWithPanelAnim(((Component) this.딟).gameObject, this.BarracksWeaponSpawnPointStart.position, this.BarracksWeaponSpawnPointEnd.position);
    ref Vector3 local1 = ref vector3_1;
    local1.z = (__Null) (local1.z - (double) this.BarracksWeaponScroller.get_Offset());
    foreach (BarracksScreenHandler.딠 딠 in this.딟)
    {
      float num = (float) 딠.땺() * this.BarracksWeaponSpacing;
      Vector3 vector3_2 = vector3_1;
      ref Vector3 local2 = ref vector3_2;
      local2.z = (__Null) (local2.z + (double) num);
      Vector3 worldPoint = this.BarracksWeaponCamera.ViewportToWorldPoint(Camera.main.WorldToViewportPoint(vector3_2));
      딠.딟(worldPoint);
    }
  }

  private void UpdateOutfitSpawnPoint()
  {
    Vector3 vector3_1 = !Object.op_Inequality((Object) this.딟, (Object) null) ? this.BarracksOutfitSpawnPointStart.position : this.UpdateUIWithPanelAnim(((Component) this.딟).gameObject, this.BarracksOutfitSpawnPointStart.position, this.BarracksOutfitSpawnPointEnd.position);
    ref Vector3 local1 = ref vector3_1;
    local1.z = (__Null) (local1.z - (double) this.BarracksOutfitScroller.get_Offset());
    int num1 = 0;
    foreach (BarracksScreenHandler.딞 딞 in this.딟)
    {
      float num2 = (float) num1 * this.BarracksOutfitSpacing;
      Vector3 vector3_2 = vector3_1;
      ref Vector3 local2 = ref vector3_2;
      local2.z = (__Null) (local2.z + (double) num2);
      Vector3 worldPoint = this.BarracksOutfitCamera.ViewportToWorldPoint(Camera.main.WorldToViewportPoint(vector3_2));
      딞.딟(worldPoint);
      ++num1;
    }
  }

  private void UpdateWeaponInfoSpawnPoint()
  {
    if (Object.op_Equality((Object) this.땄, (Object) null))
      return;
    this.땄.transform.position = this.BarracksWeaponInfoCamera.ViewportToWorldPoint(Camera.main.WorldToViewportPoint(!Object.op_Inequality((Object) this.딟, (Object) null) ? this.BarracksWeaponInfoSpawnPointStart.position : this.UpdateUIWithPanelAnim(((Component) this.딟).gameObject, this.BarracksWeaponInfoSpawnPointStart.position, this.BarracksWeaponInfoSpawnPointEnd.position)));
  }

  private void Update()
  {
    foreach (BarracksScreenHandler.딡 딡 in this.딟)
      딡.땺();
    foreach (BarracksScreenHandler.딠 딠 in this.딟)
      딠.딧();
    foreach (BarracksScreenHandler.딞 딞 in this.딟)
      딞.딧();
    if (this.딟.Count > 0)
    {
      this.UpdateCharacterSelection();
      this.UpdateOutfitSelection();
      this.UpdateWeaponSelection();
    }
    if (this.딶 && (Object.op_Equality((Object) this.딟, (Object) null) || Object.op_Inequality((Object) this.딟, (Object) null) && this.딟.IsClosing))
    {
      if (this.딟 != null)
        this.CharacterInfoCard.Init(this.딟.딝(), true, this.ButtonNAShader, false);
      this.딶 = false;
    }
    Renderer renderer = ((Component) this.UnitNameTextField.TextDisplay).renderer;
    if (Object.op_Inequality((Object) renderer, (Object) null))
    {
      Vector3 position = ((Component) this.UnitNameTextField.TextDisplay).transform.position;
      ref Vector3 local = ref position;
      // ISSUE: variable of the null type
      __Null x = local.x;
      Bounds bounds = renderer.bounds;
      double num = ((Bounds) ref bounds).extents.x + 0.0500000007450581;
      local.x = (__Null) (x - num);
      if (Vector3.op_Inequality(position, ((Component) this.ClassIcon).transform.position))
        ((Component) this.ClassIcon).transform.position = position;
    }
    if (this.땄)
    {
      if (this.BarracksScroller.get_IsHeld())
      {
        this.땄 = false;
        this.딧 = true;
      }
    }
    else if (!this.BarracksScroller.get_IsHeld())
    {
      this.땄 = true;
      this.딧 = true;
    }
    if (this.딧)
    {
      this.딧 = false;
      if (!this.땄)
      {
        this.딟.color = this.InactiveButtonColor;
        this.딧.color = this.InactiveButtonColor;
        this.땃.color = this.InactiveButtonColor;
        this.땺.color = this.InactiveButtonColor;
        this.딶.color = this.InactiveButtonColor;
        this.땄.color = this.InactiveButtonColor;
        this.딢.color = this.InactiveButtonColor;
        this.땓.color = this.InactiveButtonColor;
      }
      else
      {
        this.딟.color = Color.white;
        this.딧.color = Color.white;
        this.땃.color = Color.white;
        this.땺.color = Color.white;
        this.딶.color = Color.white;
        this.땄.color = Color.white;
        this.딢.color = Color.white;
        this.땓.color = Color.white;
        this.ShowFilterButton();
        this.NamePanel.SetActive(true);
        ((Component) this.CharacterInfoCard).gameObject.SetActive(true);
        this.CharacterInfoCard.HideLoadingElements();
        if (Object.op_Inequality((Object) this.딟, (Object) null) && !this.딟.IsClosing)
        {
          this.NamePanel.SetActive(false);
          ((Component) this.CharacterInfoCard).gameObject.SetActive(false);
          this.FilterButton.SetActive(false);
        }
        if (Object.op_Inequality((Object) this.딟, (Object) null) && !this.딟.IsClosing)
        {
          this.NamePanel.SetActive(false);
          ((Component) this.CharacterInfoCard).gameObject.SetActive(false);
          this.FilterButton.SetActive(false);
        }
        if (this.get_OpeningWeaponsInfoPanel())
        {
          this.NamePanel.SetActive(false);
          ((Component) this.CharacterInfoCard).gameObject.SetActive(false);
          this.FilterButton.SetActive(false);
        }
        if (Object.op_Inequality((Object) this.딟, (Object) null) && !this.딟.IsClosing)
        {
          this.NamePanel.SetActive(false);
          ((Component) this.CharacterInfoCard).gameObject.SetActive(false);
          this.FilterButton.SetActive(false);
        }
      }
    }
    if (this.get_OpeningWeaponsInfoPanel() && Object.op_Equality((Object) this.딟, (Object) null))
    {
      // ISSUE: reference to a compiler-generated method
      this.set_OpeningWeaponsInfoPanel(false);
      this.딟 = Object.Instantiate((Object) this.BarracksWeaponInfoPanelPrefab) as BarracksWeaponInfoPanelHandler;
      this.딟.Init(this.PanelStart_Right, this.PanelEnd_Right);
      ((Component) this.딟).transform.parent = ((Component) this).transform;
      ((Component) this.딟).transform.localPosition = new Vector3(0.0f, (float) ((Component) this.딟).transform.localPosition.y, 0.0f);
      this.딟.UpdateWeaponInfo(this.딟, this.GetNumWeaponsInUse(this.딟, (땓.떀) null));
      this.UpdateCameraAndScrollerStates();
      this.SetupWeaponInfo();
    }
    if (this.땃 && Object.op_Equality((Object) this.딟, (Object) null))
    {
      this.땃 = false;
      this.딟 = Object.Instantiate((Object) this.BarracksWeaponsPanelPrefab) as BarracksWeaponsPanelHandler;
      this.딟.Init(this.PanelStart_Right, this.PanelEnd_Right);
      ((Component) this.딟).transform.parent = ((Component) this).transform;
      ((Component) this.딟).transform.localPosition = new Vector3(0.0f, (float) ((Component) this.딟).transform.localPosition.y, 0.0f);
      this.딟.UpdateWeaponInfo(this.딟, this.GetNumWeaponsInUse(this.딟, (땓.떀) null));
      this.UpdateCameraAndScrollerStates();
      this.딧 = true;
      this.EnableUnitFocus();
      this.SetupCharacterWeapons(this.딟);
    }
    this.UpdatePanels();
    this.UpdateSpawnPositions();
    this.UpdateCameraAndScrollerStates();
    this.UpdateScrollerButtons();
  }

  private void UpdateScrollerButtons()
  {
    if (this.땓)
      return;
    this.SetGameObjectActive(((Component) this.LeftScrollButton).gameObject, this.BarracksScroller.get_ActiveElement() != 0);
    this.SetGameObjectActive(((Component) this.RightScrollButton).gameObject, this.BarracksScroller.get_ActiveElement() != this.BarracksScroller.NumElements - 1);
  }

  [SpecialName]
  private bool get_ShouldShowFilterButton() => false;

  private void ShowFilterButton()
  {
    this.FilterButton.SetActive(this.get_ShouldShowFilterButton());
    foreach (GameObject filterIcon in this.FilterIcons)
      filterIcon.SetActive(false);
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    this.딟.gameObject.SetActive(this.get_ShouldShowFilterButton());
  }

  private void UpdatePanels()
  {
    if (this.딟 == 딢.딖.땓)
      return;
    switch (this.딟)
    {
      case 딢.딖.딟:
        if (!Object.op_Equality((Object) this.딟, (Object) null) || !Object.op_Equality((Object) this.딟, (Object) null) || !Object.op_Equality((Object) this.딟, (Object) null) || !Object.op_Equality((Object) this.딟, (Object) null))
          break;
        this.BarracksScroller.ResetToActive();
        this.딟 = Object.Instantiate((Object) this.BarracksAbilitiesPanelPrefab) as BarracksAbilitiesPanelHandler;
        ((Component) this.딟).transform.parent = ((Component) this).transform;
        this.딟.Init(this.딟.딝(), this.PanelStart_Left, this.PanelEnd_Left);
        this.딟 = 딢.딖.땓;
        break;
      case 딢.딖.딧:
      case 딢.딖.땺:
        if (!Object.op_Equality((Object) this.딟, (Object) null) || !Object.op_Equality((Object) this.딟, (Object) null) || !Object.op_Equality((Object) this.딟, (Object) null) || !Object.op_Equality((Object) this.딟, (Object) null))
          break;
        this.BarracksScroller.ResetToActive();
        this.딟 = Object.Instantiate((Object) this.BarracksWeaponsPanelPrefab) as BarracksWeaponsPanelHandler;
        this.딟.Init(this.PanelStart_Right, this.PanelEnd_Right);
        ((Component) this.딟).transform.parent = ((Component) this).transform;
        ((Component) this.딟).transform.localPosition = new Vector3(0.0f, (float) ((Component) this.딟).transform.localPosition.y, 0.0f);
        if (this.딟 != 딢.딖.땺)
        {
          this.딢 = this.딟;
          this.땄 = this.딟;
        }
        this.UpdateCameraAndScrollerStates();
        this.딧 = true;
        this.EnableUnitFocus();
        this.SetupCharacterWeapons(this.딟);
        this.딟.UpdateWeaponInfo(this.딟, this.GetNumWeaponsInUse(this.딟, (땓.떀) null));
        this.딟 = 딢.딖.땓;
        break;
      case 딢.딖.땃:
      case 딢.딖.땥:
        if (!Object.op_Equality((Object) this.딟, (Object) null) || !Object.op_Equality((Object) this.딟, (Object) null) || !Object.op_Equality((Object) this.딟, (Object) null) || !Object.op_Equality((Object) this.딟, (Object) null))
          break;
        this.BarracksScroller.ResetToActive();
        if (this.딟 != 딢.딖.땥)
        {
          this.땃 = this.딟.딝().땘();
          this.딧 = this.딟;
        }
        this.딟 = Object.Instantiate((Object) this.BarracksOutfitPanelPrefab) as BarracksOutfitPanelHandler;
        this.딟.Init(this.딟.딝().땁().ClassType != 땓.땅.땃, this.PanelStart_Right, this.PanelEnd_Right);
        ((Component) this.딟).transform.parent = ((Component) this).transform;
        ((Component) this.딟).transform.localPosition = new Vector3(0.0f, (float) ((Component) this.딟).transform.localPosition.y, 0.0f);
        this.UpdateCameraAndScrollerStates();
        this.딧 = true;
        this.EnableUnitFocus();
        this.SetupCharacterOutfits();
        this.딟.UpdateOutfitInfo(this.딟.딝().땘());
        this.딟 = 딢.딖.땓;
        break;
      case 딢.딖.딶:
        if (!Object.op_Equality((Object) this.딟, (Object) null) || !Object.op_Equality((Object) this.딟, (Object) null) || !Object.op_Equality((Object) this.딟, (Object) null) || !Object.op_Equality((Object) this.딟, (Object) null))
          break;
        this.BarracksScroller.ResetToActive();
        this.딟 = Object.Instantiate((Object) this.BarracksBioPanelPrefab) as BarracksBioPanelHandler;
        this.딟.Init(this.딟.딝(), this.PanelStart_Right, this.PanelEnd_Right);
        ((Component) this.딟).transform.parent = ((Component) this).transform;
        ((Component) this.딟).transform.localPosition = new Vector3(0.0f, (float) ((Component) this.딟).transform.localPosition.y, 0.0f);
        this.EnableUnitFocus();
        this.딧 = true;
        this.딟 = 딢.딖.땓;
        break;
    }
  }

  private float UpdateCharacterSpawnPosition(GameObject Panel, float NewPos)
  {
    float StartPos = NewPos;
    float EndPos = StartPos - this.UnitFocusSpacing;
    return this.UpdateUIWithPanelAnim(Panel.gameObject, StartPos, EndPos);
  }

  private float UpdateUIWithPanelAnim(GameObject Panel, float StartPos, float EndPos)
  {
    MenuAnimatorHandler component = Panel.GetComponent<MenuAnimatorHandler>();
    float num = component.SlideAnim.Evaluate(component.get_LerpVal());
    return Mathf.Lerp(StartPos, EndPos, num);
  }

  private Vector3 UpdateUIWithPanelAnim(GameObject Panel, Vector3 StartPos, Vector3 EndPos)
  {
    MenuAnimatorHandler component = Panel.GetComponent<MenuAnimatorHandler>();
    float num = component.SlideAnim.Evaluate(component.get_LerpVal());
    return Vector3.Lerp(StartPos, EndPos, num);
  }

  private Vector3 UpdateUnitButtonPos(GameObject Panel)
  {
    MenuAnimatorHandler component = Panel.GetComponent<MenuAnimatorHandler>();
    return Vector3.Lerp(this.땄, this.UnitButtonsFocusPos.transform.position, component.SlideAnim.Evaluate(component.get_LerpVal()));
  }

  private void EnableUnitFocus()
  {
    if (this.딢)
      return;
    this.딢 = true;
    this.UpdateSpawnPositions();
  }

  private void DisableUnitFocus()
  {
    if (!this.딢)
      return;
    this.딢 = false;
    this.UpdateSpawnPositions();
  }

  private void UpdateCameraAndScrollerStates()
  {
    if (Object.op_Inequality((Object) this.딟, (Object) null))
    {
      ((Component) this.BarracksWeaponCamera).gameObject.SetActive(false);
      ((Component) this.BarracksWeaponScroller).gameObject.SetActive(false);
      ((Component) this.BarracksWeaponInfoCamera).gameObject.SetActive(true);
    }
    else
    {
      this.HideWeaponInfo();
      ((Component) this.BarracksWeaponInfoCamera).gameObject.SetActive(false);
    }
    if (Object.op_Inequality((Object) this.딟, (Object) null))
    {
      ((Component) this.BarracksWeaponCamera).gameObject.SetActive(true);
      ((Component) this.BarracksWeaponScroller).gameObject.SetActive(true);
    }
    else
    {
      this.HideWeapons();
      ((Component) this.BarracksWeaponCamera).gameObject.SetActive(false);
      ((Component) this.BarracksWeaponScroller).gameObject.SetActive(false);
    }
    if (Object.op_Inequality((Object) this.딟, (Object) null))
    {
      ((Component) this.BarracksOutfitCamera).gameObject.SetActive(true);
      ((Component) this.BarracksOutfitScroller).gameObject.SetActive(true);
    }
    else
    {
      this.HideOutfits();
      ((Component) this.BarracksOutfitCamera).gameObject.SetActive(false);
      ((Component) this.BarracksOutfitScroller).gameObject.SetActive(false);
    }
  }

  private void OnCharacterSelected(string CharacterId)
  {
    this.ClosePanels();
    for (int index = 0; index < this.딟.Count; ++index)
    {
      if (this.딟[index].딝().떔() == CharacterId)
      {
        if (this.딟[index].떎() == -1)
          this.ApplyFilter(false, 땓.땅.딧);
        this.BarracksScroller.set_ActiveElement(this.딟[index].떎());
        this.BarracksScroller.ResetToActive();
      }
    }
  }

  public void ForceOpenWeaponPanel()
  {
    if (this.딟 == null || !Object.op_Equality((Object) this.딟, (Object) null))
      return;
    this.딟 = 딢.딖.땺;
  }

  public void ForceOpenWeaponPanelAfterPurchase()
  {
    if (this.딟 == null || !Object.op_Equality((Object) this.딟, (Object) null))
      return;
    this.딟 = 딢.딖.딧;
  }

  public void ForceOpenOutfitPanel()
  {
    if (this.딟 == null || !Object.op_Equality((Object) this.딟, (Object) null))
      return;
    this.ClosePanels();
    this.딟 = 딢.딖.땥;
  }

  public void ForceOpenOutfitPanelAfterPurchase()
  {
    if (this.딟 == null || !Object.op_Equality((Object) this.딟, (Object) null))
      return;
    this.ClosePanels();
    this.딟 = 딢.딖.땃;
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (BarracksScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      BarracksScreenHandler.딟 = new Dictionary<string, int>(21)
      {
        {
          "Back",
          0
        },
        {
          "Continue",
          0
        },
        {
          "CloseWeaponInfoPanel",
          1
        },
        {
          "ClosePanel",
          2
        },
        {
          "WeaponsPanel",
          3
        },
        {
          "OutfitPanel",
          4
        },
        {
          "AbilitiesPanel",
          5
        },
        {
          "BioPanel",
          6
        },
        {
          "WeaponInfoPanel",
          7
        },
        {
          "BuyCharacter",
          8
        },
        {
          "FilterPanel",
          9
        },
        {
          "FilterCommander",
          10
        },
        {
          "FilterSoldier",
          11
        },
        {
          "FilterEngineer",
          12
        },
        {
          "FilterMedic",
          13
        },
        {
          "FilterAgent",
          14
        },
        {
          "FilterAll",
          15
        },
        {
          "ScrollerUp",
          16
        },
        {
          "ScrollerDown",
          17
        },
        {
          "ScrollUnitsLeft",
          18
        },
        {
          "ScrollUnitsRight",
          19
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!BarracksScreenHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        this.DeactivateMenu();
        switch (this.딟)
        {
          case 딢.딩.딟:
            FrontendHub.딟.MainScreen.ActivateMenu();
            return;
          case 딢.딩.땄:
            FrontendHub.딟.CommanderAbilityScreen.TryActivateMenuBack();
            return;
          case 딢.딩.딧:
            FrontendHub.딟.SquadSelectionScreen.ActivateMenu();
            return;
          case 딢.딩.딢:
            FrontendHub.딟.ChallengeLocationSelectionScreen.ActivateMenu();
            return;
          default:
            return;
        }
      case 1:
        this.CloseWeaponInfoPanel();
        this.UpdateCameraAndScrollerStates();
        break;
      case 2:
        if (Object.op_Inequality((Object) this.딟, (Object) null))
          this.딟.set_IsEnteringTheShop(false);
        this.ClosePanels();
        break;
      case 3:
        if (this.딟 == null || !Object.op_Equality((Object) this.딟, (Object) null))
          break;
        this.ResetCharacterToFallback();
        this.ClosePanels();
        this.딟 = 딢.딖.딧;
        break;
      case 4:
        if (this.딟 == null || !Object.op_Equality((Object) this.딟, (Object) null))
          break;
        this.ResetCharacterToFallback();
        this.ClosePanels();
        this.딟 = 딢.딖.땃;
        break;
      case 5:
        if (this.딟 == null || !Object.op_Equality((Object) this.딟, (Object) null))
          break;
        this.ResetCharacterToFallback();
        this.ClosePanels();
        this.딟 = 딢.딖.딟;
        break;
      case 6:
        if (this.딟 == null || !Object.op_Equality((Object) this.딟, (Object) null))
          break;
        this.ResetCharacterToFallback();
        this.ClosePanels();
        this.딟 = 딢.딖.딶;
        break;
      case 7:
        if (!Object.op_Equality((Object) this.딟, (Object) null))
          break;
        // ISSUE: reference to a compiler-generated method
        this.set_OpeningWeaponsInfoPanel(true);
        this.ClosePanels();
        break;
      case 8:
        if (GlobalAppData.떏().땥())
        {
          this.DeactivateMenu();
          FrontendHub.딟.StoreScreen.ActivateMenu(땃.땽.땓);
          break;
        }
        FrontendHub.딟.LoginHandler.LoginAttempt(true);
        break;
      case 9:
        if (!Object.op_Equality((Object) this.딟, (Object) null))
          break;
        this.ClosePanels();
        this.딟 = Object.Instantiate((Object) this.BarracksFilterPanelPrefab) as BarracksFilterPanelHandler;
        ((Component) this.딟).transform.parent = ((Component) this).transform;
        this.딟.Init(this.딟);
        break;
      case 10:
        this.ApplyFilter(true, 땓.땅.땃);
        this.ClosePanels();
        break;
      case 11:
        this.ApplyFilter(true, 땓.땅.딧);
        this.ClosePanels();
        break;
      case 12:
        this.ApplyFilter(true, 땓.땅.딟);
        this.ClosePanels();
        break;
      case 13:
        this.ApplyFilter(true, 땓.땅.땄);
        this.ClosePanels();
        break;
      case 14:
        this.ApplyFilter(true, 땓.땅.딢);
        this.ClosePanels();
        break;
      case 15:
        this.ApplyFilter(false, 땓.땅.딧);
        this.ClosePanels();
        break;
      case 16:
        if (((Component) this.BarracksWeaponScroller).gameObject.activeInHierarchy)
        {
          this.BarracksWeaponScroller.IncrementScroller();
          break;
        }
        this.BarracksOutfitScroller.IncrementScroller();
        break;
      case 17:
        if (((Component) this.BarracksWeaponScroller).gameObject.activeInHierarchy)
        {
          this.BarracksWeaponScroller.DecrementScroller();
          break;
        }
        this.BarracksOutfitScroller.DecrementScroller();
        break;
      case 18:
        if (this.BarracksScroller.get_ActiveElement() == 0)
          break;
        this.BarracksScroller.DecrementScroller();
        break;
      case 19:
        if (this.BarracksScroller.get_ActiveElement() == this.BarracksScroller.NumElements - 1)
          break;
        this.BarracksScroller.IncrementScroller();
        break;
    }
  }

  public void CloseWeaponInfoPanel()
  {
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    this.딟.Close();
    this.땃 = true;
  }

  public void ClosePanels()
  {
    if (Object.op_Inequality((Object) this.딟, (Object) null))
    {
      this.딟.Close();
      this.딟 = (BarracksFilterPanelHandler) null;
    }
    if (Object.op_Inequality((Object) this.딟, (Object) null))
      this.딟.Close();
    if (Object.op_Inequality((Object) this.딟, (Object) null))
      this.딟.Close();
    if (Object.op_Inequality((Object) this.딟, (Object) null))
      this.딟.Close();
    if (Object.op_Inequality((Object) this.딟, (Object) null))
    {
      this.딟.Close();
      this.딟 = (BarracksAbilitiesPanelHandler) null;
    }
    if (Object.op_Inequality((Object) this.딟, (Object) null))
      this.딟.Close();
    this.딧 = true;
    this.DisableUnitFocus();
  }

  public void ActivateMenu(딶.땂 Team, string ActiveUnitUniqueId, 딢.딩 ReturnScreenId, bool IsInFlow)
  {
    this.딟 = ReturnScreenId;
    this.딧 = ActiveUnitUniqueId;
    this.딟 = IsInFlow;
    this.ActivateMenu();
  }

  private void UpdateBackAndContinueButtons()
  {
    ((Component) this.BackButton).gameObject.SetActive(!this.딟);
    ((Component) this.ContinueButton).gameObject.SetActive(this.딟);
  }

  public void ActivateMenu(딢.딩 ReturnScreenId, bool IsInFlow)
  {
    this.딟 = IsInFlow;
    this.딟 = ReturnScreenId;
    this.ActivateMenu();
  }

  public override void ActivateMenu()
  {
    base.ActivateMenu();
    this.UpdateBackAndContinueButtons();
    this.UnitButtons.transform.localPosition = this.땄;
    this.StartCharacterAndWeaponLoads();
    this.UpdateCameraAndScrollerStates();
    if (GlobalAppData.땽().딟(딢.땹.딟) == 0)
      this.UnitStatsToolTipPrefab.Display();
    else if (this.get_ShouldShowFilterButton())
      this.FilteringByClassToolTipPrefab.Display();
    ((Component) this.BarracksCamera).gameObject.SetActive(true);
    FrontendHub.딟.MoneyDisplay.UpdateDisplay(true, MoneyDisplayHandler.딤.딧);
    GlobalAppData.땽().딧(딢.땹.딟);
    if (!GlobalAppData.떏().땥())
      return;
    FrontendHub.딟.StoreScreen.RequestiTunesCatalogue();
  }

  public override void DeactivateMenu()
  {
    base.DeactivateMenu();
    this.FixSelectedCharacterName();
    this.ResetCharacterToFallback();
    this.Save();
    this.ClosePanels();
    this.ClearCharacters();
    this.ClearWeapons();
    this.HideOutfits();
    this.딟 = (BarracksScreenHandler.딡) null;
    Resources.UnloadUnusedAssets();
    ((Component) this.BarracksCamera).gameObject.SetActive(false);
  }

  private void ResetCharacterToFallback()
  {
    this.SetSelectedCharacterOutfit();
    this.SetSelectedCharacterWeapon();
  }

  private void Save()
  {
    foreach (BarracksScreenHandler.딡 딡 in this.딟)
      GlobalAppData.땽().딧(딡.딝().딗());
    GlobalAppData.땽().땥();
  }

  private void OnCharacterNameChanged() => this.딟.딝().땃(this.UnitNameTextField.get_Text().ToString());

  public void ScrollingStopped()
  {
    this.땓 = false;
    if (this.BarracksScroller.get_ActiveElement() != 0)
      this.SetGameObjectActive(((Component) this.LeftScrollButton).gameObject, true);
    if (this.BarracksScroller.get_ActiveElement() == this.BarracksScroller.NumElements - 1)
      return;
    this.SetGameObjectActive(((Component) this.RightScrollButton).gameObject, true);
  }

  public void ScrollingStarted()
  {
    this.땓 = true;
    ((Component) this.LeftScrollButton).gameObject.SetActive(false);
    ((Component) this.RightScrollButton).gameObject.SetActive(false);
  }

  [CompilerGenerated]
  [SpecialName]
  public bool get_OpeningWeaponsInfoPanel() => this.땺;

  private class 딞 : IDisposable
  {
    private 딢.때 딟;
    private Vector3 딟;
    private BarracksScreenHandler.딡 딟;
    private GameObject 딟;

    public 딞(
      [In] string obj0,
      [In] BarracksScreenHandler.딡 obj1,
      [In] Vector3 obj2,
      [In] Vector3 obj3,
      [In] CharacterSilhouetteHandler obj4)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0);
      this.딟 = obj1;
      this.딟 = obj2;
      this.딟 = new GameObject();
      this.딟.transform.localRotation = Quaternion.Euler(obj3);
      this.딟.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
      CharacterSilhouetteHandler silhouetteHandler = Object.Instantiate((Object) obj4) as CharacterSilhouetteHandler;
      ((Component) silhouetteHandler).transform.parent = this.딟.transform;
      ((Component) silhouetteHandler).transform.localPosition = Vector3.zero;
      ((Component) silhouetteHandler).transform.localRotation = Quaternion.Euler(new Vector3(270f, 0.0f, 0.0f));
      this.딟 = GlobalAppData.땼().딣(obj0);
      // ISSUE: reference to a compiler-generated method
      this.딟(BarracksScreenHandler.딞.UpdateState.Download);
    }

    private void 딟()
    {
      for (int index = 0; index < this.딟.transform.childCount; ++index)
        Object.Destroy((Object) ((Component) this.딟.transform.GetChild(index)).gameObject);
      this.딟.transform.DetachChildren();
      UnitTesterComponent.딟(this.딟.transform, GlobalAppData.땼().떏(this.땃()), this.딟.딝().딛(), this.딟.딝().땷(), this.딟.딝().땔(), (Material) null, this.딟.딝().딛().딟((딶.땖) null, 땓.딺.딟), 0);
      this.딟.SetActive(true);
      // ISSUE: reference to a compiler-generated method
      this.딟(BarracksScreenHandler.딞.UpdateState.Active);
    }

    public void Dispose()
    {
      Object.Destroy((Object) this.딟);
      this.딟 = (GameObject) null;
      this.딟.땃();
    }

    [SpecialName]
    public bool 땄() => GlobalAppData.땼().딣(this.땃()).딢();

    public void 딧()
    {
      BarracksScreenHandler.딞.UpdateState updateState;
      do
      {
        updateState = this.딢();
        switch (this.딢())
        {
          case BarracksScreenHandler.딞.UpdateState.Download:
            if (GlobalAppData.땼().딢((딟.땩) this.딟))
            {
              GlobalAppData.땼().땓(this.땃());
              // ISSUE: reference to a compiler-generated method
              this.딟(BarracksScreenHandler.딞.UpdateState.Load);
              break;
            }
            break;
          case BarracksScreenHandler.딞.UpdateState.Load:
            if (this.땄())
            {
              this.딟();
              break;
            }
            break;
        }
      }
      while (updateState != this.딢());
    }

    public void 딟([In] Vector3 obj0)
    {
      if (this.딢() != BarracksScreenHandler.딞.UpdateState.Active)
      {
        this.딟.transform.position = obj0;
        this.딟.transform.localScale = Vector3.one;
      }
      else
      {
        if (Object.op_Equality((Object) GlobalAppData.땼().떏(this.땃()), (Object) null))
          return;
        this.딟.transform.position = obj0;
        this.딟.transform.localScale = this.딟;
      }
    }

    [CompilerGenerated]
    [SpecialName]
    public BarracksScreenHandler.딞.UpdateState 딢() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public string 땃() => this.딟;

    public enum UpdateState
    {
      Download,
      Load,
      Active,
    }
  }

  public class 딡 : IDisposable
  {
    private List<딟.땩> 딟;
    private CharacterSilhouetteHandler 딟;
    private CharacterSilhouetteHandler 땄;
    private float 딟;
    private GameObject 딟;

    public 딡([In] 땓.떀 obj0, [In] Transform obj1, [In] float obj2, [In] CharacterSilhouetteHandler obj3)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0);
      this.딝().땠();
      this.딟 = obj2;
      this.딟 = obj3;
      this.딟 = new GameObject();
      this.딟.transform.parent = obj1;
      this.딟.transform.localPosition = new Vector3(this.딟, 0.0f, 0.0f);
      this.딟.transform.localRotation = Quaternion.identity;
      this.딟.SetActive(false);
      this.딟(-1);
      this.딟();
    }

    private void 딟()
    {
      this.딶();
      // ISSUE: reference to a compiler-generated method
      this.딟(BarracksScreenHandler.딡.UpdateState.Download);
      this.딟 = new List<딟.땩>();
      this.딝().딟(this.딟, 땓.땾.딟);
      this.땄 = Object.Instantiate((Object) this.딟) as CharacterSilhouetteHandler;
      ((Component) this.땄).transform.parent = this.딟.transform;
      ((Component) this.땄).transform.localPosition = Vector3.zero;
      ((Component) this.땄).transform.localRotation = Quaternion.Euler(new Vector3(270f, 0.0f, 0.0f));
      this.땄.SetIcons(true);
      this.땺();
    }

    public void 딟([In] float obj0)
    {
      this.딟 = obj0;
      this.딟.transform.localPosition = new Vector3(obj0, 0.0f, 0.0f);
      this.딟.transform.localRotation = Quaternion.identity;
      this.딟.SetActive(true);
      this.땓();
    }

    public void 땄() => this.딟.SetActive(false);

    [SpecialName]
    public bool 딧()
    {
      foreach (딟.땩 땩 in this.딟)
      {
        if (땩 != null && !땩.딢())
          return false;
      }
      return true;
    }

    private bool 딢() => this.딟 != null && GlobalAppData.땼().딟((IEnumerable<딟.땩>) this.딟);

    public void 땃()
    {
      this.딶();
      this.딝().땠();
      if (Object.op_Inequality((Object) this.딝().땁(), (Object) null))
      {
        UnitTesterComponent.딟(this.딟.transform, this.딝().딣(), (UnitWeapon) null, this.딝().땷(), this.딝().땔(), (Material) null, this.딝().딛().딟((딶.땖) null, 땓.딺.딟), 0);
        UnitTesterComponent.딟(this.딟.transform, this.딝().딛());
        // ISSUE: reference to a compiler-generated method
        this.딟(BarracksScreenHandler.딡.UpdateState.Active);
        this.땓();
      }
      else
        Debug.LogWarning((object) ("Character with id " + this.딝().떔() + " does not exist in the build manifest"));
    }

    private void 딶()
    {
      for (int index = 0; index < this.딟.transform.childCount; ++index)
        Object.Destroy((Object) ((Component) this.딟.transform.GetChild(index)).gameObject);
      this.딟.transform.DetachChildren();
    }

    private void 땓()
    {
      if (this.떂() != BarracksScreenHandler.딡.UpdateState.Active || Object.op_Equality((Object) this.딝().딛(), (Object) null))
        return;
      UnitTesterComponent.딟(this.딟.transform, this.딝().딛().딟((딶.땖) null, 땓.딺.딟), true, true);
    }

    public void 땺()
    {
      BarracksScreenHandler.딡.UpdateState updateState;
      do
      {
        updateState = this.떂();
        switch (this.떂())
        {
          case BarracksScreenHandler.딡.UpdateState.Download:
            if (this.딢())
            {
              this.땄.SetIcons(false);
              this.땥();
              break;
            }
            break;
          case BarracksScreenHandler.딡.UpdateState.Load:
            if (this.딧())
            {
              this.땃();
              break;
            }
            break;
        }
      }
      while (updateState != this.떂());
    }

    public void Dispose()
    {
      foreach (Renderer componentsInChild in this.딟.GetComponentsInChildren<Renderer>())
      {
        for (int index = 0; index < componentsInChild.materials.Length; ++index)
          GlobalAppData.딟(componentsInChild.materials[index]);
      }
      Object.Destroy((Object) this.딟);
      this.딟 = (GameObject) null;
      foreach (딟.땩 땩 in this.딟)
      {
        if (땩 is 딢.때)
          땩.땃();
      }
      // ISSUE: reference to a compiler-generated method
      this.딟((땓.떀) null);
    }

    private void 땥()
    {
      GlobalAppData.땼().딟((땓.딲) this.딝(), 땓.땾.딟);
      // ISSUE: reference to a compiler-generated method
      this.딟(BarracksScreenHandler.딡.UpdateState.Load);
    }

    public void 딟([In] string obj0)
    {
      this.딝().땄(obj0);
      this.딟();
    }

    public void 땄([In] string obj0)
    {
      this.딝().딟(obj0);
      this.딟();
    }

    [CompilerGenerated]
    [SpecialName]
    public 땓.떀 딝() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public int 떎() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] int obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public BarracksScreenHandler.딡.UpdateState 떂() => this.딟;

    public enum UpdateState
    {
      Download,
      Load,
      Active,
    }
  }

  private class 딠 : IDisposable
  {
    private Vector3 딟;
    private Vector3 땄;
    private string 딟;
    private GameObject 딟;

    public 딠([In] string obj0, [In] WeaponGameplayData obj1, [In] Vector3 obj2, [In] Vector3 obj3, [In] GameObject obj4)
    {
      this.딟 = obj0;
      // ISSUE: reference to a compiler-generated method
      this.딟(obj1);
      this.딟 = new GameObject();
      this.딟.SetActive(false);
      GameObject gameObject = Object.Instantiate((Object) obj4) as GameObject;
      gameObject.transform.parent = this.딟.transform;
      gameObject.transform.localPosition = Vector3.zero;
      gameObject.transform.localRotation = Quaternion.identity;
      // ISSUE: reference to a compiler-generated method
      this.땄(-1);
      this.딟 = obj2;
      this.땄 = obj3;
      // ISSUE: reference to a compiler-generated method
      this.딟(GlobalAppData.땼().땔(obj0));
      // ISSUE: reference to a compiler-generated method
      this.딟(BarracksScreenHandler.딠.UpdateState.Download);
    }

    public void 딟()
    {
      for (int index = 0; index < this.딟.transform.childCount; ++index)
        Object.Destroy((Object) ((Component) this.딟.transform.GetChild(index)).gameObject);
      this.딟.transform.DetachChildren();
      UnitWeapon unitWeapon = GlobalAppData.땼().땽(this.딟);
      for (int index = 0; index < unitWeapon.Models.Length; ++index)
      {
        Transform transform = Object.Instantiate((Object) unitWeapon.Models[index].ModelPrefab) as Transform;
        transform.parent = this.딟.transform;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(this.땄);
        ((Component) transform).transform.localScale = this.딟;
      }
      // ISSUE: reference to a compiler-generated method
      this.딟(BarracksScreenHandler.딠.UpdateState.Active);
      this.딟.SetActive(this.땺() != -1);
    }

    [SpecialName]
    public bool 땄() => GlobalAppData.땼().땔(this.딟).딢();

    public void 딧()
    {
      BarracksScreenHandler.딠.UpdateState updateState;
      do
      {
        updateState = this.딶();
        switch (this.딶())
        {
          case BarracksScreenHandler.딠.UpdateState.Download:
            if (GlobalAppData.땼().딢((딟.땩) this.땃()))
            {
              GlobalAppData.땼().땃(this.딟);
              // ISSUE: reference to a compiler-generated method
              this.딟(BarracksScreenHandler.딠.UpdateState.Load);
              break;
            }
            break;
          case BarracksScreenHandler.딠.UpdateState.Load:
            if (this.땄())
            {
              this.딟();
              break;
            }
            break;
        }
      }
      while (updateState != this.딶());
    }

    public void Dispose()
    {
      Object.Destroy((Object) this.딟);
      this.딟 = (GameObject) null;
    }

    public void 딢()
    {
      this.딟.gameObject.SetActive(false);
      this.딟.transform.parent = (Transform) null;
      // ISSUE: reference to a compiler-generated method
      this.땄(-1);
    }

    public void 딟([In] int obj0)
    {
      // ISSUE: reference to a compiler-generated method
      this.땄(obj0);
      this.딟.gameObject.SetActive(true);
    }

    public void 딟([In] Vector3 obj0)
    {
      if (this.딶() != BarracksScreenHandler.딠.UpdateState.Active)
      {
        this.딟.transform.position = obj0;
        this.딟.transform.localRotation = Quaternion.identity;
        this.딟.transform.localScale = Vector3.one;
      }
      else
      {
        UnitWeapon unitWeapon = GlobalAppData.땼().땽(this.딟);
        if (Object.op_Equality((Object) unitWeapon, (Object) null))
          return;
        this.딟.transform.position = Vector3.op_Addition(obj0, unitWeapon.BarracksOffset);
        this.딟.transform.localRotation = Quaternion.Euler(unitWeapon.BarracksRotation);
        this.딟.transform.localScale = unitWeapon.BarracksScale;
      }
    }

    [CompilerGenerated]
    [SpecialName]
    public 딢.땻 땃() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public BarracksScreenHandler.딠.UpdateState 딶() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public WeaponGameplayData 땓() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public int 땺() => this.딟;

    public enum UpdateState
    {
      Download,
      Load,
      Active,
    }
  }
}
