// Decompiled with JetBrains decompiler
// Type: 딶.땱
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 땱 : 땣
  {
    private 땙 딟;

    public 땱([In] 땖 obj0, [In] 땙 obj1, [In] int obj2, [In] string obj3)
      : base(obj2, obj3)
    {
      this.딟 = obj1;
    }

    protected override void 딟()
    {
      if (this.딟.땺()[((땏) this).딟].땺())
      {
        base.딟();
      }
      else
      {
        ((떒) this).딟 = 1f;
        this.딧(((땏) this).딟);
        this.땄(true);
        ((떒) this).땄 = Time.time + ((떒) this).딟;
      }
    }

    public override string ToString() => string.Format("[PlayDeathAnimationCinematicEvent]: Playing Animation {0}", (object) base.딟);
  }
}
