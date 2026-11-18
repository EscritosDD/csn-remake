// Decompiled with JetBrains decompiler
// Type: 땓.땺
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 땓
{
  public class 땺 : 딦
  {
    protected new int 딟;
    protected new bool 딟;

    public 땺([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 떒 obj2, [In] int obj3, [In] int obj4, [In] 딶.땩 obj5, [In] bool obj6)
      : base(obj0, obj1, obj2, obj3, obj5)
    {
      this.딟 = obj4;
      this.딟 = obj6;
    }

    public 땺([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 떒 obj2, [In] int obj3, [In] int obj4, [In] 딶.땩 obj5)
      : this(obj0, obj1, obj2, obj3, obj4, obj5, false)
    {
    }

    public override void 딟([In] bool obj0)
    {
      base.딟(obj0);
      땊 땊1 = base.딟.땺()[this.딟];
      딲 딲1 = base.딟.땻()[this.딟];
      if (this.딟)
      {
        for (int index = 0; index < base.딟.땺().Count; ++index)
        {
          if (index != this.딟)
          {
            땊 땊2 = base.딟.땺()[index];
            if (((딶.땏) this).딟.딟 == 땊2.땃 && ((딶.땏) this).딟.땄 == 땊2.딶)
            {
              딲 딲2 = base.딟.땻()[index];
              if (딲2.딧(땊2) || 딲2.딟(base.딟, 딲1, base.딟.땃(), false, true) == -1)
              {
                GameTileComponent gameTileComponent = base.딟.땹().get_TileNetwork().딟(base.딟, base.딟, ((딶.땏) this).딟.딟, ((딶.땏) this).딟.땄, 20, 딲2, 땊1.땄);
                ((딶.땏) this).딟.딟 = gameTileComponent.TileIndexX;
                ((딶.땏) this).딟.땄 = gameTileComponent.TileIndexY;
                break;
              }
            }
          }
        }
      }
      땊 땊3 = base.딟.땺()[((딶.땏) this).딟];
      if (base.딟.딟(base.딟, this.딟, ((딶.땏) this).딟.딟, ((딶.땏) this).딟.땄, 땊3.땄))
        return;
      if (base.딟.땻()[this.딟] is 딶.땉 땉)
        땊3.딢 -= 땉.땺();
      땊1.땃 = ((딶.땏) this).딟.딟;
      땊1.딶 = ((딶.땏) this).딟.땄;
      땊1.딢 = 0;
      땊1.딧 = 딲1.딱();
    }
  }
}
