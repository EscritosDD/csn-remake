// Decompiled with JetBrains decompiler
// Type: LoginAttemptHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using UnityEngine;

public class LoginAttemptHandler : LoginAttemptHandler_Base
{
  public override void LoginWithCloudData(딢.땞 CloudData)
  {
    딟.땇.딧(CloudData.땃(), CloudData.딶());
    this.딟 = BaseMenuHandler.딟;
    this.딟 = Object.Instantiate((Object) this.LoadingOverlayPrefab) as LoadingScreenOverlayHandler;
    this.LoginHandler = new 땓.딙();
    this.LoginHandler.딟();
  }

  public void SplashScreenLoginAttemptStage2(bool hasLocalProfile, bool hasTokens)
  {
    if (!hasLocalProfile && !hasTokens)
    {
      GlobalAppData.딷().딟();
      this.LoadTutorial();
    }
    else if (hasTokens)
    {
      this.딟 = BaseMenuHandler.딟;
      this.딟 = Object.Instantiate((Object) this.LoadingOverlayPrefab) as LoadingScreenOverlayHandler;
      this.LoginHandler = new 땓.딙();
      this.LoginHandler.딟();
    }
    else
    {
      FrontendHub.딟.SplashScreen.DeactivateMenu();
      FrontendHub.딟.MainScreen.ActivateMenu();
    }
  }

  public override void SplashScreenLoginAttempt(bool AutoAdvance)
  {
    this.딟 = true;
    this.땄 |= AutoAdvance;
    if (this.LoginHandler != null)
      return;
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    LoginAttemptHandler.땅 땅 = new LoginAttemptHandler.땅()
    {
      딟 = this,
      땄 = false,
      딟 = GlobalAppData.땽().딢()
    };
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated method
    땅.딟 = new Action(땅.딟);
    if (딢.떇.딟(out string _, out string _))
    {
      // ISSUE: reference to a compiler-generated field
      땅.땄 = true;
    }
    else
    {
      // ISSUE: reference to a compiler-generated field
      if (!땅.딟)
      {
        // ISSUE: reference to a compiler-generated method
        딢.떇.딟(new Action<딢.땞>(땅.딟));
        return;
      }
    }
    // ISSUE: reference to a compiler-generated field
    땅.딟();
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
      this.RedeemKeyVoucher();
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
      if (this.딟)
      {
        if (딢.떇.딟(out string _, out string _))
        {
          this.딟.Close();
          FrontendHub.딟.SplashScreen.DeactivateMenu();
          FrontendHub.딟.MainScreen.ActivateMenu();
        }
      }
      else
      {
        this.DisplayErrorMessage(this.LoginHandler.딝(), ErrorMessagehandler.땶.땽);
        this.ConnectionErrorLoginFlow();
      }
    }
    else if (this.LoginHandler.땥() == 땓.딹.딧)
    {
      if (this.딟)
      {
        if (딢.떇.딟(out string _, out string _))
        {
          this.딟.Close();
          FrontendHub.딟.SplashScreen.DeactivateMenu();
          FrontendHub.딟.MainScreen.ActivateMenu();
        }
      }
      else
      {
        this.DisplayErrorMessage(this.LoginHandler.딝(), ErrorMessagehandler.땶.딟);
        this.ConnectionErrorLoginFlow();
      }
    }
    else
    {
      this.딟.Close();
      if (Object.op_Inequality((Object) BaseMenuHandler.딟, (Object) null))
        BaseMenuHandler.딟.DeactivateMenu();
      if (Object.op_Inequality((Object) BaseMenuHandler.땄, (Object) null))
        BaseMenuHandler.땄.DeactivateMenu();
      this.DisplayErrorMessage(this.LoginHandler.딝(), ErrorMessagehandler.땶.딟);
      if (Object.op_Inequality((Object) this.땄, (Object) null))
      {
        this.땄.DeactivateMenu();
        BaseMenuHandler 땄 = this.땄;
        this.땄 = (BaseMenuHandler) null;
        땄.ActivateMenu();
      }
      else if (Object.op_Inequality((Object) BaseMenuHandler.땄, (Object) null))
        this.딟.ActivateMenu();
      else
        FrontendHub.딟.SplashScreen.ActivateMenu();
    }
    this.LoginHandler = (땓.딙) null;
    this.땄 = false;
  }

  private void ConnectionErrorLoginFlow()
  {
    if (this.땄 is SplashScreenHandler)
    {
      FrontendHub.딟.SplashScreen.DeactivateMenu();
      FrontendHub.딟.MainScreen.ActivateMenu();
      this.딟.Close();
    }
    else
    {
      this.딟.Close();
      if (Object.op_Inequality((Object) BaseMenuHandler.딟, (Object) null))
        BaseMenuHandler.딟.DeactivateMenu();
      if (Object.op_Inequality((Object) BaseMenuHandler.땄, (Object) null))
        BaseMenuHandler.땄.DeactivateMenu();
      if (Object.op_Inequality((Object) this.땄, (Object) null))
      {
        this.땄.DeactivateMenu();
        BaseMenuHandler 땄 = this.땄;
        this.땄 = (BaseMenuHandler) null;
        땄.ActivateMenu();
      }
      else if (Object.op_Inequality((Object) this.딟, (Object) null))
        this.딟.ActivateMenu();
      else
        FrontendHub.딟.SplashScreen.ActivateMenu();
    }
  }

  private void RedeemKeyVoucher()
  {
    if (GlobalAppData.땽().딟(딢.땹.딣) != 0)
      return;
    GlobalAppData.땽().땺(GlobalAppData.딧().GameSettings.FreeKeysVoucherId);
    GlobalAppData.땽().딟(딢.땹.딣, 1);
  }
}
