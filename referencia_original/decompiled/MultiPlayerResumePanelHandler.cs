// Decompiled with JetBrains decompiler
// Type: MultiPlayerResumePanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("Gui3D/Panels/MultiPlayer Resume")]
public class MultiPlayerResumePanelHandler : MonoBehaviour
{
  private 땄.땣 딟;
  private float 딟 = 0.42f;
  private 땓.땶 딟;
  public GuiButton3D OkButton;
  public GameStatusBoxHandler GameStatusHandler;
  public CoinPotBoxHandler CoinPotHandler;
  public GameObject OtherPlayerAvatar;
  public UnitIconBank Units;
  public MenuAnimatorHandler MenuAnim;
  public GuiText3D NameText;
  public GuiText3D LevelNameText;

  public void Start()
  {
  }

  public void Init(딶.땖 GameState, Transform StartPoint, Transform EndPoint)
  {
    this.MenuAnim = ((Component) this).GetComponent<MenuAnimatorHandler>();
    this.MenuAnim.StartPoint = StartPoint;
    this.MenuAnim.EndPoint = EndPoint;
    this.OkButton.set_CustomPressFunc("OnContinueGame");
    this.OkButton.set_CustomPressValue((object) GameState);
    int TeamIndex;
    switch (GameState.떓())
    {
      case 딶.딹.딧:
        TeamIndex = GameState.땂();
        int index = (TeamIndex + 1) % 2;
        string str = GameState.딟.땄[index];
        this.딟 = GlobalAppData.떏().땄(str, false);
        break;
      default:
        TeamIndex = 0;
        this.딟 = (땓.땶) new 땓.떅(GameState.땠().AIAvatarId);
        break;
    }
    if (GameState.떓() == 딶.딹.딧)
    {
      this.GameStatusHandler.InitailiseGameStatusBox(GameState, 0, 1, GameState.딦());
      this.Units.Init(GameState, TeamIndex, GameState.딦());
    }
    else
    {
      this.GameStatusHandler.InitailiseGameStatusBox(GameState, 0, 1);
      this.Units.Init(GameState, TeamIndex);
    }
    if (Object.op_Inequality((Object) this.CoinPotHandler, (Object) null))
    {
      if (GameState.떓() == 딶.딹.땄)
      {
        ((Component) this.CoinPotHandler).gameObject.SetActive(false);
      }
      else
      {
        ((Component) this.CoinPotHandler).gameObject.SetActive(true);
        this.CoinPotHandler.InitailiseCoinValueData(GameState);
      }
    }
    this.LevelNameText.LocText = GlobalAppData.땼().딷(GameState.딟.땄);
    this.LevelNameText.UpdateMesh();
  }

  private void Update()
  {
    if (this.딟 != null && this.딟.딟())
    {
      if (this.딟.땄())
        this.OtherPlayerAvatar.renderer.sharedMaterial = this.딟.딧();
      this.딟 = (땓.땶) null;
    }
    if (this.딟 == null || !this.딟.땄())
      return;
    if (this.딟.딧())
    {
      this.NameText.Text = this.ShortenUserName(this.딟.딟.땄());
      this.NameText.UpdateMesh();
      this.딟 = (this.딟.딟.땃() as 땓.땇).딧();
    }
    this.딟 = (땄.땣) null;
  }

  private string ShortenUserName(string Name)
  {
    string str = Name;
    if (this.NameText.Font.딟(str, true, this.NameText.Size).x <= (double) this.딟)
      return Name;
    for (Vector2 vector2 = this.NameText.Font.딟(str + "...", true, this.NameText.Size); vector2.x > (double) this.딟; vector2 = this.NameText.Font.딟(str + "...", true, this.NameText.Size))
      str = str.Substring(0, str.Length - 1);
    return str + "...";
  }
}
