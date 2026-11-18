// Decompiled with JetBrains decompiler
// Type: 땥.떏
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 땥
{
  internal class 떏 : 떂
  {
    private 땽 딟;

    public 떏([In] 땽 obj0, [In] 떂 obj1, [In] 떂 obj2)
      : base(obj1, obj2)
    {
      this.딟 = obj0;
    }

    public override 딦 딟([In] 땋 obj0) => (double) obj0.딟.딟 >= (double) this.딟.딟 ? this.땄.딟(obj0) : base.딟.딟(obj0);
  }
}
