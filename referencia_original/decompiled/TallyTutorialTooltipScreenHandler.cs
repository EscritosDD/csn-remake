// Decompiled with JetBrains decompiler
// Type: TallyTutorialTooltipScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using 딶;

public class TallyTutorialTooltipScreenHandler : TallyBaseScreenHandler
{
  private Vector3 딟;
  public GameObject MainOverlay;

  public void ActivateTutorialTooltipScreen(땖 State, Vector3 ScreenPos)
  {
    this.딟 = ScreenPos;
    this.ActivateTallyScreen(State);
  }

  public override void PositionScreenCameraView() => ((Component) this).transform.position = new Vector3((float) this.딟.x, (float) (this.딟.y + 0.5), (float) this.딟.z);

  private void Update()
  {
    if (!base.딟)
      return;
    this.UpdateTallyScreenDisplayTimer();
  }

  public override void OpenNextTallyScreen()
  {
    GlobalAppData.딟.딟(GlobalAppState.땊.딧);
    this.ExitToFrontEnd();
    this.DeactivateTallyScreen();
  }

  private void OnButtonPressed(string Command)
  {
    if (!base.딟)
      return;
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (TallyTutorialTooltipScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      TallyTutorialTooltipScreenHandler.딟 = new Dictionary<string, int>(2)
      {
        {
          "Continue",
          0
        },
        {
          "Skip",
          1
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!TallyTutorialTooltipScreenHandler.딟.TryGetValue(key, out num))
      return;
    if (num != 0)
    {
      if (num == 1)
        ;
    }
    else
      this.OpenNextTallyScreen();
  }
}
