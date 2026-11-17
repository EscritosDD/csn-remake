// Decompiled with JetBrains decompiler
// Type: 딶.땧
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 땧 : 떒
  {
    protected new bool 딟;
    protected bool 땄;

    public 땧([In] 땩 obj0, [In] bool obj1, [In] float obj2)
      : base(obj2)
    {
      this.딟(obj0, -1, obj1, false);
    }

    public 땧([In] int obj0, [In] bool obj1, [In] float obj2)
      : base(obj2)
    {
      this.딟(땩.딟, obj0, obj1, false);
    }

    public 땧([In] int obj0, [In] bool obj1, [In] float obj2, [In] bool obj3)
      : base(obj2)
    {
      this.딟(땩.딟, obj0, obj1, obj3);
    }

    private void 딟([In] 땩 obj0, [In] int obj1, [In] bool obj2, [In] bool obj3)
    {
      ((땏) this).딟 = obj0;
      ((땏) this).딟 = obj1;
      this.딟 = obj2;
      this.땄 = obj3;
    }

    public override void 딟([In] bool obj0)
    {
      base.딟(obj0);
      땓.땦 땦 = 딡.땴().딷().딟(((땏) this).딟);
      if (땦 == null)
      {
        Debug.LogError((object) string.Format("Unit '{0}' doesn't exist", (object) ((땏) this).딟));
      }
      else
      {
        땦.딟(this.딟, this.땄);
        딡.땴().딷().딟(((땏) this).딟, 땦.땴().땃, 땦.땴().딶);
      }
    }

    public override string ToString() => ((땏) this).딟 >= 0 ? string.Format("[ShowObjectCinematicEvent]: Showing Object {0} -> {1}", (object) ((땏) this).딟, (object) this.딟) : string.Format("[ShowObjectCinematicEvent]: Showing Object on position {0} -> {1}", (object) ((땏) this).딟, (object) this.딟);
  }
}
