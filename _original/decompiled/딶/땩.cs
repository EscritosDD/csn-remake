// Decompiled with JetBrains decompiler
// Type: 딶.땩
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 딶
{
  public struct 땩
  {
    public int 딟;
    public int 땄;
    public int 딧;
    public int 딢;
    public static readonly 땩 딟 = new 땩(-1, -1);

    public 땩([In] int obj0, [In] int obj1)
    {
      this.딟 = obj0;
      this.땄 = obj1;
      this.딧 = 0;
      this.딢 = 0;
    }

    public override bool Equals([In] object obj0) => this == (땩) obj0;

    public override int GetHashCode() => base.GetHashCode();

    public override string ToString() => string.Format("({0},{1})", (object) this.딟, (object) this.땄);

    public static bool operator ==([In] 땩 obj0, [In] 땩 obj1) => obj0.딟 == obj1.딟 && obj0.땄 == obj1.땄;

    public static bool operator !=([In] 땩 obj0, [In] 땩 obj1) => !(obj0 == obj1);
  }
}
