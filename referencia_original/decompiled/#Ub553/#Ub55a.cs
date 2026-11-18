// Decompiled with JetBrains decompiler
// Type: 땓.땚
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땓
{
  public class 땚
  {
    private Dictionary<Material, List<딾>> 딟 = new Dictionary<Material, List<딾>>();

    public void 딟() => this.딟 = new Dictionary<Material, List<딾>>();

    public Material 딟([In] Material obj0, [In] Color? obj1, [In] Shader obj2, [In] Texture2D obj3)
    {
      List<딾> 딾List;
      if (this.딟.TryGetValue(obj0, out 딾List))
      {
        Material material = this.딟(딾List, obj1, obj2, obj3);
        if (Object.op_Inequality((Object) material, (Object) null))
          return material;
      }
      if (딾List == null)
      {
        딾List = new List<딾>();
        this.딟.Add(obj0, 딾List);
      }
      딾 딾 = new 딾(obj0, obj1, obj2, obj3);
      딾List.Add(딾);
      return 딾.딟();
    }

    private Material 딟([In] List<딾> obj0, [In] Color? obj1, [In] Shader obj2, [In] Texture2D obj3)
    {
      foreach (딾 딾 in obj0)
      {
        Color? nullable = 딾.땄();
        if ((!Color.op_Equality(nullable.GetValueOrDefault(), obj1.GetValueOrDefault()) ? 0 : (nullable.HasValue == obj1.HasValue ? 1 : 0)) != 0 && Object.op_Equality((Object) 딾.딧(), (Object) obj2) && Object.op_Equality((Object) 딾.딢(), (Object) obj3))
          return 딾.딟();
      }
      return (Material) null;
    }

    public Material 딟([In] Material obj0, [In] Color obj1) => this.딟(obj0, new Color?(obj1), (Shader) null, (Texture2D) null);

    public Material 딟([In] Material obj0, [In] Shader obj1) => this.딟(obj0, new Color?(), obj1, (Texture2D) null);

    public Material 딟([In] Material obj0, [In] Texture2D obj1) => this.딟(obj0, new Color?(), (Shader) null, obj1);
  }
}
