// Decompiled with JetBrains decompiler
// Type: 땃.딽
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땃
{
  public class 딽
  {
    public 딽([In] GameTileComponent obj0, [In] GameTileComponent obj1)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0);
      // ISSUE: reference to a compiler-generated method
      this.땄(obj1);
    }

    public bool 딟([In] 딵 obj0, [In] 딶.땙 obj1, [In] 땓.땊 obj2) => obj0.딟(obj1, this.땄().TileIndexX, this.땄().TileIndexY, obj2, true) || obj0.딟(obj1, this.딟().TileIndexX, this.딟().TileIndexY, obj2, true);

    [CompilerGenerated]
    [SpecialName]
    public GameTileComponent 딟() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public GameTileComponent 땄() => this.땄;
  }
}
