// Decompiled with JetBrains decompiler
// Type: FreeCharacterSelectionScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FreeCharacterSelectionScreenHandler : BaseMenuHandler
{
  private int 딟;
  private bool 딟;
  private bool 땄;
  private 땓.떀[] 딟;
  private GameObject 딟;
  private LoadingScreenOverlayHandler 딟;
  private 땄.땙 딟;
  private 땃.땢 딟;
  private 땄.땿 딟;
  private 땃.딷 딟;
  private bool 딧;
  private LoadingScreenOverlayHandler 땄;
  public TutorialCommanderSelectionButton[] Buttons;
  public string[] CharacterIds;
  public GameObject CharacterSpawnPoint;
  public GameObject Camera;
  public GuiText3D NameText;
  public GuiText3D ClassNameText;
  public GuiMultiLineText3D CharacterDescriptionText;
  public LoadingScreenOverlayHandler Overlay;
  public Vector3 OverlayPos = new Vector3(0.0f, 1.45f, 0.0f);
  public PurchaseSuccessfulPanelHandler SuccessMessage;
  public ErrorMessagehandler ErrorMessage;
  public LoadingScreenOverlayHandler LoadingOverlayPrefab;
  public GameObject IntroSilhouette;
  public GameObject MainSilhouette;

  private void Start()
  {
    base.딟 = ((Component) this).transform.position;
    this.Camera.SetActive(false);
    GlobalAppData.땼().땺();
  }

  public override void DeactivateMenu()
  {
    base.DeactivateMenu();
    this.땄 = false;
    this.DestroyCharacterModel();
    this.Camera.SetActive(false);
    this.IntroSilhouette.SetActive(false);
    this.MainSilhouette.SetActive(true);
  }

  public override void ActivateMenu()
  {
    base.ActivateMenu();
    this.땄 = true;
    this.딟 = false;
    this.딟 = new 땓.떀[this.CharacterIds.Length];
    for (int index = 0; index < this.CharacterIds.Length; ++index)
    {
      this.딟[index] = new 땓.떀(-1, this.CharacterIds[index]);
      this.딟[index].땠();
      GlobalAppData.땼().딟((땓.딲) this.딟[index], 땓.땾.딟);
    }
    int num = Mathf.Min(this.Buttons.Length, this.딟.Length);
    for (int Index = 0; Index < num; ++Index)
      this.Buttons[Index].Init(this.딟[Index], Index);
    this.딟 = -1;
    this.SetCharacterIndex(Random.Range(0, this.Buttons.Length));
    this.Camera.SetActive(true);
    ((Component) FrontendHub.딟.MoneyDisplay).gameObject.SetActive(false);
    this.IntroSilhouette.SetActive(true);
    this.MainSilhouette.SetActive(false);
  }

  private void SetCharacterIndex(int Index)
  {
    this.딟 = Index;
    for (int index = 0; index < this.Buttons.Length; ++index)
      this.Buttons[index].UpdateState(index == this.딟);
    this.UpdateCharacterModel();
  }

  private void Update()
  {
    if (this.땄 && !this.딟)
    {
      if (!this.딧)
      {
        this.땄 = Object.Instantiate((Object) this.LoadingOverlayPrefab, new Vector3(0.0f, 1.6f, 0.0f), Quaternion.identity) as LoadingScreenOverlayHandler;
        this.딧 = true;
      }
      if (!((딟.딗) GlobalAppData.땼()).땽())
      {
        if (this.딧)
        {
          this.땄.Close();
          this.딧 = false;
        }
        foreach (땓.떀 떀 in this.딟)
          떀.땠();
        this.딟 = true;
        this.UpdateCharacterModel();
      }
    }
    if (this.딟 != null && this.딟.땄())
    {
      if (((땄.땘) this.딟).딟 == 딟.땑.땤)
      {
        EnvironmentSettings_Game gameSettings = GlobalAppData.딧().GameSettings;
        if (GlobalAppData.땽().땃(gameSettings.CurrencyQuatlooId) == 0)
          GlobalAppData.땽().땃(true);
      }
      if (this.딟.딧() || ((땄.땘) this.딟).딟 == 딟.땑.땤)
      {
        string str = this.딟[this.딟].떔();
        this.딟 = new 땃.땢(GlobalAppData.땼().딸(str).땭());
      }
      else
        this.CreateErrorDisplay();
      this.딟 = (땄.땙) null;
    }
    if (this.딟 != null && this.딟.딟())
    {
      if (this.딟.땄())
      {
        this.딟 = this.딟.땃();
        OfferData offerData = ((IEnumerable<OfferData>) this.딟.떎()).FirstOrDefault<OfferData>((Func<OfferData, bool>) (obj0 => obj0.Price.ContainsKey(GlobalAppData.딧().GameSettings.CurrencyQuatlooId)));
        if (offerData == null || string.IsNullOrEmpty(offerData.Id))
          this.CreateErrorDisplay();
        else
          this.딟 = GlobalAppData.떏().때(offerData.Id);
      }
      else
        this.CreateErrorDisplay();
      this.딟 = (땃.땢) null;
    }
    if (this.딟 == null || !this.딟.땄())
      return;
    if (this.딟.딧())
    {
      this.LogStats(this.딟.딧());
      GlobalAppData.땽().땃(true);
      this.CreateSuccessOverlay();
    }
    else
      this.CreateErrorDisplay();
    this.딟 = (땄.땿) null;
  }

  private void CreateSuccessOverlay()
  {
    this.DestroyOverlay();
    GlobalAppData.떏().땟();
    string str = this.딟[this.딟].떔();
    UnitClass unitClass = GlobalAppData.땼().땢(str);
    (Object.Instantiate((Object) this.SuccessMessage) as PurchaseSuccessfulPanelHandler).Init(unitClass.CharacterIcon, this.딟, (딟.땫) null, (string) null);
    FrontendHub.딟.ChallengeLocationSelectionScreen.ActivateMenu(false);
    this.DeactivateMenu();
  }

  private void DisplayErrorMessage(딟.땑 ErrorCode, ErrorMessagehandler.땶 ErrorType) => (Object.Instantiate((Object) this.ErrorMessage) as ErrorMessagehandler).Init(ErrorType, ErrorCode);

  private void CreateErrorDisplay()
  {
    this.DestroyOverlay();
    if (this.딟.딟())
      this.DisplayErrorMessage(((땄.땘) this.딟).딟, ErrorMessagehandler.땶.땽);
    else
      this.DisplayErrorMessage(((땄.땘) this.딟).딟, ErrorMessagehandler.땶.딟);
  }

  private void DestroyOverlay()
  {
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    this.딟.Close();
    this.딟 = (LoadingScreenOverlayHandler) null;
  }

  private void OnCharacterSelected(int Index) => this.SetCharacterIndex(Index);

  private void UpdateCharacterModel()
  {
    if (!this.딟)
      return;
    this.DestroyCharacterModel();
    this.딟 = new GameObject();
    this.딟.transform.parent = this.CharacterSpawnPoint.transform;
    this.딟.transform.localPosition = Vector3.zero;
    this.딟.transform.localRotation = Quaternion.identity;
    땓.떀 떀 = this.딟[this.딟];
    UnitTesterComponent.딟(this.딟.transform, 떀.딣(), 떀.딛(), 떀.땷(), (UnitVoicePack) null, (Material) null, 떀.딛().딟((딶.땖) null, 땓.딺.딟), 0);
    this.NameText.Text = 떀.땹();
    this.NameText.UpdateMesh();
    this.ClassNameText.LocText = 떀.땁().ClassName;
    this.ClassNameText.UpdateMesh();
    this.CharacterDescriptionText.LocText = 떀.땁().Bio;
    this.CharacterDescriptionText.UpdateMesh();
  }

  private void DestroyCharacterModel()
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
    if (FreeCharacterSelectionScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      FreeCharacterSelectionScreenHandler.딟 = new Dictionary<string, int>(2)
      {
        {
          "Accept",
          0
        },
        {
          "Back",
          1
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!FreeCharacterSelectionScreenHandler.딟.TryGetValue(key, out num))
      return;
    if (num != 0)
    {
      if (num != 1)
        return;
      FrontendHub.딟.ChallengeLocationSelectionScreen.ActivateMenu(false);
      this.DeactivateMenu();
    }
    else
    {
      this.CreateOverlay();
      string characterVoucherId = GlobalAppData.딧().GameSettings.FreeCharacterVoucherId;
      this.딟 = GlobalAppData.떏().땩(characterVoucherId);
    }
  }

  private void LogStats(string ProductId)
  {
    int num = GlobalAppData.땽().딟(딢.땹.떏);
    딟.딦.딟("NUF_Tutorial_Free_Character", new Dictionary<string, string>()
    {
      {
        "productid",
        ProductId
      },
      {
        "numviews",
        num.ToString()
      }
    });
  }

  private void CreateOverlay() => this.딟 = Object.Instantiate((Object) this.Overlay, this.OverlayPos, Quaternion.identity) as LoadingScreenOverlayHandler;
}
