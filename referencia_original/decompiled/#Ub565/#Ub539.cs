// Decompiled with JetBrains decompiler
// Type: 땥.딹
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 땥
{
  public abstract class 딹 : 딭
  {
    public bool 딟;
    public 땱 딟;
    private 떐 딟;

    public 딹([In] 떐 obj0) => this.딟 = obj0;

    public override bool 딟([In] 딺 obj0) => !obj0.딟.딧(this.딟) && base.딟(obj0);

    public abstract void 딟([In] float obj0);
  }
}
