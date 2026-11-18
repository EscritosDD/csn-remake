// Decompiled with JetBrains decompiler
// Type: CameraAnimationWrapper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

[RequireComponent(typeof (Animation))]
[RequireComponent(typeof (Camera))]
[AddComponentMenu("Scripts/Camera/Camera Animation")]
public class CameraAnimationWrapper : MonoBehaviour
{
  public float cameraAnimationSpeed = 1f;
  public float EndZoomFraction = 0.5f;
  public Vector3 EndTargetPos = Vector3.zero;
  public AnimationClip Team0Intro;
  public AnimationClip Team1Intro;

  private void Awake()
  {
    if (!Object.op_Inequality((Object) ((Component) this).camera, (Object) null))
      return;
    ((Behaviour) ((Component) this).camera).enabled = false;
  }

  public void StopAnims()
  {
    if (Object.op_Equality((Object) ((Component) this).animation, (Object) null))
      return;
    ((Component) this).animation.Stop();
  }

  public float PlayCameraAnim(딢.땷 CameraAnim)
  {
    if (Object.op_Equality((Object) ((Component) this).animation, (Object) null))
      return 0.0f;
    ((Component) this).animation.clip = this.GetAnim(CameraAnim);
    if (Object.op_Equality((Object) ((Component) this).animation.clip, (Object) null))
      return 0.0f;
    ((Component) this).animation.wrapMode = (WrapMode) 1;
    ((Component) this).animation.Play();
    this.cameraAnimationSpeed = 1f;
    foreach (AnimationState animationState in ((Component) this).animation)
    {
      if (animationState.enabled)
        animationState.speed = this.cameraAnimationSpeed;
    }
    return ((Component) this).animation.clip.length;
  }

  public void SpeedUpCameraAnim()
  {
    if (Object.op_Equality((Object) ((Component) this).animation, (Object) null))
      return;
    this.cameraAnimationSpeed = 4f;
    foreach (AnimationState animationState in ((Component) this).animation)
    {
      if (animationState.enabled)
        animationState.speed = this.cameraAnimationSpeed;
    }
  }

  private AnimationClip GetAnim(딢.땷 CameraAnim)
  {
    switch (CameraAnim)
    {
      case 딢.땷.딟:
        return this.Team0Intro;
      case 딢.땷.땄:
        return this.Team1Intro;
      default:
        return (AnimationClip) null;
    }
  }

  public bool IsPlaying() => !Object.op_Equality((Object) ((Component) this).animation, (Object) null) && ((Component) this).animation.isPlaying;

  private void Update()
  {
    if (!Input.GetMouseButton(0) && Input.touchCount <= 0 || (double) this.cameraAnimationSpeed != 1.0)
      return;
    this.SpeedUpCameraAnim();
  }
}
