// Decompiled with JetBrains decompiler
// Type: 딧.딼
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딧
{
  public class 딼
  {
    private List<Material> 딟 = new List<Material>();

    public void 딟([In] GameObject obj0, [In] Material obj1)
    {
      obj0.renderer.material = obj1;
      this.딟.Add(obj0.renderer.material);
    }

    public static void 딟([In] GameObject obj0, [In] Material obj1, [In] Texture2D obj2) => obj0.renderer.material = new Material(obj1)
    {
      mainTexture = (Texture) obj2
    };

    public void 딟([In] GameObject obj0, [In] Material obj1, [In] Shader obj2)
    {
      Material material = new Material(obj1);
      material.shader = obj2;
      obj0.renderer.material = material;
      this.딟.Add(obj0.renderer.material);
      this.딟.Add(material);
    }

    public void 딟([In] GameObject obj0, [In] Shader obj1)
    {
      obj0.renderer.material.shader = obj1;
      this.딟.Add(obj0.renderer.material);
    }

    public void 딟([In] GameObject obj0, [In] Color obj1)
    {
      Material material = new Material(obj0.renderer.material);
      material.color = obj1;
      obj0.renderer.material = material;
      this.딟.Add(material);
      this.딟.Add(obj0.renderer.material);
    }

    public void 딟([In] Material obj0) => this.딟.Add(obj0);

    public void 딟()
    {
      foreach (Material material in this.딟)
        GlobalAppData.딟(material);
      this.딟.Clear();
    }
  }
}
