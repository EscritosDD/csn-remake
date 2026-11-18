// Decompiled with JetBrains decompiler
// Type: TutorialCommanderSelectionScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class TutorialCommanderSelectionScreenHandler : BaseMenuHandler
{
  private GameObject 딟;
  private 땓.떀 딟;
  private GameObject 땄;
  private 땓.떀 땄;
  private bool 딟;
  public float DelayBetweenToolTips;
  public GameObject MaleSpawnPoint;
  public GameObject FemaleSpawnPoint;
  public string MaleCommanderId;
  public string MaleCommanderWeaponId;
  public string FemaleCommanderId;
  public string FemaleCommanderWeaponId;
  public GameObject[] TitleTextObjects;
  public GameObject LogoObject;
  public GameObject SpinnerObject;
  public GameObject Camera;
  public 딢.땿 Timer = new 딢.땿();
  public TutorialCommanderEthnicitySelectionScreenHandler EthnicitySelectionScreen;
  public TutorialTooltipScheduler Tooltips;

  private void Start()
  {
    base.딟 = ((Component) this).transform.position;
    this.딟 = new 땓.떀(-1, this.MaleCommanderId);
    this.딟.딟(this.MaleCommanderWeaponId);
    GlobalAppData.땼().딟((땓.딲) this.딟, 땓.땾.딟);
    this.땄 = new 땓.떀(-1, this.FemaleCommanderId);
    this.땄.딟(this.FemaleCommanderWeaponId);
    GlobalAppData.땼().딟((땓.딲) this.땄, 땓.땾.딟);
  }

  public override void DeactivateMenu()
  {
    base.DeactivateMenu();
    if (Object.op_Inequality((Object) this.딟, (Object) null))
    {
      Object.Destroy((Object) this.딟);
      this.딟 = (GameObject) null;
    }
    if (Object.op_Inequality((Object) this.땄, (Object) null))
    {
      Object.Destroy((Object) this.땄);
      this.땄 = (GameObject) null;
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
    if (Restart)
    {
      this.Tooltips.Restart();
      this.UpdateLoadingObjects(true);
    }
    this.Timer.딟(this.DelayBetweenToolTips);
  }

  private void UpdateLoadingObjects(bool IsLoading)
  {
    foreach (GameObject titleTextObject in this.TitleTextObjects)
      titleTextObject.SetActive(!IsLoading);
    this.LogoObject.SetActive(IsLoading);
    this.SpinnerObject.SetActive(IsLoading);
  }

  private void Update()
  {
    if (!this.딟)
      return;
    this.Timer.딟();
    if (!((딟.딗) GlobalAppData.땼()).땽())
    {
      bool flag = false;
      if (Object.op_Equality((Object) this.딟, (Object) null))
      {
        this.딟.땠();
        this.딟 = new GameObject();
        this.딟.transform.parent = this.MaleSpawnPoint.transform;
        this.딟.transform.localPosition = Vector3.zero;
        this.딟.transform.localRotation = Quaternion.identity;
        UnitTesterComponent.딟(this.딟.transform, this.딟.딣(), this.딟.딛(), this.딟.땷(), (UnitVoicePack) null, (Material) null, this.딟.딛().딟((딶.땖) null, 땓.딺.딟), 0);
        flag = true;
      }
      if (Object.op_Equality((Object) this.땄, (Object) null))
      {
        this.땄.땠();
        this.땄 = new GameObject();
        this.땄.transform.parent = this.FemaleSpawnPoint.transform;
        this.땄.transform.localPosition = Vector3.zero;
        this.땄.transform.localRotation = Quaternion.identity;
        UnitTesterComponent.딟(this.땄.transform, this.땄.딣(), this.땄.딛(), this.땄.땷(), (UnitVoicePack) null, (Material) null, this.땄.딛().딟((딶.땖) null, 땓.딺.딟), 0);
        flag = true;
      }
      if (flag)
        this.UpdateLoadingObjects(false);
    }
    if (!this.Timer.땄())
      return;
    this.Tooltips.AdvanceTooltip();
    this.Timer.딟(this.DelayBetweenToolTips);
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (TutorialCommanderSelectionScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      TutorialCommanderSelectionScreenHandler.딟 = new Dictionary<string, int>(3)
      {
        {
          "Male",
          0
        },
        {
          "Female",
          1
        },
        {
          "Advance",
          2
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!TutorialCommanderSelectionScreenHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        this.DeactivateMenu();
        this.EthnicitySelectionScreen.ActivateMenu(땓.딽.딟);
        break;
      case 1:
        this.DeactivateMenu();
        this.EthnicitySelectionScreen.ActivateMenu(땓.딽.땄);
        break;
      case 2:
        if ((double) this.Timer.딧() >= (double) this.DelayBetweenToolTips - 1.0)
          break;
        this.Tooltips.AdvanceTooltip();
        this.Timer.딟(this.DelayBetweenToolTips);
        break;
    }
  }
}
