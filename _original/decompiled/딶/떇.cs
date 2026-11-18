// Decompiled with JetBrains decompiler
// Type: 딶.떇
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 떇 : 땁, 땚
  {
    public 떇([In] 땖 obj0, [In] int obj1, [In] int obj2)
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

    public override bool 딶() => false;

    public override bool 땽() => false;

    public override string 딟([In] 땓.땊 obj0, [In] 땓.딺 obj1) => (string) null;

    public override Transform 딟([In] 땓.딺 obj0) => (Transform) null;

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

    public bool 딟() => true;

    public bool 딟([In] 땙 obj0, [In] int obj1)
    {
      땓.땊 땊1 = obj0.땺()[this.딗()];
      땓.땊 땊2 = obj0.땺()[obj1];
      return 땊1.땄 == 땊2.땄 && 땊1.땄(땊2) <= base.땄().땞().땃().MaxRange && base.땄().땹().TestLineOfSight(base.땄(), obj0, 땊1.땃, 땊1.딶, 땊2.땃, 땊2.딶, base.땄().땞().땃().MaxRange) && base.땄().땻()[obj1].딝() && 땊2.딧 > 0 && 땊2.딧 < base.땄().땻()[obj1].딱() && 땊1 != 땊2;
    }

    public 딢.딴 딢() => 딢.딴.떏;

    public int 딧() => this.딗();

    public override int 딱() => 0;

    public override Transform 땩() => (Transform) null;

    public int 땄() => base.땄().땞().딟(딢.딴.떏).MaxUses;

    public int 땃() => base.땄().땞().땃().RequiredAP;

    public 땓.떊 땓() => base.땄().땞().땃().XPForUse;

    public void 딟([In] 땙 obj0, [In] int obj1, [In] 땓.딟 obj2, [In] 땓.떒 obj3)
    {
      int healAmount = base.땄().땞().딟(딢.딴.떏).HealAmount;
      int num1 = base.땄().땻()[obj1].딱();
      땓.땊 땊 = obj0.땺()[obj1];
      int 딧 = 땊.딧;
      int num2 = Mathf.Min(딧 + healAmount, num1) - 딧;
      obj3.땄(obj0, this.딗(), obj1, num2);
      obj2.딟((땏) new 땓.땄(base.땄(), obj0, obj3, obj1, num2));
      obj2.딟((땏) new 땓.땃(base.땄(), obj0, obj3, obj1, 딢.떍.땓, 땓.딢.땄, -1));
      obj2.딟((땏) new 땊(obj1, ((Component) GlobalAppData.딟.HealEffectPrefab).gameObject, 0.0f, GlobalAppData.딟.HealEffectDuration));
      obj2.딟((땏) new 땑(GlobalAppData.딟.GameAssets.HealingText, base.땄().땹().GetTileCentre(땊.땃, 땊.딶), "+" + (object) num2, 0.0f, 0.0f));
      obj2.딟((땏) new 땓.땃(base.땄(), obj0, obj3, obj1, 딢.떍.땼, 땓.딢.땄, -1));
      땓.떀.딟(obj2, base.땄(), obj0, obj3, obj1);
    }
  }
}
