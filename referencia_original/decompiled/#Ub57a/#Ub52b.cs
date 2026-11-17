// Decompiled with JetBrains decompiler
// Type: 땺.딫
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using 땥;

namespace 땺
{
  public struct 딫 : IEquatable<딫>
  {
    public float 딟;
    public 떁 딟;
    public float 땄;
    public float 딧;

    public bool Equals([In] 딫 obj0) => this == obj0;

    public override bool Equals([In] object obj0) => !object.ReferenceEquals((object) null, obj0) && (object) obj0.GetType() == (object) typeof (딫) && this.Equals((딫) obj0);

    public override int GetHashCode() => ((this.딟.GetHashCode() * 397 ^ this.딟.GetHashCode()) * 397 ^ this.땄.GetHashCode()) * 397 ^ this.딧.GetHashCode();

    public static bool operator ==([In] 딫 obj0, [In] 딫 obj1) => (double) obj0.딟 == (double) obj1.딟 && (double) obj0.딧 == (double) obj1.딧 && obj0.딟 == obj1.딟 && (double) obj0.땄 == (double) obj1.땄;

    public static bool operator !=([In] 딫 obj0, [In] 딫 obj1) => !(obj0 == obj1);
  }
}
