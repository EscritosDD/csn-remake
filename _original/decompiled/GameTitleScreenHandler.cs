// Decompiled with JetBrains decompiler
// Type: GameTitleScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class GameTitleScreenHandler : BaseHUDScreenHandler
{
  public Camera GameCamera;
  public Material BackgroundBlue;
  public Material BackgroundRed;
  public GameObject Background;
  public Camera BackgroundCamera;
  public GuiText3D PlayerOneNameText;
  public GuiText3D PlayerTwoNameText;
  public SquadTeamRosterList PlayerOneTeamList;
  public SquadTeamRosterList PlayerTwoTeamList;
  public MapNameScreenHandler MapNameScreen;
  public Camera CommanderCamera;
  public GameObject PlayerOneCommanderSpawn;
  public GameObject PlayerTwoCommanderSpawn;
  private bool 딟;

  public override void InitailiseScreenData()
  {
    Vector3 ScreenSize = Vector3.one;
    BoxCollider component = ((Component) this).GetComponent<BoxCollider>();
    this.get_Game().딟(false);
    bool InDeploymentMode = this.get_Game().딟() && !땓.땞.딧(this.get_Game().땼());
    if (Object.op_Inequality((Object) component, (Object) null))
      ScreenSize = component.size;
    if (Object.op_Inequality((Object) this.Background, (Object) null))
      this.Background.renderer.sharedMaterial = this.get_Game().땼().떂().땃() != 0 ? this.BackgroundRed : this.BackgroundBlue;
    if (Object.op_Inequality((Object) this.PlayerOneNameText, (Object) null))
    {
      this.PlayerOneNameText.Text = this.get_Game().땼().딟.딟[0];
      this.PlayerOneNameText.UpdateMesh();
    }
    if (Object.op_Inequality((Object) this.PlayerOneTeamList, (Object) null))
      this.PlayerOneTeamList.SetTeamRoster(this.get_Game().땼(), 딶.땂.딟, ScreenSize, InDeploymentMode);
    if (Object.op_Inequality((Object) this.PlayerTwoNameText, (Object) null))
    {
      this.PlayerTwoNameText.Text = this.get_Game().땼().딟.딟[1];
      this.PlayerTwoNameText.UpdateMesh();
    }
    if (Object.op_Inequality((Object) this.PlayerTwoTeamList, (Object) null))
      this.PlayerTwoTeamList.SetTeamRoster(this.get_Game().땼(), 딶.땂.땄, ScreenSize, InDeploymentMode);
    this.LoadCommanders();
    ((Component) this.CommanderCamera).gameObject.SetActive(true);
  }

  private void LoadCommanders() => this.딟 = true;

  private void SpawnCommanders()
  {
    딶.땖 땖 = this.get_Game().땼();
    for (int index1 = 0; index1 < 2; ++index1)
    {
      foreach (int index2 in 땖.딧(index1))
      {
        땓.떀 Commander = 땖.땻()[index2] as 땓.떀;
        if (Commander.땁().ClassType == 땓.땅.땃)
        {
          if (index1 == 0)
          {
            this.SetCommanderOnSpawnPoint(this.PlayerOneCommanderSpawn, Commander, 딶.땂.딟);
            break;
          }
          this.SetCommanderOnSpawnPoint(this.PlayerTwoCommanderSpawn, Commander, 딶.땂.땄);
          break;
        }
      }
    }
  }

  private void SetCommanderOnSpawnPoint(GameObject SpawnPoint, 땓.떀 Commander, 딶.땂 CurrTeam)
  {
    if (!Object.op_Inequality((Object) SpawnPoint, (Object) null) || Commander == null)
      return;
    GameObject gameObject = new GameObject();
    UnitTesterComponent.딟(gameObject.transform, Commander.딣(), Commander.딛(), Commander.땷(), Commander.땔(), (Material) null, Commander.딛().딟((딶.땖) null, 땓.딺.딟), CurrTeam != 딶.땂.딟 ? 1 : 0);
    gameObject.transform.parent = SpawnPoint.transform;
    gameObject.transform.localPosition = Vector3.zero;
    gameObject.transform.localRotation = Quaternion.Euler(0.0f, CurrTeam != 딶.땂.딟 ? 45f : 315f, 0.0f);
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (GameTitleScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      GameTitleScreenHandler.딟 = new Dictionary<string, int>(1)
      {
        {
          "Resume",
          0
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!GameTitleScreenHandler.딟.TryGetValue(key, out num) || num != 0)
      return;
    this.StartGame();
  }

  private void StartGame()
  {
    this.get_Game().딷().딧();
    ((Component) this.CommanderCamera).gameObject.SetActive(false);
    this.PlayerOneCommanderSpawn.SetActive(false);
    this.PlayerTwoCommanderSpawn.SetActive(false);
    ((Component) this.BackgroundCamera).gameObject.SetActive(false);
    this.Background.SetActive(false);
    AudioListener component = ((Component) this.UICamera).GetComponent<AudioListener>();
    if (Object.op_Inequality((Object) component, (Object) null))
      ((Behaviour) component).enabled = false;
    ((Component) this.GameCamera).gameObject.SetActive(true);
    this.get_Game().딟(false, false);
    if (this.get_Game().딟() && !this.get_Game().땼().딷())
    {
      if (this.get_Game().땼().떔() is 딶.딖)
        this.get_Game().딷().딟(딶.딨.딧);
      else
        this.get_Game().딷().딟(딶.딨.땃);
      this.MapNameScreen.ActivateMenu();
    }
    else
      this.get_Game().딷().딣();
    ((Component) this).gameObject.SetActive(false);
  }

  private void Update()
  {
    if (!this.딟 || ((딟.딗) GlobalAppData.땼()).땽())
      return;
    this.딟 = false;
    this.SpawnCommanders();
  }
}
