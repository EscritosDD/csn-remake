// Decompiled with JetBrains decompiler
// Type: AccountInticementScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AccountInticementScreenHandler : BaseMenuHandler
{
  private bool 딟;
  private 땓.떀[] 딟;
  private GameObject[] 딟;
  private GameObject 딟;
  public GameObject CharacterLoadingSpinnerPrefab;
  public LoadingScreenOverlayHandler LoadingOverlayPrefab;
  public RecoverAccountScreenHandler RecoverScreenPrefab;
  public WeNeedYourEmailPanelHandler EmailPanelPrefab;
  public GuiTextField3D EmailTextField;
  public ErrorMessagehandler ErrorMessage;
  private 땄.딤 딟;
  public string[] CharacterIds;
  public GameObject[] CharacterSpawnPoints;
  public Camera AccountInticementCamera;
  public GameObject ConfirmButton;
  public Shader GreyscaleShader;
  public Shader ColourShader;
  private Material 딟;
  private Material 땄;

  private void Awake()
  {
    base.딟 = ((Component) this).transform.position;
    ((Component) this.AccountInticementCamera).gameObject.SetActive(false);
  }

  private void Start()
  {
    this.딟 = GlobalAppData.땲().딟(this.ConfirmButton.renderer.material, this.GreyscaleShader);
    this.땄 = GlobalAppData.땲().딟(this.ConfirmButton.renderer.material, this.ColourShader);
  }

  private void Update()
  {
    if (this.딟 && Object.op_Equality((Object) this.딟, (Object) null))
    {
      this.딟 = Object.Instantiate((Object) this.CharacterLoadingSpinnerPrefab, Vector3.op_Addition(this.CharacterSpawnPoints[0].transform.position, new Vector3(0.0f, 0.0f, 0.75f)), Quaternion.identity) as GameObject;
      this.딟.transform.localScale = new Vector3(2f, 2f, 2f);
    }
    if (this.딟 && !((딟.딗) GlobalAppData.땼()).땽())
    {
      this.딟 = false;
      this.딟.SetActive(false);
      this.SpawnCharacters();
    }
    if (this.딟 != null && this.딟.땄())
    {
      if (this.딟.딧())
      {
        Debug.LogWarning((object) " Probably want to display a confirmation pop-up at this point ");
        FrontendHub.딟.ChallengeLocationSelectionScreen.ActivateMenu();
        this.DeactivateMenu();
      }
      else if (this.딟.딟 == 딟.땑.딶)
        this.DisplayErrorMessage(this.딟.딟, ErrorMessagehandler.땶.딝);
      else if (this.딟.딟())
        this.DisplayErrorMessage(this.딟.딟, ErrorMessagehandler.땶.땽);
      else
        this.DisplayErrorMessage(this.딟.딟, ErrorMessagehandler.땶.딟);
      this.딟 = (땄.딤) null;
    }
    if (string.IsNullOrEmpty(this.EmailTextField.get_Text().ToString()))
      this.ConfirmButton.renderer.sharedMaterial = this.딟;
    else
      this.ConfirmButton.renderer.sharedMaterial = this.땄;
  }

  private void PrepareCharacterInformation()
  {
    this.딟 = new 땓.떀[this.CharacterSpawnPoints.Length];
    for (int index = 0; index < this.CharacterSpawnPoints.Length; ++index)
    {
      this.딟[index] = new 땓.떀(-1, this.CharacterIds[index]);
      GlobalAppData.땼().딟((땓.딲) this.딟[index], 땓.땾.딟);
    }
    this.딟 = true;
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
      UnitTesterComponent.딟(gameObject.transform, 떀.딣(), 떀.딛(), 떀.땷(), 떀.땔(), (Material) null, 떀.딛().딟((딶.땖) null, 땓.딺.딟), 0);
      gameObject.transform.parent = this.CharacterSpawnPoints[index].transform;
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
    if (AccountInticementScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      AccountInticementScreenHandler.딟 = new Dictionary<string, int>(3)
      {
        {
          "Submit",
          0
        },
        {
          "Later",
          1
        },
        {
          "Email",
          2
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!AccountInticementScreenHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        if (this.EmailTextField.get_Text().Length == 0)
          break;
        if (GuiComponent3D.딧((GuiComponent3D) this.EmailTextField))
          GuiComponent3D.딟((GuiComponent3D) null);
        if (this.IsEmailInvalid())
        {
          this.DisplayErrorMessage(딟.땑.딟, ErrorMessagehandler.땶.딧);
          break;
        }
        this.딟 = GlobalAppData.떏().딝(this.EmailTextField.get_Text().ToString(), (string) null);
        break;
      case 1:
        this.DeactivateMenu();
        if (this.get_InFlow())
        {
          FrontendHub.딟.BarracksScreen.ActivateMenu(딢.딩.딢, true);
          break;
        }
        FrontendHub.딟.MainScreen.ActivateMenu();
        break;
      case 2:
        Object.Instantiate((Object) this.EmailPanelPrefab);
        break;
    }
  }

  public override void ActivateMenu()
  {
    base.ActivateMenu();
    ((Component) FrontendHub.딟.MoneyDisplay).gameObject.SetActive(false);
    ((Component) this.AccountInticementCamera).gameObject.SetActive(true);
    this.PrepareCharacterInformation();
    GlobalAppData.땽().딧(딢.땹.떏);
    new Dictionary<string, string>()
    {
      {
        "numviews",
        GlobalAppData.땽().딟(딢.땹.떏).ToString()
      }
    };
    this.set_InFlow(false);
  }

  public override void DeactivateMenu()
  {
    base.DeactivateMenu();
    ((Component) this.AccountInticementCamera).gameObject.SetActive(false);
    GuiComponent3D.딟((GuiComponent3D) null);
    this.ClearCharacters();
  }

  private bool IsEmailInvalid() => this.EmailTextField.get_Text().ToString().Split('@').Length != 2;

  private void DisplayErrorMessage(딟.땑 ErrorCode, ErrorMessagehandler.땶 ErrorType) => (Object.Instantiate((Object) this.ErrorMessage) as ErrorMessagehandler).Init(ErrorType, ErrorCode);

  [CompilerGenerated]
  [SpecialName]
  public bool get_InFlow() => this.땄;

  [CompilerGenerated]
  [SpecialName]
  public void set_InFlow(bool value) => this.땄 = value;
}
