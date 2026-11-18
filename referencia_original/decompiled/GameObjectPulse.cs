// Decompiled with JetBrains decompiler
// Type: GameObjectPulse
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class GameObjectPulse : MonoBehaviour
{
  private float 딟;
  private bool 딟;
  private bool 땄;
  private Vector3 딟;
  private float 땄;
  private Vector3 땄;
  private BoxCollider 딟;
  public float PulseTime = 0.15f;
  public float StartScale = 1f;
  public float EndScale = 0.8f;
  private float 딧 = 1f;
  public bool PulseComplete;
  private bool 딧;

  public GameObjectPulse()
  {
    this.딟 = new Vector3(1f, 1f, 1f);
    this.땄 = Time.realtimeSinceStartup;
  }

  public void Update()
  {
    if (!this.땄)
    {
      this.땄 = true;
      this.딟 = ((Component) this).gameObject.transform.localScale;
      this.딟 = ((Component) this).gameObject.GetComponent<BoxCollider>();
      this.땄 = !Object.op_Inequality((Object) this.딟, (Object) null) ? new Vector3(1f, 1f, 1f) : new Vector3((float) this.딟.size.x, (float) this.딟.size.y, (float) this.딟.size.z);
    }
    float DeltaTime = Time.realtimeSinceStartup - this.땄;
    this.땄 = Time.realtimeSinceStartup;
    if (!this.딟)
    {
      this.딟 = this.AnimatePulse(DeltaTime, this.StartScale, this.EndScale);
      this.UpdateColliderScale();
      ((Component) this).gameObject.transform.localScale = new Vector3((float) this.딟.x * this.딧, 1f, (float) this.딟.z * this.딧);
    }
    if (this.딧)
    {
      this.PulseComplete = this.AnimatePulse(DeltaTime, this.딧, this.StartScale);
      this.UpdateColliderScale();
      ((Component) this).gameObject.transform.localScale = new Vector3((float) this.딟.x * this.딧, 1f, (float) this.딟.z * this.딧);
    }
    if (!this.PulseComplete)
      return;
    if (Object.op_Inequality((Object) this.딟, (Object) null))
      this.딟.size = new Vector3((float) this.땄.x, (float) this.땄.y, (float) this.땄.z);
    Object.Destroy((Object) this);
  }

  private void UpdateColliderScale()
  {
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    Vector3 vector3;
    // ISSUE: explicit constructor call
    ((Vector3) ref vector3).\u002Ector((float) this.땄.x / this.딧, (float) this.땄.y, (float) this.땄.z / this.딧);
    this.딟.size = new Vector3((float) vector3.x, (float) vector3.y, (float) vector3.z);
  }

  public void OnButtonReleased()
  {
    this.딟 = true;
    this.딧 = true;
  }

  public void ResetPulseBackToDefault()
  {
    if (this.PulseComplete)
      return;
    this.PulseComplete = this.AnimatePulse(this.PulseTime, this.딧, this.StartScale);
    this.UpdateColliderScale();
    ((Component) this).gameObject.transform.localScale = new Vector3((float) this.딟.x * this.딧, 1f, (float) this.딟.z * this.딧);
    Object.Destroy((Object) this);
  }

  private bool AnimatePulse(float DeltaTime, float StartVal, float EndVal)
  {
    this.딟 += DeltaTime / this.PulseTime;
    this.딟 = Mathf.Clamp01(this.딟);
    this.딧 = Mathf.Lerp(StartVal, EndVal, this.딟);
    if ((double) this.딟 < 1.0)
      return false;
    this.딟 = 0.0f;
    return true;
  }
}
