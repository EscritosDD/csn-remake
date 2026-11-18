// Decompiled with JetBrains decompiler
// Type: AuthScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Gui3D/Screens/Auth Screen")]
public class AuthScreenHandler : BaseMenuHandler
{
  private 딶.땂 딟;
  private 딧.땧 딟;
  private 땓.떀[] 딟;
  private GameObject[] 딟;
  private bool 딟;
  public GuiText3D PlayerOneText;
  public GuiText3D PlayerTwoText;
  public GameObject[] AuthSpawnPoints;
  public Camera AuthCamera;

  private void Start() => base.딟 = ((Component) this).transform.position;

  public void ActivateMenu(딶.땂 Team, bool Restart, 딧.땧 LoadingInfo)
  {
    ((Component) this).transform.position = Vector3.zero;
    this.딟 = Team;
    if (Restart)
      this.딟 = LoadingInfo;
    ((Component) FrontendHub.딟.MoneyDisplay).gameObject.SetActive(false);
    ((Component) this.AuthCamera).gameObject.SetActive(true);
    if (Team == 딶.땂.딟)
    {
      ((Component) this.PlayerOneText).gameObject.SetActive(true);
      ((Component) this.PlayerTwoText).gameObject.SetActive(false);
    }
    else
    {
      ((Component) this.PlayerOneText).gameObject.SetActive(false);
      ((Component) this.PlayerTwoText).gameObject.SetActive(true);
    }
    List<딢.땥> 땥List = new List<딢.땥>((IEnumerable<딢.땥>) GlobalAppData.땼().땭());
    this.딟 = new 땓.떀[this.AuthSpawnPoints.Length];
    for (int index1 = 0; index1 < this.AuthSpawnPoints.Length; ++index1)
    {
      int index2 = Random.Range(0, 땥List.Count);
      string str = 땥List[index2].딧();
      땥List.RemoveAt(index2);
      this.딟[index1] = new 땓.떀(-1, str);
      GlobalAppData.땼().딟((땓.딲) this.딟[index1], 땓.땾.딟);
    }
    this.딟 = true;
  }

  public void Update()
  {
    if (!this.딟 || ((딟.딗) GlobalAppData.땼()).땽())
      return;
    this.딟 = false;
    this.SpawnCharacters();
  }

  public override void DeactivateMenu()
  {
    base.DeactivateMenu();
    ((Component) FrontendHub.딟.MoneyDisplay).gameObject.SetActive(true);
    ((Component) this.AuthCamera).gameObject.SetActive(false);
    this.ClearCharacters();
  }

  private void SpawnCharacters()
  {
    this.ClearCharacters();
    if (this.딟 == null)
      return;
    this.딟 = new GameObject[this.딟.Length];
    for (int index = 0; index < this.딟.Length; ++index)
    {
      this.딟[index] = new GameObject();
      땓.떀 떀 = this.딟[index];
      떀.땠();
      GameObject gameObject = this.딟[index];
      UnitTesterComponent.딟(gameObject.transform, 떀.딣(), 떀.딛(), 떀.땷(), 떀.땔(), (Material) null, 떀.딛().딟((딶.땖) null, 땓.딺.딟), this.딟 != 딶.땂.딟 ? 1 : 0);
      gameObject.transform.parent = this.AuthSpawnPoints[index].transform;
      gameObject.transform.localPosition = Vector3.zero;
      gameObject.transform.localRotation = Quaternion.identity;
    }
  }

  private void ClearCharacters()
  {
    if (this.딟 == null)
      return;
    for (int index = 0; index < this.딟.Length; ++index)
      Object.Destroy((Object) this.딟[index]);
    this.딟 = (GameObject[]) null;
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (AuthScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      AuthScreenHandler.딟 = new Dictionary<string, int>(1)
      {
        {
          "Continue",
          0
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!AuthScreenHandler.딟.TryGetValue(key, out num) || num != 0)
      return;
    딧.땧 LoadingInfo = this.딟.딟();
    this.DeactivateMenu();
    FrontendHub.딟.CommanderAbilityScreen.TryActivateMenu(this.딟, LoadingInfo, (BaseMenuHandler) this);
  }
}
