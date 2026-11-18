// Decompiled with JetBrains decompiler
// Type: 땃.땐
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 땃
{
  public class 땐 : 땶
  {
    public override 딡 딟([In] 딵 obj0)
    {
      딡 딡1 = (딡) null;
      딡 딡2 = (딡) null;
      GameTileComponent gameTileComponent = (GameTileComponent) null;
      for (int index = 0; index < obj0.땔().Count; ++index)
      {
        딡 딡3 = obj0.땔()[index];
        if (this.딟(obj0, 딡3))
        {
          딡 딡4 = this.딟(딡1, 딡3, obj0.딣().땼().떂(), obj0.딣());
          if (딡4 == 딡3)
          {
            땇 땇 = obj0.딟(딡4, 딢.딴.떏);
            if (땇 != null && 땇.딟 != null)
            {
              딡2 = 땇.딟;
              gameTileComponent = 땇.딟;
              딡1 = 딡4;
            }
          }
        }
      }
      if (딡1 != null)
        딡1.딟(땜.땄, new 땯()
        {
          딟 = 딡2,
          딟 = gameTileComponent,
          딟 = 딢.딴.떏
        });
      return 딡1;
    }

    private 딡 딟([In] 딡 obj0, [In] 딡 obj1, [In] 딶.땙 obj2, [In] 딶.딡 obj3)
    {
      if (obj3.땼().땻()[obj1.딟.땔()] is 땓.떀 떀)
      {
        땓.땊 땊1 = obj2.땺()[obj1.딟.땔()];
        땓.땊 땊2 = obj0 == null ? (땓.땊) null : obj2.땺()[obj0.딟.땔()];
        if (떀.땄(딢.딴.떏) && (땊2 == null || 땊1.딧 > 땊2.딧))
          return obj1;
      }
      return obj0;
    }
  }
}
