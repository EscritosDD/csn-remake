// Decompiled with JetBrains decompiler
// Type: UnitInfoScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class UnitInfoScreenHandler : BaseHUDScreenHandler
{
  public GuiText3D UnitNameText;
  public GameObject UnitThumbImage;
  public GameObject UnitThumbClassImage;
  public GameObject UnitThumbBackgroundImage;
  public Material UnitThumbTeam1Background;
  public Material UnitThumbTeam2Background;
  public GuiButton3D DoneButton;
  public GuiButton3D ShoppingCartButton;
  public GuiScrollList3D UnitInfoList;
  public Camera GameCamera;
  public Camera UnitCamera;
  public GameObject UnitSpawn;
  public Material CharacterAbilityBlue;
  public Material CharacterAbilityRed;
  public Material PlayerAbilityBlue;
  public Material PlayerAbilityRed;
  public Transform UnitNamePrefab;
  public Transform UnitHealthAPPrefab;
  public Transform UnitWeaponPrefab;
  public Transform UnitAbilityHeaderPrefab;
  public Transform UnitAbilityPrefab;
  private GameObject 딟;
  private bool 딟;
  private int 딟;
  private int 땄;

  public override void InitailiseScreenData()
  {
    ((Component) this.GameCamera).gameObject.SetActive(false);
    ((Component) this.UnitCamera).gameObject.SetActive(true);
    this.UnitSpawn.SetActive(true);
    ((Component) this).gameObject.SetActive(true);
    this.get_Game().땢().SetLoadingBackgroundActive(true);
    if (!Object.op_Inequality((Object) this.UnitInfoList, (Object) null))
      return;
    this.UnitInfoList.RemoveAll(true);
  }

  public void SetUnitInfoScreenData(땓.땦 Unit, 땓.떀 Character, int TeamIndex)
  {
    if (Unit == null || Character == null)
      return;
    this.딟 = TeamIndex;
    this.땄 = Unit.땔();
    this.LoadUnitPaperDoll();
    this.SetCharacterThumbData(Character);
    this.PopulateUnitInfoList(Unit, Character);
    this.SetBuyCharacterButton(Unit, Character);
  }

  private void LoadUnitPaperDoll() => this.딟 = true;

  private void SetCharacterThumbData(땓.떀 Character)
  {
    if (Object.op_Inequality((Object) this.UnitThumbImage, (Object) null))
      this.UnitThumbImage.renderer.sharedMaterial = Character.땁().CharacterIcon;
    if (Object.op_Inequality((Object) this.UnitThumbClassImage, (Object) null))
      this.UnitThumbClassImage.renderer.sharedMaterial = Character.땁().GUIIcon;
    if (!Object.op_Inequality((Object) this.UnitThumbBackgroundImage, (Object) null))
      return;
    this.UnitThumbBackgroundImage.renderer.sharedMaterial = this.딟 != 0 ? this.UnitThumbTeam2Background : this.UnitThumbTeam1Background;
  }

  private void SetBuyCharacterButton(땓.땦 Unit, 땓.떀 Character)
  {
  }

  private void PopulateUnitInfoList(땓.땦 Unit, 땓.떀 Character)
  {
    if (Object.op_Equality((Object) this.UnitInfoList, (Object) null))
      return;
    this.PopulateUnitInfoListName(Character);
    this.PopulateUnitInfoHealthAP(Character, Unit);
    this.PopulateUnitInfoWeapon(Character, Unit);
    this.PopulateUnitInfoAbilites(Character, Unit);
  }

  private void PopulateUnitInfoListName(땓.떀 Character)
  {
    if (!Object.op_Inequality((Object) this.UnitNamePrefab, (Object) null))
      return;
    Transform transform = Object.Instantiate((Object) this.UnitNamePrefab) as Transform;
    ((Component) transform).GetComponentInChildren<UnitInfoListName>().SetUnitName(Character);
    this.UnitInfoList.AddItem(transform, 1f / 16f);
  }

  private void PopulateUnitInfoHealthAP(땓.떀 Character, 땓.땦 Unit)
  {
    if (!Object.op_Inequality((Object) this.UnitHealthAPPrefab, (Object) null))
      return;
    Transform transform = Object.Instantiate((Object) this.UnitHealthAPPrefab) as Transform;
    ((Component) transform).GetComponentInChildren<UnitInfoListHealthAP>().SetUnitHealthActionPoints(Character, Unit);
    this.UnitInfoList.AddItem(transform, 0.146875f);
  }

  private void PopulateUnitInfoWeapon(땓.떀 Character, 땓.땦 Unit)
  {
    if (!Object.op_Inequality((Object) this.UnitWeaponPrefab, (Object) null) || !Object.op_Inequality((Object) Character.딛(), (Object) null))
      return;
    Transform transform = Object.Instantiate((Object) this.UnitWeaponPrefab) as Transform;
    UnitInfoListWeapon componentInChildren = ((Component) transform).GetComponentInChildren<UnitInfoListWeapon>();
    WeaponGameplayData weaponGameplayData = Character.딛().딟(this.get_Game().땼());
    float num = weaponGameplayData.딟(this.get_Game().땼().땞(), Unit.땴());
    componentInChildren.SetUnitWeapon(Character.딛().Icon, Character.딛().Name, weaponGameplayData.RequiredActionPoints.ToString(), weaponGameplayData.MaxRange.ToString(), num.ToString());
    this.UnitInfoList.AddItem(transform, 3f / 32f);
  }

  private void PopulateUnitInfoAbilites(땓.떀 Character, 땓.땦 Unit)
  {
    bool HeaderAdded = false;
    if (Character == null || !Object.op_Inequality((Object) this.UnitAbilityPrefab, (Object) null))
      return;
    for (int index = 0; index < Character.떓().Count; ++index)
    {
      PlayerAbilityEntry playerAbilityEntry = GlobalAppData.딢().GenericData.딟(Character.떓()[index]);
      if (playerAbilityEntry != null)
        HeaderAdded = this.AddAbilityToList(playerAbilityEntry.AbilityInfo, this.GetBackgroundForAbility(false), Character, Unit, HeaderAdded);
    }
    for (int index = 0; index < Character.땁().Abilities.Length; ++index)
    {
      AbilityInfo Ability = GlobalAppData.딢().GenericData.땄(Character.땁().Abilities[index]);
      if (Ability != null)
        HeaderAdded = this.AddAbilityToList(Ability, this.GetBackgroundForAbility(true), Character, Unit, HeaderAdded);
    }
  }

  private bool AddAbilityToList(
    AbilityInfo Ability,
    Material AbilityBackground,
    땓.떀 Character,
    땓.땦 Unit,
    bool HeaderAdded)
  {
    if (!HeaderAdded)
    {
      this.AddAbilityHeaderToList();
      HeaderAdded = true;
    }
    Transform transform = Object.Instantiate((Object) this.UnitAbilityPrefab) as Transform;
    ((Component) transform).GetComponentInChildren<UnitInfoListAbility>().SetUnitAbility(Ability, Character.땄(), Unit.땔(), AbilityBackground);
    this.UnitInfoList.AddItem(transform, 0.084375f);
    return HeaderAdded;
  }

  private Material GetBackgroundForAbility(bool CharacterAbility) => CharacterAbility ? (this.딟 == 0 ? this.CharacterAbilityBlue : this.CharacterAbilityRed) : (this.딟 == 0 ? this.PlayerAbilityBlue : this.PlayerAbilityRed);

  private void AddAbilityHeaderToList()
  {
    if (!Object.op_Inequality((Object) this.UnitAbilityHeaderPrefab, (Object) null))
      return;
    this.UnitInfoList.AddItem(Object.Instantiate((Object) this.UnitAbilityHeaderPrefab) as Transform, 5f / 128f);
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (UnitInfoScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      UnitInfoScreenHandler.딟 = new Dictionary<string, int>(3)
      {
        {
          "Done",
          0
        },
        {
          "BuyCharacter",
          1
        },
        {
          "BuyWeapon",
          2
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!UnitInfoScreenHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        this.CloseUnitInfoScreen();
        break;
      case 1:
        this.CloseUnitInfoScreen();
        break;
      case 2:
        this.CloseUnitInfoScreen();
        break;
    }
  }

  public void CloseUnitInfoScreen()
  {
    this.DestroyUnit();
    this.get_Game().땢().ActivateGameplayHUD();
    this.get_Game().땢().SetLoadingBackgroundActive(false);
    ((Component) this.GameCamera).gameObject.SetActive(true);
    ((Component) this.UnitCamera).gameObject.SetActive(false);
    this.UnitSpawn.SetActive(false);
    ((Component) this).gameObject.SetActive(false);
  }

  private void Update()
  {
    if (!this.딟 || ((딟.딗) GlobalAppData.땼()).땽())
      return;
    this.SpawnUnit();
    this.딟 = false;
  }

  private void SpawnUnit()
  {
    딶.땖 땖 = this.get_Game().땼();
    foreach (int index in 땖.딧(this.딟))
    {
      땓.떀 떀 = 땖.땻()[index] as 땓.떀;
      if (index == this.땄 && Object.op_Inequality((Object) this.UnitSpawn, (Object) null))
      {
        this.딟 = new GameObject();
        UnitTesterComponent.딟(this.딟.transform, 떀.딣(), 떀.딛(), 떀.땷(), 떀.땔(), (Material) null, 떀.딛().딟((딶.땖) null, 땓.딺.딟), this.딟);
        this.딟.transform.parent = this.UnitSpawn.transform;
        this.딟.transform.localPosition = Vector3.zero;
        this.딟.transform.localRotation = Quaternion.Euler(0.0f, 20f, 0.0f);
        break;
      }
    }
  }

  private void DestroyUnit()
  {
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    Object.Destroy((Object) this.딟);
    this.딟 = (GameObject) null;
  }
}
