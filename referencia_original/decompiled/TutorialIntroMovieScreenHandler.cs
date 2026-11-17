// Decompiled with JetBrains decompiler
// Type: TutorialIntroMovieScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using UnityEngine;
using 땓;

public class TutorialIntroMovieScreenHandler : BaseMenuHandler
{
  public TutorialCommanderSelectionScreenHandler nextScreen;
  public float startDelayTime = 0.5f;
  public string videoPath;
  private 떍 딟;

  private void Start()
  {
    base.딟 = ((Component) this).transform.position;
    this.ActivateMenu();
  }

  public override void DeactivateMenu() => base.DeactivateMenu();

  public override void ActivateMenu()
  {
    base.ActivateMenu();
    this.딟 = new 떍(this.videoPath, this.startDelayTime);
    this.딟.딟 = new Action(this.ContinueToNextScreen);
    this.딟.땄();
  }

  private void Update() => this.딟.딟();

  private void ContinueToNextScreen()
  {
    this.DeactivateMenu();
    this.nextScreen.ActivateMenu();
  }
}
