// Decompiled with JetBrains decompiler
// Type: UnitAbilityButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;
using 딧;

public class UnitAbilityButton : MonoBehaviour
{
  private 딼 딟 = new 딼();
  public GuiButton3D Button;
  public GameObject Icon;
  public bool IsActiveAbility;

  public void Init(PlayerAbilityEntry PlayerAbility) => this.Init(PlayerAbility, (Shader) null);

  public void Init(PlayerAbilityEntry PlayerAbility, Shader ShaderOverride)
  {
    if (PlayerAbility == null)
    {
      this.Disable();
    }
    else
    {
      ((Component) this).gameObject.SetActive(true);
      if (Object.op_Inequality((Object) this.Button, (Object) null))
      {
        if (this.IsActiveAbility)
          this.Button.set_CustomPressFunc("OnActiveAbilitySelected");
        else
          this.Button.set_CustomPressFunc("OnAbilitySelected");
        this.Button.set_CustomPressValue((object) PlayerAbility.AbilityInfo.Ability);
      }
      if (!Object.op_Inequality((Object) this.Icon, (Object) null))
        return;
      if (Object.op_Inequality((Object) ShaderOverride, (Object) null))
      {
        this.딟.딟(this.Icon, PlayerAbility.AbilityInfo.Icon);
        this.딟.딟(this.Icon, ShaderOverride);
      }
      else
        this.딟.딟(this.Icon, PlayerAbility.AbilityInfo.Icon);
    }
  }

  public void Init(AbilityInfo CharacterAbility)
  {
    if (CharacterAbility == null)
    {
      this.Disable();
    }
    else
    {
      ((Component) this).gameObject.SetActive(true);
      if (Object.op_Inequality((Object) this.Button, (Object) null))
      {
        this.Button.set_CustomPressFunc("OnCharacterAbilitySelected");
        this.Button.set_CustomPressValue((object) CharacterAbility.Ability);
      }
      if (!Object.op_Inequality((Object) this.Icon, (Object) null))
        return;
      this.Icon.renderer.material = CharacterAbility.Icon;
    }
  }

  public void Disable() => ((Component) this).gameObject.SetActive(false);

  private void OnDestroy()
  {
    this.딟.딟();
    GlobalAppData.땄(this.Icon);
  }
}
