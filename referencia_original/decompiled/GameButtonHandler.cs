// Decompiled with JetBrains decompiler
// Type: GameButtonHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using UnityEngine;

public class GameButtonHandler : MonoBehaviour
{
  private 땄.땞 딟;
  private int 딟;
  private 땓.땶 딟;
  private 땄.딽 딟;
  private GuiScrollList3D 딟;
  private bool 딟;
  private bool 땄;
  private 딢.땿 딟 = new 딢.땿();
  private bool 딧;
  private GameButtonHandler.땗 딟;
  private Renderer[] 딟;
  private float 딟;
  public GuiButton3D SelectionButton;
  public GameObject AvatarIcon;
  public GameObject AvatarBackground;
  public Shader IconShader;
  public GuiText3D OpponentNameText;
  public GuiText3D LastTurnTakenText;
  public GuiText3D MapNameText;
  public GameObject TierIcon;
  public GuiText3D TierNumberText;
  public GuiText3D PlayerLevelText;
  public GameObject PlayerLevelDisplay;
  public GameObject LoadingOverlay;
  public GameObject DownloadIcon;
  public GameObject LoadingSpinner;
  public GuiText3D LoadingOverlayText;
  public GameObject LevelDisplayLeft;
  public GameObject LevelDisplayRight;
  public GameObject XPBoostIcon;
  public GameObject CoinBoostIcon;
  public GameObject ButtonLeft;
  public GameObject ButtonMiddle_01a_Left;
  public GameObject ButtonMiddle_01a_Right;
  public GameObject ButtonMiddle_01b;
  public GameObject ButtonMiddle_01c;
  public GameObject ButtonMiddle_01d;
  public Material ButtonGreyAlpha;
  public Material ButtonGreyNoAlpha;
  public Material ButtonPurpleAlpha;
  public Material ButtonPurpleNoAlpha;
  public Material AvatarBackgroundGrey;
  public LocalisationEntry WaitingForOpponentText;
  public LocalisationEntry Loading;
  public LocalisationEntry DownloadingNewContent;
  public LocalisationEntry LastTurnTakenHours;
  public LocalisationEntry LastTurnTakenMinutes;
  public LocalisationEntry LastTurnTakenDays;
  public LocalisationEntry Expired;
  public AnimationCurve TextFadeInCurve;
  public AnimationCurve TextFadeOutCurve;
  public float LerpTime;
  private 딢.딘 딟;
  private Action<딶.땖> 딟;

  public void Init(
    GuiScrollList3D MatchList,
    string SessionId,
    bool IsActive,
    Action<딶.땖> GameStatePatcher,
    bool IsExpired)
  {
    this.InitBase(MatchList, IsActive, GameStatePatcher, IsExpired);
    this.딟 = new 딢.딘(SessionId);
    this.InitSessionLoader(this.딟);
  }

  public void Init(
    GuiScrollList3D MatchList,
    땄.땞 SessionInfo,
    bool IsActive,
    Action<딶.땖> GameStatePatcher,
    bool IsExpired)
  {
    this.InitBase(MatchList, IsActive, GameStatePatcher, IsExpired);
    this.딟 = new 딢.딘(SessionInfo);
    this.InitSessionLoader(this.딟);
    this.OnSessionInfoReceived(SessionInfo);
  }

  private void InitSessionLoader(딢.딘 SessionLoader)
  {
    SessionLoader.딟(new Action<땄.땞>(this.OnSessionInfoReceived));
    SessionLoader.딟(new Action<땄.딽>(this.OnOpponentUserLoaded));
    SessionLoader.딟(new Action(this.OnDownloadStarted));
    SessionLoader.딧(new Action(this.OnGameLoading));
    SessionLoader.딟(new Action<딶.땖>(this.OnGameLoaded));
    SessionLoader.땃(new Action(this.OnLoadFailed));
  }

