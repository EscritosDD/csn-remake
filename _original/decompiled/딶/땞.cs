// Decompiled with JetBrains decompiler
// Type: 딶.땞
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 땞 : 땁, 땉
  {
    private RemoteChargeGameObjectComponent 딟;
    private UnitWeapon 딟;

    public 땞([In] 땖 obj0, [In] int obj1, [In] int obj2)
      : base(obj1)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj2);
      this.딟(obj0);
    }

    [CompilerGenerated]
    [SpecialName]
    public int 딗() => this.딟;

    public override 땓.땑 떁() => 땓.땑.딧;

    public override UnitWeapon 딢() => this.딟;

    public override Material 땟() => this.딟.UnitIcon;

    public override string 땂() => 딧.딪.딟(this.딟.UnitName);

    public override int 딟([In] 땓.땊 obj0) => 1;

    public override Transform 때() => (Transform) null;

    public override bool 딧([In] 땓.땊 obj0) => false;

    public override bool 떂() => true;

    public override bool 땤() => true;

    public override bool 땽() => true;

    public override string 딟([In] 땓.땊 obj0, [In] 땓.딺 obj1) => (string) null;

    public override Transform 딟([In] 땓.딺 obj0) => (Transform) null;

    public override bool 땢() => false;

    public override bool 딷() => false;

    public override int 딟([In] 딢.딴 obj0) => obj0 == 딢.딴.땩 ? 10 : base.딟(obj0);

    public override void 딟([In] List<딟.땩> obj0, [In] 땓.땾 obj1)
    {
      obj0.Add((딟.땩) GlobalAppData.땼().땔(this.딧()));
      obj0.Add((딟.땩) GlobalAppData.땼().땁(GlobalAppData.딟.RemoteChargePrefabId));
    }

    public override void 땠()
    {
      this.딟 = GlobalAppData.땼().땽(this.딧());
      GameObject gameObject = GlobalAppData.땼().땋(GlobalAppData.딟.RemoteChargePrefabId);
      if (!Object.op_Inequality((Object) gameObject, (Object) null))
        return;
      this.딟 = gameObject.GetComponent<RemoteChargeGameObjectComponent>();
    }

    public override void 땴()
    {
      this.딟 = (UnitWeapon) null;
      this.딟 = (RemoteChargeGameObjectComponent) null;
    }

    public override string 딧() => base.땄().땞().땺().WeaponId;

    public override AudioShader2 딟([In] 땓.딘 obj0) => obj0 == 땓.딘.떏 ? this.딟.DeployedShader : (AudioShader2) null;

    public override int 딟([In] 땙 obj0, [In] 땓.딲 obj1, [In] int obj2, [In] bool obj3, [In] bool obj4)
    {
      땓.땊 땊 = obj0.땺()[base.딟()];
      return obj3 && obj4 && !땊.땺() && 땊.땄 != obj2 ? 10 : 0;
    }

    public override 땓.딵 땼() => 땓.딵.딧 | 땓.딵.땓;

    public override bool 딟([In] 땓.땊 obj0, [In] int obj1) => obj0.땄 == obj1 || obj0.딢(딢.떍.떏) > 0;

    public 딢.딴 딟() => 딢.딴.딸;

    public int 땄() => this.딗();

    public override int 딱() => base.땄().땞().땺().MaxHealth;

    public override Transform 땩() => this.딟.ModelPrefab;

    public override bool 땄([In] 딢.딴 obj0) => obj0 == 딢.딴.땄 || obj0 == 딢.딴.딸;

    public int 땺() => base.땄().땞().땺().RequiredAP;

    public new int 땥() => base.땄().땞().땺().MinRange;

    public int 딝() => base.땄().땞().땺().MaxRange;

    public new bool 떎() => true;

    public new bool 땭() => false;
  }
}
