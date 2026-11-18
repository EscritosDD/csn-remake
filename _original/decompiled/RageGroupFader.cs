// Decompiled with JetBrains decompiler
// Type: RageGroupFader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

[RequireComponent(typeof (RageGroup))]
public class RageGroupFader : MonoBehaviour
{
  private RageGroup 딟;
  public bool OnStart;
  public float Delay;
  public float FadeDuration;
  private float 딟;
  private float 땄;
  private float 딧;
  private float 딢;

  public void Awake() => this.딟 = ((Component) this).GetComponent<RageGroup>();

  public void Start()
  {
    if (!this.OnStart)
      return;
    this.Fade();
  }

  public void Fade()
  {
    if (Object.op_Equality((Object) this.딟, (Object) null))
      this.딟 = ((Component) this).GetComponent<RageGroup>();
    this.땄 = Time.time + this.Delay;
    this.딧 = this.땄 + this.FadeDuration;
  }

  public void Update()
  {
    this.딟 = Time.time;
    if ((double) this.딟 < (double) this.땄 || (double) this.딧 < (double) this.딟)
      return;
    this.딢 = this.딟 - this.땄;
    this.SetGroupTransparency(1f - Mathf.InverseLerp(this.땄, this.딧, this.딢));
  }

  private void SetGroupTransparency(float fadeFactor)
  {
    foreach (RageGroupElement rageGroupElement in this.딟.get_List())
    {
      Color color = rageGroupElement.Spline.땟().GetFillColor1();
      color.a = (__Null) (color.a * (double) fadeFactor);
      rageGroupElement.Spline.땟().SetFillColor1(color);
      color = rageGroupElement.Spline.땟().GetFillColor2();
      color.a = (__Null) (color.a * (double) fadeFactor);
      rageGroupElement.Spline.땟().SetFillColor2(color);
      color = rageGroupElement.Spline.땟().GetOutlineColor1();
      color.a = (__Null) (color.a * (double) fadeFactor);
      rageGroupElement.Spline.땟().SetOutlineColor1(color);
      color = rageGroupElement.Spline.땟().GetOutlineColor2();
      color.a = (__Null) (color.a * (double) fadeFactor);
      rageGroupElement.Spline.땟().SetOutlineColor2(color);
      rageGroupElement.Spline.땟().RefreshMesh(false, false, false);
    }
  }
}
