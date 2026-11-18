// Decompiled with JetBrains decompiler
// Type: InstantActionInfoBarHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class InstantActionInfoBarHandler : MonoBehaviour
{
  private 땄.땣 딟;
  public GuiText3D HeaderText;
  public GuiText3D HeaderTextDropShadow;
  public GuiText3D SubText;
  public LocalisationEntry ChallengeText;
  public LocalisationEntry MultiplayerText;
  public LocalisationEntry RandomOpponentText;

  public void Init(딧.땧 LoadingInfo)
  {
    if (LoadingInfo.땺() == 딶.딹.딧)
    {
      this.HeaderText.LocText = this.MultiplayerText;
      this.HeaderTextDropShadow.LocText = this.MultiplayerText;
      if (LoadingInfo.땥() != null)
        this.딟 = GlobalAppData.떏().땄(LoadingInfo.땥(), false);
      else
        this.SubText.LocText = this.RandomOpponentText;
    }
    else if (LoadingInfo.땺() == 딶.딹.땄)
    {
      this.HeaderText.LocText = this.ChallengeText;
      this.HeaderTextDropShadow.LocText = this.ChallengeText;
      this.SubText.Text = "\"" + 딧.딪.딟(GlobalAppData.땃(LoadingInfo.딧()).Title) + "\"";
    }
    this.HeaderText.UpdateMesh();
    this.HeaderTextDropShadow.UpdateMesh();
    this.SubText.UpdateMesh();
  }

  private void Update()
  {
    if (this.딟 == null || !this.딟.땄())
      return;
    if (this.딟.딧())
      this.SubText.Text = this.딟.딟.땄();
    else
      this.SubText.LocText = this.RandomOpponentText;
    this.SubText.UpdateMesh();
    this.딟 = (땄.땣) null;
  }
}
