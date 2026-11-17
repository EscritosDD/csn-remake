// Decompiled with JetBrains decompiler
// Type: LoginAttemptHandler_Web
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class LoginAttemptHandler_Web : LoginAttemptHandler_Base
{
  public override void LoginWithCloudData(딢.땞 CloudData)
  {
  }

  public override void SplashScreenLoginAttempt(bool AutoAdvance)
  {
    this.딟 = true;
    this.땄 |= AutoAdvance;
    if (this.LoginHandler != null)
      return;
    bool flag = false;
    if (딢.떇.딟(out string _, out string _))
      flag = true;
    if (!GlobalAppData.땽().딢() && !flag)
    {
      GlobalAppData.딷().딟();
      Object.Instantiate((Object) this.PlayedBeforePanelPrefab);
    }
    else if (flag)
    {
      this.딟 = BaseMenuHandler.딟;
      this.딟 = Object.Instantiate((Object) this.LoadingOverlayPrefab) as LoadingScreenOverlayHandler;
      this.LoginHandler = new 땓.딙();
      this.LoginHandler.딟();
    }
    else
      Object.Instantiate((Object) this.PlayedBeforePanelPrefab);
  }

  public override void LoginAttempt(bool CanCreateAccount)
  {
    this.딟 = false;
    this.땄 = false;
    if (this.LoginHandler != null)
      return;
    this.딟 = BaseMenuHandler.딟;
    if (딢.떇.딟(out string _, out string _))
    {
      this.딟 = Object.Instantiate((Object) this.LoadingOverlayPrefab) as LoadingScreenOverlayHandler;
      this.LoginHandler = new 땓.딙();
      this.LoginHandler.딟();
    }
    else
    {
      this.땄 = BaseMenuHandler.딟;
      BaseMenuHandler.딟.DeactivateMenu();
      if (CanCreateAccount)
      {
        FrontendHub.딟.RegistrationScreen.ActivateMenu();
      }
      else
      {
        ((Component) FrontendHub.딟.MoneyDisplay).gameObject.SetActive(false);
        Object.Instantiate((Object) this.RecoverAccountScreen);
      }
    }
  }

  public override void Update()
  {
    if (this.LoginHandler == null)
      return;
    this.LoginHandler.땄();
    if (!this.LoginHandler.땓())
      return;
    if (this.LoginHandler.땺())
    {
      this.딟.Close();
      if (this.딟)
      {
        FrontendHub.딟.SplashScreen.DeactivateMenu();
        if (this.땄)
        {
          FrontendHub.딟.MultiPlayerScreen.ActivateMenu();
        }
        else
        {
          GlobalAppData.땽().딧(딢.땹.딝);
          FrontendHub.딟.MainScreen.ActivateMenu();
        }
      }
      else if (this.땄 is SplashScreenHandler)
      {
        this.땄 = (BaseMenuHandler) null;
        FrontendHub.딟.MainScreen.ActivateMenu();
      }
      else
      {
        if (Object.op_Inequality((Object) BaseMenuHandler.딟, (Object) null))
          BaseMenuHandler.딟.DeactivateMenu();
        if (BaseMenuHandler.땄 is RegistrationScreenHandler && !GlobalAppData.땽().땟())
          FrontendHub.딟.AccountInticementScreen.ActivateMenu();
        else if (Object.op_Inequality((Object) this.딟, (Object) null))
          this.딟.ActivateMenu();
        else
          FrontendHub.딟.MainScreen.ActivateMenu();
      }
    }
    else if (this.LoginHandler.땥() == 땓.딹.땄)
    {
      딢.떇.딦();
      this.딟.Close();
      this.DisplayErrorMessage(this.LoginHandler.딝(), ErrorMessagehandler.땶.땄);
      Object.Instantiate((Object) this.RecoverAccountScreen);
    }
    else if (this.LoginHandler.땥() == 땓.딹.딢)
    {
      this.딟.Close();
      this.DisplayErrorMessage(this.LoginHandler.딝(), ErrorMessagehandler.땶.땽);
      Object.Instantiate((Object) this.RecoverAccountScreen);
    }
    else if (this.LoginHandler.땥() == 땓.딹.땃)
    {
      this.딟.Close();
      this.DisplayErrorMessage(this.LoginHandler.딝(), ErrorMessagehandler.땶.땼);
      Object.Instantiate((Object) this.RecoverAccountScreen);
    }
    else
    {
      this.딟.Close();
      this.DisplayErrorMessage(this.LoginHandler.딝(), ErrorMessagehandler.땶.딟);
      Object.Instantiate((Object) this.RecoverAccountScreen);
    }
    this.LoginHandler = (땓.딙) null;
    this.땄 = false;
  }
}
