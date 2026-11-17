// Decompiled with JetBrains decompiler
// Type: AudioController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using 딧;

public class AudioController : MonoBehaviour
{
  private List<GameObject> 딟;
  private List<float> 딟;
  private bool 딟;
  private float 딟;
  private float 땄;
  private float 딧 = 0.4f;
  private float 딢 = 0.4f;
  private float 땃 = 0.1f;
  private float 딶 = 0.1f;
  private string 딟 = "AmbientSoundSource";
  private List<딬> 딟;

  public void UpdateAudio()
  {
    if ((double) this.딟 > 0.0 || (double) this.땄 != 0.0)
    {
      this.InitAmbientSoundSources();
      this.딟 -= Time.deltaTime;
      if ((double) this.딟 - (double) this.딶 > 0.0)
        this.땄 += 1f / this.땃 * Time.deltaTime;
      else
        this.땄 -= 1f / this.딶 * Time.deltaTime;
      this.땄 = Mathf.Clamp01(this.땄);
      if ((double) this.딧 != (double) this.딢)
      {
        if ((double) this.딧 > (double) this.딢)
        {
          this.딧 -= this.땃 * Time.deltaTime;
          this.딧 = Mathf.Max(this.딧, this.딢);
        }
        else
        {
          this.딧 += this.땃 * Time.deltaTime;
          this.딧 = Mathf.Min(this.딧, this.딢);
        }
      }
      for (int index = 0; index < this.딟.Count; ++index)
      {
        if (Object.op_Equality((Object) this.딟[index], (Object) null) || Object.op_Equality((Object) this.딟[index].audio, (Object) null))
        {
          this.딟.RemoveAt(index);
          this.딟.RemoveAt(index);
          --index;
        }
        else
          this.딟[index].GetComponent<AudioShader2>().UpdateActiveVolume(this.딟[index] - this.땄 * this.딧);
      }
    }
    for (int index = 0; index < this.딟.Count; ++index)
    {
      딬 딬 = this.딟[index];
      딬.딢 += Time.deltaTime;
      if ((double) 딬.딢 > (double) 딬.딟)
      {
        float num = 딬.딢 - 딬.딟;
        float NewActiveVolume = Mathf.Lerp(딬.딧, 0.0f, num / 딬.땄);
        딬.딟.UpdateActiveVolume(NewActiveVolume);
        if ((double) NewActiveVolume == 0.0)
          this.딟.RemoveAt(index--);
      }
    }
  }

  public void Init()
  {
    this.딟 = new List<GameObject>();
    this.딟 = new List<float>();
    this.딟 = new List<딬>();
  }

  private void InitAmbientSoundSources()
  {
    if (this.딟)
      return;
    this.딟 = true;
    GameObject[] gameObjectsWithTag = GameObject.FindGameObjectsWithTag(this.딟);
    for (int index = 0; index < gameObjectsWithTag.Length; ++index)
    {
      AudioShader2 component = gameObjectsWithTag[index].GetComponent<AudioShader2>();
      if (!Object.op_Equality((Object) component, (Object) null))
      {
        this.딟.Add(gameObjectsWithTag[index]);
        this.딟.Add(component.get_ActiveVolume());
      }
    }
  }

  public void DuckAmbientSound(float Depth, float Duration, float AttackTime, float ReleaseTime)
  {
    this.딟 = Mathf.Max(Duration + AttackTime + ReleaseTime, this.딟);
    this.딢 = Depth;
    if ((double) this.땄 == 0.0)
      this.딧 = this.딢;
    this.땃 = AttackTime;
    this.딶 = ReleaseTime;
  }

  public void AddAmbientSoundSource(GameObject NewAmbientSoundSource)
  {
    if (!Object.op_Inequality((Object) NewAmbientSoundSource.audio, (Object) null))
      return;
    this.딟.Add(NewAmbientSoundSource);
    this.딟.Add(NewAmbientSoundSource.audio.volume);
  }

  public void AddSoundToFade(AudioShader2 SoundToFade, float FadeStartTime, float FadeDuration)
  {
    if (!Object.op_Inequality((Object) ((Component) SoundToFade).audio, (Object) null))
      return;
    this.딟.Add(new 딬(SoundToFade, FadeStartTime, FadeDuration, ((Component) SoundToFade).audio.volume));
  }
}
