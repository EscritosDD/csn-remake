// Decompiled with JetBrains decompiler
// Type: 딶.땈
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 땈 : 땁, 땉
  {
    private MineGameObjectComponent 딟;

    public 땈([In] 땖 obj0, [In] int obj1, [In] int obj2)
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

    public override Material 땟() => this.딟.UnitIcon;

    public override string 땂() => 딧.딪.딟(this.딟.UnitName);

    public override bool 딧([In] 땓.땊 obj0) => false;

    public override bool 떂() => false;

    public override bool 딦() => true;

    public override bool 땤() => true;

    public override bool 땽() => true;

    public override bool 땢() => false;

    public override int 땓() => 1;

    public override int 딟([In] 딢.딴 obj0) => obj0 == 딢.딴.땩 ? 10 : base.딟(obj0);

    public override string 딟([In] 땓.땊 obj0, [In] 땓.딺 obj1)
    {
      땓.딺 딺 = obj1;
      switch (딺)
      {
        case 땓.딺.딟:
        case 땓.딺.딧:
        case 땓.딺.딢:
        case 땓.딺.땃:
          return "Idle_01";
        case 땓.딺.딶:
          return "Walk";
        default:
          if (딺 != 땓.딺.땭)
            return (string) null;
          goto case 땓.딺.딟;
      }
    }

    public override Transform 딟([In] 땓.딺 obj0) => (Transform) null;

    public override AudioShader2 딟([In] 땓.딘 obj0)
    {
      땓.딘 딘 = obj0;
      switch (딘)
      {
        case 땓.딘.땽:
          return this.딟.ActivateShader;
        case 땓.딘.떏:
          return this.딟.DeployedShader;
        default:
          if (딘 == 땓.딘.딟)
            return this.딟.MoveShader;
          return 딘 == 땓.딘.땃 ? this.딟.TrapDetectedShader : (AudioShader2) null;
      }
    }

    public override int 딟([In] 땙 obj0, [In] 땓.딲 obj1, [In] int obj2, [In] bool obj3, [In] bool obj4) => 0;

    public override bool 딟([In] 땓.땊 obj0, [In] bool obj1) => !obj0.땺() && obj0.땓();

    public override 딢.딴 딟([In] 땙 obj0, [In] int obj1)
    {
      땓.땊 땊1 = obj0.땺()[base.딟()];
      땓.땊 땊2 = obj0.땺()[obj1];
      if (base.땄().딟(obj0, base.딟(), 땊1.땃, 땊1.딶, obj1, 땊2.땃, 땊2.딶, false, false))
      {
        List<int> intList = new List<int>();
        if (땃.땫.딟(base.땄(), obj0, base.딟(), 딢.딴.땟, obj0.땺()[obj1].땃, obj0.땺()[obj1].딶, true, intList))
          return 딢.딴.땟;
      }
      return 딢.딴.딟;
    }

    public override 땓.딵 땼() => 땓.딵.딧 | 땓.딵.땓;

    public override bool 딟([In] 땓.땊 obj0, [In] int obj1) => obj0.땄 == obj1 || obj0.딢(딢.떍.떏) > 0;

    public 딢.딴 딟() => 딢.딴.땟;

    public int 땄() => this.딗();

    public override int 딱() => base.땄().땞().땓().MaxHealth;

    public override Transform 땩() => this.딟.SkeletonPrefab;

    public override Transform 때() => this.딟.ModelPrefab;

    public override bool 땄([In] 딢.딴 obj0) => obj0 == 딢.딴.땟;

    public int 땺() => base.땄().땞().땓().RequiredAP;

    public new int 땥() => base.땄().땞().땓().MinRange;

    public int 딝() => base.땄().땞().땓().MaxRange;

    public override void 딟([In] List<딟.땩> obj0, [In] 땓.땾 obj1) => obj0.Add((딟.땩) GlobalAppData.땼().땁(GlobalAppData.딟.MinePrefabId));

    public override void 땠()
    {
      GameObject gameObject = GlobalAppData.땼().땋(GlobalAppData.딟.MinePrefabId);
      if (!Object.op_Inequality((Object) gameObject, (Object) null))
        return;
      this.딟 = gameObject.GetComponent<MineGameObjectComponent>();
    }

    public override void 땴() => this.딟 = (MineGameObjectComponent) null;

    public new bool 떎() => false;

    public new bool 땭() => false;
  }
}
