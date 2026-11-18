// Decompiled with JetBrains decompiler
// Type: FrontendHub
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class FrontendHub : MonoBehaviour
{
  public static FrontendHub 딟;
  public MainScreenHandler MainScreen;
  public StoreScreenHandler StoreScreen;
  public LoginAttemptHandler_Base LoginHandler;
  public MoneyDisplayHandler MoneyDisplay;
  public BarracksScreenHandler BarracksScreen;
  public MultiPlayerScreen1Handler MultiPlayerScreen;
  public SquadPointSelectionScreenHandler SquadPointSelectionScreen;
  public MapSelectionScreenHandler MapSelectionScreen;
  public PassAndPlayScreen1Handler PassAndPlayScreen;
  public FakeLoadingScreen LoadingScreen;
  public ErrorMessagehandler ErrorMessage;
  public ChallengeFriendScreenHandler ChallengeFriendScreen;
  public CommanderAbilitySelectionScreenHandler CommanderAbilityScreen;
  public SplashScreenHandler SplashScreen;
  public AccountInticementScreenHandler AccountInticementScreen;
  public RegistrationScreenHandler RegistrationScreen;
  public FreeCharacterSelectionScreenHandler FreeCharacterScreen;
  public AuthScreenHandler AuthScreen;
  public SquadSelectionScreenHandlerNew SquadSelectionScreen;
  public CreditsHandler CreditsScreen;
  public PlayerProfilePanelHandler ProfileScreen;
  public ChallengeLocationSelectionScreenHandler ChallengeLocationSelectionScreen;
  public ChallengePackSelectionScreenHandler ChallengePackSelectionScreen;
  public ChallengeMissionMapScreenHandler ChallengeMissionMapScreen;
  public LootRewardScreenHandler LootRewardScreen;

  private void OnEnable() => FrontendHub.딟 = this;

  private void OnDestroy() => FrontendHub.딟 = (FrontendHub) null;
}
