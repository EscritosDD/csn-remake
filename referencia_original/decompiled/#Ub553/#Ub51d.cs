// Decompiled with JetBrains decompiler
// Type: 땓.딝
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 땓
{
  public class 딝 : 딦
  {
    private 딢.딯 딟;

    public 딝([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 떒 obj2, [In] int obj3, [In] 딶.땩 obj4, [In] 딢.딯 obj5)
      : base(obj0, obj1, obj2, obj3, obj4)
    {
      this.딟 = obj5;
    }

    public override void 딟([In] bool obj0)
    {
      base.딟(obj0);
      땊 땊 = base.딟.땺()[((딶.땏) this).딟];
      땊.땃 = ((딶.땏) this).딟.딟;
      땊.딶 = ((딶.땏) this).딟.땄;
      땊.딟 = this.딟;
    }

    public override string ToString() => string.Format("[SetUnitPositionLogicEvent] Pos: {0} Dir: {1} ", (object) ((딶.땏) this).딟, (object) this.딟);
  }
}
