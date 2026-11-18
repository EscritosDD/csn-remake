// Decompiled with JetBrains decompiler
// Type: PlayerInfoData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

[Serializable]
public class PlayerInfoData
{
  public GameObject PlayerInfoParent;
  public GameObject AvatarImg;
  public GameObject AvatarImgLoadingSpinner;
  public GameObject AvatarImgBackground;
  public GameObject PlayerLevelBackground;
  public GuiText3D ProfileLevelTextbox;
  public GuiText3D NameTextbox;
  private float 딟 = 0.41f;
  private 땓.땶 딟;
  public int TeamIndex;
  public 딶.땖 GameState;

  public void 딟([In] 땄.땣 obj0)
  {
    // ISSUE: reference to a compiler-generated method
    this.땄(obj0);
    // ISSUE: reference to a compiler-generated method
    this.딶(true);
  }

  public void 딟([In] Uri obj0) => this.딟 = 땓.땶.딟(obj0);

  public void 딟([In] bool obj0) => this.딢(obj0);

  public void 땄([In] bool obj0) => this.땃(obj0);

  public void 딟([In] string obj0) => this.딧(obj0);

  public void 딧([In] bool obj0)
  {
    if (!Object.op_Inequality((Object) this.PlayerInfoParent, (Object) null))
      return;
    this.PlayerInfoParent.SetActive(obj0);
  }

  public void 딟()
  {
    if (this.땄() != null && this.땄().땄())
    {
      if (this.땄().딧())
      {
        땓.땇 땇 = this.땄().딟.땃() as 땓.땇;
        if (this.딧())
          this.딟 = 땇.딧();
        if (this.딢())
        {
          this.ProfileLevelTextbox.Text = (this.TeamIndex == this.GameState.땂() ? GlobalAppData.땽().때() : 땇.딢()).ToString();
          this.ProfileLevelTextbox.UpdateMesh();
          // ISSUE: reference to a compiler-generated method
          this.땃(false);
        }
        if (this.땃())
        {
          땓.땞.딟(this.NameTextbox, this.땄(this.땄().딟.땄()));
          // ISSUE: reference to a compiler-generated method
          this.딶(false);
        }
      }
      else if (this.땄().딟 == null)
      {
        if (Object.op_Inequality((Object) this.AvatarImgLoadingSpinner, (Object) null))
          this.AvatarImgLoadingSpinner.SetActive(false);
        this.AvatarImg.SetActive(true);
        this.AvatarImg.renderer.material = GlobalAppData.딟.GameAssets.UnknownOpponentAvatarMaterial;
      }
      // ISSUE: reference to a compiler-generated method
      this.땄((땄.땣) null);
    }
    if (this.딟 == null || !this.딟.딟())
      return;
    if (this.딟.땄())
    {
      this.AvatarImg.SetActive(true);
      this.AvatarImg.renderer.material = this.딟.딧();
      if (this.땓() && !(this.딟 is 땓.딫))
      {
        this.AvatarImg.renderer.material.SetTextureOffset("_MainTex", new Vector2(1f, 0.0f));
        this.AvatarImg.renderer.material.SetTextureScale("_MainTex", new Vector2(-1f, 1f));
      }
      if (Object.op_Inequality((Object) this.AvatarImgLoadingSpinner, (Object) null))
        this.AvatarImgLoadingSpinner.SetActive(false);
      // ISSUE: reference to a compiler-generated method
      this.딢(false);
    }
    this.딟 = (땓.땶) null;
  }

  private string 땄([In] string obj0)
  {
    string str = obj0;
    if (this.NameTextbox.Font.딟(str, true, this.NameTextbox.Size).x <= (double) this.딟)
      return obj0;
    for (Vector2 vector2 = this.NameTextbox.Font.딟(str + "...", true, this.NameTextbox.Size); vector2.x > (double) this.딟; vector2 = this.NameTextbox.Font.딟(str + "...", true, this.NameTextbox.Size))
      str = str.Substring(0, str.Length - 1);
    return str + "...";
  }

  [CompilerGenerated]
  [SpecialName]
  public 땄.땣 땄() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public bool 딧() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public bool 딢() => this.땄;

  [CompilerGenerated]
  [SpecialName]
  public bool 땃() => this.딧;

  [CompilerGenerated]
  [SpecialName]
  public string 딶() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public bool 땓() => this.딢;

  [CompilerGenerated]
  [SpecialName]
  public void 땓([In] bool obj0) => this.딢 = obj0;
}
