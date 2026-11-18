// Decompiled with JetBrains decompiler
// Type: 딶.떔
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 떔 : 땁, 땉
  {
    private int 딟;
    private DeployableCoverGameObjectComponent 딟;
    private 딢.딴 딟;

    public 떔([In] 땖 obj0, [In] int obj1, [In] int obj2, [In] 딢.딴 obj3)
      : base(obj1)
    {
      this.딟 = obj2;
      this.딟 = obj3;
      this.딟(obj0);
    }

    public override 땓.땑 떁() => 땓.땑.땃;

    public override bool 딧([In] 땓.땊 obj0) => obj0.딧 > 0;

    public override bool 땃() => true;

    public override bool 땄([In] 땓.땊 obj0) => obj0.땓() && !obj0.땺();

    public override Material 땟() => this.딟.UnitIcon;

    public override string 땂() => 딧.딪.딟(this.딟.UnitName);

    public override bool 땄([In] 딢.딴 obj0) => false;

    public override bool 딦() => true;

    public override string 딟([In] 땓.땊 obj0, [In] 땓.딺 obj1)
    {
      땓.딺 딺 = obj1;
      switch (딺)
      {
        case 땓.딺.땓:
          return "Hit";
        case 땓.딺.땺:
          return "Death";
        case 땓.딺.떎:
          return "Deploy";
        case 땓.딺.땭:
          return "Idle01";
        default:
          if (딺 == 땓.딺.딟)
            goto case 땓.딺.땭;
          else
            goto case 땓.딺.땭;
      }
    }

    public override Transform 딟([In] 땓.딺 obj0) => obj0 == 땓.딺.땺 ? this.딟.DeathEffectPrefab : (Transform) null;

    public override AudioShader2 딟([In] 땓.딘 obj0)
    {
      switch (obj0)
      {
        case 땓.딘.떏:
          return this.딟.Deploy1Shader;
        case 땓.딘.땼:
          return this.딟.Deploy2Shader;
        case 땓.딘.땢:
          return this.딟.Deploy3Shader;
        case 땓.딘.때:
          return this.딟.Hit2Shader;
        case 땓.딘.땩:
          return this.딟.Death2Shader;
        case 땓.딘.땠:
          return this.딟.Death3Shader;
        default:
          return (AudioShader2) null;
      }
    }

    public override int 딟([In] 땙 obj0, [In] 땓.딲 obj1, [In] int obj2, [In] bool obj3, [In] bool obj4)
    {
      땓.땊 땊 = obj0.땺()[base.딟()];
      return !땊.땺() && 땊.땓() ? -1 : 0;
    }

    public override 땓.딵 땼() => 땓.딵.딧;

    public 딢.딴 딟() => this.딟;

    public int 땄() => this.딟;

    public override int 딱() => base.땄().땞().땥().MaxHealth;

    public override Transform 때() => this.딟.SecondaryModelPrefab;

    public override Transform 땩() => this.딟.SecondaryModelPrefab;

    public Transform 딗() => this.딟.ModelPrefab;

    public Transform 땳() => this.딟.SkeletonPrefab;

    public int 땺() => base.땄().땞().땥().RequiredAP;

    public new int 땥() => base.땄().땞().땥().MinRange;

    public int 딝() => base.땄().땞().땥().MaxRange;

    public new bool 떎() => false;

    public override void 딟([In] List<딟.땩> obj0, [In] 땓.땾 obj1) => obj0.Add((딟.땩) GlobalAppData.땼().땁(GlobalAppData.딟.DeployableCoverPrefabId));

    public override void 땠()
    {
      GameObject gameObject = GlobalAppData.땼().땋(GlobalAppData.딟.DeployableCoverPrefabId);
      if (!Object.op_Inequality((Object) gameObject, (Object) null))
        return;
      this.딟 = gameObject.GetComponent<DeployableCoverGameObjectComponent>();
    }

    public override void 땴() => this.딟 = (DeployableCoverGameObjectComponent) null;

    public new bool 땭() => false;
  }
}
