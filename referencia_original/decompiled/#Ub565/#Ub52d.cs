// Decompiled with JetBrains decompiler
// Type: 땥.딭
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 땥
{
  public abstract class 딭
  {
    public 땑 딟;
    public int 딟;
    public 땑 땄 = 땑.땄;
    public int 땄;

    public virtual bool 딟([In] 딺 obj0)
    {
      if (obj0 == null || !obj0.떎() || obj0.딷() || obj0.딦() == null)
        return false;
      foreach (떀 떀 in obj0.딦())
      {
        if ((int) 떀.딟() == this.딟 && 떀.딟() != (short) 0 && this.딟 != 0 || (떀.딧() & this.딟) != 땑.딟)
          return false;
        if (this.땄 == 0 && this.땄 == 땑.땄 || (int) 떀.딟() == this.땄 && 떀.딟() != (short) 0 && this.땄 != 0 || (떀.딧() & this.땄) != 땑.딟 && this.땄 != 땑.땄)
          return true;
      }
      return false;
    }

    public void 딟([In] 땑 obj0) => this.딟 |= obj0;

    public void 땄([In] 땑 obj0) => this.딟 &= ~obj0;

    public bool 딧([In] 땑 obj0) => (this.딟 & obj0) == obj0;

    public void 딢([In] 땑 obj0) => this.땄 |= obj0;

    public void 땃([In] 땑 obj0) => this.땄 &= ~obj0;

    public bool 딶([In] 땑 obj0) => (this.땄 & obj0) == obj0;
  }
}
