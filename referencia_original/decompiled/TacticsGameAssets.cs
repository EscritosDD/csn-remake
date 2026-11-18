// Decompiled with JetBrains decompiler
// Type: TacticsGameAssets
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

public class TacticsGameAssets : ScriptableObject
{
  public GameObject MovementHighlightModel;
  public GameObject EnemyHighlightModel;
  public GameObject ReturnFireHighlightModel;
  public GameObject FirePossibleHighlightModelHigh;
  public GameObject FirePossibleHighlightModelMedium;
  public GameObject FirePossibleHighlightModelLow;
  public GameObject CanAttackAfterMoveModel;
  public UnitOrientationHandler UnitOrientationWidget;
  public Transform HealHighlightModel;
  public Transform PlacementHighlightModel;
  public GameObject SpawnHighlightModel;
  public Transform MovementModelStart;
  public Transform MovementModelStraight;
  public Transform MovementModelTurn;
  public Transform MovementModelTurn2;
  public Transform MovementModelEnd;
  public MoveCostBubble MovementCostBubbleUI;
  public GameObject UnitEmoteBubbleUI;
  public LocalisationEntry ControlPointGameModeText;
  public LocalisationEntry ControlPointGameModeSubText;
  public AutoPositionText HealingText;
  public AutoPositionText HealingTextAlt;
  public AutoPositionText DamageText;
  public AutoPositionText DamageTextAlt;
  public AutoPositionText CritDamageText;
  public AutoPositionText CritDamageTextAlt;
  public AutoPositionText PoisonDamageText;
  public AutoPositionText BeeDamageText;
  public AutoPositionText FireDamageText;
  public AutoPositionText RecoverText;
  public Transform UnitCollisionPrefab;
  public TacticsAPDisplayInfo APDisplayInfo;
  public TacticsTargetDisplayInfo TargetDisplayInfo;
  public TacticsTargetDisplayInfo TwoStageTargetDisplayInfo;
  public TacticsFriendlyDisplayInfo FriendlyDisplayInfo;
  public Transform AIVisBlockedHighlightModel;
  public Transform AIVisCurrentlyVisibleHighlightModel;
  public Transform AIVisNeverVisibleHighlightModel;
  public Transform AIVisRecentlyVisibleHighlightModel;
  public Transform UnitShadow;
  public Transform DefuseEffectPrefab;
  public float DefuseEffectDuration;
  public Transform RepairEffectPrefab;
  public float RepairEffectDuration;
  public Transform ContinousEffectPoison;
  public Transform ContinousEffectDisabled;
  public Transform ContinousEffectGhost;
  public Transform ContinousEffectStunned;
  public Transform ContinousEffectBacklash;
  public Transform ContinousEffectBees;
  public Transform ContinousEffectFire;
  public Transform ContinuousEffectHeadshot;
  public Transform DetectionAuraEffect;
  public float DetectionAuraDuration;
  public Transform DetectionAuraUnitEffect;
  public float DetectionAuraUnitEffectDuration;
  public Transform BacklashAuraEffect;
  public float BacklashAuraDuration;
  public Transform BacklashAuraUnitEffect;
  public float BacklashAuraUnitDuration;
  public Transform HealingAuraEffect;
  public float HealingAuraDuration;
  public Transform TeleportEffect;
  public float TeleportEffectDuration;
  public Transform ReverseTeleportEffect;
  public float ReverseTeleportEffectDuration;
  public Transform HeadshotTriggerEffect;
  public float HeadshotTriggerDuration;
  public Shader CharShader;
  public Shader CharHiddenShader;
  public Shader CharTransparentShader;
  public Shader WeaponShader;
  public Shader WeaponHiddenShader;
  public Shader WeaponTransparentShader;
  public Material VertexColourAlphaBlend;
  public Material VertexColourAlphaBlendDrawOnTop;
  public Material ControlPointBaseMaterial;
  public GameObject TutorialArrowPrefab;
  public GameObject TutorialArrowGreen;
  public GameObject TutorialArrowOrange;
  public GameObject TutorialArrowRed;
  public GameObject CoverHighlightLow;
  public GameObject CoverHighlightMedium;
  public GameObject CoverHighlightHigh;
  public SendingTurnOverlayHandler SendingTurnOverlayPrefab;
  public FakeLoadingScreen FakeLoadingScreen;
  public AIThinkingOverlayHandler AIThinkingOverlayPrefab;
  public AbilitySoundShader[] AbilitySoundShaders;
  public MusicShaders MusicShaders;
  public Material HighDamageMaterial;
  public Material MediumDamageMaterial;
  public Material LowDamageMaterial;
  public Color HighDamageColour;
  public Color MediumDamageColour;
  public Color LowDamageColour;
  public float HighDamageThreshold;
  public float MediumDamageThreshold;
  public float LowDamageThreshold;
  public float GhostVisFrac = 0.7f;
  public Color Blue = new Color(0.2196078f, 0.4941176f, 0.7882353f);
  public Color DarkBlue = new Color(0.2196078f, 0.4941176f, 0.7882353f);
  public Color Red = new Color(0.7882353f, 0.3254902f, 0.2196078f);
  public Color DarkRed = new Color(0.7882353f, 0.3254902f, 0.2196078f);
  public Color Grey = new Color(0.4980392f, 0.4980392f, 0.4980392f);
  public Color ControlPointDefault = new Color(1f, 1f, 1f);
  public Color ControlPointDefaultAlt = new Color(1f, 1f, 1f);
  public Color APBarColor;
  public Color HealthBarGreen;
  public Color HealthBarOrange;
  public Color HealthBarRed;
  public Color HealthBarYellow;
  public Material FacebookMaterial;
  public Material UnknownOpponentAvatarMaterial;
  public Material UnknownOpponentAvatarClippedMaterial;
  public LocalisationEntry RateAppTitle;
  public LocalisationEntry RateAppContent;

  public void 딟([In] 딶.딡 obj0)
  {
  }
}
