// Decompiled with JetBrains decompiler
// Type: UnitAudioEvents
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using UnityEngine;

[AddComponentMenu("Scripts/Units/Audio Events")]
public class UnitAudioEvents : MonoBehaviour
{
  public void PlayWeaponFire() => this.OnAnimEvent(딶.땮.딟);

  public void PlayWeaponCock() => this.OnAnimEvent(딶.땮.땄);

  public void PlayFootstep() => this.OnAnimEvent(딶.땮.딧);

  public void PlayFoley() => this.OnAnimEvent(딶.땮.딢);

  public void PlaySwish() => this.OnAnimEvent(딶.땮.땃);

  public void PlayBodyFall() => this.OnAnimEvent(딶.땮.딶);

  public void PlayWeaponDrop() => this.OnAnimEvent(딶.땮.땓);

  public void PlayHit() => this.OnAnimEvent(딶.땮.땺);

  public void PlayInteract() => this.OnAnimEvent(딶.땮.땥);

  public void PlayThrow() => this.OnAnimEvent(딶.땮.딝);

  public void PlayBulletBy() => this.OnAnimEvent(딶.땮.땭);

  public void PlayProjectileBy() => this.OnAnimEvent(딶.땮.딷);

  public void PlayDeath() => this.OnAnimEvent(딶.땮.딦);

  public void PlayPain() => this.OnAnimEvent(딶.땮.땤);

  public void PlayExertion() => this.OnAnimEvent(딶.땮.땋);

  public void PlayAppreciation() => this.OnAnimEvent(딶.땮.땽);

  public void PlayApreciation() => this.OnAnimEvent(딶.땮.땽);

  public void PlayIdle() => this.OnAnimEvent(딶.땮.땲);

  public void PlayFiring() => this.OnAnimEvent(딶.땮.떏);

  public void PlayUpset() => this.OnAnimEvent(딶.땮.땼);

  public void PlaySneaking() => this.OnAnimEvent(딶.땮.땢);

  public void PlayDeploy1() => this.OnAnimEvent(딶.땮.떁);

  public void PlayDeploy2() => this.OnAnimEvent(딶.땮.땟);

  public void PlayDeploy3() => this.OnAnimEvent(딶.땮.땂);

  public void PlayRecover1() => this.OnAnimEvent(딶.땮.딱);

  public void PlayRecover2() => this.OnAnimEvent(딶.땮.때);

  public void PlayRecover3() => this.OnAnimEvent(딶.땮.땩);

  public void PlayDisable() => this.OnAnimEvent(딶.땮.땠);

  public void PlayTurn() => this.OnAnimEvent(딶.땮.땴);

  public void PlayHit2() => this.OnAnimEvent(딶.땮.딗);

  public void PlayDeath2() => this.OnAnimEvent(딶.땮.땳);

  public void PlayDeath3() => this.OnAnimEvent(딶.땮.땻);

  public void PlayCommand() => this.OnAnimEvent(딶.땮.딥);

  public void PlayCommandReply() => this.OnAnimEvent(딶.땮.떓);

  public void PlayInitiateDeployment() => this.OnAnimEvent(딶.땮.딛);

  private void OnAnimEvent(딶.땮 EventType)
  {
    if (this.get_Controller() == null)
      return;
    this.get_Controller().딟(EventType);
  }

  [CompilerGenerated]
  [SpecialName]
  public 딧.떒 get_Controller() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public void set_Controller(딧.떒 value) => this.딟 = value;
}
