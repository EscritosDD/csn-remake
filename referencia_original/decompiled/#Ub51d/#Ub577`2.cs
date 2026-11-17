// Decompiled with JetBrains decompiler
// Type: 딝.땷`2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딝
{
  [CompilerGenerated]
  internal sealed class 땷<딟, 땄>
  {
    private readonly 딟 딟;
    private readonly 땄 딟;

    [DebuggerHidden]
    public 땷([In] 딟 obj0, [In] 땄 obj1)
    {
      // ISSUE: reference to a compiler-generated field
      this.딟 = obj0;
      // ISSUE: reference to a compiler-generated field
      this.딟 = (딟) obj1;
    }

    [SpecialName]
    public 딟 딟() => this.딟;

    [SpecialName]
    public 땄 땄() => (땄) this.딟;

    [DebuggerHidden]
    public override bool Equals([In] object obj0) => obj0 is 땷<딟, 땄> 땷 && EqualityComparer<딟>.Default.Equals(this.딟, 땷.딟) && EqualityComparer<땄>.Default.Equals((땄) this.딟, (땄) 땷.딟);

    [DebuggerHidden]
    public override int GetHashCode()
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      int num1 = ((-2128831035 ^ EqualityComparer<딟>.Default.GetHashCode(this.딟)) * 16777619 ^ EqualityComparer<땄>.Default.GetHashCode((땄) this.딟)) * 16777619;
      int num2 = num1 + (num1 << 13);
      int num3 = num2 ^ num2 >> 7;
      int num4 = num3 + (num3 << 3);
      int num5 = num4 ^ num4 >> 17;
      return num5 + (num5 << 5);
    }

    [DebuggerHidden]
    public override string ToString() => "{" + " Id = " + ((object) this.딟 == null ? string.Empty : this.딟.ToString()) + ", Index = " + ((object) (땄) this.딟 == null ? string.Empty : ((땄) this.딟).ToString()) + " }";
  }
}
