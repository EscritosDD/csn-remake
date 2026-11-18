// Decompiled with JetBrains decompiler
// Type: 딢.땟
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using 딟;

namespace 딢
{
  public class 땟 : 딟.땩, 땠<떁, BuildManifestMapPackData>
  {
    private BuildManifestMapPackData 딟;
    private 떁 딟 = new 떁();

    [SpecialName]
    public string 딧() => this.딟.Id;

    [SpecialName]
    public string[] 땓() => this.딟.Levels;

    [CompilerGenerated]
    [SpecialName]
    public 딟.땟 딟() => this.딟;

    [SpecialName]
    public bool 딢() => Object.op_Inequality((Object) this.딟.딟.딧(), (Object) null);

    [SpecialName]
    public string 땄() => this.딟.ProductId;

    public void 딟([In] BuildManifestMapPackData obj0, [In] 딟.때 obj1)
    {
      this.딟 = obj0;
      if (obj1 == null)
        return;
      // ISSUE: reference to a compiler-generated method
      this.딟(obj1.딟(this.딟.Package));
    }

    public 떁 딶() => this.딟;

    public void 딟([In] 딟.땟 obj0, [In] 딟.딗 obj1)
    {
      this.딟.딟.딟(this.딟.AssetPath, obj0);
      this.딟.딟.딟(this.딟.TitleAssetPath, obj0);
    }

    public bool 딟([In] 딟.딗 obj0) => true & this.딟.딟.땄() & this.딟.딟.땄();

    public void 땃()
    {
      this.딟.딟.딟();
      this.딟.딟.딟();
    }
  }
}
