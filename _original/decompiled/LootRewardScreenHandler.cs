// Decompiled with JetBrains decompiler
// Type: LootRewardScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LootRewardScreenHandler : BaseMenuHandler
{
  public GuiText3D numKeysText;
  public GameObject tapToOpen;
  public StorePurchaseWarbuxConfirmationPanelHandle purchasePanelPrefab;
  public ParticleSystem openCrateBurst;
  public Material iconMaterial;
  public ErrorMessagehandler errorMessage;
  public Transform lootBox;
  public Transform previewLootBox;
  public PurchaseSuccessfulPanelHandler purchaseSuccessPanelPrefab;
  public ToolTipHandler lootRewardSkipTooltip;
  public GuiButton3D nextButton;
  public Animation keyAnim;
  public LocalisationEntry characterLoc;
  public LocalisationEntry outfitLoc;
  private Animation 딟;
  private 땃.딦 딟;
  private 땃.딦 땄;
  private List<땃.딦> 딟;
  private 땃.딷 딟;
  private 딟.딬 딟;
  private int 딟;
  private bool 딟;
  private 딶.떈 딟;
  private PurchaseSuccessfulPanelHandler 딟;
  private Material 딟;
  private int 땄;
  private List<땃.딷> 딟;
  private List<int> 딟;
  private int 딧;

  private void Awake() => base.딟 = ((Component) this).transform.position;

  public override void ActivateMenu()
  {
    base.ActivateMenu();
    this.딟 = new 딶.떈((int) Time.realtimeSinceStartup);
    딟.딦.딟("LootCrate_RewardScreen");
    ((Component) FrontendHub.딟.MoneyDisplay).gameObject.SetActive(false);
    this.tapToOpen.gameObject.SetActive(true);
    ((Component) this.nextButton).gameObject.SetActive(false);
    ((Component) this.previewLootBox).gameObject.SetActive(true);
    this.딟 = ((Component) this.lootBox).GetComponentsInChildren<Animation>(true)[0];
    ((Component) this.lootBox).gameObject.SetActive(false);
    this.딟 = new Material(this.iconMaterial);
    this.UpdateKeyAmount();
    this.땄 = 0;
    this.딟 = (List<땃.딦>) null;
    this.딟 = new List<땃.딷>();
    this.딟 = new List<int>();
    GlobalAppData.땋().딟();
  }

  private void UpdateKeyAmount()
  {
    this.딟 = GlobalAppData.떏().딦().딟(GlobalAppData.딧().GameSettings.CurrencyKeysId);
    this.numKeysText.Text = this.딟.ToString();
    this.numKeysText.UpdateMesh();
  }

  public override void DeactivateMenu()
  {
    base.DeactivateMenu();
    ((Component) FrontendHub.딟.MoneyDisplay).gameObject.SetActive(true);
    this.딟 = (땃.딦) null;
    this.땄 = (땃.딦) null;
    this.딟 = (List<땃.딦>) null;
    ((Component) this.lootBox).gameObject.SetActive(false);
    ((Component) this.previewLootBox).gameObject.SetActive(false);
  }

  private void Update()
  {
    if (Object.op_Inequality((Object) BaseMenuHandler.딟, (Object) this))
      return;
    if (this.딟 != null)
      this.딟.땄();
    if (this.땄 != null)
      this.땄.땄();
    if (this.딟 != null)
    {
      foreach (땃.딦 딦 in this.딟)
        딦.땄();
    }
    if (this.딟 != null && this.딟.땄())
    {
      if (this.딟.딧())
      {
        if (this.딟 != GlobalAppData.떏().딦().딟(GlobalAppData.딧().GameSettings.CurrencyKeysId))
          this.keyAnim.Play();
        this.UpdateKeyAmount();
      }
      this.딟 = (딟.딬) null;
    }
    if (!this.get_AllItemsFound())
      return;
    this.StartImageDownload(this.FindMainItem());
    this.땄 = 0;
  }

  private void OnButtonPressed(string Command)
  {
    if (this.딟 != null || this.땄 != null || this.딟 != null)
      return;
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (LootRewardScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      LootRewardScreenHandler.딟 = new Dictionary<string, int>(3)
      {
        {
          "Skip",
          0
        },
        {
          "Open",
          1
        },
        {
          "AddKeys",
          2
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!LootRewardScreenHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        if (GlobalAppData.땽().땄(딢.딮.땿))
        {
          딟.딦.딟("LootCrate_DiscardedCrate");
          this.Continue();
          break;
        }
        this.lootRewardSkipTooltip.Display();
        break;
      case 1:
        if (this.딟)
        {
          this.Continue();
          break;
        }
        if (this.딟 > 0)
        {
          this.CreateLootPurchaseFlow();
          break;
        }
        this.CreateKeyPurchaseFlow();
        break;
      case 2:
        this.CreateKeyPurchaseFlow();
        break;
    }
  }

  private void CreateKeyPurchaseFlow()
  {
    딟.딦.딟("LootCrate_StartKeyPurchase");
    this.땄 = new 땃.딦(GlobalAppData.딧().GameSettings.KeyBundleProductId);
    this.땄.딟(new Action<땃.딷>(this.OnKeyItemFound));
    this.땄.딧(new Action<딟.땑, ErrorMessagehandler.땶>(this.OnKeyItemFindError));
    this.땄.딟(new Action<딟.땑, ErrorMessagehandler.땶>(this.OnKeyItemPurchaseError));
  }

  private void CreateLootPurchaseFlow()
  {
    this.딟 = new 땃.딦(GlobalAppData.딧().GameSettings.ChromeBlindBoxProductId);
    this.딟.딟(new Action<PurchaseResult>(this.OnBlindBoxPurchased));
    this.딟.딟(new Action<딟.땑, ErrorMessagehandler.땶>(this.OnBlindBoxPurchaseError));
    this.딟.딟(new Action<땃.딷>(this.OnBlindBoxFound));
    this.딟.딧(new Action<딟.땑, ErrorMessagehandler.땶>(this.OnBlindBoxFindError));
    ((Component) this.lootBox).gameObject.SetActive(true);
    ((Component) this.previewLootBox).gameObject.SetActive(false);
    this.딟.wrapMode = (WrapMode) 2;
    this.딟.Play("Shake");
  }

  private void Continue()
  {
    this.DeactivateMenu();
    FrontendHub.딟.BarracksScreen.ActivateMenu(딶.땂.딟, GlobalAppData.딟.땃(), 딢.딩.딢, true);
  }

  private void OnBlindBoxPurchased(PurchaseResult result)
  {
    this.딟.wrapMode = (WrapMode) 1;
    this.딟.Play("Death");
    this.tapToOpen.SetActive(false);
    ((Component) this.nextButton).gameObject.SetActive(true);
    this.딟 = new List<땃.딦>();
    this.땄 = result.Items.Count;
    foreach (KeyValuePair<string, int> keyValuePair in result.Items)
    {
      땃.딦 딦 = new 땃.딦(keyValuePair.Key);
      딦.딟(new Action<땃.딷>(this.OnLootItemFound));
      딦.딧(new Action<딟.땑, ErrorMessagehandler.땶>(this.OnLootItemFindError));
      this.딟.Add(딦);
      this.딟.Add(keyValuePair.Value);
    }
    this.딟 = (땃.딦) null;
    this.StartInventoryRequest();
  }

  private void OnBlindBoxPurchaseError(딟.땑 ErrorCode, ErrorMessagehandler.땶 ErrorType)
  {
    this.딟 = (땃.딦) null;
    this.DisplayErrorMessage(ErrorCode, ErrorType);
  }

  private void OnBlindBoxFound(땃.딷 item) => this.딟.딟(item.땺());

  private void OnBlindBoxFindError(딟.땑 ErrorCode, ErrorMessagehandler.땶 ErrorType)
  {
    this.딟 = (땃.딦) null;
    this.DisplayErrorMessage(ErrorCode, ErrorType);
  }

  private void OnKeyItemFound(땃.딷 item)
  {
    StorePurchaseWarbuxConfirmationPanelHandle confirmationPanelHandle = Object.Instantiate((Object) this.purchasePanelPrefab) as StorePurchaseWarbuxConfirmationPanelHandle;
    confirmationPanelHandle.SetOnClosedCallback(new Action(this.KeyPurchaseCancelled));
    confirmationPanelHandle.SetOnSuccessCallback(new Action(this.OnKeysPurchased));
    confirmationPanelHandle.Init(FrontendHub.딟.StoreScreen.get_ImageCache(), item);
  }

  private void OnKeyItemFindError(딟.땑 ErrorCode, ErrorMessagehandler.땶 ErrorType)
  {
    this.땄 = (땃.딦) null;
    this.DisplayErrorMessage(ErrorCode, ErrorType);
  }

  private void OnKeysPurchased()
  {
    딟.딦.딟("LootCrate_KeyPurchaseComplete");
    this.땄 = (땃.딦) null;
    this.StartInventoryRequest();
  }

  private void KeyPurchaseCancelled()
  {
    딟.딦.딟("LootCrate_KeyPurchaseCancelled");
    this.땄 = (땃.딦) null;
  }

  private void OnKeyItemPurchaseError(딟.땑 ErrorCode, ErrorMessagehandler.땶 ErrorType)
  {
    딟.딦.딟("LootCrate_KeyPurchaseError");
    this.땄 = (땃.딦) null;
  }

  private void OnLootItemFound(땃.딷 storeItem) => this.딟.Add(storeItem);

  private 땃.딷 FindMainItem()
  {
    땃.딷 딷 = this.딟[0];
    for (int index = 0; index < this.딟.Count; ++index)
    {
      if (this.딟[index].떏())
      {
        this.딧 = index;
        딷 = this.딟[index];
      }
    }
    return 딷;
  }

  private void StartImageDownload(땃.딷 storeItem)
  {
    딟.딦.딟("LootCrate_PurchasedCrate");
    딟.딦.딟("LootCrate_PurchasedCrateContents", new Dictionary<string, string>()
    {
      {
        "main_item",
        storeItem.딧()
      }
    });
    땓.딞 딞 = storeItem.땃().땃() as 땓.딞;
    FrontendHub.딟.StoreScreen.get_ImageCache().딟(딞.땤().딟(), new Action(this.OnImageDownloadFailure), new Action<Texture2D>(this.OnImageDownloadSuccess));
    this.딟 = storeItem;
    this.딟 = (List<땃.딦>) null;
    this.딟 = true;
  }

  private void OnLootItemFindError(딟.땑 ErrorCode, ErrorMessagehandler.땶 ErrorType)
  {
    this.딟 = (List<땃.딦>) null;
    this.DisplayErrorMessage(ErrorCode, ErrorType);
  }

  private void OnImageDownloadFailure() => this.DisplayErrorMessage(딟.땑.딟, ErrorMessagehandler.땶.딟);

  private void OnImageDownloadSuccess(Texture2D image)
  {
    this.딟.Play("Death");
    this.딟.mainTexture = (Texture) image;
    this.딟 = Object.Instantiate((Object) this.purchaseSuccessPanelPrefab) as PurchaseSuccessfulPanelHandler;
    this.딟.Init(this.딟, this.딟, (딟.땫) null, this.GetItemTypeName(this.딟));
    this.딟.set_OnClosedCallback(new Action(this.Continue));
  }

  private void StartInventoryRequest()
  {
    if (!GlobalAppData.떏().땥())
      return;
    this.딟 = GlobalAppData.떏().땟();
  }

  private void DisplayErrorMessage(딟.땑 ErrorCode, ErrorMessagehandler.땶 ErrorType) => (Object.Instantiate((Object) this.errorMessage) as ErrorMessagehandler).Init(ErrorType, ErrorCode);

  private string GetItemTypeName(땃.딷 item)
  {
    if (item.떏())
      return 딧.딪.딟(this.characterLoc);
    if (item.땲())
      return 딧.딪.딟(this.outfitLoc);
    return item.땋() ? string.Format("x{0}", (object) this.딟[this.딧]) : string.Empty;
  }

  [SpecialName]
  private bool get_AllItemsFound() => this.땄 > 0 && this.딟.Count == this.땄;
}
