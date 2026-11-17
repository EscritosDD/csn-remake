// Decompiled with JetBrains decompiler
// Type: BigBenAudioComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using UnityEngine;

[AddComponentMenu("Audio/BigBen")]
public class BigBenAudioComponent : MonoBehaviour
{
  private float 딟;
  private int 딟;
  private int 땄;
  public bool PlayOnStart;
  public AudioShader2 PreambleSound;
  public AudioShader2 Sound;

  private void Start()
  {
    if (!this.PlayOnStart)
      return;
    this.땄 = 59;
  }

  private void FixedUpdate()
  {
    DateTime now = DateTime.Now;
    if (now.Minute < this.땄)
    {
      this.딟 = now.Hour % 12;
      if (this.딟 == 0)
        this.딟 = 12;
      float num = 0.0f;
      if (Object.op_Inequality((Object) this.PreambleSound, (Object) null))
        num = this.PreambleSound.PlayOneShot(((Component) this).gameObject);
      this.딟 = Time.time + num;
    }
    this.땄 = now.Minute;
    if (this.딟 <= 0 || (double) Time.time < (double) this.딟)
      return;
    --this.딟;
    float num1 = 0.0f;
    if (Object.op_Inequality((Object) this.Sound, (Object) null))
      num1 = this.Sound.PlayOneShot(((Component) this).gameObject);
    this.딟 = Time.time + num1;
  }
}
