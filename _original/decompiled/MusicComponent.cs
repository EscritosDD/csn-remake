// Decompiled with JetBrains decompiler
// Type: MusicComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof (AudioSource))]
public class MusicComponent : MonoBehaviour
{
  public float ActiveVolume;
  public bool Looping;
  public float FadeTime;
  private bool 딟;
  private float 딟;
  private float 땄;

  private void Awake()
  {
    if (this.Looping)
      ((Component) this).audio.loop = true;
    else
      ((Component) this).audio.loop = false;
    AudioShader2.딟(new AudioShader2.땬(this.OnVolumeChanged));
    this.OnVolumeChanged();
  }

  private void OnDestroy() => AudioShader2.땄(new AudioShader2.땬(this.OnVolumeChanged));

  public void SetVolume(float Volume)
  {
    this.ActiveVolume = Volume;
    this.OnVolumeChanged();
    if ((double) this.ActiveVolume > 1.40129846432482E-45)
      return;
    // ISSUE: reference to a compiler-generated method
    this.set_Stopped(true);
    ((Component) this).audio.Stop();
  }

  private void OnVolumeChanged()
  {
    if (AudioShader2.땃())
      ((Component) this).audio.volume = 0.0f;
    else
      ((Component) this).audio.volume = this.ActiveVolume * AudioShader2.딶();
  }

  public void Play()
  {
    if (((Component) this).audio.isPlaying)
      return;
    ((Component) this).audio.Play();
  }

  public bool IsPlaying() => ((Component) this).audio.isPlaying;

  public void Update()
  {
    if (!this.딟)
      return;
    this.땄 += Time.deltaTime / this.FadeTime;
    this.땄 = Mathf.Clamp01(this.땄);
    this.FadeOutSubTheme();
  }

  private void FadeOutSubTheme()
  {
    this.ActiveVolume = Mathf.Lerp(this.딟, 0.0f, this.땄);
    this.OnVolumeChanged();
    if ((double) this.ActiveVolume != 0.0)
      return;
    this.딟 = false;
    Object.Destroy((Object) ((Component) this).gameObject);
  }

  public void StartFadeOut()
  {
    this.딟 = true;
    this.딟 = this.ActiveVolume;
  }

  [CompilerGenerated]
  [SpecialName]
  public bool get_Stopped() => this.땄;
}
