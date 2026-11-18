// Decompiled with JetBrains decompiler
// Type: 땓.땇
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땓
{
  internal sealed class 땇 : 땄.땅
  {
    private FireTeamUserProfileChallengeJsonData[] 딟;
    private Uri 딟;
    public int 딟;

    public 땇([In] 딢.떇 obj0_1)
    {
      this.딟 = obj0_1.딳();
      this.딟 = obj0_1.딣();
      this.딟 = GlobalAppData.땼().딷().Select<딢.땃, FireTeamUserProfileChallengeJsonData>((Func<딢.땃, FireTeamUserProfileChallengeJsonData>) (obj0_2 => 땇.딟(obj0_2))).Where<FireTeamUserProfileChallengeJsonData>((Func<FireTeamUserProfileChallengeJsonData, bool>) (obj0_3 => obj0_3.Position != -1 || obj0_3.IsOwned)).ToArray<FireTeamUserProfileChallengeJsonData>();
    }

    public 땇([In] FireTeamUserProfileJsonData obj0)
    {
      if (obj0 == null)
        obj0 = new FireTeamUserProfileJsonData();
      this.딟 = 땶.딟(!string.IsNullOrEmpty(obj0.AvatarId2) ? obj0.AvatarId2 : obj0.AvatarId);
      this.딟 = obj0.PlayerXP;
      this.딟 = obj0.Challenges;
    }

    public 땇()
    {
      this.딟 = new Uri(GlobalAppData.딟.땓());
      this.딟 = 0;
    }

    private static FireTeamUserProfileChallengeJsonData 딟([In] 딢.땃 obj0)
    {
      FireTeamUserProfileChallengeJsonData challengeJsonData = new FireTeamUserProfileChallengeJsonData();
      string[] strArray = obj0.딝();
      challengeJsonData.PackId = 딟.딗.딢(obj0.딧());
      challengeJsonData.Position = ChallengePackAsset.딧(strArray);
      challengeJsonData.IsOwned = obj0.떎();
      challengeJsonData.Score = ChallengePackAsset.땃(strArray);
      return challengeJsonData;
    }

    public FireTeamUserProfileJsonData 땄()
    {
      FireTeamUserProfileJsonData userProfileJsonData = new FireTeamUserProfileJsonData();
      if (this.딟.Scheme == "avatar")
        userProfileJsonData.AvatarId = this.딟.Host;
      userProfileJsonData.AvatarId2 = this.딟.ToString();
      userProfileJsonData.PlayerXP = this.딟;
      userProfileJsonData.Challenges = this.딟;
      return userProfileJsonData;
    }

    [SpecialName]
    public object 딟() => (object) this.땄();

    public 땶 딧() => 땶.딟(this.딟);

    [SpecialName]
    public int 딢() => GlobalAppData.딢().GenericData.땄(this.딟);

    public int 딟([In] string obj0)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      땇.땯 땯 = new 땇.땯();
      if (this.딟 == null)
        return -1;
      // ISSUE: reference to a compiler-generated field
      땯.딟 = 딟.딗.딢(obj0);
      // ISSUE: reference to a compiler-generated method
      FireTeamUserProfileChallengeJsonData challengeJsonData = ((IEnumerable<FireTeamUserProfileChallengeJsonData>) this.딟).FirstOrDefault<FireTeamUserProfileChallengeJsonData>(new Func<FireTeamUserProfileChallengeJsonData, bool>(땯.딟));
      return challengeJsonData == null ? -1 : challengeJsonData.Position;
    }

    public FireTeamUserProfileChallengeJsonData 땄([In] string obj0)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      땇.땨 땨 = new 땇.땨();
      if (this.딟 == null)
        return (FireTeamUserProfileChallengeJsonData) null;
      // ISSUE: reference to a compiler-generated field
      땨.딟 = 딟.딗.딢(obj0);
      // ISSUE: reference to a compiler-generated method
      return ((IEnumerable<FireTeamUserProfileChallengeJsonData>) this.딟).FirstOrDefault<FireTeamUserProfileChallengeJsonData>(new Func<FireTeamUserProfileChallengeJsonData, bool>(땨.딟));
    }
  }
}
