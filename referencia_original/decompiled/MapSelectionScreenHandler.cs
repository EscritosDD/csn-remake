// Decompiled with JetBrains decompiler
// Type: MapSelectionScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

[AddComponentMenu("Gui3D/Screens/Map Selection")]
public class MapSelectionScreenHandler : BaseMenuHandler
{
  private new Vector3 딟;
  private int 딟 = -1;
  private 딧.땧 딟;
  private new BaseMenuHandler 딟;
  private List<MapSelectionScreenHandler.딽> 딟 = new List<MapSelectionScreenHandler.딽>();
  private bool 딟;
  private bool 땄;
  private LoadingScreenOverlayHandler 딟;
  public Camera IntroCamera;
  public float MapSpacing = 1f;
  public GuiScroller3D MapScroller;
  public GuiText3D MapText;
  public Transform MapVisualsPrefab;
  public Transform MapSpawnPoint;
  public Camera MapCamera;
  public GameObject RandomMapIconPrefab;
  public LocalisationEntry RandomText;
  public GameObject MoreArrow;
  public GuiText3D MoreText;
  public GameObject LeftMoreArrow;
  public GuiText3D LeftMoreText;
  public GuiButton3D ContinueButton;
  public LoadingScreenOverlayHandler LoadingOverlayPrefab;
  public GameObject NewUserFlowHighlight;
  public GameObject leftScrollButton;
  public GameObject rightScrollButton;
  private bool 딧;

  private void Start()
  {
    base.딟 = ((Component) this).transform.position;
    this.딟 = ((Component) this.MapSpawnPoint).transform.position;
    this.NewUserFlowHighlight.SetActive(false);
    GlobalAppData.땼().땓();
  }

  private void DestroyMapVisuals()
  {
    foreach (MapSelectionScreenHandler.딽 딽 in this.딟)
      Object.Destroy((Object) 딽.딟);
    this.딟.Clear();
    this.딟 = -1;
  }

