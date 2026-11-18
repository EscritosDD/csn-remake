// Decompiled with JetBrains decompiler
// Type: WarchestFriendButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class WarchestFriendButton : MonoBehaviour
{
  private 땄.땊 딟;
  private GuiScrollList3D 딟;
  private FriendRequestPanelHandler 딟;
  private FriendRequestSentPanel 딟;
  private 땓.땶 딟;
  private 땄.딽 딟;
  public GuiText3D NameText;
  public GuiButton3D Button;
  public GameObject SearchingSpinner;
  public GameObject AvatarBackground;
  public GameObject AvatarIcon;
  public GuiText3D ProfileRank;
  public float Spacing;
  public LocalisationEntry SearchingText;
  public LocalisationEntry FriendName;
  public LocalisationEntry SearchingForYourself;
  public FriendRequestPanelHandler FriendRequestPanelPrefab;

  public void Init(
    땄.땊 SearchResponse,
    GuiScrollList3D MainList,
    FriendRequestSentPanel FriendRequestSentPanelPrefab)
  {
    this.딟 = SearchResponse;
    this.딟 = MainList;
    this.딟 = FriendRequestSentPanelPrefab;
    this.NameText.LocText = this.SearchingText;
    this.NameText.UpdateMesh();
    MainList.UpdateItemClipping();
    this.SearchingSpinner.SetActive(true);
  }

  public void Update()
  {
    if (this.딟 != null && this.딟.땄())
    {
      if (this.딟.딧())
      {
        this.딟 = this.딟.딟;
        땓.땇 땇 = this.딟.땃() as 땓.땇;
        this.ProfileRank.Text = 땇.딢().ToString();
        this.ProfileRank.UpdateMesh();
        this.딟 = 땇.딧();
        if (this.딟.딟() == GlobalAppData.땽().떔())
        {
          this.NameText.LocText = this.SearchingForYourself;
          this.NameText.Size = 0.06f;
          this.NameText.UpdateMesh();
          this.딟.UpdateItemClipping();
          this.SearchingSpinner.SetActive(false);
        }
        else
        {
          this.NameText.LocText = (LocalisationEntry) null;
          this.NameText.Text = this.딟.땄();
          this.NameText.UpdateMesh();
          this.SearchingSpinner.SetActive(false);
          this.SetButtonInfo();
          this.Button.Disabled = false;
        }
        this.딟 = (땄.땊) null;
      }
      else
      {
        this.NameText.LocText = this.FriendName;
        this.NameText.UpdateMesh();
        this.딟.UpdateItemClipping();
        this.SearchingSpinner.SetActive(false);
      }
    }
    if (this.딟 == null || !this.딟.딟())
      return;
    if (this.딟.땄())
      this.AvatarIcon.renderer.sharedMaterial = this.딟.딧();
    this.딟 = (땓.땶) null;
  }

  private void SetButtonInfo()
  {
    this.NameText.UpdateMesh();
    this.딟.UpdateItemClipping();
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (WarchestFriendButton.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      WarchestFriendButton.딟 = new Dictionary<string, int>(1)
      {
        {
          "WarchestFriendSelected",
          0
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!WarchestFriendButton.딟.TryGetValue(key, out num) || num != 0)
      return;
    this.딟 = Object.Instantiate((Object) this.FriendRequestPanelPrefab) as FriendRequestPanelHandler;
    this.딟.Init((string) null, this.딟, false, this.딟, FrontendHub.딟.ChallengeFriendScreen.StartPoint, FrontendHub.딟.ChallengeFriendScreen.EndPoint);
  }

  private void OnDestroy()
  {
    Debug.Log((object) "In Destroy");
    if (Object.op_Inequality((Object) this.딟, (Object) null))
      Object.Destroy((Object) ((Component) this.딟).gameObject);
    GlobalAppData.땄(this.SearchingSpinner);
    GlobalAppData.땄(this.AvatarBackground);
    GlobalAppData.땄(this.AvatarIcon);
  }
}
