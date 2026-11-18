// Decompiled with JetBrains decompiler
// Type: 땓.딿
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땓
{
  internal sealed class 딿 : 땄.땈
  {
    private FireTeamTurnBasedSessionAttributes 딟;

    public 딿([In] FireTeamTurnBasedSessionAttributes obj0) => this.딟 = obj0;

    [SpecialName]
    public int 딟() => this.딟.Version;

    [SpecialName]
    public int 땄() => this.딟.LevelId;

    [SpecialName]
    public int 딧() => this.딟.SubLevelId;

    [SpecialName]
    public int 딢() => this.딟.ArmySize;

    [SpecialName]
    public string 땃() => this.딟.InviteeId;

    [SpecialName]
    public int 딶() => this.딟.MatchMakingTier;

    [SpecialName]
    public string 땓() => this.딟.Name;
  }
}
