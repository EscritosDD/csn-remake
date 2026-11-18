// Decompiled with JetBrains decompiler
// Type: 땃.땡
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 땃
{
  public class 땡 : 땶
  {
    public override 딡 딟([In] 딵 obj0)
    {
      딡 딡1 = (딡) null;
      GameTileComponent gameTileComponent1 = (GameTileComponent) null;
      for (int index = 0; index < obj0.땔().Count; ++index)
      {
        딡 딡2 = obj0.땔()[index];
        if (this.딟(obj0, 딡2))
        {
          딡 딡3 = this.딟(딡1, 딡2, obj0);
          if (딡3 == 딡2)
          {
            GameTileComponent gameTileComponent2 = obj0.땄(딡3, 딡3.딟[0]);
            if (Object.op_Inequality((Object) gameTileComponent2, (Object) null))
            {
              gameTileComponent1 = gameTileComponent2;
              딡1 = 딡3;
            }
          }
        }
      }
      if (딡1 != null)
        딡1.딟(땜.딟, new 땯()
        {
          딟 = -1,
          땄 = 1,
          땄 = gameTileComponent1,
          딟 = 딡1.딟.딟,
          딟 = 땝.땄
        });
      return 딡1;
    }

    private 딡 딟([In] 딡 obj0, [In] 딡 obj1, [In] 딵 obj2) => obj0 != null && obj0.딟 == 땪.딶 || obj1.딟 != 땪.딶 && (!obj2.딶(obj1) || !obj1.땥 || obj1.딟 != 땪.딟 && obj0 != null && (obj0 == null || obj0.딟 == 땪.딟)) ? obj0 : obj1;
  }
}
