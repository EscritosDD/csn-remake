// Decompiled with JetBrains decompiler
// Type: 딶.땝
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 땝 : 땁, 땚
  {
    public 땝([In] 땖 obj0, [In] int obj1, [In] int obj2)
      : base(obj1)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj2);
      this.딟(obj0);
    }

    [CompilerGenerated]
    [SpecialName]
    public int 딗() => this.딟;

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

    public override bool 딟([In] 땓.땊 obj0, [In] int obj1) => true;

    public bool 딟() => false;

    public int 땄() => base.땄().땞().딶().MaxUses;

    public int 딧() => this.딗();

    public 딢.딴 딢() => 딢.딴.딣;

    public int 땃() => base.땄().땞().딶().RequiredAP;

    public 땓.떊 땓() => base.땄().땞().딶().XPForUse;

    public bool 딟([In] 땙 obj0, [In] int obj1) => obj1 == this.딗() && obj0.땺()[obj1].딢(딢.떍.딷) <= 0;

    public void 딟([In] 땙 obj0, [In] int obj1, [In] 땓.딟 obj2, [In] 땓.떒 obj3) => obj2.딟((땏) new 땓.땃(base.땄(), obj0, obj3, obj1, 딢.떍.딷, 땓.딢.딟, 1));
  }
}
