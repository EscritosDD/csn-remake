// Decompiled with JetBrains decompiler
// Type: LoadingScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LoadingScreenHandler : MonoBehaviour
{
  private CameraSettingsOverride 딟;
  private 딶.딡 딟;
  private 딶.땖 딟;
  private bool 딟;
  public LoadingVersusScreenHandler LoadingGameInfoHandler;
  public LoadingTutorialScreenHandler LoadingTutorialGameHandler;
  public AudioController AudioController;
  public GameplayHUDHandler HUD;
  public Camera GameCamera;
  public Camera UICamera;
  public DateTime LevelLoadTime;

  private void Start()
  {
    this.딟 = 딢.딳.딧();
    this.StartAssetsLoad();
    if (this.딟.떔() is 딶.딖)
    {
      this.LoadingTutorialGameHandler.InitailiseTutorailLoadScreen(this.딟);
      ((Component) this.LoadingGameInfoHandler).gameObject.SetActive(false);
    }
    else
    {
      this.LoadingGameInfoHandler.InitailiseVersusLoadScreen(this.딟);
      ((Component) this.LoadingTutorialGameHandler).gameObject.SetActive(false);
    }
    딟.딦.딟();
  }

  public void StartAssetsLoad()
  {
    if (this.딟 == null)
      return;
    foreach (딟.땩 땩 in this.딟.땟())
    {
      if (땩 != null)
        GlobalAppData.땼().딧(땩);
    }
    this.딟 = true;
  }

  public void LoadLevelAssets()
  {
    if (this.딟 && !((딟.딗) GlobalAppData.땼()).땽())
    {
      this.딟 = false;
      // ISSUE: reference to a compiler-generated method
      this.set_WaitingForLevelLoad(true);
      this.LevelLoadTime = DateTime.Now.AddSeconds(0.5);
    }
    if (!this.get_WaitingForLevelLoad() || !(DateTime.Now > this.LevelLoadTime))
      return;
    // ISSUE: reference to a compiler-generated method
    this.set_WaitingForLevelLoad(false);
    List<땓.딲> 딲List = this.딟.땻();
    for (int index = 0; index < 딲List.Count; ++index)
      딲List[index].땠();
    this.딟.떔().땓();
    GlobalAppData.딟.딟(this.딟);
    딢.땢 땢 = GlobalAppData.땼().땻(this.딟.딟.땄);
    if (땢 == null)
      Debug.LogError((object) ("Unknown level: " + this.딟.딟.땄));
    딢.땠 땠 = GlobalAppData.땼().땁(땢.땺());
    딢.땲 땲 = GlobalAppData.땼().딛(this.딟.딟.땄);
    딢.딟 딟 = GlobalAppData.땼().땹(땢.땥());
    LightmapData[] lightmapDataArray = new LightmapData[땲.딟.딟.Length];
    for (int index = 0; index < 땲.딟.딟.Length; ++index)
    {
      lightmapDataArray[index] = new LightmapData();
      lightmapDataArray[index].lightmapFar = 땲.딟.딟[index].딧();
    }
    LightmapSettings.lightmapsMode = (LightmapsMode) 0;
    LightmapSettings.lightmaps = lightmapDataArray;
    GameObject gameObject1 = 땲.딟.딶.딧();
    GameObject gameObject2 = 땲.딟.땄.딧();
    GameObject gameObject3 = 땲.딟.딟.딧();
    GameObject gameObject4 = 땲.딟.딧.딧();
    GameObject gameObject5 = 땲.딟.딢.딧();
    GameObject gameObject6 = 땲.딟.땃.딧();
    GameObject gameObject7 = Object.Instantiate((Object) gameObject2) as GameObject;
    gameObject7.SetActive(true);
    딟.땺().땄(gameObject7);
    if (Object.op_Inequality((Object) gameObject4, (Object) null))
    {
      GameObject gameObject8 = Object.Instantiate((Object) gameObject4) as GameObject;
      gameObject8.SetActive(true);
      딟.땺().땄(gameObject8);
      GlobalAppData.딟(gameObject8);
    }
    GlobalAppData.딟(gameObject7);
    if (Object.op_Inequality((Object) gameObject1, (Object) null))
    {
      GameObject gameObject9 = Object.Instantiate((Object) gameObject1) as GameObject;
      gameObject9.SetActive(true);
      GlobalAppData.딟(gameObject9);
      this.딟 = gameObject1.GetComponent<CameraSettingsOverride>();
    }
    if (Object.op_Inequality((Object) gameObject3, (Object) null))
    {
      GameObject gameObject10 = Object.Instantiate((Object) gameObject3) as GameObject;
      gameObject10.SetActive(true);
      GlobalAppData.딟(gameObject10);
    }
    if (Object.op_Inequality((Object) gameObject5, (Object) null))
    {
      GameObject gameObject11 = Object.Instantiate((Object) gameObject5) as GameObject;
      gameObject11.SetActive(true);
      GlobalAppData.딟(gameObject11);
    }
    if (Object.op_Inequality((Object) gameObject6, (Object) null))
    {
      GameObject gameObject12 = Object.Instantiate((Object) gameObject6) as GameObject;
      gameObject12.SetActive(true);
      GlobalAppData.딟(gameObject12);
    }
    if (땠 != null)
    {
      GameObject gameObject13 = Object.Instantiate((Object) 땠.땓()) as GameObject;
      gameObject13.SetActive(true);
      GlobalAppData.딟(gameObject13);
    }
    땢.딟.딟.InitAI(땲.딟.땓.딧(), 땲.딟.땺.딧());
    // ISSUE: reference to a compiler-generated method
    this.set_LoadingComplete(true);
    this.StartGame();
  }

  private void Update()
  {
    this.LoadLevelAssets();
    if (this.딟 == null || this.딟.떏())
      return;
    this.딟.땄();
  }

  private void StartGame()
  {
    if (GlobalAppData.땟())
      딟.딦.딟("NUF_Tutorial_Loaded");
    this.딟 = new 딶.딡();
    딶.딡.딟(this.딟);
    CameraAnimationWrapper animationWrapper = this.딟.떇();
    this.딟.딟 = ((Component) this.GameCamera).GetComponent<CameraController>();
    this.딟.딟.Game = this.딟;
    this.딟.딟.CameraAnimation = animationWrapper;
    if (Object.op_Inequality((Object) this.딟, (Object) null))
      this.딟.Init(((Component) this.딟.딟).camera, !Object.op_Equality((Object) animationWrapper, (Object) null) ? ((Component) animationWrapper).camera : (Camera) null);
    this.딟.딟 = this.AudioController;
    this.AudioController.Init();
    AudioListener component = ((Component) this.UICamera).GetComponent<AudioListener>();
    if (Object.op_Inequality((Object) component, (Object) null))
      ((Behaviour) component).enabled = false;
    this.딟.딟(this.딟, this.HUD, true);
    this.HUD.SetGameCameraActive(true);
    animationWrapper.StopAnims();
    double num = (double) GlobalAppData.딟.GameAssets.MusicShaders.GameStart.PlayOneShot(((Component) this).gameObject, 0.0f);
    if (this.딟.딟() && !this.딟.땼().딷())
      this.딟.딷().딟(딶.딨.딧);
    else
      this.딟.딷().딣();
    this.HUD.SetLoadingBackgroundActive(false);
  }

  [CompilerGenerated]
  [SpecialName]
  public bool get_WaitingForLevelLoad() => this.땄;

  [CompilerGenerated]
  [SpecialName]
  public bool get_LoadingComplete() => this.딧;
}
