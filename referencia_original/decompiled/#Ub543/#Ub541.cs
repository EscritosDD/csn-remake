// Decompiled with JetBrains decompiler
// Type: 땃.땁
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땃
{
  public class 땁
  {
    public 땁([In] 딢.딴 obj0) => this.딟(obj0);

    public virtual 땻 딟([In] 딶.딡 obj0, [In] 딡 obj1, [In] 딶.땙 obj2) => 땻.딢;

    protected bool 딟(
      [In] 딶.딡 obj0,
      [In] 딡 obj1,
      [In] List<GameTileComponent> obj2,
      [In] 딶.땙 obj3,
      [In] int obj4,
      [In] int obj5,
      out int _param7)
    {
      bool flag = false;
      _param7 = -1;
      if (obj2.Count > 0)
      {
        땓.땊 땊 = obj3.땺()[obj1.딟.땔()];
        땓.딲 딲 = obj0.땼().땻()[obj1.딟.땔()];
        if (땸.딟(obj2, obj2.Count, 딲) > 땊.딢)
        {
          for (int index = 땊.딢 / 딲.땥(); index >= 0; --index)
          {
            int tileIndexX = obj2[index].TileIndexX;
            int tileIndexY = obj2[index].TileIndexY;
            if (obj0.땼().땄(obj0.땼().떂(), obj1.딟.땔(), tileIndexX, tileIndexY, 땊.땄) >= 0)
            {
              obj4 = tileIndexX;
              obj5 = tileIndexY;
              break;
            }
          }
        }
        else
          flag = true;
        if (obj4 != -1 && obj5 != -1 && (땊.땃 != obj4 || 땊.딶 != obj5))
        {
          땸 땸 = new 땸(new 딶.땤(obj1.딟.땔(), obj4, obj5));
          땁.딟((땧) 땸, obj0);
          _param7 = 땸.딧;
        }
        else
          flag = true;
      }
      else
        flag = true;
      return flag;
    }

    public static bool 딟([In] 땧 obj0, [In] 딶.딡 obj1)
    {
      if (obj1 != null && obj1.땼() != null)
      {
        EventTimelineManager.딟().AddEventTimeline(obj1.땼().딟(obj0));
        EventTimelineManager.딟().RunToEnd(false);
      }
      return true;
    }

    [CompilerGenerated]
    [SpecialName]
    public 딢.딴 딟() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    protected void 딟([In] 딢.딴 obj0) => this.딟 = obj0;
  }
}
