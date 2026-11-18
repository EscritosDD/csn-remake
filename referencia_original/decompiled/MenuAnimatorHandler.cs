// Decompiled with JetBrains decompiler
// Type: MenuAnimatorHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MenuAnimatorHandler : MonoBehaviour
{
  public bool StartAnimationOnInitialisation = true;
  public float LerpTime = 0.2f;
  public AnimationCurve SlideAnim;
  public float YVal;
  public Transform StartPoint;
  public Transform EndPoint;
  private bool 딟;
  private bool 땄;
  private float 딟;
  private MenuAnimatorHandler.땔 딟;
  private MenuAnimatorHandler.땔 땄;

  private void Start()
  {
    if (this.StartAnimationOnInitialisation)
      this.StartAnim();
    GuiScreenARComponentAdjustBase.딟(new Action(this.OnAspectRatioChange));
  }

  public void SetWaitForUpdate(bool IsWaiting) => this.딟 = IsWaiting;

  public void StartAnim()
  {
    this.set_LerpVal(0.0f);
    ((Component) this).transform.position = this.get_StartPos();
    this.set_IsOpening(true);
    this.set_IsClosing(false);
    this.set_IsOpen(false);
    this.딟 = Time.realtimeSinceStartup;
  }

  public void SetOnOpenFinishedCallback(MenuAnimatorHandler.땔 Callback) => this.딟 = Callback;

  public void SetOnCloseFinisheCallback(MenuAnimatorHandler.땔 Callback) => this.땄 = Callback;

  private void Update()
  {
    float num = Time.realtimeSinceStartup - this.딟;
    this.딟 = Time.realtimeSinceStartup;
    if (this.get_IsOpening())
    {
      MenuAnimatorHandler menuAnimatorHandler = this;
      menuAnimatorHandler.set_LerpVal(menuAnimatorHandler.get_LerpVal() + num / this.LerpTime);
      this.set_LerpVal(Mathf.Clamp(this.get_LerpVal(), 0.0f, 1f));
      this.UpdatePanelPosition(this.get_LerpVal());
      if ((double) this.get_LerpVal() == 1.0)
      {
        this.set_IsOpening(false);
        this.set_IsOpen(true);
        if (this.딟 != null)
          this.딟();
      }
    }
    if (this.get_IsClosing())
    {
      MenuAnimatorHandler menuAnimatorHandler = this;
      menuAnimatorHandler.set_LerpVal(menuAnimatorHandler.get_LerpVal() - num / this.LerpTime);
      this.set_LerpVal(Mathf.Clamp(this.get_LerpVal(), 0.0f, 1f));
      this.UpdatePanelPosition(1f - this.get_LerpVal());
      if (Vector3.op_Equality(((Component) this).transform.position, this.get_StartPos()))
      {
        this.set_IsClosing(false);
        if (this.땄 != null)
          this.땄();
        this.땄 = true;
      }
    }
    if (!this.땄 || this.딟)
      return;
    Object.Destroy((Object) ((Component) this).gameObject);
  }

  private void UpdatePanelPosition(float LerpValue)
  {
    float num = this.SlideAnim.Evaluate(LerpValue);
    Vector3 zero = Vector3.zero;
    if (this.get_IsOpening() || this.get_IsOpen())
    {
      // ISSUE: explicit constructor call
      ((Vector3) ref zero).\u002Ector(Mathf.Lerp((float) this.get_StartPos().x, (float) this.get_TargetPos().x, num), this.YVal, Mathf.Lerp((float) this.get_StartPos().z, (float) this.get_TargetPos().z, num));
    }
    else if (this.get_IsClosing() || this.땄)
    {
      // ISSUE: explicit constructor call
      ((Vector3) ref zero).\u002Ector(Mathf.Lerp((float) this.get_TargetPos().x, (float) this.get_StartPos().x, num), this.YVal, Mathf.Lerp((float) this.get_TargetPos().z, (float) this.get_StartPos().z, num));
    }
    ((Component) this).transform.position = zero;
  }

  public void OnAspectRatioChange()
  {
    if (this.get_IsOpening())
      this.UpdatePanelPosition(this.get_LerpVal());
    else if (this.get_IsOpen())
      this.UpdatePanelPosition(1f);
    else if (this.get_IsClosing())
      this.UpdatePanelPosition(1f - this.get_LerpVal());
    else if (!this.땄)
      ;
  }

  public void Close()
  {
    this.set_IsOpening(false);
    this.set_IsOpen(false);
    this.set_IsClosing(true);
  }

  public void OnDestroy()
  {
    GuiScreenARComponentAdjustBase.땄(new Action(this.OnAspectRatioChange));
    GlobalAppData.땄(((Component) this).gameObject);
  }

  [CompilerGenerated]
  [SpecialName]
  public bool get_IsClosing() => this.딧;

  [CompilerGenerated]
  [SpecialName]
  public void set_IsClosing(bool value) => this.딧 = value;

  [CompilerGenerated]
  [SpecialName]
  public bool get_IsOpening() => this.딢;

  [CompilerGenerated]
  [SpecialName]
  public void set_IsOpening(bool value) => this.딢 = value;

  [CompilerGenerated]
  [SpecialName]
  public bool get_IsOpen() => this.땃;

  [CompilerGenerated]
  [SpecialName]
  public void set_IsOpen(bool value) => this.땃 = value;

  [CompilerGenerated]
  [SpecialName]
  public float get_LerpVal() => this.땄;

  [CompilerGenerated]
  [SpecialName]
  public void set_LerpVal(float value) => this.땄 = value;

  [SpecialName]
  public Vector3 get_StartPos() => this.StartPoint.position;

  [SpecialName]
  public Vector3 get_TargetPos() => this.EndPoint.position;

  public delegate void 땔();
}
