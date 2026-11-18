// Decompiled with JetBrains decompiler
// Type: TutorialCommanderSelectionButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;
using 땓;

public class TutorialCommanderSelectionButton : MonoBehaviour
{
  private Material 딟;
  private Material 땄;
  public GameObject UnitIcon;
  public GameObject BorderIcon;
  public GuiButton3D Button;
  public Vector3 SelectedScale = Vector3.one;
  public Vector3 NormalScale = Vector3.one;
  public Color SelectedColor = Color.white;
  public Color NormalColor = Color.white;

  public void Init(떀 Character, int Index)
  {
    this.딟 = this.UnitIcon.renderer.material;
    this.딟.mainTexture = Character.땁().CharacterIcon.mainTexture;
    this.땄 = this.BorderIcon.renderer.material;
    this.Button.set_CustomPressFunc("OnCharacterSelected");
    this.Button.set_CustomPressValue((object) Index);
  }

  public void UpdateState(bool Active)
  {
    ((Component) this).transform.localScale = !Active ? this.NormalScale : this.SelectedScale;
    this.Button.Disabled = Active;
    if (Active)
    {
      this.딟.color = this.SelectedColor;
      this.땄.color = this.SelectedColor;
    }
    else
    {
      this.딟.color = this.NormalColor;
      this.땄.color = this.NormalColor;
    }
  }
}
