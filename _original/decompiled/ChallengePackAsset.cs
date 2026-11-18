// Decompiled with JetBrains decompiler
// Type: ChallengePackAsset
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

public class ChallengePackAsset : ScriptableObject
{
  public string[] ChallengeIds;
  public LocalisationEntry PackName;
  public LocalisationEntry PackDescription;
  public Material PackIcon;
  public bool IsDirectorsCut;

  public bool 딟() => ((IEnumerable<string>) this.ChallengeIds).Select<string, 딢.땓>((Func<string, 딢.땓>) (obj0 => GlobalAppData.땼().떔(obj0))).All<딢.땓>((Func<딢.땓, bool>) (obj0 => obj0 != null && GlobalAppData.땽().딶(obj0.땄())));

  public bool 땄()
  {
    foreach (string challengeId in this.ChallengeIds)
    {
      if (!GlobalAppData.땼().떂(challengeId))
        return false;
    }
    return true;
  }

  public bool 딧() => ((IEnumerable<string>) this.ChallengeIds).All<string>((Func<string, bool>) (obj0 =>
  {
    딢.땓 땓 = GlobalAppData.땼().떔(obj0);
    return 땓 != null && 땓.딢();
  }));

  public static bool 딟([In] string[] obj0_1) => ((IEnumerable<string>) obj0_1).All<string>((Func<string, bool>) (obj0_2 => ChallengePackAsset.딟(obj0_2)));

  public static bool 땄([In] string[] obj0)
  {
    int num = 0;
    for (int index = 0; index < obj0.Length; ++index)
    {
      if (ChallengePackAsset.딟(obj0[index]))
        ++num;
    }
    return num == obj0.Length - 1;
  }

  public static int 딧([In] string[] obj0_1)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: reference to a compiler-generated method
    // ISSUE: variable of a compiler-generated type
    딝.땷<string, int> 땷 = ((IEnumerable<string>) obj0_1).Select<string, 딝.땷<string, int>>((Func<string, int, 딝.땷<string, int>>) ((obj0_2, obj1) => new 딝.땷<string, int>(obj0_2, obj1))).LastOrDefault<딝.땷<string, int>>((Func<딝.땷<string, int>, bool>) (obj0_3 => GlobalAppData.땽().떎(obj0_3.딟()) > 0));
    // ISSUE: reference to a compiler-generated method
    return 땷 == null ? -1 : 땷.땄();
  }

  public static SinglePlayerMissionAsset[] 딢([In] string[] obj0_1)
  {
    int count = Mathf.Min(ChallengePackAsset.딧(obj0_1) + 1 + 1, obj0_1.Length);
    return ((IEnumerable<string>) obj0_1).Take<string>(count).Select<string, SinglePlayerMissionAsset>((Func<string, SinglePlayerMissionAsset>) (obj0_2 => GlobalAppData.땼().때(obj0_2))).ToArray<SinglePlayerMissionAsset>();
  }

  public SinglePlayerMissionAsset[] 딢() => ChallengePackAsset.딢(this.ChallengeIds);

  public static bool 딟([In] string obj0) => GlobalAppData.땽().떎(obj0) > 0;

  public static int 땃([In] string[] obj0)
  {
    int num = 0;
    foreach (string str in obj0)
      num += GlobalAppData.땽().땥(str);
    return num;
  }

  public int 땃() => ChallengePackAsset.땃(this.ChallengeIds);

  public int 딶() => ChallengePackAsset.딧(this.ChallengeIds);
}
