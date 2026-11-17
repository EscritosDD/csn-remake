// Decompiled with JetBrains decompiler
// Type: AmbientAudioComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("Audio/AmbientAudioComponent")]
public class AmbientAudioComponent : MonoBehaviour
{
  public float Delay;
  public AudioShader2 Sound;
  public bool attachToGameObject;

  private void Start()
  {
    if (!Object.op_Inequality((Object) this.Sound, (Object) null) || !Object.op_Inequality((Object) ((Component) this.Sound).audio, (Object) null))
      return;
    this.Sound.PlayLooping(((Component) this).gameObject, this.attachToGameObject);
  }
}
