// Decompiled with JetBrains decompiler
// Type: 땃.딯
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 땃
{
  public class 딯
  {
    public 딮 딟;
    public int[,] 딟 = new int[딮.딟, 딾.딟];

    public 딯()
    {
      this.딟 = new 딮();
      this.딟();
    }

    public void 딟()
    {
      this.딟.딟();
      for (int index1 = 0; index1 < 딮.딟; ++index1)
      {
        for (int index2 = 0; index2 < 딾.딟; ++index2)
          this.딟[index1, index2] = -1;
      }
    }

    public void 딟([In] int obj0, [In] int obj1, [In] int obj2) => this.딟.딟(obj0, obj1, obj2);

    public bool 땄([In] int obj0, [In] int obj1, [In] int obj2) => this.딟.땄(obj0, obj1, obj2);

    public void 딧([In] int obj0, [In] int obj1, [In] int obj2) => this.딟.딟(obj0, obj1, obj2);

    public void 딢([In] int obj0, [In] int obj1, [In] int obj2) => this.딟[obj1, obj2] = obj0;

    public void 딟([In] int obj0, [In] int obj1) => this.딟.딟(obj0, obj1);
  }
}
