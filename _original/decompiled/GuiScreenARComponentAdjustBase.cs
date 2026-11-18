// Decompiled with JetBrains decompiler
// Type: GuiScreenARComponentAdjustBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public abstract class GuiScreenARComponentAdjustBase : MonoBehaviour
{
  public const float 딟 = 1.5f;
  protected const float 땄 = 0.5f;
  protected const float 딧 = 0.75f;
  private bool 딟;
  private static float 딢;
  private static float 땃;
  private static List<GuiScreenARComponentAdjustBase> 딟 = new List<GuiScreenARComponentAdjustBase>();
  private static Action 딟;

  [SpecialName]
  [MethodImpl(MethodImplOptions.Synchronized)]
  public static void 딟([In] Action obj0) => GuiScreenARComponentAdjustBase.딟 += obj0;

  [SpecialName]
  [MethodImpl(MethodImplOptions.Synchronized)]
  public static void 땄([In] Action obj0) => GuiScreenARComponentAdjustBase.딟 -= obj0;

  private void Start()
  {
    if (!this.딟)
    {
      // ISSUE: reference to a compiler-generated method
      this.set_DefaultObjectPosition(((Component) this).transform.localPosition);
      // ISSUE: reference to a compiler-generated method
      this.set_DefaultObjectScale(((Component) this).transform.localScale);
      this.UpdateComponent(1.5f / ((float) Screen.width / (float) Screen.height));
      this.딟 = true;
    }
    GuiScreenARComponentAdjustBase.딟.Add(this);
  }

  private void OnDestroy() => GuiScreenARComponentAdjustBase.딟.Remove(this);

  public static void 딟()
  {
    float height = (float) Screen.height;
    float num = (float) Screen.width / height;
    if ((double) height == (double) GuiScreenARComponentAdjustBase.딢 && (double) num == (double) GuiScreenARComponentAdjustBase.땃)
      return;
    float AR = 1.5f / num;
    foreach (GuiScreenARComponentAdjustBase componentAdjustBase in GuiScreenARComponentAdjustBase.딟)
      componentAdjustBase.UpdateComponent(AR);
    GuiScreenARComponentAdjustBase.딢 = height;
    GuiScreenARComponentAdjustBase.땃 = num;
    GuiCameraAdjust.딟();
    if (GuiScreenARComponentAdjustBase.딟 == null)
      return;
    GuiScreenARComponentAdjustBase.딟();
  }

  public abstract void UpdateComponent(float AR);

  [CompilerGenerated]
  [SpecialName]
  public Vector3 get_DefaultObjectPosition() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public Vector3 get_DefaultObjectScale() => this.땄;
}
