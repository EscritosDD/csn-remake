// Decompiled with JetBrains decompiler
// Type: RecoverAccountScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class RecoverAccountScreenHandler : MonoBehaviour
{
  private LoadingScreenOverlayHandler 딟;
  private 딟.땯 딟;
  private GameObject 딟;
  private ErrorMessagehandler 딟;
  public GuiButton2State3D ContinueButton;
  public GuiButton3D BackButton;
  public GuiButton3D ForgotPasswordButton;
  public GuiTextField3D UserNameTextField;
  public GuiTextField3D PasswordTextField;
  public YouAreNowLoggedInPanelHandler LoggedInPanelPrefab;
  public GameObject Overlay;
  public LoadingScreenOverlayHandler LoadingOverlayPrefab;
  public ErrorMessagehandler ErrorMessage;

  private void Start()
  {
    this.딟 = Object.Instantiate((Object) this.Overlay, new Vector3(0.0f, (float) (((Component) this).transform.position.y - 0.100000001490116), 0.0f), Quaternion.identity) as GameObject;
    this.ContinueButton.SetButtonDisabled(true);
    ((Component) this.BackButton).gameObject.SetActive(false);
    ((Component) this.ForgotPasswordButton).gameObject.SetActive(false);
  }

  public void Update()
  {
    if (this.딟 != null && this.딟.땄())
    {
      if (this.딟.딧())
      {
        딟.땇.딧(this.딟.딟, this.딟.땄);
        FrontendHub.딟.LoginHandler.LoginAttempt(true);
        this.딟.GetComponent<MenuOverlayHandler>().Close();
        Object.Destroy((Object) ((Component) this).gameObject);
      }
      else
      {
        if (this.딟.딟())
          this.DisplayErrorMessage(((땄.땘) this.딟).딟, ErrorMessagehandler.땶.땽);
        else if (this.딟.딟)
          this.DisplayErrorMessage(((땄.땘) this.딟).딟, ErrorMessagehandler.땶.땓);
        else
          this.DisplayErrorMessage(((땄.땘) this.딟).딟, ErrorMessagehandler.땶.딟);
        this.PasswordTextField.Clear();
      }
      if (Object.op_Inequality((Object) this.딟, (Object) null))
        this.딟.Close();
      this.딟 = (딟.땯) null;
    }
    if (GuiTextField3D.딟())
    {
      this.ContinueButton.SetButtonDisabled(true);
      ((Component) this.BackButton).gameObject.SetActive(false);
      ((Component) this.ForgotPasswordButton).gameObject.SetActive(false);
    }
    else
    {
      if (this.UserNameTextField.get_Text().Length > 0 && this.PasswordTextField.get_Text().Length > 0)
        this.ContinueButton.SetButtonDisabled(false);
      else
        this.ContinueButton.SetButtonDisabled(true);
      ((Component) this.BackButton).gameObject.SetActive(true);
      ((Component) this.ForgotPasswordButton).gameObject.SetActive(true);
    }
  }

  private void DisplayErrorMessage(딟.땑 ErrorCode, ErrorMessagehandler.땶 ErrorType)
  {
    if (!Object.op_Equality((Object) this.딟, (Object) null))
      return;
    this.딟 = Object.Instantiate((Object) this.ErrorMessage) as ErrorMessagehandler;
    this.딟.Init(ErrorType, ErrorCode);
    GuiComponent3D.딟((GuiComponent3D) this.딟.ConfirmButton);
  }

  private void OnButtonPressed(string Command)
  {
    if (this.UserNameTextField.get_IsOnScreenKeyboardActive() || this.PasswordTextField.get_IsOnScreenKeyboardActive())
      return;
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (RecoverAccountScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      RecoverAccountScreenHandler.딟 = new Dictionary<string, int>(5)
      {
        {
          "Cancel",
          0
        },
        {
          "Accept",
          1
        },
        {
          "ForgotPassword",
          2
        },
        {
          "ForgotUserName",
          3
        },
        {
          "AcceptUserName",
          4
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!RecoverAccountScreenHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        this.딟.GetComponent<MenuOverlayHandler>().Close();
        Object.Destroy((Object) ((Component) this).gameObject);
        BaseMenuHandler.땄.ActivateMenu();
        break;
      case 1:
        if (this.UserNameTextField.get_Text().Length == 0 || this.PasswordTextField.get_Text().Length == 0)
          break;
        if (Object.op_Equality((Object) this.딟, (Object) null))
          this.딟 = Object.Instantiate((Object) this.LoadingOverlayPrefab, new Vector3(0.0f, 3.2f, 0.0f), Quaternion.identity) as LoadingScreenOverlayHandler;
        this.딟 = GlobalAppData.떏().딟(this.UserNameTextField.get_Text().ToString(), this.PasswordTextField.get_Text().ToString());
        break;
      case 2:
        GlobalAppData.땭();
        break;
      case 3:
        GlobalAppData.딦();
        break;
      case 4:
        GuiComponent3D.딟(this.UserNameTextField.NextComponent);
        break;
    }
  }
}
