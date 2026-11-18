// Decompiled with JetBrains decompiler
// Type: AudioShader2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

[AddComponentMenu("Audio/Audio Shader 2")]
[RequireComponent(typeof (AudioSource))]
public class AudioShader2 : MonoBehaviour
{
  private int 딟;
  private GameObject 딟;
  public AudioClip[] Clips;
  public float MinVolume = 1f;
  public float MaxVolume = 1f;
  public float MinPitch = 1f;
  public float MaxPitch = 1f;
  public float ChanceToPlay = 1f;
  public bool NoRepeat = true;
  public bool IsMusic;
  public 딧.땸 Type;
  public bool ShouldDuckAmbientSoundWhilePlaying;
  public float DuckingDuration;
  public float DuckingAttackTime;
  public float DuckingReleaseTime;
  public float DuckingDepth;
  private static float 딟 = 1f;
  private static float 땄 = 1f;
  private static AudioShader2.땬 딟;

  [SpecialName]
  [MethodImpl(MethodImplOptions.Synchronized)]
  public static void 딟([In] AudioShader2.땬 obj0) => AudioShader2.딟 += obj0;

  [SpecialName]
  [MethodImpl(MethodImplOptions.Synchronized)]
  public static void 땄([In] AudioShader2.땬 obj0) => AudioShader2.딟 -= obj0;

  private void OnDestroy()
  {
    AudioShader2.딟 -= new AudioShader2.땬(this.OnShaderVolumeChanged);
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    AudioShaderList component = this.딟.GetComponent<AudioShaderList>();
    if (!Object.op_Inequality((Object) component, (Object) null))
      return;
    component.get_ActiveShaders().Remove(this);
  }

  public float PlayOneShot(GameObject target, float delay) => this.PlayOneShot(target, false, delay);

  public float PlayOneShot(GameObject target, bool attachToTarget, float delay) => this.PlayOneShot(target, attachToTarget, delay, out AudioShader2 _);

  public float PlayOneShot(GameObject target, float delay, out AudioShader2 audioShaderOut) => this.PlayOneShot(target, false, delay, out audioShaderOut);

  public float PlayOneShot(
    GameObject target,
    bool attachToTarget,
    float delay,
    out AudioShader2 audioShaderOut)
  {
    audioShaderOut = (AudioShader2) null;
    if (this.Clips == null || this.Clips.Length == 0 || Object.op_Equality((Object) target, (Object) null) || (double) Random.value > (double) this.ChanceToPlay)
      return 0.0f;
    AudioClip randomClip = this.GetRandomClip();
    if (Object.op_Equality((Object) randomClip, (Object) null))
    {
      Debug.LogWarning((object) ("Empty clip at Index " + (object) this.딟 + " on " + ((Object) ((Component) this).gameObject).name));
      return 0.0f;
    }
    AudioShader2 audioShader2 = Object.Instantiate((Object) this) as AudioShader2;
    audioShader2.SetTarget(target);
    // ISSUE: reference to a compiler-generated method
    audioShader2.set_ActiveVolume(Mathf.Lerp(this.MinVolume, this.MaxVolume, Random.value));
    audioShader2.OnShaderVolumeChanged();
    audioShaderOut = audioShader2;
    GameObject gameObject = ((Component) audioShader2).gameObject;
    if (attachToTarget)
    {
      gameObject.transform.parent = target.transform;
      gameObject.transform.localPosition = Vector3.zero;
    }
    else
      gameObject.transform.position = target.transform.position;
    gameObject.audio.pitch = Mathf.Lerp(this.MinPitch, this.MaxPitch, Random.value);
    gameObject.audio.clip = randomClip;
    AudioShader2.딟 += new AudioShader2.땬(audioShader2.OnShaderVolumeChanged);
    ulong num = (ulong) (44100.0 / (double) randomClip.frequency * ((double) randomClip.samples / (double) randomClip.length) * (double) delay);
    gameObject.audio.Play(num);
    Object.Destroy((Object) gameObject, randomClip.length);
    if (GlobalAppData.딟 != null && 딶.딡.땴() != null)
    {
      if (((Component) this).tag == "AmbientSoundSource")
        딶.딡.땴().딟.AddAmbientSoundSource(gameObject);
      if (this.ShouldDuckAmbientSoundWhilePlaying && (double) this.DuckingDuration > 0.0)
        딶.딡.땴().딟.DuckAmbientSound(this.DuckingDepth, this.DuckingDuration, this.DuckingAttackTime, this.DuckingReleaseTime);
    }
    return randomClip.length;
  }

  public float PlayOneShot(GameObject target) => this.PlayOneShot(target, 0.0f);

  public GameObject PlayLooping(GameObject target) => this.PlayLooping(target, float.MaxValue, -1f, -1f);

  public GameObject PlayLooping(GameObject target, bool attachToTarget) => this.PlayLooping(target, attachToTarget, float.MaxValue, -1f, -1f);

  public GameObject PlayLooping(
    GameObject target,
    float maxLength,
    float fadeStartTime,
    float fadeDuration)
  {
    return this.PlayLooping(target, false, maxLength, fadeStartTime, fadeDuration);
  }

