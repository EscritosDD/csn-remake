// Decompiled with JetBrains decompiler
// Type: RegistrationScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

public class RegistrationScreenHandler : BaseMenuHandler
{
  private LoadingScreenOverlayHandler 딟;
  private 땄.딬 딟;
  private 딟.땯 딟;
  private bool 딟;
  private bool 땄;
  private string 딟 = string.Empty;
  private string 땄;
  public GuiButton3D ContinueButton;
  public GuiButton3D LaterButton;
  public GuiTextField3D UserNameTextField;
  public YouAreNowLoggedInPanelHandler LoggedInPanelPrefab;
  public GameObject Overlay;
  public LoadingScreenOverlayHandler LoadingOverlayPrefab;
  public ErrorMessagehandler ErrorMessage;
  public RecoverAccountScreenHandler RecoverAccountScreenPrefab;
  public ToolTipHandler RegisterUserNameTooltip;
  public Shader GreyscaleShader;
  public Shader ColourShader;
  private Material 딟;
  private Material 땄;

  private void Awake() => base.딟 = ((Component) this).transform.position;

  private void Start()
  {
    this.딟 = GlobalAppData.땲().딟(((Component) this.ContinueButton).renderer.material, this.GreyscaleShader);
    this.땄 = GlobalAppData.땲().딟(((Component) this.ContinueButton).renderer.material, this.ColourShader);
  }

  public void ActivateMenu(bool FromTutorial, bool FromInstantAction)
  {
    this.딟 = FromTutorial;
    this.땄 = FromInstantAction;
    if (FromTutorial)
      딟.딦.딟("NUF_Tutorial_Completed");
    this.ActivateMenu();
  }

  public override void ActivateMenu()
  {
    base.ActivateMenu();
    ((Component) FrontendHub.딟.MoneyDisplay).gameObject.SetActive(false);
    if (!this.땄 || !딢.땚.딢())
      return;
    this.RegisterUserNameTooltip.Display();
  }

  public override void DeactivateMenu()
  {
    GuiComponent3D.딟((GuiComponent3D) null);
    base.DeactivateMenu();
  }

  private void Update()
  {
    if (this.딟 != null || this.딟 != null)
    {
      if (this.딟 != null && ((땄.땘) this.딟).땄())
      {
        if (this.딟.딧())
        {
          this.딟 = GlobalAppData.떏().딟(this.딟.딟(), this.딟.땄());
          string str = (string) null;
          if (this.딟)
            str = "Tutorial";
          else if (this.땄)
            str = "QuickPlay";
          if (!string.IsNullOrEmpty(str))
            딟.딦.딟("NUF_UserName", new Dictionary<string, string>()
            {
              {
                "Location",
                str
              }
            });
        }
        else
        {
          if (this.딟.딟)
          {
            this.DisplayErrorMessage(((땄.땘) this.딟).딟, ErrorMessagehandler.땶.떎);
            this.UserNameTextField.Clear();
          }
          else if (((땄.땘) this.딟).딟())
            this.DisplayErrorMessage(((땄.땘) this.딟).딟, ErrorMessagehandler.땶.땽);
          else
            this.DisplayErrorMessage(((땄.땘) this.딟).딟, ErrorMessagehandler.땶.딟);
          if (Object.op_Inequality((Object) this.딟, (Object) null))
            this.딟.Close();
        }
        this.딟 = (땄.딬) null;
      }
      if (this.딟 != null && this.딟.땄())
      {
        if (this.딟.딧())
        {
          딟.땇.딧(this.딟.딟, this.딟.땄);
          this.DeactivateMenu();
          FrontendHub.딟.LoginHandler.LoginAttempt(true);
        }
        else
          this.DisplayErrorMessage(((땄.땘) this.딟).딟, ErrorMessagehandler.땶.딟);
        if (Object.op_Inequality((Object) this.딟, (Object) null))
          this.딟.Close();
        this.딟 = (딟.땯) null;
      }
    }
    if (string.IsNullOrEmpty(this.UserNameTextField.get_Text().ToString()))
      ((Component) this.ContinueButton).renderer.sharedMaterial = this.딟;
    else
      ((Component) this.ContinueButton).renderer.sharedMaterial = this.땄;
  }

  private void OnButtonPressed(string Command)
  {
    if (this.UserNameTextField.get_IsOnScreenKeyboardActive())
      return;
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (RegistrationScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      RegistrationScreenHandler.딟 = new Dictionary<string, int>(3)
      {
        {
          "Later",
          0
        },
        {
          "Accept",
          1
        },
        {
          "SignIn",
          2
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!RegistrationScreenHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        BaseMenuHandler 땄 = BaseMenuHandler.땄;
        this.DeactivateMenu();
        if (Object.op_Inequality((Object) 땄, (Object) null) && Object.op_Inequality((Object) 땄, (Object) this))
        {
          땄.ActivateMenu();
          break;
        }
        FrontendHub.딟.MainScreen.ActivateMenu();
        break;
      case 1:
        if (this.UserNameTextField.get_Text().Length == 0)
          break;
        string str1 = this.UserNameTextField.get_Text().ToString();
        if (딟.땇.땺(str1))
        {
          this.DisplayErrorMessage(딟.땑.딟, ErrorMessagehandler.땶.딢);
          break;
        }
        if (딟.땇.땥(str1))
        {
          this.DisplayErrorMessage(딟.땑.딟, ErrorMessagehandler.땶.땃);
          break;
        }
        if (Object.op_Equality((Object) this.딟, (Object) null))
          this.딟 = Object.Instantiate((Object) this.LoadingOverlayPrefab, new Vector3(0.0f, 3.2f, 0.0f), Quaternion.identity) as LoadingScreenOverlayHandler;
        string str2 = this.UserNameTextField.get_Text().ToString();
        bool flag;
        if (this.딟.Equals(str2, StringComparison.OrdinalIgnoreCase))
        {
          flag = true;
        }
        else
        {
          flag = false;
          this.땄 = 딟.땇.딗();
          this.딟 = str2;
        }
        this.딟 = GlobalAppData.떏().딟(str2, this.땄, flag);
        break;
      case 2:
        this.DeactivateMenu();
        Object.Instantiate((Object) this.RecoverAccountScreenPrefab);
        break;
    }
  }

  private void DisplayErrorMessage(딟.땑 ErrorCode, ErrorMessagehandler.땶 ErrorType) => (Object.Instantiate((Object) this.ErrorMessage) as ErrorMessagehandler).Init(ErrorType, ErrorCode);
}
