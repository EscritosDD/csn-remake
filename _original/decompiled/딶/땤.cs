// Decompiled with JetBrains decompiler
// Type: 딶.땤
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 딶
{
  public class 땤 : 딶.땃
  {
    public int 딟;
    public int 땄;
    public int 딧;
    public string 딟;

    public 땤([In] int obj0, [In] int obj1, [In] int obj2)
    {
      this.딟 = obj0;
      this.땄 = obj1;
      this.딧 = obj2;
    }

    public 땤([In] TacticsUserActionEditorBase obj0)
    {
      this.딟 = obj0.GameObjectIndex;
      this.땄 = obj0.TileX;
      this.딧 = obj0.TileY;
      this.딟 = obj0.StatId;
    }

    public 땃.땧 딟() => (땃.땧) new 땃.땸(this);

    public void 딟([In] 땛 obj0) => obj0.딟(this.딟);

    public bool 딟([In] 딶.땃 obj0) => obj0 is 땤 땤 && this.딟 == 땤.딟 && this.땄 == 땤.땄 && this.딧 == 땤.딧;
  }
}
