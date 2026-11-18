// Decompiled with JetBrains decompiler
// Type: TutorialDaveScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class TutorialDaveScreenHandler : BaseMenuHandler
{
  private GameObject 딟;
  private 땓.떀 딟;
  private bool 딟;
  private 딢.딳.땝 딟;
  private float 딟;
  public float DelayBetweenToolTips;
  public 딢.땿 Timer = new 딢.땿();
  public string CharacterId;
  public GameObject SpawnPoint;
  public GameObject Camera;
  public TutorialTooltipScheduler Tooltips;
  public FakeLoadingScreen LoadingScreen;
  public float CharacterLoadDelay;
  public GameObject DaveArrow;
  public GameObject DaveText;
  public AudioShader2 DaveAudio;
  public ParticleSystem StarBurst;

  private void Start()
  {
    base.딟 = ((Component) this).transform.position;
    this.딟 = new 땓.떀(-1, this.CharacterId);
    GlobalAppData.땼().딟((땓.딲) this.딟, 땓.땾.딟);
  }

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
    this.딟 = true;
    this.Camera.SetActive(true);
    this.딟 = Time.time + this.CharacterLoadDelay;
    if (Restart)
      this.Tooltips.Restart();
    this.Timer.딟(this.DelayBetweenToolTips);
  }

  private void Update()
  {
    if (this.딟)
    {
      this.Timer.딟();
      if (!((딟.딗) GlobalAppData.땼()).땽() && Object.op_Equality((Object) this.딟, (Object) null) && (double) Time.time > (double) this.딟)
      {
        this.DaveArrow.SetActive(true);
        this.DaveText.SetActive(true);
        this.딟.땠();
        this.딟 = new GameObject();
        this.딟.transform.parent = this.SpawnPoint.transform;
        this.딟.transform.localPosition = Vector3.zero;
        this.딟.transform.localRotation = Quaternion.identity;
        UnitTesterComponent.딟(this.딟.transform, this.딟.딣(), this.딟.딛(), this.딟.땷(), (UnitVoicePack) null, (Material) null, this.딟.딛().딟((딶.땖) null, 땓.딺.딟), 0);
        double num = (double) this.DaveAudio.PlayOneShot(((Component) this).gameObject);
        this.StarBurst.Play();
      }
      if (this.Timer.땄())
      {
        if (!this.Tooltips.AdvanceTooltip())
          this.StartTutorial();
        this.Timer.딟(this.DelayBetweenToolTips);
      }
    }
    if (this.딟 == null || !this.딟.땄())
      return;
    딶.땖 GameToLoad = this.딟.딟();
    this.딟 = (딢.딳.땝) null;
    this.DeactivateMenu();
    this.LoadingScreen.ActivateMenu(GameToLoad, true);
  }

  private void StartTutorial()
  {
    GlobalAppData.딟(true);
    this.딟 = 딢.딳.딟(new List<땓.떀>(), new List<땓.떀>(), 0, GlobalAppData.딟.TutorialLevelId, GlobalAppData.딟.TutorialLevelScenario);
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (TutorialDaveScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      TutorialDaveScreenHandler.딟 = new Dictionary<string, int>(1)
      {
        {
          "Advance",
          0
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!TutorialDaveScreenHandler.딟.TryGetValue(key, out num) || num != 0 || Object.op_Equality((Object) this.딟, (Object) null) || (double) this.StarBurst.time < (double) this.StarBurst.duration || (double) this.Timer.딧() >= (double) this.DelayBetweenToolTips - 1.0)
      return;
    if (!this.Tooltips.AdvanceTooltip())
      this.StartTutorial();
    this.Timer.딟(this.DelayBetweenToolTips);
  }
}
