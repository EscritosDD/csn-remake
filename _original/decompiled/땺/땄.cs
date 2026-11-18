// Decompiled with JetBrains decompiler
// Type: 땺.땄
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땺
{
  [DefaultMember("Item")]
  public class 땄
  {
    public XPRewardEntry[] 딟 = new XPRewardEntry[38];

    public 땄([In] 딶.땖 obj0)
    {
      foreach (XPRewardEntry xpReward in obj0.땞().GenericData.XPRewards)
        this.딟[(int) xpReward.Reward] = xpReward;
    }

    [SpecialName]
    public XPRewardEntry 딟([In] 땓.떊 obj0) => this.딟[(int) obj0];

    [SpecialName]
    public XPRewardEntry 딟([In] int obj0) => this.딟[obj0];
  }
}
