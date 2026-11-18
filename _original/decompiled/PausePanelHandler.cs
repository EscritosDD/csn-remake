// Decompiled with JetBrains decompiler
// Type: PausePanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using 딶;

[AddComponentMenu("Gui3D/Components/Settings Panel")]
public class PausePanelHandler : MonoBehaviour
{
  private Vector3 딟;
  private Vector3 땄;
  private GameObject 딟;
  private MenuAnimatorHandler 딟;
  public GameObject AudioOnButton;
  public GameObject AudioOffButton;
  public GameObject MusicOnButton;
  public GameObject MusicOffButton;
  public GameObject RewindOffButton;
  public GameObject RewindOnButton;
  public CoinPotBoxHandler CoinPot;
  public GameStatusBoxHandler GameStatus;
  public GameObject Overlay;
  public GuiText3D FullscreenButtonText;
  public LocalisationEntry FullscreenText;
  public LocalisationEntry Windowedtext;

  public void PausePanelOpenAnimFinished()
  {
    딶.딡.땴().딟(true, true);
    // ISSUE: reference to a compiler-generated method
    this.set_PausePanelActive(true);
  }

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
    bool flag1 = 딶.딡.땴().땼().땃().Rules != 딶.땨.땃 && 딶.딡.땴().땼().딥().Count > 1;
    this.RewindOnButton.SetActive(flag1);
    this.RewindOffButton.SetActive(!flag1);
    this.딟.SetOnOpenFinishedCallback(new MenuAnimatorHandler.땔(this.PausePanelOpenAnimFinished));
    this.땄 = this.딟;
    ref Vector3 local = ref this.땄;
    local.y = (__Null) (local.y - 0.0500000007450581);
    this.딟 = Object.Instantiate((Object) this.Overlay, this.땄, Quaternion.identity) as GameObject;
    bool InTutorial = 딶.딡.땴().땼().떔() is 딖;
    bool flag2 = 딶.딡.땴().땼().떓() == 딹.땄;
    this.InitailiseCoinPot(!InTutorial && !flag2);
    this.InitailiseGameStatus(InTutorial);
    this.StartCoroutine(this.UpdateIsFullScreen());
  }

  [DebuggerHidden]
  private IEnumerator UpdateIsFullScreen() => (IEnumerator) new PausePanelHandler.\u003CUpdateIsFullScreen\u003Ec__Iterator16()
  {
    딟 = this
  };

  private void SetFullscreenText()
  {
    this.FullscreenButtonText.LocText = GlobalAppData.딱() ? this.Windowedtext : this.FullscreenText;
    this.FullscreenButtonText.UpdateMesh();
  }

  public void Init(Transform StartPoint, Transform EndPoint)
  {
    this.딟 = ((Component) this).GetComponent<MenuAnimatorHandler>();
    this.딟.StartPoint = StartPoint;
    this.딟.EndPoint = EndPoint;
    // ISSUE: reference to a compiler-generated method
    this.set_IsOpen(true);
  }

  private void InitailiseCoinPot(bool ShowCoinPot)
  {
    if (!Object.op_Inequality((Object) this.CoinPot, (Object) null))
      return;
    ((Component) this.CoinPot).gameObject.SetActive(ShowCoinPot);
    if (!ShowCoinPot)
      return;
    this.CoinPot.InitailiseCoinValueData();
  }

  private void InitailiseGameStatus(bool InTutorial)
  {
    if (!Object.op_Inequality((Object) this.GameStatus, (Object) null))
      return;
    ((Component) this.GameStatus).gameObject.SetActive(!InTutorial);
    if (InTutorial)
      return;
    this.GameStatus.InitailiseGameStatusBox(딶.딡.땴().땼(), 0, 1);
  }

  private void OnButtonPressed(string Command)
  {
    if (!this.get_PausePanelActive())
      return;
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (PausePanelHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      PausePanelHandler.딟 = new Dictionary<string, int>(9)
      {
        {
          "Home",
          0
        },
        {
          "Replay",
          1
        },
        {
          "AudioOn",
          2
        },
        {
          "AudioOff",
          3
        },
        {
          "MusicOn",
          4
        },
        {
          "MusicOff",
          5
        },
        {
          "Abandon",
          6
        },
        {
          "Back",
          7
        },
        {
          "FullscreenToggle",
          8
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!PausePanelHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        this.ClosePausePanel(false);
        딶.딡.땴().땢().OpenExitGamePanel(true);
        break;
      case 1:
        this.ClosePausePanel(false);
        딶.딡.땴().딷()?.땳();
        break;
      case 2:
        AudioShader2.땄(1f);
        AudioShader2.땄();
        this.AudioOnButton.SetActive(false);
        this.AudioOffButton.SetActive(true);
        break;
      case 3:
        AudioShader2.땄(0.0f);
        AudioShader2.땄();
        this.AudioOnButton.SetActive(true);
        this.AudioOffButton.SetActive(false);
        break;
      case 4:
        AudioShader2.딟(1f);
        AudioShader2.땄();
        this.MusicOnButton.SetActive(false);
        this.MusicOffButton.SetActive(true);
        break;
      case 5:
        AudioShader2.딟(0.0f);
        AudioShader2.땄();
        this.MusicOnButton.SetActive(true);
        this.MusicOffButton.SetActive(false);
        break;
      case 6:
        this.ClosePausePanel(false);
        딶.딡.땴().땢().OpenAbandonGamePanel(true);
        break;
      case 7:
        this.ClosePausePanel(false);
        break;
      case 8:
        GlobalAppData.땤();
        break;
    }
  }

  public void ClosePausePanel(bool CloseInstantly)
  {
    MenuOverlayHandler component = this.딟.GetComponent<MenuOverlayHandler>();
    if (CloseInstantly)
    {
      if (Object.op_Inequality((Object) component, (Object) null))
        component.CloseInstantly();
    }
    else if (Object.op_Inequality((Object) component, (Object) null))
      component.Close();
    this.딟.Close();
    딶.딡.땴().딟(false, this.get_PausePanelActive());
    // ISSUE: reference to a compiler-generated method
    this.set_PausePanelActive(false);
    if (CloseInstantly)
      this.딟.set_LerpVal(0.0f);
    // ISSUE: reference to a compiler-generated method
    this.set_IsOpen(false);
  }

  public void SetPausePanelStartPosition(Vector3 Pos) => this.딟 = Pos;

  public bool HasFinishedClosing() => !this.get_IsOpen() && (double) this.딟.LerpTime == 0.0;

  [CompilerGenerated]
  [SpecialName]
  public bool get_PausePanelActive() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public bool get_IsOpen() => this.땄;
}