  private void CreateMapVisuals()
  {
    float num = 0.0f;
    foreach (MapSelectionScreenHandler.딽 딽 in this.딟)
    {
      if (딽.딟 == MapSelectionScreenHandler.딽.MapType.Random)
      {
        GameObject gameObject = Object.Instantiate((Object) this.RandomMapIconPrefab) as GameObject;
        gameObject.transform.parent = ((Component) this.MapSpawnPoint).transform;
        gameObject.transform.position = Vector3.op_Addition(this.MapSpawnPoint.position, new Vector3(num, 0.0f, 0.0f));
        gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 270f, 270f));
        딽.딟 = gameObject;
      }
      else if (딽.딟 == MapSelectionScreenHandler.딽.MapType.Normal)
      {
        GameObject gameObject1 = GlobalAppData.땼().땲(딽.딟());
        if (Object.op_Inequality((Object) gameObject1, (Object) null))
        {
          GameObject gameObject2 = Object.Instantiate((Object) gameObject1) as GameObject;
          gameObject2.SetActive(true);
          gameObject2.transform.parent = ((Component) this.MapSpawnPoint).transform;
          gameObject2.transform.position = Vector3.op_Addition(this.MapSpawnPoint.position, new Vector3(num, 0.0f, 0.0f));
          딽.딟 = gameObject2.gameObject;
        }
      }
      else if (딽.딟 == MapSelectionScreenHandler.딽.MapType.MapPack)
      {
        딢.떁 떁 = GlobalAppData.땼().딱(딽.딟());
        if (떁 != null)
        {
          GameObject gameObject3 = 떁.딟.딧();
          if (Object.op_Inequality((Object) gameObject3, (Object) null))
          {
            GameObject gameObject4 = Object.Instantiate((Object) gameObject3) as GameObject;
            gameObject4.SetActive(true);
            gameObject4.transform.parent = ((Component) this.MapSpawnPoint).transform;
            gameObject4.transform.position = Vector3.op_Addition(this.MapSpawnPoint.position, new Vector3(num, 0.0f, 0.0f));
            딽.딟 = gameObject4.gameObject;
          }
        }
      }
      ++num;
    }
    this.MapScroller.MinOffset = 0.0f;
    this.MapScroller.MaxOffset = (float) (this.딟.Count - 1) * this.MapSpacing;
    this.MapScroller.SpringBounds = this.MapSpacing * 0.5f;
    this.MapScroller.NumElements = this.딟.Count;
    this.MapScroller.UpdateControl();
    this.MapScroller.set_ScrollStartCallback(new Action(this.ScrollingStarted));
    this.MapScroller.set_ScrollEndCallback(new Action(this.ScrollingStopped));
  }

  private void Update()
  {
    if (this.딟)
    {
      if (!((딟.딗) GlobalAppData.땼()).땽())
      {
        this.딟 = false;
        this.CreateMapVisuals();
      }
      else if (!this.땄)
      {
        this.딟 = Object.Instantiate((Object) this.LoadingOverlayPrefab, new Vector3(0.0f, 1.6f, 0.0f), Quaternion.identity) as LoadingScreenOverlayHandler;
        this.땄 = true;
      }
    }
    else
    {
      if (this.땄)
      {
        this.딟.Close();
        this.땄 = false;
      }
      if (this.딟.Count > 0 && this.딟 != this.MapScroller.get_ActiveElement())
      {
        this.딟 = this.MapScroller.get_ActiveElement();
        MapSelectionScreenHandler.딽 딽 = this.딟[this.딟];
        switch (딽.딟)
        {
          case MapSelectionScreenHandler.딽.MapType.Random:
            this.MapText.LocText = this.RandomText;
            break;
          case MapSelectionScreenHandler.딽.MapType.Normal:
            this.MapText.LocText = GlobalAppData.땼().딷(딽.딟());
            break;
          case MapSelectionScreenHandler.딽.MapType.MapPack:
            this.MapText.LocText = GlobalAppData.땼().딱(딽.딟()).딟.딧();
            break;
        }
        this.MapText.UpdateMesh();
        if (this.딟 == this.딟.Count - 1)
        {
          ((Component) this.MoreText).gameObject.SetActive(false);
          this.MoreArrow.SetActive(false);
        }
        else
        {
          ((Component) this.MoreText).gameObject.SetActive(true);
          this.MoreArrow.SetActive(true);
        }
        if (this.딟 > 0)
        {
          this.LeftMoreArrow.SetActive(true);
          ((Component) this.LeftMoreText).gameObject.SetActive(true);
        }
        else
        {
          this.LeftMoreArrow.SetActive(false);
          ((Component) this.LeftMoreText).gameObject.SetActive(false);
        }
      }
    }
    Vector3 딟 = this.딟;
    ref Vector3 local = ref 딟;
    local.x = (__Null) (local.x - (double) this.MapScroller.get_Offset());
    ((Component) this.MapSpawnPoint).transform.position = 딟;
    if (this.딟 != -1)
    {
      if (this.딟[this.딟].딟 == MapSelectionScreenHandler.딽.MapType.MapPack)
      {
        ((Component) this.ContinueButton).gameObject.SetActive(false);
        this.NewUserFlowHighlight.SetActive(false);
      }
      else
      {
        ((Component) this.ContinueButton).gameObject.SetActive(true);
        if (this.딟.딢())
          this.NewUserFlowHighlight.SetActive(true);
      }
    }
    this.UpdateScrollerButtons();
  }

  private void UpdateScrollerButtons()
  {
    if (this.MapScroller.get_ActiveElement() == 0)
      this.SetGameObjectActive(this.leftScrollButton, false);
    else if (!this.딧)
      this.SetGameObjectActive(this.leftScrollButton, true);
    if (this.MapScroller.get_ActiveElement() == this.MapScroller.NumElements - 1)
    {
      this.SetGameObjectActive(this.rightScrollButton, false);
    }
    else
    {
      if (this.딧)
        return;
      this.SetGameObjectActive(this.rightScrollButton, true);
    }
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (MapSelectionScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      MapSelectionScreenHandler.딟 = new Dictionary<string, int>(5)
      {
        {
          "Back",
          0
        },
        {
          "Continue",
          1
        },
        {
          "BuyMaps",
          2
        },
        {
          "ScrollLeft",
          3
        },
        {
          "ScrollRight",
          4
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!MapSelectionScreenHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        this.DeactivateMenu();
        this.딟.ActivateMenu();
        break;
      case 1:
        if (this.딟 == -1)
          break;
        딧.땧 LoadingInfo = this.딟.딟();
        MapSelectionScreenHandler.딽 딽 = this.딟[this.딟];
        if (딽.딟 == MapSelectionScreenHandler.딽.MapType.MapPack)
        {
          딢.땟 땟 = GlobalAppData.땼().딳(딽.딟());
          this.DeactivateMenu();
          FrontendHub.딟.StoreScreen.ActivateMenu(땃.땽.딧, 땟.땄());
          break;
        }
        if (딽.딟 == MapSelectionScreenHandler.딽.MapType.Random)
        {
          this.SelectRandomMap(LoadingInfo);
        }
        else
        {
          LoadingInfo.딟(딽.딟());
          LoadingInfo.땄(false);
        }
        this.DeactivateMenu();
        if (this.딟.땺() == 딶.딹.딧)
        {
          FrontendHub.딟.CommanderAbilityScreen.TryActivateMenu(딶.땂.딟, LoadingInfo, (BaseMenuHandler) this);
          break;
        }
        if (this.딟.땺() == 딶.딹.땄)
        {
          FrontendHub.딟.CommanderAbilityScreen.TryActivateMenu(딶.땂.딟, LoadingInfo, (BaseMenuHandler) this);
          break;
        }
        if (this.딟.땺() != 딶.딹.딟)
          break;
        FrontendHub.딟.AuthScreen.ActivateMenu(딶.땂.딟, true, LoadingInfo);
        break;
      case 2:
        if (GlobalAppData.떏().땥())
        {
          this.DeactivateMenu();
          FrontendHub.딟.StoreScreen.ActivateMenu(땃.땽.떂);
          break;
        }
        FrontendHub.딟.LoginHandler.LoginAttempt(true);
        break;
      case 3:
        if (this.MapScroller.get_ActiveElement() == 0)
          break;
        this.MapScroller.DecrementScroller();
        break;
      case 4:
        if (this.MapScroller.get_ActiveElement() == this.MapScroller.NumElements - 1)
          break;
        this.MapScroller.IncrementScroller();
        break;
    }
  }

  public void ActivateMenu(bool Restart, 딧.땧 LoadingInfo, BaseMenuHandler ReturnScreen)
  {
    base.ActivateMenu();
    if (Restart)
    {
      this.딟 = LoadingInfo;
      this.딟 = ReturnScreen;
    }
    FrontendHub.딟.MoneyDisplay.UpdateDisplay(true, MoneyDisplayHandler.딤.땭);
    ((Component) this.MapCamera).gameObject.SetActive(true);
    this.딟.Add(new MapSelectionScreenHandler.딽((string) null, MapSelectionScreenHandler.딽.MapType.Random));
    foreach (딢.땢 땢 in GlobalAppData.땼().땲())
    {
      if (GlobalAppData.땼().땄(땢.딧(), 딢.딛.딣.땃) && GlobalAppData.땽().딶(땢.땄()) && !땢.떂())
      {
        this.딟.Add(new MapSelectionScreenHandler.딽(땢.딧(), MapSelectionScreenHandler.딽.MapType.Normal));
        GlobalAppData.땼().딶(땢.딧());
        GlobalAppData.땼().땄(땢.딧());
      }
    }
    foreach (딢.땟 땟 in GlobalAppData.땼().땼())
    {
      string[] strArray = 땟.땓();
      if (GlobalAppData.땼().딢((딟.땩) 땟))
      {
        bool flag = false;
        foreach (string str in strArray)
        {
          딢.땢 땢 = GlobalAppData.땼().땻(str);
          if (!GlobalAppData.땽().딶(땢.땄()))
            flag = true;
        }
        if (flag)
        {
          this.딟.Add(new MapSelectionScreenHandler.딽(땟.딧(), MapSelectionScreenHandler.딽.MapType.MapPack));
          GlobalAppData.땼().땭(땟.딧());
        }
      }
    }
    if (((Component) this.IntroCamera).gameObject.activeInHierarchy)
      ((Component) this.IntroCamera).gameObject.SetActive(false);
    this.딟 = true;
    this.딟 = -1;
    if (this.딟.땄())
    {
      딧.땧 LoadingInfo1 = this.딟.딟();
      this.SelectRandomMap(LoadingInfo1);
      this.DeactivateMenu();
      FrontendHub.딟.CommanderAbilityScreen.TryActivateMenu(딶.땂.딟, LoadingInfo1, ReturnScreen);
    }
    if (!this.딟.딢())
      return;
    this.NewUserFlowHighlight.SetActive(딢.땚.딢());
  }

  private void SelectRandomMap(딧.땧 LoadingInfo)
  {
    IEnumerable<MapSelectionScreenHandler.딽> source = this.딟.Where<MapSelectionScreenHandler.딽>((Func<MapSelectionScreenHandler.딽, bool>) (obj0 => obj0.딟 == MapSelectionScreenHandler.딽.MapType.Normal));
    int index = Random.Range(0, source.Count<MapSelectionScreenHandler.딽>());
    MapSelectionScreenHandler.딽 딽 = source.ElementAt<MapSelectionScreenHandler.딽>(index);
    LoadingInfo.딟(딽.딟());
    LoadingInfo.땄(true);
  }

  public override void ActivateMenu()
  {
    base.ActivateMenu();
    this.ActivateMenu(false, (딧.땧) null, (BaseMenuHandler) null);
  }

  public override void DeactivateMenu()
  {
    base.DeactivateMenu();
    ((Component) this.MapCamera).gameObject.SetActive(false);
    this.DestroyMapVisuals();
  }

  public void ScrollingStopped()
  {
    this.딧 = false;
    if (this.MapScroller.get_ActiveElement() != 0)
      this.leftScrollButton.SetActive(true);
    if (this.MapScroller.get_ActiveElement() == this.MapScroller.NumElements - 1)
      return;
    this.rightScrollButton.SetActive(true);
  }

  public void ScrollingStarted()
  {
    this.딧 = true;
    this.leftScrollButton.SetActive(false);
    this.rightScrollButton.SetActive(false);
  }

  private class 딽
  {
    public GameObject 딟;
    public MapSelectionScreenHandler.딽.MapType 딟;

    public 딽([In] string obj0, [In] MapSelectionScreenHandler.딽.MapType obj1)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0);
      this.딟 = obj1;
    }

    [CompilerGenerated]
    [SpecialName]
    public string 딟() => this.딟;

    public enum MapType
    {
      Random,
      Normal,
      MapPack,
    }
  }
}
