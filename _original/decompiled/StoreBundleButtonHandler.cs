// Decompiled with JetBrains decompiler
// Type: StoreBundleButtonHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StoreBundleButtonHandler : MonoBehaviour
{
  private 딧.딼 딟 = new 딧.딼();
  public float Spacing;
  public GuiMultiLineText3D ItemNameText;
  public GuiText3D ItemSubText;
  public GameObject ItemIcon;
  public GuiButton3D Button;
  public GameObject CoinsIcon;
  public GuiText3D CoinsCostText;
  public Shader ClippedShader;
  public Material IconMaterialBase;
  public GameObject LoadingOverlay;
  public GuiText3D RealWorldCurrencyValue;

  public void Init(StoreScreenHandler StoreScreen, 땃.딷 Item)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    StoreBundleButtonHandler.땺 땺 = new StoreBundleButtonHandler.땺();
    // ISSUE: reference to a compiler-generated field
    땺.딟 = StoreScreen;
    // ISSUE: reference to a compiler-generated method
    this.set_Item(Item);
    땓.딞 딞 = Item.땃().땃() as 땓.딞;
    땓.딠 딠 = Item.땃().딢() as 땓.딠;
    if (Item.딷())
    {
      this.ItemSubText.Text = 딠.딟();
      this.ItemSubText.UpdateMesh();
      if (Item.딶() != null)
        this.Button.set_CustomPressFunc("OnBundleSelected");
      else if (Item.땥() != null)
        this.Button.set_CustomPressFunc("OnWarbuxItemSelected");
    }
    else
      this.Button.set_CustomPressFunc("OnBundleSelected");
    this.Button.set_CustomPressValue((object) Item);
    this.ItemNameText.Text = Item.딢();
    this.ItemNameText.UpdateMesh();
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated method
    this.ItemIcon.AddComponent<StoreIconLoader>().Init(this.IconMaterialBase, this.LoadingOverlay, 땺.딟.get_ImageCache(), 딞.땤().딟(), new Action(땺.딟), (Action) null);
    this.CoinsIcon.renderer.sharedMaterial = GlobalAppData.땲().딟(this.CoinsIcon.renderer.material, this.ClippedShader);
    OfferData offerData = Item.딶();
    if (offerData != null)
    {
      this.CoinsCostText.Text = offerData.딢().ToString();
    }
    else
    {
      ((Component) this.CoinsCostText).gameObject.SetActive(false);
      this.CoinsIcon.SetActive(false);
    }
    // ISSUE: reference to a compiler-generated method
    ApplePriceDisplay.딟(Item, ((Component) this).gameObject, this.RealWorldCurrencyValue, (GuiText3D) null, (GameObject) null, new Action(땺.땄));
    if (Item.땥() != null)
    {
      ((Component) this.CoinsCostText).gameObject.SetActive(false);
      this.CoinsIcon.gameObject.SetActive(false);
    }
    this.CoinsCostText.UpdateMesh();
  }

  private void OnDestroy()
  {
    GlobalAppData.땄(this.CoinsIcon);
    this.딟.딟();
  }

  [CompilerGenerated]
  [SpecialName]
  public 땃.딷 get_Item() => this.딟;
}
