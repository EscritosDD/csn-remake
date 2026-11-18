// Decompiled with JetBrains decompiler
// Type: SingleMissionAwardData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using UnityEngine;
using 딶;

[Serializable]
public class SingleMissionAwardData
{
  public GameObject AwardBackground;
  public GameObject AwardImage;
  public GameObject AwardGlow;
  public GameObject AwardGlare;
  public GameObject AwardText;
  public GuiParticleEmitter AwardParticles;
  public GuiAnimation AwardAnimation;
  public AudioShader2 AwardSound;
  private SingleMissionAwardData 딟;
  public GuiText3D CoinsText;
  private GameObject 딟;
  private SingleMissionAwardData.딜 딟;
  private Vector3 딟;
  private int 딟;
  private bool 딟;
  private 땖 딟;

  public void 딟([In] int obj0, [In] SingleMissionAwardData.딜 obj1, [In] SingleMissionAwardData obj2, [In] 땖 obj3)
  {
    this.딟 = obj0;
    this.딟 = obj1;
    this.딟 = false;
    this.딟 = obj2;
    this.딟 = obj3;
    if (Object.op_Inequality((Object) this.AwardImage, (Object) null))
    {
      this.딟 = this.AwardImage.transform.localScale;
      this.AwardImage.SetActive(false);
    }
    if (Object.op_Inequality((Object) this.AwardGlow, (Object) null))
      this.AwardGlow.SetActive(false);
    if (Object.op_Inequality((Object) this.AwardGlare, (Object) null))
      this.AwardGlare.SetActive(false);
    if (Object.op_Inequality((Object) this.AwardText, (Object) null))
      this.AwardText.SetActive(false);
    if (Object.op_Inequality((Object) this.CoinsText, (Object) null))
      ((Component) this.CoinsText).gameObject.SetActive(false);
    this.AwardAnimation.딟(new GuiAnimation.땂(this.딢));
    this.AwardAnimation.딟(new GuiAnimation.딱(this.딧));
    this.AwardAnimation.딟(new GuiAnimation.때(this.딟), true);
  }

  public void 딟([In] GameObject obj0)
  {
    this.딟 = obj0;
    if (Object.op_Inequality((Object) this.AwardImage, (Object) null))
      this.AwardImage.SetActive(true);
    if (Object.op_Inequality((Object) this.AwardGlow, (Object) null))
      this.AwardGlow.SetActive(true);
    if (Object.op_Inequality((Object) this.AwardGlare, (Object) null))
      this.AwardGlare.SetActive(true);
    if (Object.op_Inequality((Object) this.AwardText, (Object) null))
      this.AwardText.SetActive(true);
    if (this.딟 == null && Object.op_Inequality((Object) this.CoinsText, (Object) null))
      this.딟();
    this.AwardAnimation.딟();
  }

  private void 딟()
  {
    ((Component) this.CoinsText).gameObject.SetActive(true);
    string 딧 = this.딟.딟.딧;
    BuildManifestMissionRewardsData missionRewardsData = GlobalAppData.땼().땉(딧);
    int num = GlobalAppData.땽().떎(딧);
    this.CoinsText.Text = missionRewardsData == null || this.딟 <= num || this.딟 > missionRewardsData.Rewards.Length ? "-" : missionRewardsData.Rewards[this.딟 - 1].Coins.ToString();
    this.CoinsText.UpdateMesh();
  }

  public void 땄()
  {
    this.딟 = true;
    this.AwardAnimation.딟(true);
    if (!this.AwardParticles.get_bPaticleEmitterActive())
      return;
    this.AwardParticles.KillParticleEmitter();
  }

  public void 딟([In] float obj0)
  {
    if (Object.op_Inequality((Object) this.AwardImage, (Object) null))
      this.AwardImage.transform.localScale = Vector3.op_Multiply(this.딟, obj0);
    if (Object.op_Inequality((Object) this.AwardGlow, (Object) null))
      this.AwardGlow.transform.localScale = Vector3.op_Multiply(this.딟, obj0);
    if (Object.op_Inequality((Object) this.AwardGlare, (Object) null))
      this.AwardGlare.transform.localScale = Vector3.op_Multiply(this.딟, obj0);
    if (Object.op_Inequality((Object) this.AwardText, (Object) null))
      this.AwardText.transform.localScale = Vector3.op_Multiply(this.딟, obj0);
    if (!Object.op_Inequality((Object) this.CoinsText, (Object) null))
      return;
    ((Component) this.CoinsText).transform.localScale = Vector3.op_Multiply(this.딟, obj0);
  }

  public void 딧()
  {
    if (Object.op_Inequality((Object) this.AwardSound, (Object) null))
    {
      double num = (double) this.AwardSound.PlayOneShot(this.딟);
    }
    if (!this.딟)
      this.AwardParticles.ActivatePaticleEmitter();
    if (this.딟 == null)
      return;
    this.딟.딶();
    if (!Object.op_Inequality((Object) this.CoinsText, (Object) null))
      return;
    this.딟();
  }

  public void 딢()
  {
    if (this.딟 == null)
      return;
    this.딟(this.딟);
  }

  public void 땃()
  {
    if (!this.AwardAnimation.딧())
      return;
    this.AwardAnimation.땄();
  }

  public void 딶()
  {
    if (Object.op_Inequality((Object) this.AwardText, (Object) null))
      this.AwardText.SetActive(false);
    if (!Object.op_Inequality((Object) this.AwardGlow, (Object) null))
      return;
    this.AwardGlow.SetActive(false);
  }

  public delegate void 딜([In] int obj0);
}
