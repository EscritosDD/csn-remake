// Decompiled with JetBrains decompiler
// Type: 딢.땢
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using 딟;

namespace 딢
{
  public class 땢 : 딟.땩, 땠<땽, BuildManifestLevelData>
  {
    private BuildManifestLevelData 딟;
    public AssetBundleRequest 딟;
    public 땽 딟 = new 땽();

    [SpecialName]
    public string 딧() => this.딟.Id;

    [SpecialName]
    public string 땓() => this.딟.GameplayPrefabPath;

    [SpecialName]
    public string 땺() => this.딟.SharedAudioPrefabId;

    [SpecialName]
    public string 땥() => this.딟.AtlasPackId;

    [SpecialName]
    public string 딝() => this.딟.GeometryPrefabPath;

    [SpecialName]
    public string 떎() => this.딟.VFXPrefabPath;

    [SpecialName]
    public bool 떂() => this.딟.SinglePlayerOnly;

    [CompilerGenerated]
    [SpecialName]
    public int 땭() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public 딟.땟 딟() => this.딟;

    [SpecialName]
    public bool 딢() => Object.op_Inequality((Object) this.딟.딟.딧(), (Object) null);

    [SpecialName]
    public string 땄() => this.딟.ProductId;

    public void 딟([In] BuildManifestLevelData obj0, [In] 딟.때 obj1)
    {
      this.딟 = obj0;
      // ISSUE: reference to a compiler-generated method
      this.딟(딟.딗.딢(this.딧()));
      if (obj1 == null)
        return;
      // ISSUE: reference to a compiler-generated method
      this.딟(obj1.딟(this.딟.GameplayPackage));
    }

    public void 딦()
    {
      if (!Object.op_Inequality((Object) this.딟.딟, (Object) null))
        return;
      this.딟.딟.SetActive(false);
    }

    public void 딟([In] 딟.땟 obj0, [In] 딟.딗 obj1) => this.딟.딟.딟(this.땓(), obj0);

    public bool 딟([In] 딟.딗 obj0)
    {
      bool flag = true & this.딟.딟.땄();
      if (Object.op_Equality((Object) this.딟.딟, (Object) null) && Object.op_Inequality((Object) this.딟.딟.딧(), (Object) null))
      {
        this.딟.딟 = this.딟.딟.딧();
        this.딟.딟.SetActive(true);
        this.딟.딟 = this.딟.딟.GetComponent<GameGridComponent>();
        if (Object.op_Equality((Object) this.딟.딟, (Object) null))
          this.딟.딟 = this.딟.딟.GetComponentInChildren<GameGridComponent>();
        this.딟.딟 = this.딟.딟.GetComponentInChildren<ScenarioManagerComponent>();
        if (Object.op_Inequality((Object) this.딟.딟, (Object) null))
          this.딟.딟.Init();
        this.딟.딟 = this.딟.딟.GetComponentInChildren<CameraAnimationWrapper>();
        this.딟.딟.SetActive(false);
      }
      return flag;
    }

    public void 땃()
    {
      this.딟.딟.딟();
      this.딟 = new 땽();
    }

    public 땽 딶() => this.딟;
  }
}
