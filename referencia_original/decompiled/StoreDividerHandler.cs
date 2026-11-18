// Decompiled with JetBrains decompiler
// Type: StoreDividerHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class StoreDividerHandler : MonoBehaviour
{
  public GameObject Arrow;
  public GuiText3D DividerLine01Text;
  public GuiText3D DividerLine02Text;
  public float DividerSpacing;
  public LocalisationEntry Select_FeaturedItem;
  public LocalisationEntry Select_RadBuxQuantity;
  public LocalisationEntry Select_Character;
  public LocalisationEntry Select_Weapon;
  public LocalisationEntry Select_Outfit;
  public LocalisationEntry Select_Boost;
  public LocalisationEntry Select_Bundle;
  public LocalisationEntry Select_OfferWall;
  public LocalisationEntry Select_MapAndChallengePack;
  public LocalisationEntry FeaturedItem;
  public LocalisationEntry RadBuxQuantity;
  public LocalisationEntry Character;
  public LocalisationEntry Weapon;
  public LocalisationEntry Outfit;
  public LocalisationEntry Boost;
  public LocalisationEntry Bundle;
  public LocalisationEntry OfferWall;
  public LocalisationEntry MapAndChallengePack;

  public void Init(StoreDividerHandler.땥 DividerType)
  {
    switch (DividerType)
    {
      case StoreDividerHandler.땥.딟:
        this.DividerLine01Text.LocText = this.Select_FeaturedItem;
        this.DividerLine02Text.LocText = this.FeaturedItem;
        break;
      case StoreDividerHandler.땥.땄:
        this.DividerLine01Text.LocText = this.Select_RadBuxQuantity;
        this.DividerLine02Text.LocText = this.RadBuxQuantity;
        break;
      case StoreDividerHandler.땥.딧:
        this.DividerLine01Text.LocText = this.Select_Character;
        this.DividerLine02Text.LocText = this.Character;
        break;
      case StoreDividerHandler.땥.딢:
        this.DividerLine01Text.LocText = this.Select_Weapon;
        this.DividerLine02Text.LocText = this.Weapon;
        break;
      case StoreDividerHandler.땥.땃:
        this.DividerLine01Text.LocText = this.Select_Outfit;
        this.DividerLine02Text.LocText = this.Outfit;
        break;
      case StoreDividerHandler.땥.딶:
        this.DividerLine01Text.LocText = this.Select_Boost;
        this.DividerLine02Text.LocText = this.Boost;
        break;
      case StoreDividerHandler.땥.땓:
        this.DividerLine01Text.LocText = this.Select_Bundle;
        this.DividerLine02Text.LocText = this.Bundle;
        break;
      case StoreDividerHandler.땥.땺:
        this.DividerLine01Text.LocText = this.Select_OfferWall;
        this.DividerLine02Text.LocText = this.OfferWall;
        break;
      case StoreDividerHandler.땥.땥:
        this.DividerLine01Text.LocText = this.Select_MapAndChallengePack;
        this.DividerLine02Text.LocText = this.MapAndChallengePack;
        break;
    }
    this.DividerLine01Text.UpdateMesh();
    this.DividerLine02Text.UpdateMesh();
  }

  private void OnDestroy()
  {
    GlobalAppData.땄(this.Arrow);
    GlobalAppData.땄(((Component) this).gameObject);
  }

  public enum 땥
  {
    딟,
    땄,
    딧,
    딢,
    땃,
    딶,
    땓,
    땺,
    땥,
  }
}
