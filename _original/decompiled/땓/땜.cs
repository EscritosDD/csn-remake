// Decompiled with JetBrains decompiler
// Type: 땓.땜
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

namespace 땓
{
  public class 땜 : 딧.딗
  {
    private Func<object, MixPanelEventData> 딟;
    private Func<object, Dictionary<string, string>> 딟;
    private Func<object, GAEventParam> 딟;
    private Func<object, GAEvent> 딟;
    private Func<object, double> 딟;
    private Func<object, BuildManifestDataWrapper> 딟;
    private Func<object, BuildManifestDataJson> 딟;
    private Func<object, Dictionary<string, object>> 딟;
    private Func<object, BuildManifestBundleData[]> 딟;
    private Func<object, bool> 딟;
    private Func<object, int> 딟;
    private Func<object, BuildManifestBundleData> 딟;
    private Func<object, string[]> 딟;
    private Func<object, UserData> 딟;
    private Func<object, FacebookFriendData> 딟;
    private Func<object, ErrorData> 딟;
    private Func<object, 딟.땑> 딟;
    private Func<object, AccessTokenData> 딟;
    private Func<object, XboxAuthToken> 딟;
    private Func<object, XboxXuidLink> 딟;
    private Func<object, long> 딟;
    private Func<object, InventoryData> 딟;
    private Func<object, Dictionary<string, int>> 딟;
    private Func<object, OfferRealPriceData> 딟;
    private Func<object, OfferData> 딟;
    private Func<object, 딟.딘> 딟;
    private Func<object, TurnOp_AddToInventory> 딟;
    private Func<object, TurnOp_Consume> 딟;
    private Func<object, TurnBasedSessionTurnData> 딟;
    private Func<object, object[][]> 딟;
    private Func<object, TurnBasedSessionData> 딟;
    private Func<object, Dictionary<string, 딟.땾>> 딟;
    private Func<object, 딟.딺> 딟;
    private Func<object, SessionUserData[]> 딟;
    private Func<object, SessionUserData> 딟;
    private Func<object, 딟.떑> 딟;
    private Func<object, SessionListData> 딟;
    private Func<object, TurnBasedSessionData[]> 딟;
    private Func<object, SessionTurnsListData> 딟;
    private Func<object, TurnBasedSessionTurnData[]> 딟;
    private Func<object, SessionJoinData> 딟;
    private Func<object, 딟.땎> 딟;
    private Func<object, WriteSessionTurnData> 딟;
    private Func<object, TransactionData> 딟;
    private Func<object, PurchaseResult> 딟;
    private Func<object, BlindBoxTestResult> 딟;
    private Func<object, Dictionary<string, int>[]> 딟;
    private Func<object, NotificationData> 딟;
    private Func<object, 딟.땅> 딟;
    private Func<object, object[]> 딟;
    private Func<object, NotificationsData> 딟;
    private Func<object, NotificationData[]> 딟;
    private Func<object, SessionEventNotificationParams> 딟;
    private Func<object, SessionInviteNotificationParams> 딟;
    private Func<object, SessionUserEventNotificationParams> 딟;
    private Func<object, RelationFriendNotificationParams> 딟;
    private Func<object, SessionActionSubmitTurnNotificationParams> 딟;
    private Func<object, FileStoreData> 딟;
    private Func<object, CatalogEntry> 딟;
    private Func<object, 딟.딪> 딟;
    private Func<object, 딟.떕> 딟;
    private Func<object, OfferData[]> 딟;
    private Func<object, CatalogPagination> 딟;
    private Func<object, CatalogEntry[]> 딟;
    private Func<object, MarkNotificationReadUpdateData> 딟;
    private Func<object, MarkNotificationReadData> 딟;
    private Func<object, MinimalFacebookInfo> 딟;
    private Func<object, FacebookFriendsData> 딟;
    private Func<object, FacebookFriendData[]> 딟;
    private Func<object, FriendsData> 딟;
    private Func<object, UserData[]> 딟;
    private Func<object, OffersData> 딟;
    private Func<object, ApplicationStatus> 딟;
    private Func<object, FileInfo> 딟;
    private Func<object, FileList> 딟;
    private Func<object, FileInfo[]> 딟;
    private Func<object, SessionCreationWriteData> 딟;
    private Func<object, object> 딟;
    private Func<object, PublicProfileWriteData> 딟;
    private Func<object, SplashDamage.Mobile.Fireteam.NaClPushChannelData> 딟;
    private Func<object, EchoSessionJson> 딟;
    private Func<object, EchoSessionListJson> 딟;
    private Func<object, EchoSessionJson[]> 딟;
    private Func<object, EchoEventListJson> 딟;
    private Func<object, EchoEventJson[]> 딟;
    private Func<object, EchoEventJson> 딟;
    private Func<object, ScoreTableEntryData> 딟;
    private Func<object, ScoreTableData> 딟;
    private Func<object, Dictionary<string, Dictionary<string, ScoreTableEntryData>>> 딟;
    private Func<object, ScoreBoardOps> 딟;
    private Func<object, Dictionary<string, List<object>>> 딟;
    private Func<object, JWTData> 딟;
    private Func<object, ExternalCallResponse> 딟;
    private Func<object, JavaScriptCallPayload> 딟;
    private Func<object, JSResponse> 딟;
    private Func<object, JSRequest> 딟;
    private Func<object, List<JSRequestHeader>> 딟;
    private Func<object, JSRequestHeader> 딟;
    private Func<object, SplashDamage.Mobile.Notifications.NaClPushChannelData> 딟;
    private Func<object, BuildManifestPrefabData> 딟;
    private Func<object, BuildManifestAvatarData> 딟;
    private Func<object, BuildManifestCharacterData> 딟;
    private Func<object, BuildManifestGameDataData> 딟;
    private Func<object, BuildManifestWeaponData> 딟;
    private Func<object, BuildManifestVoicePackData> 딟;
    private Func<object, BuildManifestOutfitData> 딟;
    private Func<object, BuildManifestLevelData> 딟;
    private Func<object, BuildManifestChallengePackRequiredLevel> 딟;
    private Func<object, BuildManifestChallengePackChallenge> 딟;
    private Func<object, BuildManifestChallengePackData> 딟;
    private Func<object, BuildManifestChallengePackChallenge[]> 딟;
    private Func<object, BuildManifestChallengeData> 딟;
    private Func<object, BuildManifestMapPackData> 딟;
    private Func<object, BuildManifestMissionRewardEntry> 딟;
    private Func<object, BuildManifestMissionRewardsData> 딟;
    private Func<object, BuildManifestMissionRewardEntry[]> 딟;
    private Func<object, BuildManifestAtlasPackData> 딟;
    private Func<object, TacticsBuildManifestDataJson> 딟;
    private Func<object, BuildManifestLevelData[]> 딟;
    private Func<object, BuildManifestOutfitData[]> 딟;
    private Func<object, BuildManifestVoicePackData[]> 딟;
    private Func<object, BuildManifestWeaponData[]> 딟;
    private Func<object, BuildManifestGameDataData[]> 딟;
    private Func<object, BuildManifestCharacterData[]> 딟;
    private Func<object, BuildManifestAvatarData[]> 딟;
    private Func<object, BuildManifestPrefabData[]> 딟;
    private Func<object, BuildManifestChallengeData[]> 딟;
    private Func<object, BuildManifestMapPackData[]> 딟;
    private Func<object, BuildManifestMissionRewardsData[]> 딟;
    private Func<object, BuildManifestChallengePackData[]> 딟;
    private Func<object, BuildManifestAtlasPackData[]> 딟;
    private Func<object, BuildTimestampData> 딟;
    private Func<object, SinglePlayerMissionScore> 딟;
    private Func<object, ClientProfileData> 딟;
    private Func<object, UnitCharacterData[]> 딟;
    private Func<object, 딢.딮[]> 딟;
    private Func<object, int[]> 딟;
    private Func<object, SinglePlayerMissionScore[]> 딟;
    private Func<object, NewsDataText> 딟;
    private Func<object, NewsDataEntry> 딟;
    private Func<object, NewsDataJson> 딟;
    private Func<object, NewsDataEntry[]> 딟;
    private Func<object, SceneDataJson> 딟;
    private Func<object, CloudProfileJsonData> 딟;
    private Func<object, FeaturedItemsDataJson> 딟;
    private Func<object, EngineVersionData> 딟;
    private Func<object, FacebookLoginInfo> 딟;
    private Func<object, FireTeamCatalogEntryData> 딟;
    private Func<object, FireTeamCatalogEntryURL> 딟;
    private Func<object, FireTeamCatalogEntryDescriptionAbilityData> 딟;
    private Func<object, FireTeamCatalogEntryAdvertData> 딟;
    private Func<object, FireTeamCatalogEntryDescriptionData> 딟;
    private Func<object, FireTeamCatalogEntryDescriptionAbilityData[]> 딟;
    private Func<object, FireTeamUserProfileChallengeJsonData> 딟;
    private Func<object, FireTeamUserProfileJsonData> 딟;
    private Func<object, FireTeamUserProfileChallengeJsonData[]> 딟;
    private Func<object, FireTeamTurnBasedSessionAttributes> 딟;
    private Func<object, FireTeamStoreImportEntryData> 딟;
    private Func<object, FireTeamStoreImportData> 딟;
    private Func<object, FireTeamStoreImportEntryData[]> 딟;
    private Func<object, UnitBuff> 딟;
    private Func<object, 딢.떍> 딟;
    private Func<object, UnitTurnDataJson> 딟;
    private Func<object, 딢.딯> 딟;
    private Func<object, UnitBuff[]> 딟;
    private Func<object, TacticsActionData> 딟;
    private Func<object, 딢.땀> 딟;
    private Func<object, 딢.딴> 딟;
    private Func<object, TacticsInitialTurnState> 딟;
    private Func<object, TacticsSessionStateData> 딟;
    private Func<object, TacticsGameStateTurnData> 딟;
    private Func<object, UnitTurnDataJson[]> 딟;
    private Func<object, TacticsActionData[]> 딟;
    private Func<object, UnitCharacterData> 딟;
    private Func<object, 딢.딴[]> 딟;
    private Func<object, TacticsGameStateData> 딟;
    private Func<object, TacticsTurnStateUnits> 딟;
    private Func<object, 딟.땾> 딟;
    private Func<object, Dictionary<string, ScoreTableEntryData>> 딟;
    private Func<object, List<object>> 딟;
    private Func<object, 딢.딮> 딟;

