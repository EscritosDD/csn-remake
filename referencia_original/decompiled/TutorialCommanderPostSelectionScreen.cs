// Decompiled with JetBrains decompiler
// Type: TutorialCommanderPostSelectionScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class TutorialCommanderPostSelectionScreen : BaseMenuHandler
{
  private GameObject 딟;
  private 땓.떀 딟;
  private bool 딟;
  public float DelayBetweenToolTips;
  public 딢.땿 Timer = new 딢.땿();
  public ParticleSystem StarBurst;
  public GameObject SpawnPoint;
  public GameObject Camera;
  public TutorialTooltipScheduler Tooltips;
  public TutorialDaveScreenHandler DaveScreen;
  public AudioShader2 CommanderUnlockSound;

  private void Start() => base.딟 = ((Component) this).transform.position;

  public override void DeactivateMenu()
  {
    base.DeactivateMenu();
    if (Object.op_Inequality((Object) this.딟, (Object) null))
    {
      Object.Destroy((Object) this.딟);
      this.딟 = (GameObject) null;
    }
    this.딟 = false;
    this.Camera.SetActive(false);
  }

  public override void ActivateMenu() => this.ActivateMenu(true);

  public void ActivateMenu(bool Restart)
  {
    base.ActivateMenu();
    this.딟 = new 땓.떀(-1, GlobalAppData.땽().땝());
    GlobalAppData.땼().딟((땓.딲) this.딟, 땓.땾.딟);
    this.딟 = true;
    this.Camera.SetActive(true);
    if (Restart)
      this.Tooltips.Restart();
    this.Timer.딟(this.DelayBetweenToolTips);
    this.StarBurst.Play();
    double num = (double) this.CommanderUnlockSound.PlayOneShot(((Component) this).gameObject);
  }

  private void Update()
  {
    if (!this.딟)
      return;
    this.Timer.딟();
    if (!((딟.딗) GlobalAppData.땼()).땽() && Object.op_Equality((Object) this.딟, (Object) null))
    {
      this.딟.땠();
      this.딟 = new GameObject();
      this.딟.transform.parent = this.SpawnPoint.transform;
      this.딟.transform.localPosition = Vector3.zero;
      this.딟.transform.localRotation = Quaternion.identity;
      UnitTesterComponent.딟(this.딟.transform, this.딟.딣(), this.딟.딛(), this.딟.땷(), (UnitVoicePack) null, (Material) null, this.딟.딛().딟((딶.땖) null, 땓.딺.딟), 0);
    }
    if (!this.Timer.땄())
      return;
    if (!this.Tooltips.AdvanceTooltip())
    {
      this.DeactivateMenu();
      this.DaveScreen.ActivateMenu();
    }
    this.Timer.딟(this.DelayBetweenToolTips);
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (TutorialCommanderPostSelectionScreen.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      TutorialCommanderPostSelectionScreen.딟 = new Dictionary<string, int>(1)
      {
        {
          "Advance",
          0
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!TutorialCommanderPostSelectionScreen.딟.TryGetValue(key, out num) || num != 0 || (double) this.Timer.딧() >= (double) this.DelayBetweenToolTips - 1.0)
      return;
    if (!this.Tooltips.AdvanceTooltip())
    {
      this.DeactivateMenu();
      this.DaveScreen.ActivateMenu();
    }
    this.Timer.딟(this.DelayBetweenToolTips);
  }
}
