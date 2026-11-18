// Decompiled with JetBrains decompiler
// Type: TooltipAnimationHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class TooltipAnimationHandler : MonoBehaviour
{
  public GameObject ToolTipBackground;
  public GuiText3D HeaderText;
  public GuiMultiLineText3D ToolTipText;
  public GuiButton3D ContinueButton;
  public GameObject Arrow;
  public GameObject PseudoButton;
  public GameObject SecondPseudoButton;
  public GameObject ThirdPseudoButton;
  public bool IsTutorialMessage;
  private bool 딟;

  private void Start()
  {
    ((Component) this.HeaderText).gameObject.SetActive(false);
    if (Object.op_Inequality((Object) this.ToolTipText, (Object) null))
      ((Component) this.ToolTipText).gameObject.SetActive(false);
    ((Component) this.ContinueButton).gameObject.SetActive(false);
    if (Object.op_Inequality((Object) this.Arrow, (Object) null))
      this.Arrow.SetActive(false);
    if (Object.op_Inequality((Object) this.PseudoButton, (Object) null))
      this.PseudoButton.SetActive(false);
    if (Object.op_Inequality((Object) this.SecondPseudoButton, (Object) null))
      this.SecondPseudoButton.SetActive(false);
    if (Object.op_Inequality((Object) this.ThirdPseudoButton, (Object) null))
      this.ThirdPseudoButton.SetActive(false);
    if (!Object.op_Inequality((Object) this.ToolTipBackground, (Object) null))
      return;
    this.ToolTipBackground.SetActive(true);
  }

  private void Update()
  {
    if (this.딟 || ((Component) this).animation.isPlaying)
      return;
    ((Component) this.HeaderText).gameObject.SetActive(true);
    this.HeaderText.UpdateMesh();
    if (Object.op_Inequality((Object) this.ToolTipText, (Object) null))
    {
      ((Component) this.ToolTipText).gameObject.SetActive(true);
      this.ToolTipText.UpdateMesh();
    }
    ((Component) this.ContinueButton).gameObject.SetActive(true);
    if (Object.op_Inequality((Object) this.Arrow, (Object) null))
      this.Arrow.SetActive(true);
    if (Object.op_Inequality((Object) this.PseudoButton, (Object) null))
      this.PseudoButton.SetActive(true);
    if (Object.op_Inequality((Object) this.SecondPseudoButton, (Object) null))
      this.SecondPseudoButton.SetActive(true);
    if (Object.op_Inequality((Object) this.ThirdPseudoButton, (Object) null))
      this.ThirdPseudoButton.SetActive(true);
    this.딟 = true;
  }
}
