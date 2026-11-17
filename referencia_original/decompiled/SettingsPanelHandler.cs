// Decompiled with JetBrains decompiler
// Type: SettingsPanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[AddComponentMenu("Gui3D/Components/Settings Panel")]
public class SettingsPanelHandler : MonoBehaviour
{
  private GameObject 딟;
  private LogOffConfirmationPanelHandler 딟;
  private MenuAnimatorHandler 딟;
  public GameObject AudioOnButton;
  public GameObject AudioOffButton;
  public GameObject MusicOnButton;
  public GameObject MusicOffButton;
  public GameObject LoginButton;
  public GameObject LogoutButton;
  public GameObject RegisterButton;
  public GameObject DebugButton;
  public LogOffConfirmationPanelHandler LogOffPanelPrefab;
  public DebugPanelHandler DebugPanelPrefab;
  public GameObject Overlay;
  public string SupportURL;
  public GuiText3D FullscreenButtonText;
  public LocalisationEntry FullscreenText;
  public LocalisationEntry Windowedtext;

  private void Start()
  {
    if ((double) AudioShader2.땓() == 1.0)
    {
      this.AudioOnButton.SetActive(false);
      this.AudioOffButton.SetActive(true);
    }
    else
    {
      this.AudioOnButton.SetActive(true);
      this.AudioOffButton.SetActive(false);
    }
    if ((double) AudioShader2.딶() == 1.0)
    {
      this.MusicOnButton.SetActive(false);
      this.MusicOffButton.SetActive(true);
    }
    else
    {
      this.MusicOnButton.SetActive(true);
      this.MusicOffButton.SetActive(false);
    }
    if (GlobalAppData.떏().땥())
    {
      this.LogoutButton.SetActive(true);
      this.LoginButton.SetActive(false);
      this.RegisterButton.SetActive(false);
    }
    else
    {
      this.LogoutButton.SetActive(false);
      this.LoginButton.SetActive(true);
      this.RegisterButton.SetActive(false);
    }
    if (GlobalAppData.떏().땥() && !GlobalAppData.땽().땟())
    {
      this.LogoutButton.SetActive(false);
      this.LoginButton.SetActive(false);
      this.RegisterButton.SetActive(true);
    }
    this.DebugButton.SetActive(GlobalAppData.딧().AllowDebugInput);
  }

  public void Init(Transform StartPoint, Transform EndPoint)
  {
    this.딟 = ((Component) this).GetComponent<MenuAnimatorHandler>();
    this.딟 = Object.Instantiate((Object) this.Overlay, new Vector3(0.0f, 1.9f, 0.0f), Quaternion.identity) as GameObject;
    this.딟.StartPoint = StartPoint;
    this.딟.EndPoint = EndPoint;
    this.StartCoroutine(this.UpdateIsFullScreen());
  }

  [DebuggerHidden]
  private IEnumerator UpdateIsFullScreen() => (IEnumerator) new SettingsPanelHandler.\u003CUpdateIsFullScreen\u003Ec__Iterator17()
  {
    딟 = this
  };

  private void SetFullscreenText()
  {
    this.FullscreenButtonText.LocText = GlobalAppData.딱() ? this.Windowedtext : this.FullscreenText;
    this.FullscreenButtonText.UpdateMesh();
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (SettingsPanelHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      SettingsPanelHandler.딟 = new Dictionary<string, int>(14)
      {
        {
          "AudioOn",
          0
        },
        {
          "AudioOff",
          1
        },
        {
          "MusicOn",
          2
        },
        {
          "MusicOff",
          3
        },
        {
          "Back",
          4
        },
        {
          "Debug",
          5
        },
        {
          "Credits",
          6
        },
        {
          "Login",
          7
        },
        {
          "Logout",
          8
        },
        {
          "LogoutConfirm",
          9
        },
        {
          "LogoutClose",
          10
        },
        {
          "Support",
          11
        },
        {
          "Register",
          12
        },
        {
          "FullscreenToggle",
          13
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!SettingsPanelHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        AudioShader2.땄(1f);
        AudioShader2.땄();
        this.AudioOnButton.SetActive(false);
        this.AudioOffButton.SetActive(true);
        break;
      case 1:
        AudioShader2.땄(0.0f);
        AudioShader2.땄();
        this.AudioOnButton.SetActive(true);
        this.AudioOffButton.SetActive(false);
        break;
      case 2:
        AudioShader2.딟(1f);
        AudioShader2.땄();
        this.MusicOnButton.SetActive(false);
        this.MusicOffButton.SetActive(true);
        break;
      case 3:
        AudioShader2.딟(0.0f);
        AudioShader2.땄();
        this.MusicOnButton.SetActive(true);
        this.MusicOffButton.SetActive(false);
        break;
      case 4:
        this.Close();
        break;
      case 5:
        (Object.Instantiate((Object) this.DebugPanelPrefab) as DebugPanelHandler).Init(this.딟.StartPoint, this.딟.EndPoint);
        this.Close();
        break;
      case 6:
        this.딟.GetComponent<MenuOverlayHandler>().Close();
        FrontendHub.딟.MainScreen.DeactivateMenu();
        FrontendHub.딟.CreditsScreen.ActivateMenu();
        Object.Destroy((Object) ((Component) this).gameObject);
        break;
      case 7:
        this.딟.GetComponent<MenuOverlayHandler>().Close();
        this.딟.Close();
        FrontendHub.딟.LoginHandler.LoginAttempt(true);
        break;
      case 8:
        if (!Object.op_Equality((Object) this.딟, (Object) null))
          break;
        this.딟 = Object.Instantiate((Object) this.LogOffPanelPrefab) as LogOffConfirmationPanelHandler;
        ((Component) this.딟).transform.parent = ((Component) this).transform;
        break;
      case 9:
        this.딟.Close();
        GlobalAppData.떏().땭();
        딢.딳.딟();
        this.딟.GetComponent<MenuOverlayHandler>().Close();
        this.딟.Close();
        FrontendHub.딟.MainScreen.DeactivateMenu();
        FrontendHub.딟.SplashScreen.ActivateMenu();
        break;
      case 10:
        this.딟.Close();
        break;
      case 11:
        GlobalAppData.딶(this.SupportURL);
        break;
      case 12:
        this.딟.GetComponent<MenuOverlayHandler>().Close();
        this.딟.Close();
        FrontendHub.딟.MainScreen.DeactivateMenu();
        FrontendHub.딟.AccountInticementScreen.ActivateMenu();
        break;
      case 13:
        GlobalAppData.땤();
        break;
    }
  }

  public void Close()
  {
    if (Object.op_Inequality((Object) this.딟, (Object) null))
      this.딟.GetComponent<MenuOverlayHandler>().Close();
    this.딟.Close();
  }
}
