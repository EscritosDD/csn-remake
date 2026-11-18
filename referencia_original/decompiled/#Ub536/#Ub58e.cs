// Decompiled with JetBrains decompiler
// Type: 딶.떎
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 딶
{
  public class 떎 : 딶.땃
  {
    public int 딟;
    public 딢.딯 딟;
    public string 딟;

    public 떎([In] int obj0, [In] 딢.딯 obj1)
    {
      this.딟 = obj0;
      this.딟 = obj1;
    }

    public 떎([In] TacticsUserActionEditorBase obj0)
    {
      this.딟 = obj0.GameObjectIndex;
      this.딟 = obj0.Direction;
      this.딟 = obj0.StatId;
    }

    public 땃.땧 딟() => (땃.땧) null;

    public void 딟([In] 땛 obj0) => obj0.딟(this.딟);

    public bool 딟([In] 딶.땃 obj0) => obj0 is 떎 떎 && this.딟 == 떎.딟 && this.딟 == 떎.딟;
  }
}
