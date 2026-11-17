// Decompiled with JetBrains decompiler
// Type: 땓.땮
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 땓
{
  public static class 땮
  {
    public static void 딟([In] 떒 obj0, [In] 딶.땖 obj1, [In] 땮.딟 obj2)
    {
      if (obj1.딥().Count == 0)
        return;
      딶.땙 땙 = new 딶.땙(obj1, obj1.딥()[0]);
      for (int index1 = 1; index1 < obj1.딥().Count; ++index1)
      {
        List<땃.땧> 땧List = obj1.딥()[index1].땥();
        for (int index2 = 0; index2 < 땧List.Count; ++index2)
          땙.딟(obj1, 땧List[index2], obj0).땄(false);
        땙.땄().땄(false);
        if (obj2 != null)
          obj2(땙);
        땙 = new 딶.땙(obj1, 땙);
      }
    }

    public delegate void 딟([In] 딶.땙 obj0);
  }
}
