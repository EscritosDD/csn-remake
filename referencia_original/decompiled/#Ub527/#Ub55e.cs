// Decompiled with JetBrains decompiler
// Type: 딧.땞
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딧
{
  internal class 땞
  {
    public 땞([In] MemberInfo obj0, [In] Type obj1, [In] bool obj2)
    {
      // ISSUE: reference to a compiler-generated method
      this.땄(obj2);
      // ISSUE: reference to a compiler-generated method
      this.딟(obj1);
      this.딟(obj0);
    }

    private void 딟([In] MemberInfo obj0)
    {
      // ISSUE: reference to a compiler-generated method
      this.땄(obj0.Name);
      // ISSUE: reference to a compiler-generated method
      this.딟(this.땄());
      if (!(((IEnumerable<object>) obj0.GetCustomAttributes(typeof (떁), false)).FirstOrDefault<object>() is 떁 떁))
        return;
      if (!string.IsNullOrEmpty(떁.Name))
      {
        // ISSUE: reference to a compiler-generated method
        this.딟(떁.Name);
      }
      // ISSUE: reference to a compiler-generated method
      this.딟(떁.DefaultValue);
      // ISSUE: reference to a compiler-generated method
      this.딟(떁.딧());
    }

    [CompilerGenerated]
    [SpecialName]
    public string 딟() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public string 땄() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public object 딧() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public bool 딢() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public Type 땃() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public bool 딶() => this.땄;
  }
}
