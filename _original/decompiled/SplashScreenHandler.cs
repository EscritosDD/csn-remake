// Decompiled with JetBrains decompiler
// Type: SplashScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Gui3D/Screens/Splash Screen")]
public class SplashScreenHandler : BaseMenuHandler
{
  private float 딟;
  private 딢.땿 딟 = new 딢.땿();
  private Material 딟;
  private bool 딟;
  public bool PlayAnims;
  public Transform MoneyDisplay;
  public RecoverAccountScreenHandler RecoverScreenPrefab;
  public GameObject RadTacticsLogo;
  public GameObject PressToStartText;
  public GuiButton3D ContinueButton;
  public AnimationCurve CurveData;
  public float AnimationStartDelay = 1.5f;
  public float AnimationLength = 1f;
  public float LogoStartScale = 4f;
  public Transform StartPoint;
  public Transform EndPoint;

  private void Awake() => this.딟 = this.RadTacticsLogo.renderer.material;

  private void Start()
  {
    땓.땿.딟();
    Uri result = (Uri) null;
    Uri.TryCreate(Application.absoluteURL, UriKind.Absolute, out result);
    if (result == (Uri) null || GlobalAppData.딧().WebPlayerDomains.Contains(result.Host))
      ;
    base.딟 = ((Component) this).transform.position;
    switch (GlobalAppData.딟.딟())
    {
      case GlobalAppState.땊.딟:
        this.ActivateMenu();
        break;
      case GlobalAppState.땊.땄:
        FrontendHub.딟.MainScreen.ActivateMenu();
        break;
      case GlobalAppState.땊.딧:
        FrontendHub.딟.RegistrationScreen.ActivateMenu(true, false);
        break;
      case GlobalAppState.땊.딢:
        FrontendHub.딟.ChallengeLocationSelectionScreen.ActivateMenu();
        break;
      case GlobalAppState.땊.땃:
        FrontendHub.딟.MultiPlayerScreen.ActivateMenu();
        break;
      case GlobalAppState.땊.딶:
        FrontendHub.딟.PassAndPlayScreen.ActivateMenu();
        break;
      case GlobalAppState.땊.땓:
        FrontendHub.딟.MapSelectionScreen.ActivateMenu(true, GlobalAppData.딟.땄(), (BaseMenuHandler) FrontendHub.딟.ChallengeLocationSelectionScreen);
        GlobalAppData.딟.딟((딧.땧) null);
        break;
      case GlobalAppState.땊.땺:
        FrontendHub.딟.SquadPointSelectionScreen.ActivateMenu(true, GlobalAppData.딟.땄(), (BaseMenuHandler) FrontendHub.딟.ChallengeLocationSelectionScreen);
        GlobalAppData.딟.딟((딧.땧) null);
        break;
      case GlobalAppState.땊.땥:
        FrontendHub.딟.StoreScreen.ActivateMenu(GlobalAppData.딟.딧(), GlobalAppData.딟.딢());
        GlobalAppData.딟.딟((string) null);
        GlobalAppData.딟.딟(땃.땽.딟);
        break;
      case GlobalAppState.땊.딝:
        FrontendHub.딟.CommanderAbilityScreen.TryActivateMenu(딶.땂.딟, GlobalAppData.딟.땄(), (BaseMenuHandler) FrontendHub.딟.ChallengeLocationSelectionScreen);
        GlobalAppData.딟.딟((딧.땧) null);
        break;
      case GlobalAppState.땊.떎:
        GlobalAppData.땽().딟(딢.땹.땲, 0);
        FrontendHub.딟.AccountInticementScreen.ActivateMenu();
        break;
      case GlobalAppState.땊.떂:
        FrontendHub.딟.BarracksScreen.ActivateMenu(딶.땂.딟, GlobalAppData.딟.땃(), 딢.딩.딢, true);
        GlobalAppData.딟.땄((string) null);
        GlobalAppData.딟.딧((string) null);
        break;
      case GlobalAppState.땊.땭:
        FrontendHub.딟.RegistrationScreen.ActivateMenu(false, false);
        break;
      case GlobalAppState.땊.딦:
        FrontendHub.딟.ChallengeLocationSelectionScreen.ActivateMenu();
        break;
      case GlobalAppState.땊.땤:
        GlobalAppData.땽().딟(딢.땹.땲, 0);
        FrontendHub.딟.AccountInticementScreen.ActivateMenu();
        FrontendHub.딟.AccountInticementScreen.set_InFlow(true);
        break;
      case GlobalAppState.땊.땽:
        FrontendHub.딟.LootRewardScreen.ActivateMenu();
        break;
    }
    GlobalAppData.딟.딟(GlobalAppState.땊.딟);
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (SplashScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      SplashScreenHandler.딟 = new Dictionary<string, int>(1)
      {
        {
          "Continue",
          0
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!SplashScreenHandler.딟.TryGetValue(key, out num) || num != 0)
      return;
    this.Login(false);
  }

  public override void ActivateMenu()
  {
    base.ActivateMenu();
    if (!GlobalAppData.딝() && GlobalAppData.딟)
    {
      GlobalAppData.딶();
      GlobalAppData.딟 = false;
    }
    ((Component) this.MoneyDisplay).gameObject.SetActive(false);
    this.RadTacticsLogo.SetActive(false);
    if (Object.op_Inequality((Object) this.PressToStartText, (Object) null))
      this.PressToStartText.SetActive(false);
    if (Object.op_Inequality((Object) this.ContinueButton, (Object) null))
      this.ContinueButton.Disabled = true;
    this.딟.딟(this.AnimationStartDelay);
    this.딟 = true;
  }

  public override void DeactivateMenu()
  {
    base.DeactivateMenu();
    ((Component) this.MoneyDisplay).gameObject.SetActive(true);
    this.RadTacticsLogo.SetActive(false);
    if (Object.op_Inequality((Object) this.PressToStartText, (Object) null))
      this.PressToStartText.SetActive(false);
    this.딟.color = Color.op_Implicit(new Vector4(1f, 1f, 1f, 0.0f));
  }

  public void Update()
  {
    if (this.PlayAnims)
    {
      this.딟.딟();
      if (this.딟.땄())
      {
        this.딟 += Time.deltaTime / this.AnimationLength;
        this.딟 = Mathf.Clamp01(this.딟);
        if (!this.RadTacticsLogo.activeInHierarchy)
          this.RadTacticsLogo.SetActive(true);
        Vector3 localScale = this.RadTacticsLogo.transform.localScale;
        float num = Mathf.Lerp(this.LogoStartScale, 1f, this.CurveData.Evaluate(this.딟));
        localScale.x = (__Null) (double) num;
        localScale.z = (__Null) (double) num;
        this.RadTacticsLogo.transform.localScale = localScale;
        this.딟.color = Color.op_Implicit(new Vector4(1f, 1f, 1f, this.딟));
        if (Object.op_Inequality((Object) this.PressToStartText, (Object) null) && Object.op_Inequality((Object) this.ContinueButton, (Object) null) && (double) this.딟 == 1.0 && this.ContinueButton.Disabled)
        {
          this.PressToStartText.SetActive(true);
          this.ContinueButton.Disabled = false;
        }
      }
    }
    else
    {
      this.RadTacticsLogo.SetActive(true);
      this.RadTacticsLogo.transform.localScale = Vector3.one;
    }
    if (!GlobalAppData.딝() && !GlobalAppData.떎())
      GlobalAppData.땓();
    if (!this.딟 || ((딟.딗) GlobalAppData.땼()).땽())
      return;
    this.딟 = false;
    this.Login(false);
  }

  public void HandlePushNotification(딟.딽 NotType)
  {
    if (NotType != 딟.딽.딟)
      return;
    Debug.Log((object) ("In-Menu Notification: " + (object) NotType));
  }

  private void Login(bool AutoAdvanceToMultiplayer)
  {
    if (GlobalAppData.떏().땥())
    {
      if (AutoAdvanceToMultiplayer)
      {
        if (Object.op_Inequality((Object) BaseMenuHandler.딟, (Object) null))
          BaseMenuHandler.딟.DeactivateMenu();
        GlobalAppData.딟.딟(GlobalAppState.땊.딟);
        FrontendHub.딟.MultiPlayerScreen.ActivateMenu();
      }
      else
      {
        this.DeactivateMenu();
        FrontendHub.딟.MainScreen.ActivateMenu();
      }
    }
    else
      FrontendHub.딟.LoginHandler.SplashScreenLoginAttempt(AutoAdvanceToMultiplayer);
  }
}
