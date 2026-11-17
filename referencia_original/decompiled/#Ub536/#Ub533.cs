// Decompiled with JetBrains decompiler
// Type: 딶.딳
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 딳 : 땁, 땚
  {
    private int 딟;

    public 딳([In] 땖 obj0, [In] int obj1, [In] int obj2)
      : base(obj1)
    {
      this.딟 = obj2;
      this.딟(obj0);
    }

    public override 땓.땑 떁() => 땓.땑.딟;

    public override Material 땟() => (Material) null;

    public override string 땂() => (string) null;

    public override bool 땄([In] 딢.딴 obj0) => false;

    public override Transform 때() => (Transform) null;

    public override bool 딧([In] 땓.땊 obj0) => false;

    public override bool 땽() => false;

    public override string 딟([In] 땓.땊 obj0, [In] 땓.딺 obj1) => (string) null;

    public override Transform 딟([In] 땓.딺 obj0) => (Transform) null;

    public override bool 땄([In] 땓.땊 obj0) => false;

    public override int 딟([In] 땙 obj0, [In] 땓.딲 obj1, [In] int obj2, [In] bool obj3, [In] bool obj4) => 0;

    public override AudioShader2 딟([In] 땓.딘 obj0) => (AudioShader2) null;

    public override void 딟([In] List<딟.땩> obj0, [In] 땓.땾 obj1)
    {
    }

    public override void 땠()
    {
    }

    public override void 땴()
    {
    }

    public override int 딱() => 0;

    public override Transform 땩() => (Transform) null;

    public override bool 딟([In] 땓.딲 obj0, [In] 땓.땊 obj1, [In] 땓.땊 obj2) => true;

    public override bool 땢() => true;

    public override bool 딷() => false;

    public bool 딟() => false;

    public int 땄() => base.땄().땞().딧().MaxUses;

    public int 딧() => this.딟;

    public 딢.딴 딢() => 딢.딴.땻;

    public int 땃() => base.땄().땞().딧().RequiredAP;

    public 땓.떊 땓() => base.땄().땞().딧().XPForUse;

    public bool 딟([In] 땙 obj0, [In] int obj1) => obj1 == this.딟;

    public void 딟([In] 땙 obj0, [In] int obj1, [In] 땓.딟 obj2, [In] 땓.떒 obj3)
    {
      int duration = base.땄().땞().딟(딢.딴.땻).Duration;
      obj2.딟((땏) new 땓.땃(base.땄(), obj0, obj3, obj1, 딢.떍.떏, 땓.딢.땄, -1));
      obj2.딟((땏) new 땓.땃(base.땄(), obj0, obj3, obj1, 딢.떍.딢, 땓.딢.딟, duration));
      obj2.딟((땏) new 떊(obj1));
    }
  }
}
