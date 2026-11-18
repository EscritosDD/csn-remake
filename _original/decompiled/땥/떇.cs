// Decompiled with JetBrains decompiler
// Type: 땥.떇
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 땥
{
  public struct 떇
  {
    public 땹 딟;

    public void 딟([In] 땹 obj0) => this.딟 |= obj0;

    public void 땄([In] 땹 obj0) => this.딟 &= ~obj0;

    public bool 딧([In] 땹 obj0) => (this.딟 & obj0) == obj0;
  }
}
