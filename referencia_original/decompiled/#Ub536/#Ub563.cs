// Decompiled with JetBrains decompiler
// Type: 딶.땣
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 땣 : 떒
  {
    protected string 딟;
    protected WrapMode 딟;
    protected new int 딟 = -1;
    protected int 땄 = -1;
    protected new bool 딟;

    public 땣([In] int obj0, [In] string obj1)
      : this(obj0, obj1, (WrapMode) 1, false)
    {
    }

    public 땣([In] int obj0, [In] string obj1, [In] WrapMode obj2, [In] bool obj3)
      : base(obj0)
    {
      this.딟(obj1, obj2, -1, -1, obj3);
    }

    public 땣([In] int obj0, [In] string obj1, [In] WrapMode obj2, [In] 땮 obj3)
      : base(obj0)
    {
      this.딟(obj1, obj2, (int) obj3, -1, false);
    }

    public 땣([In] int obj0, [In] string obj1, [In] WrapMode obj2, [In] 땮 obj3, [In] 땮 obj4)
      : base(obj0)
    {
      this.딟(obj1, obj2, (int) obj3, (int) obj4, false);
    }

    private void 딟([In] string obj0, [In] WrapMode obj1, [In] int obj2, [In] int obj3, [In] bool obj4)
    {
      this.딟 = obj0;
      this.딟 = obj1;
      this.딟 = obj2;
      this.땄 = obj3;
      this.딟 = obj4;
    }

    protected override void 딟()
    {
      if (!this.딟)
      {
        땓.땦 땦 = 딡.땴().딷().딟(((땏) this).딟);
        base.딟 = this.딟 != null ? 땦.딟(this.딟, this.딟) : 0.0f;
      }
      base.딟();
    }

    public override void 딟([In] bool obj0)
    {
      땓.땦 땦 = 딡.땴().딷().딟(((땏) this).딟);
      if (this.딟 && this.딟 != null)
      {
        double num = (double) 땦.딟(this.딟, this.딟);
      }
      base.딟(obj0);
    }

    public override string ToString() => string.Format("[PlayAnimationCinematicEvent]: Playing Animation {0}", (object) this.딟);

    public override bool 딟([In] int obj0, [In] 땮 obj1)
    {
      if (!base.딟(obj0, obj1) || this.딟 == -1)
        return false;
      if ((땮) this.딟 == obj1)
        this.딧(true);
      if (!this.땃())
        return false;
      if ((땮) this.땄 == obj1)
        this.땄(false);
      return true;
    }
  }
}
