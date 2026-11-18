// Decompiled with JetBrains decompiler
// Type: PurchaseSuccessfulPanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PurchaseSuccessfulPanelHandler : MonoBehaviour
{
  private Vector3 딟;
  private Vector3 땄;
  private Vector3 딧;
  private 딟.땫 딟;
  public Vector3 TextMaxScale;
  public GameObject Glare;
  public GuiAnimation TextAnimation;
  public GuiAnimation GlareGlowAnimation;
  public GuiText3D HeaderText;
  public GuiText3D DescriptionText;
  public GuiText3D InfoText;
  public ParticleSystem PurchaseBurstSmall;
  public ParticleSystem PurchaseBurstMedium;
  public ParticleSystem PurchaseBurstLarge;
  public AudioShader2 LevelUpSound;
  public GameObject SkipButton;
  public GameObject ContinueButton;
  public GameObject ItemIcon;
  public MenuOverlayHandler MenuOverlayPrefab;
  private MenuOverlayHandler 딟;

  private void Start()
  {
    GlobalAppData.땽().딟(딢.딮.떔);
    this.딟 = Object.Instantiate((Object) this.MenuOverlayPrefab) as MenuOverlayHandler;
    ((Component) this.딟).transform.position = Vector3.op_Subtraction(((Component) this).transform.position, new Vector3(0.0f, 0.1f, 0.0f));
    this.Glare.SetActive(false);
    this.딟 = ((Component) this.HeaderText).transform.localScale;
    this.땄 = ((Component) this.DescriptionText).transform.localScale;
    this.딧 = this.Glare.transform.localScale;
    this.TextAnimation.딟(new GuiAnimation.땂(this.OnTextAnimationFinish));
    this.TextAnimation.딟(new GuiAnimation.때(this.OnTextAnimationUpdate), true);
    this.GlareGlowAnimation.딟(new GuiAnimation.때(this.OnGlareGlowAnimationUpdate), true);
    this.GlareGlowAnimation.딟();
    this.TextAnimation.딟();
    if (!Object.op_Inequality((Object) this.LevelUpSound, (Object) null))
      return;
    double num = (double) this.LevelUpSound.PlayOneShot(((Component) this).gameObject, 0.0f);
  }

  public void Init(Material ImageMaterial, 땃.딷 Item, 딟.땫 ImageCache, string infoText)
  {
    this.딟 = ImageCache;
    if (Object.op_Inequality((Object) ImageMaterial, (Object) null))
    {
      this.ItemIcon.renderer.material = ImageMaterial;
      this.ItemIcon.gameObject.SetActive(true);
    }
    else
      this.ItemIcon.gameObject.SetActive(false);
    땓.땞.딟(this.DescriptionText, Item.딢());
    if (infoText != null)
      땓.땞.딟(this.InfoText, infoText);
    if (Item.땽())
      this.PurchaseBurstLarge.Play();
    if (Item.떏())
      this.PurchaseBurstMedium.Play();
    else
      this.PurchaseBurstSmall.Play();
  }

  public void OnTextAnimationFinish() => this.SkipButton.gameObject.SetActive(false);

  public void OnTextAnimationUpdate(float CurrentValue)
  {
    this.ApplyScaleAnimation(((Component) this.HeaderText).gameObject, this.딟, CurrentValue);
    this.ApplyScaleAnimation(((Component) this.DescriptionText).gameObject, this.땄, CurrentValue);
    if (!Object.op_Inequality((Object) this.InfoText, (Object) null))
      return;
    this.ApplyScaleAnimation(((Component) this.InfoText).gameObject, Vector3.one, CurrentValue);
  }

  private void ApplyScaleAnimation(GameObject Target, Vector3 StartScale, float CurrentValue)
  {
    Vector3 localScale = Target.transform.localScale;
    Vector3 vector3 = Vector3.op_Addition(StartScale, Vector3.op_Multiply(Vector3.op_Subtraction(this.TextMaxScale, StartScale), CurrentValue));
    Target.transform.localScale = vector3;
  }

  public void OnGlareGlowAnimationUpdate(float CurrentValue)
  {
    if (!this.Glare.activeInHierarchy)
      this.Glare.SetActive(true);
    this.Glare.renderer.material.color = new Color((float) this.Glare.renderer.material.color.r, (float) this.Glare.renderer.material.color.g, (float) this.Glare.renderer.material.color.b, CurrentValue);
    this.Glare.transform.localScale = Vector3.op_Multiply(this.딧, CurrentValue);
  }

  private void Update()
  {
    if (!((Component) this).gameObject.activeInHierarchy)
      return;
    this.TextAnimation.땄();
    this.GlareGlowAnimation.땄();
  }

  private void SkipLevelUpAnimation()
  {
    this.SkipButton.gameObject.SetActive(false);
    if (this.TextAnimation.딧())
      this.TextAnimation.딟(true);
    if (this.GlareGlowAnimation.딧())
      this.GlareGlowAnimation.딟(true);
    if (this.PurchaseBurstLarge.isPlaying)
      this.PurchaseBurstLarge.Clear(true);
    if (this.PurchaseBurstMedium.isPlaying)
      this.PurchaseBurstMedium.Clear(true);
    if (!this.PurchaseBurstSmall.isPlaying)
      return;
    this.PurchaseBurstSmall.Clear(true);
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (PurchaseSuccessfulPanelHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      PurchaseSuccessfulPanelHandler.딟 = new Dictionary<string, int>(2)
      {
        {
          "Continue",
          0
        },
        {
          "Skip",
          1
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!PurchaseSuccessfulPanelHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        this.SkipLevelUpAnimation();
        if (this.get_OnClosedCallback() != null)
          this.get_OnClosedCallback()();
        ((Component) this.딟).GetComponent<MenuOverlayHandler>().Close();
        Object.Destroy((Object) ((Component) this).gameObject);
        break;
      case 1:
        this.SkipLevelUpAnimation();
        break;
    }
  }

  private void OnDestroy()
  {
    GlobalAppData.땄(this.Glare);
    GlobalAppData.땄(this.SkipButton);
    GlobalAppData.땄(this.ContinueButton);
    GlobalAppData.땄(this.ItemIcon);
    if (this.딟 == null)
      return;
    this.딟.Dispose();
    this.딟 = (딟.땫) null;
  }

  [CompilerGenerated]
  [SpecialName]
  public Action get_OnClosedCallback() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public void set_OnClosedCallback(Action value) => this.딟 = value;
}