  private void InitBase(
    GuiScrollList3D MatchList,
    bool IsActive,
    Action<딶.땖> GameStatePatcher,
    bool IsExpired)
  {
    this.딟 = IsActive;
    this.딟 = MatchList;
    this.딟 = GameStatePatcher;
    this.땄 = IsExpired;
    this.OpponentNameText.Text = (string) null;
    this.XPBoostIcon.SetActive(false);
    this.CoinBoostIcon.SetActive(false);
    if (!IsActive)
    {
      this.AvatarBackground.renderer.material = this.AvatarBackgroundGrey;
      this.AvatarBackground.renderer.sharedMaterial = GlobalAppData.땲().딟(this.AvatarBackground.renderer.material, this.IconShader);
      this.ButtonLeft.renderer.material = this.ButtonGreyAlpha;
      this.ButtonMiddle_01a_Left.renderer.material = this.ButtonGreyNoAlpha;
      this.ButtonMiddle_01a_Right.renderer.material = this.ButtonGreyNoAlpha;
      this.ButtonMiddle_01b.renderer.material = this.ButtonGreyNoAlpha;
      this.ButtonMiddle_01c.renderer.material = this.ButtonGreyNoAlpha;
      this.ButtonMiddle_01d.renderer.material = this.ButtonGreyNoAlpha;
    }
    this.TierIcon.renderer.material = GlobalAppData.땲().딟(this.TierIcon.renderer.material, this.IconShader);
    this.LevelDisplayLeft.renderer.material = GlobalAppData.땲().딟(this.LevelDisplayLeft.renderer.material, this.IconShader);
    this.LevelDisplayRight.renderer.material = GlobalAppData.땲().딟(this.LevelDisplayRight.renderer.material, this.IconShader);
    this.DownloadIcon.SetActive(false);
    this.DownloadIcon.renderer.sharedMaterial = GlobalAppData.땲().딟(this.DownloadIcon.renderer.material, this.IconShader);
    this.LoadingSpinner.SetActive(true);
    this.LoadingSpinner.renderer.sharedMaterial = GlobalAppData.땲().딟(this.LoadingSpinner.renderer.material, this.IconShader);
    this.CoinBoostIcon.renderer.sharedMaterial = GlobalAppData.땲().딟(this.CoinBoostIcon.renderer.material, this.IconShader);
    this.XPBoostIcon.renderer.sharedMaterial = GlobalAppData.땲().딟(this.XPBoostIcon.renderer.material, this.IconShader);
    this.LoadingOverlayText.LocText = this.Loading;
    this.LoadingOverlayText.Size = 0.07f;
    this.LoadingOverlayText.UpdateMesh();
  }

  private void OnSessionInfoReceived(땄.땞 SessionInfo)
  {
    this.딟 = SessionInfo;
    this.TierNumberText.Text = (SessionInfo.딟 as 땓.딿).딢().ToString();
    this.TierNumberText.UpdateMesh();
    if (this.땄)
    {
      this.LastTurnTakenText.LocText = this.Expired;
      this.ButtonLeft.renderer.material = this.ButtonPurpleAlpha;
      this.ButtonMiddle_01a_Left.renderer.material = this.ButtonPurpleNoAlpha;
      this.ButtonMiddle_01a_Right.renderer.material = this.ButtonPurpleNoAlpha;
      this.ButtonMiddle_01b.renderer.material = this.ButtonPurpleNoAlpha;
      this.ButtonMiddle_01c.renderer.material = this.ButtonPurpleNoAlpha;
      this.ButtonMiddle_01d.renderer.material = this.ButtonPurpleNoAlpha;
    }
    else
    {
      TimeSpan timeSpan = DateTime.Now.ToUniversalTime() - SessionInfo.딟.ToUniversalTime();
      if (timeSpan.TotalDays >= 1.0)
      {
        this.LastTurnTakenText.LocText = this.LastTurnTakenDays;
        this.LastTurnTakenText.set_LocTextParms(new object[1]
        {
          (object) Mathf.RoundToInt((float) timeSpan.TotalDays)
        });
      }
      else if (timeSpan.TotalHours >= 1.0)
      {
        this.LastTurnTakenText.LocText = this.LastTurnTakenHours;
        this.LastTurnTakenText.set_LocTextParms(new object[1]
        {
          (object) Mathf.RoundToInt((float) timeSpan.TotalHours)
        });
      }
      else
      {
        this.LastTurnTakenText.LocText = this.LastTurnTakenMinutes;
        this.LastTurnTakenText.set_LocTextParms(new object[1]
        {
          (object) Mathf.RoundToInt((float) timeSpan.TotalMinutes)
        });
      }
    }
    this.LastTurnTakenText.UpdateMesh();
  }

