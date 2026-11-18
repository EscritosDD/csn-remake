// Decompiled with JetBrains decompiler
// Type: 딢.땃
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using 딟;

namespace 딢
{
  public class 땃 : 딟.땩, 땠<ChallengePackAsset, BuildManifestChallengePackData>
  {
    private BuildManifestChallengePackData 딟;
    private 딟.땴<ChallengePackAsset> 딟 = new 딟.땴<ChallengePackAsset>();

    [SpecialName]
    public string 딧() => this.딟.Id;

    [SpecialName]
    public ChallengePackAsset 땓() => this.딟.딧();

    [SpecialName]
    public string 땺() => this.딟.LocationId;

    [SpecialName]
    public string 땥() => this.딟.LevelDisplayId;

    [SpecialName]
    public string[] 딝() => ((IEnumerable<BuildManifestChallengePackChallenge>) this.딟.Challenges).Select<BuildManifestChallengePackChallenge, string>((Func<BuildManifestChallengePackChallenge, string>) (obj0 => obj0.ChallengeId)).ToArray<string>();

    [CompilerGenerated]
    [SpecialName]
    public 딟.땟 딟() => this.딟;

    [SpecialName]
    public bool 딢() => Object.op_Inequality((Object) this.땓(), (Object) null);

    [SpecialName]
    public string 땄() => this.딟.ProductId;

    public bool 떎() => ((IEnumerable<BuildManifestChallengePackChallenge>) this.딟.Challenges).Select<BuildManifestChallengePackChallenge, 딢.땓>((Func<BuildManifestChallengePackChallenge, 딢.땓>) (obj0 => GlobalAppData.땼().떔(obj0.ChallengeId))).All<딢.땓>((Func<딢.땓, bool>) (obj0 => obj0 != null && GlobalAppData.땽().딶(obj0.땄())));

    public bool 떂() => !string.IsNullOrEmpty(this.땄()) && !this.떎();

    public void 딟([In] BuildManifestChallengePackData obj0, [In] 딟.때 obj1)
    {
      this.딟 = obj0;
      if (obj1 == null)
        return;
      // ISSUE: reference to a compiler-generated method
      this.딟(obj1.딟(this.딟.Package));
    }

    public ChallengePackAsset 딶() => this.땓();

    public void 딟([In] 딟.땟 obj0, [In] 딟.딗 obj1) => this.딟.딟(this.딟.AssetPath, obj0);

    public bool 딟([In] 딟.딗 obj0) => this.딟.땄();

    public void 땃() => this.딟.딟();
  }
}
