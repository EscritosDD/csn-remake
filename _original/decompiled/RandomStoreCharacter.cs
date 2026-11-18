// Decompiled with JetBrains decompiler
// Type: RandomStoreCharacter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class RandomStoreCharacter : MonoBehaviour
{
  private 딟.땩 딟;
  private List<딟.땩> 딟;
  private RandomStoreCharacter.떃 딟;
  private string[] 딟;
  private 땓.떉 딟;
  private GameObject 딟;
  private GameObject 땄;
  private 땄.딺 딟;
  private 딧.딼 딟 = new 딧.딼();
  public GameObject CharacterLoadingSpinnerPrefab;
  public GameObject CharacterIcon;
  public GameObject CoinsIcon;
  public GuiText3D CoinsCostText;
  public GameObject ShoppingCartIcon;
  public GuiText3D CharacterNameText;
  public GuiText3D CharacterNameDropShadow;
  public GuiText3D MoneyText;
  public Transform SpawnPoint;
  public Transform WeaponSpawnPoint;
  public GuiText3D OfflineText;
  public GuiText3D OrText;
  public GameObject StoreButton;

  private void Start() => this.Deactivate();

  public void Activate()
  {
    this.RequestFeaturedItems();
    if (Object.op_Inequality((Object) this.OfflineText, (Object) null))
      ((Component) this.OfflineText).gameObject.SetActive(false);
    if (!Object.op_Inequality((Object) this.ShoppingCartIcon, (Object) null))
      return;
    this.ShoppingCartIcon.SetActive(false);
  }

  private void RequestFeaturedItems()
  {
    if (this.딟 != null)
      this.LoadFeaturedItem();
    else if (this.딟 != null || !GlobalAppData.떏().땥())
    {
      this.SelectFeaturedItem();
    }
    else
    {
      this.딟 = GlobalAppData.떏().땺();
      this.딟 = RandomStoreCharacter.떃.땄;
    }
  }

  private void SelectFeaturedItem()
  {
    if (this.딟 != null)
    {
      foreach (string str in this.딟)
      {
        딢.땻 땻 = GlobalAppData.땼().땔(str);
        if (땻 != null)
        {
          if (!GlobalAppData.땽().딶(땻.땄()))
          {
            if (GlobalAppData.땼().딢((딟.땩) 땻))
            {
              this.딟 = (딟.땩) 땻;
              break;
            }
          }
          else
            continue;
        }
        딢.땥 땥 = GlobalAppData.땼().딸(str);
        if (땥 != null)
        {
          if (!GlobalAppData.땽().딶(땥.땄()))
          {
            if (RandomStoreCharacter.딟(str, (string) null))
            {
              this.딟 = (딟.땩) 땥;
              break;
            }
          }
          else
            continue;
        }
        딢.때 때 = GlobalAppData.땼().딣(str);
        if (때 != null && !GlobalAppData.땽().딶(때.땄()) && RandomStoreCharacter.딟(때.땓(), str))
        {
          this.딟 = (딟.땩) 때;
          break;
        }
      }
    }
    if (this.딟 == null)
      this.SelectRandomCharacter();
    this.LoadFeaturedItem();
  }

  private void SelectRandomCharacter()
  {
    딢.딛 딛 = GlobalAppData.땼();
    List<string> stringList = 딛.땤();
    List<딢.땥> 땥List1 = new List<딢.땥>();
    foreach (string str in stringList)
    {
      if (RandomStoreCharacter.딟(str, (string) null))
      {
        딢.땥 땥 = 딛.딸(str);
        땥List1.Add(땥);
      }
    }
    List<딢.땥> 땥List2 = new List<딢.땥>();
    foreach (딢.땥 땥 in 땥List1)
    {
      if (!GlobalAppData.땽().딶(땥.땄()))
        땥List2.Add(땥);
    }
    List<딢.땥> 땥List3 = 땥List2.Count <= 0 ? 땥List1 : 땥List2;
    if (땥List3.Count == 0)
      return;
    int index = Random.Range(0, 땥List3.Count);
    this.딟 = (딟.땩) 땥List3[index];
  }

  private static bool 딟([In] string obj0, [In] string obj1)
  {
    List<딟.땩> 땩List = new List<딟.땩>();
    RandomStoreCharacter.딟(obj0, obj1, 땩List);
    return GlobalAppData.땼().딟((IEnumerable<딟.땩>) 땩List);
  }

  private static void 딟([In] string obj0, [In] string obj1, [In] List<딟.땩> obj2)
  {
    땓.떀 떀 = new 땓.떀(-1, obj0);
    if (obj1 != null)
      떀.땄(obj1);
    떀.딟(obj2, 땓.땾.딟);
  }

  private void LoadFeaturedItem()
  {
    this.딟 = new List<딟.땩>();
    if (this.딟 is 딢.땥)
      RandomStoreCharacter.딟(this.딟.딧(), (string) null, this.딟);
    else if (this.딟 is 딢.때)
    {
      딢.때 딟 = this.딟 as 딢.때;
      RandomStoreCharacter.딟(딟.땓(), 딟.딧(), this.딟);
    }
    else if (this.딟 is 딢.땻)
      this.딟.Add((딟.땩) (this.딟 as 딢.땻));
    GlobalAppData.땼().땄((IEnumerable<딟.땩>) this.딟);
    this.딟 = RandomStoreCharacter.떃.딧;
  }

  public void Deactivate()
  {
    if (Object.op_Inequality((Object) this.딟, (Object) null))
    {
      Object.Destroy((Object) this.딟);
      this.딟 = (GameObject) null;
    }
    if (Object.op_Inequality((Object) this.땄, (Object) null))
      Object.Destroy((Object) this.땄);
    if (this.딟 != null)
    {
      foreach (딟.땩 땩 in this.딟)
      {
        if (땩 is 딢.때)
          땩.땃();
      }
    }
    this.딟 = RandomStoreCharacter.떃.딟;
  }

  private void SpawnFeaturedItem()
  {
    this.딟 = RandomStoreCharacter.떃.딢;
    if (this.딟 is 딢.땥)
    {
      딢.땥 딟 = this.딟 as 딢.땥;
      this.SpawnCharacter(딟.딧(), (string) null);
      this.StartStoreRequest(딟.땭());
    }
    else if (this.딟 is 딢.때)
    {
      딢.때 딟 = this.딟 as 딢.때;
      this.SpawnCharacter(딟.땓(), 딟.딧());
      this.StartStoreRequest(딟.땄());
    }
    else
    {
      if (!(this.딟 is 딢.땻))
        return;
      딢.땻 딟 = this.딟 as 딢.땻;
      this.SpawnWeapon(딟.딧());
      this.StartStoreRequest(딟.땄());
    }
  }

  private void SpawnCharacter(string CharacterId, string OutfitId)
  {
    딢.딛 딛 = GlobalAppData.땼();
    bool flag = false;
    if (OutfitId == null)
    {
      OutfitId = 딛.땳(CharacterId);
      flag = true;
    }
    UnitWeapon unitWeapon = 딛.땽(딛.딗(CharacterId));
    UnitOutfit unitOutfit = 딛.떏(OutfitId);
    UnitClass unitClass = 딛.땢(CharacterId);
    if (flag)
    {
      this.CharacterNameText.LocText = unitClass.DefaultName;
      if (Object.op_Inequality((Object) this.CharacterNameDropShadow, (Object) null))
        this.CharacterNameDropShadow.LocText = unitClass.DefaultName;
    }
    else
    {
      this.CharacterNameText.LocText = unitOutfit.Name;
      if (Object.op_Inequality((Object) this.CharacterNameDropShadow, (Object) null))
        this.CharacterNameDropShadow.LocText = unitOutfit.Name;
    }
    this.CharacterNameText.UpdateMesh();
    if (Object.op_Inequality((Object) this.CharacterNameDropShadow, (Object) null))
      this.CharacterNameDropShadow.UpdateMesh();
    if (Object.op_Inequality((Object) this.CharacterIcon, (Object) null))
      this.딟.딟(this.CharacterIcon, unitClass.CharacterIcon);
    this.딟 = new GameObject();
    this.딟.transform.parent = this.SpawnPoint;
    this.딟.transform.localPosition = Vector3.zero;
    this.딟.transform.localRotation = Quaternion.identity;
    UnitTesterComponent.딟(this.딟.transform, unitOutfit, unitWeapon, (UnitBodyType) null, (UnitVoicePack) null, (Material) null, unitWeapon.딟((딶.땖) null, 땓.딺.딟), 0);
  }

  private void SpawnWeapon(string WeaponId)
  {
    UnitWeapon unitWeapon = GlobalAppData.땼().땽(WeaponId);
    this.CharacterNameText.LocText = unitWeapon.Name;
    if (Object.op_Inequality((Object) this.CharacterNameDropShadow, (Object) null))
    {
      this.CharacterNameDropShadow.LocText = unitWeapon.Name;
      this.CharacterNameDropShadow.UpdateMesh();
    }
    this.CharacterNameText.UpdateMesh();
    if (Object.op_Inequality((Object) this.CharacterIcon, (Object) null))
      this.딟.딟(this.CharacterIcon, unitWeapon.Icon);
    this.딟 = new GameObject();
    this.딟.transform.parent = this.WeaponSpawnPoint;
    this.딟.transform.localPosition = Vector3.zero;
    this.딟.transform.localRotation = Quaternion.identity;
    UnitTesterComponent.딟(this.딟.transform, unitWeapon);
  }

  private void StartStoreRequest(string ProductId)
  {
    // ISSUE: reference to a compiler-generated method
    this.set_CachedProductId(ProductId);
    if (GlobalAppData.떏().땥())
    {
      if (string.IsNullOrEmpty(ProductId))
        return;
      this.딟 = GlobalAppData.떏().땴(ProductId);
    }
    else
    {
      this.CoinsIcon.gameObject.SetActive(false);
      ((Component) this.CoinsCostText).gameObject.SetActive(false);
      if (Object.op_Inequality((Object) this.OrText, (Object) null))
        ((Component) this.OrText).gameObject.SetActive(false);
      if (Object.op_Inequality((Object) this.StoreButton, (Object) null))
        this.StoreButton.SetActive(false);
      if (Object.op_Inequality((Object) this.ShoppingCartIcon, (Object) null))
        this.ShoppingCartIcon.SetActive(false);
      if (!Object.op_Inequality((Object) this.OfflineText, (Object) null))
        return;
      ((Component) this.OfflineText).gameObject.SetActive(true);
    }
  }

  private void Update()
  {
    if (this.딟 == RandomStoreCharacter.떃.딟)
    {
      this.딟 = (땓.떉) null;
      this.딟 = (땄.딺) null;
    }
    else
    {
      if (this.딟 != null && this.딟.땄())
      {
        if (this.딟.딧())
          this.딟 = this.딟.딟.Items;
        this.SelectFeaturedItem();
        this.딟 = (땓.떉) null;
      }
      if (this.딟 == RandomStoreCharacter.떃.딧)
      {
        if (Object.op_Equality((Object) this.땄, (Object) null))
        {
          this.땄 = Object.Instantiate((Object) this.CharacterLoadingSpinnerPrefab) as GameObject;
          this.땄.transform.parent = ((Component) FrontendHub.딟.MainScreen).transform;
          this.땄.transform.position = Vector3.zero;
        }
        if (this.get_RequiredItemsAreLoaded())
        {
          Object.Destroy((Object) this.땄);
          this.SpawnFeaturedItem();
        }
      }
      if (this.딟 == null || !this.딟.땄() || !this.딟.딧())
        return;
      OfferData offerData = ((IEnumerable<OfferData>) this.딟.딟).FirstOrDefault<OfferData>((Func<OfferData, bool>) (obj0 => obj0.Price.ContainsKey(GlobalAppData.딧().GameSettings.CurrencyCoinsId)));
      this.CoinsCostText.Text = offerData != null ? offerData.딢().ToString() : "N/A";
      this.CoinsCostText.UpdateMesh();
      this.CoinsIcon.gameObject.SetActive(true);
      ((Component) this.CoinsCostText).gameObject.SetActive(true);
      if (Object.op_Inequality((Object) this.OfflineText, (Object) null))
        ((Component) this.OfflineText).gameObject.SetActive(false);
      if (Object.op_Inequality((Object) this.ShoppingCartIcon, (Object) null))
        this.ShoppingCartIcon.SetActive(true);
      this.딟 = (땄.딺) null;
    }
  }

  private void OnDestroy()
  {
    GlobalAppData.땄(this.딟);
    GlobalAppData.땄(this.땄);
    if (Object.op_Inequality((Object) this.CharacterIcon, (Object) null))
      GlobalAppData.땄(this.CharacterIcon);
    GlobalAppData.땄(this.CoinsIcon);
    if (Object.op_Inequality((Object) this.ShoppingCartIcon, (Object) null))
      GlobalAppData.땄(this.ShoppingCartIcon);
    this.딟.딟();
  }

  [SpecialName]
  private bool get_RequiredItemsAreLoaded()
  {
    if (this.딟.Count == 0)
      return false;
    foreach (딟.땩 땩 in this.딟)
    {
      if (!땩.딢())
        return false;
    }
    return true;
  }

  [CompilerGenerated]
  [SpecialName]
  public string get_CachedProductId() => this.딟;

  private enum 떃
  {
    딟,
    땄,
    딧,
    딢,
  }
}
