// Decompiled with JetBrains decompiler
// Type: RandomAudioComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[AddComponentMenu("Audio/Audio Randomizer")]
public class RandomAudioComponent : MonoBehaviour
{
  protected float 딟;
  protected int 딟;
  protected int 땄;
  public AudioShader2 Shader;
  public float MinTimeToWait = 60f;
  public float MaxTimeToWait = 90f;
  public int MinLoopsBeforeDelay;
  public int MaxLoopsBeforeDelay;
  public float MinDelayTime = 60f;
  public float MaxDelayTime = 90f;
  public bool ResetOnActivity;
  public bool attachToGameObject;
  private static List<RandomAudioComponent> 딟 = new List<RandomAudioComponent>();

  private void Awake() => RandomAudioComponent.딟(this);

  private void OnDestroy() => RandomAudioComponent.땄(this);

  protected virtual void Start() => this.StartNextLoops();

  protected virtual void StartNextLoops()
  {
    this.딟 = Time.time + Random.Range(this.MinDelayTime, this.MaxDelayTime);
    this.땄 = Random.Range(this.MinLoopsBeforeDelay, this.MaxLoopsBeforeDelay + 1);
  }

  protected virtual void Update()
  {
    if ((double) Time.time < (double) this.딟)
      return;
    if (Object.op_Inequality((Object) this.Shader, (Object) null))
    {
      double num = (double) this.Shader.PlayOneShot(((Component) this).gameObject, this.attachToGameObject, 0.0f);
    }
    ++this.딟;
    if (this.딟 == this.땄)
    {
      this.딟 = 0;
      this.StartNextLoops();
    }
    else
      this.딟 = Time.time + Random.Range(this.MinTimeToWait, this.MaxTimeToWait);
  }

  public void OnActionAdded()
  {
    if (!this.ResetOnActivity)
      return;
    this.StartNextLoops();
  }

  private static void 딟([In] RandomAudioComponent obj0) => RandomAudioComponent.딟.Add(obj0);

  private static void 땄([In] RandomAudioComponent obj0) => RandomAudioComponent.딟.Remove(obj0);

  public static void 딟()
  {
    for (int index = 0; index < RandomAudioComponent.딟.Count; ++index)
      RandomAudioComponent.딟[index].OnActionAdded();
  }
}
