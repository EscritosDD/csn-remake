// Decompiled with JetBrains decompiler
// Type: 땺.땿
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using FarseerPhysics.Collision;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using 땥;

namespace 땺
{
  public class 땿 : 땏
  {
    public 땨 딟;
    private 떁 딟;
    private 떁 땄;
    private bool 딟;
    private bool 땄;

    private 땿()
      : base(0.0f)
    {
      this.딟(땙.땃);
      base.땄 = 0.01f;
    }

    public 땿([In] 땨 obj0)
      : base(0.0f)
    {
      this.딟(땙.땃);
      base.땄 = 0.01f;
      if (딝.땥.딶)
        this.딟 = obj0;
      else
        this.딟 = new 땨((IList<떁>) obj0);
    }

    public void 딟([In] 땨 obj0)
    {
      this.딟 = new 땨((IList<떁>) obj0);
      this.딟.Add(obj0[0]);
      this.딟 = this.딟[this.딟.Count - 2];
      this.땄 = this.딟[1];
      this.딟 = true;
      this.땄 = true;
    }

    public void 땄([In] 땨 obj0)
    {
      this.딟 = new 땨((IList<떁>) obj0);
      this.딟 = false;
      this.땄 = false;
    }

    [SpecialName]
    public override int 딟() => this.딟.Count - 1;

    public override 땏 땄()
    {
      땿 땿 = new 땿();
      ((땏) 땿).딟 = base.딟;
      ((땏) 땿).땄 = base.땄;
      땿.딟 = this.딟;
      ((땏) 땿).딟 = base.딟;
      return (땏) 땿;
    }

    public void 딟([In] 떁 obj0)
    {
      this.딟 = obj0;
      this.딟 = true;
    }

    public void 땄([In] 떁 obj0)
    {
      this.땄 = obj0;
      this.땄 = true;
    }

    public void 딟([In] ref 땖 obj0, [In] int obj1)
    {
      obj0.딟(땙.딧);
      ((땏) obj0).땄 = base.땄;
      obj0.딟(this.딟[obj1]);
      obj0.땄(this.딟[obj1 + 1]);
      if (obj1 > 0)
      {
        obj0.딟 = this.딟[obj1 - 1];
        obj0.딟 = true;
      }
      else
      {
        obj0.딟 = this.딟;
        obj0.딟 = this.딟;
      }
      if (obj1 < this.딟.Count - 2)
      {
        obj0.땄 = this.딟[obj1 + 2];
        obj0.땄 = true;
      }
      else
      {
        obj0.땄 = this.땄;
        obj0.땄 = this.땄;
      }
    }

    public override bool 딟([In] ref 땥.떓 obj0, [In] ref 떁 obj1) => false;

    public override bool 딟(out 딯 _param1, [In] ref 딮 obj1, [In] ref 땥.떓 obj2, [In] int obj3)
    {
      땖 땖 = new 땖();
      int index1 = obj3;
      int index2 = obj3 + 1;
      if (index2 == this.딟.Count)
        index2 = 0;
      땖.딟(this.딟[index1]);
      땖.땄(this.딟[index2]);
      return 땖.딟(out _param1, ref obj1, ref obj2, 0);
    }

    public override void 딟(out AABB _param1, [In] ref 땥.떓 obj1, [In] int obj2)
    {
      int index1 = obj2;
      int index2 = obj2 + 1;
      if (index2 == this.딟.Count)
        index2 = 0;
      떁 떁1 = 땥.땴.딟(ref obj1, this.딟[index1]);
      떁 떁2 = 땥.땴.딟(ref obj1, this.딟[index2]);
      _param1.LowerBound = 떁.땺(떁1, 떁2);
      _param1.UpperBound = 떁.땓(떁1, 떁2);
    }

    protected override void 딧()
    {
    }

    public override float 딟([In] 떁 obj0, [In] float obj1, [In] 땥.떓 obj2, out 떁 _param4)
    {
      _param4 = 떁.딟();
      return 0.0f;
    }
  }
}
