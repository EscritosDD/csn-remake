// Decompiled with JetBrains decompiler
// Type: TryBeforeYouBuyPanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

public class TryBeforeYouBuyPanelHandler : MonoBehaviour
{
  public GameObject unitThumb;
  public LocalisationEntry locText;
  public GuiMultiLineText3D text;
  public GuiText3D header;
  private int 딟;
  private 딢.딳.땝 딟;
  private string 딟;
  private UnitClass 딟;
  private string 땄;
  private bool 딟;
  private bool 땄;
  private bool 딧;
  private BaseMenuHandler 딟;
  private MenuOverlayHandler 딟;
  private List<땓.떀> 딟;
  public MenuOverlayHandler MenuOverlayPrefab;

  public bool Init(BaseMenuHandler launchingScreen, int dateOffset)
  {
    this.딟 = dateOffset;
    this.딟 = launchingScreen;
    this.딟 = this.GetDailyCharacterId();
    this.딧 = false;
    if (string.IsNullOrEmpty(this.딟))
      return false;
    this.FindCharacterInfo();
    this.SetUnitIcon();
    this.SetText();
    return true;
  }

  public void Init(BaseMenuHandler launchingScreen, 땃.딷 characterItem)
  {
    this.딟 = launchingScreen;
    this.딟 = characterItem.딧();
    this.딧 = true;
    this.FindCharacterInfo();
    this.SetUnitIcon();
    this.SetText();
    ((Component) this.header).gameObject.SetActive(false);
    this.땄 = true;
  }

  public void Open()
  {
    ((Component) this).gameObject.SetActive(true);
    this.딟 = true;
    this.딟 = Object.Instantiate((Object) this.MenuOverlayPrefab) as MenuOverlayHandler;
    ((Component) this.딟).transform.position = new Vector3((float) ((Component) this).transform.position.x, (float) (((Component) this).transform.position.y - 0.100000001490116), (float) ((Component) this).transform.position.z);
  }

  public Material GetCharacterIcon() => Object.op_Inequality((Object) this.딟, (Object) null) ? this.딟.CharacterIcon : (Material) null;

  private void Update()
  {
    if (!this.딟 || this.딟 == null || !this.딟.땄())
      return;
    딶.땖 GameToLoad = this.딟.딟();
    this.딟 = (딢.딳.땝) null;
    if (GameToLoad == null)
    {
      Debug.Log((object) "Game State is null");
    }
    else
    {
      this.딟.DeactivateMenu();
      this.Close();
      FrontendHub.딟.LoadingScreen.ActivateMenu(GameToLoad, true);
    }
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (TryBeforeYouBuyPanelHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      TryBeforeYouBuyPanelHandler.딟 = new Dictionary<string, int>(2)
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
    if (!TryBeforeYouBuyPanelHandler.딟.TryGetValue(key, out num))
      return;
    if (num != 0)
    {
      if (num != 1)
        return;
      this.Close();
    }
    else
      this.LoadTryOutChallenge();
  }

  private void Close()
  {
    if (Object.op_Inequality((Object) this.딟, (Object) null))
      this.딟.Close();
    if (this.땄)
      Object.Destroy((Object) ((Component) this).gameObject);
    else
      ((Component) this).gameObject.SetActive(false);
  }

  private void FindCharacterInfo()
  {
    foreach (딢.땥 땥 in GlobalAppData.땼().땭())
    {
      if (땥.땄() == this.딟 || 땥.땭() == this.딟)
      {
        this.딟 = 땥.떂();
        this.땄 = 땥.떎();
      }
    }
  }

  private string GetDailyCharacterId()
  {
    this.딟 = GlobalAppData.땽().땲();
    List<딢.땥> 땥List = new List<딢.땥>();
    foreach (딢.땥 땥 in GlobalAppData.땼().땭())
    {
      if (!this.OwnsCharacter(땥.딧()) && !string.IsNullOrEmpty(땥.땄()))
        땥List.Add(땥);
    }
    if (땥List.Count <= 0)
      return (string) null;
    DateTime universalTime = DateTime.Today.ToUniversalTime();
    int index = (universalTime.Year * 365 + universalTime.Month * 30 + universalTime.Day + this.딟) % 땥List.Count;
    return 땥List[index].땄();
  }

  private bool OwnsCharacter(string characterId)
  {
    foreach (땓.떀 떀 in this.딟)
    {
      if (characterId == 떀.떔())
        return true;
    }
    return false;
  }

  private void LoadTryOutChallenge()
  {
    if (!string.IsNullOrEmpty(this.땄))
    {
      SinglePlayerMissionAsset playerMissionAsset = GlobalAppData.땃(this.땄);
      if (Object.op_Inequality((Object) playerMissionAsset, (Object) null))
      {
        GlobalAppData.땄(this.딧);
        this.딟 = 딢.딳.땄(playerMissionAsset);
      }
      else
        Debug.LogWarning((object) ("No tryout mission exists with id: " + this.땄));
    }
    else
      Debug.LogWarning((object) ("No tryout mission specific for character with product id: " + this.딟));
  }

  private void SetUnitIcon()
  {
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    this.unitThumb.SetActive(true);
    this.unitThumb.renderer.sharedMaterial = this.딟.CharacterIcon;
  }

  private void SetText()
  {
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    this.text.Text = 딧.딪.딟(this.locText, (object) 딧.딪.딟(this.딟.DefaultName, (object[]) null));
    this.text.UpdateMesh();
  }
}