  public GameObject PlayLooping(
    GameObject target,
    bool attachToTarget,
    float maxLength,
    float fadeStartTime,
    float fadeDuration)
  {
    if (this.Clips == null || this.Clips.Length == 0 || Object.op_Equality((Object) target, (Object) null))
      return (GameObject) null;
    if ((double) Random.value > (double) this.ChanceToPlay)
      return (GameObject) null;
    AudioClip randomClip = this.GetRandomClip();
    if (Object.op_Equality((Object) randomClip, (Object) null))
    {
      Debug.LogWarning((object) ("Empty clip at Index " + (object) this.딟 + " on " + ((Object) ((Component) this).gameObject).name));
      return (GameObject) null;
    }
    AudioShader2 SoundToFade = Object.Instantiate((Object) this) as AudioShader2;
    SoundToFade.SetTarget(target);
    // ISSUE: reference to a compiler-generated method
    SoundToFade.set_ActiveVolume(Mathf.Lerp(this.MinVolume, this.MaxVolume, Random.value));
    SoundToFade.OnShaderVolumeChanged();
    GameObject gameObject = ((Component) SoundToFade).gameObject;
    if (attachToTarget)
    {
      gameObject.transform.parent = target.transform;
      gameObject.transform.localPosition = Vector3.zero;
    }
    else
      gameObject.transform.position = target.transform.position;
    gameObject.audio.pitch = Mathf.Lerp(this.MinPitch, this.MaxPitch, Random.value);
    gameObject.audio.clip = randomClip;
    gameObject.audio.loop = true;
    gameObject.audio.Play();
    AudioShader2.딟 += new AudioShader2.땬(SoundToFade.OnShaderVolumeChanged);
    if ((double) fadeStartTime >= 0.0)
      딶.딡.땴().딟.AddSoundToFade(SoundToFade, fadeStartTime, fadeDuration);
    else if ((double) maxLength > 0.0)
      Object.Destroy((Object) gameObject, maxLength);
    else if ((double) maxLength != 3.40282346638529E+38)
      Object.Destroy((Object) gameObject, 10f);
    return gameObject;
  }

  private void SetTarget(GameObject Target)
  {
    this.딟 = Target;
    AudioShaderList audioShaderList = ((Component) this).GetComponent<AudioShaderList>();
    if (Object.op_Equality((Object) audioShaderList, (Object) null))
      audioShaderList = ((Component) this).gameObject.AddComponent<AudioShaderList>();
    audioShaderList.get_ActiveShaders().Add(this);
  }

  public static void 딟([In] GameObject obj0, [In] 딧.땸 obj1)
  {
    if (Object.op_Equality((Object) obj0, (Object) null))
      return;
    AudioShaderList component1 = obj0.GetComponent<AudioShaderList>();
    if (Object.op_Equality((Object) component1, (Object) null))
      return;
    List<AudioShader2> audioShader2List = (List<AudioShader2>) null;
    foreach (AudioShader2 audioShader2 in component1.get_ActiveShaders())
    {
      if (audioShader2.Type == obj1)
      {
        if (audioShader2List == null)
          audioShader2List = new List<AudioShader2>();
        audioShader2List.Add(audioShader2);
      }
    }
    if (audioShader2List == null)
      return;
    foreach (Component component2 in audioShader2List)
      Object.Destroy((Object) component2.gameObject);
  }

  private AudioClip GetRandomClip()
  {
    int index = Random.Range(0, this.Clips.Length);
    if (this.NoRepeat && index == this.딟 && this.Clips.Length > 1)
      index = (index + Random.Range(1, this.Clips.Length)) % this.Clips.Length;
    AudioClip clip = this.Clips[index];
    this.딟 = index;
    return clip;
  }

  public static bool 딟([In] AudioShader2 obj0) => Object.op_Inequality((Object) obj0, (Object) null) && Object.op_Inequality((Object) ((Component) obj0).audio, (Object) null) && ((Component) obj0).audio.isPlaying;

  public float GetMaxLength()
  {
    float num = 0.0f;
    for (int index = 0; index < this.Clips.Length; ++index)
    {
      if (Object.op_Inequality((Object) this.Clips[index], (Object) null))
        num = this.Clips[index].length;
    }
    return num;
  }

  private void OnShaderVolumeChanged()
  {
    if (this.IsMusic && AudioShader2.땃())
    {
      ((Component) this).audio.volume = 0.0f;
    }
    else
    {
      float num = !this.IsMusic ? AudioShader2.땓() : AudioShader2.딶();
      ((Component) this).audio.volume = this.get_ActiveVolume() * num;
    }
  }

  public static void 딟()
  {
    AudioShader2.땄 = PlayerPrefs.GetFloat("GameVolume", 1f);
    AudioShader2.딟 = PlayerPrefs.GetFloat("MusicVolume", 1f);
    AudioShader2.딧();
  }

  public static void 땄()
  {
    PlayerPrefs.SetFloat("GameVolume", AudioShader2.땄);
    PlayerPrefs.SetFloat("MusicVolume", AudioShader2.딟);
  }

  private static void 딧()
  {
    if (AudioShader2.딟 == null)
      return;
    AudioShader2.딟();
  }

  public static void 딢()
  {
    bool flag = AudioShader2.땃();
    // ISSUE: reference to a compiler-generated method
    AudioShader2.딟(딟.딶.딟());
    if (flag == AudioShader2.땃())
      return;
    AudioShader2.딧();
  }

  public void UpdateActiveVolume(float NewActiveVolume)
  {
    // ISSUE: reference to a compiler-generated method
    this.set_ActiveVolume(NewActiveVolume);
    this.OnShaderVolumeChanged();
  }

  [CompilerGenerated]
  [SpecialName]
  public float get_ActiveVolume() => this.딧;

  [CompilerGenerated]
  [SpecialName]
  public static bool 땃() => AudioShader2.딟;

  [SpecialName]
  public static float 딶() => AudioShader2.딟;

  [SpecialName]
  public static void 딟([In] float obj0)
  {
    AudioShader2.딟 = obj0;
    AudioShader2.딧();
  }

  [SpecialName]
  public static float 땓() => AudioShader2.땄;

  [SpecialName]
  public static void 땄([In] float obj0)
  {
    AudioShader2.땄 = obj0;
    AudioShader2.딧();
  }

  public delegate void 땬();
}
