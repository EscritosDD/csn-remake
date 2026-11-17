// Decompiled with JetBrains decompiler
// Type: 땓.땧
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 땓
{
  internal static class 땧
  {
    public static Transform 딟([In] 딢.떍 obj0)
    {
      딢.떍 떍 = obj0;
      switch (떍)
      {
        case 딢.떍.딧:
          return GlobalAppData.딟.GameAssets.ContinousEffectDisabled;
        case 딢.떍.딢:
          return GlobalAppData.딟.GameAssets.ContinousEffectGhost;
        case 딢.떍.땓:
          return GlobalAppData.딟.GameAssets.ContinousEffectPoison;
        default:
          switch (떍 - 19)
          {
            case 딢.떍.딟:
              return GlobalAppData.딟.GameAssets.ContinousEffectStunned;
            case 딢.떍.땄:
              return GlobalAppData.딟.GameAssets.ContinousEffectBacklash;
            case 딢.떍.딧:
              return GlobalAppData.딟.GameAssets.ContinuousEffectHeadshot;
            default:
              if (떍 == 딢.떍.땔)
                return GlobalAppData.딟.GameAssets.ContinousEffectBees;
              return 떍 == 딢.떍.떈 ? GlobalAppData.딟.GameAssets.ContinousEffectFire : (Transform) null;
          }
      }
    }
  }
}
