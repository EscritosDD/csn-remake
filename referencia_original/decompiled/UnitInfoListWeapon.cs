// Decompiled with JetBrains decompiler
// Type: UnitInfoListWeapon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class UnitInfoListWeapon : MonoBehaviour
{
  public GuiText3D UnitWeaponNameText;
  public GuiText3D UnitWeaponDamageText;
  public GuiText3D UnitWeaponAPText;
  public GuiText3D UnitWeaponRangeText;
  public GameObject UnitWeaponThumb;
  public GuiButton3D BuyUnitWeaponButton;

  public void SetUnitWeapon(
    Material WeaponIcon,
    LocalisationEntry WeaponName,
    string WeaponAPCost,
    string WeaponRange,
    string WeaponDamage)
  {
    if (Object.op_Inequality((Object) this.UnitWeaponNameText, (Object) null))
    {
      this.UnitWeaponNameText.LocText = WeaponName;
      this.UnitWeaponNameText.UpdateMesh();
    }
    if (Object.op_Inequality((Object) this.UnitWeaponDamageText, (Object) null))
    {
      this.UnitWeaponDamageText.Text = WeaponDamage;
      this.UnitWeaponDamageText.UpdateMesh();
    }
    if (Object.op_Inequality((Object) this.UnitWeaponAPText, (Object) null))
    {
      this.UnitWeaponAPText.Text = WeaponAPCost;
      this.UnitWeaponAPText.UpdateMesh();
    }
    if (Object.op_Inequality((Object) this.UnitWeaponRangeText, (Object) null))
    {
      this.UnitWeaponRangeText.Text = WeaponRange;
      this.UnitWeaponRangeText.UpdateMesh();
    }
    if (!Object.op_Inequality((Object) this.UnitWeaponThumb, (Object) null))
      return;
    this.UnitWeaponThumb.renderer.sharedMaterial = WeaponIcon;
  }
}
