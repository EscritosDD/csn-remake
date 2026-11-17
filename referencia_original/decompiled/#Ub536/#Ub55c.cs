// Decompiled with JetBrains decompiler
// Type: 딶.땜
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 땜 : 땁, 땚
  {
    private int 딟;

    public 땜([In] 땖 obj0, [In] int obj1, [In] int obj2)
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
      땓.땊 땊1 = obj0.땺()[this.딟];
      땓.땊 땊2 = obj0.땺()[obj1];
      if (땊1.땄(땊2) > base.땄().땞().땤().MaxRange || 땊2.땺() || !땊2.땓())
        return false;
      if (땊1.땄 != 땊2.땄)
      {
        if (!base.땄().땻()[obj1].땤())
          return false;
      }
      else if (!base.땄().땻()[obj1].딦() || base.땄().땻()[obj1].딱() == 땊2.딧)
        return false;
      return true;
    }

    public override bool 딟([In] 땓.딲 obj0, [In] 땓.땊 obj1, [In] 땓.땊 obj2) => true;

    public override bool 딟([In] 땓.땊 obj0, [In] int obj1) => true;

    public 딢.딴 딢() => 딢.딴.땩;

    public int 딧() => this.딟;

    public override int 딱() => 0;

    public override Transform 땩() => (Transform) null;

    public int 땄() => base.땄().땞().딟(딢.딴.땩).MaxUses;

    public int 땃() => base.땄().땞().땤().RequiredAP;

    public 땓.떊 땓() => base.땄().땞().땤().XPForUse;

    public void 딟([In] 땙 obj0, [In] int obj1, [In] 땓.딟 obj2, [In] 땓.떒 obj3)
    {
      땓.땊 땊1 = obj0.땺()[this.딟];
      땓.땊 땊2 = obj0.땺()[obj1];
      if (땊1.땄 != 땊2.땄)
      {
        obj2.딟((땏) new 땊(obj1, ((Component) GlobalAppData.딟.GameAssets.DefuseEffectPrefab).gameObject, GlobalAppData.딟.GameAssets.DefuseEffectDuration, -1f));
        obj2.딟((땏) new 땑(GlobalAppData.딟.GameAssets.DamageText, base.땄().땹().GetTileCentre(땊2.땃, 땊2.딶), "-" + (object) 땊2.딧, 0.0f, 1f));
        obj2.딟((땏) new 땓.땄(base.땄(), obj0, obj3, obj1, -땊2.딧));
        obj2.딟((땏) new 떊(obj1));
      }
      else
      {
        int healAmount = base.땄().땞().딟(딢.딴.땩).HealAmount;
        int 딧 = 땊2.딧;
        int num1 = base.땄().땻()[obj1].딱();
        int num2 = Mathf.Min(딧 + healAmount, num1);
        obj2.딟((땏) new 땊(obj1, ((Component) GlobalAppData.딟.GameAssets.RepairEffectPrefab).gameObject, 0.0f, GlobalAppData.딟.GameAssets.RepairEffectDuration));
        obj2.딟((땏) new 땑(GlobalAppData.딟.GameAssets.HealingText, base.땄().땹().GetTileCentre(땊2.땃, 땊2.딶), "+" + (object) healAmount, 0.0f, 1f));
        obj2.딟((땏) new 땓.땄(base.땄(), obj0, obj3, obj1, num2 - 딧));
        obj2.딟((땏) new 땓.땃(base.땄(), obj0, obj3, obj1, 딢.떍.딧, 땓.딢.땄, -1));
      }
    }
  }
}
