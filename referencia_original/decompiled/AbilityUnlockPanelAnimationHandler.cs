// Decompiled with JetBrains decompiler
// Type: AbilityUnlockPanelAnimationHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;
using 딢;

public class AbilityUnlockPanelAnimationHandler : MonoBehaviour
{
  public GameObject PanelBackground;
  public GuiText3D NewAbilityUnlockedHeader;
  public GuiMultiLineText3D NewAbilityUnlockedDescription;
  public GuiButton3D ContinueButton;
  public GuiText3D NewAbilityUnlockedText;
  public GameObject NewAbilityUnlockedIcon;
  public GameObject NewAbilityUnlockedIconBackground;
  public GameObject LockedIcon;
  public GameObject UnlockedIcon;
  public Material LockedAbilityBackground;
  public Material UnlockedAbilityBackground;
  public float AnimLength;
  public float StartingX;
  public float StartingZ;
  public float ScaleDelay;
  public float IconStartZ;
  public float IconTargetZ;
  public float TitleStartZ;
  public float TitleTargetZ;
  private AbilityUnlockPanelAnimationHandler.떋 딟;
  private float 딟;
  private float 땄 = 1f;
  private 땿 딟 = new 땿();
  private bool 딟;

  private void Start()
  {
    ((Component) this.NewAbilityUnlockedHeader).gameObject.SetActive(false);
    ((Component) this.NewAbilityUnlockedDescription).gameObject.SetActive(false);
    ((Component) this.ContinueButton).gameObject.SetActive(false);
    ((Component) this.NewAbilityUnlockedText).gameObject.SetActive(false);
    this.NewAbilityUnlockedIcon.gameObject.SetActive(false);
    this.NewAbilityUnlockedIconBackground.gameObject.SetActive(false);
    this.LockedIcon.SetActive(false);
    this.UnlockedIcon.SetActive(false);
    this.딟 = AbilityUnlockPanelAnimationHandler.떋.딟;
  }

  private void Update()
  {
    this.PanelBackground.SetActive(true);
    this.딟.딟();
    this.딟 += Time.deltaTime / this.AnimLength;
    this.딟 = Mathf.Clamp01(this.딟);
    switch (this.딟)
    {
      case AbilityUnlockPanelAnimationHandler.떋.딟:
        this.AnimateScale(this.PanelBackground, this.StartingX, 0.0f);
        if ((double) this.딟 != 1.0)
          break;
        this.딟 = AbilityUnlockPanelAnimationHandler.떋.땄;
        this.딟 = 0.0f;
        this.딟.딟(this.ScaleDelay);
        break;
      case AbilityUnlockPanelAnimationHandler.떋.땄:
        if (this.딟.땄())
          this.AnimateScale(this.PanelBackground, this.StartingZ, 1f);
        if ((double) this.딟 != 1.0)
          break;
        this.NewAbilityUnlockedIcon.gameObject.SetActive(true);
        this.NewAbilityUnlockedIconBackground.gameObject.SetActive(true);
        ((Component) this.NewAbilityUnlockedHeader).gameObject.SetActive(true);
        this.LockedIcon.SetActive(true);
        this.딟.딟(1f);
        this.딟 = AbilityUnlockPanelAnimationHandler.떋.딧;
        break;
      case AbilityUnlockPanelAnimationHandler.떋.딧:
        if (!this.딟.땄())
          break;
        this.LockedIcon.SetActive(false);
        this.UnlockedIcon.SetActive(true);
        this.NewAbilityUnlockedIconBackground.renderer.sharedMaterial = this.UnlockedAbilityBackground;
        this.딟.딟(1f);
        this.딟 = AbilityUnlockPanelAnimationHandler.떋.딢;
        break;
      case AbilityUnlockPanelAnimationHandler.떋.딢:
        if (this.딟.땄())
        {
          if (!this.딟)
          {
            this.딟 = 0.0f;
            this.UnlockedIcon.SetActive(false);
            this.딟 = true;
          }
          this.AnimateIconAndHeader();
        }
        if (this.NewAbilityUnlockedIconBackground.transform.localPosition.z != (double) this.IconTargetZ)
          break;
        this.딟.딟(this.ScaleDelay);
        this.딟 = AbilityUnlockPanelAnimationHandler.떋.땃;
        break;
      case AbilityUnlockPanelAnimationHandler.떋.땃:
        if (!this.딟.땄())
          break;
        ((Component) this.NewAbilityUnlockedText).gameObject.SetActive(true);
        ((Component) this.NewAbilityUnlockedDescription).gameObject.SetActive(true);
        ((Component) this.ContinueButton).gameObject.SetActive(true);
        break;
    }
  }

  private void AnimateScale(GameObject TargetObject, float StartingScale, float TargetAxis)
  {
    float num = Mathf.Clamp01(Mathf.Lerp(StartingScale, this.땄, this.딟));
    Vector3 localScale = TargetObject.transform.localScale;
    if ((double) TargetAxis == 0.0)
    {
      TargetObject.transform.localScale = new Vector3(num, (float) localScale.y, (float) localScale.z);
    }
    else
    {
      if ((double) TargetAxis != 1.0)
        return;
      TargetObject.transform.localScale = new Vector3((float) localScale.x, (float) localScale.y, num);
    }
  }

  private void AnimateIconAndHeader()
  {
    float num1 = Mathf.Lerp(this.IconStartZ, this.IconTargetZ, this.딟);
    Vector3 localPosition1 = this.NewAbilityUnlockedIconBackground.transform.localPosition;
    localPosition1.z = (__Null) (double) num1;
    this.NewAbilityUnlockedIconBackground.transform.localPosition = localPosition1;
    float num2 = Mathf.Lerp(this.TitleStartZ, this.TitleTargetZ, this.딟);
    Vector3 localPosition2 = ((Component) this.NewAbilityUnlockedHeader).transform.localPosition;
    localPosition2.z = (__Null) (double) num2;
    ((Component) this.NewAbilityUnlockedHeader).transform.localPosition = localPosition2;
  }

  private enum 떋
  {
    딟,
    땄,
    딧,
    딢,
    땃,
  }
}
