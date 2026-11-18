// Decompiled with JetBrains decompiler
// Type: ControlPointObjectiveComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class ControlPointObjectiveComponent : MonoBehaviour
{
  private bool[] 딟;
  private bool[] 땄 = new bool[2];
  private Animation 딟;
  private GameObject 딟;
  private Renderer[] 딟;
  public GameObject ModelPrefab;
  public GameObject SkeletonPrefab;
  public string IntroAnimName;
  public AudioShader2 OwnTeamEnterSound;
  public AudioShader2 OtherTeamEnterSound;
  public AudioShader2 BothTeamsEnterSound;
  private 딶.땟 딟;
  private Color 딟;
  private float 딟;
  private int 딟;
  private Vector3 딟;

  public void Init(GameObject SpawnPoint)
  {
    this.딟 = Object.Instantiate((Object) this.SkeletonPrefab, SpawnPoint.transform.position, SpawnPoint.transform.rotation) as GameObject;
    this.딟 = this.딟.GetComponentInChildren<Animation>();
    this.PlayIdleAnim();
    땓.딯.딟(this.딟, this.ModelPrefab);
    this.딟 = this.딟.GetComponentsInChildren<Renderer>();
    this.딟 = this.딟.transform.localPosition;
  }

  public void UpdateActiveZones(bool[] ActiveZones, int Team)
  {
    this.땄 = this.딟;
    this.딟 = ActiveZones;
    this.딟 = Team;
  }

  public void SetObjectiveModelVisible(bool visible)
  {
    if (visible)
      this.딟.transform.localPosition = this.딟;
    else
      this.딟.transform.localPosition = new Vector3(-10000f, -10000f, -10000f);
  }

  private void Update()
  {
    this.UpdateFlagState();
    this.UpdateFlagColors();
    this.UpdateFlagSounds();
  }

  private void UpdateFlagColors()
  {
    Color color = GlobalAppData.딟.GameAssets.ControlPointDefault;
    if (this.딟[0] != this.딟[1])
      color = !this.딟[0] ? GlobalAppData.딟.GameAssets.Red : GlobalAppData.딟.GameAssets.Blue;
    this.딟 = Color.Lerp(this.딟, color, 0.5f * Time.deltaTime);
    foreach (Renderer renderer in this.딟)
      renderer.material.color = this.딟;
  }

  private void UpdateFlagState()
  {
    if ((double) this.딟 > (double) Time.time)
      return;
    if (!this.딟[0] && !this.딟[1])
    {
      if (this.딟 == 딶.땟.딟)
        return;
      this.SendFlagDown();
    }
    else if (this.딟 == 딶.땟.딟)
    {
      this.SendFlagUp();
    }
    else
    {
      if (this.딟 != 딶.땟.땄)
        return;
      this.SetFlagIdle();
    }
  }

  private void UpdateFlagSounds()
  {
    if (this.땄[0] != this.딟[0] || this.땄[1] != this.딟[1])
    {
      int index = this.딟 != 1 ? 1 : 0;
      if (this.딟[this.딟] && !this.딟[index])
      {
        if (Object.op_Inequality((Object) this.OwnTeamEnterSound, (Object) null))
        {
          double num1 = (double) this.OwnTeamEnterSound.PlayOneShot(((Component) this).gameObject);
        }
      }
      else if (this.딟[this.딟] && this.딟[index])
      {
        if (Object.op_Inequality((Object) this.BothTeamsEnterSound, (Object) null))
        {
          double num2 = (double) this.BothTeamsEnterSound.PlayOneShot(((Component) this).gameObject);
        }
      }
      else if (!this.딟[this.딟] && this.딟[index] && Object.op_Inequality((Object) this.OtherTeamEnterSound, (Object) null))
      {
        double num3 = (double) this.OtherTeamEnterSound.PlayOneShot(((Component) this).gameObject);
      }
    }
    this.땄 = this.딟;
  }

  public void PlayIntroAnim()
  {
    this.SetObjectiveModelVisible(true);
    AnimationClip clip = this.딟.GetClip(this.IntroAnimName);
    if (Object.op_Inequality((Object) clip, (Object) null))
      this.딟 = Time.time + clip.length;
    this.딟.wrapMode = (WrapMode) 1;
    this.딟.Play(this.IntroAnimName, (PlayMode) 4);
    this.딟 = 딶.땟.딟;
  }

  public void PlayIdleAnim()
  {
    if (Object.op_Inequality((Object) this.딟.GetClip("Idle"), (Object) null))
    {
      this.딟.wrapMode = (WrapMode) 2;
      this.딟.Play("Idle", (PlayMode) 4);
    }
    this.딟 = 딶.땟.딟;
  }

  private void SetFlagIdle()
  {
    AnimationClip clip = this.딟.GetClip("Idle");
    if (Object.op_Inequality((Object) clip, (Object) null))
      this.딟 = Time.time + clip.length;
    this.딟.wrapMode = (WrapMode) 2;
    this.딟.Play("Idle", (PlayMode) 4);
    this.딟 = 딶.땟.딧;
  }

  private void SendFlagUp()
  {
    AnimationClip clip = this.딟.GetClip("FlagOut");
    if (Object.op_Inequality((Object) clip, (Object) null))
      this.딟 = Time.time + clip.length;
    this.딟.wrapMode = (WrapMode) 1;
    this.딟.Play("FlagOut", (PlayMode) 4);
    this.딟 = 딶.땟.땄;
  }

  private void SendFlagDown()
  {
    AnimationClip clip = this.딟.GetClip("FlagIn");
    if (Object.op_Inequality((Object) clip, (Object) null))
      this.딟 = Time.time + clip.length;
    this.딟.wrapMode = (WrapMode) 1;
    this.딟.Play("FlagIn", (PlayMode) 4);
    this.딟 = 딶.땟.딟;
  }
}
