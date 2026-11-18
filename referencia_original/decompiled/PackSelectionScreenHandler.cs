// Decompiled with JetBrains decompiler
// Type: PackSelectionScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PackSelectionScreenHandler : MonoBehaviour
{
  private 땃.딦 딟;
  private 땃.딷 딟;
  private 딟.땫 딟;
  private Material 딟;
  private LoadingScreenOverlayHandler 딟;
  private bool 딟;
  private bool 땄;
  private 딢.땿 딟 = new 딢.땿();
  private bool 딧;
  private bool 딢;
  private bool 땃;
  private float 딟;
  private float 땄;
  private int 딟;
  private 땃.땢 딟;
  public GuiText3D PackName;
  public GuiMultiLineText3D PackDescription;
  public GameObject PackImage;
  public GuiButton3D PlayCollision;
  public GuiButton3D StoreButton;
  public GameObject TopSecretBanner;
  public bool PlayIsAvailable;
  public LoadingScreenOverlayHandler LoadingOverlayPrefab;
  public ErrorMessagehandler ErrorMessage;
  public PurchaseSuccessfulPanelHandler SuccessMessage;
  public Material SuccessIconBaseMaterial;
  public Vector3 DefaultScale;
  public Vector3 ReducedScale;
  public GuiText3D ProgressText;
  public GuiText3D ProgressTextShadow;
  public GuiText3D ScoreText;
  public GuiText3D ScoreTextShadow;
  public GameObject CompleteMedal;
  public GameObject DirectorsCutIcon;
  public GameObject AvailableGlow;
  public GameObject BuyGlow;
  public GameObject PriceDisplay;
  public GuiText3D PriceText;
  public GuiText3D PriceTextShadow;
  public AnimationCurve Activate;
  public float AnimationLength;
  public AudioShader2 SlideSelection;
  public GameObject FriendScoreAnchor;
  public PackSelectionFriendScore FriendScorePrefab;
  public CloudCoverLoadingScreen CloudCoverPrefab;
  private CloudCoverLoadingScreen 딟;

  private void Awake()
  {
    this.CompleteMedal.SetActive(false);
    ((Component) this.StoreButton).gameObject.SetActive(false);
    ((Component) this.PlayCollision).gameObject.SetActive(false);
    this.TopSecretBanner.gameObject.SetActive(false);
    this.DirectorsCutIcon.SetActive(false);
    this.AvailableGlow.SetActive(false);
    this.BuyGlow.SetActive(false);
    this.PriceDisplay.SetActive(false);
    ((Component) this.ProgressText).gameObject.SetActive(false);
    ((Component) this.ScoreText).gameObject.SetActive(false);
  }

  private void Start()
  {
    GlobalAppData.땋().딟();
    this.딟 = new 딟.땫(256, (딟.땇) GlobalAppData.떏());
  }

  public void Init(int Index, 딢.땃 Pack)
  {
    // ISSUE: reference to a compiler-generated method
    this.set_MapPack(Pack);
    this.딟 = Index;
    GlobalAppData.땼().딦(Pack.딧());
    PackSelectionFriendScore selectionFriendScore = Object.Instantiate((Object) this.FriendScorePrefab) as PackSelectionFriendScore;
    Vector3 localScale = ((Component) selectionFriendScore).transform.localScale;
    ((Component) selectionFriendScore).transform.parent = this.FriendScoreAnchor.transform;
    ((Component) selectionFriendScore).transform.localPosition = Vector3.zero;
    ((Component) selectionFriendScore).transform.localScale = localScale;
    selectionFriendScore.Init(Pack);
  }

  private void UpdatePackInformation(bool IsOwned)
  {
    this.딟 = (땃.딦) null;
    this.PackName.LocText = this.get_MapPack().땓().PackName;
    this.PackName.UpdateMesh();
    ((Component) this.PackName).gameObject.SetActive(true);
    this.PackDescription.LocText = this.get_MapPack().땓().PackDescription;
    this.PackDescription.UpdateMesh();
    ((Component) this.PackDescription).gameObject.SetActive(true);
    this.PackImage.renderer.sharedMaterial = this.get_MapPack().땓().PackIcon;
    if (this.get_MapPack().땓().IsDirectorsCut)
      this.DirectorsCutIcon.SetActive(true);
    if (IsOwned)
    {
      this.PlayIsAvailable = true;
      ((Component) this.StoreButton).gameObject.SetActive(false);
      ((Component) this.PlayCollision).gameObject.SetActive(true);
      this.TopSecretBanner.gameObject.SetActive(false);
      this.AvailableGlow.SetActive(true);
      this.BuyGlow.SetActive(false);
      this.PriceDisplay.SetActive(false);
      this.CalculateChallengePackProgress();
    }
    else
    {
      this.PlayIsAvailable = false;
      ((Component) this.StoreButton).gameObject.SetActive(true);
      ((Component) this.PlayCollision).gameObject.SetActive(false);
      this.TopSecretBanner.gameObject.SetActive(true);
      this.AvailableGlow.SetActive(false);
      this.BuyGlow.SetActive(true);
      if (!GlobalAppData.떏().땥() || string.IsNullOrEmpty(this.get_MapPack().땄()))
        return;
      this.딟 = new 땃.땢(this.get_MapPack().땄());
    }
  }

  private void CalculateChallengePackProgress()
  {
    int length = this.get_MapPack().딝().Length;
    int num1 = 0;
    int num2 = 0;
    foreach (string str in this.get_MapPack().딝())
    {
      if (GlobalAppData.땽().떎(str) > 0)
      {
        ++num1;
        if (GlobalAppData.땽().떎(str) == 3)
          ++num2;
      }
    }
    this.ProgressText.Text = num1.ToString() + "/" + length.ToString();
    this.ProgressText.UpdateMesh();
    this.ProgressTextShadow.Text = this.ProgressText.Text;
    this.ProgressTextShadow.UpdateMesh();
    this.ScoreText.Text = this.get_MapPack().땓().땃().ToString();
    this.ScoreText.UpdateMesh();
    this.ScoreTextShadow.Text = this.ScoreText.Text;
    this.ScoreTextShadow.UpdateMesh();
    ((Component) this.ProgressText).gameObject.SetActive(true);
    ((Component) this.ScoreText).gameObject.SetActive(true);
    if (num2 == length)
      this.CompleteMedal.SetActive(true);
    else
      this.CompleteMedal.SetActive(false);
  }

  private void Update()
  {
    if (!this.딟 && this.get_MapPack().딢())
    {
      this.UpdatePackInformation(this.get_MapPack().떎());
      this.딟 = true;
    }
    if (this.딟 != null)
    {
      this.딟.땄();
      if (this.딟 != null)
      {
        if (this.딟.딶())
          this.CreateLoadingOverlay();
        else
          this.CloseLoadingOverlay();
      }
    }
    if (this.딧)
    {
      float num1 = Time.realtimeSinceStartup - this.땄;
      this.땄 = Time.realtimeSinceStartup;
      if (this.딢)
        this.딟 += num1 / this.AnimationLength;
      else
        this.딟 -= num1 / this.AnimationLength;
      this.딟 = Mathf.Clamp01(this.딟);
      float num2 = this.Activate.Evaluate(this.딟);
      ((Component) this).gameObject.transform.localScale = new Vector3(num2, 1f, num2);
      if (((double) this.딟 == 1.0 || (double) this.딟 == 0.0) && this.딢 == this.땃)
        this.딧 = false;
    }
    if (this.땄)
    {
      this.딟.딟();
      if (this.딟.땄())
      {
        FrontendHub.딟.ChallengeMissionMapScreen.ActivateMenu(this.get_MapPack(), this.딟, false);
        this.딟 = (CloudCoverLoadingScreen) null;
        FrontendHub.딟.ChallengePackSelectionScreen.DeactivateMenu();
        this.땄 = false;
      }
    }
    if (this.딟 != null && this.딟.딟())
    {
      if (this.딟.땄())
        ApplePriceDisplay.딟(this.딟.땃(), ((Component) this).gameObject, this.PriceText, this.PriceTextShadow, this.PriceDisplay, (Action) (() => { }));
      this.딟 = (땃.땢) null;
    }
    this.땃 = this.딢;
  }

  private void OnButtonPressed(string Command)
  {
    if (this.딟 != FrontendHub.딟.ChallengePackSelectionScreen.PackSelectionScroller.get_ActiveElement())
      return;
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (PackSelectionScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      PackSelectionScreenHandler.딟 = new Dictionary<string, int>(2)
      {
        {
          "Play",
          0
        },
        {
          "PurchasePack",
          1
        }
      };
    }
    int num1;
    // ISSUE: reference to a compiler-generated field
    if (!PackSelectionScreenHandler.딟.TryGetValue(key, out num1))
      return;
    switch (num1)
    {
      case 0:
        GlobalAppData.땼().딝(this.get_MapPack().땥());
        this.딟 = Object.Instantiate((Object) this.CloudCoverPrefab) as CloudCoverLoadingScreen;
        float num2 = this.딟.Open();
        this.땄 = true;
        this.딟.딟(num2);
        break;
      case 1:
        if (GlobalAppData.떏().땥())
        {
          this.CreateLoadingOverlay();
          this.딟 = new 땃.딦(this.get_MapPack().땄());
          this.딟.딟(new Action<땃.딷>(this.OnItemFound));
          this.딟.딧(new Action<딟.땑, ErrorMessagehandler.땶>(this.OnItemFindError));
          this.딟.딟(new Action<PurchaseResult>(this.OnItemPurchased));
          this.딟.딟(new Action<딟.땑, ErrorMessagehandler.땶>(this.OnItemPurchaseError));
          break;
        }
        FrontendHub.딟.LoginHandler.LoginAttempt(true);
        break;
    }
  }

  private void OnItemFound(땃.딷 Item)
  {
    this.딟 = Item;
    this.딟.딟(Item.땥());
    this.딟.딟((Item.땃().땃() as 땓.딞).딦().딟(), new Action(this.OnIconDownloadFailure), new Action<Texture2D>(this.OnIconDownloadSuccess));
    this.CloseLoadingOverlay();
  }

  private void OnItemPurchaseError(딟.땑 ErrorCode, ErrorMessagehandler.땶 ErrorType)
  {
    if (ErrorType == ErrorMessagehandler.땶.떏)
      return;
    this.DisplayErrorMessage(ErrorCode, ErrorType);
  }

  private void OnItemPurchased(PurchaseResult result)
  {
    this.UpdatePackInformation(true);
    this.DisplaySuccessMessage();
    this.CloseLoadingOverlay();
  }

  private void OnItemFindError(딟.땑 ErrorCode, ErrorMessagehandler.땶 ErrorType)
  {
    this.CloseLoadingOverlay();
    this.DisplayErrorMessage(ErrorCode, ErrorType);
  }

  private void DisplaySuccessMessage()
  {
    (Object.Instantiate((Object) this.SuccessMessage) as PurchaseSuccessfulPanelHandler).Init(this.딟, this.딟, this.딟, (string) null);
    this.딟 = (딟.땫) null;
  }

  private void DisplayErrorMessage(딟.땑 ErrorCode, ErrorMessagehandler.땶 ErrorType)
  {
    ErrorMessagehandler errorMessagehandler = Object.Instantiate((Object) this.ErrorMessage) as ErrorMessagehandler;
    ((Component) errorMessagehandler).transform.position = Vector3.op_Addition(Vector3.zero, new Vector3(0.0f, 3f, 0.0f));
    errorMessagehandler.Init(ErrorType, ErrorCode);
  }

  private void OnIconDownloadFailure()
  {
  }

  private void OnIconDownloadSuccess(Texture2D Image)
  {
    this.딟 = new Material(this.SuccessIconBaseMaterial);
    this.딟.mainTexture = (Texture) Image;
  }

  private void CreateLoadingOverlay()
  {
    if (Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    this.딟 = Object.Instantiate((Object) this.LoadingOverlayPrefab) as LoadingScreenOverlayHandler;
    ((Component) this.딟).transform.position = Vector3.op_Addition(Vector3.zero, new Vector3(0.0f, 3f, 0.0f));
  }

  private void CloseLoadingOverlay()
  {
    if (Object.op_Equality((Object) this.딟, (Object) null))
      return;
    this.딟.Close();
    this.딟 = (LoadingScreenOverlayHandler) null;
  }

  private void OnDestroy()
  {
    if (this.딟 != null)
    {
      this.딟.Dispose();
      this.딟 = (딟.땫) null;
    }
    this.CloudCoverPrefab = (CloudCoverLoadingScreen) null;
  }

  public void SetScale(bool IsCurrent)
  {
    this.땃 = this.딢;
    this.딢 = IsCurrent;
    if (IsCurrent)
    {
      double num = (double) this.SlideSelection.PlayOneShot(((Component) this).gameObject);
      this.PlayCollision.Disabled = false;
      if (((Component) this.StoreButton).gameObject.activeSelf)
        this.StoreButton.Disabled = false;
      this.StoreButton.Disabled = false;
    }
    else
    {
      if (((Component) this.StoreButton).gameObject.activeSelf)
        this.StoreButton.Disabled = true;
      this.PlayCollision.Disabled = true;
    }
    this.땄 = Time.realtimeSinceStartup;
    this.딧 = true;
  }

  [CompilerGenerated]
  [SpecialName]
  public 딢.땃 get_MapPack() => this.딟;
}
