// Decompiled with JetBrains decompiler
// Type: StoreItemButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StoreItemButton : MonoBehaviour
{
  private 딧.딼 딟 = new 딧.딼();
  private 딢.땿 딟 = new 딢.땿();
  private StoreItemButton.딝 딟;
  private float 딟;
  private bool 딟;
  private bool 땄;
  private Transform 딟;
  public Transform[] RequiredClassIcons = new Transform[5];
  private Material[] 딟;
  public GameObject[] CoinsItems;
  public float Spacing;
  public GuiText3D ItemNameText;
  public GuiText3D ItemSubText;
  public GuiButton3D Button;
  public GameObject CoinsIcon;
  public GameObject SaleCoinsIcon;
  public GameObject SaleIcon;
  public GameObject SaleIconYellow;
  public GuiText3D CoinsCostText;
  public GuiText3D RealWorldMoney;
  public GuiText3D DiscountText;
  public GuiText3D QuantityText;
  public GameObject ItemIcon;
  public GameObject LoadingOverlay;
  public GameObject LoadingOverlaySpinner;
  public Shader ClippingShader;
  public GameObject ButtonLeft;
  public GameObject ButtonRight;
  public GameObject ButtonMiddle;
  public Material ButtonLeftGrey;
  public Material ButtonRightGrey;
  public Material ButtonMiddleGrey;
  public AudioShader2 BundleButtonSound;
  public AnimationCurve TextFadeInCurve;
  public AnimationCurve TextFadeOutCurve;
  public float LerpTime;
  public float RedDiscountPercentage;
  public GameObject LevelInfo;
  public GuiText3D LevelNumber;
  public Transform CharacterClassIconPos;
  public float CharacterClassIconScale;
  public Transform BaseIconPos;
  public GameObject LockIcon;
  public GuiText3D ClassesRequiredText;
  public GuiText3D CharacterNameText;
  public GuiText3D ExpansionsSubText;
  public Material IconMaterialBase;
  public float IconOffset;
  public GuiText3D AlreadyOwnedText;
  public GameObject SquadPointStar;
  public GuiText3D SquadPointText;
  public GameObject NewBanner;

  public void Init(StoreScreenHandler StoreScreen, 땃.딷 Item, bool IsBundleItem)
  {
    // ISSUE: reference to a compiler-generated method
    this.set_CurrentURL((string) null);
    this.Init(StoreScreen, Item, IsBundleItem, true, 1);
  }

  public void Init(
    StoreScreenHandler StoreScreen,
    땃.딷 Item,
    bool IsBundleItem,
    bool IsActive,
    int Quantity)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    StoreItemButton.떂 떂 = new StoreItemButton.떂();
    // ISSUE: reference to a compiler-generated field
    떂.딟 = StoreScreen;
    땓.딞 딞 = Item.땃().땃() as 땓.딞;
    땓.딠 딠 = Item.땃().딢() as 땓.딠;
    this.SquadPointStar.SetActive(false);
    ((Component) this.AlreadyOwnedText).gameObject.SetActive(false);
    StoreItemButton.떎 ButtonItemInfo = new StoreItemButton.떎();
    ButtonItemInfo.딟 = Item;
    ButtonItemInfo.땄 = true;
    ButtonItemInfo.딟 = this;
    // ISSUE: reference to a compiler-generated method
    this.set_CurrentURL(딞.딦().딟());
    this.딟.딟(this.CoinsIcon, this.ClippingShader);
    if (Object.op_Inequality((Object) this.SaleCoinsIcon, (Object) null))
      this.딟.딟(this.SaleCoinsIcon, this.ClippingShader);
    if (Object.op_Inequality((Object) this.SaleIcon, (Object) null))
      this.딟.딟(this.SaleIcon, this.ClippingShader);
    if (Object.op_Inequality((Object) this.SaleIconYellow, (Object) null))
      this.딟.딟(this.SaleIconYellow, this.ClippingShader);
    this.딟.딟(this.LoadingOverlaySpinner, this.ClippingShader);
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated method
    this.ItemIcon.AddComponent<StoreIconLoader>().Init(this.IconMaterialBase, this.LoadingOverlay, 떂.딟.get_ImageCache(), this.get_CurrentURL(), new Action(떂.딟), (Action) null);
    if (Object.op_Inequality((Object) this.QuantityText, (Object) null) && Quantity > 1)
    {
      this.QuantityText.Text = string.Format("x{0}", (object) Quantity);
      this.QuantityText.UpdateMesh();
    }
    if (!IsActive)
    {
      this.DisableButton(true);
      ButtonItemInfo.땄 = false;
    }
    this.LevelInfo.SetActive(false);
    this.LockIcon.SetActive(false);
    ((Component) this.ClassesRequiredText).gameObject.SetActive(false);
    ((Component) this.CharacterNameText).gameObject.SetActive(false);
    if (Item.땃().땃() != null)
    {
      ButtonItemInfo.딟 = 딞.딶() + 1;
      int PlayerLvl = GlobalAppData.땽().때();
      // ISSUE: reference to a compiler-generated field
      this.SetButtonLocked(떂.딟, ref ButtonItemInfo, PlayerLvl, IsBundleItem, Item);
    }
    if (Item.떏())
    {
      string str = 딠.땺();
      if (str != null)
      {
        this.ItemSubText.Text = "+ " + str;
        this.ItemSubText.UpdateMesh();
      }
      if (!string.IsNullOrEmpty(딞.땃()))
      {
        this.딟 = Object.Instantiate((Object) StorePanel_WeaponStats.딟(딞.땃()).Icon) as Transform;
        this.딟.parent = ((Component) this).transform;
        this.딟.localScale = new Vector3(this.CharacterClassIconScale, this.CharacterClassIconScale, this.CharacterClassIconScale);
        this.딟.localPosition = this.CharacterClassIconPos.localPosition;
        ((Component) this.딟).gameObject.SetActive(true);
      }
    }
    if (IsBundleItem)
    {
      ButtonItemInfo.딟 = true;
      if (Item.땼())
        this.DisableButton(true);
    }
    else
      ButtonItemInfo.딟 = false;
    if (Item.땽())
    {
      this.Button.SwishAudio = (AudioShader2) null;
      this.Button.PlayAudio = this.BundleButtonSound;
    }
    this.Button.set_CustomPressFunc("OnStoreItemSelected");
    this.Button.set_CustomPressValue((object) ButtonItemInfo);
    this.ItemNameText.Text = Item.딢();
    this.ItemNameText.UpdateMesh();
    this.딟 = StoreItemButton.딝.딟;
    this.딟 = false;
    this.땄 = false;
    if (딞.딝())
      this.NewBanner.SetActive(true);
    else
      this.NewBanner.SetActive(false);
    if (!IsBundleItem)
    {
      bool flag = false;
      this.땄 = Item.땩();
      OfferData offerData = Item.딶();
      if (offerData != null)
      {
        this.딟 = true;
        flag = true;
        this.CoinsCostText.Text = offerData.딢().ToString();
      }
      else
        this.SetCoinsOfferActive(false);
      // ISSUE: reference to a compiler-generated method
      ApplePriceDisplay.딟(Item, ((Component) this).gameObject, this.RealWorldMoney, (GuiText3D) null, (GameObject) null, new Action(떂.땄));
      if (flag && this.땄 && Object.op_Inequality((Object) this.DiscountText, (Object) null))
        this.DiscountText.Text = this.CalculateDiscount(Item);
      if (Object.op_Inequality((Object) this.DiscountText, (Object) null))
        this.DiscountText.UpdateMesh();
      this.CoinsCostText.UpdateMesh();
    }
    else
    {
      this.CoinsIcon.SetActive(false);
      ((Component) this.ItemSubText).gameObject.SetActive(false);
    }
    if (Item.땟())
    {
      this.SquadPointStar.SetActive(true);
      this.SquadPointText.Text = 딞.떎();
      this.SquadPointText.UpdateMesh();
    }
    if (Item.딷())
    {
      this.Button.SwishAudio = (AudioShader2) null;
      this.Button.PlayAudio = this.BundleButtonSound;
      this.ExpansionsSubText.Text = 딠.딟();
      ((Component) this.ExpansionsSubText).gameObject.SetActive(true);
      this.ExpansionsSubText.UpdateMesh();
    }
    if (Item.땟() || Item.떁())
    {
      this.Button.SwishAudio = (AudioShader2) null;
      this.ExpansionsSubText.Text = 딠.딟();
      ((Component) this.ExpansionsSubText).gameObject.SetActive(true);
      this.ExpansionsSubText.UpdateMesh();
    }
    this.InitFadeableObjects();
  }

  private void SetButtonLocked(
    StoreScreenHandler StoreScreen,
    ref StoreItemButton.떎 ButtonItemInfo,
    int PlayerLvl,
    bool IsBundleItem,
    땃.딷 Item)
  {
    if (IsBundleItem)
      return;
    땓.딠 딠 = Item.땃().딢() as 땓.딠;
    if (Item.땤())
    {
      bool flag1 = false;
      if (ButtonItemInfo.딟 > PlayerLvl)
      {
        flag1 = true;
        ButtonItemInfo.딧 = true;
        this.LevelInfo.SetActive(true);
        this.LevelNumber.Text = ButtonItemInfo.딟.ToString();
        this.LevelNumber.UpdateMesh();
      }
      else
      {
        string[] strArray = 딠.땓();
        if (strArray != null)
        {
          bool flag2 = false;
          Transform[] transformArray = new Transform[5];
          for (int index = 0; index < strArray.Length; ++index)
          {
            ClassInfo classInfo = StorePanel_WeaponStats.딟(strArray[index]);
            if (StoreScreen.get_OwnedClasses()[(int) classInfo.ClassType])
            {
              flag2 = true;
              break;
            }
            transformArray[index] = classInfo.Icon;
          }
          if (!flag2)
          {
            Vector3 vector3;
            // ISSUE: explicit constructor call
            ((Vector3) ref vector3).\u002Ector(0.0f, 0.0f, 0.0f);
            for (int index = 0; index < transformArray.Length; ++index)
            {
              if (Object.op_Inequality((Object) transformArray[index], (Object) null))
              {
                this.RequiredClassIcons[index] = Object.Instantiate((Object) transformArray[index]) as Transform;
                this.RequiredClassIcons[index].parent = ((Component) this).transform;
                this.RequiredClassIcons[index].localPosition = Vector3.op_Addition(this.BaseIconPos.localPosition, vector3);
                ((Component) this.RequiredClassIcons[index]).gameObject.SetActive(true);
                // ISSUE: explicit constructor call
                ((Vector3) ref vector3).\u002Ector((float) vector3.x + this.IconOffset, 0.0f, 0.0f);
              }
            }
            ((Component) this.ClassesRequiredText).gameObject.SetActive(true);
            ButtonItemInfo.땃 = true;
            flag1 = true;
          }
        }
      }
      if (!flag1)
        return;
      this.DisableButton(false);
      this.LockIcon.SetActive(true);
      ButtonItemInfo.땄 = false;
    }
    else if (Item.땲())
    {
      bool flag = false;
      if (ButtonItemInfo.딟 > PlayerLvl)
      {
        ButtonItemInfo.딧 = true;
        flag = true;
      }
      else if (!Item.딟() && !string.IsNullOrEmpty(딠.딧()))
      {
        this.CharacterNameText.Text = 딠.딧();
        ((Component) this.CharacterNameText).gameObject.SetActive(true);
        this.CharacterNameText.UpdateMesh();
        ButtonItemInfo.딢 = true;
        ButtonItemInfo.딟 = this.CharacterNameText.Text;
        flag = true;
      }
      if (!flag)
        return;
      this.DisableButton(false);
      ButtonItemInfo.땄 = false;
      this.LockIcon.SetActive(true);
    }
    else if (!Item.떂())
    {
      this.DisableButton(true);
      ((Component) this.AlreadyOwnedText).gameObject.SetActive(true);
    }
    else
    {
      if (ButtonItemInfo.딟 <= PlayerLvl)
        return;
      this.DisableButton(false);
      ButtonItemInfo.땄 = false;
    }
  }

  private void InitFadeableObjects()
  {
    this.SetTextAlpha(true, !this.딟 ? 1f : 0.0f);
    float Val = !this.딟 ? 0.0f : 1f;
    this.딟 = new Material[this.CoinsItems.Length];
    for (int index = 0; index < this.CoinsItems.Length; ++index)
    {
      this.딟[index] = new Material(this.CoinsItems[index].renderer.sharedMaterial);
      this.딟[index].color = new Color((float) this.딟[index].color.r, (float) this.딟[index].color.g, (float) this.딟[index].color.b, Val);
      this.CoinsItems[index].renderer.sharedMaterial = this.딟[index];
    }
    this.SetTextAlpha(false, Val);
  }

  private void SetCoinsOfferActive(bool Active)
  {
    ((Component) this.CoinsCostText).gameObject.SetActive(Active);
    this.CoinsIcon.SetActive(Active);
    if (!Object.op_Inequality((Object) this.SaleCoinsIcon, (Object) null))
      return;
    this.SaleCoinsIcon.SetActive(Active);
  }

  private void DisableButton(bool IsDisabled)
  {
    GlobalAppData.땄(this.ButtonLeft);
    GlobalAppData.땄(this.ButtonMiddle);
    GlobalAppData.땄(this.ButtonRight);
    this.딟.딟(this.ButtonLeft, this.ButtonLeftGrey);
    this.딟.딟(this.ButtonMiddle, this.ButtonMiddleGrey);
    this.딟.딟(this.ButtonRight, this.ButtonRightGrey);
    this.Button.Disabled = IsDisabled;
  }

  private string CalculateDiscount(땃.딷 Item)
  {
    string str = "-";
    float num1 = 1f;
    float num2 = 1f;
    OfferData offerData = Item.땓();
    if (offerData != null)
    {
      num1 = (float) Item.땓().딟();
      num2 = (float) offerData.딧();
    }
    float num3 = (num1 - num2) / num1;
    return str + Mathf.RoundToInt(num3 * 100f).ToString() + "%";
  }

  private bool IsIconVisible()
  {
    foreach (Object @object in Object.FindObjectsOfType(typeof (StoreItemButton)))
    {
      StoreItemButton storeItemButton = @object as StoreItemButton;
      if (storeItemButton.get_CurrentURL() == this.get_CurrentURL() && (double) ((Component) storeItemButton).transform.position.z > -0.6 && (double) ((Component) storeItemButton).transform.position.z < 0.6)
        return true;
    }
    return false;
  }

  private void Update()
  {
    if (((Component) this.AlreadyOwnedText).gameObject.activeInHierarchy && ((Component) this.ExpansionsSubText).gameObject.activeInHierarchy)
      ((Component) this.ExpansionsSubText).gameObject.SetActive(false);
    this.UpdateFading();
  }

  private void UpdateFading()
  {
    if (!this.딟 || !this.땄)
      return;
    this.딟.딟();
    if (!this.딟.땄())
      return;
    this.딟 += Time.deltaTime / this.LerpTime;
    this.딟 = Mathf.Clamp01(this.딟);
    switch (this.딟)
    {
      case StoreItemButton.딝.딟:
        this.딟 = StoreItemButton.딝.딧;
        this.딟.딟(4f);
        break;
      case StoreItemButton.딝.땄:
        this.FadeTextAndIcons(false, this.TextFadeInCurve.Evaluate(this.딟));
        if ((double) this.딟 != 1.0)
          break;
        this.딟 = 0.0f;
        this.딟.딟(2f);
        this.딟 = StoreItemButton.딝.딧;
        break;
      case StoreItemButton.딝.딧:
        this.FadeTextAndIcons(false, this.TextFadeOutCurve.Evaluate(this.딟));
        if ((double) this.딟 != 1.0)
          break;
        this.딟 = 0.0f;
        this.딟.딟(0.1f);
        this.딟 = StoreItemButton.딝.딢;
        break;
      case StoreItemButton.딝.딢:
        this.FadeTextAndIcons(true, this.TextFadeInCurve.Evaluate(this.딟));
        if ((double) this.딟 != 1.0)
          break;
        this.딟 = 0.0f;
        this.딟.딟(2f);
        this.딟 = StoreItemButton.딝.땃;
        break;
      case StoreItemButton.딝.땃:
        this.FadeTextAndIcons(true, this.TextFadeOutCurve.Evaluate(this.딟));
        if ((double) this.딟 != 1.0)
          break;
        this.딟 = 0.0f;
        this.딟.딟(0.1f);
        this.딟 = StoreItemButton.딝.땄;
        break;
    }
  }

  private void FadeTextAndIcons(bool IsRadBux, float Val)
  {
    if (IsRadBux)
      return;
    for (int index = 0; index < this.CoinsItems.Length; ++index)
    {
      Material material = this.딟[index];
      material.color = new Color((float) material.color.r, (float) material.color.g, (float) material.color.b, Val);
      GameObject coinsItem = this.CoinsItems[index];
      if (Object.op_Inequality((Object) coinsItem, (Object) null) && Object.op_Inequality((Object) coinsItem.renderer, (Object) null))
        coinsItem.renderer.sharedMaterial.color = material.color;
    }
    this.SetTextAlpha(false, Val);
  }

  private void SetTextAlpha(bool IsRadBux, float Val)
  {
    if (IsRadBux)
      return;
    this.CoinsCostText.SetTextAlpha(Val);
  }

  private void OnDestroy()
  {
    this.딟.딟();
    for (int index = 0; index < this.딟.Length; ++index)
      GlobalAppData.딟(this.딟[index]);
  }

  [CompilerGenerated]
  [SpecialName]
  public string get_CurrentURL() => this.딟;

  public enum 딝
  {
    딟,
    땄,
    딧,
    딢,
    땃,
  }

  public struct 떎
  {
    public bool 딟;
    public bool 땄;
    public int 딟;
    public bool 딧;
    public bool 딢;
    public bool 땃;
    public 땃.딷 딟;
    public StoreItemButton 딟;
    public string 딟;
  }
}
