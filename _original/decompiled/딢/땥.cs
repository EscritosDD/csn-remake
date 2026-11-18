// Decompiled with JetBrains decompiler
// Type: 딢.땥
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using 딟;

namespace 딢
{
  public class 땥 : 딟.땩, 땠<UnitClass, BuildManifestCharacterData>
  {
    private BuildManifestCharacterData 딟;
    public 딟.땴<UnitClass> 딟 = new 딟.땴<UnitClass>();

    [SpecialName]
    public string 딧() => this.딟.Id;

    [SpecialName]
    public string 땓() => this.딟.VoicePackId;

    [SpecialName]
    public string 땺() => this.딟.FallbackVoicePackId;

    [SpecialName]
    public string 땥() => this.딟.DefaultWeaponId;

    [SpecialName]
    public string 딝() => this.딟.DefaultOutfitId;

    [SpecialName]
    public string 떎() => this.딟.TryoutMissionId;

    [SpecialName]
    public UnitClass 떂() => this.딟.딧();

    [CompilerGenerated]
    [SpecialName]
    public 딟.땟 딟() => this.딟;

    [SpecialName]
    public bool 딢() => Object.op_Inequality((Object) this.떂(), (Object) null);

    [SpecialName]
    public string 땄() => this.딟.ProductId;

    [SpecialName]
    public string 땭() => this.딟.BundleProductId;

    public void 딟([In] BuildManifestCharacterData obj0, [In] 딟.때 obj1)
    {
      this.딟 = obj0;
      if (obj1 == null)
        return;
      // ISSUE: reference to a compiler-generated method
      this.딟(obj1.딟(this.딟.Package));
    }

    public void 딟([In] 딟.땟 obj0, [In] 딟.딗 obj1) => this.딟.딟(this.딟.AssetPath, obj0);

    public bool 딟([In] 딟.딗 obj0) => this.딟.땄();

    public void 땃() => this.딟.딟();

    public UnitClass 딶() => this.떂();
  }
}
