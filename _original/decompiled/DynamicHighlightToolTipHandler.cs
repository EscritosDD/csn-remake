// Decompiled with JetBrains decompiler
// Type: DynamicHighlightToolTipHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using UnityEngine;

public class DynamicHighlightToolTipHandler : ToolTipHandler
{
  private Vector3 딟;
  private Action<MonoBehaviour> 딟;
  private Action<MonoBehaviour> 땄;
  public MonoBehaviour TargetReference;

  public void HighlightTarget(
    MonoBehaviour Target,
    Action<MonoBehaviour> OnOpen,
    Action<MonoBehaviour> OnClose)
  {
    this.딟 = !Object.op_Inequality((Object) ((Component) Target).transform.parent, (Object) null) ? new Vector3((float) ((Component) Target).transform.position.x, (float) ((Component) Target).transform.position.y, (float) ((Component) Target).transform.position.z) : new Vector3((float) ((Component) Target).transform.localPosition.x, (float) ((Component) Target).transform.localPosition.y, (float) ((Component) Target).transform.localPosition.z);
    this.TargetReference = Target;
    this.딟 = OnOpen;
    this.땄 = OnClose;
  }

  protected override void CopyState(ToolTipHandler Original)
  {
    DynamicHighlightToolTipHandler highlightToolTipHandler = Original as DynamicHighlightToolTipHandler;
    if (!Object.op_Inequality((Object) highlightToolTipHandler, (Object) null))
      return;
    this.딟 = highlightToolTipHandler.딟;
    this.땄 = highlightToolTipHandler.땄;
    this.딟 = highlightToolTipHandler.딟;
  }

  protected override void Initialize()
  {
    if (Object.op_Equality((Object) this.TargetReference, (Object) null))
      return;
    if (Object.op_Inequality((Object) ((Component) this.TargetReference).transform.parent, (Object) null))
      ((Component) this.TargetReference).transform.localPosition = Vector3.op_Addition(this.딟, new Vector3(0.0f, 0.5f, 0.0f));
    else
      ((Component) this.TargetReference).transform.position = Vector3.op_Addition(this.딟, new Vector3(0.0f, 0.5f, 0.0f));
    if (this.딟 == null)
      return;
    this.딟(this.TargetReference);
  }

  protected override void OnClose()
  {
    base.OnClose();
    if (Object.op_Equality((Object) this.TargetReference, (Object) null))
      return;
    if (Object.op_Inequality((Object) ((Component) this.TargetReference).transform.parent, (Object) null))
      ((Component) this.TargetReference).transform.localPosition = this.딟;
    else
      ((Component) this.TargetReference).transform.position = this.딟;
    if (this.땄 == null)
      return;
    this.땄(this.TargetReference);
  }
}
