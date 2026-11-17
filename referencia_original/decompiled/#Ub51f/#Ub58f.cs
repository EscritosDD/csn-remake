// Decompiled with JetBrains decompiler
// Type: 딟.떏
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딟
{
  [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
  public sealed class 떏 : Attribute
  {
    public 떏([In] string obj0)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0);
      this.AllowBlank = true;
    }

    [CompilerGenerated]
    [SpecialName]
    public string 딟() => this.딟;

    public bool AllowBlank { get; [param: In] set; }
  }
}
