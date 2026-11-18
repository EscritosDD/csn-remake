// Decompiled with JetBrains decompiler
// Type: 땃.땠
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 땃
{
  public class 땠
  {
    private int 딟;
    private int 땄;
    private int 딧;
    private int 딢;
    public GameTileComponent[] 딟;

    public 땠([In] int obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] GameTileComponent[] obj4)
    {
      this.딟 = obj0;
      this.땄 = obj1;
      this.딧 = obj2;
      this.딢 = obj3;
      if (obj4 == null)
        return;
      this.딟 = (GameTileComponent[]) obj4.Clone();
    }

    public override int GetHashCode() => base.GetHashCode();

    public override bool Equals([In] object obj0)
    {
      if (obj0 == null)
        return false;
      땠 땠 = (땠) obj0;
      return 땠 != null && this.딟 == 땠.딟 && this.땄 == 땠.땄 && this.딧 == 땠.딧 && this.딢 == 땠.딢;
    }
  }
}
