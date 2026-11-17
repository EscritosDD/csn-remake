// Decompiled with JetBrains decompiler
// Type: 땥.딦
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 땥
{
  internal class 딦 : 떂
  {
    public 땲 딟;

    private 딦([In] 땲 obj0)
      : base((떂) null, (떂) null)
    {
      this.딟 = obj0;
      obj0.딟 = this;
    }

    public static 딦 딟([In] 땲 obj0) => obj0.딟 == null ? new 딦(obj0) : obj0.딟;

    public override 딦 딟([In] 땋 obj0) => this;
  }
}
