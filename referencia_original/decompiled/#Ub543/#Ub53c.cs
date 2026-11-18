// Decompiled with JetBrains decompiler
// Type: 땃.딼
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 땃
{
  public class 딼 : 땧
  {
    private int 딟;
    private 딢.딴 딟;
    private int 땄;
    private int 딧;

    public 딼([In] 딶.땽 obj0)
    {
      this.딟 = obj0.딟;
      this.딟 = obj0.딟;
      this.땄 = obj0.땄;
      this.딧 = obj0.딧;
    }

    public 딼([In] int obj0, [In] 딢.딴 obj1, [In] int obj2, [In] int obj3)
    {
      this.딟 = obj0;
      this.딟 = obj1;
      this.땄 = obj2;
      this.딧 = obj3;
    }

    public 딼([In] TacticsActionData obj0)
    {
      this.딟 = obj0.AttackerIndex;
      this.딟 = obj0.Ability;
      this.땄 = obj0.TileIndexX;
      this.딧 = obj0.TileIndexY;
    }

    public override 땓.딟 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 땓.떒 obj2)
    {
      땓.딟 딟 = new 땓.딟();
      딟.딟(딼.딟(obj0, this.딟, this.딟, new 딶.땩(this.땄, this.딧)));
      return 딟;
    }

    public override TacticsActionData 딟() => new TacticsActionData()
    {
      Action = 딢.땀.딟,
      AttackerIndex = this.딟,
      Ability = this.딟,
      TileIndexX = this.땄,
      TileIndexY = this.딧
    };

    public override int 땄() => this.딟;

    public static 땓.딟 딟([In] 딶.땖 obj0, [In] 딢.딴 obj1, [In] int obj2, [In] 딶.땩 obj3)
    {
      땓.딟 딟 = new 땓.딟();
      딟.딟((딶.땏) new 딶.떑("----------------- ActionAttackUnit ------------------- "));
      땫.딟(딟, obj0, obj2, obj1, obj3, 1f, 딤.딟);
      return 딟;
    }
  }
}