  private void OnDestroy()
  {
    GlobalAppData.땄(this.ButtonLeft);
    GlobalAppData.땄(this.ButtonMiddle_01a_Left);
    GlobalAppData.땄(this.ButtonMiddle_01a_Right);
    GlobalAppData.땄(this.ButtonMiddle_01b);
    GlobalAppData.땄(this.ButtonMiddle_01c);
    GlobalAppData.땄(this.ButtonMiddle_01d);
    GlobalAppData.땄(this.LevelDisplayLeft);
    GlobalAppData.땄(this.LevelDisplayRight);
    GlobalAppData.땄(this.TierIcon);
    GlobalAppData.땄(this.DownloadIcon);
    GlobalAppData.땄(this.LoadingSpinner);
    GlobalAppData.땄(this.AvatarIcon);
    GlobalAppData.땄(this.XPBoostIcon);
    GlobalAppData.땄(this.CoinBoostIcon);
  }

  private void OnGameLoading()
  {
    this.DownloadIcon.SetActive(false);
    this.LoadingSpinner.SetActive(true);
    this.LoadingOverlayText.LocText = this.Loading;
    this.LoadingOverlayText.Size = 0.07f;
    this.LoadingOverlayText.UpdateMesh();
  }

  private void OnGameLoaded(딶.땖 GameState)
  {
    if (this.딟 != null)
      this.딟(GameState);
    if (this.LoadingOverlay.gameObject.activeInHierarchy)
    {
      this.UpdateButtonInfo(GameState);
      this.LoadingOverlay.SetActive(false);
    }
    if (Object.op_Inequality((Object) this.SelectionButton, (Object) null))
    {
      if (this.딟)
      {
        this.SelectionButton.set_CustomPressFunc("OnGameSelected");
        this.SelectionButton.set_CustomPressValue((object) GameState);
      }
      else
        this.SelectionButton.Disabled = true;
    }
    if (!GlobalAppData.딧().LogHTTPInfo)
      return;
    ArbitrationErrorDisplay.딟(GameState);
  }

  private void OnDownloadStarted()
  {
    this.DownloadIcon.SetActive(true);
    this.LoadingSpinner.SetActive(false);
    this.LoadingOverlayText.LocText = this.DownloadingNewContent;
    this.LoadingOverlayText.Size = 0.07f;
    this.LoadingOverlayText.UpdateMesh();
  }

  private void OnLoadFailed()
  {
  }

