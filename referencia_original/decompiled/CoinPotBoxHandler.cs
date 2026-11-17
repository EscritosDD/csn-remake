// Decompiled with JetBrains decompiler
// Type: CoinPotBoxHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class CoinPotBoxHandler : MonoBehaviour
{
  public GuiText3D CoinBalanceText;
  public GuiAnimation CoinPotGrowAnim;
  public GuiParticleEmitter CoinsFallEmitter;
  public Animation PotAnim;
  public Animation ChestAnim;
  public AudioShader2 CoinSound;
  private int 딟;
  private int 땄;
  private 땓.땹 딟;
  private float 딟;
  private float 땄;

  public void InitailiseCoinValueData() => this.InitailiseCoinValueData(딶.딡.땴().땼());

  public void InitailiseCoinValueData(딶.땖 State) => this.InitailiseCoinValueData(State.때());

  private void InitailiseCoinValueData(int CoinValue)
  {
    if (!Object.op_Inequality((Object) this.CoinBalanceText, (Object) null))
      return;
    this.CoinBalanceText.Text = CoinValue.ToString();
    this.CoinBalanceText.UpdateMesh();
  }

  public void StopAnims()
  {
    if (Object.op_Inequality((Object) this.CoinsFallEmitter, (Object) null))
      this.CoinsFallEmitter.KillParticleEmitter();
    if (Object.op_Inequality((Object) this.PotAnim, (Object) null))
      this.PotAnim.Stop();
    if (!Object.op_Inequality((Object) this.ChestAnim, (Object) null))
      return;
    this.ChestAnim.Stop();
  }

  public void Skip()
  {
    if (Object.op_Inequality((Object) this.CoinsFallEmitter, (Object) null))
      this.CoinsFallEmitter.KillParticleEmitter();
    if (Object.op_Inequality((Object) this.PotAnim, (Object) null))
      this.SkipToEnd("ChestShow");
    if (Object.op_Inequality((Object) this.ChestAnim, (Object) null))
      this.SkipToEnd("ChestGrow");
    if ((this.딟 == 땓.땹.땄 || this.딟 == 땓.땹.딧 || this.딟 == 땓.땹.딢) && !this.PotAnim.IsPlaying("ChestHide"))
      this.PotAnim.Play("ChestHide");
    this.딟 = 땓.땹.땃;
  }

  private void SkipToEnd(string AnimName)
  {
    if (!this.PotAnim.IsPlaying(AnimName))
      return;
    this.PotAnim[AnimName].enabled = true;
    this.PotAnim[AnimName].normalizedTime = 1f;
    this.PotAnim.Sample();
    this.PotAnim[AnimName].enabled = true;
  }

  private void Update()
  {
    switch (this.딟)
    {
      case 땓.땹.땄:
        if (this.PotAnim.IsPlaying("ChestDeploy"))
          break;
        this.ChestAnim.Play("ChestBounce");
        this.딟 = 땓.땹.딧;
        break;
      case 땓.땹.딧:
        this.딟 = this.ChestAnim.GetClip("ChestGrow").length - 1f;
        this.ChestAnim.Play("ChestGrow");
        double num = (double) this.CoinSound.PlayOneShot(((Component) this).gameObject);
        this.CoinsFallEmitter.ActivatePaticleEmitter();
        this.딟 = 땓.땹.딢;
        break;
      case 땓.땹.딢:
        if (!this.ChestAnim.IsPlaying("ChestGrow"))
        {
          this.딟 = 땓.땹.땃;
          this.PotAnim.Play("ChestHide");
          this.InitailiseCoinValueData(this.딟 + this.땄);
          break;
        }
        this.땄 += Time.deltaTime;
        int CoinValue = Mathf.Clamp(this.딟 + Mathf.RoundToInt(this.땄 / this.딟 * (float) this.땄), 0, this.딟 + this.땄);
        this.InitailiseCoinValueData(CoinValue);
        if (CoinValue != this.딟 + this.땄)
          break;
        this.CoinsFallEmitter.StopParticleEmitter();
        break;
      case 땓.땹.땃:
        if (this.PotAnim.IsPlaying("ChestHide"))
          break;
        this.딟 = 땓.땹.딟;
        break;
    }
  }

  public bool IsActive() => this.딟 != 땓.땹.딟;

  public void Show()
  {
    if (딶.딡.땴() == null)
      return;
    딶.땖 땖 = 딶.딡.땴().땼();
    this.딟 = 0;
    this.땄 = 0.0f;
    if (땖.땭() != null)
      this.딟 = 땖.땞().GenericData.딶(땖.땭().딢());
    this.땄 = 땖.땞().GenericData.딶(땖.떂().딢()) - this.딟;
    if (this.땄 <= 0)
      return;
    ((Component) this).gameObject.SetActive(true);
    this.InitailiseCoinValueData(this.딟);
    if (!Object.op_Inequality((Object) this.PotAnim, (Object) null))
      return;
    this.PotAnim.Play("ChestShow");
    this.딟 = 땓.땹.땄;
  }
}
