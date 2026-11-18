// Decompiled with JetBrains decompiler
// Type: PassAndPlayActiveGameHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;
using 딶;

[AddComponentMenu("Gui3D/Controls/Pass and Play Active Game")]
public class PassAndPlayActiveGameHandler : MonoBehaviour
{
  public UnitIconBank Team0Units;
  public GameProgressDisplay Team0Progress;
  public UnitIconBank Team1Units;
  public GameProgressDisplay Team1Progress;
  public GuiButton3D OkButton;
  public GuiText3D NextPlayerText;
  public bool LoadingComplete;
  public LocalisationEntry PlayerOneText;
  public LocalisationEntry PlayerTwoText;

  public void Init(땖 GameState)
  {
    this.Team0Units.Init(GameState, 0);
    this.Team0Progress.Init(GameState, 0, false);
    this.Team1Units.Init(GameState, 1);
    this.Team1Progress.Init(GameState, 1, true);
    if (GameState.떂().땃() == 0)
    {
      this.NextPlayerText.LocText = this.PlayerOneText;
      this.NextPlayerText.TextColor = GlobalAppData.딟.GameAssets.Blue;
    }
    else
    {
      this.NextPlayerText.LocText = this.PlayerTwoText;
      this.NextPlayerText.TextColor = GlobalAppData.딟.GameAssets.Red;
    }
    this.NextPlayerText.UpdateMesh();
  }

  public void Update()
  {
    if (!this.Team0Units.CharactersLoaded || !this.Team1Units.CharactersLoaded)
      return;
    this.LoadingComplete = true;
  }
}
