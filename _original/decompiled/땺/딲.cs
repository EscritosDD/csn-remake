// Decompiled with JetBrains decompiler
// Type: 땺.딲
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땺
{
  public class 딲 : IEquatable<딲>, IComparable<딲>
  {
    private 땾 딟;
    private float 딟;
    private float 땄;
    private float 딧;
    private float 딢;

    public 딲([In] float obj0, [In] float obj1)
      : this(obj0, obj1, 0.0f, 0.0f, 땾.딟)
    {
    }

    public 딲([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3)
      : this(obj0, obj1, obj2, obj3, 땾.딟)
    {
    }

    public 딲([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3, [In] 땾 obj4)
    {
      this.딟 = obj0;
      this.딢 = obj1;
      this.땄 = obj2;
      this.딧 = obj3;
      this.딟 = obj4;
    }

    [SpecialName]
    public 땾 딟() => this.딟;

    [SpecialName]
    public void 딟([In] 땾 obj0) => this.딟 = obj0;

    [SpecialName]
    public float 땄() => this.딟;

    [SpecialName]
    public float 딧() => this.땄;

    [SpecialName]
    public void 딟([In] float obj0) => this.땄 = obj0;

    [SpecialName]
    public float 딢() => this.딧;

    [SpecialName]
    public void 땄([In] float obj0) => this.딧 = obj0;

    [SpecialName]
    public float 땃() => this.딢;

    [SpecialName]
    public void 딧([In] float obj0) => this.딢 = obj0;

    public int CompareTo([In] 딲 obj0) => this.딟.CompareTo(obj0.딟);

    public bool Equals([In] 딲 obj0) => this == obj0;

    public 딲 딶() => new 딲(this.딟, this.딢, this.땄, this.딧, this.딟);

    public override bool Equals([In] object obj0) => (object) (obj0 as 딲) != null && (딲) obj0 == this;

    public override int GetHashCode() => this.딟.GetHashCode() ^ this.딢.GetHashCode() ^ this.땄.GetHashCode() ^ this.딧.GetHashCode() ^ this.딟.GetHashCode();

    public static bool operator !=([In] 딲 obj0, [In] 딲 obj1) => !(obj0 == obj1);

    public static bool operator ==([In] 딲 obj0, [In] 딲 obj1)
    {
      if (object.Equals((object) obj0, (object) null))
        return object.Equals((object) obj1, (object) null);
      if (object.Equals((object) obj1, (object) null))
        return object.Equals((object) obj0, (object) null);
      return (double) obj0.딟 == (double) obj1.딟 && (double) obj0.딢 == (double) obj1.딢 && (double) obj0.땄 == (double) obj1.땄 && (double) obj0.딧 == (double) obj1.딧 && obj0.딟 == obj1.딟;
    }
  }
}