    public 땜()
    {
      this.딟 = (Func<object, MixPanelEventData>) (obj0 => this.딟<MixPanelEventData>(obj0, new Func<IDictionary<string, object>, MixPanelEventData>(this.딟)));
      this.딟 = (Func<object, Dictionary<string, string>>) (obj0 => this.땄<Dictionary<string, string>, string>(obj0, new Func<object, string>(((딧.딗) this).땲)));
      this.딟 = (Func<object, GAEventParam>) (obj0 => this.딟<GAEventParam>(obj0, new Func<IDictionary<string, object>, GAEventParam>(this.땄)));
      this.딟 = (Func<object, GAEvent>) (obj0 => this.딟<GAEvent>(obj0, new Func<IDictionary<string, object>, GAEvent>(this.딧)));
      this.딟 = (Func<object, double>) (obj0 => base.땺(obj0));
      this.딟 = (Func<object, BuildManifestDataWrapper>) (obj0 => this.딟<BuildManifestDataWrapper>(obj0, new Func<IDictionary<string, object>, BuildManifestDataWrapper>(this.딢)));
      this.딟 = (Func<object, BuildManifestDataJson>) (obj0 => this.딟<BuildManifestDataJson>(obj0, new Func<IDictionary<string, object>, BuildManifestDataJson>(this.땃)));
      this.딟 = (Func<object, Dictionary<string, object>>) (obj0 => this.땄<Dictionary<string, object>, object>(obj0, this.딟));
      this.딟 = (Func<object, BuildManifestBundleData[]>) (obj0 => this.딟<BuildManifestBundleData>(obj0, this.딟));
      this.딟 = (Func<object, bool>) (obj0 => base.땃(obj0));
      this.딟 = (Func<object, int>) (obj0 => base.땽(obj0));
      this.딟 = (Func<object, BuildManifestBundleData>) (obj0 => this.딟<BuildManifestBundleData>(obj0, new Func<IDictionary<string, object>, BuildManifestBundleData>(this.딶)));
      this.딟 = (Func<object, string[]>) (obj0 => this.딟<string>(obj0, new Func<object, string>(((딧.딗) this).땲)));
      this.딟 = (Func<object, UserData>) (obj0 => this.딟<UserData>(obj0, new Func<IDictionary<string, object>, UserData>(this.땓)));
      this.딟 = (Func<object, FacebookFriendData>) (obj0 => this.딟<FacebookFriendData>(obj0, new Func<IDictionary<string, object>, FacebookFriendData>(this.땺)));
      this.딟 = (Func<object, ErrorData>) (obj0 => this.딟<ErrorData>(obj0, new Func<IDictionary<string, object>, ErrorData>(this.땥)));
      this.딟 = (Func<object, 딟.땑>) (obj0 => this.딢<딟.땑>(obj0));
      this.딟 = (Func<object, AccessTokenData>) (obj0 => this.딟<AccessTokenData>(obj0, new Func<IDictionary<string, object>, AccessTokenData>(this.딝)));
      this.딟 = (Func<object, XboxAuthToken>) (obj0 => this.딟<XboxAuthToken>(obj0, new Func<IDictionary<string, object>, XboxAuthToken>(this.떎)));
      this.딟 = (Func<object, XboxXuidLink>) (obj0 => this.딟<XboxXuidLink>(obj0, new Func<IDictionary<string, object>, XboxXuidLink>(this.떂)));
      this.딟 = (Func<object, long>) (obj0 => base.땋(obj0));
      this.딟 = (Func<object, InventoryData>) (obj0 => this.딟<InventoryData>(obj0, new Func<IDictionary<string, object>, InventoryData>(this.땭)));
      this.딟 = (Func<object, Dictionary<string, int>>) (obj0 => this.땄<Dictionary<string, int>, int>(obj0, this.딟));
      this.딟 = (Func<object, OfferRealPriceData>) (obj0 => this.딟<OfferRealPriceData>(obj0, new Func<IDictionary<string, object>, OfferRealPriceData>(this.딦)));
      this.딟 = (Func<object, OfferData>) (obj0 => this.딟<OfferData>(obj0, new Func<IDictionary<string, object>, OfferData>(this.땤)));
      this.딟 = (Func<object, 딟.딘>) (obj0 => this.딢<딟.딘>(obj0));
      this.딟 = (Func<object, TurnOp_AddToInventory>) (obj0 => this.딟<TurnOp_AddToInventory>(obj0, new Func<IDictionary<string, object>, TurnOp_AddToInventory>(this.땽)));
      this.딟 = (Func<object, TurnOp_Consume>) (obj0 => this.딟<TurnOp_Consume>(obj0, new Func<IDictionary<string, object>, TurnOp_Consume>(this.땋)));
      this.딟 = (Func<object, TurnBasedSessionTurnData>) (obj0 => this.딟<TurnBasedSessionTurnData>(obj0, new Func<IDictionary<string, object>, TurnBasedSessionTurnData>(this.땲)));
      this.딟 = (Func<object, object[][]>) (obj0 => this.딟<object[]>(obj0, this.딟));
      this.딟 = (Func<object, TurnBasedSessionData>) (obj0 => this.딟<TurnBasedSessionData>(obj0, new Func<IDictionary<string, object>, TurnBasedSessionData>(this.떏)));
      this.딟 = (Func<object, Dictionary<string, 딟.땾>>) (obj0 => this.땄<Dictionary<string, 딟.땾>, 딟.땾>(obj0, this.딟));
      this.딟 = (Func<object, 딟.딺>) (obj0 => this.딢<딟.딺>(obj0));
      this.딟 = (Func<object, SessionUserData[]>) (obj0 => this.딟<SessionUserData>(obj0, this.딟));
      this.딟 = (Func<object, SessionUserData>) (obj0 => this.딟<SessionUserData>(obj0, new Func<IDictionary<string, object>, SessionUserData>(this.땼)));
      this.딟 = (Func<object, 딟.떑>) (obj0 => this.딢<딟.떑>(obj0));
      this.딟 = (Func<object, SessionListData>) (obj0 => this.딟<SessionListData>(obj0, new Func<IDictionary<string, object>, SessionListData>(this.땢)));
      this.딟 = (Func<object, TurnBasedSessionData[]>) (obj0 => this.딟<TurnBasedSessionData>(obj0, this.딟));
      this.딟 = (Func<object, SessionTurnsListData>) (obj0 => this.딟<SessionTurnsListData>(obj0, new Func<IDictionary<string, object>, SessionTurnsListData>(this.딷)));
      this.딟 = (Func<object, TurnBasedSessionTurnData[]>) (obj0 => this.딟<TurnBasedSessionTurnData>(obj0, this.딟));
      this.딟 = (Func<object, SessionJoinData>) (obj0 => this.딟<SessionJoinData>(obj0, new Func<IDictionary<string, object>, SessionJoinData>(this.떁)));
      this.딟 = (Func<object, 딟.땎>) (obj0 => this.딢<딟.땎>(obj0));
      this.딟 = (Func<object, WriteSessionTurnData>) (obj0 => this.딟<WriteSessionTurnData>(obj0, new Func<IDictionary<string, object>, WriteSessionTurnData>(this.땟)));
      this.딟 = (Func<object, TransactionData>) (obj0 => this.딟<TransactionData>(obj0, new Func<IDictionary<string, object>, TransactionData>(this.땂)));
      this.딟 = (Func<object, PurchaseResult>) (obj0 => this.딟<PurchaseResult>(obj0, new Func<IDictionary<string, object>, PurchaseResult>(this.딱)));
      this.딟 = (Func<object, BlindBoxTestResult>) (obj0 => this.딟<BlindBoxTestResult>(obj0, new Func<IDictionary<string, object>, BlindBoxTestResult>(this.때)));
      this.딟 = (Func<object, Dictionary<string, int>[]>) (obj0 => this.딟<Dictionary<string, int>>(obj0, this.딟));
      this.딟 = (Func<object, NotificationData>) (obj0 => this.딟<NotificationData>(obj0, new Func<IDictionary<string, object>, NotificationData>(this.땩)));
      this.딟 = (Func<object, 딟.땅>) (obj0 => this.딢<딟.땅>(obj0));
      this.딟 = (Func<object, object[]>) (obj0 => this.딟<object>(obj0, this.딟));
      this.딟 = (Func<object, NotificationsData>) (obj0 => this.딟<NotificationsData>(obj0, new Func<IDictionary<string, object>, NotificationsData>(this.땠)));
      this.딟 = (Func<object, NotificationData[]>) (obj0 => this.딟<NotificationData>(obj0, this.딟));
      this.딟 = (Func<object, SessionEventNotificationParams>) (obj0 => this.딟<SessionEventNotificationParams>(obj0, new Func<IDictionary<string, object>, SessionEventNotificationParams>(this.땴)));
      this.딟 = (Func<object, SessionInviteNotificationParams>) (obj0 => this.딟<SessionInviteNotificationParams>(obj0, new Func<IDictionary<string, object>, SessionInviteNotificationParams>(this.딗)));
      this.딟 = (Func<object, SessionUserEventNotificationParams>) (obj0 => this.딟<SessionUserEventNotificationParams>(obj0, new Func<IDictionary<string, object>, SessionUserEventNotificationParams>(this.땳)));
      this.딟 = (Func<object, RelationFriendNotificationParams>) (obj0 => this.딟<RelationFriendNotificationParams>(obj0, new Func<IDictionary<string, object>, RelationFriendNotificationParams>(this.땻)));
      this.딟 = (Func<object, SessionActionSubmitTurnNotificationParams>) (obj0 => this.딟<SessionActionSubmitTurnNotificationParams>(obj0, new Func<IDictionary<string, object>, SessionActionSubmitTurnNotificationParams>(this.딥)));
      this.딟 = (Func<object, FileStoreData>) (obj0 => this.딟<FileStoreData>(obj0, new Func<IDictionary<string, object>, FileStoreData>(this.떓)));
      this.딟 = (Func<object, CatalogEntry>) (obj0 => this.딟<CatalogEntry>(obj0, new Func<IDictionary<string, object>, CatalogEntry>(this.딛)));
      this.딟 = (Func<object, 딟.딪>) (obj0 => this.딢<딟.딪>(obj0));
      this.딟 = (Func<object, 딟.떕>) (obj0 => this.딢<딟.떕>(obj0));
      this.딟 = (Func<object, OfferData[]>) (obj0 => this.딟<OfferData>(obj0, this.딟));
      this.딟 = (Func<object, CatalogPagination>) (obj0 => this.딟<CatalogPagination>(obj0, new Func<IDictionary<string, object>, CatalogPagination>(this.딣)));
      this.딟 = (Func<object, CatalogEntry[]>) (obj0 => this.딟<CatalogEntry>(obj0, this.딟));
      this.딟 = (Func<object, MarkNotificationReadUpdateData>) (obj0 => this.딟<MarkNotificationReadUpdateData>(obj0, new Func<IDictionary<string, object>, MarkNotificationReadUpdateData>(this.땔)));
      this.딟 = (Func<object, MarkNotificationReadData>) (obj0 => this.딟<MarkNotificationReadData>(obj0, new Func<IDictionary<string, object>, MarkNotificationReadData>(this.땁)));
      this.딟 = (Func<object, MinimalFacebookInfo>) (obj0 => this.딟<MinimalFacebookInfo>(obj0, new Func<IDictionary<string, object>, MinimalFacebookInfo>(this.땷)));
      this.딟 = (Func<object, FacebookFriendsData>) (obj0 => this.딟<FacebookFriendsData>(obj0, new Func<IDictionary<string, object>, FacebookFriendsData>(this.딸)));
      this.딟 = (Func<object, FacebookFriendData[]>) (obj0 => this.딟<FacebookFriendData>(obj0, this.딟));
      this.딟 = (Func<object, FriendsData>) (obj0 => this.딟<FriendsData>(obj0, new Func<IDictionary<string, object>, FriendsData>(this.땘)));
      this.딟 = (Func<object, UserData[]>) (obj0 => this.딟<UserData>(obj0, this.딟));
      this.딟 = (Func<object, OffersData>) (obj0 => this.딟<OffersData>(obj0, new Func<IDictionary<string, object>, OffersData>(this.떔)));
      this.딟 = (Func<object, ApplicationStatus>) (obj0 => this.딟<ApplicationStatus>(obj0, new Func<IDictionary<string, object>, ApplicationStatus>(this.딳)));
      this.딟 = (Func<object, FileInfo>) (obj0 => this.딟<FileInfo>(obj0, new Func<IDictionary<string, object>, FileInfo>(this.땝)));
      this.딟 = (Func<object, FileList>) (obj0 => this.딟<FileList>(obj0, new Func<IDictionary<string, object>, FileList>(this.땹)));
      this.딟 = (Func<object, FileInfo[]>) (obj0 => this.딟<FileInfo>(obj0, this.딟));
      this.딟 = (Func<object, SessionCreationWriteData>) (obj0 => this.딟<SessionCreationWriteData>(obj0, new Func<IDictionary<string, object>, SessionCreationWriteData>(this.떇)));
      this.딟 = (Func<object, object>) (obj0 => obj0);
      this.딟 = (Func<object, PublicProfileWriteData>) (obj0 => this.딟<PublicProfileWriteData>(obj0, new Func<IDictionary<string, object>, PublicProfileWriteData>(this.땉)));
      this.딟 = (Func<object, SplashDamage.Mobile.Fireteam.NaClPushChannelData>) (obj0 => this.딟<SplashDamage.Mobile.Fireteam.NaClPushChannelData>(obj0, new Func<IDictionary<string, object>, SplashDamage.Mobile.Fireteam.NaClPushChannelData>(this.땈)));
      this.딟 = (Func<object, EchoSessionJson>) (obj0 => this.딟<EchoSessionJson>(obj0, new Func<IDictionary<string, object>, EchoSessionJson>(this.땞)));
      this.딟 = (Func<object, EchoSessionListJson>) (obj0 => this.딟<EchoSessionListJson>(obj0, new Func<IDictionary<string, object>, EchoSessionListJson>(this.땜)));
      this.딟 = (Func<object, EchoSessionJson[]>) (obj0 => this.딟<EchoSessionJson>(obj0, this.딟));
      this.딟 = (Func<object, EchoEventListJson>) (obj0 => this.딟<EchoEventListJson>(obj0, new Func<IDictionary<string, object>, EchoEventListJson>(this.땪)));
      this.딟 = (Func<object, EchoEventJson[]>) (obj0 => this.딟<EchoEventJson>(obj0, this.딟));
      this.딟 = (Func<object, EchoEventJson>) (obj0 => this.딟<EchoEventJson>(obj0, new Func<IDictionary<string, object>, EchoEventJson>(this.땕)));
      this.딟 = (Func<object, ScoreTableEntryData>) (obj0 => this.딟<ScoreTableEntryData>(obj0, new Func<IDictionary<string, object>, ScoreTableEntryData>(this.딚)));
      this.딟 = (Func<object, ScoreTableData>) (obj0 => this.딟<ScoreTableData>(obj0, new Func<IDictionary<string, object>, ScoreTableData>(this.따)));
      this.딟 = (Func<object, Dictionary<string, Dictionary<string, ScoreTableEntryData>>>) (obj0 => this.땄<Dictionary<string, Dictionary<string, ScoreTableEntryData>>, Dictionary<string, ScoreTableEntryData>>(obj0, this.딟));
      this.딟 = (Func<object, ScoreBoardOps>) (obj0 => this.딟<ScoreBoardOps>(obj0, new Func<IDictionary<string, object>, ScoreBoardOps>(this.딾)));
      this.딟 = (Func<object, Dictionary<string, List<object>>>) (obj0 => this.땄<Dictionary<string, List<object>>, List<object>>(obj0, this.딟));
      this.딟 = (Func<object, JWTData>) (obj0 => this.딟<JWTData>(obj0, new Func<IDictionary<string, object>, JWTData>(this.땚)));
      this.딟 = (Func<object, ExternalCallResponse>) (obj0 => this.딟<ExternalCallResponse>(obj0, new Func<IDictionary<string, object>, ExternalCallResponse>(this.딮)));
      this.딟 = (Func<object, JavaScriptCallPayload>) (obj0 => this.딟<JavaScriptCallPayload>(obj0, new Func<IDictionary<string, object>, JavaScriptCallPayload>(this.딯)));
      this.딟 = (Func<object, JSResponse>) (obj0 => this.딟<JSResponse>(obj0, new Func<IDictionary<string, object>, JSResponse>(this.떍)));
      this.딟 = (Func<object, JSRequest>) (obj0 => this.딟<JSRequest>(obj0, new Func<IDictionary<string, object>, JSRequest>(this.딴)));
      this.딟 = (Func<object, List<JSRequestHeader>>) (obj0 => this.딟<List<JSRequestHeader>, JSRequestHeader>(obj0, this.딟));
      this.딟 = (Func<object, JSRequestHeader>) (obj0 => this.딟<JSRequestHeader>(obj0, new Func<IDictionary<string, object>, JSRequestHeader>(this.땀)));
      this.딟 = (Func<object, SplashDamage.Mobile.Notifications.NaClPushChannelData>) (obj0 => this.딟<SplashDamage.Mobile.Notifications.NaClPushChannelData>(obj0, new Func<IDictionary<string, object>, SplashDamage.Mobile.Notifications.NaClPushChannelData>(this.떋)));
      this.딟 = (Func<object, BuildManifestPrefabData>) (obj0 => this.딟<BuildManifestPrefabData>(obj0, new Func<IDictionary<string, object>, BuildManifestPrefabData>(this.딩)));
      this.딟 = (Func<object, BuildManifestAvatarData>) (obj0 => this.딟<BuildManifestAvatarData>(obj0, new Func<IDictionary<string, object>, BuildManifestAvatarData>(this.딖)));
      this.딟 = (Func<object, BuildManifestCharacterData>) (obj0 => this.딟<BuildManifestCharacterData>(obj0, new Func<IDictionary<string, object>, BuildManifestCharacterData>(this.딞)));
      this.딟 = (Func<object, BuildManifestGameDataData>) (obj0 => this.딟<BuildManifestGameDataData>(obj0, new Func<IDictionary<string, object>, BuildManifestGameDataData>(this.딡)));
      this.딟 = (Func<object, BuildManifestWeaponData>) (obj0 => this.딟<BuildManifestWeaponData>(obj0, new Func<IDictionary<string, object>, BuildManifestWeaponData>(this.딠)));
      this.딟 = (Func<object, BuildManifestVoicePackData>) (obj0 => this.딟<BuildManifestVoicePackData>(obj0, new Func<IDictionary<string, object>, BuildManifestVoicePackData>(this.딿)));
      this.딟 = (Func<object, BuildManifestOutfitData>) (obj0 => this.딟<BuildManifestOutfitData>(obj0, new Func<IDictionary<string, object>, BuildManifestOutfitData>(this.딨)));
      this.딟 = (Func<object, BuildManifestLevelData>) (obj0 => this.딟<BuildManifestLevelData>(obj0, new Func<IDictionary<string, object>, BuildManifestLevelData>(this.땇)));
      this.딟 = (Func<object, BuildManifestChallengePackRequiredLevel>) (obj0 => this.딟<BuildManifestChallengePackRequiredLevel>(obj0, new Func<IDictionary<string, object>, BuildManifestChallengePackRequiredLevel>(this.땯)));
      this.딟 = (Func<object, BuildManifestChallengePackChallenge>) (obj0 => this.딟<BuildManifestChallengePackChallenge>(obj0, new Func<IDictionary<string, object>, BuildManifestChallengePackChallenge>(this.땨)));
      this.딟 = (Func<object, BuildManifestChallengePackData>) (obj0 => this.딟<BuildManifestChallengePackData>(obj0, new Func<IDictionary<string, object>, BuildManifestChallengePackData>(this.땒)));
      this.딟 = (Func<object, BuildManifestChallengePackChallenge[]>) (obj0 => this.딟<BuildManifestChallengePackChallenge>(obj0, this.딟));
      this.딟 = (Func<object, BuildManifestChallengeData>) (obj0 => this.딟<BuildManifestChallengeData>(obj0, new Func<IDictionary<string, object>, BuildManifestChallengeData>(this.떄)));
      this.딟 = (Func<object, BuildManifestMapPackData>) (obj0 => this.딟<BuildManifestMapPackData>(obj0, new Func<IDictionary<string, object>, BuildManifestMapPackData>(this.떉)));
      this.딟 = (Func<object, BuildManifestMissionRewardEntry>) (obj0 => this.딟<BuildManifestMissionRewardEntry>(obj0, new Func<IDictionary<string, object>, BuildManifestMissionRewardEntry>(this.떌)));
      this.딟 = (Func<object, BuildManifestMissionRewardsData>) (obj0 => this.딟<BuildManifestMissionRewardsData>(obj0, new Func<IDictionary<string, object>, BuildManifestMissionRewardsData>(this.땛)));
      this.딟 = (Func<object, BuildManifestMissionRewardEntry[]>) (obj0 => this.딟<BuildManifestMissionRewardEntry>(obj0, this.딟));
      this.딟 = (Func<object, BuildManifestAtlasPackData>) (obj0 => this.딟<BuildManifestAtlasPackData>(obj0, new Func<IDictionary<string, object>, BuildManifestAtlasPackData>(this.땵)));
      this.딟 = (Func<object, TacticsBuildManifestDataJson>) (obj0 => this.딟<TacticsBuildManifestDataJson>(obj0, new Func<IDictionary<string, object>, TacticsBuildManifestDataJson>(this.떐)));
      this.딟 = (Func<object, BuildManifestLevelData[]>) (obj0 => this.딟<BuildManifestLevelData>(obj0, this.딟));
      this.딟 = (Func<object, BuildManifestOutfitData[]>) (obj0 => this.딟<BuildManifestOutfitData>(obj0, this.딟));
      this.딟 = (Func<object, BuildManifestVoicePackData[]>) (obj0 => this.딟<BuildManifestVoicePackData>(obj0, this.딟));
      this.딟 = (Func<object, BuildManifestWeaponData[]>) (obj0 => this.딟<BuildManifestWeaponData>(obj0, this.딟));
      this.딟 = (Func<object, BuildManifestGameDataData[]>) (obj0 => this.딟<BuildManifestGameDataData>(obj0, this.딟));
      this.딟 = (Func<object, BuildManifestCharacterData[]>) (obj0 => this.딟<BuildManifestCharacterData>(obj0, this.딟));
      this.딟 = (Func<object, BuildManifestAvatarData[]>) (obj0 => this.딟<BuildManifestAvatarData>(obj0, this.딟));
      this.딟 = (Func<object, BuildManifestPrefabData[]>) (obj0 => this.딟<BuildManifestPrefabData>(obj0, this.딟));
      this.딟 = (Func<object, BuildManifestChallengeData[]>) (obj0 => this.딟<BuildManifestChallengeData>(obj0, this.딟));
      this.딟 = (Func<object, BuildManifestMapPackData[]>) (obj0 => this.딟<BuildManifestMapPackData>(obj0, this.딟));
      this.딟 = (Func<object, BuildManifestMissionRewardsData[]>) (obj0 => this.딟<BuildManifestMissionRewardsData>(obj0, this.딟));
      this.딟 = (Func<object, BuildManifestChallengePackData[]>) (obj0 => this.딟<BuildManifestChallengePackData>(obj0, this.딟));
      this.딟 = (Func<object, BuildManifestAtlasPackData[]>) (obj0 => this.딟<BuildManifestAtlasPackData>(obj0, this.딟));
      this.딟 = (Func<object, BuildTimestampData>) (obj0 => this.딟<BuildTimestampData>(obj0, new Func<IDictionary<string, object>, BuildTimestampData>(this.떈)));
      this.딟 = (Func<object, SinglePlayerMissionScore>) (obj0 => this.딟<SinglePlayerMissionScore>(obj0, new Func<IDictionary<string, object>, SinglePlayerMissionScore>(this.딹)));
      this.딟 = (Func<object, ClientProfileData>) (obj0 => this.딟<ClientProfileData>(obj0, new Func<IDictionary<string, object>, ClientProfileData>(this.딙)));
      this.딟 = (Func<object, UnitCharacterData[]>) (obj0 => this.딟<UnitCharacterData>(obj0, this.딟));
      this.딟 = (Func<object, 딢.딮[]>) (obj0 => this.딟<딢.딮>(obj0, this.딟));
      this.딟 = (Func<object, int[]>) (obj0 => this.딟<int>(obj0, this.딟));
      this.딟 = (Func<object, SinglePlayerMissionScore[]>) (obj0 => this.딟<SinglePlayerMissionScore>(obj0, this.딟));
      this.딟 = (Func<object, NewsDataText>) (obj0 => this.딟<NewsDataText>(obj0, new Func<IDictionary<string, object>, NewsDataText>(this.땿)));
      this.딟 = (Func<object, NewsDataEntry>) (obj0 => this.딟<NewsDataEntry>(obj0, new Func<IDictionary<string, object>, NewsDataEntry>(this.땶)));
      this.딟 = (Func<object, NewsDataJson>) (obj0 => this.딟<NewsDataJson>(obj0, new Func<IDictionary<string, object>, NewsDataJson>(this.땖)));
      this.딟 = (Func<object, NewsDataEntry[]>) (obj0 => this.딟<NewsDataEntry>(obj0, this.딟));
      this.딟 = (Func<object, SceneDataJson>) (obj0 => this.딟<SceneDataJson>(obj0, new Func<IDictionary<string, object>, SceneDataJson>(this.떅)));
      this.딟 = (Func<object, CloudProfileJsonData>) (obj0 => this.딟<CloudProfileJsonData>(obj0, new Func<IDictionary<string, object>, CloudProfileJsonData>(this.딫)));
      this.딟 = (Func<object, FeaturedItemsDataJson>) (obj0 => this.딟<FeaturedItemsDataJson>(obj0, new Func<IDictionary<string, object>, FeaturedItemsDataJson>(this.땙)));
      this.딟 = (Func<object, EngineVersionData>) (obj0 => this.딟<EngineVersionData>(obj0, new Func<IDictionary<string, object>, EngineVersionData>(this.땏)));
      this.딟 = (Func<object, FacebookLoginInfo>) (obj0 => this.딟<FacebookLoginInfo>(obj0, new Func<IDictionary<string, object>, FacebookLoginInfo>(this.떆)));
      this.딟 = (Func<object, FireTeamCatalogEntryData>) (obj0 => this.딟<FireTeamCatalogEntryData>(obj0, new Func<IDictionary<string, object>, FireTeamCatalogEntryData>(this.땐)));
      this.딟 = (Func<object, FireTeamCatalogEntryURL>) (obj0 => this.딟<FireTeamCatalogEntryURL>(obj0, new Func<IDictionary<string, object>, FireTeamCatalogEntryURL>(this.땗)));
      this.딟 = (Func<object, FireTeamCatalogEntryDescriptionAbilityData>) (obj0 => this.딟<FireTeamCatalogEntryDescriptionAbilityData>(obj0, new Func<IDictionary<string, object>, FireTeamCatalogEntryDescriptionAbilityData>(this.땡)));
      this.딟 = (Func<object, FireTeamCatalogEntryAdvertData>) (obj0 => this.딟<FireTeamCatalogEntryAdvertData>(obj0, new Func<IDictionary<string, object>, FireTeamCatalogEntryAdvertData>(this.딻)));
      this.딟 = (Func<object, FireTeamCatalogEntryDescriptionData>) (obj0 => this.딟<FireTeamCatalogEntryDescriptionData>(obj0, new Func<IDictionary<string, object>, FireTeamCatalogEntryDescriptionData>(this.딜)));
      this.딟 = (Func<object, FireTeamCatalogEntryDescriptionAbilityData[]>) (obj0 => this.딟<FireTeamCatalogEntryDescriptionAbilityData>(obj0, this.딟));
      this.딟 = (Func<object, FireTeamUserProfileChallengeJsonData>) (obj0 => this.딟<FireTeamUserProfileChallengeJsonData>(obj0, new Func<IDictionary<string, object>, FireTeamUserProfileChallengeJsonData>(this.딪)));
      this.딟 = (Func<object, FireTeamUserProfileJsonData>) (obj0 => this.딟<FireTeamUserProfileJsonData>(obj0, new Func<IDictionary<string, object>, FireTeamUserProfileJsonData>(this.떕)));
      this.딟 = (Func<object, FireTeamUserProfileChallengeJsonData[]>) (obj0 => this.딟<FireTeamUserProfileChallengeJsonData>(obj0, this.딟));
      this.딟 = (Func<object, FireTeamTurnBasedSessionAttributes>) (obj0 => this.딟<FireTeamTurnBasedSessionAttributes>(obj0, new Func<IDictionary<string, object>, FireTeamTurnBasedSessionAttributes>(this.땎)));
      this.딟 = (Func<object, FireTeamStoreImportEntryData>) (obj0 => this.딟<FireTeamStoreImportEntryData>(obj0, new Func<IDictionary<string, object>, FireTeamStoreImportEntryData>(this.떑)));
      this.딟 = (Func<object, FireTeamStoreImportData>) (obj0 => this.딟<FireTeamStoreImportData>(obj0, new Func<IDictionary<string, object>, FireTeamStoreImportData>(this.딺)));
      this.딟 = (Func<object, FireTeamStoreImportEntryData[]>) (obj0 => this.딟<FireTeamStoreImportEntryData>(obj0, this.딟));
      this.딟 = (Func<object, UnitBuff>) (obj0 => this.딟<UnitBuff>(obj0, new Func<IDictionary<string, object>, UnitBuff>(this.땾)));
      this.딟 = (Func<object, 딢.떍>) (obj0 => this.딢<딢.떍>(obj0));
      this.딟 = (Func<object, UnitTurnDataJson>) (obj0 => this.딟<UnitTurnDataJson>(obj0, new Func<IDictionary<string, object>, UnitTurnDataJson>(this.딘)));
      this.딟 = (Func<object, 딢.딯>) (obj0 => this.딢<딢.딯>(obj0));
      this.딟 = (Func<object, UnitBuff[]>) (obj0 => this.딟<UnitBuff>(obj0, this.딟));
      this.딟 = (Func<object, TacticsActionData>) (obj0 => this.딟<TacticsActionData>(obj0, new Func<IDictionary<string, object>, TacticsActionData>(this.땑)));
      this.딟 = (Func<object, 딢.땀>) (obj0 => this.딢<딢.땀>(obj0));
      this.딟 = (Func<object, 딢.딴>) (obj0 => this.딢<딢.딴>(obj0));
      this.딟 = (Func<object, TacticsInitialTurnState>) (obj0 => this.딟<TacticsInitialTurnState>(obj0, new Func<IDictionary<string, object>, TacticsInitialTurnState>(this.딲)));
      this.딟 = (Func<object, TacticsSessionStateData>) (obj0 => this.딟<TacticsSessionStateData>(obj0, new Func<IDictionary<string, object>, TacticsSessionStateData>(this.떀)));
      this.딟 = (Func<object, TacticsGameStateTurnData>) (obj0 => this.딟<TacticsGameStateTurnData>(obj0, new Func<IDictionary<string, object>, TacticsGameStateTurnData>(this.땅)));
      this.딟 = (Func<object, UnitTurnDataJson[]>) (obj0 => this.딟<UnitTurnDataJson>(obj0, this.딟));
      this.딟 = (Func<object, TacticsActionData[]>) (obj0 => this.딟<TacticsActionData>(obj0, this.딟));
      this.딟 = (Func<object, UnitCharacterData>) (obj0 => this.딟<UnitCharacterData>(obj0, new Func<IDictionary<string, object>, UnitCharacterData>(this.딽)));
      this.딟 = (Func<object, 딢.딴[]>) (obj0 => this.딟<딢.딴>(obj0, this.딟));
      this.딟 = (Func<object, TacticsGameStateData>) (obj0 => this.딟<TacticsGameStateData>(obj0, new Func<IDictionary<string, object>, TacticsGameStateData>(this.딵)));
      this.딟 = (Func<object, TacticsTurnStateUnits>) (obj0 => this.딟<TacticsTurnStateUnits>(obj0, new Func<IDictionary<string, object>, TacticsTurnStateUnits>(this.땰)));
      this.딟 = (Func<object, 딟.땾>) (obj0 => this.딢<딟.땾>(obj0));
      this.딟 = (Func<object, Dictionary<string, ScoreTableEntryData>>) (obj0 => this.땄<Dictionary<string, ScoreTableEntryData>, ScoreTableEntryData>(obj0, this.딟));
      this.딟 = (Func<object, List<object>>) (obj0 => this.딟<List<object>, object>(obj0, this.딟));
      this.딟 = (Func<object, 딢.딮>) (obj0 => this.딢<딢.딮>(obj0));
      this.딟(typeof (MixPanelEventData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (GAEventParam), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (GAEvent), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (BuildManifestDataWrapper), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (BuildManifestDataJson), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (BuildManifestBundleData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (UserData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (FacebookFriendData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (ErrorData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (AccessTokenData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (XboxAuthToken), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (XboxXuidLink), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (InventoryData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (OfferRealPriceData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (OfferData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (TurnOp_AddToInventory), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (TurnOp_Consume), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (TurnBasedSessionTurnData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (TurnBasedSessionData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (SessionUserData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (SessionListData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (SessionTurnsListData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (SessionJoinData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (WriteSessionTurnData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (TransactionData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (PurchaseResult), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (BlindBoxTestResult), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (NotificationData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (NotificationsData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (SessionEventNotificationParams), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (SessionInviteNotificationParams), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (SessionUserEventNotificationParams), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (RelationFriendNotificationParams), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (SessionActionSubmitTurnNotificationParams), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (FileStoreData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (CatalogEntry), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (CatalogPagination), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (MarkNotificationReadUpdateData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (MarkNotificationReadData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (MinimalFacebookInfo), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (FacebookFriendsData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (FriendsData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (OffersData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (ApplicationStatus), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (FileInfo), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (FileList), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (SessionCreationWriteData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (PublicProfileWriteData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (SplashDamage.Mobile.Fireteam.NaClPushChannelData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (EchoSessionJson), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (EchoSessionListJson), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (EchoEventListJson), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (EchoEventJson), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (ScoreTableEntryData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (ScoreTableData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (ScoreBoardOps), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (JWTData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (ExternalCallResponse), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (JavaScriptCallPayload), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (JSResponse), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (JSRequest), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (JSRequestHeader), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (SplashDamage.Mobile.Notifications.NaClPushChannelData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (BuildManifestPrefabData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (BuildManifestAvatarData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (BuildManifestCharacterData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (BuildManifestGameDataData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (BuildManifestWeaponData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (BuildManifestVoicePackData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (BuildManifestOutfitData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (BuildManifestLevelData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (BuildManifestChallengePackRequiredLevel), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (BuildManifestChallengePackChallenge), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (BuildManifestChallengePackData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (BuildManifestChallengeData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (BuildManifestMapPackData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (BuildManifestMissionRewardEntry), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (BuildManifestMissionRewardsData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (BuildManifestAtlasPackData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (TacticsBuildManifestDataJson), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (BuildTimestampData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (SinglePlayerMissionScore), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (ClientProfileData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (NewsDataText), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (NewsDataEntry), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (NewsDataJson), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (SceneDataJson), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (CloudProfileJsonData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (FeaturedItemsDataJson), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (EngineVersionData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (FacebookLoginInfo), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (FireTeamCatalogEntryData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (FireTeamCatalogEntryDescriptionAbilityData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (FireTeamCatalogEntryAdvertData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (FireTeamCatalogEntryDescriptionData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (FireTeamCatalogEntryURL), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (FireTeamUserProfileChallengeJsonData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (FireTeamUserProfileJsonData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (FireTeamTurnBasedSessionAttributes), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (FireTeamStoreImportEntryData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (FireTeamStoreImportData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (UnitBuff), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (UnitTurnDataJson), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (TacticsActionData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (TacticsInitialTurnState), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (TacticsSessionStateData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (TacticsGameStateTurnData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (UnitCharacterData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (TacticsGameStateData), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
      this.딟(typeof (TacticsTurnStateUnits), (Func<object, object>) (obj0 => (object) this.딟(obj0)));
    }

    private MixPanelEventData 딟([In] IDictionary<string, object> obj0) => new MixPanelEventData()
    {
      Event = this.딟<string>(obj0, "event", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Properties = this.딟<Dictionary<string, string>>(obj0, "properties", this.딟, (Dictionary<string, string>) null)
    };

    private GAEventParam 땄([In] IDictionary<string, object> obj0) => new GAEventParam()
    {
      Key = this.딟<string>(obj0, "key", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Value = this.딟<string>(obj0, "value", new Func<object, string>(((딧.딗) this).땲), (string) null)
    };

    private GAEvent 딧([In] IDictionary<string, object> obj0) => new GAEvent()
    {
      Category = this.딟<string>(obj0, "category", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Action = this.딟<string>(obj0, "action", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Label = this.딟<string>(obj0, "label", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Value = this.딟<double>(obj0, "value", this.딟, 0.0)
    };

    private BuildManifestDataWrapper 딢([In] IDictionary<string, object> obj0) => new BuildManifestDataWrapper()
    {
      Base = this.딟<BuildManifestDataJson>(obj0, "base", this.딟, (BuildManifestDataJson) null),
      Game = this.딟<Dictionary<string, object>>(obj0, "game", this.딟, (Dictionary<string, object>) null)
    };

    private BuildManifestDataJson 땃([In] IDictionary<string, object> obj0) => new BuildManifestDataJson()
    {
      Bundles = this.딟<BuildManifestBundleData[]>(obj0, "Bundles", this.딟, (BuildManifestBundleData[]) null),
      CDNUrl = this.딟<string>(obj0, "url_cdn", new Func<object, string>(((딧.딗) this).땲), (string) null),
      OutputBundleManifests = this.딟<bool>(obj0, "output_bundle_manifests", this.딟, false),
      Version = this.딟<int>(obj0, "version", this.딟, 0)
    };

    private BuildManifestBundleData 딶([In] IDictionary<string, object> obj0) => new BuildManifestBundleData()
    {
      Content = this.딟<string[]>(obj0, "Content", this.딟, (string[]) null),
      Internal = this.딟<bool>(obj0, "Internal", this.딟, false),
      Name = this.딟<string>(obj0, "Name", new Func<object, string>(((딧.딗) this).땲), (string) null),
      ResourceName = this.딟<string>(obj0, "resource", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Version = this.딟<int>(obj0, "version", this.딟, 0)
    };

    private UserData 땓([In] IDictionary<string, object> obj0) => new UserData()
    {
      Email = this.딟<string>(obj0, "email_address", new Func<object, string>(((딧.딗) this).땲), (string) null),
      PublicProfileData = this.딟<Dictionary<string, object>>(obj0, "public_profile_data", this.딟, (Dictionary<string, object>) null),
      UserId = this.딟<string>(obj0, "user_id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      UserName = this.딟<string>(obj0, "username", new Func<object, string>(((딧.딗) this).땲), (string) null)
    };

    private FacebookFriendData 땺([In] IDictionary<string, object> obj0) => new FacebookFriendData()
    {
      FacebookId = this.딟<string>(obj0, "facebook_id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      PublicProfileData = this.딟<Dictionary<string, object>>(obj0, "public_profile_data", this.딟, (Dictionary<string, object>) null),
      UserId = this.딟<string>(obj0, "user_id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      UserName = this.딟<string>(obj0, "username", new Func<object, string>(((딧.딗) this).땲), (string) null)
    };

    private ErrorData 땥([In] IDictionary<string, object> obj0) => new ErrorData()
    {
      Code = this.딟<딟.땑>(obj0, "code", this.딟, 딟.땑.딟),
      Error = this.딟<string>(obj0, "error", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Message = this.딟<string>(obj0, "message", new Func<object, string>(((딧.딗) this).땲), (string) null)
    };

    private AccessTokenData 딝([In] IDictionary<string, object> obj0) => new AccessTokenData()
    {
      AccessToken = this.딟<string>(obj0, "access_token", new Func<object, string>(((딧.딗) this).땲), (string) null),
      RefreshToken = this.딟<string>(obj0, "refresh_token", new Func<object, string>(((딧.딗) this).땲), (string) null)
    };

    private XboxAuthToken 떎([In] IDictionary<string, object> obj0) => new XboxAuthToken()
    {
      TokenType = this.딟<string>(obj0, "token_type", new Func<object, string>(((딧.딗) this).땲), (string) null),
      AccessToken = this.딟<string>(obj0, "access_token", new Func<object, string>(((딧.딗) this).땲), (string) null),
      ExpiresIn = this.딟<int>(obj0, "expires_in", this.딟, 0),
      RefreshToken = this.딟<string>(obj0, "refresh_token", new Func<object, string>(((딧.딗) this).땲), (string) null)
    };

    private XboxXuidLink 떂([In] IDictionary<string, object> obj0) => new XboxXuidLink()
    {
      XuidValue = this.딟<long>(obj0, "xuid", this.딟, 0L),
      Pxuid = this.딟<string>(obj0, "pxuid", new Func<object, string>(((딧.딗) this).땲), (string) null)
    };

    private InventoryData 땭([In] IDictionary<string, object> obj0) => new InventoryData()
    {
      Inventory = this.딟<Dictionary<string, int>>(obj0, "inventory", this.딟, (Dictionary<string, int>) null)
    };

    private OfferRealPriceData 딦([In] IDictionary<string, object> obj0) => new OfferRealPriceData()
    {
      Currency = this.딟<string>(obj0, "currency", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Region = this.딟<string>(obj0, "region", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Amount = this.딟<int>(obj0, "amount", this.딟, 0),
      Tax = this.딟<int>(obj0, "tax", this.딟, 0)
    };

    private OfferData 땤([In] IDictionary<string, object> obj0) => new OfferData()
    {
      Id = this.딟<string>(obj0, "id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      ItemId = this.딟<string>(obj0, "item_id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Price = this.딟<Dictionary<string, int>>(obj0, "price", this.딟, (Dictionary<string, int>) null),
      PriceOriginal = this.딟<Dictionary<string, int>>(obj0, "price_original", this.딟, (Dictionary<string, int>) null),
      ProductId = this.딟<string>(obj0, "product_id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Vendor = this.딟<딟.딘>(obj0, "vendor", this.딟, 딟.딘.딟),
      RealPrice = this.딟<OfferRealPriceData>(obj0, "price_real", this.딟, (OfferRealPriceData) null)
    };

    private TurnOp_AddToInventory 땽([In] IDictionary<string, object> obj0) => new TurnOp_AddToInventory()
    {
      UserId = this.딟<string>(obj0, "user_id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      ItemId = this.딟<string>(obj0, "item_id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Quantity = this.딟<int>(obj0, "quantity", this.딟, 0)
    };

    private TurnOp_Consume 땋([In] IDictionary<string, object> obj0) => new TurnOp_Consume()
    {
      ItemId = this.딟<string>(obj0, "item_id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Quantity = this.딟<int>(obj0, "quantity", this.딟, 0)
    };

    private TurnBasedSessionTurnData 땲([In] IDictionary<string, object> obj0) => new TurnBasedSessionTurnData()
    {
      CompletionTime = this.딟<DateTime>(obj0, "created_at", new Func<object, DateTime>(((딧.딗) this).딶), new DateTime()),
      Data = this.딟<string>(obj0, "data", new Func<object, string>(((딧.딗) this).땲), (string) null),
      ExpireOps = this.딟<object[][]>(obj0, "expire_ops", this.딟, (object[][]) null),
      Index = this.딟<int>(obj0, "index", this.딟, 0),
      Inventory = this.딟<Dictionary<string, int>>(obj0, "inventory", this.딟, (Dictionary<string, int>) null),
      NextUserId = this.딟<string>(obj0, "next_user_id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Ops = this.딟<object[][]>(obj0, "ops", this.딟, (object[][]) null),
      UserId = this.딟<string>(obj0, "user_id", new Func<object, string>(((딧.딗) this).땲), (string) null)
    };

    private TurnBasedSessionData 떏([In] IDictionary<string, object> obj0) => new TurnBasedSessionData()
    {
      Attributes = this.딟<Dictionary<string, object>>(obj0, "attributes", this.딟, (Dictionary<string, object>) null),
      CurrentUserId = this.딟<string>(obj0, "current_user_id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      ExpiresAtTime = this.딟<DateTime>(obj0, "expires_at", new Func<object, DateTime>(((딧.딗) this).딶), new DateTime()),
      FilledPrivateSlots = this.딟<int>(obj0, "filled_private_slots", this.딟, 0),
      FilledPublicSlots = this.딟<int>(obj0, "filled_public_slots", this.딟, 0),
      Id = this.딟<string>(obj0, "id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      NumTurns = this.딟<int>(obj0, "num_turns", this.딟, 0),
      Outcomes = this.딟<Dictionary<string, 딟.땾>>(obj0, "outcomes", this.딟, (Dictionary<string, 딟.땾>) null),
      PrivateSlots = this.딟<int>(obj0, "private_slots", this.딟, 0),
      PublicSlots = this.딟<int>(obj0, "public_slots", this.딟, 0),
      SessionType = this.딟<int>(obj0, "session_type", this.딟, 0),
      State = this.딟<딟.딺>(obj0, "state", this.딟, 딟.딺.땄),
      UpdatedAtTime = this.딟<DateTime>(obj0, "updated_at", new Func<object, DateTime>(((딧.딗) this).딶), new DateTime()),
      Users = this.딟<SessionUserData[]>(obj0, "users", this.딟, (SessionUserData[]) null)
    };

    private SessionUserData 땼([In] IDictionary<string, object> obj0) => new SessionUserData()
    {
      Flags = this.딟<딟.떑>(obj0, "flags", this.딟, (딟.떑) 0),
      UserId = this.딟<string>(obj0, "user_id", new Func<object, string>(((딧.딗) this).땲), (string) null)
    };

    private SessionListData 땢([In] IDictionary<string, object> obj0) => new SessionListData()
    {
      Items = this.딟<TurnBasedSessionData[]>(obj0, "items", this.딟, (TurnBasedSessionData[]) null)
    };

    private SessionTurnsListData 딷([In] IDictionary<string, object> obj0) => new SessionTurnsListData()
    {
      Items = this.딟<TurnBasedSessionTurnData[]>(obj0, "items", this.딟, (TurnBasedSessionTurnData[]) null)
    };

    private SessionJoinData 떁([In] IDictionary<string, object> obj0) => new SessionJoinData()
    {
      SlotType = this.딟<딟.땎>(obj0, "slot_type", this.딟, 딟.땎.딟)
    };

    private WriteSessionTurnData 땟([In] IDictionary<string, object> obj0) => new WriteSessionTurnData()
    {
      NextUserId = this.딟<string>(obj0, "next_user_id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Data = this.딟<string>(obj0, "data", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Ops = this.딟<object[][]>(obj0, "ops", this.딟, (object[][]) null),
      Inventory = this.딟<Dictionary<string, int>>(obj0, "inventory", this.딟, (Dictionary<string, int>) null),
      JoinSlotType = this.딟<딟.땎>(obj0, "join_slot_type", this.딟, 딟.땎.딟),
      Outcomes = this.딟<Dictionary<string, 딟.땾>>(obj0, "outcomes", this.딟, (Dictionary<string, 딟.땾>) null),
      State = this.딟<딟.딺>(obj0, "state", this.딟, 딟.딺.땄),
      ExpireOps = this.딟<object[][]>(obj0, "expire_ops", this.딟, (object[][]) null)
    };

    private TransactionData 땂([In] IDictionary<string, object> obj0) => new TransactionData()
    {
      TransactionId = this.딟<string>(obj0, "transaction_id", new Func<object, string>(((딧.딗) this).땲), (string) null)
    };

    private PurchaseResult 딱([In] IDictionary<string, object> obj0) => new PurchaseResult()
    {
      Items = this.딟<Dictionary<string, int>>(obj0, "items", this.딟, (Dictionary<string, int>) null)
    };

    private BlindBoxTestResult 때([In] IDictionary<string, object> obj0) => new BlindBoxTestResult()
    {
      rolls = this.딟<Dictionary<string, int>[]>(obj0, "rolls", this.딟, (Dictionary<string, int>[]) null)
    };

    private NotificationData 땩([In] IDictionary<string, object> obj0) => new NotificationData()
    {
      Id = this.딟<string>(obj0, "id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      ReceiverId = this.딟<string>(obj0, "receiver_id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      AppId = this.딟<string>(obj0, "app_id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      IsRealmLevel = this.딟<bool>(obj0, "realm_level", this.딟, false),
      DeletionPolicy = this.딟<딟.땅>(obj0, "deletion_policy", this.딟, (딟.땅) 0),
      Read = this.딟<bool>(obj0, "read", this.딟, false),
      Cancelled = this.딟<bool>(obj0, "cancelled", this.딟, false),
      Expires = this.딟<DateTime>(obj0, "expires", new Func<object, DateTime>(((딧.딗) this).딶), new DateTime()),
      SentDate = this.딟<DateTime>(obj0, "sent_date", new Func<object, DateTime>(((딧.딗) this).딶), new DateTime()),
      Declaration = this.딟<object[]>(obj0, "declaration", this.딟, (object[]) null)
    };

    private NotificationsData 땠([In] IDictionary<string, object> obj0) => new NotificationsData()
    {
      Items = this.딟<NotificationData[]>(obj0, "items", this.딟, (NotificationData[]) null)
    };

    private SessionEventNotificationParams 땴(
      [In] IDictionary<string, object> obj0)
    {
      return new SessionEventNotificationParams()
      {
        SessionId = this.딟<string>(obj0, "session_id", new Func<object, string>(((딧.딗) this).땲), (string) null)
      };
    }

    private SessionInviteNotificationParams 딗(
      [In] IDictionary<string, object> obj0)
    {
      return new SessionInviteNotificationParams()
      {
        SessionId = this.딟<string>(obj0, "session_id", new Func<object, string>(((딧.딗) this).땲), (string) null),
        UserId = this.딟<string>(obj0, "user_id", new Func<object, string>(((딧.딗) this).땲), (string) null),
        InviteId = this.딟<string>(obj0, "invite_id", new Func<object, string>(((딧.딗) this).땲), (string) null)
      };
    }

    private SessionUserEventNotificationParams 땳(
      [In] IDictionary<string, object> obj0)
    {
      return new SessionUserEventNotificationParams()
      {
        SessionId = this.딟<string>(obj0, "session_id", new Func<object, string>(((딧.딗) this).땲), (string) null),
        UserId = this.딟<string>(obj0, "user_id", new Func<object, string>(((딧.딗) this).땲), (string) null)
      };
    }

    private RelationFriendNotificationParams 땻(
      [In] IDictionary<string, object> obj0)
    {
      return new RelationFriendNotificationParams()
      {
        UserId = this.딟<string>(obj0, "user_id", new Func<object, string>(((딧.딗) this).땲), (string) null),
        Message = this.딟<string>(obj0, "message", new Func<object, string>(((딧.딗) this).땲), (string) null)
      };
    }

    private SessionActionSubmitTurnNotificationParams 딥(
      [In] IDictionary<string, object> obj0)
    {
      return new SessionActionSubmitTurnNotificationParams()
      {
        SessionId = this.딟<string>(obj0, "session_id", new Func<object, string>(((딧.딗) this).땲), (string) null),
        LastUserId = this.딟<string>(obj0, "last_user_id", new Func<object, string>(((딧.딗) this).땲), (string) null)
      };
    }

    private FileStoreData 떓([In] IDictionary<string, object> obj0) => new FileStoreData()
    {
      Data = this.딟<string>(obj0, "data", new Func<object, string>(((딧.딗) this).땲), (string) null)
    };

    private CatalogEntry 딛([In] IDictionary<string, object> obj0) => new CatalogEntry()
    {
      Id = this.딟<string>(obj0, "id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Type = this.딟<딟.딪>(obj0, "type", this.딟, 딟.딪.딟),
      Flags = this.딟<딟.떕>(obj0, "flags", this.딟, (딟.떕) 0),
      Category = this.딟<string>(obj0, "category", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Tags = this.딟<string[]>(obj0, "tags", this.딟, (string[]) null),
      Dependencies = this.딟<string[]>(obj0, "dependencies", this.딟, (string[]) null),
      Data = this.딟<Dictionary<string, object>>(obj0, "data", this.딟, (Dictionary<string, object>) null),
      Name = this.딟<string>(obj0, "name", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Description = this.딟<string>(obj0, "description", new Func<object, string>(((딧.딗) this).땲), (string) null),
      IconURL = this.딟<string>(obj0, "icon_url", new Func<object, string>(((딧.딗) this).땲), (string) null),
      PreviewURLs = this.딟<string[]>(obj0, "preview_urls", this.딟, (string[]) null),
      VideoURL = this.딟<string>(obj0, "video_url", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Info = this.딟<Dictionary<string, object>>(obj0, "info", this.딟, (Dictionary<string, object>) null),
      OwnedQuantity = this.딟<int>(obj0, "owned_quantity", this.딟, 0),
      Items = this.딟<Dictionary<string, int>>(obj0, "items", this.딟, (Dictionary<string, int>) null),
      Offers = this.딟<OfferData[]>(obj0, "offers", this.딟, (OfferData[]) null)
    };

    private CatalogPagination 딣([In] IDictionary<string, object> obj0) => new CatalogPagination()
    {
      Page = this.딟<int>(obj0, "page", this.딟, 0),
      PrevPage = this.딟<int>(obj0, "prev_page", this.딟, 0),
      NextPage = this.딟<int>(obj0, "next_page", this.딟, 0),
      Pages = this.딟<int>(obj0, "pages", this.딟, 0),
      TotalCount = this.딟<int>(obj0, "total_count", this.딟, 0),
      Items = this.딟<CatalogEntry[]>(obj0, "items", this.딟, (CatalogEntry[]) null)
    };

    private MarkNotificationReadUpdateData 땔(
      [In] IDictionary<string, object> obj0)
    {
      return new MarkNotificationReadUpdateData()
      {
        Read = this.딟<bool>(obj0, "read", this.딟, false)
      };
    }

    private MarkNotificationReadData 땁([In] IDictionary<string, object> obj0) => new MarkNotificationReadData()
    {
      UpdateData = this.딟<MarkNotificationReadUpdateData>(obj0, "update", this.딟, (MarkNotificationReadUpdateData) null)
    };

    private MinimalFacebookInfo 땷([In] IDictionary<string, object> obj0) => new MinimalFacebookInfo()
    {
      FacebookId = this.딟<string>(obj0, "facebook_id", new Func<object, string>(((딧.딗) this).땲), (string) null)
    };

    private FacebookFriendsData 딸([In] IDictionary<string, object> obj0) => new FacebookFriendsData()
    {
      Items = this.딟<FacebookFriendData[]>(obj0, "items", this.딟, (FacebookFriendData[]) null)
    };

    private FriendsData 땘([In] IDictionary<string, object> obj0) => new FriendsData()
    {
      Items = this.딟<UserData[]>(obj0, "items", this.딟, (UserData[]) null)
    };

    private OffersData 떔([In] IDictionary<string, object> obj0) => new OffersData()
    {
      Offers = this.딟<OfferData[]>(obj0, "offers", this.딟, (OfferData[]) null)
    };

    private ApplicationStatus 딳([In] IDictionary<string, object> obj0) => new ApplicationStatus()
    {
      AccountHasAccess = this.딟<bool>(obj0, "account_has_access", this.딟, false),
      Public = this.딟<bool>(obj0, "public", this.딟, false)
    };

    private FileInfo 땝([In] IDictionary<string, object> obj0) => new FileInfo()
    {
      FileName = this.딟<string>(obj0, "filename", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Size = this.딟<int>(obj0, "size", this.딟, 0),
      CreatedAt = this.딟<DateTime>(obj0, "created_at", new Func<object, DateTime>(((딧.딗) this).딶), new DateTime()),
      ModifiedAt = this.딟<DateTime>(obj0, "modified_at", new Func<object, DateTime>(((딧.딗) this).딶), new DateTime())
    };

    private FileList 땹([In] IDictionary<string, object> obj0) => new FileList()
    {
      Files = this.딟<FileInfo[]>(obj0, "files", this.딟, (FileInfo[]) null)
    };

    private SessionCreationWriteData 떇([In] IDictionary<string, object> obj0) => new SessionCreationWriteData()
    {
      PublicSlots = this.딟<int>(obj0, "public_slots", this.딟, 0),
      PrivateSlots = this.딟<int>(obj0, "private_slots", this.딟, 0),
      JoinSlotType = this.딟<딟.땎>(obj0, "join_slot_type", this.딟, 딟.땎.딟),
      Attributes = this.딟<object>(obj0, "attributes", this.딟, (object) null),
      Nonce = this.딟<string>(obj0, "nonce", new Func<object, string>(((딧.딗) this).땲), (string) null),
      TurnData = this.딟<string>(obj0, "turn_data", new Func<object, string>(((딧.딗) this).땲), (string) null),
      TurnInventory = this.딟<Dictionary<string, int>>(obj0, "turn_inventory", this.딟, (Dictionary<string, int>) null),
      Invitees = this.딟<string[]>(obj0, "invitees", this.딟, (string[]) null)
    };

    private PublicProfileWriteData 땉([In] IDictionary<string, object> obj0) => new PublicProfileWriteData()
    {
      Data = this.딟<object>(obj0, "data", this.딟, (object) null)
    };

    private SplashDamage.Mobile.Fireteam.NaClPushChannelData 땈(
      [In] IDictionary<string, object> obj0)
    {
      return new SplashDamage.Mobile.Fireteam.NaClPushChannelData()
      {
        ChannelId = this.딟<string>(obj0, "channel_id", new Func<object, string>(((딧.딗) this).땲), (string) null)
      };
    }

    private EchoSessionJson 땞([In] IDictionary<string, object> obj0) => new EchoSessionJson()
    {
      Timestamp = this.딟<long>(obj0, "timestamp", this.딟, 0L),
      Users = this.딟<string[]>(obj0, "users", this.딟, (string[]) null),
      SessionId = this.딟<string>(obj0, "session_id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Type = this.딟<string>(obj0, "type", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Data = this.딟<Dictionary<string, object>>(obj0, "data", this.딟, (Dictionary<string, object>) null)
    };

    private EchoSessionListJson 땜([In] IDictionary<string, object> obj0) => new EchoSessionListJson()
    {
      UserName = this.딟<string>(obj0, "user_name", new Func<object, string>(((딧.딗) this).땲), (string) null),
      AppId = this.딟<string>(obj0, "app_id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Sessions = this.딟<EchoSessionJson[]>(obj0, "user_sessions", this.딟, (EchoSessionJson[]) null)
    };

    private EchoEventListJson 땪([In] IDictionary<string, object> obj0) => new EchoEventListJson()
    {
      AppId = this.딟<string>(obj0, "app_id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      SessionId = this.딟<string>(obj0, "session_id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Events = this.딟<EchoEventJson[]>(obj0, "events", this.딟, (EchoEventJson[]) null)
    };

    private EchoEventJson 땕([In] IDictionary<string, object> obj0) => new EchoEventJson()
    {
      Type = this.딟<string>(obj0, "type", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Users = this.딟<string[]>(obj0, "users", this.딟, (string[]) null),
      EventId = this.딟<string>(obj0, "event_id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Timestamp = this.딟<long>(obj0, "timestamp", this.딟, 0L),
      SessionId = this.딟<string>(obj0, "session_id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Time = this.딟<long>(obj0, "time", this.딟, 0L),
      Data = this.딟<Dictionary<string, object>>(obj0, "data", this.딟, (Dictionary<string, object>) null)
    };

    private ScoreTableEntryData 딚([In] IDictionary<string, object> obj0) => new ScoreTableEntryData()
    {
      Score = this.딟<int>(obj0, "score", this.딟, 0),
      Payload = this.딟<object>(obj0, "payload", this.딟, (object) null)
    };

    private ScoreTableData 따([In] IDictionary<string, object> obj0) => new ScoreTableData()
    {
      TableName = this.딟<string>(obj0, "table_name", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Users = this.딟<Dictionary<string, Dictionary<string, ScoreTableEntryData>>>(obj0, "users", this.딟, (Dictionary<string, Dictionary<string, ScoreTableEntryData>>) null)
    };

    private ScoreBoardOps 딾([In] IDictionary<string, object> obj0) => new ScoreBoardOps()
    {
      ops = this.딟<Dictionary<string, List<object>>>(obj0, "ops", this.딟, (Dictionary<string, List<object>>) null)
    };

    private JWTData 땚([In] IDictionary<string, object> obj0) => new JWTData()
    {
      JWT = this.딟<string>(obj0, "jwt", new Func<object, string>(((딧.딗) this).땲), (string) null)
    };

    private ExternalCallResponse 딮([In] IDictionary<string, object> obj0) => new ExternalCallResponse()
    {
      Id = this.딟<string>(obj0, "id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Value = this.딟<object>(obj0, "value", this.딟, (object) null)
    };

    private JavaScriptCallPayload 딯([In] IDictionary<string, object> obj0) => new JavaScriptCallPayload()
    {
      Method = this.딟<string>(obj0, "method", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Id = this.딟<string>(obj0, "id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Parameter = this.딟<string>(obj0, "parameter", new Func<object, string>(((딧.딗) this).땲), (string) null)
    };

    private JSResponse 떍([In] IDictionary<string, object> obj0) => new JSResponse()
    {
      HeadersText = this.딟<string>(obj0, "headers", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Response = this.딟<string>(obj0, "response", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Status = this.딟<int>(obj0, "status", this.딟, 0),
      StatusText = this.딟<string>(obj0, "status_text", new Func<object, string>(((딧.딗) this).땲), (string) null),
      UniqueId = this.딟<string>(obj0, "unique_id", new Func<object, string>(((딧.딗) this).땲), (string) null)
    };

    private JSRequest 딴([In] IDictionary<string, object> obj0) => new JSRequest()
    {
      Body = this.딟<string>(obj0, "body", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Headers = this.딟<List<JSRequestHeader>>(obj0, "headers", this.딟, (List<JSRequestHeader>) null),
      Method = this.딟<string>(obj0, "method", new Func<object, string>(((딧.딗) this).땲), (string) null),
      UniqueId = this.딟<string>(obj0, "unique_id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Url = this.딟<string>(obj0, "url", new Func<object, string>(((딧.딗) this).땲), (string) null)
    };

    private JSRequestHeader 땀([In] IDictionary<string, object> obj0) => new JSRequestHeader()
    {
      Key = this.딟<string>(obj0, "key", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Value = this.딟<string>(obj0, "value", new Func<object, string>(((딧.딗) this).땲), (string) null)
    };

    private SplashDamage.Mobile.Notifications.NaClPushChannelData 떋(
      [In] IDictionary<string, object> obj0)
    {
      return new SplashDamage.Mobile.Notifications.NaClPushChannelData()
      {
        ChannelId = this.딟<string>(obj0, "channel_id", new Func<object, string>(((딧.딗) this).땲), (string) null)
      };
    }

    private BuildManifestPrefabData 딩([In] IDictionary<string, object> obj0) => new BuildManifestPrefabData()
    {
      Id = this.딟<string>(obj0, "id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Package = this.딟<string>(obj0, "bundle", new Func<object, string>(((딧.딗) this).땲), (string) null),
      AssetPath = this.딟<string>(obj0, "prefab", new Func<object, string>(((딧.딗) this).땲), (string) null)
    };

    private BuildManifestAvatarData 딖([In] IDictionary<string, object> obj0) => new BuildManifestAvatarData()
    {
      Id = this.딟<string>(obj0, "id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Package = this.딟<string>(obj0, "bundle", new Func<object, string>(((딧.딗) this).땲), (string) null),
      AssetPath = this.딟<string>(obj0, "prefab", new Func<object, string>(((딧.딗) this).땲), (string) null),
      ProductId = this.딟<string>(obj0, "productid", new Func<object, string>(((딧.딗) this).땲), (string) null)
    };

    private BuildManifestCharacterData 딞([In] IDictionary<string, object> obj0) => new BuildManifestCharacterData()
    {
      Id = this.딟<string>(obj0, "id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Package = this.딟<string>(obj0, "bundle", new Func<object, string>(((딧.딗) this).땲), (string) null),
      AssetPath = this.딟<string>(obj0, "prefab", new Func<object, string>(((딧.딗) this).땲), (string) null),
      ProductId = this.딟<string>(obj0, "productid", new Func<object, string>(((딧.딗) this).땲), (string) null),
      BundleProductId = this.딟<string>(obj0, "bundleproductid", new Func<object, string>(((딧.딗) this).땲), (string) null),
      DefaultWeaponId = this.딟<string>(obj0, "defaultweapon", new Func<object, string>(((딧.딗) this).땲), (string) null),
      VoicePackId = this.딟<string>(obj0, "defaultvoicepack", new Func<object, string>(((딧.딗) this).땲), (string) null),
      FallbackVoicePackId = this.딟<string>(obj0, "fallbackvoicepack", new Func<object, string>(((딧.딗) this).땲), (string) null),
      LevelRequired = this.딟<int>(obj0, "levelreq", this.딟, 0),
      DefaultOutfitId = this.딟<string>(obj0, "defaultoutfit", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Advertise = this.딟<bool>(obj0, "advertise", this.딟, false),
      TryoutMissionId = this.딟<string>(obj0, "tryoutmissionid", new Func<object, string>(((딧.딗) this).땲), (string) null)
    };

    private BuildManifestGameDataData 딡([In] IDictionary<string, object> obj0) => new BuildManifestGameDataData()
    {
      Id = this.딟<string>(obj0, "id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Package = this.딟<string>(obj0, "bundle", new Func<object, string>(((딧.딗) this).땲), (string) null),
      AssetPath = this.딟<string>(obj0, "prefab", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Primary = this.딟<bool>(obj0, "primary", this.딟, false)
    };

    private BuildManifestWeaponData 딠([In] IDictionary<string, object> obj0) => new BuildManifestWeaponData()
    {
      Id = this.딟<string>(obj0, "id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Package = this.딟<string>(obj0, "bundle", new Func<object, string>(((딧.딗) this).땲), (string) null),
      AssetPath = this.딟<string>(obj0, "prefab", new Func<object, string>(((딧.딗) this).땲), (string) null),
      ProductId = this.딟<string>(obj0, "productid", new Func<object, string>(((딧.딗) this).땲), (string) null),
      OnlyShowIfOwned = this.딟<bool>(obj0, "showifowned", this.딟, false),
      LevelRequired = this.딟<int>(obj0, "levelreq", this.딟, 0)
    };

    private BuildManifestVoicePackData 딿([In] IDictionary<string, object> obj0) => new BuildManifestVoicePackData()
    {
      Id = this.딟<string>(obj0, "id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Package = this.딟<string>(obj0, "bundle", new Func<object, string>(((딧.딗) this).땲), (string) null),
      AssetPath = this.딟<string>(obj0, "prefab", new Func<object, string>(((딧.딗) this).땲), (string) null)
    };

    private BuildManifestOutfitData 딨([In] IDictionary<string, object> obj0) => new BuildManifestOutfitData()
    {
      Id = this.딟<string>(obj0, "id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Package = this.딟<string>(obj0, "bundle", new Func<object, string>(((딧.딗) this).땲), (string) null),
      OwnerId = this.딟<string>(obj0, "ownerid", new Func<object, string>(((딧.딗) this).땲), (string) null),
      AssetPath = this.딟<string>(obj0, "prefab", new Func<object, string>(((딧.딗) this).땲), (string) null),
      ProductId = this.딟<string>(obj0, "productid", new Func<object, string>(((딧.딗) this).땲), (string) null),
      OnlyShowIfOwned = this.딟<bool>(obj0, "showifowned", this.딟, false),
      LevelRequired = this.딟<int>(obj0, "levelreq", this.딟, 0)
    };

    private BuildManifestLevelData 땇([In] IDictionary<string, object> obj0) => new BuildManifestLevelData()
    {
      Id = this.딟<string>(obj0, "id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      GameplayPackage = this.딟<string>(obj0, "bundle", new Func<object, string>(((딧.딗) this).땲), (string) null),
      GameplayPrefabPath = this.딟<string>(obj0, "gameplay", new Func<object, string>(((딧.딗) this).땲), (string) null),
      PrettyNamePackage = this.딟<string>(obj0, "prettynamepackage", new Func<object, string>(((딧.딗) this).땲), (string) null),
      PrettyNamePrefabPath = this.딟<string>(obj0, "prettynameprefab", new Func<object, string>(((딧.딗) this).땲), (string) null),
      InGamePackage = this.딟<string>(obj0, "ingamepackage", new Func<object, string>(((딧.딗) this).땲), (string) null),
      LightingPrefabPath = this.딟<string>(obj0, "lighting", new Func<object, string>(((딧.딗) this).땲), (string) null),
      AudioPrefabPath = this.딟<string>(obj0, "audio", new Func<object, string>(((딧.딗) this).땲), (string) null),
      GeometryPrefabPath = this.딟<string>(obj0, "geometry", new Func<object, string>(((딧.딗) this).땲), (string) null),
      VFXPrefabPath = this.딟<string>(obj0, "vfx", new Func<object, string>(((딧.딗) this).땲), (string) null),
      OOBPrefabPath = this.딟<string>(obj0, "oob", new Func<object, string>(((딧.딗) this).땲), (string) null),
      ClipPrefabPath = this.딟<string>(obj0, "clip", new Func<object, string>(((딧.딗) this).땲), (string) null),
      CoverMapPrefabPath = this.딟<string>(obj0, "covermap", new Func<object, string>(((딧.딗) this).땲), (string) null),
      VisMapPrefabPath = this.딟<string>(obj0, "vismap", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Lightmaps = this.딟<string[]>(obj0, "lightmaps", this.딟, (string[]) null),
      IconPackage = this.딟<string>(obj0, "iconpackage", new Func<object, string>(((딧.딗) this).땲), (string) null),
      IconPrefabPath = this.딟<string>(obj0, "mapselecticon", new Func<object, string>(((딧.딗) this).땲), (string) null),
      SharedAudioPrefabId = this.딟<string>(obj0, "sharedaudio", new Func<object, string>(((딧.딗) this).땲), (string) null),
      ProductId = this.딟<string>(obj0, "productid", new Func<object, string>(((딧.딗) this).땲), (string) null),
      AtlasPackId = this.딟<string>(obj0, "atlaspackid", new Func<object, string>(((딧.딗) this).땲), (string) null),
      SinglePlayerOnly = this.딟<bool>(obj0, "singleplayeronly", this.딟, false)
    };

    private BuildManifestChallengePackRequiredLevel 땯(
      [In] IDictionary<string, object> obj0)
    {
      return new BuildManifestChallengePackRequiredLevel()
      {
        LevelId = this.딟<string>(obj0, "level_id", new Func<object, string>(((딧.딗) this).땲), (string) null)
      };
    }

    private BuildManifestChallengePackChallenge 땨(
      [In] IDictionary<string, object> obj0)
    {
      return new BuildManifestChallengePackChallenge()
      {
        ChallengeId = this.딟<string>(obj0, "challenge_id", new Func<object, string>(((딧.딗) this).땲), (string) null)
      };
    }

    private BuildManifestChallengePackData 땒(
      [In] IDictionary<string, object> obj0)
    {
      return new BuildManifestChallengePackData()
      {
        Id = this.딟<string>(obj0, "id", new Func<object, string>(((딧.딗) this).땲), (string) null),
        Package = this.딟<string>(obj0, "bundle", new Func<object, string>(((딧.딗) this).땲), (string) null),
        AssetPath = this.딟<string>(obj0, "prefab", new Func<object, string>(((딧.딗) this).땲), (string) null),
        LocationId = this.딟<string>(obj0, "location_id", new Func<object, string>(((딧.딗) this).땲), (string) null),
        LevelDisplayId = this.딟<string>(obj0, "level_display_id", new Func<object, string>(((딧.딗) this).땲), (string) null),
        ProductId = this.딟<string>(obj0, "productid", new Func<object, string>(((딧.딗) this).땲), (string) null),
        Challenges = this.딟<BuildManifestChallengePackChallenge[]>(obj0, "challenges", this.딟, (BuildManifestChallengePackChallenge[]) null)
      };
    }

    private BuildManifestChallengeData 떄([In] IDictionary<string, object> obj0) => new BuildManifestChallengeData()
    {
      Id = this.딟<string>(obj0, "id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Package = this.딟<string>(obj0, "bundle", new Func<object, string>(((딧.딗) this).땲), (string) null),
      AssetPath = this.딟<string>(obj0, "prefab", new Func<object, string>(((딧.딗) this).땲), (string) null),
      ProductId = this.딟<string>(obj0, "productid", new Func<object, string>(((딧.딗) this).땲), (string) null)
    };

    private BuildManifestMapPackData 떉([In] IDictionary<string, object> obj0) => new BuildManifestMapPackData()
    {
      Id = this.딟<string>(obj0, "id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Package = this.딟<string>(obj0, "bundle", new Func<object, string>(((딧.딗) this).땲), (string) null),
      AssetPath = this.딟<string>(obj0, "prefab", new Func<object, string>(((딧.딗) this).땲), (string) null),
      TitleAssetPath = this.딟<string>(obj0, "title", new Func<object, string>(((딧.딗) this).땲), (string) null),
      ProductId = this.딟<string>(obj0, "productid", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Levels = this.딟<string[]>(obj0, "levels", this.딟, (string[]) null)
    };

    private BuildManifestMissionRewardEntry 떌(
      [In] IDictionary<string, object> obj0)
    {
      return new BuildManifestMissionRewardEntry()
      {
        VoucherId = this.딟<string>(obj0, "voucherid", new Func<object, string>(((딧.딗) this).땲), (string) null),
        Coins = this.딟<int>(obj0, "coins", this.딟, 0)
      };
    }

    private BuildManifestMissionRewardsData 땛(
      [In] IDictionary<string, object> obj0)
    {
      return new BuildManifestMissionRewardsData()
      {
        MissionId = this.딟<string>(obj0, "missionid", new Func<object, string>(((딧.딗) this).땲), (string) null),
        Rewards = this.딟<BuildManifestMissionRewardEntry[]>(obj0, "rewards", this.딟, (BuildManifestMissionRewardEntry[]) null)
      };
    }

    private BuildManifestAtlasPackData 땵([In] IDictionary<string, object> obj0) => new BuildManifestAtlasPackData()
    {
      Id = this.딟<string>(obj0, "id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Package = this.딟<string>(obj0, "bundle", new Func<object, string>(((딧.딗) this).땲), (string) null),
      AssetPath = this.딟<string>(obj0, "prefab", new Func<object, string>(((딧.딗) this).땲), (string) null)
    };

    private TacticsBuildManifestDataJson 떐(
      [In] IDictionary<string, object> obj0)
    {
      return new TacticsBuildManifestDataJson()
      {
        AppStoreURL = this.딟<string>(obj0, "url_appstore", new Func<object, string>(((딧.딗) this).땲), (string) null),
        FacebookPostUrl = this.딟<string>(obj0, "url_facebook_link", new Func<object, string>(((딧.딗) this).땲), (string) null),
        FacebookPostUrlNaCl = this.딟<string>(obj0, "url_facebook_link_nacl", new Func<object, string>(((딧.딗) this).땲), (string) null),
        MaxConcurrentGames = this.딟<int>(obj0, "max_concurrent_games", this.딟, 0),
        Levels = this.딟<BuildManifestLevelData[]>(obj0, "Levels", this.딟, (BuildManifestLevelData[]) null),
        Outfits = this.딟<BuildManifestOutfitData[]>(obj0, "Outfits", this.딟, (BuildManifestOutfitData[]) null),
        VoicePacks = this.딟<BuildManifestVoicePackData[]>(obj0, "VoicePacks", this.딟, (BuildManifestVoicePackData[]) null),
        Weapons = this.딟<BuildManifestWeaponData[]>(obj0, "Weapons", this.딟, (BuildManifestWeaponData[]) null),
        GameData = this.딟<BuildManifestGameDataData[]>(obj0, "GameData", this.딟, (BuildManifestGameDataData[]) null),
        Characters = this.딟<BuildManifestCharacterData[]>(obj0, "Characters", this.딟, (BuildManifestCharacterData[]) null),
        Avatars = this.딟<BuildManifestAvatarData[]>(obj0, "Avatars", this.딟, (BuildManifestAvatarData[]) null),
        Prefabs = this.딟<BuildManifestPrefabData[]>(obj0, "Prefabs", this.딟, (BuildManifestPrefabData[]) null),
        Challenges = this.딟<BuildManifestChallengeData[]>(obj0, "Challenges", this.딟, (BuildManifestChallengeData[]) null),
        MapPacks = this.딟<BuildManifestMapPackData[]>(obj0, "MapPacks", this.딟, (BuildManifestMapPackData[]) null),
        MissionRewards = this.딟<BuildManifestMissionRewardsData[]>(obj0, "MissionRewards", this.딟, (BuildManifestMissionRewardsData[]) null),
        ChallengePacks = this.딟<BuildManifestChallengePackData[]>(obj0, "ChallengePacks", this.딟, (BuildManifestChallengePackData[]) null),
        AtlasPacks = this.딟<BuildManifestAtlasPackData[]>(obj0, "AtlasPacks", this.딟, (BuildManifestAtlasPackData[]) null)
      };
    }

    private BuildTimestampData 떈([In] IDictionary<string, object> obj0) => new BuildTimestampData()
    {
      BuildNumber = this.딟<string>(obj0, "build_number", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Time = this.딟<string>(obj0, "time", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Environment = this.딟<string>(obj0, "environment", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Platform = this.딟<string>(obj0, "platform", new Func<object, string>(((딧.딗) this).땲), (string) null)
    };

    private SinglePlayerMissionScore 딹([In] IDictionary<string, object> obj0) => new SinglePlayerMissionScore()
    {
      MissionIdHash = this.딟<int>(obj0, "Id", this.딟, 0),
      BestScore = this.딟<int>(obj0, "S", this.딟, 0),
      BestLevel = this.딟<int>(obj0, "Level", this.딟, 0)
    };

    private ClientProfileData 딙([In] IDictionary<string, object> obj0) => new ClientProfileData()
    {
      Characters = this.딟<UnitCharacterData[]>(obj0, "Characters", this.딟, (UnitCharacterData[]) null),
      PlayerXP = this.딟<int>(obj0, "PlayerXP", this.딟, 0),
      PlayerMPScore = this.딟<int>(obj0, "PlayerMPScore", this.딟, 0),
      LastModified = this.딟<DateTime>(obj0, "LastModified", new Func<object, DateTime>(((딧.딗) this).딶), new DateTime()),
      UserId = this.딟<string>(obj0, "UserId", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Avatar2 = this.딟<string>(obj0, "Avatar2", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Avatar = this.딟<string>(obj0, "Avatar", new Func<object, string>(((딧.딗) this).땲), (string) null),
      ActiveCommanderId = this.딟<string>(obj0, "CommanderId", new Func<object, string>(((딧.딗) this).땲), (string) null),
      ToolTipsWatched = this.딟<딢.딮[]>(obj0, "ToolTips", this.딟, (딢.딮[]) null),
      UnlockedAchievements = this.딟<int[]>(obj0, "Achievements", this.딟, (int[]) null),
      Cookies = this.딟<Dictionary<string, int>>(obj0, "Cookies", this.딟, (Dictionary<string, int>) null),
      Inventory = this.딟<Dictionary<string, int>>(obj0, "Inventory", this.딟, (Dictionary<string, int>) null),
      MissionScores = this.딟<SinglePlayerMissionScore[]>(obj0, "Missions", this.딟, (SinglePlayerMissionScore[]) null),
      PendingVouchers = this.딟<string[]>(obj0, "Vouchers", this.딟, (string[]) null)
    };

    private NewsDataText 땿([In] IDictionary<string, object> obj0) => new NewsDataText()
    {
      English = this.딟<string>(obj0, "english", new Func<object, string>(((딧.딗) this).땲), (string) null),
      French = this.딟<string>(obj0, "french", new Func<object, string>(((딧.딗) this).땲), (string) null),
      German = this.딟<string>(obj0, "german", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Spanish = this.딟<string>(obj0, "spanish", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Italian = this.딟<string>(obj0, "italian", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Portuguese = this.딟<string>(obj0, "portuguese", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Russian = this.딟<string>(obj0, "russian", new Func<object, string>(((딧.딗) this).땲), (string) null)
    };

    private NewsDataEntry 땶([In] IDictionary<string, object> obj0) => new NewsDataEntry()
    {
      Type = this.딟<string>(obj0, "type", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Date = this.딟<string>(obj0, "date", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Text = this.딟<NewsDataText>(obj0, "text", this.딟, (NewsDataText) null)
    };

    private NewsDataJson 땖([In] IDictionary<string, object> obj0) => new NewsDataJson()
    {
      Items = this.딟<NewsDataEntry[]>(obj0, "items", this.딟, (NewsDataEntry[]) null)
    };

    private SceneDataJson 떅([In] IDictionary<string, object> obj0) => new SceneDataJson()
    {
      LanguageSelection = this.딟<string>(obj0, "LanguageSelection", new Func<object, string>(((딧.딗) this).땲), (string) null),
      MainMenu = this.딟<string>(obj0, "Main", new Func<object, string>(((딧.딗) this).땲), (string) null),
      LoadingScreen = this.딟<string>(obj0, "Loading", new Func<object, string>(((딧.딗) this).땲), (string) null),
      TallyScreen = this.딟<string>(obj0, "Tally", new Func<object, string>(((딧.딗) this).땲), (string) null),
      TutorialScreen = this.딟<string>(obj0, "Tutorial", new Func<object, string>(((딧.딗) this).땲), (string) null)
    };

    private CloudProfileJsonData 딫([In] IDictionary<string, object> obj0) => new CloudProfileJsonData()
    {
      AccessToken = this.딟<string>(obj0, "access", new Func<object, string>(((딧.딗) this).땲), (string) null),
      RefreshToken = this.딟<string>(obj0, "refresh", new Func<object, string>(((딧.딗) this).땲), (string) null),
      UserName = this.딟<string>(obj0, "name", new Func<object, string>(((딧.딗) this).땲), (string) null)
    };

    private FeaturedItemsDataJson 땙([In] IDictionary<string, object> obj0) => new FeaturedItemsDataJson()
    {
      Items = this.딟<string[]>(obj0, "items", this.딟, (string[]) null)
    };

    private EngineVersionData 땏([In] IDictionary<string, object> obj0) => new EngineVersionData()
    {
      Version = this.딟<int>(obj0, "version", this.딟, 0)
    };

    private FacebookLoginInfo 떆([In] IDictionary<string, object> obj0) => new FacebookLoginInfo()
    {
      딟 = this.딟<string>(obj0, "access_token", new Func<object, string>(((딧.딗) this).땲), (string) null),
      땄 = this.딟<string>(obj0, "facebook_id", new Func<object, string>(((딧.딗) this).땲), (string) null)
    };

    private FireTeamCatalogEntryData 땐([In] IDictionary<string, object> obj0) => new FireTeamCatalogEntryData()
    {
      IconUrl = this.딟<FireTeamCatalogEntryURL>(obj0, "icon_url", this.딟, (FireTeamCatalogEntryURL) null),
      PreviewUrl = this.딟<FireTeamCatalogEntryURL>(obj0, "preview_url", this.딟, (FireTeamCatalogEntryURL) null),
      Version = this.딟<int>(obj0, "Version", this.딟, 0),
      Hide = this.딟<bool>(obj0, "Hide", this.딟, false),
      Sort = this.딟<int>(obj0, "Sort", this.딟, 0),
      Health = this.딟<string>(obj0, "Health", new Func<object, string>(((딧.딗) this).땲), (string) null),
      ActionPoints = this.딟<string>(obj0, "Action Points", new Func<object, string>(((딧.딗) this).땲), (string) null),
      SquadPoints = this.딟<string>(obj0, "Squad Points", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Range = this.딟<string>(obj0, "Range", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Special = this.딟<string>(obj0, "Special", new Func<object, string>(((딧.딗) this).땲), (string) null),
      Damage = this.딟<string>(obj0, "Damage", new Func<object, string>(((딧.딗) this).땲), (string) null),
      APCost = this.딟<string>(obj0, "AP Cost", new Func<object, string>(((딧.딗) this).땲), (string) null),
      LevelRequired = this.딟<int>(obj0, "Level Req", this.딟, 0),
      Class = this.딟<string>(obj0, "Class", new Func<object, string>(((딧.딗) this).땲), (string) null),
      IsNew = this.딟<bool>(obj0, "IsNew", this.딟, false)
    };

    private FireTeamCatalogEntryDescriptionAbilityData 땡(
      [In] IDictionary<string, object> obj0)
    {
      return new FireTeamCatalogEntryDescriptionAbilityData()
      {
        Name = this.딟<string>(obj0, "Name", new Func<object, string>(((딧.딗) this).땲), (string) null),
        Description = this.딟<string>(obj0, "Description", new Func<object, string>(((딧.딗) this).땲), (string) null)
      };
    }

    private FireTeamCatalogEntryAdvertData 딻(
      [In] IDictionary<string, object> obj0)
    {
      return new FireTeamCatalogEntryAdvertData()
      {
        Title = this.딟<string>(obj0, "Title", new Func<object, string>(((딧.딗) this).땲), (string) null),
        SmallTitle = this.딟<string>(obj0, "SmallTitle", new Func<object, string>(((딧.딗) this).땲), (string) null),
        Description = this.딟<string>(obj0, "Description", new Func<object, string>(((딧.딗) this).땲), (string) null),
        ImageURL = this.딟<FireTeamCatalogEntryURL>(obj0, "ImageURL", this.딟, (FireTeamCatalogEntryURL) null)
      };
    }

    private FireTeamCatalogEntryDescriptionData 딜(
      [In] IDictionary<string, object> obj0)
    {
      return new FireTeamCatalogEntryDescriptionData()
      {
        Abilities = this.딟<FireTeamCatalogEntryDescriptionAbilityData[]>(obj0, "Abilities", this.딟, (FireTeamCatalogEntryDescriptionAbilityData[]) null),
        Weapon = this.딟<string>(obj0, "Weapon", new Func<object, string>(((딧.딗) this).땲), (string) null),
        WeaponType = this.딟<string>(obj0, "Weapon Type", new Func<object, string>(((딧.딗) this).땲), (string) null),
        Name = this.딟<string>(obj0, "Name", new Func<object, string>(((딧.딗) this).땲), (string) null),
        Classes = this.딟<string[]>(obj0, "Classes", this.딟, (string[]) null),
        Character = this.딟<string>(obj0, "Character", new Func<object, string>(((딧.딗) this).땲), (string) null),
        Description = this.딟<string>(obj0, "Description", new Func<object, string>(((딧.딗) this).땲), (string) null),
        Free = this.딟<string>(obj0, "Free", new Func<object, string>(((딧.딗) this).땲), (string) null),
        Advert = this.딟<FireTeamCatalogEntryAdvertData>(obj0, "Advert", this.딟, (FireTeamCatalogEntryAdvertData) null),
        ChallengeType = this.딟<string>(obj0, "ChalType", new Func<object, string>(((딧.딗) this).땲), (string) null)
      };
    }

    private FireTeamCatalogEntryURL 땗([In] IDictionary<string, object> obj0) => new FireTeamCatalogEntryURL()
    {
      PNG = this.딟<string>(obj0, "png", new Func<object, string>(((딧.딗) this).땲), (string) null),
      PVR = this.딟<string>(obj0, "pvr", new Func<object, string>(((딧.딗) this).땲), (string) null)
    };

    private FireTeamUserProfileChallengeJsonData 딪(
      [In] IDictionary<string, object> obj0)
    {
      return new FireTeamUserProfileChallengeJsonData()
      {
        PackId = this.딟<int>(obj0, "Id", this.딟, 0),
        Position = this.딟<int>(obj0, "Pos", this.딟, 0),
        Score = this.딟<int>(obj0, "S", this.딟, 0),
        IsOwned = this.딟<bool>(obj0, "Owned", this.딟, false)
      };
    }

    private FireTeamUserProfileJsonData 떕(
      [In] IDictionary<string, object> obj0)
    {
      return new FireTeamUserProfileJsonData()
      {
        AvatarId2 = this.딟<string>(obj0, "AvatarId2", new Func<object, string>(((딧.딗) this).땲), (string) null),
        AvatarId = this.딟<string>(obj0, "AvatarId", new Func<object, string>(((딧.딗) this).땲), (string) null),
        PlayerXP = this.딟<int>(obj0, "PlayerXP", this.딟, 0),
        Challenges = this.딟<FireTeamUserProfileChallengeJsonData[]>(obj0, "Challenges", this.딟, (FireTeamUserProfileChallengeJsonData[]) null)
      };
    }

    private FireTeamTurnBasedSessionAttributes 땎(
      [In] IDictionary<string, object> obj0)
    {
      return new FireTeamTurnBasedSessionAttributes()
      {
        Version = this.딟<int>(obj0, "version", this.딟, 0),
        LevelId = this.딟<int>(obj0, "level_id", this.딟, 0),
        SubLevelId = this.딟<int>(obj0, "sublevel_id", this.딟, 0),
        ArmySize = this.딟<int>(obj0, "army_size", this.딟, 0),
        InviteeId = this.딟<string>(obj0, "invitee_id", new Func<object, string>(((딧.딗) this).땲), (string) null),
        MatchMakingTier = this.딟<int>(obj0, "tier", this.딟, 0),
        Name = this.딟<string>(obj0, "name", new Func<object, string>(((딧.딗) this).땲), (string) null)
      };
    }

    private FireTeamStoreImportEntryData 떑(
      [In] IDictionary<string, object> obj0)
    {
      return new FireTeamStoreImportEntryData()
      {
        IdString = this.딟<string>(obj0, "id", new Func<object, string>(((딧.딗) this).땲), (string) null),
        ProductId = this.딟<string>(obj0, "_product_id", new Func<object, string>(((딧.딗) this).땲), (string) null)
      };
    }

    private FireTeamStoreImportData 딺([In] IDictionary<string, object> obj0) => new FireTeamStoreImportData()
    {
      Items = this.딟<FireTeamStoreImportEntryData[]>(obj0, "items", this.딟, (FireTeamStoreImportEntryData[]) null)
    };

    private UnitBuff 땾([In] IDictionary<string, object> obj0) => new UnitBuff()
    {
      Turns = this.딟<int>(obj0, "N", this.딟, 0),
      Type = this.딟<딢.떍>(obj0, "T", this.딟, 딢.떍.딟)
    };

    private UnitTurnDataJson 딘([In] IDictionary<string, object> obj0) => new UnitTurnDataJson()
    {
      TileX = this.딟<int>(obj0, "X", this.딟, 0),
      TileY = this.딟<int>(obj0, "Y", this.딟, 0),
      ActionPoints = this.딟<int>(obj0, "AP", this.딟, 0),
      Health = this.딟<int>(obj0, "HP", this.딟, 0),
      TeamIndex = this.딟<int>(obj0, "T", this.딟, 0),
      Direction = this.딟<딢.딯>(obj0, "D", this.딟, 딢.딯.딟),
      Buffs = this.딟<UnitBuff[]>(obj0, "B", this.딟, (UnitBuff[]) null)
    };

    private TacticsActionData 땑([In] IDictionary<string, object> obj0) => new TacticsActionData()
    {
      Index = this.딟<int>(obj0, "Idx", this.딟, 0),
      TileIndexX = this.딟<int>(obj0, "X", this.딟, 0),
      TileIndexY = this.딟<int>(obj0, "Y", this.딟, 0),
      Action = this.딟<딢.땀>(obj0, "Act", this.딟, 딢.땀.딟),
      Direction = this.딟<딢.딯>(obj0, "D", this.딟, 딢.딯.딟),
      Ability = this.딟<딢.딴>(obj0, "Abi", this.딟, 딢.딴.딟),
      TargetIndex = this.딟<int>(obj0, "Tgt", this.딟, 0),
      AttackerIndex = this.딟<int>(obj0, "Atk", this.딟, 0)
    };

    private TacticsInitialTurnState 딲([In] IDictionary<string, object> obj0) => new TacticsInitialTurnState()
    {
      InitialData = this.딟<string>(obj0, "Initial", new Func<object, string>(((딧.딗) this).땲), (string) null),
      TurnData = this.딟<string>(obj0, "Turn", new Func<object, string>(((딧.딗) this).땲), (string) null)
    };

    private TacticsSessionStateData 떀([In] IDictionary<string, object> obj0) => new TacticsSessionStateData()
    {
      GameDataVersion = this.딟<int>(obj0, "DataVersion", this.딟, 0),
      LevelName = this.딟<string>(obj0, "LevelName", new Func<object, string>(((딧.딗) this).땲), (string) null),
      ScenarioIndex = this.딟<int>(obj0, "Scenario", this.딟, 0),
      Id = this.딟<string>(obj0, "Id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      SquadPointsTier = this.딟<int>(obj0, "SP", this.딟, 0),
      Players = this.딟<string[]>(obj0, "Players", this.딟, (string[]) null),
      LootDropTurn = this.딟<int>(obj0, "LootDropTurn", this.딟, 0)
    };

    private TacticsGameStateTurnData 땅([In] IDictionary<string, object> obj0) => new TacticsGameStateTurnData()
    {
      ActiveTeam = this.딟<int>(obj0, "ActiveTeam", this.딟, 0),
      StartSeed = this.딟<int>(obj0, "StartSeed", this.딟, 0),
      Seed = this.딟<int>(obj0, "Seed", this.딟, 0),
      RatingValue = this.딟<int>(obj0, "RatingValue", this.딟, 0),
      Units = this.딟<UnitTurnDataJson[]>(obj0, "Units", this.딟, (UnitTurnDataJson[]) null),
      Actions = this.딟<TacticsActionData[]>(obj0, "Actions", this.딟, (TacticsActionData[]) null),
      chatLine = this.딟<string>(obj0, "Chat", new Func<object, string>(((딧.딗) this).땲), (string) null)
    };

    private UnitCharacterData 딽([In] IDictionary<string, object> obj0) => new UnitCharacterData()
    {
      WeaponId = this.딟<string>(obj0, "Wpn", new Func<object, string>(((딧.딗) this).땲), (string) null),
      OutfitId = this.딟<string>(obj0, "Oft", new Func<object, string>(((딧.딗) this).땲), (string) null),
      CharacterId = this.딟<string>(obj0, "Class", new Func<object, string>(((딧.딗) this).땲), (string) null),
      XP = this.딟<int>(obj0, "XP", this.딟, 0),
      Name = this.딟<string>(obj0, "Name", new Func<object, string>(((딧.딗) this).땲), (string) null),
      UniqueId = this.딟<string>(obj0, "Id", new Func<object, string>(((딧.딗) this).땲), (string) null),
      SelectedAbilities = this.딟<딢.딴[]>(obj0, "Abi", this.딟, (딢.딴[]) null)
    };

    private TacticsGameStateData 딵([In] IDictionary<string, object> obj0) => new TacticsGameStateData()
    {
      Session = this.딟<TacticsSessionStateData>(obj0, "Session", this.딟, (TacticsSessionStateData) null),
      Turns = this.딟<string[]>(obj0, "Turns", this.딟, (string[]) null)
    };

    private TacticsTurnStateUnits 땰([In] IDictionary<string, object> obj0) => new TacticsTurnStateUnits()
    {
      Units = this.딟<UnitCharacterData[]>(obj0, "Units", this.딟, (UnitCharacterData[]) null)
    };
  }
}
