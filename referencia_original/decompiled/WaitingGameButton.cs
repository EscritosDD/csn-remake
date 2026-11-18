// Decompiled with JetBrains decompiler
// Type: WaitingGameButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("Gui3D/Controls/Active Game Button")]
public class WaitingGameButton : MonoBehaviour
{
  public GuiText3D NameText;
  public 딶.땖 GameState;
  private 땄.땣 딟;
  public GameProgressDisplay BlueTeamProgress;
  public GameProgressDisplay RedTeamProgress;
  public LocalisationEntry WaitingForOpponent;

  public void Init(딶.땖 GameState, bool IsActive)
  {
    this.GameState = GameState;
    int TeamIndex1 = GameState.땂();
    int TeamIndex2 = TeamIndex1 ^ 1;
    this.BlueTeamProgress.Init(GameState, TeamIndex1, false);
    this.RedTeamProgress.Init(GameState, TeamIndex2, true);
    if (GameState.떓() == 딶.딹.딧)
    {
      string str = GameState.딟.땄[TeamIndex2];
      this.딟 = GlobalAppData.떏().땄(str, false);
    }
    else
      this.UpdatePlayerName(GameState.딟.딟[TeamIndex1]);
  }

  private void UpdatePlayerName(string OtherPlayerName)
  {
    if (string.IsNullOrEmpty(OtherPlayerName))
    {
      this.NameText.LocText = this.WaitingForOpponent;
      this.NameText.Size = 0.055f;
    }
    else
      this.NameText.Text = OtherPlayerName;
    this.NameText.UpdateMesh();
  }

  public void Update()
  {
    if (this.딟 == null || !this.딟.땄())
      return;
    if (this.딟.딧())
      this.UpdatePlayerName(this.딟.딟.땄());
    this.딟 = (땄.땣) null;
  }
}
