// Decompiled with JetBrains decompiler
// Type: FriendSelectionButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using UnityEngine;

[AddComponentMenu("Gui3D/Controls/Friend Selection Button")]
public class FriendSelectionButton : MonoBehaviour
{
  private GuiScrollList3D 딟;
  private 땓.땶 딟;
  public GuiButton3D SelectionButton;
  public GuiText3D NameText;
  public GameObject AvatarBackground;
  public GameObject AvatarIcon;
  public GameObject FacebookIcon;
  public GameObject ProfileRankBackground;
  public GuiText3D ProfileRank;
  public GameObject ButtonLeft;
  public GameObject ButtonMiddle;
  public GameObject ButtonRight;
  public Shader FacebookFriendShader;
  public Material AvatarBackgroundMaterial;
  public Shader IconShader;
  public Shader FacebookIconShader;

  public void Init(딢.땇 Friend, GuiScrollList3D List)
  {
    // ISSUE: reference to a compiler-generated method
    this.set_Friend(Friend);
    this.딟 = List;
    this.SelectionButton.set_CustomPressFunc("OnFriendSelected");
    this.SelectionButton.set_CustomPressValue((object) this);
    this.FacebookIcon.SetActive(false);
    this.ProfileRankBackground.renderer.sharedMaterial = GlobalAppData.땲().딟(this.ProfileRankBackground.renderer.material, this.IconShader);
    this.ButtonLeft.renderer.sharedMaterial = GlobalAppData.땲().딟(this.ButtonLeft.renderer.material, this.IconShader);
    this.ButtonMiddle.renderer.sharedMaterial = GlobalAppData.땲().딟(this.ButtonMiddle.renderer.material, this.IconShader);
    this.ButtonRight.renderer.sharedMaterial = GlobalAppData.땲().딟(this.ButtonRight.renderer.material, this.IconShader);
    this.SelectionButton.Disabled = false;
    this.NameText.Text = Friend.딧().땄();
    this.NameText.UpdateMesh();
    땓.땇 땇 = Friend.딧().땃() as 땓.땇;
    this.딟 = 땇.딧();
    this.ProfileRank.Text = 땇.딢().ToString();
    this.ProfileRank.UpdateMesh();
    List.UpdateItemClipping();
  }

  private void Update()
  {
    if (!this.get_IsFacebookUser() && !string.IsNullOrEmpty(this.get_Friend().딧().딢()))
    {
      this.FacebookIcon.SetActive(true);
      // ISSUE: reference to a compiler-generated method
      this.set_IsFacebookUser(true);
    }
    if (this.딟 == null || !this.딟.딟())
      return;
    if (this.딟.땄())
    {
      this.AvatarIcon.renderer.material = !(this.딟 is 땓.딫) ? GlobalAppData.땲().딟(this.딟.딧(), this.IconShader) : GlobalAppData.땲().딟(this.딟.딧(), this.FacebookIconShader);
      this.AvatarBackground.renderer.sharedMaterial = GlobalAppData.땲().딟(this.AvatarBackgroundMaterial, this.IconShader);
      this.딟.UpdateItemClipping();
    }
    this.딟 = (땓.땶) null;
  }

  public void SetAvatarIcon(Texture2D Image)
  {
    if (Object.op_Equality((Object) Image, (Object) null) || !Object.op_Inequality((Object) this.AvatarIcon, (Object) null))
      return;
    this.AvatarIcon.renderer.material.shader = this.FacebookFriendShader;
    this.AvatarIcon.renderer.material.mainTexture = (Texture) Image;
    if (((Texture) Image).width > ((Texture) Image).height)
    {
      float num1 = (float) ((Texture) Image).height / (float) ((Texture) Image).width;
      float num2 = (float) (((double) ((Texture) Image).width / (double) ((Texture) Image).height - 1.0) * 0.5);
      this.AvatarIcon.renderer.material.mainTextureScale = new Vector2(num1, 1f);
      this.AvatarIcon.renderer.material.mainTextureOffset = new Vector2(num2, 0.0f);
    }
    else
    {
      if (((Texture) Image).height <= ((Texture) Image).width)
        return;
      float num3 = (float) ((Texture) Image).width / (float) ((Texture) Image).height;
      float num4 = (float) (((double) ((Texture) Image).height / (double) ((Texture) Image).width - 1.0) * 0.5);
      this.AvatarIcon.renderer.material.mainTextureScale = new Vector2(1f, num3);
      this.AvatarIcon.renderer.material.mainTextureOffset = new Vector2(0.0f, num4);
    }
  }

  private void OnDestroy() => GlobalAppData.땄(this.AvatarIcon);

  [CompilerGenerated]
  [SpecialName]
  public 딢.땇 get_Friend() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public bool get_IsFacebookUser() => this.딟;
}
