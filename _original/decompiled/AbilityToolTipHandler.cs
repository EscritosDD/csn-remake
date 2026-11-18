// Decompiled with JetBrains decompiler
// Type: AbilityToolTipHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class AbilityToolTipHandler : ToolTipHandler
{
  public TooltipAnimationHandler tooltipAnimation;

  public void Display(AbilityTooltipInfo tooltipInfo, bool force)
  {
    this.tooltipAnimation.HeaderText.LocText = tooltipInfo.headerText;
    this.tooltipAnimation.ToolTipText.LocText = tooltipInfo.messageText;
    this.Type = tooltipInfo.type;
    this.Display(force, (Transform) null);
  }
}
