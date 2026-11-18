// Decompiled with JetBrains decompiler
// Type: 딢.땲
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
  public class 땲 : 딟.땩, 땠<땋, BuildManifestLevelData>
  {
    private BuildManifestLevelData 딟;
    public 땋 딟 = new 땋();

    [SpecialName]
    public string 딧() => this.딟.Id;

    public void 딟([In] BuildManifestLevelData obj0, [In] 딟.때 obj1)
    {
      this.딟 = obj0;
      this.딟.딟 = ((IEnumerable<string>) this.딟.Lightmaps).Select<string, 딟.땴<Texture2D>>((Func<string, 딟.땴<Texture2D>>) delegate
      {
        return new 딟.땴<Texture2D>();
      }).ToArray<딟.땴<Texture2D>>();
      if (obj1 == null)
        return;
      // ISSUE: reference to a compiler-generated method
      this.딟(obj1.딟(this.딟.InGamePackage));
    }

    public void 딟([In] 딟.땟 obj0, [In] 딟.딗 obj1)
    {
      this.딟.딟.딟(this.딟.AudioPrefabPath, obj0);
      this.딟.땄.딟(this.딟.GeometryPrefabPath, obj0);
      this.딟.딧.딟(this.딟.VFXPrefabPath, obj0);
      this.딟.딢.딟(this.딟.OOBPrefabPath, obj0);
      this.딟.땃.딟(this.딟.ClipPrefabPath, obj0);
      this.딟.딶.딟(this.딟.LightingPrefabPath, obj0);
      for (int index = 0; index < this.딟.Lightmaps.Length; ++index)
        this.딟.딟[index].딟(this.딟.Lightmaps[index], obj0);
      this.딟.땓.딟(this.딟.CoverMapPrefabPath, obj0);
      this.딟.땺.딟(this.딟.VisMapPrefabPath, obj0);
    }

    public bool 딟([In] 딟.딗 obj0)
    {
      bool flag = true & this.딟.딟.땄() & this.딟.땄.땄() & this.딟.딧.땄() & this.딟.딢.땄() & this.딟.땃.땄() & this.딟.딶.땄();
      for (int index = 0; index < this.딟.Lightmaps.Length; ++index)
        flag &= this.딟.딟[index].땄();
      return flag & this.딟.땓.땄() & this.딟.땺.땄();
    }

    public void 땃()
    {
      this.딟.딟.딟();
      this.딟.땄.딟();
      this.딟.딧.딟();
      this.딟.딢.딟();
      this.딟.땃.딟();
      this.딟.딶.딟();
      for (int index = 0; index < this.딟.딟.Length; ++index)
        this.딟.딟[index].딟();
      this.딟.땓.딟();
      this.딟.땺.딟();
    }

    [CompilerGenerated]
    [SpecialName]
    public 딟.땟 딟() => this.딟;

    [SpecialName]
    public bool 딢() => Object.op_Inequality((Object) this.딟.땄.딧(), (Object) null);

    [SpecialName]
    public string 땄() => this.딟.ProductId;

    public 땋 딶() => this.딟;
  }
}
