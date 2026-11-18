// Decompiled with JetBrains decompiler
// Type: ChatMessageDisplay
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class ChatMessageDisplay : MonoBehaviour
{
  public GuiText3D singleLineText;
  public GameObject avatar;
  public GameObject background;
  public GuiTextField3D textField;
  public GameObject avatarComponents;
  public GameObject textComponents;
  public GameObject blueTextBackground;
  public GameObject redTextBackground;
  private bool 딟;
  private bool 땄;
  private 땄.땣 딟;
  private 땓.땶 딟;
  private Material 딟;

  public void HideAll() => ((Component) this).gameObject.SetActive(false);

  public void ShowAll()
  {
    ((Component) this).gameObject.SetActive(true);
    this.textComponents.gameObject.SetActive(true);
  }

  public void HideTextComponents() => this.textComponents.gameObject.SetActive(false);

  public void Init(
    string text,
    string userId,
    Material backgroundMaterial,
    Color textColor,
    int teamIndex,
    bool isLeft)
  {
    this.딟 = GlobalAppData.떏().땄(userId, false);
    this.딟 = true;
    this.땄 = isLeft;
    if (!string.IsNullOrEmpty(text))
    {
      this.singleLineText.Text = text;
      this.singleLineText.TextColor = new Color((float) textColor.r, (float) textColor.g, (float) textColor.b, 1f);
      this.singleLineText.UpdateMesh();
      if (Object.op_Inequality((Object) this.textField, (Object) null))
        this.textField.SetText(text);
    }
    this.딟 = backgroundMaterial;
    if (!Object.op_Inequality((Object) this.blueTextBackground, (Object) null) || !Object.op_Inequality((Object) this.redTextBackground, (Object) null))
      return;
    if (teamIndex == 0)
    {
      this.redTextBackground.SetActive(false);
      this.blueTextBackground.SetActive(true);
    }
    else
    {
      this.redTextBackground.SetActive(true);
      this.blueTextBackground.SetActive(false);
    }
  }

  private void Update()
  {
    if (!this.딟)
      return;
    if (this.딟 != null && this.딟.땄())
    {
      if (this.딟.딧())
        this.딟 = (this.딟.딟.땃() as 땓.땇).딧();
      this.딟 = (땄.땣) null;
    }
    if (this.딟 == null || !this.딟.딟())
      return;
    if (this.딟.땄() && Object.op_Inequality((Object) this.avatar, (Object) null))
    {
      this.avatar.renderer.sharedMaterial = this.딟.딧();
      this.background.renderer.sharedMaterial = this.딟;
      if (!this.땄 && !(this.딟 is 땓.딫))
      {
        this.avatar.renderer.material.SetTextureOffset("_MainTex", new Vector2(1f, 0.0f));
        this.avatar.renderer.material.SetTextureScale("_MainTex", new Vector2(-1f, 1f));
      }
    }
    this.딟 = (땓.땶) null;
  }
}
