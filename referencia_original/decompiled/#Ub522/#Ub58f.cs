// Decompiled with JetBrains decompiler
// Type: 딢.떏
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using 딟;

namespace 딢
{
  public class 떏 : 딟.땩, 땠<LocalisationEntry, BuildManifestLevelData>
  {
    private BuildManifestLevelData 딟;
    private 딟.땴<LocalisationEntry> 딟 = new 딟.땴<LocalisationEntry>();

    [SpecialName]
    public string 딧() => this.딟.Id;

    public void 딟([In] BuildManifestLevelData obj0, [In] 딟.때 obj1)
    {
      this.딟 = obj0;
      if (obj1 == null)
        return;
      // ISSUE: reference to a compiler-generated method
      this.딟(obj1.딟(this.딟.PrettyNamePackage));
    }

    public void 딟([In] 딟.땟 obj0, [In] 딟.딗 obj1) => this.딟.딟(this.딟.PrettyNamePrefabPath, obj0);

    public bool 딟([In] 딟.딗 obj0) => this.딟.땄();

    public void 땃() => this.딟.딟();

    public LocalisationEntry 딶() => this.딟.딧();

    [CompilerGenerated]
    [SpecialName]
    public 딟.땟 딟() => this.딟;

    [SpecialName]
    public bool 딢() => Object.op_Inequality((Object) this.딟.딧(), (Object) null);

    [SpecialName]
    public string 땄() => this.딟.ProductId;
  }
}
