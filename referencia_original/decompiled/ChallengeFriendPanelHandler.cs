// Decompiled with JetBrains decompiler
// Type: ChallengeFriendPanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class ChallengeFriendPanelHandler : MonoBehaviour
{
  private MenuAnimatorHandler 딟;
  private GuiScrollList3D 딟;
  private FriendDeletionConfirmationPanelHandler 딟;
  private 땓.땶 딟;
  private 땄.딽 딟;
  private 땄.땣 딟;
  private GameObject 딟;
  private string 딟;
  private GameObject 땄;
  private ChallengeFriendScreenHandler 딟;
  private SquadPointSelectionScreenHandler 딟;
  private 딢.딪 딟;
  public FriendDeletionConfirmationPanelHandler FriendDeletionPanelPrefab;
  public GameObject Overlay;
  public GuiText3D ProfileName;
  public GameObject AvatarIcon;
  public GuiButton3D DeleteFriendButton;
  public GameLimit GameLimitPrefab;
  public EngineVersionChecker VersionCheckerPrefab;
  public float MaxNameLength;

  private void Start()
  {
  }

  public void Init(
    GameObject OriginButton,
    string FriendToInviteID,
    bool IsFacebookUser,
    GuiScrollList3D List,
    Transform StartPoint,
    Transform EndPoint)
  {
    this.딟 = ((Component) this).GetComponent<MenuAnimatorHandler>();
    this.딟.StartPoint = StartPoint;
    this.딟.EndPoint = EndPoint;
    this.딟 = Object.Instantiate((Object) this.Overlay, new Vector3(0.0f, 0.79f, 0.0f), Quaternion.identity) as GameObject;
    this.딟 = FrontendHub.딟.ChallengeFriendScreen;
    this.딟 = FrontendHub.딟.SquadPointSelectionScreen;
    this.딟 = FriendToInviteID;
    this.딟 = List;
    this.땄 = OriginButton;
    this.딟 = GlobalAppData.떏().땄(FriendToInviteID, false);
    if (!IsFacebookUser)
      return;
    ((Component) this.DeleteFriendButton).gameObject.SetActive(false);
  }

  public void Close() => this.딟.Close();

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (ChallengeFriendPanelHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      ChallengeFriendPanelHandler.딟 = new Dictionary<string, int>(3)
      {
        {
          "Delete",
          0
        },
        {
          "Close",
          1
        },
        {
          "Accept",
          2
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!ChallengeFriendPanelHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        this.딟 = Object.Instantiate((Object) this.FriendDeletionPanelPrefab) as FriendDeletionConfirmationPanelHandler;
        this.딟.Init(this.딟, this.AvatarIcon.renderer.material, this.땄, this.딟);
        this.딟.GetComponent<MenuOverlayHandler>().Close();
        this.Close();
        break;
      case 1:
        this.딟.GetComponent<MenuOverlayHandler>().Close();
        this.Close();
        break;
      case 2:
        this.딟 = new 딢.딪();
        this.딟.딟(this.GameLimitPrefab, this.VersionCheckerPrefab, new 딢.딪.떕(this.OnGameStartFailed), new 딢.딪.떕(this.OnGameStartSucceeded));
        break;
    }
  }

  private void OnGameStartFailed() => this.딟 = (딢.딪) null;

  private void OnGameStartSucceeded()
  {
    this.딟 = (딢.딪) null;
    딧.땧 LoadingInfo = new 딧.땧(GlobalAppData.딢().Version, 딶.딹.딧);
    LoadingInfo.땄(this.딟);
    LoadingInfo.딟(false);
    GlobalAppData.땽().딧(딢.땹.딢);
    this.딟.DeactivateMenu();
    this.딟.ActivateMenu(true, LoadingInfo, (BaseMenuHandler) this.딟);
    this.딟.GetComponent<MenuOverlayHandler>().Close();
    this.Close();
    딟.딦.딟("Friends_ChallengeSent");
  }

  private void Update()
  {
    if (this.딟 != null && this.딟.딟())
    {
      if (this.딟.땄())
        this.AvatarIcon.renderer.sharedMaterial = this.딟.딧();
      this.딟 = (땓.땶) null;
    }
    if (this.딟 != null && this.딟.땄())
    {
      if (this.딟.딧())
      {
        this.딟 = this.딟.딟;
        this.ProfileName.Text = this.ShortenUserName(this.딟.땄());
        this.ProfileName.UpdateMesh();
        this.딟 = (this.딟.땃() as 땓.땇).딧();
      }
      this.딟 = (땄.땣) null;
    }
    if (this.딟 == null)
      return;
    this.딟.딟();
  }

  private string ShortenUserName(string Name)
  {
    string str = Name;
    if (this.ProfileName.Font.딟(str, true, this.ProfileName.Size).x <= (double) this.MaxNameLength)
      return Name;
    for (Vector2 vector2 = this.ProfileName.Font.딟(str + "...", true, this.ProfileName.Size); vector2.x > (double) this.MaxNameLength; vector2 = this.ProfileName.Font.딟(str + "...", true, this.ProfileName.Size))
      str = str.Substring(0, str.Length - 1);
    return str + "...";
  }

  private void OnDestroy()
  {
    GlobalAppData.땄(this.AvatarIcon);
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    Object.Destroy((Object) this.딟);
  }
}
