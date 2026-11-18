// Decompiled with JetBrains decompiler
// Type: StoreScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class StoreScreenHandler : BaseMenuHandler
{
  public const float 딟 = 0.125f;
  private 땃.땽 딟;
  private StoreScreenHandler.떏 딟;
  public List<땃.딷> StoreItems;
  private LoadingScreenOverlayHandler 딟;
  private 땃.땽 땄;
  private string 딟;
  private StoreBundleNameDividerHandler 딟;
  private GameObject 딟;
  private bool 딟;
  private bool 땄;
  private bool 딧;
  private 딧.딼 딟 = new 딧.딼();
  private 딧.딼 땄 = new 딧.딼();
  private List<StoreScreenHandler.땲> 딟 = new List<StoreScreenHandler.땲>();
  private ErrorMessagehandler 딟;
  private StorePanel 딟;
  public ClassInfo[] ClassInfoList;
  public Shader ClippedShader;
  public StoreTagButton[] DefaultCategoryPrefabs;
  public StoreItemButton ItemButtonPrefab;
  public StoreItemButton SaleItemButtonPrefab;
  public StoreWarbuxButtonHandler WarbuxButtonPrefab;
  public StoreBundleButtonHandler StoreBundleButton;
  public GuiButton3D BackButton;
  public float ButtonOpacity = 0.5f;
  public LoadingScreenOverlayHandler LoadingOverlayPrefab;
  public Material Back;
  public Material BackOneStep;
  public GuiScrollList3D MainScrollList;
  public Transform ScrollListBuffer;
  public StoreBundleNameDividerHandler BundleNameDividerPrefab;
  public GameObject BundleItemsDividerPrefab;
  public StoreDividerHandler StoreDivider;
  public StoreDividerHandler StoreDividerNaCl;
  public StorePurchaseWeaponPanelHandler WeaponPanelPrefab;
  public StorePurchaseCharacterPanelHandler CharacterPanelPrefab;
  public StorePurchaseSkinPanelHandler SkinPanelPrefab;
  public StorePurchaseBoosterPanelHandler BoosterPanelPrefab;
  public StorePurchaseConfirmationPanelHandler PurchaseConfirmationPrefab;
  public StorePurchaseWarbuxConfirmationPanelHandle PurchaseWarbuxConfrimationPrefab;
  public StoreChallengeInfoPanelhandler StoreChallengeInfoPanelPrefab;
  public WrongVersionMessageHandler WrongVersionPrefab;
  public 땄.딪 CatalogResponse;
  public Transform PanelStart_Right;
  public Transform PanelEnd_Right;
  public SuccessMessageHandler SuccessOverlayPrefab;
  [SerializeField]
  private CurrencyPurchasePopupHandler currencyPopupPrefab;
  private CurrencyPurchasePopupHandler 딟;

  private void Awake()
  {
    base.딟 = ((Component) this).transform.position;
    this.StoreItems = new List<땃.딷>();
    this.ChangeInitialiseState(StoreScreenHandler.떏.땄);
    for (int index = 0; index < this.ClassInfoList.Length; ++index)
      ((Component) this.ClassInfoList[index].Icon).renderer.sharedMaterial = new Material(((Component) this.ClassInfoList[index].Icon).renderer.material)
      {
        shader = this.ClippedShader
      };
  }

  private void Start() => this.set_ImageCache(new 딟.땫(4096, (딟.땇) GlobalAppData.떏()));

  private void ChangeInitialiseState(StoreScreenHandler.떏 NewState)
  {
    if (this.딟 == StoreScreenHandler.떏.딢)
      this.TransformToView();
    if (this.딟 == StoreScreenHandler.떏.딟)
    {
      this.딟 = NewState;
    }
    else
    {
      if ((NewState != StoreScreenHandler.떏.땄 || this.딟 != StoreScreenHandler.떏.딧) && (NewState != StoreScreenHandler.떏.딧 || this.딟 != StoreScreenHandler.떏.땄))
        return;
      this.TransformToView();
      this.딟 = StoreScreenHandler.떏.딢;
    }
  }

  private void TransformToView() => ((Component) this).transform.position = Vector3.zero;

  private void FilterItemsToList(
    GuiScrollList3D List,
    IEnumerable<땃.딷> Items,
    Func<땃.딷, bool> FilterFunc)
  {
    this.UpdateOwnedCharacterClasses();
    if (Items == null)
      return;
    foreach (땃.딷 딷 in Items)
    {
      Debug.Log((object) ("ITEM NAME : " + 딷.딢()));
      Debug.Log((object) ("ITEM ID : " + 딷.딧()));
      if (FilterFunc(딷))
      {
        if (딷.땂() || 딷.딱())
        {
          StoreWarbuxButtonHandler warbuxButtonHandler = Object.Instantiate((Object) this.WarbuxButtonPrefab) as StoreWarbuxButtonHandler;
          warbuxButtonHandler.Init(this, 딷);
          List.AddItemNoUpdate(((Component) warbuxButtonHandler).transform, (float) ((double) warbuxButtonHandler.Spacing * 0.5 / 320.0));
        }
        else
        {
          StoreItemButton storeItemButton = Object.Instantiate(!딷.땩() ? (Object) this.ItemButtonPrefab : (Object) this.SaleItemButtonPrefab) as StoreItemButton;
          storeItemButton.Init(this, 딷, false, 딷.딟(), 1);
          List.AddItemNoUpdate(((Component) storeItemButton).transform, (float) ((double) storeItemButton.Spacing * 0.5 / 320.0));
        }
      }
    }
    List.ForceItemsUpdate();
  }

  private void UpdateOwnedCharacterClasses()
  {
    if (this.get_OwnedClasses() == null)
    {
      // ISSUE: reference to a compiler-generated method
      this.set_OwnedClasses(new bool[5]);
    }
    int num = 0;
    foreach (땓.떀 떀 in GlobalAppData.땽().땲())
    {
      떀.땠();
      if (Object.op_Equality((Object) 떀.땁(), (Object) null))
      {
        Debug.LogWarning((object) ("Character with id " + 떀.떔() + " does not exist in the build manifest"));
      }
      else
      {
        if (!this.get_OwnedClasses()[(int) 떀.땁().ClassType])
        {
          this.get_OwnedClasses()[(int) 떀.땁().ClassType] = true;
          ++num;
        }
        if (num == 5)
          break;
      }
    }
  }

  private void GoBack()
  {
    BaseMenuHandler 땄 = BaseMenuHandler.땄;
    this.DeactivateMenu();
    if (Object.op_Inequality((Object) 땄, (Object) null) && Object.op_Inequality((Object) 땄, (Object) this))
      땄.ActivateMenu();
    else
      FrontendHub.딟.MainScreen.ActivateMenu();
  }

  private void OnButtonPressed(string Command)
  {
    if (Command != "Back")
      this.딟.딟();
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (StoreScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      StoreScreenHandler.딟 = new Dictionary<string, int>(11)
      {
        {
          "Back",
          0
        },
        {
          "ShowFeatured",
          1
        },
        {
          "ShowCategories",
          2
        },
        {
          "ShowTagsNew",
          3
        },
        {
          "ShowTagsSale",
          4
        },
        {
          "ShowCategoryCharacters",
          5
        },
        {
          "ShowCategoryWeapons",
          6
        },
        {
          "ShowCategorySkins",
          7
        },
        {
          "ShowCategoryBundles",
          8
        },
        {
          "ShowMapAndChallengeBundles",
          9
        },
        {
          "PurchaseCoins",
          10
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!StoreScreenHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        this.GoBack();
        break;
      case 1:
        this.SetState(땃.땽.딢);
        this.BackButton.Command = "Back";
        break;
      case 2:
        this.SetState(땃.땽.딧);
        this.BackButton.Command = "Back";
        break;
      case 3:
        this.SetState(땃.땽.땃);
        this.BackButton.Command = "ShowTags";
        break;
      case 4:
        this.SetState(땃.땽.딶);
        this.BackButton.Command = "ShowTags";
        break;
      case 5:
        딟.딦.딟("StoreCategoryCharacters");
        this.SetState(땃.땽.땓);
        this.BackButton.Command = "ShowCategories";
        break;
      case 6:
        딟.딦.딟("StoreCategoryWeapons");
        this.SetState(땃.땽.땺);
        this.BackButton.Command = "ShowCategories";
        break;
      case 7:
        딟.딦.딟("StoreCategoryOutfits");
        this.SetState(땃.땽.땥);
        this.BackButton.Command = "ShowCategories";
        break;
      case 8:
        딟.딦.딟("StoreCategoryBundles");
        this.SetState(땃.땽.딝);
        this.BackButton.Command = "ShowCategories";
        break;
      case 9:
        딟.딦.딟("StoreMapAndChallengeBundles");
        this.SetState(땃.땽.떂);
        this.BackButton.Command = "ShowCategories";
        break;
      case 10:
        if (!Object.op_Inequality((Object) this.currencyPopupPrefab, (Object) null) || !Object.op_Equality((Object) this.딟, (Object) null))
          break;
        this.딟 = Object.Instantiate((Object) this.currencyPopupPrefab) as CurrencyPurchasePopupHandler;
        this.딟.Init(new Action(this.CloseCurrencyPopupInstance), new Action<string>(this.CurrencyPopupPurchaseBegin));
        break;
    }
  }

  private void CurrencyPopupPurchaseBegin(string productID)
  {
    foreach (땃.딷 딷 in GlobalAppData.땋().땃())
    {
      if (딷.땃().땄() == productID)
      {
        if (Object.op_Inequality((Object) this.딟, (Object) null))
          this.딟.ClosePopup();
        this.CurrencyPurchase(딷);
      }
    }
  }

  private void CurrencyPurchase(땃.딷 Item)
  {
    StorePurchaseWarbuxConfirmationPanelHandle confirmationPanelHandle = Object.Instantiate((Object) this.PurchaseWarbuxConfrimationPrefab) as StorePurchaseWarbuxConfirmationPanelHandle;
    confirmationPanelHandle.Init(this.get_ImageCache(), Item);
    this.딟 = (StorePanel) confirmationPanelHandle;
  }

  private void CloseCurrencyPopupInstance()
  {
    Object.Destroy((Object) ((Component) this.딟).gameObject);
    this.딟 = (CurrencyPurchasePopupHandler) null;
  }

  private void OpenLoadingOverlay() => this.딟 = Object.Instantiate((Object) this.LoadingOverlayPrefab, new Vector3(0.0f, 2f, 0.0f), Quaternion.identity) as LoadingScreenOverlayHandler;

  private void CloseLoadingOverlay()
  {
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    this.딟.Close();
    this.딟 = (LoadingScreenOverlayHandler) null;
  }

  private void OnBundleSelected(땃.딷 Item)
  {
    StorePurchaseConfirmationPanelHandler confirmationPanelHandler = Object.Instantiate((Object) this.PurchaseConfirmationPrefab) as StorePurchaseConfirmationPanelHandler;
    confirmationPanelHandler.Init(Item, this.get_ImageCache());
    confirmationPanelHandler.set_OnSuccessCallback(new Action(this.OnBundlePurchased));
    this.딟 = (StorePanel) confirmationPanelHandler;
  }

  private void OnBundlePurchased()
  {
    GuiScrollList3D.땴[] items = this.MainScrollList.GetItems();
    if (items.Length < 2)
      return;
    StoreBundleButtonHandler component = ((Component) items[1].딟).GetComponent<StoreBundleButtonHandler>();
    if (Object.op_Equality((Object) component, (Object) null) || !component.get_Item().땢())
      return;
    ((Component) component.Button).gameObject.SetActive(false);
  }

  private void UnityPurchaseConfirmed(string JsonString)
  {
  }

  private void OnWarbuxItemSelected(땃.딷 Item)
  {
    StorePurchaseWarbuxConfirmationPanelHandle confirmationPanelHandle = Object.Instantiate((Object) this.PurchaseWarbuxConfrimationPrefab) as StorePurchaseWarbuxConfirmationPanelHandle;
    confirmationPanelHandle.Init(this.get_ImageCache(), Item);
    this.딟 = (StorePanel) confirmationPanelHandle;
  }

  private static void 딟([In] 땃.딷 obj0)
  {
    string str = (string) null;
    if (obj0.땤())
      str = "StoreWeaponView";
    else if (obj0.떏())
      str = "StoreCharacterView";
    else if (obj0.땲())
      str = "StoreOutfitView";
    else if (obj0.땋())
      str = "StoreBoostView";
    else if (obj0.땽())
      str = "StoreBundleView";
    if (str == null)
      return;
    StoreScreenHandler.딟(obj0, str);
  }

  private static void 딟([In] 땃.딷 obj0, [In] string obj1) => 딟.딦.딟(obj1, new Dictionary<string, string>()
  {
    {
      "productid",
      obj0.땃().땄()
    }
  });

  private void OnStoreItemSelected(StoreItemButton.떎 StoreItemInfo)
  {
    땃.딷 딟 = StoreItemInfo.딟;
    StoreScreenHandler.딟(딟);
    if ((딟.땃().땃() as 땓.딞).땺() > 10)
      Object.Instantiate((Object) this.WrongVersionPrefab);
    else if (딟.딦())
    {
      StorePurchaseConfirmationPanelHandler confirmationPanelHandler = Object.Instantiate((Object) this.PurchaseConfirmationPrefab) as StorePurchaseConfirmationPanelHandler;
      confirmationPanelHandler.Init(딟, this.get_ImageCache());
      this.딟 = (StorePanel) confirmationPanelHandler;
    }
    else if (딟.땤())
    {
      StorePurchaseWeaponPanelHandler weaponPanelHandler = Object.Instantiate((Object) this.WeaponPanelPrefab) as StorePurchaseWeaponPanelHandler;
      weaponPanelHandler.Init(StoreItemInfo, this.PanelStart_Right, this.PanelEnd_Right);
      this.딟 = (StorePanel) weaponPanelHandler;
    }
    else if (딟.떏())
    {
      StorePurchaseCharacterPanelHandler characterPanelHandler = Object.Instantiate((Object) this.CharacterPanelPrefab) as StorePurchaseCharacterPanelHandler;
      characterPanelHandler.Init(StoreItemInfo, this.PanelStart_Right, this.PanelEnd_Right);
      this.딟 = (StorePanel) characterPanelHandler;
    }
    else if (딟.땲())
    {
      StorePurchaseSkinPanelHandler skinPanelHandler = Object.Instantiate((Object) this.SkinPanelPrefab) as StorePurchaseSkinPanelHandler;
      skinPanelHandler.Init(StoreItemInfo, this.PanelStart_Right, this.PanelEnd_Right);
      this.딟 = (StorePanel) skinPanelHandler;
    }
    else if (딟.땋())
    {
      StorePurchaseBoosterPanelHandler boosterPanelHandler = Object.Instantiate((Object) this.BoosterPanelPrefab) as StorePurchaseBoosterPanelHandler;
      boosterPanelHandler.Init(StoreItemInfo, this.PanelStart_Right, this.PanelEnd_Right);
      this.딟 = (StorePanel) boosterPanelHandler;
    }
    else
    {
      if (!딟.땽() && !딟.딷())
        return;
      this.ResetStoreListToDisplayBundleContents(딟);
    }
  }

  private void ResetStoreListToDisplayBundleContents(땃.딷 Item)
  {
    this.OpenLoadingOverlay();
    foreach (KeyValuePair<string, int> keyValuePair in Item.땃().딝())
    {
      if (!(keyValuePair.Key == "1efe42bd-1d03-4188-8d21-c6f68c2d2fc1"))
        this.딟.Add(new StoreScreenHandler.땲()
        {
          딟 = GlobalAppData.떏().땠(keyValuePair.Key),
          딟 = keyValuePair.Value
        });
    }
    this.땄 = true;
    this.딧 = Item.딷();
    this.SetState(땃.땽.떎);
    if (Item.땽())
      this.BackButton.Command = "ShowCategoryBundles";
    else if (Item.딷())
      this.BackButton.Command = "ShowMapAndChallengeBundles";
    this.MainScrollList.Reset();
    this.딟 = Object.Instantiate((Object) this.BundleNameDividerPrefab) as StoreBundleNameDividerHandler;
    this.딟.Init(Item.딢());
    this.MainScrollList.AddItem(((Component) this.딟).gameObject.transform, (float) ((double) this.딟.Spacing * 0.5 / 320.0));
    StoreBundleButtonHandler bundleButtonHandler = Object.Instantiate((Object) this.StoreBundleButton) as StoreBundleButtonHandler;
    bundleButtonHandler.Init(this, Item);
    this.MainScrollList.AddItem(((Component) bundleButtonHandler).transform, (float) ((double) bundleButtonHandler.Spacing * 0.5 / 320.0));
    this.딟 = Object.Instantiate((Object) this.BundleItemsDividerPrefab) as GameObject;
    this.MainScrollList.AddItem(this.딟.gameObject.transform, 7f / 64f);
  }

  private void SetState(땃.땽 State)
  {
    if (this.딟 == State)
      return;
    this.땄.딟();
    this.딟 = State;
    this.MainScrollList.RemoveAll(true);
    this.MainScrollList.Reset();
    switch (State)
    {
      case 땃.땽.딧:
        foreach (Object defaultCategoryPrefab in this.DefaultCategoryPrefabs)
        {
          StoreTagButton storeTagButton = Object.Instantiate(defaultCategoryPrefab) as StoreTagButton;
          this.MainScrollList.AddItemNoUpdate(((Component) storeTagButton).transform, (float) ((double) storeTagButton.Spacing * 0.5 / 320.0));
        }
        break;
      case 땃.땽.딢:
        this.AddStoreDivider(StoreDividerHandler.땥.딟);
        this.SetupStoreCategory((Func<땃.딷, bool>) (obj0 => obj0.땭()));
        break;
      case 땃.땽.땓:
        this.AddStoreDivider(StoreDividerHandler.땥.딧);
        this.SetupStoreCategory((Func<땃.딷, bool>) (obj0 => obj0.떏()), false);
        break;
      case 땃.땽.땺:
        this.AddStoreDivider(StoreDividerHandler.땥.딢);
        this.SetupStoreCategory((Func<땃.딷, bool>) (obj0 => obj0.땤()), false);
        break;
      case 땃.땽.땥:
        this.AddStoreDivider(StoreDividerHandler.땥.땃);
        this.SetupStoreCategory((Func<땃.딷, bool>) (obj0 => obj0.땲()), false);
        break;
      case 땃.땽.딝:
        this.AddStoreDivider(StoreDividerHandler.땥.땓);
        this.SetupStoreCategory((Func<땃.딷, bool>) (obj0 => obj0.땽()));
        break;
      case 땃.땽.떂:
        this.AddStoreDivider(StoreDividerHandler.땥.땥);
        this.SetupStoreCategory((Func<땃.딷, bool>) (obj0 => obj0.딷()));
        break;
    }
    this.MainScrollList.AddItem(Object.Instantiate((Object) this.ScrollListBuffer) as Transform, 0.125f);
    this.MainScrollList.ForceItemsUpdate();
  }

  private void AddStoreDivider(StoreDividerHandler.땥 DividerType)
  {
    StoreDividerHandler storeDividerHandler = Object.Instantiate((Object) this.StoreDividerNaCl) as StoreDividerHandler;
    storeDividerHandler.Init(DividerType);
    this.MainScrollList.AddItem(((Component) storeDividerHandler).transform, (float) ((double) storeDividerHandler.DividerSpacing * 0.5 / 320.0));
  }

  private void SetupStoreCategory(Func<땃.딷, bool> FilterFunc) => this.SetupStoreCategory(FilterFunc, true);

  private void SetupStoreCategory(Func<땃.딷, bool> FilterFunc, bool IncludeExternal)
  {
    this.FilterItemsToList(this.MainScrollList, (IEnumerable<땃.딷>) this.StoreItems, FilterFunc);
    if (!IncludeExternal)
      return;
    this.FilterItemsToList(this.MainScrollList, (IEnumerable<땃.딷>) GlobalAppData.땋().땃(), FilterFunc);
  }

  private bool HasCompletedAllOffers() => GlobalAppData.땽().딟(딢.땹.땼) > 0 && GlobalAppData.땽().딟(딢.땹.땢) > 0 && GlobalAppData.땽().딟(딢.땹.딷) > 0 && GlobalAppData.땽().딟(딢.땹.떁) > 0 && GlobalAppData.땽().딟(딢.땹.땟) > 0;

  public override void ActivateMenu()
  {
    base.ActivateMenu();
    this.ActivateMenu(this.땄);
  }

  public void ActivateMenu(땃.땽 PendingStoreState) => this.ActivateMenu(PendingStoreState, (string) null);

  public void ActivateMenu(땃.땽 PendingStoreState, string RequestedProductId)
  {
    base.ActivateMenu();
    this.ChangeInitialiseState(StoreScreenHandler.떏.딧);
    this.땄 = PendingStoreState;
    this.딟 = RequestedProductId;
    this.OpenLoadingOverlay();
    this.RequestiTunesCatalogue();
    this.CatalogResponse = GlobalAppData.떏().딟(딟.딘.딟);
    FrontendHub.딟.MoneyDisplay.UpdateDisplay(true, MoneyDisplayHandler.딤.땄);
  }

  public void RequestiTunesCatalogue() => GlobalAppData.땋().딟();

  public override void DeactivateMenu()
  {
    base.DeactivateMenu();
    ((Component) this).transform.position = base.딟;
    this.MainScrollList.RemoveAll(true);
    this.딟 = 땃.땽.딟;
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    this.딟.Close();
  }

  private void OnErrorClosing(object Sender, EventArgs Args)
  {
    (Sender as ErrorMessagehandler).OnClosing -= new EventHandler(this.OnErrorClosing);
    this.GoBack();
  }

  private void DisplayErrorMessage(딟.땑 ErrorCode, ErrorMessagehandler.땶 ErrorType)
  {
    if (!Object.op_Equality((Object) this.딟, (Object) null))
      return;
    this.딟 = Object.Instantiate((Object) FrontendHub.딟.ErrorMessage) as ErrorMessagehandler;
    this.딟.Init(ErrorType, ErrorCode);
    GuiComponent3D.딟((GuiComponent3D) this.딟.ConfirmButton);
  }

  private void Update()
  {
    if (this.CatalogResponse != null && this.CatalogResponse.땄())
    {
      if (this.CatalogResponse.딧())
      {
        this.StoreItems = ((IEnumerable<땄.땗>) this.CatalogResponse.딟).OrderBy<땄.땗, int>((Func<땄.땗, int>) (obj0 => (obj0.땃() as 땓.딞).땓())).Select<땄.땗, 땃.딷>((Func<땄.땗, 땃.딷>) (obj0 => new 땃.딷(obj0))).ToList<땃.딷>();
        this.딟 = true;
      }
      else
      {
        this.DisplayErrorMessage(((땄.땘) this.CatalogResponse).딟, !this.CatalogResponse.딟() ? ErrorMessagehandler.땶.딟 : ErrorMessagehandler.땶.땽);
        this.딟 = false;
        if (Object.op_Inequality((Object) this.딟, (Object) null))
          this.딟.Close();
        BaseMenuHandler baseMenuHandler = BaseMenuHandler.땄;
        if (Object.op_Equality((Object) baseMenuHandler, (Object) null))
          baseMenuHandler = (BaseMenuHandler) FrontendHub.딟.MainScreen;
        this.DeactivateMenu();
        baseMenuHandler.ActivateMenu();
      }
      this.CatalogResponse = (땄.딪) null;
    }
    if (this.딟 && !GlobalAppData.땋().딧())
    {
      StoreItemButton.떎? nullable = new StoreItemButton.떎?();
      if (!string.IsNullOrEmpty(this.딟))
      {
        nullable = this.SearchStoreListsForItem((IEnumerable<땃.딷>) this.StoreItems);
        if (!nullable.HasValue)
          nullable = this.SearchStoreListsForItem((IEnumerable<땃.딷>) GlobalAppData.땋().땃());
        this.딟 = (string) null;
      }
      this.SetState(this.땄);
      this.CloseLoadingOverlay();
      if (nullable.HasValue)
      {
        this.OnStoreItemSelected(nullable.Value);
        this.BackButton.Command = "Back";
      }
      this.딟 = false;
    }
    if (!this.땄 || !this.딟.All<StoreScreenHandler.땲>((Func<StoreScreenHandler.땲, bool>) (obj0 => obj0.딟.땄())))
      return;
    if (this.딟.All<StoreScreenHandler.땲>((Func<StoreScreenHandler.땲, bool>) (obj0 => obj0.딟.딧())))
    {
      // ISSUE: object of a compiler-generated type is created
      IEnumerable<딝.땝<땃.딷, int>> source = this.딟.Where<StoreScreenHandler.땲>((Func<StoreScreenHandler.땲, bool>) (obj0 => !(obj0.딟.딟.땃() as 땓.딞).땥())).Select<StoreScreenHandler.땲, 딝.땝<땃.딷, int>>((Func<StoreScreenHandler.땲, 딝.땝<땃.딷, int>>) (obj0 => new 딝.땝<땃.딷, int>(new 땃.딷(obj0.딟.딟), obj0.딟)));
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      foreach (딝.땝<땃.딷, int> 땝 in !this.딧 ? (IEnumerable<딝.땝<땃.딷, int>>) source.OrderBy<딝.땝<땃.딷, int>, int>((Func<딝.땝<땃.딷, int>, int>) (obj0 => obj0.딟().땠())) : (IEnumerable<딝.땝<땃.딷, int>>) source.OrderBy<딝.땝<땃.딷, int>, int>((Func<딝.땝<땃.딷, int>, int>) (obj0 => obj0.딟().때())))
      {
        // ISSUE: reference to a compiler-generated method
        if (!땝.딟().땋())
        {
          StoreItemButton storeItemButton = Object.Instantiate((Object) this.ItemButtonPrefab) as StoreItemButton;
          // ISSUE: reference to a compiler-generated method
          // ISSUE: reference to a compiler-generated method
          storeItemButton.Init(this, 땝.딟(), true, true, 땝.땄());
          this.MainScrollList.AddItemNoUpdate(((Component) storeItemButton).transform, (float) ((double) storeItemButton.Spacing * 0.5 / 320.0));
        }
      }
      this.MainScrollList.AddItem(Object.Instantiate((Object) this.ScrollListBuffer) as Transform, 0.125f);
      this.MainScrollList.ForceItemsUpdate();
    }
    this.CloseLoadingOverlay();
    this.딟.Clear();
    this.땄 = false;
  }

  private StoreItemButton.떎? SearchStoreListsForItem(IEnumerable<땃.딷> StoreItemList)
  {
    if (StoreItemList == null)
      return new StoreItemButton.떎?();
    foreach (땃.딷 storeItem in StoreItemList)
    {
      if (storeItem.땃().땄() == this.딟)
      {
        if (storeItem.딷())
          this.땄 = 땃.땽.떂;
        else if (storeItem.땽())
          this.땄 = 땃.땽.딝;
        else if (storeItem.떏())
          this.땄 = 땃.땽.땓;
        else if (storeItem.땤())
          this.땄 = 땃.땽.땺;
        else if (storeItem.땲())
          this.땄 = 땃.땽.땥;
        return new StoreItemButton.떎?(new StoreItemButton.떎()
        {
          땄 = true,
          딟 = false,
          딟 = 0,
          딟 = storeItem
        });
      }
    }
    return new StoreItemButton.떎?();
  }

  public static int 딟([In] 땃.딷 obj0, [In] 땃.딷 obj1) => Comparer<int>.Default.Compare(obj0.때(), obj1.때());

  [SpecialName]
  public bool get_InCategoryState()
  {
    switch (this.딟)
    {
      case 땃.땽.딧:
      case 땃.땽.땓:
      case 땃.땽.땺:
      case 땃.땽.땥:
      case 땃.땽.딝:
      case 땃.땽.떎:
      case 땃.땽.떂:
        return true;
      default:
        return false;
    }
  }

  [SpecialName]
  public bool get_InTagState() => this.딟 == 땃.땽.딢;

  private void OnDestroy()
  {
    if (this.get_ImageCache() != null)
    {
      this.get_ImageCache().Dispose();
      // ISSUE: reference to a compiler-generated method
      this.set_ImageCache((딟.땫) null);
    }
    this.딟.딟();
    this.땄.딟();
    GlobalAppData.땄(this.딟);
  }

  [CompilerGenerated]
  [SpecialName]
  public bool[] get_OwnedClasses() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public 딟.땫 get_ImageCache() => this.딟;

  private class 땲
  {
    public 땄.땐 딟;
    public int 딟;
  }

  public enum 떏
  {
    딟,
    땄,
    딧,
    딢,
  }
}
