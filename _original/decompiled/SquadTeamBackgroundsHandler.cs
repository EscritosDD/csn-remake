// Decompiled with JetBrains decompiler
// Type: SquadTeamBackgroundsHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;
using 딧;

public class SquadTeamBackgroundsHandler : MonoBehaviour
{
  private 딼 딟 = new 딼();
  public GameObject LeftTeamMainBackground;
  public GameObject RightTeamMainBackground;
  public GameObject LeftTeamHeaderBackground;
  public GameObject RightTeamHeaderBackground;

  public void InitailiseBackgroundColours(
    Color Team1Colour,
    Color Team2Colour,
    bool ShowOppositionBackground)
  {
    if (Object.op_Inequality((Object) this.LeftTeamMainBackground, (Object) null))
    {
      this.딟.딟(this.LeftTeamMainBackground, Team1Colour);
      this.LeftTeamMainBackground.SetActive(true);
    }
    if (Object.op_Inequality((Object) this.LeftTeamHeaderBackground, (Object) null))
    {
      this.딟.딟(this.LeftTeamHeaderBackground, Team1Colour);
      this.LeftTeamHeaderBackground.SetActive(true);
    }
    if (Object.op_Inequality((Object) this.RightTeamMainBackground, (Object) null))
    {
      this.딟.딟(this.RightTeamMainBackground, Team2Colour);
      this.RightTeamMainBackground.SetActive(ShowOppositionBackground);
    }
    if (!Object.op_Inequality((Object) this.RightTeamHeaderBackground, (Object) null))
      return;
    this.딟.딟(this.RightTeamHeaderBackground, Team2Colour);
    this.RightTeamHeaderBackground.SetActive(ShowOppositionBackground);
  }

  private void OnDestroy() => this.딟.딟();
}
