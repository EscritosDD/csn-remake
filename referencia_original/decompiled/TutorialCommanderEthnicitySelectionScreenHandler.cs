// Decompiled with JetBrains decompiler
// Type: TutorialCommanderEthnicitySelectionScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class TutorialCommanderEthnicitySelectionScreenHandler : BaseMenuHandler
{
  private 땓.떀[] 딟;
  private 땓.떀[] 땄;
  private 땓.떀[] 딧;
  private string[] 딟;
  private GameObject 딟;
  private int 딟;
  public GuiText3D NameText;
  public GuiText3D ClassNameText;
  public string[] MaleCommanderAvatarIds;
  public string[] MaleCommanderIds;
  public string MaleCommanderWeaponId;
  public string MaleCommanderAnim;
  public string[] FemaleCommanderAvatarIds;
  public string[] FemaleCommanderIds;
  public string FemaleCommanderWeaponId;
  public string FemaleCommanderAnim;
  public TutorialCommanderSelectionButton[] Buttons;
  public TutorialCommanderSelectionScreenHandler GenderSelectionScreen;
  public TutorialCommanderPostSelectionScreen PostSelectionScreen;
  public GameObject Camera;
  public GameObject SpawnPoint;

  private void Start()
  {
    base.딟 = ((Component) this).transform.position;
    this.딟 = new 땓.떀[this.MaleCommanderIds.Length];
    for (int index = 0; index < this.MaleCommanderIds.Length; ++index)
    {
      string maleCommanderId = this.MaleCommanderIds[index];
      this.딟[index] = new 땓.떀(-1, maleCommanderId);
      this.딟[index].딟(this.MaleCommanderWeaponId);
      GlobalAppData.땼().딟((땓.딲) this.딟[index], 땓.땾.딟);
    }
    this.땄 = new 땓.떀[this.FemaleCommanderIds.Length];
    for (int index = 0; index < this.FemaleCommanderIds.Length; ++index)
    {
      string femaleCommanderId = this.FemaleCommanderIds[index];
      this.땄[index] = new 땓.떀(-1, femaleCommanderId);
      this.땄[index].딟(this.FemaleCommanderWeaponId);
      GlobalAppData.땼().딟((땓.딲) this.땄[index], 땓.땾.딟);
    }
  }

  public override void DeactivateMenu()
  {
    base.DeactivateMenu();
    this.Camera.SetActive(false);
    this.DestroyModel();
  }

  public void ActivateMenu(땓.딽 Gender)
  {
    this.ActivateMenu();
    this.딧 = Gender != 땓.딽.딟 ? this.땄 : this.딟;
    this.딟 = Gender != 땓.딽.딟 ? this.FemaleCommanderAvatarIds : this.MaleCommanderAvatarIds;
    int num = Mathf.Min(this.Buttons.Length, this.딧.Length);
    for (int Index = 0; Index < num; ++Index)
    {
      this.딧[Index].땠();
      this.Buttons[Index].Init(this.딧[Index], Index);
    }
    this.Camera.SetActive(true);
    this.딟 = -1;
    this.SetActiveCommanderIndex(0);
  }

  private void SetActiveCommanderIndex(int Index)
  {
    this.딟 = Index;
    this.DestroyModel();
    this.딟 = new GameObject();
    this.딟.transform.parent = this.SpawnPoint.transform;
    this.딟.transform.localPosition = Vector3.zero;
    this.딟.transform.localRotation = Quaternion.identity;
    땓.떀 떀 = this.딧[this.딟];
    UnitTesterComponent.딟(this.딟.transform, 떀.딣(), 떀.딛(), 떀.땷(), (UnitVoicePack) null, (Material) null, 떀.딛().딟((딶.땖) null, 땓.딺.딟), 0);
    for (int index = 0; index < this.Buttons.Length; ++index)
      this.Buttons[index].UpdateState(index == this.딟);
    this.NameText.Text = 떀.땹();
    this.NameText.UpdateMesh();
    this.ClassNameText.LocText = 떀.땁().ClassName;
    this.ClassNameText.UpdateMesh();
  }

  private void DestroyModel()
  {
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    Object.Destroy((Object) this.딟);
    this.딟 = (GameObject) null;
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (TutorialCommanderEthnicitySelectionScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      TutorialCommanderEthnicitySelectionScreenHandler.딟 = new Dictionary<string, int>(2)
      {
        {
          "Back",
          0
        },
        {
          "Accept",
          1
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!TutorialCommanderEthnicitySelectionScreenHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        this.DeactivateMenu();
        this.GenderSelectionScreen.ActivateMenu(false);
        break;
      case 1:
        땓.떀 떀 = this.딧[this.딟];
        딢.떇 떇 = new 딢.떇(true);
        떇.딦(떀.떔());
        if (this.딟 < this.딟.Length)
        {
          string str = "avatar://" + this.딟[this.딟];
          떇.땓(str);
        }
        GlobalAppData.딟(떇);
        GlobalAppData.땽().땄(false);
        this.DeactivateMenu();
        this.PostSelectionScreen.ActivateMenu(true);
        break;
    }
  }

  private void OnCharacterSelected(int Index) => this.SetActiveCommanderIndex(Index);
}
