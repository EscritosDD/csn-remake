// Decompiled with JetBrains decompiler
// Type: SPActiveGameButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;
using 딶;

[AddComponentMenu("Gui3D/Controls/Active Game Button")]
public class SPActiveGameButton : MonoBehaviour
{
  public GuiButton3D SelectionButton;
  public GuiText3D NameText;
  public GuiText3D DetailText;
  public 땖 GameState;
  public GameObject[] SinglePlayerTicks = new GameObject[3];
  public Material[] SinglePlayerTickMaterials = new Material[3];

  public string GetTeamName(땖 GameState, int TeamIndex) => GameState.딟.딟[TeamIndex];

  public void Init(땖 GameState, SinglePlayerMissionAsset Mission, bool IsActive)
  {
    this.GameState = GameState;
    this.NameText.LocText = Mission.Title;
    this.NameText.UpdateMesh();
    this.DetailText.LocText = GlobalAppData.땼().딷(GameState.딟.땄);
    this.DetailText.UpdateMesh();
    switch (GlobalAppData.땽().떎(Mission.Id))
    {
      case 1:
        this.SinglePlayerTicks[0].renderer.material = this.SinglePlayerTickMaterials[0];
        break;
      case 2:
        this.SinglePlayerTicks[0].renderer.material = this.SinglePlayerTickMaterials[0];
        this.SinglePlayerTicks[1].renderer.material = this.SinglePlayerTickMaterials[1];
        break;
      case 3:
        this.SinglePlayerTicks[0].renderer.material = this.SinglePlayerTickMaterials[0];
        this.SinglePlayerTicks[1].renderer.material = this.SinglePlayerTickMaterials[1];
        this.SinglePlayerTicks[2].renderer.material = this.SinglePlayerTickMaterials[2];
        break;
    }
    if (!Object.op_Inequality((Object) this.SelectionButton, (Object) null))
      return;
    this.SelectionButton.set_CustomPressFunc("OnGameSelected");
    this.SelectionButton.set_CustomPressValue((object) GameState);
  }

  private void OnDestroy()
  {
    for (int index = 0; index < 3; ++index)
    {
      if (Object.op_Inequality((Object) this.SinglePlayerTicks[index], (Object) null))
        GlobalAppData.땄(this.SinglePlayerTicks[index]);
    }
  }
}
