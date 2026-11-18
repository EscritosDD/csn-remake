// Decompiled with JetBrains decompiler
// Type: 땓.땿
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace 땓
{
  public static class 땿
  {
    public static void 딟() => Social.localUser.Authenticate(new Action<bool>(땿.딟));

    private static void 딟([In] IAchievementDescription[] obj0)
    {
    }

    private static void 딟([In] IAchievement[] obj0)
    {
    }

    private static void 딟([In] bool obj0)
    {
      if (!obj0)
        return;
      Social.LoadAchievements(new Action<IAchievement[]>(땿.딟));
      // ISSUE: reference to a compiler-generated method
      땿.딟(((IUserProfile) Social.localUser).userName);
    }

    [CompilerGenerated]
    [SpecialName]
    public static string 땄() => 땿.딟;
  }
}
