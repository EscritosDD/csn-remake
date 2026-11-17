// Decompiled with JetBrains decompiler
// Type: InGameTooltipAnimationHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;
using 딢;

public class InGameTooltipAnimationHandler : MonoBehaviour
{
  public GameObject ToolTipBackground;
  public GuiMultiLineText3D ToolTipText;
  public GuiButton3D ContinueButton;
  public GuiText3D ProgressText;
  public Transform TutorialPadding;
  public bool IsTutorialMessage;
  public float AnimLength;
  public float StartingX;
  public float StartingZ;
  public float ScaleDelay;
  private float 딟;
  private float 땄 = 1f;
  private bool 딟;
  private bool 땄;
  private 땿 딟 = new 땿();
  private bool 딧;

  private void Start()
  {
    ((Component) this.ToolTipText).gameObject.SetActive(false);
    if (this.IsTutorialMessage)
      return;
    ((Component) this.ContinueButton).gameObject.SetActive(false);
    ((Component) this.ProgressText).gameObject.SetActive(false);
  }

  private void Update()
  {
    this.ToolTipBackground.SetActive(true);
    this.딟.딟();
    this.딟 += Time.deltaTime / this.AnimLength;
    this.딟 = Mathf.Clamp01(this.딟);
    if (!this.딟)
    {
      this.AnimateScale(this.딟, this.ToolTipBackground, this.StartingX, 0.0f);
      if ((double) this.딟 == 1.0)
      {
        this.딟 = true;
        this.딟 = 0.0f;
        this.딟.딟(this.ScaleDelay);
      }
    }
    else if (!this.땄)
    {
      if (this.딟.땄())
        this.AnimateScale(this.딟, this.ToolTipBackground, this.StartingZ, 1f);
      if ((double) this.딟 == 1.0)
      {
        this.땄 = true;
        this.딟.딟(this.ScaleDelay);
      }
    }
    if (this.ToolTipBackground.transform.localScale.z != 1.0)
      return;
    if (this.딟.땄() && !this.딧)
    {
      ((Component) this.ToolTipText).gameObject.SetActive(true);
      this.ToolTipText.UpdateMesh();
      this.딧 = true;
    }
    if (this.IsTutorialMessage)
      return;
    ((Component) this.ProgressText).gameObject.SetActive(true);
    ((Component) this.ContinueButton).gameObject.SetActive(true);
  }

  private void AnimateScale(
    float LerpVal,
    GameObject TargetObject,
    float StartingScale,
    float TargetAxis)
  {
    float num = Mathf.Clamp01(Mathf.Lerp(StartingScale, this.땄, LerpVal));
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
}
