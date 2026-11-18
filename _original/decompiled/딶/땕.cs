// Decompiled with JetBrains decompiler
// Type: 딶.땕
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public abstract class 땕 : 땁, 땉
  {
    protected UnitWeapon 딟;

    public 땕([In] 땖 obj0, [In] int obj1, [In] int obj2)
      : base(obj1)
    {
      this.딟(obj2);
      this.딟(obj0);
    }

    [CompilerGenerated]
    [SpecialName]
    public int 딗() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    protected new void 딟([In] int obj0) => this.딟 = obj0;

    public override UnitWeapon 딢() => this.딟;

    public override bool 땄([In] 딢.딴 obj0) => obj0 == 딢.딴.땄;

    public override 땓.땑 떁() => 땓.땑.딧;

    public override int 딟([In] 딢.딴 obj0) => 1;

    public override int 땓() => 5;

    public override bool 떂() => true;

    public override bool 딦() => true;

    public override bool 딧([In] 땓.땊 obj0) => obj0.딧 > 0;

    public override bool 땃() => true;

    public override string 딟([In] 땓.땊 obj0, [In] 땓.딺 obj1)
    {
      bool flag = obj0.딢(딢.떍.딧) > 0;
      switch (obj1)
      {
        case 땓.딺.땄:
          return "Fire";
        case 땓.딺.딧:
          return "Turn_R";
        case 땓.딺.딢:
          return "Turn_L";
        case 땓.딺.땃:
          return "Turn_180";
        case 땓.딺.딶:
          return "Walk";
        case 땓.딺.땓:
          return "Hit";
        case 땓.딺.땺:
          return "Death";
        case 땓.딺.딝:
          return "Throw";
        case 땓.딺.떎:
          return "Deploy";
        case 땓.딺.떂:
          return "Recover";
        default:
          return flag ? "Disable_Idle" : "Idle_01";
      }
    }

    public override Transform 딟([In] 땓.딺 obj0) => (Transform) null;

    public override int 딟([In] 땙 obj0, [In] 땓.딲 obj1, [In] int obj2, [In] bool obj3, [In] bool obj4)
    {
      땓.땊 땊 = obj0.땺()[base.딟()];
      return 땊.땄 == obj2 || 땊.땺() || !땊.땓() ? 0 : -1;
    }

    public override bool 딟([In] 땓.땊 obj0, [In] int obj1) => true;

    public abstract 딢.딴 딟();

    public int 땄() => this.딗();

    public override void 딟([In] int obj0, [In] 땺.땃 obj1) => obj1.딟(obj0, this.딗());

    public abstract int 땺();

    public new int 땥() => 1;

    public int 딝() => 1;

    public new bool 떎() => false;

    public new bool 땭() => false;
  }
}
