// Decompiled with JetBrains decompiler
// Type: PlayAudioComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using UnityEngine;

[AddComponentMenu("Audio/PlaySoundComponent")]
[Serializable]
public class PlayAudioComponent : MonoBehaviour
{
  public float Delay;
  public AudioShader2 Sound;

  private void Start()
  {
    if (!Object.op_Inequality((Object) this.Sound, (Object) null) || !Object.op_Inequality((Object) ((Component) this.Sound).audio, (Object) null))
      return;
    double num = (double) this.Sound.PlayOneShot(((Component) this).gameObject, this.Delay);
  }
}
