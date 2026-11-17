// Decompiled with JetBrains decompiler
// Type: 딢.땕
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딢
{
  public class 땕
  {
    public 땕([In] 땪 obj0, [In] Dictionary<string, object> obj1)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0);
      // ISSUE: reference to a compiler-generated method
      this.딟(obj1);
    }

    [SpecialName]
    public string 딟() => this.땃()["id"] as string;

    [SpecialName]
    public string 땄() => this.땃()["name"] as string;

    [SpecialName]
    public int 딧() => this.땃()["kills"] is int num ? num : 0;

    [CompilerGenerated]
    [SpecialName]
    public 땪 딢() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public Dictionary<string, object> 땃() => this.딟;
  }
}
