// Decompiled with JetBrains decompiler
// Type: UnitInfoListAbility
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class UnitInfoListAbility : MonoBehaviour
{
  public GuiText3D UnitAbilityStat1Text;
  public GameObject UnitAbilityStat1Icon;
  public GuiText3D UnitAbilityStat2Text;
  public GameObject UnitAbilityStat2Icon;
  public GuiText3D UnitAbilityStat3Text;
  public GameObject UnitAbilityStat3Icon;
  public Material UnitAbilityStatIconDamage;
  public Material UnitAbilityStatIconBlastDamage;
  public Material UnitAbilityStatIconAPUse;
  public GuiText3D UnitAbilityNameText;
  public GameObject UnitAbilityThumb;
  public GameObject UnitAbilityThumbBackground;

  public void SetUnitAbility(AbilityInfo Ability, 딶.땖 State, int GameObjIdx, Material AbilityBGIcon)
  {
    if (Object.op_Inequality((Object) this.UnitAbilityNameText, (Object) null))
    {
      this.UnitAbilityNameText.LocText = Ability.Title;
      this.UnitAbilityNameText.UpdateMesh();
    }
    if (Object.op_Inequality((Object) this.UnitAbilityThumb, (Object) null))
      this.UnitAbilityThumb.renderer.sharedMaterial = Ability.Icon;
    if (Object.op_Inequality((Object) this.UnitAbilityThumbBackground, (Object) null))
      this.UnitAbilityThumbBackground.renderer.sharedMaterial = AbilityBGIcon;
    if (땓.땎.땺(Ability.Ability))
    {
      WeaponGameplayData weaponGameplayData = 땓.땎.딧(Ability.Ability, State.땻()[GameObjIdx]);
      this.UnitAbilityStat1Text.Text = weaponGameplayData.딟(State.땞(), State.떂().땺()[GameObjIdx]).ToString();
      this.UnitAbilityStat1Text.UpdateMesh();
      this.UnitAbilityStat1Icon.renderer.material = this.UnitAbilityStatIconDamage;
      this.UnitAbilityStat2Text.Text = weaponGameplayData.DamageSpread.ToString();
      this.UnitAbilityStat2Text.UpdateMesh();
      this.UnitAbilityStat2Icon.renderer.material = this.UnitAbilityStatIconBlastDamage;
      int num = 땓.땎.딟(State, GameObjIdx, Ability.Ability);
      if (num >= 0)
      {
        this.UnitAbilityStat3Text.Text = num.ToString();
        this.UnitAbilityStat3Text.UpdateMesh();
        this.UnitAbilityStat3Icon.renderer.material = this.UnitAbilityStatIconAPUse;
      }
      else
      {
        ((Component) this.UnitAbilityStat3Text).gameObject.SetActive(false);
        this.UnitAbilityStat3Icon.SetActive(false);
      }
    }
    else
    {
      int num = 땓.땎.딟(State, GameObjIdx, Ability.Ability);
      if (num >= 0)
      {
        this.UnitAbilityStat1Text.Text = num.ToString();
        this.UnitAbilityStat1Text.UpdateMesh();
        this.UnitAbilityStat1Icon.renderer.material = this.UnitAbilityStatIconAPUse;
      }
      else
      {
        ((Component) this.UnitAbilityStat1Text).gameObject.SetActive(false);
        this.UnitAbilityStat1Icon.SetActive(false);
      }
      ((Component) this.UnitAbilityStat2Text).gameObject.SetActive(false);
      this.UnitAbilityStat2Icon.SetActive(false);
      ((Component) this.UnitAbilityStat3Text).gameObject.SetActive(false);
      this.UnitAbilityStat3Icon.SetActive(false);
    }
  }
}
