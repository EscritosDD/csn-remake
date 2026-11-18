// Decompiled with JetBrains decompiler
// Type: StorePanel_CharacterStats
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;
using 딧;

public class StorePanel_CharacterStats : MonoBehaviour
{
  private 딼 딟 = new 딼();
  public GuiText3D HealthText;
  public GuiText3D APText;
  public GuiText3D SPText;
  public GuiText3D WeaponsNameText;
  public GuiText3D Ability01NameText;
  public GuiText3D Ability02NameText;
  public GuiMultiLineText3D Ability01DescriptionText;
  public GuiMultiLineText3D Ability02DescriptionText;
  public GameObject HealthIcon;
  public GameObject APIcon;
  public Shader IconShader;
  public float Buffer = 0.02f;

  public void Init(
    string HealthText,
    string APText,
    string SPText,
    string Ability01Name,
    string Ability02Name,
    string Ability01Description,
    string Ability02Description,
    string WeaponName)
  {
    this.딟.딟(this.HealthIcon, this.IconShader);
    this.HealthText.Text = HealthText;
    this.APText.Text = APText;
    this.SPText.Text = SPText;
    this.Ability01NameText.Text = Ability01Name;
    this.Ability02NameText.Text = Ability02Name;
    this.Ability01DescriptionText.Text = Ability01Description;
    this.Ability02DescriptionText.Text = Ability02Description;
    this.WeaponsNameText.Text = WeaponName;
    float num = this.Ability01DescriptionText.MeasureHeight(this.Ability01DescriptionText.Text) + this.Buffer;
    Transform transform = ((Component) this.Ability02NameText).gameObject.transform;
    transform.localPosition = Vector3.op_Subtraction(transform.localPosition, new Vector3(0.0f, 0.0f, num));
    ((Component) this.Ability02DescriptionText).gameObject.transform.localPosition = Vector3.op_Subtraction(((Component) this.Ability02NameText).gameObject.transform.position, new Vector3(0.0f, 0.0f, 0.08f));
    this.HealthText.UpdateMesh();
    this.APText.UpdateMesh();
    this.SPText.UpdateMesh();
    this.Ability01NameText.UpdateMesh();
    this.Ability02NameText.UpdateMesh();
    this.Ability01DescriptionText.UpdateMesh();
    this.Ability02DescriptionText.UpdateMesh();
    this.WeaponsNameText.UpdateMesh();
  }

  private void OnDestroy()
  {
    GlobalAppData.땄(this.HealthIcon);
    GlobalAppData.땄(this.APIcon);
    this.딟.딟();
  }
}
