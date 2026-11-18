// Decompiled with JetBrains decompiler
// Type: 땓.땥
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 땓
{
  public class 땥 : 딦
  {
    private 땃.땦 딟;

    public 땥([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 떒 obj2, [In] int obj3, [In] 땃.땦 obj4)
      : base(obj0, obj1, obj2, obj3)
    {
      this.딟 = obj4;
    }

    public override void 딟([In] bool obj0)
    {
      base.딟(obj0);
      땓.딟 timeline = new 땓.딟();
      땃.땫.딟(timeline, base.딟, ((딶.땏) this).딟, this.딟);
      if (obj0)
        timeline.땄(딶.딡.땴() != null);
      else
        EventTimelineManager.딟().AddEventTimeline(timeline);
    }
  }
}
