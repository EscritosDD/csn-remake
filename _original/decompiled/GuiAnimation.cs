// Decompiled with JetBrains decompiler
// Type: GuiAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

[Serializable]
public class GuiAnimation
{
  private ArrayList 딟 = new ArrayList();
  private ArrayList 땄 = new ArrayList();
  private ArrayList 딧 = new ArrayList();
  private bool 딟;
  public bool DelayStart;
  public float DelayStartTime;
  public float TotalAnimTime = 0.2f;
  public float StartValue;
  public float TargetValue;
  public AnimationCurve AnimStyle;

  public void 딟()
  {
    this.땄(true);
    this.딟(0.0f);
    if (!this.DelayStart)
      return;
    this.딧(0.0f);
  }

  public void 딟([In] bool obj0)
  {
    this.딟 = obj0;
    if (obj0)
    {
      this.딟(1f);
      this.딧(this.DelayStartTime);
      this.땄();
    }
    this.DelayStart = false;
    this.땄(false);
    this.딟 = false;
  }

  public void 땄()
  {
    if (!this.딧() && !this.딟)
      return;
    if (this.DelayStart || this.딟)
    {
      GuiAnimation guiAnimation = this;
      guiAnimation.딧(guiAnimation.딶() + Time.deltaTime);
      if ((double) this.딶() >= (double) this.DelayStartTime)
      {
        this.DelayStart = false;
        if (this.땄.Count > 0)
        {
          foreach (GuiAnimation.딱 딱 in this.땄)
            딱();
        }
      }
    }
    if (this.DelayStart)
      return;
    GuiAnimation guiAnimation1 = this;
    guiAnimation1.딟(guiAnimation1.딢() + Time.deltaTime / this.TotalAnimTime);
    this.딟(Mathf.Clamp(this.딢(), 0.0f, 1f));
    // ISSUE: reference to a compiler-generated method
    this.땄(Mathf.Lerp(this.StartValue, this.TargetValue, this.AnimStyle.Evaluate(this.딢())));
    if (this.딧 != null && this.딧.Count > 0)
    {
      foreach (GuiAnimation.때 때 in this.딧)
        때(this.땃());
    }
    if ((double) this.딢() != 1.0)
      return;
    this.땄(false);
    if (this.딟.Count <= 0)
      return;
    foreach (GuiAnimation.땂 땂 in this.딟)
      땂();
  }

  public void 딟([In] GuiAnimation.땂 obj0) => this.딟.Add((object) obj0);

  public void 딟([In] GuiAnimation.딱 obj0) => this.땄.Add((object) obj0);

  public void 딟([In] GuiAnimation.때 obj0, [In] bool obj1)
  {
    this.딧.Add((object) obj0);
    if (!obj1)
      return;
    obj0(0.0f);
  }

  [CompilerGenerated]
  [SpecialName]
  public bool 딧() => this.땄;

  [CompilerGenerated]
  [SpecialName]
  public void 땄([In] bool obj0) => this.땄 = obj0;

  [CompilerGenerated]
  [SpecialName]
  public float 딢() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public void 딟([In] float obj0) => this.딟 = obj0;

  [CompilerGenerated]
  [SpecialName]
  public float 땃() => this.땄;

  [CompilerGenerated]
  [SpecialName]
  public float 딶() => this.딧;

  [CompilerGenerated]
  [SpecialName]
  public void 딧([In] float obj0) => this.딧 = obj0;

  public delegate void 땂();

  public delegate void 딱();

  public delegate void 때([In] float obj0);
}
