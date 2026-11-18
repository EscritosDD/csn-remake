// Decompiled with JetBrains decompiler
// Type: TallyXPBar
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;
using 땓;

public class TallyXPBar : MonoBehaviour
{
  private TallyXPBar.딪 딟;
  private TallyXPBar.떕 딟;
  private float 딟;
  private float 땄;
  private bool 딟;
  private static int 딟;
  private static int 땄 = 1;
  private float 딧;
  private float 딢;
  private float 땃;
  private int 딧;
  private int 딢;
  private int 땃;
  private int 딶;
  private int 땓;
  private int 땺;
  private int 땥;
  private int 딝;
  private bool 땄;
  private bool 딧;
  private Vector3 딟;
  private Vector3 땄;
  public GuiText3D XPNumText;
  public GuiText3D XPText;
  public GameObject XPFillArrow;
  public GameObject XPFillBarGraphic;
  public GameObject XPFillBar;
  public GameObject XPRewardFillBar;
  public GameObject XPRewardTextBackground;
  public GuiAnimation FillAnimation;
  public AudioShader2 XPlevelUpSound;
  public AudioShader2 XPFillUpSound;
  private bool 딢;

  public bool IntialiseTallyXPBar(
    int inCurrentXP,
    int inRewardXP,
    int inCurrentLevel,
    bool GetPlayerXP)
  {
    this.딢 = this.땺 = inCurrentXP;
    this.딧 = inRewardXP;
    this.딶 = inCurrentLevel;
    this.딧 = GetPlayerXP;
    this.땓 = 0;
    this.땄 = false;
    this.딧 = 0.0f;
    this.딟 = 0.0f;
    this.땄 = 1f;
    this.딟 = 땞.딟(this.XPFillBarGraphic);
    this.땄 = 땞.딟(this.XPRewardTextBackground);
    this.땄 = this.SetXPBarFillValues();
    this.FillAnimation.딟(new GuiAnimation.땂(this.OnXPFillAnimationEnd));
    this.FillAnimation.딟(new GuiAnimation.딱(this.OnXPFillAnimationDelayEnd));
    this.FillAnimation.딟(new GuiAnimation.때(this.OnXPFillAnimationUpdate), true);
    this.딢 = false;
    return this.땄;
  }

  public void TriggerTallyXPBarFillAnimation(bool ShouldPlayAudio)
  {
    this.딟 = ShouldPlayAudio;
    this.FillAnimation.딟();
  }

  public void FinishXPBarFillAnimation() => this.FillAnimation.딟(true);

  private bool SetXPBarFillValues()
  {
    int index = this.딶;
    if (this.딧 && GlobalAppData.딢().GenericData.딧(index))
    {
      this.딢 = 1f;
      this.땃 = 1f;
    }
    else
    {
      if (!this.딧)
        index = Mathf.Min(index + 1, GlobalAppData.딢().XPLevels.Levels.Length - 1);
      this.땃 = !this.딧 ? GlobalAppData.딢().땄(GlobalAppData.딢().XPLevels.Levels[index]) : GlobalAppData.딢().GenericData.딢(index);
      this.땥 = !this.딧 ? GlobalAppData.딢().XPLevels.Levels[index].RequiredXP : GlobalAppData.딢().GenericData.PlayerLevels[index].RequiredXP;
      this.딝 = 0;
      if (index > 0)
        this.딝 = !this.딧 ? GlobalAppData.딢().땄(GlobalAppData.딢().XPLevels.Levels[index - 1]) : GlobalAppData.딢().GenericData.딢(index - 1);
      if (this.땥 == 0)
        this.땥 = 1;
      this.딢 = (float) (this.땺 - this.딝) / (float) this.땥;
      this.땃 = (float) (this.땺 + (this.딧 - this.땓) - this.딝) / (float) this.땥;
    }
    float num = this.땃;
    if ((double) this.땃 > 1.0)
      num = 1f;
    bool flag = this.땺 + (this.딧 - this.땓) >= this.땃 && this.딧 > 0;
    this.XPFillBar.transform.localScale = new Vector3(this.딢, (float) this.XPFillBar.transform.localScale.y, (float) this.XPFillBar.transform.localScale.z);
    this.XPRewardFillBar.transform.localScale = new Vector3(num, (float) this.XPRewardFillBar.transform.localScale.y, (float) this.XPRewardFillBar.transform.localScale.z);
    return flag;
  }

