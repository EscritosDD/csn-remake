// Decompiled with JetBrains decompiler
// Type: LevelAudioEvents
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class LevelAudioEvents : MonoBehaviour
{
  public void StartAudio()
  {
    foreach (Component component in ((Component) this).transform)
    {
      AudioSource audio = component.audio;
      if (Object.op_Inequality((Object) audio, (Object) null))
        audio.Play();
    }
  }

  public void StopAudio()
  {
    foreach (Component component in ((Component) this).transform)
    {
      AudioSource audio = component.audio;
      if (Object.op_Inequality((Object) audio, (Object) null))
        audio.Stop();
    }
  }

  public void ToggleAudio()
  {
    foreach (Component component in ((Component) this).transform)
    {
      AudioSource audio = component.audio;
      if (Object.op_Inequality((Object) audio, (Object) null))
      {
        if (audio.isPlaying)
          audio.Stop();
        else
          audio.Play();
      }
    }
  }
}
