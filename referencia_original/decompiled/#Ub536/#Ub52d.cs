// Decompiled with JetBrains decompiler
// Type: 딶.딭
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 딶
{
  public class 딭 : 떒
  {
    private new int 딟;
    private int 땄;
    private int 딧;

    public 딭([In] int obj0, [In] int obj1, [In] int obj2)
      : base(0.2f)
    {
      this.딟 = obj0;
      this.땄 = obj1;
      this.딧 = obj2;
    }

    protected override void 딟()
    {
      base.딟();
      땇 땇 = (땇) 딡.땴().딷();
      땇.딟(this.딟).딟(땓.땊.딟(땇.딟(this.딟).땴().딟));
      땇.딟(this.딟, this.땄, this.딧);
    }

    public override void 딟([In] bool obj0)
    {
      base.딟(obj0);
      땇 땇 = (땇) 딡.땴().딷();
      땇.딟().딟.ClearCinematics();
      땇.딟(this.딟, this.땄, this.딧);
    }

    public override string ToString() => string.Format("[ActionDisplayPlaceUnit] Unit: {0} - Pos: ({1}, {2} )", (object) this.딟, (object) this.땄, (object) this.딧);
  }
}
