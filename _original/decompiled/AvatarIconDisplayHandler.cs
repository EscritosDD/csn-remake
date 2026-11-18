// Decompiled with JetBrains decompiler
// Type: AvatarIconDisplayHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using 딧;

public class AvatarIconDisplayHandler : MonoBehaviour
{
  public GameObject Background;
  public GameObject Icon;
  public GameObject LockIcon;
  public Material BackgroundBlue;
  public Material BackgroundGrey;
  public Material BackgroundSelected;
  public Shader DisabledIconShader;
  public PlayerProfilePanelHandler ProfileScreen;
  public GameObject LoadingOverlay;
  private Uri 딟;
  private bool 딟;
  private 딼 딟 = new 딼();

  private void OnEnable()
  {
    this.LockIcon.SetActive(false);
    this.SetLoadState(true);
  }

  public void Init(Uri AvatarUri, bool IsOwned)
  {
    this.딟 = AvatarUri;
    this.딟 = IsOwned;
    this.LockIcon.SetActive(!IsOwned);
  }

  public void SetIconMaterial(Material IconMaterial)
  {
    Material material = IconMaterial;
    if (!this.딟)
      this.딟.딟(this.Icon, this.DisabledIconShader);
    this.딟.딟(this.Icon, material);
    this.SetSelected(this.IsCurrentAvatar());
  }

  public void ResetAvatarIconDisplay()
  {
    this.딟.딟();
    if (this.딟)
      this.딟.딟(this.Icon, this.BackgroundBlue);
    else
      this.딟.딟(this.Icon, this.BackgroundGrey);
    this.SetSelected(false);
  }

  public void SetButtonState(bool IsEnabled)
  {
    GuiButton3D component = ((Component) this).GetComponent<GuiButton3D>();
    if (!Object.op_Inequality((Object) component, (Object) null))
      return;
    component.Disabled = !IsEnabled;
    component.AnimateButton = !this.딟;
    this.ResetAvatarIconDisplay();
    if (!this.딟)
      this.딟.딟(this.Background, this.BackgroundGrey);
    else
      this.딟.딟(this.Background, !this.IsCurrentAvatar() ? this.BackgroundBlue : this.BackgroundSelected);
  }

  private void SetSelected(bool Selected)
  {
    this.SetScale(!Selected ? 1f : 0.75f);
    this.SetOpacity(!Selected ? 1f : 0.5f);
  }

  private void SetScale(float TargetScale) => ((Component) this).transform.localScale = new Vector3(TargetScale, 1f, TargetScale);

  private void SetOpacity(float TargetOpacity)
  {
    if (Object.op_Inequality((Object) this.Background, (Object) null))
      this.딟.딟(this.Background, new Color(1f, 1f, 1f, TargetOpacity));
    if (!Object.op_Inequality((Object) this.Icon, (Object) null))
      return;
    this.딟.딟(this.Icon, new Color(1f, 1f, 1f, TargetOpacity));
  }

  public void SetLoadState(bool DoShow)
  {
    if (!Object.op_Inequality((Object) this.LoadingOverlay, (Object) null))
      return;
    this.LoadingOverlay.gameObject.SetActive(DoShow);
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (AvatarIconDisplayHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      AvatarIconDisplayHandler.딟 = new Dictionary<string, int>(1)
      {
        {
          "Select",
          0
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!AvatarIconDisplayHandler.딟.TryGetValue(key, out num) || num != 0 || !this.딟)
      return;
    this.ProfileScreen.ChangeActiveAvatar(this.딟);
  }

  private void OnDestroy()
  {
    this.딟.딟();
    GlobalAppData.땄(this.Background);
    GlobalAppData.땄(this.Icon);
    GlobalAppData.땄(this.LockIcon);
    GlobalAppData.땄(this.LoadingOverlay);
  }

  private bool IsCurrentAvatar() => this.딟 != (Uri) null && this.딟.Equals((object) GlobalAppData.땽().딳());
}
