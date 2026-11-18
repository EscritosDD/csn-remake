// Decompiled with JetBrains decompiler
// Type: 땓.땃
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 땓
{
  public class 땃 : 딦
  {
    private 딢.떍 딟;
    private 땓.딢 딟;
    private new int 딟;

    public 땃([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 떒 obj2, [In] int obj3, [In] 딢.떍 obj4, [In] 땓.딢 obj5, [In] int obj6)
      : base(obj0, obj1, obj2, obj3)
    {
      this.딟 = obj4;
      this.딟 = obj5;
      this.딟 = obj6;
    }

    public override void 딟([In] bool obj0)
    {
      base.딟(obj0);
      땊 땊 = base.딟.땺()[((딶.땏) this).딟];
      switch (this.딟)
      {
        case 땓.딢.딟:
          땊.딟(this.딟, this.딟);
          break;
        case 땓.딢.땄:
          땊.딧(this.딟);
          break;
        case 땓.딢.딧:
          땊.땄(this.딟);
          break;
        case 땓.딢.딢:
          땊.딟(this.딟);
          break;
      }
    }

    public override string ToString() => string.Format("[ChangeUnitBuffLogicEvent] Buff:{0} Method:{1} Turns:{2}", (object) this.딟, (object) this.딟, (object) this.딟);
  }
}
