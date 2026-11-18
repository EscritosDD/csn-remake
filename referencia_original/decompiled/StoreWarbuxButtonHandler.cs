// Decompiled with JetBrains decompiler
// Type: StoreWarbuxButtonHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using UnityEngine;

public class StoreWarbuxButtonHandler : MonoBehaviour
{
  public float Spacing;
  public GuiText3D ItemNameText;
  public GuiText3D SubText;
  public GuiButton3D Button;
  public GameObject ItemIcon;
  public GameObject LoadingOverlay;
  public Material IconMaterialBase;
  public GuiText3D RealWorldCurrencyValue;
  public GuiText3D RealWorldMoneyTax;
  public Shader ClippedShader;
  public GameObject LoadingSpinner;
  public GameObject LoadingSpinnerBackground;

  public void Init(StoreScreenHandler StoreScreen, 땃.딷 Item)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    StoreWarbuxButtonHandler.땟 땟 = new StoreWarbuxButtonHandler.땟();
    // ISSUE: reference to a compiler-generated field
    땟.딟 = StoreScreen;
    // ISSUE: reference to a compiler-generated field
    땟.딟 = this;
    땓.딞 딞 = Item.땃().땃() as 땓.딞;
    땓.딠 딠 = Item.땃().딢() as 땓.딠;
    this.LoadingSpinner.renderer.sharedMaterial = GlobalAppData.땲().딟(this.LoadingSpinner.renderer.material, this.ClippedShader);
    this.LoadingSpinnerBackground.renderer.sharedMaterial = GlobalAppData.땲().딟(this.LoadingSpinnerBackground.renderer.material, this.ClippedShader);
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated method
    this.ItemIcon.AddComponent<StoreIconLoader>().Init(this.IconMaterialBase, this.LoadingOverlay, 땟.딟.get_ImageCache(), 딞.딦().딟(), new Action(땟.딟), (Action) null);
    this.Button.set_CustomPressFunc("OnWarbuxItemSelected");
    this.Button.set_CustomPressValue((object) Item);
    this.ItemNameText.Text = 딠.땄();
    this.ItemNameText.UpdateMesh();
    this.SubText.Text = 딠.땃();
    this.SubText.UpdateMesh();
    // ISSUE: reference to a compiler-generated method
    ApplePriceDisplay.딟(Item, ((Component) this).gameObject, this.RealWorldCurrencyValue, (GuiText3D) null, (GameObject) null, new Action(땟.땄));
  }
}
