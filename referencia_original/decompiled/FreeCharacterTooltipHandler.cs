// Decompiled with JetBrains decompiler
// Type: FreeCharacterTooltipHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

public class FreeCharacterTooltipHandler : ToolTipHandler
{
  protected override void Initialize() => base.Initialize();

  protected override void OnButtonPressed(string command)
  {
    if (command == "Accept")
    {
      FrontendHub.딟.ChallengeLocationSelectionScreen.DeactivateMenu();
      FrontendHub.딟.FreeCharacterScreen.ActivateMenu();
      this.OnClose();
    }
    else
      base.OnButtonPressed(command);
  }
}
