// Decompiled with JetBrains decompiler
// Type: 땓.땄
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 땓
{
  public class 땄 : 딦
  {
    protected new int 딟;

    public 땄([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 떒 obj2, [In] int obj3, [In] int obj4)
      : base(obj0, obj1, obj2, obj3)
    {
      this.딟 = obj4;
    }

    public override void 딟([In] bool obj0)
    {
      if (((딶.땏) this).딟 < 0 || ((딶.땏) this).딟 >= base.딟.땺().Count)
        return;
      땊 땊 = base.딟.땺()[((딶.땏) this).딟];
      땊.딧 += this.딟;
      땊.딧 = Mathf.Clamp(땊.딧, 0, base.딟.땻()[((딶.땏) this).딟].딱());
      base.딟(obj0);
    }

    public override string ToString() => string.Format("[ChangeHealthLogicEvent] Amount:{0} Unit Health:{1}", (object) this.딟, (object) base.딟.땺()[((딶.땏) this).딟].딧);
  }
}
