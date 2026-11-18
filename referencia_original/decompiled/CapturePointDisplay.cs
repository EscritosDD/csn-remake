// Decompiled with JetBrains decompiler
// Type: CapturePointDisplay
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class CapturePointDisplay : MonoBehaviour
{
  private int[] 딟 = new int[2];
  public CaptutrePointBackground[] Team0CapturePoints;
  public CaptutrePointBackground[] Team1CapturePoints;
  private Animation 딟;
  public float VisibleTime;
  private bool 딟;
  public float SlideZOffset;
  public float SlideTime;
  public bool AlwaysVisible;
  private float 딟;
  private CapturePointDisplay.딳 딟;
  public float AlphaDelta;
  private 땓.땘 딟;
  private float 땄;

  public void Start()
  {
    this.딟 = (float) ((Component) this).gameObject.transform.localPosition.z;
    float num = 1.5f / ((float) Screen.width / (float) Screen.height);
    if ((double) num < 1.0)
    {
      this.딟 /= num;
      this.SlideZOffset /= num;
    }
    else
    {
      this.딟 *= num;
      this.SlideZOffset *= num;
    }
    ((Component) this).gameObject.transform.localPosition = new Vector3((float) ((Component) this).gameObject.transform.localPosition.x, (float) ((Component) this).gameObject.transform.localPosition.y, this.딟);
    this.딟 = new 땓.땘();
    this.딟 = ((Component) this).GetComponentInChildren<Animation>();
  }

  public void Show()
  {
    ((Component) this).gameObject.SetActive(true);
    if (!this.딟)
      this.딟 = CapturePointDisplay.딳.땄;
    this.딟.딧 = this.AlphaDelta;
    this.딟 = true;
    this.땄 = Time.realtimeSinceStartup;
  }

  public void Hide()
  {
    ((Component) this).gameObject.SetActive(false);
    this.딟 = false;
  }

  private void Update()
  {
    if (this.AlwaysVisible)
    {
      this.딟.딟(this.딟);
    }
    else
    {
      if (!this.딟)
        return;
      float TimeElapsed = Time.realtimeSinceStartup - this.땄;
      if (this.딟 != CapturePointDisplay.딳.땄)
        this.딟.딟(this.딟);
      if (this.딟 == CapturePointDisplay.딳.땄)
        this.UpdateShowAnim(TimeElapsed);
      else if (this.딟 == CapturePointDisplay.딳.딧)
        this.UpdateHideAnim(TimeElapsed);
      if ((double) TimeElapsed <= (double) this.VisibleTime)
        return;
      this.딟 = CapturePointDisplay.딳.딧;
    }
  }

  private void UpdateShowAnim(float TimeElapsed)
  {
    float num = Mathf.Clamp01(TimeElapsed / this.SlideTime);
    ((Component) this).gameObject.transform.localPosition = new Vector3((float) ((Component) this).gameObject.transform.localPosition.x, (float) ((Component) this).gameObject.transform.localPosition.y, this.딟 + this.SlideZOffset * num);
    if ((double) num != 1.0)
      return;
    this.딟 = CapturePointDisplay.딳.딟;
  }

  private void UpdateHideAnim(float TimeElapsed)
  {
    float num = Mathf.Clamp01((TimeElapsed - this.VisibleTime) / this.SlideTime);
    ((Component) this).gameObject.transform.localPosition = new Vector3((float) ((Component) this).gameObject.transform.localPosition.x, (float) ((Component) this).gameObject.transform.localPosition.y, (float) ((double) this.딟 + (double) this.SlideZOffset - (double) this.SlideZOffset * (double) num));
    if ((double) num != 1.0)
      return;
    this.Hide();
  }

  public void Init(딶.땖 State, 땓.땁 ZoneStatus, bool ForceUpdateBlink)
  {
    if (State == null || !ZoneStatus.딟() && !ForceUpdateBlink)
      return;
    this.UpdateBar(State, this.Team0CapturePoints, 0);
    this.UpdateBar(State, this.Team1CapturePoints, 1);
    if (this.딟 != null)
      this.딟.딟(State.딝(), ZoneStatus, this.Team0CapturePoints, this.Team1CapturePoints, this.딟);
    if (!ZoneStatus.딟() || !Object.op_Inequality((Object) this.딟, (Object) null) || this.딟.isPlaying)
      return;
    this.딟.Play();
  }

  private void UpdateBar(딶.땖 State, CaptutrePointBackground[] CapturePoints, int TeamID)
  {
    Color color = TeamID != 0 ? GlobalAppData.딟.GameAssets.Red : GlobalAppData.딟.GameAssets.Blue;
    this.딟[TeamID] = State.땄(TeamID, State.떂());
    for (int index = 0; index < CapturePoints.Length; ++index)
    {
      CapturePoints[index].딟(color);
      CapturePoints[index].딟(index < this.딟[TeamID]);
    }
  }

  private enum 딳
  {
    딟,
    땄,
    딧,
  }
}
