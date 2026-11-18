// Decompiled with JetBrains decompiler
// Type: GameResultOverlayHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using UnityEngine;

public class GameResultOverlayHandler : MonoBehaviour
{
  private bool 딟;
  private bool 땄;
  private 딢.땿 딟 = new 딢.땿();
  public float AnimDelay = 7f;
  public GameObject Banner;
  public GuiText3D MainText;
  public GuiText3D SubText;
  public ParticleSystem StarBurst;
  public AudioShader2 WinTheme;
  public AudioShader2 LoseTheme;
  public LocalisationEntry Victory;
  public LocalisationEntry Defeat;
  public LocalisationEntry TakeAndHold;
  public LocalisationEntry Elimination;

  private void Start()
  {
    ((Component) this.MainText).gameObject.SetActive(false);
    ((Component) this.SubText).gameObject.SetActive(false);
  }

  public void Init(딶.땖 GameState)
  {
    int num1 = GameState.땂();
    딶.떉 떉 = GameState.떔().땄(GameState);
    if (num1 == 떉.딟)
    {
      this.MainText.LocText = this.Victory;
      double num2 = (double) this.WinTheme.PlayOneShot(((Component) this).gameObject, 0.0f);
    }
    else
    {
      this.MainText.LocText = this.Defeat;
      double num3 = (double) this.LoseTheme.PlayOneShot(((Component) this).gameObject, 0.0f);
    }
    if (떉.딟 != 딶.떌.딟)
      this.SubText.LocText = 떉.딟 != 딶.떌.땄 ? this.TakeAndHold : this.Elimination;
    this.MainText.UpdateMesh();
    this.SubText.UpdateMesh();
  }

  public void Update()
  {
    this.딟.딟();
    if (this.get_IsDone() || this.Banner.animation.isPlaying)
      return;
    if (!this.딟)
    {
      ((Component) this.MainText).gameObject.SetActive(true);
      ((Component) this.MainText).animation.Play();
      if (딶.딡.땴().땼().땂() == 딶.딡.땴().땼().떔().땄(딶.딡.땴().땼()).딟)
        this.StarBurst.Play();
      this.딟 = true;
    }
    else
    {
      if (((Component) this.MainText).animation.isPlaying)
        return;
      if (!this.땄)
      {
        ((Component) this.SubText).gameObject.SetActive(true);
        ((Component) this.SubText).animation.Play();
        this.땄 = true;
        this.딟.딟(this.AnimDelay);
      }
      else
      {
        if (!this.딟.땄())
          return;
        this.set_IsDone(true);
      }
    }
  }

  [CompilerGenerated]
  [SpecialName]
  public bool get_IsDone() => this.딧;

  [CompilerGenerated]
  [SpecialName]
  public void set_IsDone(bool value) => this.딧 = value;
}
