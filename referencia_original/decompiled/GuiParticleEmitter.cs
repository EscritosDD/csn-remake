// Decompiled with JetBrains decompiler
// Type: GuiParticleEmitter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using UnityEngine;

public class GuiParticleEmitter : MonoBehaviour
{
  private bool 딟;
  public int MaxParticles;
  public int NumParticlesToInitailisePerTick;
  public float TickInitailiseDelay;
  public bool bSpawnWithRandomYRotation;
  public bool bFadeParticleOverLife;
  public GameObject ParticlePrefab;
  public Vector3 ParticleAcceleration;
  public Vector3 MinParticleLaunchVelocity;
  public Vector3 MaxParticleLaunchVelocity;
  public bool bClampParticlesY;
  public bool bLoopEmitter;
  public float ParticleKillPlane;
  public float MinParticleLife;
  public float MaxParticleLife;
  private GuiParticleEmitter.땩[] 딟;
  private float 딟;
  private int 딟;
  private int 땄;

  public void ActivatePaticleEmitter()
  {
    // ISSUE: reference to a compiler-generated method
    this.set_bPaticleEmitterActive(true);
    this.딟 = true;
    this.땄 = 0;
    this.딟 = new GuiParticleEmitter.땩[this.MaxParticles];
  }

  public void StopParticleEmitter() => this.딟 = false;

  public void KillParticleEmitter()
  {
    if (this.딟 != null)
    {
      for (int index = 0; index < this.딟.Length; ++index)
      {
        if (this.딟[index].딟)
        {
          this.딟[index].딟 = false;
          Object.Destroy((Object) this.딟[index].딟);
          this.딟[index].딟 = (GameObject) null;
        }
      }
    }
    this.딟 = (GuiParticleEmitter.땩[]) null;
    // ISSUE: reference to a compiler-generated method
    this.set_bPaticleEmitterActive(false);
    this.딟 = false;
  }

  public void InitailiseParticles(int NumToCreate)
  {
    for (int index = 0; index < NumToCreate; ++index)
      this.IntailiseParticle();
  }

  private void IntailiseParticle()
  {
    if (this.딟 == null || this.딟 >= this.MaxParticles)
      return;
    this.딟[this.딟].딟 = Object.Instantiate((Object) this.ParticlePrefab) as GameObject;
    this.ResetParticle(this.딟);
    ++this.딟;
  }

  private void ResetParticle(int Index)
  {
    if (this.딟 == null || Index >= this.딟.Length)
      return;
    this.딟[Index].딟 = true;
    this.딟[Index].딟.SetActive(true);
    this.딟[Index].딟 = ((Component) this).transform.position;
    this.딟[Index].땄 = new Vector3((float) (this.MinParticleLaunchVelocity.x + (this.MaxParticleLaunchVelocity.x - this.MinParticleLaunchVelocity.x) * (double) Random.value), !this.bClampParticlesY ? (float) (this.MinParticleLaunchVelocity.y + (this.MaxParticleLaunchVelocity.y - this.MinParticleLaunchVelocity.y) * (double) Random.value) : 0.0f, (float) (this.MinParticleLaunchVelocity.z + (this.MaxParticleLaunchVelocity.x - this.MinParticleLaunchVelocity.x) * (double) Random.value));
    this.딟[Index].딟 = 0.0f;
    this.딟[Index].땄 = this.MinParticleLife + (this.MaxParticleLife - this.MinParticleLife) * Random.value;
    if (!this.bSpawnWithRandomYRotation)
      return;
    Quaternion localRotation = this.딟[Index].딟.transform.localRotation;
    Vector3 eulerAngles = ((Quaternion) ref localRotation).eulerAngles;
    eulerAngles.y = (__Null) (360.0 * (double) Random.value);
    this.딟[Index].딟.transform.localRotation = Quaternion.Euler(eulerAngles);
  }

  private void Update()
  {
    if (!this.get_bPaticleEmitterActive())
      return;
    if (this.딟)
      this.UpdateParticleInitialisationStep();
    this.UpdateParticles();
  }

  private void UpdateParticleInitialisationStep()
  {
    if (this.딟 >= this.MaxParticles)
      return;
    this.딟 += Time.deltaTime;
    if ((double) this.딟 <= (double) this.TickInitailiseDelay)
      return;
    int NumToCreate = this.NumParticlesToInitailisePerTick;
    if (NumToCreate + this.딟 > this.MaxParticles)
      NumToCreate = this.MaxParticles - this.딟;
    this.InitailiseParticles(NumToCreate);
    this.딟 = 0.0f;
  }

  private void UpdateParticles()
  {
    if (this.딟 == null)
      return;
    for (int Index = 0; Index < this.딟.Length; ++Index)
    {
      if (this.딟[Index].딟)
      {
        ref GuiParticleEmitter.땩 local1 = ref this.딟[Index];
        local1.땄 = Vector3.op_Addition(local1.땄, Vector3.op_Multiply(this.ParticleAcceleration, Time.deltaTime));
        ref GuiParticleEmitter.땩 local2 = ref this.딟[Index];
        local2.딟 = Vector3.op_Addition(local2.딟, Vector3.op_Multiply(this.딟[Index].땄, Time.deltaTime));
        this.딟[Index].딟.transform.localPosition = this.딟[Index].딟;
        this.딟[Index].딟 += Time.deltaTime;
        if (this.bFadeParticleOverLife && (double) this.딟[Index].땄 != -1.0 && (double) this.딟[Index].땄 != 0.0)
        {
          float num = (float) (1.0 - (double) this.딟[Index].딟 / (double) this.딟[Index].땄);
          this.딟[Index].딟.renderer.material.color = new Color((float) this.딟[Index].딟.renderer.material.color.r, (float) this.딟[Index].딟.renderer.material.color.g, (float) this.딟[Index].딟.renderer.material.color.b, num);
        }
        if ((double) this.ParticleKillPlane != -10.0 && this.딟[Index].딟.z < (double) this.ParticleKillPlane || (double) this.딟[Index].땄 != -1.0 && (double) this.딟[Index].딟 > (double) this.딟[Index].땄)
        {
          this.딟[Index].딟 = false;
          this.딟[Index].딟.SetActive(false);
          if (this.bLoopEmitter)
          {
            this.ResetParticle(Index);
          }
          else
          {
            ++this.땄;
            Object.Destroy((Object) this.딟[Index].딟);
            this.딟[Index].딟 = (GameObject) null;
            if (this.땄 >= this.딟.Length)
            {
              this.딟 = (GuiParticleEmitter.땩[]) null;
              // ISSUE: reference to a compiler-generated method
              this.set_bPaticleEmitterActive(false);
              this.딟 = false;
              break;
            }
          }
        }
      }
    }
  }

  public bool IsParticleSystemDead()
  {
    if (this.딟 != null)
    {
      for (int index = 0; index < this.딟.Length; ++index)
      {
        if (this.딟[index].딟)
          return false;
      }
    }
    return true;
  }

  [CompilerGenerated]
  [SpecialName]
  public bool get_bPaticleEmitterActive() => this.땄;

  private struct 땩
  {
    public Vector3 딟;
    public Vector3 땄;
    public GameObject 딟;
    public bool 딟;
    public float 딟;
    public float 땄;
  }
}
