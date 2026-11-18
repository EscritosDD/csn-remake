// Decompiled with JetBrains decompiler
// Type: RandomAudioLoopingComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("Audio/Audio Looping Randomizer")]
public class RandomAudioLoopingComponent : RandomAudioComponent
{
  public AudioShader2 startShader;
  public AudioShader2 stopShader;
  private RandomAudioLoopingComponent.떊 딟;

  protected override void Start()
  {
    if (Object.op_Equality((Object) this.startShader, (Object) null) || Object.op_Equality((Object) this.stopShader, (Object) null) || Object.op_Equality((Object) this.Shader, (Object) null))
    {
      ((Behaviour) this).enabled = false;
    }
    else
    {
      base.Start();
      base.딟 = -1;
    }
  }

  protected override void Update()
  {
    if ((double) Time.time < (double) base.딟)
      return;
    this.AdvancePhase();
  }

  private void AdvancePhase()
  {
    this.딟 = base.딟 != -1 ? (base.딟 != this.땄 ? RandomAudioLoopingComponent.떊.땄 : RandomAudioLoopingComponent.떊.딧) : RandomAudioLoopingComponent.떊.딟;
    switch (this.딟)
    {
      case RandomAudioLoopingComponent.떊.딟:
        base.딟 = Time.time + this.startShader.PlayOneShot(((Component) this).gameObject);
        base.딟 = 0;
        break;
      case RandomAudioLoopingComponent.떊.땄:
        base.딟 = Time.time + this.Shader.PlayOneShot(((Component) this).gameObject);
        RandomAudioLoopingComponent loopingComponent = this;
        ((RandomAudioComponent) loopingComponent).딟 = ((RandomAudioComponent) loopingComponent).딟 + 1;
        break;
      case RandomAudioLoopingComponent.떊.딧:
        double num = (double) this.stopShader.PlayOneShot(((Component) this).gameObject);
        base.딟 = -1;
        this.StartNextLoops();
        break;
    }
  }

  private enum 떊
  {
    딟,
    땄,
    딧,
  }
}
