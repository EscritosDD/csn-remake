// Decompiled with JetBrains decompiler
// Type: 땓.딾
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땓
{
  internal class 딾
  {
    public 딾([In] Material obj0, [In] Color? obj1, [In] Shader obj2, [In] Texture2D obj3)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(new Material(obj0));
      ((Object) this.딟()).name = "Cached copy of " + ((Object) obj0).name;
      if (obj1.HasValue)
        this.딟().color = obj1.Value;
      if (Object.op_Inequality((Object) obj2, (Object) null))
        this.딟().shader = obj2;
      if (Object.op_Inequality((Object) obj3, (Object) null))
        this.딟().mainTexture = (Texture) obj3;
      // ISSUE: reference to a compiler-generated method
      this.딟(obj1);
      // ISSUE: reference to a compiler-generated method
      this.딟(obj2);
      // ISSUE: reference to a compiler-generated method
      this.딟(obj3);
    }

    [CompilerGenerated]
    [SpecialName]
    public Material 딟() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public Color? 땄() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public Shader 딧() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public Texture2D 딢() => this.딟;
  }
}
