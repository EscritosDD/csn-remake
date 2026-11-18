// Decompiled with JetBrains decompiler
// Type: LoginAttemptHandler_Base
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public abstract class LoginAttemptHandler_Base : MonoBehaviour
{
  protected LoadingScreenOverlayHandler 딟;
  protected BaseMenuHandler 딟;
  protected BaseMenuHandler 땄;
  protected bool 딟;
  protected ErrorMessagehandler 딟;
  protected bool 땄;
  public CloudDataPanelHandler CloudDataPanelPrefab;
  public PlayedBeforePanelHandler PlayedBeforePanelPrefab;
  public RecoverAccountScreenHandler RecoverAccountScreen;
  public 땓.딙 LoginHandler;
  public LoadingScreenOverlayHandler LoadingOverlayPrefab;
  public YouAreNowLoggedInPanelHandler YouAreLoggedInPrefab;

  protected void DisplayErrorMessage(딟.땑 ErrorCode, ErrorMessagehandler.땶 ErrorType)
  {
    if (!Object.op_Equality((Object) this.딟, (Object) null))
      return;
    this.딟 = Object.Instantiate((Object) FrontendHub.딟.ErrorMessage) as ErrorMessagehandler;
    this.딟.Init(ErrorType, ErrorCode);
    GuiComponent3D.딟((GuiComponent3D) this.딟.ConfirmButton);
  }

  public virtual void LoginWithCloudData(딢.땞 CloudData)
  {
  }

  public virtual void SplashScreenLoginAttempt(bool AutoAdvance)
  {
  }

  public virtual void LoginAttempt(bool CanCreateAccount)
  {
  }

  public virtual void Update()
  {
  }

  public virtual void OpenAccountPanel()
  {
    Transform startPoint = FrontendHub.딟.SplashScreen.StartPoint;
    Transform endPoint = FrontendHub.딟.SplashScreen.EndPoint;
    (Object.Instantiate((Object) this.PlayedBeforePanelPrefab) as PlayedBeforePanelHandler).Init(startPoint, endPoint);
  }

  public void LoadTutorial() => Application.LoadLevelAsync(GlobalAppData.딟.EnvSettings.ScenesAsset.Data.땃());

  protected void DeactivateMenu() => this.딟.DeactivateMenu();
}
