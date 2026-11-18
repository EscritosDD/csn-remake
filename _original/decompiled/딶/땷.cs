// Decompiled with JetBrains decompiler
// Type: 딶.땷
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 땷 : 땁, 땉
  {
    protected int 딟;
    protected BeaconGameObjectComponent 딟;

    public 땷([In] 땖 obj0, [In] int obj1, [In] int obj2, [In] 딢.딴 obj3)
      : base(obj1)
    {
      this.딟 = obj2;
      // ISSUE: reference to a compiler-generated method
      this.딧(obj3);
      this.딟(obj0);
    }

    [CompilerGenerated]
    [SpecialName]
    public 딢.딴 딗() => this.딟;

    public override 땓.땑 떁() => 땓.땑.딧;

    public override int 딱() => 1;

    public override Transform 때() => this.딟.ModelPrefab;

    public override Transform 땩() => this.딟.SkeletonPrefab;

    public override string 딟([In] 땓.땊 obj0, [In] 땓.딺 obj1) => (string) null;

    public override Transform 딟([In] 땓.딺 obj0) => (Transform) null;

    public override int 딟([In] 땙 obj0, [In] 땓.딲 obj1, [In] int obj2, [In] bool obj3, [In] bool obj4) => 0;

    public override UnitWeapon 딢() => GlobalAppData.딟.땤();

    public override string 딧() => GlobalAppData.딟.GrenadeMarkerWeaponId;

    public override bool 땄([In] 딢.딴 obj0) => obj0 == 딢.딴.땚 && obj0 == this.딗();

    public override Material 땟()
    {
      switch (this.딗())
      {
        case 딢.딴.땈:
          return this.딟.UnitIconHealth;
        case 딢.딴.땞:
          return this.딟.UnitIconHighVelocityAmmo;
        case 딢.딴.땜:
          return this.딟.UnitIconPainKillers;
        case 딢.딴.땪:
          return this.딟.UnitIconTeamSpirit;
        case 딢.딴.땚:
          return this.딟.UnitIconDetectoSweep;
        default:
          return this.딟.UnitIconUnknown;
      }
    }

    public override string 땂()
    {
      switch (this.딗())
      {
        case 딢.딴.땈:
          return 딧.딪.딟(this.딟.UnitNameHealth);
        case 딢.딴.땞:
          return 딧.딪.딟(this.딟.UnitNameHighVelocityAmmo);
        case 딢.딴.땜:
          return 딧.딪.딟(this.딟.UnitNamePainKillers);
        case 딢.딴.땪:
          return 딧.딪.딟(this.딟.UnitNameTeamSpirit);
        case 딢.딴.땚:
          return 딧.딪.딟(this.딟.UnitNameDetectoSweep);
        default:
          return 딧.딪.딟(this.딟.UnitNameUnknown);
      }
    }

    public override bool 딧([In] 땓.땊 obj0) => false;

    public override bool 땃() => false;

    public override bool 딶() => false;

    public override bool 딟([In] 땓.땊 obj0, [In] int obj1) => this.딗() != 딢.딴.땚;

    public override 땓.딵 땼() => 땓.딵.딧 | 땓.딵.딢;

    public override AudioShader2 딟([In] 땓.딘 obj0) => this.딟.DeployedShader;

    public override bool 땢() => false;

    public override bool 딷() => false;

    public override bool 땽() => false;

    public 딢.딴 딟() => this.딗();

    public int 땄() => this.딟;

    public int 땺()
    {
      switch (this.딗())
      {
        case 딢.딴.땈:
          return base.땄().땞().떏().RequiredAP;
        case 딢.딴.땞:
          return base.땄().땞().땼().RequiredAP;
        case 딢.딴.땜:
          return base.땄().땞().땢().RequiredAP;
        case 딢.딴.땪:
          return base.땄().땞().딷().RequiredAP;
        case 딢.딴.땚:
          return base.땄().땞().딱().RequiredAP;
        default:
          return 0;
      }
    }

    public new int 땥()
    {
      switch (this.딗())
      {
        case 딢.딴.땈:
          return base.땄().땞().떏().MinRange;
        case 딢.딴.땞:
          return base.땄().땞().땼().MinRange;
        case 딢.딴.땜:
          return base.땄().땞().땢().MinRange;
        case 딢.딴.땪:
          return base.땄().땞().딷().MinRange;
        case 딢.딴.땚:
          return base.땄().땞().딱().MinRange;
        default:
          return 1;
      }
    }

    public int 딝()
    {
      switch (this.딗())
      {
        case 딢.딴.땈:
          return base.땄().땞().떏().MaxRange;
        case 딢.딴.땞:
          return base.땄().땞().땼().MaxRange;
        case 딢.딴.땜:
          return base.땄().땞().땢().MaxRange;
        case 딢.딴.땪:
          return base.땄().땞().딷().MaxRange;
        case 딢.딴.땚:
          return base.땄().땞().딱().MaxRange;
        default:
          return 1;
      }
    }

    public new bool 떎() => true;

    public new bool 땭() => this.딗() != 딢.딴.땚;

    public override void 딟([In] List<딟.땩> obj0, [In] 땓.땾 obj1) => obj0.Add((딟.땩) GlobalAppData.땼().땁(GlobalAppData.딟.BeaconPrefabId));

    public override void 땠()
    {
      GameObject gameObject = GlobalAppData.땼().땋(GlobalAppData.딟.BeaconPrefabId);
      if (!Object.op_Inequality((Object) gameObject, (Object) null))
        return;
      this.딟 = gameObject.GetComponent<BeaconGameObjectComponent>();
    }

    public override void 땴() => this.딟 = (BeaconGameObjectComponent) null;
  }
}
