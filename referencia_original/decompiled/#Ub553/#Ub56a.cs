// Decompiled with JetBrains decompiler
// Type: 땓.땪
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Analytics;
using SplashDamage.Mobile.Build;
using SplashDamage.Mobile.Fireteam;
using SplashDamage.Mobile.HTTP;
using SplashDamage.Mobile.JavaScript;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace 땓
{
  public class 땪 : 딧.딾
  {
    private Action<StringBuilder, MixPanelEventData> 딟;
    private Action<StringBuilder, Dictionary<string, string>> 딟;
    private Action<StringBuilder, GAEventParam> 딟;
    private Action<StringBuilder, GAEvent> 딟;
    private Action<StringBuilder, double> 딟;
    private Action<StringBuilder, BuildManifestDataWrapper> 딟;
    private Action<StringBuilder, BuildManifestDataJson> 딟;
    private Action<StringBuilder, Dictionary<string, object>> 딟;
    private Action<StringBuilder, BuildManifestBundleData[]> 딟;
    private Action<StringBuilder, int> 딟;
    private Action<StringBuilder, BuildManifestBundleData> 딟;
    private Action<StringBuilder, string[]> 딟;
    private Action<StringBuilder, UserData> 딟;
    private Action<StringBuilder, FacebookFriendData> 딟;
    private Action<StringBuilder, ErrorData> 딟;
    private Action<StringBuilder, 딟.땑> 딟;
    private Action<StringBuilder, AccessTokenData> 딟;
    private Action<StringBuilder, XboxAuthToken> 딟;
    private Action<StringBuilder, XboxXuidLink> 딟;
    private Action<StringBuilder, long> 딟;
    private Action<StringBuilder, InventoryData> 딟;
    private Action<StringBuilder, Dictionary<string, int>> 딟;
    private Action<StringBuilder, OfferRealPriceData> 딟;
    private Action<StringBuilder, OfferData> 딟;
    private Action<StringBuilder, 딟.딘> 딟;
    private Action<StringBuilder, TurnOp_AddToInventory> 딟;
    private Action<StringBuilder, TurnOp_Consume> 딟;
    private Action<StringBuilder, TurnBasedSessionTurnData> 딟;
    private Action<StringBuilder, DateTime> 딟;
    private Action<StringBuilder, object[][]> 딟;
    private Action<StringBuilder, TurnBasedSessionData> 딟;
    private Action<StringBuilder, Dictionary<string, 딟.땾>> 딟;
    private Action<StringBuilder, 딟.딺> 딟;
    private Action<StringBuilder, SessionUserData[]> 딟;
    private Action<StringBuilder, SessionUserData> 딟;
    private Action<StringBuilder, 딟.떑> 딟;
    private Action<StringBuilder, SessionListData> 딟;
    private Action<StringBuilder, TurnBasedSessionData[]> 딟;
    private Action<StringBuilder, SessionTurnsListData> 딟;
    private Action<StringBuilder, TurnBasedSessionTurnData[]> 딟;
    private Action<StringBuilder, SessionJoinData> 딟;
    private Action<StringBuilder, 딟.땎> 딟;
    private Action<StringBuilder, WriteSessionTurnData> 딟;
    private Action<StringBuilder, TransactionData> 딟;
    private Action<StringBuilder, PurchaseResult> 딟;
    private Action<StringBuilder, BlindBoxTestResult> 딟;
    private Action<StringBuilder, Dictionary<string, int>[]> 딟;
    private Action<StringBuilder, NotificationData> 딟;
    private Action<StringBuilder, 딟.땅> 딟;
    private Action<StringBuilder, object[]> 딟;
    private Action<StringBuilder, NotificationsData> 딟;
    private Action<StringBuilder, NotificationData[]> 딟;
    private Action<StringBuilder, SessionEventNotificationParams> 딟;
    private Action<StringBuilder, SessionInviteNotificationParams> 딟;
    private Action<StringBuilder, SessionUserEventNotificationParams> 딟;
    private Action<StringBuilder, RelationFriendNotificationParams> 딟;
    private Action<StringBuilder, SessionActionSubmitTurnNotificationParams> 딟;
    private Action<StringBuilder, FileStoreData> 딟;
    private Action<StringBuilder, CatalogEntry> 딟;
    private Action<StringBuilder, 딟.딪> 딟;
    private Action<StringBuilder, 딟.떕> 딟;
    private Action<StringBuilder, OfferData[]> 딟;
    private Action<StringBuilder, CatalogPagination> 딟;
    private Action<StringBuilder, CatalogEntry[]> 딟;
    private Action<StringBuilder, MarkNotificationReadUpdateData> 딟;
    private Action<StringBuilder, MarkNotificationReadData> 딟;
    private Action<StringBuilder, MinimalFacebookInfo> 딟;
    private Action<StringBuilder, FacebookFriendsData> 딟;
    private Action<StringBuilder, FacebookFriendData[]> 딟;
    private Action<StringBuilder, FriendsData> 딟;
    private Action<StringBuilder, UserData[]> 딟;
    private Action<StringBuilder, OffersData> 딟;
    private Action<StringBuilder, ApplicationStatus> 딟;
    private Action<StringBuilder, FileInfo> 딟;
    private Action<StringBuilder, FileList> 딟;
    private Action<StringBuilder, FileInfo[]> 딟;
    private Action<StringBuilder, SessionCreationWriteData> 딟;
    private Action<StringBuilder, PublicProfileWriteData> 딟;
    private Action<StringBuilder, SplashDamage.Mobile.Fireteam.NaClPushChannelData> 딟;
    private Action<StringBuilder, EchoSessionJson> 딟;
    private Action<StringBuilder, EchoSessionListJson> 딟;
    private Action<StringBuilder, EchoSessionJson[]> 딟;
    private Action<StringBuilder, EchoEventListJson> 딟;
    private Action<StringBuilder, EchoEventJson[]> 딟;
    private Action<StringBuilder, EchoEventJson> 딟;
    private Action<StringBuilder, ScoreTableEntryData> 딟;
    private Action<StringBuilder, ScoreTableData> 딟;
    private Action<StringBuilder, Dictionary<string, Dictionary<string, ScoreTableEntryData>>> 딟;
    private Action<StringBuilder, ScoreBoardOps> 딟;
    private Action<StringBuilder, Dictionary<string, List<object>>> 딟;
    private Action<StringBuilder, JWTData> 딟;
    private Action<StringBuilder, ExternalCallResponse> 딟;
    private Action<StringBuilder, JavaScriptCallPayload> 딟;
    private Action<StringBuilder, JSResponse> 딟;
    private Action<StringBuilder, JSRequest> 딟;
    private Action<StringBuilder, List<JSRequestHeader>> 딟;
    private Action<StringBuilder, JSRequestHeader> 딟;
    private Action<StringBuilder, SplashDamage.Mobile.Notifications.NaClPushChannelData> 딟;
    private Action<StringBuilder, BuildManifestPrefabData> 딟;
    private Action<StringBuilder, BuildManifestAvatarData> 딟;
    private Action<StringBuilder, BuildManifestCharacterData> 딟;
    private Action<StringBuilder, BuildManifestGameDataData> 딟;
    private Action<StringBuilder, BuildManifestWeaponData> 딟;
    private Action<StringBuilder, BuildManifestVoicePackData> 딟;
    private Action<StringBuilder, BuildManifestOutfitData> 딟;
    private Action<StringBuilder, BuildManifestLevelData> 딟;
    private Action<StringBuilder, BuildManifestChallengePackRequiredLevel> 딟;
    private Action<StringBuilder, BuildManifestChallengePackChallenge> 딟;
    private Action<StringBuilder, BuildManifestChallengePackData> 딟;
    private Action<StringBuilder, BuildManifestChallengePackChallenge[]> 딟;
    private Action<StringBuilder, BuildManifestChallengeData> 딟;
    private Action<StringBuilder, BuildManifestMapPackData> 딟;
    private Action<StringBuilder, BuildManifestMissionRewardEntry> 딟;
    private Action<StringBuilder, BuildManifestMissionRewardsData> 딟;
    private Action<StringBuilder, BuildManifestMissionRewardEntry[]> 딟;
    private Action<StringBuilder, BuildManifestAtlasPackData> 딟;
    private Action<StringBuilder, TacticsBuildManifestDataJson> 딟;
    private Action<StringBuilder, BuildManifestLevelData[]> 딟;
    private Action<StringBuilder, BuildManifestOutfitData[]> 딟;
    private Action<StringBuilder, BuildManifestVoicePackData[]> 딟;
    private Action<StringBuilder, BuildManifestWeaponData[]> 딟;
    private Action<StringBuilder, BuildManifestGameDataData[]> 딟;
    private Action<StringBuilder, BuildManifestCharacterData[]> 딟;
    private Action<StringBuilder, BuildManifestAvatarData[]> 딟;
    private Action<StringBuilder, BuildManifestPrefabData[]> 딟;
    private Action<StringBuilder, BuildManifestChallengeData[]> 딟;
    private Action<StringBuilder, BuildManifestMapPackData[]> 딟;
    private Action<StringBuilder, BuildManifestMissionRewardsData[]> 딟;
    private Action<StringBuilder, BuildManifestChallengePackData[]> 딟;
    private Action<StringBuilder, BuildManifestAtlasPackData[]> 딟;
    private Action<StringBuilder, BuildTimestampData> 딟;
    private Action<StringBuilder, SinglePlayerMissionScore> 딟;
    private Action<StringBuilder, ClientProfileData> 딟;
    private Action<StringBuilder, UnitCharacterData[]> 딟;
    private Action<StringBuilder, 딢.딮[]> 딟;
    private Action<StringBuilder, int[]> 딟;
    private Action<StringBuilder, SinglePlayerMissionScore[]> 딟;
    private Action<StringBuilder, NewsDataText> 딟;
    private Action<StringBuilder, NewsDataEntry> 딟;
    private Action<StringBuilder, NewsDataJson> 딟;
    private Action<StringBuilder, NewsDataEntry[]> 딟;
    private Action<StringBuilder, SceneDataJson> 딟;
    private Action<StringBuilder, CloudProfileJsonData> 딟;
    private Action<StringBuilder, FeaturedItemsDataJson> 딟;
    private Action<StringBuilder, EngineVersionData> 딟;
    private Action<StringBuilder, FacebookLoginInfo> 딟;
    private Action<StringBuilder, FireTeamCatalogEntryData> 딟;
    private Action<StringBuilder, FireTeamCatalogEntryURL> 딟;
    private Action<StringBuilder, FireTeamCatalogEntryDescriptionAbilityData> 딟;
    private Action<StringBuilder, FireTeamCatalogEntryAdvertData> 딟;
    private Action<StringBuilder, FireTeamCatalogEntryDescriptionData> 딟;
    private Action<StringBuilder, FireTeamCatalogEntryDescriptionAbilityData[]> 딟;
    private Action<StringBuilder, FireTeamUserProfileChallengeJsonData> 딟;
    private Action<StringBuilder, FireTeamUserProfileJsonData> 딟;
    private Action<StringBuilder, FireTeamUserProfileChallengeJsonData[]> 딟;
    private Action<StringBuilder, FireTeamTurnBasedSessionAttributes> 딟;
    private Action<StringBuilder, FireTeamStoreImportEntryData> 딟;
    private Action<StringBuilder, FireTeamStoreImportData> 딟;
    private Action<StringBuilder, FireTeamStoreImportEntryData[]> 딟;
    private Action<StringBuilder, UnitBuff> 딟;
    private Action<StringBuilder, 딢.떍> 딟;
    private Action<StringBuilder, UnitTurnDataJson> 딟;
    private Action<StringBuilder, 딢.딯> 딟;
    private Action<StringBuilder, UnitBuff[]> 딟;
    private Action<StringBuilder, TacticsActionData> 딟;
    private Action<StringBuilder, 딢.땀> 딟;
    private Action<StringBuilder, 딢.딴> 딟;
    private Action<StringBuilder, TacticsInitialTurnState> 딟;
    private Action<StringBuilder, TacticsSessionStateData> 딟;
    private Action<StringBuilder, TacticsGameStateTurnData> 딟;
    private Action<StringBuilder, UnitTurnDataJson[]> 딟;
    private Action<StringBuilder, TacticsActionData[]> 딟;
    private Action<StringBuilder, UnitCharacterData> 딟;
    private Action<StringBuilder, 딢.딴[]> 딟;
    private Action<StringBuilder, TacticsGameStateData> 딟;
    private Action<StringBuilder, TacticsTurnStateUnits> 딟;
    private Action<StringBuilder, 딟.땾> 딟;
    private Action<StringBuilder, Dictionary<string, ScoreTableEntryData>> 딟;
    private Action<StringBuilder, List<object>> 딟;
    private Action<StringBuilder, 딢.딮> 딟;

    public 땪()
    {
      this.딟 = (Action<StringBuilder, MixPanelEventData>) ((obj0, obj1) => this.딟<MixPanelEventData>(obj0, obj1, new Action<MixPanelEventData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, Dictionary<string, string>>) ((obj0, obj1) => this.딟<string, string>(obj0, (IDictionary<string, string>) obj1, new Action<StringBuilder, string>(딧.딾.딟)));
      this.딟 = (Action<StringBuilder, GAEventParam>) ((obj0, obj1) => this.딟<GAEventParam>(obj0, obj1, new Action<GAEventParam, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, GAEvent>) ((obj0, obj1) => this.딟<GAEvent>(obj0, obj1, new Action<GAEvent, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, double>) ((obj0, obj1) => obj0.Append(obj1));
      this.딟 = (Action<StringBuilder, BuildManifestDataWrapper>) ((obj0, obj1) => this.딟<BuildManifestDataWrapper>(obj0, obj1, new Action<BuildManifestDataWrapper, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, BuildManifestDataJson>) ((obj0, obj1) => this.딟<BuildManifestDataJson>(obj0, obj1, new Action<BuildManifestDataJson, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, Dictionary<string, object>>) ((obj0, obj1) => this.딟<string, object>(obj0, (IDictionary<string, object>) obj1, new Action<StringBuilder, object>(((딧.딾) this).딢)));
      this.딟 = (Action<StringBuilder, BuildManifestBundleData[]>) ((obj0, obj1) => this.딟<BuildManifestBundleData>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, int>) ((obj0, obj1) => obj0.Append(obj1));
      this.딟 = (Action<StringBuilder, BuildManifestBundleData>) ((obj0, obj1) => this.딟<BuildManifestBundleData>(obj0, obj1, new Action<BuildManifestBundleData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, string[]>) ((obj0, obj1) => this.딟<string>(obj0, obj1, new Action<StringBuilder, string>(딧.딾.딟)));
      this.딟 = (Action<StringBuilder, UserData>) ((obj0, obj1) => this.딟<UserData>(obj0, obj1, new Action<UserData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, FacebookFriendData>) ((obj0, obj1) => this.딟<FacebookFriendData>(obj0, obj1, new Action<FacebookFriendData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, ErrorData>) ((obj0, obj1) => this.딟<ErrorData>(obj0, obj1, new Action<ErrorData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, 딟.땑>) ((obj0, obj1) => obj0.Append((int) obj1));
      this.딟 = (Action<StringBuilder, AccessTokenData>) ((obj0, obj1) => this.딟<AccessTokenData>(obj0, obj1, new Action<AccessTokenData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, XboxAuthToken>) ((obj0, obj1) => this.딟<XboxAuthToken>(obj0, obj1, new Action<XboxAuthToken, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, XboxXuidLink>) ((obj0, obj1) => this.딟<XboxXuidLink>(obj0, obj1, new Action<XboxXuidLink, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, long>) ((obj0, obj1) => obj0.Append(obj1));
      this.딟 = (Action<StringBuilder, InventoryData>) ((obj0, obj1) => this.딟<InventoryData>(obj0, obj1, new Action<InventoryData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, Dictionary<string, int>>) ((obj0, obj1) => this.딟<string, int>(obj0, (IDictionary<string, int>) obj1, this.딟));
      this.딟 = (Action<StringBuilder, OfferRealPriceData>) ((obj0, obj1) => this.딟<OfferRealPriceData>(obj0, obj1, new Action<OfferRealPriceData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, OfferData>) ((obj0, obj1) => this.딟<OfferData>(obj0, obj1, new Action<OfferData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, 딟.딘>) ((obj0, obj1) => obj0.Append((int) obj1));
      this.딟 = (Action<StringBuilder, TurnOp_AddToInventory>) ((obj0, obj1) => this.딟<TurnOp_AddToInventory>(obj0, obj1, new Action<TurnOp_AddToInventory, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, TurnOp_Consume>) ((obj0, obj1) => this.딟<TurnOp_Consume>(obj0, obj1, new Action<TurnOp_Consume, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, TurnBasedSessionTurnData>) ((obj0, obj1) => this.딟<TurnBasedSessionTurnData>(obj0, obj1, new Action<TurnBasedSessionTurnData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, DateTime>) ((obj0, obj1) => 딧.딾.딟(obj0, obj1.ToString()));
      this.딟 = (Action<StringBuilder, object[][]>) ((obj0, obj1) => this.딟<object[]>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, TurnBasedSessionData>) ((obj0, obj1) => this.딟<TurnBasedSessionData>(obj0, obj1, new Action<TurnBasedSessionData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, Dictionary<string, 딟.땾>>) ((obj0, obj1) => this.딟<string, 딟.땾>(obj0, (IDictionary<string, 딟.땾>) obj1, this.딟));
      this.딟 = (Action<StringBuilder, 딟.딺>) ((obj0, obj1) => obj0.Append((int) obj1));
      this.딟 = (Action<StringBuilder, SessionUserData[]>) ((obj0, obj1) => this.딟<SessionUserData>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, SessionUserData>) ((obj0, obj1) => this.딟<SessionUserData>(obj0, obj1, new Action<SessionUserData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, 딟.떑>) ((obj0, obj1) => obj0.Append((int) obj1));
      this.딟 = (Action<StringBuilder, SessionListData>) ((obj0, obj1) => this.딟<SessionListData>(obj0, obj1, new Action<SessionListData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, TurnBasedSessionData[]>) ((obj0, obj1) => this.딟<TurnBasedSessionData>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, SessionTurnsListData>) ((obj0, obj1) => this.딟<SessionTurnsListData>(obj0, obj1, new Action<SessionTurnsListData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, TurnBasedSessionTurnData[]>) ((obj0, obj1) => this.딟<TurnBasedSessionTurnData>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, SessionJoinData>) ((obj0, obj1) => this.딟<SessionJoinData>(obj0, obj1, new Action<SessionJoinData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, 딟.땎>) ((obj0, obj1) => obj0.Append((int) obj1));
      this.딟 = (Action<StringBuilder, WriteSessionTurnData>) ((obj0, obj1) => this.딟<WriteSessionTurnData>(obj0, obj1, new Action<WriteSessionTurnData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, TransactionData>) ((obj0, obj1) => this.딟<TransactionData>(obj0, obj1, new Action<TransactionData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, PurchaseResult>) ((obj0, obj1) => this.딟<PurchaseResult>(obj0, obj1, new Action<PurchaseResult, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, BlindBoxTestResult>) ((obj0, obj1) => this.딟<BlindBoxTestResult>(obj0, obj1, new Action<BlindBoxTestResult, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, Dictionary<string, int>[]>) ((obj0, obj1) => this.딟<Dictionary<string, int>>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, NotificationData>) ((obj0, obj1) => this.딟<NotificationData>(obj0, obj1, new Action<NotificationData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, 딟.땅>) ((obj0, obj1) => obj0.Append((int) obj1));
      this.딟 = (Action<StringBuilder, object[]>) ((obj0, obj1) => this.딟<object>(obj0, obj1, new Action<StringBuilder, object>(((딧.딾) this).딢)));
      this.딟 = (Action<StringBuilder, NotificationsData>) ((obj0, obj1) => this.딟<NotificationsData>(obj0, obj1, new Action<NotificationsData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, NotificationData[]>) ((obj0, obj1) => this.딟<NotificationData>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, SessionEventNotificationParams>) ((obj0, obj1) => this.딟<SessionEventNotificationParams>(obj0, obj1, new Action<SessionEventNotificationParams, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, SessionInviteNotificationParams>) ((obj0, obj1) => this.딟<SessionInviteNotificationParams>(obj0, obj1, new Action<SessionInviteNotificationParams, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, SessionUserEventNotificationParams>) ((obj0, obj1) => this.딟<SessionUserEventNotificationParams>(obj0, obj1, new Action<SessionUserEventNotificationParams, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, RelationFriendNotificationParams>) ((obj0, obj1) => this.딟<RelationFriendNotificationParams>(obj0, obj1, new Action<RelationFriendNotificationParams, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, SessionActionSubmitTurnNotificationParams>) ((obj0, obj1) => this.딟<SessionActionSubmitTurnNotificationParams>(obj0, obj1, new Action<SessionActionSubmitTurnNotificationParams, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, FileStoreData>) ((obj0, obj1) => this.딟<FileStoreData>(obj0, obj1, new Action<FileStoreData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, CatalogEntry>) ((obj0, obj1) => this.딟<CatalogEntry>(obj0, obj1, new Action<CatalogEntry, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, 딟.딪>) ((obj0, obj1) => obj0.Append((int) obj1));
      this.딟 = (Action<StringBuilder, 딟.떕>) ((obj0, obj1) => obj0.Append((int) obj1));
      this.딟 = (Action<StringBuilder, OfferData[]>) ((obj0, obj1) => this.딟<OfferData>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, CatalogPagination>) ((obj0, obj1) => this.딟<CatalogPagination>(obj0, obj1, new Action<CatalogPagination, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, CatalogEntry[]>) ((obj0, obj1) => this.딟<CatalogEntry>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, MarkNotificationReadUpdateData>) ((obj0, obj1) => this.딟<MarkNotificationReadUpdateData>(obj0, obj1, new Action<MarkNotificationReadUpdateData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, MarkNotificationReadData>) ((obj0, obj1) => this.딟<MarkNotificationReadData>(obj0, obj1, new Action<MarkNotificationReadData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, MinimalFacebookInfo>) ((obj0, obj1) => this.딟<MinimalFacebookInfo>(obj0, obj1, new Action<MinimalFacebookInfo, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, FacebookFriendsData>) ((obj0, obj1) => this.딟<FacebookFriendsData>(obj0, obj1, new Action<FacebookFriendsData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, FacebookFriendData[]>) ((obj0, obj1) => this.딟<FacebookFriendData>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, FriendsData>) ((obj0, obj1) => this.딟<FriendsData>(obj0, obj1, new Action<FriendsData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, UserData[]>) ((obj0, obj1) => this.딟<UserData>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, OffersData>) ((obj0, obj1) => this.딟<OffersData>(obj0, obj1, new Action<OffersData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, ApplicationStatus>) ((obj0, obj1) => this.딟<ApplicationStatus>(obj0, obj1, new Action<ApplicationStatus, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, FileInfo>) ((obj0, obj1) => this.딟<FileInfo>(obj0, obj1, new Action<FileInfo, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, FileList>) ((obj0, obj1) => this.딟<FileList>(obj0, obj1, new Action<FileList, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, FileInfo[]>) ((obj0, obj1) => this.딟<FileInfo>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, SessionCreationWriteData>) ((obj0, obj1) => this.딟<SessionCreationWriteData>(obj0, obj1, new Action<SessionCreationWriteData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, PublicProfileWriteData>) ((obj0, obj1) => this.딟<PublicProfileWriteData>(obj0, obj1, new Action<PublicProfileWriteData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, SplashDamage.Mobile.Fireteam.NaClPushChannelData>) ((obj0, obj1) => this.딟<SplashDamage.Mobile.Fireteam.NaClPushChannelData>(obj0, obj1, new Action<SplashDamage.Mobile.Fireteam.NaClPushChannelData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, EchoSessionJson>) ((obj0, obj1) => this.딟<EchoSessionJson>(obj0, obj1, new Action<EchoSessionJson, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, EchoSessionListJson>) ((obj0, obj1) => this.딟<EchoSessionListJson>(obj0, obj1, new Action<EchoSessionListJson, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, EchoSessionJson[]>) ((obj0, obj1) => this.딟<EchoSessionJson>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, EchoEventListJson>) ((obj0, obj1) => this.딟<EchoEventListJson>(obj0, obj1, new Action<EchoEventListJson, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, EchoEventJson[]>) ((obj0, obj1) => this.딟<EchoEventJson>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, EchoEventJson>) ((obj0, obj1) => this.딟<EchoEventJson>(obj0, obj1, new Action<EchoEventJson, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, ScoreTableEntryData>) ((obj0, obj1) => this.딟<ScoreTableEntryData>(obj0, obj1, new Action<ScoreTableEntryData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, ScoreTableData>) ((obj0, obj1) => this.딟<ScoreTableData>(obj0, obj1, new Action<ScoreTableData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, Dictionary<string, Dictionary<string, ScoreTableEntryData>>>) ((obj0, obj1) => this.딟<string, Dictionary<string, ScoreTableEntryData>>(obj0, (IDictionary<string, Dictionary<string, ScoreTableEntryData>>) obj1, this.딟));
      this.딟 = (Action<StringBuilder, ScoreBoardOps>) ((obj0, obj1) => this.딟<ScoreBoardOps>(obj0, obj1, new Action<ScoreBoardOps, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, Dictionary<string, List<object>>>) ((obj0, obj1) => this.딟<string, List<object>>(obj0, (IDictionary<string, List<object>>) obj1, this.딟));
      this.딟 = (Action<StringBuilder, JWTData>) ((obj0, obj1) => this.딟<JWTData>(obj0, obj1, new Action<JWTData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, ExternalCallResponse>) ((obj0, obj1) => this.딟<ExternalCallResponse>(obj0, obj1, new Action<ExternalCallResponse, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, JavaScriptCallPayload>) ((obj0, obj1) => this.딟<JavaScriptCallPayload>(obj0, obj1, new Action<JavaScriptCallPayload, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, JSResponse>) ((obj0, obj1) => this.딟<JSResponse>(obj0, obj1, new Action<JSResponse, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, JSRequest>) ((obj0, obj1) => this.딟<JSRequest>(obj0, obj1, new Action<JSRequest, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, List<JSRequestHeader>>) ((obj0, obj1) => this.딟<JSRequestHeader>(obj0, (IEnumerable<JSRequestHeader>) obj1, this.딟));
      this.딟 = (Action<StringBuilder, JSRequestHeader>) ((obj0, obj1) => this.딟<JSRequestHeader>(obj0, obj1, new Action<JSRequestHeader, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, SplashDamage.Mobile.Notifications.NaClPushChannelData>) ((obj0, obj1) => this.딟<SplashDamage.Mobile.Notifications.NaClPushChannelData>(obj0, obj1, new Action<SplashDamage.Mobile.Notifications.NaClPushChannelData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, BuildManifestPrefabData>) ((obj0, obj1) => this.딟<BuildManifestPrefabData>(obj0, obj1, new Action<BuildManifestPrefabData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, BuildManifestAvatarData>) ((obj0, obj1) => this.딟<BuildManifestAvatarData>(obj0, obj1, new Action<BuildManifestAvatarData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, BuildManifestCharacterData>) ((obj0, obj1) => this.딟<BuildManifestCharacterData>(obj0, obj1, new Action<BuildManifestCharacterData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, BuildManifestGameDataData>) ((obj0, obj1) => this.딟<BuildManifestGameDataData>(obj0, obj1, new Action<BuildManifestGameDataData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, BuildManifestWeaponData>) ((obj0, obj1) => this.딟<BuildManifestWeaponData>(obj0, obj1, new Action<BuildManifestWeaponData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, BuildManifestVoicePackData>) ((obj0, obj1) => this.딟<BuildManifestVoicePackData>(obj0, obj1, new Action<BuildManifestVoicePackData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, BuildManifestOutfitData>) ((obj0, obj1) => this.딟<BuildManifestOutfitData>(obj0, obj1, new Action<BuildManifestOutfitData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, BuildManifestLevelData>) ((obj0, obj1) => this.딟<BuildManifestLevelData>(obj0, obj1, new Action<BuildManifestLevelData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, BuildManifestChallengePackRequiredLevel>) ((obj0, obj1) => this.딟<BuildManifestChallengePackRequiredLevel>(obj0, obj1, new Action<BuildManifestChallengePackRequiredLevel, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, BuildManifestChallengePackChallenge>) ((obj0, obj1) => this.딟<BuildManifestChallengePackChallenge>(obj0, obj1, new Action<BuildManifestChallengePackChallenge, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, BuildManifestChallengePackData>) ((obj0, obj1) => this.딟<BuildManifestChallengePackData>(obj0, obj1, new Action<BuildManifestChallengePackData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, BuildManifestChallengePackChallenge[]>) ((obj0, obj1) => this.딟<BuildManifestChallengePackChallenge>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, BuildManifestChallengeData>) ((obj0, obj1) => this.딟<BuildManifestChallengeData>(obj0, obj1, new Action<BuildManifestChallengeData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, BuildManifestMapPackData>) ((obj0, obj1) => this.딟<BuildManifestMapPackData>(obj0, obj1, new Action<BuildManifestMapPackData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, BuildManifestMissionRewardEntry>) ((obj0, obj1) => this.딟<BuildManifestMissionRewardEntry>(obj0, obj1, new Action<BuildManifestMissionRewardEntry, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, BuildManifestMissionRewardsData>) ((obj0, obj1) => this.딟<BuildManifestMissionRewardsData>(obj0, obj1, new Action<BuildManifestMissionRewardsData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, BuildManifestMissionRewardEntry[]>) ((obj0, obj1) => this.딟<BuildManifestMissionRewardEntry>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, BuildManifestAtlasPackData>) ((obj0, obj1) => this.딟<BuildManifestAtlasPackData>(obj0, obj1, new Action<BuildManifestAtlasPackData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, TacticsBuildManifestDataJson>) ((obj0, obj1) => this.딟<TacticsBuildManifestDataJson>(obj0, obj1, new Action<TacticsBuildManifestDataJson, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, BuildManifestLevelData[]>) ((obj0, obj1) => this.딟<BuildManifestLevelData>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, BuildManifestOutfitData[]>) ((obj0, obj1) => this.딟<BuildManifestOutfitData>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, BuildManifestVoicePackData[]>) ((obj0, obj1) => this.딟<BuildManifestVoicePackData>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, BuildManifestWeaponData[]>) ((obj0, obj1) => this.딟<BuildManifestWeaponData>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, BuildManifestGameDataData[]>) ((obj0, obj1) => this.딟<BuildManifestGameDataData>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, BuildManifestCharacterData[]>) ((obj0, obj1) => this.딟<BuildManifestCharacterData>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, BuildManifestAvatarData[]>) ((obj0, obj1) => this.딟<BuildManifestAvatarData>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, BuildManifestPrefabData[]>) ((obj0, obj1) => this.딟<BuildManifestPrefabData>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, BuildManifestChallengeData[]>) ((obj0, obj1) => this.딟<BuildManifestChallengeData>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, BuildManifestMapPackData[]>) ((obj0, obj1) => this.딟<BuildManifestMapPackData>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, BuildManifestMissionRewardsData[]>) ((obj0, obj1) => this.딟<BuildManifestMissionRewardsData>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, BuildManifestChallengePackData[]>) ((obj0, obj1) => this.딟<BuildManifestChallengePackData>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, BuildManifestAtlasPackData[]>) ((obj0, obj1) => this.딟<BuildManifestAtlasPackData>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, BuildTimestampData>) ((obj0, obj1) => this.딟<BuildTimestampData>(obj0, obj1, new Action<BuildTimestampData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, SinglePlayerMissionScore>) ((obj0, obj1) => this.딟<SinglePlayerMissionScore>(obj0, obj1, new Action<SinglePlayerMissionScore, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, ClientProfileData>) ((obj0, obj1) => this.딟<ClientProfileData>(obj0, obj1, new Action<ClientProfileData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, UnitCharacterData[]>) ((obj0, obj1) => this.딟<UnitCharacterData>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, 딢.딮[]>) ((obj0, obj1) => this.딟<딢.딮>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, int[]>) ((obj0, obj1) => this.딟<int>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, SinglePlayerMissionScore[]>) ((obj0, obj1) => this.딟<SinglePlayerMissionScore>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, NewsDataText>) ((obj0, obj1) => this.딟<NewsDataText>(obj0, obj1, new Action<NewsDataText, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, NewsDataEntry>) ((obj0, obj1) => this.딟<NewsDataEntry>(obj0, obj1, new Action<NewsDataEntry, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, NewsDataJson>) ((obj0, obj1) => this.딟<NewsDataJson>(obj0, obj1, new Action<NewsDataJson, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, NewsDataEntry[]>) ((obj0, obj1) => this.딟<NewsDataEntry>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, SceneDataJson>) ((obj0, obj1) => this.딟<SceneDataJson>(obj0, obj1, new Action<SceneDataJson, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, CloudProfileJsonData>) ((obj0, obj1) => this.딟<CloudProfileJsonData>(obj0, obj1, new Action<CloudProfileJsonData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, FeaturedItemsDataJson>) ((obj0, obj1) => this.딟<FeaturedItemsDataJson>(obj0, obj1, new Action<FeaturedItemsDataJson, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, EngineVersionData>) ((obj0, obj1) => this.딟<EngineVersionData>(obj0, obj1, new Action<EngineVersionData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, FacebookLoginInfo>) ((obj0, obj1) => this.딟<FacebookLoginInfo>(obj0, obj1, new Action<FacebookLoginInfo, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, FireTeamCatalogEntryData>) ((obj0, obj1) => this.딟<FireTeamCatalogEntryData>(obj0, obj1, new Action<FireTeamCatalogEntryData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, FireTeamCatalogEntryURL>) ((obj0, obj1) => this.딟<FireTeamCatalogEntryURL>(obj0, obj1, new Action<FireTeamCatalogEntryURL, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, FireTeamCatalogEntryDescriptionAbilityData>) ((obj0, obj1) => this.딟<FireTeamCatalogEntryDescriptionAbilityData>(obj0, obj1, new Action<FireTeamCatalogEntryDescriptionAbilityData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, FireTeamCatalogEntryAdvertData>) ((obj0, obj1) => this.딟<FireTeamCatalogEntryAdvertData>(obj0, obj1, new Action<FireTeamCatalogEntryAdvertData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, FireTeamCatalogEntryDescriptionData>) ((obj0, obj1) => this.딟<FireTeamCatalogEntryDescriptionData>(obj0, obj1, new Action<FireTeamCatalogEntryDescriptionData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, FireTeamCatalogEntryDescriptionAbilityData[]>) ((obj0, obj1) => this.딟<FireTeamCatalogEntryDescriptionAbilityData>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, FireTeamUserProfileChallengeJsonData>) ((obj0, obj1) => this.딟<FireTeamUserProfileChallengeJsonData>(obj0, obj1, new Action<FireTeamUserProfileChallengeJsonData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, FireTeamUserProfileJsonData>) ((obj0, obj1) => this.딟<FireTeamUserProfileJsonData>(obj0, obj1, new Action<FireTeamUserProfileJsonData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, FireTeamUserProfileChallengeJsonData[]>) ((obj0, obj1) => this.딟<FireTeamUserProfileChallengeJsonData>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, FireTeamTurnBasedSessionAttributes>) ((obj0, obj1) => this.딟<FireTeamTurnBasedSessionAttributes>(obj0, obj1, new Action<FireTeamTurnBasedSessionAttributes, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, FireTeamStoreImportEntryData>) ((obj0, obj1) => this.딟<FireTeamStoreImportEntryData>(obj0, obj1, new Action<FireTeamStoreImportEntryData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, FireTeamStoreImportData>) ((obj0, obj1) => this.딟<FireTeamStoreImportData>(obj0, obj1, new Action<FireTeamStoreImportData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, FireTeamStoreImportEntryData[]>) ((obj0, obj1) => this.딟<FireTeamStoreImportEntryData>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, UnitBuff>) ((obj0, obj1) => this.딟<UnitBuff>(obj0, obj1, new Action<UnitBuff, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, 딢.떍>) ((obj0, obj1) => obj0.Append((int) obj1));
      this.딟 = (Action<StringBuilder, UnitTurnDataJson>) ((obj0, obj1) => this.딟<UnitTurnDataJson>(obj0, obj1, new Action<UnitTurnDataJson, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, 딢.딯>) ((obj0, obj1) => obj0.Append((int) obj1));
      this.딟 = (Action<StringBuilder, UnitBuff[]>) ((obj0, obj1) => this.딟<UnitBuff>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, TacticsActionData>) ((obj0, obj1) => this.딟<TacticsActionData>(obj0, obj1, new Action<TacticsActionData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, 딢.땀>) ((obj0, obj1) => obj0.Append((int) obj1));
      this.딟 = (Action<StringBuilder, 딢.딴>) ((obj0, obj1) => obj0.Append((int) obj1));
      this.딟 = (Action<StringBuilder, TacticsInitialTurnState>) ((obj0, obj1) => this.딟<TacticsInitialTurnState>(obj0, obj1, new Action<TacticsInitialTurnState, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, TacticsSessionStateData>) ((obj0, obj1) => this.딟<TacticsSessionStateData>(obj0, obj1, new Action<TacticsSessionStateData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, TacticsGameStateTurnData>) ((obj0, obj1) => this.딟<TacticsGameStateTurnData>(obj0, obj1, new Action<TacticsGameStateTurnData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, UnitTurnDataJson[]>) ((obj0, obj1) => this.딟<UnitTurnDataJson>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, TacticsActionData[]>) ((obj0, obj1) => this.딟<TacticsActionData>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, UnitCharacterData>) ((obj0, obj1) => this.딟<UnitCharacterData>(obj0, obj1, new Action<UnitCharacterData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, 딢.딴[]>) ((obj0, obj1) => this.딟<딢.딴>(obj0, obj1, this.딟));
      this.딟 = (Action<StringBuilder, TacticsGameStateData>) ((obj0, obj1) => this.딟<TacticsGameStateData>(obj0, obj1, new Action<TacticsGameStateData, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, TacticsTurnStateUnits>) ((obj0, obj1) => this.딟<TacticsTurnStateUnits>(obj0, obj1, new Action<TacticsTurnStateUnits, StringBuilder>(this.딟)));
      this.딟 = (Action<StringBuilder, 딟.땾>) ((obj0, obj1) => obj0.Append((int) obj1));
      this.딟 = (Action<StringBuilder, Dictionary<string, ScoreTableEntryData>>) ((obj0, obj1) => this.딟<string, ScoreTableEntryData>(obj0, (IDictionary<string, ScoreTableEntryData>) obj1, this.딟));
      this.딟 = (Action<StringBuilder, List<object>>) ((obj0, obj1) => this.딟<object>(obj0, (IEnumerable<object>) obj1, new Action<StringBuilder, object>(((딧.딾) this).딢)));
      this.딟 = (Action<StringBuilder, 딢.딮>) ((obj0, obj1) => obj0.Append((int) obj1));
      this.딟(typeof (MixPanelEventData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as MixPanelEventData)));
      this.딟(typeof (GAEventParam), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as GAEventParam)));
      this.딟(typeof (GAEvent), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as GAEvent)));
      this.딟(typeof (BuildManifestDataWrapper), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as BuildManifestDataWrapper)));
      this.딟(typeof (BuildManifestDataJson), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as BuildManifestDataJson)));
      this.딟(typeof (BuildManifestBundleData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as BuildManifestBundleData)));
      this.딟(typeof (UserData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as UserData)));
      this.딟(typeof (FacebookFriendData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as FacebookFriendData)));
      this.딟(typeof (ErrorData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as ErrorData)));
      this.딟(typeof (AccessTokenData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as AccessTokenData)));
      this.딟(typeof (XboxAuthToken), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as XboxAuthToken)));
      this.딟(typeof (XboxXuidLink), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as XboxXuidLink)));
      this.딟(typeof (InventoryData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as InventoryData)));
      this.딟(typeof (OfferRealPriceData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as OfferRealPriceData)));
      this.딟(typeof (OfferData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as OfferData)));
      this.딟(typeof (TurnOp_AddToInventory), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as TurnOp_AddToInventory)));
      this.딟(typeof (TurnOp_Consume), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as TurnOp_Consume)));
      this.딟(typeof (TurnBasedSessionTurnData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as TurnBasedSessionTurnData)));
      this.딟(typeof (TurnBasedSessionData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as TurnBasedSessionData)));
      this.딟(typeof (SessionUserData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as SessionUserData)));
      this.딟(typeof (SessionListData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as SessionListData)));
      this.딟(typeof (SessionTurnsListData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as SessionTurnsListData)));
      this.딟(typeof (SessionJoinData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as SessionJoinData)));
      this.딟(typeof (WriteSessionTurnData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as WriteSessionTurnData)));
      this.딟(typeof (TransactionData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as TransactionData)));
      this.딟(typeof (PurchaseResult), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as PurchaseResult)));
      this.딟(typeof (BlindBoxTestResult), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as BlindBoxTestResult)));
      this.딟(typeof (NotificationData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as NotificationData)));
      this.딟(typeof (NotificationsData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as NotificationsData)));
      this.딟(typeof (SessionEventNotificationParams), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as SessionEventNotificationParams)));
      this.딟(typeof (SessionInviteNotificationParams), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as SessionInviteNotificationParams)));
      this.딟(typeof (SessionUserEventNotificationParams), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as SessionUserEventNotificationParams)));
      this.딟(typeof (RelationFriendNotificationParams), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as RelationFriendNotificationParams)));
      this.딟(typeof (SessionActionSubmitTurnNotificationParams), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as SessionActionSubmitTurnNotificationParams)));
      this.딟(typeof (FileStoreData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as FileStoreData)));
      this.딟(typeof (CatalogEntry), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as CatalogEntry)));
      this.딟(typeof (CatalogPagination), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as CatalogPagination)));
      this.딟(typeof (MarkNotificationReadUpdateData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as MarkNotificationReadUpdateData)));
      this.딟(typeof (MarkNotificationReadData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as MarkNotificationReadData)));
      this.딟(typeof (MinimalFacebookInfo), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as MinimalFacebookInfo)));
      this.딟(typeof (FacebookFriendsData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as FacebookFriendsData)));
      this.딟(typeof (FriendsData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as FriendsData)));
      this.딟(typeof (OffersData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as OffersData)));
      this.딟(typeof (ApplicationStatus), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as ApplicationStatus)));
      this.딟(typeof (FileInfo), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as FileInfo)));
      this.딟(typeof (FileList), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as FileList)));
      this.딟(typeof (SessionCreationWriteData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as SessionCreationWriteData)));
      this.딟(typeof (PublicProfileWriteData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as PublicProfileWriteData)));
      this.딟(typeof (SplashDamage.Mobile.Fireteam.NaClPushChannelData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as SplashDamage.Mobile.Fireteam.NaClPushChannelData)));
      this.딟(typeof (EchoSessionJson), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as EchoSessionJson)));
      this.딟(typeof (EchoSessionListJson), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as EchoSessionListJson)));
      this.딟(typeof (EchoEventListJson), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as EchoEventListJson)));
      this.딟(typeof (EchoEventJson), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as EchoEventJson)));
      this.딟(typeof (ScoreTableEntryData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as ScoreTableEntryData)));
      this.딟(typeof (ScoreTableData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as ScoreTableData)));
      this.딟(typeof (ScoreBoardOps), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as ScoreBoardOps)));
      this.딟(typeof (JWTData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as JWTData)));
      this.딟(typeof (ExternalCallResponse), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as ExternalCallResponse)));
      this.딟(typeof (JavaScriptCallPayload), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as JavaScriptCallPayload)));
      this.딟(typeof (JSResponse), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as JSResponse)));
      this.딟(typeof (JSRequest), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as JSRequest)));
      this.딟(typeof (JSRequestHeader), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as JSRequestHeader)));
      this.딟(typeof (SplashDamage.Mobile.Notifications.NaClPushChannelData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as SplashDamage.Mobile.Notifications.NaClPushChannelData)));
      this.딟(typeof (BuildManifestPrefabData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as BuildManifestPrefabData)));
      this.딟(typeof (BuildManifestAvatarData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as BuildManifestAvatarData)));
      this.딟(typeof (BuildManifestCharacterData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as BuildManifestCharacterData)));
      this.딟(typeof (BuildManifestGameDataData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as BuildManifestGameDataData)));
      this.딟(typeof (BuildManifestWeaponData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as BuildManifestWeaponData)));
      this.딟(typeof (BuildManifestVoicePackData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as BuildManifestVoicePackData)));
      this.딟(typeof (BuildManifestOutfitData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as BuildManifestOutfitData)));
      this.딟(typeof (BuildManifestLevelData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as BuildManifestLevelData)));
      this.딟(typeof (BuildManifestChallengePackRequiredLevel), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as BuildManifestChallengePackRequiredLevel)));
      this.딟(typeof (BuildManifestChallengePackChallenge), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as BuildManifestChallengePackChallenge)));
      this.딟(typeof (BuildManifestChallengePackData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as BuildManifestChallengePackData)));
      this.딟(typeof (BuildManifestChallengeData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as BuildManifestChallengeData)));
      this.딟(typeof (BuildManifestMapPackData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as BuildManifestMapPackData)));
      this.딟(typeof (BuildManifestMissionRewardEntry), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as BuildManifestMissionRewardEntry)));
      this.딟(typeof (BuildManifestMissionRewardsData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as BuildManifestMissionRewardsData)));
      this.딟(typeof (BuildManifestAtlasPackData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as BuildManifestAtlasPackData)));
      this.딟(typeof (TacticsBuildManifestDataJson), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as TacticsBuildManifestDataJson)));
      this.딟(typeof (BuildTimestampData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as BuildTimestampData)));
      this.딟(typeof (SinglePlayerMissionScore), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as SinglePlayerMissionScore)));
      this.딟(typeof (ClientProfileData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as ClientProfileData)));
      this.딟(typeof (NewsDataText), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as NewsDataText)));
      this.딟(typeof (NewsDataEntry), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as NewsDataEntry)));
      this.딟(typeof (NewsDataJson), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as NewsDataJson)));
      this.딟(typeof (SceneDataJson), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as SceneDataJson)));
      this.딟(typeof (CloudProfileJsonData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as CloudProfileJsonData)));
      this.딟(typeof (FeaturedItemsDataJson), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as FeaturedItemsDataJson)));
      this.딟(typeof (EngineVersionData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as EngineVersionData)));
      this.딟(typeof (FacebookLoginInfo), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as FacebookLoginInfo)));
      this.딟(typeof (FireTeamCatalogEntryData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as FireTeamCatalogEntryData)));
      this.딟(typeof (FireTeamCatalogEntryDescriptionAbilityData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as FireTeamCatalogEntryDescriptionAbilityData)));
      this.딟(typeof (FireTeamCatalogEntryAdvertData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as FireTeamCatalogEntryAdvertData)));
      this.딟(typeof (FireTeamCatalogEntryDescriptionData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as FireTeamCatalogEntryDescriptionData)));
      this.딟(typeof (FireTeamCatalogEntryURL), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as FireTeamCatalogEntryURL)));
      this.딟(typeof (FireTeamUserProfileChallengeJsonData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as FireTeamUserProfileChallengeJsonData)));
      this.딟(typeof (FireTeamUserProfileJsonData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as FireTeamUserProfileJsonData)));
      this.딟(typeof (FireTeamTurnBasedSessionAttributes), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as FireTeamTurnBasedSessionAttributes)));
      this.딟(typeof (FireTeamStoreImportEntryData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as FireTeamStoreImportEntryData)));
      this.딟(typeof (FireTeamStoreImportData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as FireTeamStoreImportData)));
      this.딟(typeof (UnitBuff), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as UnitBuff)));
      this.딟(typeof (UnitTurnDataJson), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as UnitTurnDataJson)));
      this.딟(typeof (TacticsActionData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as TacticsActionData)));
      this.딟(typeof (TacticsInitialTurnState), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as TacticsInitialTurnState)));
      this.딟(typeof (TacticsSessionStateData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as TacticsSessionStateData)));
      this.딟(typeof (TacticsGameStateTurnData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as TacticsGameStateTurnData)));
      this.딟(typeof (UnitCharacterData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as UnitCharacterData)));
      this.딟(typeof (TacticsGameStateData), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as TacticsGameStateData)));
      this.딟(typeof (TacticsTurnStateUnits), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, obj1 as TacticsTurnStateUnits)));
    }

    private void 딟([In] MixPanelEventData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"event\":");
      딧.딾.딟(obj1, obj0.Event);
      obj1.Append(",\"properties\":");
      this.딟(obj1, obj0.Properties);
      obj1.Append("}");
    }

    private void 딟([In] GAEventParam obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"key\":");
      딧.딾.딟(obj1, obj0.Key);
      obj1.Append(",\"value\":");
      딧.딾.딟(obj1, obj0.Value);
      obj1.Append("}");
    }

    private void 딟([In] GAEvent obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"category\":");
      딧.딾.딟(obj1, obj0.Category);
      obj1.Append(",\"action\":");
      딧.딾.딟(obj1, obj0.Action);
      obj1.Append(",\"label\":");
      딧.딾.딟(obj1, obj0.Label);
      obj1.Append(",\"value\":");
      this.딟(obj1, obj0.Value);
      obj1.Append("}");
    }

    private void 딟([In] BuildManifestDataWrapper obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"base\":");
      this.딟(obj1, obj0.Base);
      obj1.Append(",\"game\":");
      this.딟(obj1, obj0.Game);
      obj1.Append("}");
    }

    private void 딟([In] BuildManifestDataJson obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"Bundles\":");
      this.딟(obj1, obj0.Bundles);
      obj1.Append(",\"url_cdn\":");
      딧.딾.딟(obj1, obj0.CDNUrl);
      obj1.Append(",\"output_bundle_manifests\":");
      딧.딾.딟(obj1, obj0.OutputBundleManifests);
      obj1.Append(",\"version\":");
      this.딟(obj1, obj0.Version);
      obj1.Append("}");
    }

    private void 딟([In] BuildManifestBundleData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"Content\":");
      this.딟(obj1, obj0.Content);
      obj1.Append(",\"Internal\":");
      딧.딾.딟(obj1, obj0.Internal);
      obj1.Append(",\"Name\":");
      딧.딾.딟(obj1, obj0.Name);
      obj1.Append(",\"resource\":");
      딧.딾.딟(obj1, obj0.ResourceName);
      obj1.Append(",\"version\":");
      this.딟(obj1, obj0.Version);
      obj1.Append("}");
    }

    private void 딟([In] UserData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"email_address\":");
      딧.딾.딟(obj1, obj0.Email);
      obj1.Append(",\"public_profile_data\":");
      this.딟(obj1, obj0.PublicProfileData);
      obj1.Append(",\"user_id\":");
      딧.딾.딟(obj1, obj0.UserId);
      obj1.Append(",\"username\":");
      딧.딾.딟(obj1, obj0.UserName);
      obj1.Append("}");
    }

    private void 딟([In] FacebookFriendData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"facebook_id\":");
      딧.딾.딟(obj1, obj0.FacebookId);
      obj1.Append(",\"public_profile_data\":");
      this.딟(obj1, obj0.PublicProfileData);
      obj1.Append(",\"user_id\":");
      딧.딾.딟(obj1, obj0.UserId);
      obj1.Append(",\"username\":");
      딧.딾.딟(obj1, obj0.UserName);
      obj1.Append("}");
    }

    private void 딟([In] ErrorData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"code\":");
      this.딟(obj1, obj0.Code);
      obj1.Append(",\"error\":");
      딧.딾.딟(obj1, obj0.Error);
      obj1.Append(",\"message\":");
      딧.딾.딟(obj1, obj0.Message);
      obj1.Append("}");
    }

    private void 딟([In] AccessTokenData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"access_token\":");
      딧.딾.딟(obj1, obj0.AccessToken);
      obj1.Append(",\"refresh_token\":");
      딧.딾.딟(obj1, obj0.RefreshToken);
      obj1.Append("}");
    }

    private void 딟([In] XboxAuthToken obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"token_type\":");
      딧.딾.딟(obj1, obj0.TokenType);
      obj1.Append(",\"access_token\":");
      딧.딾.딟(obj1, obj0.AccessToken);
      obj1.Append(",\"expires_in\":");
      this.딟(obj1, obj0.ExpiresIn);
      obj1.Append(",\"refresh_token\":");
      딧.딾.딟(obj1, obj0.RefreshToken);
      obj1.Append("}");
    }

    private void 딟([In] XboxXuidLink obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"xuid\":");
      this.딟(obj1, obj0.XuidValue);
      obj1.Append(",\"pxuid\":");
      딧.딾.딟(obj1, obj0.Pxuid);
      obj1.Append("}");
    }

    private void 딟([In] InventoryData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"inventory\":");
      this.딟(obj1, obj0.Inventory);
      obj1.Append("}");
    }

    private void 딟([In] OfferRealPriceData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"currency\":");
      딧.딾.딟(obj1, obj0.Currency);
      obj1.Append(",\"region\":");
      딧.딾.딟(obj1, obj0.Region);
      obj1.Append(",\"amount\":");
      this.딟(obj1, obj0.Amount);
      obj1.Append(",\"tax\":");
      this.딟(obj1, obj0.Tax);
      obj1.Append("}");
    }

    private void 딟([In] OfferData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"id\":");
      딧.딾.딟(obj1, obj0.Id);
      obj1.Append(",\"item_id\":");
      딧.딾.딟(obj1, obj0.ItemId);
      obj1.Append(",\"price\":");
      this.딟(obj1, obj0.Price);
      obj1.Append(",\"price_original\":");
      this.딟(obj1, obj0.PriceOriginal);
      obj1.Append(",\"product_id\":");
      딧.딾.딟(obj1, obj0.ProductId);
      obj1.Append(",\"vendor\":");
      this.딟(obj1, obj0.Vendor);
      obj1.Append(",\"price_real\":");
      this.딟(obj1, obj0.RealPrice);
      obj1.Append("}");
    }

    private void 딟([In] TurnOp_AddToInventory obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"user_id\":");
      딧.딾.딟(obj1, obj0.UserId);
      obj1.Append(",\"item_id\":");
      딧.딾.딟(obj1, obj0.ItemId);
      obj1.Append(",\"quantity\":");
      this.딟(obj1, obj0.Quantity);
      obj1.Append("}");
    }

    private void 딟([In] TurnOp_Consume obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"item_id\":");
      딧.딾.딟(obj1, obj0.ItemId);
      obj1.Append(",\"quantity\":");
      this.딟(obj1, obj0.Quantity);
      obj1.Append("}");
    }

    private void 딟([In] TurnBasedSessionTurnData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"created_at\":");
      this.딟(obj1, obj0.CompletionTime);
      obj1.Append(",\"data\":");
      딧.딾.딟(obj1, obj0.Data);
      obj1.Append(",\"expire_ops\":");
      this.딟(obj1, obj0.ExpireOps);
      obj1.Append(",\"index\":");
      this.딟(obj1, obj0.Index);
      obj1.Append(",\"inventory\":");
      this.딟(obj1, obj0.Inventory);
      obj1.Append(",\"next_user_id\":");
      딧.딾.딟(obj1, obj0.NextUserId);
      obj1.Append(",\"ops\":");
      this.딟(obj1, obj0.Ops);
      obj1.Append(",\"user_id\":");
      딧.딾.딟(obj1, obj0.UserId);
      obj1.Append("}");
    }

    private void 딟([In] TurnBasedSessionData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"attributes\":");
      this.딟(obj1, obj0.Attributes);
      obj1.Append(",\"current_user_id\":");
      딧.딾.딟(obj1, obj0.CurrentUserId);
      obj1.Append(",\"expires_at\":");
      this.딟(obj1, obj0.ExpiresAtTime);
      obj1.Append(",\"filled_private_slots\":");
      this.딟(obj1, obj0.FilledPrivateSlots);
      obj1.Append(",\"filled_public_slots\":");
      this.딟(obj1, obj0.FilledPublicSlots);
      obj1.Append(",\"id\":");
      딧.딾.딟(obj1, obj0.Id);
      obj1.Append(",\"num_turns\":");
      this.딟(obj1, obj0.NumTurns);
      obj1.Append(",\"outcomes\":");
      this.딟(obj1, obj0.Outcomes);
      obj1.Append(",\"private_slots\":");
      this.딟(obj1, obj0.PrivateSlots);
      obj1.Append(",\"public_slots\":");
      this.딟(obj1, obj0.PublicSlots);
      obj1.Append(",\"session_type\":");
      this.딟(obj1, obj0.SessionType);
      obj1.Append(",\"state\":");
      this.딟(obj1, obj0.State);
      obj1.Append(",\"updated_at\":");
      this.딟(obj1, obj0.UpdatedAtTime);
      obj1.Append(",\"users\":");
      this.딟(obj1, obj0.Users);
      obj1.Append("}");
    }

    private void 딟([In] SessionUserData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"flags\":");
      this.딟(obj1, obj0.Flags);
      obj1.Append(",\"user_id\":");
      딧.딾.딟(obj1, obj0.UserId);
      obj1.Append("}");
    }

    private void 딟([In] SessionListData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"items\":");
      this.딟(obj1, obj0.Items);
      obj1.Append("}");
    }

    private void 딟([In] SessionTurnsListData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"items\":");
      this.딟(obj1, obj0.Items);
      obj1.Append("}");
    }

    private void 딟([In] SessionJoinData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"slot_type\":");
      this.딟(obj1, obj0.SlotType);
      obj1.Append("}");
    }

    private void 딟([In] WriteSessionTurnData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"next_user_id\":");
      딧.딾.딟(obj1, obj0.NextUserId);
      obj1.Append(",\"data\":");
      딧.딾.딟(obj1, obj0.Data);
      if (obj0.Ops != null)
      {
        obj1.Append(",\"ops\":");
        this.딟(obj1, obj0.Ops);
      }
      if (obj0.Inventory != null)
      {
        obj1.Append(",\"inventory\":");
        this.딟(obj1, obj0.Inventory);
      }
      if (obj0.JoinSlotType != 딟.땎.딟)
      {
        obj1.Append(",\"join_slot_type\":");
        this.딟(obj1, obj0.JoinSlotType);
      }
      if (obj0.Outcomes != null)
      {
        obj1.Append(",\"outcomes\":");
        this.딟(obj1, obj0.Outcomes);
      }
      if (obj0.State != 딟.딺.땄)
      {
        obj1.Append(",\"state\":");
        this.딟(obj1, obj0.State);
      }
      if (obj0.ExpireOps != null)
      {
        obj1.Append(",\"expire_ops\":");
        this.딟(obj1, obj0.ExpireOps);
      }
      obj1.Append("}");
    }

    private void 딟([In] TransactionData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"transaction_id\":");
      딧.딾.딟(obj1, obj0.TransactionId);
      obj1.Append("}");
    }

    private void 딟([In] PurchaseResult obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"items\":");
      this.딟(obj1, obj0.Items);
      obj1.Append("}");
    }

    private void 딟([In] BlindBoxTestResult obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"rolls\":");
      this.딟(obj1, obj0.rolls);
      obj1.Append("}");
    }

    private void 딟([In] NotificationData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"id\":");
      딧.딾.딟(obj1, obj0.Id);
      obj1.Append(",\"receiver_id\":");
      딧.딾.딟(obj1, obj0.ReceiverId);
      obj1.Append(",\"app_id\":");
      딧.딾.딟(obj1, obj0.AppId);
      obj1.Append(",\"realm_level\":");
      딧.딾.딟(obj1, obj0.IsRealmLevel);
      obj1.Append(",\"deletion_policy\":");
      this.딟(obj1, obj0.DeletionPolicy);
      obj1.Append(",\"read\":");
      딧.딾.딟(obj1, obj0.Read);
      obj1.Append(",\"cancelled\":");
      딧.딾.딟(obj1, obj0.Cancelled);
      obj1.Append(",\"expires\":");
      this.딟(obj1, obj0.Expires);
      obj1.Append(",\"sent_date\":");
      this.딟(obj1, obj0.SentDate);
      obj1.Append(",\"declaration\":");
      this.딟(obj1, obj0.Declaration);
      obj1.Append("}");
    }

    private void 딟([In] NotificationsData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"items\":");
      this.딟(obj1, obj0.Items);
      obj1.Append("}");
    }

    private void 딟([In] SessionEventNotificationParams obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"session_id\":");
      딧.딾.딟(obj1, obj0.SessionId);
      obj1.Append("}");
    }

    private void 딟([In] SessionInviteNotificationParams obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"session_id\":");
      딧.딾.딟(obj1, obj0.SessionId);
      obj1.Append(",\"user_id\":");
      딧.딾.딟(obj1, obj0.UserId);
      obj1.Append(",\"invite_id\":");
      딧.딾.딟(obj1, obj0.InviteId);
      obj1.Append("}");
    }

    private void 딟([In] SessionUserEventNotificationParams obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"session_id\":");
      딧.딾.딟(obj1, obj0.SessionId);
      obj1.Append(",\"user_id\":");
      딧.딾.딟(obj1, obj0.UserId);
      obj1.Append("}");
    }

    private void 딟([In] RelationFriendNotificationParams obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"user_id\":");
      딧.딾.딟(obj1, obj0.UserId);
      obj1.Append(",\"message\":");
      딧.딾.딟(obj1, obj0.Message);
      obj1.Append("}");
    }

    private void 딟([In] SessionActionSubmitTurnNotificationParams obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"session_id\":");
      딧.딾.딟(obj1, obj0.SessionId);
      obj1.Append(",\"last_user_id\":");
      딧.딾.딟(obj1, obj0.LastUserId);
      obj1.Append("}");
    }

    private void 딟([In] FileStoreData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"data\":");
      딧.딾.딟(obj1, obj0.Data);
      obj1.Append("}");
    }

    private void 딟([In] CatalogEntry obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"id\":");
      딧.딾.딟(obj1, obj0.Id);
      obj1.Append(",\"type\":");
      this.딟(obj1, obj0.Type);
      obj1.Append(",\"flags\":");
      this.딟(obj1, obj0.Flags);
      obj1.Append(",\"category\":");
      딧.딾.딟(obj1, obj0.Category);
      obj1.Append(",\"tags\":");
      this.딟(obj1, obj0.Tags);
      obj1.Append(",\"dependencies\":");
      this.딟(obj1, obj0.Dependencies);
      obj1.Append(",\"data\":");
      this.딟(obj1, obj0.Data);
      obj1.Append(",\"name\":");
      딧.딾.딟(obj1, obj0.Name);
      obj1.Append(",\"description\":");
      딧.딾.딟(obj1, obj0.Description);
      obj1.Append(",\"icon_url\":");
      딧.딾.딟(obj1, obj0.IconURL);
      obj1.Append(",\"preview_urls\":");
      this.딟(obj1, obj0.PreviewURLs);
      obj1.Append(",\"video_url\":");
      딧.딾.딟(obj1, obj0.VideoURL);
      obj1.Append(",\"info\":");
      this.딟(obj1, obj0.Info);
      obj1.Append(",\"owned_quantity\":");
      this.딟(obj1, obj0.OwnedQuantity);
      obj1.Append(",\"items\":");
      this.딟(obj1, obj0.Items);
      obj1.Append(",\"offers\":");
      this.딟(obj1, obj0.Offers);
      obj1.Append("}");
    }

    private void 딟([In] CatalogPagination obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"page\":");
      this.딟(obj1, obj0.Page);
      obj1.Append(",\"prev_page\":");
      this.딟(obj1, obj0.PrevPage);
      obj1.Append(",\"next_page\":");
      this.딟(obj1, obj0.NextPage);
      obj1.Append(",\"pages\":");
      this.딟(obj1, obj0.Pages);
      obj1.Append(",\"total_count\":");
      this.딟(obj1, obj0.TotalCount);
      obj1.Append(",\"items\":");
      this.딟(obj1, obj0.Items);
      obj1.Append("}");
    }

    private void 딟([In] MarkNotificationReadUpdateData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"read\":");
      딧.딾.딟(obj1, obj0.Read);
      obj1.Append("}");
    }

    private void 딟([In] MarkNotificationReadData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"update\":");
      this.딟(obj1, obj0.UpdateData);
      obj1.Append("}");
    }

    private void 딟([In] MinimalFacebookInfo obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"facebook_id\":");
      딧.딾.딟(obj1, obj0.FacebookId);
      obj1.Append("}");
    }

    private void 딟([In] FacebookFriendsData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"items\":");
      this.딟(obj1, obj0.Items);
      obj1.Append("}");
    }

    private void 딟([In] FriendsData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"items\":");
      this.딟(obj1, obj0.Items);
      obj1.Append("}");
    }

    private void 딟([In] OffersData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"offers\":");
      this.딟(obj1, obj0.Offers);
      obj1.Append("}");
    }

    private void 딟([In] ApplicationStatus obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"account_has_access\":");
      딧.딾.딟(obj1, obj0.AccountHasAccess);
      obj1.Append(",\"public\":");
      딧.딾.딟(obj1, obj0.Public);
      obj1.Append("}");
    }

    private void 딟([In] FileInfo obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"filename\":");
      딧.딾.딟(obj1, obj0.FileName);
      obj1.Append(",\"size\":");
      this.딟(obj1, obj0.Size);
      obj1.Append(",\"created_at\":");
      this.딟(obj1, obj0.CreatedAt);
      obj1.Append(",\"modified_at\":");
      this.딟(obj1, obj0.ModifiedAt);
      obj1.Append("}");
    }

    private void 딟([In] FileList obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"files\":");
      this.딟(obj1, obj0.Files);
      obj1.Append("}");
    }

    private void 딟([In] SessionCreationWriteData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"public_slots\":");
      this.딟(obj1, obj0.PublicSlots);
      obj1.Append(",\"private_slots\":");
      this.딟(obj1, obj0.PrivateSlots);
      obj1.Append(",\"join_slot_type\":");
      this.딟(obj1, obj0.JoinSlotType);
      obj1.Append(",\"attributes\":");
      base.딢(obj1, obj0.Attributes);
      obj1.Append(",\"nonce\":");
      딧.딾.딟(obj1, obj0.Nonce);
      obj1.Append(",\"turn_data\":");
      딧.딾.딟(obj1, obj0.TurnData);
      obj1.Append(",\"turn_inventory\":");
      this.딟(obj1, obj0.TurnInventory);
      obj1.Append(",\"invitees\":");
      this.딟(obj1, obj0.Invitees);
      obj1.Append("}");
    }

    private void 딟([In] PublicProfileWriteData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"data\":");
      base.딢(obj1, obj0.Data);
      obj1.Append("}");
    }

    private void 딟([In] SplashDamage.Mobile.Fireteam.NaClPushChannelData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"channel_id\":");
      딧.딾.딟(obj1, obj0.ChannelId);
      obj1.Append("}");
    }

    private void 딟([In] EchoSessionJson obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"timestamp\":");
      this.딟(obj1, obj0.Timestamp);
      obj1.Append(",\"users\":");
      this.딟(obj1, obj0.Users);
      obj1.Append(",\"session_id\":");
      딧.딾.딟(obj1, obj0.SessionId);
      obj1.Append(",\"type\":");
      딧.딾.딟(obj1, obj0.Type);
      obj1.Append(",\"data\":");
      this.딟(obj1, obj0.Data);
      obj1.Append("}");
    }

    private void 딟([In] EchoSessionListJson obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"user_name\":");
      딧.딾.딟(obj1, obj0.UserName);
      obj1.Append(",\"app_id\":");
      딧.딾.딟(obj1, obj0.AppId);
      obj1.Append(",\"user_sessions\":");
      this.딟(obj1, obj0.Sessions);
      obj1.Append("}");
    }

    private void 딟([In] EchoEventListJson obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"app_id\":");
      딧.딾.딟(obj1, obj0.AppId);
      obj1.Append(",\"session_id\":");
      딧.딾.딟(obj1, obj0.SessionId);
      obj1.Append(",\"events\":");
      this.딟(obj1, obj0.Events);
      obj1.Append("}");
    }

    private void 딟([In] EchoEventJson obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"type\":");
      딧.딾.딟(obj1, obj0.Type);
      obj1.Append(",\"users\":");
      this.딟(obj1, obj0.Users);
      obj1.Append(",\"event_id\":");
      딧.딾.딟(obj1, obj0.EventId);
      obj1.Append(",\"timestamp\":");
      this.딟(obj1, obj0.Timestamp);
      obj1.Append(",\"session_id\":");
      딧.딾.딟(obj1, obj0.SessionId);
      obj1.Append(",\"time\":");
      this.딟(obj1, obj0.Time);
      obj1.Append(",\"data\":");
      this.딟(obj1, obj0.Data);
      obj1.Append("}");
    }

    private void 딟([In] ScoreTableEntryData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"score\":");
      this.딟(obj1, obj0.Score);
      obj1.Append(",\"payload\":");
      base.딢(obj1, obj0.Payload);
      obj1.Append("}");
    }

    private void 딟([In] ScoreTableData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"table_name\":");
      딧.딾.딟(obj1, obj0.TableName);
      obj1.Append(",\"users\":");
      this.딟(obj1, obj0.Users);
      obj1.Append("}");
    }

    private void 딟([In] ScoreBoardOps obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"ops\":");
      this.딟(obj1, obj0.ops);
      obj1.Append("}");
    }

    private void 딟([In] JWTData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"jwt\":");
      딧.딾.딟(obj1, obj0.JWT);
      obj1.Append("}");
    }

    private void 딟([In] ExternalCallResponse obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"id\":");
      딧.딾.딟(obj1, obj0.Id);
      obj1.Append(",\"value\":");
      base.딢(obj1, obj0.Value);
      obj1.Append("}");
    }

    private void 딟([In] JavaScriptCallPayload obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"method\":");
      딧.딾.딟(obj1, obj0.Method);
      obj1.Append(",\"id\":");
      딧.딾.딟(obj1, obj0.Id);
      obj1.Append(",\"parameter\":");
      딧.딾.딟(obj1, obj0.Parameter);
      obj1.Append("}");
    }

    private void 딟([In] JSResponse obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"headers\":");
      딧.딾.딟(obj1, obj0.HeadersText);
      obj1.Append(",\"response\":");
      딧.딾.딟(obj1, obj0.Response);
      obj1.Append(",\"status\":");
      this.딟(obj1, obj0.Status);
      obj1.Append(",\"status_text\":");
      딧.딾.딟(obj1, obj0.StatusText);
      obj1.Append(",\"unique_id\":");
      딧.딾.딟(obj1, obj0.UniqueId);
      obj1.Append("}");
    }

    private void 딟([In] JSRequest obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"body\":");
      딧.딾.딟(obj1, obj0.Body);
      obj1.Append(",\"headers\":");
      this.딟(obj1, obj0.Headers);
      obj1.Append(",\"method\":");
      딧.딾.딟(obj1, obj0.Method);
      obj1.Append(",\"unique_id\":");
      딧.딾.딟(obj1, obj0.UniqueId);
      obj1.Append(",\"url\":");
      딧.딾.딟(obj1, obj0.Url);
      obj1.Append("}");
    }

    private void 딟([In] JSRequestHeader obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"key\":");
      딧.딾.딟(obj1, obj0.Key);
      obj1.Append(",\"value\":");
      딧.딾.딟(obj1, obj0.Value);
      obj1.Append("}");
    }

    private void 딟([In] SplashDamage.Mobile.Notifications.NaClPushChannelData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"channel_id\":");
      딧.딾.딟(obj1, obj0.ChannelId);
      obj1.Append("}");
    }

    private void 딟([In] BuildManifestPrefabData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"id\":");
      딧.딾.딟(obj1, obj0.Id);
      obj1.Append(",\"bundle\":");
      딧.딾.딟(obj1, obj0.Package);
      obj1.Append(",\"prefab\":");
      딧.딾.딟(obj1, obj0.AssetPath);
      obj1.Append("}");
    }

    private void 딟([In] BuildManifestAvatarData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"id\":");
      딧.딾.딟(obj1, obj0.Id);
      obj1.Append(",\"bundle\":");
      딧.딾.딟(obj1, obj0.Package);
      obj1.Append(",\"prefab\":");
      딧.딾.딟(obj1, obj0.AssetPath);
      obj1.Append(",\"productid\":");
      딧.딾.딟(obj1, obj0.ProductId);
      obj1.Append("}");
    }

    private void 딟([In] BuildManifestCharacterData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"id\":");
      딧.딾.딟(obj1, obj0.Id);
      obj1.Append(",\"bundle\":");
      딧.딾.딟(obj1, obj0.Package);
      obj1.Append(",\"prefab\":");
      딧.딾.딟(obj1, obj0.AssetPath);
      obj1.Append(",\"productid\":");
      딧.딾.딟(obj1, obj0.ProductId);
      obj1.Append(",\"bundleproductid\":");
      딧.딾.딟(obj1, obj0.BundleProductId);
      obj1.Append(",\"defaultweapon\":");
      딧.딾.딟(obj1, obj0.DefaultWeaponId);
      obj1.Append(",\"defaultvoicepack\":");
      딧.딾.딟(obj1, obj0.VoicePackId);
      obj1.Append(",\"fallbackvoicepack\":");
      딧.딾.딟(obj1, obj0.FallbackVoicePackId);
      obj1.Append(",\"levelreq\":");
      this.딟(obj1, obj0.LevelRequired);
      obj1.Append(",\"defaultoutfit\":");
      딧.딾.딟(obj1, obj0.DefaultOutfitId);
      obj1.Append(",\"advertise\":");
      딧.딾.딟(obj1, obj0.Advertise);
      obj1.Append(",\"tryoutmissionid\":");
      딧.딾.딟(obj1, obj0.TryoutMissionId);
      obj1.Append("}");
    }

    private void 딟([In] BuildManifestGameDataData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"id\":");
      딧.딾.딟(obj1, obj0.Id);
      obj1.Append(",\"bundle\":");
      딧.딾.딟(obj1, obj0.Package);
      obj1.Append(",\"prefab\":");
      딧.딾.딟(obj1, obj0.AssetPath);
      obj1.Append(",\"primary\":");
      딧.딾.딟(obj1, obj0.Primary);
      obj1.Append("}");
    }

    private void 딟([In] BuildManifestWeaponData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"id\":");
      딧.딾.딟(obj1, obj0.Id);
      obj1.Append(",\"bundle\":");
      딧.딾.딟(obj1, obj0.Package);
      obj1.Append(",\"prefab\":");
      딧.딾.딟(obj1, obj0.AssetPath);
      obj1.Append(",\"productid\":");
      딧.딾.딟(obj1, obj0.ProductId);
      obj1.Append(",\"showifowned\":");
      딧.딾.딟(obj1, obj0.OnlyShowIfOwned);
      obj1.Append(",\"levelreq\":");
      this.딟(obj1, obj0.LevelRequired);
      obj1.Append("}");
    }

    private void 딟([In] BuildManifestVoicePackData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"id\":");
      딧.딾.딟(obj1, obj0.Id);
      obj1.Append(",\"bundle\":");
      딧.딾.딟(obj1, obj0.Package);
      obj1.Append(",\"prefab\":");
      딧.딾.딟(obj1, obj0.AssetPath);
      obj1.Append("}");
    }

    private void 딟([In] BuildManifestOutfitData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"id\":");
      딧.딾.딟(obj1, obj0.Id);
      obj1.Append(",\"bundle\":");
      딧.딾.딟(obj1, obj0.Package);
      obj1.Append(",\"ownerid\":");
      딧.딾.딟(obj1, obj0.OwnerId);
      obj1.Append(",\"prefab\":");
      딧.딾.딟(obj1, obj0.AssetPath);
      obj1.Append(",\"productid\":");
      딧.딾.딟(obj1, obj0.ProductId);
      obj1.Append(",\"showifowned\":");
      딧.딾.딟(obj1, obj0.OnlyShowIfOwned);
      obj1.Append(",\"levelreq\":");
      this.딟(obj1, obj0.LevelRequired);
      obj1.Append("}");
    }

    private void 딟([In] BuildManifestLevelData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"id\":");
      딧.딾.딟(obj1, obj0.Id);
      obj1.Append(",\"bundle\":");
      딧.딾.딟(obj1, obj0.GameplayPackage);
      obj1.Append(",\"gameplay\":");
      딧.딾.딟(obj1, obj0.GameplayPrefabPath);
      obj1.Append(",\"prettynamepackage\":");
      딧.딾.딟(obj1, obj0.PrettyNamePackage);
      obj1.Append(",\"prettynameprefab\":");
      딧.딾.딟(obj1, obj0.PrettyNamePrefabPath);
      obj1.Append(",\"ingamepackage\":");
      딧.딾.딟(obj1, obj0.InGamePackage);
      obj1.Append(",\"lighting\":");
      딧.딾.딟(obj1, obj0.LightingPrefabPath);
      obj1.Append(",\"audio\":");
      딧.딾.딟(obj1, obj0.AudioPrefabPath);
      obj1.Append(",\"geometry\":");
      딧.딾.딟(obj1, obj0.GeometryPrefabPath);
      obj1.Append(",\"vfx\":");
      딧.딾.딟(obj1, obj0.VFXPrefabPath);
      obj1.Append(",\"oob\":");
      딧.딾.딟(obj1, obj0.OOBPrefabPath);
      obj1.Append(",\"clip\":");
      딧.딾.딟(obj1, obj0.ClipPrefabPath);
      obj1.Append(",\"covermap\":");
      딧.딾.딟(obj1, obj0.CoverMapPrefabPath);
      obj1.Append(",\"vismap\":");
      딧.딾.딟(obj1, obj0.VisMapPrefabPath);
      obj1.Append(",\"lightmaps\":");
      this.딟(obj1, obj0.Lightmaps);
      obj1.Append(",\"iconpackage\":");
      딧.딾.딟(obj1, obj0.IconPackage);
      obj1.Append(",\"mapselecticon\":");
      딧.딾.딟(obj1, obj0.IconPrefabPath);
      obj1.Append(",\"sharedaudio\":");
      딧.딾.딟(obj1, obj0.SharedAudioPrefabId);
      obj1.Append(",\"productid\":");
      딧.딾.딟(obj1, obj0.ProductId);
      obj1.Append(",\"atlaspackid\":");
      딧.딾.딟(obj1, obj0.AtlasPackId);
      obj1.Append(",\"singleplayeronly\":");
      딧.딾.딟(obj1, obj0.SinglePlayerOnly);
      obj1.Append("}");
    }

    private void 딟([In] BuildManifestChallengePackRequiredLevel obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"level_id\":");
      딧.딾.딟(obj1, obj0.LevelId);
      obj1.Append("}");
    }

    private void 딟([In] BuildManifestChallengePackChallenge obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"challenge_id\":");
      딧.딾.딟(obj1, obj0.ChallengeId);
      obj1.Append("}");
    }

    private void 딟([In] BuildManifestChallengePackData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"id\":");
      딧.딾.딟(obj1, obj0.Id);
      obj1.Append(",\"bundle\":");
      딧.딾.딟(obj1, obj0.Package);
      obj1.Append(",\"prefab\":");
      딧.딾.딟(obj1, obj0.AssetPath);
      obj1.Append(",\"location_id\":");
      딧.딾.딟(obj1, obj0.LocationId);
      obj1.Append(",\"level_display_id\":");
      딧.딾.딟(obj1, obj0.LevelDisplayId);
      obj1.Append(",\"productid\":");
      딧.딾.딟(obj1, obj0.ProductId);
      obj1.Append(",\"challenges\":");
      this.딟(obj1, obj0.Challenges);
      obj1.Append("}");
    }

    private void 딟([In] BuildManifestChallengeData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"id\":");
      딧.딾.딟(obj1, obj0.Id);
      obj1.Append(",\"bundle\":");
      딧.딾.딟(obj1, obj0.Package);
      obj1.Append(",\"prefab\":");
      딧.딾.딟(obj1, obj0.AssetPath);
      obj1.Append(",\"productid\":");
      딧.딾.딟(obj1, obj0.ProductId);
      obj1.Append("}");
    }

    private void 딟([In] BuildManifestMapPackData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"id\":");
      딧.딾.딟(obj1, obj0.Id);
      obj1.Append(",\"bundle\":");
      딧.딾.딟(obj1, obj0.Package);
      obj1.Append(",\"prefab\":");
      딧.딾.딟(obj1, obj0.AssetPath);
      obj1.Append(",\"title\":");
      딧.딾.딟(obj1, obj0.TitleAssetPath);
      obj1.Append(",\"productid\":");
      딧.딾.딟(obj1, obj0.ProductId);
      obj1.Append(",\"levels\":");
      this.딟(obj1, obj0.Levels);
      obj1.Append("}");
    }

    private void 딟([In] BuildManifestMissionRewardEntry obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"voucherid\":");
      딧.딾.딟(obj1, obj0.VoucherId);
      obj1.Append(",\"coins\":");
      this.딟(obj1, obj0.Coins);
      obj1.Append("}");
    }

    private void 딟([In] BuildManifestMissionRewardsData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"missionid\":");
      딧.딾.딟(obj1, obj0.MissionId);
      obj1.Append(",\"rewards\":");
      this.딟(obj1, obj0.Rewards);
      obj1.Append("}");
    }

    private void 딟([In] BuildManifestAtlasPackData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"id\":");
      딧.딾.딟(obj1, obj0.Id);
      obj1.Append(",\"bundle\":");
      딧.딾.딟(obj1, obj0.Package);
      obj1.Append(",\"prefab\":");
      딧.딾.딟(obj1, obj0.AssetPath);
      obj1.Append("}");
    }

    private void 딟([In] TacticsBuildManifestDataJson obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"url_appstore\":");
      딧.딾.딟(obj1, obj0.AppStoreURL);
      obj1.Append(",\"url_facebook_link\":");
      딧.딾.딟(obj1, obj0.FacebookPostUrl);
      obj1.Append(",\"url_facebook_link_nacl\":");
      딧.딾.딟(obj1, obj0.FacebookPostUrlNaCl);
      obj1.Append(",\"max_concurrent_games\":");
      this.딟(obj1, obj0.MaxConcurrentGames);
      obj1.Append(",\"Levels\":");
      this.딟(obj1, obj0.Levels);
      obj1.Append(",\"Outfits\":");
      this.딟(obj1, obj0.Outfits);
      obj1.Append(",\"VoicePacks\":");
      this.딟(obj1, obj0.VoicePacks);
      obj1.Append(",\"Weapons\":");
      this.딟(obj1, obj0.Weapons);
      obj1.Append(",\"GameData\":");
      this.딟(obj1, obj0.GameData);
      obj1.Append(",\"Characters\":");
      this.딟(obj1, obj0.Characters);
      obj1.Append(",\"Avatars\":");
      this.딟(obj1, obj0.Avatars);
      obj1.Append(",\"Prefabs\":");
      this.딟(obj1, obj0.Prefabs);
      obj1.Append(",\"Challenges\":");
      this.딟(obj1, obj0.Challenges);
      obj1.Append(",\"MapPacks\":");
      this.딟(obj1, obj0.MapPacks);
      obj1.Append(",\"MissionRewards\":");
      this.딟(obj1, obj0.MissionRewards);
      obj1.Append(",\"ChallengePacks\":");
      this.딟(obj1, obj0.ChallengePacks);
      obj1.Append(",\"AtlasPacks\":");
      this.딟(obj1, obj0.AtlasPacks);
      obj1.Append("}");
    }

    private void 딟([In] BuildTimestampData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"build_number\":");
      딧.딾.딟(obj1, obj0.BuildNumber);
      obj1.Append(",\"time\":");
      딧.딾.딟(obj1, obj0.Time);
      obj1.Append(",\"environment\":");
      딧.딾.딟(obj1, obj0.Environment);
      obj1.Append(",\"platform\":");
      딧.딾.딟(obj1, obj0.Platform);
      obj1.Append("}");
    }

    private void 딟([In] SinglePlayerMissionScore obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"Id\":");
      this.딟(obj1, obj0.MissionIdHash);
      obj1.Append(",\"S\":");
      this.딟(obj1, obj0.BestScore);
      obj1.Append(",\"Level\":");
      this.딟(obj1, obj0.BestLevel);
      obj1.Append("}");
    }

    private void 딟([In] ClientProfileData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"Characters\":");
      this.딟(obj1, obj0.Characters);
      obj1.Append(",\"PlayerXP\":");
      this.딟(obj1, obj0.PlayerXP);
      obj1.Append(",\"PlayerMPScore\":");
      this.딟(obj1, obj0.PlayerMPScore);
      obj1.Append(",\"LastModified\":");
      this.딟(obj1, obj0.LastModified);
      obj1.Append(",\"UserId\":");
      딧.딾.딟(obj1, obj0.UserId);
      obj1.Append(",\"Avatar2\":");
      딧.딾.딟(obj1, obj0.Avatar2);
      obj1.Append(",\"Avatar\":");
      딧.딾.딟(obj1, obj0.Avatar);
      obj1.Append(",\"CommanderId\":");
      딧.딾.딟(obj1, obj0.ActiveCommanderId);
      obj1.Append(",\"ToolTips\":");
      this.딟(obj1, obj0.ToolTipsWatched);
      obj1.Append(",\"Achievements\":");
      this.딟(obj1, obj0.UnlockedAchievements);
      obj1.Append(",\"Cookies\":");
      this.딟(obj1, obj0.Cookies);
      obj1.Append(",\"Inventory\":");
      this.딟(obj1, obj0.Inventory);
      obj1.Append(",\"Missions\":");
      this.딟(obj1, obj0.MissionScores);
      obj1.Append(",\"Vouchers\":");
      this.딟(obj1, obj0.PendingVouchers);
      obj1.Append("}");
    }

    private void 딟([In] NewsDataText obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"english\":");
      딧.딾.딟(obj1, obj0.English);
      obj1.Append(",\"french\":");
      딧.딾.딟(obj1, obj0.French);
      obj1.Append(",\"german\":");
      딧.딾.딟(obj1, obj0.German);
      obj1.Append(",\"spanish\":");
      딧.딾.딟(obj1, obj0.Spanish);
      obj1.Append(",\"italian\":");
      딧.딾.딟(obj1, obj0.Italian);
      obj1.Append(",\"portuguese\":");
      딧.딾.딟(obj1, obj0.Portuguese);
      obj1.Append(",\"russian\":");
      딧.딾.딟(obj1, obj0.Russian);
      obj1.Append("}");
    }

    private void 딟([In] NewsDataEntry obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"type\":");
      딧.딾.딟(obj1, obj0.Type);
      obj1.Append(",\"date\":");
      딧.딾.딟(obj1, obj0.Date);
      obj1.Append(",\"text\":");
      this.딟(obj1, obj0.Text);
      obj1.Append("}");
    }

    private void 딟([In] NewsDataJson obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"items\":");
      this.딟(obj1, obj0.Items);
      obj1.Append("}");
    }

    private void 딟([In] SceneDataJson obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"LanguageSelection\":");
      딧.딾.딟(obj1, obj0.LanguageSelection);
      obj1.Append(",\"Main\":");
      딧.딾.딟(obj1, obj0.MainMenu);
      obj1.Append(",\"Loading\":");
      딧.딾.딟(obj1, obj0.LoadingScreen);
      obj1.Append(",\"Tally\":");
      딧.딾.딟(obj1, obj0.TallyScreen);
      obj1.Append(",\"Tutorial\":");
      딧.딾.딟(obj1, obj0.TutorialScreen);
      obj1.Append(",\"LanguageSelectionSceneName\":");
      딧.딾.딟(obj1, obj0.딟());
      obj1.Append(",\"MainMenuSceneName\":");
      딧.딾.딟(obj1, obj0.땄());
      obj1.Append(",\"LoadingScreenSceneName\":");
      딧.딾.딟(obj1, obj0.딧());
      obj1.Append(",\"TallyScreenSceneName\":");
      딧.딾.딟(obj1, obj0.딢());
      obj1.Append(",\"TutorialScreenSceneName\":");
      딧.딾.딟(obj1, obj0.땃());
      obj1.Append(",\"Scenes\":");
      this.딟(obj1, obj0.딶());
      obj1.Append("}");
    }

    private void 딟([In] CloudProfileJsonData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"access\":");
      딧.딾.딟(obj1, obj0.AccessToken);
      obj1.Append(",\"refresh\":");
      딧.딾.딟(obj1, obj0.RefreshToken);
      obj1.Append(",\"name\":");
      딧.딾.딟(obj1, obj0.UserName);
      obj1.Append("}");
    }

    private void 딟([In] FeaturedItemsDataJson obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"items\":");
      this.딟(obj1, obj0.Items);
      obj1.Append("}");
    }

    private void 딟([In] EngineVersionData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"version\":");
      this.딟(obj1, obj0.Version);
      obj1.Append("}");
    }

    private void 딟([In] FacebookLoginInfo obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"access_token\":");
      딧.딾.딟(obj1, obj0.딟);
      obj1.Append(",\"facebook_id\":");
      딧.딾.딟(obj1, obj0.땄);
      obj1.Append("}");
    }

    private void 딟([In] FireTeamCatalogEntryData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"icon_url\":");
      this.딟(obj1, obj0.IconUrl);
      obj1.Append(",\"preview_url\":");
      this.딟(obj1, obj0.PreviewUrl);
      obj1.Append(",\"Version\":");
      this.딟(obj1, obj0.Version);
      obj1.Append(",\"Hide\":");
      딧.딾.딟(obj1, obj0.Hide);
      obj1.Append(",\"Sort\":");
      this.딟(obj1, obj0.Sort);
      obj1.Append(",\"Health\":");
      딧.딾.딟(obj1, obj0.Health);
      obj1.Append(",\"Action Points\":");
      딧.딾.딟(obj1, obj0.ActionPoints);
      obj1.Append(",\"Squad Points\":");
      딧.딾.딟(obj1, obj0.SquadPoints);
      obj1.Append(",\"Range\":");
      딧.딾.딟(obj1, obj0.Range);
      obj1.Append(",\"Special\":");
      딧.딾.딟(obj1, obj0.Special);
      obj1.Append(",\"Damage\":");
      딧.딾.딟(obj1, obj0.Damage);
      obj1.Append(",\"AP Cost\":");
      딧.딾.딟(obj1, obj0.APCost);
      obj1.Append(",\"Level Req\":");
      this.딟(obj1, obj0.LevelRequired);
      obj1.Append(",\"Class\":");
      딧.딾.딟(obj1, obj0.Class);
      obj1.Append(",\"IsNew\":");
      딧.딾.딟(obj1, obj0.IsNew);
      obj1.Append("}");
    }

    private void 딟([In] FireTeamCatalogEntryDescriptionAbilityData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"Name\":");
      딧.딾.딟(obj1, obj0.Name);
      obj1.Append(",\"Description\":");
      딧.딾.딟(obj1, obj0.Description);
      obj1.Append("}");
    }

    private void 딟([In] FireTeamCatalogEntryAdvertData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"Title\":");
      딧.딾.딟(obj1, obj0.Title);
      obj1.Append(",\"SmallTitle\":");
      딧.딾.딟(obj1, obj0.SmallTitle);
      obj1.Append(",\"Description\":");
      딧.딾.딟(obj1, obj0.Description);
      obj1.Append(",\"ImageURL\":");
      this.딟(obj1, obj0.ImageURL);
      obj1.Append("}");
    }

    private void 딟([In] FireTeamCatalogEntryDescriptionData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"Abilities\":");
      this.딟(obj1, obj0.Abilities);
      obj1.Append(",\"Weapon\":");
      딧.딾.딟(obj1, obj0.Weapon);
      obj1.Append(",\"Weapon Type\":");
      딧.딾.딟(obj1, obj0.WeaponType);
      obj1.Append(",\"Name\":");
      딧.딾.딟(obj1, obj0.Name);
      obj1.Append(",\"Classes\":");
      this.딟(obj1, obj0.Classes);
      obj1.Append(",\"Character\":");
      딧.딾.딟(obj1, obj0.Character);
      obj1.Append(",\"Description\":");
      딧.딾.딟(obj1, obj0.Description);
      obj1.Append(",\"Free\":");
      딧.딾.딟(obj1, obj0.Free);
      obj1.Append(",\"Advert\":");
      this.딟(obj1, obj0.Advert);
      obj1.Append(",\"ChalType\":");
      딧.딾.딟(obj1, obj0.ChallengeType);
      obj1.Append("}");
    }

    private void 딟([In] FireTeamCatalogEntryURL obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"png\":");
      딧.딾.딟(obj1, obj0.PNG);
      obj1.Append(",\"pvr\":");
      딧.딾.딟(obj1, obj0.PVR);
      obj1.Append("}");
    }

    private void 딟([In] FireTeamUserProfileChallengeJsonData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"Id\":");
      this.딟(obj1, obj0.PackId);
      obj1.Append(",\"Pos\":");
      this.딟(obj1, obj0.Position);
      obj1.Append(",\"S\":");
      this.딟(obj1, obj0.Score);
      obj1.Append(",\"Owned\":");
      딧.딾.딟(obj1, obj0.IsOwned);
      obj1.Append("}");
    }

    private void 딟([In] FireTeamUserProfileJsonData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"AvatarId2\":");
      딧.딾.딟(obj1, obj0.AvatarId2);
      obj1.Append(",\"AvatarId\":");
      딧.딾.딟(obj1, obj0.AvatarId);
      obj1.Append(",\"PlayerXP\":");
      this.딟(obj1, obj0.PlayerXP);
      obj1.Append(",\"Challenges\":");
      this.딟(obj1, obj0.Challenges);
      obj1.Append("}");
    }

    private void 딟([In] FireTeamTurnBasedSessionAttributes obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"version\":");
      this.딟(obj1, obj0.Version);
      obj1.Append(",\"level_id\":");
      this.딟(obj1, obj0.LevelId);
      obj1.Append(",\"sublevel_id\":");
      this.딟(obj1, obj0.SubLevelId);
      obj1.Append(",\"army_size\":");
      this.딟(obj1, obj0.ArmySize);
      obj1.Append(",\"invitee_id\":");
      딧.딾.딟(obj1, obj0.InviteeId);
      obj1.Append(",\"tier\":");
      this.딟(obj1, obj0.MatchMakingTier);
      obj1.Append(",\"name\":");
      딧.딾.딟(obj1, obj0.Name);
      obj1.Append("}");
    }

    private void 딟([In] FireTeamStoreImportEntryData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"id\":");
      딧.딾.딟(obj1, obj0.IdString);
      obj1.Append(",\"_product_id\":");
      딧.딾.딟(obj1, obj0.ProductId);
      obj1.Append("}");
    }

    private void 딟([In] FireTeamStoreImportData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"items\":");
      this.딟(obj1, obj0.Items);
      obj1.Append("}");
    }

    private void 딟([In] UnitBuff obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"N\":");
      this.딟(obj1, obj0.Turns);
      obj1.Append(",\"T\":");
      this.딟(obj1, obj0.Type);
      obj1.Append("}");
    }

    private void 딟([In] UnitTurnDataJson obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"X\":");
      this.딟(obj1, obj0.TileX);
      obj1.Append(",\"Y\":");
      this.딟(obj1, obj0.TileY);
      obj1.Append(",\"AP\":");
      this.딟(obj1, obj0.ActionPoints);
      obj1.Append(",\"HP\":");
      this.딟(obj1, obj0.Health);
      obj1.Append(",\"T\":");
      this.딟(obj1, obj0.TeamIndex);
      obj1.Append(",\"D\":");
      this.딟(obj1, obj0.Direction);
      obj1.Append(",\"B\":");
      this.딟(obj1, obj0.Buffs);
      obj1.Append("}");
    }

    private void 딟([In] TacticsActionData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"Idx\":");
      this.딟(obj1, obj0.Index);
      if (obj0.TileIndexX != 0)
      {
        obj1.Append(",\"X\":");
        this.딟(obj1, obj0.TileIndexX);
      }
      if (obj0.TileIndexY != 0)
      {
        obj1.Append(",\"Y\":");
        this.딟(obj1, obj0.TileIndexY);
      }
      if (obj0.Action != 딢.땀.딟)
      {
        obj1.Append(",\"Act\":");
        this.딟(obj1, obj0.Action);
      }
      if (obj0.Direction != 딢.딯.딟)
      {
        obj1.Append(",\"D\":");
        this.딟(obj1, obj0.Direction);
      }
      if (obj0.Ability != 딢.딴.딟)
      {
        obj1.Append(",\"Abi\":");
        this.딟(obj1, obj0.Ability);
      }
      if (obj0.TargetIndex != 0)
      {
        obj1.Append(",\"Tgt\":");
        this.딟(obj1, obj0.TargetIndex);
      }
      if (obj0.AttackerIndex != 0)
      {
        obj1.Append(",\"Atk\":");
        this.딟(obj1, obj0.AttackerIndex);
      }
      obj1.Append("}");
    }

    private void 딟([In] TacticsInitialTurnState obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"Initial\":");
      딧.딾.딟(obj1, obj0.InitialData);
      obj1.Append(",\"Turn\":");
      딧.딾.딟(obj1, obj0.TurnData);
      obj1.Append("}");
    }

    private void 딟([In] TacticsSessionStateData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"DataVersion\":");
      this.딟(obj1, obj0.GameDataVersion);
      obj1.Append(",\"LevelName\":");
      딧.딾.딟(obj1, obj0.LevelName);
      obj1.Append(",\"Scenario\":");
      this.딟(obj1, obj0.ScenarioIndex);
      obj1.Append(",\"Id\":");
      딧.딾.딟(obj1, obj0.Id);
      obj1.Append(",\"SP\":");
      this.딟(obj1, obj0.SquadPointsTier);
      obj1.Append(",\"Players\":");
      this.딟(obj1, obj0.Players);
      obj1.Append(",\"LootDropTurn\":");
      this.딟(obj1, obj0.LootDropTurn);
      obj1.Append("}");
    }

    private void 딟([In] TacticsGameStateTurnData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"ActiveTeam\":");
      this.딟(obj1, obj0.ActiveTeam);
      obj1.Append(",\"StartSeed\":");
      this.딟(obj1, obj0.StartSeed);
      obj1.Append(",\"Seed\":");
      this.딟(obj1, obj0.Seed);
      obj1.Append(",\"RatingValue\":");
      this.딟(obj1, obj0.RatingValue);
      obj1.Append(",\"Units\":");
      this.딟(obj1, obj0.Units);
      obj1.Append(",\"Actions\":");
      this.딟(obj1, obj0.Actions);
      obj1.Append(",\"Chat\":");
      딧.딾.딟(obj1, obj0.chatLine);
      obj1.Append("}");
    }

    private void 딟([In] UnitCharacterData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"Wpn\":");
      딧.딾.딟(obj1, obj0.WeaponId);
      obj1.Append(",\"Oft\":");
      딧.딾.딟(obj1, obj0.OutfitId);
      obj1.Append(",\"Class\":");
      딧.딾.딟(obj1, obj0.CharacterId);
      obj1.Append(",\"XP\":");
      this.딟(obj1, obj0.XP);
      obj1.Append(",\"Name\":");
      딧.딾.딟(obj1, obj0.Name);
      obj1.Append(",\"Id\":");
      딧.딾.딟(obj1, obj0.UniqueId);
      obj1.Append(",\"Abi\":");
      this.딟(obj1, obj0.SelectedAbilities);
      obj1.Append("}");
    }

    private void 딟([In] TacticsGameStateData obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"Session\":");
      this.딟(obj1, obj0.Session);
      obj1.Append(",\"Turns\":");
      this.딟(obj1, obj0.Turns);
      obj1.Append("}");
    }

    private void 딟([In] TacticsTurnStateUnits obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      obj1.Append("\"Units\":");
      this.딟(obj1, obj0.Units);
      obj1.Append("}");
    }
  }
}
