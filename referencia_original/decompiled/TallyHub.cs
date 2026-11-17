// Decompiled with JetBrains decompiler
// Type: TallyHub
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class TallyHub : MonoBehaviour
{
  public static TallyHub 딟;
  public TallyNewAbilityScreenHandler AbilityAwardScreen;
  public TallyNewCoinAwardScreenHandler CoinsAwardScreen;
  public TallyCoinsScreenHandler CoinsScreen;
  public TallyGameOverviewScreenHandler GameOverviewScreen;
  public TallyLevelUpScreenHandler LevelUpScreen;
  public TallyLoadingScreenHandler LoadingScreen;
  public TallyRematchScreenHandler RematchScreen;
  public TallySinglePlayerXPScreenHandler SinglePlayerXPScreen;
  public TallyNewStoreItemHandler StoreItemAwardScreen;
  public TallyTutorialTooltipScreenHandler TutorialToolTipScreen;
  public TallyTutorialScreenHandler TutorialScreen;
  public TallyXPScreenHandler XPScreen;

  private void OnEnable() => TallyHub.딟 = this;
}
