// Decompiled with JetBrains decompiler
// Type: EventDrivenMessagingPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class EventDrivenMessagingPopup : MonoBehaviour
{
  private MenuOverlayHandler 딟;
  private 딢.땕 딟;
  private bool 딟;
  private bool 땄;
  private Dictionary<string, string> 딟 = new Dictionary<string, string>();
  public LocalisationEntry OutfitsHeaderText;
  public LocalisationEntry WeaponsHeaderText;
  public LocalisationEntry RegisterHeaderText;
  public LocalisationEntry RecruitHeaderText;
  public LocalisationEntry[] MatchWonText;
  public LocalisationEntry OutfitsText;
  public LocalisationEntry WeaponsText;
  public LocalisationEntry RegisterText;
  public LocalisationEntry RecruitText;
  public LocalisationEntry MatchWonHeaderText;
  public Material OutfitsButtonMaterial;
  public Material WeaponsButtonMaterial;
  public Material RegisterButtonMaterial;
  public Material RecruitButtonMaterial;
  public Material MatchWonButtonMaterial;
  public Material CloseButtonNormalMaterial;
  public Material CloseButtonGreyMaterial;
  public Renderer CloseButtonIcon;
  public Renderer AcceptButtonIcon;
  public GuiText3D EventTitleText;
  public GuiMultiLineText3D EventText;
  public MenuOverlayHandler OverlayPrefab;

  public void Init(딢.땕 Event)
  {
    this.딟 = Event;
    this.땄 = (SystemInfo.deviceUniqueIdentifier.GetHashCode() & 1) != 0;
    this.딟.Add("grey", this.땄.ToString());
    this.CloseButtonIcon.sharedMaterial = !this.땄 ? this.CloseButtonNormalMaterial : this.CloseButtonGreyMaterial;
    switch (Event.딢())
    {
      case 딢.땪.땄:
        this.EventText.LocText = this.OutfitsText;
        this.EventText.set_LocTextParms(new object[2]
        {
          (object) Event.땄(),
          (object) Event.딧()
        });
        this.EventTitleText.LocText = this.OutfitsHeaderText;
        this.AcceptButtonIcon.sharedMaterial = this.OutfitsButtonMaterial;
        this.딟.Add("type", "outfit");
        break;
      case 딢.땪.딧:
        this.EventText.LocText = this.RecruitText;
        this.EventText.set_LocTextParms(new object[1]
        {
          (object) Event.땄()
        });
        this.EventTitleText.LocText = this.RecruitHeaderText;
        this.AcceptButtonIcon.sharedMaterial = this.RecruitButtonMaterial;
        this.딟.Add("type", "recruit");
        break;
      case 딢.땪.딢:
        this.EventText.LocText = this.RegisterText;
        this.EventTitleText.LocText = this.RegisterHeaderText;
        this.AcceptButtonIcon.sharedMaterial = this.RegisterButtonMaterial;
        this.딟.Add("type", "register");
        break;
      case 딢.땪.땃:
        this.EventText.LocText = this.WeaponsText;
        this.EventText.set_LocTextParms(new object[1]
        {
          (object) Event.땄()
        });
        this.EventTitleText.LocText = this.WeaponsHeaderText;
        this.AcceptButtonIcon.sharedMaterial = this.WeaponsButtonMaterial;
        this.딟.Add("type", "weapon");
        break;
      case 딢.땪.땓:
        this.EventText.LocText = this.RandomMatchWonText();
        this.EventTitleText.LocText = this.MatchWonHeaderText;
        this.AcceptButtonIcon.sharedMaterial = this.MatchWonButtonMaterial;
        this.딟.Add("type", "matchwon");
        break;
    }
    this.EventText.UpdateMesh();
    this.EventTitleText.UpdateMesh();
    딟.딦.딟("EvtMsgOpened", this.딟);
  }

  private LocalisationEntry RandomMatchWonText() => this.MatchWonText.Length == 0 ? (LocalisationEntry) null : this.MatchWonText[Random.Range(0, this.MatchWonText.Length)];

  private void Start()
  {
    this.딟 = Object.Instantiate((Object) this.OverlayPrefab) as MenuOverlayHandler;
    ((Component) this.딟).transform.position = Vector3.op_Subtraction(((Component) this).transform.position, new Vector3(0.0f, 0.1f, 0.0f));
  }

  private void OnButtonPressed(string Command)
  {
    if (this.딟)
      return;
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (EventDrivenMessagingPopup.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      EventDrivenMessagingPopup.딟 = new Dictionary<string, int>(2)
      {
        {
          "Accept",
          0
        },
        {
          "Close",
          1
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!EventDrivenMessagingPopup.딟.TryGetValue(key, out num))
      return;
    if (num != 0)
    {
      if (num != 1)
        return;
      딟.딦.딟("EvtMsgClosed", this.딟);
      this.딟.Close();
      Object.Destroy((Object) ((Component) this).gameObject);
    }
    else
    {
      딟.딦.딟("EvtMsgAccepted", this.딟);
      this.딟 = true;
      this.LoadNextScreen();
    }
  }

  private void LoadNextScreen()
  {
    switch (this.딟.딢())
    {
      case 딢.땪.땄:
        GlobalAppData.딟.딟(GlobalAppState.땊.떂);
        GlobalAppData.딟.땄(this.딟.딟());
        break;
      case 딢.땪.딧:
        GlobalAppData.딟.딟(GlobalAppState.땊.땥);
        GlobalAppData.딟.딟(this.딟.딟());
        break;
      case 딢.땪.딢:
        if (GlobalAppData.떏().땥())
        {
          GlobalAppData.딟.딟(GlobalAppState.땊.떎);
          break;
        }
        GlobalAppData.딟.딟(GlobalAppState.땊.땭);
        break;
      case 딢.땪.땃:
        GlobalAppData.딟.딟(GlobalAppState.땊.떂);
        GlobalAppData.딟.땄(this.딟.딟());
        break;
      case 딢.땪.땓:
        GlobalAppData.딟.딟(GlobalAppState.땊.땥);
        GlobalAppData.딟.딟(땃.땽.땓);
        break;
    }
    Application.LoadLevelAsync(GlobalAppData.딟.EnvSettings.ScenesAsset.Data.땄());
  }
}
