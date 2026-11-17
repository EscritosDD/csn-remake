// Decompiled with JetBrains decompiler
// Type: PlayAnimOnEnable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class PlayAnimOnEnable : MonoBehaviour
{
  public float AnimationSpeed = 1f;
  private float 딟 = 1f;
  public Animation animationComponent;
  public string clipName;

  private void OnEnable()
  {
    if (this.animationComponent.IsPlaying(this.clipName))
      return;
    this.animationComponent.Play(this.clipName);
  }

  public void Update()
  {
    if (Mathf.Approximately(this.딟, this.AnimationSpeed))
      return;
    this.딟 = this.AnimationSpeed;
    foreach (AnimationState animationState in this.animationComponent)
      animationState.speed = this.AnimationSpeed;
  }
}
