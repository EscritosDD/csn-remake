// Decompiled with JetBrains decompiler
// Type: ErrorMessagehandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using 딟;

public class ErrorMessagehandler : MonoBehaviour
{
  private MenuOverlayHandler 딟;
  private bool 딟;
  public MenuOverlayHandler Overlay;
  public GuiButton3D ConfirmButton;
  public GuiText3D ErrorText;
  public GuiText3D ErrorCodeText;
  public GuiText3D ErrorCodeValue;
  public GuiMultiLineText3D ErrorDescriptionText;
  public EventHandler OnClosing;
  public Action OnClosedCallback;
  public LocalisationEntry CouldNotConnect;
  public LocalisationEntry InvalidCredentials;
  public LocalisationEntry InvalidEmail;
  public LocalisationEntry InvalidUserName;
  public LocalisationEntry InvalidUserNameLength;
  public LocalisationEntry InvalidPassword;
  public LocalisationEntry InvalidUser;
  public LocalisationEntry AlreadyRequested;
  public LocalisationEntry AlreadyFriend;
  public LocalisationEntry EmailInUse;
  public LocalisationEntry UserNameInUse;
  public LocalisationEntry TooManyGames;
  public LocalisationEntry OpponentTooManyGames;
  public LocalisationEntry GameOutOfDate;
  public LocalisationEntry FriendLimitReached;
  public LocalisationEntry ServerIsDown;
  public LocalisationEntry MissingContent;
  public LocalisationEntry AlreadyRedeemed;
  public LocalisationEntry DownloadingContentCheckNetwork;
  public LocalisationEntry DownloadingContentPleaseWait;

  private void Start()
  {
    ((Component) this.ConfirmButton).gameObject.SetActive(false);
    ((Component) this.ErrorText).gameObject.SetActive(false);
    ((Component) this.ErrorDescriptionText).gameObject.SetActive(false);
    Vector3 vector3 = Vector3.op_Subtraction(((Component) this).transform.position, new Vector3(0.0f, 0.1f, 0.0f));
    if (!Object.op_Equality((Object) this.딟, (Object) null))
      return;
    this.딟 = Object.Instantiate((Object) this.Overlay, vector3, Quaternion.identity) as MenuOverlayHandler;
  }

  public void SetParent(Transform parent, Vector3 localPosition)
  {
    ((Component) this).transform.parent = parent;
    ((Component) this).transform.localPosition = localPosition;
    if (Object.op_Equality((Object) this.딟, (Object) null))
      this.딟 = Object.Instantiate((Object) this.Overlay) as MenuOverlayHandler;
    ((Component) this.딟).transform.parent = parent;
    ((Component) this.딟).transform.localPosition = new Vector3((float) localPosition.x, (float) (localPosition.y - 0.100000001490116), (float) localPosition.z);
  }

  public void Init(ErrorMessagehandler.땶 Error, 땑 ErrorCode)
  {
    if (ErrorCode == 땑.딟)
    {
      ((Component) this.ErrorCodeText).gameObject.SetActive(false);
      ((Component) this.ErrorCodeValue).gameObject.SetActive(false);
    }
    else
    {
      this.ErrorCodeValue.Text = ((int) ErrorCode).ToString();
      this.ErrorCodeValue.UpdateMesh();
    }
    switch (Error)
    {
      case ErrorMessagehandler.땶.딟:
        this.ErrorDescriptionText.LocText = this.CouldNotConnect;
        break;
      case ErrorMessagehandler.땶.땄:
        this.ErrorDescriptionText.LocText = this.InvalidCredentials;
        break;
      case ErrorMessagehandler.땶.딧:
        this.ErrorDescriptionText.LocText = this.InvalidEmail;
        break;
      case ErrorMessagehandler.땶.딢:
        this.ErrorDescriptionText.LocText = this.InvalidUserNameLength;
        break;
      case ErrorMessagehandler.땶.땃:
        this.ErrorDescriptionText.LocText = this.InvalidUserName;
        break;
      case ErrorMessagehandler.땶.딶:
        this.ErrorDescriptionText.LocText = this.InvalidPassword;
        break;
      case ErrorMessagehandler.땶.땓:
        this.ErrorDescriptionText.LocText = this.InvalidUser;
        break;
      case ErrorMessagehandler.땶.땺:
        this.ErrorDescriptionText.LocText = this.AlreadyRequested;
        break;
      case ErrorMessagehandler.땶.땥:
        this.ErrorDescriptionText.LocText = this.AlreadyFriend;
        break;
      case ErrorMessagehandler.땶.딝:
        this.ErrorDescriptionText.LocText = this.EmailInUse;
        break;
      case ErrorMessagehandler.땶.떎:
        this.ErrorDescriptionText.LocText = this.UserNameInUse;
        break;
      case ErrorMessagehandler.땶.떂:
        this.ErrorDescriptionText.LocText = this.TooManyGames;
        break;
      case ErrorMessagehandler.땶.땭:
        this.ErrorDescriptionText.LocText = this.GameOutOfDate;
        break;
      case ErrorMessagehandler.땶.딦:
        this.ErrorDescriptionText.LocText = this.OpponentTooManyGames;
        break;
      case ErrorMessagehandler.땶.땤:
        this.ErrorDescriptionText.LocText = this.FriendLimitReached;
        break;
      case ErrorMessagehandler.땶.땽:
        this.ErrorDescriptionText.LocText = this.ServerIsDown;
        break;
      case ErrorMessagehandler.땶.땋:
        this.ErrorDescriptionText.LocText = this.MissingContent;
        break;
      case ErrorMessagehandler.땶.땲:
        this.ErrorDescriptionText.LocText = this.AlreadyRedeemed;
        break;
      case ErrorMessagehandler.땶.땼:
        this.ErrorDescriptionText.Text = "Placeholder: This user is lacking an access key to access the title.";
        break;
      case ErrorMessagehandler.땶.땢:
        this.ErrorDescriptionText.LocText = this.DownloadingContentCheckNetwork;
        break;
      case ErrorMessagehandler.땶.딷:
        this.ErrorDescriptionText.LocText = this.DownloadingContentPleaseWait;
        break;
    }
    this.ErrorDescriptionText.UpdateMesh();
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (ErrorMessagehandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      ErrorMessagehandler.딟 = new Dictionary<string, int>(1)
      {
        {
          "Close",
          0
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!ErrorMessagehandler.딟.TryGetValue(key, out num) || num != 0)
      return;
    this.딟.Close();
    if (this.OnClosing != null)
      this.OnClosing((object) this, EventArgs.Empty);
    if (this.OnClosedCallback != null)
      this.OnClosedCallback();
    Object.Destroy((Object) ((Component) this).gameObject);
  }

  private void Update()
  {
    if (!((Component) this).animation.isPlaying && !this.딟)
    {
      ((Component) this.ConfirmButton).gameObject.SetActive(true);
      ((Component) this.ErrorText).gameObject.SetActive(true);
      ((Component) this.ErrorDescriptionText).gameObject.SetActive(true);
      this.딟 = true;
    }
    if (!Input.GetKeyDown((KeyCode) 13))
      return;
    ((Component) this).SendMessageUpwards("OnButtonPressed", (object) "Close");
  }

  public enum 땶
  {
    딟,
    땄,
    딧,
    딢,
    땃,
    딶,
    땓,
    땺,
    땥,
    딝,
    떎,
    떂,
    땭,
    딦,
    땤,
    땽,
    땋,
    땲,
    떏,
    땼,
    땢,
    딷,
  }
}