  public void OnXPFillAnimationUpdate(float CurrentValue)
  {
    this.땓 = Mathf.CeilToInt((float) this.딧 * CurrentValue);
    this.땺 = this.딢 + this.땓;
    땞.딟(this.XPNumText, this.땺.ToString());
    if (this.땺 >= this.땃)
    {
      this.딶 = !this.딧 ? GlobalAppData.딢().땄(this.땺) : GlobalAppData.딢().GenericData.땄(this.땺);
      this.SetXPBarFillValues();
      if (this.딟 != null)
        this.딟(this.땺, this.딶);
      this.딟 = CurrentValue;
      if ((double) this.딟 == 1.0)
        this.딟 = 9.9999f;
      this.땄 = (float) (1.0 / (1.0 - (double) this.딟));
      if (Object.op_Inequality((Object) this.XPlevelUpSound, (Object) null) && TallyXPBar.딟 < TallyXPBar.땄)
      {
        this.딧 = Time.realtimeSinceStartup + this.XPlevelUpSound.PlayOneShot(((Component) this).gameObject, 0.0f);
        ++TallyXPBar.딟;
      }
    }
    float num1 = this.딢 + (this.땃 - this.딢) * ((CurrentValue - this.딟) * this.땄);
    if ((double) num1 > 1.0)
      num1 = 1f;
    this.XPFillBar.transform.localScale = new Vector3(num1, (float) this.XPFillBar.transform.localScale.y, (float) this.XPFillBar.transform.localScale.z);
    float num2 = (float) (this.딟.x * (double) num1 + this.XPFillBar.transform.localPosition.x);
    this.XPFillArrow.transform.localPosition = new Vector3(num2, (float) this.XPFillArrow.transform.localPosition.y, (float) this.XPFillArrow.transform.localPosition.z);
    float x1 = (float) this.XPNumText.GetTextWidthHeight().x;
    float x2 = (float) this.XPText.GetTextWidthHeight().x;
    float num3 = num2;
    if ((double) num3 - (double) x1 < this.XPRewardTextBackground.transform.localPosition.x - this.땄.x * 0.5)
      num3 = (float) (this.XPRewardTextBackground.transform.localPosition.x - this.땄.x * 0.5) + x1;
    if ((double) num3 + (double) x2 > this.XPRewardTextBackground.transform.localPosition.x + this.땄.x * 0.5)
      num3 = (float) (this.XPRewardTextBackground.transform.localPosition.x + this.땄.x * 0.5) - x2;
    this.XPNumText.SetTextPosition(new Vector3(num3, (float) ((Component) this.XPNumText).gameObject.transform.localPosition.y, (float) ((Component) this.XPNumText).gameObject.transform.localPosition.z));
    this.XPText.SetTextPosition(new Vector3(num3, (float) ((Component) this.XPText).gameObject.transform.localPosition.y, (float) ((Component) this.XPText).gameObject.transform.localPosition.z));
  }

  public void OnXPFillAnimationEnd()
  {
    this.XPRewardFillBar.SetActive(false);
    if (this.딟 == null)
      return;
    this.딟();
  }

  public void OnXPFillAnimationDelayEnd()
  {
    if (!this.딟 || this.딢 || !Object.op_Inequality((Object) this.XPFillUpSound, (Object) null))
      return;
    double num = (double) this.XPFillUpSound.PlayOneShot(((Component) this).gameObject, 0.0f);
    this.딢 = true;
  }

  public void AddOnLevelUpCallback(TallyXPBar.딪 Callback) => this.딟 = Callback;

  public void AddOnXPAnimFinishCallback(TallyXPBar.떕 Callback) => this.딟 = Callback;

  private void Update()
  {
    this.FillAnimation.땄();
    if (TallyXPBar.딟 <= 0 || (double) this.딧 <= 0.0 || (double) Time.realtimeSinceStartup <= (double) this.딧)
      return;
    --TallyXPBar.딟;
  }

  public void SetXPFillBarGraphicBackgroundMaterial(Material NewMat)
  {
    if (!Object.op_Inequality((Object) this.XPFillBarGraphic, (Object) null))
      return;
    this.XPFillBarGraphic.renderer.sharedMaterial = NewMat;
  }

  public delegate void 딪([In] int obj0, [In] int obj1);

  public delegate void 떕();
}
