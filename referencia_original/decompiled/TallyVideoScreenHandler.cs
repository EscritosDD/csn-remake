// Decompiled with JetBrains decompiler
// Type: TallyVideoScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using 땓;

public class TallyVideoScreenHandler : TallyBaseScreenHandler
{
  public TallyGameOverviewScreenHandler nextScreen;
  public float startDelayTime = 0.5f;
  public string rioCompletedVideoPath;
  public string londonCompletedVideoPath;
  private string 딟;
  private 떍 딟;

  public override void InitailiseScreenData()
  {
    this.딟 = new 떍(this.딟, this.startDelayTime);
    this.딟.딟 = new Action(this.ContinueToNextScreen);
    this.딟.땄();
  }

  public void SetActiveVideoPath(bool isLondon)
  {
    if (isLondon)
      this.딟 = this.londonCompletedVideoPath;
    else
      this.딟 = this.rioCompletedVideoPath;
  }

  private void Update()
  {
    if (this.딟 == null)
      return;
    this.딟.딟();
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (TallyVideoScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      TallyVideoScreenHandler.딟 = new Dictionary<string, int>(1)
      {
        {
          "Continue",
          0
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!TallyVideoScreenHandler.딟.TryGetValue(key, out num) || num != 0)
      return;
    this.ContinueToNextScreen();
  }

  private void ContinueToNextScreen() => this.nextScreen.ActivateTallyScreen(base.딟);
}
