// Decompiled with JetBrains decompiler
// Type: 딧.떁
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딧
{
  [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
  public sealed class 떁 : Attribute
  {
    private object 딟;

    public string Name { get; [param: In] set; }

    public object DefaultValue
    {
      get => this.딟;
      [param: In] set
      {
        this.딟(true);
        this.딟 = value;
      }
    }

    [CompilerGenerated]
    [SpecialName]
    public bool 딧() => this.딟;
  }
}