  private void Update()
  {
    this.딟.딧();
    this.딟.딟();
    if (this.딟 != null && this.딟.딟())
    {
      if (this.딟.땄())
      {
        this.AvatarIcon.renderer.material = GlobalAppData.땲().딟(this.딟.딧(), this.IconShader);
        this.AvatarIcon.SetActive(true);
        this.딟.UpdateItemClipping();
        this.딟.딟(4f);
        this.딟 = GameButtonHandler.땗.딟;
        this.딧 = true;
      }
      this.딟 = (땓.땶) null;
    }
    if (!this.딧 || !this.딟.땄())
      return;
    this.딟 += Time.deltaTime / this.LerpTime;
    this.딟 = Mathf.Clamp01(this.딟);
    switch (this.딟)
    {
      case GameButtonHandler.땗.딟:
        this.FadeTextAndIcons(this.MapNameText, this.TextFadeOutCurve.Evaluate(this.딟), true);
        if ((double) this.딟 != 1.0)
          break;
        this.딟 = (Renderer[]) null;
        this.딟 = 0.0f;
        this.딟.딟(0.1f);
        this.딟 = GameButtonHandler.땗.땄;
        break;
      case GameButtonHandler.땗.땄:
        this.FadeTextAndIcons(this.LastTurnTakenText, this.TextFadeInCurve.Evaluate(this.딟), false);
        if ((double) this.딟 != 1.0)
          break;
        this.딟 = (Renderer[]) null;
        this.딟 = 0.0f;
        this.딟.딟(4f);
        this.딟 = GameButtonHandler.땗.딢;
        break;
      case GameButtonHandler.땗.딧:
        this.FadeTextAndIcons(this.MapNameText, this.TextFadeInCurve.Evaluate(this.딟), true);
        if ((double) this.딟 != 1.0)
          break;
        this.딟 = (Renderer[]) null;
        this.딟 = 0.0f;
        this.딟.딟(4f);
        this.딟 = GameButtonHandler.땗.딟;
        break;
      case GameButtonHandler.땗.딢:
        this.FadeTextAndIcons(this.LastTurnTakenText, this.TextFadeOutCurve.Evaluate(this.딟), false);
        if ((double) this.딟 != 1.0)
          break;
        this.딟 = (Renderer[]) null;
        this.딟 = 0.0f;
        this.딟.딟(0.1f);
        this.딟 = GameButtonHandler.땗.딧;
        break;
    }
  }

  private void OnOpponentUserLoaded(땄.딽 User)
  {
    this.딟 = User;
    if (User == null)
    {
      this.OpponentNameText.Text = 딧.딪.딟(this.WaitingForOpponentText);
      this.AvatarIcon.renderer.material = GlobalAppData.딟.GameAssets.UnknownOpponentAvatarClippedMaterial;
      this.AvatarIcon.SetActive(true);
      this.PlayerLevelDisplay.SetActive(false);
    }
    else
    {
      this.OpponentNameText.Text = this.딟.땄();
      땓.땇 땇 = User.땃() as 땓.땇;
      this.딟 = 땇.딢();
      this.딟 = 땇.딧();
      this.UpdatePlayerLevelText();
    }
  }

  private void FadeTextAndIcons(GuiText3D Text, float Val, bool FadeIcons)
  {
    if (this.딟 == null)
    {
      this.딟 = ((Component) Text).gameObject.GetComponentsInChildren<Renderer>();
    }
    else
    {
      Color color;
      // ISSUE: explicit constructor call
      ((Color) ref color).\u002Ector(1f, 1f, 1f, Val);
      foreach (Renderer renderer in this.딟)
        renderer.material.color = color;
      if (!FadeIcons)
        return;
      this.CoinBoostIcon.renderer.material.color = color;
      this.XPBoostIcon.renderer.material.color = color;
    }
  }

  private void UpdateButtonInfo(딶.땖 GameState)
  {
    this.OpponentNameText.UpdateMesh();
    땓.딿 딟 = this.딟.딟 as 땓.딿;
    int num1 = 딟.땄();
    string str = GlobalAppData.땼().땄(num1);
    this.MapNameText.LocText = GlobalAppData.땼().딷(str);
    this.MapNameText.UpdateMesh();
    int num2 = 딟.딢();
    this.TierNumberText.Text = GameState.땞().GenericData.땃(num2).MaxUnitSquadPoints.ToString();
    this.TierNumberText.UpdateMesh();
    this.UpdatePlayerLevelText();
    int num3 = GameState.땂();
    if (GameState.떂(num3))
      this.CoinBoostIcon.SetActive(true);
    if (GameState.떎(num3))
      this.XPBoostIcon.SetActive(true);
    this.딟.UpdateItemClipping();
  }

  private void UpdatePlayerLevelText()
  {
    this.PlayerLevelText.Text = this.딟.ToString();
    this.PlayerLevelText.UpdateMesh();
  }

  private enum 땗
  {
    딟,
    땄,
    딧,
    딢,
  }
}
