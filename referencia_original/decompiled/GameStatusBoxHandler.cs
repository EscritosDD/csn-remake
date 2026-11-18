// Decompiled with JetBrains decompiler
// Type: GameStatusBoxHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class GameStatusBoxHandler : MonoBehaviour
{
  public GameObject Team1GameStateFillBarScale;
  public GameObject Team1GameStateFillBarBlock;
  public GameObject Team2GameStateFillBarScale;
  public GameObject Team2GameStateFillBarBlock;
  public CaptutrePointBackground[] Team1CapturePoints;
  public CaptutrePointBackground[] Team2CapturePoints;
  public GameObject[] Team1CapturePointObjects;
  public GameObject[] Team2CapturePointObjects;
  public GameObject[] ScoreEffectPrefabs;
  public AudioShader2 ScoreSound;
  public float ScoreEffectDuration;
  private GameObject 딟;
  public float AlphaDelta;
  private int[] 딟 = new int[2];
  private 땓.땘 딟;
  private 땓.땁 딟 = new 땓.땁();
  private Animation 딟;

  public void InitailiseGameStatusBox(딶.땖 State, int Team1ID, int Team2ID) => this.InitailiseGameStatusBox(State, Team1ID, Team2ID, State.떂());

  public void InitailiseGameStatusBox(딶.땖 State, int Team1ID, int Team2ID, 딶.땙 Turn)
  {
    ((Component) this).gameObject.SetActive(true);
    if (State == null || (Team1ID < 0 || Team1ID > 1) && (Team2ID < 0 || Team2ID > 1))
      return;
    this.UpdateBar(State, Turn, this.Team1GameStateFillBarScale, this.Team1GameStateFillBarBlock, this.Team1CapturePoints, Team1ID);
    this.UpdateBar(State, Turn, this.Team2GameStateFillBarScale, this.Team2GameStateFillBarBlock, this.Team2CapturePoints, Team2ID);
    if (this.딟 == null)
      this.딟 = new 땓.땘();
    this.딟.딧 = this.AlphaDelta;
    this.딟 = ((Component) this).GetComponentInChildren<Animation>();
  }

  public void InitBlinking(
    딶.땖 State,
    bool[] ActiveZones,
    bool[] PreviousActiveZones,
    bool ForceUpdateBlink,
    bool PlayEffectInSkirmish)
  {
    if (this.딟 == null)
      return;
    int TeamIndex1 = State.딝();
    this.딟.딟(ActiveZones, PreviousActiveZones, this.딟);
    if (this.딟.딟() || ForceUpdateBlink)
    {
      this.딟.딟(TeamIndex1, ActiveZones, PreviousActiveZones, this.Team1CapturePoints, this.Team2CapturePoints, this.딟);
      if (this.딟.딟() && Object.op_Inequality((Object) this.딟, (Object) null) && !this.딟.isPlaying)
        this.딟.Play();
    }
    if (!PlayEffectInSkirmish && State.떓() != 딶.딹.땄)
    {
      if (!this.딟.딟(TeamIndex1))
        return;
      this.PlayTeamCaptureEffect(TeamIndex1);
    }
    else
    {
      if (!PlayEffectInSkirmish || State.떓() != 딶.딹.땄)
        return;
      int TeamIndex2 = TeamIndex1 != 0 ? 0 : 1;
      if (this.딟.딟(TeamIndex1))
      {
        this.PlayTeamCaptureEffect(TeamIndex1);
      }
      else
      {
        if (!this.딟.딟(TeamIndex2))
          return;
        this.PlayTeamCaptureEffect(TeamIndex2);
      }
    }
  }

  private void PlayTeamCaptureEffect(int TeamIndex)
  {
    if (!Object.op_Equality((Object) this.딟, (Object) null) || TeamIndex >= this.ScoreEffectPrefabs.Length)
      return;
    GameObject[] gameObjectArray = TeamIndex != 0 ? this.Team2CapturePointObjects : this.Team1CapturePointObjects;
    int index = Mathf.Max(0, this.딟[TeamIndex] - 1);
    if (index >= gameObjectArray.Length)
      return;
    Vector3 vector3;
    // ISSUE: explicit constructor call
    ((Vector3) ref vector3).\u002Ector((float) gameObjectArray[index].transform.position.x, (float) (gameObjectArray[index].transform.position.y + 0.100000001490116), (float) gameObjectArray[index].transform.position.z);
    this.딟 = Object.Instantiate((Object) this.ScoreEffectPrefabs[TeamIndex], vector3, Quaternion.identity) as GameObject;
    Object.Destroy((Object) this.딟, this.ScoreEffectDuration);
    double num = (double) this.ScoreSound.PlayOneShot(this.딟);
  }

  public void UpdateBlinking()
  {
    if (this.딟 == null)
      return;
    this.딟.딟(this.딟);
  }

  private void UpdateBar(
    딶.땖 State,
    딶.땙 Turn,
    GameObject FillBarScale,
    GameObject FillBarBlock,
    CaptutrePointBackground[] CapturePoints,
    int TeamID)
  {
    Color color = TeamID != 0 ? GlobalAppData.딟.GameAssets.Red : GlobalAppData.딟.GameAssets.Blue;
    if (TeamID != 0 && TeamID != 1)
      return;
    if (Object.op_Inequality((Object) FillBarScale, (Object) null))
    {
      double num1;
      if (State.딟(Turn))
      {
        num1 = 1.0;
      }
      else
      {
        float num2 = (float) (num1 = (double) Mathf.Clamp(State.딟(TeamID, Turn), 0.0f, 1f));
      }
      float num3 = (float) num1;
      FillBarScale.transform.localScale = new Vector3(num3, 1f, 1f);
      FillBarScale.SetActive(true);
      if (Object.op_Inequality((Object) FillBarBlock, (Object) null))
      {
        FillBarBlock.renderer.material.color = color;
        FillBarBlock.SetActive(true);
      }
    }
    this.딟[TeamID] = State.땄(TeamID, State.떂());
    for (int index = 0; index < CapturePoints.Length; ++index)
    {
      CapturePoints[index].딟(index < this.딟[TeamID]);
      CapturePoints[index].딟(color);
    }
  }
}
