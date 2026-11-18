// Decompiled with JetBrains decompiler
// Type: 땃.딫
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 땃
{
  public class 딫 : 땶
  {
    public override bool 딟([In] 딵 obj0, [In] 딡 obj1) => base.딟(obj0, obj1) && obj0.딟;

    public override 딡 딟([In] 딵 obj0)
    {
      딡 딡1 = (딡) null;
      int num = -1;
      GameTileComponent gameTileComponent = (GameTileComponent) null;
      for (int index = 0; index < obj0.땔().Count; ++index)
      {
        딡 딡2 = obj0.땔()[index];
        if (this.딟(obj0, 딡2))
        {
          딡 딡3 = this.딟(딡1, 딡2, obj0.딣().땼().떂(), obj0.딣());
          if (딡3 == 딡2)
          {
            딨 딨 = obj0.땄(딡3.딟.땔());
            if (딨 != null && 딨.딟 != -1 && Object.op_Inequality((Object) 딨.딟, (Object) null))
            {
              num = 딨.딟;
              gameTileComponent = 딨.딟;
              딡1 = 딡3;
            }
          }
        }
      }
      if (딡1 != null)
        딡1.딟(땜.딢, new 땯()
        {
          딟 = num,
          딟 = gameTileComponent,
          딟 = 딢.딴.딥
        });
      return 딡1;
    }

    private 딡 딟([In] 딡 obj0, [In] 딡 obj1, [In] 딶.땙 obj2, [In] 딶.딡 obj3)
    {
      if (!obj1.땥)
        return obj0;
      땓.땊 땊1 = obj2.땺()[obj1.딟.땔()];
      땓.땊 땊2 = obj0 == null ? (땓.땊) null : obj2.땺()[obj0.딟.땔()];
      return obj3.땼().땻()[obj1.딟.땔()].땄(딢.딴.딥) && (땊2 == null || 땊1.딧 > 땊2.딧) ? obj1 : obj0;
    }
  }
}
