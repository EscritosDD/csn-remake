// Decompiled with JetBrains decompiler
// Type: 딟.떇
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딟
{
  public class 떇
  {
    public 떇()
    {
    }

    public 떇([In] string obj0, [In] IEnumerable<Guid> obj1)
    {
      this.딟(new object[1]{ (object) obj1 });
      this.딟(string.Format("{0} in :1", (object) obj0));
    }

    public 떇([In] IEnumerable<Guid> obj0)
      : this("_id", obj0)
    {
    }

    [CompilerGenerated]
    [SpecialName]
    public object[] 딟() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] object[] obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public string 땄() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] string obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public string[] 딧() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] string[] obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public int? 딢() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] int? obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public int? 땃() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public void 땄([In] int? obj0) => this.땄 = obj0;
  }
}
