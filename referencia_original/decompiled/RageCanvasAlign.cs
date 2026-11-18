// Decompiled with JetBrains decompiler
// Type: RageCanvasAlign
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof (BoxCollider))]
[ExecuteInEditMode]
[AddComponentMenu("RageTools/Rage CanvasAlign")]
public class RageCanvasAlign : MonoBehaviour
{
  public BoxCollider Boundaries;
  public RageCanvasAlign.딷 HorizontalAlign;
  public RageCanvasAlign.떁 VerticalAlign;
  [SerializeField]
  private bool _startOnly;
  private float 딟;
  private float 땄;
  private Camera 딟;
  private Type 딟;
  public Action UpdateAction;
  public Action StartAction;

  [SpecialName]
  public bool get_StartOnly() => this._startOnly;

  [SpecialName]
  public void set_StartOnly(bool value)
  {
    if (this._startOnly == value)
      return;
    this._startOnly = value;
    this.UpdateActions();
  }

  public void NoAction()
  {
  }

  public void Awake()
  {
    if (this.UpdateAction == null || this.StartAction == null)
      this.UpdateActions();
    this.딟 = Camera.main;
    this.Boundaries = ((Component) this).GetComponent<BoxCollider>();
    if (Object.op_Equality((Object) this.Boundaries, (Object) null))
      return;
    ((Collider) this.Boundaries).enabled = true;
    ((Collider) this.Boundaries).isTrigger = true;
  }

  public void OnGUI()
  {
    if (this.UpdateAction == null)
      this.UpdateActions();
    if ((MulticastDelegate) this.UpdateAction == (MulticastDelegate) new Action(this.NoAction) || this.UpdateAction == null)
      return;
    this.UpdateAction();
  }

  public void Start()
  {
    if (this.StartAction == null)
      this.UpdateActions();
    if ((MulticastDelegate) this.StartAction == (MulticastDelegate) new Action(this.NoAction) || this.StartAction == null)
      return;
    this.StartAction();
  }

  public void UpdateActions()
  {
    this.StartAction = !this._startOnly ? new Action(this.NoAction) : new Action(this.DoAlignToCanvas);
    this.UpdateAction = !this._startOnly ? new Action(this.DoAlignToCanvas) : new Action(this.NoAction);
  }

  private bool GetCamera()
  {
    if (!Object.op_Implicit((Object) this.딟))
      this.딟 = Camera.main;
    return Object.op_Inequality((Object) this.딟, (Object) null);
  }

  public void DoAlignToCanvas()
  {
    if (!this.GetCamera() || this.딟.orthographic && 땺.땢.딟(this.딟.orthographicSize, 0.0f))
      return;
    Vector2 gameViewSize = this.GetGameViewSize();
    Vector3 worldPoint1 = this.딟.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, this.딟.nearClipPlane));
    Vector3 worldPoint2 = this.딟.ScreenToWorldPoint(new Vector3((float) gameViewSize.x, (float) gameViewSize.y, this.딟.farClipPlane));
    if (Object.op_Equality((Object) this.Boundaries, (Object) null))
      return;
    switch (this.HorizontalAlign)
    {
      case RageCanvasAlign.딷.딟:
        this.딟 = (float) (worldPoint1.x + ((Component) this).transform.lossyScale.x * (-this.Boundaries.center.x + this.Boundaries.size.x / 2.0));
        break;
      case RageCanvasAlign.딷.땄:
        this.딟 = (float) (worldPoint2.x + ((Component) this).transform.lossyScale.x * (-this.Boundaries.center.x - this.Boundaries.size.x / 2.0));
        break;
      case RageCanvasAlign.딷.딧:
        this.딟 = (float) ((worldPoint2.x + worldPoint1.x) / 2.0 + ((Component) this).transform.lossyScale.x * -this.Boundaries.center.x);
        break;
    }
    switch (this.VerticalAlign)
    {
      case RageCanvasAlign.떁.딟:
        this.땄 = (float) (worldPoint2.y + ((Component) this).transform.lossyScale.x * (-this.Boundaries.center.y - this.Boundaries.size.y / 2.0));
        break;
      case RageCanvasAlign.떁.땄:
        this.땄 = (float) (worldPoint1.y + ((Component) this).transform.lossyScale.x * (-this.Boundaries.center.y + this.Boundaries.size.y / 2.0));
        break;
      case RageCanvasAlign.떁.딧:
        this.땄 = (float) ((worldPoint2.y + worldPoint1.y) / 2.0 + ((Component) this).transform.lossyScale.x * -this.Boundaries.center.y);
        break;
    }
    ((Component) this).transform.position = new Vector3(this.딟, this.땄, (float) ((Component) this).transform.position.z);
  }

  public Vector2 GetGameViewSize()
  {
    if (!Application.isEditor)
      return new Vector2((float) Screen.width, (float) Screen.height);
    if ((object) this.딟 == null)
      this.딟 = Type.GetType("UnityEditor.GameView,UnityEditor");
    if ((object) this.딟 == null)
      return Vector2.zero;
    object obj = this.딟.GetMethod("GetSizeOfMainGameView", BindingFlags.Static | BindingFlags.NonPublic).Invoke((object) null, (object[]) null);
    return obj == null ? Vector2.zero : (Vector2) obj;
  }

  public enum 딷
  {
    딟,
    땄,
    딧,
  }

  public enum 떁
  {
    딟,
    땄,
    딧,
  }
}
