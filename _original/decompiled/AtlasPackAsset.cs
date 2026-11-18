// Decompiled with JetBrains decompiler
// Type: AtlasPackAsset
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

public class AtlasPackAsset : ScriptableObject
{
  public MaterialSwap[] MaterialSwaps;

  private static void 딟<딟>([In] Transform obj0, [In] List<딟> obj1) where 딟 : Component
  {
    딟 component = ((Component) obj0).GetComponent<딟>();
    if (Object.op_Inequality((Object) (object) component, (Object) null))
      obj1.Add(component);
    foreach (Transform transform in obj0)
      AtlasPackAsset.딟<딟>(transform, obj1);
  }

  private static 딟[] 딟<딟>([In] Transform obj0) where 딟 : Component
  {
    List<딟> 딟List = new List<딟>();
    AtlasPackAsset.딟<딟>(obj0, 딟List);
    return 딟List.ToArray();
  }

  public void 딟([In] GameObject obj0_1) => this.딟(obj0_1, (Func<MaterialSwap, Material, bool>) ((obj0_2, obj1) => ((Object) obj0_2.OriginalMaterial).name == ((Object) obj1).name), (Func<MaterialSwap, Material>) (obj0_3 => obj0_3.PlaceholderMaterial));

  public void 땄([In] GameObject obj0_1)
  {
    Func<MaterialSwap, Material> func = (Func<MaterialSwap, Material>) (obj0_2 => obj0_2.OriginalMaterialNaCl);
    this.딟(obj0_1, (Func<MaterialSwap, Material, bool>) ((obj0_3, obj1) => ((Object) obj0_3.PlaceholderMaterial).name == ((Object) obj1).name), func);
  }

  public void 딧([In] GameObject obj0_1) => this.딟(obj0_1, (Func<MaterialSwap, Material, bool>) ((obj0_2, obj1) => ((Object) obj0_2.PlaceholderMaterial).name == ((Object) obj1).name), (Func<MaterialSwap, Material>) (obj0_3 => obj0_3.OriginalMaterial));

  private void 딟(
    [In] GameObject obj0,
    [In] Func<MaterialSwap, Material, bool> obj1,
    [In] Func<MaterialSwap, Material> obj2)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    AtlasPackAsset.땕 땕 = new AtlasPackAsset.땕();
    // ISSUE: reference to a compiler-generated field
    땕.딟 = obj1;
    foreach (Renderer renderer in AtlasPackAsset.딟<Renderer>(obj0.transform))
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      AtlasPackAsset.딚 딚 = new AtlasPackAsset.딚();
      // ISSUE: reference to a compiler-generated field
      딚.딟 = ((IEnumerable<Material>) renderer.sharedMaterials).ToArray<Material>();
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      AtlasPackAsset.따 따 = new AtlasPackAsset.따();
      // ISSUE: reference to a compiler-generated field
      따.딟 = 땕;
      // ISSUE: reference to a compiler-generated field
      따.딟 = 딚;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      for (따.딟 = 0; 따.딟 < 딚.딟.Length; ++따.딟)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if (!Object.op_Equality((Object) 딚.딟[따.딟], (Object) null))
        {
          // ISSUE: reference to a compiler-generated method
          MaterialSwap materialSwap = ((IEnumerable<MaterialSwap>) this.MaterialSwaps).FirstOrDefault<MaterialSwap>(new Func<MaterialSwap, bool>(따.딟));
          if (materialSwap != null)
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            딚.딟[따.딟] = obj2(materialSwap);
          }
        }
      }
      // ISSUE: reference to a compiler-generated field
      renderer.sharedMaterials = 딚.딟;
    }
  }
}
